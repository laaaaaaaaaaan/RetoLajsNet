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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Loging.Click
        Try
            Dim da As New MySqlDataAdapter("select * from cliente", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            For Each row As DataRow In DT.Rows
                Dim usuario As String = CStr(row("username"))
                Dim password As String = CStr(row("password"))
                If (TextBox1.Text = usuario And TextBox2.Text = password) Then
                    Gestor.Show()
                    Me.Hide()

                Else
                    Label3.Visible() = True
                End If

            Next

        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
        If TextBox1.Text = "sdf" Then

        End If
    End Sub
End Class
