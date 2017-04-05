Imports Conexion.Conexion
Imports System.Data.SqlClient
Imports System.Security.Cryptography

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
        Dim DES As New TripleDESCryptoServiceProvider
        Dim MD5 As New MD5CryptoServiceProvider
        Dim pass As String
        Try
            RS = obtenerdatos()
        Catch ex As Exception
            Label5.Text = ex.Message
            Exit Sub
        End Try
        While RS.Read
            'Para encriptar el password
            DES.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes("qualityi"))
            DES.Mode = CipherMode.ECB
            Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(TextBox2.Text)
            pass = Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
            If (RS.Item("email") = TextBox1.Text) And (pass = RS.Item("pass") And (RS.Item("confirmado") = True)) Then
                Application.Lock()
                Dim NA As Integer = Application.Contents("numeroalumnos")
                Dim NP As Integer = Application.Contents("numeroprofes")
                Dim AC As ArrayList = Application.Contents("alumnosconectados")
                Dim PC As ArrayList = Application.Contents("profesconectados")

                Session("email") = TextBox1.Text
                Session("tipo") = RS.Item("tipo")

                If (RS.Item("tipo") = "P") Then
                    PC.Add(Session("email"))
                    NP = Application.Contents("numeroprofes") + 1
                    Application.Contents("numeroprofes") = NP
                    Application.Contents("profesconectados") = PC
                    If (RS.Item("email") = "vadillo@ehu.es") Then
                        System.Web.Security.FormsAuthentication.SetAuthCookie("vadillo@ehu.es", False)
                    Else
                        System.Web.Security.FormsAuthentication.SetAuthCookie("Profesor", False)
                    End If
                    Response.Redirect("Profesor/Profesor.aspx")
                ElseIf (RS.Item("tipo") = "A") Then
                    AC.Add(Session("email"))
                    NA = Application.Contents("numeroalumnos") + 1
                    Application.Contents("numeroalumnos") = NA
                    Application.Contents("alumnosconectados") = AC
                    System.Web.Security.FormsAuthentication.SetAuthCookie("Alumno", False)
                    Response.Redirect("Alumno/Alumno.aspx")
                End If
                Application.UnLock()
            End If
        End While
    End Sub
End Class