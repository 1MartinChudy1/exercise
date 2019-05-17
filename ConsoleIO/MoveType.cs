using System.Collections.Generic;

namespace Main
{
    public class MoveType : IType
    {
        public MoveType(IEnumerable<IFile> files, IFilter filter)
        {
            MeasureType = new MoveMeasure();
            OperationType = new Move(files, filter);
        }

        public IMeasure MeasureType { get; set; }

        public IOperation OperationType { get; set; }
    }
}