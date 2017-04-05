<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumno.aspx.vb" Inherits="Inicio.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 601px;
        }
    </style>
</head>
<body style="height: 600px">
    <form id="form1" runat="server">
    <div>

    </div>
        
        <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" BorderColor="#669999" BorderStyle="Solid" BorderWidth="3px" Height="155px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Gestión Web de Tareas-Dedicación" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Alumnos"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Cerrar sesión" />
        </asp:Panel>
        
        <asp:Panel ID="Panel2" runat="server" BackColor="#CCCCFF" BorderColor="#669999" BorderStyle="Solid" BorderWidth="3px" Height="425px" style="margin-left: 0px">
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="TareasAlumno.aspx">Tareas Genéricas</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server">Tareas propias</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server">Grupos</asp:HyperLink>
            <br />
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Alumnos"></asp:Label>
                    <br />
                    <asp:ListBox ID="ListBox1" runat="server" Width="149px"></asp:ListBox>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Profesores"></asp:Label>
                    <br />
                    <asp:ListBox ID="ListBox2" runat="server" Width="160px"></asp:ListBox>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
        </asp:Panel>
        
    </form>
</body>
</html>
