<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="Inicio.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Iniciar sesión" />
        &nbsp;
        <asp:Label ID="Label5" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Si todavía no te has registrado, registrate "></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registro.aspx">aquí</asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Si deseas cambiar tu contraseña, haz click"></asp:Label>
&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CambiarPassword.aspx">aquí</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
