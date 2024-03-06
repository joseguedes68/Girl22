Public Class frmUtil

    Private Sub UtilizadoresBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles UtilizadoresBindingNavigatorSaveItem.Click

        Me.Validate()
        Me.UtilizadoresBindingSource.EndEdit()
        Me.UtilizadoresTableAdapter.Update(Me.GirlDataSet.Utilizadores)

    End Sub

    Private Sub frmUtil_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GirlDataSet.Utilizadores' table. You can move, or remove it, as needed.
        Me.UtilizadoresTableAdapter.Fill(Me.GirlDataSet.Utilizadores)

    End Sub

    Private Sub btSair_Click(sender As System.Object, e As System.EventArgs) Handles btSair.Click
        UtilizadoresDataGridView.Visible = False
        Close()
    End Sub

    'EVENTOS NA GRID

    Private Sub UtilizadoresDataGridView_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles UtilizadoresDataGridView.DataError
        MsgBox("DADOS ERRADOS!")
    End Sub


End Class