using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace ManoExperta
{
    public partial class ListadoTickets : System.Web.UI.Page
    {
        public Usuario usuariotemp = new Usuario();
        public TrabajoNegocio trabajoTemp = new TrabajoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    usuariotemp = (Usuario)Session["usuario"];
                    string nombre = usuariotemp.Nombre;
                    if (usuariotemp.RolUsuario != RolUsuario.PRESTADOR)
                    {
                        Response.Redirect("Home.aspx", false);
                    }

                    repTrabajosActivos.DataSource = trabajoTemp.getTicketsPorRol(usuariotemp);
                    repTrabajosActivos.DataBind();

                }
            }


        }

        protected void buttonMasInformacion_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?idTicket=" + id, false);
        }
    }
}