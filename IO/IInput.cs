using System.Collections.Generic;

namespace IO
{
    public interface IInput
    {
        IEnumerable<IArgument> Read(string[] args);
    }
}
