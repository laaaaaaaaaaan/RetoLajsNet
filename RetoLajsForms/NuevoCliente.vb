Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class NuevoCliente
    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)
    Dim idMax As Integer

    Private Sub NuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox4.PasswordChar = "*"
        TextBox5.PasswordChar = "*"
        sacarIdMax()
    End Sub

    Protected Sub sacarIdMax()
        MysqlConexion.Open()
        Dim cmd As MySqlCommand = New MySqlCommand("select MAX(idUsr) from usuario", MysqlConexion)
        Dim reader1 As MySqlDataReader = cmd.ExecuteReader()
        While reader1.Read()
            idMax = reader1("MAX(idUsr)")
        End While
        MysqlConexion.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GestorUsuarios.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cont As Integer = 0
        Dim permiso As Boolean = False
        Dim seguir As Boolean = True
        Try
            MysqlConexion.Open()
            Dim cmd As MySqlCommand = New MySqlCommand("select * from usuario", MysqlConexion)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cont = 0
                If (seguir = True) Then
                    If TextBox1.Text = "" Then
                        TextBox1.BackColor = Color.Red
                        Label9.Visible = True
                    Else
                        cont = cont + 1
                    End If
                    If TextBox1.Text = "" Then
                        TextBox1.BackColor = Color.Red
                        Label9.Visible = True
                    Else
                        cont = cont + 1
                    End If
                    If reader.GetString(7) = TextBox3.Text Or TextBox3.Text = "" Then
                        TextBox1.BackColor = Color.Red
                        Label9.Visible = True
                    Else
                        cont = cont + 1
                    End If
                    If reader.GetString(3) = TextBox6.Text Or TextBox6.Text = "" Or TextBox6.Text <> Calcular(Mid(TextBox6.Text, 1, 8)) Then
                        TextBox1.BackColor = Color.Red
                        Label9.Visible = True
                    Else
                        cont = cont + 1
                    End If
                    If TextBox4.Text <> "" Then
                        If TextBox4.Text = TextBox5.Text Then
                            cont = cont + 1
                        Else
                            TextBox4.BackColor = Color.Red
                            TextBox5.BackColor = Color.Red
                        End If
                    Else
                        TextBox4.BackColor = Color.Red
                        Label9.Visible = True
                    End If
                    If RadioButton1.Checked Then
                        cont = cont + 1
                    Else
                        RadioButton1.BackColor = Color.Red
                        Label9.Visible = True
                    End If
                    If (cont = 6) Then
                        Try
                            reader.Close()
                            Label9.Visible = False
                            idMax = idMax + 1
                            Dim asd As String = "INSERT INTO `usuario`(`idUsr`, `admin`, `apellidos`, `dni`, `fechaNac`, `nombre`, `password`, `username`) VALUES ('" & idMax & "','" & False & "','" & TextBox2.Text & "','" & TextBox6.Text & "','" & DateTimePicker1.Text & "','" & TextBox1.Text & "','" & GetHash(TextBox4.Text) & "','" & TextBox3.Text & "')"
                            Dim we As MySqlCommand = New MySqlCommand(asd, MysqlConexion)
                            we.ExecuteNonQuery()
                            MsgBox("Usuario insertado exitosamente")
                            seguir = False
                            MysqlConexion.Close()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    Else
                        MsgBox("Error al insertar usuario en la base de datos")
                    End If
                End If
            End While
        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            MysqlConexion.Close()
            sacarIdMax()
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

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Function Calcular(Num As String)
        Dim Tabla()
        Dim Result As Integer
        If Len(Num) < 7 Or Len(Num) > 8 Then
            MsgBox("ERROR : el DNI debe de tener 7 o 8 números")
            Exit Function
        End If
        Result = ((Int(Num / 23)) * 23)
        Result = -Result + Num
        Tabla = {"T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E"}
        Calcular = Num & Tabla(Result)
    End Function

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        If TextBox4.PasswordChar = "*" And TextBox5.PasswordChar = "*" Then
            TextBox4.PasswordChar = ""
            TextBox5.PasswordChar = ""
        Else
            TextBox4.PasswordChar = "*"
            TextBox5.PasswordChar = "*"
            TextBox4.Focus()
        End If
    End Sub
End Class