using Microsoft.Practices.Unity;
using MiniSO.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MiniSO.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //var container = new UnityContainer();
            //container.RegisterType<IServicioMiniSO, ServicioMiniSO>(new HierarchicalLifetimeManager());
            config.EnableCors();//Esto se añadió por WebApi.CORS
            // Configuración y servicios de API web
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
