Imports MySql.Data.MySqlClient

Public Class GestorReservas

    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)

    Protected Sub llamodatos()
        Try
            Dim da As New MySqlDataAdapter("select * from reserva", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub GestorReservas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llamodatos()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class