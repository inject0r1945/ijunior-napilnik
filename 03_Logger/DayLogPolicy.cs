using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikLogger
{
    public class DayLogPolicy : ILogPolicy
    {
        private List<DayOfWeek> _allowedDaysOfWeek;

        public DayLogPolicy(DayOfWeek allowedDayOfWeek)
        {
            _allowedDaysOfWeek = new List<DayOfWeek>() { allowedDayOfWeek };
        }

        public DayLogPolicy(List<DayOfWeek> allowedDaysOfWeek)
        {
            _allowedDaysOfWeek = allowedDaysOfWeek;
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
