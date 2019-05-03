using System.Collections.Generic;
using System.IO;

namespace Main
{
    public class SourceFolder
    {
        public SourceFolder(ISource source)
        {
            Files = Fill(source);
        }

        public IEnumerable<IFile> Files { get; set; }

        private IEnumerable<IFile> Fill(ISource source)
        {
            var directory = Directory.EnumerateFiles(source.SourcePath.Value);
            var files = new List<IFile>();

            foreach (var file in directory)
            {
                files.Add(new File(file, new FileInfo(file).Length));
            }

            return files;
        }
    }
}
