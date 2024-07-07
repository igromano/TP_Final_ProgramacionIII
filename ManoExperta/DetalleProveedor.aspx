<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleProveedor.aspx.cs" Inherits="ManoExperta.DetalleProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex;">
            <div class="container" style="background-color: #B3E2A7; padding: 10px;">
                <h3>Detalle</h3>
                <h4><%= usuarioTemp.Nombre %> <%=usuarioTemp.Apellido %></h4>
                <hr />
                <hr />
                <div class="row">
                    <div class="col" style="display: grid">
                        <label>Direccion: <%= usuarioTemp.Domicilio %></label>
                        <label>Localidad: <%= usuarioTemp.IdLocalidad %></label>
                    </div>
                    <div class="col" style="display: grid">
                        <label>Especialidad:</label>
                        <div class="capsulaMatricula">Matriculado</div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <h4>Estadisticas trabajos:</h4>
                    <label>Trabajos realizados: <%=trabajos %></label>
                    <label>Puntacion:</label>
                </div>
                <hr />
                <div class="row" style="margin: 10px">
                    <h5>Reseñas:</h5>
                    <asp:Repeater runat="server" ID="repListadoResenias">
                        <ItemTemplate>
                            <div class="card mb-3" style="width: 100%;">
                                <div class="row no-gutters">
                                    <div class="col-md-2">
                                        <img src="Resources/Images/comentario.png" class="img-fluid rounded-start" alt="..." style="max-height: 100px">
                                    </div>
                                </div>
                                <h5 class="card-title"><%#Eval("Usuario.Nombre") %> <%#Eval("Usuario.Apellido") %></h5>
                                <p><%# Eval("ComentarioResenia") %></p>
                                <p>
                                    Puntuación: <%# Eval("Calificacion")%>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>



            </div>
        </div>
    </div>
</asp:Content>
