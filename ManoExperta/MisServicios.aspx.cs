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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {   
                string idUsuario = Session["usuario"].ToString();
                TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                List<Ticket> tickets = trabajoNegocio.getTicketsPorPrestador(idUsuario);
                repTrabajosActivos.DataSource = tickets;
                repTrabajosActivos.DataBind();
            }
        }
    }

    }
}