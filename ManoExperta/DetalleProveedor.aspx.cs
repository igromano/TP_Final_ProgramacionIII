using dominio;
using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using negocio.Utils;

namespace ManoExperta
{
    public partial class DetalleProveedor : System.Web.UI.Page
    {
        public string id = "";
        public int calificacion;
        public UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
        public TrabajoNegocio trabajoNegocioTemp = new TrabajoNegocio();
        public List<Ticket> ticketsTemp = new List<Ticket>();
        public Usuario usuarioTemp = new Usuario();
        public Usuario usuario = new Usuario();
        public int trabajos;
        public (int codigo, string mensaje) alerta;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", true);
            }

            if (Session["proveedorTemp"] == null)
            {
                Response.Redirect("Error.aspx", false);
            }
            //id = Request.QueryString["id"];
            //usuarioTemp = usuarioNegocioTemp.getUsuario(int.Parse(id));
            usuarioTemp = usuarioNegocioTemp.getUsuariosPorRol(RolUsuario.PRESTADOR).Find(user => user.Id == ((Usuario)Session["proveedorTemp"]).Id);
            ticketsTemp = trabajoNegocioTemp.getTicketsPorRol(usuarioTemp);
            usuario = (Usuario)Session["usuario"];
            if (!IsPostBack)
            {
                if (usuario.Sexo.ToString().Equals("X") || usuario.Sexo.ToString().Equals("0"))
                {
                    alerta = (2, "Tus datos no están completos. Por favor, completá tus datos para poder soliticar trabajos. Completá tus datos en Preferencias por favor.");
                }
                ticketsTemp.RemoveAll(t => !t.Prestador.IdPersona.Equals(usuarioTemp.IdPersona));
                trabajos = ticketsTemp.FindAll(tck => (tck.FechaRealizado.Year != 1900 && (tck.Estado.Nombre.Equals("REALIZADO") || tck.Estado.Nombre.Equals("CANCELADO")))).Count;
                repListadoResenias.DataSource = ticketsTemp.FindAll(tck => (tck.FechaRealizado.Year != 1900 && tck.Calificacion > 0 && (tck.Estado.Nombre.Equals("REALIZADO") || tck.Estado.Nombre.Equals("CANCELADO"))));
                repListadoResenias.DataBind();
                textBoxDireccion.Text = usuarioTemp.Domicilio;
                textBoxLocalidad.Text = Utils.getLocaciones().Find(loc => loc.Id == Convert.ToInt32(usuarioTemp.IdLocalidad)).Nombre;
                textBoxProvincia.Text = Utils.getLocaciones().Find(loc => loc.Id == Convert.ToInt32(usuarioTemp.IdLocalidad)).NombreProvincia;
                textBoxEspecialidad.Text = usuarioTemp.Especialidad.Nombre;
                textBoxEmail.Text = usuarioTemp.Email;
                textBoxPrestadorDesde.Text = usuarioTemp.FechaAlta.ToString("yyyy-MM-dd");

            }





        }

        protected void buttonSolicitarTrabajo_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("CargaTicket.aspx?tipo=2&proveedor=" + usuarioTemp.Id, false);
        }
    }
}