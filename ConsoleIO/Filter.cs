using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IO;

namespace ConsoleIO
{
    public class Filter : IFilter
    {
        public Filter(IEnumerable<IArgument> arguments)
        {
            Types = GetTypes(arguments);
        }

        public IEnumerable<string> Types { get; set; }
        
        public IEnumerable<string> GetTypes(IEnumerable<IArgument> arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException();
            if (arguments.ToList().Count < 3)
                Types = null;
            var filter = arguments.First(x => x.Name == "Filter") as Argument;
            return filter?.Value.Split(',');
        }
    }
}
