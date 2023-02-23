using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new EdLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new Log4NetLogger();
        }
    }
}
