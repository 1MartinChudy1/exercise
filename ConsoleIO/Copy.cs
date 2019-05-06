using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Main.Extensions;

namespace Main
{
    public class Copy : IOperation
    {
        public Copy(IEnumerable<IFile> files, IFilter filter = null)
        {
            Files = files.Filter(filter);
        }

        public IEnumerable<IFile> Files { get; set; }

        public OperationResult EngageOperation(Argument source, Argument destination)
        {
            var stopwatch = Stopwatch.StartNew();
            foreach (var file in this.Files)
            {
                System.IO.File.Copy(file.Name.GetPath(source.Value),
                    file.Name.GetPath(destination.Value));
            }
            return new CopyResult(Files.Count(),stopwatch.ElapsedMilliseconds,Files.Select(x=>x.Size).Sum());
        }
    }
}
