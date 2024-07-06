<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisServicios.aspx.cs" Inherits="ManoExperta.MisServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
            window.onload = function () {
                var divs = document.querySelectorAll(".capsulaEstadoTrabajo");

                divs.forEach(function (div) {
                    var texto = div.textContent || div.innerText;

                    if (texto === "EN PROCESO") {
                        div.style.backgroundColor = "#FFA500";
                    } else if (texto === "REALIZADO") {
                        div.style.backgroundColor = "#008000";
                    } else if (texto === "SOLICITADO") {
                        div.style.backgroundColor = "#0000FF";
                    } else {
                        div.style.backgroundColor = "#F44336";
                    }
                });
            };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex;">
            <div class="col-2" style="background-color: #B3E2A7; padding: 10px;">
                <h3>Menú de Navegación</h3>
                <ul>
                    <li><a href="#" style="text-decoration: none; color: black;">Opción 1</a></li>
                    <li><a href="#" style="text-decoration: none; color: black;">Opción 2</a></li>
                    <li><a href="#" style="text-decoration: none; color: black;">Opción 3</a></li>
                </ul>
            </div>
            <div class="col-10" id="InfoCentral" style="background-color: #B3E2A7; padding: 20px;">
                <h3>Trabajos activos</h3>
                <asp:Repeater runat="server" ID="repTrabajosActivos" OnItemCommand="TrabajosActivos_ItemCommand">
                    <ItemTemplate>
                        <div class="card mb-3" style="width: 100%;">
                            <div class="row no-gutters">
                                <div class="col-md-2">
                                    <img src="Resources/Images/imagenProveedor.jpg" class="img-fluid rounded-start" alt="..." style="max-height: 175px">
                                </div>
                                <div class="col-md-5">
                                    <div class="card-body">
                                        <h5 class="card-title">Ticket: <%# Eval("Id") %></h5>
                                        <p class="card-text"><small class="text-muted"><%# Eval("ComentariosUsuario") %></small></p>
                                        <div class="row align-items-center justify-content-cente">
                                            <div class="col-md-3">
                                                <p class="card-text"><small class="text-muted">Estado: <span class="capsulaEstadoTrabajo"><%# Eval("Estado") %></span></small></p>
                                            </div>
                                            <div class="col-md-5">
                                                <p class="card-text"><small class="text-muted">Presupuesto estimado: $<%# Eval("Monto") %></small></p>
                                            </div>
                                            <%-- 
                                            <div class="col-md-4">
                                                <p class="card-text"><small class="text-muted">Dias estimados: 4 días</small></p>
                                            </div>
                                            --%>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("Prestador") %></h5>
                                        <p class="card-text"><small class="text-muted"><%# Eval("Especialidad") %></small></p>
                                        <div class="capsulaMatricula">Matriculado</div>
                                    </div>
                                </div>
                                <div class="col-md-2 d-flex align-items-center justify-content-center">
                                    <div class="row no-gutters" style="max-width: 80%">
                                        <asp:Button ID="btnMasInfo" CssClass="btn btn-secondary mb-2" runat="server" Text="Mas información" CommandName="MasInfo" CommandArgument='<%# Eval("Id") %>' />
                                        <asp:Button ID="BtnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar Trabajo" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <hr />
                <h3>Historial de trabajos</h3>
                <asp:Repeater runat="server" ID="repHistorialTrabajos">
                    <ItemTemplate>
                        <div class="card mb-3" style="width: 100%;">
                            <div class="row no-gutters">
                                <div class="col-md-2">
                                    <img src="Resources/Images/imagenProveedor.jpg" class="img-fluid rounded-start" alt="..." style="max-height: 175px">
                                </div>
                                <div class="col-md-5">
                                    <div class="card-body">
                                        <h5 class="card-title">Ticket: <%# Eval("Id") %></h5>
                                        <p class="card-text"><small class="text-muted"><%# Eval("ComentariosUsuario") %></small></p>
                                        <div class="row align-items-center justify-content-cente">
                                            <div class="col-md-3">
                                                <p class="card-text"><small class="text-muted">Estado: <span class="capsulaEstadoTrabajo"><%# Eval("Estado") %></span></small></p>
                                            </div>
                                            <div class="col-md-5">
                                                <p class="card-text"><small class="text-muted">Costo total: $<%# Eval("Monto") %></small></p>
                                            </div>
                                            <div class="col-md-4">
                                                <p class="card-text" style="margin-bottom: 2px"><small class="text-muted">Tu Puntuacion:</small></p>
                                                <div class="puntuacionEstrellas">
                                                    <%# new string('★', int.Parse(Eval("Calificacion").ToString())) %>
                                                </div>

                                            </div>
                                        </div>


                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="card-body">
                                        <h5 class="card-title">Carlos Gabriel Gimenez</h5>
                                        <p class="card-text"><small class="text-muted">Gasista</small></p>
                                        <div class="capsulaMatricula">Matriculado</div>
                                    </div>
                                </div>
                                <div class="col-md-2 d-flex align-items-center justify-content-center">
                                    <div class="row no-gutters" style="max-width: 80%">
                                        <asp:Button ID="btnMasInfo" CssClass="btn btn-secondary mb-2" runat="server" Text="Mas información" CommandName="MasInfo" CommandArgument='<%# Eval("Id") %>' />

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
</asp:Content>
