using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsBD_SAM;
using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using System.Data;
using nsGEN;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_ITEM_AdministrarPasos : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Almacenes libAlm = new BD_ALM_Almacenes();
        BD_ALM_Pasos libPasos = new BD_ALM_Pasos();
        BD_ALM_Pasos_Subdepto_usu libPasosUsu = new BD_ALM_Pasos_Subdepto_usu();
        BD_SAM_Usuarios libusu = new BD_SAM_Usuarios();
        BD_ALM_Dominios libdom = new BD_ALM_Dominios();
        BD_ALM_Plantillas libplant = new BD_ALM_Plantillas();
        BD_GEN_Subdeptos libsubdeptos = new BD_GEN_Subdeptos();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_ALM_AdministrarAlmacenes"))
                {
                    CargarDdlAlmacenes();
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
        
        protected void CargarDdlAlmacenes()
        {
            libAlm.StrConexion = axVarSes.Lee<string>("strConexion");
            // LISTAR TODOS LOS ALMACENES
            ddlAlmacenes.DataSource = libAlm.dtListarTodosAlmacenes();
            ddlAlmacenes.DataTextField = "NOMBRE";
            ddlAlmacenes.DataValueField = "NUM_SEC_ALMACEN";
            ddlAlmacenes.DataBind();
        }

       protected void CargarDdlPasos()
        {
            if (!string.IsNullOrEmpty(ddlPlantilla.SelectedValue))
            {
                libPasos.StrConexion = axVarSes.Lee<string>("strConexion");
                libPasos.NumSecPlantilla = Convert.ToInt64(ddlPlantilla.SelectedValue);
                ddlPasos.DataSource = libPasos.VerPasosPlantilla();
                ddlPasos.DataTextField = "NOMBRE";
                ddlPasos.DataValueField = "NUM_SEC_PASO";
                ddlPasos.DataBind();
            }
        }

        protected void CargarDdlPlantillas(bool ingreso, bool salida)
        {
            if (!string.IsNullOrEmpty(ddlAlmacenes.SelectedValue))
            {
                libplant.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlPlantilla.DataSource = libplant.ListarPlantillasPorTipo(ingreso, salida, ddlAlmacenes.SelectedValue);
                ddlPlantilla.DataTextField = "NOMBRE";
                ddlPlantilla.DataValueField = "NUM_SEC_PLANTILLA";
                ddlPlantilla.DataBind();
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
        protected void ddlAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnPlantilla.Visible = false;
            pnPasos.Visible = false;
            pnbuscar.Visible = false;
            pnAdmUsuarios.Visible = false;
            pnMensajeError.Visible = false;
            rbIngreso.Checked = false;
            rbSalidas.Checked = false;
        }

        protected void ddlPasos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnAdmUsuarios.Visible = false;
            pnMensajeError.Visible = false;
        }

        protected void ddlPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnPasos.Visible = true;
            CargarDdlPasos();
            pnAdmUsuarios.Visible = false;
            pnMensajeError.Visible = false;
        }

        protected void ddlDeptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            pnbuscar.Visible = true;
        }

        protected void btnAdmUsu_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if ((ddlAlmacenes.Items.Count != 0)&&(ddlPlantilla.Items.Count != 0))
            {
                pnAdmUsuarios.Visible = true;
                pnPrincipal.Visible = true;
                libPasosUsu.StrConexion = axVarSes.Lee<string>("strConexion");
                libPasosUsu.NumSecPaso = Convert.ToInt64(ddlPasos.SelectedValue);
                gvDatos1.Visible = true;
                gvDatos1.Columns[0].Visible = true;
                gvDatos1.Columns[2].Visible = true;
                gvDatos1.Columns[4].Visible = true;
                gvDatos1.DataSource = libPasosUsu.VerUsuariosPaso();
                gvDatos1.DataBind();
                gvDatos1.Columns[0].Visible = false;
                gvDatos1.Columns[2].Visible = false;
                gvDatos1.Columns[4].Visible = false;
                pnDeptos.Visible = true;
                libsubdeptos = new BD_GEN_Subdeptos();
                libsubdeptos.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlDeptos.DataSource = libsubdeptos.DTVerSubdeptos();
                ddlDeptos.DataTextField = "NOMBRE";
                ddlDeptos.DataValueField = "NUM_SEC_subdepartamento";
                ddlDeptos.DataBind();
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún almacen creado o falta seleccionar un paso. ";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnsugeridos.Visible = true;
            libusu.StrConexion = axVarSes.Lee<string>("strConexion");
            gvUsuarios.Visible = true;
            gvUsuarios.Columns[0].Visible = true;
            gvUsuarios.DataSource = libusu.ObtenerUsuariosSugeridos(tbusuario.Text.ToUpper());
            gvUsuarios.DataBind();
            gvUsuarios.Columns[0].Visible = false;
        }


        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnCancelarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_AdministrarPasos.aspx");
        }
        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            libPasosUsu = new BD_ALM_Pasos_Subdepto_usu();
            libPasosUsu.StrConexion = axVarSes.Lee<string>("strConexion");
            libPasosUsu.NumSecPaso = Convert.ToInt32(ddlPasos.SelectedValue);
            bool blOpCorrecta = false;
            if (e.CommandName == "agregar")
            {
                if (cbConfirmar.Checked)
                {
                        libPasosUsu.NumSecSubdepto = Convert.ToInt64(ddlDeptos.SelectedValue);
                        libPasosUsu.NumSecUsuario = Convert.ToInt32(gvUsuarios.Rows[indice].Cells[0].Text);
                        if (libPasosUsu.VerExistente())
                        {

                            if (!libPasosUsu.VolverActivo())
                            {

                                pnMensajeError.Visible = true;
                                lblMensajeError.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvUsuarios.Rows[indice].Cells[1].Text) + ". " + libPasosUsu.Mensaje;
                                pnMensajeOK.Visible = false;
                            }
                            else
                            {
                                blOpCorrecta = true;
                            }
                        }
                        else
                        {

                            if (!libPasosUsu.Insertar())
                            {
                                pnMensajeError.Visible = true;
                                lblMensajeError.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvUsuarios.Rows[indice].Cells[1].Text) + ". " + libPasosUsu.Mensaje;
                                pnMensajeOK.Visible = false;
                            }
                            else
                            {
                                blOpCorrecta = true;
                            }
                        }
                }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Debe confirmar la operacion. ";
                pnMensajeOK.Visible = false;
            }

            }
            if (e.CommandName == "eliminar")
            {
                libPasosUsu.NumSecUsuario = Convert.ToInt64(gvDatos1.Rows[indice].Cells[2].Text);
                libPasosUsu.NumSecSubdepto = Convert.ToInt64(gvDatos1.Rows[indice].Cells[0].Text);
                if (!libPasosUsu.VolverInactivo())
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "No se pudo eliminar el usuario. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[3].Text) + ". " + libPasosUsu.Mensaje; 
                    pnMensajeOK.Visible = false;
                }
                else
                {
                    blOpCorrecta = true;
                }
            }
            if (blOpCorrecta)
            {
                pnMensajeError.Visible = false;
            }
            else
            {
                pnVacio.Focus();
            }
            gvDatos1.Visible = true;
            gvDatos1.Columns[0].Visible = true;
            gvDatos1.DataSource = libPasosUsu.VerUsuariosPaso();
            gvDatos1.DataBind();
            gvDatos1.Columns[0].Visible = false;

        } 
        protected void rbIngreso_Click(object sender, EventArgs e)
        {
            pnPlantilla.Visible = true;
            CargarDdlPlantillas(true, false);
            pnPasos.Visible = true;
            CargarDdlPasos();
            pnAdmUsuarios.Visible = false;
        }

        protected void rbSalida_Click(object sender, EventArgs e)
        {
            pnPlantilla.Visible = true;
            CargarDdlPlantillas(false, true);
            pnPasos.Visible = true;
            CargarDdlPasos();
            pnAdmUsuarios.Visible = false;
        }

        #endregion

    }
}