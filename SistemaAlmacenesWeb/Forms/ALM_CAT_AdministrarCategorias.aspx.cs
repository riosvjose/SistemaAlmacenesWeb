using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_CAT_AdministrarCategorias : System.Web.UI.Page
    {
        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlCategoriaItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearCategoria_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearCategoriaItem.Visible = true;
            lblFormCategoriaItem.Text = "Crear Categoría de Item";
            pnEditarCategoriaItem.Visible = false;
        }

        protected void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearCategoriaItem.Visible = false;
            lblEditarCategoriaItem.Text = "Editar Categoría de Item";
            pnEditarCategoriaItem.Visible = true;

        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGuardarCategoriaItem_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarCategoriaItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_CAT_AdministrarCategorias.aspx");
        }

        protected void btnEditarGuardarCategoriaItem_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarCancelarCategoriaItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_CAT_AdministrarCategorias.aspx");
        }
        #endregion

    }
}