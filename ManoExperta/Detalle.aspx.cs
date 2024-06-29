using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManoExperta.helpers;
using dominio;
using negocio;

namespace ManoExperta
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected string idTicket = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthServices.estaLogueado((Usuario)Session["usuario"]) == false)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (Request.QueryString["idTicket"] == null)
                {
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    idTicket = Request.QueryString["idTicket"];
                }
            }

        }
    }
}