<%@ Page Title="Eliminar Cuenta" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EliminarCuenta.aspx.cs" Inherits="ManoExperta.EliminarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <div class="container" style="max-width: 1000px">
                    <h3>Eliminar Cuenta</h3>
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
                    <% } %>
                    <%} %>
                    <h5>Es una lastima que te vayas. Esta opción es irreversible. Una vez que eliminás tu cuenta, se borran todos tus datos e historial de servicios. Si sos proveedor, perderás toda tu puntuación y reviews</h5>
                    <h5>¿Estás seguro que deseas contiunar?</h5>
                    <br />
                    <h5>Para confirmar la baja, por favor ingresá tu usuario y contraseña</h5>
                    <br />
                    <div class="container" style="max-width: 600px">
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
                        <br />
                        <div class="row">
                            <asp:Button ID="btnEliminarCuenta" CssClass="btn btn-danger" runat="server" Text="Eliminar Cuenta" OnClick="btnEliminarCuenta_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
