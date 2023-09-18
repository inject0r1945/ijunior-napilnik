using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikLogger
{
    public class ConsoleLogWriter : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
