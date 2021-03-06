﻿using System;
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
    public partial class ALM_ITEM_AdministrarItems : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Items ALMItems = new BD_ALM_Items();
        BD_ALM_Grupos_Items ALMGruposItems = new BD_ALM_Grupos_Items();
        BD_ALM_Cat_Items ALMCategoriasItems = new BD_ALM_Cat_Items();
        BD_ALM_Medidas ALMMedidas = new BD_ALM_Medidas();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_ITEM_AdministrarItems"))
                {
                    //Cargar todos los Drop Down List
                    CargarTodosDdl();

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
        //Cargar todos los Drop Down List
        protected void CargarTodosDdl()
        {
            ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
            // Listar a todos los Items
            ddlItem.DataSource = ALMItems.dtListaTodosItems();
            ddlItem.DataTextField = "NOMBRE";
            ddlItem.DataValueField = "NUM_SEC_ITEM";
            ddlItem.DataBind();

            ALMGruposItems.StrConexion = axVarSes.Lee<string>("strConexion");
            //Listar todos los Grupos
            ddlGrupoItem.DataSource = ALMGruposItems.DTListaGrupos();
            ddlGrupoItem.DataTextField = "NOMBRE";
            ddlGrupoItem.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupoItem.DataBind();

            //Listar todas las Categorias
            CargarCategoriasDdl();

            ALMMedidas.StrConexion = axVarSes.Lee<string>("strConexion");
            //Listar todas las Medidas
            ddlMedidaItem.DataSource = ALMMedidas.dtListarMedidas();
            ddlMedidaItem.DataTextField = "NOMBRE";
            ddlMedidaItem.DataValueField = "NUM_SEC_MEDIDA";
            ddlMedidaItem.DataBind();
            //Listar todas las Medidas al Editar
            ddlEditarMedidaItem.DataSource = ALMMedidas.dtListarMedidas();
            ddlEditarMedidaItem.DataTextField = "NOMBRE";
            ddlEditarMedidaItem.DataValueField = "NUM_SEC_MEDIDA";
            ddlEditarMedidaItem.DataBind();
            //Listar Grupo de Categorias (Dentro del modal)
            ddlGrupoCategoria.DataSource = ALMGruposItems.DTListaGrupos();
            ddlGrupoCategoria.DataTextField = "NOMBRE";
            ddlGrupoCategoria.DataValueField = "NUM_SEC_GRUPO";
            ddlGrupoCategoria.DataBind();           
        }
        //Cargar todos los Drop Down List de Categorias
        protected void CargarCategoriasDdl()
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            ALMCategoriasItems.StrConexion = axVarSes.Lee<string>("strConexion");
            //Listar todas las Categorias
            if (ddlGrupoItem.Items.Count != 0)
            {
                //Listar Categorias
                ALMCategoriasItems.NumSecGrupoItem = Convert.ToInt64(ddlGrupoItem.Text.Trim()); // Obtener el NUM_SEC_GRUPO (id del grupo)
                ddlCategoriaItem.DataSource = ALMCategoriasItems.DTListaCategorias();
                ddlCategoriaItem.DataTextField = "NOMBRE";
                ddlCategoriaItem.DataValueField = "NUM_SEC_CAT";
                ddlCategoriaItem.DataBind();
            
                //Listar Editar Categorias
                ddlEditarCategoriaItem.DataSource = ALMCategoriasItems.dtListarTodasCategorias();
                ddlEditarCategoriaItem.DataTextField = "NOMBRE";
                ddlEditarCategoriaItem.DataValueField = "NUM_SEC_CAT";
                ddlEditarCategoriaItem.DataBind();
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "El Grupo seleccionado no cuenta con Categorías registradas. Seleccione otro Grupo por favor";
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
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearItem.Visible = true;
            lblFormItem.Text = "Crear Item";
            pnEditarItem.Visible = false;
            pnBorrarItem.Visible = false;
        }

        protected void btnEditarItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if (ddlItem.Items.Count != 0)
            {
                pnPrincipal.Visible = false;
                pnCrearItem.Visible = false;
                lblFormEditarItem.Text = "Editar Item";
                pnEditarItem.Visible = true;
                pnBorrarItem.Visible = false;
                //BD_ALM_Items
                ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMItems.NumSecItem = Convert.ToInt64(ddlItem.Text.Trim()); // Obtener el NUM_SEC_ITEM (id del Item)
                if (ALMItems.Ver())
                {
                    tbEditarCodigoItem.Text = ALMItems.Cod.Trim();
                    tbEditarNombreItem.Text = ALMItems.Nombre.ToUpper().Trim();
                    ddlEditarCategoriaItem.SelectedValue = ALMItems.NumSecCat.ToString();
                    ddlEditarMedidaItem.SelectedValue = ALMItems.NumSecMedida.ToString();
                    tbEditarStockItem.Text = ALMItems.StockMin.ToString().Trim();
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = ALMItems.Mensaje;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún Item registrado";
            }
        }

        protected void btnEliminarItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearItem.Visible = false;
            lblFormBorrarItem.Text = "Eliminar Item";
            pnEditarItem.Visible = false;
            pnBorrarItem.Visible = true;

            if (ddlItem.Items.Count != 0)
            {
                pnBorrarItem.Visible = true;
                lblFormBorrarItem.Visible = true;
                lblFormBorrarItem.Text = "¿Está seguro de que desea eliminar el item " + ddlItem.SelectedItem.ToString() + " ?";
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún Item registrado";
            }
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            upCategoriaItem.Visible = true;
            upMedidaItem.Visible = false;
            // Abrir el modal
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalCategoriaItem').modal('show');", true);
        }

        protected void btnAgregarMedida_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            upCategoriaItem.Visible = false;
            upMedidaItem.Visible = true;
            // Abrir el modal
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalMedidaItem').modal('show');", true);
        }

        //Ocultar los modals
        protected void cerrarModals()
        {
            upCategoriaItem.Visible = false;    //Modal Crear Categorias
            upMedidaItem.Visible = false;       //Modal Crear Medida
        }

        protected void btnGuardarModalCat_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            //Validar que el DDL no este vacio
            if (ddlGrupoItem.Items.Count != 0)
            {
                ALMCategoriasItems.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMCategoriasItems.Nombre = tbNombreCategoria.Text.ToUpper().Trim();
                ALMCategoriasItems.Descripcion = tbDescripcionCategoria.Text.Trim();
                ALMCategoriasItems.NumSecGrupoItem = Convert.ToInt64(ddlGrupoItem.Text.Trim());
                if (tbDescripcionCategoria.Text.Length >= 500)
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "El campo Descripción debe contener menos de 500 caracteres";
                }
                else if (ALMCategoriasItems.Insertar())
                {
                    pnMensajeOK.Visible = true;
                    lblMensajeOK.Text = "La Categoría fue creada exitosamente";
                    //Ocultar los modals
                    cerrarModals();
                    // Cerrar el modal
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalCategoriaItem').hide();$('.modal-backdrop').hide();", true);                    
                    //Limpiar los campos del modal
                    tbNombreCategoria.Text = "";
                    tbDescripcionCategoria.Text = "";
                    //Recargar el DDL Categoria de Items
                    ALMCategoriasItems.StrConexion = axVarSes.Lee<string>("strConexion");                    
                    if (ddlGrupoItem.Items.Count != 0)
                    {
                        //Listar Categorias
                        ALMCategoriasItems.NumSecGrupoItem = Convert.ToInt64(ddlGrupoItem.Text.Trim()); // Obtener el NUM_SEC_GRUPO (id del grupo)
                        ddlCategoriaItem.DataSource = ALMCategoriasItems.DTListaCategorias();
                        ddlCategoriaItem.DataTextField = "NOMBRE";
                        ddlCategoriaItem.DataValueField = "NUM_SEC_CAT";
                        ddlCategoriaItem.DataBind();
                    }
                    else
                    {
                        pnMensajeError.Visible = true;
                        lblMensajeError.Text = "El Grupo seleccionado no cuenta con Categorías registradas. Seleccione otro Grupo por favor";
                    }
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = ALMCategoriasItems.Mensaje;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún Grupo de Items creado";
            }
        }

        protected void btnCancelarModalCat_Click(object sender, EventArgs e)
        {
            //Ocultar los modals
            cerrarModals();
            // Cerrar el modal Categoria
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalCategoriaItem').hide();$('.modal-backdrop').hide();", true);
        }

        protected void btnGuardarModalMedida_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;

            ALMMedidas.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMMedidas.Nombre = tbNombreMedida.Text.ToUpper().Trim();
            ALMMedidas.Abreviacion = tbAbrevMedida.Text.Trim();
            if (ALMMedidas.Insertar())
            {
                pnMensajeOK.Visible = true;
                lblMensajeOK.Text = "La Medida fue creada exitosamente";
                //Ocultar los modals
                cerrarModals();
                // Cerrar el modal
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalMedidaItem').hide();$('.modal-backdrop').hide();", true);
                //Limpiar los campos del modal
                tbNombreMedida.Text = "";
                tbAbrevMedida.Text = "";
                //Recargar el DDL Medida de Items
                ddlMedidaItem.DataSource = ALMMedidas.dtListarMedidas();
                ddlMedidaItem.DataTextField = "NOMBRE";
                ddlMedidaItem.DataValueField = "NUM_SEC_MEDIDA";
                ddlMedidaItem.DataBind();
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = ALMMedidas.Mensaje;
            }
        }

        protected void btnCancelarModalMedida_Click(object sender, EventArgs e)
        {
            //Ocultar los modals
            cerrarModals();
            // Cerrar el modal Medida
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalMedidaItem').hide();$('.modal-backdrop').hide();", true);
        }

        protected void btnGuardarItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMItems.Cod = tbCodigoItem.Text.Trim();
            ALMItems.Nombre = tbNombreItem.Text.ToUpper().Trim();
            ALMItems.NumSecCat = Convert.ToInt64(ddlCategoriaItem.Text.Trim());           
            ALMItems.NumSecMedida = Convert.ToInt64(ddlMedidaItem.Text.Trim());
            ALMItems.StockMin = Convert.ToInt64(tbStockItem.Text.Trim());

            if (ddlCategoriaItem.Items.Count == 0)
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ninguna Categoría registrada";
            }
            else if (ddlMedidaItem.Items.Count == 0)
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ninguna Medida registrada";
            }
            else if (ALMItems.Insertar())
            {
                Session["MensajeOK"] = "El Item fue creado exitosamente";
                Response.Redirect("ALM_ITEM_AdministrarItems.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = ALMItems.Mensaje;
            }
        }

        protected void btnCancelarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_ITEM_AdministrarItems.aspx");
        }

        protected void btnEditarGuardarItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            //BD_ALM_Items
            ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMItems.NumSecItem = Convert.ToInt64(ddlItem.Text.Trim()); // Obtener el NUM_SEC_ITEM (id del Item)
            ALMItems.Cod = tbEditarCodigoItem.Text.Trim();
            ALMItems.Nombre = tbEditarNombreItem.Text.ToUpper().Trim();
            ALMItems.StockMin = Convert.ToInt64(tbEditarStockItem.Text.Trim());
            if (ALMItems.Modificar())
            {
                Session["MensajeOK"] = "El Item fue actualizada exitosamente";
                Response.Redirect("ALM_ITEM_AdministrarItems.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = ALMItems.Mensaje;
            }
        }

        protected void btnEditarCancelarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_ITEM_AdministrarItems.aspx");
        }

        protected void btnBorrarItem_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            ALMItems.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMItems.NumSecItem = Convert.ToInt64(ddlItem.Text.Trim()); // Obtener el NUM_SEC_ITEM (id del Item)
            if (ALMItems.Borrar())
            {
                Session["MensajeOK"] = "El Item fue eliminado exitosamente";
                Response.Redirect("ALM_ITEM_AdministrarItems.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = ALMItems.Mensaje;
            }
        }

        protected void btnCancelarBorrarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_ITEM_AdministrarItems.aspx");
        }

        protected void ddlGrupoItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCategoriasDdl();
            //Auto-Seleccionar el mismo grupo del item en el modal
            ddlGrupoCategoria.SelectedValue = ddlGrupoItem.SelectedValue.ToString();
        }

        protected void ddlEditarGrupoItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCategoriasDdl();
        }
        #endregion

    }
}