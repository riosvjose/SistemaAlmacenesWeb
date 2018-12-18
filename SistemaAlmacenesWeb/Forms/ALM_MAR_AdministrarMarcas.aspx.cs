using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_MAR_AdministrarMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearMarca_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearMarca.Visible = true;
            lblFormMarca.Text = "Crear Marca";
            pnEditarMarca.Visible = false;
        }

        protected void btnEditarMarca_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearMarca.Visible = false;
            lblEditarMarca.Text = "Editar Marca";
            pnEditarMarca.Visible = true;
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGuardarMarca_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_MAR_AdministrarMarcas.aspx");
        }

        protected void tbEditarNombreMarca_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditarCancelarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_MAR_AdministrarMarcas.aspx");
        }
    }
}