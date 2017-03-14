Imports Conexion.Conexion
Imports System.Data.SqlClient

Public Class InsertarTarea
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

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dst = Session("dataset")
        dap = Session("dataadapter")
        tbl = dst.Tables("TareasGenericas")

        Dim row As DataRow = tbl.NewRow
        row("Codigo") = TextBox1.Text
        row("Descripcion") = TextBox2.Text
        row("CodAsig") = DropDownList1.SelectedValue
        row("HEstimadas") = TextBox3.Text
        row("Explotacion") = 0
        row("TipoTarea") = DropDownList2.SelectedValue
        tbl.Rows.Add(row)

        dap.Update(dst, "TareasGenericas")
        dst.AcceptChanges()
        Label8.Text = "Se ha insertado correctamente la tarea"

    End Sub
End Class