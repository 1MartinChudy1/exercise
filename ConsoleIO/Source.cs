using System;
using System.Collections.Generic;
using System.Linq;
using IO;

namespace ConsoleIO
{
    public class Source : ISource
    {  
        public Source(IEnumerable<IArgument> arguments)
        {
            SourcePath = SetSource(arguments);
        }  
        
        public IArgument SourcePath { get; set; }


        public IArgument SetSource(IEnumerable<IArgument> arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException();
            if (arguments.ToList().Count < 1)
                throw new ArgumentOutOfRangeException();
            return arguments.First(x => x.Name == "Input");
        }
    }  
}
