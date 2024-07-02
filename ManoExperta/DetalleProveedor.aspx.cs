using dominio;
using ManoExperta.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManoExperta
{
    public partial class DetalleProveedor : System.Web.UI.Page
    {
        public string id = "";
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
            }

        }
    }
}