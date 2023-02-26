using System;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProducDal>().InSingletonScope();

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();
            Console.ReadLine();
        }
    }
    interface IProductDal
    {
        void Save();
    }
    class EfProducDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with ef");
        }
    }
    class NhProducDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with nh");
        }
    }
    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            //Business Code

            _productDal.Save();
        }
    }
}
