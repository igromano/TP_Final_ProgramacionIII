using accesoDatos;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ServicioNegocio
    {

        public List<Estado> getEstados()
        {
            List<Estado> estados = new List<Estado>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.configurarConsulta("SELECT * FROM Estados");
                datos.ejecutarConsulta();

                while (datos.lector.Read())
                {
                    Estado estado = new Estado();
                    estado.Id = int.Parse(datos.lector["ID"].ToString());
                    estado.Nombre = datos.lector["Nombre"].ToString();

                    estados.Add(estado);
                }

                return estados;
            }
            catch (Exception ex)
            {
                throw ex;
            }finally { datos.cerrarConexion(); }
        }

        public List<Locacion> getLocaciones()
        {
            List<Locacion> locaciones = new List<Locacion>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.configurarConsulta("SELECT l.ID AS 'ID_Localidad', l.Nombre AS 'Nombre', p.ID AS 'ID_Provincia', p.Nombre AS 'Nombre_Provincia'" +
                    " FROM Localidad l inner join Provincia p ON l.IDProvincia = p.ID");
                datos.ejecutarConsulta();

                while (!datos.lector.Read())
                {
                    Locacion locacion = new Locacion();
                    locacion.Id = int.Parse(datos.lector["ID_Localidad"].ToString());
                    locacion.Nombre = datos.lector["Nombre"].ToString();
                    locacion.IdProvincia = int.Parse(datos.lector["ID_Provincia"].ToString());
                    locacion.NombreProvincia = datos.lector["Nombre_Provincia"].ToString();

                    locaciones.Add(locacion);
                }
                return locaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public List<Especialidad> getEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.configurarConsulta("SELECT * FROM Especialidades");
                datos.ejecutarConsulta();

                while (!datos.lector.Read())
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.Id = int.Parse(datos.lector["ID"].ToString());
                    especialidad.Nombre = datos.lector["Nombre"].ToString();

                    especialidades.Add(especialidad);
                }
                return especialidades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
   

}
