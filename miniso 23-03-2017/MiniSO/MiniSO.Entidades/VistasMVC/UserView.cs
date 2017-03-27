using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniSO.Entidades
{
    public class UserView
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Debe escribir el nombre del alumno")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Debe escribir un email valido")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Debe escribir la contraseña")]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "Debe escribir la contraseña otra vez")]
        public string ConfirmPassword { get; set; }

    }
}