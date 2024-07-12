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
        public UsuarioNegocio usuarioNegocioTemp = new UsuarioNegocio();
        public TrabajoNegocio trabajoNegocioTemp = new TrabajoNegocio();
        public List<Ticket> ticketsTemp = new List<Ticket>();
        public Usuario usuarioTemp = new Usuario();
        public int trabajos = 0;
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
            usuarioTemp = (Usuario)Session["proveedorTemp"];
            ticketsTemp = trabajoNegocioTemp.getTicketsPorRol(usuarioTemp);
            if (!IsPostBack)
            {
                ticketsTemp.RemoveAll(t => !t.Prestador.IdPersona.Equals(usuarioTemp.IdPersona));
                repListadoResenias.DataSource = ticketsTemp.FindAll(tck => (tck.FechaRealizado.Year != 1900 && (tck.Estado.Nombre.Equals("REALIZADO") || tck.Estado.Nombre.Equals("CANCELADO"))));
                trabajos = repListadoResenias.Items.Count;
                repListadoResenias.DataBind();
                textBoxDireccion.Text = usuarioTemp.Domicilio;
                textBoxLocalidad.Text = usuarioTemp.IdLocalidad.ToString();

            }





        }
    }
}