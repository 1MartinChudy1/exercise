using System.Diagnostics;
using IO;

namespace Operations
{
    public class Tracker : ITracker
    {
        public Tracker()
        { }

        public int FileCount { get; set; }

        public long DurationOfOperation { get; set; }

        public long SizeOfPayload { get; set; }
    }
}
