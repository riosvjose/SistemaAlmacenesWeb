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
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_REP_ConsumoDepto : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Items ALMItems = new BD_ALM_Items();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_REP_ConsumoDepartamento"))
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
                    axVarSes.Escribe("MostrarMensajeError", "1");
                    Response.Redirect("Index.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        private void ExportarExcel(GridView gvMatriz)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw1 = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw1);
            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gvMatriz.EnableViewState = false;
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(gvMatriz);
            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=Reporte Consumo.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
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
            pnRepConsumoDepto.Visible = false;
            string fechaInicial = Convert.ToDateTime(tbFechaInicialCon.Text.Trim()).ToString("dd/MM/yyyy");
            string fechaFinal = Convert.ToDateTime(tbFechaFinalCon.Text.Trim()).ToString("dd/MM/yyyy");
            ALMItems.StrConexion = axVarSes.Lee<string>("strConexion"); // Conexion con Items
            if (ALMItems.VerificarFecha(fechaFinal))
            { //Habilitar el panel del reporte
                pnRepConsumoDepto.Visible = true;
                lblRepConsumoDepto.Text = "Reporte del consumo expresado en dinero del " + fechaInicial + " al " + fechaFinal;
                // Reporte del consumo de items expresado en dinero                          
                gvConsumoDepto.Visible = true;
                gvConsumoDepto.DataSource = ALMItems.dtCostoConsumoDepto(fechaInicial, fechaFinal);
                gvConsumoDepto.DataBind();
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "La Fecha Final debe ser menor o igual a la fecha de hoy";
            }
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnLimpiarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_ConsumoDepto.aspx");
        }
        protected void ibtnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarExcel(gvConsumoDepto);
        }
        #endregion

    }
}