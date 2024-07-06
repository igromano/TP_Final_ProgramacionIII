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
                TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                List<Ticket> tickets = trabajoNegocio.getTicketsPorRol(usuario);
                repTrabajosActivos.DataSource = tickets;
                repTrabajosActivos.DataBind();
            }
        }
    }
}
