Imports MySql.Data.MySqlClient

Public Class NuevoCliente
    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)

    Private Sub NuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedText = ComboBox1.Items(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GestorUsuarios.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cont As Integer = 0
        Dim da As New MySqlDataAdapter("select * from cliente where username='" & TextBox3.Text & "' ", MysqlConnString)
        Dim command As New MySqlCommand
        command.Connection = MysqlConexion
        da.SelectCommand = command
        Dim Mydata As MySqlDataReader
        Mydata = command.ExecuteReader
        If (cont <> 3) Then
            If Mydata.HasRows Or TextBox1.Text = "" Then
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
        Else
            Dim da1 As New MySqlDataAdapter("INSERT INTO `cliente`(`idCli`, `apellidos`, `fechanac`, `nombre`, `password`, `username`) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.SelectedText & "','" & TextBox4.Text & "')" & TextBox1.Text & "' ", MysqlConnString)
            da1.SelectCommand = command
        End If


    End Sub
End Class