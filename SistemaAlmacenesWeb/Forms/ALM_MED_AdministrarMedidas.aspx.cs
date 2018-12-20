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
    public partial class ALM_MED_AdministrarMedidas : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Medidas ALMMedidas = new BD_ALM_Medidas();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                ALMMedidas.StrConexion = axVarSes.Lee<string>("strConexion");

                // Listar a todas las medidas
                gvListaMedidas.Visible = true;
                gvListaMedidas.DataSource = ALMMedidas.dtListarMedidas();
                gvListaMedidas.DataBind();

                // Recibir mensaje exitoso cuando se redirige de otra pagina
                if (Session["MensajeOK"] != null)
                {
                    pnMensajeOK.Visible = true;
                    lblMensajeOK.Text = Session["MensajeOK"].ToString();
                    Session["MensajeOK"] = null;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
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
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void btnGuardarMedida_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            ALMMedidas.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMMedidas.Nombre = tbNombreMedida.Text.ToUpper().Trim();
            ALMMedidas.Abreviacion = tbAbrevMedida.Text.Trim();

            if (ALMMedidas.Insertar())
            {
                Session["MensajeOK"] = "La Medida fue creada exitosamente";
                Response.Redirect("ALM_MED_AdministrarMedidas.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Mensaje: " + ALMMedidas.Mensaje;
            }
        }

        protected void btnCancelarMedida_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_MED_AdministrarMedidas.aspx");
        }
        #endregion
    }
}