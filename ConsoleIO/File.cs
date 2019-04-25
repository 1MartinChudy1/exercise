using System;
using System.IO;
using Operations;

namespace ConsoleIO
{
    public class File : IFile
    {
        public File(string path, long size)
        {
            Name = GetName(path);
            Path = path;
            Size = size;
        }

        public long Size { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public string GetName(string path) => 
            path.Substring(path.LastIndexOf('\\') + 1);
    }
}