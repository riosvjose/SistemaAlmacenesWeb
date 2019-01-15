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
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Grupos_Items ALMGruposItems = new BD_ALM_Grupos_Items();
        BD_ALM_Almacenes ALMAlmacenes = new BD_ALM_Almacenes();
        BD_ALM_Grupos_Items_Subdeptos libGrupoSubdepto = new BD_ALM_Grupos_Items_Subdeptos();
        BD_GEN_Subdeptos libSubdeptos = new BD_GEN_Subdeptos();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_GRU_AdministrarGrupos"))
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
                        DataRow dr = ALMAlmacenes.dtListarAlmacenes().Rows[0];
                        axVarSes.Escribe("UsuarioNumSecAlmacen", dr["NUM_SEC_ALMACEN"].ToString());
                    }
                    else
                    {
                        axVarSes.Escribe("UsuarioNumSecAlmacen", 0.ToString());
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

        protected void ddlGrupoItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnAdmDeptos.Visible = false;
            pnCrearGrupoItem.Visible = false;
            pnEditarGrupoItem.Visible = false;
            pnMensajeError.Visible = false;
        }

        protected void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnAdmDeptos.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearGrupoItem.Visible = true;
            lblFormGrupoItem.Text = "Crear Grupo de Items";
            pnEditarGrupoItem.Visible = false;
            long almacen = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSecAlmacen"));
            if (almacen == 0)
            {
                idAlmacenItem.Visible = true;
            }
        }

        protected void btnEditarGrupo_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnAdmDeptos.Visible = false;
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
                    lblMensajeError.Text = ALMGruposItems.Mensaje;
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
            pnAdmDeptos.Visible = false;
            long almacen = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSecAlmacen"));
            //Validar que el DDL no este vacio
            if (ddlAlmacenItem.Items.Count != 0)
            {
                ALMGruposItems.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMGruposItems.Nombre = tbNombreGrupoItem.Text.ToUpper().Trim();
                if (almacen != 0)
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
                    lblMensajeError.Text = ALMGruposItems.Mensaje;
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
            pnAdmDeptos.Visible = false;
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
                lblMensajeError.Text = ALMGruposItems.Mensaje;
            }
        }

        protected void btnEditarCancelarGrupoItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_GRU_AdministrarGrupos.aspx");
        }

        protected void btnAdmSubdepto_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if (ddlGrupoItems.Items.Count != 0)
            {
                pnAdmDeptos.Visible = true;
                pnPrincipal.Visible = true;
                pnCrearGrupoItem.Visible = false;
                libGrupoSubdepto.StrConexion = axVarSes.Lee<string>("strConexion");
                libGrupoSubdepto.NumSecGrupoItem = Convert.ToInt64(ddlGrupoItems.SelectedValue);
                gvDatos1.Visible = true;
                gvDatos1.Columns[0].Visible = true;
                gvDatos1.DataSource = libGrupoSubdepto.DTSubdeptosGrupo();
                gvDatos1.DataBind();
                gvDatos1.Columns[0].Visible = false;
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún almacen creado";
            }
        }
        protected void btnAgregarSubdepto_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if (ddlGrupoItems.Items.Count != 0)
            {
                pnPrincipal.Visible = true;
                pnbuscar.Visible = true;
                btnAgregar.Visible = false;
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún grupo creado";
            }
        } 
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnsugeridos.Visible = true;
            libSubdeptos.StrConexion = axVarSes.Lee<string>("strConexion");
            gvSubdeptos.Visible = true;
            gvSubdeptos.Columns[0].Visible = true;
            gvSubdeptos.DataSource = libSubdeptos.DTBuscarSubdeptos(tbsubdepartamento.Text);
            gvSubdeptos.DataBind();
            gvSubdeptos.Columns[0].Visible = false;
        }

        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            libGrupoSubdepto = new BD_ALM_Grupos_Items_Subdeptos();
            libGrupoSubdepto.StrConexion = axVarSes.Lee<string>("strConexion");
            libGrupoSubdepto.NumSecGrupoItem = Convert.ToInt32(ddlGrupoItems.SelectedValue);
            if (e.CommandName == "agregar")
            {
                libGrupoSubdepto.NumSecSubdepto = Convert.ToInt32(gvSubdeptos.Rows[indice].Cells[0].Text);
                if (libGrupoSubdepto.VerExistente())
                {

                    if (!libGrupoSubdepto.VolverActivo())
                    {

                        pnMensajeError.Visible = true;
                        lblMensajeOK.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvSubdeptos.Rows[indice].Cells[1].Text) + ". " + libGrupoSubdepto.Mensaje; ;
                        pnMensajeOK.Visible = false;
                    }
                }
                else
                {

                    if (!libGrupoSubdepto.Insertar())
                    {
                        pnMensajeError.Visible = true;
                        lblMensajeOK.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvSubdeptos.Rows[indice].Cells[1].Text) + ". " + libGrupoSubdepto.Mensaje; ;
                        pnMensajeOK.Visible = false;
                    }
                }

            }
            if (e.CommandName == "eliminar")
            {
                libGrupoSubdepto.NumSecSubdepto = Convert.ToInt32(gvDatos1.Rows[indice].Cells[0].Text);
                if (!libGrupoSubdepto.VolverInactivo())
                {
                    pnMensajeError.Visible = true;
                    lblMensajeOK.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[1].Text) + ". " + libGrupoSubdepto.Mensaje; ;
                    pnMensajeOK.Visible = false;
                }
            }
            pnMensajeError.Visible = false;
            gvDatos1.Visible = true;
            gvDatos1.Columns[0].Visible = true;
            gvDatos1.DataSource = libGrupoSubdepto.DTSubdeptosGrupo();
            gvDatos1.DataBind();
            gvDatos1.Columns[0].Visible = false;

        }
        #endregion

    }
}