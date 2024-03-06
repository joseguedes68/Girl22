Public Class frmClientesLojaOLD

    Private Sub ClientesLojaBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesLojaBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ClientesLojaBindingSource.EndEdit()
        Me.ClientesLojaTableAdapter.Update(Me.GirlDataSet.ClientesLoja)

    End Sub

    Private Sub frmClientesLoja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GirlDataSet.ClientesLoja' table. You can move, or remove it, as needed.
        Me.ClientesLojaTableAdapter.Fill(Me.GirlDataSet.ClientesLoja)

    End Sub


End Class