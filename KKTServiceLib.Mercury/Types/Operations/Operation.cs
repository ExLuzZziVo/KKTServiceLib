#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using CoreLib.CORE.Types;
using KKTServiceLib.Shared.Types.Exceptions;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations
{
    public abstract class Operation<T> : IValidatableObject where T : OperationResult
    {
        protected static readonly JsonSerializerOptions OperationJsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        protected static readonly JsonSerializerOptions OperationResultJsonSerializerOptions =
            new JsonSerializerOptions(JsonSerializerDefaults.Web);

        /// <summary>
        /// Создание JSON-задания ККТ
        /// </summary>
        /// <param name="type">Наименование задания</param>
        protected Operation(string type)
        {
            Command = type;
        }

        /// <summary>
        /// Сессионный ключ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Сессионный ключ")]
        public virtual string SessionKey { get; protected set; }

        /// <summary>
        /// Костыль, который необходим после обновления библиотеки <see cref="System.ComponentModel.DataAnnotations"/> и/или net6.0. Значение по умолчанию: true
        /// </summary>
        protected bool IsSessionKeyRequired { get; set; } = true;

        /// <summary>
        /// Имя команды
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Имя команды")]
        public string Command { get; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }

        /// <summary>
        /// Запуск выбранной операции
        /// </summary>
        /// <param name="sessionKey">Сессионный ключ</param>
        /// <param name="driverUrl">Адрес службы Inecrman</param>
        /// <exception cref="ExtendedValidationException">Выбрасывает исключение, если задача не прошла проверку перед отправкой на выполнение</exception>
        /// <exception cref="KKTExecuteOperationException">Выбрасывает исключение, если выполнение задачи не удалось</exception>
        /// <remarks>
        /// Значение <paramref name="driverUrl"/> по умолчанию: "http://127.0.0.1:50010/api.json". Метод остался синхронным для совместимости
        /// </remarks>
        /// <returns>Возвращает результат выполнения операции</returns>
        public async Task<T> ExecuteAsync(string sessionKey,
            string driverUrl = "http://127.0.0.1:50010/api.json")
        {
            using (var httpClient = new HttpClient())
            {
                return await ExecuteAsync(httpClient, sessionKey, driverUrl);
            }
        }

        /// <summary>
        /// Асинхронный запуск выбранной операции, используя <see cref="HttpClient"/>
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="sessionKey">Сессионный ключ</param>
        /// <param name="driverUrl">Адрес службы Inecrman</param>
        /// <exception cref="ExtendedValidationException">Выбрасывает исключение, если задача не прошла проверку перед отправкой на выполнение</exception>
        /// <exception cref="KKTExecuteOperationException">Выбрасывает исключение, если выполнение задачи не удалось</exception>
        /// <remarks>
        /// Значение <paramref name="driverUrl"/> по умолчанию: "http://127.0.0.1:50010/api.json"
        /// </remarks>
        /// <returns>Задача, асинхронно возвращающая результат выполнения выбранной операции, использовавшей <see cref="HttpClient"/></returns>
        public virtual async Task<T> ExecuteAsync(HttpClient httpClient, string sessionKey,
            string driverUrl = "http://127.0.0.1:50010/api.json")
        {
            // Костыль. См. описание IsSessionKeyRequired
            if (IsSessionKeyRequired)
            {
                if (sessionKey.IsNullOrEmptyOrWhiteSpace())
                {
                    throw new ArgumentNullException(nameof(sessionKey));
                }

                SessionKey = sessionKey;
            }

            var validationResults = new List<ValidationResult>(32);

            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

            if (validationResults.Count() != 0)
            {
                throw new ExtendedValidationException(validationResults);
            }

            // Костыль. См. описание IsSessionKeyRequired
            if (!IsSessionKeyRequired)
            {
                SessionKey = null;
            }

            var jsonData = JsonSerializer.Serialize(this, GetType(), OperationJsonSerializerOptions);

            string jsonResult;

            using (var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, driverUrl)
                   {
                       Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
                   }))
            {
                jsonResult = await response.Content.ReadAsStringAsync();
            }

            if (jsonResult.IsNullOrEmptyOrWhiteSpace())
            {
                return default;
            }

            var result = JsonSerializer.Deserialize<T>(jsonResult, OperationResultJsonSerializerOptions);

            if (result.Result != 0)
            {
                throw new KKTExecuteOperationException(result.Result, result.Description);
            }

            return result;
        }
    }
}