

Imports System.Data.SqlClient


Public Class frmHistoricos

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub btArquivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btArquivar.Click

        Dim xAno As String
        xAno = tbAno.Text
        Dim db As New ClsSqlBDados
        Dim dtLimparModelosCor As New DataTable
        Dim sFotosServer As String = "\\" & xServidor & "\Fotos\"
        Dim PhotosCount As Integer = 0
        Dim folderExists As Boolean
        Dim fileExists As Boolean

        Try

            If xAno <= "2005" Or xAno >= Trim(Str((Today().Year))) Then
                MsgBox("Não é permitido arquivar dados do Ano " & xAno)
                Exit Sub
            End If

            If MsgBox("Esta operação vai arquivar todos os dados até o ano" & xAno & "!! Confirma?", MsgBoxStyle.YesNo, "ARQUIVO") = MsgBoxResult.Yes Then

                Me.Cursor = Cursors.WaitCursor

                'Carregar Tabela com ModelosCor para eliminar fotos
                Sql = "SELECT MODELOID+CORID FROM (SELECT ModeloCor.ModeloID, ModeloCor.CorID, ISNULL(TABEXIS.Existencia,0) EXISTENCIAS, ISNULL(TABULTMOV.UltMov,0) ULTIMOMOVIMENTO FROM ModeloCor LEFT OUTER JOIN (SELECT ModeloID, CorID, ISNULL(YEAR(MAX(DtSaida)), 0) AS UltMov FROM Serie AS Serie_1 GROUP BY ModeloID, CorID) AS TABULTMOV ON TABULTMOV.ModeloID = ModeloCor.ModeloID AND TABULTMOV.CorID = ModeloCor.CorID LEFT OUTER JOIN (SELECT ModeloID, CorID, SUM(1) AS Existencia FROM Serie WHERE (EstadoID IN ('S', 'T', 'V', 'G')) GROUP BY ModeloID, CorID) AS TABEXIS ON TABEXIS.ModeloID = ModeloCor.ModeloID AND TABEXIS.CorID = ModeloCor.CorID) AS LIMPAR WHERE EXISTENCIAS='0' AND ULTIMOMOVIMENTO<='" & xAno & "' AND ULTIMOMOVIMENTO<>'0'"
                db.GetData(Sql, dtLimparModelosCor, False)

                folderExists = My.Computer.FileSystem.DirectoryExists(sFotosServer)
                If folderExists Then
                    For Each r As DataRow In dtLimparModelosCor.Rows
                        fileExists = My.Computer.FileSystem.FileExists(sFotosServer + r(0) + ".jpg")
                        If fileExists Then
                            My.Computer.FileSystem.DeleteFile(sFotosServer + r(0) + ".jpg")
                            PhotosCount += 1
                        End If
                    Next
                End If

                'Elimina Modelos sem movimentos desde o ano xAno
                Sql = "BEGIN TRANSACTION SELECT MODELOID, CORID INTO #ARTIGOS_SEM_MOV FROM (SELECT ModeloCor.ModeloID, ModeloCor.CorID, ISNULL(TABEXIS.Existencia,0) EXISTENCIAS, ISNULL(TABULTMOV.UltMov,0) ULTIMOMOVIMENTO FROM ModeloCor LEFT OUTER JOIN (SELECT ModeloID, CorID, ISNULL(YEAR(MAX(DtSaida)), 0) AS UltMov FROM Serie AS Serie_1 GROUP BY ModeloID, CorID) AS TABULTMOV ON TABULTMOV.ModeloID = ModeloCor.ModeloID AND TABULTMOV.CorID = ModeloCor.CorID LEFT OUTER JOIN (SELECT ModeloID, CorID, SUM(1) AS Existencia FROM Serie WHERE (EstadoID IN ('S', 'T', 'V', 'G')) GROUP BY ModeloID, CorID) AS TABEXIS ON TABEXIS.ModeloID = ModeloCor.ModeloID AND TABEXIS.CorID = ModeloCor.CorID) AS LIMPAR WHERE EXISTENCIAS='0' AND ULTIMOMOVIMENTO<='" & xAno & "' AND ULTIMOMOVIMENTO<>'0'; DELETE FROM serie FROM Serie INNER JOIN #ARTIGOS_SEM_MOV ON Serie.ModeloID = #ARTIGOS_SEM_MOV.ModeloID AND Serie.CorID = #ARTIGOS_SEM_MOV.CorID and Serie.EstadoID in ('A','R'); DELETE FROM ModeloCor FROM ModeloCor INNER JOIN #ARTIGOS_SEM_MOV ON ModeloCor.ModeloID = #ARTIGOS_SEM_MOV.ModeloID AND ModeloCor.CorID = #ARTIGOS_SEM_MOV.CorID; DELETE FROM Modelos FROM #ARTIGOS_SEM_MOV INNER JOIN Modelos ON #ARTIGOS_SEM_MOV.ModeloID = Modelos.ModeloID and Modelos.ModeloID not in ((SELECT ModeloId FROM Serie GROUP BY ModeloID));  DELETE FROM Encomendas FROM Encomendas INNER JOIN #ARTIGOS_SEM_MOV ON Encomendas.ModeloID = #ARTIGOS_SEM_MOV.ModeloID AND Encomendas.CorID = #ARTIGOS_SEM_MOV.CorID; COMMIT"
                db.ExecuteData(Sql)

                'ELIMINA DOCUMENTOS ANTIGOS
                Sql = "BEGIN TRANSACTION SELECT DocCab.ArmazemID, SUM(DocDet.Qtd * TipoDoc.MovStock) AS QtdIni INTO #TempStocInicial FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN TipoDoc ON DocCab.TipoDocID = TipoDoc.TipoDocID INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID WHERE (TipoDoc.MovStock <> 0) AND (DocCab.TipoDocID + DocCab.EstadoDoc <> 'SEC') AND (YEAR(DocCab.DataDoc)<= '" & xAno & "') GROUP BY DocCab.ArmazemID; DELETE FROM DOCCAB WHERE YEAR(DATADOC) <= '" & xAno & "' AND TIPODOCID IN ('DC','DF','GE','RC','RE','SE','TD','TL','TT'); UPDATE DocDet SET Qtd = #TempStocInicial.QtdIni FROM DocDet INNER JOIN #TempStocInicial ON DocDet.Armazemid = #TempStocInicial.Armazemid and DocDet.TipoDocID='SI'; DROP TABLE #TempStocInicial; COMMIT"
                db.ExecuteData(Sql)

                MsgBox("Foram eliminados  " & PhotosCount & "  Modelos-Cor!")

            End If

            Me.Cursor = Cursors.Default


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, " btArquivar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, " btArquivar_Click")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            folderExists = Nothing
            PhotosCount = Nothing
            xAno = Nothing
            dtLimparModelosCor = Nothing
            fileExists = Nothing
            sFotosServer = Nothing

        End Try

    End Sub


End Class