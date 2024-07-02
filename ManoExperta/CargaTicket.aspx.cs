using dominio;
using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManoExperta
{
    public partial class CargaTicket : System.Web.UI.Page
    {
        protected string idTipo = "";
        protected string idProveedor = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if(Request.QueryString["tipo"] == null)
                {
                    Response.Redirect("Error.aspx", false);
                }
                idTipo = Request.QueryString["tipo"];
                if (Request.QueryString["proveedor"] == null && idTipo.Equals("2"))
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}