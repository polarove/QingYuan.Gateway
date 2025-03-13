using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace QingYuan.Extensions
{
    public static class StringExtensions
    {

        #region ToCase
        public static string ToCamelCase(this string s) => JsonNamingPolicy.CamelCase.ConvertName(s);
        public static string ToSnakeCaseLower(this string s) => JsonNamingPolicy.SnakeCaseLower.ConvertName(s);

        //public static string ToKebabCase(this string s) => ToSeparatedCase(s, '-');

        #endregion

        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? s)
        {
            return string.IsNullOrEmpty(s);
        }
        public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static string IfNullOrWhiteSpace(this string? value, string defaultValue)
            => value.IsNullOrWhiteSpace() ? defaultValue : value;

        public static bool IsArrayJson(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            return value.StartsWith('[') && value.EndsWith(']');
        }
        public static bool IsObjectJson(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            return value.StartsWith('{') && value.EndsWith('}');
        }

        /// <summary>
        /// 将传入的字符串中间部分字符替换成特殊字符
        /// </summary>
        /// <param name="value">需要替换的字符串</param>
        /// <param name="startLen">前保留长度</param>
        /// <param name="endLen">尾保留长度</param>
        /// <param name="specialChar">特殊字符</param>
        /// <returns>被特殊字符替换的字符串</returns>
        public static string? CoverWith(this string? value, int startLen = 6, int endLen = 4, char specialChar = '*')
        {
            if (value == null || value.Length <= startLen + endLen)
            {
                return null;
            }
            value = value.Trim();
            var length = value.Length - startLen - endLen;
            var specialStr = new string(specialChar, length);
            return string.Concat(value.AsSpan(0, startLen), specialStr, value.AsSpan(startLen + length, endLen));
        }


        public static int? ParseToInt32(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            if (int.TryParse(value, out var number))
            {
                return number;
            }
            return null;
        }

        public static long? ParseToInt64(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            if (long.TryParse(value, out var number))
            {
                return number;
            }
            return null;
        }

        public static double? ParseToDouble(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            if (double.TryParse(value, out var number))
            {
                return number;
            }
            return null;
        }

        public static decimal? ParseToDecimal(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            if (decimal.TryParse(value, out var number))
            {
                return number;
            }
            return null;
        }

        public static int[ ]? SplitToInt32Array(this string? value, char separator)
            => value.SplitToArray(separator, Convert.ToInt32);

        public static long[ ]? SplitToInt64Array(this string? value, char separator)
            => value.SplitToArray(separator, Convert.ToInt64);

        public static T[ ]? SplitToArray<T>(this string? value, char separator, Converter<string, T> converter)
        {
            if (value == null)
            {
                return null;
            }
            return Array.ConvertAll(value.Split(separator, StringSplitOptions.RemoveEmptyEntries), converter);
        }
    }
}
