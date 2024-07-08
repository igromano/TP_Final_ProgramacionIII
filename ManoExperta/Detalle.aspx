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
                <div class="row">
                    <div class="col" style="display: grid">
                        <asp:TextBox ID="TextBoxNombre_Cliente" CssClass="form-control" runat="server" ReadOnly="true">Solicitado por: </asp:TextBox>
                        <asp:TextBox ID="TextBoxDireccion" CssClass="form-control   " runat="server" ReadOnly="true">Direccion: </asp:TextBox>
                    </div>
                    <div class="col" style="display: grid">
                        <asp:TextBox ID="TextBoxFecha_Solicitado" CssClass="form-control" runat="server" ReadOnly="true">Fecha solicitado: </asp:TextBox>
                    </div>
                </div>
                <asp:TextBox ID="TextBoxComentario" CssClass="form-control" runat="server" ReadOnly="true" TextMode="MultiLine">Comentario problema: </asp:TextBox>

                <hr />
                <div class="row">
                    <div class="col" style="display: grid">
                        <asp:TextBox ID="TextBoxProveedor" CssClass="form-control" runat="server" ReadOnly="true">Proveedor: </asp:TextBox>
                        <asp:TextBox ID="TextBoxDireccion_Prov" CssClass="form-control" runat="server" ReadOnly="true">Direccion: </asp:TextBox>
                    </div>
                    <div class="col" style="display: grid">
                        <asp:TextBox ID="TextBoxFecha_Trabajo" CssClass="form-control" runat="server" ReadOnly="true">Fecha trabajo: </asp:TextBox>
                    </div>
                </div>
                <asp:TextBox ID="TextBoxComentario_Proveedor" CssClass="form-control" runat="server" ReadOnly="true" TextMode="MultiLine">Comentario proveedor: </asp:TextBox>


                <div class="row" style="margin-left: 50px; margin-right: 50px; margin-top: 20px">
                    <div class="col">
                        <asp:Button ID="btnActualizarDatos" CssClass="btn btn-danger" runat="server" Text="Cancelar Trabajo" OnClick="btnCancelar_Trabajo" />
                        <asp:Button ID="btnPasarRealizado" CssClass="btn btn-success ml-2" runat="server" Text="Pasar a Realizado" />
                        <asp:Button ID="BtnPasarAAsignar" CssClass="btn btn-success ml-2"  runat="server" Text="Pasar a A Asignar" />                                              
                    </div>
                </div>



            </div>
        </div>
    </div>
</asp:Content>
