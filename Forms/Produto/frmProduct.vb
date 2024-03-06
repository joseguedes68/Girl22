Public Class frmProduct



    Private Sub frmProduct_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GirlDataSet1.Unidades' table. You can move, or remove it, as needed.
        Me.UnidadesTableAdapter.Fill(Me.GirlDataSet1.Unidades)

        Dim dtUnid As New DataTable

        Try

            GirlDataSet.dtProductType.AdddtProductTypeRow("P", "Produtos")
            GirlDataSet.dtProductType.AdddtProductTypeRow("S", "Serviços")
            GirlDataSet.dtProductType.AdddtProductTypeRow("O", "Outros")
            Me.ProductTableAdapter.Fill(Me.GirlDataSet.Product)




            'Dim db As New ClsSqlBDados



            'Sql = "SELECT UnidID, UnidDescr FROM Unidades ORDER BY UnidID"
            'db.GetData(Sql, dtUnid)

            'Me.dgvProdutos.DataSource = dtOrigens
            'Me.CbOrigem.DisplayMember = "Origem"
            'Me.CbOrigem.ValueMember = "ArmazemID"
            'Me.CbOrigem.SelectedValue = xArmz



        Catch ex As Exception

        End Try

    End Sub

    Private Sub btGravar_Click(sender As System.Object, e As System.EventArgs) Handles btGravar.Click

        Try

            Me.Validate()
            Me.ProductBindingSource.EndEdit()
            Me.ProductTableAdapter.Update(Me.GirlDataSet.Product)


        Catch ex As Exception
            ErroVB(ex.Message, "btGravar_Click")
        End Try


    End Sub

    Private Sub btFechar_Click(sender As System.Object, e As System.EventArgs) Handles btFechar.Click

        Me.Close()

    End Sub




    Private Sub dgvProdutos_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvProdutos.CellBeginEdit



        Dim db As New ClsSqlBDados


        Try

            If Me.dgvProdutos("ProductCode", dgvProdutos.CurrentRow.Index).Value Is DBNull.Value Then
                Exit Sub
            End If

            Dim sProductCode As String = Me.dgvProdutos("ProductCode", dgvProdutos.CurrentRow.Index).Value

            Sql = "SELECT COUNT(*) FROM DocDet WHERE ProductCode = '" & sProductCode & "'"

            If db.GetDataValue(Sql) > 0 Then
                MsgBox("ARTIGO COM MOVIMENTOS! NÃO É POSSIVEL ALTERAR!")
                e.Cancel = True
            End If


        Catch ex As Exception

        End Try


    End Sub

    Private Sub dgvProdutos_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProdutos.CellEndEdit



        Try
            If dgvProdutos.Columns(e.ColumnIndex).Name = "ProductCode" Then
                Me.dgvProdutos("ProductNumberCode", dgvProdutos.CurrentRow.Index).Value = Me.dgvProdutos("ProductCode", dgvProdutos.CurrentRow.Index).Value
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProdutos_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvProdutos.UserDeletingRow
        e.Cancel = True
    End Sub

    Private Sub frmProduct_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing


        Try

            If Not Me.GirlDataSet.Tables("Product").GetChanges Is Nothing Then
                If MsgBox("PRETENDE SAIR SEM GRAVAR?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                End If
            Else
                Me.GirlDataSet.Tables("Product").RejectChanges()
            End If

        Catch ex As Exception

        End Try


    End Sub

End Class