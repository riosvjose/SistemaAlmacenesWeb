<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="SAL_Registrar.aspx.cs" Inherits="SistemaAlmacenes.Forms.SAL_Registrar" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
           
        </Triggers>
        <ContentTemplate>

            <div class="row">
                <div class="col-md-4 pull-right">
                    <br/>
                     <asp:LinkButton ID="lbtPagAnterior" runat="server" CausesValidation="False" CssClass="TextoBoton" Width="100px" OnClick="lbtPagAnterior_Click" >Página anterior</asp:LinkButton>
                </div>
	            <div class="col-xs-12 col-md-6 pull-left">
		            <h1>Registrar salida</h1>
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
             <%--panel items--%>
            <asp:Panel ID="pnItems" runat="server" Visible="true">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblSalida" runat="server" Text="Salidas"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
                    <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblCat" runat="server" Text="Categoria:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-4">
                                 <asp:DropDownList ID="ddlCat1" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblItem" runat="server" Text="Item:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-4">
                                 <asp:DropDownList ID="ddlItem1" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div> 
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblTipoSalida" runat="server" Text="Tipo salida:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-4">
                                 <asp:DropDownList ID="ddlTipoSal" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoSal_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div> 
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label>
                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="tbCant1" CssClass="text-danger" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="tbCant1" CssClass="text-danger" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0">*</asp:CompareValidator>
                                </strong>
                            </div>
                            <div class="col-xs-3 col-sm-3 col-md-2 col-lg-2">
                                 <asp:TextBox ID="tbCant1" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="tbCant1_FilteredTextBoxExtender" runat="server" BehaviorID="tbCant1_FilteredTextBoxExtender" TargetControlID="tbCant1" ValidChars="1234567890" />
                            </div>
                        </div>  
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-4 col-md-3 col-lg-2">
                                 <strong><asp:Label ID="lblMotivo" runat="server" Text="Motivo:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-8 col-md-6 col-lg-6">
                                 <asp:TextBox ID="tbMotivo" runat="server" CssClass="form-control" MaxLength="150" Visible="true" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                            </div>
                        </div>                     
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                     <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar Cambios" CausesValidation="True" OnClick="btnGuardar_Click" />
                                     <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancelar_Click" />
                                </div>
                        </div>
			        </div>
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
