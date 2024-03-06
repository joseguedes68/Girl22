Public Class frmEpocas

    Private Sub EpocasBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EpocasBindingNavigatorSaveItem.Click

        Try


            Me.Validate()
            Me.EpocasBindingSource.EndEdit()
            Me.EpocasTableAdapter.Update(Me.GirlDataSet.Epocas)


        Catch ex As Exception
            ErroVB(ex.Message, "EpocasBindingNavigatorSaveItem_Click")
        End Try



    End Sub

    Private Sub frmEpocas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GirlDataSet.Epocas' table. You can move, or remove it, as needed.
        Me.EpocasTableAdapter.Fill(Me.GirlDataSet.Epocas)

    End Sub
End Class