using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManoExperta
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected bool creaUsuario;
        protected bool creaProveedor;
        protected bool modalOpciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                modalOpciones = false;

            }
            modalOpciones = true;
        }
        protected void CrearUsuario(object sender, EventArgs e)
        {
            creaUsuario = true;
            creaProveedor = false;
            modalOpciones = false;
        }
        protected void CrearProveedor(object sender, EventArgs e)
        {
            creaUsuario = false;
            creaProveedor = true;
            modalOpciones = false;
        }

        protected void pronvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}