using dominio;
using ManoExperta.helpers;
using negocio;
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
        public UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }

            if (!IsPostBack)
            {
                usuariotemp = (Usuario)Session["usuario"];
                if (usuariotemp.RolUsuario != RolUsuario.USUARIO)
                {
                    Response.Redirect("Home.aspx", false);
                }
                proveedores = usuarioNegocioTemp.getUsuariosPorRol(RolUsuario.PRESTADOR);
                repListadoProfesionales.DataSource = proveedores;
                repListadoProfesionales.DataBind();
            }



        }

        protected void buttonMasInformacion_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("DetalleProveedor.aspx?id=" + id, false);
        }

        protected void buttonSolicitarTrabajo_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("CargaTicket.aspx?tipo=2&proveedor=" + id, false);
        }
    }
}

