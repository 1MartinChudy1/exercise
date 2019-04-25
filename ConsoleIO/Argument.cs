using IO;

namespace ConsoleIO

{
    public class Argument : IArgument
    {
        public Argument(string argName, string argValue)
        {
            Name = argName;
            Value = argValue;
        }

        public string Name { get; }

        public string Value { get; }
    }
}
