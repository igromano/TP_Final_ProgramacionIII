using accesoDatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace negocio
{
    public class TrabajoNegocio
    {
        public void registrarTrabajo(string idUsuario, int idEspecialidad, double monto, int idEstado, string comentarioUsuario, string idPrestador = "0")
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.configurarProcedimiento("SP_CrearTicket");
                datos.settearParametros("@IdUsuario", idUsuario);   
                datos.settearParametros("@IdPrestador", idPrestador);
                datos.settearParametros("@IdEspecialidad", idEspecialidad);
                datos.settearParametros("@Monto", monto);
                datos.settearParametros("@IdEstado", idEstado);
                datos.settearParametros("@ComentarioUsuario", comentarioUsuario);

                datos.ejecutarConsulta();
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
            finally { datos.cerrarConexion(); }
        }

        public List<Ticket> getTicketsPorRol(Usuario usuario)
        {

            List<Ticket> listadoTickets = new List<Ticket>();
            AccesoADatos datos = new AccesoADatos();
            try
            {
                if (usuario.RolUsuario == RolUsuario.USUARIO)
                {
                    datos.configurarConsulta("SELECT * FROM VW_VerTickets WHERE ID_Usuario = @IdUsuario");
                }
                else
                {
                    datos.configurarConsulta("SELECT * FROM VW_VerTickets WHERE ID_Prestador = @IdUsuario");

                }

                datos.settearParametros("@IdUsuario", usuario.IdPersona);
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
                    tmpUsuario.Id = int.Parse(datos.lector["ID_Usr_Cliente"].ToString());
                    tmpTicket.Usuario = tmpUsuario;

                    tmpPrestador.IdPersona = datos.lector["ID_Prestador"].ToString();
                    tmpPrestador.Nombre = datos.lector["Pres_Nombre"].ToString();
                    tmpPrestador.Apellido = datos.lector["Pres_Apellido"].ToString();
                    tmpPrestador.RolUsuario = RolUsuario.PRESTADOR;
                    tmpPrestador.Id = int.Parse(datos.lector["ID_Usr_Prestador"].ToString());
                    tmpTicket.Prestador = tmpPrestador;

                    Estado estado = new Estado();

                    tmpTicket.Especialidad = datos.lector["Especialidad"].ToString();
                    estado.Id = int.Parse(datos.lector["ID_Estado"].ToString());
                    estado.Nombre = datos.lector["Estado"].ToString();
                    tmpTicket.Estado = estado;

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

        //public void crearTicket(Ticket ticket)
        //{
        //    AccesoADatos datos = new AccesoADatos();
        //    try
        //    {
        //        datos.configurarConsulta(" INSERT INTO Ticket(@IDUsuario, @IDPrestador, @IDEspecialidad, @Monto, @IDEstado, @ComentarioUsuario, FechaSolicitado) +" +
        //            "VALUES(@IDUsuario, @IDPrestador, @IDEspecialidad, @Monto, @IDEstado, @ComentarioUsuario, getdate())");

        //        datos.settearParametros("@IDUsuario", ticket.Usuario.IdPersona);
        //        datos.settearParametros("@IDPrestador", ticket.Prestador.IdPersona);
        //        datos.settearParametros("@IDEspecialidad", ticket.Especialidad);
        //        datos.settearParametros("@Monto", ticket.Monto);
        //        datos.settearParametros("@IDEstado", ticket.Estado);
        //        datos.settearParametros("@ComentarioUsuario", ticket.ComentariosUsuario);

        //        datos.ejecutarConsulta();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }

        //}


    }
}
