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
    public partial class Principal : System.Web.UI.MasterPage
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();

        #endregion
        #region "Procedimientos y Funciones Locales"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (axVarSes.Lee<string>("strConexion") == "" || axVarSes.Lee<string>("strConexion") == null)
            {
                Response.Redirect("~/Default.aspx");
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
           Response.Redirect("PED_Autorizar.aspx");
        }

        protected void lnkbtnRealizarPedido_Click(object sender, EventArgs e)
        {
           Response.Redirect("PED_Realizar.aspx");
        }

        protected void lnkbtnRegistarSalida_Click(object sender, EventArgs e)
        {
           Response.Redirect("SAL_Registrar.aspx");
        }

        protected void lnkbtnAutorizarSalida_Click(object sender, EventArgs e)
        {
            Response.Redirect("SAL_Autorizar.aspx");
        }

        protected void lnkbtnCrearMarca_Click(object sender, EventArgs e)
        {
            //Response.Redirect("STRS_PROY_Administrar.aspx");
        }

        protected void lnkbtnEliminarMarca_Click(object sender, EventArgs e)
        {
            //Response.Redirect("STRS_PROY_RegistrarAvanceEvento.aspx");
        }

        protected void lnkbtnReporte1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("STRS_PROY_RegistrarAvanceEvento.aspx");
        }

        protected void lnkbtnReporte2_Click(object sender, EventArgs e)
        {
            //Response.Redirect("STRS_PROY_RegistrarAvanceEvento.aspx");
        }

        protected void lnkbtnReporte3_Click(object sender, EventArgs e)
        {
            //Response.Redirect("STRS_PROY_RegistrarAvanceEvento.aspx");
        }

        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_Salir.aspx");
        }
        #endregion
    }
}