using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


namespace SistemaAlmacenes
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
                
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["UsuarioLogin"] = "";
            Session["Servidor"] = "ucbp";
            Session["bEnviarNotificaciones"] = false;
            Session["StrConexion"] = "";
            Session["UsuarioNumSec"] = "";
            Session["strDeptoUsuario"]= "";
            Session["UsuarioPersonaNumSec"] = "";
            Session["UsuarioPersonaCI"] = "";
            Session["UsuarioPersonaNombre"] = "";
            Session["UsuarioPersonaTipo"] = "";

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("x-frame-options", "DENY");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}