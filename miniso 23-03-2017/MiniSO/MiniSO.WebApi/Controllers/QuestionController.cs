using MiniSO.Entidades;
using MiniSO.Entidades.WebApiModels;
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
    [EnableCors(origins: ServicioWebApi.CorsOriginsUri , headers: "*", methods: "*")]
    public class QuestionController : ApiController
    {
        private readonly IServicioMiniSO servicio;
        public QuestionController(IServicioMiniSO _servicio)
        {
            servicio = _servicio;
        }
        [HttpGet]
        // GET: api/Question
        public QuestionModel Get()
        {
            return servicio.getLastQuestionByUserId(1);
        }
        [HttpGet]
        // GET: api/Question/5
        public QuestionModel Get(int id)
        {
            return servicio.GetQuestionById(id);
        }
        [HttpGet]
        //[Route("api/question/getallbyuser/{user_id}")]
        public IEnumerable<QuestionModel> GetAllByUser(int id)
        {
            return servicio.GetAllQuestionsFromUser(id);
        }
        [HttpPost]
        // POST: api/Question
        public QuestionModel Post([FromBody]Question question)
        {
            servicio.AddQuestion(question);
            return servicio.getLastQuestionByUserId(question.User_id);

        }
        [HttpPut]
        // PUT: api/Question/5
        public void Put(int id, [FromBody]string value)
        {
        }
        
    }
}
