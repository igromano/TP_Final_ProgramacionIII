using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDatos;

namespace negocio
{
    public class PrestadoresNegocio
    {
        /*
         Retorna todos los prestadores de la DB
         */
        public List<Prestador> getPrestadores()
        {
            AccesoADatos datos = new AccesoADatos();
            Prestador prestador;
            List<Prestador> prestadores = new List<Prestador>();
            try
            {
                datos.configurarConsulta("SELECT p.ID, p.Nombre, p.Apellido FROM Usuarios u inner join Personas p on u.ID = p.IDUsuario where u.iDRol = " + RolUsuario.PRESTADOR);
                datos.ejecutarConsulta();

                while (datos.lector.Read())
                {
                    prestador = new Prestador();    
                    prestador.Id = int.Parse(datos.lector["ID"].ToString());
                    prestador.Nombre = datos.lector["Nombre"].ToString();
                    prestador.Apellido = datos.lector["Apellido"].ToString();

                    prestadores.Add(prestador);
                }

                datos.cerrarConexion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return prestadores;
        }
    }
}
