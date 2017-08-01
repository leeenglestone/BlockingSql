namespace BlockingSql.MvcWebApplication.Models
{
    public class BlockingSqlStatementModel
    {
        public int SessionId { get; set; }
        public string SqlText { get; set; }
        public string LoginName { get; set; }
        public int? BlockingSessionId { get; set; }
        public string HostName { get; set; }
        public string DatabaseName { get; set; }
        public string Server { get; set; }
        public string Status { get; set; }
        public string ProgramName { get; set; }
        public string Duration { get; set; }
    }
}