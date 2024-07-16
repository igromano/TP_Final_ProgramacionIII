using dominio;
using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace ManoExperta
{
    public partial class CambiarContrasena : System.Web.UI.Page
    {
        public (int codigo, string mensaje) alerta;
        public Usuario usuarioTemp = new Usuario();
        public UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }
            usuarioTemp = (Usuario)Session["usuario"];
            if (usuarioTemp.Sexo.ToString().Equals("X") || usuarioTemp.Sexo.ToString().Equals("0"))
            {
                alerta = (2, "Tus datos no están completos. Por favor, completá tus datos para poder soliticar trabajos. Completá tus datos en Preferencias por favor.");
            }
            if (!IsPostBack)
            {

                TextBoxContrasenaActual.Text = "";
                TextBoxUsuarioContrasenia.Text = "";
                TextBoxUsuarioContraseniaConfirmar.Text = "";

            }
        }

        protected void activarBoton(object sender, EventArgs e)
        {
            btnActualizarContrasena.Enabled = true;
        }
        protected void btnActualizarContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TextBoxContrasenaActual.Text.Equals(usuarioTemp.Contrasenia))
                {
                    throw new Exception("Las contraseña actual no es correcta. Por favor intente nuevamente.");
                }
                if (!TextBoxUsuarioContrasenia.Text.Equals(TextBoxUsuarioContraseniaConfirmar.Text))
                {
                    throw new Exception("Las contraseñas no coinciden. Por favor, intente nuevamente.");
                }
                usuarioTemp.Contrasenia = TextBoxUsuarioContrasenia.Text;
                usuarioNegocioTemp.updateUsuario(usuarioTemp);
                alerta = (1, "Contraseña actualizada correctamente");


            }
            catch (Exception ex)
            {
                alerta = (2, ex.Message);

            }
        }
    }
}