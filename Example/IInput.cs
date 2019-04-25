using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    public interface IInput
    {
        IEnumerable<Argument> Read(string[] args);
    }
}
