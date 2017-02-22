Imports Conexion.Conexion
Imports System.Data.SqlClient

Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = conectar()
        Label5.Text = result
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim RS As SqlDataReader
        Try
            RS = obtenerdatos()
        Catch ex As Exception
            Label5.Text = ex.Message
            Exit Sub
        End Try
        While RS.Read
            If (RS.Item("email") = TextBox1.Text) And (RS.Item("pass") = TextBox2.Text And (RS.Item("confirmado") = True)) Then
                Response.Redirect("InicioLogin.aspx")
            End If
        End While
    End Sub
End Class