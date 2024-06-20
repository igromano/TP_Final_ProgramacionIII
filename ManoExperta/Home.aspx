<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ManoExperta.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Home.css" rel="stylesheet" />
    <div class="container-fluid" id="MenuCentral" style="background-color: #80B9AD; display: flex; flex-direction: column; justify-content: space-between; align-items: center; padding: 20px;">
        <div class="row" style="justify-content: center; text-align: center;">
            <div class="col">
                <h2>Bienvenido "NOMBRE DE USUARIO"</h2>
            </div>
        </div>
        <div id="SubMenuCentral" style="flex: 1; width: 100%; display: flex;">
            <div class="col justify-content-center" id="InfoCentral" style="background-color: #B3E2A7; padding: 20px;">
                <div class="row">
                    <h3>¿Qué estás necesitando hoy?</h3>
                </div>
                <div class="row" style="display:flex; justify-content: center">
                    <div class="col-auto">
                        <button class="btn btn-secondary">Tengo un problema...</button>
                    </div>
                    <div class="col-auto">
                        <button class="btn btn-secondary">Quiero buscar un experto...</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
