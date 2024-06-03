using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int Id { get; set; }

        public int UserName { get; set; }

        public int Contrasenia { get; set; }

        public RolUsuario RolUsuario { get; set; }
    }
}
