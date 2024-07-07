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
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("Error.aspx", false);
                }
                id = Request.QueryString["id"];
                usuarioTemp = usuarioNegocioTemp.getUsuario(int.Parse(id));
                ticketsTemp = trabajoNegocioTemp.getTicketsPorRol(usuarioTemp);
                if (!IsPostBack)
                {
                    ticketsTemp.RemoveAll(t => !t.Prestador.IdPersona.Equals(usuarioTemp.IdPersona));
                    trabajos = ticketsTemp.Count();
                    repListadoResenias.DataSource = ticketsTemp;
                    repListadoResenias.DataBind();
                }

            }



        }
    }
}