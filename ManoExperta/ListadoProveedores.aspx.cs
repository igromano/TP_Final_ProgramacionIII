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
    public partial class ListadoProveedores : System.Web.UI.Page
    {
        public Usuario usuariotemp = new Usuario();
        public List<Usuario> proveedores = new List<Usuario>();
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
                    if (usuariotemp.RolUsuario != RolUsuario.USUARIO)
                    {
                        Response.Redirect("Home.aspx", false);
                    }
                }
                repListadoProfesionales.DataSource = proveedores;
                repListadoProfesionales.DataBind();
            }


        }
    }
}