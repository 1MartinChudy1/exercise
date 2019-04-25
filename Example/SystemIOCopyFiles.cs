using System;
using System.Collections.Generic;
using System.IO;
using Example.Extensions;

namespace Example
{
    public class SystemIoCopyFiles : ICopyFiles
    {
        public void Copy(IEnumerable<Argument> arguments)
        {
            var sourceArgument = arguments.GetArgumentByName("source");
            var destinationArgument = arguments.GetArgumentByName("destination");

            var allFilesFromSource = Directory.GetFileSystemEntries(sourceArgument.Value);

            foreach (var fileInSource in allFilesFromSource)
            {
                File.Copy(fileInSource,$"{destinationArgument.Value}{GetFileName(fileInSource, sourceArgument)}");
            }
        }

        private string GetFileName(string fileInSource, Argument sourceArgument)
            => fileInSource.Replace(sourceArgument.Value, string.Empty);
    }
}
