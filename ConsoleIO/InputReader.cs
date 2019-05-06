using System;
using System.Collections.Generic;

namespace Main
{
    public class InputReader : IInput
    {
        public InputReader()
        {
        }

        public IEnumerable<Argument> Read(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException();
            if (args.Length < 4)
                throw new ArgumentOutOfRangeException();
            if ((args[3] != "Copy") || (args[3] != "Move") || (args[3] != "Search"))
                throw new ArgumentException("Wrong operation type");

            yield return new Argument("Input", args[0]);
            yield return new Argument("Output", args[1]);
            yield return new Argument("Filter", args[2]);
            yield return new Argument("OperationType", args[3]);
        }
    }
}
