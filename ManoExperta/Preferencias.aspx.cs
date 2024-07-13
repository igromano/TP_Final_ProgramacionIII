using dominio;
using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using negocio.Utils;

namespace ManoExperta
{
    public partial class Preferencias : System.Web.UI.Page
    {
        public Usuario usuariotemp = new Usuario();
        public UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
        public List<Locacion> provinciasUnicas = new List<Locacion>();
        public (int codigo, string mensaje) alerta;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }

            usuariotemp = (Usuario)Session["usuario"];
            if (!IsPostBack)
            {
                cargarDatos();

            }


        }

        public void cargarDatos()
        {
            DropDownListLocalidad.DataSource = Utils.getLocaciones();
            DropDownListLocalidad.DataTextField = "Nombre";
            DropDownListLocalidad.DataValueField = "Id";
            DropDownListLocalidad.DataBind();
            provinciasUnicas = Utils.getLocaciones().GroupBy(loc => new { loc.IdProvincia, loc.NombreProvincia }).Select(loc => loc.First()).ToList();
            DropDownListProvincia.DataSource = provinciasUnicas;
            DropDownListProvincia.DataTextField = "NombreProvincia";
            DropDownListProvincia.DataValueField = "IdProvincia";
            DropDownListProvincia.DataBind();
            DropDownListLocalidad.SelectedValue = usuariotemp.IdLocalidad.ToString();
            DropDownListProvincia.SelectedValue = usuariotemp.IdLocalidad == 0 ? "1" : Utils.getLocaciones().Find(loc => loc.Id == usuariotemp.IdLocalidad).IdProvincia.ToString();
            DropDownSexo.SelectedValue = usuariotemp.Sexo.ToString();
            TextBoxUsuarioUsuario.Text = usuariotemp.UserName;
            TextBoxNombreUsuario.Text = usuariotemp.Nombre;
            TextBoxApellidoUsuario.Text = usuariotemp.Apellido;
            TextBoxDireccionCalle.Text = usuariotemp.Domicilio;
            TextBoxDNI.Text = usuariotemp.IdPersona;
            TextBoxEmailUsuario.Text = (usuariotemp.Email).ToLower();
            TextBoxFechaNacimiento.Text = usuariotemp.FechaNacimiento.Year == 1900 ? "" : usuariotemp.FechaNacimiento.ToString("yyyy-MM-dd");
            TextBoxTelefono.Text = usuariotemp.Telefono;
            if (usuariotemp.RolUsuario == RolUsuario.PRESTADOR)
            {
                DropDownListEspecialidad.DataSource = Utils.getEspecialidades();
                DropDownListEspecialidad.DataTextField = "Nombre";
                DropDownListEspecialidad.DataValueField = "Id";
                DropDownListEspecialidad.DataBind();
                DropDownListEspecialidad.SelectedValue = usuariotemp.Especialidad.Id.ToString();
            }

            btnActualizarDatos.Enabled = false;
            btnDescartar.Enabled = false;
        }

        protected void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                usuariotemp = (Usuario)Session["usuario"];
                usuariotemp.Nombre = TextBoxNombreUsuario.Text;
                usuariotemp.Apellido = TextBoxApellidoUsuario.Text;
                usuariotemp.Sexo = char.Parse(DropDownSexo.SelectedValue);
                usuariotemp.Domicilio = TextBoxDireccionCalle.Text;
                usuariotemp.Telefono = TextBoxTelefono.Text;
                usuariotemp.Email = TextBoxEmailUsuario.Text;
                usuariotemp.FechaNacimiento = DateTime.Parse(TextBoxFechaNacimiento.Text);
                usuariotemp.IdLocalidad = int.Parse(DropDownListLocalidad.SelectedValue);
                usuariotemp.Especialidad.Id = Convert.ToInt32(DropDownListEspecialidad.SelectedValue);
                usuarioNegocioTemp.updateUsuario(usuariotemp);
                btnActualizarDatos.Enabled = false;
                btnDescartar.Enabled = false;
                Session["usuario"] = usuariotemp;
                alerta = (1, "Datos actualizados correctamente.");
                //Response.Redirect("Preferencias.aspx", false);


            }
            catch (Exception ex)
            {
                alerta = (2, "Ocurrió un error actualizando los datos. Por favor, intente nuevamente.");
                Session["error"] = ex.ToString();
                Response.Redirect("Preferencias.aspx", false);
                throw ex;
            }

        }
        protected void cambioDatos(object sender, EventArgs e)
        {
            btnActualizarDatos.Enabled = true;
            btnDescartar.Enabled = true;
        }
        protected void btnDescartar_Click(object sender, EventArgs e)
        {
            //usuariotemp = (Usuario)Session["usuario"];
            Response.Redirect("Preferencias.aspx", false);
            Session["alertaError"] = "Ocurrio un error!";
            cargarDatos();

        }

    }
}