<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ManoExperta.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex;">
            <div class="container" style="background-color: #B3E2A7; padding: 10px;">
                <h3>Detalle</h3>
                <h4>Numero de Pedido: <%= idTicket %></h4>
                <hr />
                <hr />
                <div class="row">
                    <div class="col" style="display: grid">
                        <asp:Label ID="lblNombre_Cliente" runat="server">Solicitado por: </asp:Label>
                        <asp:Label ID="lblDireccion" runat="server">Direccion: </asp:Label>
                    </div>
                    <div class="col" style="display: grid">
                        <asp:Label ID="lblFecha_Solicitado" runat="server" Text="Label">Fecha solicitado: </asp:Label>
                    </div>
                    <asp:Label ID="lblComentario" runat="server" Text="Label">Comentario problema: </asp:Label>
                </div>
                <hr />
                <div class="row">
                    <div class="col" style="display: grid">
                        <asp:Label ID="lblProveedor" runat="server" Text="Label">Proveedor: </asp:Label>
                        <asp:Label ID="lblDireccionProv" runat="server" Text="Label">Direccion: </asp:Label>
                    </div>
                    <div class="col" style="display: grid">
                        <asp:Label ID="lblFechaTrabajo" runat="server" Text="Label">Fecha trabajo: </asp:Label>
                    </div>
                    <asp:Label ID="lblComentarioProveedor" runat="server" Text="Label">Comentario proveedor: </asp:Label>
                </div>
                <div class="row" style="margin-left: 50px; margin-right: 50px; margin-top: 20px">
                    <asp:Button ID="btnActualizarDatos" CssClass="btn btn-danger" runat="server" Text="Cancelar Trabajo" />
                </div>


            </div>
        </div>
    </div>
</asp:Content>
