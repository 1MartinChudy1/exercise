using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Example.Extensions;
using System.Linq;

namespace Example
{
    internal class DiagnosticCopyFile : ICopyFiles
    {
        private ICopyFiles copyFilesEngine;
        private IOutput output;

        private class OperationContext
        {
            Stopwatch duration;
            private int initialcount;

            public OperationContext(int initialcount)
            {
                duration = Stopwatch.StartNew();
                this.initialcount = initialcount;
            }

            public int Initialcount { get => initialcount; set => initialcount = value; }

            public Stopwatch Duration { get => duration; set => duration = value; }
        }

        public DiagnosticCopyFile(ICopyFiles copyFilesEngine, IOutput output)
        {
            this.copyFilesEngine = copyFilesEngine;
            this.output = output;
        }

        public void Copy(IEnumerable<Argument> arguments)
        {
            OperationContext context = Start(arguments);
            copyFilesEngine.Copy(arguments);
            Result result = Stop(arguments, context);

            output.Write(result);
        }

        private Result Stop(IEnumerable<Argument> arguments, OperationContext context)
        {
            context.Duration.Stop();
            var destination = arguments.GetArgumentByName("destination");
            var allFilesFromDestination = Directory.GetFileSystemEntries(destination.Value);
            var countFiles = allFilesFromDestination.Count();
            return new Result(context.Initialcount == countFiles ? countFiles : countFiles - context.Initialcount, context.Duration.Elapsed);
        }

        private OperationContext Start(IEnumerable<Argument> arguments)
        {
            var source = arguments.GetArgumentByName("source");
            var allFilesFromSource = Directory.GetFileSystemEntries(source.Value);
            var countFiles = allFilesFromSource.Count();

            return new OperationContext(countFiles);
        }
    }
}