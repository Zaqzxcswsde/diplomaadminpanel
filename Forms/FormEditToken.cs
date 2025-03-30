using diplomaadminpanel.Models;
using diplomaadminpanel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Foundation.Metadata;
//using Windows.Web.Http;
//using Windows.Web.Http;

namespace diplomaadminpanel.Forms
{
    public partial class FormEditToken : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int? tokenId { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal FullTokenInfo token { get; set; } = null!;


        public FormEditToken()
        {
            InitializeComponent();
        }


        public event EventHandler? PerformedSave;


        private async Task UpdateUIFromToken()
        {
            txtId.Text = token.id.ToString();
            txtFingerprint.Text = token.fingerprint!.ToString();
            txtPubkey.Text = token.pubkey!.ToString();
            if (token.user == null) txtLastActivated.Text = "<пользователь не привязан>";
            else txtLastActivated.Text = token.user_last_login == null ? "<пользователь ещё не заходил>" : token.user_last_login.ToString();
            txtUserID.Text = token.user ?? "<пользователь не привязан>";
            txtAdditionalInfo.Text = token.user_additional_data;
            txtAllowedIps.Text = token.allowed_ips?.Replace(" ", "").Replace(",", System.Environment.NewLine);

            cbIsActive.Checked = token.is_active;
            cbCanResetPassword.Checked = token.can_reset_password;
            UpdateUserRelatedUI();

            cbClearUser.Enabled = token.user != null;

            await Task.WhenAll(
                LoadHistoryWithParams(),
                LoadUsersWithParams()
            );
        }


        private bool _isUpdateTokenFromDatabaseBusy = false;
        private async Task UpdateTokenFromDatabaseAndRefetchUI()
        {
            if (_isUpdateTokenFromDatabaseBusy) { return; }
            _isUpdateTokenFromDatabaseBusy = true;
            if (tokenId != null)
            {
                await new PaginatedRequest<FullTokenInfo>(
                    usePagination: false,
                    method: HttpMethod.Get,
                    url: $"/tokens/{tokenId}",
                    onSuccess: async (StatusCode, response) =>
                    {
                        token = response;
                        await UpdateUIFromToken();
                    }
                ).FetchCurrentPage();
            }
            _isUpdateTokenFromDatabaseBusy = false;
        }


        private bool _isLoadHistoryWithParamsBusy = false;
        private async Task<HttpStatusCode> LoadHistoryWithParams()
        {
            if (_isLoadHistoryWithParamsBusy) return (HttpStatusCode)999;
            _isLoadHistoryWithParamsBusy = true;

            paginatedView1.Bind<HistoryElem>(
                method: HttpMethod.Get,
                url: "/history/",
                payload: null,
                parameters: new Dictionary<string, string?>
                {
                    ["search"] = txtHistSearch.Text,
                    ["token"] = token.id.ToString(),
                    ["msg"] = (cbSuccess.Checked, cbErr.Checked) switch
                    {
                        (true, true) => "",
                        (true, false) => "SUCCESS",
                        (false, true) => "ERR",
                        (false, false) => "INVALID"
                    }
                }
            );
            var res = await paginatedView1.FetchCurrentPage();
            _isLoadHistoryWithParamsBusy = false;

            return res;
        }


        private async void FormEditToken_Load(object sender, EventArgs e)
        {
            paginatedView1.LoadColumns(new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn {
                    Name = "colDatetime",
                    HeaderText = "Дата и время",
                    Width = 120,
                },
                new DataGridViewTextBoxColumn {
                    Name = "colIp",
                    HeaderText = "IP-адрес",
                },
                new DataGridViewCheckBoxColumn {
                    Name = "msg",
                    HeaderText = "Успешно?",
                },
                new DataGridViewTextBoxColumn {
                    Name = "result",
                    HeaderText = "Ошибка",
                    Width = 250,
                },
                new DataGridViewTextBoxColumn {
                    Name = "colInitialdata",
                    HeaderText = "Запрос",
                }
            });
            paginatedView1.SetRowBuilder<HistoryElem>((elem) =>
                [
                    elem.datetime.ToString(),
                    elem.ip ?? "",
                    elem.msg == "SUCCESS",
                    elem.result ?? "",
                    elem.initial_data ?? ""
                ]
            );

            paginatedView2.LoadColumns(new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn {
                    Name = "colAdditionalData",
                    HeaderText = "Доп. сведения",
                    Width = 350
                },
                new DataGridViewCheckBoxColumn {
                    Name = "colHasToken",
                    HeaderText = "Токен привязан?",
                },
                new DataGridViewTextBoxColumn {
                    Name = "colUuid",
                    HeaderText = "UUID",
                },
            });
            paginatedView2.SetRowBuilder<UserInfo>((elem) =>
                [
                    elem.additional_data ?? "",
                    elem.token != null,
                    elem.uuid
                ]
            );
            paginatedView2.RowDoubleClick += PaginatedView2_RowDoubleClick;

