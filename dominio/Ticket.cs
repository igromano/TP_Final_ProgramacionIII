using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Ticket
    {
        private DateTime fechaRealizado;
        private DateTime fechaSolicitado;
        private DateTime fechaResenia;
        public Ticket() { }

        public Ticket(string idUsuario,
            string idPrestador,
            int idEspecialdiad,
            int monto,
            int idEstado,
            string comentarioUsuario,
            string comentarioPrestador)
        { }

        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        public Usuario Prestador { get; set; }

        //public Especialidad Especialidad { get; set; }

        public string  Especialidad { get; set; }
        public double Monto { get; set; }

        //public Estado Estado { get; set; }
        public string Estado { get; set; }

        public  string ComentariosUsuario { get; set; }

        public string ComentariosPrestador { get; set; }

        public string ComentarioResenia { get; set; }

        public  int Calificacion { get; set; }

        public DateTime FechaSolicitado { get; set; }

        public DateTime FechaRealizado
        {
            get { return fechaRealizado; }
            set { if (value > fechaSolicitado) fechaRealizado = value; }
        }

        public DateTime FechaResenia {
            get { return fechaResenia; }
            set { if (value >= fechaRealizado) fechaResenia = value; } }

    }
}
