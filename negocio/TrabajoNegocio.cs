using accesoDatos;
using dominio;
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

        public List<Ticket> getTicketsPorPrestador(string idPrestador)
        {
            List<Ticket> listadoTickets = new List<Ticket>();
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.configurarConsulta("SELECT * FROM VW_VerTickets WHERE ID_Prestador = @idPrestador");
                datos.settearParametros("@idPrestador", idPrestador);
                datos.ejecutarConsulta();

                while (datos.lector.Read())
                {
                    Ticket tmpTicket = new Ticket();
                    Usuario tmpUsuario = new Usuario();
                    Usuario tmpPrestador = new Usuario();

                    tmpTicket.Id = int.Parse(datos.lector["ID_Ticket"].ToString());
                    
                    tmpUsuario.IdPersona = datos.lector["ID_Usuario"].ToString();
                    tmpUsuario.Nombre = datos.lector["Usr_Nombre"].ToString();
                    tmpUsuario.Apellido = datos.lector["Usr_Apellido"].ToString();
                    tmpUsuario.RolUsuario = RolUsuario.USUARIO;
                    tmpTicket.Usuario = tmpUsuario;

                    tmpPrestador.IdPersona = datos.lector["ID_Prestador"].ToString();
                    tmpPrestador.Nombre = datos.lector["Pres_Nombre"].ToString();
                    tmpPrestador.Apellido = datos.lector["Pres_Apellido"].ToString();
                    tmpPrestador.RolUsuario = RolUsuario.PRESTADOR;
                    tmpTicket.Prestador = tmpPrestador;

                    tmpTicket.Especialidad = datos.lector["Especialidad"].ToString();
                    tmpTicket.Estado = datos.lector["Estado"].ToString();

                    tmpTicket.ComentariosUsuario = datos.lector["Usr_Comentarios"].ToString();
                    tmpTicket.ComentariosPrestador = datos.lector["Pres_Comentarios"].ToString();

                    tmpTicket.Calificacion = (int.Parse(datos.lector["Calificacion"].ToString()) < 0) ||
                        (int.Parse(datos.lector["Calificacion"].ToString())) > 5
                        ? 0 : int.Parse(datos.lector["Calificacion"].ToString());

                    tmpTicket.ComentarioResenia = datos.lector["Res_Comentario"] is DBNull ?
                        "" : datos.lector["Res_Comentario"].ToString();

                    tmpTicket.FechaSolicitado = datos.lector["Fecha_Solicitado"] is DBNull ? 
                        DateTime.Parse("2000-01-01") : 
                        DateTime.Parse(datos.lector["Fecha_Solicitado"].ToString());

                    tmpTicket.FechaRealizado = datos.lector["Fecha_Realizado"] is DBNull ?
                        DateTime.Parse("2000-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Realizado"].ToString());

                    tmpTicket.FechaResenia = datos.lector["Fecha_Res"] is DBNull ?
                        DateTime.Parse("2000-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Res"].ToString());
                
                    listadoTickets.Add(tmpTicket);
                }

                return listadoTickets;
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
    }
}
