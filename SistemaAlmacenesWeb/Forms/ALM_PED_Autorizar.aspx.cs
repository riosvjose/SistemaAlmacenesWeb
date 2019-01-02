using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;

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
        BD_ALM_Ingresos libIngreso = new BD_ALM_Ingresos();
        BD_ALM_IngresosMov libIngresoMov = new BD_ALM_IngresosMov();
        BD_ALM_Movimientos libMov = new BD_ALM_Movimientos();
        BD_ALM_Pasos libPasos = new BD_ALM_Pasos();
        BD_ALM_Dominios libDominio = new BD_ALM_Dominios();
        BD_ALM_Almacenes_Usu libAlmUsu = new BD_ALM_Almacenes_Usu();
        BD_ALM_Almacenes libAlm = new BD_ALM_Almacenes();
        BD_ALM_Plantillas libPlant = new BD_ALM_Plantillas();
        BD_ALM_Pasos_Subdepto_usu libPasoUsu = new BD_ALM_Pasos_Subdepto_usu();
        #endregion

        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            

        }
        protected void VerificarPasos()
        {
            libAlm = new BD_ALM_Almacenes();
            libAlm.StrConexion = axVarSes.Lee<string>("strConexion");
            libPlant = new BD_ALM_Plantillas();
            libPlant.StrConexion = axVarSes.Lee<string>("strConexion");
            libPasos = new BD_ALM_Pasos();
            libPasos.StrConexion = axVarSes.Lee<string>("strConexion");
            libMov = new BD_ALM_Movimientos();
            libMov.StrConexion = axVarSes.Lee<string>("strConexion");
            libAlm.NumSecAlmacen = libGrupo.NumSecAlmacen;
            libAlm.Ver();
            libPlant.NumSecAlmacen = libAlm.NumSecAlmacen;
            libPlant.TipoEgreso = 1;
            libPlant.TipoIngreso = 0;
            libPlant.Ver();
            libPasos.NumSecPlantilla = libPlant.NumSecPlantilla;
            libPasos.VerPrimeroPlantilla();

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

        protected void lbtPagAnterior_Click(object sender, EventArgs e)
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

        }

        #endregion
        }
}
