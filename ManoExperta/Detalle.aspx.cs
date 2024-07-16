using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManoExperta.helpers;
using dominio;
using negocio;
using negocio.Utils;
using System.Net.NetworkInformation;
using System.Data.SqlTypes;

namespace ManoExperta
{
    public partial class Detalle : System.Web.UI.Page
    {
        public int idTicket = 0;
        public Usuario usuario = new Usuario();
        public string estadoActual;
        public Ticket ticket = new Ticket();
        public UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        public (int codigo, string mensaje) alerta;
        TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
        List<Ticket> tickets = new List<Ticket>();
        protected void Page_Load(object sender, EventArgs e)
        {
            idTicket = Convert.ToInt32(Request.QueryString["idTicket"]);
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                if (idTicket != null)
                {
                    Session.Add("estadoRuta", Request.Url.ToString());
                }
                Response.Redirect("Login.aspx", true);
            }

            if (Request.QueryString["idTicket"] == null)
            {
                Response.Redirect("Error.aspx", false);
            }
            else
            {

                usuario = (Usuario)Session["usuario"];

                if (((List<Ticket>)Session["tickets"]) != null)
                {
                    //tickets = (List<Ticket>)Session["tickets"];
                    tickets = trabajoNegocio.getTicketsPorEstado();
                    ticket = tickets.Find(tck => tck.Id == idTicket);
                }
                else
                {
                    ticket = trabajoNegocio.getTicketPorId(idTicket);

                }
                
                if (ticket == null || usuario.RolUsuario == RolUsuario.USUARIO && ticket.Usuario.IdPersona != usuario.IdPersona)
                {
                    Response.Redirect("Error.aspx", false);
                }


                /*if(usuario.RolUsuario == RolUsuario.PRESTADOR)
                {
                    ticket = tickets.Find(tck => tck.Id == idTicket && tck.Prestador.IdPersona == usuario.IdPersona);
                }
                else
                {

                    ticket = tickets.Find(tck => tck.Id == idTicket && tck.Usuario.IdPersona == usuario.IdPersona);
                }
                */
                if (!IsPostBack)
                {

                    if (ticket != null)
                    {

                        Usuario usuarioCreador;
                        usuarioCreador = usuarioNegocio.getUsuario(ticket.Usuario.Id);
                        estadoActual = ticket.Estado.Nombre;
                        TextBoxNombre_Cliente.Text = ticket.Usuario.Nombre + " " + ticket.Usuario.Apellido;
                        TextBoxDireccion.Text = usuarioCreador.Domicilio; // cambiar cuando nacho lo agregue a la carga en getTicketsPorRol
                        List<Locacion> provinciasUnicas = Utils.getLocaciones().GroupBy(loc => new { loc.IdProvincia, loc.NombreProvincia }).Select(loc => loc.First()).ToList();
                        TextBoxProvincia.Text = Utils.getLocaciones().Find(loc => loc.Id == usuarioCreador.IdLocalidad).NombreProvincia;
                        TextBoxLocalidad.Text = Utils.getLocaciones().Find(loc => loc.Id == usuarioCreador.IdLocalidad).Nombre;
                        TextBoxFecha_Solicitado.Text = ticket.FechaSolicitado.ToString("yyyy-MM-dd");
                        TextBoxFecha_Trabajo.Text = ticket.FechaRealizado.Year == 1900 ? "" : ticket.FechaRealizado.ToString("yyyy-MM-dd");
                        TextBoxComentario.Text = ticket.ComentariosUsuario;
                        TextBoxDNICliente.Text = ticket.Usuario.IdPersona;
                        TextBoxEspecialidad.Text = ticket.Especialidad;

                        if (ticket.Prestador != null)
                        {
                            estadoActual = ticket.Estado.Nombre;

                            TextBoxProveedor.Text = ticket.Prestador.Nombre + " " + ticket.Prestador.Apellido;
                            TextBoxFecha_Trabajo.Text = ticket.FechaRealizado.Year == 1900 ? "" : ticket.FechaRealizado.ToString("yyyy-MM-dd");
                            TextBoxComentario_Proveedor.Text = ticket.ComentariosPrestador;
                            TextBoxCuil_Prov.Text = ticket.Prestador.IdPersona;
                            TextBoxMonto_Trabajo.Text = ticket.Monto.ToString();

                        }
                        evaluarEstado();

                    }
                    else
                    {
                        Response.Redirect("Error.aspx", false);
                    }
                }
                evaluarEstado();
            }

        }

