<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_PED_Buscar.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_PED_Buscar" %>

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
		            <h1>Buscar pedido</h1>
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
                            <asp:Panel ID="pnAlmacen" runat="server" Visible="true">
                                <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                    <strong><asp:Label ID="lblAlmacenes" runat="server" Text="Almacen:"></asp:Label></strong>
                                </div>
                                <div class="col-xs-12 col-sm-7 col-md-9 col-lg-10">
                                    <asp:DropDownList ID="ddlAlmacenes" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlAlmacenes_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="row mb-3">
                            <asp:Panel ID="pnSubdepto" runat="server" Visible="true">
                                <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                    <strong><asp:Label ID="lblSubdeptos" runat="server" Text="Subdepartamento:"></asp:Label></strong>
                                </div>
                                <div class="col-xs-12 col-sm-7 col-md-9 col-lg-10">
                                    <asp:DropDownList ID="ddlSubdeptos" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlSubdeptos_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </asp:Panel>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                            <div class="row">
                                <div class="col-xs-6 text-left">
                                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-success" Text="Buscar" CausesValidation="False" OnClick="btnBuscar_Click" />
                                </div>
                                <div class="col-xs-6 text-right">
                                    <asp:Button ID="btnVolver" CssClass="btn btn-warning" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                                </div>
                            </div>
                        </div>
			        </div>
            </asp:Panel>
             <%--panel pedidos--%>
            <asp:Panel ID="pnBuscar" runat="server" Visible="false">
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
