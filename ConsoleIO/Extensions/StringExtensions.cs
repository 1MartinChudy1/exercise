using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Main.Extensions
{
    public static class StringExtensions
    {
        public static string GetPath(this string fileName, string directoryPath)
            => $"{directoryPath}\\{fileName}";

        public static IEnumerable<IFile> Filter(this IEnumerable<IFile> files, IFilter filter = null)
        {
            if (filter != null)
                return files.Where(x => Whitelist(x.Name.Substring(x.Name.IndexOf('.')+1), filter));
            return files;
        }

        private static bool Whitelist(string fileName, IFilter filter)
        {
            var value =  Array.Exists(filter.Types.ToArray(), element => element == fileName);
            return value;
        }
    }
}