        protected void evaluarEstado()
        {
            if (ticket.Estado.Id == Utils.getEstados().Find(est => est.Nombre.Equals("A ASIGNAR")).Id)
            {
                if (usuario.RolUsuario == RolUsuario.USUARIO)
                {

                    btnCancelarTrabajo.Visible = true;
                }
                else
                {
                    if (!ticket.Especialidad.Equals("SIN ESPECIALIDAD") && !ticket.Especialidad.Equals(usuario.Especialidad.Nombre))
                    {
                        alerta = (2, "Su especialidad no es la indicada para este trabajo.");
                        return;
                    }
                    btnPostularse.Visible = true;
                    TextBoxFecha_Trabajo.ReadOnly = false;
                    TextBoxMonto_Trabajo.ReadOnly = false;
                    TextBoxComentario_Proveedor.ReadOnly = false;

                }
            }
            if (ticket.Estado.Id == Utils.getEstados().Find(est => est.Nombre.Equals("SOLICITADO")).Id)
            {
                if (usuario.RolUsuario == RolUsuario.USUARIO)
                {
                    if (ticket.IdUsuarioAprobacion.Equals(usuario.IdPersona))
                    {
                        alerta = (1, "Tu solicitud ya fue hecha al prestador y esta esperando que sea aceptada.");
                    }
                    else
                    {
                        alerta = (1, "¡Un prestador se postuló para tu trabajo! Aceptalo o rechazalo.");
                        btnAprobarSolicitud.Visible = true;
                        btnDescartarSolicitud.Visible = true;

                    }

                }
                else
                {
                    if (ticket.IdUsuarioAprobacion.Equals(ticket.Usuario.IdPersona))
                    {
                        alerta = (1, "¡Felicidades, te han solicitado un trabajo! Completa la información y aceptalo, o rechazalo.");
                        btnAceptarPedido.Visible = true;
                        btnRechazarPedido.Visible = true;
                        TextBoxFecha_Trabajo.ReadOnly = false;
                        TextBoxMonto_Trabajo.ReadOnly = false;
                        TextBoxComentario_Proveedor.ReadOnly = false;
                    }
                    else
                    {
                        alerta = (1, "Este ticket se encuentra en aprobación para pasar al siguiente estado.");
                        btnPostularse.Visible = true;
                        btnPostularse.Enabled = false;

                    }
                }
            }
            if (ticket.Estado.Id == Utils.getEstados().Find(est => est.Nombre.Equals("EN PROCESO")).Id)
            {
                if (usuario.RolUsuario == RolUsuario.USUARIO)
                {
                    if (ticket.IdUsuarioAprobacion.Equals(ticket.Prestador.IdPersona))
                    {
                        alerta = (1, "El proveedor indica que el trabajo ya se hizo. Por favor confirmalo para indicar que fue realizado.");
                        btnConfirmarRealizado.Visible = true;
                    }
                    else
                    {
                        btnCancelarTrabajo.Visible = true;
                    }
                }
                else
                {
                    if (ticket.IdUsuarioAprobacion.Equals(ticket.Prestador.IdPersona))
                    {
                        btnPasarRealizado.Visible = true;
                        btnPasarRealizado.Enabled = false;
                        alerta = (1, "Este ticket se encuentra en aprobación para pasar al siguiente estado.");
                    }
                    else
                    {
                        btnPasarRealizado.Visible = true;
                        btnPasarRealizado.Enabled = true;
                    }
                }
            }
            if (ticket.Estado.Id == Utils.getEstados().Find(est => est.Nombre.Equals("REALIZADO")).Id || ticket.Estado.Id == Utils.getEstados().Find(est => est.Nombre.Equals("CANCELADO")).Id)
            {
                btnPasarRealizado.Visible = false;
                btnCancelarTrabajo.Visible = false;
            }
        }
        protected void btnAccionTrabajo(object sender, EventArgs e)
        {
            string accion = ((Button)sender).CommandArgument;
            tickets = (List<Ticket>)Session["tickets"];
            ticket = tickets.Find(tck => tck.Id == idTicket);
            try
            {
                if (accion.Equals("POSTULARSE"))
                {
                    ticket.Estado = Utils.getEstados().Find(est => est.Nombre.Equals("SOLICITADO"));
                    ticket.Prestador = usuario;
                    ticket.Especialidad = usuario.Especialidad.Nombre;
                    ticket.IdUsuarioAprobacion = usuario.IdPersona;
                    ticket.ComentariosPrestador = TextBoxComentario_Proveedor.Text;
                    ticket.Monto = double.Parse(TextBoxMonto_Trabajo.Text);
                    trabajoNegocio.updateTicket(ticket);
                    Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
                    alerta = (1, "Trabajo actualizado correctamente.");
                }
                if (accion.Equals("APROBAR SOLICITUD"))
                {
                    ticket.Estado = Utils.getEstados().Find(est => est.Nombre.Equals("EN PROCESO"));
                    ticket.IdUsuarioAprobacion = "0";
                    trabajoNegocio.updateTicket(ticket);
                    alerta = (1, "Trabajo actualizado correctamente.");
                    Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
                }
                if (accion.Equals("DESCARTAR SOLICITUD"))
                {
                    ticket.Estado = Utils.getEstados().Find(est => est.Nombre.Equals("A ASIGNAR"));
                    ticket.Prestador = null;
                    ticket.Monto = 0;
                    ticket.Especialidad = "SIN ESPECIALIDAD";
                    ticket.ComentariosPrestador = "";
                    ticket.IdUsuarioAprobacion = "0";
                    trabajoNegocio.updateTicket(ticket);
                    alerta = (1, "Trabajo actualizado correctamente.");
                    Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
                }
                if (accion.Equals("ACEPTAR PEDIDO"))
                {
                    ticket.Estado = Utils.getEstados().Find(est => est.Nombre.Equals("EN PROCESO"));
                    ticket.IdUsuarioAprobacion = "0";
                    ticket.Monto = double.Parse(TextBoxMonto_Trabajo.Text);
                    ticket.ComentariosPrestador = TextBoxComentario_Proveedor.Text;
                    trabajoNegocio.updateTicket(ticket);
                    alerta = (1, "Trabajo actualizado correctamente.");
                    Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
                }
                if (accion.Equals("RECHAZAR PEDIDO"))
                {
                    ticket.Estado = Utils.getEstados().Find(est => est.Nombre.Equals("A ASIGNAR"));
                    ticket.Prestador = null;
                    ticket.Monto = 0;
                    ticket.ComentariosPrestador = "";
                    ticket.IdUsuarioAprobacion = "0";
                    ticket.Especialidad = usuario.Especialidad.Nombre;
                    trabajoNegocio.updateTicket(ticket);
                    alerta = (1, "Trabajo actualizado correctamente.");
                    Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
                }
                if (accion.Equals("PASAR REALIZADO"))
                {
                    ticket.IdUsuarioAprobacion = usuario.IdPersona;
                    trabajoNegocio.updateTicket(ticket);
                    alerta = (1, "Trabajo actualizado correctamente.");
                    Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
                }
                if (accion.Equals("CONFIRMAR REALIZADO"))
                {
                    ticket.Estado = Utils.getEstados().Find(est => est.Nombre.Equals("REALIZADO"));
                    ticket.FechaRealizado = DateTime.Now;
                    ticket.IdUsuarioAprobacion = "0";
                    trabajoNegocio.updateTicket(ticket);
                    alerta = (1, "Trabajo actualizado correctamente.");
                    Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
                }
                if (accion.Equals("CANCELAR TRABAJO"))
                {
                    ticket.Estado = Utils.getEstados().Find(est => est.Nombre.Equals("CANCELADO"));
                    ticket.IdUsuarioAprobacion = "0";
                    trabajoNegocio.updateTicket(ticket);
                    alerta = (1, "Trabajo actualizado correctamente.");
                    Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
                }

            }
            catch (Exception ex)
            {
                alerta = (2, "Ocurrió un error cambiando el estado.");
            }
        }

        protected void btnAgregar_Resenia(object sender, EventArgs e)
        {

        }

        protected void LinkProveedor_Click(object sender, EventArgs e)
        {
            Session["proveedorTemp"] = usuarioNegocio.getUsuario(ticket.Prestador.Id);
            Response.Redirect("DetalleProveedor.aspx", false);
        }

        protected void buttonGuardarResenia_Click(object sender, EventArgs e)
        {
            try
            {
                ticket.ComentarioResenia = textBoxResenia.Text;
                ticket.Calificacion = Convert.ToInt32(dropDownListPuntaje.SelectedValue);
                trabajoNegocio.registrarResenia(ticket);
                alerta = (1, "Reseña ingresada correctamente. ¡Muchas gracias!");
                Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
            }
            catch (Exception ex)
            {
                alerta = (2, ex.Message);
            }
        }


    }
}