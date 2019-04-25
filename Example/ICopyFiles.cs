using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    public interface ICopyFiles
    {
        void Copy(IEnumerable<Argument> arguments);
    }
}
