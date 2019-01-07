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
    public partial class ALM_REP_ItemsEntregados : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Items ALMItems = new BD_ALM_Items();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
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

        protected void btnGenerarReportes_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;            
            //Habilitar el panel del reporte
            pnRepConsumoItem.Visible = true;
            string fechaInicial = Convert.ToDateTime(tbFechaInicialItem.Text.Trim()).ToString("dd/MM/yyyy");
            string fechaFinal = Convert.ToDateTime(tbFechaFinalItem.Text.Trim()).ToString("dd/MM/yyyy");
            lblRepConsumoItem.Text = "Reporte de Items entregados del " + fechaInicial + " al " + fechaFinal;
            // Reporte de Items entregados               
            ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
            gvItemsEntregados.Visible = true;
            gvItemsEntregados.DataSource = ALMItems.dtItemsEntregados(fechaInicial, fechaFinal);
            gvItemsEntregados.DataBind();
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_ItemsEntregados.aspx");
        }

        #endregion
    }
}