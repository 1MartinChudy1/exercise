using System;
using System.Collections.Generic;
using System.Linq;
using IO;

namespace ConsoleIO
{
    public class Destination : IDestination
    {
        public Destination(IEnumerable<IArgument> arguments)
        {
            DestinationPath = SetDestination(arguments);
        }  

        public IArgument DestinationPath { get; set; }

        private IArgument SetDestination(IEnumerable<IArgument> argument)
        {
            if (argument == null)
                throw new ArgumentNullException();
            if (argument.ToList().Count < 2)
                throw new ArgumentOutOfRangeException();
            return argument.First(x => x.Name == "Output");
        }
    }
}
