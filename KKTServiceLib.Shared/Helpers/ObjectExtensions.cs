using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace KKTServiceLib.Shared.Helpers
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Проверяет, является ли входящая строка пустой, равной null или состоящей из одних пробелов
        /// </summary>
        /// <param name="source">Строка для проверки</param>
        /// <returns>Результат проверки</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string source)
        {
            return string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// Меняет регистр первого символа в строке на нижний
        /// </summary>
        /// <param name="str">Входящая строка</param>
        /// <returns>Обработанная строка</returns>
        public static string ToLowerFirstChar(this string str)
        {
            if (str.IsNullOrEmptyOrWhiteSpace())
            {
                return string.Empty;
            }

            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Получает значение атрибута <see cref="DisplayAttribute"/> у <see cref="Enum"/>
        /// </summary>
        /// <param name="en">Значение типа <see cref="Enum"/></param>
        /// <returns>Значение атрибута <see cref="DisplayAttribute"/></returns>
        public static string GetDisplayName(this Enum en)
        {
            return GetDisplayName(en, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Получает значение атрибута <see cref="DisplayAttribute"/> у <see cref="Enum"/>
        /// </summary>
        /// <param name="en">Значение типа <see cref="Enum"/></param>
        /// <param name="cultureInfo">Сведения об языке и региональных параметрах</param>
        /// <returns>Значение атрибута <see cref="DisplayAttribute"/></returns>
        public static string GetDisplayName(this Enum en, CultureInfo cultureInfo)
        {
            var displayAttr = en
                .GetType()
                .GetMember(en.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();

            var resourceManager =
                displayAttr?.ResourceType
                    ?.GetProperty(@"ResourceManager",
                        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    ?.GetValue(null, null) as ResourceManager;

            return resourceManager?.GetString(displayAttr.Name, cultureInfo) ?? displayAttr?.GetName() ?? en.ToString();
        }

        /// <summary>
        /// Получает значение атрибута <see cref="DisplayAttribute"/> у <see cref="PropertyInfo"/>
        /// </summary>
        /// <param name="propertyInfo">Значение <see cref="PropertyInfo"/></param>
        /// <returns>Значение атрибута <see cref="DisplayAttribute"/></returns>
        public static string GetDisplayName(this PropertyInfo propertyInfo)
        {
            return GetDisplayName(propertyInfo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Получает значение атрибута <see cref="DisplayAttribute"/> у <see cref="PropertyInfo"/>
        /// </summary>
        /// <param name="propertyInfo">Значение <see cref="PropertyInfo"/></param>
        /// <param name="cultureInfo">Сведения об языке и региональных параметрах</param>
        /// <returns>Значение атрибута <see cref="DisplayAttribute"/></returns>
        public static string GetDisplayName(this PropertyInfo propertyInfo, CultureInfo cultureInfo)
        {
            if (propertyInfo != null)
            {
                var displayAttr = (DisplayAttribute)propertyInfo
                    .GetCustomAttributes(typeof(DisplayAttribute), false)
                    .FirstOrDefault();

                var resourceManager =
                    displayAttr?.ResourceType
                        ?.GetProperty(@"ResourceManager",
                            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                        ?.GetValue(null, null) as ResourceManager;

                return resourceManager?.GetString(displayAttr.Name, cultureInfo) ??
                       displayAttr?.GetName() ?? propertyInfo.Name;
            }

            return null;
        }
    }
}