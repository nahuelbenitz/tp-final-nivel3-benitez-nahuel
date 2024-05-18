using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                UserNegocio negocio = new UserNegocio();
                User user = new User();
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

                int id = negocio.insertarNuevo(user);

                EmailService email = new EmailService();
                email.ArmarCorreo(user.Email,$"Bienvenido al Catalogo Web, {user.Nombre}!", "!Nos alegra que te hayas registrado! \nPronto te llegaran promociones exclusivas.");
                _ = email.EnviarEmailAsync();
                Session.Add("nombre", user.Nombre.ToString());

                Response.Redirect($"Bienvenida.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}