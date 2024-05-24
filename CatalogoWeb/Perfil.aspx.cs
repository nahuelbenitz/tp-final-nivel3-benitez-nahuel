using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace CatalogoWeb
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["user"]))
                    {
                        User user = (User)Session["user"];

                        txtEmail.Text = user.Email;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if (!string.IsNullOrEmpty(user.UrlImagen))
                            imgNuevoPerfil.ImageUrl = $"~/Images/{user.UrlImagen}";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //escribir img
                UserNegocio negocio = new UserNegocio();
                User user = (User)Session["user"];

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs($"{ruta}perfil-{user.Id}.jpg");
                    user.UrlImagen = $"perfil-{user.Id}.jpg";
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                negocio.actualizar(user);

                //leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = $"~/Images/{user.UrlImagen}";


                if (!string.IsNullOrEmpty(user.UrlImagen))
                    imgNuevoPerfil.ImageUrl = $"~/Images/{user.UrlImagen}";
                lblGuardar.Text = "Se guardo correctamente";
                lblGuardar.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}