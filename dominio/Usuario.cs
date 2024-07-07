using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario : Persona
    {

        public Usuario() { }    
        public Usuario(string userName, string contrasenia) {
            this.UserName = userName;
            this.Contrasenia = contrasenia;
        }
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Contrasenia { get; set; }

        public RolUsuario RolUsuario { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public  DateTime FechaAlta { get; set; }

        public int Calificacion { get; set; }

        public bool Activo { get; set; }
    }
}
