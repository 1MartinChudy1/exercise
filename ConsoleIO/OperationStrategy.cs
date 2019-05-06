using System;
using System.Collections.Generic;

namespace Main
{
    public class OperationStrategy
    {
        private static Dictionary<OperationTypes, IType> _strategies =
            new Dictionary<OperationTypes, IType>();
 
        public OperationStrategy(IEnumerable<IFile> files, IFilter filter)
        {
            if ((files == null) || (filter == null))
                throw new NullReferenceException();

            _strategies.Add(OperationTypes.Copy, new CopyType(files, filter));
            _strategies.Add(OperationTypes.Move, new MoveType(files, filter));
            _strategies.Add(OperationTypes.Search, new SearchType(files, filter));
        }

        public IType PickMeasurementType(OperationTypes operationType)
        {
            return _strategies[operationType];
        }
    }
}