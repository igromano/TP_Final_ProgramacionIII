<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ManoExperta.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="display: flex; align-items: center; justify-content: center; height: 100%; width: 100%">
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLabel">Creación de Usuario</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body" style="align-items: center">
                        <h3>¿Que tipo de Usuario desea crear? </h3>
                        <div class="container align-self-end">
                            <div class="d-grid gap-2 p-4">
                                <asp:Button ID="Button1" type="button" runat="server" Text="Nuevo Usuario" CssClass="btn btn-secondary" data-bs-dismiss="modal" OnClick="CrearUsuario" />
                            </div>
                            <div class="d-grid gap-2 p-4">
                                <asp:Button ID="Proveedor" type="button" runat="server" Text="Nuevo Proveedor" CssClass="btn btn-secondary" data-bs-dismiss="modal" OnClick="CrearProveedor" />

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="align-items: center">
                        <div class="container align-self-end">
                            <div class="d-grid gap-2 p-4">
                                <a class="btn btn-danger" href="/Login.aspx">Salir</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <% if (creaUsuario)
            { %>
        <div class="container-fluid" style="display: flex; align-items: center; justify-content: center">
            <div class="container form-container" style="display: flex; align-items: center; justify-content: center">
                <div class="card p-4 shadow-sm" style="width: 100%; max-width: 80%; background-color: darkorange; box-shadow: 0 20px 27px 0 rgb(0 0 0 / 5%)">
                    <h2 class="card-title text-center">Alta de Usuario</h2>
                    <form>
                        <div class="mb-3 row">
                            <div class="col">
                                <asp:Label runat="server" ID="labelNombre" CssClass="form-label">Nombre</asp:Label>
                                <asp:TextBox runat="server" ID="textBoxNombre" CssClass="form-control" />
                            </div>
                            <div class="col">

                                <asp:Label runat="server" ID="labelApellido" CssClass="form-label">Apellido</asp:Label>
                                <asp:TextBox ID="textBoxApellido" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="mb-3 row">
                            <div class="col-md-6">

                                <asp:Label ID="labelEmail" runat="server" CssClass="form-label">Email</asp:Label>
                                <asp:TextBox ID="textBoxEmail" runat="server" CssClass="form-control" TextMode="Email" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="labelDNI" runat="server" CssClass="form-label">DNI</asp:Label>
                                <asp:TextBox ID="textBoxDNI" runat="server" CssClass="form-control" MaxLength="8" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="labelTelefono" runat="server" CssClass="form-label">Teléfono</asp:Label>
                                <asp:TextBox ID="textBoxTelefono" runat="server" TextMode="Phone" CssClass="form-control" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="labelFechaNacimiento" runat="server" CssClass="form-label">Fecha Nacimiento</asp:Label>
                                <asp:TextBox ID="calendarFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>

                        </div>
                        <div class="mb-3 row">
                            <div class="col-md-6">
                                <asp:Label ID="LabelDireccion" runat="server" CssClass="form-label">Dirección Casa</asp:Label>
                                <asp:TextBox ID="textBoxDireccion" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="labelAltura" runat="server" CssClass="form-label">Altura de la Calle</asp:Label>
                                <asp:TextBox ID="textBoxAltura" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="labelPiso" runat="server" CssClass="form-label">Piso</asp:Label>
                                <asp:TextBox ID="textBoxPiso" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="labelDepartamento" runat="server" CssClass="form-label">Departamento</asp:Label>
                                <asp:TextBox ID="textBoxDepartamento" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="mb-3 row">
                            <div class="col-md">
                                <asp:Label ID="labelProvincia" runat="server" CssClass="form-label">Provincia</asp:Label>
                                <asp:DropDownList ID="pronvincia" runat="server" CssClass="form-select" OnSelectedIndexChanged="pronvincia_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md">
                                <asp:Label ID="labelCuidad" runat="server" CssClass="form-label">Ciudad</asp:Label>
                                <select class="form-select" id="ciudad" required>
                                    <option value="">Ciudad...</option>
                                </select>
                            </div>
                            <div class="col-md">
                                <asp:Label ID="labelBarrio" runat="server" CssClass="form-label">Barrio</asp:Label>
                                <asp:TextBox ID="textBoxBarrio" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Label ID="labelCodPostal" runat="server" CssClass="form-label">Codigo Postal</asp:Label>
                                <asp:TextBox ID="textBoxCodPostal" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="container text-center">
                            <div class="row">
                                <div class="col">
                                    <asp:Button ID="buttonRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" Width="100%" />
                                </div>
                                <div class="col">
                                    <a class="btn btn-danger" href="/Login.aspx" style="width: 100%">Salir</a>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>

        <% } %>
        <% if (creaProveedor)
            { %>

        <div class="container-fluid" style="display: flex; align-items: center; justify-content: center">
            <div class="container form-container" style="display: flex; align-items: center; justify-content: center">
                <div class="card p-4 shadow-sm" style="width: 100%; max-width: 80%; background-color: darkorange; box-shadow: 0 20px 27px 0 rgb(0 0 0 / 5%)">
                    <h2 class="card-title text-center">Alta de Proveedor</h2>
                    <form>
                        <h3>Datos Personales</h3>
                        <hr />
                        <div class="mb-3 row">
                            <div class="col">
                                <asp:Label runat="server" ID="label1" CssClass="form-label">Nombre</asp:Label>
                                <asp:TextBox runat="server" ID="textBox1" CssClass="form-control" />
                            </div>
                            <div class="col">

                                <asp:Label runat="server" ID="label2" CssClass="form-label">Apellido</asp:Label>
                                <asp:TextBox ID="textBox2" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="mb-3 row">
                            <div class="col-md-6">

                                <asp:Label ID="label3" runat="server" CssClass="form-label">Email</asp:Label>
                                <asp:TextBox ID="textBox3" runat="server" CssClass="form-control" TextMode="Email" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="label4" runat="server" CssClass="form-label">DNI</asp:Label>
                                <asp:TextBox ID="textBox4" runat="server" CssClass="form-control" MaxLength="8" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="label5" runat="server" CssClass="form-label">Teléfono</asp:Label>
                                <asp:TextBox ID="textBox5" runat="server" TextMode="Phone" CssClass="form-control" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="label6" runat="server" CssClass="form-label">Fecha Nacimiento</asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>

                        </div>
                        <div class="mb-3 row">
                            <div class="col-md-6">
                                <asp:Label ID="Label7" runat="server" CssClass="form-label">Dirección Casa</asp:Label>
                                <asp:TextBox ID="textBox7" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="label8" runat="server" CssClass="form-label">Altura de la Calle</asp:Label>
                                <asp:TextBox ID="textBox8" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="label9" runat="server" CssClass="form-label">Piso</asp:Label>
                                <asp:TextBox ID="textBox9" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="label10" runat="server" CssClass="form-label">Departamento</asp:Label>
                                <asp:TextBox ID="textBox10" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="mb-3 row">
                            <div class="col-md">
                                <asp:Label ID="label11" runat="server" CssClass="form-label">Provincia</asp:Label>
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" OnSelectedIndexChanged="pronvincia_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md">
                                <asp:Label ID="label12" runat="server" CssClass="form-label">Ciudad</asp:Label>
                                <select class="form-select" id="ciudad" required>
                                    <option value="">Ciudad...</option>
                                </select>
                            </div>
                            <div class="col-md">
                                <asp:Label ID="label13" runat="server" CssClass="form-label">Barrio</asp:Label>
                                <asp:TextBox ID="textBox11" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Label ID="label14" runat="server" CssClass="form-label">Codigo Postal</asp:Label>
                                <asp:TextBox ID="textBox12" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="container text-center">
                            <div class="row">
                                <div class="col">
                                    <asp:Button ID="button2" runat="server" Text="Registrar" CssClass="btn btn-primary" Width="100%" />
                                </div>
                                <div class="col">
                                    <a class="btn btn-danger" href="/Login.aspx" style="width: 100%">Salir</a>
                                </div>
                            </div>
                        </div>
                        <br />
                        <h3>Datos Profesionales</h3>
                        <hr />
                        <div class="mb-3 row">
                            <div class="col-md-4">
                                <asp:Label ID="labelRazonSocial" runat="server" CssClass="form-label">Razon Social</asp:Label>
                                <asp:TextBox ID="textBoxRazonSocial" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="labelCUIT" runat="server" CssClass="form-label">CUIT</asp:Label>
                                <asp:TextBox ID="textBoxCUIT" runat="server" CssClass="form-control" MaxLength="11" />
                            </div>
                            <div class="col-md-5">
                                <asp:Label ID="labelDireccionFac" runat="server" CssClass="form-label">Dirección Facturación</asp:Label>
                                <asp:TextBox ID="textBoxDirFactura" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="mb-3 row">
                            <div class="col-md-6">
                                <asp:Label ID="labelEspecialidad" runat="server" CssClass="form-label">Especialidad</asp:Label>
                                <asp:DropDownList ID="dropDownEspecialidad" runat="server" CssClass="form-select" />
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="labelMatricula" runat="server" CssClass="form-label">N° Matricula</asp:Label>
                                <asp:TextBox ID="textBoxMatricula" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <% } %>
        <script type="text/javascript">
            $(document).ready(() => {
                var modalMostrar = ('<%= modalOpciones%>' === 'True') ? true : false;
                    var myModal = new bootstrap.Modal(document.getElementById('staticBackdrop'));
                    if (modalMostrar) {
                        myModal.show();
                    }
                    else {
                        myModal.hide();
                    }
                })

        </script>
    </div>


</asp:Content>
