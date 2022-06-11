using System;
using System.Collections.Generic;
using System.Text;

namespace BalancedLog
{
    public class LogRecord
    {
        private string text;
        private DateTime currentTime;
        private RecordType recordType;

        public LogRecord(string text, RecordType recordType)
        {
            this.text = text;
            this.recordType = recordType;
            this.currentTime = DateTime.UtcNow;
        }

        public override int GetHashCode()
        {
            int hash = 3049; 

            hash = hash * 13 + this.text.GetHashCode();
            hash = hash * 13 + this.currentTime.GetHashCode();
            hash = hash * 13 + this.recordType.GetHashCode();

            return Math.Abs(hash);
        }

        public override string ToString()
        {
            return $"{this.GetHashCode()} - [{this.recordType.ToString()}]: {this.text} ({this.currentTime.ToString()})";
        }
    }

    public enum RecordType
    {
        Info = 1,
        Warn = 2,
        Error = 3,
        Fatal = 4
    }
}
