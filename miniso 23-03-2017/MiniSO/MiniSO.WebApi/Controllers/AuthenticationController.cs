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
    public class AuthenticationController : ApiController
    {
        private readonly IServicioMiniSO servicio;
        public  AuthenticationController(IServicioMiniSO _servicio)
        {
            servicio = _servicio;
        }

        [HttpGet]
        [Route("api/authentication/if_user_already_exists/{username}/{password}")]
        public bool If_User_Already_Exists(string username, string password)
        {
            return servicio.IsValid(username, password);
        }

        [HttpGet]
        [Route("api/authentication/if_email_is_already_registered/{email}")]
        public bool If_email_is_already_registered(string email)
        {
            return servicio.IfUserEmailIsAlreadyRegistered(email);
        }

        [HttpGet]
        [Route("api/authentication/if_username_is_already_registered/{username}")]
        public bool If_username_is_already_registered(string username)
        {
            return servicio.IfUserNameIsAlreadyRegistered(username);
        }

        [HttpGet]
        [Route("api/authentication/check_login/{username}/{password}")]
        public UserModel check_login_data(string username, string password)
        {
            return servicio.GetUserByUserNameAndPassword(username, password);
        }




    }
}
