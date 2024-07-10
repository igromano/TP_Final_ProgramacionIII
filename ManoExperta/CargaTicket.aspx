<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CargaTicket.aspx.cs" Inherits="ManoExperta.CargaTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex; border-radius: 10px">
            <div class="container" style="background-color: #B3E2A7; padding: 10px; border-radius: 10px">
                <h3>Carga Ticket</h3>
                <hr />
                <hr />
                <div class="row" style="margin-left: 10px; margin-right: 10px; margin-bottom: 10px">
                    <label>Solicitado por:</label>
                    <div class="col" style="display: grid">
                        <label>Usuario:</label>
                        <asp:TextBox ID="TextBoxUsuarioSolicitante" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        <label>Nombre y Apellido:</label>
                        <asp:TextBox ID="TextBoxNombreApellidoSolicitante" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col" style="display: grid;">
                        <label>Fecha solicitado:</label>
                        <asp:TextBox ID="TextBoxFechaSolicitud" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        <label>Email:</label>
                        <asp:TextBox ID="TextBoxEmailSolicitante" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <hr />
                <div class="row" style="margin-left: 10px; margin-right: 10px; margin-bottom: 10px">
                    <label>Direccion:</label>
                    <div class="col-4">
                        <label>Calle y altura:</label>
                        <asp:TextBox ID="TextBoxCalleAltura" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>Localidad:</label>
                        <asp:TextBox ID="TextBoxLocalidad" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>Provincia:</label>
                        <asp:TextBox ID="TextBoxProvincia" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-left: 20px; margin-right: 20px; margin-bottom: 10px">
                    <label>Comentario problema:</label>
                    <asp:TextBox ID="TextBoxProblema" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <hr />
                <%if (idTipo.Equals("2"))
                    { %>
                <div class="row" style="margin-left: 10px; margin-right: 10px; margin-bottom: 10px">
                    <div class="col" style="display: grid">
                        <label>Proveedor:</label>
                        <asp:TextBox ID="TextBoxProveedor" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <% } %>

                <div class="row">
                    <div class="col" style="display: flex; justify-content: center">
                        <asp:Button ID="btnCargarPedido" CssClass="btn btn-success" runat="server" Text="Cargar Ticket" OnClick="btnCargarPedido_Click" />
                    </div>
                    <div class="col" style="display: flex; justify-content: center">
                        <asp:Button ID="btnCancelarPedido" CssClass="btn btn-danger" runat="server" Text="Volver" OnClick="btnCancelarPedido_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
