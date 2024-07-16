<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ManoExperta.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center" style="min-height: 100vh; background-color: #80B9AD;">
        <div class="container">
            <div class="row">
                <div class="col d-flex flex-column">
                    <div class="justify-content-center align-items-center text-white">
                        <h1>Comentanos qué necesitas y cuál es tu problema</h1>
                    </div>
                    <div class="text-white" style="margin-top: 30px">
                        <h4>Te proporcionamos las herramientas para resolver los problemas en tu casa. Buscá proveedores o compartí tu problema para que un proveedor te pueda ayudar. Te acompañamos en el proceso.</h4>
                        
                        <div class="d-grid gap-2 d-md-flex justify-content-md-end" style="margin-top: 15px">
                            <a href="Registrar.aspx" class="btn btn-outline-light btn-lg">Registrarse</a>
                        </div>
                    </div>
                </div>

                <div class="col text-center">
                    <img src="Resources/Images/imagenUsuarioNormal.jpg" class="rounded" style="width: 80%; height: auto;" />
                </div>
            </div>
        </div>
    </div>

    <div class="d-flex justify-content-center align-items-center" style="min-height: 100vh; background-color: #538392;">
        <div class="container">
            <div class="row">
                <div class="col text-center">
                    <img src="Resources/Images/imagenProveedor.jpg" class="rounded" style="width: 80%; height: auto;" />
                </div>
                <div class="col d-flex flex-column">
                    <div class="justify-content-center align-items-center text-white">
                        <h1>Haz públicos tus servicios y ten acceso a clientes en toda la Argentina</h1>
                    </div>
                    <div class="text-white" style="margin-top: 30px">
                        <h4>Comparti tus servicios con miles de usuarios que lo necesitan. Expandí tu negocio con nosotros y mejorá tus ventas.</h4>

                        <div class="d-grid gap-2 d-md-flex justify-content-md-end" style="margin-top: 15px">
                            <a href="Registrar.aspx" class="btn btn-outline-light btn-lg">Registrarse</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
