<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SistemaAlmacenes.Forms.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="300"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
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
    </div>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Inicio</h1>
        </div>
    </div>

    <div class="row">
        <div class="visible-xs">
            <img src="../Img/LogoPeqUCB.png" class="img-responsive" width="140" alt="LogoUcbWeb" style="margin: 0 auto; padding-top: 15px; padding-bottom: 15px;" />
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <div class="text-center">

                <asp:LinkButton ID="lbSalidas" runat="server" OnClick="lbSalidas_Click">
                    <asp:Panel ID="pnSalidas" runat="server" CssClass="panel-dashboard" role="button" style="margin:0; padding:0;">
                        <div class="hidden-xs">
                            <div class="ASR5DCB-v-l ASR5DCB-v-n">
                                    <asp:Image ID="imgSalidas" CssClass="ASR5DCB-d-Vc" ImageUrl="~/Img/Salidas.png" Width="70px" Height="70px" runat="server" />
                            </div>
                        </div>
                        <div class="gwt-Label ASR5DCB-v-q ASR5DCB-v-s quantumMediumText">Salidas</div>
                        <div class="gwt-Label ASR5DCB-v-d quantumFadedDescriptionText ASR5DCB-v-e" style="width:200px;">Registre su salida y retorno.</div>
                    </asp:Panel>
                </asp:LinkButton>
            </div>
        </div>
        <div class="visible-xs">
            <div class="col-xs-12">
                <br />
            </div>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <div class="text-center">
                <asp:LinkButton ID="lbTareas" runat="server" OnClick="lbTareas_Click">
                    <asp:Panel ID="pnTareas" runat="server" CssClass="panel-dashboard" role="button" style="margin:0; padding:0;">
                        <div class="hidden-xs">
                            <div class="ASR5DCB-v-l ASR5DCB-v-n">
                                <asp:Image ID="imgTareas" CssClass="ASR5DCB-d-Vc" ImageUrl="~/Img/Tareas.png" Width="52px" Height="52px" runat="server" />
                            </div>
                        </div>
                        <div class="gwt-Label ASR5DCB-v-q ASR5DCB-v-s quantumMediumText" style="width:200px;">Tareas</div>
                        <div class="gwt-Label ASR5DCB-v-d quantumFadedDescriptionText ASR5DCB-v-e" style="width:200px;">Registre sus tareas.</div>
                    </asp:Panel>
                </asp:LinkButton>
            </div>
        </div>
        <div class="visible-xs">
            <div class="col-xs-12">
                <br />
            </div>
        </div>
        <div class="visible-sm">
            <div class="col-sm-12">
                <br /><br />
            </div>
        </div>                
    </div>
    <div class="visible-lg visible-md">
        <div class="col-lg-12">
            <br /><br />
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <div class="text-center">
                <asp:LinkButton ID="lbProyectos" runat="server" OnClick="lbProyectos_Click">
                    <asp:Panel ID="pnProyectos" runat="server" CssClass="panel-dashboard" role="button" style="margin:0; padding:0;">
                        <div class="hidden-xs">
                            <div class="ASR5DCB-v-l ASR5DCB-v-n">
                                <asp:Image ID="imgProyectos" CssClass="ASR5DCB-d-Vc" ImageUrl="~/Img/Proyectos.png" Width="70px" Height="70px" runat="server" />
                            </div>
                        </div>
                        <div class="gwt-Label ASR5DCB-v-q ASR5DCB-v-s quantumMediumText" style="width:200px;">Proyectos</div>
                        <div class="gwt-Label ASR5DCB-v-d quantumFadedDescriptionText ASR5DCB-v-e" style="width:200px;">Registre sus proyectos y actividades.</div>
                    </asp:Panel>
                </asp:LinkButton>
            </div>
        </div>
        <div class="visible-xs">
            <div class="col-xs-12">
                <br />
            </div>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <div class="text-center">
                <asp:LinkButton ID="lbControlAulas" runat="server" OnClick="lbControlAulas_Click" Visible="false">
                    <asp:Panel ID="pnControlAulas" runat="server" CssClass="panel-dashboard" role="button" style="margin:0; padding:0;">
                        <div class="hidden-xs">
                            <div class="ASR5DCB-v-l ASR5DCB-v-n">
                                <asp:Image ID="Image1" CssClass="ASR5DCB-d-Vc" ImageUrl="~/Img/icon-people-2.png" Width="70px" Height="70px" runat="server" />
                            </div>
                        </div>
                        <div class="gwt-Label ASR5DCB-v-q ASR5DCB-v-s quantumMediumText" style="width:200px;">Control Aulas</div>
                        <div class="gwt-Label ASR5DCB-v-d quantumFadedDescriptionText ASR5DCB-v-e" style="width:200px;">Registre la asistencia de los docentes en aula.</div>
                    </asp:Panel>
                </asp:LinkButton>
            </div>
        </div>
        <div class="visible-xs">
            <div class="col-xs-12">
                <br />
            </div>
        </div>
        <div class="visible-sm">
            <div class="col-sm-12">
                <br /><br />
            </div>
        </div>
    </div>
</asp:Content>
