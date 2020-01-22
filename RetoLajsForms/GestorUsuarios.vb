Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class GestorUsuarios
    Dim conexion As New conexion
    Dim valorBorrar As String

    Private Sub GestorUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox6.PasswordChar = "*"
        llamodatos()
        RellenarComboBox()
    End Sub

    Protected Sub llamodatos()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Public Sub RellenarComboBox()
        Try
            conexion.MysqlConexion.Open()
            Dim da As New MySqlDataAdapter("select distinct dni from usuario", conexion.MysqlConnString)
            Dim da1 As New MySqlDataAdapter("select distinct username from usuario", conexion.MysqlConnString)
            Dim DT As New DataTable
            Dim DT1 As New DataTable
            da.Fill(DT)
            da1.Fill(DT1)

            For p = 0 To DT.Rows.Count - 1
                ComboBox1.Items.Add(DT.Rows(p).Item(0))
            Next
            ComboBox1.Items.Add("Sin filtro")

            For p = 0 To DT1.Rows.Count - 1
                ComboBox2.Items.Add(DT1.Rows(p).Item(0))
            Next
            ComboBox2.Items.Add("Sin filtro")
            conexion.MysqlConexion.Close()
        Catch ex As Exception
            MsgBox("No se lograron cargar los datos por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    'Filtrar'

    Protected Sub filtrarDNI()
        If ComboBox1.Text = "Sin filtro" Then
            llamodatos()
        Else
            Try
                Dim da As New MySqlDataAdapter("select * from usuario where dni='" & ComboBox1.Text & "' ", conexion.MysqlConnString)
                Dim DT As New DataTable
                da.Fill(DT)
                DataGridView1.DataSource = DT
            Catch ex As Exception
                MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
            End Try
        End If
    End Sub

    Protected Sub filtrarUsuario()
        If ComboBox2.Text = "Sin filtro" Then
            llamodatos()
        Else
            Try
                Dim da As New MySqlDataAdapter("select * from usuario where username='" & ComboBox2.Text & "' ", conexion.MysqlConnString)
                Dim DT As New DataTable
                da.Fill(DT)
                DataGridView1.DataSource = DT
            Catch ex As Exception
                MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
            End Try
        End If
    End Sub

    Protected Sub filtrarNombre()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where nombre='" & TextBox1.Text & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarApellido()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where apellidos='" & TextBox2.Text & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarFecha()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where fechanac='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarNombreYApellido()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where nombre='" & TextBox1.Text & "' AND apellidos='" & TextBox2.Text & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarNombreYFecha()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where nombre='" & TextBox1.Text & "' AND fechanac='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarApellidoYFecha()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where fechanac='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'  AND apellidos='" & TextBox2.Text & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarNombreYApellidoYFecha()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario where nombre='" & TextBox1.Text & "' AND fechanac='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'  AND apellidos='" & TextBox2.Text & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    'Modificar'

    Protected Sub modificarNombre()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET nombre='" & TextBox1.Text & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarApellido()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET apellidos='" & TextBox2.Text & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarFecha()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET fechanac='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarNombreYApellido()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET nombre='" & TextBox1.Text & "', apellidos='" & TextBox2.Text & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarNombreYFecha()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET nombre='" & TextBox1.Text & "', fechanac='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarApellidoYFecha()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET fechanac='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', apellidos='" & TextBox2.Text & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarNombreYApellidoYFecha()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET nombre='" & TextBox1.Text & "', apellidos='" & TextBox2.Text & "', fechanac='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarContra()
        If (TextBox6.Text = "") Then
            MsgBox("No puede dejar la contraseña vacia")
        Else
            Try
                Dim da As New MySqlDataAdapter("UPDATE usuario SET password='" & GetHash(TextBox6.Text) & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
                Dim DT As New DataTable
                da.Fill(DT)
                DataGridView1.DataSource = DT
                MsgBox("Su contraseña se ha modificado con éxito")
            Catch ex As Exception
                MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
            End Try
        End If
    End Sub

    Protected Sub modificarNombreUsuario()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET username='" & TextBox3.Text & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub darPermisos()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET admin='1' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub quitarPermisos()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET admin= 0 WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub resetearContra()
        Try
            Dim da As New MySqlDataAdapter("UPDATE usuario SET password='" & GetHash(123) & "' WHERE idUsr='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim da As New MySqlDataAdapter("delete from usuario where idUsr='" & valorBorrar & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
            llamodatos()
            MsgBox("Se ha eliminado el usuario con exito")
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        filtrarDNI()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        filtrarUsuario()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        modificarContra()
        llamodatos()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        resetearContra()
        llamodatos()
        MsgBox("Su contraseña se ha reseteado con éxito")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        NuevoCliente.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        generarInforme()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        llamodatos()
        limpiarCampos()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        llamodatos()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If (Not IsNumeric(TextBox3.Text)) Then
            modificarNombreUsuario()
        End If
        llamodatos()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        darPermisos()
        llamodatos()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        quitarPermisos()
        llamodatos()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If (TextBox1.Text = "") Then
            CheckBox1.CheckState = CheckState.Unchecked
        End If
        If (TextBox2.Text = "") Then
            CheckBox2.CheckState = CheckState.Unchecked
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
            End If
        End If
        If CheckBox3.Checked And Not (CheckBox1.Checked) And Not (CheckBox2.Checked) Then
            filtrarFecha()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextBox1.Text = "" Or IsNumeric(TextBox1.Text)) Then
            CheckBox1.CheckState = CheckState.Unchecked
        End If
        If (TextBox2.Text = "" Or IsNumeric(TextBox2.Text)) Then
            CheckBox2.CheckState = CheckState.Unchecked
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
            End If
        End If
        If CheckBox3.Checked And Not (CheckBox1.Checked) And Not (CheckBox2.Checked) Then
            modificarFecha()
        End If
        llamodatos()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            valorBorrar = DataGridView1.Rows(e.RowIndex).Cells("idUsr").Value.ToString
            Label4.Text = "Nombre: " & DataGridView1.Rows(e.RowIndex).Cells("nombre").Value.ToString
            Label5.Text = "Apellido: " & DataGridView1.Rows(e.RowIndex).Cells("apellidos").Value.ToString
            Label6.Text = "Fecha de nacimiento: " & Format(DataGridView1.Rows(e.RowIndex).Cells("fechanac").Value, "yyyy-MM-dd")
            Label7.Text = "ID: " & DataGridView1.Rows(e.RowIndex).Cells("idUsr").Value.ToString
            Label12.Text = "Usuario: " & DataGridView1.Rows(e.RowIndex).Cells("username").Value.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Gestor.Show()
        Me.Hide()
        limpiarCampos()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Login.Show()
        Me.Hide()
        limpiarCampos()
    End Sub

    Shared Function GetHash(theInput As String) As String
        Using hasher As MD5 = MD5.Create()

            Dim dbytes As Byte() = hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            Dim sBuilder As New StringBuilder()

            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using
    End Function

    Protected Sub generarInforme()
        Try
            Dim da As New MySqlDataAdapter("select * from usuario", conexion.MysqlConnString)
            Dim DTXML As New DataSet
            da.Fill(DTXML)
            DTXML.WriteXml("informeUsuario.xml")
            Dim rutaCompleta As String
            rutaCompleta = Path.GetFullPath("informeUsuario.xml")
            'MsgBox(rutaCompleta)
            MsgBox("El informe de usuarios se ha generado satisfactoriamente")
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Protected Sub limpiarCampos()
        Label4.Text = "Nombre:"
        Label5.Text = "Apellido:"
        Label6.Text = "Fecha de nacimiento:"
        Label7.Text = "ID:"
        Label12.Text = "Usuario:"
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = "Sin filtro"
        ComboBox2.Text = "Sin filtro"
        DateTimePicker1.ResetText()
        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
        CheckBox3.CheckState = CheckState.Unchecked
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If TextBox6.PasswordChar = "*" Then
            TextBox6.PasswordChar = ""
        Else
            TextBox6.PasswordChar = "*"
            TextBox6.Focus()
        End If
    End Sub

    Private Sub GestorUsuarios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Close()
    End Sub

End Class