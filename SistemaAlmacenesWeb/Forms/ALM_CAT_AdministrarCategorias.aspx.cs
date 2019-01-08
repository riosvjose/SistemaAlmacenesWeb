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
    public partial class ALM_CAT_AdministrarCategorias : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Cat_Items ALMCategoriasItems = new BD_ALM_Cat_Items();
        BD_ALM_Grupos_Items ALMGruposItems = new BD_ALM_Grupos_Items();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_CAT_AdministrarCategorias"))
                {
                    ALMCategoriasItems.StrConexion = axVarSes.Lee<string>("strConexion");
                    // Listar todas las Categorias de Items
                    ddlCategoriaItems.DataSource = ALMCategoriasItems.dtListarTodasCategorias();
                    ddlCategoriaItems.DataTextField = "NOMBRE";
                    ddlCategoriaItems.DataValueField = "NUM_SEC_CAT";
                    ddlCategoriaItems.DataBind();

                    ALMGruposItems.StrConexion = axVarSes.Lee<string>("strConexion");
                    //Listar todos los grupos a los que ua persona tiene permisos
                    ddlGrupoItem.DataSource = ALMGruposItems.DTListaGrupos();
                    ddlGrupoItem.DataTextField = "NOMBRE";
                    ddlGrupoItem.DataValueField = "NUM_SEC_GRUPO";
                    ddlGrupoItem.DataBind();
                    //Listar todos los grupos a los que ua persona tiene permisos al editar
                    ddlEditarGrupoItem.DataSource = ALMGruposItems.DTListaGrupos();
                    ddlEditarGrupoItem.DataTextField = "NOMBRE";
                    ddlEditarGrupoItem.DataValueField = "NUM_SEC_GRUPO";
                    ddlEditarGrupoItem.DataBind();

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
                    axVarSes.Escribe("MostrarMensajeError", "1");
                    Response.Redirect("Index.aspx");
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

        protected void ddlCategoriaItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearCategoria_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearCategoriaItem.Visible = true;
            lblFormCategoriaItem.Text = "Crear Categoría de Item";
            pnEditarCategoriaItem.Visible = false;
        }

        protected void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if (ddlCategoriaItems.Items.Count != 0)
            {
                pnPrincipal.Visible = false;
                pnCrearCategoriaItem.Visible = false;
                lblEditarCategoriaItem.Text = "Editar Categoría de Item";
                pnEditarCategoriaItem.Visible = true;
                //BD_ALM_Cat_Items
                ALMCategoriasItems.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMCategoriasItems.NumSecCat = Convert.ToInt64(ddlCategoriaItems.Text.Trim()); // Obtener el NUM_SEC_CAT (id de la Categoría del Item)
                if (ALMCategoriasItems.Ver())
                {
                    tbEditarNombreCategoriaItem.Text = ALMCategoriasItems.Nombre.Trim();
                    tbEditarDescCatItem.Text = ALMCategoriasItems.Descripcion.Trim();
                    ddlEditarGrupoItem.SelectedValue = ALMCategoriasItems.NumSecGrupoItem.ToString();
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

        protected void btnGuardarCategoriaItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            //Validar que el DDL no este vacio
            if (ddlGrupoItem.Items.Count != 0)
            {
                
                ALMCategoriasItems.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMCategoriasItems.Nombre = tbNombreCategoriaItem.Text.ToUpper().Trim();
                ALMCategoriasItems.Descripcion = tbDescripcionCatItem.Text.Trim();
                ALMCategoriasItems.NumSecGrupoItem = Convert.ToInt64(ddlGrupoItem.Text.Trim());
                if (tbDescripcionCatItem.Text.Length >= 500)
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "El campo Descripción debe contener menos de 500 caracteres";
                }
                else if (ALMCategoriasItems.Insertar())
                {
                    Session["MensajeOK"] = "La Categoría del Item fue creada exitosamente";
                    Response.Redirect("ALM_CAT_AdministrarCategorias.aspx");
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "Mensaje: " + ALMCategoriasItems.Mensaje;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún Grupo de Items creado"; 
            }
        }

        protected void btnCancelarCategoriaItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_CAT_AdministrarCategorias.aspx");
        }

        protected void btnEditarGuardarCategoriaItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            //BD_ALM_Cat_Items
            ALMCategoriasItems.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMCategoriasItems.NumSecCat = Convert.ToInt64(ddlCategoriaItems.Text.Trim()); // Obtener el NUM_SEC_CAT (id de la Categoria de Item)
            ALMCategoriasItems.Nombre = tbEditarNombreCategoriaItem.Text.ToUpper().Trim();
            ALMCategoriasItems.Descripcion = tbEditarDescCatItem.Text.Trim();
            if (tbEditarDescCatItem.Text.Length >= 500)
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "El campo Descripción debe contener menos de 500 caracteres";
            }
            else if (ALMCategoriasItems.Modificar())
            {
                Session["MensajeOK"] = "La Categoria del Item fue actualizada exitosamente";
                Response.Redirect("ALM_CAT_AdministrarCategorias.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Mensaje: " + ALMCategoriasItems.Mensaje;
            }
        }

        protected void btnEditarCancelarCategoriaItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_CAT_AdministrarCategorias.aspx");
        }
        #endregion

    }
}