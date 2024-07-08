<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ManoExperta.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
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
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex; border-radius: 10px;">
            <div class="container" style="background-color: #B3E2A7; padding: 10px; border-radius: 10px;">
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
                    <div class="col-md-6 mb-3">
                        <label>Direccion:</label>
                        <asp:TextBox ID="TextBoxDireccion" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label>Fecha solicitado:</label>
                        <asp:TextBox ID="TextBoxFecha_Solicitado" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label>Comentario problema:</label>
                        <asp:TextBox ID="TextBoxComentario" CssClass="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <hr />
                    <hr />
                    <div class="col-md-6 mb-3">
                        <label>Proveedor:</label>
                        <asp:TextBox ID="TextBoxProveedor" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label>Direccion:</label>
                        <asp:TextBox ID="TextBoxDireccion_Prov" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label>Fecha trabajo:</label>
                        <asp:TextBox ID="TextBoxFecha_Trabajo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label>Comentario proveedor:</label>
                        <asp:TextBox ID="TextBoxComentario_Proveedor" CssClass="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <hr />
                <% if (estadoActual == "SOLICITADO") { %>
                <div class="row" style="margin-left: 50px; margin-right: 50px; margin-top: 20px">
                    <div class="col">
                        <asp:Button ID="btnCancelarTrabajo" CssClass="btn btn-danger" runat="server" Text="Cancelar Trabajo" OnClientClick="showToast('Trabajo cancelado con éxito.'); return false;" CommandArgument="cancelar" OnClick="btnAccionTrabajo" />
                        <asp:Button ID="btnPasarRealizado" CssClass="btn btn-success ml-2" runat="server" Text="Pasar a Realizado" OnClientClick="showToast('Trabajo pasado a realizado con éxito.'); return false;" CommandArgument="finalizar" OnClick="btnAccionTrabajo" />
                    </div>
                </div>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>

