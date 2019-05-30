using System.Collections.Generic;

namespace Main
{
    public interface IFilter
    {
        string Types { get; set; }

        string GetTypes(IEnumerable<Argument> arguments);
    }
}
