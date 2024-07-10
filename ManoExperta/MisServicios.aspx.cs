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
    public partial class MisServicios : System.Web.UI.Page
    {
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                usuario = (Usuario)Session["usuario"];
                if (!IsPostBack)
                {
                    CargarDdlEstadosYEspecialidad();
                    TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                    List<Ticket> tickets = trabajoNegocio.getTicketsPorRol(usuario);
                    Session.Add("tickets", tickets);
                    repTrabajosActivos.DataSource = tickets.FindAll(t => t.Estado.Id == 2 || t.Estado.Id == 1 || t.Estado.Id == 5);                   
                    repHistorialTrabajos.DataSource = tickets.FindAll(t => t.Estado.Id == 3 || t.Estado.Id == 4);
                    repHistorialTrabajos.DataBind();
                    repTrabajosActivos.DataBind();
                    
                }
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
            
            List<Especialidad> especialidades = servicioNegocio.getEspecialidades();
            List<Estado> estados = servicioNegocio.getEstados();
            ddlEstado.DataSource = estados;
            ddlEstado.DataTextField = "Nombre"; 
            ddlEstado.DataValueField = "Id";    
            ddlEstado.DataBind();                      
            DdlFiltro_Especialidad.DataSource = especialidades;
            DdlFiltro_Especialidad.DataTextField = "Nombre";
            DdlFiltro_Especialidad.DataValueField = "Id";
            DdlFiltro_Especialidad.DataBind();


        }





    }

    
}
