#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Common;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.Settings.SetKKTSettings
{
    [Description("Запись настроек ККТ")]
    public class SetKKTSettingsOperation : Operation<SetKKTSettingsResult>
    {
        /// <summary>
        /// Запись настроек ККТ
        /// </summary>
        /// <param name="deviceParameters">Список номеров настроек и их значений для записи</param>
        public SetKKTSettingsOperation(IDictionary<uint, string> deviceParameters) : base("setDeviceParameters")
        {
            if (deviceParameters?.Any() != true)
            {
                throw new ArgumentException(string.Format(ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        GetType().GetProperty(nameof(DeviceParameters)).GetDisplayName(), 1),
                    nameof(deviceParameters));
            }

            DeviceParameters = new JsonArrayReadOnlyDictionary<uint, string>(deviceParameters);
        }

        /// <summary>
        /// Настройки ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Настройки ККТ")]
        public JsonArrayReadOnlyDictionary<uint, string> DeviceParameters { get; }
    }
}