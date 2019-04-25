using System.Collections.Generic;
using System.Linq;

namespace Example.Extensions
{
    public static class IEnumerableArgumentsExtensions
    {
        public static Argument GetArgumentByName(this IEnumerable<Argument> arguments, string name)
        {
            var result = from argument in arguments
                where argument.Name.Equals(name)
                select argument;

            return result.FirstOrDefault();
        }
    }
}
