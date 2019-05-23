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

        public IEnumerable<string> Types { get; set; }
        
        public IEnumerable<string> GetTypes(IEnumerable<Argument> arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException();
            if (arguments.First(x => x.Name == "Filter").Value == string.Empty)
            {
                return null;
            }
            var filter = arguments.First(x => x.Name == "Filter") as Argument;
            return filter?.Value.Split(',');
        }
    }
}
