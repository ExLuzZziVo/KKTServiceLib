#region

using System;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;

#endregion

namespace KKTServiceLib.Shared.Types.ValidationAttributes
{
    /// <summary>
    /// Атрибут валидации обязательности значения поля на основе значения другого поля
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredIfValidationAttribute : RequiredAttribute
    {
        /// <summary>
        /// Атрибут валидации обязательности значения поля на основе значения другого поля
        /// </summary>
        /// <param name="otherPropertyName">Имя другого поля</param>
        /// <param name="otherPropertyValue">Значение другого поля</param>
        /// <param name="invert">Если истина, то валидация начнется, если значение <paramref name="otherPropertyValue"/> НЕ будет равно значению поля <paramref name="otherPropertyName"/></param>
        public RequiredIfValidationAttribute(string otherPropertyName, object otherPropertyValue, bool invert = false)
        {
            OtherPropertyName = otherPropertyName;
            OtherPropertyValue = otherPropertyValue;
            Invert = invert;
        }

        /// <summary>
        /// Имя другого поля
        /// </summary>
        public string OtherPropertyName { get; }

        /// <summary>
        /// Значение другого поля
        /// </summary>
        public object OtherPropertyValue { get; }

        /// <summary>
        /// Флаг, указывающий, что валидация начнется, если значение <see name="OtherPropertyValue"/> НЕ будет равно значению поля <see name="OtherPropertyName"/>
        /// </summary>
        public bool Invert { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (OtherPropertyName.IsNullOrEmptyOrWhiteSpace())
            {
                return new ValidationResult("Other property name is empty");
            }

            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherPropertyName);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Unknown property: {OtherPropertyName}");
            }

            var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            var valuesEqual = Equals(OtherPropertyValue, otherValue);

            if (valuesEqual && !Invert || !valuesEqual && Invert)
            {
                return base.IsValid(value, validationContext);
            }

            return null;
        }
    }
}