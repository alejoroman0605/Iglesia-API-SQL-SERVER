using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Service.Extensions
{
    public static class StringExtension
    {
        #region Métodos Estáticos Públicos
        public static bool IsNullOrEmpty(this string s)
        {
            return s == null || s == string.Empty;
        }

        public static string ToStringOrEmpty(this string s)
        {
            return s == null ? string.Empty : s;
        }

        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string GetDisplayDataAnnotation(object value, string nameProperty)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);

            foreach (PropertyDescriptor property in properties)
            {
                if (property.Name == nameProperty)
                {
                    foreach (var item2 in property.Attributes)
                    {
                        if (item2.ToString().Contains("DisplayAttribute"))
                        {
                            System.ComponentModel.DataAnnotations.DisplayAttribute data = (System.ComponentModel.DataAnnotations.DisplayAttribute)item2;
                            return data.Name;
                        }
                    }

                }
            }

            return "";
        }

        public static string RemoverMascaras(this string propriedade)
        {
            return Regex.Replace(propriedade, "[^0-9,]", "");
        }

        public static string RemoverHTML(this string input)
        {
            return Regex.Replace(input, "<(.|\n)*?>", String.Empty);
        }
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
        #endregion
    }
}
