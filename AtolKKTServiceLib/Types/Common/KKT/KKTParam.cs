#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

#endregion

namespace AtolKKTServiceLib.Types.Common.KKT
{
    [Description("Параметр ККТ")]
    public class KKTSettingsResultParam
    {
        /// <summary>
        /// Параметр ККТ
        /// </summary>
        /// <param name="key">Номер настройки</param>
        /// <param name="value">Значение</param>
        public KKTSettingsResultParam(uint key, string value)
        {
            Key = key;
            Value = value;
        }

        [JsonConstructor]
        private KKTSettingsResultParam()
        {
        }

        /// <summary>
        /// Номер настройки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Номер настройки")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public uint Key { get; }

        /// <summary>
        /// Значение настройки
        /// </summary>
        [Display(Name = "Значение настройки")]
        public string Value { get; }

        /// <summary>
        /// Код ошибки
        /// </summary>
        [Display(Name = "Код ошибки")]
        public int ErrorCode { get; }

        /// <summary>
        /// Текст ошибки
        /// </summary>
        [Display(Name = "Текст ошибки")]
        public string ErrorDescription { get; }
    }
}