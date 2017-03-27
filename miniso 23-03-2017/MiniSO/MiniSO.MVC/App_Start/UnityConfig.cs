using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using MiniSO.Servicio;
using MiniSO.Common;
using MiniSO.MVC.Controllers;

namespace MiniSO.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            ComponentLoader.LoadContainer(container, ".\\bin", "MiniSO*.dll");
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IServicioMiniSO, ServicioMiniSO>();
            //container.RegisterType<UsersController>(new InjectionConstructor());
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}