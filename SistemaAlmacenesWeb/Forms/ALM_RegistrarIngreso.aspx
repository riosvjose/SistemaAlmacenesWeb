<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_RegistrarIngreso.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.RegistrarIngreso" %>

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
		            <h1>Registro de ingresos</h1>
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
            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="Label1" runat="server" Text="Datos generales del movimiento"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblFechaMov" runat="server" Width="150">Fecha de ingreso:</asp:Label></strong>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbFechaMov" CssClass="text-danger" ErrorMessage="El campo fecha de emisión es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-5 col-lg-4">
                                 <asp:TextBox ID="tbFechaMov" runat="server" CssClass="form-control" MaxLength="10" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" BehaviorID="tbFechaMov_CalendarExtender" TargetControlID="tbFechaMov" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblTarea" runat="server" Text="Tipo de ingreso:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-4">
                                <asp:DropDownList ID="ddlTipoIngreso" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoIngreso_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>                      
			        </div>
                    <%--PIE DEL PANEL--%>	       
			   </div>
            </asp:Panel>
             <%--panel Factura--%>
            <asp:Panel ID="pnFactura" runat="server" Visible="true">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFactura" runat="server" Text="Datos de la factura"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblProveedor" runat="server" Text="Provedor:"></asp:Label>                                </strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                 <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNumeroFac" runat="server" Text="Numero de factura: "></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="tbNumFac" CssClass="text-danger" ErrorMessage="El campo número factura es obligatorio.">*</asp:RequiredFieldValidator>
                                </strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-5 col-lg-4">
                                <asp:TextBox ID="tbNumFac" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNumOrden" runat="server" Text="Numero de orden: "></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbNumOrden" CssClass="text-danger" ErrorMessage="El campo número de orden es obligatorio.">*</asp:RequiredFieldValidator>
                                </strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-5 col-lg-4">
                                <asp:TextBox ID="tbNumOrden" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                         <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblFechaFac" runat="server" Width="150">Fecha de emisión:</asp:Label></strong>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbFechaFac" CssClass="text-danger" ErrorMessage="El campo fecha de emisión es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-5 col-lg-4">
                                 <asp:TextBox ID="tbFechaFac" runat="server" CssClass="form-control" MaxLength="10" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" BehaviorID="tbFechaFac_CalendarExtender" TargetControlID="tbFechaFac" />
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
		        </div>
            </asp:Panel>
             <%--panel items--%>
            <asp:Panel ID="pnItems" runat="server" Visible="true">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblItems" runat="server" Text="Items"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnAgregarItem" runat="server" CssClass="btn btn-primary" Text="Agregar Item" CausesValidation="False" OnClick="btnAgregarItem_Click" />
                                <asp:Button ID="btnQuitarItem" runat="server" CssClass="btn btn-warning" Text="Quitar Item" CausesValidation="False" OnClick="btnQuitarItem_Click" />
                              </div>        
                        </div>
                        <asp:Label ID="lblContador" runat="server" Text="1" Visible="false"></asp:Label>
                        <br />
                        <div class="row mb-3">
                            <div class="col-sm-5">
                                <strong><asp:Label ID="lblItem" runat="server" Text="Item"></asp:Label></strong>
                            </div>
                            <div class="col-sm-3">
                                <strong><asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label></strong>
                            </div>
                            <div class="col-sm-3">
                                <strong><asp:Label ID="lblPrecioUnitario" runat="server" Text="Precio Unitario"></asp:Label></strong>
                            </div>
                        </div>
                        <asp:Panel ID="Panel1" runat="server" Visible="true">
                            <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem1" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant1" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="tbCant1_FilteredTextBoxExtender" runat="server" BehaviorID="tbCant1_FilteredTextBoxExtender" TargetControlID="tbCant1" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant1" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="tbCant1" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio1" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="tbPrecio1_FilteredTextBoxExtender" runat="server" BehaviorID="tbPrecio1_FilteredTextBoxExtender" TargetControlID="tbPrecio1" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio1" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbPrecio1" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                         </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem2" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant2" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" BehaviorID="tbCant2_FilteredTextBoxExtender" TargetControlID="tbCant2" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant2" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="tbCant2" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio2" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" BehaviorID="tbPrecio2_FilteredTextBoxExtender" TargetControlID="tbPrecio2" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio2" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="tbPrecio2" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel3" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem3" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant3" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" BehaviorID="tbCant3_FilteredTextBoxExtender" TargetControlID="tbCant3" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator9" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant3" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="tbCant3" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio3" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" BehaviorID="tbPrecio3_FilteredTextBoxExtender" TargetControlID="tbPrecio3" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator11" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio3" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="tbPrecio3" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel4" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem4" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant4" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" BehaviorID="tbCant4_FilteredTextBoxExtender" TargetControlID="tbCant4" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator13" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant4" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="tbCant4" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio4" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" BehaviorID="tbPrecio4_FilteredTextBoxExtender" TargetControlID="tbPrecio4" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator15" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio4" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToValidate="tbPrecio4" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel5" runat="server" Visible="false">
                            <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem5" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant5" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" BehaviorID="tbCant5_FilteredTextBoxExtender" TargetControlID="tbCant5" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator17" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant5" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator18" runat="server" ControlToValidate="tbCant5" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio5" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" BehaviorID="tbPrecio5_FilteredTextBoxExtender" TargetControlID="tbPrecio5" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator19" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio5" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator20" runat="server" ControlToValidate="tbPrecio5" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel6" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem6" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant6" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" BehaviorID="tbCant6_FilteredTextBoxExtender" TargetControlID="tbCant6" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator21" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant6" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToValidate="tbCant6" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio6" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" BehaviorID="tbPrecio6_FilteredTextBoxExtender" TargetControlID="tbPrecio6" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator23" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio6" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator24" runat="server" ControlToValidate="tbPrecio6" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel7" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem7" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant7" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" BehaviorID="tbCant7_FilteredTextBoxExtender" TargetControlID="tbCant7" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator25" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant7" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator26" runat="server" ControlToValidate="tbCant7" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio7" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" BehaviorID="tbPrecio7_FilteredTextBoxExtender" TargetControlID="tbPrecio7" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator33" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio7" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator34" runat="server" ControlToValidate="tbPrecio7" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel8" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem8" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant8" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" BehaviorID="tbCant8_FilteredTextBoxExtender" TargetControlID="tbCant1" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator27" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant1" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator28" runat="server" ControlToValidate="tbCant1" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio8" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" BehaviorID="tbPrecio8_FilteredTextBoxExtender" TargetControlID="tbPrecio8" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator35" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio8" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator36" runat="server" ControlToValidate="tbPrecio8" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel9" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem9" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant9" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" BehaviorID="tbCant9_FilteredTextBoxExtender" TargetControlID="tbCant9" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator29" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant9" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator30" runat="server" ControlToValidate="tbCant9" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio9" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" BehaviorID="tbPrecio9_FilteredTextBoxExtender" TargetControlID="tbPrecio9" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator37" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio9" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator38" runat="server" ControlToValidate="tbPrecio9" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel10" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem10" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant10" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" BehaviorID="tbCant10_FilteredTextBoxExtender" TargetControlID="tbCant10" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator31" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant10" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator32" runat="server" ControlToValidate="tbCant10" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio10" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" BehaviorID="tbPrecio10_FilteredTextBoxExtender" TargetControlID="tbPrecio10" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator39" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio10" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator40" runat="server" ControlToValidate="tbPrecio10" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel11" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem11" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant11" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" BehaviorID="tbCant11_FilteredTextBoxExtender" TargetControlID="tbCant11" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator41" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant11" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator42" runat="server" ControlToValidate="tbCant11" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio11" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" BehaviorID="tbPrecio11_FilteredTextBoxExtender" TargetControlID="tbPrecio11" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator43" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio11" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator44" runat="server" ControlToValidate="tbPrecio11" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel12" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem12" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant12" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" BehaviorID="tbCant12_FilteredTextBoxExtender" TargetControlID="tbCant12" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator45" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant12" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator46" runat="server" ControlToValidate="tbCant12" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio12" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" BehaviorID="tbPrecio12_FilteredTextBoxExtender" TargetControlID="tbPrecio12" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator47" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio12" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator48" runat="server" ControlToValidate="tbPrecio12" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel13" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem13" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant13" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" BehaviorID="tbCant13_FilteredTextBoxExtender" TargetControlID="tbCant13" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator49" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant13" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator50" runat="server" ControlToValidate="tbCant13" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio13" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" BehaviorID="tbPrecio13_FilteredTextBoxExtender" TargetControlID="tbPrecio13" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator51" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio13" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator52" runat="server" ControlToValidate="tbPrecio13" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel14" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem14" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant14" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" BehaviorID="tbCant14_FilteredTextBoxExtender" TargetControlID="tbCant14" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator53" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant14" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator54" runat="server" ControlToValidate="tbCant14" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio14" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server" BehaviorID="tbPrecio14_FilteredTextBoxExtender" TargetControlID="tbPrecio14" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator55" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio14" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator56" runat="server" ControlToValidate="tbPrecio14" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel15" runat="server" Visible="false">
                             <div class="row mb-3">
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlItem15" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbCant15" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server" BehaviorID="tbCant15_FilteredTextBoxExtender" TargetControlID="tbCant15" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator57" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant15" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator58" runat="server" ControlToValidate="tbCant15" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="tbPrecio15" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server" BehaviorID="tbPrecio15_FilteredTextBoxExtender" TargetControlID="tbPrecio15" ValidChars=".1234567890" />
                                    <asp:CompareValidator ID="CompareValidator59" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbPrecio15" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator60" runat="server" ControlToValidate="tbPrecio15" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                             </div>
                        </asp:Panel> 
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
