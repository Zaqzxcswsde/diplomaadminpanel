using diplomaadminpanel.Models;
using dotenv.net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomaadminpanel.Utils
{
    internal static partial class Utils
    {

        public async static void PopulateOrderingComboBox(string url, ComboBox cb)
        {
            if (cb.Items.Count == 0)
            {
                if (await new PaginatedRequest<OrderingResponse>(
                    usePagination: false,
                    method: HttpMethod.Get,
                    url: url,
                    onSuccess: (StatusCode, response) =>
                    {
                        foreach (var item in response.choices!)
                        {
                            cb.Items.Add(new ComboBoxItem { Tag = item.Key, Text = item.Value + " ↑" });
                            cb.Items.Add(new ComboBoxItem { Tag = "-" + item.Key, Text = item.Value + " ↓" });
                        }
                        cb.SelectedItem = cb.Items
                            .OfType<ComboBoxItem>()
                            .FirstOrDefault(it => it.Tag?.ToString() == response.@default);
                    }
                ).FetchCurrentPage() != HttpStatusCode.OK) return;
            }
        }



        public static string Truncate(string input, int maxLength = 500)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return input.Length <= maxLength ? input : input.Substring(0, maxLength) + "\n...\n(truncated)";
        }



        internal static string Env => Properties.Settings.Default.env;

        public static string Get_url()
        {
            string domain = "";
            string proto = "";

            switch (Env)
            {
                case "dev":
                    domain = "192.168.1.67:8000";
                    proto = "http";
                    break;

                case "prod":
                    domain = "zaqzxcswsde.ru";
                    proto = "https";
                    break;
            }

            return $"{proto}://{domain}";
        }


        public static string GetAdminToken()
        {
            string varName = $"ADMIN_TOKEN_{Env.ToUpper()}";
            if (!dotenv.net.Utilities.EnvReader.TryGetStringValue(varName, out string token))
            {
                MessageBox.Show(
                    $"Не удаётся найти токен {varName}.\nПриложение не может продолжать работу.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                Application.Exit();
            }
            return token;
        }


        public static async Task<(HttpStatusCode StatusCode, string Content)> GetOrSetEnforcingMode(
            string? newMode = null,
            Label? lbl = null
            )
        {
            return await _GetOrSetEnforcingMode(
                newMode: newMode,
                lbl != null ? ((text) => {
                    lbl.Text = $"Текущий режим: {text}";

                    switch (text)
                    {
                        case "on": lbl.ForeColor = Color.Black; break;
                        case "gr": lbl.ForeColor = Color.Green; break;
                        case "of": lbl.ForeColor = Color.Red; break;
                        default: lbl.ForeColor = Color.Black; break;
                    }

                }) : null);
        }


        public static async Task<(HttpStatusCode StatusCode, string Content)> GetOrSetEnforcingMode(
            string? newMode = null,
            ToolStripLabel? lbl = null
            )
            {
                return await _GetOrSetEnforcingMode(
                    newMode: newMode,
                    lbl != null ? ((text) => {
                        lbl.Text = $"Текущий режим: {text}";

                        switch (text)
                        {
                            case "on": lbl.ForeColor = Color.Black; break;
                            case "gr": lbl.ForeColor = Color.Green; break;
                            case "of": lbl.ForeColor = Color.Red; break;
                            default: lbl.ForeColor = Color.Black; break;
                        }

                    }) : null);
            }


        private static async Task<(HttpStatusCode StatusCode, string Content)> _GetOrSetEnforcingMode(
            string? newMode = null,
            Action<string>? setText = null
        ){
            (HttpStatusCode status, string content) result = default;

            using var req = new PaginatedRequest<EnforcingModeInfo>(
                usePagination: false,
                method: newMode is not null ? HttpMethod.Post : HttpMethod.Get,
                url: "/enforcing-mode/",
                payload: newMode is not null ? new { enforcing_mode = newMode } : null,
                onSuccess: (StatusCode, response) =>
                {
                    if (setText != null) setText(response.enforcing_mode);

                    result = (StatusCode, response.enforcing_mode);
                },
                onError: (StatusCode, response) =>
                {
                    if (setText != null) setText("<placeholder>");

                    result = (StatusCode, response);
                });
            await req.FetchCurrentPage();

            return result;
        }

    }
}
