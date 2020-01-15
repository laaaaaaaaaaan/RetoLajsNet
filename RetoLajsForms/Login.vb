Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Login
    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos;Convert Zero Datetime=True"
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
            Dim da As New MySqlDataAdapter("select * from usuario where admin='1'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            For Each row As DataRow In DT.Rows
                Dim usuario As String = CStr(row("username"))
                Dim password As String = CStr(row("password"))
                Dim admin As String = CStr(row("admin"))
                MsgBox(usuario & password & admin)
                If (TextBox1.Text = usuario And GetHash(TextBox2.Text) = password And admin = "1") Then
                    Gestor.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                    Label3.Visible() = False
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

    Shared Function GetHash(theInput As String) As String
        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
             hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using
    End Function
End Class
