using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;

namespace SistemaAlmacenes.Forms
{
    public partial class SAL_Registrar : System.Web.UI.Page
    {
        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();


        #endregion

        #region "Clase de tablas de la Base de Datos"

        #endregion

        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {


        }
        protected void VaciarBoxes()
        {
            
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
        
        protected void btnSgteGenerales_Click(object sender, EventArgs e)
        {

        }
        protected void btnEditarGenerales_Click(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        protected void ddlTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTipoSal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void tbCambioValor_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
