using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleTest.Models.YandexCloud
{
    internal class Translator
    {
        private string IamToken;
        private Uri YCUri;
        private HttpClient YCConnection;

        private string FolderID;

        public Translator(string iamToken)
        {
            IamToken = iamToken;

            YCUri = new Uri("https://" + "translate.api.cloud.yandex.net" + "/translate/v2/translate");
            YCConnection = new HttpClient();
            YCConnection.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", IamToken);

            FolderID = "b1ga1g0epv5ub27qagll";
        }

        public async Task<Reply> Translate(string[] texts, string sourceLang, string targerLang, CancellationToken cancellationToken)
        {
            if (targerLang == String.Empty)
            {
                return new Reply
                {
                    Code = -1,
                    Message = "Не выбран язык перевода"
                };
            }

            var data = new Dictionary<String, String>()
            {
                { "folderId", FolderID },
                { "texts", "[" + string.Join(",", texts.Select(v => $"\"{v}\"")) + "]"},
                { "targetLanguageCode", targerLang }
            };
            if (sourceLang != String.Empty)
            {
                data.Add("sourceLanguageCode", sourceLang);
            }

            JsonDocument? requestJsonData = null;
            JsonDocument? responceJsonData = null;
            HttpResponseMessage? responce = null;

            try
            {
                requestJsonData = JsonSerializer.SerializeToDocument<Dictionary<String, String>>(data);
                responce = await RetryPolicy.policy.ExecuteAsync(() => YCConnection.PostAsJsonAsync<JsonDocument>(YCUri, requestJsonData, cancellationToken));
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
                    Message = ex.ToString()
                };
            }

            if (responce.IsSuccessStatusCode)
            {
                return new Reply
                {
                    Code = (int)responce.StatusCode,
                    Message = responceJsonData != null ?
                    responceJsonData.RootElement.GetProperty("translations").EnumerateArray().ToList()[0].GetProperty("text").ToString() :
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
