Imports System.Data.SqlClient

Public Class frmTipos

    Dim dtTipos As New DataTable
    Dim daTipos As New SqlDataAdapter
    Dim CmdBuilder As SqlCommandBuilder




    Private Sub frmTipos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            'Sql = "SELECT TipoId as Tipo, DescrTipo as Descrição, DescrAbrev FROM Tipos ORDER BY TipoId"
            Sql = "SELECT TipoId as Tipo, DescrTipo as Descrição, DescrAbrev, DescrAux, PID as PIdAux, PIDDESCR as PDescrAux, Ordem FROM Tipos ORDER BY TipoId"

            daTipos = New SqlDataAdapter(Sql, cn)
            daTipos.Fill(dtTipos)
            CmdBuilder = New SqlCommandBuilder(daTipos)
            dgvTipos.DataSource = dtTipos
            dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvTipos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

            'C1DbNavigator

            C1DbNavigator.DataSource = dtTipos

            'WindowState = FormWindowState.Maximized




        Catch ex As Exception
        End Try



    End Sub





    Private Sub dgvTipos_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipos.RowValidated

        Try
            daTipos.Update(dtTipos)
        Catch ex As Exception
        End Try

    End Sub


End Class

