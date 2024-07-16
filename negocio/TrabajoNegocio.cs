using accesoDatos;
using dominio;
using negocio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace negocio
{
    public class TrabajoNegocio
    {
        public void registrarTrabajo(string idUsuario, double monto, int idEstado, string comentarioUsuario, string idPrestador = "0", int idEspecialidad = 0, int idUsuarioAprobacion = 0)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                List<Especialidad> especialidades = new List<Especialidad>();
                especialidades = Utils.Utils.getEspecialidades();
                if (idEspecialidad == 0)
                {
                    idEspecialidad = especialidades.Find(f => f.Nombre == "SIN ESPECIALIDAD").Id;
                }
                datos.configurarProcedimiento("SP_CrearTicket");
                datos.settearParametros("@IdUsuario", idUsuario);
                datos.settearParametros("@IdPrestador", idPrestador);
                datos.settearParametros("@IdEspecialidad", idEspecialidad);
                datos.settearParametros("@Monto", monto);
                datos.settearParametros("@IdEstado", idEstado);
                datos.settearParametros("@ComentarioUsuario", comentarioUsuario);                
                if(idUsuarioAprobacion != 0)
                {
                    datos.settearParametros("@IDUsuarioAprobacion", idUsuarioAprobacion);
                }
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

        public void cambiarEstado(int idTrabajo, int idEstado, Usuario usuario = null)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.configurarConsulta("UPDATE Ticket set IDEstado = @IDEstado, IDUsrAprobacion = @IDUsrAprobacion where ID = @IDTrabajo");
                datos.settearParametros("@IDEstado", idEstado);
                datos.settearParametros("@IDTrabajo", idTrabajo);
                if (usuario != null)
                {
                    datos.settearParametros("@IDUsrAprobacion", usuario.IdPersona);
                }
                else
                {
                    datos.settearParametros("@IDUsrAprobacion", DBNull.Value);
                }

                datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }

            EmailService email = new EmailService();
            email.armarMail(usuario.Email, "Su ticket se ha actualizado", "", "Detalle.aspx?idTicket=1005");
            email.enviarCorreo();
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
                    tmpTicket.Monto = double.Parse(datos.lector["Monto"].ToString());

                    if (!(datos.lector["ID_Prestador"] is DBNull))
                    {
                        tmpPrestador.IdPersona = datos.lector["ID_Prestador"].ToString();
                        tmpPrestador.Nombre = datos.lector["Pres_Nombre"].ToString();
                        tmpPrestador.Apellido = datos.lector["Pres_Apellido"].ToString();
                        tmpPrestador.RolUsuario = RolUsuario.PRESTADOR;
                        tmpPrestador.Id = int.Parse(datos.lector["ID_Usr_Prestador"].ToString());
                        tmpTicket.Prestador = tmpPrestador;
                    }

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
                        DateTime.Parse("1900-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Solicitado"].ToString());

                    tmpTicket.FechaRealizado = datos.lector["Fecha_Realizado"] is DBNull ?
                        DateTime.Parse("1900-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Realizado"].ToString());

                    tmpTicket.FechaResenia = datos.lector["Fecha_Res"] is DBNull ?
                        DateTime.Parse("1900-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Res"].ToString());
                    tmpTicket.IdUsuarioAprobacion = datos.lector["ID_Usr_Aprobacion"] is DBNull ? "" : datos.lector["ID_Usr_Aprobacion"].ToString();

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

        public List<Ticket> getTicketsPorEstado(Estado estado)
        {
            List<Ticket> listadoTickets = new List<Ticket>();
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.configurarConsulta("SELECT * FROM VW_VerTickets WHERE ID_Estado = @IdEstado");
                datos.settearParametros("@IdEstado", estado.Id);
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
                    tmpTicket.Monto = double.Parse(datos.lector["Monto"].ToString());

                    if (!(datos.lector["ID_Prestador"] is DBNull))
                    {
                        tmpPrestador.IdPersona = datos.lector["ID_Prestador"].ToString();
                        tmpPrestador.Nombre = datos.lector["Pres_Nombre"].ToString();
                        tmpPrestador.Apellido = datos.lector["Pres_Apellido"].ToString();
                        tmpPrestador.RolUsuario = RolUsuario.PRESTADOR;
                        tmpPrestador.Id = int.Parse(datos.lector["ID_Usr_Prestador"].ToString());
                        tmpTicket.Prestador = tmpPrestador;
                    }

                    Estado tmpEstado = new Estado();

                    tmpTicket.Especialidad = datos.lector["Especialidad"].ToString();
                    tmpEstado.Id = int.Parse(datos.lector["ID_Estado"].ToString());
                    tmpEstado.Nombre = datos.lector["Estado"].ToString();
                    tmpTicket.Estado = tmpEstado;

                    tmpTicket.ComentariosUsuario = datos.lector["Usr_Comentarios"].ToString();
                    tmpTicket.ComentariosPrestador = datos.lector["Pres_Comentarios"].ToString();

                    tmpTicket.Calificacion = (int.Parse(datos.lector["Calificacion"].ToString()) < 0) ||
                        (int.Parse(datos.lector["Calificacion"].ToString())) > 5
                        ? 0 : int.Parse(datos.lector["Calificacion"].ToString());

                    tmpTicket.ComentarioResenia = datos.lector["Res_Comentario"] is DBNull ?
                        "" : datos.lector["Res_Comentario"].ToString();

                    tmpTicket.FechaSolicitado = datos.lector["Fecha_Solicitado"] is DBNull ?
                        DateTime.Parse("1900-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Solicitado"].ToString());

                    tmpTicket.FechaRealizado = datos.lector["Fecha_Realizado"] is DBNull ?
                        DateTime.Parse("1900-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Realizado"].ToString());

                    tmpTicket.FechaResenia = datos.lector["Fecha_Res"] is DBNull ?
                        DateTime.Parse("1900-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Res"].ToString());
                    tmpTicket.DomicilioTrabajo = datos.lector["Usr_Domicilio"].ToString();
                    tmpTicket.IdLocalidad = int.Parse(datos.lector["ID_Localidad_Trabajo"].ToString());
                    tmpTicket.IdProvincia = int.Parse(datos.lector["ID_Provincia_Trabajo"].ToString());
                    tmpTicket.IdUsuarioAprobacion = datos.lector["ID_Usr_Aprobacion"] is DBNull ? "" : datos.lector["ID_Usr_Aprobacion"].ToString();
                    listadoTickets.Add(tmpTicket);
                }

                return listadoTickets;
            }

            catch (Exception ex)
            {

                throw new Exception("Error al obtener tickets desde la DB - Error: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void registrarResenia(Ticket ticket)
        {
            if (ticket.Estado.Nombre.Equals("EN PROCESO") || ticket.Estado.Nombre.Equals("A ASIGNAR") || ticket.Estado.Nombre.Equals("SOLICITADO"))
            {
                throw new Exception("El ticket debe estar finalizado para agregar una reseña");
            }

            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.configurarConsulta("INSERT Resenias VALUES(@ID, GETDATE(), @Comentario, @Calificacion)");
                datos.settearParametros("@ID", ticket.Id);
                datos.settearParametros("@Comentario", ticket.ComentarioResenia);
                datos.settearParametros("@Calificacion", ticket.Calificacion);

                datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ingresar reseña, Error: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void updateTicket(Ticket ticket)
        {
            if (!ticket.Estado.Nombre.Equals("CANCELADO") || !ticket.Estado.Nombre.Equals("REALIZADO"))
            {
                AccesoADatos datos = new AccesoADatos();
                try
                {
                    datos.configurarProcedimiento("SP_UpdateTicket");
                    datos.settearParametros("@ID", ticket.Id);
                    if (ticket.Prestador != null)
                    {

                        datos.settearParametros("@IDPrestador", ticket.Prestador.IdPersona);
                    }
                    datos.settearParametros("@IDEspecialidad", Utils.Utils.getEspecialidades().Find(e => e.Nombre.Equals(ticket.Especialidad)).Id);
                    datos.settearParametros("@Monto", ticket.Monto);
                    datos.settearParametros("@IDEstado", ticket.Estado.Id);
                    datos.settearParametros("@ComentarioUsuario", ticket.ComentariosUsuario);
                    datos.settearParametros("@ComentarioPrestador", ticket.ComentariosPrestador);
                    if (!ticket.IdUsuarioAprobacion.Equals("0"))
                    {
                        datos.settearParametros("@IDUsrAprobacion", ticket.IdUsuarioAprobacion);
                    }
                    if(ticket.FechaRealizado.Year != 1900)
                    {
                        datos.settearParametros("@FechaRealizado", ticket.FechaRealizado);
                    }

                    datos.ejecutarConsulta();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally { datos.cerrarConexion(); }

            }
            else
            {
                throw new Exception("El ticket no puede ser modificado en estado CANCELADO o REALIZADO");
            }
        }

        public Ticket getTicketPorId(int idticket)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.configurarConsulta("SELECT * FROM VW_VerTickets WHERE ID_Ticket = @IDticket");
                datos.settearParametros("@IDticket", idticket);

                datos.ejecutarConsulta();

                Ticket tmpTicket = new Ticket();
                
                while (datos.lector.Read())
                {
                    Usuario tmpUsuario = new Usuario();
                    Usuario tmpPrestador = new Usuario();

                    tmpTicket.Id = int.Parse(datos.lector["ID_Ticket"].ToString());

                    tmpUsuario.IdPersona = datos.lector["ID_Usuario"].ToString();
                    tmpUsuario.Nombre = datos.lector["Usr_Nombre"].ToString();
                    tmpUsuario.Apellido = datos.lector["Usr_Apellido"].ToString();
                    tmpUsuario.RolUsuario = RolUsuario.USUARIO;
                    tmpUsuario.Id = int.Parse(datos.lector["ID_Usr_Cliente"].ToString());
                    tmpTicket.Usuario = tmpUsuario;
                    tmpTicket.Monto = double.Parse(datos.lector["Monto"].ToString());

                    if (!(datos.lector["ID_Prestador"] is DBNull))
                    {
                        tmpPrestador.IdPersona = datos.lector["ID_Prestador"].ToString();
                        tmpPrestador.Nombre = datos.lector["Pres_Nombre"].ToString();
                        tmpPrestador.Apellido = datos.lector["Pres_Apellido"].ToString();
                        tmpPrestador.RolUsuario = RolUsuario.PRESTADOR;
                        tmpPrestador.Id = int.Parse(datos.lector["ID_Usr_Prestador"].ToString());
                        tmpTicket.Prestador = tmpPrestador;
                    }

                    Estado tmpEstado = new Estado();

                    tmpTicket.Especialidad = datos.lector["Especialidad"].ToString();
                    tmpEstado.Id = int.Parse(datos.lector["ID_Estado"].ToString());
                    tmpEstado.Nombre = datos.lector["Estado"].ToString();
                    tmpTicket.Estado = tmpEstado;

                    tmpTicket.ComentariosUsuario = datos.lector["Usr_Comentarios"].ToString();
                    tmpTicket.ComentariosPrestador = datos.lector["Pres_Comentarios"].ToString();

                    tmpTicket.Calificacion = (int.Parse(datos.lector["Calificacion"].ToString()) < 0) ||
                        (int.Parse(datos.lector["Calificacion"].ToString())) > 5
                        ? 0 : int.Parse(datos.lector["Calificacion"].ToString());

                    tmpTicket.ComentarioResenia = datos.lector["Res_Comentario"] is DBNull ?
                        "" : datos.lector["Res_Comentario"].ToString();

                    tmpTicket.FechaSolicitado = datos.lector["Fecha_Solicitado"] is DBNull ?
                        DateTime.Parse("1900-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Solicitado"].ToString());

                    tmpTicket.FechaRealizado = datos.lector["Fecha_Realizado"] is DBNull ?
                        DateTime.Parse("1900-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Realizado"].ToString());

                    tmpTicket.FechaResenia = datos.lector["Fecha_Res"] is DBNull ?
                        DateTime.Parse("1900-01-01") :
                        DateTime.Parse(datos.lector["Fecha_Res"].ToString());
                    tmpTicket.DomicilioTrabajo = datos.lector["Usr_Domicilio"].ToString();
                    tmpTicket.IdLocalidad = int.Parse(datos.lector["ID_Localidad_Trabajo"].ToString());
                    tmpTicket.IdProvincia = int.Parse(datos.lector["ID_Provincia_Trabajo"].ToString());
                    tmpTicket.IdUsuarioAprobacion = datos.lector["ID_Usr_Aprobacion"] is DBNull ? "" : datos.lector["ID_Usr_Aprobacion"].ToString();
                    
                }
                
                return tmpTicket;
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
