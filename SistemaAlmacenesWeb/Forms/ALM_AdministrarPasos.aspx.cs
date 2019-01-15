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

       /* protected void CargarDdlSalidas()
        {
            libdom.StrConexion = axVarSes.Lee<string>("strConexion");
            libdom.Dominio = "ALM_TIPO_EGRESO";
            ddlTipoSalida.DataSource = libdom.DTVerDominio("");
            ddlTipoSalida.DataTextField = "DESCRIPCION";
            ddlTipoSalida.DataValueField = "VALOR";
            ddlTipoSalida.DataBind();
        }

        protected void CargarDdlIngresos()
        {
            libdom.StrConexion = axVarSes.Lee<string>("strConexion");
            libdom.Dominio = "ALM_TIPO_INGRESO";
            ddlTipoIngreso.DataSource = libdom.DTVerDominio("");
            ddlTipoIngreso.DataTextField = "DESCRIPCION";
            ddlTipoIngreso.DataValueField = "VALOR";
            ddlTipoIngreso.DataBind();
        }*/

        protected void CargarDdlPlantillas(bool ingreso, bool salida)
        {
            libplant.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlPlantilla.DataSource = libplant.ListarPlantillasPorTipo(ingreso, salida);
            ddlPlantilla.DataTextField = "NOMBRE";
            ddlPlantilla.DataValueField = "NUM_SEC_PLANTILLA";
            ddlPlantilla.DataBind();
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
            pnTipoIngreso.Visible = false;
        }

        protected void ddlPasos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
           /* pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;*/
        }

        protected void btnAdmUsu_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if ((ddlAlmacenes.Items.Count != 0)&&(ddlPasos.Items.Count != 0))
            {
                pnAdmUsuarios.Visible = true;
                pnPrincipal.Visible = true;
                //pnCrearAlmacen.Visible = false;
                libPasosUsu.StrConexion = axVarSes.Lee<string>("strConexion");
                libPasosUsu.NumSecPaso = Convert.ToInt64(ddlPasos.SelectedValue);
                gvDatos1.Visible = true;
                gvDatos1.Columns[0].Visible = true;
                gvDatos1.DataSource = libPasosUsu.VerUsuariosPaso();
                gvDatos1.DataBind();
                gvDatos1.Columns[0].Visible = false;
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún almacen creado";
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
            if (e.CommandName == "agregar")
            {
                libPasosUsu.NumSecUsuario = Convert.ToInt32(gvUsuarios.Rows[indice].Cells[0].Text);
                if (libPasosUsu.VerExistente())
                {

                    if (!libPasosUsu.VolverActivo())
                    {

                        pnMensajeError.Visible = true;
                        lblMensajeOK.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvUsuarios.Rows[indice].Cells[1].Text) + ". " + libPasosUsu.Mensaje; ;
                        pnMensajeOK.Visible = false;
                    }
                }
                else
                {

                    if (!libPasosUsu.Insertar())
                    {
                        pnMensajeError.Visible = true;
                        lblMensajeOK.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvUsuarios.Rows[indice].Cells[1].Text) + ". " + libPasosUsu.Mensaje; ;
                        pnMensajeOK.Visible = false;
                    }
                }

            }
            if (e.CommandName == "eliminar")
            {
                libPasosUsu.NumSecUsuario = Convert.ToInt32(gvDatos1.Rows[indice].Cells[0].Text);
                if (!libPasosUsu.VolverInactivo())
                {
                    pnMensajeError.Visible = true;
                    lblMensajeOK.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[1].Text) + ". " + libPasosUsu.Mensaje; ;
                    pnMensajeOK.Visible = false;
                }
            }
            pnMensajeError.Visible = false;
            gvDatos1.Visible = true;
            gvDatos1.Columns[0].Visible = true;
            gvDatos1.DataSource = libPasosUsu.VerUsuariosPaso();
            gvDatos1.DataBind();
            gvDatos1.Columns[0].Visible = false;

        } 
        protected void rbIngreso_Click(object sender, EventArgs e)
        {
            //pnTipoSalida.Visible = false;
            pnTipoIngreso.Visible = true;
            /*CargarDdlIngresos();
            CargarDdlSalidas();
            ddlTipoSalida.SelectedValue = 0.ToString();*/
            CargarDdlPlantillas(true, false);
        }

        protected void rbSalida_Click(object sender, EventArgs e)
        {
            pnTipoIngreso.Visible = true;
            /* pnTipoSalida.Visible = true;
             CargarDdlIngresos();
             CargarDdlSalidas();
             ddlTipoIngreso.SelectedValue = 0.ToString();*/
            CargarDdlPlantillas(false, true);
        }
        #endregion

    }
}