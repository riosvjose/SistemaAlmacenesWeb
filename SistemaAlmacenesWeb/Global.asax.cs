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
            Session["SubUnidad"] = "11";
            Session["NumModulo"] = "46";
            Session["UsuarioLogin"] = string.Empty;
            Session["Servidor"] = "ucbp";
            Session["bEnviarNotificaciones"] = false;
            Session["StrConexion"] = string.Empty;
            Session["UsuarioNumSec"] = 0.ToString();
            Session["strDeptoUsuario"] = string.Empty;
            Session["UsuarioPersonaNumSec"] = string.Empty;
            Session["UsuarioPersonaCI"] = string.Empty;
            Session["UsuarioPersonaNombre"] = string.Empty;
            Session["UsuarioPersonaTipo"] = string.Empty;

            Session["UsuarioNumSecAlmacen"] = 0.ToString();
            Session["NumSecItem"] = 0.ToString();
            Session["MostrarMensajeError"] = "0"; //Muestra mensaje de error cuando el usuario no tiene acceso a una funcion
            Session["DeptoSolicitante"] = "0";
            Session["NumSecUsuarioPersonaSolicitante"] = "0";
            Session["TokenSolicitante"] = string.Empty;
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