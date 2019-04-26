using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleIO
{
    public class Source : ISource
    {  
        public Source(IEnumerable<Argument> arguments)
        {
            SourcePath = SetSource(arguments);
        }  
        
        public Argument SourcePath { get; set; }


        public Argument SetSource(IEnumerable<Argument> arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException();
            if (arguments.ToList().Count < 1)
                throw new ArgumentOutOfRangeException();
            return arguments.First(x => x.Name == "Input");
        }
    }  
}
