using System.Collections.Generic;

namespace IO
{
    public interface IFilter
    {
        IEnumerable<string> Types { get; set; }

        IEnumerable<string> GetTypes(IEnumerable<IArgument> arguments);
    }
}
