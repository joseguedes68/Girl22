Public Class frmTerceiros



    Dim xNIFAux As String


    Private Sub frmTerceiros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TerceirosTableAdapter.Fill(Me.GirlDataSet.Terceiros)
        Me.GirlDataSet.TipoTerceiros.AddTipoTerceirosRow("I", "Armazem")
        Me.GirlDataSet.TipoTerceiros.AddTipoTerceirosRow("C", "Cliente")
        Me.GirlDataSet.TipoTerceiros.AddTipoTerceirosRow("F", "Fornecedor")
        Me.GirlDataSet.TipoTerceiros.AddTipoTerceirosRow("A", "Ambos")


        Dim I As Int16
        For I = 0 To Me.TerceirosDataGridView.Columns.Count - 1
            Me.TerceirosDataGridView.AutoResizeColumn(I, DataGridViewAutoSizeColumnMode.DisplayedCells)
        Next



    End Sub

    Private Sub frmTerceiros_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Me.GirlDataSet.Terceiros.GetChanges Is Nothing Then
            If MsgBox("Pretende Gravar as alterções?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Validate()
                Me.TerceirosBindingSource.EndEdit()
                Me.TerceirosTableAdapter.Update(Me.GirlDataSet.Terceiros)
            Else
                Me.GirlDataSet.Terceiros.RejectChanges()
            End If

        End If

    End Sub





    Private Sub TerceirosBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerceirosBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TerceirosBindingSource.EndEdit()
        Me.TerceirosTableAdapter.Update(Me.GirlDataSet.Terceiros)

    End Sub

    Private Sub TerceirosDataGridView_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles TerceirosDataGridView.CellValidating


        Dim db As New ClsSqlBDados


        Try



            If Me.TerceirosDataGridView.Columns(TerceirosDataGridView.CurrentCell.ColumnIndex).Name = "NIF" Then

                If Len(Me.TerceirosDataGridView("PaisID", TerceirosDataGridView.CurrentRow.Index).Value.ToString) < 2 Then
                    MsgBox("Falta preencher o Pais!")
                    e.Cancel = True
                    Exit Sub
                End If

                Sql = "SELECT COUNT(*) FROM TERCEIROS WHERE TERCID='" & Me.TerceirosDataGridView("TercID", TerceirosDataGridView.CurrentRow.Index).Value & "'"
                If db.GetDataValue(Sql) = 0 Then
                    If Me.TerceirosDataGridView("PaisID", TerceirosDataGridView.CurrentRow.Index).Value = "PT" Then
                        If Not IsValidContrib(Me.TerceirosDataGridView("NIF", TerceirosDataGridView.CurrentRow.Index).Value) Then
                            MsgBox("O NIF NÃO É VÁLIDO PARA CLIENTE NACIONAL!")
                            e.Cancel = True
                        End If
                    End If
                Else
                    e.Cancel = True
                    MsgBox("O NIF NÃO PODE SER ALTERADO!")
                End If

            End If




        Catch ex As Exception

        End Try

    End Sub

    Private Sub TerceirosDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TerceirosDataGridView.DataError

        MsgBox("DADOS ERRADOS!!")
        e.Cancel = True
    End Sub






    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If keyData = Keys.Enter Then
            If TypeOf Me.ActiveControl Is DataGridViewTextBoxEditingControl Then
                If TerceirosDataGridView.CurrentCell.ColumnIndex < TerceirosDataGridView.ColumnCount - 1 Then
                    TerceirosDataGridView.CurrentCell = TerceirosDataGridView.Rows(TerceirosDataGridView.CurrentCell.RowIndex).Cells(TerceirosDataGridView.CurrentCell.ColumnIndex + 1)
                Else
                    Return MyBase.ProcessCmdKey(msg, keyData)
                End If
            End If
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

    End Function









    Private Sub TerceirosDataGridView_RowValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles TerceirosDataGridView.RowValidating


        Dim db As New ClsSqlBDados

        Try


            'verificar se é novo:

            Sql = "SELECT COUNT(*) FROM TERCEIROS WHERE TERCID='" & Me.TerceirosDataGridView("TercID", TerceirosDataGridView.CurrentRow.Index).Value & "'"
            If db.GetDataValue(Sql) = 0 Then
                'o registo é novo!!!
                'MsgBox(Me.TerceirosDataGridView("TercID", TerceirosDataGridView.CurrentRow.Index).Value & " " & e.RowIndex & " e " & e.ColumnIndex)
                e.Cancel = True

            End If







        Catch ex As Exception

        End Try



    End Sub
End Class