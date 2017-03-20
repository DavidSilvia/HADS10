Imports System.Xml
Imports System.Data.SqlClient
Imports Conexion.Conexion

Public Class ExportarTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
     
        Dim dtv As DataView = SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        Dim tbl As DataTable = dtv.Table

        Try
            tbl.WriteXml("C:\Users\Usuario1\Desktop\UNI\UNI 3\SEGUNDO CUATRI\HADS\Inicio\Inicio\App_Data\" & DropDownList1.SelectedValue & ".xml")
        Catch ex As Exception
            Label4.Text = "ERROOOOR: " + ex.StackTrace
        End Try

        Dim xmldoc As New XmlDocument
        xmldoc.Load("C:\Users\Usuario1\Desktop\UNI\UNI 3\SEGUNDO CUATRI\HADS\Inicio\Inicio\App_Data\" & DropDownList1.SelectedValue & ".xml")
        Label4.Text = "Se ha exportado la tarea correctamente"
       

        'Cambiar nodo raíz
        Dim xmldocnew As New XmlDocument
        Dim newroot As XmlElement = xmldocnew.CreateElement("hads", "tareas", "http://ji.ehu.es/has")
        xmldocnew.AppendChild(newroot)
        newroot.InnerXml = xmldoc.DocumentElement.InnerXml
        'Cambiar nodo DefaultView
        Dim nodeList As XmlNodeList = xmldocnew.GetElementsByTagName("DefaultView")
        Dim i As Integer
        For i = 0 To nodeList.Count - 1
            Dim oldNode As XmlNode = nodeList(0)
            Dim tarea As XmlNode = xmldocnew.CreateElement("tarea")
 
            oldNode.ParentNode.InsertBefore(tarea, oldNode)
            tarea.InnerXml = oldNode.InnerXml
            oldNode.ParentNode.RemoveChild(oldNode)
        Next

        ' Dim nsMgr As New XmlNamespaceManager(xmldocnew.NameTable)
        'nsMgr.AddNamespace("hads", "http://ji.ehu.es/has")

        xmldocnew.Save("C:\Users\Usuario1\Desktop\UNI\UNI 3\SEGUNDO CUATRI\HADS\Inicio\Inicio\App_Data\" & DropDownList1.SelectedValue & ".xml")

    End Sub
End Class