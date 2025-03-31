using diplomaadminpanel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomaadminpanel.Forms
{
    public partial class FormAddToken : Form
    {
        public FormAddToken()
        {
            InitializeComponent();
        }

        private void FormAddToken_Load(object sender, EventArgs e)
        {
            pgViewListUsers.LoadColumns([
                new DataGridViewTextBoxColumn
                {
                    Name = "colFingerprint",
                    HeaderText = "Отпечаток",
                    Width = 150
                },
                new DataGridViewCheckBoxColumn
                {
                    Name = "colIsActive",
                    HeaderText = "Активен?"
                },
                new DataGridViewCheckBoxColumn
                {
                    Name = "colHasUser",
                    HeaderText = "Пользователь привязан?",
                }
                ]
            );
            pgViewListUsers.SetRowBuilder<FullTokenInfo>((elem) => [
                elem.fingerprint!,
                elem.is_active,
                elem.user != null
                ]
            );
            pgViewListUsers.RowDoubleClick += PgViewListUsers_RowDoubleClick;
            btnSearch.PerformClick();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal FullTokenInfo? Result { get; private set; } = null;

        private void PgViewListUsers_RowDoubleClick(object? sender, object e)
        {
            if (e is not FullTokenInfo token) return;

            if (MessageBox.Show(
                token.user == null
                ? $"Привязать к токену {token.fingerprint}?"
                : $"Внимание!\nТокен {token.fingerprint} уже привязан к другому пользователю.\nЕсли вы решите продолжить, то он будет от него отвязан.\nПривязать?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                token.user == null
                ? MessageBoxIcon.Question
                : MessageBoxIcon.Warning) != DialogResult.Yes) return;

            this.DialogResult = DialogResult.OK;
            this.Result = token.Clone();
            this.Close();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            pgViewListUsers.Bind<FullTokenInfo>(
                method: HttpMethod.Get,
                url: "/tokens/",
                parameters: new Dictionary<string, string?>
                {
                    ["search"] = txtSearch.Text
                }
            );
            await pgViewListUsers.FetchCurrentPage();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnSearch.PerformClick();
            }
        }
    }
}
