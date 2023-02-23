using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public interface ILogging
    {
        void Log();
    }
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged.");
        }
    }
    public interface ICaching
    {
        void Cache();
    }
    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached.");
        }
    }
    public interface IAuthorize
    {
        void CheckUser();
    }
    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Check.");
        }
    }
    class CustomerManager
    {
        private CrossCuttongConcernsFacade facade; 

        public CustomerManager()
        {
            facade= new CrossCuttongConcernsFacade();
        }
        public void Save()
        {
            facade.Logging.Log();
            facade.Caching.Cache();
            facade.Authorize.CheckUser();
            Console.WriteLine("kaydedildi.");
        }
    }
    public class CrossCuttongConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttongConcernsFacade()
        {
            Logging=new Logging();
            Caching=new Caching();
            Authorize=new Authorize();

        }
    }
}
