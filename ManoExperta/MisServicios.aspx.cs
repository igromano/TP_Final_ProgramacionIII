using dominio;
using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace ManoExperta
{
    public partial class MisServicios : System.Web.UI.Page
    {
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                usuario = (Usuario)Session["usuario"];
                if (!IsPostBack)
                {
                    TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                    List<Ticket> tickets = trabajoNegocio.getTicketsPorRol(usuario);
                    repTrabajosActivos.DataSource = tickets;
                    repHistorialTrabajos.DataSource = tickets;
                    repHistorialTrabajos.DataBind();
                    repTrabajosActivos.DataBind();
                    
                }
            }
        }
        
        protected void TrabajosActivos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "MasInfo")
            {
                // Obtén el IdTicket desde CommandArgument
                string idTicket = e.CommandArgument.ToString();
                Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
            }
        }
    }
}
