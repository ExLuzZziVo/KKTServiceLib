#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Atol.Drivers10.Fptr;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Exceptions;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.Settings.ReadKKTSettings
{
    [Description("Чтение настроек ККТ")]
    public class ReadKKTSettingsOperation : Operation<ReadKKTSettingsResult>
    {
        /// <summary>
        /// Чтение настроек ККТ
        /// </summary>
        /// <param name="keys">Список номеров настроек для чтения</param>
        public ReadKKTSettingsOperation(ISet<uint> keys) : base("getDeviceParameters")
        {
            if (keys?.Any() != true)
            {
                throw new ArgumentException(string.Format(ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        this.GetType().GetProperty(nameof(Keys)).GetDisplayName(), 1),
                    nameof(keys));
            }

            Keys = keys;
        }

        /// <summary>
        /// Список номеров настроек для чтения
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Display(Name = "Список номеров настроек для чтения")]
        public ISet<uint> Keys { get; }
    }
}