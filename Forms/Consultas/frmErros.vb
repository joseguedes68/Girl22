Imports System.Data.SqlClient





Public Class frmErros



    Private Sub EventosBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.EventosBindingSource.EndEdit()
        Me.EventosTableAdapter.Update(Me.GirlDataSet.Eventos)

    End Sub

    Private Sub frmErros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'POR MINHA INICIATIVA COMENTEI A ATUALIZAÇÃO DE ESTADO, ACHO QUE NÃO FAZ SENTIDO....
        'ActualizaEstadoTalao()

        Me.EventosTableAdapter.Fill(Me.GirlDataSet.Eventos)

    End Sub


    Private Sub EventosDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles EventosDataGridView.CellMouseClick
        Try

            Dim dg As New clsDataGrid(Me.EventosDataGridView, , Me.EventosBindingSource)
            Try
                If e.Button = Windows.Forms.MouseButtons.Right Then

                    dg.MostraFiltroForm(e)

                End If


                If e.Button = Windows.Forms.MouseButtons.Left Then

                    Select Case e.ColumnIndex
                        Case 4
                            If Not EventosDataGridView.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then

                                xMovTalao = EventosDataGridView.Item(e.ColumnIndex, e.RowIndex).Value

                                frmMovTalao.StartPosition = FormStartPosition.CenterParent
                                frmMovTalao.WindowState = FormWindowState.Normal
                                frmMovTalao.ShowInTaskbar = False
                                frmMovTalao.MaximizeBox = False
                                frmMovTalao.MinimizeBox = False
                                frmMovTalao.ShowDialog(Me)

                            End If

                        Case 3


                            If Not EventosDataGridView.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then

                                Dim sArtigo As String = EventosDataGridView.Item(e.ColumnIndex, e.RowIndex).Value

                                If Len(sArtigo) < 11 Then Exit Sub

                                frmStockLoja.xModelo = Microsoft.VisualBasic.Left(sArtigo, 5)
                                frmStockLoja.xCor = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(sArtigo, 8), 2)
                                frmStockLoja.StartPosition = FormStartPosition.CenterParent
                                frmStockLoja.WindowState = FormWindowState.Normal
                                frmStockLoja.ShowInTaskbar = False
                                frmStockLoja.MaximizeBox = False
                                frmStockLoja.MinimizeBox = False
                                frmStockLoja.ShowDialog(Me)

                            End If
                    End Select
                End If


            Catch ex As Exception
                ErroVB(ex.Message, Me.Name + ": EventosDataGridView_CellMouseClick")
            Finally
                dg.Dispose()
                dg = Nothing
            End Try
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": EventosDataGridView_CellMouseClick")
        End Try
    End Sub


    Private Sub ActualizaEstadoTalao()

        Dim db As New ClsSqlBDados

        Try

            Sql = "UPDATE Eventos SET Descr3 = Serie.ArmazemID + '/' + Serie.EstadoID FROM Eventos INNER JOIN Serie ON Eventos.Descr2 = Serie.SerieID "
            db.ExecuteData(Sql)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaEstadoTalao")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaEstadoTalao")
        End Try

    End Sub


    Private Sub EventosBindingNavigatorSaveItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EventosBindingNavigatorSaveItem.Click

        Me.Validate()
        Me.EventosBindingSource.EndEdit()
        Me.EventosTableAdapter.Update(Me.GirlDataSet.Eventos)

    End Sub



    Private Sub EventosDataGridView_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles EventosDataGridView.RowsRemoved
        Try
            btGravar_Click()
        Catch ex As Exception
            ErroVB(ex.Message, "EventosDataGridView_RowsRemoved")
        End Try
    End Sub






    Private Sub btGravar_Click()
        Try

            If Not GirlDataSet.Eventos.GetChanges Is Nothing Then
                Me.Validate()
                Me.EventosBindingSource.EndEdit()
                Me.EventosTableAdapter.Update(Me.GirlDataSet.Eventos)
                Me.GirlDataSet.Eventos.AcceptChanges()

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btGravar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btGravar_Click")
        End Try

    End Sub


End Class