using System;

namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string str) => !(string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str));
        public static bool EqualsIgnoreCase(this string str, string toCompare) => str != null ? str.Equals(toCompare, StringComparison.CurrentCultureIgnoreCase) : false;

        public static bool ToBool(this string str, bool defaultValue = false) => bool.TryParse(str, out bool parseResult) ? parseResult : defaultValue;
        public static bool? ToNullableBool(this string str, bool? defaultValue = null)
        {
            bool? result = defaultValue;
            if (bool.TryParse(str, out bool parseResult))
            {
                result = parseResult;
            }

            return result;
        }


        public static int ToInt32(this string str, int defaultValue = 0) => Int32.TryParse(str, out int parseResult) ? parseResult : defaultValue;
        public static int? ToNullableInt32(this string str)
        {
            int? result = null;
            if (int.TryParse(str, out int parseResult))
            {
                result = parseResult;
            }

            return result;
        }
    }
}
