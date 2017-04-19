<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="coordinador.aspx.vb" Inherits="Inicio.coordinador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 319px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
  <location path="Profesor/ExportarTareas.aspx">
    <system.web>
      <authorization>
        <allow users="vadillo@ehu.es"/>
        <deny users="*"/>
  <location path="Profesor/ExportarTareas.aspx">
    <system.web>
      <authorization>
        <allow users="vadillo@ehu.es"/>
        <deny users="*"/>
  <location path="Profesor/ExportarTareas.aspx">
    <system.web>
      <authorization>
        <allow users="vadillo@ehu.es"/>
        <deny users="*"/>
  <location path="Profesor/ExportarTareas.aspx">
    <system.web>
      <authorization>
        <allow users="vadillo@ehu.es"/>
        <deny users="*"/>
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" BorderColor="#669999" BorderStyle="Solid" BorderWidth="3px" Height="133px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Profesor" Font-Bold="True" Font-Size="XX-Large" style="text-align: left"></asp:Label>
                   <br />
     <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Obtener dedicación media"></asp:Label>
        </asp:Panel>
        
  
      </authorization>
    </system.web>
  </location>
      </authorization>
    </system.web>
  </location>
      </authorization>
    </system.web>
  </location>
      </authorization>
    </system.web>
  </location>
    
    </div>
        <asp:Panel ID="Panel2" runat="server" Height="180px">
            <asp:Label ID="Label3" runat="server" Text="Seleccionar Asignatura para calcular dedicación media:"></asp:Label>
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
            Dedicación media:<br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
