using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaNamingManager
{
    public static class StringExtensions
    {
        public static string FileExtension(this string fileName)
        {
            var idx = fileName.LastIndexOf('.');
            return fileName.Substring(idx);
        }

        public static T FirstOrDefaultWithAction<T>(this IEnumerable<string> values, Func<string, bool> expression, Func<string, T> callback)
            where T : class 
        {
            var first = values.FirstOrDefault(expression);

            if (first == null)
                return null;

            return callback(first);
        }
    }

}