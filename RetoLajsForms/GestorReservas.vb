Imports System.IO
Imports MySql.Data.MySqlClient

Public Class GestorReservas
    Dim conexion As New conexion
    Dim valorBorrar As String
    Dim idUsu As String
    Dim idAloj As String

    Private Sub GestorReservas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenarComboBox()
        llamodatos()
    End Sub

    Protected Sub llamodatos()
        Try
            Dim da As New MySqlDataAdapter("select * from reserva order by idRes ASC", conexion.MysqlConnString)
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
            Dim da As New MySqlDataAdapter("select distinct nombre from usuario", conexion.MysqlConnString)
            Dim da2 As New MySqlDataAdapter("select distinct tipo from alojamiento", conexion.MysqlConnString)
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
            conexion.MysqlConexion.Close()
        Catch ex As Exception
            MsgBox("No se lograron cargar los datos por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Public Sub rellenaLabelDatos()
        Try
            conexion.MysqlConexion.Open()
            Dim datosUsu As MySqlCommand = New MySqlCommand("select * from usuario where idUsr='" & idUsu & "'", conexion.MysqlConexion)
            Dim reader As MySqlDataReader = datosUsu.ExecuteReader()
            While reader.Read()
                Label5.Text = reader("nombre").ToString
                Label5.Visible = True
            End While
            reader.Close()

            Dim datosAloj As MySqlCommand = New MySqlCommand("select * from alojamiento where idAloj='" & idAloj & "'", conexion.MysqlConexion)
            Dim reader1 As MySqlDataReader = datosAloj.ExecuteReader()
            While reader1.Read()
                Label10.Text = reader1("tipo").ToString
                Label12.Text = reader1("nombre").ToString
                Label13.Text = reader1("localidad").ToString
                Label10.Visible = True
                Label12.Visible = True
                Label13.Visible = True
            End While
            reader1.Close()
            conexion.MysqlConexion.Close()
        Catch ex As Exception
            MsgBox("No se lograron cargar los datos por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            valorBorrar = DataGridView1.Rows(e.RowIndex).Cells("idRes").Value.ToString
            idUsu = DataGridView1.Rows(e.RowIndex).Cells("idUsr").Value.ToString
            idAloj = DataGridView1.Rows(e.RowIndex).Cells("idAloj").Value.ToString
            rellenaLabelDatos()
            Label14.Text = DataGridView1.Rows(e.RowIndex).Cells("fechaEntrada").Value
            Label15.Text = DataGridView1.Rows(e.RowIndex).Cells("fechaSalida").Value
            Label14.Visible = True
            Label15.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiarCampos()
        Me.Hide()
        Gestor.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Login.Show()
        Me.Hide()
        limpiarCampos()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        generarInforme()
    End Sub

    Protected Sub generarInforme()
        Try
            Dim da As New MySqlDataAdapter("select * from reserva", conexion.MysqlConnString)
            Dim DTXML As New DataSet
            da.Fill(DTXML)
            DTXML.WriteXml("informeReservas.xml")
            Dim rutaCompleta As String
            rutaCompleta = Path.GetFullPath("informeReservas.xml")
            'MsgBox(rutaCompleta)
            MsgBox("El informe de reservas se ha generado satisfactoriamente")
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim da As New MySqlDataAdapter("delete from reserva where idRes='" & valorBorrar & "' ", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
            llamodatos()
            MsgBox("Se ha eliminado el alojamiento con exito")
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        filtrarNombre()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        filtrarTipo()
    End Sub

    Protected Sub filtrarNombre()
        conexion.MysqlConexion.Open()
        Try
            Dim da As New MySqlDataAdapter("SELECT reserva.idRes, reserva.fechaEntrada, reserva.fechaSalida, reserva.idAloj, reserva.idUsr FROM reserva,usuario WHERE reserva.idUsr=usuario.idUsr and usuario.nombre='" & ComboBox1.Text & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
        conexion.MysqlConexion.Close()
    End Sub

    Protected Sub filtrarTipo()
        conexion.MysqlConexion.Open()
        Try
            Dim da As New MySqlDataAdapter("SELECT reserva.idRes, reserva.fechaEntrada, reserva.fechaSalida, reserva.idAloj, reserva.idUsr FROM reserva,alojamiento WHERE reserva.idAloj=alojamiento.idAloj and alojamiento.tipo='" & ComboBox2.Text & "'", conexion.MysqlConnString)
            Dim DT As New DataTable
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical,)
        End Try
        conexion.MysqlConexion.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llamodatos()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        llamodatos()
    End Sub

    Protected Sub limpiarCampos()
        Label5.Text = ""
        Label10.Text = ""
        Label12.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label15.Text = ""
        ComboBox1.Text = "Sin filtros"
        ComboBox2.Text = "Sin filtros"

        Label5.Visible = False
        Label10.Visible = False
        Label12.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label15.Visible = False
    End Sub

    Private Sub GestorReservas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Close()
    End Sub

End Class