using System.Collections.Generic;

namespace IO
{
    public interface IArguments
    {
        IEnumerable<IArgument> Args { get; }

        IEnumerable<IArgument> Read(string[] args);
    }
}
