<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="Inicio.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 376px">
    <form id="form1" runat="server">
    <div style="height: 370px">
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" BorderColor="#669999" BorderStyle="Solid" BorderWidth="3px" Height="132px">
            <asp:Button ID="Button1" runat="server" BackColor="#99CCFF" BorderColor="#6699FF" BorderStyle="None" Font-Bold="True" Font-Overline="False" Font-Underline="True" ForeColor="Blue" Text="Cerrar sesión" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Alumnos" Font-Bold="True" Font-Size="XX-Large" style="text-align: left"></asp:Label>
                   <br />
     <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Instanciar Tarea Genérica"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel2" runat="server" Height="111px" style="margin-top: 14px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Usuario"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" style="margin-left: 47px" Width="197px" ForeColor="#999999"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Tarea"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" style="margin-left: 59px" Width="197px" ForeColor="#999999"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Horas Est."></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True" style="margin-left: 29px" Width="197px" ForeColor="#999999"></asp:TextBox>
                <br />
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Horas Reales"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 10px" Width="197px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" style="margin-left: 122px" Width="183px"></asp:Label>
                <br />
                <asp:Button ID="Button2" runat="server" Font-Bold="False" Font-Italic="True" Height="37px" Text="Instanciar" Width="99px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="TareasAlumno.aspx">Página anterior</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
            </asp:Panel>
        </asp:Panel>
        
    </div>
    </form>
</body>
</html>
