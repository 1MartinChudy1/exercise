using System.Collections.Generic;

namespace Main
{
    public interface IFilter
    {
        IEnumerable<string> Types { get; set; }

        IEnumerable<string> GetTypes(IEnumerable<Argument> arguments);
    }
}
