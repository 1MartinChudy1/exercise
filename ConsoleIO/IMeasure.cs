using System.Collections;
using System.Collections.Generic;

namespace Main
{
    public interface IMeasure
    {
        IEnumerable<IFile> Files { get; set; }

        void Track(IOperation operation, ISource source, IDestination destination);
    }
}