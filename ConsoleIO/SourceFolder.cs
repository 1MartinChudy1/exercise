using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Main
{
    public class SourceFolder
    {
        public SourceFolder(IEnumerable<Argument> source)
        {
            Files = Fill(source);
        }

        public IEnumerable<IFile> Files { get; set; }

        private IEnumerable<IFile> Fill(IEnumerable<Argument> source)
        {
            if (source == null)
                throw new ArgumentNullException();
            if (source.Count() != 4)
                throw new ArgumentOutOfRangeException();

            var directory = Directory.EnumerateFiles(source.First(x => x.Name == "Input").Value);
            var files = new List<IFile>();

            foreach (var file in directory)
            {
                files.Add(new File(file, new FileInfo(file).Length));
            }

            return files;
        }
    }
}
