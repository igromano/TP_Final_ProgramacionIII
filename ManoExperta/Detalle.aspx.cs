using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManoExperta.helpers;
using dominio;
using negocio;

namespace ManoExperta
{
    public partial class Detalle : System.Web.UI.Page
    {
        public int idTicket = 0;
        public string estadoActual;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (Request.QueryString["idTicket"] == null)
                {
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    idTicket = Convert.ToInt32(Request.QueryString["idTicket"]);

                    Usuario usuario = (Usuario)Session["usuario"];
                    //TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                    //List<Ticket> tickets = trabajoNegocio.getTicketsPorRol(usuario);
                    List<Ticket> tickets = (List<Ticket>)Session["tickets"];

                    Ticket ticket = tickets.Find(x => x.Id == idTicket);

                    if (ticket != null)
                    {
                        estadoActual = ticket.Estado.Nombre;

                        TextBoxNombre_Cliente.Text = ticket.Usuario.Nombre + " " + ticket.Usuario.Apellido;
                        TextBoxDireccion.Text = ticket.Usuario.Domicilio;
                        TextBoxFecha_Solicitado.Text = ticket.FechaSolicitado.ToShortDateString();
                        TextBoxComentario.Text = ticket.ComentariosUsuario;
                        TextBoxProveedor.Text = ticket.Prestador.Nombre + " " + ticket.Prestador.Apellido;
                        TextBoxDireccion_Prov.Text = ticket.Prestador.Domicilio;
                        TextBoxFecha_Trabajo.Text = ticket.FechaRealizado.ToShortDateString();
                        TextBoxComentario_Proveedor.Text = ticket.ComentariosPrestador;
                    }
                    else
                    {
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
        }


        protected void btnAccionTrabajo(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                List<Ticket> tickets = (List<Ticket>)Session["tickets"];
                Ticket ticket = tickets.Find(x => x.Id == idTicket);

                if (ticket != null)
                {
                    string action = ((Button)sender).CommandArgument;
                    if (action == "cancelar")
                    {
                        trabajoNegocio.cambiarEstado(ticket.Id, 3);                        
                    }
                    else if (action == "finalizar")
                    {
                        trabajoNegocio.cambiarEstado(ticket.Id, 4);                        
                    }
                    Session["tickets"] = tickets;
                    Response.Redirect("MisServicios.aspx", false);
                }
                else
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);
            }
        }
        /*
        protected void btnCancelar_Trabajo(object sender, EventArgs e)
        {
            try
            {
              
                Usuario usuario = (Usuario)Session["usuario"];
               
                TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                
                List<Ticket> tickets = (List<Ticket>)Session["tickets"];
                
                Ticket ticket = tickets.Find(x => x.Id == idTicket);

                if (ticket != null)
                {    
                    
                    trabajoNegocio.cambiarEstado(ticket.Id, 3);               
                    Session["tickets"] = tickets;
                    Response.Redirect("MisServicios.aspx", false);                
                }
                else
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);
            }
        }
        */
        /*
        protected void btnPasar_A_Finalizado(object sender, EventArgs e)
        {
            try
            {

                Usuario usuario = (Usuario)Session["usuario"];

                TrabajoNegocio trabajoNegocio = new TrabajoNegocio();

                List<Ticket> tickets = (List<Ticket>)Session["tickets"];

                Ticket ticket = tickets.Find(x => x.Id == idTicket);

                if (ticket != null)
                {
                    trabajoNegocio.cambiarEstado(ticket.Id, 4);
                    Session["tickets"] = tickets;
                    Response.Redirect("MisServicios.aspx", false);                }
                else
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);
            }
        }
        */
    }
}