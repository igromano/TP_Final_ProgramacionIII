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
    public partial class Preferencias : System.Web.UI.Page
    {
        public Usuario usuariotemp = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                usuariotemp = (Usuario)Session["usuario"];
                TextBoxUsuarioUsuario.Text = usuariotemp.UserName;
                TextBoxUsuarioContrasenia.Text = usuariotemp.Contrasenia;
                TextBoxNombreUsuario.Text = usuariotemp.Nombre;
                TextBoxApellidoUsuario.Text = usuariotemp.Apellido;
                TextBoxDireccionCalle.Text = usuariotemp.Domicilio;
                TextBoxDNI.Text = usuariotemp.IdPersona;
                TextBoxEmailUsuario.Text = (usuariotemp.Email).ToLower();
                TextBoxFechaNacimiento.Text = usuariotemp.FechaNacimiento.ToString("yyyy-MM-dd");
                
            }
        }
    }
}