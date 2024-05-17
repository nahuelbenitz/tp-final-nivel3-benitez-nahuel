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
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtUrlImagen.Enabled = false;
            ddlCategoria.Enabled = false;
            ddlMarca.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Marca> marcas = marcaNegocio.listar();
                    List<Categoria> categorias = categoriaNegocio.listar();

                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                    ddlCategoria.DataSource = categorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listar(id))[0];

                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtPrecio.Text = seleccionado.Precio.ToString("0.00"); //Validar que sea solo numeros
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.UrlImagen;

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    txtUrlImagen_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }
    }
}