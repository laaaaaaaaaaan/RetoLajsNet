Imports MySql.Data.MySqlClient

Public Class GestorUsuarios

    Dim MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos;Convert Zero Datetime=True"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)
    Dim buscar As String
    Dim valorBorrar As String

    Private Sub GestorUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llamodatos()
    End Sub

    Protected Sub llamodatos()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarDNI()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where dni='" & TextBox3.Text & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarNombre()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where nombre='" & buscar & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarApellido()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where apellidos='" & TextBox2.Text & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarFecha()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where fechanac='" & buscar & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarNombreYApellido()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where nombre='" & TextBox1.Text & "' AND apellidos='" & TextBox2.Text & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarNombreYFecha()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where nombre='" & TextBox1.Text & "' AND fechanac='" & TextBox4.Text & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarApellidoYFecha()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where fechanac='" & TextBox4.Text & "'  AND apellidos='" & TextBox2.Text & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarNombreYApellidoYFecha()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where nombre='" & TextBox1.Text & "' AND fechanac='" & TextBox4.Text & "'  AND apellidos='" & TextBox2.Text & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarNombre()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET nombre='" & TextBox1.Text & "' WHERE idUsr='" & valorBorrar & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarApellido()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET apellidos='" & TextBox2.Text & "' WHERE idUsr='" & valorBorrar & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarFecha()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET fechanac='" & TextBox4.Text & "' WHERE idUsr='" & valorBorrar & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarNombreYApellido()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET nombre='" & TextBox1.Text & "', apellidos='" & TextBox2.Text & "' WHERE idUsr='" & valorBorrar & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarNombreYFecha()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET nombre='" & TextBox1.Text & "', fechanac='" & TextBox4.Text & "' WHERE idUsr='" & valorBorrar & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarApellidoYFecha()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET fechanac='" & TextBox4.Text & "', apellidos='" & TextBox2.Text & "' WHERE idUsr='" & valorBorrar & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarNombreYApellidoYFecha()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET nombre='" & TextBox1.Text & "', apellidos='" & TextBox2.Text & "', fechanac='" & TextBox4.Text & "' WHERE idUsr='" & valorBorrar & "'", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim da As New MySqlDataAdapter("delete from usuario where idUsr='" & valorBorrar & "' ", MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
            llamodatos()
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        filtrarDNI()
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

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If (TextBox1.Text = "") Then
            CheckBox1.CheckState = CheckState.Unchecked
        End If
        If (TextBox2.Text = "") Then
            CheckBox2.CheckState = CheckState.Unchecked
        End If
        If (TextBox4.Text = "" Or TextBox4.Text = "yyyy/mm/dd") Then
            CheckBox3.CheckState = CheckState.Unchecked
        End If

        If CheckBox1.Checked Then
            filtrarNombre()
            If CheckBox2.Checked Then
                If CheckBox3.Checked Then
                    filtrarNombreYApellidoYFecha()
                Else
                    filtrarNombreYApellido()
                End If
            End If
            If CheckBox3.Checked Then
                filtrarNombreYFecha()
            End If
        End If
        If CheckBox2.Checked And Not (CheckBox1.Checked) Then
            filtrarApellido()
            If CheckBox3.Checked Then
                filtrarApellidoYFecha()
            ElseIf Not (CheckBox1.Checked) Then
                filtrarApellido()
            End If
        End If
        If CheckBox3.Checked And Not (CheckBox1.Checked) And Not (CheckBox2.Checked) Then
            filtrarFecha()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextBox1.Text = "") Then
            CheckBox1.CheckState = CheckState.Unchecked
        End If
        If (TextBox2.Text = "") Then
            CheckBox2.CheckState = CheckState.Unchecked
        End If
        If (TextBox4.Text = "" Or TextBox4.Text = "yyyy/mm/dd") Then
            CheckBox3.CheckState = CheckState.Unchecked
        End If

        If CheckBox1.Checked Then
            modificarNombre()
            If CheckBox2.Checked Then
                If CheckBox3.Checked Then
                    modificarNombreYApellidoYFecha()
                Else
                    modificarNombreYApellido()
                End If
            End If
            If CheckBox3.Checked Then
                modificarNombreYFecha()
            End If
        End If
        If CheckBox2.Checked And Not (CheckBox1.Checked) Then
            modificarApellido()
            If CheckBox3.Checked Then
                modificarApellidoYFecha()
            ElseIf Not (CheckBox1.Checked) Then
                modificarApellido()
            End If
        End If
        If CheckBox3.Checked And Not (CheckBox1.Checked) And Not (CheckBox2.Checked) Then
            modificarFecha()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        valorBorrar = DataGridView1.Rows(e.RowIndex).Cells("idUsr").Value.ToString
        Label4.Text = "Nombre: " & DataGridView1.Rows(e.RowIndex).Cells("nombre").Value.ToString
        Label5.Text = "Apellido: " & DataGridView1.Rows(e.RowIndex).Cells("apellidos").Value.ToString
        Label6.Text = "Fecha de nacimiento: " & DataGridView1.Rows(e.RowIndex).Cells("fechanac").Value.ToString
        Label7.Text = "ID: " & DataGridView1.Rows(e.RowIndex).Cells("idUsr").Value.ToString
    End Sub

    Protected Sub limpiarCampos()
        Label4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        Label7.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Gestor.Show()
        Me.Hide()
        limpiarCampos()
    End Sub

End Class