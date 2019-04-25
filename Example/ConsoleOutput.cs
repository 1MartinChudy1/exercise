using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    class ConsoleOutput : IOutput
    {
        public void Write(Result result)
        {
            Console.WriteLine(result);
        }
    }
}
