#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Atol.Drivers10.Fptr;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#endregion

namespace AtolKKTServiceLib.Types.Operations
{
    public abstract class Operation<T>
    {
        /// <summary>
        /// Создание JSON-задания ККТ
        /// </summary>
        /// <param name="type">Наименование задания</param>
        protected Operation(string type)
        {
            Type = type;
        }

        /// <summary>
        /// Тип задания
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип задания")]
        public string Type { get; }

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
        /// <param name="fptr">Экземпляр драйвера ККТ АТОЛ</param>
        /// <exception cref="ExtendedValidationException">Выбрасывает исключение, если задача не прошла проверку перед отправкой на выполнение</exception>
        /// <exception cref="KKTExecuteOperationException">Выбрасывает исключение, если выполнение задачи не удалось</exception>
        /// <returns>Возвращает результат выполнения задачи</returns>
        public virtual T Execute(Fptr fptr)
        {
            var validationResults = Validate();
            if (validationResults.Count() != 0)
                throw new ExtendedValidationException(validationResults);

            var jsonData = JsonConvert.SerializeObject(this,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore, TypeNameHandling = TypeNameHandling.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            fptr.setParam(Constants.LIBFPTR_PARAM_JSON_DATA, jsonData);

            if (fptr.validateJson() < 0)
            {
                var errorCode = fptr.errorCode();

                if (errorCode != 504)
                {
                    throw new KKTExecuteOperationException(errorCode, fptr.errorDescription());
                }
            }

            fptr.setParam(Constants.LIBFPTR_PARAM_JSON_DATA, jsonData);

            if (fptr.processJson() < 0)
            {
                throw new KKTExecuteOperationException(fptr.errorCode(), fptr.errorDescription());
            }

            var jsonResult = fptr.getParamString(Constants.LIBFPTR_PARAM_JSON_DATA);

            if (jsonResult.IsNullOrEmptyOrWhiteSpace())
                return default;

            var result = JsonConvert.DeserializeObject<T>(jsonResult);

            return result;
        }
    }
}