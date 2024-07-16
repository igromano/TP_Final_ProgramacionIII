<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ManoExperta.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManagerPreferencias" runat="server"></asp:ScriptManager>
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex; border-radius: 10px;">
                    <div class="container" style="background-color: #B3E2A7; padding: 10px; border-radius: 10px;">
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
                        <hr />
                        <div class="d-flex justify-content-between align-items-center">
                            <h4>Numero de Pedido: <span><%= idTicket %></span></h4>
                            <div class="col-md-3">
                                <p class="card-text"><small class="text-muted">Estado actual: <span class="capsulaEstadoTrabajo"><%= estadoActual %></span></small></p>
                            </div>
                        </div>
                        <hr />
                        <div class="row" style="margin-left: 10px; margin-right: 10px; margin-bottom: 10px">
                            <div class="col-md-6 mb-3">
                                <label>Solicitado por:</label>
                                <asp:TextBox ID="TextBoxNombre_Cliente" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-3 mb-3">
                                <label>DNI:</label>
                                <asp:TextBox ID="TextBoxDNICliente" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-3 mb-3">
                                <label>Fecha solicitado:</label>
                                <asp:TextBox ID="TextBoxFecha_Solicitado" TextMode="Date" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="row">
                            </div>
                            <div class="col-12 mb-3">
                                <label>Comentario problema:</label>
                                <asp:TextBox ID="TextBoxComentario" CssClass="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <hr />
                            <h4>Datos del proveedor:</h4>
                            <div class="col-md-6 mb-3">
                                <%if (ticket.Prestador != null)

                                    {%>
                                <label>
                                    Proveedor:                          
                            <asp:LinkButton ID="LinkProveedor" runat="server" OnClick="LinkProveedor_Click" Text="(Ver Detalle)"></asp:LinkButton></label>
                                <asp:TextBox ID="TextBoxProveedor" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                <%}%>
                                <%else
                                    {%>
                                <label>Proveedor:</label>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                <% } %>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>CUIL:</label>
                                <asp:TextBox ID="TextBoxCuil_Prov" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <hr />
                        <div class="row" style="margin-left: 10px; margin-right: 10px; margin-bottom: 10px">
                            <h4>Detalle del trabajo:</h4>
                            <div class="col-md-6 mb-3">
                                <label>Domicilio del trabajo:</label>
                                <asp:TextBox ID="TextBoxDireccion" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Localidad:</label>
                                <asp:TextBox ID="TextBoxLocalidad" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-3">
                                <label>Provincia:</label>
                                <asp:TextBox ID="TextBoxProvincia" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-2 mb-3">
                                <label>Fecha realizado:</label>
                                <asp:TextBox ID="TextBoxFecha_Trabajo" CssClass="form-control" runat="server" TextMode="Date" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-3 mb-3">
                                <label>Monto del trabajo:</label>
                                <asp:TextBox ID="TextBoxMonto_Trabajo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-3 mb-3">
                                <label>Especialidad:</label>
                                <asp:TextBox ID="TextBoxEspecialidad" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-12 mb-3">
                                <label>Comentario proveedor:</label>
                                <asp:TextBox ID="TextBoxComentario_Proveedor" CssClass="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="row" style="margin-left: 10px; margin-right: 10px; margin-top: 20px; justify-content: flex-end;">
                                <div class="col text-right">
                                    <asp:Button ID="btnPostularse" CssClass="btn btn-success ml-2" runat="server" Text="Postularse" CommandArgument="POSTULARSE" OnClick="btnAccionTrabajo" Visible="false" />
                                    <asp:Button ID="btnAprobarSolicitud" CssClass="btn btn-success ml-2" runat="server" Text="Aprobar Solicitud" CommandArgument="APROBAR SOLICITUD" OnClick="btnAccionTrabajo" Visible="false" />
                                    <asp:Button ID="btnConfirmarRealizado" CssClass="btn btn-success ml-2" runat="server" Text="Confirmar Realizado" CommandArgument="CONFIRMAR REALIZADO" OnClick="btnAccionTrabajo" Visible="false" />
                                    <asp:Button ID="btnAceptarPedido" CssClass="btn btn-success ml-2" runat="server" Text="Aceptar Pedido" CommandArgument="ACEPTAR PEDIDO" OnClick="btnAccionTrabajo" Visible="false" />
                                    <asp:Button ID="btnPasarRealizado" CssClass="btn btn-success ml-2" runat="server" Text="Confirmar Realizado" CommandArgument="PASAR REALIZADO" OnClick="btnAccionTrabajo" Visible="false" />
                                    <asp:Button ID="btnRechazarPedido" CssClass="btn btn-danger" runat="server" Text="Rechazar Pedido" CommandArgument="DESCARTAR SOLICITUD" OnClick="btnAccionTrabajo" Visible="false" />
                                    <asp:Button ID="btnDescartarSolicitud" CssClass="btn btn-danger" runat="server" Text="Descartar Solicitud" CommandArgument="DESCARTAR SOLICITUD" OnClick="btnAccionTrabajo" Visible="false" />
                                    <asp:Button ID="btnCancelarTrabajo" CssClass="btn btn-danger" runat="server" Text="Cancelar Trabajo" CommandArgument="CANCELAR TRABAJO" OnClick="btnAccionTrabajo" Visible="false" />
                                </div>
                            </div>
                            <% if (estadoActual == "REALIZADO" || estadoActual == "CANCELADO")
                                {
                                    if (ticket.ComentarioResenia.Equals("") && ticket.Prestador != null)
                                    {%>
                            <div class="row" style="margin-left: 10px; margin-right: 10px; margin-top: 20px; justify-content: flex-end;">
                                <div class="col text-right">
                                    <p class="d-inline-flex gap-1">
                                        <a class="btn btn-success" data-bs-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">Dejar Reseña
                                        </a>
                                    </p>
                                    <div class="collapse" id="collapseExample">
                                        <div class="card card-body" style="background-color: #B3E2A7">
                                            <div class="row">
                                                <div class="col">
                                                    <label>Puntuación de la reseña:</label>
                                                    <asp:DropDownList ID="dropDownListPuntaje" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <label>Dejanos un comentario:</label>
                                                    <asp:TextBox ID="textBoxResenia" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col text-right">
                                                    <asp:Button ID="buttonGuardarResenia" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="buttonGuardarResenia_Click"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%}%>
                            <%else
                                {%>
                            <%if (ticket.Prestador != null)%>
                            <%{ %>
                            <hr />
                            <h4>Reseña:</h4>
                            <div class="row" style="margin-left: 10px; margin-right: 10px; margin-top: 20px; justify-content: flex-end;">
                                <label>
                                    Tu Puntuación:
                                        <h5><%= new string('★', ticket.Calificacion) %></h5>
                                </label>
                                <label>Tu reseña:</label>
                                <textbox class="form-control" multiline="true"><%= ticket.ComentarioResenia %></textbox>
                            </div>
                            <%}%>
                            <%} %>

                            <%} %>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">
        window.onload = function () {
            var divs = document.querySelectorAll(".capsulaEstadoTrabajo");

            divs.forEach(function (div) {
                var texto = div.textContent || div.innerText;

                if (texto === "EN PROCESO") {
                    div.style.backgroundColor = "#FFA500";
                } else if (texto === "REALIZADO") {
                    div.style.backgroundColor = "#0A831B";
                } else if (texto === "SOLICITADO") {
                    div.style.backgroundColor = "#0A4383";
                } else if (texto === "A ASIGNAR") {
                    div.style.backgroundColor = "#0000FF";
                } else {
                    div.style.backgroundColor = "#F44336";
                }
            });
        };
    </script>
</asp:Content>

