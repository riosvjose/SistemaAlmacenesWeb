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
    public partial class Principal : System.Web.UI.MasterPage
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        #endregion

        #region "Procedimientos y Funciones Locales"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(axVarSes.Lee<string>("strConexion").Trim()))
            {
                Response.Redirect("~/Default.aspx");
            }            
            else
            {
                // Desplegar el SideBar de acuerdo a que modulos tiene permisos una persona
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_ALM_AdministrarAlmacenes"))
                    sbAdminAlmacenes.Visible = true;
                if (libproc.AccesoObjetoUsuario("ALM_RegistrarIngreso"))
                    sbRegIngreso.Visible = true;
                if (libproc.AccesoObjetoUsuario("ALM_MED_AdministrarMedidas"))
                    sbAdminMedidas.Visible = true;
                if (libproc.AccesoObjetoUsuario("ALM_PROV_AdministrarProveedores"))
                    sbAdminProveedores.Visible = true;
                if (libproc.AccesoObjetoUsuario("ALM_GRU_AdministrarGrupos"))
                    sbAdminGrupos.Visible = true;
                if (libproc.AccesoObjetoUsuario("ALM_CAT_AdministrarCategorias"))
                    sbAdminCategorias.Visible = true;
                if (libproc.AccesoObjetoUsuario("ALM_ITEM_AdministrarItems"))
                    sbAdminItems.Visible = true;
                //Desplegar los Collapse si una persona tiene permiso al menos a un módulo
                
                // Collapse de Pedidos
                int pedidos = 0;
                if (libproc.AccesoObjetoUsuario("ALM_PED_Realizar"))
                {
                    lnkbtnRealizarPedido.Visible = true;
                    pedidos++;
                }
                if (libproc.AccesoObjetoUsuario("ALM_PED_Autorizar"))
                {
                    lnkbtnAutorizarPedido.Visible = true;
                    pedidos++;
                }
                if (libproc.AccesoObjetoUsuario("ALM_PED_Entregar"))
                {
                    lnkbtnEntregarPedido.Visible = true;
                    pedidos++;
                }
                if (libproc.AccesoObjetoUsuario("ALM_TOK_Generar_Token"))
                {
                    lnkbtnGenerarToken.Visible = true;
                    pedidos++;
                }
                if (pedidos > 0) //Mostrar sbPedidos en caso de que el usuario tenga acceso a almenos un modulo
                    sbPedidos.Visible = true;

                //Collapse de Salidas
                int salidas = 0;
                if (libproc.AccesoObjetoUsuario("ALM_SAL_Registrar"))
                {
                    lnkbtnRegistarSalida.Visible = true;
                    salidas++;
                }
                if (libproc.AccesoObjetoUsuario("ALM_SAL_Autorizar"))
                {
                    lnkbtnAutorizarSalida.Visible = true;
                    salidas++;
                }
                if (salidas > 0)//Mostrar sbSalidas en caso de que el usuario tenga acceso a almenos un modulo
                    sbSalidas.Visible = true;

                //Collapse de Reportes
                int reportes = 0;
                if (libproc.AccesoObjetoUsuario("ALM_REP_ItemsEntregados"))
                {
                    lnkbtnReporte1.Visible = true;
                    reportes++;
                }
                if (libproc.AccesoObjetoUsuario("ALM_REP_ConsumoDepartamento"))
                {
                    lnkbtnReporte2.Visible = true;
                    reportes++;
                }
                if (libproc.AccesoObjetoUsuario("ALM_REP_Existencias"))
                {
                    lnkbtnReporte3.Visible = true;
                    reportes++;
                }
                if (reportes > 0)
                    sbReportes.Visible = true;
            }

            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
            {
                Request.Browser.Adapters.Clear();
                if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
                {
                    Request.Browser.Adapters.Clear();
                }

            }
        }
        #endregion

        #region "Procedimientos y Funciones Públicos"
        #endregion
        #region "Eventos"
        
        protected void lnkbtnAlmacen_Click(object sender, EventArgs e)
        {
           Response.Redirect("Index.aspx");
        }

        protected void lnkbtnAutorizarPedido_Click(object sender, EventArgs e)
        {
           Response.Redirect("ALM_PED_Autorizar.aspx");
        }

        protected void lnkbtnRealizarPedido_Click(object sender, EventArgs e)
        {
           Response.Redirect("ALM_PED_Realizar.aspx");
        }

        protected void lnkbtnEntregarPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_PED_Entregar1.aspx");
        }

        protected void lnkbtnGenerarToken_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_TOK_GenerarToken.aspx");
        }

        protected void lnkbtnRegistarSalida_Click(object sender, EventArgs e)
        {
           Response.Redirect("ALM_SAL_Registrar.aspx");
        }

        protected void lnkbtnAutorizarSalida_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_SAL_Autorizar.aspx");
        }

        protected void lnkbtnReporte1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_ItemsEntregados.aspx");
        }

        protected void lnkbtnReporte2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_ConsumoDepto.aspx");
        }

        protected void lnkbtnReporte3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_Existencias.aspx");
        }

        

        #endregion
    }
}