using System.Collections.Generic;
using System.Diagnostics;

namespace Main
{
    public class MoveMeasure : Measure, IMeasure
    {
        public override void Track(IOperation operation, ISource source, IDestination destination)
        {
            var stopwatch = Stopwatch.StartNew();
            MoveResult operationResult = operation.EngageOperation(source.SourcePath, destination.DestinationPath) as MoveResult;
            operationResult.OperationDuration = $"Operation duration: { stopwatch.ElapsedMilliseconds.ToString() }"; 
            IPrintResults printer = new PrintResults();
            printer.Print(operationResult);
        }
    }
}