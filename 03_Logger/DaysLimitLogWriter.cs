using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikLogger
{
    class DaysLimitLogWriter : ILogger
    {
        private ILogger _logger;
        private DayOfWeek[] _allowedDaysOfWeek;

        public DaysLimitLogWriter(ILogger logger, params DayOfWeek[] allowedDaysOfWeek)
        {
            _logger = logger;
            _allowedDaysOfWeek = allowedDaysOfWeek;
        }

        public void Log(string message)
        {
            if (!IsAllowedWriteLog())
                return;

            _logger.Log(message);
        }

        public bool IsAllowedWriteLog()
        {
            foreach (DayOfWeek allowedDayOfWeek in _allowedDaysOfWeek)
            {
                if (DateTime.Now.DayOfWeek == allowedDayOfWeek)
                    return true;
            }

            return false;
        }
    }
}
