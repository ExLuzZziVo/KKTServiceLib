#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.UploadPicture
{
    [Description("Загрузка картинки клише")]
    public class UploadPictureOperation: Operation<bool>
    {
        /// <summary>
        /// Загрузка картинки клише
        /// </summary>
        /// <param name="filePath">Путь к файлу картинки</param>
        public UploadPictureOperation(string filePath): base("uploadPictureCliche")
        {
            if (filePath.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("RequiredError"),
                        GetType().GetProperty(nameof(FileName)).GetPropertyDisplayName()),
                    nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException(
                    ValidationStrings.ResourceManager.GetString("FileNotFoundError"),
                    nameof(filePath));
            }

            FileName = filePath;
        }

        /// <summary>
        /// Путь к файлу картинки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Путь к файлу картинки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string FileName { get; }

        /// <summary>
        /// Масштаб изображения в процентах
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-<see cref="int.MaxValue"/></item>
        /// </list>
        /// <remarks>
        /// Значение по умолчанию: 100
        /// </remarks>
        [Display(Name = "Масштаб изображения в процентах")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int ScalePercent { get; set; } = 100;
    }
}
