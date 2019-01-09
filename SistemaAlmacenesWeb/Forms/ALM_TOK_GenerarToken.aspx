<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_TOK_GenerarToken.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_TOK_GenerarToken" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="300"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Generar token</h1>
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
             <%--panel Crear Item--%>
            <asp:Panel ID="pnPrincipal" runat="server" Visible="true">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormItem" runat="server" Text="Token"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblToken" runat="server" Text=""></asp:Label></strong>
                            </div>
                        </div>
			        </div>                    
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnGenerar" runat="server" CssClass="btn btn-success" Text="Generar" CausesValidation="False" OnClick="btnGenerar_Click"/>                                                                           
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancelar_Click"/>
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
