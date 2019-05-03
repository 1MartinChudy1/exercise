using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class Destination : IDestination
    {
        public Destination(IEnumerable<Argument> arguments)
        {
            DestinationPath = SetDestination(arguments);
        }  

        public Argument DestinationPath { get; set; }

        private Argument SetDestination(IEnumerable<Argument> arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException();
            if (arguments.ToList().Count < 2)
                throw new ArgumentOutOfRangeException();
            return arguments.First(x => x.Name == "Output");
        }
    }
}
