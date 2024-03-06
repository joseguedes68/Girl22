Public Class frmTestes




    Private Sub frmTestes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            e.Handled = True
            Beep()
        End If
    End Sub



End Class