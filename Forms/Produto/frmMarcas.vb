Public Class frmMarcas


    Private Sub frmMarcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.MarcasTableAdapter.Fill(Me.GirlDataSet.Marcas)
        Catch ex As Exception

        End Try


    End Sub


    Private Sub MarcasDataGridView_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles MarcasDataGridView.CellValidating

        Try



            If e.ColumnIndex = MarcasDataGridView.Columns("MarcaDescr").Index Then
                Dim newValue As String = e.FormattedValue.ToString()

                ' Verifica se o comprimento do valor inserido é maior que 45 caracteres
                If newValue.Length > 45 Then
                    MessageBox.Show("O campo Marca deve ter no máximo 45 caracteres.", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True ' Cancela a edição da célula
                    Exit Sub
                End If

                For Each row As DataGridViewRow In MarcasDataGridView.Rows
                    If row.Index <> e.RowIndex Then ' Exclui a linha atual da comparação
                        Dim cell As DataGridViewCell = row.Cells("MarcaDescr")
                        If cell.Value IsNot Nothing AndAlso Not cell.Value.Equals(DBNull.Value) Then
                            Dim cellValue As String = cell.Value.ToString()
                            ' Convertendo ambas as strings para minúsculas antes de compará-las
                            If String.Equals(newValue.ToLower(), cellValue.ToLower()) Then
                                MessageBox.Show("O valor da Marca está duplicado.", "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                e.Cancel = True ' Cancela a edição da célula
                                Exit Sub
                            End If
                        End If
                    End If
                Next

            End If

        Catch ex As Exception

        End Try

    End Sub




    Private Sub MarcasDataGridView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles MarcasDataGridView.CellValidated
        Try


            Me.MarcasBindingSource.EndEdit()
            Me.MarcasTableAdapter.Update(Me.GirlDataSet.Marcas)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MarcasDataGridView_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles MarcasDataGridView.UserAddedRow
        Try


            Dim maxID As Integer = 0
            For Each row As DataRow In GirlDataSet.Marcas.Rows
                If row.RowState <> DataRowState.Deleted Then
                    If row("MarcaID") > maxID Then
                        maxID = row("MarcaID")
                    End If
                End If
            Next
            MarcasDataGridView.CurrentRow.Cells("MarcaID").Value = maxID + 1



        Catch ex As Exception

        End Try
    End Sub
End Class