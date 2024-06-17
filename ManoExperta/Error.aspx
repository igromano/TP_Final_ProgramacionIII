<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ManoExperta.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center" style="min-height: 100vh; background-color: #80B9AD;">
        <div class="container">
            <div class="row">
                <div class="col d-flex flex-column justify-content-center align-items-center text-center">
                    <h1 class="text-white mb-4">Parece que algo salió mal...</h1>
                    <img src="Resources/Images/errorFondo.jpg" class="rounded" style="width: 60%; height: auto;" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
