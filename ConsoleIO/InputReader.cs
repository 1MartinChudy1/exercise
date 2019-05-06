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
            if (args.Length < 1)
                throw new ArgumentOutOfRangeException();

            yield return new Argument("Input", args[0]);
            yield return new Argument("Output", args[1]);
            yield return new Argument("Filter", args[2]);
            yield return new Argument("OperationType", args[3]);
        }
    }
}
