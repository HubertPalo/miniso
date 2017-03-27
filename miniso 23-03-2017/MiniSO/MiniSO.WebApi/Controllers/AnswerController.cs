using MiniSO.Entidades;
using MiniSO.Servicio;
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
    public class AnswerController : ApiController
    {
        private readonly IServicioMiniSO servicio;
        public AnswerController(IServicioMiniSO _servicio)
        {
            servicio = _servicio;
        }

        // GET: api/Answer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Answer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Answer
        public int Post([FromBody]Answer answer)
        {
            return servicio.AddAnswer(answer);
        }

        // PUT: api/Answer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Answer/5
        public void Delete(int id)
        {
        }
    }
}
