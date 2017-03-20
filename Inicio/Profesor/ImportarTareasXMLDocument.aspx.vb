Imports System.Xml
Imports System.Data.SqlClient
Imports Conexion.Conexion
Imports System.IO

Public Class ImportarTareasXMLDocument
    Inherits System.Web.UI.Page
    Dim dap As New SqlDataAdapter
    Dim dst As New DataSet
    Dim tbl As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dap = New SqlDataAdapter("select * from TareasGenericas", obtenerconexion())
        Dim bld As New SqlCommandBuilder(dap)
        dap.Fill(dst, "TareasGenericas")
        Session("dataset") = dst
        Session("dataadapter") = dap
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        If Not File.Exists(Server.MapPath("../App_Data/" & DropDownList1.SelectedValue & ".xml")) Then
            Label4.Text = "No existe el XML"
        Else
            Xml1.DocumentSource = Server.MapPath("../App_Data/" & DropDownList1.SelectedValue & ".xml")
            Xml1.TransformSource = Server.MapPath("../App_Data/XSLTFile.xsl")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim xd As XmlDocument = New XmlDocument()
        Dim t As XmlNodeList
        dst = Session("dataset")
        dap = Session("dataadapter")
        tbl = dst.Tables("TareasGenericas")
        xd.Load(Server.MapPath("../App_Data/" & DropDownList1.SelectedValue & ".xml"))
        t = xd.GetElementsByTagName("tarea")
        Dim i As Integer
        For i = 0 To t.Count - 1
            Dim row As DataRow = tbl.NewRow
            row("Codigo") = t(i).ChildNodes(0).ChildNodes(0).Value
            row("Descripcion") = t(i).ChildNodes(1).ChildNodes(0).Value
            row("CodAsig") = DropDownList1.SelectedValue
            row("HEstimadas") = t(i).ChildNodes(2).ChildNodes(0).Value
            row("Explotacion") = t(i).ChildNodes(3).ChildNodes(0).Value
            row("TipoTarea") = t(i).ChildNodes(4).ChildNodes(0).Value
            tbl.Rows.Add(row)

        Next
        dap.Update(dst, "TareasGenericas")
        dst.AcceptChanges()
        Label4.Text = "Se ha insertado correctamente la tarea"

    End Sub
End Class