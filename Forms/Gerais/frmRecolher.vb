






Public Class frmRecolher




    Private Sub frmRecolher_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim db As New ClsSqlBDados
        Dim dtCab As New DataTable

        Try


            Sql = "SELECT CONVERT(varchar(10), DocCab.DataDoc, 120) AS Data, DocCab.DocNr, Armazens.ArmAbrev, DocCab.Obs FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID WHERE (DocCab.EstadoDoc = 'D') ORDER BY DocCab.DataDoc DESC"
            db.GetData(Sql, dtCab)

            dgvRecolherCab.DataSource = dtCab


            dgvRecolherCab.Columns("Data").Width = 100
            dgvRecolherCab.Columns("DocNr").Width = 100
            dgvRecolherCab.Columns("ArmAbrev").Width = 100
            dgvRecolherCab.Columns("Obs").Width = 100



        Catch ex As Exception

        End Try


    End Sub



    Private Sub CmdGerRecolha_Click(sender As System.Object, e As System.EventArgs) Handles CmdGerRecolha.Click

    End Sub
End Class