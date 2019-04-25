using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    public class InputReader : IInput
    {
        public IEnumerable<Argument> Read(string[] args)
        {
            yield return new Argument("source", args[0]);
            yield return new Argument("destination", args[1]);
        }
    }
}
