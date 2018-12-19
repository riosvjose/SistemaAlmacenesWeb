using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using System.Data;
using nsGEN;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_CAT_AdministrarCategorias : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Cat_Items ALMCategoriasItems = new BD_ALM_Cat_Items();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                ALMCategoriasItems.StrConexion = axVarSes.Lee<string>("strConexion");
                // Listar todas las Categorias de Items
                ddlCategoriaItems.DataSource = ALMCategoriasItems.DTListaCategorias();
                ddlCategoriaItems.DataTextField = "NOMBRE";
                ddlCategoriaItems.DataValueField = "NUM_SEC_CAT";
                ddlCategoriaItems.DataBind();

                // Recibir mensaje exitoso cuando se redirige de otra pagina
                if (Session["MensajeOK"] != null)
                {
                    pnMensajeOK.Visible = true;
                    lblMensajeOK.Text = Session["MensajeOK"].ToString();
                    Session["MensajeOK"] = null;
                }
            }
        }
        #endregion

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
            }
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