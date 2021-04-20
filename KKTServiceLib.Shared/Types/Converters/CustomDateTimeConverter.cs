using Newtonsoft.Json.Converters;

namespace KKTServiceLib.Shared.Types.Converters
{
    /// <summary>
    /// Конвертер <see cref="System.DateTime"/> в нужный формат и обратно
    /// </summary>
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Конвертер <see cref="System.DateTime"/> в нужный формат и обратно
        /// </summary>
        /// <param name="dateTimeFormat">Формат даты и времени</param>
        public CustomDateTimeConverter(string dateTimeFormat)
        {
            base.DateTimeFormat = dateTimeFormat;
        }
    }
}