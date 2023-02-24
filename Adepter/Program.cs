using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adepter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
        }
    }
    class ProductManager
    {
        Ilogger _logger;

        public ProductManager(Ilogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data.");
            Console.WriteLine("Saved");
        }
    }
    interface Ilogger
    {
        void Log(string message);
    }
    class KdLogger : Ilogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0}", message);
        }
    }
    //Nuget
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net, {0}", message);
        }
    }
    class Log4NetAdapter : Ilogger
    {
      

        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
