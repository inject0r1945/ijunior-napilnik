using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikLogger
{
    public class ConsoleLogWriter : ILogger
    {
        private ILogger _logger;

        public ConsoleLogWriter() { }

        public ConsoleLogWriter(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            Console.WriteLine(message);

            if (_logger == null)
                return;

            _logger.Log(message);
        }
    }
}
