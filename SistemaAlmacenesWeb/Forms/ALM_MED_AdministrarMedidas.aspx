<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_MED_AdministrarMedidas.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_MED_AdministrarMedidas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Administrar Medidas</h1>
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
            <%--panel Principal de Medidas--%>
            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">                        
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblMedidas" runat="server" Text="Medida:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-9 col-lg-10">
                                <asp:DropDownList ID="ddlMedida" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMedida_SelectedIndexChanged" ></asp:DropDownList>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnCrearMedida" runat="server" CssClass="btn btn-success" Text="Crear Medida" CausesValidation="False" OnClick="btnCrearMedida_Click" />
                                <asp:Button ID="btnEditarMedida" runat="server" CssClass="btn btn-primary" Text="Editar Medida" CausesValidation="False" OnClick="btnEditarMedida_Click" />
                            </div>
                            <div class="btn-group pull-right">
                                  <asp:Button ID="btnVolverMenu" runat="server" CssClass="btn btn-warning btn-block" Text="Volver" CausesValidation="False" OnClick="btnVolverMenu_Click" />
                            </div>
                          </div>
                        </div>
			        </div>
            </asp:Panel>
            <%--panel Crear Medida--%>
            <asp:Panel ID="pnCrearMedida" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormMedida" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNombreMedida" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvNombreMedida" runat="server" ControlToValidate="tbNombreMedida" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbNombreMedida" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblAbrevMedida" runat="server" Text="Abreviación:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvAbrevMedida" runat="server" ControlToValidate="tbAbrevMedida" CssClass="text-danger" ErrorMessage="El campo Abreviación es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbAbrevMedida" runat="server" CssClass="form-control" MaxLength="5" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnGuardarMedida" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnGuardarMedida_Click" />
                                <asp:Button ID="btnCancelarMedida" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarMedida_Click" />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>
            <%--panel Editar Medida--%>
            <asp:Panel ID="pnEditarMedida" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblEditarMedida" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarNombreMedida" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarNombreMedida" runat="server" ControlToValidate="tbEditarNombreMedida" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarNombreMedida" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarAbrevMedida" runat="server" Text="Abreviación:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarAbrevMedida" runat="server" ControlToValidate="tbEditarAbrevMedida" CssClass="text-danger" ErrorMessage="El campo Abreviación es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarAbrevMedida" runat="server" CssClass="form-control" MaxLength="5" AutoCompleteType="Disabled" ></asp:TextBox>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnEditarGuardarMedida" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnEditarGuardarMedida_Click" />
                                <asp:Button ID="btnEditarCancelarMedida" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnEditarCancelarMedida_Click" />
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
