using System.Collections.Generic;
using System.IO;
using System.Linq;
using Operations;

namespace ConsoleIO
{
    public class SourceFolder
    {
        public SourceFolder(string sourcePath)
        {
            Files = Fill(sourcePath);
        }

        public IEnumerable<IFile> Files { get; set; }

        private IEnumerable<IFile> Fill(string sourcePath)
        {
            var directory = Directory.EnumerateFiles(sourcePath);
            var files = new List<IFile>();

            foreach (var file in directory)
            {
                files.Add(new File(file, new FileInfo(file).Length));
            }

            return files;
        }
    }
}
