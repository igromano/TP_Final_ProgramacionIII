using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using System.Web.Services.Description;
using negocio.Utils;

namespace ManoExperta
{
    public partial class ListadoTickets : System.Web.UI.Page
    {
        public Usuario usuariotemp = new Usuario();
        public TrabajoNegocio trabajoTemp = new TrabajoNegocio();
        public List<Ticket> ticketsTemp = new List<Ticket>();
        public List<Locacion> provinciasUnicas = new List<Locacion>();
        public List<Ticket> ticketsFiltro = new List<Ticket>();
        public Ticket ticketTemp = new Ticket();
        public int trabajosActivos = 0;
        public (int codigo, string mensaje) alerta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }

            if (!IsPostBack)
            {
                usuariotemp = (Usuario)Session["usuario"];
                string nombre = usuariotemp.Nombre;
                if (usuariotemp.RolUsuario != RolUsuario.PRESTADOR)
                {
                    Response.Redirect("Home.aspx", false);
                }

                ticketsTemp = trabajoTemp.getTicketsPorEstado(Utils.getEstados().Find(es => es.Nombre.Equals("A ASIGNAR")));
                Session["tickets"] = ticketsTemp;

                DropDownListLocalidadFiltro.DataSource = Utils.getLocaciones();
                DropDownListLocalidadFiltro.DataTextField = "Nombre";
                DropDownListLocalidadFiltro.DataValueField = "Id";
                DropDownListLocalidadFiltro.DataBind();
                DropDownListLocalidadFiltro.SelectedValue = usuariotemp.IdLocalidad.ToString();

                ticketsFiltro = new List<Ticket>(ticketsTemp);
                repTrabajosActivos.DataSource = ticketsFiltro.FindAll(tck => tck.IdLocalidad == usuariotemp.IdLocalidad);
                repTrabajosActivos.DataBind();

                provinciasUnicas = Utils.getLocaciones().GroupBy(loc => new { loc.IdProvincia, loc.NombreProvincia }).Select(loc => loc.First()).ToList();

                DropDownListProvinciaFiltro.DataSource = provinciasUnicas;
                DropDownListProvinciaFiltro.DataTextField = "NombreProvincia";
                DropDownListProvinciaFiltro.DataValueField = "IdProvincia";
                DropDownListProvinciaFiltro.DataBind();
                if (usuariotemp.Sexo.ToString().Equals("X"))
                {
                    alerta = (2, "Tus datos no están completos. Por favor, completá tus datos para poder tomar trabajos");
                }
            }
            else
            {

                ticketsTemp = (List<Ticket>)Session["tickets"];
                usuariotemp = (Usuario)Session["usuario"];
                if (usuariotemp.Sexo.ToString().Equals("X"))
                {
                    alerta = (2, "Tus datos no están completos. Por favor, completá tus datos para poder tomar trabajos");
                }
            }



        }

        protected void buttonMasInformacion_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?idTicket=" + id, false);
        }

        protected void filtro(object sender, EventArgs e)
        {
            ticketsFiltro = trabajoTemp.getTicketsPorEstado(Utils.getEstados().Find(est => est.Nombre.Equals("A ASIGNAR")));
            ticketsFiltro.RemoveAll(tck => !tck.Especialidad.Equals("SIN ESPECIALIDAD"));
            if (DropDownListLocalidadFiltro.SelectedValue != "0")
            {
                ticketsFiltro.RemoveAll(tck => tck.IdLocalidad != Utils.getLocaciones().Find(loc => loc.Id == tck.IdLocalidad).Id);
            }
            repTrabajosActivos.DataSource = ticketsFiltro;
            repTrabajosActivos.DataBind();
        }
        protected void DropDownListProvinciaFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

            ticketsFiltro = new List<Ticket>(ticketsTemp);

            string idSeleccionado = DropDownListProvinciaFiltro.SelectedValue;
            //ticketsFiltro.RemoveAll(tck => !tck..Equals(idSeleccionado));
            repTrabajosActivos.DataSource = ticketsFiltro;
            repTrabajosActivos.DataBind();
        }

        protected void DropDownListLocalidadFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ticketsFiltro = new List<Ticket>(ticketsTemp);
            repTrabajosActivos.DataSource = ticketsFiltro.FindAll(tck => tck.IdLocalidad == int.Parse(DropDownListLocalidadFiltro.SelectedValue));
            repTrabajosActivos.DataBind();
            trabajosActivos = repTrabajosActivos.Items.Count;
        }

        protected void buttonTomarTrabajo_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            try
            {
                ticketsTemp = (List<Ticket>)Session["tickets"];
                ticketTemp = ticketsTemp.Find(tck => tck.Id == id);
                ticketTemp.Prestador = usuariotemp;
                ticketTemp.Especialidad = usuariotemp.Especialidad.Nombre;
                ticketTemp.Estado = Utils.getEstados().Find(est => est.Nombre.Equals("SOLICITADO"));
                ticketTemp.IdUsuarioAprobacion = usuariotemp.IdPersona;
                trabajoTemp.updateTicket(ticketTemp);
            }
            catch (Exception ex)
            {
                alerta = (2, "Ocurrió un error al asignar el trabajo." + ex.ToString());
            }



        }
    }
}