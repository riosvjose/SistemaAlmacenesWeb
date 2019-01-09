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
            pnRepConsumoDepto.Visible = false;
            pnRepConsumoPersona.Visible = false;
            string fechaInicial = Convert.ToDateTime(tbFechaInicialItem.Text.Trim()).ToString("dd/MM/yyyy");
            string fechaFinal = Convert.ToDateTime(tbFechaFinalItem.Text.Trim()).ToString("dd/MM/yyyy");
            lblRepConsumoItem.Text = "Reporte de Items entregados del " + fechaInicial + " al " + fechaFinal;
            // Reporte de Items entregados               
            ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
            gvItemsEntregados.Visible = true;
            gvItemsEntregados.Columns[1].Visible = true;
            gvItemsEntregados.DataSource = ALMItems.dtItemsEntregados(fechaInicial, fechaFinal);
            gvItemsEntregados.DataBind();
            gvItemsEntregados.Columns[1].Visible = false; // Jalar y ocultar el num_sec_item
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_ItemsEntregados.aspx");
        }

        #endregion

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
                gvConsumoDepto.DataBind();
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
                lblRepConsumoDepto.Text = "Reporte de Items entregados por Persona del " + fechaInicial + " al " + fechaFinal;
                // Reporte de Items entregados por persona               
                ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
                gvConsumoPersona.Visible = true;
                gvConsumoPersona.Columns[1].Visible = true; //num_sec_item
                gvConsumoPersona.Columns[2].Visible = true; //num_sec_subdepartamento
                gvConsumoPersona.DataSource = ALMItems.dtConsumoPersona(fechaInicial, fechaFinal, num_sec_depto);
                gvConsumoPersona.DataBind();
                gvConsumoPersona.Columns[1].Visible = false; // ocultar el num_sec_item
                gvConsumoPersona.Columns[2].Visible = false; // ocultar el num_sec_subdepartamento (Numero del departamento)
            }
        }
    }
}