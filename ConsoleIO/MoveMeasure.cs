using System.Collections.Generic;
using System.Diagnostics;

namespace Main
{
    public class MoveMeasure : Measure, IMeasure
    {
        public override void Track(IOperation operation, ISource source, IDestination destination)
        {
            MoveResult operationResult = operation.EngageOperation(source.SourcePath, destination.DestinationPath) as MoveResult;
            IPrintResults printer = new PrintResults();
            printer.Print(operationResult);
        }
    }
}