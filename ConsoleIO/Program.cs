using System.Collections.Generic;
using System.Linq;
using Main.Extensions;

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
            OperationStrategy strategy = new OperationStrategy(folder, filter);
            IType approach = strategy.PickMeasurementType(arguments);
            IMeasure measure = approach.MeasureType;
            IOperation operation = approach.OperationType;
            measure.Track(operation, source, destination);
        }
    }
}