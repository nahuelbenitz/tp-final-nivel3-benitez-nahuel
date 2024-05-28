using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace CatalogoWeb
{
    public partial class ListadoArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                Session.Add("error", "Se requieren permisos de admin para acceder a esta pantalla.");
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listadoArticulo", negocio.listar());
                dgvArticulos.DataSource = Session["listadoArticulo"];
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect($"FormularioArticulo.aspx?id={id}");
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.DataSource = Session["listadoArticulo"];
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listadoArticulo"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar.Enabled = !chkAvanzado.Checked;
            if (!chkAvanzado.Checked)
            {
                ddlCampo.SelectedIndex = 0;
                ddlCampo_SelectedIndexChanged(sender, e);
                dgvArticulos.DataSource = Session["listadoArticulo"];
                dgvArticulos.DataBind();
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                txtFiltroAvanzado.Text = "";
            }
            else if (ddlCampo.SelectedItem.ToString() != "")
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                txtFiltroAvanzado.Text = "";
            }
            else
            {
                ddlCriterio.Items.Clear();
                txtFiltroAvanzado.Text = "";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                if (ddlCampo.SelectedItem.ToString() == "")
                    dgvArticulos.DataSource = Session["listadoArticulo"];
                else
                    dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                                                              ddlCriterio.SelectedItem.ToString(),
                                                              txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddlCampo.SelectedIndex = 0;
            ddlCampo_SelectedIndexChanged(sender, e);
            dgvArticulos.DataSource = Session["listadoArticulo"];
            dgvArticulos.DataBind();
        }
    }
}