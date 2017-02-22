Imports Conexion.Conexion
Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = conectar()
        Label9.Text = result
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged

    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles nombre.TextChanged

    End Sub

    Protected Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles dni.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim numconfir
        Randomize()
        numconfir = CLng(Rnd() * 9000000) + 1000000
        Label9.Text = insertarRegistro(email.Text, nombre.Text, apellidos.Text, pregunta.Text, respuesta.Text, dni.Text, numconfir, 0, pass.Text)
        enviarEmail(email.Text, numconfir)

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub
End Class