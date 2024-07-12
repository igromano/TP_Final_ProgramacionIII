using dominio;
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
    public partial class EliminarCuenta : System.Web.UI.Page
    {
        public string error = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }
            
        }

        protected void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            Usuario usuarioTemp = new Usuario();
            UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
            usuarioTemp = (Usuario)Session["usuario"];
            usuarioTemp.Activo = false;
            usuarioNegocioTemp.updateUsuario(usuarioTemp);
            Session.Remove("usuario");
            Response.Redirect("Index.aspx", false);
        }
    }
}