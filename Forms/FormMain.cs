using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Data.Json;
using Windows.Graphics.Printing;
using static diplomaadminpanel.Forms.FormMain;
using static System.Runtime.InteropServices.JavaScript.JSType;
using diplomaadminpanel.Utils;
using diplomaadminpanel.Models;
using System.Formats.Nrbf;
using Windows.UI.Composition;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Linq;

namespace diplomaadminpanel.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            //Program.UISyncContext = SynchronizationContext.Current;

            InitializeComponent();
        }


        private async Task<(HttpStatusCode StatusCode, string Content)> GetOrSetEnforcingMode(string? newMode = null) =>
            await Utils.Utils.GetOrSetEnforcingMode(newMode, tslCurrentMode);



        private void Form1_Load(object sender, EventArgs e)
        {
            CreateMyListView();


            //this.FormBorderStyle = FormBorderStyle.Sizable;

            //Program.UISyncContext = SynchronizationContext.Current;


            string currentEnv = Utils.Utils.Env;

            foreach (object item in toolStripDropDownButtonEnv.DropDownItems)
            {
                if (item is ToolStripMenuItem tsm && tsm.Text == currentEnv)
                {
                    tsm.Checked = true;
                    break;
                }
            }

            _ = GetOrSetEnforcingMode();

            toolStripDropDownButtonEnv.DropDown.Closing += DropDown_Closing!;


            pgViewHist.LoadColumns(
            [
                new DataGridViewTextBoxColumn {
                    Name = "colDatetime",
                    HeaderText = "Дата и время",
                    Width = 110,
                },
                new DataGridViewTextBoxColumn {
                    Name = "colIp",
                    HeaderText = "IP-адрес",
                    Width = 90,
                },
                new DataGridViewTextBoxColumn {
                    Name = "fingerprint",
                    HeaderText = "Токен",
                    Width = 110,
                },
                new DataGridViewCheckBoxColumn {
                    Name = "msg",
                    HeaderText = "Успешно?",
                    Width = 70,
                },
                new DataGridViewTextBoxColumn {
                    Name = "result",
                    HeaderText = "Ошибка",
                    Width = 390,
                },
                new DataGridViewTextBoxColumn {
                    Name = "colInitialdata",
                    HeaderText = "Запрос",
                    Width = 120,
                }
            ]);
            pgViewHist.SetRowBuilder<HistoryElem>((elem) =>
                [
                    elem.datetime.ToString(),
                    elem.ip ?? "",
                    elem.fingerprint ?? "",
                    elem.msg == "SUCCESS",
                    elem.result ?? "",
                    elem.initial_data ?? ""
                ]
            );
            pgViewHist.ChangeHeaderHeight(40);
            pgViewHist.RowDoubleClick += PgViewHist_RowDoubleClick;

            cbHistAutoupdate.Checked = true;

            pgViewAllUsers.LoadColumns([

                new DataGridViewTextBoxColumn {
                    Name = "colAdditionalData",
                    HeaderText = "Доп. сведения",
                    Width = 375
                },
                new DataGridViewCheckBoxColumn {
                    Name = "colHasToken",
                    HeaderText = "Токен привязан?",
                    Width = 75
                },
                new DataGridViewTextBoxColumn {
                    Name = "colFingerprint",
                    HeaderText = "Отпечаток",
                    Width = 110
                },
                new DataGridViewTextBoxColumn {
                    Name = "colUuid",
                    HeaderText = "Последний вход",
                    Width = 115
                },
                new DataGridViewTextBoxColumn {
                    Name = "colUuid",
                    HeaderText = "Создан",
                    Width = 115
                },
                new DataGridViewTextBoxColumn {
                    Name = "colUuid",
                    HeaderText = "UUID",
                    Width = 115
                },
                new DataGridViewButtonColumn {
                    Name = "colDelete",
                    HeaderText = "Удаление пользователя",
                    Text = "Удалить",
                    Width = 115,
                    UseColumnTextForButtonValue = true
                },
            ]);
            pgViewAllUsers.SetRowBuilder<UserInfo>((elem) =>
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = elem.additional_data ?? ""
                });
                row.Cells.Add(new DataGridViewCheckBoxCell
                {
                    Value = elem.token != null,
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = elem.fingerprint ?? "",
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = elem.last_login?.ToString() ?? "",
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = elem.created?.ToString() ?? "",
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = elem.uuid
                });
                DataGridViewCell deleteButtonCell = elem.token == null
                                                    ? new DataGridViewButtonCell { Value = "Удалить" }
                                                    : new DataGridViewTextBoxCell { Value = "Нельзя удалить" };
                row.Cells.Add(deleteButtonCell);

                return row;
            }

            );
            pgViewAllUsers.CellContentClick += PgViewAllUsers_CellContentClick;
            pgViewAllUsers.RowDoubleClick += PgViewAllUsers_RowDoubleClick;

            cbAllowUsersDeletion.Checked = true;
            cbAllowUsersDeletion.Checked = false;

            pgViewAllTokens.LoadColumns(
            [
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colFingerprint",
                    HeaderText = "Fingerprint"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colPubkey",
                    HeaderText = "Public Key"
                },
                new DataGridViewCheckBoxColumn
                {
                    Name = "colIsActive",
                    HeaderText = "Активен?",
                },
                new DataGridViewCheckBoxColumn
                {
                    Name = "colCanResetPassword",
                    HeaderText = "Может сбросить пароль?",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colLastActivated",
                    HeaderText = "Последняя активация"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colAllowedIPs",
                    HeaderText = "Разрешённые IP"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colUser",
                    HeaderText = "ID пользователя"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colUserAdditionalData",
                    HeaderText = "Доп. сведения пользователя"
                }
            ]);
            pgViewAllTokens.SetRowBuilder<FullTokenInfo>((elem) =>
                [
                    elem.id,
                    elem.fingerprint ?? "",
                    elem.pubkey ?? "",
                    elem.is_active,
                    elem.can_reset_password,
                    elem.last_activated.ToString(),
                    elem.allowed_ips ?? "",
                    elem.user ?? "",
                    elem.user_additional_data ?? ""
                ]
            );
            pgViewAllTokens.RowDoubleClick += PgViewAllTokens_RowDoubleClick;
            pgViewAllTokens.CellContentClick += PgViewAllTokens_CellContentClick;

            ActivateStage(["1"]);
        }




        private async void PgViewAllUsers_RowDoubleClick(object? sender, object e)
        {
            if (e is not UserInfo ui) return;

            if (ui.token == null)
            {
                var dlgNewToken = new FormAddToken();
                var res = dlgNewToken.ShowDialog();
                if (res == DialogResult.OK && dlgNewToken.Result is FullTokenInfo token)
                {
                    await new PaginatedRequest<FullTokenInfo>(
                        usePagination: false,
                        method: HttpMethod.Patch,
                        url: $"/tokens/{token.id}",
                        payload: new
                        {
                            user = ui.uuid,
                        },
                        onSuccess: (_, _) => btnAllUsersSearch.PerformClick()
                        ).FetchCurrentPage();
                }
                return;
            }




            var token_id = Convert.ToInt32(ui.token);

            spawnTokenForm(token_id);

            //if (_openTokenForms.TryGetValue(token_id, out var frm))
            //{
            //    if (frm.WindowState == FormWindowState.Minimized)
            //        frm.WindowState = FormWindowState.Normal;

            //    frm.BringToFront();

            //    return;
            //}

            //var dlg = new FormEditToken { tokenId = token_id };

            //dlg.PerformedSave += (_, _) => btnAllTknSearch.PerformClick();
            //dlg.PerformedSave += (_, _) => btnAllUsersSearch.PerformClick();
            //dlg.FormClosed += (_, _) => btnAllUsersSearch.PerformClick();
            //dlg.FormClosed += (_, _) => btnAllTknSearch.PerformClick();
            //dlg.FormClosed += (_, _) => _openTokenForms.Remove(token_id);

            //_openTokenForms[token_id] = dlg;

            //dlg.Show();
        }

        private async void PgViewAllUsers_CellContentClick(object? sender, (string ColumnName, object? RowTag, object? Value) e)
        {
            if (e.ColumnName != "colDelete") return;

            if (e.RowTag is not UserInfo user) return;

            if (user.token != null) return;

            if (MessageBox.Show(
                $"""
                Вы собираетесь удалить пользователя {user.additional_data}{((user.token != null) ? "," : ".")}
                {((user.token != null) ? $"к которому привязан токен {user.fingerprint}." : "")}
                Если данный пользователь привязан к системе входа, вам придётся её перенастроить.

                Вы уверены, что хотите продолжить?
                """,
                "Внимание",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2)
            != DialogResult.OK) { return; }

            await new PaginatedRequest<string>(
            usePagination: false,
            method: HttpMethod.Delete,
            url: $"/users/{user.uuid}",
            onSuccess: (_, _) => { btnAllUsersSearch.PerformClick(); }
            ).FetchCurrentPage();

        }

        private async void PgViewAllTokens_CellContentClick(object? sender, (string ColumnName, object? RowTag, object? Value) e)
        {
            if (e.Value is not bool isChecked) return;
            isChecked = !isChecked;

            if (e.RowTag is not FullTokenInfo token) return;

            string msg = (e.ColumnName) switch
            {
                "colIsActive" => $"{(isChecked ? "Активировать" : "Деактивировать")} токен {token.fingerprint}?",
                "colCanResetPassword" => $"{(isChecked ? "Разрешить" : "Запретить")} изменение пин-кода при следующем входе токена {token.fingerprint}?",
                _ => "Неизвестная колонка, нажмите \"Нет\"."
            };

            if (MessageBox.Show(msg, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                btnAllTknSearch.PerformClick();
                return;
            }

            var payload = new Dictionary<string, object>();
            if (e.ColumnName == "colIsActive") payload["is_active"] = isChecked;
            if (e.ColumnName == "colCanResetPassword") payload["can_reset_password"] = isChecked;

            await new PaginatedRequest<FullTokenInfo>(
            usePagination: false,
            method: HttpMethod.Patch,
            url: $"/tokens/{token.id}",
            payload: payload,
            onSuccess: (StatusCode, response) =>
            {
                btnAllTknSearch.PerformClick();
            }).FetchCurrentPage();
        }

        private void PgViewAllTokens_RowDoubleClick(object? sender, object initial)
        {
            if (initial is not FullTokenInfo token) return;


            spawnTokenForm(token.id);

            //var token_id = token.id;

            //if (_openTokenForms.TryGetValue(token_id, out var frm))
            //{
            //    if (frm.WindowState == FormWindowState.Minimized)
            //        frm.WindowState = FormWindowState.Normal;

            //    frm.BringToFront();

            //    return;
            //}

            //var dlg = new FormEditToken { token = token };

            //dlg.PerformedSave += (_, _) => btnAllTknSearch.PerformClick();
            //dlg.FormClosed += (_, _) => btnAllTknSearch.PerformClick();
            //dlg.FormClosed += (_, _) => _openTokenForms.Remove(token_id);

            //_openTokenForms[token_id] = dlg;

            //dlg.Show();
        }




        private string tokensrequesttimestamp = "";
        private bool _isbuttonSwitchToGracefulBusy = false;
        private async void buttonSwitchToGraceful_Click(object sender, EventArgs e)
        {
            if (_isbuttonSwitchToGracefulBusy) return;
            _isbuttonSwitchToGracefulBusy = true;

            try
            {
                var (StatusCode, _) = await GetOrSetEnforcingMode("gr");
                if (StatusCode == HttpStatusCode.OK)
                {
                    tokensrequesttimestamp = DateTimeOffset.Now.ToString("o");

                    ActivateStage(["2", "3"]);

                    //buttonSwitchToGraceful.Enabled = false;
                    //buttonUpdateTokensList.Enabled = true;
                    //buttonActivateSelectedTokens.Enabled = true;
                }
                selectedTokens.Clear();
            }
            finally
            {
                _isbuttonSwitchToGracefulBusy = false;
            }


        }


        private bool _isbuttonUpdateTokensList_ClickBusy = false;
        private PaginatedRequest<List<FullTokenInfo>>? lstTnkResp;
        private HashSet<ComboBoxItem> selectedTokens = [];
        private async void buttonUpdateTokensList_Click(object sender, EventArgs e)
        {
            if (lstTnkResp != null)
            {
                lstTnkResp?.Dispose();
                lstTnkResp = null;
            }

            if (_isbuttonUpdateTokensList_ClickBusy) return;
            _isbuttonUpdateTokensList_ClickBusy = true;

            try
            {
                lstTnkResp = new PaginatedRequest<List<FullTokenInfo>>(
                    usePagination: true,
                    method: HttpMethod.Get,
                    url: "/tokens/",
                    nextPageButton: this.btnTknNext,
                    previousPageButton: this.btnTknPrev,
                    labelCurrentPage: lblPgInfo,
                    parameters: new Dictionary<string, string?>
                    {
                        ["is_active"] = "false",
                        ["last_activated__gt"] = tokensrequesttimestamp

                    },
                    onSuccess: (StatusCode, response) =>
                    {
                        //response.ForEach(it => Debug.WriteLine(it.ToString()));

                        var selectedIds = new HashSet<int>(selectedTokens.Select(it => ((FullTokenInfo)it.Tag).id));

                        _isBeingAdded = true;

                        clbTokensList.Items.Clear();
                        foreach (var token in response)
                        {
                            clbTokensList.Items.Add(
                                new ComboBoxItem { Tag = token, Text = token.fingerprint! },
                                isChecked: selectedIds.Contains(token.id));
                        }

                        _isBeingAdded = false;
                    }
                );
                await lstTnkResp.FetchCurrentPage();

            }
            finally
            {
                _isbuttonUpdateTokensList_ClickBusy = false;
            }

        }


        private List<FullTokenInfo> activatedTokens = [];


        private bool _buttonActivateSelectedTokensBusy = false;
        private async void buttonActivateSelectedTokens_Click(object sender, EventArgs e)
        {
            if (_buttonActivateSelectedTokensBusy) return;
            _buttonActivateSelectedTokensBusy = true;

            try
            {
                if (clbTokensList.CheckedItems.Count == 0)
                {

                    if (MessageBox.Show(
                        $"Вы не выбрали ни одного токена\nВы уверены, что хотите продолжить?\nСистема будет переведена в on режим",
                        "Подтверждение",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning)
                     != DialogResult.OK)
                    {
                        return;
                    }

                }
                else
                {
                    var selectedFingerprints = string.Join("\n",
                        selectedTokens
                        .Select(item => ((FullTokenInfo)item.Tag).fingerprint).ToList()
                    );

                    var result = MessageBox.Show(
                        $"Будут активированы следующие токены:\n{selectedFingerprints}\nВы уверены, что хотите продолжить?\nСистема будет переведена в on режим",
                        "Подтверждение",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question
                    );

                    if (result != DialogResult.OK) { return; }


                    using var req = new PaginatedRequest<ActivatedInfo>(
                        usePagination: false,
                        method: HttpMethod.Post,
                        url: "/tokens/bulk-activate/",
                        payload: new
                        {
                            is_active = true,
                            ids = selectedTokens
                                .Select(item => item.Tag)
                                .Select(item => ((FullTokenInfo)item).id)
                                .ToList()
                        },
                        onSuccess: (StatusCode, response) =>
                        {
                            MessageBox.Show($"Активировано токенов: {response.updated}", "Активировано", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    );
                    await req.FetchCurrentPage();
                }

                await GetOrSetEnforcingMode("on");

                if (clbTokensList.CheckedItems.Count != 0)
                {
                    clbTokensList.Items.Clear();
                    activatedTokens.AddRange(selectedTokens.Select(item => item.Tag).OfType<FullTokenInfo>().ToList());
                    RedrawActivatedTokensList();
                }
                
                if (clbTokensList.CheckedItems.Count != 0 || activatedTokens.Count != 0)
                {
                    ActivateStage(["1", "4", "5"]);
                }
                else
                {
                    ActivateStage(["1"]);
                }

            }
            finally
            {
                _buttonActivateSelectedTokensBusy = false;
            }
        }


        bool _isBeingAdded = false;
        private void clbTokensList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isBeingAdded) return;

            if (e.NewValue == CheckState.Checked)
            {
                selectedTokens.Add((ComboBoxItem)clbTokensList.Items[e.Index]);
            }
            else
            {
                selectedTokens.Remove((ComboBoxItem)clbTokensList.Items[e.Index]);
            }
            Debug.WriteLine(selectedTokens.Count());

            //var s = sender as CheckedListBox;
            //var count = s.CheckedIndices.Count + (e.NewValue == CheckState.Checked ? 1 : -1);
            //if (count > 0) { buttonActivateSelectedTokens.Enabled = true; }
            //else { buttonActivateSelectedTokens.Enabled = false; }
        }


        private void toolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is ToolStripMenuItem clickedMenuItem)
            {
                foreach (ToolStripItem item in toolStripDropDownButtonEnv.DropDownItems)
                {
                    if (item is ToolStripMenuItem menuItem && menuItem != clickedMenuItem)
                    {
                        menuItem.Checked = false;
                    }
                }

                clickedMenuItem.Checked = true;

                Properties.Settings.Default.env = clickedMenuItem.Text;
                Properties.Settings.Default.Save();

                _ = GetOrSetEnforcingMode();
            }
        }


        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }


        private async void tslCurrentMode_Click(object sender, EventArgs e)
        {
            (HttpStatusCode StatusCode, string Content) = await GetOrSetEnforcingMode();

            if (StatusCode == HttpStatusCode.OK)
            {
                using var dlg = new FormSelectEnforcingMode { PrepopulatedOption = Content };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.SelectedOption != Content)
                    {
                        _ = GetOrSetEnforcingMode(dlg.SelectedOption);
                    }
                }
            }
        }


        private bool _isbtnAllTknSearchBusy = false;
        private async void btnAllTknSearch_Click(object sender, EventArgs e)
        {
            if (_isbtnAllTknSearchBusy) return;
            _isbtnAllTknSearchBusy = true;
            pgViewAllTokens.Bind<FullTokenInfo>(
                method: HttpMethod.Get,
                url: $"/tokens/",
                parameters: new Dictionary<string, string?>
                {
                    ["search"] = txtAllTknSearch.Text,
                    ["is_active"] = cbOnlyActive.Checked ? "true" : null,
                    ["has_user"] = cbOnlyLinked.Checked ? "true" : null,
                }
            );
            await pgViewAllTokens.FetchCurrentPage();
            _isbtnAllTknSearchBusy = false;
        }


        private async void btnDeleteUnlinked_Click(object sender, EventArgs e)
        {
            int tokenCount = 0;
            using var req = new PaginatedRequest<TokenCount>(
                usePagination: false,
                method: HttpMethod.Get,
                url: "/tokens/count/",
                parameters: new Dictionary<string, string?> { ["has_user"] = "false" },
                onSuccess: (StatusCode, response) =>
                {
                    tokenCount = response.count;
                }
            );
            if (await req.FetchCurrentPage() != HttpStatusCode.OK) { return; }

            if (tokenCount == 0)
            {
                MessageBox.Show(
                $"В системе нет непривязанных токенов.",
                "Удаление",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(
                $"ВНИМАНИЕ!\nВы собираетесь удалить {tokenCount} непривязанных токенов.\nВы уверены, что хотите продолжить?",
                "Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ) != DialogResult.Yes) { return; }

            using var req2 = new PaginatedRequest<DeletedCount>(
                usePagination: false,
                method: HttpMethod.Delete,
                url: "/tokens/delete-unlinked",
                onSuccess: (StatusCode, response) =>
                {
                    MessageBox.Show(
                        $"Удалено токенов: {response.deleted}",
                        "Удалено",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            );
            if (await req2.FetchCurrentPage() != HttpStatusCode.OK) { return; }

            //dgvAllTkn.Rows.Clear();
            btnAllTknSearch.PerformClick();
        }


        private async void btnDeleteInactive_Click(object sender, EventArgs e)
        {
            int tokenCount = 0;
            using var req = new PaginatedRequest<TokenCount>(
                usePagination: false,
                method: HttpMethod.Get,
                url: "/tokens/count/",
                parameters: new Dictionary<string, string?> { ["is_active"] = "false" },
                onSuccess: (StatusCode, response) =>
                {
                    tokenCount = response.count;
                }
            );
            if (await req.FetchCurrentPage() != HttpStatusCode.OK) { return; }

            if (tokenCount == 0)
            {
                MessageBox.Show(
                $"В системе нет неактивных токенов.",
                "Удаление",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }


            if (MessageBox.Show(
                $"ВНИМАНИЕ!\nВы собираетесь удалить {tokenCount} неактивных токенов.\nВы уверены, что хотите продолжить?",
                "Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ) != DialogResult.Yes) { return; }

            using var req2 = new PaginatedRequest<DeletedCount>(
                usePagination: false,
                method: HttpMethod.Delete,
                url: "/tokens/delete-inactive",
                onSuccess: (StatusCode, response) =>
                {
                    MessageBox.Show(
                        $"Удалено токенов: {response.deleted}",
                        "Удалено",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            );
            if (await req2.FetchCurrentPage() != HttpStatusCode.OK) { return; }

            btnAllTknSearch.PerformClick();
        }


        private void cbOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            btnAllTknSearch.PerformClick();
        }


        private void cbOnlyLinked_CheckedChanged(object sender, EventArgs e)
        {
            btnAllTknSearch.PerformClick();
        }


        private readonly Dictionary<int, FormEditToken> _openTokenForms = new();

        //private Dictionary<string, string>? UserOrderingDict = null;

        private bool _ShouldResetHistFromDateTime = true;
        private bool _ShouldResetUsersFromDateTime = true;
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTab = tcMain.SelectedTab;

            //var cbwaschecked = cbHistAutoupdate.Checked;

            //if (selectedTab != tpHistory) cbHistAutoupdate.Checked = false;

            if (selectedTab == tpAddNewTokens)
            {
                BeginInvoke(new Action(() =>
                {
                    lstViewActivatedTokens.Focus();
                }));
            }
            else if (selectedTab == tpListTokens)
            {
                btnAllTknSearch.PerformClick();
            }
            else if (selectedTab == tpHistory)
            {
                if (_ShouldResetHistFromDateTime)
                {
                    dtpHistFrom.Value = DateTime.Today;
                    _ShouldResetHistFromDateTime = false;
                    dtpHistFrom.Checked = false;
                }

                if (FilterFieldsDict == null)
                {
                    if (await new PaginatedRequest<List<string>>(
                        usePagination: false,
                        method: HttpMethod.Get,
                        url: $"/errors/",
                        onSuccess: (StatusCode, response) =>
                        {
                            FilterFieldsDict = new Dictionary<string, bool>();
                            foreach (var item in response)
                            {
                                FilterFieldsDict.Add(item, false);
                            }
                        }
                    ).FetchCurrentPage() != HttpStatusCode.OK) return;
                }

                btnSearchHistory_Click(btnSearchHistory, EventArgs.Empty);
                //cbHistAutoupdate.Checked = cbwaschecked;
            }
            else if (selectedTab == tpAllUsers)
            {
                if (_ShouldResetUsersFromDateTime)
                {
                    dtpUsersFrom.Value = DateTime.Today;
                    _ShouldResetUsersFromDateTime = false;
                    dtpUsersFrom.Checked = false;
                }

                Utils.Utils.PopulateOrderingComboBox("/ordering/user/", cbUserOrdering);
            }

            btnAllUsersSearch.PerformClick();
        }



        private void txtAllTknSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAllTknSearch.PerformClick();
            }
        }


        private Dictionary<string, bool>? FilterFieldsDict = null;
        private string filterText = "";
        private void btnFilterHistory_Click(object sender, EventArgs e)
        {
            if (FilterFieldsDict == null) return;

            var dlg = new Forms.FormCustomCheckboxFilter
            {
                InitialValues = FilterFieldsDict
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filterText = "";
                filterText = string.Join(" | ", dlg.Result!.Where(kv => kv.Value).Select(kv => kv.Key));
                FilterFieldsDict = dlg.Result;
            }

            cbHistSuccessfull.Enabled = filterText == "";

            lblHistFilterAmount.Text = $"Выбрано фильтров: {FilterFieldsDict!.Where(it => it.Value).Count()}";

            if (filterText != "") btnHistClearFilters.Enabled = true;

            btnSearchHistory_Click(btnFilterHistory, EventArgs.Empty);
            //MessageBox.Show(filterText);
        }


        bool wasHistToChecked = false;
        private void cbHistAutoupdate_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbHistAutoupdate.Checked)
            {
                dtpHistTo.Value = DateTime.Now;
                dtpHistTo.Checked = wasHistToChecked;
            }
            else
            {
                wasHistToChecked = dtpHistTo.Checked;
            }

            pgViewHist.PageButtonsEnabled = (!cbHistAutoupdate.Checked);
            dtpHistTo.Enabled = !cbHistAutoupdate.Checked;
            btnSearchHistory.Enabled = !cbHistAutoupdate.Checked;
            tmrAutoUpdateHistory.Enabled = cbHistAutoupdate.Checked;
        }


        private bool _isbtnSearchHistoryBusy = false;
        private async void btnSearchHistory_Click(object sender, EventArgs e)
        {
            if (_isbtnSearchHistoryBusy) return;
            _isbtnSearchHistoryBusy = true;

            tmrAutoUpdateHistory.Enabled = false;

            pgViewHist.Bind<HistoryElem>(
                method: HttpMethod.Get,
                url: "/history/",
                parameters: new Dictionary<string, string?>
                {
                    ["search"] = txtSearchHist.Text,
                    ["datetime__lt"] = dtpHistTo.Enabled && dtpHistTo.Checked ? new DateTimeOffset(dtpHistTo.Value).ToString("o") : null,
                    ["datetime__gt"] = dtpHistFrom.Checked ? new DateTimeOffset(dtpHistFrom.Value).ToString("o") : null,
                    ["result"] = filterText,
                    ["msg"] = (cbHistSuccessfull.Enabled && cbHistSuccessfull.Checked, cbHistUnsuccessful.Checked) switch
                    {
                        (true, true) => "",
                        (true, false) => "SUCCESS",
                        (false, true) => "ERR",
                        (false, false) => "INVALID"
                    }
                }
            );

            if (await pgViewHist.FetchCurrentPage() != HttpStatusCode.OK) cbHistAutoupdate.Checked = false;
            else if (cbHistAutoupdate.Checked) tmrAutoUpdateHistory.Enabled = true;
            _isbtnSearchHistoryBusy = false;
        }

        private void PgViewHist_RowDoubleClick(object? sender, object e)
        {
            if (e is not HistoryElem ui || ui.token == null) return;

            var token_id = Convert.ToInt32(ui.token);

            spawnTokenForm(token_id);

            //if (_openTokenForms.TryGetValue(token_id, out var frm))
            //{
            //    if (frm.WindowState == FormWindowState.Minimized)
            //        frm.WindowState = FormWindowState.Normal;

            //    frm.BringToFront();

            //    return;
            //}

            //var dlg = new FormEditToken { tokenId = token_id };

            //dlg.PerformedSave += (_, _) => btnAllTknSearch.PerformClick();
            //dlg.FormClosed += (_, _) => btnAllTknSearch.PerformClick();
            //dlg.FormClosed += (_, _) => _openTokenForms.Remove(token_id);

            //_openTokenForms[token_id] = dlg;

            //dlg.Show();
        }

        private void tmrAutoUpdateHistory_Tick(object sender, EventArgs e)
        {
            if (tcMain.SelectedTab != tpHistory) return;
            btnSearchHistory_Click(btnSearchHistory, EventArgs.Empty);
        }


        private void btnHistClearFilters_Click(object sender, EventArgs e)
        {
            btnHistClearFilters.Enabled = false;

            lblHistFilterAmount.Text = $"Выбрано фильтров: 0";

            filterText = "";

            FilterFieldsDict = FilterFieldsDict!.Keys.ToDictionary(k => k, _ => false);

            btnSearchHistory_Click(btnFilterHistory, EventArgs.Empty);

            cbHistSuccessfull.Enabled = true;
        }


        private void txtSearchHist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnSearchHistory.PerformClick();
            }
        }


        private Forms.FormSampleLogin? LoginForm = null;
        private void tsmSimulateLogin_Click(object sender, EventArgs e)
        {
            if (LoginForm != null)
            {
                if (LoginForm.WindowState == FormWindowState.Minimized)
                    LoginForm.WindowState = FormWindowState.Normal;
                LoginForm.BringToFront();
                return;
            }

            LoginForm = new FormSampleLogin();
            LoginForm.FormClosed += (_, _) =>
            {
                LoginForm.Dispose();
                LoginForm = null;
            };
            LoginForm.Show();
        }


        private void FormMain_Shown(object sender, EventArgs e) { }
        private void dtpHistFrom_EnabledChanged(object sender, EventArgs e) { }


        private bool dtpHistFromPrevChecked = false;
        private void dtpHistFrom_ValueChanged(object sender, EventArgs e)
        {
            if (_ShouldResetHistFromDateTime) return;

            if (dtpHistFrom.Checked || dtpHistFrom.Checked != dtpHistFromPrevChecked)
            {
                btnSearchHistory_Click(btnSearchHistory, EventArgs.Empty);
            }

            dtpHistFromPrevChecked = dtpHistFrom.Checked;
        }


        private bool dtpHistToPrevChecked;
        private void dtpHistTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpHistTo.Checked || dtpHistTo.Checked != dtpHistToPrevChecked)
            {
                btnSearchHistory_Click(btnSearchHistory, EventArgs.Empty);
            }

            dtpHistToPrevChecked = dtpHistTo.Checked;
        }

        private void cbHistUnsuccessful_CheckedChanged(object sender, EventArgs e)
        {
            btnSearchHistory_Click(btnSearchHistory, EventArgs.Empty);
        }

        private void cbHistSuccessfull_CheckedChanged(object sender, EventArgs e)
        {
            btnSearchHistory_Click(btnSearchHistory, EventArgs.Empty);
        }


        private void btnAllUsersSearch_Click(object sender, EventArgs e)
        {
            _ = LoadUsersWithParams();
            //pgViewAllUsers.Bind
        }


        private bool _isLoadUsersWithParamsBusy = false;
        private async Task<HttpStatusCode> LoadUsersWithParams()
        {
            if (_isLoadUsersWithParamsBusy) return (HttpStatusCode)999;
            _isLoadUsersWithParamsBusy = true;

            ComboBoxItem? selected_ordering = cbUserOrdering.SelectedItem as ComboBoxItem;

            pgViewAllUsers.Bind<UserInfo>(
            method: HttpMethod.Get,
            url: "/users/",
            payload: null,
            //pageSize: 100,
            parameters: new Dictionary<string, string?>
            {
                ["last_login__lt"] = dtpUsersTo.Checked ? new DateTimeOffset(dtpUsersTo.Value).ToString("o") : null,
                ["last_login__gt"] = dtpUsersFrom.Checked ? new DateTimeOffset(dtpUsersFrom.Value).ToString("o") : null,
                ["search"] = txtAllUsersSearch.Text,
                ["has_token"] = cbOnlyLinkedUsers.Checked ? "true" : null,
                ["ordering"] = selected_ordering?.Tag.ToString(),
            }
            );
            var res = await pgViewAllUsers.FetchCurrentPage();
            _isLoadUsersWithParamsBusy = false;
            return res;
        }

        private void cbAllowUsersDeletion_CheckedChanged(object sender, EventArgs e)
        {
            pgViewAllUsers.SetColumnVisibility("colDelete", cbAllowUsersDeletion.Checked);
        }

        private int ClickedCount = 0;
        private void cbAllowUsersDeletion_Click(object sender, EventArgs e)
        {
            if (cbAllowUsersDeletion.Checked)
            {
                cbAllowUsersDeletion.Checked = false;
                ClickedCount = 0;
                return;
            }

            if (ClickedCount < 5)
            {
                ClickedCount++;
                return;
            }

            if (MessageBox.Show(
                """
                Вы собираетесь включить режим удаления пользователей.
                Если вы удалите пользователя, вам придётся перенастраивать систему входа на новый ID.
                Вы уверены, что хотите продолжить?
                """,
                "Внимание",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2)
            != DialogResult.OK)
            {
                ClickedCount = 0;
                return;
            }

            cbAllowUsersDeletion.Checked = true;
        }


        private bool dtpUsersFromPrevChecked = false;
        private void dtpUsersFrom_ValueChanged(object sender, EventArgs e)
        {
            if (_ShouldResetUsersFromDateTime) { return; }

            if (dtpUsersFrom.Checked || dtpUsersFrom.Checked != dtpUsersFromPrevChecked)
            {
                btnAllUsersSearch.PerformClick();
            }

            dtpUsersFromPrevChecked = dtpUsersFrom.Checked;
        }


        private bool dtpUsersToPrevChecked = false;
        private void dtpUsersTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpUsersTo.Checked || dtpUsersTo.Checked != dtpUsersToPrevChecked)
            {
                btnAllUsersSearch.PerformClick();
            }

            dtpUsersToPrevChecked = dtpUsersTo.Checked;
        }


        private void cbOnlyLinkedUsers_CheckedChanged(object sender, EventArgs e)
        {
            btnAllUsersSearch.PerformClick();
        }

        private void txtAllUsersSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAllUsersSearch.PerformClick();
            }
        }


        private void CreateMyListView()
        {

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            //if (!suppressSelection)
            //{
            //    var selectedIndex = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            //    e.Item!.Selected = false;
            //    listView1.Items[selectedIndex].Selected = true;
            //}
        }

        private bool suppressSelection = false;
        private bool suppressItemCheck = false;

        private int? prevselectedindex;

        public void SelectItemProgrammatically(int index)
        {
            suppressSelection = true;

            lstViewActivatedTokens.SelectedItems.Clear();

            if (index == -1)
            {
                prevselectedindex = -1;
                suppressSelection = false;
                return;
            }

            if (index >= 0 && index < lstViewActivatedTokens.Items.Count)
            {
                lstViewActivatedTokens.Items[index].Selected = true;
                prevselectedindex = index;
                BeginInvoke(new Action(() =>
                {
                    lstViewActivatedTokens.Focus();
                    //listView1.Items[index].Selected = true;
                }));
            }

            suppressSelection = false;
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!suppressSelection)
            {
                suppressSelection = true;

                //if (listView1.SelectedItems.Count > 0)
                //{
                lstViewActivatedTokens.SelectedItems.Clear();
                //}

                if (prevselectedindex != null && prevselectedindex > 0)
                {
                    lstViewActivatedTokens.Items[(int)prevselectedindex].Selected = true;
                }

                suppressSelection = false;
            }
        }


        private void spawnTokenForm(int token_id)
        {
            if (_openTokenForms.TryGetValue(token_id, out var frm))
            {
                if (frm.WindowState == FormWindowState.Minimized)
                    frm.WindowState = FormWindowState.Normal;

                frm.BringToFront();

                return;
            }

            var dlg = new FormEditToken { tokenId = token_id };

            dlg.PerformedSave += (_, _) => btnAllTknSearch.PerformClick();
            dlg.PerformedSave += (_, _) => btnAllUsersSearch.PerformClick();
            dlg.PerformedSave += (_, _) => RedrawActivatedTokensList();
            dlg.FormClosed += (_, _) => btnAllUsersSearch.PerformClick();
            dlg.FormClosed += (_, _) => btnAllTknSearch.PerformClick();
            dlg.FormClosed += (_, _) => RedrawActivatedTokensList();
            dlg.FormClosed += (_, _) => _openTokenForms.Remove(token_id);

            _openTokenForms[token_id] = dlg;

            dlg.Show();
        }

        private HashSet<int> validatedTokens = [];

        private void ActivateStage(List<string> StagesToActivate)
        {
            tpAddNewTokens.Controls
                .OfType<GroupBox>()
                .ToList()
                .ForEach(grp => grp.Enabled = StagesToActivate.Contains(grp.Tag));
        }


        private async void RedrawActivatedTokensList()
        {

            lstViewActivatedTokens.Items.Clear();

            var activatedIdsList = string.Join(",", activatedTokens.Select(item => item.id).ToList());

            var tokensInfo = await new PaginatedRequest<List<FullTokenInfo>>(
                usePagination: true,
                method: HttpMethod.Get,
                url: "tokens",
                parameters: new Dictionary<string, string?>
                {
                    ["ids"] = activatedIdsList,
                },
                onSuccess: (StatusCode, response) =>
                {
                    foreach (var item in response)
                    {
                        var lstViewItem = new ListViewItem();
                        lstViewItem.Tag = item;
                        lstViewItem.Text = item.fingerprint;
                        lstViewItem.SubItems.Add(string.IsNullOrEmpty(item.user) ? "❌" : "✔");
                        lstViewItem.SubItems.Add(item.user_additional_data);
                        lstViewActivatedTokens.Items.Add(lstViewItem);
                        suppressItemCheck = true;
                        lstViewActivatedTokens.Items[lstViewActivatedTokens.Items.IndexOf(lstViewItem)].Checked = validatedTokens.Contains(item.id);
                        suppressItemCheck = false;
                        //
                    }

                    //lstViewActivatedTokens.Items.AddRange(
                    //    [.. response.Select(item =>
                    //        new ListViewItem(new[] { item.fingerprint, item.user_additional_data! })
                    //        {
                    //            Tag = item
                    //        }
                    //    )]
                    //);
                },
                nextPageButton: btnActivatedTokensNextPage,
                previousPageButton: btnActivatedTokensPrevPage,
                labelCurrentPage: lblActivatedTokensPages
                ).FetchCurrentPage();


            //foreach token in activatedTokens (
            //    )

            //// Create a new ListView control.
            ////ListView listView1 = new ListView();
            ////listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

            //// Set the view to show details.
            ////listView1.View = View.Details;
            //// Allow the user to edit item text.
            ////listView1.LabelEdit = true;
            //// Allow the user to rearrange columns.
            ////listView1.AllowColumnReorder = true;
            //// Display check boxes.
            ////listView1.CheckBoxes = true;
            //// Select the item and subitems when selection is made.
            //lstViewActivatedTokens.FullRowSelect = true;
            //lstViewActivatedTokens.HideSelection = false;
            //// Display grid lines.
            ////listView1.GridLines = true;
            //// Sort the items in the list in ascending order.
            ////listView1.Sorting = SortOrder.Ascending;

            //// Create three items and three sets of subitems for each item.
            //ListViewItem item1 = new ListViewItem("item1");
            //// Place a check mark next to the item.
            //item1.Checked = true;
            //item1.SubItems.Add("1");
            //item1.SubItems.Add("2");
            //item1.SubItems.Add("3");
            //ListViewItem item2 = new ListViewItem("item2");
            //item2.SubItems.Add("4");
            //item2.SubItems.Add("5");
            //item2.SubItems.Add("6");
            //ListViewItem item3 = new ListViewItem("item3");
            //// Place a check mark next to the item.
            //item3.Checked = true;
            //item3.SubItems.Add("7");
            //item3.SubItems.Add("8");
            //item3.SubItems.Add("9");

            //// Create columns for the items and subitems.
            //// Width of -2 indicates auto-size.
            ////listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
            ////listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            ////listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            ////listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

            ////Add the items to the ListView.
            //lstViewActivatedTokens.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            ////// Create two ImageList objects.
            ////ImageList imageListSmall = new ImageList();
            ////ImageList imageListLarge = new ImageList();

            ////// Initialize the ImageList objects with bitmaps.
            ////imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage1.bmp"));
            ////imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage2.bmp"));
            ////imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage1.bmp"));
            ////imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage2.bmp"));

            //////Assign the ImageList objects to the ListView.
            ////listView1.LargeImageList = imageListLarge;
            ////listView1.SmallImageList = imageListSmall;

            //// Add the ListView to the control collection.
            ////this.Controls.Add(listView1);

            //SelectItemProgrammatically(2);

        }

        private void lstViewActivatedTokens_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (suppressItemCheck) return;
            e.NewValue = e.CurrentValue;
        }

        private void lstViewActivatedTokens_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = lstViewActivatedTokens.HitTest(e.Location);
            ListViewItem? item = hit.Item;

            if (item?.Tag is not FullTokenInfo token) return;

            if (token.user == null || token.user == "") spawnTokenForm(token.id);

        }

        private void btnTestActivatedTokens_Click(object sender, EventArgs e)
        {


            foreach (var item in lstViewActivatedTokens.Items)
            {
                if (item is not ListViewItem lstitem) continue;

                if (lstitem.Checked) { continue; }

                if (lstitem.Tag is not FullTokenInfo token) continue;

                if (token.user == null || token.user == "") continue;

                BeginInvoke(new Action(() =>
                {
                    lstViewActivatedTokens.Focus();
                }));
                SelectItemProgrammatically(lstitem.Index);
                BeginInvoke(new Action(() =>
                {
                    lstViewActivatedTokens.Focus();
                }));

                if (new FormSampleLogin { InitialUuid = token.user }.ShowDialog() == DialogResult.OK)
                {
                    suppressItemCheck = true;
                    lstViewActivatedTokens.Items[lstitem.Index].Checked = true;
                    suppressItemCheck = false;
                    validatedTokens.Add(token.id);
                }

            }
            SelectItemProgrammatically(-1);
            BeginInvoke(new Action(() =>
            {
                lstViewActivatedTokens.Focus();
            }));
        }
    }

}