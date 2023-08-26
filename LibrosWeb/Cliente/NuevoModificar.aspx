<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoModificar.aspx.cs" Inherits="LibrosWeb.Cliente.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link type="text/css" href="../Estilos/NuevoModificar.css" rel="stylesheet" />
    <style type="text/css">
        #numericInput0 {
            width: 286px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nombre del libro"></asp:Label>
            <br />
            <asp:TextBox ID="txtNombre" runat="server" Width="283px"></asp:TextBox>
            <br />
            <asp:Label ID="LabelError0" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Autor"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:DropDownList ID="ddlAutores" runat="server" Height="16px" Width="291px">
            </asp:DropDownList>
&nbsp;<br />
            <asp:Label ID="LabelError1" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Editorial"></asp:Label>
            <br />
&nbsp;<asp:DropDownList ID="ddlEditoriales" runat="server" Height="16px" Width="291px">
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelError2" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Costo"></asp:Label>
            <br />

            <%--<input type="number" id="numericInput" min="0" max="1000" />--%>
            <asp:TextBox ID="numCosto" runat="server" TextMode="Number" min="0" max="1000"></asp:TextBox>

            <br />
            <asp:Label ID="LabelError4" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>

            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Año de publicacion"></asp:Label>
            <br />
            <asp:TextBox ID="numAño" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Label ID="LabelError3" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelError" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Guardar" OnClick="btnModificar_Click" />
        </div>
    </form>
</body>

<%--<script>
    //document.addEventListener("DOMContentLoaded", function() {
    //    const currentYear = new Date().getFullYear();
    //    document.getElementById("numericInput0").setAttribute("max", currentYear);
    //});

    document.addEventListener("DOMContentLoaded", function () {
        const currentYear = new Date().getFullYear();
        const inputElement = document.getElementById("numericInput0");

        inputElement.setAttribute("max", currentYear);
        inputElement.value = 1900;  // asigna un valor por defecto
    });

</script>--%>

</html>