using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class Filter : IFilter
    {
        public Filter(IEnumerable<Argument> arguments)
        {
            Types = GetTypes(arguments);
        }

        public string Types { get; set; }
        
        public string GetTypes(IEnumerable<Argument> arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException();
            if (arguments.ToList().Count < 3)
                Types = null;
            var filter = arguments.First(x => x.Name == "Filter") as Argument;
            return filter?.Value;
        }
    }
}
