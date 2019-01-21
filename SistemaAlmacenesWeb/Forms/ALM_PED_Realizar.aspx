<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_PED_Realizar.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_PED_Realizar" %>

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
		            <h1>Realizar pedido</h1>
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
                            <div class="col-sm-3">
                                <strong><asp:Label ID="lblGrupo" runat="server" Text="Grupo"></asp:Label></strong>
                            </div>
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblCat" runat="server" Text="Categoria"></asp:Label></strong>
                            </div>
                            <div class="col-sm-3">
                                <strong><asp:Label ID="lblItem" runat="server" Text="Item"></asp:Label></strong>
                            </div>
                            <div class="col-sm-1">
                                <strong><asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label></strong>
                            </div>
                            <div class="col-sm-3">
                                <strong><asp:Label ID="lblPersona" runat="server" Text="Solicitante"></asp:Label></strong>
                            </div>
                        </div>
                        <asp:Panel ID="Panel1" runat="server" Visible="true">
                            <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo1" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo1_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat1" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat1_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem1" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem1_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant1" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="tbCant1_FilteredTextBoxExtender" runat="server" BehaviorID="tbCant1_FilteredTextBoxExtender" TargetControlID="tbCant1" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant1" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="tbCant1" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante1" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                         </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo2" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo2_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat2" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat2_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem2" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem2_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant2" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" BehaviorID="tbCant2_FilteredTextBoxExtender" TargetControlID="tbCant2" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant2" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="tbCant2" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante2" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel3" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo3" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo3_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat3" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat3_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem3" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem3_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant3" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" BehaviorID="tbCant3_FilteredTextBoxExtender" TargetControlID="tbCant3" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator9" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant3" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="tbCant3" ErrorMessage="El valor ingresado debe ser mayor o igual a 0." Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                 <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante3" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel4" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo4" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo4_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat4" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat4_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem4" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem4_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant4" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" BehaviorID="tbCant4_FilteredTextBoxExtender" TargetControlID="tbCant4" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator13" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant4" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="tbCant4" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante4" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel5" runat="server" Visible="false">
                            <div class="row mb-3">
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo5" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo5_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat5" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat5_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem5" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem5_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant5" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" BehaviorID="tbCant5_FilteredTextBoxExtender" TargetControlID="tbCant5" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator17" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant5" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator18" runat="server" ControlToValidate="tbCant5" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante5" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel6" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo6" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo6_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat6" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat6_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem6" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem6_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant6" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" BehaviorID="tbCant6_FilteredTextBoxExtender" TargetControlID="tbCant6" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator21" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant6" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToValidate="tbCant6" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante6" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel7" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo7" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo7_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat7" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat7_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem7" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem7_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant7" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" BehaviorID="tbCant7_FilteredTextBoxExtender" TargetControlID="tbCant7" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator25" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant7" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator26" runat="server" ControlToValidate="tbCant7" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                 <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante7" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel8" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo8" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo8_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat8" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat8_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem8" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem8_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant8" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" BehaviorID="tbCant8_FilteredTextBoxExtender" TargetControlID="tbCant1" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator27" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant1" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator28" runat="server" ControlToValidate="tbCant8" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                 <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante8" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel9" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo9" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo9_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat9" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat9_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem9" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem9_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant9" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" BehaviorID="tbCant9_FilteredTextBoxExtender" TargetControlID="tbCant9" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator29" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant9" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator30" runat="server" ControlToValidate="tbCant9" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                 <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante9" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel10" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo10" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo10_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat10" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat10_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem10" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem10_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant10" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" BehaviorID="tbCant10_FilteredTextBoxExtender" TargetControlID="tbCant10" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator31" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant10" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator32" runat="server" ControlToValidate="tbCant10" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                 <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante10" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel11" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo11" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo11_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat11" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat11_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem11" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem11_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant11" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" BehaviorID="tbCant11_FilteredTextBoxExtender" TargetControlID="tbCant11" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator41" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant11" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator42" runat="server" ControlToValidate="tbCant11" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                 <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante11" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel12" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo12" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo12_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat12" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat12_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem12" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem12_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant12" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" BehaviorID="tbCant12_FilteredTextBoxExtender" TargetControlID="tbCant12" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator45" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant12" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator46" runat="server" ControlToValidate="tbCant12" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                 <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante12" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel13" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo13" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo13_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat13" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat13_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem13" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem13_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant13" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" BehaviorID="tbCant13_FilteredTextBoxExtender" TargetControlID="tbCant13" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator49" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant13" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator50" runat="server" ControlToValidate="tbCant13" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                 <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante13" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel14" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo14" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo14_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat14" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat14_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem14" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem14_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant14" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" BehaviorID="tbCant14_FilteredTextBoxExtender" TargetControlID="tbCant14" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator53" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant14" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator54" runat="server" ControlToValidate="tbCant14" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante14" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                             </div>
                        </asp:Panel> 
                        <asp:Panel ID="Panel15" runat="server" Visible="false">
                             <div class="row mb-3">
                                 <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlGrupo15" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupo15_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCat15" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCat15_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlItem15" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem15_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:TextBox ID="tbCant15" runat="server" CssClass="form-control" MaxLength="10" Visible="true" Text="0" OnTextChanged="tbCambioValor_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server" BehaviorID="tbCant15_FilteredTextBoxExtender" TargetControlID="tbCant15" ValidChars="1234567890" />
                                    <asp:CompareValidator ID="CompareValidator57" runat="server" ErrorMessage="Formato incorrecto, en valor ingresado debe ser numerico" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbCant15" CssClass="text-danger">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator58" runat="server" ControlToValidate="tbCant15" ErrorMessage="El valor ingresado debe ser mayor o igual a 1." Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" CssClass="text-danger">*</asp:CompareValidator>
                                </div>
                                 <div class="col-sm-3">
                                   <asp:DropDownList ID="ddlSolicitante15" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged" Visible="true" AutoPostBack="True"></asp:DropDownList>
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
