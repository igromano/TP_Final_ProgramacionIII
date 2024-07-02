﻿using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using ManoExperta.Services;

namespace ManoExperta
{

    public partial class login : System.Web.UI.Page
    {
        
        public bool accesoExitoso = true;
        public string error;

        //public bool accesoExitoso = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            getClientLocation();

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
                        Session.Add("usuario", usuario); // guardo el objeto usuario en sesion con la clave
                        accesoExitoso = true;
                        Response.Redirect("Home.aspx", false);
                    }
                    else
                    {
                        accesoExitoso = false;
                        txtUser.Text = "";
                        txtPass.Text = "";
                        error = "Los datos proporcionados son incorrectos";
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mifuncion", error);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mifuncion", "errorMsg()", true);
                        //}

                    }
                }
                else
                {
                    accesoExitoso = false;
                    error = "Debe ingresar un usuario y contraseña";
                }
            }catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar iniciar sesión.", ex);
            }
        }

        async private void getClientLocation()
        {
            ServiciosExternos service = new ServiciosExternos();
            Locacion locacion = await service.getLocacion();
        }
    }
}