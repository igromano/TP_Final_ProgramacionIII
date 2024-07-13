﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManoExperta.helpers;
using dominio;
using negocio;
using negocio.Utils;

namespace ManoExperta
{
    public partial class Detalle : System.Web.UI.Page
    {
        public int idTicket = 0;
        public string estadoActual;
        public Ticket ticket = new Ticket();
        public UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }

            if (Request.QueryString["idTicket"] == null)
            {
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                idTicket = Convert.ToInt32(Request.QueryString["idTicket"]);
                Usuario usuario = (Usuario)Session["usuario"];
                List<Ticket> tickets = (List<Ticket>)Session["tickets"];

                if(usuario.RolUsuario == RolUsuario.PRESTADOR)
                {
                    ticket = tickets.Find(tck => tck.Id == idTicket && tck.Prestador.IdPersona == usuario.IdPersona);
                }
                else
                {

                    ticket = tickets.Find(tck => tck.Id == idTicket && tck.Usuario.IdPersona == usuario.IdPersona);
                }

                if (ticket != null)
                {

                    Usuario usuarioCreador;
                    usuarioCreador = usuarioNegocio.getUsuario(ticket.Usuario.Id);
                    estadoActual = ticket.Estado.Nombre;
                    TextBoxNombre_Cliente.Text = ticket.Usuario.Nombre + " " + ticket.Usuario.Apellido;
                    TextBoxDireccion.Text = usuarioCreador.Domicilio; // cambiar cuando nacho lo agregue a la carga en getTicketsPorRol
                    List<Locacion> provinciasUnicas = Utils.getLocaciones().GroupBy(loc => new { loc.IdProvincia, loc.NombreProvincia }).Select(loc => loc.First()).ToList();
                    TextBoxProvincia.Text = Utils.getLocaciones().Find(loc => loc.Id == usuarioCreador.IdLocalidad).NombreProvincia;
                    TextBoxLocalidad.Text = Utils.getLocaciones().Find(loc => loc.Id == usuarioCreador.IdLocalidad).Nombre;
                    TextBoxFecha_Solicitado.Text = ticket.FechaSolicitado.ToShortDateString();
                    TextBoxComentario.Text = ticket.ComentariosUsuario;

                    if (ticket.Prestador != null)
                    {
                        estadoActual = ticket.Estado.Nombre;

                        TextBoxProveedor.Text = ticket.Prestador.Nombre + " " + ticket.Prestador.Apellido;
                        TextBoxFecha_Trabajo.Text = ticket.FechaRealizado.ToShortDateString();
                        TextBoxComentario_Proveedor.Text = ticket.ComentariosPrestador;
                        TextBoxCuil_Prov.Text = ticket.Prestador.IdPersona;
                        TextBoxMonto_Trabajo.Text = ticket.Monto.ToString();
                    }
                }
                else
                {
                    Response.Redirect("Error.aspx", false);
                }
            }

        }


        protected void btnAccionTrabajo(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                List<Ticket> tickets = (List<Ticket>)Session["tickets"];
                Ticket ticket = tickets.Find(x => x.Id == idTicket);

                if (ticket != null)
                {
                    string action = ((Button)sender).CommandArgument;
                    if (action == "cancelar")
                    {
                        trabajoNegocio.cambiarEstado(ticket.Id, 3);
                    }
                    else if (action == "finalizar")
                    {
                        trabajoNegocio.cambiarEstado(ticket.Id, 4);
                    }
                    Session["tickets"] = tickets;
                    Response.Redirect("MisServicios.aspx", false);
                }
                else
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregar_Resenia(object sender, EventArgs e)
        {

        }

        protected void LinkProveedor_Click(object sender, EventArgs e)
        {
            Session["proveedorTemp"] = usuarioNegocio.getUsuario(ticket.Prestador.Id);
            Response.Redirect("DetalleProveedor.aspx", false);
        }


        /*
        protected void btnCancelar_Trabajo(object sender, EventArgs e)
        {
            try
            {
              
                Usuario usuario = (Usuario)Session["usuario"];
               
                TrabajoNegocio trabajoNegocio = new TrabajoNegocio();
                
                List<Ticket> tickets = (List<Ticket>)Session["tickets"];
                
                Ticket ticket = tickets.Find(x => x.Id == idTicket);

                if (ticket != null)
                {    
                    
                    trabajoNegocio.cambiarEstado(ticket.Id, 3);               
                    Session["tickets"] = tickets;
                    Response.Redirect("MisServicios.aspx", false);                
                }
                else
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);
            }
        }
        
        
        protected void btnPasar_A_Finalizado(object sender, EventArgs e)
        {
            try
            {

                Usuario usuario = (Usuario)Session["usuario"];

                TrabajoNegocio trabajoNegocio = new TrabajoNegocio();

                List<Ticket> tickets = (List<Ticket>)Session["tickets"];

                Ticket ticket = tickets.Find(x => x.Id == idTicket);

                if (ticket != null)
                {
                    trabajoNegocio.cambiarEstado(ticket.Id, 4);
                    Session["tickets"] = tickets;
                    Response.Redirect("MisServicios.aspx", false);                }
                else
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);
            }
        }
        */



    }
}