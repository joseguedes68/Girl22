Imports System.Data.SqlClient

Public Class frmGrupos

    Dim dtGrupos As New DataTable
    Dim daGrupos As New SqlDataAdapter
    Dim CmdBuilder As SqlCommandBuilder

    Private Sub frmGrupos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            'Sql = "SELECT GrupoId as Grupo, GrupoDesc as Descrição, EscalaIDDef as Escala FROM Grupos ORDER BY GrupoId"
            Sql = "SELECT GrupoID as Grupo,GrupoDesc as Descrição,EscalaIDDef as Escala,UnidIdDef as Unid FROM Grupos ORDER BY GrupoId"
            daGrupos = New SqlDataAdapter(Sql, cn)
            daGrupos.Fill(dtGrupos)
            CmdBuilder = New SqlCommandBuilder(daGrupos)
            dgvGrupos.DataSource = dtGrupos
            dgvGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            C1DbNavigator.DataSource = dtGrupos

        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgvGrupos_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrupos.RowValidated

        Try
            daGrupos.Update(dtGrupos)
        Catch ex As Exception
        End Try

    End Sub

End Class

