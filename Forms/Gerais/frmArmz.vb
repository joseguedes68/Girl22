Public Class frmArmz



    Private Sub frmArmazens_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.ArmazensTableAdapter.Fill(Me.GirlDataSet.Armazens)

        Dim I As Int16
        For I = 0 To Me.ArmazensDataGridView.Columns.Count - 1
            Me.ArmazensDataGridView.AutoResizeColumn(I, DataGridViewAutoSizeColumnMode.DisplayedCells)
        Next

    End Sub

    Private Sub ArmazensBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArmazensBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ArmazensBindingSource.EndEdit()
        Me.ArmazensTableAdapter.Update(Me.GirlDataSet.Armazens)

    End Sub

    Private Sub frmArmazens_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Me.GirlDataSet.Armazens.GetChanges Is Nothing Then
            If MsgBox("Pretende Gravar as alterções?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Validate()
                Me.ArmazensBindingSource.EndEdit()
                Me.ArmazensTableAdapter.Update(Me.GirlDataSet.Armazens)
            Else
                Me.GirlDataSet.Armazens.RejectChanges()
            End If

        End If

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If keyData = Keys.Enter Then
            If TypeOf Me.ActiveControl Is DataGridViewTextBoxEditingControl Then
                If ArmazensDataGridView.CurrentCell.ColumnIndex < ArmazensDataGridView.ColumnCount - 1 Then
                    ArmazensDataGridView.CurrentCell = ArmazensDataGridView.Rows(ArmazensDataGridView.CurrentCell.RowIndex).Cells(ArmazensDataGridView.CurrentCell.ColumnIndex + 1)
                Else
                    Return MyBase.ProcessCmdKey(msg, keyData)
                End If
            End If
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

    End Function

    Private Sub ArmazensDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ArmazensDataGridView.DataError
        MsgBox("As Colunas Codigo -- TipoTerceiro -- Nome -- NIF" & Chr(13) & "               NÃO PODEM SER NULAS")
        e.Cancel = True
    End Sub


End Class