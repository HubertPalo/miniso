using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniSO.Entidades;
using MiniSO.Entidades.WebApiModels;

namespace MiniSO.WebApi.Models
{
    public class UserModel : EntidadBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public UserModel(User usuario)
        {
            this.Id = usuario.Id;
            this.Email = usuario.Email;
            this.Name = usuario.Name;
            this.Password = usuario.Password;
            this.Register_date = usuario.Register_date;
            this.Last_edit_date = usuario.Last_edit_date;
            this.Status = usuario.Status;
        }
    }
}