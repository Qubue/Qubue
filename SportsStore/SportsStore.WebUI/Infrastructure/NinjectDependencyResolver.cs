using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type servicesType)
        {
            return kernel.GetAll(servicesType);
        }

        private void AddBindings()
        {
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m=>m.Products).Returns(new List<Product>{
            //    new Product { Name = "Piłka nożna", Price = 25 },
            //    new Product { Name = "Deska surfingowa", Price = 179 },
            //    new Product { Name = "Buty do biegania", Price = 95 }
            //}.AsQueryable);

            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}