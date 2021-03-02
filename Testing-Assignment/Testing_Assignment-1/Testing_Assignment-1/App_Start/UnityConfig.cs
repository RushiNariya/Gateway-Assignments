using System.Web.Http;
using Testing_Assignment_1.Repository;
using Unity;
using Unity.WebApi;

namespace Testing_Assignment_1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataRepository, DataRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}