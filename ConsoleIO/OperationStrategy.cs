using System;
using System.Collections.Generic;
using System.Linq;
using Main.Extensions;

namespace Main
{
    public class OperationStrategy
    {
        private static Dictionary<string, IType> _strategies =
            new Dictionary<string, IType>();
 
        public OperationStrategy(IEnumerable<IFile> files, IFilter filter)
        {
            if (files == null)
                throw new NullReferenceException();

            _strategies.Add(nameof(Copy), new CopyType(files, filter));
            _strategies.Add(nameof(Move), new MoveType(files, filter));
            _strategies.Add(nameof(Search), new SearchType(files, filter));
        }

        public IType PickMeasurementType(IEnumerable<Argument> arguments)
        {
            return _strategies[arguments.First(x => x.Name == "OperationType").Value];
        }
    }
}