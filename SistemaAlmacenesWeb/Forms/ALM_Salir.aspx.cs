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
    public partial class ALM_Salir : System.Web.UI.Page
    {

        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            axVarSes.Escribe("strUsuario", "");
            axVarSes.Escribe("strPassword", "");
            axVarSes.Escribe("strConexion", "");
            axVarSes.Escribe("UsuarioPersonaNumSec", "");
            Response.Write(@"<script language='javascript'>window.close();</script>");
            Response.Redirect("~/Default.aspx");
        }
    }
}