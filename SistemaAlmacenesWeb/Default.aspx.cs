using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_Java;
using nsGEN_VarSession;
using nsGEN_WebForms;
using nsGEN_AutenticacionBD;
using System.Data;
using nsBD_SAM;

namespace SistemaAlmacenesWeb
{
    public partial class Default : System.Web.UI.Page
    {

        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        GEN_AutenticacionBD AutenticacionBD = new GEN_AutenticacionBD();

        #endregion

        #region "Clase de tablas de la Base de Datos"

        BD_SAM_Parametros_Modulos ParametrosModulos = new BD_SAM_Parametros_Modulos();
        BD_SAM_Parametros_Personas ParametrosPersonas = new BD_SAM_Parametros_Personas();
        BD_SAM_Usuarios_Subdeptos UsuariosSubdeptos = new BD_SAM_Usuarios_Subdeptos();

        #endregion

        #region "Variables Globales"

        string strConexion = string.Empty;
        string strSql = string.Empty;

        #endregion

        #region "Funciones y Procedimientos"

        private void Revisar_Permisos_Operacion(string NSPersona, string NSModulo, string NSUsuario, string NSSubUnidad, string strCon)
        {
            DataTable dt;
            string SubDeptos = string.Empty;

            ParametrosPersonas.StrConexion = strCon;
            ParametrosPersonas.NumSecPersona = Convert.ToInt64(NSPersona);
            dt = ParametrosPersonas.DTParametrosPersonaPorModulo(NSModulo);
            axVarSes.Escribe("ax_Num_Sec_Semestre_AHP", "0");
            axVarSes.Escribe("axModalidad_Operacion_Sistema", Convert.ToInt16("0"));
            axVarSes.Escribe("axPermitir_insc_otros_deptos", Convert.ToInt16("0"));
            axVarSes.Escribe("axPermitir_insc_nuevos", Convert.ToInt16("0"));
            axVarSes.Escribe("axPermitir_todos_deptos", Convert.ToInt16("0"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["codigo"].ToString().Trim())
                {
                    case "8012": // Semestre habilitado para habandono parcial
                        axVarSes.Escribe("ax_Num_Sec_Semestre_AHP", dt.Rows[i]["valor"].ToString().Trim());
                        break;
                    case "8015": // Modalidad Operacion Sistema
                        axVarSes.Escribe("axModalidad_Operacion_Sistema", Convert.ToInt16(dt.Rows[i]["valor"].ToString().Trim()));
                        break;
                    case "8016": // Permitir inscribir en materias de otros departamentos
                        axVarSes.Escribe("axPermitir_insc_otros_deptos", Convert.ToInt16(dt.Rows[i]["valor"].ToString().Trim()));
                        break;
                    case "8017": // Permitir inscribir estudiantes nuevos
                        axVarSes.Escribe("axPermitir_insc_nuevos", Convert.ToInt16(dt.Rows[i]["valor"].ToString().Trim()));
                        break;
                    case "8018": // Permitir acceso a todos los departamentos académicos
                        axVarSes.Escribe("axPermitir_todos_deptos", Convert.ToInt16(dt.Rows[i]["valor"].ToString().Trim()));
                        break;  

                }
            }
            UsuariosSubdeptos.StrConexion = strCon;
            dt = UsuariosSubdeptos.DTUsuarioSubSeptos(NSUsuario, NSSubUnidad);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                    SubDeptos += dt.Rows[i]["num_sec_subdepartamento"].ToString().Trim();
                else
                    SubDeptos += ", " + dt.Rows[i]["num_sec_subdepartamento"].ToString().Trim();

            }
            axVarSes.Escribe("usuario_carreras", SubDeptos);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
                Request.Browser.Adapters.Clear();
            if (Page.IsPostBack == false)
            {
                axVarSes.Escribe("strMensaje_Inicial_Pagina", string.Empty);
                tbUsuario.Focus();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            AutenticacionBD.Login = tbUsuario.Text.Trim();
            AutenticacionBD.Password = tbPassword.Text.Trim();
            AutenticacionBD.Servidor = axVarSes.Lee<string>("Servidor");
            AutenticacionBD.Pagina = this.Page;
            AutenticacionBD.MostrarError = false;
            AutenticacionBD.AutenticarSAM();

            axVarSes.Escribe("Servidor", axVarSes.Lee<string>("Servidor"));
            axVarSes.Escribe("StrConexion", AutenticacionBD.StrConexion);
            axVarSes.Escribe("UsuarioNumSec", AutenticacionBD.NumSec.ToString());
            axVarSes.Escribe("UsuarioLogin", AutenticacionBD.Login);
            axVarSes.Escribe("UsuarioCarrera", string.Empty);
            axVarSes.Escribe("UsuarioFacultad", string.Empty);
            axVarSes.Escribe("UsuarioPerfil", "0");
            axVarSes.Escribe("UsuarioPersonaNumSec", AutenticacionBD.Persona_NumSec.ToString());
            axVarSes.Escribe("UsuarioPersonaCI", AutenticacionBD.Persona_CI);
            axVarSes.Escribe("UsuarioPersonaNombre", AutenticacionBD.Persona_Nombre);
            axVarSes.Escribe("UsuarioPersonaTipo", AutenticacionBD.Persona_Tipo.ToString());
            axVarSes.Escribe("usuario_persona_grupo", AutenticacionBD.Persona_Grupo.ToString());
            axVarSes.Escribe("ax_Permitir_Manuales_Todos", "1");
            axVarSes.Escribe("UsuarioNumSecAlmacen", "0");
            axVarSes.Escribe("NumSecItem", "0");
            BD_GEN_Subdeptos_Personas libSubdeptoPersona = new BD_GEN_Subdeptos_Personas();
            libSubdeptoPersona.StrConexion = axVarSes.Lee<string>("StrConexion");
            libSubdeptoPersona.Ver();
            axVarSes.Escribe("strDeptoUsuario", libSubdeptoPersona.NumSecSubdepto.ToString());
            if (AutenticacionBD.Autenticado)
            {
                lblMensaje.Visible = false;
                axVarSes.Escribe("Path", webForms.Determinar_Path_App());

                //if (AutenticacionBD.CambioPwd)
                //{
                //    axVarSes.Escribe("UsuarioLogin", "");
                //    axVarSes.Escribe("usuario_login_cambiopwd", AutenticacionBD.Login);
                //    Response.Redirect("~/Forms/SACAD_CambioPassword.aspx");
                //}
                //else
               // {
                    //AutenticacionBD.AutenticarADMSINF();
                    axVarSes.Escribe("UsuarioCodigo", AutenticacionBD.CodigoUsuario);
                    //Revisar_Permisos_Operacion(AutenticacionBD.Persona_NumSec.ToString(),axVarSes.Lee<string>("modulo_ns"), axVarSes.Lee<string>("UsuarioNumSec"), axVarSes.Lee<string>("subunidad_ns"), axVarSes.Lee<string>("strConexion"));
                    Response.Redirect("~/Forms/Index.aspx");
                //}
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = AutenticacionBD.Mensaje;
            }
        }
    }
}