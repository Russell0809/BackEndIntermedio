<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LibrosWeb.Cliente.Index" %>

<<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bienvenido</title>
    <link type="text/css" href="../Estilos/Index.css" rel="stylesheet" />
</head>
<body>
    <div class="header"></div>
    <form id="form1" runat="server">
        <div class="container">
            Buscar libro por<asp:RadioButtonList ID="rblBuscarPor" runat="server" OnSelectedIndexChanged="rblBuscarPor_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="0">Nombre</asp:ListItem>
                <asp:ListItem Value="1">Autor</asp:ListItem>
                <asp:ListItem Value="2">Editorial</asp:ListItem>
                <asp:ListItem Value="3">Precio</asp:ListItem>
                <asp:ListItem Selected="True" Value="-1">Todos</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="txtConsulta" runat="server" Width="355px"></asp:TextBox>
            <asp:TextBox ID="txtConsulta2" runat="server" Width="355px" Visible="False">1000</asp:TextBox>
            <br />
            <asp:Label ID="LabelError" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" Text="Consultar" />
            &nbsp;
            <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
            <br />

            <asp:GridView ID="dgvUniverso" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Folio" HeaderText="Folio" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Autor" HeaderText="Autor" />
                    <asp:BoundField DataField="Anio" HeaderText="Año" />
                    <asp:BoundField DataField="Editorial" HeaderText="Editorial" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="btnAccion" runat="server" Text="Seleccionar" OnClick="btnAccion_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br />
            <br />
            Editoriales<br />
            <br />
            <asp:Button ID="btnNuevo0" runat="server" OnClick="btnNuevoEditorial_Click" Text="Nuevo" />
            <br />
            <asp:GridView ID="dgvUniversoEditoriales" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Folio" HeaderText="Folio" />
                    <asp:BoundField DataField="NombreEditorial" HeaderText="NombreEditorial" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="btnAccion0" runat="server" Text="Seleccionar" OnClick="btnAccionEditorial_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br />
            <br />
            Autores<br />
            <br />
            <asp:Button ID="btnNuevo1" runat="server" OnClick="btnNuevoAutor_Click" Text="Nuevo" />
            <br />
            <br />
            <asp:GridView ID="dgvUniversoAutores" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Folio" HeaderText="Folio" />
                    <asp:BoundField DataField="NombreAutor" HeaderText="NombreAutor" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="btnAccion1" runat="server" Text="Seleccionar" OnClick="btnAccionAutor_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
