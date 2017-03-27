using MiniSO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiniSO.Common;
using MiniSO.Servicio;
using System.Web.Http.Cors;
using MiniSO.WebApi.Models;

namespace MiniSO.WebApi.Controllers
{
    [EnableCors(origins: ServicioWebApi.CorsOriginsUri, headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private readonly IServicioMiniSO servicio;
        public UserController(IServicioMiniSO _servicio)
        {
            servicio = _servicio;
        }
        
        
        // GET: api/User
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return servicio.GetAllValidUsers();
        }

        // GET: api/User/5
        [HttpGet]
        public UserModel Get(int id)
        {
            return servicio.GetUserById(id);
        }

        

        /*
        // POST: api/User
        [HttpGet][Route("api/user/agregar/{username}/{email}/{password}")]
        public string Post(string username, string email, string password)
        {
            servicio.AddUser(username, email, password);
            return "exito";
        }*/

        [HttpPost]
        public int Post([FromBody]User usuario)
        {
            if (servicio.IfUserNameIsAlreadyRegistered(usuario.Name))
            {
                return -2;
            } else
            {
                servicio.AddUser(usuario);
                return servicio.GetUserByUserNameAndPassword(usuario.Name, usuario.Password).Id; 
            }
                
            
        }

        // PUT: api/User/5
        public string Put(int id, [FromBody]string value)
        {
            return value;
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
