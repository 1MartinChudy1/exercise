using System.Collections.Generic;

namespace ConsoleIO
{
    public interface IOperation
    {
        IEnumerable<IFile> Files { get; set; }

        void Init(ISource source, IDestination destination, ITracker tracker);

        void EngageOperation(ISource source, IDestination destination);

        void TrackTime(ISource source, IDestination destination, ITracker tracker);

        void ComputeSize(ITracker tracker);
    }
}
