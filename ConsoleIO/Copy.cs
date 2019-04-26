using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleIO
{
    public class Copy : IOperation
    {
        public Copy(IEnumerable<IFile> files, IFilter filter = null)
        {
            Files = Filtered(filter, files);
        }

        public IEnumerable<IFile> Files { get; set; }

        public void Init(ISource source, IDestination destination, ITracker tracker)
        {
            TrackTime(source, destination, tracker);
        }

        public void TrackTime(ISource source, IDestination destination, ITracker tracker)
        {
            var stopwatch = Stopwatch.StartNew();
            EngageOperation(source, destination);
            tracker.DurationOfOperation = stopwatch.ElapsedMilliseconds;
            CountFiles(tracker);
            ComputeSize(tracker);
        }

        public void EngageOperation(ISource source, IDestination destination)
        {
            foreach (var file in this.Files)
            {
                System.IO.File.Copy(GetPath(source.SourcePath.Value, file.Name),
                    GetPath(destination.DestinationPath.Value, file.Name));
            }
        }

        private void CountFiles(ITracker tracker)
        {
            tracker.FileCount = Files.Count();
        }

        public void ComputeSize(ITracker tracker)
        {
            tracker.SizeOfPayload = Files.Select(x => x.Size).Sum();
        }

        private IEnumerable<IFile> Filtered(IFilter filter, IEnumerable<IFile> files)
        {
            if (filter != null)
                return files.Where(x => Whitelist(x.Name.Substring(x.Name.IndexOf('.')+1), filter));
            return files;
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
