Imports System.Data.SqlClient

Public Class frmComissoes

    Dim dtComissoes As New DataTable
    Dim daComissoes As New SqlDataAdapter
    Dim CmdBuilder As SqlCommandBuilder


    Private Sub frmComissoes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Sql = "SELECT ArmazemID as Armazem, LinhaID as Linha, TabPrecoID as TabPreço, UtilizadorId as Util, Comissao as Comissão FROM Comissoes order by ArmazemID, LinhaID, TabPrecoID, UtilizadorId"
            daComissoes = New SqlDataAdapter(Sql, cn)
            daComissoes.Fill(dtComissoes)
            CmdBuilder = New SqlCommandBuilder(daComissoes)
            dgvComissoes.DataSource = dtComissoes
            dgvComissoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            C1DbNavigator.DataSource = dtComissoes

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvComissoes_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvComissoes.RowValidated

        Try
            daComissoes.Update(dtComissoes)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgvComissoes_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvComissoes.CellMouseClick
        Dim dg_Comissoes As New clsDataGrid(Me.dgvComissoes, dtComissoes.DefaultView)
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                dg_Comissoes.MostraFiltroForm(e)
            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": IniciarDataGrid")
        Finally
            dg_Comissoes.Dispose()
            dg_Comissoes = Nothing
        End Try
    End Sub


End Class

