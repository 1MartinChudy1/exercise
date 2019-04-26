using System.Collections.Generic;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IInput inputReader = new InputReader();
            IEnumerable<Argument> arguments = inputReader.Read(args);
            IFilter filter = new Filter(arguments);
            ISource source = new Source(arguments);
            IDestination destination = new Destination(arguments);
            IEnumerable<IFile> folder = new SourceFolder(source.SourcePath.Value).Files;
            IOperation copyMachine = new Copy(folder, filter);
            var tracker = new Tracker(); 
            copyMachine.Init(source, destination, tracker);
            IPrintResults printer = new PrintResults();
            printer.Print(tracker);
        }
    }
}
 