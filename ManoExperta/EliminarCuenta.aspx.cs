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
        public Usuario usuarioTemp = new Usuario();
        public UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
        public (int codigo, string mensaje) alerta;
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
        }

        protected void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if(!TextBoxUsuarioUsuario.Text.ToLower().Equals(usuarioTemp.UserName.ToLower()))
                {
                    throw new Exception("El usuario ingresado no es correcto. Por favor, ingrese su usuario.");
                }
                if (!TextBoxUsuarioContrasenia.Text.Equals(usuarioTemp.Contrasenia))
                {
                    throw new Exception("La contraseña ingresada no es correcta.");
                }
                if (!TextBoxUsuarioContraseniaConfirmar.Text.Equals(TextBoxUsuarioContrasenia.Text))
                {
                    throw new Exception("Las contraseñas ingresadas no son iguales. Por favor, verifique que las contraseñas sean iguales.");
                }
                usuarioTemp.Activo = false;
                usuarioNegocioTemp.updateUsuario(usuarioTemp);
                Session.Remove("usuario");
                Response.Redirect("Index.aspx", false);
            }
            catch (Exception ex)
            {
                alerta = (2, ex.Message);
            }
        }
    }
}