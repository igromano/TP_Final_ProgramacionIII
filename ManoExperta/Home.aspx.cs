using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public Usuario usuarioTemp = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == true)
            {
                usuarioTemp = (Usuario)Session["usuario"];

                if(usuarioTemp.RolUsuario == RolUsuario.PRESTADOR)
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

        protected void ButtonBuscarProfesional_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoProveedores.aspx", false);
        }
    }
}