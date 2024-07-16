using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManoExperta
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected bool creaUsuario;
        protected bool creaProveedor;
        protected bool modalOpciones;
        public bool registroExitoso = true;
        public (int codigo, string mensaje) alerta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                modalOpciones = true;
                Session["crear"] = "";
            }
            else
            {
                modalOpciones = false;
            }
        }
        protected void CrearUsuario(object sender, EventArgs e)
        {
            creaUsuario = true;
            Session["crear"] = "usuario";
            creaProveedor = false;
            modalOpciones = false;


        }

        protected void AltaUsuario(object sender, EventArgs e)
        {
            string nombre = TextBoxNombreUsuario.Text;
            string apellido = TextBoxApellidoUsuario.Text;
            string email = TextBoxEmailUsuario.Text;
            string userName = TextBoxUsuarioUsuario.Text;
            string contrasenia = TextBoxUsuarioContrasenia.Text;
            string contraseniaRepetir = TextBoxUsuarioContraseniaConfirmar.Text;
            string dni = TextBoxDNI.Text;





            Usuario nuevoUsuario = new Usuario(userName, contrasenia); // instancia del objeto usuario
            nuevoUsuario.Email = email; // asigno los valores a las propiedades del obj usuario
            nuevoUsuario.UserName = userName;
            nuevoUsuario.Nombre = nombre;
            nuevoUsuario.Apellido = apellido;
            nuevoUsuario.IdPersona = dni;
            nuevoUsuario.RolUsuario = RolUsuario.USUARIO;

            try
            {
                if (!contrasenia.Equals(contraseniaRepetir))
                {
                    throw new Exception("Las contraseñas no son iguales.");

                }
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio(); // creo una instancia de usuarioNegocio
                registroExitoso = usuarioNegocio.registrarUsuario(nuevoUsuario); // llamada a metodo registrarUsuario(nacho)
                if (registroExitoso)
                {
                    // mostrar un mensaje de registro exitoso
                    Session.Add("usuario", usuarioNegocio.login(nuevoUsuario));
                    Response.Redirect("Home.aspx");

                }
                else
                {
                    alerta = (2, "Hubo un error en el registro");
                }
            }
            catch (Exception ex)
            {
                registroExitoso = false;
                alerta = (2, ex.Message);
                Session["error"] = ex.Message;
            }





        }

        protected void CrearProveedor(object sender, EventArgs e)
        {
            creaUsuario = false;

            creaProveedor = true;
            Session["crear"] = "proveedor";
            modalOpciones = false;
        }

        protected void AltaProveedor(object sender, EventArgs e)
        {
            string nombre = TextBoxNombreProveedor.Text;
            string apellido = TextBoxApellidoProveedor.Text;
            string email = TextBoxEmailProveedor.Text;
            string userName = TextBoxUsuarioProveedor.Text;
            string contrasenia = TextBoxProveedorContrasenia.Text;
            string contraseniaRepetir = TextBoxProveedorContraseniaConfirmar.Text;
            string cuil = TextBoxCUIL.Text;

            Usuario nuevoProveedor = new Usuario(userName, contrasenia); // crea instancia de nuevo prov

            nuevoProveedor.Email = email;
            nuevoProveedor.UserName = userName;
            nuevoProveedor.Nombre = nombre;
            nuevoProveedor.Apellido = apellido;
            nuevoProveedor.IdPersona = cuil;
            nuevoProveedor.RolUsuario = RolUsuario.PRESTADOR;

            try
            {
                if (!contrasenia.Equals(contraseniaRepetir))
                {
                    throw new Exception("Las contraseñas no son iguales.");

                }
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                bool registroExitoso = usuarioNegocio.registrarUsuario(nuevoProveedor);
                if (registroExitoso)
                {
                    Session.Add("usuario", usuarioNegocio.login(nuevoProveedor));
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    throw new Exception("No se pudo registrar al usuario. Por favor intente nuevamente.");
                }

            }
            catch (Exception ex)
            {
                registroExitoso = false;
                alerta = (2, ex.Message);
                Session["error"] = "Hubo un error en el registro...";
            }




        }
    }
}