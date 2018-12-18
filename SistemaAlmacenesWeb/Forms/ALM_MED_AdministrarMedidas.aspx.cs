using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_MED_AdministrarMedidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearMedida_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearMedida.Visible = true;
            lblFormMedida.Text = "Crear Medida";
            pnEditarMedida.Visible = false;
        }

        protected void btnEditarMedida_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearMedida.Visible = false;
            lblEditarMedida.Text = "Editar Medida";
            pnEditarMedida.Visible = true;
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void btnGuardarMedida_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarMedida_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_MED_AdministrarMedidas.aspx");
        }

        protected void btnEditarGuardarMedida_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarCancelarMedida_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_MED_AdministrarMedidas.aspx");
        }

    }
}