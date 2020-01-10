Imports MySql.Data.MySqlClient

Public Class GestorUsuarios

    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)
    Dim buscar As String
    Dim valorBorrar As String

    Private Sub GestorUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llamodatos()
    End Sub

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
            Dim da As New MySqlDataAdapter("select * from cliente where nombre='" & buscar & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarNombre()
        Try
            Dim da As New MySqlDataAdapter("UPDATE cliente SET nombre='" & buscar & "' WHERE idCli='" & valorBorrar & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarApellido()
        Try
            Dim da As New MySqlDataAdapter("select * from cliente where apellidos='" & buscar & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarApellido()
        Try
            Dim da As New MySqlDataAdapter("UPDATE cliente SET apellidos='" & buscar & "' WHERE idCli='" & valorBorrar & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarFecha()
        Try
            Dim da As New MySqlDataAdapter("select * from cliente where fechanac='" & buscar & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim da As New MySqlDataAdapter("delete from cliente where idCli='" & valorBorrar & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
            llamodatos()
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        buscar = TextBox1.Text
        If (buscar = "") Then
            TextBox1.BackColor = Color.Red
        Else
            TextBox1.BackColor = Color.White
            filtrarNombre()
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = "yyyy/mm/dd"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        buscar = TextBox2.Text
        If (buscar = "") Then
            TextBox2.BackColor = Color.Red
        Else
            TextBox2.BackColor = Color.White
            filtrarApellido()
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = "yyyy/mm/dd"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        buscar = TextBox4.Text
        If (buscar = "" Or buscar = "yyyy/mm/dd") Then
            TextBox2.BackColor = Color.Red
        Else
            TextBox2.BackColor = Color.White
            filtrarFecha()
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = "yyyy/mm/dd"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        buscar = TextBox1.Text
        modificarNombre()
        llamodatos()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        buscar = TextBox2.Text
        modificarApellido()
        llamodatos()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        NuevoCliente.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        llamodatos()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        valorBorrar = DataGridView1.Rows(e.RowIndex).Cells("idCli").Value.ToString
        Label4.Text = "Nombre: " & DataGridView1.Rows(e.RowIndex).Cells("nombre").Value.ToString
        Label5.Text = "Apellido: " & DataGridView1.Rows(e.RowIndex).Cells("apellidos").Value.ToString
        Label6.Text = "Fecha de nacimiento: " & DataGridView1.Rows(e.RowIndex).Cells("fechanac").Value.ToString
        Label7.Text = "ID: " & DataGridView1.Rows(e.RowIndex).Cells("idCli").Value.ToString
    End Sub

End Class