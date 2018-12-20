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
    public partial class ALM_PED_Realizar : System.Web.UI.Page
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
        BD_ALM_Almacenes libAlm = new BD_ALM_Almacenes();
        BD_ALM_Plantillas libPlant = new BD_ALM_Plantillas();
        #endregion

        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = strCon;
            ddlCat1.DataSource = libCat.DTListaCategorias();
            ddlCat1.DataTextField = "NOMBRE";
            ddlCat1.DataValueField = "NUM_SEC_CAT";
            ddlCat1.DataBind();
            ddlCat2.DataSource = libCat.DTListaCategorias();
            ddlCat2.DataTextField = "NOMBRE";
            ddlCat2.DataValueField = "NUM_SEC_CAT";
            ddlCat2.DataBind();
            ddlCat3.DataSource = libCat.DTListaCategorias();
            ddlCat3.DataTextField = "NOMBRE";
            ddlCat3.DataValueField = "NUM_SEC_CAT";
            ddlCat3.DataBind();
            ddlCat4.DataSource = libCat.DTListaCategorias();
            ddlCat4.DataTextField = "NOMBRE";
            ddlCat4.DataValueField = "NUM_SEC_CAT";
            ddlCat4.DataBind();
            ddlCat5.DataSource = libCat.DTListaCategorias();
            ddlCat5.DataTextField = "NOMBRE";
            ddlCat5.DataValueField = "NUM_SEC_CAT";
            ddlCat5.DataBind();
            ddlCat6.DataSource = libCat.DTListaCategorias();
            ddlCat6.DataTextField = "NOMBRE";
            ddlCat6.DataValueField = "NUM_SEC_CAT";
            ddlCat6.DataBind();
            ddlCat7.DataSource = libCat.DTListaCategorias();
            ddlCat7.DataTextField = "NOMBRE";
            ddlCat7.DataValueField = "NUM_SEC_CAT";
            ddlCat7.DataBind();
            ddlCat8.DataSource = libCat.DTListaCategorias();
            ddlCat8.DataTextField = "NOMBRE";
            ddlCat8.DataValueField = "NUM_SEC_CAT";
            ddlCat8.DataBind();
            ddlCat9.DataSource = libCat.DTListaCategorias();
            ddlCat9.DataTextField = "NOMBRE";
            ddlCat9.DataValueField = "NUM_SEC_CAT";
            ddlCat9.DataBind();
            ddlCat10.DataSource = libCat.DTListaCategorias();
            ddlCat10.DataTextField = "NOMBRE";
            ddlCat10.DataValueField = "NUM_SEC_CAT";
            ddlCat10.DataBind();
            ddlCat11.DataSource = libCat.DTListaCategorias();
            ddlCat11.DataTextField = "NOMBRE";
            ddlCat11.DataValueField = "NUM_SEC_CAT";
            ddlCat11.DataBind();
            ddlCat12.DataSource = libCat.DTListaCategorias();
            ddlCat12.DataTextField = "NOMBRE";
            ddlCat12.DataValueField = "NUM_SEC_CAT";
            ddlCat12.DataBind();
            ddlCat13.DataSource = libCat.DTListaCategorias();
            ddlCat13.DataTextField = "NOMBRE";
            ddlCat13.DataValueField = "NUM_SEC_CAT";
            ddlCat13.DataBind();
            ddlCat14.DataSource = libCat.DTListaCategorias();
            ddlCat14.DataTextField = "NOMBRE";
            ddlCat14.DataValueField = "NUM_SEC_CAT";
            ddlCat14.DataBind();
            ddlCat15.DataSource = libCat.DTListaCategorias();
            ddlCat15.DataTextField = "NOMBRE";
            ddlCat15.DataValueField = "NUM_SEC_CAT";
            ddlCat15.DataBind();
            libpersona = new BD_Personas();
            libpersona.StrConexion = strCon;
            ddlSolicitante1.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante1.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante1.DataValueField = "NUM_SEC";
            ddlSolicitante1.DataBind();
            ddlSolicitante2.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante2.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante2.DataValueField = "NUM_SEC";
            ddlSolicitante2.DataBind();
            ddlSolicitante3.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante3.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante3.DataValueField = "NUM_SEC";
            ddlSolicitante3.DataBind();
            ddlSolicitante4.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante4.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante4.DataValueField = "NUM_SEC";
            ddlSolicitante4.DataBind();
            ddlSolicitante5.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante5.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante5.DataValueField = "NUM_SEC";
            ddlSolicitante5.DataBind();
            ddlSolicitante6.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante6.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante6.DataValueField = "NUM_SEC";
            ddlSolicitante6.DataBind();
            ddlSolicitante7.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante7.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante7.DataValueField = "NUM_SEC";
            ddlSolicitante7.DataBind();
            ddlSolicitante8.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante8.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante8.DataValueField = "NUM_SEC";
            ddlSolicitante8.DataBind();
            ddlSolicitante9.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante9.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante9.DataValueField = "NUM_SEC";
            ddlSolicitante9.DataBind();
            ddlSolicitante10.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante10.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante10.DataValueField = "NUM_SEC";
            ddlSolicitante10.DataBind();
            ddlSolicitante11.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante11.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante11.DataValueField = "NUM_SEC";
            ddlSolicitante11.DataBind();
            ddlSolicitante12.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante12.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante12.DataValueField = "NUM_SEC";
            ddlSolicitante12.DataBind();
            ddlSolicitante13.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante13.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante13.DataValueField = "NUM_SEC";
            ddlSolicitante13.DataBind();
            ddlSolicitante14.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante14.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante14.DataValueField = "NUM_SEC";
            ddlSolicitante14.DataBind();
            ddlSolicitante15.DataSource = libpersona.DTListaPersonasDepto();
            ddlSolicitante15.DataTextField = "NOMBRE_COMPLETO";
            ddlSolicitante15.DataValueField = "NUM_SEC";
            ddlSolicitante15.DataBind();
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
            string[] StrSqls = new string[15];
            for (int i = 1; ((i <= 15)&&(i <= Convert.ToInt32(lblContador.Text))); i++)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libGrupo = new BD_ALM_Grupos_Items();
                libGrupo.StrConexion = axVarSes.Lee<string>("strConexion");
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                switch (i)
                {
                    case 1:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem1.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante1.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant1.Text);
                        //libI
                        libMov.NumSecPaso = 2;
                        break;
                    case 2:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem2.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante2.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant2.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 3:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem3.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante3.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant3.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 4:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante4.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant4.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 5:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem5.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante5.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant5.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 6:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem6.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante6.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant4.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 7:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante7.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant4.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 8:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante8.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant8.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 9:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante9.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant9.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 10:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante10.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant10.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 11:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante11.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant11.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 12:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante12.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant12.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 13:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante13.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant13.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 14:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante14.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant14.Text);
                        libMov.NumSecPaso = 2;
                        break;
                    case 15:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante15.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant15.Text);
                        libMov.NumSecPaso = 2;
                        break;
                }
                libMov.NumSecUsuario = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
                libMov.NumSecUsuarioRegistro = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
                StrSqls[i - 1] = libMov.SQLCadenaMovimiento();
            }
            libMov = new BD_ALM_Movimientos();
            libMov.StrConexion = axVarSes.Lee<string>("strConexion");
            if (libMov.InsetarVarios(StrSqls, Convert.ToInt32(lblContador.Text)))
            {
                lblMensajeOK.Text = "Pedido registrado exitosamente.";
                pnMensajeOK.Visible = true;
            }
            else
            {
                lblMensajeError.Text = "Error al registrar el pedido."+libMov.Mensaje;
                pnMensajeError.Visible = true;
            }

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
                    break;
                case 3:
                    Panel3.Visible = false;
                    break;
                case 4:
                    Panel4.Visible = false;
                    break;
                case 5:
                    Panel5.Visible = false;
                    break;
                case 6:
                    Panel6.Visible = false;
                    break;
                case 7:
                    Panel7.Visible = false;
                    break;
                case 8:
                    Panel8.Visible = false;
                    break;
                case 9:
                    Panel9.Visible = false;
                    break;
                case 10:
                    Panel10.Visible = false;
                    break;
                case 11:
                    Panel11.Visible = false;
                    break;
                case 12:
                    Panel12.Visible = false;
                    break;
                case 13:
                    Panel13.Visible = false;
                    break;
                case 14:
                    Panel14.Visible = false;
                    break;
                case 15:
                    Panel15.Visible = false;
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

        protected void ddlCat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem1.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat1.SelectedValue));
            ddlItem1.DataTextField = "NOMBRE";
            ddlItem1.DataValueField = "NUM_SEC_ITEM";
            ddlItem1.DataBind();
        }
        protected void ddlCat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem2.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat2.SelectedValue));
            ddlItem2.DataTextField = "NOMBRE";
            ddlItem2.DataValueField = "NUM_SEC_ITEM";
            ddlItem2.DataBind();
        }
        protected void ddlCat3_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem3.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat3.SelectedValue));
            ddlItem3.DataTextField = "NOMBRE";
            ddlItem3.DataValueField = "NUM_SEC_ITEM";
            ddlItem3.DataBind();
        }
        protected void ddlCat4_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem4.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat4.SelectedValue));
            ddlItem4.DataTextField = "NOMBRE";
            ddlItem4.DataValueField = "NUM_SEC_ITEM";
            ddlItem4.DataBind();
        }
        protected void ddlCat5_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem5.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat5.SelectedValue));
            ddlItem5.DataTextField = "NOMBRE";
            ddlItem5.DataValueField = "NUM_SEC_ITEM";
            ddlItem5.DataBind();
        }
        protected void ddlCat6_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem6.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat6.SelectedValue));
            ddlItem6.DataTextField = "NOMBRE";
            ddlItem6.DataValueField = "NUM_SEC_ITEM";
            ddlItem6.DataBind();
        }
        protected void ddlCat7_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem7.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat7.SelectedValue));
            ddlItem7.DataTextField = "NOMBRE";
            ddlItem7.DataValueField = "NUM_SEC_ITEM";
            ddlItem7.DataBind();
        }
        protected void ddlCat8_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem8.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat8.SelectedValue));
            ddlItem8.DataTextField = "NOMBRE";
            ddlItem8.DataValueField = "NUM_SEC_ITEM";
            ddlItem8.DataBind();
        }
        protected void ddlCat9_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem9.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat9.SelectedValue));
            ddlItem9.DataTextField = "NOMBRE";
            ddlItem9.DataValueField = "NUM_SEC_ITEM";
            ddlItem9.DataBind();
        }
        protected void ddlCat10_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem10.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat10.SelectedValue));
            ddlItem10.DataTextField = "NOMBRE";
            ddlItem10.DataValueField = "NUM_SEC_ITEM";
            ddlItem10.DataBind();
        }
        protected void ddlCat11_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem11.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat11.SelectedValue));
            ddlItem11.DataTextField = "NOMBRE";
            ddlItem11.DataValueField = "NUM_SEC_ITEM";
            ddlItem11.DataBind();
        }
        protected void ddlCat12_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem12.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat12.SelectedValue));
            ddlItem12.DataTextField = "NOMBRE";
            ddlItem12.DataValueField = "NUM_SEC_ITEM";
            ddlItem12.DataBind();
        }
        protected void ddlCat13_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem13.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat13.SelectedValue));
            ddlItem13.DataTextField = "NOMBRE";
            ddlItem13.DataValueField = "NUM_SEC_ITEM";
            ddlItem13.DataBind();
        }
        protected void ddlCat14_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem14.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat14.SelectedValue));
            ddlItem14.DataTextField = "NOMBRE";
            ddlItem14.DataValueField = "NUM_SEC_ITEM";
            ddlItem14.DataBind();
        }
        protected void ddlCat15_SelectedIndexChanged(object sender, EventArgs e)
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlItem15.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat15.SelectedValue));
            ddlItem15.DataTextField = "NOMBRE";
            ddlItem15.DataValueField = "NUM_SEC_ITEM";
            ddlItem15.DataBind();
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
