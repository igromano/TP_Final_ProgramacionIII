using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Estado
    {
        public Estado() { }
        public Estado(int Id, string nombre) {
            this.Nombre = nombre;
            this.Id = Id;
        }
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}
