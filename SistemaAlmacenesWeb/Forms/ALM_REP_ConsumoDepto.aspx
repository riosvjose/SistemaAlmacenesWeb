<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_REP_ConsumoDepto.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_REP_ConsumoDepto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Reporte de Consumo expresado en dinero</h1>
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
            <%--panel de Items Entregados--%>
            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label runat="server" Text="Consumo expresado en dinero en un intervalo de fechas"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblFechaInicialCon" runat="server" Width="150">Fecha inicial:</asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvFechaInicialCon" runat="server" ControlToValidate="tbFechaInicialCon" CssClass="text-danger" ErrorMessage="El campo Fecha Inicial es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-5 col-lg-3">
                                 <asp:TextBox ID="tbFechaInicialCon" runat="server" TextMode="Date" CssClass="form-control" max="3000-12-31" min="2000-01-01" MaxLength="10" AutoCompleteType="Disabled" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblFechaFinalCon" runat="server" Width="150">Fecha Final:</asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvFechaFinalCon" runat="server" ControlToValidate="tbFechaFinalCon" CssClass="text-danger" ErrorMessage="El campo Fecha Final es obligatorio.">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="rfvFechaFinalConMayor" runat="server" ControlToCompare="tbFechaInicialCon" ControlToValidate="tbFechaFinalCon" CssClass="text-danger" ErrorMessage="La Fecha Final debe ser mayor o igual a la Fecha Inicial." Operator="GreaterThanEqual" Type="Date">*</asp:CompareValidator>                            
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-5 col-lg-3">
                                 <asp:TextBox ID="tbFechaFinalCon" runat="server" TextMode="Date" CssClass="form-control" max="3000-12-31" min="2000-01-01" MaxLength="10" AutoCompleteType="Disabled" ></asp:TextBox>
                            </div>
                        </div>                                           
			        </div>
                    <%--PIE DEL PANEL--%>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-10"> 
                                <asp:Button ID="btnGenerarReportes" runat="server" CssClass="btn btn-success" Text="Generar Reporte" CausesValidation="True" OnClick="btnGenerarReportes_Click" />                                   
                            </div>
                            <div class="col-xs-2 text-right">
                                <asp:Button ID="btnVolverMenu" runat="server" CssClass="btn btn-warning btn-default btn-block" Text="Menú Principal" CausesValidation="False" OnClick="btnVolverMenu_Click"/>
                            </div>
                        </div>
			        </div>	       
			   </div>
            </asp:Panel>
            <%--panel Reporte de Costo de Consumo de Items por departamento--%>
            <asp:Panel ID="pnRepConsumoDepto" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <div class="panel-heading">
                            <h3> <strong><asp:Label ID="lblRepConsumoDepto" runat="server" ></asp:Label></strong></h3>
                        </div>			        
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-inline">
                                    <div class="form-group">
                                        <asp:GridView ID="gvConsumoDepto" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Nro."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                                                <asp:BoundField DataField="nombre_depto" HeaderText="Departamento"/>
                                                <asp:BoundField DataField="costo_total" HeaderText="Costo Total"/>
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
                                <asp:Button ID="btnLimpiarReporte" runat="server" CssClass="btn btn-warning btn-default btn-block" Text="Limpiar Reporte" CausesValidation="False" OnClick="btnLimpiarReporte_Click"/>
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
