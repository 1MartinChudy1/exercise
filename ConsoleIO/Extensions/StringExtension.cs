using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Main.Extensions
{
    public static class StringExtension
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

        public static OperationTypes ToEnum(this string argument)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ValidationException("Invalid operation type");
            }

            OperationTypes result;

            return Enum.TryParse<OperationTypes>(argument, true, out result) ? result : OperationTypes.None;
        }
    }
}
