using System.Collections.Generic;

namespace Main
{
    public class CopyMeasure : Measure, IMeasure
    {
        public override void Track(IOperation operation, IEnumerable<Argument> arguments)
        {
            CopyResult operationResult = operation.EngageOperation(arguments) as CopyResult;
            IPrintResults printer = new PrintResults();
            printer.Print(operationResult);
        }
    }
}