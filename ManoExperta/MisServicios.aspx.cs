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
    public partial class MisServicios : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public (int codigo, string mensaje) alerta;
        public List<Ticket> filtroTickets = new List<Ticket> ();
        public List<Ticket> tickets = new List<Ticket> ();
        TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }
            usuario = (Usuario)Session["usuario"];
            if (usuario.RolUsuario == RolUsuario.PRESTADOR)
            {
                if (usuario.Sexo.ToString().Equals("X") || usuario.Sexo.ToString().Equals("0"))
                {
                    alerta = (2, "Tus datos no están completos. Por favor, completá tus datos para poder tomar trabajos");
                }

            }

            if (!IsPostBack)
            {
                CargarDdlEstadosYEspecialidad();
                tickets = trabajoNegocio.getTicketsPorRol(usuario);
                Session.Add("tickets", tickets);
                repTrabajosActivos.DataSource = tickets.FindAll(t => t.Estado.Id == 2 || t.Estado.Id == 1 || t.Estado.Id == 5);
                repHistorialTrabajos.DataSource = tickets.FindAll(t => t.Estado.Id == 3 || t.Estado.Id == 4);
                repHistorialTrabajos.DataBind();
                repTrabajosActivos.DataBind();

            }

        }

        protected void TrabajosActivos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "MasInfo")
            {
                string idTicket = e.CommandArgument.ToString();
                Response.Redirect("Detalle.aspx?idTicket=" + idTicket, false);
            }
        }

        private void CargarDdlEstadosYEspecialidad()
        {

            ServicioNegocio servicioNegocio = new ServicioNegocio();
            ddlEstado.DataSource = Utils.getEstados();
            ddlEstado.DataTextField = "Nombre";
            ddlEstado.DataValueField = "Id";            
            ddlEstado.DataBind();
            DdlFiltro_Especialidad.DataSource = Utils.getEspecialidades();
            DdlFiltro_Especialidad.DataTextField = "Nombre";
            DdlFiltro_Especialidad.DataValueField = "Id";
            DdlFiltro_Especialidad.DataBind();


        }

        protected void filtro(object sender, EventArgs e)
        {
            filtroTickets = trabajoNegocio.getTicketsPorRol(usuario);
            if (ddlEstado.SelectedValue != "0")
            {
                filtroTickets.RemoveAll(tck => tck.Estado.Id != int.Parse(ddlEstado.SelectedValue));
            }
            if(DdlFiltro_Especialidad.SelectedValue != "0")
            {

            }
            repTrabajosActivos.DataSource = filtroTickets.FindAll(t => t.Estado.Id == 2 || t.Estado.Id == 1 || t.Estado.Id == 5);
            repHistorialTrabajos.DataSource = filtroTickets.FindAll(t => t.Estado.Id == 3 || t.Estado.Id == 4);
            repHistorialTrabajos.DataBind();
            repTrabajosActivos.DataBind();
        }

        protected void ButtonLimpiarFiltro_Click(object sender, EventArgs e)
        {
            tickets = (List<Ticket>)Session["tickets"];
            repTrabajosActivos.DataSource = tickets.FindAll(t => t.Estado.Id == 2 || t.Estado.Id == 1 || t.Estado.Id == 5);
            repHistorialTrabajos.DataSource = tickets.FindAll(t => t.Estado.Id == 3 || t.Estado.Id == 4);
            repHistorialTrabajos.DataBind();
            repTrabajosActivos.DataBind();
        }

        protected int evaluarUsuario(int idUsuarioAprobacion)
        {
            if(idUsuarioAprobacion != 0)
            {
                if(idUsuarioAprobacion == Convert.ToInt32(usuario.IdPersona))
                {
                    return 1;
                }
                return 2;
            }
            return 0;
        }
    }


}
