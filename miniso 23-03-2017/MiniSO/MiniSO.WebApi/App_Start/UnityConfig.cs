using Microsoft.Practices.Unity;
using System.Web.Http;
using MiniSO.Servicio;
using Unity.WebApi;
using MiniSO.Common;

namespace MiniSO.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            ComponentLoader.LoadContainer(container, ".\\bin", "MiniSO*.dll");
            container.RegisterType<IServicioMiniSO, ServicioMiniSO>();
            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            
        }
    }
}