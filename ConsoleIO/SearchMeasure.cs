using System.Collections.Generic;

namespace Main
{
    public class SearchMeasure : Measure, IMeasure
    {
        public override void Track(IOperation operation, ISource source, IDestination destination)
        {
            OperationResult operationResult = operation.EngageOperation(source.SourcePath, destination.DestinationPath);
            IPrintResults printer = new PrintResults();
            printer.Print(operationResult as SearchResult);
        }
    }
}