using System;
using System.Net.Http;
using System.Threading.Tasks;
using Models;
using System.IO;

namespace Services{
    public class ApiRequestService{
        public async Task<(string response, int statusCode)> SendRequestAsync(ApiSetting setting){
            using (HttpClient client = new HttpClient()){
                client.Timeout = TimeSpan.FromSeconds(setting.TimeoutSeconds);

                HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(setting.Method), setting.Url);

                // ヘッダー設定
                if (setting.Headers != null){
                    foreach (var h in setting.Headers)
                        request.Headers.TryAddWithoutValidation(h.Key, h.Value);
                }

                // Bearer認証
                if (setting.AuthType == "Bearer" && !string.IsNullOrEmpty(setting.BearerTokenPath)){
                    string token = File.Exists(setting.BearerTokenPath) ? File.ReadAllText(setting.BearerTokenPath).Trim() : "";
                    if (!string.IsNullOrEmpty(token))
                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }

                // ボディ
                if (!string.IsNullOrEmpty(setting.Body) && setting.Method != "GET"){
                    request.Content = new StringContent(setting.Body, System.Text.Encoding.UTF8, "application/json");
                }

                try{
                    HttpResponseMessage res = await client.SendAsync(request);
                    string content = await res.Content.ReadAsStringAsync();
                    return (content, (int)res.StatusCode);
                } catch (Exception ex) {
                    return ($"Error: {ex.Message}", 0);
                }
            }
        }
    }
}
