<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Preferencias.aspx.cs" Inherits="ManoExperta.Preferencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex;">
            <div class="col-2" style="background-color: #B3E2A7; border-radius: 10px; padding: 20px; margin-right: 10px">
                <h4>Nombre de Usuario</h4>
                <h5>Email del Usuario</h5>
                <hr />
                <menu>
                    <li><a href="Preferencias.aspx" style="text-decoration: none; color: black; font-weight: bold;">Mis datos</a></li>
                    <li><a href="EliminarCuenta.aspx" style="text-decoration: none; color: black; font-weight: bold;">Eliminar Cuenta</a></li>
                    <li><a href="#" style="text-decoration: none; color: black; font-weight: bold;">Cerrar Sesion</a></li>
                </menu>


            </div>
            <div class="col-10 justify-content-center" id="InfoCentral" style="background-color: #B3E2A7; border-radius: 10px; padding: 20px;">
                <div class="container" style="max-width: 1000px">
                    <h3>Tus datos de ingreso:</h3>
                    <div class="row">
                        <div class="col">

                            <div class="form-text opacity-100 needs-validation">
                                <asp:Label ID="lblUser" CssClass="form-label fw-bold" runat="server" Text="Usuario"></asp:Label>
                                <asp:TextBox ID="TextBoxUsuarioUsuario" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                <asp:Label ID="lblValidateUser" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col">
                            <div id="passwordHelpBlockUsuario" class="form-text">
                                <asp:Label ID="lblPass" CssClass="form-label fw-bold" runat="server" Text="Contraseña"></asp:Label>
                                <asp:TextBox ID="TextBoxUsuarioContrasenia" CssClass="form-control" TextMode="Password" runat="server" required="true"></asp:TextBox>
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
                                <asp:TextBox ID="TextBoxNombreUsuario" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col">
                            <div id="apellidoUsuario" class="form-text">
                                <asp:Label ID="Label8" CssClass="form-label fw-bold" runat="server" Text="Apellido"></asp:Label>
                                <asp:TextBox ID="TextBoxApellidoUsuario" CssClass="form-control" runat="server" required="true" disabled="true"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <br />
                    <h5>¿Cual es tu email?</h5>
                    <div id="emailUsuario" class="form-text">
                        <asp:Label ID="Label16" CssClass="form-label fw-bold" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="TextBoxEmailUsuario" CssClass="form-control" TextMode="Email" runat="server" required="true"></asp:TextBox>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col">
                            <h5>¿Cual es tu teléfono?</h5>
                            <div id="telefonoUsuario" class="form-text">
                                <asp:Label ID="labelTelefono" CssClass="form-label fw-bold" runat="server" Text="Telefono"></asp:Label>
                                <asp:TextBox ID="TextBoxTelefono" CssClass="form-control" TextMode="Phone" runat="server" required="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col">
                            <h5>¿Cual es tu DNI?</h5>
                            <div id="DNIUsuario" class="form-text">
                                <asp:Label ID="labelDNI" CssClass="form-label fw-bold" runat="server" Text="DNI"></asp:Label>
                                <asp:TextBox ID="TextBoxDNI" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <h5>¿Cuando naciste?</h5>
                    <div id="fechaNacimiento" class="form-text">
                        <asp:Label ID="labelNacimiento" CssClass="form-label fw-bold" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                        <asp:TextBox ID="TextBoxFechaNacimiento" CssClass="form-control" TextMode="Date" runat="server" required="true"></asp:TextBox>
                    </div>
                    <br />
                    <h5>¿Con que sexo te indentificás?</h5>
                    <p class="d-inline-flex gap-1">
                        <input type="radio" class="btn-check btn-outline-secondary" name="genero" id="masculino" autocomplete="off">
                        <label class="btn btn-outline-secondary" for="masculino">Masculino</label>

                        <input type="radio" class="btn-check" name="genero" id="femenino" autocomplete="off">
                        <label class="btn btn-outline-secondary" for="femenino">Femenino</label>

                        <input type="radio" class="btn-check" name="genero" id="noBinario" autocomplete="off">
                        <label class="btn btn-outline-secondary" for="noBinario">No Binario</label>

                        <input type="radio" class="btn-check" name="genero" id="prefieroNoDecir" autocomplete="off">
                        <label class="btn btn-outline-secondary" for="prefieroNoDecir">Prefiero no decir</label>

                    </p>
                    <hr />
                    <h3>¿Donde vivís?</h3>
                    <hr />
                    <h5>¿Cuál es tu dirección?</h5>
                    <div class="row">
                        <div class="col-8">
                            <asp:Label ID="labelDireccionCalle" CssClass="form-label fw-bold" runat="server" Text="Calle"></asp:Label>
                            <asp:TextBox ID="TextBoxDireccionCalle" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <asp:Label ID="labelAlturaCalle" CssClass="form-label fw-bold" runat="server" Text="Altura"></asp:Label>
                            <asp:TextBox ID="TextBoxAlturaCalle" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <h5>¿En que barrio vivís?</h5>
                    <div class="row">
                        <div class="col-4">
                            <asp:Label ID="labelDropBarrio" CssClass="form-label fw-bold" runat="server" Text="Barrio"></asp:Label>
                            <asp:DropDownList ID="DropDownBarrio" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="col-4">
                            <asp:Label ID="labelDropProvincia" CssClass="form-label fw-bold" runat="server" Text="Provincia"></asp:Label>
                            <asp:DropDownList ID="DropDownListProvincia" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="col-4">
                            <asp:Label ID="labelCodigoPostal" CssClass="form-label fw-bold" runat="server" Text="Cod. Postal"></asp:Label>
                            <asp:TextBox ID="TextBoxCodigoPostal" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Button ID="btnActualizarDatos" CssClass="btn btn-danger" runat="server" Text="Actualizar Datos" />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
