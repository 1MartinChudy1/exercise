using System;
using System.Linq;

namespace Example
{
    internal class InputValidation : IInputValidation
    {
        public void Validate(string[] arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException();
            if (arguments.Count() < 2)
                throw new ArgumentOutOfRangeException();
        }
    }
}