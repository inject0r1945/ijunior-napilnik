using System.IO;

namespace NapilnikLogger
{
    public class FileLogWriter : ILogger
    {
        private string _logFilePath = "log.txt";

        public void Log(string message)
        {
            File.WriteAllText(_logFilePath, message);
        }
    }
}
