using dominio;
using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            }
        }

        private void CargarTrabajosActivos()
        {           
            string idPrestador = Session["ID_Prestador"].ToString();

            TicketNegocio ticketNegocio = new TicketNegocio();
            List<Ticket> listaTickets = ticketNegocio.getTicketsPorPrestador(idPrestador);

            repTrabajosActivos.DataSource = listaTickets;
            repTrabajosActivos.DataBind();
        }
    }
}