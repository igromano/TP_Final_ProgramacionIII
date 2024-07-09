<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ManoExperta.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Style.css" rel="stylesheet" />
    <div class="container-fluid" style="display: flex; align-items: center; justify-content: center; height: 100%; width: 100%">
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLabel">Creación de Usuario</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body" style="align-items: center">
                        <h3>¿Que tipo de Usuario desea crear? </h3>
                        <div class="container align-self-end">
                            <div class="d-grid gap-2 p-4">
                                <asp:Button ID="Button1" type="button" runat="server" Text="Nuevo Usuario" CssClass="btn btn-secondary" data-bs-dismiss="modal" OnClick="CrearUsuario" />
                            </div>
                            <div class="d-grid gap-2 p-4">
                                <asp:Button ID="Proveedor" type="button" runat="server" Text="Nuevo Proveedor" CssClass="btn btn-secondary" data-bs-dismiss="modal" OnClick="CrearProveedor" />

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="align-items: center">
                        <div class="container align-self-end">
                            <div class="d-grid gap-2 p-4">
                                <a class="btn btn-danger" href="/Login.aspx">Salir</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <% if (creaUsuario)
            { %>
        <form class="row g-3 needs-validation" novalidate>
            <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">

                <div id="registrarUsuario" class="container opacity-85" style="--bs-bg-opacity: .5; max-width: 400px; padding: 20px; background-color: white; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                    <%if (errorBool)
                        { %>
                    <div class="alert alert-danger" role="alert">
                        <%:error %>
                    </div>
                    <%} %>
                    <div id="nombreUsuario" class="form-text">
                        <asp:Label ID="Label7" CssClass="form-label fw-bold" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="TextBoxNombreUsuario" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                    </div>
                    <div id="apellidoUsuario" class="form-text">
                        <asp:Label ID="Label8" CssClass="form-label fw-bold" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="TextBoxApellidoUsuario" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                    </div>
                    <div id="DNIUsuario" class="form-text">
                        <asp:Label ID="Label12" CssClass="form-label fw-bold" runat="server" Text="DNI"></asp:Label>
                        <asp:TextBox ID="TextBoxDNI" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                    </div>
                    <div id="emailUsuario" class="form-text">
                        <asp:Label ID="Label16" CssClass="form-label fw-bold" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="TextBoxEmailUsuario" CssClass="form-control" TextMode="Email" runat="server" required="true"></asp:TextBox>
                    </div>
                    <div class="form-text opacity-100 needs-validation">
                        <asp:Label ID="lblUser" CssClass="form-label fw-bold" runat="server" Text="Usuario"></asp:Label>
                        <asp:TextBox ID="TextBoxUsuarioUsuario" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                        <asp:Label ID="lblValidateUser" runat="server" Text=""></asp:Label>
                    </div>

                    <div id="passwordHelpBlockUsuario" class="form-text">
                        <asp:Label ID="lblPass" CssClass="form-label fw-bold" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="TextBoxUsuarioContrasenia" CssClass="form-control" TextMode="Password" runat="server" required="true"></asp:TextBox>
                    </div>
                    <div id="passwordHelpBlockRepetirUsuario" class="form-text">
                        <asp:Label ID="Label15" CssClass="form-label fw-bold" runat="server" Text="Repetir Contraseña"></asp:Label>
                        <asp:TextBox ID="TextBoxUsuarioContraseniaConfirmar" CssClass="form-control" TextMode="Password" runat="server" required="true"></asp:TextBox>
                    </div>


                    <div class="d-grid gap-2 p-4">
                        <asp:Button ID="btnRegistrarUsuario" CssClass="btn btn-success" runat="server" Text="Registrar" OnClick="AltaUsuario" />
                        <a href="Index.aspx" class="btn btn-danger">Cancelar</a>

                    </div>
                    <asp:Label ID="lblIp" runat="server"></asp:Label>
                </div>
            </div>
        </form>

        <% } %>
        <% if (creaProveedor)
            { %>
        <form class="row g-3 needs-validation" novalidate>
            <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
                <div id="registrarProveedor" class="container opacity-85" style="--bs-bg-opacity: .5; max-width: 400px; padding: 20px; background-color: white; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                    <div id="nombreProveedor" class="form-text">
                        <asp:Label ID="Label9" CssClass="form-label fw-bold" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="TextBoxNombreProveedor" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                    </div>
                    <div id="apellidoProveedor" class="form-text">
                        <asp:Label ID="Label10" CssClass="form-label fw-bold" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="TextBoxApellidoProveedor" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                    </div>
                    <div id="CUILProveedor" class="form-text">
                        <asp:Label ID="Label11" CssClass="form-label fw-bold" runat="server" Text="CUIL"></asp:Label>
                        <asp:TextBox ID="TextBoxCUIL" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                    </div>
                    <div id="emailProveedor" class="form-text">
                        <asp:Label ID="Label5" CssClass="form-label fw-bold" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="TextBoxEmailProveedor" CssClass="form-control" TextMode="Email" runat="server" required="true"></asp:TextBox>
                    </div>

                    <div class="form-text opacity-100 needs-validation">
                        <asp:Label ID="Label1" CssClass="form-label fw-bold" runat="server" Text="Usuario"></asp:Label>
                        <asp:TextBox ID="TextBoxUsuarioProveedor" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="passwordHelpBlockProveedor" class="form-text">
                        <asp:Label ID="Label3" CssClass="form-label fw-bold" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="TextBoxProveedorContrasenia" CssClass="form-control" TextMode="Password" runat="server" required="true"></asp:TextBox>
                    </div>
                    <div id="passwordHelpBlockRepetirProveedor" class="form-text">
                        <asp:Label ID="Label4" CssClass="form-label fw-bold" runat="server" Text="Repetir Contraseña"></asp:Label>
                        <asp:TextBox ID="TextBoxProveedorContraseniaConfirmar" CssClass="form-control" TextMode="Password" runat="server" required="true"></asp:TextBox>
                    </div>


                    <div class="d-grid gap-2 p-4">
                        <asp:Button ID="btnRegistrarProveedor" CssClass="btn btn-success" runat="server" Text="Registrar" OnClick="AltaProveedor" />
                        <a href="Index.aspx" class="btn btn-danger">Cancelar</a>
                    </div>
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                </div>
            </div>
        </form>
        <% } %>

        <script type="text/javascript">
            $(document).ready(() => {
                var modalMostrar = ('<%= modalOpciones%>' === 'True') ? true : false;
                var myModal = new bootstrap.Modal(document.getElementById('staticBackdrop'));
                if (modalMostrar) {
                    myModal.show();
                }
                else {
                    myModal.hide();
                }
            })

        </script>
    </div>


</asp:Content>
