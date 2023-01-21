using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Extensions
{
    public static class EnumExtension
    {
        #region Métodos Estáticos Públicos
        public static string GetEnumDescription(this System.Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string GetEnumName(this System.Enum value)
        {
            return value.ToString();
        }

        public static int GetEnumValue(this System.Enum value)
        {
            return Convert.ToInt32(value);
        }
        public static T GetEnumValue<T>(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return default(T);

            return (T)System.Enum.Parse(typeof(T), value.RemoveDiacritics(), true);
        }

        public static int GetValueOf(Type enumType, string enumConst)
        {
            object value = System.Enum.Parse(enumType, enumConst);

            return Convert.ToInt32(value);
        }

        #endregion
    }
}
