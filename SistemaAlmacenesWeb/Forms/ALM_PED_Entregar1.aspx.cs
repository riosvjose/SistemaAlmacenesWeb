﻿using System;
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
        BD_ALM_Tokens libtoken = new BD_ALM_Tokens();
        #endregion

        #region Variable globales
        DataTable dtPedidos = new DataTable();
        #endregion

        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            libproc.StrConexion = axVarSes.Lee<string>("strConexion");
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                if (libproc.AccesoObjetoUsuario("ALM_PED_Entregar"))
                {
                    if ((!string.IsNullOrEmpty(axVarSes.Lee<string>("DeptoSolicitante")))&&((!string.IsNullOrEmpty(axVarSes.Lee<string>("NumSecUsuarioPersonaSolicitante")))) &&((!string.IsNullOrEmpty(axVarSes.Lee<string>("TokenSolicitante")))))
                    {
                        pnPedidos.Visible = true;
                        pnPrincipal.Visible = false;
                        MostrarPedidos(axVarSes.Lee<string>("DeptoSolicitante"));
                    }
                    else
                    {
                        pnPrincipal.Visible = true;
                    }
                    
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
                for(int j=0; j<auxdeptos.Length;j++)
                {
                    if (auxdeptos[j].ToString().Equals(depto))
                    {
                        int[] aux = new int[1];
                        aux [0] = auxdeptos[j];
                        libMov = new BD_ALM_Movimientos();
                        libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                        DataTable dtAux = new DataTable();
                        dtAux = libMov.DTTransaccionesPasoAnterior(pasoaux, aux);
                        dtPedidos = new DataTable();
                        dtPedidos.Merge(dtAux);
                        gvDatos1.Visible = true;
                        gvDatos1.Columns[2].Visible = true;
                        gvDatos1.DataSource = dtPedidos;
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
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_PED_Buscar.aspx");
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "eliminar")
            {
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libMov.RechazarSalida(Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text), Convert.ToInt32(gvDatos1.Rows[indice].Cells[2].Text), Convert.ToInt32(gvDatos1.Rows[indice].Cells[5].Text)))
                {
                    pnMensajeError.Visible = false;
                    Response.Redirect("ALM_PED_Entregar1.aspx");
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeOK.Text = "No se pudo eliminar el pedido Nro. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text)+libMov.Mensaje;
                    pnMensajeOK.Visible = false;
                }
            }
        }
        protected void btnEntregar_Click(object sender, EventArgs e)
        {
            if (gvDatos1.Rows.Count>0)
            {
                libPasoUsu = new BD_ALM_Pasos_Subdepto_usu();
                libPasoUsu.StrConexion = axVarSes.Lee<string>("strConexion");
                int[] auxpasos = libPasoUsu.VerPasosSalidaUsuario(1); //1 define dominio como pedido
                DataTable dtAux = new DataTable();
                for (int i = 0; i < auxpasos.Length; i++)
                {
                    int pasoaux = auxpasos[i];
                    int[] auxdeptos = libPasoUsu.VerDeptosPasoUsuario(pasoaux);
                    for (int j = 0; j < auxdeptos.Length; j++)
                    {
                        if (auxdeptos[j].ToString().Equals(axVarSes.Lee<string>("DeptoSolicitante")))
                        {
                            int[] aux = new int[1];
                            aux[0] = auxdeptos[j];
                            libMov = new BD_ALM_Movimientos();
                            libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                            dtAux = libMov.DTTransaccionesPasoAnterior(pasoaux, aux);
                        }
                    }
                }
                libMov = new BD_ALM_Movimientos();
                libMov.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libMov.EntregarVariasSalidas(dtAux, tbToken.Text))
                {
                    pnMensajeError.Visible = false;
                    libtoken.StrConexion = axVarSes.Lee<string>("strConexion");
                    libtoken.NumSecSubdepartamento = Convert.ToInt64(axVarSes.Lee<string>("DeptoSolicitante"));
                    libtoken.AnularTokenDepto();
                    axVarSes.Escribe("DeptoSolicitante", string.Empty);
                    axVarSes.Escribe("TokenSolicitante", string.Empty);
                    axVarSes.Escribe("NumSecUsuariosSolicitante", string.Empty);
                    axVarSes.Escribe("Mensaje", "Pedido entregado, los datos se almacenaron con éxito.");
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "No se pudo registrar la entrega de pedidos. " + libMov.Mensaje; ;
                    pnMensajeOK.Visible = false;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existen items para entregar. " ;
                pnMensajeOK.Visible = false;
            }
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (rbAdmin.Checked)
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
                axVarSes.Escribe("NumSecUsuarioPersonaSolicitante", AutenticacionBD.Persona_NumSec.ToString());
                if (AutenticacionBD.Autenticado)
                {
                    pnMensajeError.Visible = false;
                    BD_ALM_Tokens libtoken = new BD_ALM_Tokens();
                    libtoken.StrConexion = axVarSes.Lee<string>("StrConexion");
                    libtoken.Token = tbToken.Text.ToUpper();
                    libtoken.NumSecSubdepartamento = libSubdeptoPersona.NumSecSubdepto;
                    if (libtoken.VerificarTokenDepto())
                    {
                        pnPedidos.Visible = true;
                        pnPrincipal.Visible = false;
                        axVarSes.Escribe("DeptoSolicitante", libSubdeptoPersona.NumSecSubdepto.ToString());
                        axVarSes.Escribe("TokenSolicitante", tbToken.Text);
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
            else if (rbAsistente.Checked)
            {
                BD_ProcAdicionales libAdicionales = new BD_ProcAdicionales();
                libAdicionales.StrConexion= axVarSes.Lee<string>("StrConexion");
                if (libAdicionales.VerificarPassword(tbUsuario.Text.Trim(), tbPassword.Text.Trim()))
                {
                    BD_ALM_Tokens libtoken = new BD_ALM_Tokens();
                    libtoken.StrConexion = axVarSes.Lee<string>("StrConexion");
                    libtoken.Token = tbToken.Text.ToUpper();
                    libtoken.Ver();
                    pnPedidos.Visible = true;
                    pnPrincipal.Visible = false;
                    libpersona.StrConexion = axVarSes.Lee<string>("StrConexion");
                    libpersona.VerPorCI(tbUsuario.Text.Trim());
                    axVarSes.Escribe("NumSecUsuarioPersonaSolicitante", libpersona.NumSec.ToString());
                    axVarSes.Escribe("DeptoSolicitante", libtoken.NumSecSubdepartamento.ToString());
                    axVarSes.Escribe("TokenSolicitante", tbToken.Text);
                    MostrarPedidos(libtoken.NumSecSubdepartamento.ToString());
                    pnMensajeError.Visible = false;
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "Usuario o contraseña incorrectos.";
                }
            }
        }
        protected void rb_Click(object sender, EventArgs e)
        {

        }

            #endregion
        }
    }
