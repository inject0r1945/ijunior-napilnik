using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikLogger
{
    class DaysLimitLogWriter : ILogger
    {
        private ILogger _logger;
        private DayOfWeek _allowedDayOfWeek;

        public DaysLimitLogWriter(ILogger logger, DayOfWeek allowedDayOfWeek)
        {
            _logger = logger;
            _allowedDayOfWeek = allowedDayOfWeek;
        }

        public void Log(string message)
        {
            if (!CanWrite())
                return;

            _logger.Log(message);
        }

        public bool CanWrite()
        {
            if (DateTime.Now.DayOfWeek == _allowedDayOfWeek)
                return true;

            return false;
        }
    }
}
