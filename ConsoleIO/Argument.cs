namespace ConsoleIO

{
    public class Argument
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
