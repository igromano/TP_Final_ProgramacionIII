<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ManoExperta.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
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
                        <asp:TextBox ID="TextBoxNombre_Cliente" runat="server" ReadOnly="true">Solicitado por: </asp:TextBox>
                        <asp:TextBox ID="TextBoxDireccion" runat="server" ReadOnly="true">Direccion: </asp:TextBox>
                    </div>
                    <div class="col" style="display: grid">
                        <asp:TextBox ID="TextBoxFecha_Solicitado" runat="server" ReadOnly="true">Fecha solicitado: </asp:TextBox>
                    </div>
                    <asp:TextBox ID="TextBoxComentario" runat="server" ReadOnly="true">Comentario problema: </asp:TextBox>
                </div>
                <hr />
                <div class="row">
                    <div class="col" style="display: grid">
                        <asp:TextBox ID="TextBoxProveedor" runat="server" ReadOnly="true">Proveedor: </asp:TextBox>
                        <asp:TextBox ID="TextBoxDireccion_Prov" runat="server" ReadOnly="true">Direccion: </asp:TextBox>
                    </div>
                    <div class="col" style="display: grid">
                        <asp:TextBox ID="TextBoxFecha_Trabajo" runat="server" ReadOnly="true">Fecha trabajo: </asp:TextBox>
                    </div>
                    <asp:TextBox ID="TextBoxComentario_Proveedor" runat="server" ReadOnly="true">Comentario proveedor: </asp:TextBox>
                </div>

                <div class="row" style="margin-left: 50px; margin-right: 50px; margin-top: 20px">
                    <div class="col">
                        <asp:Button ID="btnActualizarDatos" CssClass="btn btn-danger" runat="server" Text="Cancelar Trabajo" />
                        <asp:Button ID="btnPasarRealizado" CssClass="btn btn-success ml-2" runat="server" Text="Pasar a Realizado" />
                    </div>
                </div>



            </div>
        </div>
    </div>
</asp:Content>
