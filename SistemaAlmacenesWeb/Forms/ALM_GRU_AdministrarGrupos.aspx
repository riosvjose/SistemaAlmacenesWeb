<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_GRU_AdministrarGrupos.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_GRU_AdministrarGrupos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Administrar Grupo de Items</h1>
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
            <%--panel Principal de Grupos de Items--%>
            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">                        
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblGrupoItems" runat="server" Text="Grupo de Items:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-9 col-lg-10">
                                <asp:DropDownList ID="ddlGrupoItems" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupoItems_SelectedIndexChanged" ></asp:DropDownList>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnCrearGrupo" runat="server" CssClass="btn btn-success" Text="Crear Grupo" CausesValidation="False" OnClick="btnCrearGrupo_Click" />
                                <asp:Button ID="btnEditarGrupo" runat="server" CssClass="btn btn-primary" Text="Editar Grupo" CausesValidation="False" OnClick="btnEditarGrupo_Click" />
                            </div>
                            <div class="btn-group pull-right">
                                  <asp:Button ID="btnVolverMenu" runat="server" CssClass="btn btn-warning btn-block" Text="Volver" CausesValidation="False" OnClick="btnVolverMenu_Click" />
                            </div>
                          </div>
                        </div>
			        </div>
            </asp:Panel>
            <%--panel Crear Grupo de Item--%>
            <asp:Panel ID="pnCrearGrupoItem" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormGrupoItem" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNombreGrupoItem" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvNombreGrupoItem" runat="server" ControlToValidate="tbNombreGrupoItem" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbNombreGrupoItem" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3" runat="server" id="idAlmacenItem" visible="false">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblAlmacenItem" runat="server" Text="Almacen:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlAlmacenItem" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnGuardarGrupoItem" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnGuardarGrupoItem_Click" />
                                <asp:Button ID="btnCancelarGrupoItem" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarGrupoItem_Click" />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>
            <%--panel Editar Grupo de Items--%>
            <asp:Panel ID="pnEditarGrupoItem" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblEditarGrupoItem" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarNombreGrupoItem" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarNombreGrupoItem" runat="server" ControlToValidate="tbEditarNombreGrupoItem" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarNombreGrupoItem" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3" runat="server">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarAlmacen" runat="server" Text="Almacen:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlEditarAlmacen" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnEditarGuardarGrupoItem" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnEditarGuardarGrupoItem_Click" />
                                <asp:Button ID="btnEditarCancelarGrupoItem" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnEditarCancelarGrupoItem_Click" />
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
