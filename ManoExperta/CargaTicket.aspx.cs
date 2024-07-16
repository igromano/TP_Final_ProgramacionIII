using dominio;
using ManoExperta.helpers;
using negocio;
using negocio.Utils;
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
        public (int codigo, string mensaje) alerta;
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
                Response.Redirect("Login.aspx", true);
            }

            if (Request.QueryString["tipo"] == null)
            {
                Response.Redirect("Error.aspx", true);
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
            {

                usuarioTemp = (Usuario)Session["usuario"];
                if (idTipo.Equals("1"))
                {


                    TextBoxUsuarioSolicitante.Text = usuarioTemp.UserName;
                    TextBoxNombreApellidoSolicitante.Text = usuarioTemp.Nombre + " " + usuarioTemp.Apellido;
                    TextBoxEmailSolicitante.Text = usuarioTemp.Email;
                    TextBoxFechaSolicitud.Text = DateTime.Now.ToString();
                    TextBoxCalleAltura.Text = usuarioTemp.Domicilio;
                    TextBoxLocalidad.Text = usuarioTemp.IdLocalidad == 0 ? "" : Utils.getLocaciones().Find(loc => loc.Id == usuarioTemp.IdLocalidad).Nombre;
                    TextBoxProvincia.Text = usuarioTemp.IdLocalidad == 0 ? "" : Utils.getLocaciones().Find(loc => loc.Id == usuarioTemp.IdLocalidad).NombreProvincia;
                }
                else
                {
                    idProveedor = Request.QueryString["proveedor"];
                    TextBoxUsuarioSolicitante.Text = usuarioTemp.UserName;
                    TextBoxNombreApellidoSolicitante.Text = usuarioTemp.Nombre + " " + usuarioTemp.Apellido;
                    TextBoxEmailSolicitante.Text = usuarioTemp.Email;
                    TextBoxFechaSolicitud.Text = DateTime.Now.ToString();
                    TextBoxCalleAltura.Text = usuarioTemp.Domicilio;
                    usuarioProveedor = usuarioNegocioTemp.getUsuario(int.Parse(idProveedor));
                    TextBoxProveedor.Text = usuarioProveedor.Nombre + " " + usuarioProveedor.Apellido;
                    TextBoxLocalidad.Text = usuarioTemp.IdLocalidad == 0 ? "" : Utils.getLocaciones().Find(loc => loc.Id == usuarioTemp.IdLocalidad).Nombre;
                    TextBoxProvincia.Text = usuarioTemp.IdLocalidad == 0 ? "" : Utils.getLocaciones().Find(loc => loc.Id == usuarioTemp.IdLocalidad).NombreProvincia;

                }
            }

        }
        protected void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }

        protected void btnCargarPedido_Click(object sender, EventArgs e)
        {
            try
            {

                if (usuarioProveedor.IdPersona != null)
                {
                    trabajoNegocioTemp.registrarTrabajo(usuarioTemp.IdPersona.ToString(), 0, Utils.getEstados().Find(es => es.Nombre.Equals("SOLICITADO")).Id, TextBoxProblema.Text, usuarioProveedor.IdPersona.ToString(), usuarioProveedor.Especialidad.Id, Convert.ToInt32(usuarioTemp.IdPersona));
                }
                else
                {
                    trabajoNegocioTemp.registrarTrabajo(usuarioTemp.IdPersona.ToString(), 0, Utils.getEstados().Find(es => es.Nombre.Equals("A ASIGNAR")).Id, TextBoxProblema.Text);

                }
                TextBoxProblema.Text = "";

                alerta = (1, "Ticket ingresado correctamente");
            }
            catch(Exception ex)
            {
                alerta = (2, "Ocurrió un error cargando el ticket. Intenta nuevamente por favor.");
            }
        }
    }
}