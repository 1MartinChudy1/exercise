using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class Move : IOperation
    {
        public Move(IEnumerable<IFile> files, IFilter filter = null)
        {
            Files = Filtered(filter, files);
        }

        public IEnumerable<IFile> Files { get; set; }
        
        private IEnumerable<IFile> Filtered(IFilter filter, IEnumerable<IFile> files)
        {
            if (filter != null)
                return files.Where(x => Whitelist(x.Name.Substring(x.Name.IndexOf('.')+1), filter));
            return files;
        }

        public OperationResult EngageOperation(Argument source, Argument destination)
        {
            
            foreach (var file in this.Files)
            {
                System.IO.File.Move(GetPath(source.Value, file.Name),
                    GetPath(destination.Value, file.Name));
            }
            return new MoveResult(Files.Count(),0,Files.Select(x=>x.Size).Sum());
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