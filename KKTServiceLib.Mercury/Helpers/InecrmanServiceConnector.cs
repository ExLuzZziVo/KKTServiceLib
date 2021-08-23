using System.IO;
using System.Net;
using System.Text;

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
        /// Значение <paramref name="driverUrl"/> по умолчанию: "http://127.0.0.1:50010/api.json"
        /// </remarks>
        /// <returns></returns>
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
    }
}