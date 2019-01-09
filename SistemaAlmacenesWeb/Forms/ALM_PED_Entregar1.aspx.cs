using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsGEN_AutenticacionBD;
using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using System.Data;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_PED_Entregar1 : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_AutenticacionBD AutenticacionBD = new GEN_AutenticacionBD();
        GEN_WebForms webForms = new GEN_WebForms();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Grupos_Items libGrupo = new BD_ALM_Grupos_Items();
        BD_ALM_Cat_Items libCat = new BD_ALM_Cat_Items();
        BD_ALM_Items libItem = new BD_ALM_Items();
        BD_Personas libpersona = new BD_Personas();
        BD_ALM_Movimientos libMov = new BD_ALM_Movimientos();
        BD_ALM_Pasos libPasos = new BD_ALM_Pasos();
        BD_ALM_Almacenes_Usu libAlmUsu = new BD_ALM_Almacenes_Usu();
        BD_ALM_Almacenes libAlm = new BD_ALM_Almacenes();
        BD_ALM_Plantillas libPlant = new BD_ALM_Plantillas();
        BD_ALM_Pasos_Subdepto_usu libPasoUsu = new BD_ALM_Pasos_Subdepto_usu();
        #endregion

        #region Variable globales
        DataTable dtPedidos = new DataTable();
        #endregion

        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            libproc.StrConexion = axVarSes.Lee<string>("strConexion");
            if ((strCon != "") && (strCon != string.Empty))
            {
                if (libproc.AccesoObjetoUsuario("ALM_PED_Entregar"))
                {
                    pnPrincipal.Visible = true;
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
        protected void MostrarPedidos(string depto)
        {
            libPasoUsu = new BD_ALM_Pasos_Subdepto_usu();
            libPasoUsu.StrConexion = axVarSes.Lee<string>("strConexion");
            int [] auxpasos = libPasoUsu.VerPasosSalidaUsuario(1); //1 define dominio como pedido
            for (int i=0; i<auxpasos.Length;i++)
            {
                int pasoaux = auxpasos[i];
                int[] auxdeptos = libPasoUsu.VerDeptosPasoUsuario(pasoaux);
                for(int j=0; j<auxdeptos.Length;i++)
                {
                    if (auxdeptos[j].ToString().Equals(depto))
                    {
                        int[] aux = new int[1];
                        aux [0] = auxdeptos[j];
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        DataTable dtAux = new DataTable();
                        dtAux = libMov.DTTransaccionesPasoAnterior(pasoaux, aux);
                        gvDatos1.Visible = true;
                        gvDatos1.Columns[2].Visible = true;
                        gvDatos1.DataSource = dtAux;
                        gvDatos1.DataBind();
                        gvDatos1.Columns[2].Visible = false;
                    }
                }
                
            }
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

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "entregar")
            {
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libMov.autorizarSalida(Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text), Convert.ToInt32(gvDatos1.Rows[indice].Cells[2].Text), Convert.ToInt32(gvDatos1.Rows[indice].Cells[5].Text)))
                {
                    pnMensajeError.Visible = false;
                    Response.Redirect("ALM_PED_Entregar.aspx");
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeOK.Text = "No se pudo entregar el pedido Nro. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text)+". "+libMov.Mensaje; ;
                    pnMensajeOK.Visible = false;
                }
            }
            if (e.CommandName == "eliminar")
            {
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libMov.RechazarSalida(Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text), Convert.ToInt32(gvDatos1.Rows[indice].Cells[2].Text), Convert.ToInt32(gvDatos1.Rows[indice].Cells[5].Text)))
                {
                    pnMensajeError.Visible = false;
                    Response.Redirect("ALM_PED_Entregar.aspx");
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeOK.Text = "No se pudo eliminar el pedido Nro. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text)+libMov.Mensaje;
                    pnMensajeOK.Visible = false;
                }
            }
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            AutenticacionBD.Login = tbUsuario.Text.Trim();
            AutenticacionBD.Password = tbPassword.Text.Trim();
            AutenticacionBD.Servidor = axVarSes.Lee<string>("Servidor");
            AutenticacionBD.Pagina = this.Page;
            AutenticacionBD.MostrarError = false;
            AutenticacionBD.AutenticarSAM();
            BD_GEN_Subdeptos_Personas libSubdeptoPersona = new BD_GEN_Subdeptos_Personas();
            libSubdeptoPersona.StrConexion = axVarSes.Lee<string>("StrConexion");
            libSubdeptoPersona.Ver();
            axVarSes.Escribe("strDeptoUsuario1", libSubdeptoPersona.NumSecSubdepto.ToString());
            if (AutenticacionBD.Autenticado)
            {
                pnMensajeError.Visible = false;
                BD_ALM_Tokens libtoken = new BD_ALM_Tokens();
                libtoken.StrConexion= axVarSes.Lee<string>("StrConexion");
                libtoken.Token = tbToken.Text.ToUpper();
                libtoken.NumSecSubdepartamento = libSubdeptoPersona.NumSecSubdepto;
                if(libtoken.VerificarTokenDepto())
                {
                    pnPedidos.Visible = true;
                    pnPrincipal.Visible = false;
                    MostrarPedidos(libSubdeptoPersona.NumSecSubdepto.ToString());
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "Token incorrecto";
                    tbPassword.Text = string.Empty;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = AutenticacionBD.Mensaje;
            }
        }
        #endregion
    }
}
