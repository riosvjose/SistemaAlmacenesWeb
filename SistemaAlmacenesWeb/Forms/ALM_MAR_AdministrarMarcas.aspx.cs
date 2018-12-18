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
    public partial class ALM_MAR_AdministrarMarcas : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Marcas ALMMarcas = new BD_ALM_Marcas();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            ALMMarcas.StrConexion = axVarSes.Lee<string>("strConexion");
            if (!Page.IsPostBack)
            {
                // Listar a todos los Proveedores
                ddlMarca.DataSource = ALMMarcas.ListarMarcas();
                ddlMarca.DataTextField = "NOMBRE_COMERCIAL";
                ddlMarca.DataValueField = "NUM_SEC_PROVEEDOR";
                ddlMarca.DataBind();
            }
            // Recibir mensaje exitoso cuando se redirige de otra pagina
            if (Session["MensajeOK"] != null)
            {
                pnMensajeOK.Visible = true;
                lblMensajeOK.Text = Session["MensajeOK"].ToString();
                Session["MensajeOK"] = null;
            }
        }
        #endregion

        #region "Eventos"
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
            if (ddlMarca.SelectedIndex != 0)
            {
                pnPrincipal.Visible = false;
                pnCrearMarca.Visible = false;
                lblEditarMarca.Text = "Editar Marca";
                pnEditarMarca.Visible = true;
                //BD_ALM_Marcas
                ALMMarcas.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMMarcas.NumSecMarca = Convert.ToInt64(ddlMarca.Text.Trim()); // Obtener el NUM_SEC_MARCA (id de la marca)
                if (ALMMarcas.Ver())
                {
                    tbEditarNombreMarca.Text = ALMMarcas.Nombre.Trim();
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "Mensaje: " + ALMMarcas.Mensaje;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Usted no selecciono a ninguna Marca";
            }
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
        #endregion
    }
}