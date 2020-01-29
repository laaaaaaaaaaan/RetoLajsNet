Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Login
    Public user As String
    Dim conexion As New conexion

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.PasswordChar = "*"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Loging.Click
        Try
            conexion.MysqlConexion.Open()
            Dim da As New MySqlDataAdapter("select * from usuario where admin='1'", conexion.MysqlConnString)
            Dim cmd As MySqlCommand = New MySqlCommand("select * from usuario where admin='1'", conexion.MysqlConexion)
            Dim DT As New DataTable
            da.Fill(DT)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                For Each row As DataRow In DT.Rows
                    Dim usuario As String = CStr(row("username"))
                    Dim password As String = CStr(row("password"))
                    Dim admin As String = CStr(row("admin"))
                    If (TextBox1.Text = usuario And GetHash(TextBox2.Text) = password And admin = "1") Then
                        Gestor.Show()
                        Me.Hide()
                        TextBox1.Clear()
                        TextBox2.Clear()
                        Label3.Visible() = False
                        Exit While
                    Else
                        Label3.Visible() = True
                    End If
                Next
            End While
            conexion.MysqlConexion.Close()
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try

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
