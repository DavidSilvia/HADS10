Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication
    Public Shadows AC As ArrayList = New ArrayList()
    Public Shared PC As ArrayList = New ArrayList()

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Application.Contents("numeroalumnos") = 0
        Application.Contents("numeroprofes") = 0
        Application.Contents("alumnosconectados") = AC
        Application.Contents("profesconectados") = PC

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        Application.Lock()
        Dim NA As Integer = Application.Contents("numeroalumnos")
        Dim NP As Integer = Application.Contents("numeroprofes")
        AC = Application.Contents("alumnosconectados")
        PC = Application.Contents("profesconectados")

        If (Session("tipo") = "P") Then
            PC.Remove(Session("email"))
            NP = Application.Contents("numeroprofes") - 1
        Else
            AC.Remove(Session("email"))
            NA = Application.Contents("numeroalumnos") - 1
        End If
        Application.Contents("numeroalumnos") = NA
        Application.Contents("numeroprofes") = NP
        Application.Contents("alumnosconectados") = AC
        Application.Contents("profesconectados") = PC
        Application.UnLock()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
    End Sub

End Class