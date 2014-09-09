using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaNamingManager
{
    public static class CustomExtensions
    {
        public static string FileExtension(this string fileName)
        {
            var idx = fileName.LastIndexOf('.');
            return fileName.Substring(idx);
        }

        public static bool IsDigit(this string value)
        {
            int parsed;
            return int.TryParse(value, out parsed);
        }

        public static string ToFriendlyName(this int number)
        {
            var str = number.ToString();
            if (str.Length == 1)
            {
                // Should put in a zero in front to make it sortable in windows.
                return string.Format("0{0}", str);
            }
            return str;
        }

    }
}