using System;
using System.Collections.Generic;

namespace Main
{
    public class PrintResults : IPrintResults
    {
        public void Print(OperationResult tracker)
        {
            var banan = tracker.GetType().GetProperties();
            foreach (var propertyInfo in tracker.GetType().GetProperties())
            {
                Console.WriteLine(propertyInfo.GetValue(tracker));
            }
        }
    }
}
