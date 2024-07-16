<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleProveedor.aspx.cs" Inherits="ManoExperta.DetalleProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex; height: 100vh">
            <div class="container" style="background-color: #B3E2A7; padding: 10px; border-radius:10px">
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
                <h3>Detalle</h3>
                <h4><%= usuarioTemp.Nombre %> <%=usuarioTemp.Apellido %></h4>
                <hr />
                <hr />
                <div class="row">
                    <div class="col-6" style="display: grid">
                        <div class="row">
                            <div class="col">
                                <label>Direccion:</label>
                                <asp:TextBox ID="textBoxDireccion" runat="server" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Localidad:</label>
                                <asp:TextBox ID="textBoxLocalidad" runat="server" CssClass="form-control" ReadOnly="true" />
                            </div>
                            <div class="col">
                                <label>Provincia:</label>
                                <asp:TextBox ID="textBoxProvincia" runat="server" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="row">
                            <div class="col">
                                <label>Email:</label>
                                <asp:TextBox ID="textBoxEmail" runat="server" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>Especialidad:</label>
                                <asp:TextBox ID="textBoxEspecialidad" runat="server" CssClass="form-control" ReadOnly="true" />
                            </div>
                            <div class="col-6">
                                <label>Prestador desde:</label>
                                <asp:TextBox ID="textBoxPrestadorDesde" runat="server" CssClass="form-control" TextMode="Date" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <h4>Estadisticas trabajos:</h4>
                    <label>Trabajos realizados: <%=trabajos %></label>
                    <label>Puntacion: <%= usuarioTemp.Calificacion %></label>
                </div>
                <hr />
                <div class="row" style="margin: 10px">
                    <h5>Reseñas:</h5>
                    <% if (repListadoResenias.Items.Count == 0)
                        { %>
                    <h3>Este proveedor todavía no tiene reseñas. ¡Dale una oportunidad y pedile un trabajo!</h3>
                    <% } %>
                    <% else
                        {  %>
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
                <div class="row" style="margin-left: 10px; margin-right: 10px; margin-top: 20px; justify-content: flex-end;">
                    <div class="col text-right">
                        <%if (usuario.Sexo.ToString().Equals("X") || usuario.Sexo.ToString().Equals("0"))%>
                        <%{%>
                        <asp:Button ID="button1" runat="server" CssClass="btn btn-success mb-2" Text="Solicitar Trabajo" OnClick="buttonSolicitarTrabajo_Click" Enabled="false" />
                        <%} %>
                        <% else %>
                        <%{ %>

                        <asp:Button ID="buttonSolicitarTrabajo" runat="server" CssClass="btn btn-success mb-2" Text="Solicitar Trabajo" OnClick="buttonSolicitarTrabajo_Click" />
                        <%} %>
                    </div>
                </div>



            </div>
        </div>
    </div>
</asp:Content>
