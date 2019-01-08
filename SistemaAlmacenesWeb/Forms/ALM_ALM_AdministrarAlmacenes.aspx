<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_ALM_AdministrarAlmacenes.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_ALM_AdministrarAlmacenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Administrar Almacenes</h1>
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
            <%--panel Principal de Categoría de Items--%>
            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">                        
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblAlmacen" runat="server" Text="Almacen:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-9 col-lg-10">
                                <asp:DropDownList ID="ddlAlmacenes" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlAlmacenes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnCrearAlmacen" runat="server" CssClass="btn btn-success" Text="Crear Almacen" CausesValidation="False" OnClick="btnCrearAlmacen_Click" />
                                 <asp:Button ID="btnAdmUsuariosAlm" runat="server" CssClass="btn btn-info" Text="Administrar Usuarios" CausesValidation="False" OnClick="btnAdmUsu_Click" />
                                <%--<asp:Button ID="btnEditarAlmacen" runat="server" CssClass="btn btn-primary" Text="Editar Almacen" CausesValidation="False" OnClick="btnEditarAlmacen_Click" />--%>
                            </div>
                            <%--<div class="btn-group pull-right">
                                  <asp:Button ID="btnVolverMenu" runat="server" CssClass="btn btn-warning btn-block" Text="Volver" CausesValidation="False" OnClick="btnVolverMenu_Click" />
                            </div>--%>
                          </div>
                        </div>
			        </div>
            </asp:Panel>
            <%--panel Crear almacen--%>
            <asp:Panel ID="pnCrearAlmacen" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblCrearAlmacen" runat="server" Text="Creal almacen"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNombreAlmacen" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvNombreCategoriaItem" runat="server" ControlToValidate="tbNombreAlmacen" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbNombreAlmacen" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblDescripcionAlmacen" runat="server" Text="Descripción:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvDescripcionCatItem" runat="server" ControlToValidate="tbDescripcionAlmacen" CssClass="text-danger" ErrorMessage="El campo Descripción es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbDescripcionAlmacen" runat="server" CssClass="form-control" onKeyPress="if(this.value.length==499) return false;" TextMode="MultiLine" Rows="5" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnGuardar_Click" />
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>
            <%--panel administar ususarios--%>
            <asp:Panel ID="pnAdmUsuarios" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblAdmUsuarios" runat="server" Text="Administrar usuarios"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                         <br />
                         <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                                        <div class="col-xs-12">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:GridView ID="gvDatos1" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" OnRowCommand="gvDatos1_RowCommand" >
                                                        <Columns>
                                                            <asp:BoundField DataField="num_sec_usuario" HeaderText="ns"   Visible="false"/>
                                                            <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                                                            <asp:BoundField DataField="persona" HeaderText="Persona" />
                                                            <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="eliminar" Text="Eliminar" >
                                                                 <ControlStyle CssClass="btn btn-sm btn-danger "/>
                                                            </asp:ButtonField>
                                                        </Columns>
                                                        <PagerStyle CssClass="GridPager" Wrap="True" />
                                                        <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                   </div>
                                                </div>
                                        </div>
                                   </div>
                            </div>
                        </div>
                    <asp:Panel ID="pnbuscar" runat="server" Visible="false">
                        <div class="row">
                            <div class="col-xs-12">
                                 <div class="form-inline">
                                       <strong><asp:Label ID="lblusuario" runat="server" Text="Usuario:"></asp:Label></strong>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbusuario" CssClass="text-danger" ErrorMessage="El campo usuario es obligatorio.">*</asp:RequiredFieldValidator>
                                       <asp:TextBox ID="tbusuario" runat="server" CssClass="form-control" MaxLength="15" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-info" Text="Buscar" CausesValidation="true" OnClick="btnBuscar_Click" />
                                 </div>
                             </div>
                         </div>
                    </asp:Panel>
                    <asp:Panel ID="pnsugeridos" runat="server" Visible="false">
                          <br />
                         <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                                        <div class="col-xs-12">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" OnRowCommand="gvDatos1_RowCommand" >
                                                        <Columns>
                                                            <asp:BoundField DataField="num_sec_usuario" HeaderText="ns"  Visible="false"/>
                                                            <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                                                            <asp:BoundField DataField="persona" HeaderText="Persona" />
                                                            <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="agregar" Text="Agregar" >
                                                                 <ControlStyle CssClass="btn btn-sm btn-success "/>
                                                            </asp:ButtonField>
                                                        </Columns>
                                                        <PagerStyle CssClass="GridPager" Wrap="True" />
                                                        <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                   </div>
                                                </div>
                                        </div>
                                   </div>
                            </div>
                        </div>
                     </asp:Panel>
                    </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar usuario" CausesValidation="false" OnClick="btnAgregarUsuario_Click" />
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
