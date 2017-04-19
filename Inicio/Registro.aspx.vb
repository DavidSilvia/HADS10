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
        Dim quien
        Dim servicio As New servicioComprobarMatricula.Matriculas
        Dim servPass As New passwordsSeguros.passwordseguro

        servPass.Timeout = -1
        Randomize()
        numconfir = CLng(Rnd() * 9000000) + 1000000
        If DropDownList1.SelectedValue = "Profesor" Then
            quien = "P"
        Else
            quien = "A"
        End If
        If servicio.comprobar(email.Text) = "NO" Then
            Label9.Text = "Para registrarte debes estar matriculado"
        Else
            If servPass.esSeguro(pass.Text) = "SI" Then
                Label9.Text = insertarRegistro(email.Text, nombre.Text, pregunta.Text, respuesta.Text, dni.Text, quien, pass.Text)
                ' If (Label9.Text <> "No se ha podido insertar el registro") Then
                'enviarEmail(email.Text, numconfir)
                'End If
            Else
                Label9.Text = "La contraseña introducida no es segura"
            End If
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

    End Sub
End Class