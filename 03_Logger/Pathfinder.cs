using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NapilnikLogger
{
    public class Pathfinder : ILogger
    {
        private List<ILogger> _loggers;
        private List<ILogPolicy> _logPolicies;

        public Pathfinder(List<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public Pathfinder(ILogger logger)
        {
            _loggers = new List<ILogger>() { logger };
        }

        public Pathfinder(ILogger logger, List<ILogPolicy> logPolicies) : this(logger)
        {
            _logPolicies = logPolicies;
        }

        public Pathfinder(ILogger logger, ILogPolicy logPolicy) : this(logger)
        {
            _logPolicies = new List<ILogPolicy>() { logPolicy };
        }

        public void Find()
        {
            string message = "Hello, World";
            Log(message);
        }

        public void Log(string message)
        {
            if (!IsAllowedWriteLog())
                return;
            
            foreach(ILogger logger in _loggers)
            {
                logger.Log(message);
            }
        }

        private bool IsAllowedWriteLog()
        {
            if (_logPolicies == null)
                return true;

            foreach (ILogPolicy logPolicy in _logPolicies)
            {
                if (logPolicy.IsAllowedWriteLog())
                    return true;
            }

            return false;
        }
    }
}
