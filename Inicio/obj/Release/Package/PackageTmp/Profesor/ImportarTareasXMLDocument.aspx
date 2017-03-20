<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarTareasXMLDocument.aspx.vb" Inherits="Inicio.ImportarTareasXMLDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 431px">
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" BorderColor="#669999" BorderStyle="Solid" BorderWidth="3px" Height="133px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Profesor" Font-Bold="True" Font-Size="XX-Large" style="text-align: left"></asp:Label>
                   <br />
     <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Importar tareas genéricas"></asp:Label>
        </asp:Panel>
        
  
        <asp:Panel ID="Panel2" runat="server" Height="288px">
            <asp:Label ID="Label3" runat="server" Text="Seleccionar Asignatura a Importar:"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="Tareas" DataTextField="codigo" DataValueField="codigo">
            </asp:DropDownList>
            <asp:SqlDataSource ID="Tareas" runat="server" ConnectionString="<%$ ConnectionStrings:HADS10_TareasConnectionString %>" SelectCommand="SELECT Asignaturas.codigo FROM (Asignaturas INNER JOIN GruposClase ON Asignaturas.codigo = GruposClase.codigoasig )INNER JOIN ProfesoresGrupo ON GruposClase.codigo = ProfesoresGrupo.codigogrupo
WHERE ProfesoresGrupo.email=@Profesor">
                <SelectParameters>
                    <asp:SessionParameter Name="Profesor" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Importar (XSLD)" Width="135px" />
            <br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Profesor.aspx">Menu Profesor</asp:HyperLink>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
