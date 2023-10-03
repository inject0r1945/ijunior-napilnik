using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikLogger
{
    public class LoggerGroup : ILogger
    {
        ILogger[] _loggers;

        public LoggerGroup(params ILogger[] loggers)
        {
            _loggers = loggers;
        }

        public void Log(string message)
        {
            foreach (ILogger logger in _loggers)
            {
                logger.Log(message);
            }
        }
    }
}
