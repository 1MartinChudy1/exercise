namespace Main
{
    public class MoveResult : OperationResult
    {
        public MoveResult(int fileCount, long operationDuration, long sizeOfPayload) : base(fileCount)
        {
            OperationDuration = $"Operation duration: { operationDuration.ToString() } ms";
            SizeOfPayload = $"Operation duration: { sizeOfPayload.ToString() }";
        }

        public string OperationDuration { get; set; }

        public string SizeOfPayload { get; set; }
    }
}