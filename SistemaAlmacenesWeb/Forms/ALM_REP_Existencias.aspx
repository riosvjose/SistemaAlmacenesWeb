<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_REP_Existencias.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_REP_Existencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="ibtnExportarExcel" />
        </Triggers>
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Reporte de Existencia de Items</h1>
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
            <%--panel Reporte de Existencia de Items--%>
            <asp:Panel ID="pnRepExistenciaItem" runat="server" Visible="true">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label runat="server" Text="Existencia de Items"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                                <div class="col-xs-12 text-right">
                                   <asp:ImageButton ID="ibtnExportarExcel" ImageUrl="~/Img/excel.png" runat="server" OnClick="ibtnExportarExcel_Click" />
                             </div>
                         </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-inline">
                                    <div class="form-group">
                                        <asp:GridView ID="gvExistenciaItem" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Nro." ><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                                                <asp:BoundField DataField="num_sec_item" HeaderText="id" />
                                                <asp:BoundField DataField="item" HeaderText="Item" />
                                                <asp:BoundField DataField="existencia" HeaderText="Existencias" />
                                                <asp:BoundField DataField="reserva" HeaderText="Reservados" />
                                                <asp:BoundField DataField="saldo_real" HeaderText="Saldo Real" />                                            
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
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-10">                                
                            </div>
                            <div class="col-xs-2 text-right">
                                <asp:Button ID="btnVolverMenu" runat="server" CssClass="btn btn-warning btn-default btn-block" Text="Menú Principal" CausesValidation="False" OnClick="btnVolverMenu_Click"/>
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

