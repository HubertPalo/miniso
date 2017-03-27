using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Entidades
{
    public class EntidadBase
    {
        [Column(TypeName = "smalldatetime")]
        public DateTime Register_date { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Last_edit_date { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }
    }
}
