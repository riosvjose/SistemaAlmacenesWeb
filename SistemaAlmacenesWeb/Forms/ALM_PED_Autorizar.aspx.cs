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

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_PED_Autorizar : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Grupos_Items libGrupo = new BD_ALM_Grupos_Items();
        BD_ALM_Cat_Items libCat = new BD_ALM_Cat_Items();
        BD_ALM_Items libItem = new BD_ALM_Items();
        BD_Personas libpersona = new BD_Personas();
        BD_ALM_Movimientos libMov = new BD_ALM_Movimientos();
        BD_ALM_Pasos libPasos = new BD_ALM_Pasos();
        BD_ALM_Almacenes_Usu libAlmUsu = new BD_ALM_Almacenes_Usu();
        BD_ALM_Almacenes libAlm = new BD_ALM_Almacenes();
        BD_ALM_Plantillas libPlant = new BD_ALM_Plantillas();
        BD_ALM_Pasos_Subdepto_usu libPasoUsu = new BD_ALM_Pasos_Subdepto_usu();
        #endregion

        #region Variable globales
        DataTable dtPedidos = new DataTable();
        #endregion

        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            VerificarPasos();
            gvDatos1.Visible = true;
            gvDatos1.Columns[2].Visible = true;
            gvDatos1.DataSource = dtPedidos;
            gvDatos1.DataBind();
            gvDatos1.Columns[2].Visible = false;
            llenarTexboxes();
        }

        protected void llenarTexboxes()
        {
            for (int i = 0; i < gvDatos1.Rows.Count; i++)
            {
                ((TextBox)gvDatos1.Rows[i].Cells[6].Controls[1]).Text= gvDatos1.Rows[i].Cells[5].Text.Trim();
            }
        }

        protected void VerificarPasos()
        {
            libPasoUsu = new BD_ALM_Pasos_Subdepto_usu();
            libPasoUsu.StrConexion = axVarSes.Lee<string>("strConexion");
            int [] auxpasos = libPasoUsu.VerPasosTramiteUsuario(0,1);
            for (int i=0; i<auxpasos.Length;i++)
            {
                int pasoaux = auxpasos[i];
                int[] auxdeptos = libPasoUsu.VerDeptosPasoUsuario(pasoaux);
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                DataTable dtAux = new DataTable();
                dtAux = libMov.DTTransaccionesPasoAnterior(pasoaux, auxdeptos);
                dtPedidos.Merge(dtAux);
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

        protected void btnAtras_Click(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            int cant = Convert.ToInt32(((TextBox)gvDatos1.Rows[indice].Cells[6].Controls[1]).Text);
            if (e.CommandName == "autorizar")
            {
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libMov.autorizarSalida(Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text), Convert.ToInt32(gvDatos1.Rows[indice].Cells[2].Text), cant))
                {
                    pnMensajeError.Visible = false;
                    Response.Redirect("ALM_PED_Autorizar.aspx");
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeOK.Text = "No se pudo aprobar el pedido Nro. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text)+". "+libMov.Mensaje; ;
                    pnMensajeOK.Visible = false;
                }
            }
            if (e.CommandName == "modificar")
            {
                ((TextBox)gvDatos1.Rows[indice].Cells[6].Controls[1]).Enabled=true;
            }
            if (e.CommandName == "rechazar")
            {
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libMov.RechazarSalida(Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text), Convert.ToInt32(gvDatos1.Rows[indice].Cells[2].Text), Convert.ToInt32(gvDatos1.Rows[indice].Cells[5].Text)))
                {
                    pnMensajeError.Visible = false;
                    Response.Redirect("ALM_PED_Autorizar.aspx");
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeOK.Text = "No se pudo rechazar el pedido Nro. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text)+libMov.Mensaje;
                    pnMensajeOK.Visible = false;
                }
            }
        }

        #endregion
        }
}
