using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NapilnikLogger
{
    public class Pathfinder
    {
        private ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            _logger =  logger;
        }

        public void Find()
        {
            string message = "Hello, World";
            _logger.Log(message);
        }
    }
}
