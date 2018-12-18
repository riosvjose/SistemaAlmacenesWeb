using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_ITEM_AdministrarItems : System.Web.UI.Page
    {
        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearItem.Visible = true;
            lblFormItem.Text = "Crear Item";
            pnEditarItem.Visible = false;
            pnBorrarItem.Visible = false;
        }

        protected void btnEditarItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearItem.Visible = false;
            lblFormEditarItem.Text = "Editar Item";
            pnEditarItem.Visible = true;
            pnBorrarItem.Visible = false;
        }

        protected void btnEliminarItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearItem.Visible = false;
            lblFormBorrarItem.Text = "Eliminar Item";
            pnEditarItem.Visible = false;
            pnBorrarItem.Visible = true;
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGuardarItem_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_ITEM_AdministrarItems.aspx");
        }

        protected void btnEditarGuardarItem_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarCancelarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_ITEM_AdministrarItems.aspx");
        }

        protected void btnBorrarItem_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarBorrarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_ITEM_AdministrarItems.aspx");
        }
        #endregion

    }
}