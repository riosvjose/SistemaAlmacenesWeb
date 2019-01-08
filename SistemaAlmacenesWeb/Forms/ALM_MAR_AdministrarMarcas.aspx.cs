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
    public partial class ALM_MAR_AdministrarMarcas : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        BD_ProcAdicionales libproc = new BD_ProcAdicionales();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Marcas ALMMarcas = new BD_ALM_Marcas();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_MAR_AdministrarMarcas"))
                {
                    ALMMarcas.StrConexion = axVarSes.Lee<string>("strConexion");

                    // Listar a todas las marcas
                    ddlMarca.DataSource = ALMMarcas.dtListarMarcas();
                    ddlMarca.DataTextField = "NOMBRE";
                    ddlMarca.DataValueField = "NUM_SEC_MARCA";
                    ddlMarca.DataBind();

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

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearMarca_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearMarca.Visible = true;
            lblFormMarca.Text = "Crear Marca";
            pnEditarMarca.Visible = false;
        }

        protected void btnEditarMarca_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if (ddlMarca.Items.Count != 0)
            {
                pnPrincipal.Visible = false;
                pnCrearMarca.Visible = false;
                lblEditarMarca.Text = "Editar Marca";
                pnEditarMarca.Visible = true;
                //BD_ALM_Marcas
                ALMMarcas.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMMarcas.NumSecMarca = Convert.ToInt64(ddlMarca.Text.Trim()); // Obtener el NUM_SEC_MARCA (id de la marca)
                if (ALMMarcas.Ver())
                {
                    tbEditarNombreMarca.Text = ALMMarcas.Nombre.Trim();
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "Mensaje: " + ALMMarcas.Mensaje;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ninguna Marca creada";
            }
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            ALMMarcas.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMMarcas.Nombre = tbNombreMarca.Text.ToUpper().Trim();

            if (ALMMarcas.Insertar())
            {
                Session["MensajeOK"] = "La Marca fue creada exitosamente";
                Response.Redirect("ALM_MAR_AdministrarMarcas.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Mensaje: " + ALMMarcas.Mensaje;
            }
        }

        protected void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_MAR_AdministrarMarcas.aspx");
        }

        protected void btnEditarGuardarMarca_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            //BD_ALM_Marcas
            ALMMarcas.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMMarcas.NumSecMarca = Convert.ToInt64(ddlMarca.Text.Trim()); // Obtener el NUM_SEC_MARCA (id de la marca)*/
            ALMMarcas.Nombre= tbEditarNombreMarca.Text.ToUpper().Trim();

            if (ALMMarcas.Modificar())
            {
                Session["MensajeOK"] = "La Marca fue actualizada exitosamente";
                Response.Redirect("ALM_MAR_AdministrarMarcas.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Mensaje: " + ALMMarcas.Mensaje;
            }
        }

        protected void btnEditarCancelarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_MAR_AdministrarMarcas.aspx");
        }
        #endregion
    }
}