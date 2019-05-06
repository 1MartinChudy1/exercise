using System.Collections.Generic;

namespace Main
{
    internal class CopyType : IType
    {
        public CopyType(IEnumerable<IFile> files, IFilter filter)
        {
            MeasureType = new CopyMeasure();
            OperationType = new Copy(files, filter);
        }

        public IMeasure MeasureType { get; set; }

        public IOperation OperationType { get; set; }
    }
}