#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Enums;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.Session.OpenSession
{
    [Description("Открытие сессии")]
    public class OpenSessionOperation: Operation<OpenSessionResult>
    {
        /// <summary>
        /// Открытие сессии
        /// </summary>
        /// <param name="portName">Имя порта (например: COM1, COM2, USB, /dev/ttyS0)</param>
        public OpenSessionOperation(string portName): base("OpenSession")
        {
            if (portName.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(PortName)).GetPropertyDisplayName()),
                    nameof(portName));
            }

            PortName = portName;
            IsSessionKeyRequired = false;
        }

        /// <summary>
        /// Сессионный ключ
        /// </summary>
        [Display(Name = "Сессионный ключ")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [Required(AllowEmptyStrings = true, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        public override string SessionKey { get; protected set; } = string.Empty;

        /// <summary>
        /// Имя порта
        /// </summary>
        /// <remarks>
        /// Например: COM1, COM2, USB, /dev/ttyS0
        /// </remarks>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Имя порта")]
        public string PortName { get; }

        /// <summary>
        /// Скорость обмена с ККТ
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: 115200
        /// </remarks>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-230400</item>
        /// </list>
        [Range(1, 230400, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Скорость обмена с ККТ")]
        public int? BaudRate { get; set; } = 115200;

        /// <summary>
        /// Модель ККТ
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: <see cref="KKTModel._119F"/>
        /// </remarks>
        [Display(Name = "Модель ККТ")]
        public KKTModel? Model { get; set; } = KKTModel._119F;

        /// <summary>
        /// Серийный номер ККТ
        /// </summary>
        [Display(Name = "Серийный номер ККТ")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Отладка
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Отладка")]
        public bool? Debug { get; set; } = false;

        /// <summary>
        /// Полный путь к каталогу лог-файлов
        /// </summary>
        [Display(Name = "Полный путь к каталогу лог-файлов")]
        public string LogPath { get; set; }
    }
}