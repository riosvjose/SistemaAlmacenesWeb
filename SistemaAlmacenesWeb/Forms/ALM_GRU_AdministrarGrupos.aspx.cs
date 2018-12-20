using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using System.Data;
using nsGEN;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_GRU_AdministrarGrupos : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Grupos_Items ALMGruposItems = new BD_ALM_Grupos_Items();
        BD_ALM_Almacenes ALMAlmacenes = new BD_ALM_Almacenes();
        #endregion

        #region "Variable local"
        static bool Almacenes = false;
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                ALMGruposItems.StrConexion = axVarSes.Lee<string>("strConexion");
                // Listar a todos los Grupos de Items
                ddlGrupoItems.DataSource = ALMGruposItems.DTListaGrupos();
                ddlGrupoItems.DataTextField = "NOMBRE";
                ddlGrupoItems.DataValueField = "NUM_SEC_GRUPO";
                ddlGrupoItems.DataBind();

                ALMAlmacenes.StrConexion = axVarSes.Lee<string>("strConexion");
                // Listar todos los almacenes
                ddlAlmacenItem.DataSource = ALMAlmacenes.dtListarAlmacenes();
                ddlAlmacenItem.DataTextField = "NOMBRE";
                ddlAlmacenItem.DataValueField = "NUM_SEC_ALMACEN";
                ddlAlmacenItem.DataBind();
                // Listar todos los almacenes al editar
                ddlEditarAlmacen.DataSource = ALMAlmacenes.dtListarAlmacenes();
                ddlEditarAlmacen.DataTextField = "NOMBRE";
                ddlEditarAlmacen.DataValueField = "NUM_SEC_ALMACEN";
                ddlEditarAlmacen.DataBind();
                // Determinar si una persona tiene acceso a uno o a mas almacenes
                if (ALMAlmacenes.dtListarAlmacenes().Rows.Count == 1) //Ver si el usuario tiene solo 1 almacen asignado
                {
                    Almacenes = true;
                    DataRow dr = ALMAlmacenes.dtListarAlmacenes().Rows[0];
                    axVarSes.Escribe("UsuarioNumSecAlmacen", Convert.ToInt64(dr["NUM_SEC_ALMACEN"].ToString()));
                }

                // Recibir mensaje exitoso cuando se redirige de otra pagina
                if (Session["MensajeOK"] != null)
                {
                    pnMensajeOK.Visible = true;
                    lblMensajeOK.Text = Session["MensajeOK"].ToString();
                    Session["MensajeOK"] = null;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
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

        protected void ddlGrupoItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearGrupoItem.Visible = true;
            lblFormGrupoItem.Text = "Crear Grupo de Items";
            pnEditarGrupoItem.Visible = false;
            if (Almacenes == false)
            {
                idAlmacenItem.Visible = true;
            }
        }

        protected void btnEditarGrupo_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;          
            if (ddlGrupoItems.Items.Count != 0)
            {
                pnPrincipal.Visible = false;
                pnCrearGrupoItem.Visible = false;
                lblEditarGrupoItem.Text = "Editar Grupo de Items";
                pnEditarGrupoItem.Visible = true;
                //BD_ALM_Grupos_Items
                ALMGruposItems.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMGruposItems.NumSecGrupoItem = Convert.ToInt64(ddlGrupoItems.Text.Trim()); // Obtener el NUM_SEC_GRUPO (id del Grupo de Item)
                if (ALMGruposItems.Ver())
                {
                    tbEditarNombreGrupoItem.Text = ALMGruposItems.Nombre.Trim();
                    ddlEditarAlmacen.SelectedValue = ALMGruposItems.NumSecAlmacen.ToString();
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "Mensaje: " + ALMGruposItems.Mensaje;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún Grupo de Items creado";
            }
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGuardarGrupoItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            //Validar que el DDL no este vacio
            if (ddlAlmacenItem.Items.Count != 0)
            {
                ALMGruposItems.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMGruposItems.Nombre = tbNombreGrupoItem.Text.ToUpper().Trim();
                if(Almacenes == true)
                {
                    ALMGruposItems.NumSecAlmacen = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSecAlmacen"));                    
                }
                else
                {
                    ALMGruposItems.NumSecAlmacen = Convert.ToInt64(ddlAlmacenItem.Text.Trim()); // Obtener el NUM_SEC_ALMACEN (id del Almacen)
                }
                if (ALMGruposItems.Insertar())
                {
                    Session["MensajeOK"] = "El grupo de Item fue creado exitosamente";
                    Response.Redirect("ALM_GRU_AdministrarGrupos.aspx");
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "Mensaje: " + ALMGruposItems.Mensaje;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún Almacén creado"; //O tambien puede ser que una persona no cuente con "permisos" para acceder a ningun almacen
            }            
        }

        protected void btnCancelarGrupoItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_GRU_AdministrarGrupos.aspx");
        }

        protected void btnEditarGuardarGrupoItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            //BD_ALM_Grupos_Items
            ALMGruposItems.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMGruposItems.NumSecGrupoItem = Convert.ToInt64(ddlGrupoItems.Text.Trim()); // Obtener el NUM_SEC_GRUPO (id del Grupo de Item)
            ALMGruposItems.Nombre = tbEditarNombreGrupoItem.Text.ToUpper().Trim();
            if (ALMGruposItems.Modificar())
            {
                Session["MensajeOK"] = "El grupo de Item fue actualizado exitosamente";
                Response.Redirect("ALM_GRU_AdministrarGrupos.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Mensaje: " + ALMGruposItems.Mensaje;
            }
        }

        protected void btnEditarCancelarGrupoItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_GRU_AdministrarGrupos.aspx");
        }
        #endregion

    }
}