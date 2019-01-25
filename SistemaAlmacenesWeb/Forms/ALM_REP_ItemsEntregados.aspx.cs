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
using System.IO;
using System.Web.UI.HtmlControls;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_REP_ItemsEntregados : System.Web.UI.Page
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
                if (libproc.AccesoObjetoUsuario("ALM_REP_ItemsEntregados"))
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
            Response.AddHeader("Content-Disposition", "attachment; filename=Exportar items entregados.xls");
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
            pnRepConsumoItem.Visible = false;
            pnRepConsumoDepto.Visible = false;
            pnRepConsumoPersona.Visible = false;
            string fechaInicial = Convert.ToDateTime(tbFechaInicialItem.Text.Trim()).ToString("dd/MM/yyyy");
            string fechaFinal = Convert.ToDateTime(tbFechaFinalItem.Text.Trim()).ToString("dd/MM/yyyy");
            ALMItems.StrConexion = axVarSes.Lee<string>("strConexion"); // Conexion con Items
            if (ALMItems.VerificarFecha(fechaFinal))
            { //Habilitar el panel del reporte
                pnRepConsumoItem.Visible = true;
                lblRepConsumoItem.Text = "Reporte de Items entregados del " + fechaInicial + " al " + fechaFinal;
                // Reporte de Items entregados                           
                gvItemsEntregados.Visible = true;
                gvItemsEntregados.Columns[1].Visible = true;
                gvItemsEntregados.DataSource = ALMItems.dtItemsEntregados(fechaInicial, fechaFinal);
                gvItemsEntregados.DataBind();
                gvItemsEntregados.Columns[1].Visible = false; // Jalar y ocultar el num_sec_item
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

        protected void gvItemsEntregados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            int indice = Convert.ToInt32(e.CommandArgument); //Para indicar la Fila
            //int cant = Convert.ToInt32(((TextBox)gvItemsEntregados.Rows[indice].Cells[1].Controls[1]).Text);
            gvItemsEntregados.Columns[1].Visible = true; //Habilitar y mostrar la columna num_sec_item, para despues poder enviar el dato.
            string num_sec_item = gvItemsEntregados.Rows[indice].Cells[1].Text.Trim();
            gvItemsEntregados.Columns[1].Visible = false; //Ocultar la columna num_sec_item
            axVarSes.Escribe("NumSecItem", num_sec_item); // Enviar el id de ALM_ITEMS (num_sec_item)
            if (e.CommandName == "verDepto")
            {
                //Habilitar el panel del reporte por departamento
                pnRepConsumoItem.Visible = false;
                pnRepConsumoDepto.Visible = true;
                pnRepConsumoPersona.Visible = false;
                string fechaInicial = Convert.ToDateTime(tbFechaInicialItem.Text.Trim()).ToString("dd/MM/yyyy");
                string fechaFinal = Convert.ToDateTime(tbFechaFinalItem.Text.Trim()).ToString("dd/MM/yyyy");
                lblRepConsumoDepto.Text = "Reporte de Items entregados por Departamento del " + fechaInicial + " al " + fechaFinal;
                // Reporte de Items entregados por departamento
                ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
                gvConsumoDepto.Visible = true;
                gvConsumoDepto.Columns[1].Visible = true; 
                gvConsumoDepto.Columns[2].Visible = true; 
                gvConsumoDepto.DataSource = ALMItems.dtConsumoDepto(fechaInicial, fechaFinal);
                gvConsumoDepto.DataBind(); //Llenar el GridView con los datos de la consulta
                //Hacer el calculo del Consumo Total por Departamento con datos del GridView
                long totalDepto = 0; //Consumo total del Departamento
                foreach (GridViewRow gvr in gvConsumoDepto.Rows)
                {
                    totalDepto += Convert.ToInt64(gvr.Cells[4].Text);// Sumar todo el campo cantidad
                }
                if (gvConsumoDepto.Rows.Count > 0) // Mostar el TOTAL caso de que haya mas de una fila
                {
                    gvConsumoDepto.ShowFooter = true;
                    gvConsumoDepto.Columns[4].FooterText = totalDepto.ToString();
                    gvConsumoDepto.DataBind(); //Aumentar el Total en el GridView
                }                               
                gvConsumoDepto.Columns[1].Visible = false; // ocultar el num_sec_item
                gvConsumoDepto.Columns[2].Visible = false; // ocultar el num_sec_subdepartamento (Numero del departamento)
            }
        }

        protected void gvConsumoDepto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            int indice = Convert.ToInt32(e.CommandArgument); //Para indicar la Fila
            //int cant = Convert.ToInt32(((TextBox)gvItemsEntregados.Rows[indice].Cells[1].Controls[1]).Text);
            gvConsumoDepto.Columns[1].Visible = true; //Habilitar y mostrar la columna "num_sec_item", para despues poder enviar el dato.
            gvConsumoDepto.Columns[2].Visible = true; //Habilitar y mostrar la columna "num_sec_subdepartamento", para despues poder enviar el dato.
            string num_sec_item = gvConsumoDepto.Rows[indice].Cells[1].Text.Trim();
            string num_sec_depto = gvConsumoDepto.Rows[indice].Cells[2].Text.Trim();            
            gvConsumoDepto.Columns[1].Visible = false; //Ocultar la columna "num_sec_item"
            gvConsumoDepto.Columns[2].Visible = false; //Ocultar la columna "num_sec_subdepartamento"
            axVarSes.Escribe("NumSecItem", num_sec_item); // Enviar el id de ALM_ITEMS (num_sec_item)

            if (e.CommandName == "verPer")
            {
                //Habilitar el panel del reporte por persona
                pnRepConsumoItem.Visible = false;
                pnRepConsumoDepto.Visible = false;
                pnRepConsumoPersona.Visible = true;
                string fechaInicial = Convert.ToDateTime(tbFechaInicialItem.Text.Trim()).ToString("dd/MM/yyyy");
                string fechaFinal = Convert.ToDateTime(tbFechaFinalItem.Text.Trim()).ToString("dd/MM/yyyy");
                lblRepConsumoPersona.Text = "Reporte de Items entregados por Persona del " + fechaInicial + " al " + fechaFinal;
                // Reporte de Items entregados por persona               
                ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
                gvConsumoPersona.Visible = true;
                gvConsumoPersona.Columns[1].Visible = true; //num_sec_item
                gvConsumoPersona.Columns[2].Visible = true; //num_sec_subdepartamento
                gvConsumoPersona.DataSource = ALMItems.dtConsumoPersona(fechaInicial, fechaFinal, num_sec_depto);
                gvConsumoPersona.DataBind();
                //Hacer el calculo del Consumo Total por Persona con datos del GridView
                long totalPer = 0; //Consumo total 
                foreach (GridViewRow gvr in gvConsumoPersona.Rows)
                {
                    totalPer += Convert.ToInt64(gvr.Cells[6].Text);// Sumar todo el campo cantidad
                }
                if (gvConsumoPersona.Rows.Count > 0) // Mostar el TOTAL caso de que haya mas de una fila
                {
                    gvConsumoPersona.ShowFooter = true;
                    gvConsumoPersona.Columns[6].FooterText = totalPer.ToString();
                    gvConsumoPersona.DataBind(); //Aumentar el Total en el GridView
                }
                gvConsumoPersona.Columns[1].Visible = false; // ocultar el num_sec_item
                gvConsumoPersona.Columns[2].Visible = false; // ocultar el num_sec_subdepartamento (Numero del departamento)
            }
        }

        protected void btnLimpiarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_ItemsEntregados.aspx");
        }

        protected void btnVolverItem_Click(object sender, EventArgs e)
        {
            pnRepConsumoItem.Visible = true;
            pnRepConsumoDepto.Visible = false;
            pnRepConsumoPersona.Visible = false;
        }


        protected void btnVolverDepto_Click(object sender, EventArgs e)
        {
            pnRepConsumoItem.Visible = false;
            pnRepConsumoDepto.Visible = true;
            pnRepConsumoPersona.Visible = false;
        }

        protected void ibtnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarExcel(gvItemsEntregados);
        }

        protected void ibtnExportarExcel1_Click(object sender, EventArgs e)
        {
            ExportarExcel(gvConsumoDepto);
        }

        protected void ibtnExportarExcel2_Click(object sender, EventArgs e)
        {
            ExportarExcel(gvConsumoPersona);
        }
        #endregion

    }
}