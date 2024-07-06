<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoTickets.aspx.cs" Inherits="ManoExperta.ListadoTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex;">
            <div class="col-2" style="background-color: #B3E2A7; padding: 10px;">
                <h3>Filtros</h3>
                <div class="row g-3">
                    <div class="col-12">
                        <label>Por especialidad:</label>
                        <asp:DropDownList ID="DropDownListaEspecialidadFiltro" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-12">
                        <label>Por Provincia:</label>
                        <asp:DropDownList ID="DropDownListProvinciaFiltro" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-12">
                        <label>Por Localidad:</label>
                        <asp:DropDownList ID="DropDownListLocalidadFiltro" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-10" id="InfoCentral" style="background-color: #B3E2A7; padding: 20px;">
                <h3>Trabajos Disponibles</h3>
                <asp:Repeater runat="server" ID="repTrabajosActivos">
                    <ItemTemplate>
                        <div class="card mb-3" style="width: 100%;">
                            <div class="row no-gutters">
                                <div class="col-md-2">
                                    <img src="Resources/Images/imagenProveedor.jpg" class="img-fluid rounded-start" alt="...">
                                </div>
                                <div class="col-md-5">
                                    <div class="card-body">
                                        <h5 class="card-title">Ticket: <%# Eval("Id") %></h5>
                                        <h6>Solicitud:</h6>
                                        <h6 class="card-text"><small class="text-muted"><%# Eval("ComentariosUsuario") %></small></h6>
                                        <div class="row align-items-center justify-content-cente">
                                            <div class="col-md-3">
                                                <p class="card-text"><small class="text-muted">Estado: <span class="capsulaEstadoTrabajo"><%# Eval("Estado") %></span></small></p>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("Usuario.Nombre") %> <%# Eval("Usuario.Apellido") %> </h5>
                                        <p class="card-text"><small class="text-muted"><%# Eval("Usuario.Domicilio") %></small></p>
                                        <p class="card-text"><small class="text-muted"><%# Eval("FechaSolicitado") %></small></p>
                                        <h6 class="card-text"><small class="text-muted">Especialidad: <%# Eval("Especialidad") %></small></h6>

                                    </div>
                                </div>
                                <div class="col-md-2 d-flex align-items-center justify-content-center">
                                    <div class="row no-gutters" style="max-width: 80%">
                                        <button class="btn btn-secondary mb-2">Más información</button>
                                        <button class="btn btn-success">Tomar Trabajo</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <hr />

            </div>
        </div>
    </div>
    <script type="text/javascript">
        window.onload = function () {
            var divs = document.querySelectorAll(".capsulaEstadoTrabajo");

            divs.forEach(function (div) {
                var texto = div.textContent || div.innerText;

                if (texto === "EN PROCESO") {
                    div.style.backgroundColor = "#FFA500"; // Naranja para Pendiente
                } else if (texto === "REALIZADO") {
                    div.style.backgroundColor = "#008000"; // Verde para Completado
                } else if (texto === "SOLICITADO") {
                    div.style.backgroundColor = "#0000FF"; // Azul para En Proceso
                } else {
                    div.style.backgroundColor = "#F44336"; // Color por defecto
                }
            });
        };
    </script>
</asp:Content>
