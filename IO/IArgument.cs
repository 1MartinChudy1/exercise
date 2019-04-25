using System;
using System.Collections.Generic;
using System.Text;

namespace IO
{
    public interface IArgument
    {
        string Name { get; }

        string Value { get; }
    }
}
