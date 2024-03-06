
'Imports CrystalDecisions.CrystalReports.Engine


'IMPRESSORA
'Imports System.Drawing
'Imports System.Drawing.Printing

Public Class frmRelacaoVendas

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
            btVndResumo.Visible = False
            btAcessorios.Visible = False
        Else
            Me.cbLojas.SelectedValue = "%"
        End If


    End Sub

    Private Sub btListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListar.Click
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados

        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report

            Dim cryRpt As New CRVndDetalhe

            Dim ds As New DataSet

            Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna AS NomeEmpresa, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia AS MoradaEmpresa, 
                    Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade AS CodigoPostal, Empresas.EmpContrib, Armazens.ArmAbrev AS Loja, Terceiros.Morada, Terceiros.Localidade, 
                    Terceiros.NIF, Terceiros.CodPostal, 
                    RTRIM(LTRIM(DocCab.TipoDocID)) + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS DocNr, DocCab.DataDoc, 
                    DocDet.FormaPagtoID, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) 
                    * DocDet.Qtd) AS Liquido, SUM(DocDet.VlrIVA * DocDet.Qtd) AS IVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS Total, 
                    SUM(DocDet.VlrDescLn * DocDet.Qtd) AS Desconto, SUM(DocDet.Qtd) AS QtdTotal,
                    (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 WHEN 'FT' THEN 1 END AS Expr1) AS SinalMovStk FROM DocCab INNER JOIN
                    DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID 
                    AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
                    Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID
                    GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, DocDet.FormaPagtoID, 
                    RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna, Empresas.EmpContrib, RTRIM(Empresas.EmpMorada) 
                    + ' Nº' + Empresas.EmpNumPolicia, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade, Armazens.ArmAbrev, Terceiros.Morada, Terceiros.CodPostal, 
                    Terceiros.Localidade, Terceiros.NIF, DocCab.DtRegisto
                    HAVING (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.TipoDocID IN ('VD', 'FS', 'NC', 'FT')) 
                    AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, 
                    '" & xAteData & "', 102))
                    ORDER BY DocCab.DataDoc"


            db.GetData(Sql, ds, False)

            'cryRpt.Database.Tables("dtMapaVendas").SetDataSource(ds.Tables(0))
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
            ErroVB(ex.Message, "frmRelacaoVendas: btListar_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try
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

    Private Sub btComissões_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btComissões.Click

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados
        Dim dtAuxFecho As New DataTable
        Dim dtAuxRec As New DataTable



        Try

            'REPORTS : 
            '1 - RESUMO DE LOJA
            '2 - RESUMO POR VENDEDOR


            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report
            Dim sVendedor As String = "%"

            'Sql = "SELECT MIN(DocNr) AS DEDOC, MAX(DocNr) AS ATEDOC, SUM(Obs2) AS MB, SUM(Obs3) AS DH, SUM(DescontoDoc) AS CM FROM DocCab WHERE (TipoDocID = 'FX') AND (ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (EmpresaID = '" & xEmp & "') GROUP BY DataDoc HAVING (DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))"
            'Sql = "SELECT MIN(DocCab.DocNr) AS DEDOC, MAX(DocCab.DocNr) AS ATEDOC, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS VndValor, SUM(DocDet.PercDescLn * (DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS Comissao, DocDet.FormaPagtoID, DocDet.TamID FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) GROUP BY DocDet.FormaPagtoID, DocDet.TamID HAVING (DocDet.FormaPagtoID LIKE '%') AND (DocDet.TamID LIKE '5')"


            'Sql = "SELECT MIN(DocCab.DocNr) AS DEDOC, MAX(DocCab.DocNr) AS ATEDOC, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS VndValor, SUM(DocDet.PercDescLn * (DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS Comissao FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocDet.TamID LIKE '%')"
            Sql = "SELECT MIN(DocCab.DocNr) AS DEDOC, MAX(DocCab.DocNr) AS ATEDOC, ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd),0) AS VndValor, ISNULL(SUM(DocDet.PercDescLn * (DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd),0) AS Comissao FROM DocCab LEFT OUTER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))"

            db.GetData(Sql, dtAuxFecho)
            If dtAuxFecho.Rows.Count = 0 Then
                MsgBox("Não existem fechos no Intervalo de datas")
                Exit Sub
            End If

            Sql = "SELECT isnull(SUM(DocDet.Valor * DocDet.Qtd),0) AS TVnd, isnull(SUM(DocDet.Valor * DocDet.Qtd * DocDet.PercDescLn),0) AS TComissoes FROM DocCab INNER JOIN DocCab AS DocCab_1 ON DocCab.IdDocCabOrig = DocCab_1.IdDocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab_1.EmpresaID = '" & xEmp & "') AND (DocCab_1.ArmazemID = '" + cbLojas.SelectedValue.ToString + "') AND (DocCab_1.TipoDocID = 'FX') AND (DocCab_1.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.TipoDocID = 'RE') AND (DocCab_1.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))"
            db.GetData(Sql, dtAuxRec)
            If dtAuxRec.Rows.Count = 0 Then
                'NÃO EXISTEM RECOLHAS PARA ESTE FECHO

                Exit Sub
            End If


            Dim sMinDoc As String = dtAuxFecho.Rows(0)("DEDOC")
            Dim sMaxDoc As String = dtAuxFecho.Rows(0)("ATEDOC")
            Dim dC1 As Double = dtAuxFecho.Rows(0)("Comissao")
            Dim dC2 As Double = dtAuxRec.Rows(0)("TComissoes") - dtAuxFecho.Rows(0)("Comissao")

            Dim dDep As Double = dtAuxRec.Rows(0)("TVnd") - dtAuxFecho.Rows(0)("VndValor") - dC2

            Dim xLoja As String = cbLojas.SelectedValue.ToString


            Dim cryRpt As New CRComissoes

            Dim ds As New DataSet

            'Sql = "SELECT RECOLHADETALHE.SerieID FROM DocCab INNER JOIN (SELECT DocCab_2.IdDocCabOrig, DocDet_1.SerieID FROM DocCab AS DocCab_2 INNER JOIN DocDet AS DocDet_1 ON DocCab_2.IdDocCab = DocDet_1.IdDocCab) AS RECOLHADETALHE ON DocCab.IdDocCab = RECOLHADETALHE.IdDocCabOrig INNER JOIN Serie ON RECOLHADETALHE.SerieID = Serie.SerieID WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.ArmazemID = '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.EmpresaID = '0001') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (Serie.Vendedor LIKE '%') ORDER BY RECOLHADETALHE.SerieID"
            'db.GetData(Sql, ds, False)
            'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna AS NomeEmpresa, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia AS MoradaEmpresa, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade AS CodigoPostal, Empresas.EmpContrib, Armazens.ArmAbrev AS Loja, Terceiros.Morada, Terceiros.Localidade, Terceiros.NIF, Terceiros.CodPostal, DocCab.DocNr, DocCab.DataDoc, DocDet.FormaPagtoID, SUM(DocDet.Valor * DocDet.Qtd) AS Total, SUM(DocDet.VlrDescLn * DocDet.Qtd) AS Desconto, SUM(DocDet.VlrIVA) AS IVA, SUM(DocDet.Qtd) AS QtdTotal FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, DocDet.FormaPagtoID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna, Empresas.EmpContrib, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia, Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade, Armazens.ArmAbrev, Terceiros.Morada, Terceiros.CodPostal, Terceiros.Localidade, Terceiros.NIF HAVING (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID LIKE '" + xLoja + "') AND (DocCab.TipoDocID = 'VD') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))"

            Sql = "SELECT RECOLHADETALHE.SerieID FROM DocCab INNER JOIN (SELECT DocCab_2.IdDocCabOrig, DocDet_1.SerieID FROM DocCab AS DocCab_2 INNER JOIN DocDet AS DocDet_1 ON DocCab_2.IdDocCab = DocDet_1.IdDocCab) AS RECOLHADETALHE ON DocCab.IdDocCab = RECOLHADETALHE.IdDocCabOrig INNER JOIN Serie ON RECOLHADETALHE.SerieID = Serie.SerieID WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (Serie.Vendedor LIKE '" & sVendedor & "') ORDER BY RECOLHADETALHE.SerieID"
            db.GetData(Sql, ds, False)


            cryRpt.SetDataSource(ds.Tables(0)) 'FUNCIONA PORQUE SÓ TEM UMA TABELA NO REPORT?????

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Sem dados no período!")
                Exit Sub
            End If


            cryRpt.SetParameterValue("deData", xDeData)
            cryRpt.SetParameterValue("ateData", xAteDataReport)
            cryRpt.SetParameterValue("C1", dC1)
            cryRpt.SetParameterValue("C2", dC2)
            cryRpt.SetParameterValue("Valor", dDep)
            cryRpt.SetParameterValue("deDoc", sMinDoc)
            cryRpt.SetParameterValue("ateDoc", sMaxDoc)
            cryRpt.SetParameterValue("Vendedor", sVendedor)
            cryRpt.SetParameterValue("Loja", xLoja)


            Me.CRViewer.ReportSource = cryRpt
            Me.CRViewer.Refresh()

            CRViewer.Visible = True


        Catch ex As Exception
            ErroVB(ex.Message, "frmRelacaoVendas: btComissões_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try
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

    Private Sub btVndResumo_Click(sender As System.Object, e As System.EventArgs) Handles btVndResumo.Click


        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados


        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report

            Dim cryRpt As New CRVndResumo

            Dim ds As New DataSet

            Sql = "SELECT EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal, 
                    SUM(Total) AS Total, SUM(Desconto) AS Desconto, SUM(IVA) AS IVA, SUM(QtdTotal) AS QtdTotal, TipoDocID, TipoDocDesc, SinalMovStk 
                    FROM (SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(Empresas.EmpNome) + ' ' + Empresas.EmpDesigna AS NomeEmpresa, RTRIM(Empresas.EmpMorada) + ' Nº' + Empresas.EmpNumPolicia AS MoradaEmpresa, 
                    Empresas.EmpCodPostal + ' ' + Empresas.EmpLocalidade AS CodigoPostal, Empresas.EmpContrib, Armazens.ArmAbrev AS Loja, Terceiros.Morada, Terceiros.Localidade, Terceiros.NIF, Terceiros.CodPostal, 
                    DocDet.Valor * DocDet.Qtd AS Total, DocDet.VlrDescLn * DocDet.Qtd AS Desconto, DocDet.VlrIVA * DocDet.Qtd AS IVA, DocDet.Qtd AS QtdTotal, TipoDoc.TipoDocDesc,
                    (SELECT CASE DocCab.TipoDocId WHEN 'FS' THEN 1 WHEN 'NC' THEN - 1 WHEN 'FT' THEN 1 END AS Expr1) AS SinalMovStk
                    FROM     DocCab INNER JOIN
                    DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
                    Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
                    Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN
                    Terceiros ON Armazens.TercID = Terceiros.TercID INNER JOIN
                    TipoDoc ON DocCab.TipoDocID = TipoDoc.TipoDocID
                    WHERE  (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) 
                    AND (DocCab.EstadoDoc <> 'A') AND (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND 
                    (DocCab.TipoDocID IN ('VD', 'FS', 'NC', 'FT'))) AS DocCabAux 
                    GROUP BY EmpresaID, ArmazemID, NomeEmpresa, MoradaEmpresa, CodigoPostal, EmpContrib, Loja, Morada, Localidade, NIF, CodPostal, TipoDocID, TipoDocDesc, SinalMovStk"

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

    Private Sub frmRelacaoVendas_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        bConsignacaoAuxListagens = False
    End Sub

    Private Sub btAcessorios_Click(sender As Object, e As EventArgs) Handles btAcessorios.Click


        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim db As New ClsSqlBDados

        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dpAteData.Value.ToString("yyyy-MM-dd") ' data para aparecer no report

            Dim cryRpt As New CRVndAcessorios

            Dim ds As New DataSet

            ''ESTE SELECT TEM O VALOR SEM IVA E SEM COMISSÕES
            'Sql = "SELECT * FROM (
            '    SELECT Armazens.ArmAbrev AS Loja, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, Serie.SerieID, (DocDet.Valor - DocDet.VlrIVA) * DocDet.Qtd * IIF(DocCab.TipoDocId='NC',-1,1) AS Valor, 
            '    (DocDet.Valor - DocDet.VlrIVA) * DocDet.Qtd * IIF(DocCab.TipoDocId='NC',-1,1) * 0.7 AS Deposito, DocDet.Qtd * IIF(DocCab.TipoDocId='NC',-1,1) as Qtd, DocCab.Obs
            '    FROM     DocCab INNER JOIN
            '    DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
            '    Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
            '    Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
            '    Serie ON DocDet.SerieID = Serie.SerieID
            '    WHERE  (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.TipoDocID IN ('VD', 'FS', 'NC', 'FT', 'VC')) 
            '    AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND
            '    (Modelos.GrupoID LIKE '6')
            '    union
            '    SELECT Armazens.ArmAbrev AS Loja, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, Serie.SerieID, (DocDet.Valor - DocDet.VlrIVA) * DocDet.Qtd AS Valor, 
            '    (DocDet.Valor - DocDet.VlrIVA) * DocDet.Qtd * 0.7 AS Deposito, DocDet.Qtd, DocCab.Obs
            '    FROM     DocCab INNER JOIN
            '    DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
            '    Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
            '    Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
            '    Serie ON DocDet.SerieID = Serie.SerieID
            '    WHERE  (DocCab.TercID = DocCab.ArmazemID) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') 
            '    AND (Modelos.GrupoID LIKE '6') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.EstadoDoc = 'D') 
            '    AND (DocCab.TipoDocID IN ('SE')) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))) as A
            '    ORDER BY A.Loja, A.TipoDocID, A.DataDoc"

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


            'Sql = "SELECT * FROM (
            '    SELECT Armazens.ArmAbrev AS Loja, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, Serie.SerieID, DocDet.Valor * DocDet.Qtd * IIF(DocCab.TipoDocId='NC',-1,1) AS Valor, 
            '    0 AS Deposito, DocDet.Qtd * IIF(DocCab.TipoDocId='NC',-1,1) as Qtd, DocCab.Obs
            '    FROM     DocCab INNER JOIN
            '    DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
            '    Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
            '    Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
            '    Serie ON DocDet.SerieID = Serie.SerieID
            '    WHERE  (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.TipoDocID IN ('VD', 'FS', 'NC', 'FT', 'VC')) 
            '    AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND
            '    (Modelos.GrupoID LIKE '6')
            '    union
            '    SELECT Armazens.ArmAbrev AS Loja, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, Serie.SerieID, DocDet.Valor * DocDet.Qtd AS Valor, 
            '    0 AS Deposito, DocDet.Qtd, DocCab.Obs
            '    FROM     DocCab INNER JOIN
            '    DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
            '    Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
            '    Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
            '    Serie ON DocDet.SerieID = Serie.SerieID
            '    WHERE  (DocCab.TercID = DocCab.ArmazemID) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') 
            '    AND (Modelos.GrupoID LIKE '6') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.EstadoDoc = 'D') 
            '    AND (DocCab.TipoDocID IN ('SE')) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))) as A
            '    ORDER BY A.Loja, A.TipoDocID, A.DataDoc"




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

    Private Sub Button1_btAcessoriosA(sender As Object, e As EventArgs) Handles btAcessoriosA.Click


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



            Sql = "SELECT Armazens.ArmAbrev AS Loja, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, Serie.SerieID, DocDet.Valor * DocDet.Qtd AS Valor, 
                0 AS Deposito, DocDet.Qtd, DocCab.Obs
                FROM     DocCab INNER JOIN
                DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
                Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
                Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
                Serie ON DocDet.SerieID = Serie.SerieID
                WHERE  (DocCab.TercID = DocCab.ArmazemID) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') 
                AND (Modelos.GrupoID NOT LIKE '6') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.EstadoDoc = 'D') 
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
End Class