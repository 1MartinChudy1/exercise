using System;
using System.Collections.Generic;
using System.Linq;
using Main.Extensions;

namespace Main
{
    public class OperationStrategy
    {
        private static Dictionary<OperationTypes, IType> _strategies =
            new Dictionary<OperationTypes, IType>();
 
        public OperationStrategy(IEnumerable<IFile> files, IFilter filter)
        {
            if (files == null)
                throw new NullReferenceException();

            _strategies.Add(OperationTypes.Copy, new CopyType(files, filter));
            _strategies.Add(OperationTypes.Move, new MoveType(files, filter));
            _strategies.Add(OperationTypes.Search, new SearchType(files, filter));
        }

        public IType PickMeasurementType(IEnumerable<Argument> arguments)
        {
            return _strategies[arguments.ElementAt(3).Value.ToEnum()];
        }
    }
}