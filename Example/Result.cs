using System;
using System.Threading;

namespace Example
{
    public class Result
    {
        private int count;
        private TimeSpan elapsed;
        
        public Result(int count, TimeSpan elapsed)
        {
            this.elapsed = elapsed;
            this.count = count;
        }

        public override string ToString()
        {
            return $"{elapsed} {count}";
        }
    }
}