<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoTickets.aspx.cs" Inherits="ManoExperta.ListadoTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <h3>Trabajos activos</h3>
                <asp:Repeater runat="server" ID="repTrabajosActivos">
                    <ItemTemplate>
                        <div class="card mb-3" style="width: 100%;">
                            <div class="row no-gutters">
                                <div class="col-md-2">
                                    <img src="Resources/Images/imagenProveedor.jpg" class="img-fluid rounded-start" alt="..." style="max-height: 175px">
                                </div>
                                <div class="col-md-5">
                                    <div class="card-body">
                                        <h5 class="card-title">Ticket: <%# Eval("numeroTicket") %></h5>
                                        <p class="card-text"><small class="text-muted"><%# Eval("descripcionUsuario") %></small></p>
                                        <div class="row align-items-center justify-content-cente">
                                            <div class="col-md-3">
                                                <p class="card-text"><small class="text-muted">Estado: <span class="capsulaEstadoTrabajo"><%# Eval("estadoTicket") %></span></small></p>
                                            </div>
                                            <div class="col-md-5">
                                                <p class="card-text"><small class="text-muted">Presupuesto estimado: $<%# Eval("montoTicket") %></small></p>
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
                                        <h5 class="card-title"><%# Eval("nombrePrestador") %></h5>
                                        <p class="card-text"><small class="text-muted">Gasista</small></p>
                                        <div class="capsulaMatricula">Matriculado</div>
                                    </div>
                                </div>
                                <div class="col-md-2 d-flex align-items-center justify-content-center">
                                    <div class="row no-gutters" style="max-width: 80%">
                                        <button class="btn btn-secondary mb-2">Más información</button>
                                        <button class="btn btn-success">Aceptar Trabajo</button>
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
