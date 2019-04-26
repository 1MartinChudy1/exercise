using System;

namespace ConsoleIO
{
    public class PrintResults : IPrintResults
    {
        public void Print(ITracker tracker)
        {
            Console.WriteLine($"FILE COUNT: {tracker.FileCount}\n" +
                              $"DURATION OF OPERATION: {tracker.DurationOfOperation} ms\n" +
                              $"TOTAL SIZE: {tracker.SizeOfPayload}");
        }
    }
}
