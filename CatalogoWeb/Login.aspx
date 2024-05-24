<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CatalogoWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Loguearse</h1>
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
            </div>
            <div class="mb-3 text-center">
                <asp:Button Text="Ingresar" runat="server" CssClass="btn btn-primary" ID="btnIngresar" OnClick="btnIngresar_Click" />
                <a href="/" class="btn btn-secondary">Cancelar</a>
            </div>
            <div class="mb-3 text-center">
                <hr />
                <a href="Registro.aspx">¿No tenes cuenta? Registrate.</a>
            </div>
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>
