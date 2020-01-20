Imports System.IO
Imports MySql.Data.MySqlClient

Public Class GestorAloj
    Dim conexion As New conexion
    Dim valorBorrar As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RellenarComboBox()
        llamodatos()
    End Sub

    Public Sub RellenarComboBox()
        Try
            Dim da As New MySqlDataAdapter("select distinct tipo from alojamiento", conexion.MysqlConnString)
            Dim da2 As New MySqlDataAdapter("select distinct localidad from alojamiento", conexion.MysqlConnString)
            Dim DT As New DataTable
            Dim DT2 As New DataTable
            da.Fill(DT)
            da2.Fill(DT2)
            For p = 0 To DT.Rows.Count - 1
                ComboBox1.Items.Add(DT.Rows(p).Item(0))
            Next
            ComboBox1.Items.Add("Sin filtro")
            For t = 0 To DT2.Rows.Count - 1
                ComboBox2.Items.Add(DT2.Rows(t).Item(0))
            Next
            ComboBox2.Items.Add("Sin filtro")
        Catch ex As Exception
            MsgBox("No se lograron cargar los datos por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conexion.MysqlConexion.Open()
            llamodatos()
            ComboBox1.Text = "Sin Filtro"
            ComboBox2.Text = "Sin Filtro"
            TextBox1.Text = ""
            conexion.MysqlConexion.Close()
        Catch ex As Exception
            MsgBox("La conexión no fue exitosa")
        End Try
    End Sub

    Protected Sub llamodatos()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarLocalidad()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento where localidad='" & ComboBox2.Text & "' ", conexion.MysqlConnString)
            MsgBox("select * from alojamiento where localidad='" & ComboBox2.Text & "' ")
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarTipoAlojamiento()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento where tipo='" & ComboBox1.Text & "' ", conexion.MysqlConnString)
            MsgBox("select * from alojamiento where tipo='" & ComboBox1.Text & "' ")
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarCapacidad()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento where capacidad >='" & TextBox1.Text & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarLocalidadYTipo()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento where localidad='" & ComboBox2.Text & "' AND tipo='" & ComboBox1.Text & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarLocalidadYCapacidad()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento where localidad='" & ComboBox2.Text & "' AND capacidad >='" & TextBox1.Text & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarTipoYCapacidad()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento where tipo='" & ComboBox1.Text & "' AND capacidad >='" & TextBox1.Text & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub filtrarLocalidadYCapacidadYTipo()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento where localidad='" & ComboBox2.Text & "'  AND tipo='" & ComboBox1.Text & "' AND capacidad >='" & TextBox1.Text & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    'zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz'

    Protected Sub modificarLocalidad()
        Try
            Dim da As New MySqlDataAdapter("UPDATE alojamiento SET localidad='" & ComboBox2.Text & "' WHERE idAloj='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarTipoAlojamiento()
        Try
            Dim da As New MySqlDataAdapter("UPDATE alojamiento SET tipo='" & ComboBox1.Text & "' WHERE idAloj='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarCapacidad()
        Try
            Dim da As New MySqlDataAdapter("UPDATE alojamiento SET capacidad='" & TextBox1.Text & "' WHERE idAloj='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarLocalidadYTipo()
        Try

            Dim da As New MySqlDataAdapter("UPDATE alojamiento SET localidad='" & ComboBox2.Text & "', tipo='" & ComboBox1.Text & "' WHERE idAloj='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarLocalidadYCapacidad()
        Try
            Dim da As New MySqlDataAdapter("UPDATE alojamiento SET localidad='" & ComboBox2.Text & "', capacidad='" & TextBox1.Text & "' WHERE idAloj='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarTipoYCapacidad()
        Try
            Dim da As New MySqlDataAdapter("UPDATE alojamiento SET tipo='" & ComboBox1.Text & "', capacidad='" & TextBox1.Text & "' WHERE idAloj='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Protected Sub modificarLocalidadYCapacidadYTipo()
        Try
            Dim da As New MySqlDataAdapter("UPDATE alojamiento SET localidad='" & ComboBox2.Text & "', tipo='" & ComboBox1.Text & "', capacidad='" & TextBox1.Text & "' WHERE idAloj='" & valorBorrar & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    'zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz'

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        generarInforme()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Gestor.Show()
        Me.Hide()
        limpiarCampos()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (ComboBox2.Text = "Sin filtro" Or ComboBox2.Text = " ") Then
            CheckBox1.CheckState = CheckState.Unchecked
        End If
        If (ComboBox1.Text = "Sin filtro" Or ComboBox1.Text = " ") Then
            CheckBox2.CheckState = CheckState.Unchecked
        End If
        If (TextBox1.Text = "") Then
            CheckBox3.CheckState = CheckState.Unchecked
        End If

        If CheckBox1.Checked Then
            filtrarLocalidad()
            If CheckBox2.Checked Then
                If CheckBox3.Checked Then
                    filtrarLocalidadYCapacidadYTipo()
                Else
                    filtrarLocalidadYTipo()
                End If
            End If
            If CheckBox3.Checked Then
                filtrarLocalidadYCapacidad()
            End If
        End If
        If CheckBox2.Checked And Not (CheckBox1.Checked) Then
            filtrarTipoAlojamiento()
            If CheckBox3.Checked Then
                filtrarTipoYCapacidad()
            End If
        End If
        If CheckBox3.Checked And Not (CheckBox1.Checked) And Not (CheckBox2.Checked) Then
            filtrarCapacidad()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (ComboBox2.Text = "Sin filtro" Or ComboBox2.Text = " ") Then
            CheckBox1.CheckState = CheckState.Unchecked
        End If
        If (ComboBox1.Text = "Sin filtro" Or ComboBox1.Text = " ") Then
            CheckBox2.CheckState = CheckState.Unchecked
        End If
        If (TextBox1.Text = "") Then
            CheckBox3.CheckState = CheckState.Unchecked
        End If

        If CheckBox1.Checked Then
            modificarLocalidad()
            If CheckBox2.Checked Then
                If CheckBox3.Checked Then
                    modificarLocalidadYCapacidadYTipo()
                Else
                    modificarLocalidadYTipo()
                End If
            End If
            If CheckBox3.Checked Then
                modificarLocalidadYCapacidad()
            End If
        End If
        If CheckBox2.Checked And Not (CheckBox1.Checked) Then
            modificarTipoAlojamiento()
            If CheckBox3.Checked Then
                modificarTipoYCapacidad()
            End If
        End If
        If CheckBox3.Checked And Not (CheckBox1.Checked) And Not (CheckBox2.Checked) Then
            modificarCapacidad()
        End If

        llamodatos()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim da As New MySqlDataAdapter("delete from alojamiento where idAloj='" & valorBorrar & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
            MsgBox("Se ha eliminado el alojamiento con exito")
            llamodatos()
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            valorBorrar = DataGridView1.Rows(e.RowIndex).Cells("idAloj").Value.ToString
            Label21.Text = DataGridView1.Rows(e.RowIndex).Cells("nombre").Value.ToString
            Label20.Text = DataGridView1.Rows(e.RowIndex).Cells("descripcion").Value.ToString
            Label19.Text = DataGridView1.Rows(e.RowIndex).Cells("tipo").Value.ToString
            Label18.Text = DataGridView1.Rows(e.RowIndex).Cells("direccion").Value.ToString
            Label15.Text = DataGridView1.Rows(e.RowIndex).Cells("localidad").Value.ToString
            Label14.Text = DataGridView1.Rows(e.RowIndex).Cells("capacidad").Value.ToString
            Label16.Text = DataGridView1.Rows(e.RowIndex).Cells("email").Value.ToString
            Label17.Text = DataGridView1.Rows(e.RowIndex).Cells("web").Value.ToString

            Label21.Visible = True
            Label20.Visible = True
            Label19.Visible = True
            Label18.Visible = True
            Label15.Visible = True
            Label14.Visible = True
            Label16.Visible = True
            Label17.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub generarInforme()
        Try
            Dim da As New MySqlDataAdapter("select * from alojamiento", conexion.MysqlConnString)
            Dim DTXML As New DataSet
            da.Fill(DTXML)
            DTXML.WriteXml("informeAlojamientos.xml")
            Dim rutaCompleta As String
            rutaCompleta = Path.GetFullPath("informeAlojamientos.xml")
            MsgBox(rutaCompleta)
            MsgBox("El informe de alojamientos se ha generado satisfactoriamente")
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Protected Sub limpiarCampos()
        TextBox1.Text = ""
        ComboBox1.Text = "Sin filtro"
        ComboBox2.Text = "Sin filtro"

        Label21.Visible = False
        Label20.Visible = False
        Label19.Visible = False
        Label18.Visible = False
        Label15.Visible = False
        Label14.Visible = False
        Label16.Visible = False
        Label17.Visible = False

        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
    End Sub

    Private Sub GestorAloj_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Close()
    End Sub


End Class