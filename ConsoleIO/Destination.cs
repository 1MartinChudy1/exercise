using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleIO
{
    public class Destination : IDestination
    {
        public Destination(IEnumerable<Argument> arguments)
        {
            DestinationPath = SetDestination(arguments);
        }  

        public Argument DestinationPath { get; set; }

        private Argument SetDestination(IEnumerable<Argument> argument)
        {
            if (argument == null)
                throw new ArgumentNullException();
            if (argument.ToList().Count < 2)
                throw new ArgumentOutOfRangeException();
            return argument.First(x => x.Name == "Output");
        }
    }
}
