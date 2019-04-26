namespace ConsoleIO
{
    public interface ITracker
    {
        int FileCount { get; set; }

        long DurationOfOperation { get; set; }

        long SizeOfPayload { get; set; }
    }
}
