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
    public partial class CargaTicket : System.Web.UI.Page
    {
        protected string idTipo = "";
        protected string idProveedor = "";
        public Usuario usuarioTemp = new Usuario();
        protected UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
        public Usuario usuarioProveedor = new Usuario();
        public TrabajoNegocio trabajoNegocioTemp = new TrabajoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (Request.QueryString["tipo"] == null)
                {
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    idTipo = Request.QueryString["tipo"];

                }
                if (Request.QueryString["proveedor"] == null && idTipo.Equals("2"))
                {
                    Response.Redirect("Error.aspx", false);
                }
                else
                if (idTipo.Equals("1"))
                {
                    usuarioTemp = (Usuario)Session["usuario"];
                    TextBoxUsuarioSolicitante.Text = usuarioTemp.UserName;
                    TextBoxNombreApellidoSolicitante.Text = usuarioTemp.Nombre + " " + usuarioTemp.Apellido;
                    TextBoxEmailSolicitante.Text = usuarioTemp.Email;
                    TextBoxFechaSolicitud.Text = DateTime.Now.ToString();
                    TextBoxCalleAltura.Text = usuarioTemp.Domicilio;
                }
                else
                {
                    idProveedor = Request.QueryString["proveedor"];
                    //usuarioProveedor = usuarioNegocioTemp.getPrestador(int.Parse(idProveedor));
                    TextBoxProveedor.Text = usuarioProveedor.Nombre + " " + usuarioProveedor.Apellido;

                }
            }
        }
        protected void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }

        protected void btnCargarPedido_Click(object sender, EventArgs e)
        {
           // trabajoNegocioTemp.registrarTrabajo(usuarioTemp.IdPersona.ToString(),0,0,5,TextBoxProblema.Text);
        }
    }
}