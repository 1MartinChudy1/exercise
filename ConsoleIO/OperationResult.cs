using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class OperationResult
    {
        public OperationResult(int fileCount)
        {
            FileCount = $"File count: { fileCount.ToString() }"; 
        }

        public string FileCount { get; }
    }
}