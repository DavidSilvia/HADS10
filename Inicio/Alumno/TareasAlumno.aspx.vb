Imports System.Data.SqlClient
Imports Conexion.Conexion

Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dstMbrs As New DataSet
        Dim dst As New DataSet
        Dim tbl As New DataTable
        Dim tblMbrs As New DataTable

        conectar()

        If Page.IsPostBack Then
            'Cuando nose ejecuta por primera vez, cogemos los guardados'
            dstMbrs = Session("dl")
            dst = Session("dt")
            tblMbrs = dstMbrs.Tables("GruposClase")
            tbl = dst.Tables("TareasGenericas")
        Else
            'Se crea el dropdown list porque se ejecuta por primera vez'
            Dim dapMbrs = New SqlDataAdapter("select GC.codigoasig from ((Usuarios U inner join EstudiantesGrupo EG on U.email=EG.Email) inner join GruposClase GC on GC.codigo=EG.Grupo) where U.email='" & Session("email") & "'", obtenerconexion())
            Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
            dapMbrs.Fill(dstMbrs, "GruposClase")
            tblMbrs = dstMbrs.Tables("GruposClase")
            DropDownList1.DataTextField = "codigoasig"
            DropDownList1.DataValueField = "codigoasig"
            DropDownList1.DataSource = tblMbrs
            DropDownList1.DataBind()
            'Se guarda el dataset de la lista de datos, para cuando no se carge por primera vez la pagina'
            Session("dl") = dstMbrs

            'Visualizar tareas en el gripview'
            Dim dap = New SqlDataAdapter("select TG.Codigo, TG.Descripcion, TG.CodAsig, TG.HEstimadas, TG.TipoTarea from TareasGenericas TG where TG.Explotacion=1 and TG.Codigo NOT IN (select ET.CodTarea from EstudiantesTareas ET WHERE ET.CodTarea=TG.Codigo and ET.Email='" & Session("email") & "')", obtenerconexion())
            Dim bld As New SqlCommandBuilder(dap)
            dap.Fill(dst, "TareasGenericas")
            tbl = dst.Tables("TareasGenericas")
            'Se guardan el data set de la tabla de datos, para cuando no se carge por primera vez la pagina'
            Session("dt") = dst
        End If
        Dim dv As New DataView(tbl)
        dv.RowFilter = "CodAsig='" & DropDownList1.SelectedValue & "'"
        If dv.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            Label4.Text = "No hay tareas pendientes"
        Else
            GridView1.DataSource = dv
            GridView1.DataBind()
            Label4.Text = ""
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session.Abandon()
        cerrarconexion()
        Response.Redirect("../Inicio.aspx")
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Session("selectedAsig") = DropDownList1.SelectedIndex
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Session("selectedTarea") = GridView1.Rows(GridView1.SelectedIndex).Cells(1).Text
        Response.Redirect("InstanciarTarea.aspx")
    End Sub
End Class