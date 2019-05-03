using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class Search : IOperation
    {
        public Search(IEnumerable<IFile> files, IFilter filter)
        {
            Files = Filtered(files, filter);
        }

        public IEnumerable<IFile> Files { get; set; }

        private IEnumerable<IFile> Filtered(IEnumerable<IFile> files, IFilter filter)
        {
            if (filter != null)
                return files.Where(x => Whitelist(x.Name.Substring(x.Name.IndexOf('.')+1), filter));
            return files;
        }

        public OperationResult EngageOperation(Argument source, Argument destination)
        {
            return new SearchResult(Files.Count(), Files);
        }

        private bool Whitelist(string fileName, IFilter filter)
        {
            var value =  Array.Exists(filter.Types.ToArray(), element => element == fileName);
            return value;
        }

        private string GetPath(string directoryPath, string fileName)
            => $"{directoryPath}\\{fileName}";
    }
}