#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.Settings.ReadKKTSettings
{
    [Description("Чтение настроек ККТ")]
    public class ReadKKTSettingsOperation: Operation<ReadKKTSettingsResult>
    {
        /// <summary>
        /// Чтение настроек ККТ
        /// </summary>
        /// <param name="keys">Список номеров настроек для чтения</param>
        public ReadKKTSettingsOperation(ISet<uint> keys): base("getDeviceParameters")
        {
            if (keys?.Any() != true)
            {
                throw new ArgumentException(string.Format(
                        ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(Keys)).GetPropertyDisplayName(), 1),
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
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Display(Name = "Список номеров настроек для чтения")]
        public ISet<uint> Keys { get; }
    }
}