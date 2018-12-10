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
    public partial class PED_Realizar : System.Web.UI.Page
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
        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(lblContador.Text.Trim());
            aux++;
            lblContador.Text = aux.ToString();
            switch (aux)
            {
                case 2:
                    Panel2.Visible = true;
                    break;
                case 3:
                    Panel3.Visible = true;
                    break;
                case 4:
                    Panel4.Visible = true;
                    break;
                case 5:
                    Panel5.Visible = true;
                    break;
                case 6:
                    Panel6.Visible = true;
                    break;
                case 7:
                    Panel7.Visible = true;
                    break;
                case 8:
                    Panel8.Visible = true;
                    break;
                case 9:
                    Panel9.Visible = true;
                    break;
                case 10:
                    Panel10.Visible = true;
                    break;
                case 11:
                    Panel11.Visible = true;
                    break;
                case 12:
                    Panel12.Visible = true;
                    break;
                case 13:
                    Panel13.Visible = true;
                    break;
                case 14:
                    Panel14.Visible = true;
                    break;
                case 15:
                    Panel15.Visible = true;
                    break;
            }
        }
        protected void btnQuitarItem_Click(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(lblContador.Text.Trim());
            switch (aux)
            {
                case 2:
                    Panel2.Visible = false;
                    ddlItem2.SelectedIndex = 0;
                    ddlCat2.SelectedIndex = 0;
                    ddlSolicitante2.SelectedIndex = 0;
                    break;
                case 3:
                    Panel3.Visible = false;
                    ddlItem3.SelectedIndex = 0;
                    ddlCat3.SelectedIndex = 0;
                    ddlSolicitante3.SelectedIndex = 0;
                    break;
                case 4:
                    Panel4.Visible = false;
                    ddlItem4.SelectedIndex = 0;
                    ddlCat4.SelectedIndex = 0;
                    ddlSolicitante4.SelectedIndex = 0;
                    break;
                case 5:
                    Panel5.Visible = false;
                    ddlItem5.SelectedIndex = 0;
                    ddlCat5.SelectedIndex = 0;
                    ddlSolicitante5.SelectedIndex = 0;
                    break;
                case 6:
                    Panel6.Visible = false;
                    ddlItem6.SelectedIndex = 0;
                    ddlCat6.SelectedIndex = 0;
                    ddlSolicitante6.SelectedIndex = 0;
                    break;
                case 7:
                    Panel7.Visible = false;
                    ddlItem7.SelectedIndex = 0;
                    ddlCat7.SelectedIndex = 0;
                    ddlSolicitante7.SelectedIndex = 0;
                    break;
                case 8:
                    Panel8.Visible = false;
                    ddlItem8.SelectedIndex = 0;
                    ddlCat8.SelectedIndex = 0;
                    ddlSolicitante8.SelectedIndex = 0;
                    break;
                case 9:
                    Panel9.Visible = false;
                    ddlItem9.SelectedIndex = 0;
                    ddlCat9.SelectedIndex = 0;
                    ddlSolicitante9.SelectedIndex = 0;
                    break;
                case 10:
                    Panel10.Visible = false;
                    ddlItem10.SelectedIndex = 0;
                    ddlCat10.SelectedIndex = 0;
                    ddlSolicitante10.SelectedIndex = 0;
                    break;
                case 11:
                    Panel11.Visible = false;
                    ddlItem11.SelectedIndex = 0;
                    ddlCat11.SelectedIndex = 0;
                    ddlSolicitante11.SelectedIndex = 0;
                    break;
                case 12:
                    Panel12.Visible = false;
                    ddlItem12.SelectedIndex = 0;
                    ddlCat12.SelectedIndex = 0;
                    ddlSolicitante12.SelectedIndex = 0;
                    break;
                case 13:
                    Panel13.Visible = false;
                    ddlItem13.SelectedIndex = 0;
                    ddlCat13.SelectedIndex = 0;
                    ddlSolicitante13.SelectedIndex = 0;
                    break;
                case 14:
                    Panel14.Visible = false;
                    ddlItem14.SelectedIndex = 0;
                    ddlCat14.SelectedIndex = 0;
                    ddlSolicitante14.SelectedIndex = 0;
                    break;
                case 15:
                    Panel15.Visible = false;
                    ddlItem15.SelectedIndex = 0;
                    ddlCat15.SelectedIndex = 0;
                    ddlSolicitante15.SelectedIndex = 0;
                    break;

            }
            aux--;
            lblContador.Text = aux.ToString();
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

        protected void ddlPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void tbCambioValor_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
