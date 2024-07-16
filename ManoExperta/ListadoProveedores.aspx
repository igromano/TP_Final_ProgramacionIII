<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoProveedores.aspx.cs" Inherits="ManoExperta.ListadoProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <link href="Style/Home.css" rel="stylesheet" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
                <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex;">
                    <div class="col-2" style="background-color: #B3E2A7; padding: 10px;">
                        <h3>Filtros</h3>
                        <div class="row g-3">
                            <div class="col-12">
                                <label>Por especialidad:</label>
                                <asp:DropDownList ID="DropDownListaEspecialidadFiltro" CssClass="form-select form-select-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="filtro" />
                            </div>
                            <div class="col-12">
                                <label>Por Provincia:</label>
                                <asp:DropDownList ID="DropDownListProvinciaFiltro" CssClass="form-select form-select-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="filtro"></asp:DropDownList>
                            </div>
                            <div class="col-12">
                                <label>Por Localidad:</label>
                                <asp:DropDownList ID="DropDownListLocalidadFiltro" CssClass="form-select form-select-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="filtro"></asp:DropDownList>
                            </div>
                            <div class="col-12">
                                <asp:Button ID="buttonLimpiarFiltro" CssClass="btn btn-success" runat="server" Text="Limpiar Filtro" OnClick="buttonLimpiarFiltro_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-10" id="InfoCentral" style="background-color: #B3E2A7; padding: 20px;">
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
                        <h3>Buscá tu profesional:</h3>
                        <% if (repListadoProfesionales.Items.Count == 0)
                            { %>
                        <h5>¡Ups!... Todavía no hay proveedores para esta zona o especialidad. Si conocés alguno, ¡Invitalo a unirse!</h5>
                        <% }

                        %>
                        <%else
                            { %>
                        <asp:Repeater runat="server" ID="repListadoProfesionales">
                            <ItemTemplate>
                                <div class="card mb-3" style="width: 100%;">
                                    <div class="row no-gutters">
                                        <div class="col-md-2">
                                            <img src="Resources/Images/imagenProveedor.jpg" class="img-fluid rounded-start" alt="..." style="max-height: 200px">
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card-body">
                                                <h4 class="card-title"><%# Eval("Nombre") %> <%# Eval("Apellido") %></h4>
                                                <div class="row">
                                                    <div class="col">
                                                        <p>Direccion: <%# Eval("Domicilio") %></p>
                                                        <p>Localidad: <%# obtenerLocalidad(Convert.ToInt32(Eval("IdLocalidad"))) %></p>
                                                        <p>Email: <%# Eval("Email") %></p>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card-body">
                                                <span>
                                                    <h5 style="margin-bottom: 20px">Puntuacion: <%# obtenerCalificacion(Convert.ToInt32(Eval("Calificacion"))) %>                                      </h5>
                                                    </h5>
                                                </span>
                                                <h5>Especialidad: <%# Eval("Especialidad.Nombre")%></h5>
                                            </div>
                                        </div>
                                        <div class="col-md-2 d-flex align-items-center justify-content-center">
                                            <div class="card-body">
                                                <div class="row no-gutters" style="max-width: 80%">
                                                    <asp:Button ID="buttonMasInformacion" runat="server" CssClass="btn btn-secondary mb-2" Text="Más información" CommandArgument='<%#Eval("ID")%>' CommandName="ProveedorID" OnClick="buttonMasInformacion_Click" />
                                                    <%if (usuariotemp.Sexo.ToString().Equals("X") || usuariotemp.Sexo.ToString().Equals("0"))%>
                                                      <%{%>
                                                    <asp:Button ID="button1" runat="server" CssClass="btn btn-success mb-2" Text="Solicitar Trabajo" CommandArgument='<%#Eval("ID")%>' CommandName="ProveedorID" OnClick="buttonSolicitarTrabajo_Click" Enabled="false"/>
                                                      <%} %>
                                                    <% else %>
                                                    <%{ %>

                                                    <asp:Button ID="buttonSolicitarTrabajo" runat="server" CssClass="btn btn-success mb-2" Text="Solicitar Trabajo" CommandArgument='<%#Eval("ID")%>' CommandName="ProveedorID" OnClick="buttonSolicitarTrabajo_Click" />
                                                    <%} %>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%} %>
                        <hr />

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
