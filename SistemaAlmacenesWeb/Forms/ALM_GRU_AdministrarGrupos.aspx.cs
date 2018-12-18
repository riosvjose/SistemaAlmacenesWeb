using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_GRU_AdministrarGrupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlGrupoItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearGrupoItem.Visible = true;
            lblFormGrupoItem.Text = "Crear Grupo de Item";
            pnEditarGrupoItem.Visible = false;
        }

        protected void btnEditarGrupo_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearGrupoItem.Visible = false;
            lblEditarGrupoItem.Text = "Editar Grupo de Item";
            pnEditarGrupoItem.Visible = true;
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGuardarGrupoItem_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarGrupoItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_GRU_AdministrarGrupos.aspx");
        }

        protected void btnEditarGuardarGrupoItem_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarCancelarGrupoItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_GRU_AdministrarGrupos.aspx");
        }

    }
}