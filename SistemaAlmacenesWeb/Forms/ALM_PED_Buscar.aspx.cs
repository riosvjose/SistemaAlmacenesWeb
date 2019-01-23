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
    public partial class ALM_PED_Buscar : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
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
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_PED_Buscar"))
                {
                    CargarDDLSubdeptos();
                    CargarDDLAlmacenes();
                    if((ddlSubdeptos.Items.Count==1)&&(ddlAlmacenes.Items.Count==1))
                    {
                        pnBuscar.Visible = true;
                        pnPrincipal.Visible = false;
                        VerificarPasosPedido();
                        gvDatos1.Visible = true;
                        gvDatos1.Columns[2].Visible = true;
                        gvDatos1.DataSource = dtPedidos;
                        gvDatos1.DataBind();
                        gvDatos1.Columns[2].Visible = false;
                    }
                    else  if(ddlAlmacenes.Items.Count==1)
                    {
                        pnAlmacen.Visible = false;
                    }
                    else if(ddlSubdeptos.Items.Count == 1)
                    {
                        pnSubdepto.Visible = false;
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

        protected void VerificarPasosPedido()
        {
            libPlant = new BD_ALM_Plantillas();
            libPlant.StrConexion = axVarSes.Lee<string>("strConexion");
            libPlant.TipoEgreso = 1;
            libPlant.TipoIngreso = 0;
            libPlant.NumSecAlmacen = Convert.ToInt64(ddlAlmacenes.SelectedValue);
            libPlant.Ver();
            libPasos = new BD_ALM_Pasos();
            libPasos.StrConexion = axVarSes.Lee<string>("strConexion");
            libPasos.NumSecPlantilla = libPlant.NumSecPlantilla;
            DataTable dtpasos= libPasos.VerPasosPlantilla();
            int[] auxpasos = new int[dtpasos.Rows.Count];
            for (int j=0; j<dtpasos.Rows.Count;j++)
            {
                DataRow dr = dtpasos.Rows[j];
                auxpasos[j] = Convert.ToInt32(dr["num_sec_paso"].ToString().Trim());
            }
            
            for (int i=0; i<auxpasos.Length;i++)
            {
                int pasoaux = auxpasos[i];
                int[] auxdeptos = libPasoUsu.VerDeptosPasoUsuario(pasoaux);
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                string subdepto = string.Empty;
                subdepto = ddlSubdeptos.SelectedValue;
                DataTable dtAux = new DataTable();
                dtAux = libMov.DTMostrarPedidosDepto(pasoaux, subdepto);
                dtPedidos.Merge(dtAux);
            }
        }
        public void CargarDDLSubdeptos()
        {
            libPasoUsu.StrConexion = axVarSes.Lee<string>("strConexion");
            libPasoUsu.NumSecUsuario = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
            ddlSubdeptos.DataSource = libPasoUsu.DTVerSubdeptosTodosPasosUsu();
            ddlSubdeptos.DataTextField = "NOMBRE";
            ddlSubdeptos.DataValueField = "NUM_SEC_SUBDEPARTAMENTO";
            ddlSubdeptos.DataBind();
        }
        public void CargarDDLAlmacenes()
        {
            libAlmUsu.StrConexion = axVarSes.Lee<string>("strConexion");
            libAlmUsu.NumSecUsu = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
            ddlAlmacenes.DataSource = libAlmUsu.DTObtenerAlmacenUsuario();
            ddlAlmacenes.DataTextField = "NOMBRE";
            ddlAlmacenes.DataValueField = "NUM_SEC_ALMACEN";
            ddlAlmacenes.DataBind();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnBuscar.Visible = true;
            VerificarPasosPedido();
            gvDatos1.Visible = true;
            gvDatos1.Columns[2].Visible = true;
            gvDatos1.DataSource = dtPedidos;
            gvDatos1.DataBind();
            gvDatos1.Columns[2].Visible = false;

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void ddlSubdeptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnBuscar.Visible = false;
        }

        protected void ddlAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnBuscar.Visible = false;
        }

        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #endregion
        }
}
