using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace ManoExperta
{
    public partial class ListadoTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else {
                Usuario usuariotemp = new Usuario();
                usuariotemp = (Usuario)Session["usuario"];
                string nombre = usuariotemp.Nombre;
                if(usuariotemp.RolUsuario != RolUsuario.PRESTADOR)
                {
                    Response.Redirect("Home.aspx", false);
                }
            }


        }
    }
}