using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class Bienvenida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombre = Session["nombre"].ToString();

            lblMensaje.Text = $"Muchas gracias por registrarte, {nombre}.<br /> Ya podes comenzar a disfrutar del catalogo. A la brevedad te estara llegando un mail, por favor revisar la bandeja de spam.";
        }
    }
}