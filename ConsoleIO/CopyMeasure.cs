using System.Collections.Generic;
using System.Diagnostics;

namespace Main
{
    public class CopyMeasure : Measure, IMeasure
    {
        public override void Track(IOperation operation, ISource source, IDestination destination)
        {
            var stopwatch = Stopwatch.StartNew();
            CopyResult operationResult = operation.EngageOperation(source.SourcePath, destination.DestinationPath) as CopyResult;
            operationResult.OperationDuration = $"Operation duration: { stopwatch.ElapsedMilliseconds.ToString() }"; 
            IPrintResults printer = new PrintResults();
            printer.Print(operationResult);
        }
    }
}