Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System
Imports System.IO
Imports System.Collections

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class passwordseguro
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function esSeguro(ByVal pass As String) As String
        Dim objReader As New StreamReader(Server.MapPath("~/toppasswords.txt"))
        Dim sLine As String = ""

        While Not sLine Is Nothing
            sLine = objReader.ReadLine()
            If sLine = pass Then
                Return "NO"
            End If
        End While
        objReader.Close()
        Return "SI"
        ' If pass = "12345" Or pass = "password" Or pass = "0000" Then
        'Return "NO"
        ' Else : Return "SI"
        'End If
    End Function

End Class