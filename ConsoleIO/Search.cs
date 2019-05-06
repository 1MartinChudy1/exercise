using System;
using System.Collections.Generic;
using System.Linq;
using Main.Extensions;

namespace Main
{
    public class Search : IOperation
    {
        public Search(IEnumerable<IFile> files, IFilter filter)
        {
            Files = files.Filter(filter);
        }

        public IEnumerable<IFile> Files { get; set; }

        public OperationResult EngageOperation(Argument source, Argument destination)
        {
            return new SearchResult(Files.Count(), Files);
        }
    }
}