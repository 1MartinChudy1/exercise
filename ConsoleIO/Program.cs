using System.Collections.Generic;
using System.Linq;

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

            IMeasure measure = OperationStrategy.PickMeasurementType(arguments.First(x => x.Name == "OperationType"));
            IOperation operation = OperationStrategy.PickOperationType(arguments.First(x => x.Name == "OperationType"), folder, filter);
            measure.Track(operation, source, destination);
        }
    }
}