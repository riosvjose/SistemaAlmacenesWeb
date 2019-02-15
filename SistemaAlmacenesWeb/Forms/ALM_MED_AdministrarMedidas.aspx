<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_MED_AdministrarMedidas.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_MED_AdministrarMedidas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Administrar medidas</h1>
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
            <%--panel Principal de Medidas--%>
            <asp:Panel ID="pnPrincipal" runat="server">
                <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8">
		            <div class="panel panel-info">
                        <%--ENCABEZADO DEL PANEL--%>
			            <div class="panel-heading">
                            <div class="row mb-3">
					            <h2>Listado de medidas</h2>
                            </div>
			            </div>
                        <%--CUERPO DEL PANEL--%>
                        <div class="panel-body">
                            <div class="row mb-3">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <asp:GridView ID="gvListaMedidas" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" >
                                        <Columns>
                                            <asp:BoundField DataField="nro" HeaderText="Nro." ItemStyle-Width=15%/> 
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre" /> 
                                            <asp:BoundField DataField="abreviacion" HeaderText="Abreviación" ItemStyle-Width=30%/>                                            
                                        </Columns>
                                        <PagerStyle CssClass="GridPager" Wrap="True" />
                                        <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                            </div>
			            </div>
                        <%--PIE DEL PANEL--%>
			            <div class="panel-footer">
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group">
                                    <asp:Button ID="btnCrearMedida" runat="server" CssClass="btn btn-success" Text="Crear Medida" CausesValidation="False" OnClick="btnCrearMedida_Click" />
                                </div>
                              </div>
                            </div>
			            </div>
                    </div>
            </asp:Panel>
            <%--panel Crear Medida--%>
            <asp:Panel ID="pnCrearMedida" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormMedida" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNombreMedida" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvNombreMedida" runat="server" ControlToValidate="tbNombreMedida" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbNombreMedida" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblAbrevMedida" runat="server" Text="Abreviación:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvAbrevMedida" runat="server" ControlToValidate="tbAbrevMedida" CssClass="text-danger" ErrorMessage="El campo Abreviación es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbAbrevMedida" runat="server" CssClass="form-control" MaxLength="5" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnGuardarMedida" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnGuardarMedida_Click" />
                                <asp:Button ID="btnCancelarMedida" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarMedida_Click" />
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
