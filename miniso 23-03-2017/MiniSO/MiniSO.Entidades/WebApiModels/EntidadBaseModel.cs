using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Entidades.WebApiModels
{
    public class EntidadBaseModel
    {
        public DateTime Register_date { get; set; }
        public DateTime Last_edit_date { get; set; }
        public string Status { get; set; }
    }
}
