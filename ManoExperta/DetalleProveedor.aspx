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
                        <label>Direccion:</label>
                        <asp:TextBox ID="textBoxDireccion" runat="server" CssClass="form-control"/>
                        <label>Localidad:</label>
                        <asp:TextBox ID="textBoxLocalidad" runat="server" CssClass="form-control"/>
                    </div>
                    <div class="col" style="display: grid">
                        <label>Especialidad:</label>
                        <div class="capsulaMatricula">Matriculado</div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <h4>Estadisticas trabajos:</h4>
                    <label>Trabajos realizados: <%=repListadoResenias.Items.Count %></label>
                    <label>Puntacion: <%= usuarioTemp.Calificacion %></label>
                </div>
                <hr />
                <div class="row" style="margin: 10px">
                    <h5>Reseñas:</h5>
                    <% if (repListadoResenias.Items.Count == 0) { %>
                        <h3> Este proveedor todavía no tiene reseñas. ¡Dale una oportunidad y pedile un trabajo!</h3>
                        <% } %>
                    <% else {  %>
                    <asp:Repeater runat="server" ID="repListadoResenias">
                        <ItemTemplate>
                            <div class="card mb-3" style="width: 100%;">
                                <div class="row no-gutters">
                                    <div class="col-md-2">
                                        <img src="Resources/Images/comentario.png" class="img-fluid rounded-start" alt="..." style="max-height: 100px">
                                    </div>

                                    <div class="col-md-7">
                                        <div class="card-body">
                                            <h5 class="card-title"><%#Eval("Usuario.Nombre") %> <%#Eval("Usuario.Apellido") %></h5>
                                            <p><%# Eval("ComentarioResenia") %></p>

                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="card-body">
                                            <p>
                                                Puntuación: <%# Eval("Calificacion")%>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                <% } %>
                </div>



            </div>
        </div>
    </div>
</asp:Content>
