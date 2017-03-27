using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Entidades.WebApiModels
{
    public class QuestionModel : EntidadBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int User_id { get; set; }

        public QuestionModel(Question question)
        {
            this.Id = question.Id;
            this.Title = question.Title;
            this.Description = question.Description;
            this.User_id = question.User_id;

            this.Register_date = question.Register_date;
            this.Last_edit_date = question.Last_edit_date;
            this.Status = question.Status;
        }

    }
}
