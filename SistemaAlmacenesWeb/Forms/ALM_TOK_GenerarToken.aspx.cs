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
    public partial class ALM_TOK_GenerarToken : System.Web.UI.Page
    {
        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        #endregion
        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Tokens libtokens = new BD_ALM_Tokens();

        #endregion
        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
            {
                Request.Browser.Adapters.Clear();
            }
            if (axVarSes.Lee<string>("strConexion") == "" || axVarSes.Lee<string>("strConexion") == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!Page.IsPostBack)
            {
                CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
            }
        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            string token = string.Empty;
            libtokens.StrConexion = axVarSes.Lee<string>("strConexion");
            token = libtokens.GenerarToken();
            if (!string.IsNullOrEmpty(token.Trim()))
            {
                BD_ALM_Tokens libtoken = new BD_ALM_Tokens();
                libtoken.StrConexion= axVarSes.Lee<string>("strConexion");
                libtoken.Token = token;
                libtoken.NumSecSubdepartamento= Convert.ToInt64(axVarSes.Lee<string>("strDeptoUsuario"));
                if ((libtoken.AnularTokenDepto())&&(libtoken.Insertar()))
                {
                    lblToken.Text = token;
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "No se pudo insertar el token. "+libtoken.Mensaje;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No se pudo generar el token.";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        #endregion
    }
}