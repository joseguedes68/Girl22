



Imports System.Data.SqlClient

Public Class frmConsultaDetalheDocs


    Friend xdoc As String


    Private Sub frmConsultaDetalheDocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim dt As New DataTable
        Dim db As New ClsSqlBDados


        Try

            GirlDataSet.DocDet.Clear()
            Me.DocDetTableAdapter.ClearBeforeFill = True

            Sql = "SELECT * FROM DOCDET WHERE IDDOCCAB='" & xdoc & "'"
            db.GetData(Sql, GirlDataSet.DocDet)


            Sql = "SELECT TipoDocID + ' ' + LEFT(DocNr, 2) + '/' + RIGHT(DocNr, 5) AS Doc FROM  DocCab WHERE IDDOCCAB='" & xdoc & "'"
            Me.Text = db.GetDataValue(Sql)


            'Dim xdocaux As Guid = New Guid(xdoc)
            'GirlDataSet.DocDet.Clear()
            'TODO: This line of code loads data into the 'GirlDataSet.DocDet' table. You can move, or remove it, as needed.
            'Me.DocDetTableAdapter.FillByIdDocCab(Me.GirlDataSet.DocDet, xdoc)
            'Me.DocDetTableAdapter.FillByNrDoc(GirlDataSet.DocDet, "0001", "0001", "FS", "2100103")
            'Me.DocDetTableAdapter.Fill(dt)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmConsultaDetalheDocs_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmConsultaDetalheDocs_Load")


        End Try



    End Sub

    Private Sub frmConsultaDetalheDocs_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Me.Dispose()

    End Sub


End Class