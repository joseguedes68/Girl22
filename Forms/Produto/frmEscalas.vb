Imports System.Data.SqlClient

Public Class frmEscalas

    Dim dtEscalas As New DataTable
    Dim daEscalas As New SqlDataAdapter
    Dim CmdBuilder As SqlCommandBuilder


    Private Sub frmEscalas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Sql = "SELECT EscalaId as Escala, TamId as Tam, TamDescr as Descrição FROM Escalas ORDER BY EscalaId, TamId"
            daEscalas = New SqlDataAdapter(Sql, cn)
            daEscalas.Fill(dtEscalas)
            CmdBuilder = New SqlCommandBuilder(daEscalas)
            dgvEscalas.DataSource = dtEscalas
            dgvEscalas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            C1DbNavigator.DataSource = dtEscalas

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvEscalas_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEscalas.RowValidated

        Try
            daEscalas.Update(dtEscalas)
        Catch ex As Exception
        End Try

    End Sub


End Class

