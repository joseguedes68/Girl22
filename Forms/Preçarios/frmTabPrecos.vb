Imports System.Data.SqlClient

Public Class frmTabPrecos

    Dim dtTabPrecos As New DataTable
    Dim daTabPrecos As New SqlDataAdapter
    Dim CmdBuilder As SqlCommandBuilder


    Private Sub frmTabPrecos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            StartPosition = FormStartPosition.CenterScreen
            Sql = "SELECT TabPrecoID as Tabela, DescTabPreco as Descrição, Ordem, Visivel FROM TabelaPrecos  WHERE TabPrecoID<>'00' order by Ordem"
            daTabPrecos = New SqlDataAdapter(Sql, cn)
            daTabPrecos.Fill(dtTabPrecos)
            CmdBuilder = New SqlCommandBuilder(daTabPrecos)
            dgvTabPrecos.DataSource = dtTabPrecos
            dgvTabPrecos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            C1DbNavigator.DataSource = dtTabPrecos
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dgvTabPrecos_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTabPrecos.RowValidated

        Try

            daTabPrecos.Update(dtTabPrecos)


        Catch ex As Exception

        End Try

    End Sub



End Class

