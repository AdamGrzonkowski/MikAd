using Microsoft.Practices.Unity;
using System.Web.Http;
using Shop.Model.Models;
using Shop.Repository.Interfaces;
using Shop.Repository.Repositories;
using Unity.WebApi;

namespace Shop.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRepository<Category, int>, CategoryRepository>();
            container.RegisterType<IRepository<Product, int>, ProductRepository>();
            container.RegisterType<IRepository<Order, int>, OrderRepository>();
            container.RegisterType<IRepository<Image, int>, ImageRepository>();
            container.RegisterType<IRepository<Review, int>, ReviewRepository>();
            container.RegisterType<IRepository<Payment, int>, PaymentRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}