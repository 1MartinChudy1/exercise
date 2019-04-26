using System;

namespace Main
{
    public class PrintResults : IPrintResults
    {
        public void Print(Tracker tracker)
        {
            Console.WriteLine($"FILE COUNT: {tracker.FileCount}\n" +
                              $"DURATION OF OPERATION: {tracker.DurationOfOperation} ms\n" +
                              $"TOTAL SIZE: {tracker.SizeOfPayload}");
        }
    }
}
