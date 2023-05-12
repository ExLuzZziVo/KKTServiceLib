using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Converters;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Операционный реквизит чека")]
    public class OperationParams
    {
        /// <summary>
        /// Операционный реквизит чека
        /// </summary>
        /// <param name="id">Идентификатор операции</param>
        /// <param name="dateTime">Дата, время операции</param>
        /// <param name="data">Данные операции</param>
        public OperationParams(byte id, DateTime dateTime, string data)
        {
            if (data.IsNullOrEmptyOrWhiteSpace() || data.Length > 64)
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(AttrValue)).GetDisplayName()),
                    nameof(data));
            }

            OpID = id;
            OpTime = dateTime;
            AttrValue = data;
        }

        /// <summary>
        /// Идентификатор операции
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Идентификатор операции")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public byte OpID { get; }

        /// <summary>
        /// Дата, время операции
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Дата, время операции")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-ddTHH:mm:ss")]
        public DateTime OpTime { get; }

        /// <summary>
        /// Данные операции
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 64</item>
        /// </list>
        [Display(Name = "Данные операции")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(64, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string AttrValue { get; }
    }
}