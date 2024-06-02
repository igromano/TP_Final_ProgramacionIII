using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManoExperta
{
    public partial class login : System.Web.UI.Page
    {

        public bool accesoExitoso = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
                string error = "<script type = 'text/javascript'>alert('Error en acceder a la aplicación!')</script>";
                if (accesoExitoso)
                {
                    //hacer redirect al home
                }
                else
                {
                    accesoExitoso = true;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mifuncion", error);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mifuncion", "errorMsg()", true);
                }
            //Session.Add("clientIp", Request.ServerVariables["REMOTE_ADDR"]);
        }
    }
}