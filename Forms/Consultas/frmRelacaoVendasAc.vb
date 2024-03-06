
'Imports CrystalDecisions.CrystalReports.Engine


'IMPRESSORA
'Imports System.Drawing
'Imports System.Drawing.Printing

Public Class frmRelacaoVendasAc

    Dim dtLojas As New DataTable

    Dim sDocsConsignacao As String = ""
    Dim sbtOrigem As String = ""


    Private Sub FrmRelacaoVendas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'For Each Printer In PrinterSettings.InstalledPrinters
        '    cmbPrinters.Items.Add(Printer)
        'Next




        CRViewer.Visible = False
        Dim db As New ClsSqlBDados

        'PREENCHER COMBOBOX ARMAZEM
        Sql = "SELECT Armazens.ArmazemID, RTRIM(Armazens.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) AS Lojas
            FROM     Armazens INNER JOIN
            Terceiros ON Armazens.TercID = Terceiros.TercID
            WHERE  (Armazens.Activo = 'True') AND (Terceiros.NIF = N'507687213')"

        db.GetData(Sql, dtLojas)
        dtLojas.Rows.Add("%", "Todas as Lojas")
        Me.cbLojas.DataSource = dtLojas
        Me.cbLojas.DisplayMember = "Lojas"
        Me.cbLojas.ValueMember = "ArmazemID"


        If xCallByPosDocs Then
            Me.cbLojas.SelectedValue = xArmz
            Me.cbLojas.Enabled = False
            btVnd.Visible = False

        Else
            Me.cbLojas.SelectedValue = "%"
        End If


    End Sub



    Private Sub btNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados
        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report


            Dim cryRpt As New CRVndResumo

            Dim ds As New DataSet

            'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna AS NomeEmpresa, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia AS MoradaEmpresa, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade AS CodigoPostal, Empresas.EmpContrib, Armazens.ArmAbrev AS Loja, Terceiros.Morada, Terceiros.Localidade, Terceiros.NIF, Terceiros.CodPostal, SUM(DocDet.Valor * DocDet.Qtd) AS Total, SUM(DocDet.VlrDescLn * DocDet.Qtd) AS Desconto, SUM(DocDet.VlrIVA * DocDet.Qtd) AS IVA, SUM(DocDet.Qtd) AS QtdTotal FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna, Empresas.EmpContrib, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade, Armazens.ArmAbrev, Terceiros.Morada, Terceiros.CodPostal, Terceiros.Localidade, Terceiros.NIF HAVING (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.TipoDocID IN ('VD','FS'))"
            'Sql = "SELECT EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal, SUM(Total) AS Total, SUM(Desconto) AS Desconto, SUM(IVA) AS IVA, SUM(QtdTotal) AS QtdTotal FROM (SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna AS NomeEmpresa, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia AS MoradaEmpresa, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade AS CodigoPostal, Empresas.EmpContrib, Armazens.ArmAbrev AS Loja, Terceiros.Morada, Terceiros.Localidade, Terceiros.NIF, Terceiros.CodPostal, DocDet.Valor * DocDet.Qtd * (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 END AS Expr1) AS Total, DocDet.VlrDescLn * DocDet.Qtd * (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 END AS Expr1) AS Desconto, DocDet.VlrIVA * DocDet.Qtd * (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 END AS Expr1) AS IVA, DocDet.Qtd * (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 END AS Expr1) AS QtdTotal FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.EstadoDoc <> 'A') AND (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.TipoDocID IN ('NC', 'FS'))) AS DocCabAux GROUP BY EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal"
            Sql = "SELECT EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal, SUM(Total) AS Total, SUM(Desconto) AS Desconto, SUM(IVA) AS IVA, SUM(QtdTotal) AS QtdTotal FROM (SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna AS NomeEmpresa, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia AS MoradaEmpresa, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade AS CodigoPostal, Empresas.EmpContrib, Armazens.ArmAbrev AS Loja, Terceiros.Morada, Terceiros.Localidade, Terceiros.NIF, Terceiros.CodPostal, DocDet.Valor * DocDet.Qtd AS Total, DocDet.VlrDescLn * DocDet.Qtd AS Desconto, DocDet.VlrIVA * DocDet.Qtd AS IVA, DocDet.Qtd AS QtdTotal FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.EstadoDoc <> 'A') AND (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.TipoDocID IN ('NC'))) AS DocCabAux GROUP BY EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal"

            db.GetData(Sql, ds, False)

            cryRpt.SetDataSource(ds.Tables(0)) 'FUNCIONA PORQUE SÓ TEM UMA TABELA NO REPORT?????

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Sem dados no período!")
                Exit Sub
            End If

            cryRpt.SetParameterValue("deData", xDeData)
            cryRpt.SetParameterValue("ateData", xAteDataReport)

            Me.CRViewer.ReportSource = cryRpt
            Me.CRViewer.Refresh()

            CRViewer.Visible = True


        Catch ex As Exception
            ErroVB(ex.Message, "frmRelacaoVendas: btListarResumo_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click

        Me.Close()

    End Sub



    Private Sub btFS_Click(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados
        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report


            Dim cryRpt As New CRVndResumo

            Dim ds As New DataSet

            'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna AS NomeEmpresa, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia AS MoradaEmpresa, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade AS CodigoPostal, Empresas.EmpContrib, Armazens.ArmAbrev AS Loja, Terceiros.Morada, Terceiros.Localidade, Terceiros.NIF, Terceiros.CodPostal, SUM(DocDet.Valor * DocDet.Qtd) AS Total, SUM(DocDet.VlrDescLn * DocDet.Qtd) AS Desconto, SUM(DocDet.VlrIVA * DocDet.Qtd) AS IVA, SUM(DocDet.Qtd) AS QtdTotal FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna, Empresas.EmpContrib, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade, Armazens.ArmAbrev, Terceiros.Morada, Terceiros.CodPostal, Terceiros.Localidade, Terceiros.NIF HAVING (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.TipoDocID IN ('VD','FS'))"
            'Sql = "SELECT EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal, SUM(Total) AS Total, SUM(Desconto) AS Desconto, SUM(IVA) AS IVA, SUM(QtdTotal) AS QtdTotal FROM (SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna AS NomeEmpresa, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia AS MoradaEmpresa, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade AS CodigoPostal, Empresas.EmpContrib, Armazens.ArmAbrev AS Loja, Terceiros.Morada, Terceiros.Localidade, Terceiros.NIF, Terceiros.CodPostal, DocDet.Valor * DocDet.Qtd * (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 END AS Expr1) AS Total, DocDet.VlrDescLn * DocDet.Qtd * (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 END AS Expr1) AS Desconto, DocDet.VlrIVA * DocDet.Qtd * (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 END AS Expr1) AS IVA, DocDet.Qtd * (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 END AS Expr1) AS QtdTotal FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.EstadoDoc <> 'A') AND (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.TipoDocID IN ('NC', 'FS'))) AS DocCabAux GROUP BY EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal"
            Sql = "SELECT EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal, SUM(Total) AS Total, SUM(Desconto) AS Desconto, SUM(IVA) AS IVA, SUM(QtdTotal) AS QtdTotal FROM (SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna AS NomeEmpresa, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia AS MoradaEmpresa, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade AS CodigoPostal, Empresas.EmpContrib, Armazens.ArmAbrev AS Loja, Terceiros.Morada, Terceiros.Localidade, Terceiros.NIF, Terceiros.CodPostal, DocDet.Valor * DocDet.Qtd AS Total, DocDet.VlrDescLn * DocDet.Qtd AS Desconto, DocDet.VlrIVA * DocDet.Qtd AS IVA, DocDet.Qtd AS QtdTotal FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.EstadoDoc <> 'A') AND (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.TipoDocID IN ('FS'))) AS DocCabAux GROUP BY EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal"

            db.GetData(Sql, ds, False)

            cryRpt.SetDataSource(ds.Tables(0)) 'FUNCIONA PORQUE SÓ TEM UMA TABELA NO REPORT?????

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Sem dados no período!")
                Exit Sub
            End If

            cryRpt.SetParameterValue("deData", xDeData)
            cryRpt.SetParameterValue("ateData", xAteDataReport)

            Me.CRViewer.ReportSource = cryRpt
            Me.CRViewer.Refresh()

            CRViewer.Visible = True


        Catch ex As Exception
            ErroVB(ex.Message, "frmRelacaoVendas: btListarResumo_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btVnd_Click(sender As System.Object, e As System.EventArgs) Handles btVnd.Click



        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados

        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report

            Dim cryRpt As New CrVndAcessorios

            Dim ds As New DataSet


            Sql = "SELECT Armazens.ArmAbrev AS Loja, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, Serie.SerieID, DocDet.Valor * DocDet.Qtd * IIF(DocCab.TipoDocId='NC',-1,1) AS Valor, 
                0 AS Deposito, DocDet.Qtd * IIF(DocCab.TipoDocId='NC',-1,1) as Qtd, DocCab.Obs
                FROM     DocCab INNER JOIN
                DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
                Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
                Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
                Serie ON DocDet.SerieID = Serie.SerieID
                WHERE  (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') 
                AND (DocCab.TipoDocID IN ('FS', 'NC', 'FT')) 
                AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) 
                AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) 
                AND (Modelos.GrupoID LIKE '6')"



            db.GetData(Sql, ds, False)

            cryRpt.SetDataSource(ds.Tables(0))

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Sem dados no período!")
                Exit Sub
            End If

            cryRpt.SetParameterValue("deData", xDeData)
            cryRpt.SetParameterValue("ateData", xAteDataReport)


            Me.CRViewer.ReportSource = cryRpt
            Me.CRViewer.Refresh()

            CRViewer.Visible = True
            Me.Cursor = Cursors.Default

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmRelacaoVendas_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        bConsignacaoAuxListagens = False
    End Sub


    Private Sub cbLojas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbLojas.SelectedValueChanged
        Try


            If ArmazemConsignacao(cbLojas.SelectedValue.ToString) = True Then
                sDocsConsignacao = "'VC'"
            Else
                sDocsConsignacao = "'VD', 'FS', 'NC', 'FT'"
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)



        'Me.Cursor = Cursors.WaitCursor
        'Application.DoEvents()
        'Dim db As New ClsSqlBDados

        'Try

        '    Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
        '    Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
        '    Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report

        '    Dim cryRpt As New CrVndAcessoriosResumo

        '    Dim ds As New DataSet


        '    Sql = "SELECT DocCab.ArmazemID AS Loja, DocCab.TipoDocID AS TipoDocID, SUM(DocDet.Valor * DocDet.Qtd) AS Valor, SUM(DocDet.Qtd) AS Qtd
        '        FROM     DocDet INNER JOIN
        '        Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
        '        DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr INNER JOIN
        '        Serie ON DocDet.SerieID = Serie.SerieID
        '        WHERE  (DocDet.TipoDocID = 'FX') AND (Modelos.GrupoID = '6') AND (DocCab.DataDoc >= CONVERT(DATETIME, '2023-08-13 00:00:00', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '2023-11-01 00:00:00', 102))
        '        GROUP BY DocCab.TipoDocID, DocCab.ArmazemID
        '        HAVING (DocCab.ArmazemID <> '0000')
        '        UNION
        '        SELECT DocCab.ArmazemID AS Loja, DocCab.TipoDocID AS TipoDocID,  SUM(DocDet.Valor * DocDet.Qtd) AS Valor, SUM(DocDet.Qtd) AS Qtd
        '        FROM     DocDet INNER JOIN
        '        Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
        '        DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr INNER JOIN
        '        Serie ON DocDet.SerieID = Serie.SerieID
        '        WHERE  (DocDet.TipoDocID = 'SE') AND (DocCab.EstadoDoc = 'D') AND (DocCab.DataDoc >= CONVERT(DATETIME, '2023-08-13 00:00:00', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '2023-11-01 00:00:00', 102)) AND (Modelos.GrupoID IN ('6', 
        '        '4')) AND (DocCab.TercID = DocCab.ArmazemID)
        '        GROUP BY DocCab.TipoDocID, DocCab.ArmazemID
        '        ORDER BY Loja, TipoDocID;"


        '    db.GetData(Sql, ds, False)

        '    cryRpt.SetDataSource(ds.Tables(0))

        '    If ds.Tables(0).Rows.Count = 0 Then
        '        MsgBox("Sem dados no período!")
        '        Exit Sub
        '    End If

        '    'cryRpt.SetParameterValue("deData", xDeData)
        '    'cryRpt.SetParameterValue("ateData", xAteDataReport)


        '    Me.CRViewer.ReportSource = cryRpt
        '    Me.CRViewer.Refresh()

        '    CRViewer.Visible = True





        'Catch ex As Exception

        'End Try



    End Sub

    Private Sub Button1_btAcessoriosA(sender As Object, e As EventArgs)


        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados

        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report

            Dim cryRpt As New CrVndAcessorios

            Dim ds As New DataSet



            Sql = "SELECT Armazens.ArmAbrev AS Loja, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, Serie.SerieID, DocDet.Valor * DocDet.Qtd AS Valor, 
                0 AS Deposito, DocDet.Qtd, DocCab.Obs
                FROM     DocCab INNER JOIN
                DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
                Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
                Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
                Serie ON DocDet.SerieID = Serie.SerieID
                WHERE  (DocCab.TercID = DocCab.ArmazemID) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') 
                AND (Modelos.GrupoID LIKE '6') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.EstadoDoc = 'D') 
                AND (DocCab.TipoDocID IN ('SE')) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))"



            db.GetData(Sql, ds, False)

            cryRpt.SetDataSource(ds.Tables(0))

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Sem dados no período!")
                Exit Sub
            End If

            cryRpt.SetParameterValue("deData", xDeData)
            cryRpt.SetParameterValue("ateData", xAteDataReport)


            Me.CRViewer.ReportSource = cryRpt
            Me.CRViewer.Refresh()

            CRViewer.Visible = True


        Catch ex As Exception

        End Try

    End Sub



    Private Sub btAnulados_Click(sender As Object, e As EventArgs) Handles btAnulados.Click



        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados

        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report

            Dim cryRpt As New CrVndAcessorios

            Dim ds As New DataSet



            Sql = "SELECT Armazens.ArmAbrev AS Loja, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, Serie.SerieID, DocDet.Valor * DocDet.Qtd AS Valor, 
                0 AS Deposito, DocDet.Qtd, DocCab.Obs
                FROM     DocCab INNER JOIN
                DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
                Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
                Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
                Serie ON DocDet.SerieID = Serie.SerieID
                WHERE  (DocCab.TercID = DocCab.ArmazemID) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') 
                AND (Modelos.GrupoID IN ('4','6')) AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.EstadoDoc = 'D') 
                AND (DocCab.TipoDocID IN ('SE')) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))"



            db.GetData(Sql, ds, False)

            cryRpt.SetDataSource(ds.Tables(0))

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Sem dados no período!")
                Exit Sub
            End If

            cryRpt.SetParameterValue("deData", xDeData)
            cryRpt.SetParameterValue("ateData", xAteDataReport)


            Me.CRViewer.ReportSource = cryRpt
            Me.CRViewer.Refresh()

            CRViewer.Visible = True
            Me.Cursor = Cursors.Default



        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click


        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados

        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report

            Dim cryRpt As New CrVndAcessorios

            Dim ds As New DataSet


            Sql = "SELECT Armazens.ArmAbrev AS Loja, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, Serie.SerieID, DocDet.Valor * DocDet.Qtd AS Valor, 0 AS Deposito, 
                DocDet.Qtd, DocCab.Obs FROM DocCab INNER JOIN
                DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID 
                AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
                Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
                Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
                Serie ON DocDet.SerieID = Serie.SerieID
                WHERE  (DocCab.TercID = DocCab.ArmazemID) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "' AND NOT (DocCab.ArmazemID IN ('0000','0001'))) 
                AND (Modelos.GrupoID NOT IN ('4','6')) AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND 
                (DocCab.EstadoDoc = 'D') AND (DocCab.TipoDocID IN ('SE')) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))"


            db.GetData(Sql, ds, False)

            cryRpt.SetDataSource(ds.Tables(0))

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Sem dados no período!")
                Exit Sub
            End If

            cryRpt.SetParameterValue("deData", xDeData)
            cryRpt.SetParameterValue("ateData", xAteDataReport)


            Me.CRViewer.ReportSource = cryRpt
            Me.CRViewer.Refresh()

            CRViewer.Visible = True
            Me.Cursor = Cursors.Default

        Catch ex As Exception

        End Try
    End Sub
End Class