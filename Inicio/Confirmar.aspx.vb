Imports System.Data.SqlClient
Imports Conexion.Conexion
Public Class Confirmar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = conectar()
        Dim lng As Long
        Dim emailDestino As String
        emailDestino = Request.QueryString("emailDestino")
        lng = obtenernumconfir(emailDestino)
        If CLng(Request.QueryString("numconf")) = lng Then
            Label4.Text = "Se ha confirmado correctamente su registro."
            actualizarConfirmado(emailDestino)
        Else : Label4.Text = "Debe confirmar su registro"
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub
End Class