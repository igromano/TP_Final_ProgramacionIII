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
        protected string idTicket = "";
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
                    int idTicket = Convert.ToInt32(Request.QueryString["idTicket"]);

                    Usuario usuario = (Usuario)Session["usuario"];
                    //TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                    //List<Ticket> tickets = trabajoNegocio.getTicketsPorRol(usuario);
                    List<Ticket> tickets = (List<Ticket>)Session["tickets"];

                    Ticket ticket = tickets.Find(x => x.Id == idTicket);

                    if (ticket != null)
                    {

                        lblNombre_Cliente.Text = "Solicitado por: " + ticket.Usuario.Nombre + " " + ticket.Usuario.Apellido;
                        //lblDireccion.Text = "Dirección: " + ticket.Usuario.Direccion;
                        lblFecha_Solicitado.Text = "Fecha solicitado: " + ticket.FechaSolicitado.ToShortDateString();
                        lblComentario.Text = "Comentario problema: " + ticket.ComentariosUsuario;
                        lblProveedor.Text = "Proveedor: " + ticket.Prestador.Nombre + " " + ticket.Prestador.Apellido;
                        //lblDireccionProv.Text = "Dirección: " + ticket.Prestador.Direccion;
                        lblFechaTrabajo.Text = "Fecha trabajo: " + ticket.FechaRealizado.ToShortDateString();
                        lblComentarioProveedor.Text = "Comentario proveedor: " + ticket.ComentariosPrestador;
                    }
                    else
                    {
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
        }
    }
}