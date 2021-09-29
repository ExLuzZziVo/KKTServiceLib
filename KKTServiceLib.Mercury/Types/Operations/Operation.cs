using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KKTServiceLib.Mercury.Helpers;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Mercury.Types.Operations
{
    public abstract class Operation<T> where T : OperationResult
    {
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Сессионный ключ")]
        public string SessionKey { get; protected set; }

        /// <summary>
        /// Имя команды
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Имя команды")]
        public string Command { get; }

        /// <summary>
        /// Проверка текущего задания
        /// </summary>
        /// <returns>Список ошибок</returns>
        protected virtual IEnumerable<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>(32);

            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

            return validationResults;
        }

        /// <summary>
        /// Запуск выбранной задачи
        /// </summary>
        /// <param name="sessionKey">Сессионный ключ</param>
        /// <param name="driverUrl">Адрес службы Inecrman</param>
        /// <exception cref="ExtendedValidationException">Выбрасывает исключение, если задача не прошла проверку перед отправкой на выполнение</exception>
        /// <exception cref="KKTExecuteOperationException">Выбрасывает исключение, если выполнение задачи не удалось</exception>
        /// <remarks>
        /// Значение <paramref name="driverUrl"/> по умолчанию: "http://127.0.0.1:50010/api.json"
        /// </remarks>
        /// <returns>Возвращает результат выполнения задачи</returns>
        public virtual T Execute(string sessionKey, string driverUrl = "http://127.0.0.1:50010/api.json")
        {
            SessionKey = sessionKey;

            var validationResults = Validate();

            if (validationResults.Count() != 0)
            {
                throw new ExtendedValidationException(validationResults);
            }

            var jsonData = JsonConvert.SerializeObject(this,
                Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore, TypeNameHandling = TypeNameHandling.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            var jsonResult = InecrmanServiceConnector.SendJson(jsonData, driverUrl);

            if (jsonResult.IsNullOrEmptyOrWhiteSpace())
            {
                return default;
            }

            var result = JsonConvert.DeserializeObject<T>(jsonResult);

            if (result.Result != 0)
            {
                throw new KKTExecuteOperationException(result.Result, result.Description);
            }

            return result;
        }
    }
}