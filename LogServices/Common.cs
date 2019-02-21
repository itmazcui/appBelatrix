namespace LogServices
{
    public enum KindOfError
    {
        Message = 1,
        Error = 2,
        Warning = 3
    }

    public class KindOfLogs
    {
        public bool LogToFile { get; set; }
        public bool LogToConsole { get; set; }
        public bool LogToDatabase { get; set; }
    }
}
