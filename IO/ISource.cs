using System;
using System.Collections.Generic;
using System.Text;

namespace IO
{
    public interface ISource
    {
        IArgument SourcePath { get; set; }
    }
}