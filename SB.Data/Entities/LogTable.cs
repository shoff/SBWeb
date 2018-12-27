using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class LogTable
    {
        public int LogId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LogLevel { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string MessageId { get; set; }
        public string WindowsUserName { get; set; }
        public string CallSite { get; set; }
        public string ThreadId { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}
