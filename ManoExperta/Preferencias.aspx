<%@ Page Title="Preferencias" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Preferencias.aspx.cs" Inherits="ManoExperta.Preferencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManagerPreferencias" runat="server"></asp:ScriptManager>
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex;">

            <div class="col-2" style="background-color: #B3E2A7; border-radius: 10px; padding: 20px; margin-right: 10px">
                <h4><%= usuariotemp.Nombre %> <%= usuariotemp.Apellido %></h4>
                <h5><%= usuariotemp.Email %></h5>
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
                            <h3>Datos de tu cuenta:</h3>
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
                            <h3>Tus datos de ingreso:</h3>
                            <div class="row">
                                <div class="col">

                                    <div class="form-text opacity-100 needs-validation">
                                        <asp:Label ID="lblUser" CssClass="form-label fw-bold" runat="server" Text="Usuario"></asp:Label>
                                        <asp:TextBox ID="TextBoxUsuarioUsuario" CssClass="form-control" runat="server" required="true" OnTextChanged="cambioDatos"></asp:TextBox>
                                        <asp:Label ID="lblValidateUser" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <hr />

                            <h3>Contanos de vos:</h3>
                            <hr />

                            <h5>¿Cómo te llamás?</h5>
                            <div class="row">
                                <div class="col">
                                    <div id="nombreUsuario" class="form-text">
                                        <asp:Label ID="Label7" CssClass="form-label fw-bold" runat="server" Text="Nombre"></asp:Label>
                                        <asp:TextBox ID="TextBoxNombreUsuario" CssClass="form-control" AutoPostBack="true" runat="server" required="true" OnTextChanged="cambioDatos"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col">
                                    <div id="apellidoUsuario" class="form-text">
                                        <asp:Label ID="Label8" CssClass="form-label fw-bold" runat="server" Text="Apellido"></asp:Label>
                                        <asp:TextBox ID="TextBoxApellidoUsuario" CssClass="form-control" AutoPostBack="true" runat="server" required="true" OnTextChanged="cambioDatos"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <br />
                            <h5>¿Cual es tu email?</h5>
                            <div id="emailUsuario" class="form-text">
                                <asp:Label ID="Label16" CssClass="form-label fw-bold" runat="server" Text="Email"></asp:Label>
                                <asp:TextBox ID="TextBoxEmailUsuario" CssClass="form-control" TextMode="Email" AutoPostBack="true" runat="server" required="true" OnTextChanged="cambioDatos"></asp:TextBox>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <h5>¿Cual es tu teléfono?</h5>
                                    <div id="telefonoUsuario" class="form-text">
                                        <asp:Label ID="labelTelefono" CssClass="form-label fw-bold" runat="server" Text="Telefono"></asp:Label>
                                        <asp:TextBox ID="TextBoxTelefono" CssClass="form-control" TextMode="Phone" AutoPostBack="true" runat="server" required="true" OnTextChanged="cambioDatos"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col">
                                    <h5>¿Cual es tu DNI?</h5>
                                    <div id="DNIUsuario" class="form-text">
                                        <asp:Label ID="labelDNI" CssClass="form-label fw-bold" runat="server" Text="DNI"></asp:Label>
                                        <asp:TextBox ID="TextBoxDNI" CssClass="form-control" AutoPostBack="true" runat="server" required="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <h5>¿Cuando naciste?</h5>
                            <div id="fechaNacimiento" class="form-text">
                                <asp:Label ID="labelNacimiento" CssClass="form-label fw-bold" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                                <asp:TextBox ID="TextBoxFechaNacimiento" CssClass="form-control" TextMode="Date" AutoPostBack="true" runat="server" required="true" OnTextChanged="cambioDatos"></asp:TextBox>
                            </div>
                            <br />
                            <h5>¿Con que sexo te indentificás?</h5>
                            <p class="d-inline-flex gap-1">
                                <asp:DropDownList ID="DropDownSexo" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="cambioDatos">
                                    <asp:ListItem Text="" Value="X"></asp:ListItem>
                                    <asp:ListItem Text="Prefiero no decir" Value="O"></asp:ListItem>
                                    <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                    <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                </asp:DropDownList>

                            </p>
                            <hr />
                            <h3>¿Donde vivís?</h3>
                            <hr />
                            <h5>¿Cuál es tu dirección?</h5>
                            <div class="row">
                                <div class="col-4">
                                    <asp:Label ID="labelDireccionCalle" CssClass="form-label fw-bold" runat="server" Text="Calle"></asp:Label>
                                    <asp:TextBox ID="TextBoxDireccionCalle" CssClass="form-control" AutoPostBack="true" runat="server" required="true" OnTextChanged="cambioDatos"></asp:TextBox>
                                </div>
                                <div class="col-4">
                                    <asp:Label ID="labelLocalidad" CssClass="form-label fw-bold" runat="server" Text="Localidad"></asp:Label>
                                    <asp:DropDownList ID="DropDownListLocalidad" runat="server" CssClass="form-select" AutoPostBack="true" OnTextChanged="cambioDatos"></asp:DropDownList>
                                </div>
                                <div class="col-4">
                                    <asp:Label ID="labelProvincia" CssClass="form-label fw-bold" runat="server" Text="Provincia"></asp:Label>
                                    <asp:DropDownList ID="DropDownListProvincia" runat="server" CssClass="form-select" AutoPostBack="true" OnTextChanged="cambioDatos"></asp:DropDownList>
                                </div>
                            </div>
                            <% if (usuariotemp.RolUsuario == dominio.RolUsuario.PRESTADOR)
                                {%>
                            <hr />
                            <div class="row">
                                <div class="col-12">
                                    <h5>¿Cuál es tu especialidad?:</h5>
                                    <asp:DropDownList ID="DropDownListEspecialidad" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="cambioDatos"></asp:DropDownList>
                                </div>
                            </div>
                            <% } %>

                            <br />
                            <div class="row justify-content-center">
                                <div class="col-auto">
                                    <asp:Button ID="btnActualizarDatos" CssClass="btn btn-success" runat="server" Text="Actualizar Datos" Enabled="false" OnClick="btnActualizarDatos_Click" />
                                </div>
                                <div class="col-auto">
                                    <asp:Button ID="btnDescartar" CssClass="btn btn-danger" runat="server" Text="Descartar Cambios" Enabled="false" OnClick="btnDescartar_Click" CausesValidation="false" ValidationGroup="none" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
