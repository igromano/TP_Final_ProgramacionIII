﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoProveedores.aspx.cs" Inherits="ManoExperta.ListadoProveedores" %>

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
                <h3>Buscá tu profesional:</h3>
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
                                                <p>Localidad: </p>
                                                <p>Email: <%# Eval("Email") %></p>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="card-body">
                                        <h5 style="margin-bottom: 20px">Calificacion:
                                        <div class="puntuacionEstrellas">
                                            <% for (int i = 0; i < 4; i++)
                                                { %>
                                            <i class="fas fa-solid fa-star"></i>
                                            <% } %>
                                        </div>
                                        </h5>
                                        <h5> Gasista</h5>
                                        <div class="capsulaMatricula">Matriculado</div>
                                    </div>
                                </div>
                                <div class="col-md-2 d-flex align-items-center justify-content-center">
                                    <div class="card-body">
                                        <div class="row no-gutters" style="max-width: 80%">
                                            <button class="btn btn-secondary mb-2">Más información</button>
                                            <button class="btn btn-success">Solicitar Trabajo</button>
                                        </div>
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