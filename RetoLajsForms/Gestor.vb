Public Class Gestor
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GestorAloj.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GestorUsuarios.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GestorReservas.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Login.Show()
        Me.Hide()
    End Sub
End Class