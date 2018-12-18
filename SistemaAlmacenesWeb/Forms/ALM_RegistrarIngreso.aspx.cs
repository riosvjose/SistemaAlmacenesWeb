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
    public partial class RegistrarIngreso : System.Web.UI.Page
    {
        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        BD_ALM_Grupos_Items libGrupo = new BD_ALM_Grupos_Items();
        BD_ALM_Cat_Items libCat = new BD_ALM_Cat_Items();
        BD_ALM_Items libItem = new BD_ALM_Items();
        BD_Personas libpersona = new BD_Personas();
        BD_ALM_Movimientos libMov = new BD_ALM_Movimientos();
        BD_ALM_Dominios libDominio = new BD_ALM_Dominios();
        BD_ALM_Almacenes_Usu libAlmUsu = new BD_ALM_Almacenes_Usu();
        #endregion

        #region "Clase de tablas de la Base de Datos"

        #endregion

        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            libDominio = new BD_ALM_Dominios();
            libDominio.StrConexion = axVarSes.Lee<string>("strConexion");
            libDominio.Dominio = "ALM_TIPO_INGRESO";
            ddlTipoIngreso.DataSource = libDominio.DTVerDominio();
            ddlTipoIngreso.DataTextField = "DESCRIPCION";
            ddlTipoIngreso.DataValueField = "VALOR";
            ddlTipoIngreso.DataBind();
        }
        protected void VaciarBoxes()
        {
            
        }
        protected void CargarDdlGrupos()
        {
            libAlmUsu = new BD_ALM_Almacenes_Usu();
            libAlmUsu.StrConexion = axVarSes.Lee<string>("strConexion");
            libAlmUsu.NumSecUsu= Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
            string[] stralmacenes = libAlmUsu.ObtenerAlmacenUsuario();
            libGrupo = new BD_ALM_Grupos_Items(); 
            libGrupo.StrConexion= axVarSes.Lee<string>("strConexion");
            libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            
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
            string[] StrSqls = new string[15];
            for (int i = 1; ((i <= 15) && (i <= Convert.ToInt32(lblContador.Text))); i++)
            {
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion"); 
                libMov.NumSecPersona = Convert.ToInt64(axVarSes.Lee<string>("UsuarioPersonaNumSec"));
                libMov.NumSecTipoMov = 1;
                switch (i)
                {
                    case 1:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem1.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant1.Text);
                        break;
                    case 2:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem2.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant2.Text);
                        break;
                    case 3:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem3.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant3.Text);
                        break;
                    case 4:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant4.Text);
                        break;
                    case 5:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem5.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant5.Text);
                        break;
                    case 6:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem6.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant4.Text);
                        break;
                    case 7:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant4.Text);
                        break;
                    case 8:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant8.Text);
                        break;
                    case 9:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant9.Text);
                        break;
                    case 10:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant10.Text);
                        break;
                    case 11:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant11.Text);
                        break;
                    case 12:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant12.Text);
                        break;
                    case 13:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant13.Text);
                        break;
                    case 14:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant14.Text);
                        break;
                    case 15:
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.Ingreso = Convert.ToInt32(tbCant15.Text);
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
                lblMensajeOK.Text = "Ingreso registrado exitosamente.";
                pnMensajeOK.Visible = true;
            }
            else
            {
                lblMensajeError.Text = "Error al registrar el ingreso. " + libMov.Mensaje;
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
                    ddlItem2.SelectedIndex = 0;
                    tbPrecio2.Text = "0";
                    break;
                case 3:
                    Panel3.Visible = false;
                    ddlItem3.SelectedIndex = 0;
                    tbPrecio3.Text = "0";
                    break;
                case 4:
                    Panel4.Visible = false;
                    ddlItem4.SelectedIndex = 0;
                    tbPrecio4.Text = "0";
                    break;
                case 5:
                    Panel5.Visible = false;
                    ddlItem5.SelectedIndex = 0;
                    tbPrecio5.Text = "0";
                    break;
                case 6:
                    Panel6.Visible = false;
                    ddlItem6.SelectedIndex = 0;
                    tbPrecio6.Text = "0";
                    break;
                case 7:
                    Panel7.Visible = false;
                    ddlItem7.SelectedIndex = 0;
                    tbPrecio7.Text = "0";
                    break;
                case 8:
                    Panel8.Visible = false;
                    ddlItem8.SelectedIndex = 0;
                    tbPrecio8.Text = "0";
                    break;
                case 9:
                    Panel9.Visible = false;
                    ddlItem9.SelectedIndex = 0;
                    tbPrecio9.Text = "0";
                    break;
                case 10:
                    Panel10.Visible = false;
                    ddlItem10.SelectedIndex = 0;
                    tbPrecio10.Text = "0";
                    break;
                case 11:
                    Panel11.Visible = false;
                    ddlItem11.SelectedIndex = 0;
                    tbPrecio11.Text = "0";
                    break;
                case 12:
                    Panel12.Visible = false;
                    ddlItem12.SelectedIndex = 0;
                    tbPrecio12.Text = "0";
                    break;
                case 13:
                    Panel13.Visible = false;
                    ddlItem13.SelectedIndex = 0;
                    tbPrecio13.Text = "0";
                    break;
                case 14:
                    Panel14.Visible = false;
                    ddlItem14.SelectedIndex = 0;
                    tbPrecio14.Text = "0";
                    break;
                case 15:
                    Panel15.Visible = false;
                    ddlItem15.SelectedIndex = 0;
                    tbPrecio15.Text = "0";
                    break;

            }
            aux--;
            lblContador.Text = aux.ToString();
        }
        protected void ddlGrupo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem= (Convert.ToInt64(ddlGrupo1.SelectedValue));
            ddlCat1.DataSource = libCat.DTListaCategorias();
            ddlCat1.DataTextField = "NOMBRE";
            ddlCat1.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat1.DataBind();
        }
        protected void ddlGrupo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo2.SelectedValue));
            ddlCat2.DataSource = libCat.DTListaCategorias();
            ddlCat2.DataTextField = "NOMBRE";
            ddlCat2.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat2.DataBind();
        }
        protected void ddlGrupo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo3.SelectedValue));
            ddlCat3.DataSource = libCat.DTListaCategorias();
            ddlCat3.DataTextField = "NOMBRE";
            ddlCat3.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat3.DataBind();
        }
        protected void ddlGrupo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo4.SelectedValue));
            ddlCat4.DataSource = libCat.DTListaCategorias();
            ddlCat4.DataTextField = "NOMBRE";
            ddlCat4.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat4.DataBind();
        }
        protected void ddlGrupo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo5.SelectedValue));
            ddlCat5.DataSource = libCat.DTListaCategorias();
            ddlCat5.DataTextField = "NOMBRE";
            ddlCat5.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat5.DataBind();
        }
        protected void ddlGrupo6_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo6.SelectedValue));
            ddlCat6.DataSource = libCat.DTListaCategorias();
            ddlCat6.DataTextField = "NOMBRE";
            ddlCat6.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat6.DataBind();
        }
        protected void ddlGrupo7_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo7.SelectedValue));
            ddlCat7.DataSource = libCat.DTListaCategorias();
            ddlCat7.DataTextField = "NOMBRE";
            ddlCat7.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat7.DataBind();
        }
        protected void ddlGrupo8_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo8.SelectedValue));
            ddlCat8.DataSource = libCat.DTListaCategorias();
            ddlCat8.DataTextField = "NOMBRE";
            ddlCat8.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat8.DataBind();
        }
        protected void ddlGrupo9_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo9.SelectedValue));
            ddlCat9.DataSource = libCat.DTListaCategorias();
            ddlCat9.DataTextField = "NOMBRE";
            ddlCat9.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat9.DataBind();
        }
        protected void ddlGrupo10_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo10.SelectedValue));
            ddlCat10.DataSource = libCat.DTListaCategorias();
            ddlCat10.DataTextField = "NOMBRE";
            ddlCat10.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat10.DataBind();
        }
        protected void ddlGrupo11_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo11.SelectedValue));
            ddlCat11.DataSource = libCat.DTListaCategorias();
            ddlCat11.DataTextField = "NOMBRE";
            ddlCat11.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat11.DataBind();
        }
        protected void ddlGrupo12_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo12.SelectedValue));
            ddlCat12.DataSource = libCat.DTListaCategorias();
            ddlCat12.DataTextField = "NOMBRE";
            ddlCat12.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat12.DataBind();
        }
        protected void ddlGrupo13_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo13.SelectedValue));
            ddlCat13.DataSource = libCat.DTListaCategorias();
            ddlCat13.DataTextField = "NOMBRE";
            ddlCat13.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat13.DataBind();
        }
        protected void ddlGrupo14_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo14.SelectedValue));
            ddlCat14.DataSource = libCat.DTListaCategorias();
            ddlCat14.DataTextField = "NOMBRE";
            ddlCat1.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat14.DataBind();
        }
        protected void ddlGrupo15_SelectedIndexChanged(object sender, EventArgs e)
        {
            libCat = new BD_ALM_Cat_Items();
            libCat.StrConexion = axVarSes.Lee<string>("strConexion");
            libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo15.SelectedValue));
            ddlCat15.DataSource = libCat.DTListaCategorias();
            ddlCat15.DataTextField = "NOMBRE";
            ddlCat15.DataValueField = "NUM_SEC_CATEGORIA";
            ddlCat15.DataBind();
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

        protected void ddlTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tbCambioValor_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
