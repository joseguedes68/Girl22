

Imports System.Data.SqlClient
Imports System.Text



Public Class frmSepConsignacao

    Dim sIdDocCabSep As String
    Dim dsCab As New DataSet
    Dim dsDet As New DataSet
    Dim xNovoDoc As String
    Dim sTercIDGT As String
    Dim sTercIDCC As String

    Dim sAddressDetailCarga As String
    Dim sCityCarga As String
    Dim sPostalCodeCarga As String
    Dim sAddressDetailDescarga As String
    Dim sCityDescarga As String
    Dim sPostalCodeDescarga As String

    Dim xArmzConsignacao As String

    Dim sIdDocCabGT As String
    Dim sIdDocDetGT As String
    Dim sNrAT As String
    Dim sIdDocCabCC As String
    Dim sIdDocDetCC As String











    Private Sub frmSepConsignacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try


            btFiltra_Click(sender, e)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmSepConsignacao_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmSepConsignacao_Load")
        End Try

    End Sub

    Private Sub btFiltra_Click(sender As Object, e As EventArgs) Handles btFiltra.Click

        Dim db As New ClsSqlBDados
        Dim sVertodas As String = "C"

        dsCab.Clear()

        Try

            If cbVerTodas.Checked = True Then
                sVertodas = "%"
            End If

            Sql = "SELECT IdDocCab, DocCab.ArmazemID+ '-'+Armazens.ArmAbrev Loja, DocCab.DocNr Documento, DocCab.DataDoc DataDoc
            FROM  DocCab INNER JOIN
            Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
            Terceiros ON Armazens.TercID = Terceiros.TercID
            WHERE  (Terceiros.TipoTerc = 'C') AND (DocCab.TipoDocID = 'SE')
            and DocCab.ArmazemID+Armazens.ArmAbrev+DocCab.DocNr like '%" & tbFiltro.Text & "%'
            and EstadoDoc like '" & sVertodas & "'
            order by DataDoc desc"

            db.GetData(Sql, dsCab, False)
            If dsCab.Tables(0).Rows.Count = 0 Then Exit Sub
            dgvSepCab.DataSource = dsCab.Tables(0)

            dgvSepCab.Columns("IdDocCab").Visible = False



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btFiltra_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btFiltra_Click")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Private Sub cbVerTodas_CheckedChanged(sender As Object, e As EventArgs) Handles cbVerTodas.CheckedChanged

        Try

            btFiltra_Click(sender, e)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "cbVerTodas_CheckedChanged")
        Catch ex As Exception
            ErroVB(ex.Message, "cbVerTodas_CheckedChanged")
        End Try

    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub

    Private Sub btGerarDocs_Click(sender As Object, e As EventArgs) Handles btGerarDocs.Click

        'Vou Gerar Uma guia de transporte e um Crédito de consignação.....

        Dim db As New ClsSqlBDados
        Dim dtCab As New DataTable

        Try

            If SistemaBloqueado() = True Then
                Exit Sub
            End If

            'vou emitir a Guia de Trasporte:
            If GravarGT() Then
                AtualizarAT()
            Else
                Sql = "DELETE FROM DOCCAB WHERE IdDocCab='" & sIdDocCabGT.ToString & "'"
                db.ExecuteData(Sql)
                MsgBox("ERRO NA CRIAÇÃO DA GUIA DE TRANSPORTE!")
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btGerarDocs_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btGerarDocs_Click")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub


    'Eventos na dgvSepCab
    Private Sub DgvSepCab_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSepCab.SelectionChanged


        Dim db As New ClsSqlBDados
        dsDet.Clear()

        Try


            lbNrAT.Visible = False
            btGerarDocs.Enabled = False

            If dsCab.Tables(0).Rows.Count = 0 Then Exit Sub
            If Me.dgvSepCab.CurrentCell Is Nothing Then Exit Sub


            If Me.dgvSepCab("IdDocCab", Me.dgvSepCab.CurrentCell.RowIndex).Value.ToString Is DBNull.Value Then Exit Sub
            sIdDocCabSep = Me.dgvSepCab("IdDocCab", Me.dgvSepCab.CurrentCell.RowIndex).Value.ToString

            Sql = "SELECT SerieID Talão, ModeloID Modelo, CorID Cor, TamID Tam
                FROM     DocDet
                WHERE  (IdDocCab = '" & sIdDocCabSep & "')
                ORDER BY SerieID"
            db.GetData(Sql, dsDet, False)
            If dsDet.Tables(0).Rows.Count = 0 Then Exit Sub
            dgvSepDet.DataSource = dsDet.Tables(0)

            sTercIDGT = 2000

            Sql = "SELECT Armazens.TercID
                FROM     DocCab INNER JOIN
                Armazens ON DocCab.ArmazemID = Armazens.ArmazemID
                WHERE  (DocCab.IdDocCab = '" & sIdDocCabSep & "')"

            sTercIDCC = db.GetDataValue(Sql)



            Sql = "SELECT ArmazemID FROM DocCab WHERE  (IdDocCab = '" & sIdDocCabSep & "')"
            xArmzConsignacao = db.GetDataValue(Sql)


            lbNrAT.Visible = False



            atualizarAT()



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DgvSepCab_SelectionChanged")
        Catch ex As Exception
            ErroVB(ex.Message, "DgvSepCab_SelectionChanged")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub CarregarInfoCargaDescarga(ByVal sCarga As String, ByVal sDescarga As String)

        Dim db As New ClsSqlBDados
        Dim dtCarga As New DataTable
        Dim dtDescarga As New DataTable

        Try



            Sql = "SELECT Armazens.ArmazemID, Terceiros.Morada, Terceiros.Localidade, Terceiros.CodPostal, Terceiros.PaisID FROM Terceiros INNER JOIN Armazens 
                ON Terceiros.TercID = Armazens.TercID WHERE (Armazens.ArmazemID = '" & sCarga & "')"
            db.GetData(Sql, dtCarga)

            Sql = "SELECT Armazens.ArmazemID, Terceiros.Morada, Terceiros.Localidade, Terceiros.CodPostal, Terceiros.PaisID, Terceiros.TercID FROM Terceiros 
                INNER JOIN Armazens ON Terceiros.TercID = Armazens.TercID WHERE (Armazens.ArmazemID = '" & sDescarga & "')"
            db.GetData(Sql, dtDescarga)


            If dtCarga.Rows.Count > 0 Then
                sAddressDetailCarga = dtCarga.Rows(0)("Morada").ToString
                sCityCarga = dtCarga.Rows(0)("Localidade").ToString
                sPostalCodeCarga = dtCarga.Rows(0)("CodPostal").ToString
            End If

            If dtDescarga.Rows.Count > 0 Then
                sAddressDetailDescarga = dtDescarga.Rows(0)("Morada").ToString
                sCityDescarga = dtDescarga.Rows(0)("Localidade").ToString
                sPostalCodeDescarga = dtDescarga.Rows(0)("CodPostal").ToString
                sTercIDGT = dtDescarga.Rows(0)("TercID").ToString
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarInfoCargaDescarga")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarInfoCargaDescarga")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Private Sub AtualizarAT()

        Dim db As New ClsSqlBDados


        Try

            lbNrAT.Text = ""
            'IR BUSCAR O NUMERO AT....DA GUIA CORRESPONDENTE
            Sql = "SELECT ISNULL(ATDocCodeID,'') FROM DocCab WHERE IdDocCabOrig = '" & sIdDocCabSep & "'"
            sNrAT = db.GetDataValue(Sql)

            If Len(sNrAT) > 0 Then
                btGerarDocs.Enabled = False
                lbNrAT.Text = "Nr. AT: " & sNrAT
                lbNrAT.Visible = True
            Else
                lbNrAT.Visible = False
                btGerarDocs.Enabled = True
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "AtualizarAT")
        Catch ex As Exception
            ErroVB(ex.Message, "AtualizarAT")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Function GravarGT() As Boolean


        Dim db As New ClsSqlBDados

        Try

            Dim dtDet As New DataTable
            Dim xTipoTerc As String = "C"
            Dim xTipoDoc As String = "GT"



            Dim xData As String = Format(CType(Now(), Date), "yyyy-MM-dd H:mm:ss")
            sIdDocCabGT = Guid.NewGuid.ToString
            sIdDocDetGT = Guid.NewGuid.ToString

            Dim strData As New StringBuilder

            Dim sCountryCarga As String = "PT"
            Dim sCountryDescarga As String = "PT"

            xNovoDoc = PesquisaMaxNumDoc(xTipoDoc)
            If xNovoDoc = "" Then Return False

            CarregarInfoCargaDescarga(xArmzConsignacao, "0000")

            Dim sATCUD As String = DevolveATCUD("0000", xTipoDoc, xNovoDoc)

            If Now() >= #01/01/2023# And sATCUD = "0" Then Return False


            Sql = "BEGIN TRANSACTION"
            strData.AppendLine(Sql)

            Sql = "INSERT INTO DocCab (EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, 
                HoraDesc, Obs, Obs1, Obs2, Obs3, DescontoDoc, EstadoDoc, TipoTerc, FormaPagtoID, IdDocCab, IdDocCabOrig, UtilizadorID, OperadorID, SAFT, DtUltAlt, 
                AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, 
                CountryDescarga, MovementEndTime, ATCUD) " &
                "VALUES ('" & xEmp & "', '0000', '" & xTipoDoc & "', N'" & xNovoDoc & "', '" & sTercIDGT & "', CONVERT(DATETIME, '" & xData & "', 102), '', '', '', '0', '',
                '', '', '', '', '0', '0', '0', '0', 'C', N'" & xTipoTerc & "', '0', '" & sIdDocCabGT & "','" & sIdDocCabSep & "', '" & iUtilizadorID & "', '" & xUtilizador & "', 
                '0', CONVERT(DATETIME, '" & xData & "', 102), N'" & sAddressDetailCarga & "', N'" & sCityCarga & "', N'" & sPostalCodeCarga & "', N'" & sCountryCarga & "', 
                CONVERT(DATETIME, '" & xData & "', 102), N'" & sAddressDetailDescarga & "', N'" & sCityDescarga & "', N'" & sPostalCodeDescarga & "', N'" & sCountryDescarga & "', 
                CONVERT(DATETIME, '" & xData & "', 102), '" & sATCUD & "');"

            strData.AppendLine(Sql)

            Dim inLinha As Int16 = 0
            Dim dValor As Double = 0
            Dim dVlrDescLn As Double = 0
            Dim dVlrIVA As Double = 0


            Sql = "SELECT DocDet.ProductCode, Product.ProductDescription, SUM(DocDet.Qtd) AS Qtd, Product.UnitOfMeasure
                FROM     DocDet INNER JOIN
                Product ON DocDet.ProductCode = Product.ProductCode
                WHERE  (DocDet.IdDocCab = '" & sIdDocCabSep & "')
                GROUP BY Product.ProductDescription, Product.UnitOfMeasure, DocDet.ProductCode;"

            db.GetData(Sql, dtDet, False)

            For Each r As DataRow In dtDet.Rows

                inLinha = inLinha + 1

                Sql = "INSERT INTO dbo.DocDet (EmpresaID,ArmazemID,TipoDocID,DocNr,DocLnNr,Descricao,Unidade,Valor,
                IvaID,VlrIVA,TxIva,Qtd,EstadoLn,IdDocCab,IdDocDet,UtilizadorID,ProductCode) 
                VALUES('" & xEmp & "','" & xArmz & "','" & xTipoDoc & "','" & xNovoDoc & "', " & inLinha & ", 
                '" & r("ProductDescription") & "', '" & r("UnitOfMeasure") & "', " & dValor & ", " & 0 & ",  " & 0 & ", " & 0 & "," & r("Qtd") & ", 
                'C','" & sIdDocCabGT & "','" & sIdDocDetGT & "', '" & iUtilizadorID & "', '" & r("ProductCode") & "');"
                strData.AppendLine(Sql)

            Next


            Sql = "COMMIT TRANSACTION;"
            strData.AppendLine(Sql)
            Sql = strData.ToString
            dberrorAtivo = True


            Dim clsGravaDoc As New ClsDocs
            If Not clsGravaDoc.NovoDoc(Sql, sIdDocCabGT, xTipoDoc) Then
                MsgBox("Erro 7501 da criação do documento!!",, "Girl")
                Return False
            Else

                Dim dtAuxSeparacao As New DataTable
                Sql = "SELECT DocDet.EmpresaID, DocDet.ArmazemID, DocDet.TipoDocID, DocDet.DocNr, DocDet.DocLnNr, DocDet.SerieID, Serie.ProductCode AS Artigo, DocDet.ModeloID, DocDet.CorID, DocDet.TamID, ISNULL(RTRIM(LTRIM(Serie.Obs)), '') + ' ' + ISNULL(RTRIM(LTRIM(Serie.Obs1)), '') AS Obs FROM DocDet LEFT OUTER JOIN Serie ON DocDet.SerieID = Serie.SerieID WHERE (DocDet.IdDocCab = '" & sIdDocCabSep & "') ORDER BY DocDet.SerieID"
                db.GetData(Sql, dtAuxSeparacao)
                'VOU FAZER AQUI O ENVIO PARA O ARMAZEM
                For Each r As DataRow In dtAuxSeparacao.Rows
                    'ACTUALIZA ESTADO DO TALÃO NA TABELA SERIE
                    Sql = "UPDATE Serie SET EstadoID = 'T' WHERE SerieID = '" & r("SerieID") & "' AND EstadoID = 'S' AND ArmazemID = '" & r("ArmazemID") & "'"
                    db.ExecuteData(Sql)
                Next

                Sql = "Update DocCab SET EstadoDoc = 'G',DataDoc = '" & Format(Now(), "yyyy-MM-dd H:mm:ss") & "' WHERE IdDocCab = '" & sIdDocCabSep & "' AND EstadoDoc = 'C'"
                db.ExecuteData(Sql)


                Return True


            End If







        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravarGT")
        Catch ex As Exception
            ErroVB(ex.Message, "GravarGT")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function








End Class