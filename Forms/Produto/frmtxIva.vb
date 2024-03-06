Public Class frmtxIva

    Private Sub TaxIVABindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.TaxIVABindingSource.EndEdit()
        Me.TaxIVATableAdapter.Update(Me.GirlDataSet.TaxIVA)

    End Sub

    Private Sub frmtxIva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GirlDataSet.TaxIVA' table. You can move, or remove it, as needed.
        Me.TaxIVATableAdapter.Fill(Me.GirlDataSet.TaxIVA)
        'TODO: This line of code loads data into the 'GirlDataSet.TaxIVA' table. You can move, or remove it, as needed.
        Me.TaxIVATableAdapter.Fill(Me.GirlDataSet.TaxIVA)
        'TODO: This line of code loads data into the 'GirlDataSet.TaxIVA' table. You can move, or remove it, as needed.
        Me.TaxIVATableAdapter.Fill(Me.GirlDataSet.TaxIVA)

    End Sub

    Private Sub TaxIVABindingNavigatorSaveItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.TaxIVABindingSource.EndEdit()
        Me.TaxIVATableAdapter.Update(Me.GirlDataSet.TaxIVA)

    End Sub

    Private Sub TaxIVABindingNavigatorSaveItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxIVABindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TaxIVABindingSource.EndEdit()
        Me.TaxIVATableAdapter.Update(Me.GirlDataSet.TaxIVA)

    End Sub
End Class