using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_PROV_AdministrarProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearProveedor_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearProveedor.Visible = true;
            lblFormProveedor.Text = "Crear Proveedor";            
            pnEditarProveedor.Visible = false;
        }

        protected void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearProveedor.Visible = false;
            lblFormEditarProveedor.Text = "Editar Proveedor";
            pnEditarProveedor.Visible = true;
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGuardarProv_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarProv_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_PROV_AdministrarProveedores.aspx");
        }

        protected void btnEditarGuardarProv_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarCancelarProv_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_PROV_AdministrarProveedores.aspx");
        }
    }
}