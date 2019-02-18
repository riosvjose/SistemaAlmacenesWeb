<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_PED_Autorizar.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_PED_Autorizar" %>

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
		            <h1>Autorizar pedido</h1>
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
            <asp:Panel ID="pn1raAut" runat="server" Visible="true">
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
                                                            <asp:BoundField DataField="item" HeaderText="Item" />
                                                            <asp:BoundField DataField="num_sec_item" HeaderText="ns_item" />
                                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad solicitada" />
                                                            <asp:TemplateField HeaderText="Cantidad autorizada" Visible="true">
                                                               <ItemTemplate>
                                                                 <asp:TextBox ID="tbCantAut" runat="server" Enabled="false"></asp:TextBox>
                                                                   <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCantAut" CssClass="text-danger">*</asp:CompareValidator>
                                                                   <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="tbCantAut" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                                               </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="autorizar" Text="Autorizar" CausesValidation="true" >
                                                                 <ControlStyle CssClass="btn btn-sm btn-success "/>
                                                            </asp:ButtonField>
                                                            <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="modificar" Text="Modificar" >
                                                                 <ControlStyle CssClass="btn btn-sm btn-warning "/>
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
                 <%--Mensaje de Error AJAXValidator--%>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" /> 
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
