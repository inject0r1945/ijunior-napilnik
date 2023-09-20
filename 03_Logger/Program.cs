using System;
using System.Collections.Generic;
using System.IO;

namespace NapilnikLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger consoleLogWriter = new ConsoleLogWriter();
            Pathfinder consolePathfinder = new Pathfinder(consoleLogWriter);

            ILogger fileLogWriter = new FileLogWriter();
            Pathfinder filePathfinder = new Pathfinder(fileLogWriter);

            ILogger fridayLimitConsoleLogWriter = new DaysLimitLogWriter(consoleLogWriter, DayOfWeek.Friday);
            Pathfinder consoleFridayPathfinder = new Pathfinder(fridayLimitConsoleLogWriter);

            ILogger fridayLimitFileLogWriter = new DaysLimitLogWriter(fileLogWriter, DayOfWeek.Friday);
            Pathfinder fileFridayPathfinder = new Pathfinder(fridayLimitFileLogWriter);

            Pathfinder customPathFinder = new Pathfinder(new List<ILogger>() { consoleLogWriter, fridayLimitFileLogWriter });

            customPathFinder.Find();
        }
    }
}
