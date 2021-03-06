﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using System.Drawing;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_PED_Realizar : System.Web.UI.Page
    {
        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();

        #endregion

        #region "Clases de tablas de la Base de Datos"
        BD_ALM_Grupos_Items libGrupo = new BD_ALM_Grupos_Items();
        BD_ALM_Cat_Items libCat = new BD_ALM_Cat_Items();
        BD_ALM_Items libItem = new BD_ALM_Items();
        BD_Personas libpersona = new BD_Personas();
        BD_ALM_Movimientos libMov = new BD_ALM_Movimientos();
        BD_ALM_Almacenes libAlm = new BD_ALM_Almacenes();
        BD_ALM_Plantillas libPlant = new BD_ALM_Plantillas();
        BD_ALM_Pasos libPasos = new BD_ALM_Pasos();
        BD_ALM_Dominios libDominio = new BD_ALM_Dominios();
        BD_ALM_Almacenes_Usu libAlmUsu = new BD_ALM_Almacenes_Usu();

        #endregion

        #region Variables Gobales

        #endregion
        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            libproc.StrConexion = axVarSes.Lee<string>("strConexion");
            if ((strCon != "") && (strCon != string.Empty))
            {
                if (libproc.AccesoObjetoUsuario("ALM_PED_Realizar"))
                {
                    //Cargar todos los Drop Down List
                    CargarDdlGrupos();
                    CargarDdlCategorias();
                    CargarDdlItems();
                    CargarDdlPersonas();
                    // Recibir mensaje exitoso cuando se redirige de otra pagina
                    if (Session["MensajeOK"] != null)
                    {
                        pnMensajeOK.Visible = true;
                        pnFinal.Visible = true;
                        lblMensajeOK.Text = Session["MensajeOK"].ToString();
                        Session["MensajeOK"] = null;
                        pnFinal.Focus();
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalPedidoAviso').modal('show');", true);
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
            long ns_usuario = Convert.ToInt64(user);
            libAlmUsu.NumSecUsu = ns_usuario;
            string[] stralmacenes = libAlmUsu.ObtenerAlmacenUsuario();
            libGrupo = new BD_ALM_Grupos_Items();
            libGrupo.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlGrupo1.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo1.DataTextField = "NOMBRE";
            ddlGrupo1.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo1.DataBind();
            ddlGrupo2.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo2.DataTextField = "NOMBRE";
            ddlGrupo2.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo2.DataBind();
            ddlGrupo3.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo3.DataTextField = "NOMBRE";
            ddlGrupo3.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo3.DataBind();
            ddlGrupo4.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo4.DataTextField = "NOMBRE";
            ddlGrupo4.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo4.DataBind();
            ddlGrupo5.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo5.DataTextField = "NOMBRE";
            ddlGrupo5.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo5.DataBind();
            ddlGrupo6.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo6.DataTextField = "NOMBRE";
            ddlGrupo6.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo6.DataBind();
            ddlGrupo7.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo7.DataTextField = "NOMBRE";
            ddlGrupo7.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo7.DataBind();
            ddlGrupo8.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo8.DataTextField = "NOMBRE";
            ddlGrupo8.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo8.DataBind();
            ddlGrupo9.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo9.DataTextField = "NOMBRE";
            ddlGrupo9.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo9.DataBind();
            ddlGrupo10.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo10.DataTextField = "NOMBRE";
            ddlGrupo10.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo10.DataBind();
            ddlGrupo11.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo11.DataTextField = "NOMBRE";
            ddlGrupo11.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo11.DataBind();
            ddlGrupo12.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo12.DataTextField = "NOMBRE";
            ddlGrupo12.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo12.DataBind();
            ddlGrupo13.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo13.DataTextField = "NOMBRE";
            ddlGrupo13.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo13.DataBind();
            ddlGrupo14.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo14.DataTextField = "NOMBRE";
            ddlGrupo14.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo14.DataBind();
            ddlGrupo15.DataSource = libGrupo.DTListaGruposPorDepto();
            ddlGrupo15.DataTextField = "NOMBRE";
            ddlGrupo15.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupo15.DataBind();
        }

        protected void CargarDdlPersonas()
        {
            libpersona = new BD_Personas();
            libpersona.StrConexion = axVarSes.Lee<string>("strConexion");
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
            if (ddlGrupo1.SelectedValue != string.Empty)
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
            if (ddlCat1.SelectedValue != string.Empty)
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
            ddlGrupo1.SelectedIndex = 0;
            ddlGrupo2.SelectedIndex = 0;
            ddlGrupo3.SelectedIndex = 0;
            ddlGrupo4.SelectedIndex = 0;
            ddlGrupo5.SelectedIndex = 0;
            ddlGrupo6.SelectedIndex = 0;
            ddlGrupo7.SelectedIndex = 0;
            ddlGrupo8.SelectedIndex = 0;
            ddlGrupo9.SelectedIndex = 0;
            ddlGrupo10.SelectedIndex = 0;
            ddlGrupo11.SelectedIndex = 0;
            ddlGrupo12.SelectedIndex = 0;
            ddlGrupo13.SelectedIndex = 0;
            ddlGrupo14.SelectedIndex = 0;
            ddlGrupo15.SelectedIndex = 0;
            ddlSolicitante1.SelectedIndex = 0;
            ddlSolicitante2.SelectedIndex = 0;
            ddlSolicitante3.SelectedIndex = 0;
            ddlSolicitante4.SelectedIndex = 0;
            ddlSolicitante5.SelectedIndex = 0;
            ddlSolicitante6.SelectedIndex = 0;
            ddlSolicitante7.SelectedIndex = 0;
            ddlSolicitante8.SelectedIndex = 0;
            ddlSolicitante9.SelectedIndex = 0;
            ddlSolicitante10.SelectedIndex = 0;
            ddlSolicitante11.SelectedIndex = 0;
            ddlSolicitante12.SelectedIndex = 0;
            ddlSolicitante13.SelectedIndex = 0;
            ddlSolicitante14.SelectedIndex = 0;
            ddlSolicitante15.SelectedIndex = 0;
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

            //Limpiar las Categorias
            ddlCat1.Items.Clear();
            ddlCat2.Items.Clear();
            ddlCat3.Items.Clear();
            ddlCat4.Items.Clear();
            ddlCat5.Items.Clear();
            ddlCat6.Items.Clear();
            ddlCat7.Items.Clear();
            ddlCat8.Items.Clear();
            ddlCat9.Items.Clear();
            ddlCat10.Items.Clear();
            ddlCat11.Items.Clear();
            ddlCat12.Items.Clear();
            ddlCat13.Items.Clear();
            ddlCat14.Items.Clear();
            ddlCat15.Items.Clear();
            //Limpiar los items
            ddlItem1.Items.Clear();
            ddlItem2.Items.Clear();
            ddlItem3.Items.Clear();
            ddlItem4.Items.Clear();
            ddlItem5.Items.Clear();
            ddlItem6.Items.Clear();
            ddlItem7.Items.Clear();
            ddlItem8.Items.Clear();
            ddlItem9.Items.Clear();
            ddlItem10.Items.Clear();
            ddlItem11.Items.Clear();
            ddlItem12.Items.Clear();
            ddlItem13.Items.Clear();
            ddlItem14.Items.Clear();
            ddlItem15.Items.Clear();
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
            //Response.Redirect("#");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string[] StrSqls = new string[30];
            int contSqls = 0;
            bool mayorQueExistencia = false, blError = false;
            string item = string.Empty;
            int cantmaxItem1 = 0;
            int cantmaxItem2 = 0;
            int cantmaxItem3 = 0;
            int cantmaxItem4 = 0;
            int cantmaxItem5 = 0;
            int cantmaxItem6 = 0;
            int cantmaxItem7 = 0;
            int cantmaxItem8 = 0;
            int cantmaxItem9 = 0;
            int cantmaxItem10 = 0;
            int cantmaxItem11 = 0;
            int cantmaxItem12 = 0;
            int cantmaxItem13 = 0;
            int cantmaxItem14 = 0;
            int cantmaxItem15 = 0;
            for (int i = 1; ((i <= 15) && (i <= Convert.ToInt32(lblContador.Text))); i++)
            {
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
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                switch (i)
                {
                    case 1:
                        cantmaxItem1 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem1.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem1.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante1.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant1.Text);
                        if (Convert.ToInt32(tbCant1.Text) > cantmaxItem1) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem1.SelectedItem.Text;
                        }
                        break;
                    case 2:
                        cantmaxItem2 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem2.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem2.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante2.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant2.Text);
                        if (Convert.ToInt32(tbCant2.Text) > cantmaxItem2) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem2.SelectedItem.Text;
                        }
                        break;
                    case 3:
                        cantmaxItem3 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem3.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem3.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante3.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant3.Text);
                        if (Convert.ToInt32(tbCant3.Text) > cantmaxItem3) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem3.SelectedItem.Text;
                        }
                        break;
                    case 4:
                        cantmaxItem4 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem4.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante4.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant4.Text);
                        if (Convert.ToInt32(tbCant4.Text) > cantmaxItem4) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem4.SelectedItem.Text;
                        }
                        break;
                    case 5:
                        cantmaxItem5 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem5.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem5.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante5.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant5.Text);
                        if (Convert.ToInt32(tbCant5.Text) > cantmaxItem5) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem5.SelectedItem.Text;
                        }
                        break;
                    case 6:
                        cantmaxItem6 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem6.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem6.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante6.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant4.Text);
                        if (Convert.ToInt32(tbCant6.Text) > cantmaxItem6) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem6.SelectedItem.Text;
                        }
                        break;
                    case 7:
                        cantmaxItem7 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem7.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante7.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant4.Text);
                        if (Convert.ToInt32(tbCant7.Text) > cantmaxItem7) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem7.SelectedItem.Text;
                        }
                        break;
                    case 8:
                        cantmaxItem8 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem8.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante8.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant8.Text);
                        if (Convert.ToInt32(tbCant8.Text) > cantmaxItem8) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem8.SelectedItem.Text;
                        }
                        break;
                    case 9:
                        cantmaxItem9 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem9.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante9.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant9.Text);
                        if (Convert.ToInt32(tbCant9.Text) > cantmaxItem9) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem9.SelectedItem.Text;
                        }
                        break;
                    case 10:
                        cantmaxItem10 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem10.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante10.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant10.Text);
                        if (Convert.ToInt32(tbCant10.Text) > cantmaxItem10) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem10.SelectedItem.Text;
                        }
                        break;
                    case 11:
                        cantmaxItem11 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem11.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante11.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant11.Text);
                        if (Convert.ToInt32(tbCant11.Text) > cantmaxItem11) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem11.SelectedItem.Text;
                        }
                        break;
                    case 12:
                        cantmaxItem12 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem12.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante12.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant12.Text);
                        if (Convert.ToInt32(tbCant12.Text) > cantmaxItem12) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem12.SelectedItem.Text;
                        }
                        break;
                    case 13:
                        cantmaxItem13 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem13.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante13.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant13.Text);
                        if (Convert.ToInt32(tbCant13.Text) > cantmaxItem13) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem13.SelectedItem.Text;
                        }
                        break;
                    case 14:
                        cantmaxItem14 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem14.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante14.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant14.Text);
                        if (Convert.ToInt32(tbCant14.Text) > cantmaxItem14) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem14.SelectedItem.Text;
                        }
                        break;
                    case 15:
                        cantmaxItem15 = libMov.ObtenerExistenciasItem(Convert.ToInt64(ddlItem15.SelectedValue));
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        libMov.NumSecItem = Convert.ToInt64(ddlItem4.SelectedValue);
                        libMov.NumSecPersona = Convert.ToInt64(ddlSolicitante15.SelectedValue);
                        libMov.Egreso = Convert.ToInt32(tbCant15.Text);
                        if (Convert.ToInt32(tbCant15.Text) > cantmaxItem15) // verifica si se pide mas de las existencias
                        {
                            mayorQueExistencia = true;
                            item = ddlItem15.SelectedItem.Text;
                        }
                        break;
                }
                if (libMov.NumSecItem > 0) //evalua que no se seleccione un item nulo
                {
                    if (mayorQueExistencia)
                    {
                        pnMensajeOK.Visible = false;
                        pnMensajeError.Visible = true;
                        pnFinal.Visible = true;
                        lblMensajeError.Text = "La cantidad del articulo " + item + " no esta disponible. Intente solicitando una cantidad menor. ";
                        pnFinal.Focus();
                        i = 16;// Para salir del ciclo
                    }
                    else
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
                        libPlant.TipoEgreso = 1;
                        libPlant.TipoIngreso = 0;
                        libPlant.Ver();
                        libPasos.NumSecPlantilla = libPlant.NumSecPlantilla;
                        libPasos.VerPrimeroPlantilla();
                        libMov.NumSecPaso = libPasos.NumSecPaso;
                        libMov.NumSecMovimiento = libMov.ObtenerNSMov();
                        StrSqls[contSqls] = libMov.SQLCadenaMovimiento(false, true);
                        contSqls++;
                    }
                }
                else
                {
                    i = 16;// sale del ciclo porque el chiclo solo evalua 15 elementos
                    blError = true;
                }
            }
            if (!blError)
            {
                if (!mayorQueExistencia)
                {
                    libMov = new BD_ALM_Movimientos();
                    libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                    if (libMov.InsertarVarios(StrSqls, contSqls))
                    {
                        pnMensajeError.Visible = false;
                        pnMensajeOK.Visible = true;
                        pnFinal.Visible = true;
                        lblMensajeOK.Text = "Pedido registrado exitosamente.";                        
                        VaciarBoxes();
                        //Desplegar un mensaje en un modal
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalPedidoAviso').modal('show');", true);
                        pnFinal.Focus();
                    }
                    else
                    {
                        pnMensajeError.Visible = true;
                        pnMensajeOK.Visible = false;
                        pnFinal.Visible = true;
                        lblMensajeError.Text = "Error al registrar el pedido." + libMov.Mensaje;
                        pnFinal.Focus();
                    }
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                pnMensajeOK.Visible = false;
                pnFinal.Visible = true;
                lblMensajeError.Text = "No puede registrar un item nulo.";
                pnFinal.Focus();
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_PED_Realizar.aspx");
        }
        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(lblContador.Text.Trim());
            if (aux<15)
            {
                aux++;
            }
            lblContador.Text = aux.ToString();
            switch (aux)
            {
                case 2:
                    Panel2.Visible = true;
                    btnQuitarItem.Enabled = true; //Cuando queda solo un panel para hacer ingresos se Habilita el Boton QuitarItem.
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
                    btnAgregarItem.Enabled = false; //Se des-habilita el Boton AgregarItem
                    break;
            }
        }
        protected void btnQuitarItem_Click(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(lblContador.Text.Trim());
            btnAgregarItem.Enabled = true; //Se habilita el Boton AgregarItem, cuando se quita un item
            switch (aux)
            {
                case 2:
                    Panel2.Visible = false;
                    btnQuitarItem.Enabled = false; //Cuando queda solo un panel para hacer ingresos se des-habilita el Boton QuitarItem.
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
            if (aux>1)
            {
                aux--;
            }
            lblContador.Text = aux.ToString();
        }
        protected void ddlTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void ddlPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem13_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlItem15_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void tbCambioValor_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
