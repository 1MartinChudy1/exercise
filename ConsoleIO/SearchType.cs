using System.Collections;
using System.Collections.Generic;

namespace Main
{
    public  class SearchType : IType
    {
        public SearchType(IEnumerable<IFile> files, IFilter filter)
        {
            MeasureType = new SearchMeasure();
            OperationType = new Search(files, filter);
        }

        public IMeasure MeasureType { get; set; }

        public IOperation OperationType { get; set; }
    }
}