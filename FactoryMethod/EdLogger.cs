using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("EdLogger ile Loglandı.");
        }
    }
    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("LogfNetLogger ile Loglandı.");
        }
    }

}
