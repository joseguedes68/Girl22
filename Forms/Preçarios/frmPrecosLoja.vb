Public Class frmPrecosLoja

    Private Sub frmPrecosLoja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GirlDataSet.Armazens' table. You can move, or remove it, as needed.
        Me.ArmazensTableAdapter.Fill(Me.GirlDataSet.Armazens)
        'TODO: This line of code loads data into the 'GirlDataSet.TabPrecosLoja' table. You can move, or remove it, as needed.
        Me.TabPrecosLojaTableAdapter.Fill(Me.GirlDataSet.TabPrecosLoja)
        'TODO: This line of code loads data into the 'GirlDataSet.TabPrecosLoja' table. You can move, or remove it, as needed.
        Me.TabPrecosLojaTableAdapter.Fill(Me.GirlDataSet.TabPrecosLoja)

    End Sub

    Private Sub TabPrecosLojaBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPrecosLojaBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TabPrecosLojaBindingSource.EndEdit()
        Me.TabPrecosLojaTableAdapter.Update(Me.GirlDataSet.TabPrecosLoja)

    End Sub
End Class