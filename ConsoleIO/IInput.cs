using System.Collections.Generic;

namespace Main
{
    public interface IInput
    {
        IEnumerable<Argument> Read(string[] args);
    }
}
