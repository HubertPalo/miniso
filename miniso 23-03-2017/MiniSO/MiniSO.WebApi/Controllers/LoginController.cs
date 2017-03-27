using MiniSO.Entidades;
using MiniSO.Servicio;
using MiniSO.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MiniSO.WebApi.Controllers
{
    [EnableCors(origins: ServicioWebApi.CorsOriginsUri, headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        private readonly IServicioMiniSO servicio;
        public LoginController(IServicioMiniSO _servicio)
        {
            servicio = _servicio;
        }

        [HttpPost]
        //[Route("api/authentication/check_login/{username}/{password}")]
        public UserModel validate_login([FromBody] User usuario)
        {
            return servicio.GetUserByUserNameAndPassword(usuario.Name, usuario.Password);
        }

    }
}
