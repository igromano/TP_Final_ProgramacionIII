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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                modalOpciones = false;

            }
            modalOpciones = true; // revisar, 
        }
        protected void CrearUsuario(object sender, EventArgs e)
        {
            creaUsuario = true;
            creaProveedor = false;
            modalOpciones = false;
           
            
        }

        protected void AltaUsuario(object sender, EventArgs e)
        {
            string nombre = TextBoxNombreUsuario.Text;
            string email = TextBoxEmailUsuario.Text;
            string userName = TextBoxUsuarioUsuario.Text;
            string contrasenia = TextBoxUsuarioContrasenia.Text;
            string dni = TextBoxDNI.Text;

            Usuario nuevoUsuario = new Usuario(userName, contrasenia); // instancia del objeto usuario

            nuevoUsuario.Email = email; // asigno los valores a las propiedades del obj usuario
            nuevoUsuario.UserName = userName;
            nuevoUsuario.Nombre = nombre;
            nuevoUsuario.IdPersona = dni;
            nuevoUsuario.RolUsuario = RolUsuario.USUARIO;


            UsuarioNegocio usuarioNegocio = new UsuarioNegocio(); // creo una instancia de usuarioNegocio
            bool registroExitoso = usuarioNegocio.registrarUsuario(nuevoUsuario); // llamada a metodo registrarUsuario(nacho)


            if (registroExitoso)
            {
                // mostrar un mensaje de registro exitoso
                Response.Redirect("Login.aspx");

            }
            else
            {
                // AGREGAR LBL EN EL FRONT

                //lblMensajeDeError.Text = "No se pudo registrar el usuario. Por favor, intente denuevo.";
                //lblMensajeError.Visible = true;
            }
        }

        protected void CrearProveedor(object sender, EventArgs e)
        {
            creaUsuario = false;
            creaProveedor = true;
            modalOpciones = false;          
        }

        protected void AltaProveedor(object sender, EventArgs e)
        {
            string nombre = TextBoxNombreProveedor.Text;
            string email = TextBoxEmailProveedor.Text;
            string userName = TextBoxUsuarioProveedor.Text;
            string contrasenia = TextBoxProveedorContrasenia.Text;
            string cuil = TextBoxCUIL.Text;

            Usuario nuevoProveedor = new Usuario(userName, contrasenia); // crea instancia de nuevo prov

            nuevoProveedor.Email = email;
            nuevoProveedor.UserName = userName;
            nuevoProveedor.Nombre = nombre;
            nuevoProveedor.IdPersona = cuil;
            nuevoProveedor.RolUsuario = RolUsuario.PRESTADOR;


            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            bool registroExitoso = usuarioNegocio.registrarUsuario(nuevoProveedor);


            if (registroExitoso)
            {
                // mostrar un mensaje de registro exitoso
                Response.Redirect("Login.aspx");
            }
            else
            {
                // AGREGAR ESTOS LBL EN EL FRONT

                //lblMensajeDeError.Text = "No se pudo registrar el usuario. Por favor, intente denuevo.";
                //lblMensajeError.Visible = true;
            }

        }


        protected void pronvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}