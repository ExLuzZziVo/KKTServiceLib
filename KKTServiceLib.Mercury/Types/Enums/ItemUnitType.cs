using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Мера количества товара
    /// </summary>
    public enum ItemUnitType : byte
    {
        /// <summary>
        /// Штуки, единицы
        /// </summary>
        [Display(Name = "Штуки, единицы")] Piece = 0,

        /// <summary>
        /// Грамм
        /// </summary>
        [Display(Name = "Грамм")] Gram = 10,

        /// <summary>
        /// Килограмм
        /// </summary>
        [Display(Name = "Килограмм")] Kilogram = 11,

        /// <summary>
        /// Тонна
        /// </summary>
        [Display(Name = "Тонна")] Ton = 12,

        /// <summary>
        /// Сантиметр
        /// </summary>
        [Display(Name = "Сантиметр")] Centimeter = 20,

        /// <summary>
        /// Дециметр
        /// </summary>
        [Display(Name = "Дециметр")] Decimeter = 21,

        /// <summary>
        /// Метр
        /// </summary>
        [Display(Name = "Метр")] Meter = 22,

        /// <summary>
        /// Квадратный сантиметр
        /// </summary>
        [Display(Name = "Квадратный сантиметр")]
        SquareCentimeter = 30,

        /// <summary>
        /// Квадратный дециметр
        /// </summary>
        [Display(Name = "Квадратный дециметр")]
        SquareDecimeter = 31,

        /// <summary>
        /// Квадратный метр
        /// </summary>
        [Display(Name = "Квадратный метр")] SquareMeter = 32,

        /// <summary>
        /// Миллилитр
        /// </summary>
        [Display(Name = "Миллилитр")] Milliliter = 40,

        /// <summary>
        /// Литр
        /// </summary>
        [Display(Name = "Литр")] Liter = 41,

        /// <summary>
        /// Кубический метр
        /// </summary>
        [Display(Name = "Кубический метр")] CubicMeter = 42,

        /// <summary>
        /// Киловатт-час
        /// </summary>
        [Display(Name = "Киловатт-час")] KilowattHour = 50,

        /// <summary>
        /// Гигакалория
        /// </summary>
        [Display(Name = "Гигакалория")] Gkal = 51,

        /// <summary>
        /// Сутки (день)
        /// </summary>
        [Display(Name = "Сутки (день)")] Day = 70,

        /// <summary>
        /// Час
        /// </summary>
        [Display(Name = "Час")] Hour = 71,

        /// <summary>
        /// Минута
        /// </summary>
        [Display(Name = "Минута")] Minute = 72,

        /// <summary>
        /// Секунда
        /// </summary>
        [Display(Name = "Секунда")] Second = 73,

        /// <summary>
        /// Килобайт
        /// </summary>
        [Display(Name = "Килобайт")] Kilobyte = 80,

        /// <summary>
        /// Мегабайт
        /// </summary>
        [Display(Name = "Мегабайт")] Megabyte = 81,

        /// <summary>
        /// Гигабайт
        /// </summary>
        [Display(Name = "Гигабайт")] Gigabyte = 82,

        /// <summary>
        /// Терабайт
        /// </summary>
        [Display(Name = "Терабайт")] Terabyte = 83,

        /// <summary>
        /// Иные единицы измерения
        /// </summary>
        [Display(Name = "Иные единицы измерения")]
        OtherUnits = 255
    }
}