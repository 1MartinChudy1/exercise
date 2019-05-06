using System.Collections;
using System.Collections.Generic;

namespace Main
{
    public interface IType
    {
        IMeasure MeasureType { get; set; }

        IOperation OperationType { get; set; }
    }
}