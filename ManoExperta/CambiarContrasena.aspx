<%@ Page Title="Cambiar Contraseña" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CambiarContrasena.aspx.cs" Inherits="ManoExperta.CambiarContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">

        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex;">
            <div class="col-2" style="background-color: #B3E2A7; border-radius: 10px; padding: 20px; margin-right: 10px">
                <h4><%= usuarioTemp.Nombre %> <%= usuarioTemp.Apellido %></h4>
                <h5><%= usuarioTemp.Email %></h5>
                <hr />
                <menu>
                    <li><a href="Preferencias.aspx" style="text-decoration: none; color: black; font-weight: bold;">Mis datos</a></li>
                    <li><a href="CambiarContrasena.aspx" style="text-decoration: none; color: black; font-weight: bold;">Cambiar Contraseña</a></li>
                    <li><a href="EliminarCuenta.aspx" style="text-decoration: none; color: black; font-weight: bold;">Eliminar Cuenta</a></li>
                    <li><a href="CerrarSesion.aspx" style="text-decoration: none; color: black; font-weight: bold;">Cerrar Sesion</a></li>
                </menu>


            </div>
            <div class="col-10 justify-content-center" id="InfoCentral" style="background-color: #B3E2A7; border-radius: 10px; padding: 20px;">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="container" style="max-width: 1000px">
                            <h3>Cambiar Contraseña:</h3>
                            <hr />
                            <%if (alerta.codigo != 0)
                                {
                                    if (alerta.codigo == 1)
                                    { %>
                            <div class="alert alert-success alert-dismissible fade show" role="alert">
                                <%= alerta.mensaje %>
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>
                            <% }%>
                            <%else if (alerta.codigo == 2)
                                { %>
                            <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                <%= alerta.mensaje %>
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>
                            <% }%>
                            <%} %>
                            <h5>Por favor, ingresá tu contrseña actual y la nueva contraseña.</h5>
                            <br />
                            <div class="container" style="max-width: 600px">
                                <div class="form-text opacity-100 needs-validation">
                                    <asp:Label ID="lblUser" CssClass="form-label fw-bold" runat="server" Text="Contraseña actual"></asp:Label>
                                    <asp:TextBox ID="TextBoxContrasenaActual" CssClass="form-control" TextMode="Password" runat="server" required="true"></asp:TextBox>
                                    <asp:Label ID="lblValidateUser" runat="server" Text=""></asp:Label>
                                </div>

                                <div id="passwordHelpBlockUsuario" class="form-text">
                                    <asp:Label ID="lblPass" CssClass="form-label fw-bold" runat="server" Text="Contraseña nueva"></asp:Label>
                                    <asp:TextBox ID="TextBoxUsuarioContrasenia" CssClass="form-control" TextMode="Password" runat="server" required="true"></asp:TextBox>
                                </div>
                                <div id="passwordHelpBlockRepetirUsuario" class="form-text">
                                    <asp:Label ID="Label15" CssClass="form-label fw-bold" runat="server" Text="Repetir contraseña nueva"></asp:Label>
                                    <asp:TextBox ID="TextBoxUsuarioContraseniaConfirmar" CssClass="form-control" TextMode="Password" runat="server" required="true"></asp:TextBox>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:Button ID="btnActualizarContrasena" CssClass="btn btn-success" runat="server" Text="Cambiar Contraseña" OnClick="btnActualizarContrasena_Click" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
