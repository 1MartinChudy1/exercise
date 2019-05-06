namespace Main
{
    public class CopyMeasure : Measure, IMeasure
    {
        public override void Track(IOperation operation, ISource source, IDestination destination)
        {
            CopyResult operationResult = operation.EngageOperation(source.SourcePath, destination.DestinationPath) as CopyResult;
            IPrintResults printer = new PrintResults();
            printer.Print(operationResult);
        }
    }
}