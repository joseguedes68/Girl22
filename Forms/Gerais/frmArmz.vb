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
        MsgBox("ERRO 580!!")
        'MsgBox("As Colunas Codigo -- TipoTerceiro -- Nome -- NIF" & Chr(13) & "               NÃO PODEM SER NULAS")
        e.Cancel = True
    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles ArmazensDataGridView.CellValidating
        ' Verificar se a célula atual é a do campo armazemid

        Try


            If e.ColumnIndex = ArmazensDataGridView.Columns("ArmazemID").Index AndAlso e.RowIndex >= 0 Then
                ' Verifica se a célula está em estado de edição
                If ArmazensDataGridView.IsCurrentCellInEditMode Then
                    Dim cellValue As Object = e.FormattedValue ' Valor atual da célula

                    ' Valida o valor do campo armazemid
                    If Not IsValidArmazemID(cellValue) Then
                        ' Cancela a edição se o valor não estiver no intervalo desejado
                        ArmazensDataGridView.Rows(e.RowIndex).ErrorText = "O armazém ID deve estar entre 0000 e 0099!"
                        e.Cancel = True
                    Else
                        ' Limpa qualquer mensagem de erro se o valor for válido
                        ArmazensDataGridView.Rows(e.RowIndex).ErrorText = ""
                    End If
                End If
            End If

        Catch ex As Exception

        End Try


    End Sub



    Private Function IsValidArmazemID(value As Object) As Boolean
        ' Verifica se o valor é numérico e está no intervalo desejado
        If value.ToString().Length <> 4 Then Return False
        If IsNumeric(value) Then
            Dim armazemID As Integer = CInt(value)
            Return armazemID >= 0 AndAlso armazemID <= 99
        Else
            Return False
        End If
    End Function


End Class