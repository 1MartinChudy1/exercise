using System.Collections.Generic;

namespace Main
{
    public class SearchMeasure : Measure, IMeasure
    {
        public override void Track(IOperation operation, IEnumerable<Argument> arguments)
        {
            OperationResult operationResult = operation.EngageOperation(arguments);
            IPrintResults printer = new PrintResults();
            printer.Print(operationResult as SearchResult);
        }
    }
}