Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class NuevoCliente
    Dim conexion As New conexion
    Dim idMax As Integer

    Private Sub NuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox4.PasswordChar = "*"
        TextBox5.PasswordChar = "*"
        sacarIdMax()
    End Sub

    Protected Sub sacarIdMax()
        conexion.MysqlConexion.Open()
        Dim cmd As MySqlCommand = New MySqlCommand("select MAX(idUsr) from usuario", conexion.MysqlConexion)
        Dim reader1 As MySqlDataReader = cmd.ExecuteReader()
        While reader1.Read()
            idMax = reader1("MAX(idUsr)")
        End While
        conexion.MysqlConexion.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GestorUsuarios.Show()
        Me.Hide()
        limpiarCampos()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cont As Integer = 0
        Dim cont2 As Integer = 0
        Dim cont3 As Integer = 0
        Dim seguir As Boolean = True

        Try
            conexion.MysqlConexion.Open()
            Dim cmd As MySqlCommand = New MySqlCommand("select * from usuario", conexion.MysqlConexion)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                cont = cont + 1
            End While
            reader.Close()

            'comprobar DNI
            cont2 = comprobarDNI(cmd, reader, cont2)

            'comprueba nombre de usuario
            cont3 = comprobarNombreUsu(cmd, reader, cont3)

            'comprueba el resto de campos
            comprobarCampos(cmd, reader, cont, cont2, cont3, seguir)

        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            conexion.MysqlConexion.Close()
            sacarIdMax()
        End Try
    End Sub

    Protected Function comprobarDNI(cmd As MySqlCommand, reader As MySqlDataReader, cont2 As Integer) As Integer
        Try
            reader = cmd.ExecuteReader()
            While reader.Read()
                If TextBox6.Text = "" Or TextBox6.Text <> Calcular(Mid(TextBox6.Text, 1, 8)) Then
                    TextBox6.BackColor = Color.Red
                    Label9.Visible = True
                    Exit While
                ElseIf reader.GetString(3) = TextBox6.Text Then
                    MsgBox("El DNI que esta utilizando ya esta registrado, compruebe su DNI")
                    TextBox6.BackColor = Color.Red
                    Label9.Visible = True
                    Exit While
                Else
                    cont2 = cont2 + 1
                    TextBox6.BackColor = Color.White
                End If
            End While
            reader.Close()
        Catch ex As Exception

        End Try
        Return cont2
    End Function

    Protected Function comprobarNombreUsu(cmd As MySqlCommand, reader As MySqlDataReader, cont3 As Integer) As Integer
        reader = cmd.ExecuteReader()
        While reader.Read()
            If TextBox3.Text = "" Then
                TextBox3.BackColor = Color.Red
                Label9.Visible = True
            ElseIf reader.GetString(7) = TextBox3.Text Then
                MsgBox("El Nombre de usuario que esta utilizando ya esta registrado, utilice otro")
                TextBox3.BackColor = Color.Red
                Label9.Visible = True
                Exit While
            Else
                cont3 = cont3 + 1
            End If
        End While
        reader.Close()
        Return cont3
    End Function

    Protected Sub comprobarCampos(cmd As MySqlCommand, reader As MySqlDataReader, cont As Integer, cont2 As Integer, cont3 As Integer, seguir As Boolean)
        reader = cmd.ExecuteReader()
        While reader.Read()
            Dim contador As Integer = 0
            If (seguir = True) Then
                If TextBox1.Text = "" Then
                    TextBox1.BackColor = Color.Red
                    Label9.Visible = True
                Else
                    contador = contador + 1
                End If
                If TextBox3.Text = "" Then
                    TextBox3.BackColor = Color.Red
                    Label9.Visible = True
                Else
                    contador = contador + 1
                End If
                If TextBox4.Text <> "" Then
                    If TextBox4.Text = TextBox5.Text Then
                        contador = contador + 1
                    Else
                        TextBox4.BackColor = Color.Red
                        TextBox5.BackColor = Color.Red
                    End If
                Else
                    TextBox4.BackColor = Color.Red
                    Label9.Visible = True
                End If
                If (contador = 3) Then
                    If (cont = cont2 And cont = cont3) Then
                        Try
                            reader.Close()
                            Label9.Visible = False
                            idMax = idMax + 1
                            Dim asd As String = "INSERT INTO `usuario`(`idUsr`, `admin`, `apellidos`, `dni`, `fechaNac`, `nombre`, `password`, `username`) VALUES ('" & idMax & "','" & False & "','" & TextBox2.Text & "','" & TextBox6.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TextBox1.Text & "','" & GetHash(TextBox4.Text) & "','" & TextBox3.Text & "')"
                            Dim we As MySqlCommand = New MySqlCommand(asd, conexion.MysqlConexion)
                            we.ExecuteNonQuery()
                            seguir = False
                            MsgBox("¡Usuario administrador creado con éxito!")
                            limpiarCampos()
                            Me.Hide()
                            GestorUsuarios.Show()
                            Exit While
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If
                Else
                    MsgBox("Error al insertar usuario en la base de datos")
                    Exit While
                End If
            End If
        End While
        reader.Close()

    End Sub



    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

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

    Protected Sub limpiarCampos()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White
        TextBox3.BackColor = Color.White
        TextBox4.BackColor = Color.White
        TextBox5.BackColor = Color.White
        TextBox6.BackColor = Color.White

        Label9.Visible = False

        DateTimePicker1.ResetText()
    End Sub

    Private Sub NuevoCliente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Close()
    End Sub

End Class