            if (token == null)
            {
                if (tokenId == null) { throw new Exception("Must set either token or tokenId"); }
                await UpdateTokenFromDatabaseAndRefetchUI();
            }
            else
            {
                tokenId = token.id;
                await UpdateUIFromToken();
            }
        }


        private void PaginatedView2_RowDoubleClick(object? sender, object e)
        {
            var userInfoObj = e as UserInfo;

            if (userInfoObj!.uuid == token.user)
            {
                MessageBox.Show(
                    $"Вы выбрали пользователя, к которому уже привязан этот токен.\nИзменения отменены.",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                //UpdateUserRelatedUi();
                return;
            }

            if (userInfoObj!.token != null)
            {
                if (MessageBox.Show(
                    $"Вы выбрали пользователя, к которому уже привязан другой токен.\nВ случае применения изменений другой токен будет отвязан от этого пользователя.\nВы уверены, что хотите продолжить?",
                    "Внимание",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                ) != DialogResult.Yes) { return; }
            }

            txtAdditionalInfo.Enabled = false;
            btnUserChangeRollback1.Enabled = true;
            btnUserChangeRollback2.Enabled = true;
            lblNewUserStatus.Text = $"Будет изменено на: {userInfoObj!.uuid}";
            lblNewUserStatus.Tag = userInfoObj.uuid;
        }


        private bool _isLoadUsersWithParamsBusy = false;
        private async Task<HttpStatusCode> LoadUsersWithParams()
        {
            if (_isLoadUsersWithParamsBusy) return (HttpStatusCode)999;
            _isLoadUsersWithParamsBusy = true;
            paginatedView2.Bind<UserInfo>(
            method: HttpMethod.Get,
            url: "/users/",
            payload: null,
            parameters: new Dictionary<string, string?>
            {
                ["search"] = txtSearchUser.Text,
            }
            );
            var res = await paginatedView2.FetchCurrentPage();
            _isLoadUsersWithParamsBusy = false;
            return res;
        }


        private List<String> hasInfoChanged()
        {
            FullTokenInfo newInfo = new();
            UpdateTokenFromUI(newInfo);

            var whatChanged = new List<String>();

            if (token.is_active != newInfo.is_active) whatChanged.Add("- Токен активен");

            if (token.can_reset_password != newInfo.can_reset_password) whatChanged.Add("- Может сбросить пароль");

            if (token.allowed_ips != newInfo.allowed_ips) whatChanged.Add("- Разрешённые IP-адреса");

            if (token.user != newInfo.user)
            {
                whatChanged.Add((newInfo.user) switch
                {
                    "new" => "- Токену будет присвоен новый пользователь",
                    "" => "- У токена будет очищен пользователь",
                    _ => "- Будет изменён пользователь"
                });
            }
            else if (token.user_additional_data != newInfo.user_additional_data)
                whatChanged.Add("- Описание пользователя будет изменено");

            return whatChanged;
        }


        private enum UpdateChoices { NoChange, New, Clear }
        private void UpdateUserRelatedUI(UpdateChoices? to = UpdateChoices.NoChange)
        {
            var (createNew, clear, enabled, text, tag) = to switch
            {
                UpdateChoices.New => (true, false, false, "Будет изменено на: <будет создан новый пользователь>", "new"),
                UpdateChoices.Clear => (false, true, false, "Будет изменено на: <пользователь будет удалён>", "clear"),
                UpdateChoices.NoChange => (false, false, true, "Будет изменено на: <пользователь не будет изменён>", ""),
                _ => throw new NotImplementedException()
            };

            cbCreateNewUser.Checked = createNew;
            cbClearUser.Checked = clear;
            paginatedView2.Enabled = enabled;
            txtSearchUser.Enabled = enabled;
            btnSearchUser.Enabled = enabled;
            txtAdditionalInfo.Enabled = (to == UpdateChoices.New) || enabled;
            btnUserChangeRollback1.Enabled = !enabled;
            btnUserChangeRollback2.Enabled = !enabled;
            lblNewUserStatus.Text = text;
            lblNewUserStatus.Tag = tag;
        }


        private async Task<HttpStatusCode> PerformSave()
        {
            UpdateTokenFromUI();
            return await SaveChangesToDatabaseAndRefetchUI();
        }


        private void UpdateTokenFromUI(FullTokenInfo? target = null)
        {
            target ??= this.token;

            target.user_additional_data = txtAdditionalInfo.Text;
            target.is_active = cbIsActive.Checked;
            target.can_reset_password = cbCanResetPassword.Checked;
            target.allowed_ips = txtAllowedIps.Text.Replace(" ", "").Replace(",", System.Environment.NewLine).Replace(System.Environment.NewLine, ",");

            target.user = (lblNewUserStatus.Tag) switch
            {
                "" => token.user,
                null => token.user,
                "new" => "new",
                "clear" => "",
                _ => (string)lblNewUserStatus.Tag!
            };
        }


        private async Task<HttpStatusCode> SaveChangesToDatabaseAndRefetchUI()
        {
            string? createdUserId = null;
            HttpStatusCode status;

            if (token.user == "new")
            {
                status = await new PaginatedRequest<UserInfo>(
                    usePagination: false,
                    method: HttpMethod.Post,
                    url: $"/users/",
                    payload: new
                    {
                        additional_data = token.user_additional_data
                    },
                    onSuccess: (StatusCode, responce) => createdUserId = responce.uuid
                ).FetchCurrentPage();

                if (status != HttpStatusCode.Created) { return status; }
                token.user = createdUserId;
            }


            status = await new PaginatedRequest<FullTokenInfo>(
                usePagination: false,
                method: HttpMethod.Patch,
                url: $"/tokens/{tokenId}",
                payload: new
                {
                    is_active = token.is_active,
                    can_reset_password = token.can_reset_password,
                    user = token.user,
                    user_additional_data = token.user_additional_data,
                    allowed_ips = token.allowed_ips
                },
                onSuccess: async (_, _) => await UpdateTokenFromDatabaseAndRefetchUI(),
                onError: async (_, _) =>
                {
                    if (createdUserId != null)
                    {
                        await new PaginatedRequest<UserInfo>(
                        usePagination: false,
                        method: HttpMethod.Delete,
                        url: $"/users/{createdUserId}"
                        ).FetchCurrentPage();
                    }
                }
                ).FetchCurrentPage();

            return status;
        }


        private async void FormEditToken_FormClosing(object sender, FormClosingEventArgs e)
        {
            var whatChanged = hasInfoChanged();
            if (whatChanged.Count > 0)
            {
                var result = MessageBox.Show(
                    $"У вас есть неподтверждённые изменения:\n{string.Join('\n', whatChanged)}\n\nДа - применить изменения и закрыть окно\nНет - сбросить изменения и закрыть окно\nОтмена - не закрывать окно",
                    "Подтверждение",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // отменяем закрытие
                }
                else if (result == DialogResult.No)
                {
                    // nothing
                }
                else if (result == DialogResult.Yes)
                {
                    await PerformSave();
                }
            }
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            var whatChanged = hasInfoChanged();

            if (whatChanged.Count == 0) return;

            FullTokenInfo prevToken = token.Clone();

            if (MessageBox.Show(
                $"Вы собираетесь изменить:\n{string.Join('\n', whatChanged)}",
                "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            ) == DialogResult.Cancel) return;

            //UpdateTokenFromDatabase();
            var StatusCode = await PerformSave();

            if (StatusCode != HttpStatusCode.OK)
            {
                token.CopyFrom(prevToken);
            }
            else
            {
                PerformedSave?.Invoke(this, EventArgs.Empty);
            }
        }


        private void cbClearUser_Click(object sender, EventArgs e) =>
            UpdateUserRelatedUI(cbClearUser.Checked ? UpdateChoices.NoChange : UpdateChoices.Clear);


        private void cbCreateNewUser_Click(object sender, EventArgs e) =>
            UpdateUserRelatedUI(cbCreateNewUser.Checked ? UpdateChoices.NoChange : UpdateChoices.New);


        private void EventLoadHistoryWithParams(object sender, EventArgs e) =>
            _ = LoadHistoryWithParams();


        private void btnUserChangeRollback_Click(object sender, EventArgs e) =>
            UpdateUserRelatedUI();


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var whatChanged = hasInfoChanged();
            if (whatChanged.Count > 0)
            {
                if (MessageBox.Show(
                    $"Вы собираетесь отменить следующие изменения:\n{string.Join('\n', whatChanged)}\n\nОк - отменить изменения (синхронизировать с базой), Отмена - закрыть окно и продолжить редактирование",
                    "Подтверждение",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                ) == DialogResult.Cancel) return;
            }
            await UpdateTokenFromDatabaseAndRefetchUI();
        }


        private void btnSearchUser_Click(object sender, EventArgs e) =>
            _ = LoadUsersWithParams();

        private void txtHistSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void txtSearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnSearchUser.PerformClick();
            }   
        }
    }
}
