Imports MySql.Data.MySqlClient

Public Class Login
    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GestorAloj.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GestorUsuarios.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GestorReservas.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim valor() As String
            Dim da As New MySqlDataAdapter("select * from cliente", MysqlConnString)
            ':::Creamos el objeto DataTable que recibe la informacion del DataAdapter
            Dim DT As New DataTable
            ':::Pasamos la informacion del DataAdapter al DataTable mediante la propiedad Fill
            da.Fill(DT)
            For Each row As DataRow In DT.Rows
                valor(0) = CStr(row("username"))
            Next

        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
        If TextBox1.Text = "sdf" Then

        End If
    End Sub
End Class
