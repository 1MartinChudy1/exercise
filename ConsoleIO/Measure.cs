using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Main
{
    public class Measure : IMeasure
    {
        public IEnumerable<IFile> Files { get; set; }

        public virtual void Track(IOperation operation, IEnumerable<Argument> arguments)
        {
            throw new NotImplementedException();
        }
    }
}