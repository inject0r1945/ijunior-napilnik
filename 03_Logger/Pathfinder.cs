using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NapilnikLogger
{
    public class Pathfinder
    {
        private List<ILogger> _loggers;

        public Pathfinder(List<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public Pathfinder(ILogger logger)
        {
            _loggers = new List<ILogger>() { logger };
        }

        public void Find()
        {
            string message = "Hello, World";
            Log(message);
        }

        private void Log(string message)
        {
            foreach(ILogger logger in _loggers)
            {
                logger.Log(message);
            }
        }
    }
}
