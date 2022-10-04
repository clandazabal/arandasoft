namespace ArandaSoft.Test.API
{
    using System.Web.Http;
    using ArandaSoft.Test.Service.Contract;
    using ArandaSoft.Test.Service.Implementation.Repository.Persistence;
    using ArandaSoft.Test.Service.Implementation.Service;
    using Unity;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepository, ProductRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}