Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Conexion.Conexion

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class dedicacionMedia
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function media(ByVal asignatura As String) As Integer
        Dim conexion As New SqlConnection
        Dim comando As New SqlCommand
        Dim result As Integer
        'Juntar estudiantes tareas con tareas genericas y hacer un average
        'excutescalar mirar conexion
        conectar()
        Dim st = "select avg(et.HReales) from EstudiantesTareas et inner join TareasGenericas tg on tg.Codigo=et.CodTarea where tg.CodAsig='" & asignatura & "'"
        comando = New SqlCommand(st, obtenerconexion())
        result = comando.ExecuteScalar()
        cerrarconexion()
        Return result
    End Function

End Class