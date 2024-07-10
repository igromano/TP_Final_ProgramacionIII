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
    public partial class Preferencias : System.Web.UI.Page
    {
        public Usuario usuariotemp = new Usuario();
        public UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
        public ServicioNegocio servicioNegocioTemp = new ServicioNegocio();
        public List<Locacion> locacionTemp = new List<Locacion>();
        public List<Locacion> provinciasUnicas = new List<Locacion>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }

            usuariotemp = (Usuario)Session["usuario"];
            if (!IsPostBack)
            {
                locacionTemp = servicioNegocioTemp.getLocaciones();
                DropDownListLocalidad.DataSource = locacionTemp;
                DropDownListLocalidad.DataTextField = "Nombre";
                DropDownListLocalidad.DataValueField = "Id";
                DropDownListLocalidad.DataBind();
                provinciasUnicas = locacionTemp.GroupBy(loc => new { loc.IdProvincia, loc.NombreProvincia }).Select(loc => loc.First()).ToList();
                DropDownListProvincia.DataSource = provinciasUnicas;
                DropDownListProvincia.DataTextField = "NombreProvincia";
                DropDownListProvincia.DataValueField = "IdProvincia";
                DropDownListProvincia.DataBind();
                DropDownListLocalidad.SelectedValue = usuariotemp.IdLocalidad.ToString();
                DropDownListProvincia.SelectedValue = locacionTemp.Find(loc => loc.Id == usuariotemp.IdLocalidad) == null ? "0" : locacionTemp.Find(loc => loc.Id == usuariotemp.IdLocalidad).IdProvincia.ToString();
                TextBoxUsuarioUsuario.Text = usuariotemp.UserName;
                TextBoxNombreUsuario.Text = usuariotemp.Nombre;
                TextBoxApellidoUsuario.Text = usuariotemp.Apellido;
                TextBoxDireccionCalle.Text = usuariotemp.Domicilio;
                TextBoxDNI.Text = usuariotemp.IdPersona;
                TextBoxEmailUsuario.Text = (usuariotemp.Email).ToLower();
                TextBoxFechaNacimiento.Text = usuariotemp.FechaNacimiento.ToString("yyyy-MM-dd");
                TextBoxTelefono.Text = usuariotemp.Telefono;

            }

        }

        public void cargarDatos()
        {
            locacionTemp = servicioNegocioTemp.getLocaciones();
            DropDownListLocalidad.DataSource = locacionTemp;
            DropDownListLocalidad.DataTextField = "Nombre";
            DropDownListLocalidad.DataValueField = "Id";
            DropDownListLocalidad.DataBind();
            provinciasUnicas = locacionTemp.GroupBy(loc => new { loc.IdProvincia, loc.NombreProvincia }).Select(loc => loc.First()).ToList();
            DropDownListProvincia.DataSource = provinciasUnicas;
            DropDownListProvincia.DataTextField = "NombreProvincia";
            DropDownListProvincia.DataValueField = "IdProvincia";
            DropDownListProvincia.DataBind();
            DropDownListLocalidad.SelectedValue = usuariotemp.IdLocalidad.ToString();
            DropDownListProvincia.SelectedValue = locacionTemp.Find(loc => loc.Id == usuariotemp.IdLocalidad).IdProvincia.ToString();
            TextBoxUsuarioUsuario.Text = usuariotemp.UserName;
            TextBoxNombreUsuario.Text = usuariotemp.Nombre;
            TextBoxApellidoUsuario.Text = usuariotemp.Apellido;
            TextBoxDireccionCalle.Text = usuariotemp.Domicilio;
            TextBoxDNI.Text = usuariotemp.IdPersona;
            TextBoxEmailUsuario.Text = (usuariotemp.Email).ToLower();
            TextBoxFechaNacimiento.Text = usuariotemp.FechaNacimiento.ToString("yyyy-MM-dd");
            TextBoxTelefono.Text = usuariotemp.Telefono;
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
                //usuariotemp.Sexo =
                usuariotemp.Domicilio = TextBoxDireccionCalle.Text;
                usuariotemp.Telefono = TextBoxTelefono.Text;
                usuariotemp.Email = TextBoxEmailUsuario.Text;
                usuariotemp.FechaNacimiento = DateTime.Parse(TextBoxFechaNacimiento.Text);
                usuariotemp.IdLocalidad = int.Parse(DropDownListLocalidad.SelectedValue);
                usuarioNegocioTemp.updateUsuario(usuariotemp);
                btnActualizarDatos.Enabled = false;
                btnDescartar.Enabled = false;
                Session["usuario"] = usuariotemp;
                Session["alertaOK"] = "Datos actualizados correctamente";
                Response.Redirect("Preferencias.aspx", false);


            }
            catch (Exception ex)
            {
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
            usuariotemp = (Usuario)Session["usuario"];
            Session["alertaError"] = "Ocurrio un error!";
            cargarDatos();

        }

    }
}