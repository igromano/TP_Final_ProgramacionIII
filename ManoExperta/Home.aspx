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
        <div id="SubMenuCentral" style="flex: 1; width: 100%; height: 100vh; display: flex;">
            <div class="col justify-content-center" id="InfoCentral" style="background-color: #B3E2A7; padding: 20px;">
                <div class="row">
                    <h3>¡Hola <%= usuarioTemp.Nombre %>! ¿En que te podemos ayudar?</h3>
                </div>
                <div class="row" style="display: flex; justify-content: center">
                    <div class="col-auto">
                        <div class="card" style="width: 18rem;">
                            <img src="Resources/Images/imagenUsuarioNormal.jpg" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title">Tengo un problema...</h5>
                                <p class="card-text">Si no estás seguro de que problema tenés, no te preocupes. Estamos para ayudarte. Cargá un problema y dejá que algunos de nuestros especialistas te ayuden a decidir.</p>
                                <asp:Button ID="ButtonProblema" runat="server" CssClass="btn btn-secondary" OnClick="ButtonProblema_Click" Text="Tengo un problema..." />

                            </div>
                        </div>
                    </div>
                    <div class="col-auto">
                        <div class="card" style="width: 18rem;">
                            <img src="Resources/Images/imagenProveedor.jpg" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title">Busco un profesional...</h5>
                                <p class="card-text">En esta sección encontrarás la amplia gama de profesionales que tenemos en nuestra plataforma. Podrás contactarte con ellos y resolver tu problema.</p>
                                <asp:Button ID="ButtonBuscarProfesional" runat="server" CssClass="btn btn-secondary" OnClick="ButtonBuscarProfesional_Click" Text="Buscar profesional..." />


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
