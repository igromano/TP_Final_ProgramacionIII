using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using ManoExperta.Services;
using System.Drawing;

namespace ManoExperta
{

    public partial class login : System.Web.UI.Page
    {
                
        public bool accesoExitoso = true;
        public string error;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtPass.Text.Length > 0 && txtUser.Text.Length > 0)
                {
                    Usuario usuario = new UsuarioNegocio().login(new Usuario(txtUser.Text, txtPass.Text));
                    if (usuario != null)
                    {
                        Session.Add("usuario", usuario);
                        accesoExitoso = true;
                        Response.Redirect("Home.aspx", false);

                    }
                    else
                    {

                        accesoExitoso = false;
                        txtUser.Text = "";
                        txtPass.Text = "";
                    }
                }
                else
                {
                    txtPass.BorderColor = txtPass.Text.Length == 0 ? Color.Red : Color.Gray;
                    txtUser.BorderColor = txtUser.Text.Length == 0 ? Color.Red : Color.LightGray;

                    accesoExitoso = false;
                    error = "Debe ingresar un usuario y/o contraseña";
                }
            }catch (Exception ex)
            {
                txtPass.BorderColor = txtPass.Text.Length == 0 ? Color.Red : Color.LightGray;
                txtUser.BorderColor = txtUser.Text.Length == 0 ? Color.Red : Color.LightGray;
                accesoExitoso = false;
                txtUser.Text = "";
                txtPass.Text = "";
                error = ex.Message;
            }
        }

    }
}