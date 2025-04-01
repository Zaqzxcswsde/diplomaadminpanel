using Microsoft.AspNetCore.WebUtilities;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace diplomaadminpanel.Utils
{
    internal class PaginatedRequest<T> : IDisposable, IPaginatedRequestWrapper
    {

        internal class PagedResponse<U>
        {
            public int count { get; set; }
            public string? next { get; set; }
            public string? previous { get; set; }
            public required U results { get; set; }
        }

        private readonly bool usePagination;
        private readonly HttpMethod method;
        private readonly string url;
        private readonly Dictionary<string, string?>? parameters;
        private readonly object? payload;
        private readonly Action<HttpStatusCode, T>? onSuccess;
        private readonly Action<HttpStatusCode, string>? onError;
        private string adminToken => Utils.GetAdminToken();

        private readonly Button? nextPageButton;
        private readonly Button? previousPageButton;
        private readonly Label? labelCurrentPage;

        private int currentPage = 1;

        private int? totalPages;
        private bool hasNext = false;
        private bool hasPrevious = false;

        private int pageSize = 10;

        internal PaginatedRequest(
            bool usePagination,
            HttpMethod method,
            string url,
            Dictionary<string, string?>? parameters = null,
            object? payload = null,
            Action<HttpStatusCode, T>? onSuccess = null,
            Action<HttpStatusCode, string>? onError = null,
            Button? nextPageButton = null,
            Button? previousPageButton = null,
            Label? labelCurrentPage = null,
            int pageSize = 10
        )
        {
            this.usePagination = usePagination;
            this.method = method;
            this.url = $"{Utils.Get_url()}{(url.StartsWith("/") ? url : "/" + url)}";
            this.parameters = parameters ?? new();
            this.payload = payload;
            this.onSuccess = onSuccess;
            this.onError = DefaultErrorHandler + onError;
            this.labelCurrentPage = labelCurrentPage;
            this.nextPageButton = nextPageButton;
            this.previousPageButton = previousPageButton;
            if (this.nextPageButton != null) this.nextPageButton.Click += NextButtonClick;
            if (this.previousPageButton != null) this.previousPageButton.Click += PreviousButtonClick;
            this.pageSize = pageSize;

            if (this.usePagination)
            {
                this.parameters.TryAdd("page_size", this.pageSize.ToString());
            }
        }


        private string getUrl(int page)
        {
            Dictionary<string, string?> paramsWithPage;

            if (this.usePagination)
            {
                paramsWithPage = new Dictionary<string, string?>(parameters!)
                {
                    ["page"] = page.ToString()
                };
            }
            else
            {
                paramsWithPage = new Dictionary<string, string?>(parameters!);
            }

            if (paramsWithPage.Count > 0)
            {
                var urlWithSlash = this.url.EndsWith('/') ? this.url : this.url + "/";
                //var urlWithoutSlash = this.url.EndsWith('/') ? this.url[..^1] : this.url;
                return QueryHelpers.AddQueryString(urlWithSlash, paramsWithPage);
            }
            else
            {
                return this.url.EndsWith('/') ? this.url : this.url + "/";
            }
        }

        private void DefaultErrorHandler(HttpStatusCode StatusCode, string response)
        {
            string errstr = StatusCode != (HttpStatusCode)0 ? $"\nКод ответа: {StatusCode}" : "";

            MessageBox.Show($"Ошибка при отправке запроса.{errstr}\n{Utils.Truncate(response)}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool _isNextButtonBusy = false;
        private bool _isPreviousButtonBusy = false;

        private async void NextButtonClick(object? sender, EventArgs e)
        {
            if (_isNextButtonBusy) { return; }
            _isNextButtonBusy = true;
            await FetchNextPage();
            _isNextButtonBusy = false;
        }
        private async void PreviousButtonClick(object? sender, EventArgs e)
        {
            if (_isPreviousButtonBusy) { return; }
            _isPreviousButtonBusy = true;
            await FetchPreviousPage();
            _isPreviousButtonBusy = false;
        }


        private async Task<HttpStatusCode> SendRequestAsync(int page)
        {
            //await Task.Delay(3000);

            this.currentPage = page;

            string reqest_url = getUrl(page);

            Debug.WriteLine(reqest_url);
            //Debug.WriteLine(parameters);
            //Debug.WriteLine(payload);

            try
            {
                using var requestMessage = new HttpRequestMessage(method, reqest_url);

                if (payload != null)
                {
                    string json = JsonSerializer.Serialize(payload);
                    //Debug.WriteLine(json);
                    requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                requestMessage.Headers.Add("X-Admin-Token", this.adminToken);
                var response = await Utils.httpClient.SendAsync(requestMessage);

                string respContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"[{response.StatusCode}] {respContent}");

                if (response.IsSuccessStatusCode)
                {

                    if (onSuccess != null)
                    {
                        try
                        {
                            if (typeof(T) == typeof(string))
                            {
                                onSuccess(response.StatusCode, (T)(object)respContent);
                            }
                            else
                            {
                                object? parsed;

                                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                                if (this.usePagination)
                                {
                                    parsed = JsonSerializer.Deserialize<PagedResponse<T>>(respContent, options);
                                }
                                else
                                {
                                    parsed = JsonSerializer.Deserialize<T>(respContent, options);
                                }


                                if (parsed != null)
                                {
                                    if (this.usePagination)
                                    {
                                        this.hasNext = (((PagedResponse<T>)parsed).next != null);
                                        this.hasPrevious = (((PagedResponse<T>)parsed).previous != null);

                                        if (((PagedResponse<T>)parsed).count > 0)
                                        {
                                            totalPages = (int)Math.Ceiling((double)((PagedResponse<T>)parsed).count / this.pageSize);
                                        }
                                        else
                                        {
                                            totalPages = 0;
                                        }


                                        UpdateButtons();
                                        UpdateLabel();

                                        onSuccess?.Invoke(response.StatusCode, ((PagedResponse<T>)parsed).results);
                                    }
                                    else
                                    {
                                        onSuccess?.Invoke(response.StatusCode, (T)parsed);
                                    }
                                }
                                else
                                {
                                    onError?.Invoke(response.StatusCode, "Empty response");
                                }
                            }
                        }
                        catch (JsonException jsonEx)
                        {
                            Debug.WriteLine($"Ошибка парсинга JSON: {jsonEx.Message}");
                            onError?.Invoke(response.StatusCode, $"JSON error: {jsonEx.Message}");
                        }
                    }
                }
                else
                {
                    onError?.Invoke(response.StatusCode, respContent);
                }
                return response.StatusCode;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Error sending request: {ex.Message}");

                string errmsg = ex.Message;

                if (ex.InnerException is System.Net.Sockets.SocketException ||
                    ex.InnerException is System.Net.WebException && ex.InnerException.InnerException is System.Net.Sockets.SocketException)
                {
                    errmsg = "Сервер выключен или недоступен";
                }

                onError?.Invoke((HttpStatusCode)0, errmsg);
                return (HttpStatusCode)0;
            }
        }

        public Task<HttpStatusCode> FetchCurrentPage() => SendRequestAsync(currentPage);
        public Task<HttpStatusCode> FetchNextPage() => SendRequestAsync(currentPage + 1);
        public Task<HttpStatusCode> FetchPreviousPage() => SendRequestAsync(currentPage > 1 ? currentPage - 1 : currentPage);

        private void UpdateButtons()
        {
            if (this.nextPageButton != null) this.nextPageButton.Enabled = this.hasNext;
            if (this.previousPageButton != null) this.previousPageButton.Enabled = this.hasPrevious;
        }

        private void UpdateLabel()
        {
            if (this.labelCurrentPage != null)
            {
                this.labelCurrentPage.Text = $"{(totalPages > 0 ? currentPage : 0)}/{totalPages}";
            }
        }

        public void Dispose()
        {
            //Debug.WriteLine("!!!");
            if (this.nextPageButton != null)
            {
                nextPageButton.Enabled = false;
                nextPageButton.Click -= NextButtonClick;
            }
            if (this.previousPageButton != null)
            {
                previousPageButton.Enabled = false;
                previousPageButton.Click -= PreviousButtonClick;
            }
        }

    }
}
