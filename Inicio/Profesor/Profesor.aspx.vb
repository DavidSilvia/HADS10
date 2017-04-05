Public Class Profesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ac As ArrayList = Application.Contents("alumnosconectados")
        Dim pc As ArrayList = Application.Contents("profesconectados")
        Label3.Text = "Hay " & Application.Contents("numeroalumnos") & " alumnos conectados y " & Application.Contents("numeroprofes") & " profesores conectados"
        If Not Application.Contents("alumnosconectados") Is Nothing Then
            ListBox1.Items.Clear()
            ListBox1.DataSource = Application.Contents("alumnosconectados")
            ListBox1.DataBind()
        End If
        If Not Application.Contents("profesconectados") Is Nothing Then
            ListBox2.Items.Clear()
            ListBox2.DataSource = Application.Contents("profesconectados")
            ListBox2.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session.Abandon()
        Response.Redirect("../Inicio.aspx")
    End Sub
End Class