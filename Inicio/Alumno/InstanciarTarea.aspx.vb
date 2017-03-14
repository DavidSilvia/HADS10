Imports System.Data.SqlClient
Imports Conexion.Conexion

Public Class InstanciarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dst As New DataSet
        Dim tbl As New DataTable
        Dim dap = New SqlDataAdapter("select * from TareasGenericas TG where TG.Codigo='" & Session("selectedTarea") & "'", obtenerconexion())
        Dim bld As New SqlCommandBuilder(dap)
        dap.Fill(dst, "EstudiantesTareas")
        tbl = dst.Tables("EstudiantesTareas")
        TextBox1.Text = Session("email")
        TextBox2.Text = tbl.Rows(0)("Codigo").ToString()
        TextBox3.Text = tbl.Rows(0)("HEstimadas").ToString()

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session.Abandon()
        cerrarconexion()
        Response.Redirect("../Inicio.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label7.Text = instanciar(Session("email"), TextBox2.Text, TextBox3.Text, TextBox4.Text)
    End Sub
End Class