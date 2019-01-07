<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_SAL_Autorizar.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_SAL_Autorizar" %>

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
		            <h1>Autorizar salida</h1>
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
             <%--panel pedidos--%>
            <asp:Panel ID="pnPedidos" runat="server" Visible="true">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblPedidos" runat="server" Text="Salidas"></asp:Label></strong></h3>
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
                                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad Requerida" />
                                                            <asp:BoundField DataField="descripcion" HeaderText="Detalle" />
                                                            <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="autorizar" Text="Autorizar" >
                                                                 <ControlStyle CssClass="btn btn-sm btn-success "/>
                                                            </asp:ButtonField>
                                                            <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="rechazar" Text="Rechazar" >
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
