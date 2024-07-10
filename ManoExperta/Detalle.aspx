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
                    <div class="col-md-3 mb-3">
                        <label>Fecha solicitado:</label>
                        <asp:TextBox ID="TextBoxFecha_Solicitado" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-12 mb-3">
                        <label>Comentario problema:</label>
                        <asp:TextBox ID="TextBoxComentario" CssClass="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <hr />
                    <hr />
                    <h4>Datos del proveedor:</h4>
                    <div class="col-md-6 mb-3">
                        <label>Proveedor:</label>
                        <asp:TextBox ID="TextBoxProveedor" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
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
                    <div class="col-md-6 mb-3">
                        <label>Provincia:</label>
                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-3 mb-3">
                        <label>Fecha estimativa del trabajo:</label>
                        <asp:TextBox ID="TextBoxFecha_Trabajo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-3 mb-3">
                        <label>Monto del trabajo:</label>
                        <asp:TextBox ID="TextBoxMonto_Trabajo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-12 mb-3">
                        <label>Comentario proveedor:</label>
                        <asp:TextBox ID="TextBoxComentario_Proveedor" CssClass="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                    </div>                
                <% if (estadoActual == "SOLICITADO" || estadoActual == "EN PROCESO" || estadoActual == "A ASIGNAR")
                    { %>
                <div class="row" style="margin-left: 10px; margin-right: 10px; margin-top: 20px; justify-content: flex-end;">
                    <div class="col text-right">
                        <asp:Button ID="btnCancelarTrabajo" CssClass="btn btn-danger" runat="server" Text="Cancelar Trabajo" CommandArgument="cancelar" OnClick="btnAccionTrabajo" />
                        <asp:Button ID="btnPasarRealizado" CssClass="btn btn-success ml-2" runat="server" Text="Pasar a Realizado" CommandArgument="finalizar" OnClick="btnAccionTrabajo" />
                    </div>
                </div>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>

