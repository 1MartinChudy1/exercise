using System.Collections.Generic;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputValidation validation = new InputValidation();
            validation.Validate(args);

            IInput inputReader = new InputReader();
            IEnumerable<Argument> arguments = inputReader.Read(args);
            
            ICopyFiles diagnosticCopyFile = new DiagnosticCopyFile(new SystemIoCopyFiles(), new ConsoleOutput());

            diagnosticCopyFile.Copy(arguments);
        }
    }
}
