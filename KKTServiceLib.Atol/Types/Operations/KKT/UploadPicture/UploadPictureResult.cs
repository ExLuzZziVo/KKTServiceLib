#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.UploadPicture
{
    [Description("Результат загрузки картинки клише")]
    public class UploadPictureResult
    {
        /// <summary>
        /// Номер картинки клише
        /// </summary>
        /// <remarks>
        /// Нумерация картинок клише начинается с 0
        /// </remarks>
        [Display(Name = "Номер картинки клише")]
        public int PictureNumber { get; set; }
    }
}
