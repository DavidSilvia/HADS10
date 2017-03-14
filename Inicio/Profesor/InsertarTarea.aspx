<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTarea.aspx.vb" Inherits="Inicio.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 533px">
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" BorderColor="#669999" BorderStyle="Solid" BorderWidth="3px" Height="132px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Profesor" Font-Bold="True" Font-Size="XX-Large" style="text-align: left"></asp:Label>
                   <br />
     <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Gestión de tareas genéricas"></asp:Label>
        </asp:Panel>
        
    </div>
        <asp:Panel ID="Panel2" runat="server" Height="369px" style="margin-top: 22px">
            <asp:Label ID="Label3" runat="server" Text="Código"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" style="margin-left: 82px" Width="222px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Descripción"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Height="38px" style="margin-left: 56px; margin-top: 15px" Width="220px"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Asignatura"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" style="margin-left: 65px; margin-top: 13px" Width="85px" AutoPostBack="True">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS10_TareasConnectionString %>" SelectCommand="SELECT Asignaturas.codigo FROM Asignaturas INNER JOIN GruposClase ON Asignaturas.codigo = GruposClase.codigoasig INNER JOIN ProfesoresGrupo ON GruposClase.codigo = ProfesoresGrupo.codigogrupo
WHERE ProfesoresGrupo.email=@profesor">
                <SelectParameters>
                    <asp:SessionParameter Name="profesor" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Horas Estimadas"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 27px; margin-top: 14px" Width="74px"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Tipo Tarea"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" style="margin-left: 61px; margin-top: 13px" Width="111px" AutoPostBack="True">
                <asp:ListItem>Ejercicio</asp:ListItem>
                <asp:ListItem Value="Examen">Examen</asp:ListItem>
                <asp:ListItem>Laboratorio</asp:ListItem>
                <asp:ListItem>Trabajo</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" style="margin-top: 0px" Text="Añadir Tarea" />
            &nbsp;
            <asp:Label ID="Label8" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="TareasProfesor.aspx">Página anterior</asp:HyperLink>
        </asp:Panel>
    </form>
</body>
</html>
