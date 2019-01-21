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

        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Proveedores libProv = new BD_ALM_Proveedores();
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
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        #endregion

        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            if ((strCon!="")&&(strCon!=string.Empty)&&(strCon!=null))
            {
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_RegistrarIngreso"))
                {
                    libDominio = new BD_ALM_Dominios();
                    libDominio.StrConexion = axVarSes.Lee<string>("strConexion");
                    libDominio.Dominio = "ALM_TIPO_INGRESO";
                    string straux = "and valor <> 0";
                    ddlTipoIngreso.DataSource = libDominio.DTVerDominio(straux);
                    ddlTipoIngreso.DataTextField = "DESCRIPCION";
                    ddlTipoIngreso.DataValueField = "VALOR";
                    ddlTipoIngreso.DataBind();
                    libProv = new BD_ALM_Proveedores();
                    libProv.StrConexion = axVarSes.Lee<string>("strConexion");
                    ddlProveedor.DataSource = libProv.dtListarProveedores();
                    ddlProveedor.DataTextField = "nombre_comercial";
                    ddlProveedor.DataValueField = "num_sec_proveedor";
                    ddlProveedor.DataBind();
                    CargarDdlGrupos();
                    CargarDdlCategorias();
                    CargarDdlItems();
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
        protected void CargarDdlGrupos()
        {
            libAlmUsu = new BD_ALM_Almacenes_Usu();
            libAlmUsu.StrConexion = axVarSes.Lee<string>("strConexion");
            string user = (axVarSes.Lee<string>("UsuarioNumSec")).ToString();
            long ns_usuario= Convert.ToInt64(user);
            libAlmUsu.NumSecUsu= ns_usuario;
            string[] stralmacenes = libAlmUsu.ObtenerAlmacenUsuario();
            libGrupo = new BD_ALM_Grupos_Items(); 
            libGrupo.StrConexion= axVarSes.Lee<string>("strConexion");
            ddlGrupo1.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo1.DataTextField = "NOMBRE";
            ddlGrupo1.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo1.DataBind();
            ddlGrupo2.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo2.DataTextField = "NOMBRE";
            ddlGrupo2.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo2.DataBind();
            ddlGrupo3.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo3.DataTextField = "NOMBRE";
            ddlGrupo3.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo3.DataBind();
            ddlGrupo4.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo4.DataTextField = "NOMBRE";
            ddlGrupo4.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo4.DataBind();
            ddlGrupo5.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo5.DataTextField = "NOMBRE";
            ddlGrupo5.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo5.DataBind();
            ddlGrupo6.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo6.DataTextField = "NOMBRE";
            ddlGrupo6.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo6.DataBind();
            ddlGrupo7.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo7.DataTextField = "NOMBRE";
            ddlGrupo7.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo7.DataBind();
            ddlGrupo8.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo8.DataTextField = "NOMBRE";
            ddlGrupo8.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo8.DataBind();
            ddlGrupo9.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo9.DataTextField = "NOMBRE";
            ddlGrupo9.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo9.DataBind();
            ddlGrupo10.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo10.DataTextField = "NOMBRE";
            ddlGrupo10.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo10.DataBind();
            ddlGrupo11.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo11.DataTextField = "NOMBRE";
            ddlGrupo11.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo11.DataBind();
            ddlGrupo12.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo12.DataTextField = "NOMBRE";
            ddlGrupo12.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo12.DataBind();
            ddlGrupo13.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo13.DataTextField = "NOMBRE";
            ddlGrupo13.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo13.DataBind();
            ddlGrupo14.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo14.DataTextField = "NOMBRE";
            ddlGrupo14.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo14.DataBind();
            ddlGrupo15.DataSource = libGrupo.DTListaGruposPorAlmacen(stralmacenes);
            ddlGrupo15.DataTextField = "NOMBRE";
            ddlGrupo15.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo15.DataBind();
        }

        protected void CargarDdlCategorias()
        {
            CargarDdlCaT1();
            CargarDdlCaT2();
            CargarDdlCaT3();
            CargarDdlCaT4();
            CargarDdlCaT5();
            CargarDdlCaT6();
            CargarDdlCaT7();
            CargarDdlCaT8();
            CargarDdlCaT9();
            CargarDdlCaT10();
            CargarDdlCaT11();
            CargarDdlCaT12();
            CargarDdlCaT13();
            CargarDdlCaT14();
            CargarDdlCaT15();
        }

        protected void CargarDdlItems()
        {
            CargarDdlItem1();
            CargarDdlItem2();
            CargarDdlItem3();
            CargarDdlItem4();
            CargarDdlItem5();
            CargarDdlItem6();
            CargarDdlItem7();
            CargarDdlItem8();
            CargarDdlItem9();
            CargarDdlItem10();
            CargarDdlItem11();
            CargarDdlItem12();
            CargarDdlItem13();
            CargarDdlItem14();
            CargarDdlItem15();
        }
        protected void CargarDdlCaT1()
        {
            if (ddlGrupo1.SelectedValue!= string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo1.SelectedValue));
                ddlCat1.DataSource = libCat.DTListaCategorias();
                ddlCat1.DataTextField = "NOMBRE";
                ddlCat1.DataValueField = "NUM_SEC_CAT";
                ddlCat1.DataBind();
            }
        }

        protected void CargarDdlCaT2()
        {
            if (ddlGrupo2.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo2.SelectedValue));
                ddlCat2.DataSource = libCat.DTListaCategorias();
                ddlCat2.DataTextField = "NOMBRE";
                ddlCat2.DataValueField = "NUM_SEC_CAT";
                ddlCat2.DataBind();
            }
        }

        protected void CargarDdlCaT3()
        {
            if (ddlGrupo3.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo3.SelectedValue));
                ddlCat3.DataSource = libCat.DTListaCategorias();
                ddlCat3.DataTextField = "NOMBRE";
                ddlCat3.DataValueField = "NUM_SEC_CAT";
                ddlCat3.DataBind();
            }
        }

        protected void CargarDdlCaT4()
        {
            if (ddlGrupo4.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo4.SelectedValue));
                ddlCat4.DataSource = libCat.DTListaCategorias();
                ddlCat4.DataTextField = "NOMBRE";
                ddlCat4.DataValueField = "NUM_SEC_CAT";
                ddlCat4.DataBind();
            }
        }

        protected void CargarDdlCaT5()
        {
            if (ddlGrupo5.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo5.SelectedValue));
                ddlCat5.DataSource = libCat.DTListaCategorias();
                ddlCat5.DataTextField = "NOMBRE";
                ddlCat5.DataValueField = "NUM_SEC_CAT";
                ddlCat5.DataBind();
            }
        }

        protected void CargarDdlCaT6()
        {
            if (ddlGrupo6.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo6.SelectedValue));
                ddlCat6.DataSource = libCat.DTListaCategorias();
                ddlCat6.DataTextField = "NOMBRE";
                ddlCat6.DataValueField = "NUM_SEC_CAT";
                ddlCat6.DataBind();
            }
        }

        protected void CargarDdlCaT7()
        {
            if (ddlGrupo7.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo7.SelectedValue));
                ddlCat7.DataSource = libCat.DTListaCategorias();
                ddlCat7.DataTextField = "NOMBRE";
                ddlCat7.DataValueField = "NUM_SEC_CAT";
                ddlCat7.DataBind();
            }
        }

        protected void CargarDdlCaT8()
        {
            if (ddlGrupo8.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo8.SelectedValue));
                ddlCat8.DataSource = libCat.DTListaCategorias();
                ddlCat8.DataTextField = "NOMBRE";
                ddlCat8.DataValueField = "NUM_SEC_CAT";
                ddlCat8.DataBind();
            }
        }

        protected void CargarDdlCaT9()
        {
            if (ddlGrupo9.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo9.SelectedValue));
                ddlCat9.DataSource = libCat.DTListaCategorias();
                ddlCat9.DataTextField = "NOMBRE";
                ddlCat9.DataValueField = "NUM_SEC_CAT";
                ddlCat9.DataBind();
            }
        }

        protected void CargarDdlCaT10()
        {
            if (ddlGrupo10.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo10.SelectedValue));
                ddlCat10.DataSource = libCat.DTListaCategorias();
                ddlCat10.DataTextField = "NOMBRE";
                ddlCat10.DataValueField = "NUM_SEC_CAT";
                ddlCat10.DataBind();
            }
        }

        protected void CargarDdlCaT11()
        {
            if (ddlGrupo11.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo11.SelectedValue));
                ddlCat11.DataSource = libCat.DTListaCategorias();
                ddlCat11.DataTextField = "NOMBRE";
                ddlCat11.DataValueField = "NUM_SEC_CAT";
                ddlCat11.DataBind();
            }
        }

        protected void CargarDdlCaT12()
        {
            if (ddlGrupo12.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo12.SelectedValue));
                ddlCat12.DataSource = libCat.DTListaCategorias();
                ddlCat12.DataTextField = "NOMBRE";
                ddlCat12.DataValueField = "NUM_SEC_CAT";
                ddlCat12.DataBind();
            }
        }

        protected void CargarDdlCaT13()
        {
            if (ddlGrupo13.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo13.SelectedValue));
                ddlCat13.DataSource = libCat.DTListaCategorias();
                ddlCat13.DataTextField = "NOMBRE";
                ddlCat13.DataValueField = "NUM_SEC_CAT";
                ddlCat13.DataBind();
            }
        }

        protected void CargarDdlCaT14()
        {
            if (ddlGrupo14.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo14.SelectedValue));
                ddlCat14.DataSource = libCat.DTListaCategorias();
                ddlCat14.DataTextField = "NOMBRE";
                ddlCat14.DataValueField = "NUM_SEC_CAT";
                ddlCat14.DataBind();
            }
        }

        protected void CargarDdlCaT15()
        {
            if (ddlGrupo15.SelectedValue != string.Empty)
            {
                libCat = new BD_ALM_Cat_Items();
                libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                libCat.NumSecGrupoItem = (Convert.ToInt64(ddlGrupo15.SelectedValue));
                ddlCat15.DataSource = libCat.DTListaCategorias();
                ddlCat15.DataTextField = "NOMBRE";
                ddlCat15.DataValueField = "NUM_SEC_CAT";
                ddlCat15.DataBind();
            }
        }
        protected void CargarDdlItem1()
        {
            if (ddlCat1.SelectedValue !=string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem1.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat1.SelectedValue));
                ddlItem1.DataTextField = "NOMBRE";
                ddlItem1.DataValueField = "NUM_SEC_ITEM";
                ddlItem1.DataBind();
            }
            else
            {
                ddlItem1.Items.Clear();
            }
        }
        protected void CargarDdlItem2()
        {
            if (ddlCat2.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem2.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat2.SelectedValue));
                ddlItem2.DataTextField = "NOMBRE";
                ddlItem2.DataValueField = "NUM_SEC_ITEM";
                ddlItem2.DataBind();
            }
            else
            {
                ddlItem2.Items.Clear();
            }
        }
        protected void CargarDdlItem3()
        {
            if (ddlCat3.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem3.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat3.SelectedValue));
                ddlItem3.DataTextField = "NOMBRE";
                ddlItem3.DataValueField = "NUM_SEC_ITEM";
                ddlItem3.DataBind();
            }
            else
            {
                ddlItem3.Items.Clear();
            }
        }
        protected void CargarDdlItem4()
        {
            if (ddlCat4.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem4.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat4.SelectedValue));
                ddlItem4.DataTextField = "NOMBRE";
                ddlItem4.DataValueField = "NUM_SEC_ITEM";
                ddlItem4.DataBind();
            }
            else
            {
                ddlItem6.Items.Clear();
            }
        }
        protected void CargarDdlItem5()
        {
            if (ddlCat5.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem5.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat5.SelectedValue));
                ddlItem5.DataTextField = "NOMBRE";
                ddlItem5.DataValueField = "NUM_SEC_ITEM";
                ddlItem5.DataBind();
            }
            else
            {
                ddlItem5.Items.Clear();
            }
        }
        protected void CargarDdlItem6()
        {
            if (ddlCat6.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem6.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat6.SelectedValue));
                ddlItem6.DataTextField = "NOMBRE";
                ddlItem6.DataValueField = "NUM_SEC_ITEM";
                ddlItem6.DataBind();
            }
            else
            {
                ddlItem6.Items.Clear();
            }
        }
        protected void CargarDdlItem7()
        {
            if (ddlCat7.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem7.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat7.SelectedValue));
                ddlItem7.DataTextField = "NOMBRE";
                ddlItem7.DataValueField = "NUM_SEC_ITEM";
                ddlItem7.DataBind();
            }
            else
            {
                ddlItem7.Items.Clear();
            }
        }
        protected void CargarDdlItem8()
        {
            if (ddlCat8.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem8.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat8.SelectedValue));
                ddlItem8.DataTextField = "NOMBRE";
                ddlItem8.DataValueField = "NUM_SEC_ITEM";
                ddlItem8.DataBind();
            }
            else
            {
                ddlItem8.Items.Clear();
            }
        }
        protected void CargarDdlItem9()
        {
            if (ddlCat9.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem9.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat9.SelectedValue));
                ddlItem9.DataTextField = "NOMBRE";
                ddlItem9.DataValueField = "NUM_SEC_ITEM";
                ddlItem9.DataBind();
            }
            else
            {
                ddlItem9.Items.Clear();
            }
        }
        protected void CargarDdlItem10()
        {
            if (ddlCat10.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem10.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat10.SelectedValue));
                ddlItem10.DataTextField = "NOMBRE";
                ddlItem10.DataValueField = "NUM_SEC_ITEM";
                ddlItem10.DataBind();
            }
            else
            {
                ddlItem10.Items.Clear();
            }
        }
        protected void CargarDdlItem11()
        {
            if (ddlCat11.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem11.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat11.SelectedValue));
                ddlItem11.DataTextField = "NOMBRE";
                ddlItem11.DataValueField = "NUM_SEC_ITEM";
                ddlItem11.DataBind();
            }
            else
            {
                ddlItem11.Items.Clear();
            }
        }
        protected void CargarDdlItem12()
        {
            if (ddlCat12.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem12.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat12.SelectedValue));
                ddlItem12.DataTextField = "NOMBRE";
                ddlItem12.DataValueField = "NUM_SEC_ITEM";
                ddlItem12.DataBind();
            }
            else
            {
                ddlItem12.Items.Clear();
            }
        }
        protected void CargarDdlItem13()
        {
            if (ddlCat13.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem13.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat13.SelectedValue));
                ddlItem13.DataTextField = "NOMBRE";
                ddlItem13.DataValueField = "NUM_SEC_ITEM";
                ddlItem13.DataBind();
            }
            else
            {
                ddlItem13.Items.Clear();
            }
        }
        protected void CargarDdlItem14()
        {
            if (ddlCat14.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem14.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat14.SelectedValue));
                ddlItem14.DataTextField = "NOMBRE";
                ddlItem14.DataValueField = "NUM_SEC_ITEM";
                ddlItem14.DataBind();
            }
            else
            {
                ddlItem14.Items.Clear();
            }
        }
        protected void CargarDdlItem15()
        {
            if (ddlCat15.SelectedValue != string.Empty)
            {
                libItem = new BD_ALM_Items();
                libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlItem15.DataSource = libItem.DTListaItems(Convert.ToInt64(ddlCat15.SelectedValue));
                ddlItem15.DataTextField = "NOMBRE";
                ddlItem15.DataValueField = "NUM_SEC_ITEM";
                ddlItem15.DataBind();
            }
            else
            {
                ddlItem15.Items.Clear();
            }
        }
        protected void VaciarBoxes()
        {
            tbPrecio1.Text = "0";
            tbPrecio2.Text = "0";
            tbPrecio3.Text = "0";
            tbPrecio4.Text = "0";
            tbPrecio5.Text = "0";
            tbPrecio6.Text = "0";
            tbPrecio7.Text = "0";
            tbPrecio8.Text = "0";
            tbPrecio9.Text = "0";
            tbPrecio10.Text = "0";
            tbPrecio11.Text = "0";
            tbPrecio12.Text = "0";
            tbPrecio13.Text = "0";
            tbPrecio14.Text = "0";
            tbPrecio15.Text = "0";
            tbFechaMov.Text = string.Empty;
            tbCodSap.Text = string.Empty;
            tbCant1.Text = "0";
            tbCant2.Text = "0";
            tbCant3.Text = "0";
            tbCant4.Text = "0";
            tbCant5.Text = "0";
            tbCant6.Text = "0";
            tbCant7.Text = "0";
            tbCant9.Text = "0";
            tbCant10.Text = "0";
            tbCant11.Text = "0";
            tbCant12.Text = "0";
            tbCant13.Text = "0";
            tbCant14.Text = "0";
            tbCant15.Text = "0";
            ddlItem1.SelectedIndex = 0;
            ddlItem2.SelectedIndex = 0;
            ddlItem3.SelectedIndex = 0;
            ddlItem4.SelectedIndex = 0;
            ddlItem5.SelectedIndex = 0;
            ddlItem6.SelectedIndex = 0;
            ddlItem7.SelectedIndex = 0;
            ddlItem8.SelectedIndex = 0;
            ddlItem9.SelectedIndex = 0;
            ddlItem10.SelectedIndex = 0;
            ddlItem11.SelectedIndex = 0;
            ddlItem12.SelectedIndex = 0;
            ddlItem13.SelectedIndex = 0;
            ddlItem14.SelectedIndex = 0;
            ddlItem15.SelectedIndex = 0;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            Panel14.Visible = false;
            Panel15.Visible = false;
            lblContador.Text = "1";
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
            string[] StrSqls = new string[60];
            int contSqls = 0;
            bool blError = false;
            if (ddlTipoIngreso.SelectedValue!="0")
            {
                libIngreso = new BD_ALM_Ingresos();
                libIngreso.StrConexion = axVarSes.Lee<string>("strConexion");
                libIngreso.NumSecIngreso = libIngreso.ObtenerNSIngreso();
                libIngreso.NumSecProveedor = Convert.ToInt64(ddlProveedor.SelectedValue);
                libIngreso.CodCompraSAP = tbCodSap.Text;
                libIngreso.Tipo = Convert.ToInt16(ddlTipoIngreso.SelectedValue);
                libIngreso.FechaIngreso = Convert.ToDateTime(tbFechaMov.Text.Trim()).ToString("dd/MM/yyyy");// tbFechaMov.Text;
                libproc.StrConexion= axVarSes.Lee<string>("strConexion"); ;
                if (libproc.FechaMenorIgualHoy(libIngreso.FechaIngreso))
                {
                    StrSqls[contSqls] = libIngreso.ObtenerCadenaInsertar();
                    contSqls++;
                    for (int i = 1; ((i <= 15) && (i <= Convert.ToInt32(lblContador.Text))); i++)
                    {
                        libIngresoMov = new BD_ALM_IngresosMov();
                        libIngresoMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libItem = new BD_ALM_Items();
                        libItem.StrConexion = axVarSes.Lee<string>("strConexion");
                        libCat = new BD_ALM_Cat_Items();
                        libCat.StrConexion = axVarSes.Lee<string>("strConexion");
                        libGrupo = new BD_ALM_Grupos_Items();
                        libGrupo.StrConexion = axVarSes.Lee<string>("strConexion");
                        libAlm = new BD_ALM_Almacenes();
                        libAlm.StrConexion = axVarSes.Lee<string>("strConexion");
                        libPlant = new BD_ALM_Plantillas();
                        libPlant.StrConexion = axVarSes.Lee<string>("strConexion");
                        libPasos = new BD_ALM_Pasos();
                        libPasos.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecPersona = Convert.ToInt64(axVarSes.Lee<string>("UsuarioPersonaNumSec"));
                        switch (i)
                        {
                            case 1:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem1.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant1.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio1.Text);
                                break;
                            case 2:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem2.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant2.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio2.Text);
                                break;
                            case 3:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem3.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant3.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio3.Text);
                                break;
                            case 4:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant4.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio4.Text);
                                break;
                            case 5:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem5.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant5.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio5.Text);
                                break;
                            case 6:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem6.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant4.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio6.Text);
                                break;
                            case 7:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant4.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio7.Text);
                                break;
                            case 8:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant8.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio8.Text);
                                break;
                            case 9:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant9.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio9.Text);
                                break;
                            case 10:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant10.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio10.Text);
                                break;
                            case 11:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant11.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio11.Text);
                                break;
                            case 12:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant12.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio12.Text);
                                break;
                            case 13:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant13.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio13.Text);
                                break;
                            case 14:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant14.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio14.Text);
                                break;
                            case 15:
                                libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                                libMov.Ingreso = Convert.ToInt32(tbCant15.Text);
                                libMov.PrecioUnitario = Convert.ToDouble(tbPrecio15.Text);
                                break;
                        }
                        if (libMov.NumSecItem>0) //evalua que no se seleccione un item nulo
                        {
                            libMov.NumSecUsuario = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
                            libMov.NumSecUsuarioRegistro = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
                            double auxprecio = libMov.PrecioUnitario;
                            libItem.NumSecItem = libMov.NumSecItem;
                            libItem.Ver();
                            libCat.NumSecCat = libItem.NumSecCat;
                            libCat.Ver();
                            libGrupo.NumSecGrupoItem = libCat.NumSecGrupoItem;
                            libGrupo.Ver();
                            libAlm.NumSecAlmacen = libGrupo.NumSecAlmacen;
                            libAlm.Ver();
                            libPlant.NumSecAlmacen = libAlm.NumSecAlmacen;
                            libPlant.TipoEgreso = 0;
                            libPlant.TipoIngreso = Convert.ToInt16(ddlTipoIngreso.SelectedValue);// definido en basde a dominios 'alm_tipo_ingreso'
                            libPlant.Ver();
                            libPasos.NumSecPlantilla = libPlant.NumSecPlantilla;
                            libPasos.VerPrimeroPlantilla();
                            libMov.NumSecPaso = libPasos.NumSecPaso;
                            libMov.NumSecMovimiento = libMov.ObtenerNSMov();
                            libMov.PrecioUnitario = auxprecio;
                            StrSqls[contSqls] = libMov.SQLCadenaMovimiento(true, false);
                            contSqls++;
                            libIngresoMov.NumSecIngreso = libIngreso.NumSecIngreso;
                            libIngresoMov.NumSecMovimiento = libMov.NumSecMovimiento;
                            StrSqls[contSqls] = libIngresoMov.ObtenerCadenaInsertar();
                            contSqls++;
                            StrSqls[contSqls] = libItem.CadenaActualizarPrecio(libMov.Ingreso, auxprecio);//actualiza precio
                            contSqls++;
                        }
                        else
                        {
                            i = 16;// sale del ciclo porque el chiclo solo evalua 15 elementos
                            blError = true;
                        }
                        
                    }
                    libMov = new BD_ALM_Movimientos();
                    libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                    if (!blError)
                    {
                        if (libMov.InsertarVarios(StrSqls, contSqls))
                        {
                            lblMensajeOK.Text = "Ingreso registrado exitosamente.";
                            pnMensajeOK.Visible = true;
                            pnMensajeError.Visible = false;
                            VaciarBoxes();
                        }
                        else
                        {
                            lblMensajeError.Text = "Error al registrar el ingreso. " + libMov.Mensaje;
                            pnMensajeError.Visible = true;
                            pnMensajeOK.Visible = false;
                        }
                    }
                    else
                    {
                        lblMensajeError.Text = "No puede registrar un item nulo. ";
                        pnMensajeError.Visible = true;
                        pnMensajeOK.Visible = false;
                    }
                    
                }
                else
                {
                    lblMensajeError.Text = "Debe ingresar una fecha menor o igual a hoy. ";
                    pnMensajeError.Visible = true;
                    pnMensajeOK.Visible = false;
                }
            }
            else
            {
                lblMensajeError.Text = "Debe indicar el tipo de ingreso. " ;
                pnMensajeError.Visible = true;
                pnMensajeOK.Visible = false;
            }
            

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            VaciarBoxes();
        }
        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(lblContador.Text.Trim());
            if(aux<15)
            {
                aux++;
            }
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
            if(aux>1)
            {
                aux--;
            }
            lblContador.Text = aux.ToString();
        }
        protected void ddlGrupo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT1();
            CargarDdlItem1();
        }
        protected void ddlGrupo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT2();
            CargarDdlItem2();
        }
        protected void ddlGrupo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT3();
            CargarDdlItem3();
        }
        protected void ddlGrupo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT4();
            CargarDdlItem4();
        }
        protected void ddlGrupo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT5();
            CargarDdlItem5();
        }
        protected void ddlGrupo6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT6();
            CargarDdlItem6();
        }
        protected void ddlGrupo7_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT7();
            CargarDdlItem7();
        }
        protected void ddlGrupo8_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT8();
            CargarDdlItem8();
        }
        protected void ddlGrupo9_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT9();
            CargarDdlItem9();
        }
        protected void ddlGrupo10_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT10();
            CargarDdlItem10();
        }
        protected void ddlGrupo11_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT11();
            CargarDdlItem11();
        }
        protected void ddlGrupo12_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT12();
            CargarDdlItem12();
        }
        protected void ddlGrupo13_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT13();
            CargarDdlItem13();
        }
        protected void ddlGrupo14_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT14();
            CargarDdlItem14();
        }
        protected void ddlGrupo15_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlCaT15();
            CargarDdlItem15();
        }

        protected void ddlCat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem1();
        }
        protected void ddlCat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem2();
        }
        protected void ddlCat3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem3();
        }
        protected void ddlCat4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem4();
        }
        protected void ddlCat5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem5();
        }
        protected void ddlCat6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem6();
        }
        protected void ddlCat7_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem7();
        }
        protected void ddlCat8_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem8();
        }
        protected void ddlCat9_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem9();
        }
        protected void ddlCat10_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem10();
        }
        protected void ddlCat11_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem11();
        }
        protected void ddlCat12_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem12();
        }
        protected void ddlCat13_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem13();
        }
        protected void ddlCat14_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem14();
        }
        protected void ddlCat15_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlItem15();
        }

        protected void ddlTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlTipoIngreso.SelectedValue) != 1)
            {
                pnCodSAP.Visible = false;
            }
            else
            {
                pnCodSAP.Visible = true;
            }
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
