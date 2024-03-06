Public Class frmVerificarTalFalta
    Private Sub frmVerificarTalFalta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GirlDataSet.Serie' table. You can move, or remove it, as needed.
        Me.SerieTableAdapter.Fill(Me.GirlDataSet.Serie)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim dbGirl As New ClsSqlBDados
        Dim dbCelfGest As New ClsSqlBDados
        Dim dtseriep2 As DataTable

        Try


            'dgvRelacaoTaloes

            ActualizaLigacao("CelfGest")
            Sql = "SELECT SerieID FROM Serie WHERE EstadoID IN ('S','T')"
            dbCelfGest.GetData(Sql, dtseriep2)

            ActualizaLigacao("Girl")

            For Each r As DataRow In dtseriep2.Rows
                Sql = "SELECT SerieID FROM Serie WHERE SerieID=" & r(0)
                dbGirl.GetData(Sql, dtseriep2)
            Next





        Catch ex As Exception

        End Try


    End Sub
End Class