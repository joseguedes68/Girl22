Public Class frmResumoMensal


    Private Sub frmResumoMensal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CRViewer.Visible = False

        CRViewer.Visible = False

        Dim cryRpt As New rptResumoMensal

        Dim db As New ClsSqlBDados
        Dim xDeData As String = "2011-08-15"
        Dim xAteData As String = "2011-08-15" 'data para a query
        Dim xAteDataReport As String = "2011-08-15" ' data para aparecer no report

        Dim ds As New DataSet

        'Sql = "EXECUTE prc_ResumoMensal @deData='" & xDeData & "', @ateData='" & xAteData & "'"
        'db.GetData(Sql, ds, False)

        If sAplicacao = "CELFGEST" Then
            Sql = "EXECUTE prc_ResumoMensalEx @deData='" & xDeData & "', @ateData='" & xAteData & "'"
            db.GetData(Sql, ds, False)
            'btListar.Visible = False
        ElseIf sAplicacao = "GIRL" Then
            btListarEx.Visible = False
            Sql = "EXECUTE prc_ResumoMensal @deData='" & xDeData & "', @ateData='" & xAteData & "'"
            db.GetData(Sql, ds, False)
        End If

        cryRpt.SetDataSource(ds.Tables(0)) 'FUNCIONA PORQUE SÓ TEM UMA TABELA NO REPORT?????
        cryRpt.SetParameterValue("deData", xDeData)
        cryRpt.SetParameterValue("ateData", xAteData)

        Me.CRViewer.ReportSource = cryRpt
        Me.CRViewer.Refresh()

    End Sub

    Private Sub btListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListar.Click, btListarEx.Click

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados
        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report

            'Dim xDeData As String = "2011-08-01"
            'Dim xAteData As String = "2011-09-01" 'data para a query
            'Dim xAteDataReport As String = "2011-08-31" ' data para aparecer no report

            'Dim cryRpt As New ReportDocument
            'Dim cryRpt As New rptResumoMensal

            Dim ds As New DataSet

            'cryRpt.Load("C:\Girl\Reports\rptResumoMensal.rpt")

            If btListar.Focused Then
                Sql = "EXECUTE prc_ResumoMensal @deData='" & xDeData & "', @ateData='" & xAteData & "'"
                db.GetData(Sql, ds, False)
                Dim cryRpt As New rptResumoMensal
                'NOTA: A TABELA NO DATASET LISTAGENS SÓ SERVER PARA PODER DER OS CAMPOS DISPONIVEIS PARA CONSTRUIR O REPORT. PENSO EU....
                'NOTA: PARA TER UMA BASE DE CRIAÇÃO DO REPORT, TENHO QUE TER UM DATASET E ASSOCIA-LO AO REPORT
                cryRpt.SetDataSource(ds.Tables(0)) 'FUNCIONA PORQUE SÓ TEM UMA TABELA NO DATASET ou SEJA, NO ds só tem uma tabela. este dataset não tem nada haver com o dslistagem, este só serve para fazer a ponte com o report
                'ou seja, as colunas tem que ter os mesmos nomes


                cryRpt.SetParameterValue("deData", xDeData)
                cryRpt.SetParameterValue("ateData", xAteDataReport)
                Me.CRViewer.ReportSource = cryRpt
                cryRpt = Nothing
            End If


            If btListarEx.Focused Then
                Sql = "EXECUTE prc_ResumoMensalEx @deData='" & xDeData & "', @ateData='" & xAteData & "'"
                db.GetData(Sql, ds, False)
                Dim cryRpt As New rptResumoMensalEx


                cryRpt.SetDataSource(ds.Tables(0))
                cryRpt.SetParameterValue("deData", xDeData)
                cryRpt.SetParameterValue("ateData", xAteDataReport)
                Me.CRViewer.ReportSource = cryRpt
                cryRpt = Nothing
            End If

            'If sAplicacao = "CELFGEST" Then
            '    Sql = "EXECUTE prc_ResumoMensalEx @deData='" & xDeData & "', @ateData='" & xAteData & "'"
            '    db.GetData(Sql, ds, False)
            'ElseIf sAplicacao = "GIRL" Then
            '    Sql = "EXECUTE prc_ResumoMensal @deData='" & xDeData & "', @ateData='" & xAteData & "'"
            '    db.GetData(Sql, ds, False)
            'End If

            ''cryRpt.Database.Tables("dtMapaVendas").SetDataSource(ds.Tables(0))
            'cryRpt.SetDataSource(ds.Tables(0)) 'FUNCIONA PORQUE SÓ TEM UMA TABELA NO REPORT?????
            'cryRpt.SetParameterValue("deData", xDeData)
            'cryRpt.SetParameterValue("ateData", xAteDataReport)
            'Me.CRViewer.ReportSource = cryRpt

            Me.CRViewer.Refresh()

            CRViewer.Visible = True


        Catch ex As Exception

            ErroVB(ex.Message, "frmResumoMensal: btListar_Click")

        Finally

            Me.Cursor = Cursors.Default


        End Try
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class