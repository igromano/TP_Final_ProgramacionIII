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
            modalOpciones = true;
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

            Usuario nuevoUsuario = new Usuario(userName, contrasenia);

            nuevoUsuario.Email = email;
            nuevoUsuario.UserName = userName;
            nuevoUsuario.Nombre = nombre;
            nuevoUsuario.RolUsuario = RolUsuario.USUARIO;


            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            bool registroExitoso = usuarioNegocio.registrarUsuario(nuevoUsuario);


            if (registroExitoso)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {

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

            Usuario nuevoProveedor = new Usuario(userName, contrasenia);

            nuevoProveedor.Email = email;
            nuevoProveedor.UserName = userName;
            nuevoProveedor.Nombre = nombre;
            nuevoProveedor.RolUsuario = RolUsuario.PRESTADOR;


            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            bool registroExitoso = usuarioNegocio.registrarUsuario(nuevoProveedor);

            
            if (registroExitoso)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {

            }
            
        }


        protected void pronvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}