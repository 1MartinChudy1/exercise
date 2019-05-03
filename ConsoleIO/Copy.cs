﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Main
{
    public class Copy : IOperation
    {
        public Copy(IEnumerable<IFile> files, IFilter filter = null)
        {
            Files = Filtered(filter, files);
        }

        public IEnumerable<IFile> Files { get; set; }

        public OperationResult EngageOperation(Argument source, Argument destination)
        {
            foreach (var file in this.Files)
            {
                System.IO.File.Copy(GetPath(source.Value, file.Name),
                    GetPath(destination.Value, file.Name));
            }
            return new CopyResult(Files.Count(),0,Files.Select(x=>x.Size).Sum());
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
