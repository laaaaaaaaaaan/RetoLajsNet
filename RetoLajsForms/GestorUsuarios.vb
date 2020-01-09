Imports MySql.Data.MySqlClient

Public Class GestorUsuarios

    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)
    Dim nombre As String
    Dim valorBorrar As String

    Protected Sub llamodatos()
        Try
            Dim da As New MySqlDataAdapter("select * from cliente", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarNombre()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento where localidad='" & nombre & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        llamodatos()
    End Sub

    Private Sub GestorUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llamodatos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim da As New MySqlDataAdapter("delete from cliente where idAloj='" & valorBorrar & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
            llamodatos()
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        valorBorrar = DataGridView1.Rows(e.RowIndex).Cells("idCli").Value.ToString
    End Sub
End Class