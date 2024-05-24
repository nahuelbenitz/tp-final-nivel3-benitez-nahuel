using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

            if (!(Page is Login || Page is Default || Page is Registro || Page is DetalleArticulo || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["user"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    User user = (User)Session["user"];
                    if (!string.IsNullOrEmpty(user.Nombre))
                        lblUser.Text = $"Hola, {user.Nombre}";
                    else
                        lblUser.Text = $"Hola, {user.Email}";

                    if (!string.IsNullOrEmpty(user.UrlImagen))
                        imgAvatar.ImageUrl = $"~/Images/{user.UrlImagen}";
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}