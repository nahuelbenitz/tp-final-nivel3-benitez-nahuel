<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Bienvenida.aspx.cs" Inherits="CatalogoWeb.Bienvenida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido!</h1>
    <div class="row">
        <div class="col">
            <div class="mb-3">
                <asp:Label runat="server" Text="" Id="lblMensaje"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <a href="Perfil.aspx" class="btn btn-primary">Ir a tu Perfil</a>
                <a href="/" class="btn btn-secondary">Ir al Home</a>
            </div>
        </div>

    </div>

</asp:Content>
