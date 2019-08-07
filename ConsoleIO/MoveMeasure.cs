using System.Collections.Generic;
using System.Diagnostics;

namespace Main
{
    public class MoveMeasure : Measure, IMeasure
    {
        public override void Track(IOperation operation, IEnumerable<Argument> arguments)
        {
            MoveResult operationResult = operation.EngageOperation(arguments) as MoveResult;
            IPrintResults printer = new PrintResults();
            printer.Print(operationResult);
        }
    }
}