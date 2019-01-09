using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using nsBD_SAM;
using System.Data;
using nsGEN;

namespace SistemaAlmacenesWeb.Forms
{
    public partial class ALM_ALM_AdministrarAlmacenes : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        BD_SAM_Usuarios libusu = new BD_SAM_Usuarios();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Almacenes libalm = new BD_ALM_Almacenes();
        BD_ALM_Almacenes_Usu libalmUsu = new BD_ALM_Almacenes_Usu();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_ALM_AdministrarAlmacenes"))
                {
                    libalm.StrConexion = axVarSes.Lee<string>("strConexion");
                    // Listar todos los almacenes
                    ddlAlmacenes.DataSource = libalm.dtListarTodosAlmacenes();
                    ddlAlmacenes.DataTextField = "NOMBRE";
                    ddlAlmacenes.DataValueField = "NUM_SEC_ALMACEN";
                    ddlAlmacenes.DataBind();

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
        public void VaciarBoxes()
        {
            tbDescripcionAlmacen.Text = "";
            tbNombreAlmacen.Text = "";
            tbusuario.Text = "";
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
            pnAdmUsuarios.Visible = false;
            pnCrearAlmacen.Visible = false;
        }

        protected void btnCrearAlmacen_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearAlmacen.Visible = true;
            pnAdmUsuarios.Visible = false;
        }

        protected void btnEditarAlmacen_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if (ddlAlmacenes.Items.Count != 0)
            {
               
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún almacen creado";
            }
        }
        
        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if (ddlAlmacenes.Items.Count != 0)
            {
                pnPrincipal.Visible=true;
                pnbuscar.Visible = true;
                btnAgregar.Visible = false;
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún almacen creado";
            }
        }


        protected void btnAdmUsu_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;      
            if (ddlAlmacenes.Items.Count != 0)
            {
                pnAdmUsuarios.Visible = true;
                pnPrincipal.Visible = true;
                pnCrearAlmacen.Visible = false;
                libalmUsu.StrConexion = axVarSes.Lee<string>("strConexion");
                libalmUsu.NumSecAlmacen= Convert.ToInt64(ddlAlmacenes.SelectedValue);
                gvDatos1.Visible = true;
                gvDatos1.Columns[0].Visible = true;
                gvDatos1.DataSource = libalmUsu.ObtenerUsuariosAlmacen();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            //Validar que el DDL no este vacio
         
            libalm.StrConexion = axVarSes.Lee<string>("strConexion");
            libalm.Nombre = tbNombreAlmacen.Text.ToUpper().Trim();
            libalm.Descripcion = tbDescripcionAlmacen.Text.Trim();
            if (tbDescripcionAlmacen.Text.Length >= 500)
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "El campo Descripción debe contener menos de 500 caracteres";
            }
            else if (libalm.Insertar())
            {
                pnMensajeOK.Visible = true;
                lblMensajeOK.Text = "Datos ingresados satisfactoriamente. ";
                pnPrincipal.Visible = true;
                pnCrearAlmacen.Visible = false;
                VaciarBoxes();
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No se pudo insertar el dato. " + libalm.Mensaje;
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_ALM_AdministrarAlmacenes.aspx");
        }

        protected void btnEditarGuardar_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            //BD_ALM_Cat_Items
            /*ALMCategoriasItems.StrConexion = axVarSes.Lee<string>("strConexion");
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
            }*/
        }

        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            libalmUsu = new BD_ALM_Almacenes_Usu();
            libalmUsu.StrConexion = axVarSes.Lee<string>("strConexion");
            libalmUsu.NumSecAlmacen = Convert.ToInt32(ddlAlmacenes.SelectedValue);
            if (e.CommandName == "agregar")
            {
                libalmUsu.NumSecUsu = Convert.ToInt32(gvUsuarios.Rows[indice].Cells[0].Text);
                if (libalmUsu.VerExistente())
                {

                    if (!libalmUsu.VolverActivo())
                    {

                        pnMensajeError.Visible = true;
                        lblMensajeOK.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvUsuarios.Rows[indice].Cells[1].Text) + ". " + libalm.Mensaje; ;
                        pnMensajeOK.Visible = false;
                    }
                }
                else
                {
                    
                    if (!libalmUsu.Insertar())
                    {
                        pnMensajeError.Visible = true;
                        lblMensajeOK.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvUsuarios.Rows[indice].Cells[1].Text) + ". " + libalm.Mensaje; ;
                        pnMensajeOK.Visible = false;
                    }
                }
                
            }
            if (e.CommandName == "eliminar")
            {
                libalmUsu.NumSecUsu = Convert.ToInt32(gvDatos1.Rows[indice].Cells[0].Text);
                if (!libalmUsu.VolverInactivo())
                {
                    pnMensajeError.Visible = true;
                    lblMensajeOK.Text = "No se pudo agregar el usuario. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[1].Text) + ". " + libalm.Mensaje; ;
                    pnMensajeOK.Visible = false;
                }
            }
            pnMensajeError.Visible = false;
            gvDatos1.Visible = true;
            gvDatos1.Columns[0].Visible = true;
            gvDatos1.DataSource = libalmUsu.ObtenerUsuariosAlmacen();
            gvDatos1.DataBind();
            gvDatos1.Columns[0].Visible = false;

        }
        #endregion

    }
}