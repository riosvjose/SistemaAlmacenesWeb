<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_ITEM_AdministrarItems.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_ITEM_AdministrarItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Administrar Items</h1>
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
            <%--panel Principal de Items--%>
            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">                        
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblItems" runat="server" Text="Items:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-9 col-lg-10">
                                <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnCrearItem" runat="server" CssClass="btn btn-success" Text="Crear Item" CausesValidation="False" OnClick="btnCrearItem_Click" />
                                <asp:Button ID="btnEditarItem" runat="server" CssClass="btn btn-primary" Text="Editar Item" CausesValidation="False" OnClick="btnEditarItem_Click" />
                                <asp:Button ID="btnEliminarItem" runat="server" CssClass="btn btn-danger" Text="Eliminar Item" CausesValidation="False" OnClick="btnEliminarItem_Click" />
                            </div>
                            <div class="btn-group pull-right">
                                  <asp:Button ID="btnVolverMenu" runat="server" CssClass="btn btn-warning btn-block" Text="Volver" CausesValidation="False" OnClick="btnVolverMenu_Click" />
                            </div>
                          </div>
                        </div>
			        </div>
            </asp:Panel>
            <%--panel Crear Item--%>
            <asp:Panel ID="pnCrearItem" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormItem" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblCodigoItem" runat="server" Text="Código:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvCodigoItem" runat="server" ControlToValidate="tbCodigoItem" CssClass="text-danger" ErrorMessage="El campo Código es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbCodigoItem" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNombreItem" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvNombreItem" runat="server" ControlToValidate="tbNombreItem" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbNombreItem" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblGrupoItem" runat="server" Text="Grupo de Categoría:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlGrupoItem" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupoItem_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblCategoriaItem" runat="server" Text="Categoria:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlCategoriaItem" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblMarcaItem" runat="server" Text="Marca:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlMarcaItem" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblMedidaItem" runat="server" Text="Medida:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlMedidaItem" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblStockItem" runat="server" Text="Stock Mínimo:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvStockItem" runat="server" ControlToValidate="tbStockItem" CssClass="text-danger" ErrorMessage="El campo Stock es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbStockItem" runat="server" CssClass="form-control" onKeyPress="if(this.value.length==5) return false;" type="number" min="0" max="99999" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="tbStockItem_FilteredTextBoxExtender" runat="server" BehaviorID="tbStockItem_FilteredTextBoxExtender" FilterType="Numbers" InvalidChars="0123456789" TargetControlID="tbStockItem" />
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnGuardarItem" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnGuardarItem_Click" />
                                <asp:Button ID="btnCancelarItem" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarItem_Click" />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>
            <%--panel Editar Item--%>
            <asp:Panel ID="pnEditarItem" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormEditarItem" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarCodigoItem" runat="server" Text="Código:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarCodigoItem" runat="server" ControlToValidate="tbEditarCodigoItem" CssClass="text-danger" ErrorMessage="El campo Código es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarCodigoItem" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarNombreItem" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarNombreItem" runat="server" ControlToValidate="tbEditarNombreItem" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarNombreItem" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarCategoriaItem" runat="server" Text="Categoria:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlEditarCategoriaItem" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarMarcaItem" runat="server" Text="Marca:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlEditarMarcaItem" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarMedidaItem" runat="server" Text="Medida:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlEditarMedidaItem" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarStockItem" runat="server" Text="Stock Mínimo:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarStockItem" runat="server" ControlToValidate="tbEditarStockItem" CssClass="text-danger" ErrorMessage="El campo Stock es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarStockItem" runat="server" CssClass="form-control" onKeyPress="if(this.value.length==5) return false;" type="number" min="0" max="99999" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="tbEditarStockItem_FilteredTextBoxExtender" runat="server" BehaviorID="tbEditarStockItem_FilteredTextBoxExtender" FilterType="Numbers" InvalidChars="0123456789" TargetControlID="tbEditarStockItem" />
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnEditarGuardarItem" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnEditarGuardarItem_Click"  />
                                <asp:Button ID="btnEditarCancelarItem" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnEditarCancelarItem_Click"  />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>
            <%--panel Confirmar borrado de Item--%>
            <asp:Panel ID="pnBorrarItem" runat="server" Visible="false" CssClass="bg-danger" >
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3><strong><asp:Label ID="lblBorrarItem" runat="server" Text="Eliminar Item" ForeColor="#9e0501"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <h2><strong><asp:Label ID="lblFormBorrarItem" runat="server" Text="" ForeColor="#9e0501"></asp:Label></strong></h2>
                            </div>
                        </div>
                    </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                     <asp:Button ID="btnBorrarItem" runat="server" CssClass="btn btn-danger" Text="Confirmar" CausesValidation="False" OnClick="btnBorrarItem_Click" />
                                     <asp:Button ID="btnCancelarBorrarItem" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarBorrarItem_Click" />
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
