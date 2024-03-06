

Imports System.Data.SqlClient


Public Class ClsDocs

    Public Function NovoDoc(ByVal sSql As String, ByVal sIdDocCab As String, ByVal sTipoDoc As String) As Boolean

        Dim db As New ClsSqlBDados

        Try


            db.ExecuteData(sSql)

            'VALIDAR SE O DOCUMENTO TEM DETALHE!!!
            Sql = "SELECT COUNT(*) AS NumLinhasDoc FROM DocDet WHERE (IdDocCab = '" & sIdDocCab.ToString & "')"
            If db.GetDataValue(Sql) = 0 Then
                Dim clsApagaDoc As New ClsDocs
                clsApagaDoc.ApagaDoc(sIdDocCab)
                Return False
            End If



            Dim HashKey As New clsHash
            HashKey.CriarHashKey(sIdDocCab)

            If HashOK = False Then
                Dim clsApagaDoc As New ClsDocs
                clsApagaDoc.ApagaDoc(sIdDocCab)
                Return False
            End If

            Dim cQrCode As New clsQrCode
            cQrCode.CarregaQrCode(sIdDocCab.ToString)


            If dberror = True Then
                Dim clsApagaDoc As New ClsDocs
                clsApagaDoc.ApagaDoc(sIdDocCab)
                Return False
            End If


            If sTipoDoc = "GT" Or sTipoDoc = "GC" Then

                Dim NumAT As New clsWebServiceGTs
                Dim sNumAT As String = "1234"

                Sql = "SELECT CountryDescarga FROM DocCab WHERE  IdDocCab = '" & sIdDocCab & "'"
                If db.GetDataValue(Sql) = "PT" Then

                    If NumAT.PedidoAT(sIdDocCab, sNumAT) = False Or Len(Trim(sNumAT)) = 0 Then
                        'não foi possivel assinar o documento
                        If bDesenvolvimento = False Then
                            Dim clsApagaDoc As New ClsDocs
                            clsApagaDoc.ApagaDoc(sIdDocCab)
                            Return False
                        Else
                            sNumAT = "Testes"
                        End If
                    End If
                Else
                    sNumAT = "Estrangeiro"
                End If

                'TODO: ESTOU A ACEITAR QUE SE Len(sNumAT) = 0 NÃO COMUNICOU, MAS NÃO SEI O MOTIVO. MELHORAR ISTO.....

                'GRAVAR NUMERO AT NO DOCUMENTO 
                Sql = "UPDATE DocCab SET ATDocCodeID = N'" & sNumAT & "' WHERE IdDocCab='" & sIdDocCab & "'"
                db.ExecuteData(Sql)


            End If




            'ANTES DE IMPRIMIR VOU VERIFICAR SE O DOC ESTÁ OK E SE FOI DEVIDAMENTE EXPORTADO
            'não devia exportar as vc e outras??
            Dim backupdoc As New ClsExportaXML
            If Not backupdoc.exportadocs(sIdDocCab) Then
                EnviarEmail("Erro", "ERRO Nº1212 NO BACKUP DO DOCUMENTO " + xArmz + sIdDocCab)
            End If

            Return True


        Catch ex As SqlException
            If Not dberrorAtivo Then ErroSQL(ex.Number, ex.Message, "ClsDocs: NovoDoc")
            Return False
        Catch ex As Exception
            ErroVB(ex.Message, "ClsDocs: NovoDoc")
            Return False
        Finally


        End Try


    End Function



    Public Function AlteraDoc() As Boolean

        Try


            'INSERIR CÓDIGO AQUI!!


        Catch ex As SqlException
            If Not dberrorAtivo Then ErroSQL(ex.Number, ex.Message, "ClsDocs: AlteraDoc")
            Return False
        Catch ex As Exception
            ErroVB(ex.Message, "ClsDocs: AlteraDoc")
            Return False
        Finally


        End Try


    End Function




    Public Function ApagaDoc(ByVal sIdDocCab As String) As Boolean

        Dim db As New ClsSqlBDados


        Try


            Sql = "DELETE FROM DOCCAB WHERE IdDocCAb='" & sIdDocCab & "'"
            db.ExecuteData(Sql)

            'INSERIR CÓDIGO AQUI!!



        Catch ex As SqlException
            If Not dberrorAtivo Then ErroSQL(ex.Number, ex.Message, "ClsDocs: ApagaDoc")
            Return False
        Catch ex As Exception
            ErroVB(ex.Message, "ClsDocs: ApagaDoc")
            Return False
        Finally


        End Try


    End Function




    'Public Sub ImprimeDoc(ByVal sIdDocCab As String, ByVal xTipoVia As String)

    '    Try


    '        frmRpt = New frmReport
    '        frmSubRpt = New frmReport
    '        frmSubRptRela = New frmReport


    '        Dim bdados As New ClsSqlBDados
    '        Dim xTipoTerc As String = ""
    '        Dim db As New ClsSqlBDados
    '        Dim dt As New DataTable
    '        bImprimeSubRelatorio = False


    '        With frmRpt

    '            .StartPosition = FormStartPosition.CenterScreen
    '            .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.PageWidth


    '            Sql = "SELECT DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, 
    '                Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, 
    '                DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS DocNrSerie, DocCab.TipoDocID, 
    '                DocCab.ArmazemID, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, Destino.Nome AS DestDescr, 
    '                Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.DocLnNr, 
    '                DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIVA.TxIVA, DocDet.VlrDescLn, DocCab.LocalCarga, 
    '                DocCab.HoraCarga, DocCab.LocDesc, DocDet.Qtd, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, 
    '                DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementStartTime, DocCab.ATDocCodeID, 
    '                DocCab.Hash4d, '" & xTipoVia & "' AS Via, CAST(ROUND(DocDet.Valor / (1 + TaxIVA.TxIVA), 4) AS NUMERIC(36, 4)) AS ValorLiq, 
    '                CAST(ROUND(DocDet.VlrDescLn / (1 + TaxIVA.TxIVA), 4) AS NUMERIC(36, 4)) AS VlrDescLnLiq, DocCab.IdDocCab, 
    '                CASE DocCab.DocOrig WHEN '' THEN '' ELSE 'Doc. Origem: ' + DocCab.DocOrig END DocOrig, DocDet.ProductCode, DocCab.QrCode FROM Empresas 
    '                INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID 
    '                AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Terceiros AS Destino ON DocCab.TercID = Destino.TercID 
    '                INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.IdDocCab = '" & sIdDocCab & "') ORDER BY DocDet.DocLnNr"

    '            db.GetData(Sql, dt)

    '            'xTipoDoc = dt.Compute("max(TipoDocID)", "").ToString
    '            xTipoDoc = dt.Rows(0)("TipoDocID").ToString()


    '            'TODO: A FUNÇÃO SEGUINTE VAI VARIAR EM FUNÇÃO DO TIPO DE DOCUMENTO
    '            If xTipoDoc = "GT" Then .C1Report1.Load(xRptPath & "DocGuiaTransporteQrCode.xml", "GuiaTransp")
    '            If xTipoDoc = "GC" Then .C1Report1.Load(xRptPath & "DocGuiaConsignacaoQrCode.xml", "GuiaConsignacao")
    '            If xTipoDoc = "FT" Then .C1Report1.Load(xRptPath & "DocFacturaQrCode.xml", "Factura")
    '            If xTipoDoc = "NC" Then .C1Report1.Load(xRptPath & "DocNCQrCode.xml", "NC")
    '            If xTipoDoc = "ND" Then .C1Report1.Load(xRptPath & "DocND.xml", "ND")
    '            If xTipoDoc = "GA" Then .C1Report1.Load(xRptPath & "DocGuiaMovAP.xml", "GuiaMAP")
    '            If xTipoDoc = "FC" Then .C1Report1.Load(xRptPath & "DocFacturaConsignacaoQrCode.xml", "Consignacao")
    '            If xTipoDoc = "VD" Then .C1Report1.Load(xRptPath & "DocVndDinheiro.xml", "DocVndDinheiro")
    '            If xTipoDoc = "TD" Then .C1Report1.Load(xRptPath & "DocTalaoDevolucao.xml", "DocTalaoDevolucao")
    '            If xTipoDoc = "TT" Then .C1Report1.Load(xRptPath & "DocVndDinheiro.xml", "DocVndDinheiro")


    '            .C1Report1.DataSource.ConnectionString = sconnectionstringReport
    '            .C1Report1.DataSource.RecordSource = Sql


    '            If xTipoDoc = "FT" Or xTipoDoc = "NC" Then
    '                frmSubRpt.C1Report1 = .C1Report1.Fields("srIva").Subreport
    '                frmSubRpt.C1Report1.DataSource.ConnectionString = sconnectionstringReport
    '                frmSubRpt.C1Report1.DataSource.RecordSource = "SELECT DocCab.IdDocCab, DocDet.TxIva, 
    '                    SUM((DocDet.Valor - DocDet.VlrDescLn) * (1 - 1 / (DocDet.TxIva + 1)) * DocDet.Qtd) AS VIva, 
    '                    SUM((DocDet.Valor - DocDet.VlrDescLn) / (1 + DocDet.TxIva) * DocDet.Qtd) AS VLiq FROM DocCab 
    '                    INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID 
    '                    AND DocCab.DocNr = DocDet.DocNr GROUP BY DocDet.TxIva, DocCab.IdDocCab HAVING (DocCab.IdDocCab = '" & dt.Rows(0)("IdDocCab").ToString & "')"

    '                frmSubRptRela.C1Report1 = .C1Report1.Fields("srDocsRela").Subreport
    '                frmSubRptRela.C1Report1.DataSource.ConnectionString = sconnectionstringReport
    '                frmSubRptRela.C1Report1.DataSource.RecordSource = "Select TipoDoc.TipoDocDesc As TD, 
    '                    DocCab.SerieDoc + N'/' + DocCab.NrDoc AS ND, MAX(DocCab.DataDoc) AS DD, DocSerie.IdDocCab From DocSerie INNER Join
    '                    DocSerie As DocSerie_1 On DocSerie.SerieID = DocSerie_1.SerieID INNER Join
    '                    DocCab On DocSerie_1.IdDocCab = DocCab.IdDocCab INNER Join
    '                    TipoDoc On DocCab.TipoDocID = TipoDoc.TipoDocID Where (DocCab.TipoDocID = 'FC')
    '                    GROUP BY TipoDoc.TipoDocDesc, DocCab.SerieDoc + N'/' + DocCab.NrDoc, DocSerie.IdDocCab
    '                    HAVING(DocSerie.IdDocCab = '" & dt.Rows(0)("IdDocCab").ToString & "')"


    '                'ISTO SÓ SERVE PARA VALIDAR SE MOSTRO O SUBREPORT. ENCONTRAR ALTERNATIVA.....
    '                Sql = "SELECT COUNT(*) AS Linhas
    '                FROM     DocSerie INNER JOIN
    '                DocSerie AS DocSerie_1 ON DocSerie.SerieID = DocSerie_1.SerieID INNER JOIN
    '                DocCab ON DocSerie_1.IdDocCab = DocCab.IdDocCab INNER JOIN
    '                TipoDoc ON DocCab.TipoDocID = TipoDoc.TipoDocID
    '                WHERE  (DocCab.TipoDocID = 'FC')
    '                GROUP BY DocSerie.IdDocCab
    '                HAVING (DocSerie.IdDocCab = '" & dt.Rows(0)("IdDocCab").ToString & "')"
    '                If db.GetDataValue(Sql) > 0 Then
    '                    bImprimeSubRelatorio = True
    '                End If



    '            End If

    '            If xTipoDoc = "GT" Then
    '                'VERIFICAR SE TEM NUM DE AT
    '            Else

    '            End If

    '            JustPrint(.C1Report1)

    '            'isto funciona em 19/06/2022
    '            'If PrintDirect = True Then
    '            '    JustPrint(.C1Report1)
    '            'Else
    '            '    .C1PrtPreview.Document = frmRpt.C1Report1.Document
    '            '    .Show(frmReport)
    '            'End If

    '            ''*******  OPTAR POR IMPRIMIR DIRECTO PARA A IMPRESSORA   *************
    '            'If MsgBox("Visualizar o Documento", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '            '    .C1PrtPreview.Document = frmRpt.C1Report1.Document
    '            '    xNPag = frmRpt.C1PrtPreview.Pages.Count / 3
    '            '    'frmReport.C1Report1.MaxPages
    '            '    .Show(frmReport)
    '            'Else
    '            '    JustPrint(.C1Report1)
    '            '    'AskPrinter(.C1Report1)
    '            'End If





    '        End With


    '    Catch ex As SqlException
    '        If Not dberrorAtivo Then ErroSQL(ex.Number, ex.Message, "ClsDocs: ImprimeDoc")
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "ClsDocs: ImprimeDoc")
    '    Finally


    '    End Try


    'End Sub






End Class
