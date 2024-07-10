#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.Settings.SetKKTSettings
{
    [Description("Запись настроек ККТ")]
    public class SetKKTSettingsOperation: Operation<SetKKTSettingsResult>
    {
        /// <summary>
        /// Запись настроек ККТ
        /// </summary>
        /// <param name="deviceParameters">Список номеров настроек и их значений для записи</param>
        public SetKKTSettingsOperation(IDictionary<uint, string> deviceParameters): base("setDeviceParameters")
        {
            if (deviceParameters?.Any() != true)
            {
                throw new ArgumentException(string.Format(
                        ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(DeviceParameters)).GetPropertyDisplayName(), 1),
                    nameof(deviceParameters));
            }

            DeviceParameters = new ReadOnlyDictionary<uint, string>(deviceParameters);
        }

        /// <summary>
        /// Настройки ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [JsonConverter(typeof(DictionaryToArrayConverter<uint, string>))]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Настройки ККТ")]
        public ReadOnlyDictionary<uint, string> DeviceParameters { get; }
    }
}