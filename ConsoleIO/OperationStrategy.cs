using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Main
{
    public static class OperationStrategy
    {
        public static IMeasure PickMeasurementType(Argument argument)
        {
            switch (argument.Value)
            {
                case "Copy": return new CopyMeasure();
                case "Move": return new MoveMeasure();
                case "Search": return new SearchMeasure();
                default: return new Measure();
            }
        }

        public static IOperation PickOperationType(Argument argument, IEnumerable<IFile> files, IFilter filter)
        {
            switch (argument.Value)
            {
                case "Copy": return new Copy(files, filter);
                case "Move": return new Move(files, filter);
                case "Search": return new Search(files, filter);
                default: return null;
            }
        }
    }
}