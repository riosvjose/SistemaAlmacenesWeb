<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_PROV_AdministrarProveedores.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_PROV_AdministrarProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Administrar Proveedores</h1>
	            </div>
            </div>            
            <div class="row">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="fa-lg text-danger">
                                    <i class="fa fa-spinner fa-spin"></i> Procesando, un momento por favor ...
                                    <br /><br />
                                </div>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <br />
            <%--panel Principal de Proveedores--%>
            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">                        
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblProveedores" runat="server" Text="Proveedor:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-9 col-lg-10">
                                <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnCrearProveedor" runat="server" CssClass="btn btn-success" Text="Crear Proveedor" CausesValidation="False" OnClick="btnCrearProveedor_Click"/>
                                <asp:Button ID="btnEditarProveedor" runat="server" CssClass="btn btn-primary" Text="Editar Proveedor" CausesValidation="False" OnClick="btnEditarProveedor_Click" />
                            </div>
                            <div class="btn-group pull-right">
                                  <asp:Button ID="btnVolverMenu" runat="server" CssClass="btn btn-warning btn-block" Text="Volver" CausesValidation="False" OnClick="btnVolverMenu_Click" />
                            </div>
                          </div>
                        </div>
			        </div>
            </asp:Panel>
            <%--panel Crear Proveedor--%>
            <asp:Panel ID="pnCrearProveedor" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormProveedor" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNitProveedor" runat="server" Text="Nit:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvNitProveedor" runat="server" ControlToValidate="tbNitProveedor" CssClass="text-danger" ErrorMessage="El campo Nit es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbNitProveedor" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNombreComProveedor" runat="server" Text="Nombre Comercial:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvNombreComProveedor" runat="server" ControlToValidate="tbNombreComercialProv" CssClass="text-danger" ErrorMessage="El campo Nombre Comercial es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbNombreComercialProv" runat="server" CssClass="form-control" MaxLength="150" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblRazonSocialProv" runat="server" Text="Razón Social:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvRazonSocialProv" runat="server" ControlToValidate="tbRazonSocialProv" CssClass="text-danger" ErrorMessage="El campo Razón Social es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbRazonSocialProv" runat="server" CssClass="form-control" MaxLength="150" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblTelefonoProv" runat="server" Text="Teléfono:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvTelefonoProv" runat="server" ControlToValidate="tbTelefonoProv" CssClass="text-danger" ErrorMessage="El campo Teléfono es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbTelefonoProv" runat="server" pattern="(?=.*\d).{6,}" title="Debe contener un número telefonico valido." CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled" ></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="tbTelefonoProv_FilteredTextBoxExtender" runat="server" BehaviorID="tbTelefonoProv_FilteredTextBoxExtender" TargetControlID="tbTelefonoProv" ValidChars="01234567890-" />                                                                                                
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblDireccionProv" runat="server" Text="Dirección:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvDireccionProv" runat="server" ControlToValidate="tbDireccionProv" CssClass="text-danger" ErrorMessage="El campo Dirección es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbDireccionProv" runat="server" CssClass="form-control" MaxLength="150" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEmailProv" runat="server" Text="Email:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEmailProv" runat="server" ControlToValidate="tbEmailProv" CssClass="text-danger" ErrorMessage="El campo Email es obligatorio.">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmailProv" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbEmailProv" CssClass="text-danger" ErrorMessage="El formato del Email no es valido (@).">*</asp:RegularExpressionValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox  ID="tbEmailProv" runat="server" CssClass="form-control" type="email" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNombreConProv" runat="server" Text="Nombre de Contacto:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvNombreConProv" runat="server" ControlToValidate="tbNombreConProv" CssClass="text-danger" ErrorMessage="El campo Nombre de Contacto es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbNombreConProv" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnGuardarProv" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnGuardarProv_Click" />
                                <asp:Button ID="btnCancelarProv" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarProv_Click" />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>

            <%--panel Editar Proveedor--%>
            <asp:Panel ID="pnEditarProveedor" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormEditarProveedor" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lvlEditarNitProv" runat="server" Text="Nit:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarNitProv" runat="server" ControlToValidate="tbEditarNitProveedor" CssClass="text-danger" ErrorMessage="El campo Nit es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarNitProveedor" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled" ReadOnly="true" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarNombreComProv" runat="server" Text="Nombre Comercial:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarNombreComProv" runat="server" ControlToValidate="tbEditarNombreComercialProv" CssClass="text-danger" ErrorMessage="El campo Nombre Comercial es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarNombreComercialProv" runat="server" CssClass="form-control" MaxLength="150" AutoCompleteType="Disabled" ReadOnly="true" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarRazonSocialProv" runat="server" Text="Razón Social:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarRazonSocialProv" runat="server" ControlToValidate="tbEditarRazonSocialProv" CssClass="text-danger" ErrorMessage="El campo Razón Social es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarRazonSocialProv" runat="server" CssClass="form-control" MaxLength="150" AutoCompleteType="Disabled" ReadOnly="true" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarTelefonoProv" runat="server" Text="Teléfono:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarTelefonoProv" runat="server" ControlToValidate="tbEditarTelefonoProv" CssClass="text-danger" ErrorMessage="El campo Teléfono es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarTelefonoProv" pattern="(?=.*\d).{6,}" title="Debe contener un número telefonico valido." runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="tbEditarTelefonoProv_FilteredTextBoxExtender" runat="server" BehaviorID="tbEditarTelefonoProv_FilteredTextBoxExtender" TargetControlID="tbEditarTelefonoProv" ValidChars="01234567890-" />                                                                                                
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarDireccionProv" runat="server" Text="Dirección:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarDireccionProv" runat="server" ControlToValidate="tbEditarDireccionProv" CssClass="text-danger" ErrorMessage="El campo Dirección es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarDireccionProv" runat="server" CssClass="form-control" MaxLength="150" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>                        
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarEmailProv" runat="server" Text="Email:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarEmailProv" runat="server" ControlToValidate="tbEditarEmailProv" CssClass="text-danger" ErrorMessage="El campo Email es obligatorio.">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEditarEmailProv" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbEditarEmailProv" CssClass="text-danger" ErrorMessage="El formato del Email no es valido (@).">*</asp:RegularExpressionValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox  ID="tbEditarEmailProv" runat="server" CssClass="form-control" type="email" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarNombreConProv" runat="server" Text="Nombre de Contacto:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarNombreConProv" runat="server" ControlToValidate="tbEditarNombreConProv" CssClass="text-danger" ErrorMessage="El campo Nombre de Contacto es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarNombreConProv" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled" ReadOnly="true" ></asp:TextBox>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnEditarGuardarProv" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnEditarGuardarProv_Click" />
                                <asp:Button ID="btnEditarCancelarProv" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnEditarCancelarProv_Click"/>
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>

            <%--Salto de linea--%>
            <div class="visible-lg visible-md">
                <div class="col-lg-12">
                    <br /><br />
                </div>
            </div>
            <%--Mensajes de exito y error--%>
            <div class="row">
	            <div class="col-md-6">
	                <asp:Panel ID="pnMensajeError" runat="server" Visible="false">
		                <div class="alert alert-danger alert-dismissable">
			                <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>.
		                </div>
	                </asp:Panel>
	                <asp:Panel ID="pnMensajeOK" runat="server" Visible="false">
		                <div class="alert alert-success alert-dismissable">
			                <asp:Label ID="lblMensajeOK" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>.
		                </div>
	                </asp:Panel>
                    <%--Mensaje de Error AJAXValidator--%>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
	            </div>
            </div>    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
