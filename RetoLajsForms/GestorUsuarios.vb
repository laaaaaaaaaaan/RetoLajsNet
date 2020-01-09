Imports MySql.Data.MySqlClient

Public Class GestorUsuarios

    Private MysqlCommand As New MySqlCommand
    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)

    Public Sub Probarconexion()
        Try
            MysqlConexion.Open()
            MsgBox("la conexión fue exitosa")
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter("select * from alojamiento", MysqlConexion)
            da.Fill(ds, "cliente")
            DataGridView1.DataSource = ds.Tables("cliente")
            MysqlConexion.Close()
        Catch ex As Exception
            MsgBox("La conexión no fue exitosa")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Probarconexion()
    End Sub

End Class