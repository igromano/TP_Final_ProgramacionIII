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
        public bool errorBool = false;
        public bool registroExitoso;
        public string error;
        protected void Page_Load(object sender, EventArgs e)
        {
            errorBool = false;
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
            string apellido = TextBoxApellidoUsuario.Text;
            string email = TextBoxEmailUsuario.Text;
            string userName = TextBoxUsuarioUsuario.Text;
            string contrasenia = TextBoxUsuarioContrasenia.Text;
            string contraseniaRepetir = TextBoxUsuarioContraseniaConfirmar.Text;
            string dni = TextBoxDNI.Text;

            if (!contrasenia.Equals(contraseniaRepetir))
            {
                errorBool = true;
                error = "Las contraseñas no son iguales";
                
            }

            Usuario nuevoUsuario = new Usuario(userName, contrasenia); // instancia del objeto usuario

            nuevoUsuario.Email = email; // asigno los valores a las propiedades del obj usuario
            nuevoUsuario.UserName = userName;
            nuevoUsuario.Nombre = nombre;
            nuevoUsuario.Apellido = apellido;
            nuevoUsuario.IdPersona = dni;
            nuevoUsuario.RolUsuario = RolUsuario.USUARIO;

            if (!errorBool)
            {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio(); // creo una instancia de usuarioNegocio
            registroExitoso = usuarioNegocio.registrarUsuario(nuevoUsuario); // llamada a metodo registrarUsuario(nacho)

            }



            if (registroExitoso)
            {
                // mostrar un mensaje de registro exitoso
                error = "";
                Response.Redirect("Login.aspx");

            }
            else
            {
                error = "Hubo un error en el registro";
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
            string apellido = TextBoxApellidoProveedor.Text;
            string email = TextBoxEmailProveedor.Text;
            string userName = TextBoxUsuarioProveedor.Text;
            string contrasenia = TextBoxProveedorContrasenia.Text;
            string contraseniaRepetida = TextBoxUsuarioContraseniaConfirmar.Text;
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
            catch (Exception ex)
            {
                throw ex;
            }




        }


        protected void pronvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}