using accesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class TrabajoNegocio
    {
        public int registrarTrabajo(int idUsuario, int idPrestador, int idEspecialidad, double monto, int idEstado)
        {
            AccesoADatos datos = new AccesoADatos();
			try
			{
				datos.configurarConsulta("");
				datos.settearParametros("@IDUsuario", idUsuario);
                datos.settearParametros("@IDPrestador", idPrestador);
                datos.settearParametros("@IDEspecialidad", idEspecialidad);
                datos.settearParametros("@Monto", monto);
                datos.settearParametros("@IDEstado", idEstado);

                return datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void cambiarEstado(int idTrabajo, int idEstado)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.configurarConsulta("UPDATE Ticket set IDEstado = @IDEstado where ID = @IDTrabajo");
                datos.settearParametros("@IDEstado", idEstado);
                datos.settearParametros("@IDTrabajo", idTrabajo);

                datos.ejecutarConsulta();   
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion();}
        }
    }
}
