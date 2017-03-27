using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSO.Servicio.IServicio;
using MiniSO.Entidades;

namespace MiniSO.Comando
{
    class Test
    {
        private readonly IServicioMiniSO servicio;

        public Test(IServicioMiniSO _servicio)
        {
            servicio = _servicio;
        }
        public void init()
        {
            /*alumno2 al1 = new alumno2();
            alumno2 al2 = new alumno2();
            IList<alumno2> alset = new List<alumno2>();

            al1.alumno2id = 7;
            al2.alumno2id = 8;

            al1.alumno2nombre = "Nombre de al1";
            al2.alumno2nombre = "Nombre de al2";

            alset.Add(al1);
            alset.Add(al2);
            servicio.InsertarAlumnos(alset);
            servicio.ModificarNombreAlumno(3, "NombreModificado");
            */

            /*
            User usuario = new User();
            usuario.Id = 1;
            usuario.Name = "Nombreprueba";
            usuario.Password = "pass";
            usuario.Email = "asda@asdas.com";
            servicio.AddUser(usuario);
            */
            //servicio.EditUser(1, "Fernando", "Fernando@gmail.com", "newPassword");
            servicio.DeleteUser(1);
            
        }
    }
}
