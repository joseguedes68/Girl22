Imports System.Data.SqlClient

Public Class frmLinhas

    Dim dtLinhas As New DataTable
    Dim daLinhas As New SqlDataAdapter
    Dim CmdBuilder As SqlCommandBuilder


    Private Sub frmLinhas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Sql = "SELECT LinhaId as Linha, DescrLinha as Descrição FROM Linhas ORDER BY LinhaId"
            daLinhas = New SqlDataAdapter(Sql, cn)
            daLinhas.Fill(dtLinhas)
            CmdBuilder = New SqlCommandBuilder(daLinhas)
            dgvLinhas.DataSource = dtLinhas
            dgvLinhas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            WindowState = FormWindowState.Normal
            C1DbNavigator.DataSource = dtLinhas
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvLinhas_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLinhas.RowValidated

        Try
            daLinhas.Update(dtLinhas)
        Catch ex As Exception
        End Try

    End Sub


End Class

