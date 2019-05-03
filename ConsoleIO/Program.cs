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
            IEnumerable<IFile> folder = new SourceFolder(source).Files;

            IMeasure measure = OperationStrategy.PickMeasurementType(new Argument("OperationType", args[3]));
            measure.Track(OperationStrategy.PickOperationType(new Argument("name", args[3]), folder, filter), source, destination);
        }
    }
}