using dominio;
using ManoExperta.helpers;
using negocio;
using negocio.Utils;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManoExperta
{
    public partial class ListadoProveedores : System.Web.UI.Page
    {
        public Usuario usuariotemp = new Usuario();
        public List<Usuario> proveedores = new List<Usuario>();
        public List<Usuario> proveedoresFiltrados = new List<Usuario>();
        public UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }

            if (!IsPostBack)
            {
                usuariotemp = (Usuario)Session["usuario"];
                if (usuariotemp.RolUsuario != RolUsuario.USUARIO)
                {
                    Response.Redirect("Home.aspx", false);
                }
                proveedores = usuarioNegocioTemp.getUsuariosPorRol(RolUsuario.PRESTADOR);
                Session.Add("proveedores", proveedores);
                Session.Add("proveedoresFiltrados", proveedores);
                repListadoProfesionales.DataSource = Session["proveedoresFiltrados"];
                repListadoProfesionales.DataBind();
                DropDownListLocalidadFiltro.DataSource = Utils.getLocaciones();
                DropDownListLocalidadFiltro.DataTextField = "Nombre";
                DropDownListLocalidadFiltro.DataValueField = "Id";
                DropDownListLocalidadFiltro.DataBind();
                DropDownListProvinciaFiltro.DataSource = Utils.getLocaciones().GroupBy(loc => new { loc.IdProvincia, loc.NombreProvincia }).Select(loc => loc.First()).ToList();
                DropDownListProvinciaFiltro.DataTextField = "NombreProvincia";
                DropDownListProvinciaFiltro.DataValueField = "IdProvincia";
                DropDownListProvinciaFiltro.DataBind();
                DropDownListaEspecialidadFiltro.DataSource = Utils.getEspecialidades();
                DropDownListaEspecialidadFiltro.DataTextField = "Nombre";
                DropDownListaEspecialidadFiltro.DataValueField = "Id";
                DropDownListaEspecialidadFiltro.DataBind();
            }



        }

        protected void buttonMasInformacion_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            proveedores = (List<Usuario>)Session["proveedores"];
            Session.Add("proveedorTemp", proveedores.Find(prov => prov.Id == id));
            Response.Redirect("DetalleProveedor.aspx", false);
            //Response.Redirect("DetalleProveedor.aspx?id=" + id, false);
        }

        protected void buttonSolicitarTrabajo_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("CargaTicket.aspx?tipo=2&proveedor=" + id, false);
        }

        protected void DropDownListaEspecialidadFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            proveedoresFiltrados.RemoveAll(prov => prov.Especialidad.Id != int.Parse(DropDownListaEspecialidadFiltro.SelectedValue));
            repListadoProfesionales.DataSource = Session["proveedoresFiltrados"];
            repListadoProfesionales.DataBind();
        }

        protected void DropDownListProvinciaFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            repListadoProfesionales.DataSource = Session["proveedoresFiltrados"];
            repListadoProfesionales.DataBind();
        }

        protected void DropDownListLocalidadFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            proveedoresFiltrados = (List<Usuario>)Session["proveedoresFiltrados"];
            proveedoresFiltrados.RemoveAll(prov => prov.IdLocalidad != int.Parse(DropDownListLocalidadFiltro.SelectedValue.ToString()));
            Session["proveedoresFiltrados"] = proveedoresFiltrados;
            cargarRepeater();



        }

        protected void buttonLimpiarFiltro_Click(object sender, EventArgs e)
        {
            Session["proveedoresFiltrados"] = proveedores;
            cargarRepeater();
        }

        protected void cargarRepeater()
        {
            repListadoProfesionales.DataSource = (List<Usuario>)Session["proveedores"];
            repListadoProfesionales.DataBind();
        }
    }
}

