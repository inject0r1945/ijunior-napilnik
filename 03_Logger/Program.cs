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

            ILogPolicy fridayLogPolicy = new DayLogPolicy(DayOfWeek.Friday);
            Pathfinder consoleFridayPathfinder = new Pathfinder(consoleLogWriter, fridayLogPolicy);

            Pathfinder fileFridayPathfinder = new Pathfinder(fileLogWriter, fridayLogPolicy);

            Pathfinder customPathFinder = new Pathfinder(new List<ILogger>() { consoleLogWriter, fileFridayPathfinder });

            customPathFinder.Log("Привет");
        }
    }
}
