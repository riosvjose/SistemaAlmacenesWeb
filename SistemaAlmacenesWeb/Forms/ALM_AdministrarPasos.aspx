<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_AdministrarPasos.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_ITEM_AdministrarPasos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Administrar pasos movimientos</h1>
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
                        <div class="row">
                            <div class="col-xs-12 col-sm-5 col-md-4 col-lg-4">
                                <strong><asp:Label ID="lblAlmacen" runat="server" Text="Almacen:" Visible="true"></asp:Label></strong>
                                <br/>
                                <asp:DropDownList ID="ddlAlmacenes" runat="server" CssClass="form-control mr-3" OnSelectedIndexChanged="ddlAlmacenes_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </div>
                            </div>
                            <div class="row">  
                                <div class="col-xs-12 col-sm-5 col-md-4 col-lg-4">
                                    <strong><asp:Label ID="lblTipoPlantilla" runat="server" Text="Movimiento:" Visible="true"></asp:Label></strong>
                                    <br/>
                                    <asp:RadioButton ID="rbIngreso" runat="server" AutoPostBack="true"  GroupName="rbMovimiento" OnCheckedChanged="rbIngreso_Click" Text="Ingreso" />
                                    <br/>
                                    <asp:RadioButton ID="rbSalidas" runat="server" AutoPostBack="true"  GroupName="rbMovimiento" OnCheckedChanged="rbSalida_Click" Text="Salida" />
                                    <br/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                    <asp:Panel ID="pnPlantilla" runat="server" Visible="false">
                                        <strong><asp:Label ID="lblPlantilla" runat="server" Text="Plantilla:" Visible="true"></asp:Label></strong>
                                        <asp:DropDownList ID="ddlPlantilla"  AutoPostBack="true" runat="server" CssClass="form-control mr-3" OnSelectedIndexChanged="ddlPlantilla_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                    <asp:Panel ID="pnPasos" runat="server" Visible="false">
                                        <strong><asp:Label ID="lblPasos" runat="server" Text="Paso:" Visible="true"></asp:Label></strong>
                                        <asp:DropDownList ID="ddlPasos" runat="server" CssClass="form-control mr-3" OnSelectedIndexChanged="ddlPasos_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    </asp:Panel>
                                </div>
                            </div>                
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnAdministrarUsuarios" runat="server" CssClass="btn btn-primary" Text="Administrar usuarios" CausesValidation="False" OnClick="btnAdmUsu_Click" />
                            </div>
                            <div class="btn-group pull-right">
                                  <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-warning btn-block" Text="Volver" CausesValidation="False" OnClick="btnVolverMenu_Click" />
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
                                                            <asp:BoundField DataField="num_sec_subdepartamento" HeaderText="ns_subdepartamento"  />
                                                            <asp:BoundField DataField="nombre_subdepto" HeaderText="Subdepartamento" />
                                                            <asp:BoundField DataField="num_sec_usuario" HeaderText="ns" />
                                                            <asp:BoundField DataField="login" HeaderText="Usuario" />
                                                            <asp:BoundField DataField="num_sec_persona" HeaderText="Persona" />
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
                             <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <strong><asp:Label ID="lblDepto" runat="server" Text="Departamento:" Visible="true"></asp:Label></strong>
                                 <br/>
                                <asp:RadioButton ID="rbTodosDeptos" runat="server" AutoPostBack="true" GroupName="RegistrarDepto" OnCheckedChanged="rbTodosDepto_Click" Text="Todos los departamentos" />
                                <br/>
                                <asp:RadioButton ID="rbUnDepto" runat="server" AutoPostBack="true" GroupName="RegistrarDepto" OnCheckedChanged="rbUnDepto_Click" Text="Un departamento específico" />
                                <asp:Panel ID="pnDeptos" runat="server" Visible="false">
                                    <asp:DropDownList ID="ddlDeptos" runat="server" CssClass="form-control mr-3" OnSelectedIndexChanged="ddlDeptos_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </asp:Panel>
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
