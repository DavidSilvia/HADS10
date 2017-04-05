<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExportarTareas.aspx.vb" Inherits="Inicio.ExportarTareas" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" BorderColor="#669999" BorderStyle="Solid" BorderWidth="3px" Height="133px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Profesor" Font-Bold="True" Font-Size="XX-Large" style="text-align: left"></asp:Label>
                   <br />
     <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Exportar tareas genéricas"></asp:Label>
        </asp:Panel>
        
  
            <asp:Label ID="Label3" runat="server" Text="Seleccionar Asignatura a Exportar:"></asp:Label>
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
        <asp:Button ID="Button1" runat="server" Text="Exportar XML" />
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
        <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Profesor.aspx">Menu Profesor</asp:HyperLink>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Codigo" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <ajaxToolkit:DragPanelExtender ID="GridView1_DragPanelExtender" runat="server" TargetControlID="GridView1" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS10_TareasConnectionString2 %>" SelectCommand="SELECT [Codigo], [Descripcion], [HEstimadas], [Explotacion], [TipoTarea] FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
