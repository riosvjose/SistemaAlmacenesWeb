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
    public partial class ALM_PROV_AdministrarProveedores : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ALM_Proveedores ALMProveedores = new BD_ALM_Proveedores();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            ALMProveedores.StrConexion = axVarSes.Lee<string>("strConexion");
            if (!Page.IsPostBack)
            {
                // Listar a todos los Proveedores
                ddlProveedor.DataSource = ALMProveedores.ListarProveedores();
                ddlProveedor.DataTextField = "NOMBRE_COMERCIAL";
                ddlProveedor.DataValueField = "NUM_SEC_PROVEEDOR";
                ddlProveedor.DataBind();
            }
            // Recibir mensaje exitoso cuando se redirige de otra pagina
            if (Session["MensajeOK"] != null)
            {
                pnMensajeOK.Visible = true;
                lblMensajeOK.Text = Session["MensajeOK"].ToString();
                Session["MensajeOK"] = null;
            }
        }
        #endregion

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearProveedor_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnPrincipal.Visible = false;
            pnCrearProveedor.Visible = true;
            lblFormProveedor.Text = "Crear Proveedor";            
            pnEditarProveedor.Visible = false;
        }

        protected void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if (ddlProveedor.SelectedIndex != 0)
            {
                pnPrincipal.Visible = false;
                pnCrearProveedor.Visible = false;
                lblFormEditarProveedor.Text = "Editar Proveedor";
                pnEditarProveedor.Visible = true;
                //BD_ALM_Proveedores
                ALMProveedores.StrConexion = axVarSes.Lee<string>("strConexion");
                ALMProveedores.NumSecProveedor = Convert.ToInt64(ddlProveedor.Text.Trim()); // Obtener el NUM_SEC_PROVEEDOR (id del proveedor)
                if (ALMProveedores.Ver())
                {
                    tbEditarNitProveedor.Text = ALMProveedores.Nit.Trim();
                    tbEditarNombreComercialProv.Text = ALMProveedores.NombreComercial.Trim();
                    tbEditarRazonSocialProv.Text = ALMProveedores.RazonSocial.Trim();
                    tbEditarTelefonoProv.Text = ALMProveedores.Telefono.Trim();
                    tbEditarEmailProv.Text = ALMProveedores.Email.Trim();
                    tbEditarDireccionProv.Text = ALMProveedores.Direccion.Trim();
                    tbEditarNombreConProv.Text = ALMProveedores.NombreContacto.Trim();
                }
                else
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "Mensaje: " + ALMProveedores.Mensaje;
                }
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Usted no selecciono a ningún Proveedor";
            }
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGuardarProv_Click(object sender, EventArgs e)
        {
            ALMProveedores.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMProveedores.Nit = tbNitProveedor.Text.Trim();
            ALMProveedores.NombreComercial = tbNombreComercialProv.Text.Trim();
            ALMProveedores.RazonSocial = tbRazonSocialProv.Text.Trim();
            ALMProveedores.Telefono = tbTelefonoProv.Text.Trim();
            ALMProveedores.Email = tbEmailProv.Text.Trim();
            ALMProveedores.Direccion = tbDireccionProv.Text.Trim();
            ALMProveedores.NombreContacto = tbNombreConProv.Text.Trim();
            if (ALMProveedores.Insertar()){
                Session["MensajeOK"] = "El Proveedor fue creado exitosamente";
                Response.Redirect("ALM_PROV_AdministrarProveedores.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Mensaje: " + ALMProveedores.Mensaje ;
            }
        }

        protected void btnCancelarProv_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_PROV_AdministrarProveedores.aspx");
        }

        protected void btnEditarGuardarProv_Click(object sender, EventArgs e)
        {
            //BD_ALM_Proveedores
            ALMProveedores.StrConexion = axVarSes.Lee<string>("strConexion");
            ALMProveedores.NumSecProveedor = Convert.ToInt64(ddlProveedor.Text.Trim()); // Obtener el NUM_SEC_PROVEEDOR (id del proveedor)*/
            ALMProveedores.Telefono = tbEditarTelefonoProv.Text.Trim();
            ALMProveedores.Direccion = tbEditarDireccionProv.Text.Trim();
            ALMProveedores.Email = tbEditarEmailProv.Text.Trim();

            if (ALMProveedores.Modificar())
            {
                Session["MensajeOK"] = "El Proveedor fue actualizado exitosamente";
                Response.Redirect("ALM_PROV_AdministrarProveedores.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "Mensaje: " + ALMProveedores.Mensaje;
            }
        }

        protected void btnEditarCancelarProv_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_PROV_AdministrarProveedores.aspx");
        }
        #endregion
    }
}