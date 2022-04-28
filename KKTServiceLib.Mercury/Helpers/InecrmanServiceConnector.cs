using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KKTServiceLib.Mercury.Helpers
{
    internal static class InecrmanServiceConnector
    {
        /// <summary>
        /// Соединяется со службой Inecrman и отправляет JSON
        /// </summary>
        /// <param name="json">Сериализованная операция</param>
        /// <param name="driverUrl">Адрес службы Inecrman</param>
        /// <remarks>
        /// Значение <paramref name="driverUrl"/> по умолчанию: "http://127.0.0.1:50010/api.json". Метод остался синхронным для совместимости
        /// </remarks>
        /// <returns>Результат выполнения текущего запроса к api службы Inecrman в виде строки</returns>
        internal static string SendJson(string json, string driverUrl = "http://127.0.0.1:50010/api.json")
        {
            var data = Encoding.UTF8.GetBytes(json);
            var request = WebRequest.Create(driverUrl);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = data.Length;

            using (var str = request.GetRequestStream())
            {
                str.Write(data, 0, data.Length);
            }

            string responseResult;

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        responseResult = sr.ReadToEnd();
                    }
                }
            }

            return responseResult;
        }

        /// <summary>
        /// Асинхронно соединяется со службой Inecrman при помощи предоставленного <see cref="HttpClient"/> и отправляет JSON
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="json">Сериализованная операция</param>
        /// <param name="driverUrl">Адрес службы Inecrman</param>
        /// <remarks>
        /// Значение <paramref name="driverUrl"/> по умолчанию: "http://127.0.0.1:50010/api.json"
        /// </remarks>
        /// <returns>Задача, представляющая результат асинхронного выполнения текущего запроса к api службы Inecrman при помощи предоставленного <see cref="HttpClient"/> в виде строки</returns>
        internal static async Task<string> SendJsonAsync(HttpClient httpClient, string json,
            string driverUrl = "http://127.0.0.1:50010/api.json")
        {
            string responseResult;

            using (var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, driverUrl)
                   {
                       Content = new StringContent(json, Encoding.UTF8, "application/json")
                   }))
            {
                responseResult = await response.Content.ReadAsStringAsync();
            }

            return responseResult;
        }
    }
}