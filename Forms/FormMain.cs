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
                    buttonSwitchToGraceful.Enabled = false;
                    buttonUpdateTokensList.Enabled = true;
                    buttonActivateSelectedTokens.Enabled = true;
                }
                selectedTokens.Clear();
            }
            finally
            {
                _isbuttonSwitchToGracefulBusy = false;
            }


        }


        private bool _isbuttonUpdateTokensList_ClickBusy = false;
        private PaginatedRequest<List<TokenInfo>>? lstTnkResp;
        private HashSet<TokenInfo> selectedTokens = [];
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
                lstTnkResp = new PaginatedRequest<List<TokenInfo>>(
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

                        var selectedIds = new HashSet<int>(selectedTokens.Select(it => it.id));

                        _isBeingAdded = true;

                        clbTokensList.Items.Clear();
                        foreach (var token in response)
                        {
                            clbTokensList.Items.Add(token, isChecked: selectedIds.Contains(token.id));
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
                        .Select(item => item.fingerprint).ToList()
                    );

                    var result = MessageBox.Show(
                        $"Будут активированы следующие токены:\n{selectedFingerprints}\nВы уверены, что хотите продолжить?\nСистема будет переведена в on режим",
                        "Подтверждение",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question
                    );

                    if (result != DialogResult.OK) { return; }

                    var selectedIds = selectedTokens
                        .Select(item => item.id).ToList();

                    using var req = new PaginatedRequest<ActivatedInfo>(
                        usePagination: false,
                        method: HttpMethod.Post,
                        url: "/tokens/bulk-activate/",
                        payload: new
                        {
                            is_active = true,
                            ids = selectedIds
                        },
                        onSuccess: (StatusCode, response) =>
                        {
                            MessageBox.Show($"Активировано токенов: {response.updated}", "Активировано", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    );
                    await req.FetchCurrentPage();
                }

                await GetOrSetEnforcingMode("on");

                clbTokensList.Items.Clear();
                buttonUpdateTokensList.Enabled = false;
                buttonSwitchToGraceful.Enabled = true;
                buttonActivateSelectedTokens.Enabled = false;


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
                selectedTokens.Add(((TokenInfo)clbTokensList.Items[e.Index]));
            }
            else
            {
                selectedTokens.Remove(((TokenInfo)clbTokensList.Items[e.Index]));
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


        PaginatedRequest<List<FullTokenInfo>>? allTknInfo = null;
        private void btnAllTknSearch_Click(object sender, EventArgs e)
        {
            if (allTknInfo != null)
            {
                allTknInfo.Dispose();
                allTknInfo = null;
            }

            allTknInfo = new PaginatedRequest<List<FullTokenInfo>>(
                usePagination: true,
                method: HttpMethod.Get,
                url: $"/tokens/",
                parameters: new Dictionary<string, string?>
                {
                    ["search"] = txtAllTknSearch.Text,
                    ["is_active"] = cbOnlyActive.Checked ? "true" : null,
                    ["has_user"] = cbOnlyLinked.Checked ? "true" : null,
                },
                payload: null,
                nextPageButton: btnAllTknNext,
                previousPageButton: btnAllTknPrev,
                labelCurrentPage: LblAllTkn,
                onSuccess: (StatusCode, response) =>
                {
                    dgvAllTkn.SuspendLayout();
                    dgvAllTkn.Rows.Clear();
                    foreach (FullTokenInfo token in response)
                    {
                        int rowIndex = dgvAllTkn.Rows.Add(
                            token.id,
                            token.fingerprint!,
                            token.pubkey!,
                            token.is_active,
                            token.can_reset_password,
                            token.last_activated.ToString("o"),
                            token.allowed_ips ?? "",
                            token.user ?? "",
                            token.user_additional_data ?? ""
                        );
                        dgvAllTkn.Rows[rowIndex].Tag = token;
                    }
                    dgvAllTkn.ResumeLayout();
                }
                );
            _ = allTknInfo.FetchCurrentPage();

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
            if (await req2.FetchCurrentPage() != HttpStatusCode.OK ) { return; }

            dgvAllTkn.Rows.Clear();
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
            if (await req2.FetchCurrentPage() != HttpStatusCode.OK ) { return; }

            dgvAllTkn.Rows.Clear();
            btnAllTknSearch.PerformClick();
        }


        private void cbOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            //dgvAllTkn.Rows.Clear();
        }


        private void cbOnlyLinked_CheckedChanged(object sender, EventArgs e)
        {
            //dgvAllTkn.Rows.Clear();
        }


        private readonly Dictionary<int, FormEditToken> _openTokenForms = new();


        private void dgvAllTkn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            var row = dgvAllTkn.Rows[e.RowIndex];
            var token = (FullTokenInfo)row.Tag!;
            var token_id = token.id;

            if (_openTokenForms.TryGetValue(token_id, out var frm))
            {
                if (frm.WindowState == FormWindowState.Minimized)
                    frm.WindowState = FormWindowState.Normal;

                frm.BringToFront();

                return;
            }

            var dlg = new FormEditToken { token = token };

            dlg.PerformedSave += (_, _) => btnAllTknSearch.PerformClick();
            dlg.FormClosed += (_, _) => btnAllTknSearch.PerformClick();
            dlg.FormClosed += (_, _) => _openTokenForms.Remove(token_id);

            _openTokenForms[token_id] = dlg;

            dlg.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTab = tabControl1.SelectedTab;

            if (selectedTab == tpListTokens)
            {
                btnAllTknSearch.PerformClick();
            }
        }

        private void dgvAllTkn_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAllTkn.IsCurrentCellDirty)
            {
                dgvAllTkn.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private async void dgvAllTkn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            if (dgvAllTkn.Columns[e.ColumnIndex] is not DataGridViewCheckBoxColumn col) { return; }

            bool isChecked = (bool)dgvAllTkn.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!;
            var row = dgvAllTkn.Rows[e.RowIndex];
            var token = (FullTokenInfo)row.Tag!;
            string msg = (col.Name) switch
            {
                "ColumnIsActive" => $"{(isChecked ? "Активировать" : "Деактивировать")} токен {token.fingerprint}?",
                "ColumnCanResetPassword" => $"{(isChecked ? "Разрешить" : "Запретить")} изменение пин-кода при следующем входе токена {token.fingerprint}?",
                _ => "Неизвестная колонка, нажмите \"Нет\"."
            };

            if (MessageBox.Show(msg, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                btnAllTknSearch.PerformClick();
                return;
            }

            var payload = new Dictionary<string, object>();
            if (col.Name == "ColumnIsActive") payload["is_active"] = isChecked;
            if (col.Name == "ColumnCanResetPassword") payload["can_reset_password"] = isChecked;

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

        private void txtAllTknSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAllTknSearch.PerformClick();
            }
        }
    }
}
