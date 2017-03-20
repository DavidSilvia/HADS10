<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Inicio.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" BorderColor="#669999" BorderStyle="Solid" BorderWidth="3px" Height="132px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Gestión Web de Tareas-Dedicación" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Profesores"></asp:Label>
        </asp:Panel>
        
        <asp:Panel ID="Panel2" runat="server" BackColor="#CCCCFF" BorderColor="#669999" BorderStyle="Solid" BorderWidth="3px" Height="255px">
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor/TareasProfesor.aspx">Asignaturas</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server">Tareas</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server">Grupos</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="ImportarTareasXMLDocument.aspx">Importar v. XMLDocument</asp:HyperLink>
            &nbsp;<br />
            <br />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ExportarTareas.aspx">Exportar</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink6" runat="server">Importar v. DataSet</asp:HyperLink>
        </asp:Panel>
        
    </form>
    
</body>
</html>
