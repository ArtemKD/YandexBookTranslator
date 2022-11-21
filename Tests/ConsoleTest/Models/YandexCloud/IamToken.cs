using System.Net.Http.Json;
using System.Text.Json;

namespace ConsoleTest.Models.YandexCloud
{
    internal static class IamToken
    {
        public static async Task<Reply> Get(string oAuthToken, CancellationToken cancellationToken)
        {
            string iamToken = string.Empty;
            Uri iamUri = new Uri("https://" + "iam.api.cloud.yandex.net" + "/iam/v1/tokens");
            HttpClient iamConnection = new HttpClient();

            var data = new Dictionary<String, String>()
            {
                {"yandexPassportOauthToken", oAuthToken }
            };

            JsonDocument? requestJsonData;
            JsonDocument? responceJsonData;
            HttpResponseMessage? responce = null;

            try
            {
                requestJsonData = JsonSerializer.SerializeToDocument<Dictionary<String, String>>(data);
                responce = await RetryPolicy.policy.ExecuteAsync(() => iamConnection.PostAsJsonAsync<JsonDocument>(iamUri, requestJsonData, cancellationToken));
                responceJsonData = await responce.Content.ReadFromJsonAsync<JsonDocument>();
            }
            catch (HttpRequestException requestEx)
            {
                return new Reply
                {
                    Code = requestEx.HResult,
                    Message = "Ошибка сети, проверьте соединение и повторите попытку"
                };
            }
            catch (TaskCanceledException cancelEx)
            {
                return new Reply
                {
                    Code = -11,
                    Message = "Отмена"
                };
            }
            catch (Exception ex)
            {
                return new Reply
                {
                    Code = ex.HResult,
                    Message = ex.Message
                };
            }
            if (responce.IsSuccessStatusCode)
            {
                return new Reply
                {
                    Code = (int)responce.StatusCode,
                    Message = responceJsonData != null ?
                    responceJsonData.RootElement.GetProperty("iamToken").ToString() :
                    "Empty responce data"
                };
            }
            else
            {
                return new Reply
                {
                    Code = (int)responce.StatusCode,
                    Message = responceJsonData != null ?
                    responceJsonData.RootElement.GetProperty("message").ToString() :
                    "Empty responce data"
                };
            }
        }
    }
}
