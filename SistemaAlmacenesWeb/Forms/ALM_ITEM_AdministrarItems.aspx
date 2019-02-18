<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ALM_ITEM_AdministrarItems.aspx.cs" Inherits="SistemaAlmacenesWeb.Forms.ALM_ITEM_AdministrarItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Administrar items</h1>
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
            <%--panel Principal de Items--%>
            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">                        
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <strong><asp:Label ID="lblItems" runat="server" Text="Item:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-9 col-lg-10">
                                <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnCrearItem" runat="server" CssClass="btn btn-success" Text="Crear item" CausesValidation="False" OnClick="btnCrearItem_Click" />
                                <asp:Button ID="btnEditarItem" runat="server" CssClass="btn btn-primary" Text="Editar item" CausesValidation="False" OnClick="btnEditarItem_Click" />
                                <asp:Button ID="btnEliminarItem" runat="server" CssClass="btn btn-danger" Text="Eliminar item" CausesValidation="False" OnClick="btnEliminarItem_Click" />
                            </div>
                          </div>
                        </div>
			        </div>
            </asp:Panel>
            <%--panel Crear Item--%>
            <asp:Panel ID="pnCrearItem" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormItem" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblCodigoItem" runat="server" Text="Código:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvCodigoItem" runat="server" ControlToValidate="tbCodigoItem" CssClass="text-danger" ErrorMessage="El campo Código es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbCodigoItem" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" BehaviorID="tbCodigoItem_FilteredTextBoxExtender" TargetControlID="tbCodigoItem" ValidChars="1234567890_QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblNombreItem" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvNombreItem" runat="server" ControlToValidate="tbNombreItem" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbNombreItem" runat="server" CssClass="form-control" MaxLength="150" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" BehaviorID="tbNombreItem_FilteredTextBoxExtender" TargetControlID="tbNombreItem" ValidChars="1234567890_QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm " />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblGrupoItem" runat="server" Text="Grupo:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlGrupoItem" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGrupoItem_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblCategoriaItem" runat="server" Text="Categoría:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlCategoriaItem" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                            <div>
                                <asp:Button ID="btnAgregarCategoria" runat="server" CssClass="btn btn-primary" Text="Agregar categoría" CausesValidation="False" OnClick="btnAgregarCategoria_Click"/>                                                                           
                            </div>                            
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblMedidaItem" runat="server" Text="Medida:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlMedidaItem" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                            <div>
                                <asp:Button ID="btnAgregarMedida" runat="server" CssClass="btn btn-primary" Text="Agregar medida" CausesValidation="False" OnClick="btnAgregarMedida_Click"/>                                                                           
                            </div> 

                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblStockItem" runat="server" Text="Stock mínimo:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvStockItem" runat="server" ControlToValidate="tbStockItem" CssClass="text-danger" ErrorMessage="El campo Stock es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbStockItem" runat="server" CssClass="form-control" onKeyPress="if(this.value.length==5) return false;" type="number" min="0" max="99999" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="tbStockItem_FilteredTextBoxExtender" runat="server" BehaviorID="tbStockItem_FilteredTextBoxExtender" FilterType="Numbers" InvalidChars="0123456789" TargetControlID="tbStockItem" />
                            </div>
                        </div>
			        </div>                    
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnGuardarItem" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnGuardarItem_Click" />
                                <asp:Button ID="btnCancelarItem" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarItem_Click" />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>
            <%--MODAL CREAR CATEGORIA--%>
            <asp:UpdatePanel ID="upCategoriaItem" runat="server" Visible="false">    
                <ContentTemplate>
                    <div id="modalCategoriaItem" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modalLblCategoria" aria-hidden="true" >                              
                        <div class="modal-dialog" role="document">                                
                            <div class="modal-content">                                  
                                <div class="modal-header">                                    
                                    <center><h3 class="modal-title" id="modalLblCategoria">Agregar Categoría</h3></center>                                                                          
                                </div>                                                                      
                                <div class="modal-body">                                                                                                              
                                    <form>                                                                                                                      
                                        <div class="form-group">                                          
                                            <strong><asp:Label ID="lblNombreCategoria" runat="server">Nombre:</asp:Label></strong>                                          
                                            <asp:TextBox ID="tbNombreCategoria" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled" required="" ></asp:TextBox>                                                                                                                   
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" BehaviorID="tbNombreCategoria_FilteredTextBoxExtender" TargetControlID="tbNombreCategoria" ValidChars="1234567890_QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm " />
                                        </div>                                      
                                        <div class="form-group">                                          
                                            <strong><asp:Label ID="lblDescripcion" runat="server">Descripción:</asp:Label></strong>                                          
                                            <asp:TextBox ID="tbDescripcionCategoria" runat="server" CssClass="form-control" onKeyPress="if(this.value.length==499) return false;" TextMode="MultiLine" Rows="2" AutoCompleteType="Disabled" required="" ></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" BehaviorID="tbDescripcionCategoria_FilteredTextBoxExtender" TargetControlID="tbDescripcionCategoria" ValidChars="1234567890_QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm " />
                                        </div>
                                        <div class="form-group">                                                                                      
                                            <strong><asp:Label ID="lblGrupoCategoria" runat="server">Grúpo de Categoría:</asp:Label></strong>
                                            <asp:DropDownList ID="ddlGrupoCategoria" runat="server" CssClass="form-control" required="" ></asp:DropDownList>
                                        </div>                                    
                                    </form>                                                                     
                                </div>                                                                      
                                <div class="modal-footer">                                                                            
                                    <asp:Button ID="btnGuardarModalCat" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="False" OnClick="btnGuardarModalCat_Click"/>                                                                           
                                    <asp:Button ID="btnCancelarModalCat" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClientClick="CancelarModalCategoria()" OnClick="btnCancelarModalCat_Click"/>                                                                                                                                       
                                </div>                                
                            </div>                              
                        </div>                            
                    </div>                    
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--MODAL CREAR MEDIDA--%>
            <asp:UpdatePanel ID="upMedidaItem" runat="server" Visible="false">    
                <ContentTemplate>
                    <div id="modalMedidaItem" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modalLblMedida" aria-hidden="true" >                              
                        <div class="modal-dialog" role="document">                                
                            <div class="modal-content">                                  
                                <div class="modal-header">                                    
                                    <center><h3 class="modal-title" id="modalLblMedida">Agregar Medida</h3></center>                                                                          
                                </div>                                                                      
                                <div class="modal-body">                                                                                                              
                                    <form>                                                                                                                      
                                        <div class="form-group">                                          
                                            <strong><asp:Label ID="lblNombreMedida" runat="server">Nombre:</asp:Label></strong>                                          
                                            <asp:TextBox ID="tbNombreMedida" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled" required="" ></asp:TextBox>                                                                                                                   
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" BehaviorID="tbNombreMedida_FilteredTextBoxExtender" TargetControlID="tbNombreMedida" ValidChars="1234567890_QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm " />
                                        </div>                                      
                                        <div class="form-group">                                          
                                            <strong><asp:Label ID="lblAbrevMedida" runat="server">Abreviación:</asp:Label></strong>                                          
                                            <asp:TextBox ID="tbAbrevMedida" runat="server" CssClass="form-control" MaxLength="5" AutoCompleteType="Disabled" required="" ></asp:TextBox>                                                                                                                   
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" BehaviorID="tbAbrevMedida_FilteredTextBoxExtender" TargetControlID="tbAbrevMedida" ValidChars="1234567890_QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm/@" />
                                        </div>                                   
                                    </form>                                                                     
                                </div>                                                                      
                                <div class="modal-footer">                                                                            
                                    <asp:Button ID="btnGuardarModalMedida" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="False" OnClick="btnGuardarModalMedida_Click"/>                                                                           
                                    <asp:Button ID="btnCancelarModalMedida" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClientClick="CancelarModalMedida()" OnClick="btnCancelarModalMedida_Click"/>                                                                                                                                       
                                </div>                                
                            </div>                              
                        </div>                            
                    </div>                    
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--panel Editar Item--%>
            <asp:Panel ID="pnEditarItem" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblFormEditarItem" runat="server" Text=""></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarCodigoItem" runat="server" Text="Código:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarCodigoItem" runat="server" ControlToValidate="tbEditarCodigoItem" CssClass="text-danger" ErrorMessage="El campo Código es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarCodigoItem" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" BehaviorID="tbEditarCodigoItem_FilteredTextBoxExtender" TargetControlID="tbEditarCodigoItem" ValidChars="1234567890_QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarNombreItem" runat="server" Text="Nombre:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarNombreItem" runat="server" ControlToValidate="tbEditarNombreItem" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarNombreItem" runat="server" CssClass="form-control" MaxLength="150" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" BehaviorID="tbEditarNombreItem_FilteredTextBoxExtender" TargetControlID="tbEditarNombreItem" ValidChars="1234567890_QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm " />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarCategoriaItem" runat="server" Text="Categoria:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlEditarCategoriaItem" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarMedidaItem" runat="server" Text="Medida:"></asp:Label></strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:DropDownList ID="ddlEditarMedidaItem" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEditarStockItem" runat="server" Text="Stock mínimo:"></asp:Label></strong>
                                <asp:RequiredFieldValidator ID="rfvEditarStockItem" runat="server" ControlToValidate="tbEditarStockItem" CssClass="text-danger" ErrorMessage="El campo Stock es obligatorio.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEditarStockItem" runat="server" CssClass="form-control" onKeyPress="if(this.value.length==5) return false;" type="number" min="0" max="99999" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="tbEditarStockItem_FilteredTextBoxExtender" runat="server" BehaviorID="tbEditarStockItem_FilteredTextBoxExtender" FilterType="Numbers" InvalidChars="0123456789" TargetControlID="tbEditarStockItem" />
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnEditarGuardarItem" runat="server" CssClass="btn btn-success" Text="Guardar" CausesValidation="True" OnClick="btnEditarGuardarItem_Click"  />
                                <asp:Button ID="btnEditarCancelarItem" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnEditarCancelarItem_Click"  />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>
            <%--panel Confirmar borrado de Item--%>
            <asp:Panel ID="pnBorrarItem" runat="server" Visible="false" CssClass="bg-danger" >
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3><strong><asp:Label ID="lblBorrarItem" runat="server" Text="Eliminar Item" ForeColor="#9e0501"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <h2><strong><asp:Label ID="lblFormBorrarItem" runat="server" Text="" ForeColor="#9e0501"></asp:Label></strong></h2>
                            </div>
                        </div>
                    </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnBorrarItem" runat="server" CssClass="btn btn-danger" Text="Confirmar" CausesValidation="False" OnClick="btnBorrarItem_Click" />
                                <asp:Button ID="btnCancelarBorrarItem" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarBorrarItem_Click" />
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
            <script type="text/javascript">
                function CancelarModalCategoria() {
                    document.getElementById('<%= tbNombreCategoria.ClientID %>').removeAttribute('required');
                    document.getElementById('<%= tbDescripcionCategoria.ClientID %>').removeAttribute('required');
                    document.getElementById('<%= ddlGrupoCategoria.ClientID %>').removeAttribute('required');
                }
                function CancelarModalMedida() {
                    document.getElementById('<%= tbNombreMedida.ClientID %>').removeAttribute('required');
                    document.getElementById('<%= tbAbrevMedida.ClientID %>').removeAttribute('required');                    
                }
            </script>    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
