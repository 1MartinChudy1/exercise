using System.Collections.Generic;
using IO;
using Operations;

namespace ConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            IInput inputReader = new InputReader();
            IEnumerable<IArgument> arguments = inputReader.Read(args);
            IFilter filter = new Filter(arguments);
            ISource source = new Source(arguments);
            IDestination destination = new Destination(arguments);
            IEnumerable<IFile> folder = new SourceFolder(source.SourcePath.Value).Files;
            IOperation copyMachine = new Copy(folder ,filter);
            ITracker tracker = new Tracker(); 
            copyMachine.Init(source, destination, tracker);
            var printer = new PrintResults();
            printer.Print(tracker);
        }
    }
}
