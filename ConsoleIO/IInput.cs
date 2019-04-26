using System.Collections.Generic;

namespace ConsoleIO
{
    public interface IInput
    {
        IEnumerable<Argument> Read(string[] args);
    }
}
