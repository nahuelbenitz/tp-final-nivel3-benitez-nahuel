<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CatalogoWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Errores:</h1>
        <asp:Label Text="" ID="lblError" runat="server" />
    <div class="col-3">
        <br />
        <a href="Default.aspx" class="btn btn-secondary">Volver al home</a>
    </div>
</asp:Content>
