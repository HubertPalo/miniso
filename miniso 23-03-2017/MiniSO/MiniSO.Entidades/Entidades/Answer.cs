namespace MiniSO.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer : EntidadBase
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        public int Question_id { get; set; }

        public int User_id { get; set; }

        public virtual Question Question { get; set; }

        public virtual User User { get; set; }
    }
}
