<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola!</h1>
    <p>Conoce nuestro catalogo de articulos</p>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="..." height="500px">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <p class="card-text">$<%#Convert.ToDouble(Eval("Precio").ToString()).ToString("F2") %></p> <!-- Aca formateo a 2 decimales -->
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalle</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
