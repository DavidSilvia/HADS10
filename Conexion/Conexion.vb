Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class Conexion
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    Private Shared datos As SqlDataReader
    Private Shared actualizar As Integer

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = "Data Source=tcp:hads10-17.database.windows.net,1433;Initial Catalog=HADS10_Usuarios;User ID=HADS10@hads10-17;Password=delfin_10"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub

    Public Shared Function insertarRegistro(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal pregunta As String, ByVal respuesta As String, ByVal dni As String, ByVal numconfir As Integer, ByVal confirmado As Integer, ByVal pass As String) As String
        Dim st = "insert into Usuarios (email, nombre, apellidos, pregunta, respuesta, dni, numconfir, confirmado, pass) values ('" & email & "', '" & nombre & "', '" & apellidos & "', '" & pregunta & "', '" & respuesta & "', '" & dni & "', " & numconfir & ", " & confirmado & ", '" & pass & "')"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ex.Message
        End Try
        Return (numregs & " registro(s) insertado(s) en la BD ")
    End Function

    Public Shared Function obtenerdatos() As SqlDataReader
        Dim st = "select * from Usuarios"
        comando = New SqlCommand(st, conexion)
        datos = comando.ExecuteReader
        Return datos
    End Function

    Public Shared Function enviarEmail(ByVal emailDestino As String, ByVal numconf As Integer) As Boolean
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("hads1017@gmail.com", "HADS1017")
            'Direccion de destino
            Dim to_address As New MailAddress(emailDestino, emailDestino)
            'Password de la cuenta
            Dim from_pass As String = "davidmontllorsilviagarcia"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.gmail.com"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = "Confirmación de registro"
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" + "Pulsa en el siguiente enlace para confirmar: http://hads10-17.azurewebsites.net/Confirmar.aspx?emailDestino=" + emailDestino + "&numconf=" + numconf.ToString + "</body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function

    Public Shared Function actualizarConfirmado(ByVal email As String) As Boolean
        Dim st = "update Usuarios set confirmado=1 where email='" & email & "'"
        comando = New SqlCommand(st, conexion)
        actualizar = comando.ExecuteNonQuery
        Return True
    End Function

    Public Shared Function obtenernumconfir(ByVal email As String) As Long
        Dim st = "Select numconfir from Usuarios where email='" & email & "'"
        comando = New SqlCommand(st, conexion)
        Return comando.ExecuteScalar()
    End Function



End Class
