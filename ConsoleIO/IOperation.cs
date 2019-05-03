using System.Collections.Generic;

namespace Main
{
    public interface IOperation
    {
        IEnumerable<IFile> Files { get; set; }
        
        OperationResult EngageOperation(Argument source, Argument destination);
    }
}
