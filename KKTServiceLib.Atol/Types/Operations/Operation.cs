#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Atol.Drivers10.Fptr;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#endregion

namespace KKTServiceLib.Atol.Types.Operations
{
    public abstract class Operation<T> : IValidatableObject
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

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }

        /// <summary>
        /// Асинхронный запуск выбранной операции
        /// </summary>
        /// <param name="fptr">Экземпляр драйвера ККТ АТОЛ</param>
        /// <exception cref="ExtendedValidationException">Выбрасывает исключение, если задача не прошла проверку перед отправкой на выполнение</exception>
        /// <exception cref="KKTExecuteOperationException">Выбрасывает исключение, если выполнение задачи не удалось</exception>
        /// <returns>Задача, асинхронно возвращающая результат выполнения операции</returns>
        public Task<T> ExecuteAsync(Fptr fptr)
        {
            return Task.Run(() => Execute(fptr));
        }

        /// <summary>
        /// Запуск выбранной операции
        /// </summary>
        /// <param name="fptr">Экземпляр драйвера ККТ АТОЛ</param>
        /// <exception cref="ExtendedValidationException">Выбрасывает исключение, если задача не прошла проверку перед отправкой на выполнение</exception>
        /// <exception cref="KKTExecuteOperationException">Выбрасывает исключение, если выполнение задачи не удалось</exception>
        /// <returns>Возвращает результат выполнения операции</returns>
        public virtual T Execute(Fptr fptr)
        {
            var validationResults = new List<ValidationResult>(32);

            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

            if (validationResults.Count() != 0)
            {
                throw new ExtendedValidationException(validationResults);
            }

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
            {
                return default;
            }

            var result = JsonConvert.DeserializeObject<T>(jsonResult);

            return result;
        }
    }
}