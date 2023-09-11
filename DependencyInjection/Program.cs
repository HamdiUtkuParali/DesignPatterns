using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IKernel kernel1 = new StandardKernel();
            kernel1.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            IKernel kernel2 = new StandardKernel();
            kernel2.Bind<IProductDal>().To<NhProductDal>().InSingletonScope();

            ProductManager productManager = new ProductManager(kernel1.Get<IProductDal>());
            productManager.Save();

            ProductManager productManager2 = new ProductManager(kernel2.Get<IProductDal>());
            productManager2.Save();

            Console.ReadLine();

        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh");
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
            _productDal.Save();
        }
    }



}
