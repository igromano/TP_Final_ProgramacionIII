using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace ManoExperta
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public Usuario usuarioTemp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                usuarioTemp = (Usuario)Session["usuario"];

            }
        }
    }
}