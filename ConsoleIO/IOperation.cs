using System.Collections.Generic;

namespace Main
{
    public interface IOperation
    {
        IEnumerable<IFile> Files { get; set; }

        void Init(ISource source, IDestination destination, Tracker tracker);

        void EngageOperation(ISource source, IDestination destination);

        void TrackTime(ISource source, IDestination destination, Tracker tracker);

        void ComputeSize(Tracker tracker);
    }
}
