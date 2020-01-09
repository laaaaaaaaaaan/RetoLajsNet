Imports MySql.Data.MySqlClient

Public Class GestorAloj

    Private MysqlCommand As New MySqlCommand
    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)
    Dim localidad As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Probarconexion()
        llamodatos()
    End Sub

    Public Sub Probarconexion()
        Try
            Dim da As New MySqlDataAdapter("select distinct tipo from alojamiento", MysqlConnString)
            Dim da2 As New MySqlDataAdapter("select distinct localidad from alojamiento", MysqlConnString)
            Dim DT As New DataTable
            Dim DT2 As New DataTable
            da.Fill(DT)
            da2.Fill(DT2)
            Dim numero As Integer = DT.Rows.Count
            Label3.Text = DT.Rows.Count
            For p = 0 To DT.Rows.Count - 1
                ComboBox1.Items.Add(DT.Rows(p).Item(0))
            Next
            ComboBox1.Items.Add("Sin filtro")
            For t = 0 To DT2.Rows.Count - 1
                ComboBox2.Items.Add(DT2.Rows(t).Item(0))
            Next
            ComboBox2.Items.Add("Sin filtro")
        Catch ex As Exception
            MsgBox("No se lograron cargar los datos por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            MysqlConexion.Open()
            MsgBox("la conexión fue exitosa")
            llamodatos()
            MysqlConexion.Close()
        Catch ex As Exception
            MsgBox("La conexión no fue exitosa")
        End Try
    End Sub

    Protected Sub llamodatos()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento", MysqlConnString)
            ':::Creamos el objeto DataTable que recibe la informacion del DataAdapter
            Dim DT As New DataTable
            ':::Pasamos la informacion del DataAdapter al DataTable mediante la propiedad Fill
            da.Fill(DT)
            ':::Ahora mostramos los datos en el DataGridView
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Label2.Text = DataGridView1.CurrentCell.Value
        Label1.Text = DataGridView1.Rows(1).Cells(4).Value
    End Sub

    Protected Sub filtrarLocalidad()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento where localidad='" & localidad & "' ", MysqlConnString)
            Label1.Text = localidad
            ':::Creamos el objeto DataTable que recibe la informacion del DataAdapter
            Dim DT As New DataTable
            ':::Pasamos la informacion del DataAdapter al DataTable mediante la propiedad Fill
            da.Fill(DT)
            ':::Ahora mostramos los datos en el DataGridView
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarTipoAlojamiento()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento", MysqlConnString)
            Label1.Text = localidad
            ':::Creamos el objeto DataTable que recibe la informacion del DataAdapter
            Dim DT As New DataTable
            ':::Pasamos la informacion del DataAdapter al DataTable mediante la propiedad Fill
            da.Fill(DT)
            ':::Ahora mostramos los datos en el DataGridView
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            localidad = ComboBox1.SelectedItem.ToString()
            filtrarLocalidad()
        Catch ex As Exception
            MsgBox("No va por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            localidad = ComboBox2.SelectedItem.ToString()
            filtrarTipoAlojamiento()
        Catch ex As Exception
            MsgBox("No va por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub
End Class