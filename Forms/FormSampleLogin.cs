using diplomaadminpanel.Models;
using diplomaadminpanel.Utils;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;

namespace diplomaadminpanel.Forms
{
    public partial class FormSampleLogin : Form
    {
        public FormSampleLogin()
        {
            InitializeComponent();
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? InitialUuid { get; set; }

        private void BtnSimulateLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length > 0 && Guid.TryParse(txtLogin.Text, out _))
            {
                timer1.Enabled = true;
                BtnSimulateLogin.Enabled = false;
                txtLogin.Enabled = false;
            }
        }


        private void reinitialize()
        {
            BtnSimulateLogin.Enabled = true;
            if (InitialUuid == null)
            {
                txtLogin.Enabled = true;
            }
            progressBar1.Value = 0;
            label3.Text = "Ожидание команды";
            timer_ticks = 0;
        }


        int timer_ticks = 0;
        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (timer_ticks >= 5)
            {
                MessageBox.Show(
                    "Не удалось получить подтверждение от токена",
                    "Вход",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                reinitialize();
                return;
            }

            timer_ticks++;
            progressBar1.Value = Math.Min(Math.Max(timer_ticks * 100 / 5, 0), 100);
            label3.Text = $"Ожидаю подтверждение от токена {timer_ticks}/5";

            await new PaginatedRequest<CanLoginInfo>(
                usePagination: false,
                HttpMethod.Get,
                url: $"/canlogin/{txtLogin.Text}",
                onSuccess: (HttpStatusCode, response) => {
                    if (response.status)
                    {
                        MessageBox.Show(
                            "Успешный вход!",
                            "Вход",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        if (InitialUuid != null)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        reinitialize();
                    }
                    else timer1.Start();
                }).FetchCurrentPage();
        }


        private void Form1_Load(object sender, EventArgs e) {
            if (InitialUuid != null)
            {
                txtLogin.Text = InitialUuid;
                txtLogin.Enabled = false;
            }

        }
    }
}
