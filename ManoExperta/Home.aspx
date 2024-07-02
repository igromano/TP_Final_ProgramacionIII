<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ManoExperta.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div class="row" style="justify-content: center; text-align: center;">
            <%-- <div class="col">
                <h2>Bienvenido <%= usuarioTemp.Nombre %> <%= usuarioTemp.Apellido %></h2>
            </div>
            --%>
        </div>
    <div id="SubMenuCentral" style="flex: 1; width: 100%; height:100vh; display: flex;">
        <div class="col justify-content-center" id="InfoCentral" style="background-color: #B3E2A7; padding: 20px;">
            <div class="row">
                <h3>¡Hola <%= usuarioTemp.Nombre %>! ¿En que te podemos ayudar?</h3>
            </div>
            <div class="row" style="display: flex; justify-content: center">
                <div class="col-auto">
                    <asp:Button ID="ButtonProblema" runat="server" CssClass="btn btn-secondary" OnClick="ButtonProblema_Click" Text="Tengo un problema..."/>
                </div>
                <div class="col-auto">
                    <asp:Button ID="ButtonBuscarProfesional" runat="server" CssClass="btn btn-secondary" OnClick="ButtonBuscarProfesional_Click" Text="Buscar profesional..."/>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
