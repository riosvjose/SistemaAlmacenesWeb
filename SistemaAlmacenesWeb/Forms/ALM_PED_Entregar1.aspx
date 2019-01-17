<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_PED_Entregar1.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_PED_Entregar1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
           
        </Triggers>
        <ContentTemplate>

            <div class="row">
                 <%--<div class="col-md-3 pull-right">
                    <div class="col-xs-12 text-right">
                        <br/>
                         
                        <div class="btn-group">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-info" Text="Atrás" CausesValidation="False" OnClick="btnAtras_Click" />
                        </div>
                   </div>
                </div>--%>
	            <div class="col-xs-12 col-md-6 pull-left">
		            <h1>Entregar pedido</h1>
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
            <%--panel principal--%>
            <asp:Panel ID="pnPrincipal" runat="server" Visible="true">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="Label1" runat="server" Text="Ver pedidos autorizados"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <br />
                         <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                                    <div class="col-xs-4" >
                                        </div>
                                        <div class="col-xs-4" >
                                                <div class="form-group">
                                                    <label>Usuario</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-user fa-fw"></i></span>
                                                        <asp:TextBox ID="tbUsuario" CssClass="form-control" placeholder="Ingrese su usuario ..." runat="server" MaxLength="20" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="tbCI_RequiredFieldValidator" ControlToValidate="tbUsuario" runat="server" ErrorMessage="Debe ingresar su usuario." Text="*" CssClass="text-warning"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>Contraseña</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-key fa-fw"></i></span>
                                                        <asp:TextBox ID="tbPassword" CssClass="form-control" placeholder="Ingrese su contraseña ..." runat="server" TextMode="Password" MaxLength="32" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="tbPassword_RequiredFieldValidator" ControlToValidate="tbPassword" runat="server" ErrorMessage="Debe ingresar su contraseña." Text="*" CssClass="text-warning"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>Token</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-key fa-fw"></i></span>
                                                        <asp:TextBox ID="tbToken" CssClass="form-control" placeholder="Ingrese el token ..." runat="server" MaxLength="32" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbToken" runat="server" ErrorMessage="Debe ingresar su contraseña." Text="*" CssClass="text-warning"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="row">  
                                                    <div class="col-xs-12 col-sm-5 col-md-4 col-lg-4">
                                                            <strong><asp:Label ID="lblTipoUsuario" runat="server" Text="Movimiento:" Visible="true"></asp:Label></strong>
                                                            <br/>
                                                            <asp:RadioButton ID="rbAdmin" runat="server" AutoPostBack="false"  GroupName="rbuser" OnCheckedChanged="rb_Click" Text="Administrativo" />
                                                            <br/>
                                                            <asp:RadioButton ID="rbAsistente" runat="server" AutoPostBack="false"  GroupName="rbuser" OnCheckedChanged="rb_Click" Text="Asistente" />
                                                            <br/>
                                                        </div>
                                                    </div>
                                                <asp:Button ID="btnIngresar" CssClass="btn btn-success" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                                                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                                    <ProgressTemplate>
                                                        <asp:Image ID="imgProcesando" runat="server" ImageUrl="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA==" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            <br />
                                        </div>
                                   </div>
                            </div>
                        </div>
                    </div>
                    <%--PIE DEL PANEL--%>
		        </div>
            </asp:Panel>
             <%--panel pedidos--%>
            <asp:Panel ID="pnPedidos" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblPedidos" runat="server" Text="Pedidos"></asp:Label></strong></h3>
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
                                                            <asp:BoundField DataField="num_sec_transaccion" HeaderText="Nro"  />
                                                            <%--<asp:BoundField DataField="depto" HeaderText="Departamento" Visible="false" />--%>
                                                            <asp:BoundField DataField="persona" HeaderText="Solicitante" />
                                                            <asp:BoundField DataField="num_sec_paso" HeaderText="Paso" />
                                                            <asp:BoundField DataField="paso" HeaderText="Estado" />
                                                            <asp:BoundField DataField="num_sec_item" HeaderText="Item" />
                                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
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
                    </div>
                    <%--PIE DEL PANEL--%>
		        </div>
                <asp:Button ID="btnEntregar" CssClass="btn btn-success" runat="server" Text="Entregar" OnClick="btnEntregar_Click" />
            </asp:Panel>
           <%--Panel mensajes error--%>
            <div class="row">
	            <asp:Panel ID="pnMensajeError" runat="server" Visible="false">
		            <div class="alert alert-danger alert-dismissable">
			            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>
		            </div>
	            </asp:Panel>

	            <asp:Panel ID="pnMensajeOK" runat="server" Visible="false">
		            <div class="alert alert-success alert-dismissable">
			            <asp:Label ID="lblMensajeOK" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>
		            </div>
	            </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
