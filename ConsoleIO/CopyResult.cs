using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;

namespace Main
{
    public class CopyResult : OperationResult
    {
        public CopyResult(int fileCount, long operationDuration, long sizeOfPayload) : base(fileCount)
        {
            OperationDuration = $"Operation duration: { operationDuration.ToString() } ms";
            SizeOfPayload = $"Size of payload: { sizeOfPayload.ToString() }";
        }

        public string OperationDuration { get; set; }

        public string SizeOfPayload { get; set; }
    }
}