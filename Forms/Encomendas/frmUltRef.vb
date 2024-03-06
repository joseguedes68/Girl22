Public Class frmUltRef

    Private Sub frmUltRef_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With DataGridView1
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .Dock = DockStyle.Fill
            .AlternatingRowsDefaultCellStyle.BackColor = Color.YellowGreen
            .AutoSize = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .ReadOnly = True
        End With

        Me.UltRefTipoAbrevTableAdapter.Fill(Me.GirlDataSet.UltRefTipoAbrev)
    End Sub
End Class