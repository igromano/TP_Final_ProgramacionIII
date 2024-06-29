using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using ManoExperta.helpers;
using negocio;
namespace ManoExperta
{ 
    public partial class Home : System.Web.UI.Page
    {
        public bool userLoggeado = false;
        public Usuario usuarioTemp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == true)
            {
                Usuario usuarioptemp = new Usuario();
                usuarioptemp = (Usuario)Session["usuario"];

                if(usuarioptemp.RolUsuario == RolUsuario.PRESTADOR)
                {
                    Response.Redirect("MisServicios.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void ButtonProblema_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargaTicket.aspx?tipo=1", false);
        }
    }
}