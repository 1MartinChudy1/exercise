using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    public class Argument
    {
        public Argument(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }
    }
}
