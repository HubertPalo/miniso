using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Entidades.WebApiModels
{
    public class AnswerModel : EntidadBaseModel
    {
        public string Description { get; set; }
        public int Question_id { get; set; }
        public int User_id { get; set; }

        public AnswerModel(Answer answer)
        {
            this.Description = answer.Description;
            this.Question_id = answer.Question_id;
            this.User_id = answer.User_id;

            this.Register_date = answer.Register_date;
            this.Last_edit_date = answer.Last_edit_date;
            this.Status = answer.Status;
        }

    }
}
