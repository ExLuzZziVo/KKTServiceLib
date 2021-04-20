#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Shared.Types.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при ошибках проверки всех полей данных объекта
    /// </summary>
    public class ExtendedValidationException : Exception
    {
        private readonly List<string> _validationErrors = new List<string>();

        /// <summary>
        /// Исключение, возникающее при ошибках проверки всех полей данных объекта
        /// </summary>
        /// <param name="errors">Список ошибок в виде коллекции объектов <see cref="ValidationResult"/></param>
        public ExtendedValidationException(IEnumerable<ValidationResult> errors)
        {
            foreach (var ve in errors) _validationErrors.Add(ve.ErrorMessage);
        }

        /// <summary>
        /// Исключение, возникающее при ошибках проверки всех полей данных объекта
        /// </summary>
        /// <param name="errors">Список ошибок в виде коллекции строк</param>
        public ExtendedValidationException(IEnumerable<string> errors)
        {
            _validationErrors.AddRange(errors);
        }

        /// <summary>
        /// Исключение, возникающее при ошибках проверки всех полей данных объекта
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public ExtendedValidationException(string message): base(message)
        {
            _validationErrors.Add(message);
        }

        /// <summary>
        /// Список всех ошибок валидации
        /// </summary>
        public IEnumerable<string> ValidationErrors => _validationErrors;
    }
}