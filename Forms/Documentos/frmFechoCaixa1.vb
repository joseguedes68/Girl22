Imports System.Data.SqlClient


Public Class frmFechoCaixa



    'O FECHO VAI VAI FICAR AO NIVEL DO ARMAZEM!!

    Friend sIdDocCabFechoAux As String
    Dim dtFechos As New DataTable
    Dim dtLojas As New DataTable
    Dim xFiltraEstado As String = "= 'C'"


    Private Sub frmFechoCaixa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim db As New ClsSqlBDados
        dtFechos.Clear()

        Try

            'PREENCHER COMBOBOX ARMAZEM
            Sql = "SELECT ArmazemID, rtrim(ArmazemID) + ' - ' + rtrim(ArmAbrev) as Lojas from Armazens where Activo='True'"
            db.GetData(Sql, dtLojas)
            dtLojas.Rows.Add("%", "Todas as Lojas")
            Me.cbLojas.DataSource = dtLojas
            Me.cbLojas.DisplayMember = "Lojas"
            Me.cbLojas.ValueMember = "ArmazemID"
            Me.cbLojas.SelectedValue = "%"

            If SistemaBloqueado() = True Then
                Exit Sub
            End If

            If xAplicacao = "BACKOFFICE" Then
                btDetalhe.Visible = True
                btValidar.Visible = True
                dpDeData.Visible = True
                dpAteData.Visible = True
                btAtualizar.Visible = True
                btFecharCaixa.Visible = False
                Me.cbLojas.SelectedValue = "%"
            Else
                btDetalhe.Visible = False
                btValidar.Visible = False
                dpDeData.Visible = False
                dpAteData.Visible = False
                btAtualizar.Visible = False
                btFecharCaixa.Visible = True
                Me.cbLojas.SelectedValue = xArmz
                cbLojas.Enabled = False
            End If

            Sql = "SELECT DocCab.DataDoc AS Data, DocCab.ArmazemID Loja, DocCab.DocNr AS Fecho, DocCab.Obs2 AS Multibanco, DocCab.Obs3 AS Dinheiro, ISNULL(DocCab.Obs2, 0) + ISNULL(DocCab.Obs3, 0) AS Total, DocCab.DescontoDoc AS Comissão, DocCab.Obs1 AS ObsLoja, DocCab.IdDocCab, Utilizadores.NomeUtilizador AS Utilizador FROM DocCab LEFT OUTER JOIN Utilizadores ON DocCab.UtilizadorID = Utilizadores.UtilizadorID WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.EstadoDoc " & xFiltraEstado & ") ORDER BY Data DESC"
            db.GetData(Sql, dtFechos)

            dpDeData.Value = Today.AddDays(-40)

            dgvFechosCaixa.DataSource = dtFechos

            dgvFechosCaixa.Columns("Data").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvFechosCaixa.Columns("Data").DefaultCellStyle.Format = "g"
            dgvFechosCaixa.Columns("Data").Width = 75
            dgvFechosCaixa.Columns("Data").ReadOnly = True

            dgvFechosCaixa.Columns("Fecho").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvFechosCaixa.Columns("Fecho").Width = 70
            dgvFechosCaixa.Columns("Fecho").ReadOnly = True

            dgvFechosCaixa.Columns("Multibanco").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFechosCaixa.Columns("Multibanco").DefaultCellStyle.Format = "C2"
            dgvFechosCaixa.Columns("Multibanco").Width = 90
            dgvFechosCaixa.Columns("Multibanco").ReadOnly = True

            dgvFechosCaixa.Columns("Dinheiro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFechosCaixa.Columns("Dinheiro").DefaultCellStyle.Format = "C2"
            dgvFechosCaixa.Columns("Dinheiro").Width = 90
            dgvFechosCaixa.Columns("Dinheiro").ReadOnly = True

            dgvFechosCaixa.Columns("Comissão").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFechosCaixa.Columns("Comissão").DefaultCellStyle.Format = "C2"
            dgvFechosCaixa.Columns("Comissão").Width = 90
            dgvFechosCaixa.Columns("Comissão").ReadOnly = True

            dgvFechosCaixa.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFechosCaixa.Columns("Total").DefaultCellStyle.Format = "C2"
            dgvFechosCaixa.Columns("Total").Width = 90
            dgvFechosCaixa.Columns("Total").ReadOnly = True

            dgvFechosCaixa.Columns("ObsLoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvFechosCaixa.Columns("ObsLoja").Width = 200

            dgvFechosCaixa.Columns("Utilizador").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvFechosCaixa.Columns("Utilizador").Width = 120
            dgvFechosCaixa.Columns("Utilizador").ReadOnly = True

            dgvFechosCaixa.Columns("IdDocCab").Visible = False


            If xAplicacao = "POS" Then
                dgvFechosCaixa.Columns("Comissão").Visible = False
            End If

            If dtFechos.DefaultView.Count > 0 Then dgvFechosCaixa.Rows(0).Selected = True


            btAtualizar_Click(sender, e)


        Catch ex As Exception
            ErroVB(ex.Message, "frmFechoCaixa_Load")
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click

        Dim db As New ClsSqlBDados
        frmRpt = New frmReport

        Try


            Sql = "SELECT DocCab.DocNr, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpContrib, DocCab.DataDoc, DocCab.Obs2 AS Multibanco, DocCab.Obs3 AS Dinheiro, Terceiros.NomeAbrev AS LNome, Terceiros.Morada AS LMorada, Terceiros.CodPostal AS LCodPostal, Terceiros.Localidade AS LLocalidade, Terceiros.Telefone AS LTelefone, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade FROM DocCab INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN TipoDoc ON DocCab.TipoDocID = TipoDoc.TipoDocID INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (DocCab.IdDocCab = '" & Me.dgvFechosCaixa("IdDocCab", Me.dgvFechosCaixa.CurrentCell.RowIndex).Value.ToString & "')"
            db.ExecuteData(Sql)

            frmRpt.C1Report1.Load(xRptPath & "DocFechoCaixa.xml", "DocFechoCaixa")
            frmRpt.C1Report1.DataSource.ConnectionString = sconnectionstringReport
            frmRpt.C1Report1.DataSource.RecordSource = Sql
            JustPrint(frmRpt.C1Report1)



        Catch ex As Exception
            ErroVB(ex.Message, "btImprimir_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Close()
    End Sub

    Private Sub btValidar_Click(sender As System.Object, e As System.EventArgs) Handles btValidar.Click

        Dim db As New ClsSqlBDados
        Dim sIdDocCabFecho As String
        Dim dtCab As New DataTable
        Dim dtDet As New DataTable
        Dim strData As New System.Text.StringBuilder



        Try

            If ArmazemConsignacao(Me.dgvFechosCaixa("Loja", Me.dgvFechosCaixa.CurrentCell.RowIndex).Value.ToString) Then

                'GERAR A FATURA COM BASE NOS ELEMENTOS DO FECHO DE CONSIGNAÇÃO

                sIdDocCabFecho = Me.dgvFechosCaixa("IdDocCab", Me.dgvFechosCaixa.CurrentCell.RowIndex).Value.ToString


                Sql = "SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, Obs1, Obs2, Obs3, DescontoDoc, EstadoDoc, TipoTerc, NIFTerc, FormaPagtoID, 
                    IdDocCab, IdDocCabOrig, UtilizadorID, OperadorID, DtRegisto, SAFT, DtUltAlt, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, 
                    CountryDescarga, MovementEndTime, ATDocCodeID, Hash, Hash4d, ChaveAssinar, ChavePrivadaVersao, SerieDoc, NrDoc, DocOrig, IDTerceiro, ObsPag, ObsOrigem, QrCodeValor, QrCode
                    FROM     DocCab
                    WHERE  (IdDocCab = '" & sIdDocCabFecho & "')"
                db.GetData(Sql, dtCab)


                Sql = "SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, VlrIVA, TxIva, Qtd, FormaPagtoID, Comissao, Obs, EstadoLn, IdDocCab, 
                    IdDocDet, IdDocDetOrig, UtilizadorID, ProductCode, OperadorID, DtRegisto
                    FROM     DocDet
                    WHERE  (IdDocCab = '" & sIdDocCabFecho & "')"
                db.GetData(Sql, dtDet)

                Dim sTerceiro As String = DevolveTerceiro(Me.dgvFechosCaixa("Loja", Me.dgvFechosCaixa.CurrentCell.RowIndex).Value.ToString)






                Dim xData As String = Format(CType(Now(), Date), "yyyy-MM-dd H:mm:ss")
                'sIdDocDet = Guid.NewGuid.ToString



                Sql = "BEGIN TRANSACTION"
                strData.AppendLine(Sql)

                'Sql = "INSERT INTO DocCab (EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, 
                '    EstadoDoc, TipoTerc, NIFTerc, FormaPagtoID, IdDocCab,  UtilizadorID, OperadorID, SAFT, DtUltAlt, IDTerceiro)
                '    VALUES ('0001', '0000', 'FT', N'" & PesquisaMaxNumDoc("FT") & "', '" & sTerceiro & "', CONVERT(DATETIME, '" & xData & "', 102), 
                '    'C','C', '" & tbNIF.Text & "', '0', '" & Guid.NewGuid.ToString & "', 
                '    '" & iUtilizadorID & "', '" & xUtilizador & "', '0', GETDATE(), '" & GuidDestino & "')" CONVERT(DATETIME, '" & xData & "', 102), '', '', '', '0', '', '', '', '', '', '0', '0', '0', '0', 'C', N'C', '" & tbNIF.Text & "', '0', '" & Guid.NewGuid.ToString & "', " & sIdDocCabOrig & ",'" & sDocOrigem & "', '" & iUtilizadorID & "', '" & xUtilizador & "', '0', GETDATE(), N'', N'" & tbCityCarga.Text & "', N'" & tbPostalCodeCarga.Text & "', N'" & sCountryCarga & "', CONVERT(DATETIME, '" & dpMovementStartTime.Text & "', 102), N'" & tbAddressDetailDescarga.Text & "', N'" & tbCityDescarga.Text & "', N'" & tbPostalCodeDescarga.Text & "', N'" & sCountryDescarga & "', CONVERT(DATETIME, '" & dpMovementStartTime.Text & "', 102), '" & GuidDestino & "');"


                strData.AppendLine(Sql)


                'Dim inLinha As Int16 = 0
                'Dim dValor As Double = 0
                'Dim dVlrDescLn As Double = 0
                'Dim dVlrIVA As Double = 0
                'Dim dTxIva As Double = 0

                'For Each r As DataRow In GirlDataSet.DocDetAux.Rows

                '    dTxIva = DevolveIva(r("IvaId"))
                '    dValor = r("PrUniLiq") * (1 + dTxIva)
                '    dVlrDescLn = r("VlrDescLiq") * (1 + dTxIva)
                '    dVlrIVA = (r("PrUniLiq") - r("VlrDescLiq")) * dTxIva
                '    inLinha = inLinha + 1

                '    If xTipoDoc = "GT" Or xTipoDoc = "GC" Then
                '        dValor = 0
                '        dVlrDescLn = 0
                '        dVlrIVA = 0
                '    End If


                '    If r("Qtd").ToString < "1" Then
                '        sMsgErro = "Quantidade menor que 1 na linha :" & inLinha
                '        Return False
                '    End If

                '    Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, ModeloID, CorID, Descricao, Unidade, Valor, VlrDescLn, IvaID, VlrIVA, TxIva, Qtd, EstadoLn, IDDocCab, ProductCode, OperadorID) " &
                '        "VALUES ('" & xEmp & "','" & sOrigemID & "','" & xTipoDoc & "','" & xNovoDoc & "', " & inLinha & ", '" & r("ModeloID") & "', '" & r("CorID") & "', '" & Trim(r("Descricao")) & "', '" & r("Unidade") & "', " & dValor & ", " & dVlrDescLn & ", '" & r("IvaID") & "', " & dVlrIVA & ",  " & dTxIva & ", " & r("Qtd") & ", 'C','" & sIdDocCab & "', '" & r("Artigo") & "', '" & xUtilizador & "');"
                '    strData.AppendLine(Sql)



                'Next

                'Sql = "COMMIT TRANSACTION;"
                'strData.AppendLine(Sql)
                'Sql = strData.ToString
                'dberrorAtivo = True
                'db.ExecuteData(Sql)


















            Else
                Sql = "UPDATE DocCab SET EstadoDoc = 'V' WHERE IdDocCab = '" & Me.dgvFechosCaixa("IdDocCab", Me.dgvFechosCaixa.CurrentCell.RowIndex).Value.ToString & "'"
                db.ExecuteData(Sql)
                btAtualizar_Click(sender, e)
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btValidar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btValidar_Click")
        Finally
            dtCab = Nothing
            dtDet = Nothing
        End Try



    End Sub

    Private Sub btFecharCaixa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFecharCaixa.Click
        Try


            If bLojaConsignacao = True Then
                FecharCaixaConsignacao()
            Else
                FecharCaixa()
            End If
            btAtualizar_Click(sender, e)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btDetalhe_Click(sender As System.Object, e As System.EventArgs) Handles btDetalhe.Click

        Dim db As New ClsSqlBDados


        Try

            sIdDocCabFechoAux = Me.dgvFechosCaixa("IdDocCab", Me.dgvFechosCaixa.CurrentCell.RowIndex).Value.ToString
            frmFechoCaixaDet.WindowState = FormWindowState.Normal
            frmFechoCaixaDet.StartPosition = FormStartPosition.CenterScreen
            frmFechoCaixaDet.ShowDialog(Me)
            frmFechoCaixaDet.Dispose()


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btDetalhe_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btDetalhe_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub btAtualizar_Click(sender As System.Object, e As System.EventArgs) Handles btAtualizar.Click

        Dim db As New ClsSqlBDados
        dtFechos.Clear()
        Me.Cursor = Cursors.WaitCursor
        Dim dtUtil As New DataTable

        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query


            If xAplicacao = "BACKOFFICE" Then
                Sql = "SELECT DocCab.DataDoc AS Data, DocCab.ArmazemID Loja, DocCab.DocNr AS Fecho, DocCab.Obs2 AS Multibanco, DocCab.Obs3 AS Dinheiro, ISNULL(DocCab.Obs2, 0) + ISNULL(DocCab.Obs3, 0) AS Total, DocCab.DescontoDoc AS Comissão, DocCab.Obs1 AS ObsLoja, DocCab.IdDocCab, Utilizadores.NomeUtilizador AS Utilizador FROM DocCab LEFT OUTER JOIN Utilizadores ON DocCab.UtilizadorID = Utilizadores.UtilizadorID WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102) AND DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102) AND (DocCab.EstadoDoc " & xFiltraEstado & ") ORDER BY Data DESC"
            Else
                Sql = "SELECT DocCab.DataDoc AS Data, DocCab.ArmazemID Loja, DocCab.DocNr AS Fecho, DocCab.Obs2 AS Multibanco, DocCab.Obs3 AS Dinheiro, ISNULL(DocCab.Obs2, 0) + ISNULL(DocCab.Obs3, 0) AS Total, DocCab.DescontoDoc AS Comissão, DocCab.Obs1 AS ObsLoja, DocCab.IdDocCab, Utilizadores.NomeUtilizador AS Utilizador FROM DocCab LEFT OUTER JOIN Utilizadores ON DocCab.UtilizadorID = Utilizadores.UtilizadorID WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.EstadoDoc " & xFiltraEstado & ") ORDER BY Data DESC"
            End If
            db.GetData(Sql, dtFechos)
            dgvFechosCaixa.DataSource = dtFechos

            If dtFechos.Rows.Count > 0 And cbLojas.SelectedValue.ToString <> "%" Then
                Dim TMB As String = dtFechos.Compute("sum(Multibanco)", "").ToString
                Dim TVD As String = dtFechos.Compute("sum(Dinheiro)", "").ToString
                Dim TT As String = dtFechos.Compute("sum(Total)", "").ToString
                Dim TC As String = dtFechos.Compute("sum(Comissão)", "").ToString
                If TMB = "" Then TMB = "0"
                If TVD = "" Then TVD = "0"
                If TT = "" Then TT = "0"
                If TC = "" Then TC = "0"

                dtFechos.Rows.Add(DBNull.Value, "", "TOTAIS", TMB, TVD, TT, TC, "", DBNull.Value, DBNull.Value)
                dgvFechosCaixa.Rows(dgvFechosCaixa.RowCount - 1).DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

                If xGrupoAcesso = "ADMIN" Then

                    Sql = "SELECT Utilizadores.NomeUtilizador, ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd), 0) AS VndValor, ISNULL(SUM(DocDet.Comissao * (DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd), 0) AS Comissao FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab INNER JOIN Utilizadores ON DocDet.UtilizadorID = Utilizadores.UtilizadorID WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.ArmazemID = '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) GROUP BY Utilizadores.NomeUtilizador"
                    db.GetData(Sql, dtUtil)

                    For Each r As DataRow In dtUtil.Rows
                        dtFechos.Rows.Add(DBNull.Value, "", "", DBNull.Value, DBNull.Value, r("VndValor"), r("Comissao"), "", DBNull.Value, r("NomeUtilizador"))
                        dgvFechosCaixa.Rows(dgvFechosCaixa.RowCount - 1).DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)
                    Next

                End If

            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btAtualizar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btAtualizar_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub cbVerTodas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodas.CheckedChanged
        If cbVerTodas.Checked = True Then
            xFiltraEstado = "LIKE '%'"
            btValidar.Enabled = False
        Else
            xFiltraEstado = "= 'C'"
            If xAplicacao = "BACKOFFICE" Then btValidar.Enabled = True
        End If
        btAtualizar_Click(sender, e)
    End Sub

    'EVENTOS NA dgvFechosCaixa

    Private Sub dgvFechosCaixa_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFechosCaixa.CellEndEdit
        Try



            GravarObsRecolhas(Me.dgvFechosCaixa("IdDocCab", Me.dgvFechosCaixa.CurrentCell.RowIndex).Value.ToString, Me.dgvFechosCaixa("ObsLoja", Me.dgvFechosCaixa.CurrentCell.RowIndex).Value.ToString)


        Catch ex As Exception

        End Try

    End Sub

    'Private Sub dgvFechosCaixa_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvFechosCaixa.CellMouseClick
    '    Dim dg_FechosCaixa As New clsDataGrid(Me.dgvFechosCaixa, dtFechos.DefaultView)
    '    Try
    '        If e.Button = Windows.Forms.MouseButtons.Right Then
    '            dg_FechosCaixa.MostraFiltroForm(e)
    '        End If

    '    Catch ex As Exception
    '        ErroVB(ex.Message, Me.Name + ": dgvFechosCaixa_CellMouseClick")
    '    Finally
    '        dg_FechosCaixa.Dispose()
    '        dg_FechosCaixa = Nothing
    '    End Try
    'End Sub

    Private Sub dgvFechosCaixa_SelectionChanged(sender As Object, e As EventArgs) Handles dgvFechosCaixa.SelectionChanged

        Dim DB As New ClsSqlBDados


        Try

            If ArmazemConsignacao(Me.dgvFechosCaixa("Loja", Me.dgvFechosCaixa.CurrentCell.RowIndex).Value.ToString) Then
                btValidar.Text = "Faturar"
            Else
                btValidar.Text = "Validar"
            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub FecharCaixa()




        If SistemaBloqueado() = True Then
            Exit Sub
        End If


        Dim db As New ClsSqlBDados
        Dim dVendasDinheiro As Double = 0
        Dim dVendasConsignacao As Double = 0
        Dim dVendasMB As Double = 0
        Dim dTotalComissao As Double = 0
        Dim dTVnd As Double = 0
        Dim maxDocnr As String
        Dim xData As String = Format(CType(Now, Date), "yyyy-MM-dd H:mm:ss")
        Dim gIdDocCabFX As Guid = Guid.NewGuid
        Dim gIdDocDetFX As Guid
        Dim dtdetAux As New DataTable


        Try


            'TODO: SE FIZERMOS FT PARA EMPRESAS ISTO TEM QUE SER ALTERADO 
            Sql = "SELECT ISNULL(SUM(((CASE WHEN DOCDET.TIPODOCID IN ('NC','DC') THEN - 1 ELSE 1 END) * DocDet.Qtd) * (DocDet.Valor - DocDet.VlrDescLn)), 0) AS Valor FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.EstadoDoc = 'C') AND (DocCab.FormaPagtoID = 1) AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID IN ('FS', 'NC', 'DC', 'FT','VC'))"
            dVendasDinheiro = db.GetDataValue(Sql)

            Sql = "SELECT ISNULL(SUM(((CASE WHEN DOCDET.TIPODOCID IN ('NC','DC') THEN - 1 ELSE 1 END) * DocDet.Qtd) * (DocDet.Valor - DocDet.VlrDescLn)),0) AS Valor FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.EstadoDoc = 'C') AND (DocCab.FormaPagtoID = 6) AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID IN ('FS','NC', 'DC', 'FT','VC'))"
            dVendasMB = db.GetDataValue(Sql)

            Sql = "SELECT ISNULL(SUM(DocDet.Comissao * (DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd * (CASE WHEN DOCDET.TIPODOCID IN ('NC','DC') THEN - 1 ELSE 1 END)), 0) AS VDC FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.EstadoDoc = 'C') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID IN ('FS','NC','DC','FT','VC')) AND (DocCab.EmpresaID = '" & xEmp & "')"
            dTotalComissao = db.GetDataValue(Sql)

            'VALIDAR VALORES NA TABELA SERIE!!
            Sql = "SELECT isnull(SUM(PVndReal),0) AS Vendas FROM Serie WHERE (ArmazemID = '" & xArmz & "') AND (EstadoID = 'V')"
            dTVnd = dVendasDinheiro + dVendasMB
            If dTVnd <> db.GetDataValue(Sql) Then
                'MsgBox("ERRO 152! NÃO É POSSIVEL FAZER O FECHO")
                'Me.Cursor = Cursors.Default
                'EnviarEmail("Erro","ERRO 152 NA LOJA " & xArmz)
                'Exit Sub
            End If

            Sql = "SELECT ISNULL(SUM(Comissao * PVndReal),0) AS Comissao FROM Serie WHERE (ArmazemID = '" & xArmz & "') AND (EstadoID = 'V')"
            If dTotalComissao <> db.GetDataValue(Sql) Then
                'MsgBox("ERRO 153! NÃO É POSSIVEL FAZER O FECHO")
                'Me.Cursor = Cursors.Default
                'EnviarEmail("Erro","ERRO 153 NA LOJA " & xArmz)
                'Exit Sub
            End If


            If MsgBox("Confirma o fecho com os Valores:" & Chr(13) & Chr(13) & " MB: " & FormatCurrency(dVendasMB) & "    Dinheiro: " & FormatCurrency(dVendasDinheiro), MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Fecho de Caixa") = MsgBoxResult.Yes Then

                Me.Cursor = Cursors.WaitCursor


                maxDocnr = PesquisaMaxNumDoc("FX")

                'TODO : SE ESTIVER ALGUEM A FAZER VENDAS PARA A MESMA LOJA NESTE MOMENTO, PODE DAR PROBLEMAS - SUGESTÃO BLOQUEAR VENDAS!!
                Sql = "INSERT into DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr,  DataDoc, Obs2, Obs3, DescontoDoc, EstadoDoc, IdDocCab, UtilizadorID, OperadorID) " &
               "VALUES ('" & xEmp & "', '" & xArmz & "', 'FX', '" & maxDocnr & "', '" & xData & "', '" & dVendasMB & "','" & dVendasDinheiro & "','" & dTotalComissao & "', 'C', '" & gIdDocCabFX.ToString & "', '" & iUtilizadorID & "', '" & xUtilizador & "')"
                db.ExecuteData(Sql)

                'Sql = "SELECT DocDet.SerieID, DocDet.Valor - DocDet.VlrDescLn AS VndValor, DocDet.VlrIVA, DocDet.Comissao, DocDet.Qtd * (CASE WHEN DOCDET.TIPODOCID = 'NC' THEN - 1 ELSE 1 END) Qtd, DocCab.FormaPagtoID, DocCab.UtilizadorID AS Vendedor FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab WHERE (DocCab.EstadoDoc = 'C') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID IN ('FS','NC')) "
                'Sql = "SELECT DocDet.SerieID, DocDet.Valor - DocDet.VlrDescLn AS VndValor, DocDet.VlrIVA, DocDet.Comissao, DocDet.Qtd * (CASE WHEN DOCDET.TIPODOCID = 'NC' THEN - 1 ELSE 1 END) AS Qtd, DocCab.FormaPagtoID, DocCab.UtilizadorID AS Vendedor, DocDet.ModeloID, DocDet.CorID FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab WHERE (DocCab.EstadoDoc = 'C') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID IN ('FS', 'NC', 'FT','VC'))"

                'Sql = "SELECT SerieID AS Serie, PVndReal AS VndValor, 99 AS VlrIVA, Comissao, 1 AS Qtd, 1 AS FormaPagtoID, Vendedor, ModeloID, CorID, ProductCode
                '        FROM   Serie  WHERE (ArmazemID = '0101') AND (EstadoID = 'V')"


                Sql = "SELECT DocDet.SerieID, DocDet.Valor - DocDet.VlrDescLn AS VndValor, DocDet.VlrIVA, DocDet.Comissao, 
                    DocDet.Qtd * (CASE WHEN DOCDET.TIPODOCID = 'NC' THEN - 1 ELSE 1 END) AS Qtd, DocCab.FormaPagtoID, 
                    DocCab.UtilizadorID AS Vendedor, DocDet.ModeloID, DocDet.CorID, 
                    DocDet.ProductCode FROM   DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab
                    WHERE (DocCab.EstadoDoc = 'C') AND (DocCab.EmpresaID = '" & xEmp & "') 
                    AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID IN ('FS', 'NC', 'FT', 'VC'))"
                db.GetData(Sql, dtdetAux)


                If dtdetAux.Rows.Count > 0 Then

                    Dim xDocLnNr As Integer = 1
                    For Each r As DataRow In dtdetAux.Rows

                        gIdDocDetFX = Guid.NewGuid
                        Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, Valor, PercDescLn, Comissao, VlrIVA, Qtd, EstadoLn, IDDocCab, IDDocDet, OperadorID, FormaPagtoID, ModeloID, CorID, UtilizadorID, ProductCode) " &
                                "VALUES ('" & xEmp & "', '" & xArmz & "', 'FX', '" & maxDocnr & "', " & xDocLnNr & ", '" & r("SerieID") & "', '" & r("VndValor") & "', '0','" & r("Comissao") & "',  '" & r("VlrIVA") & "', '" & r("Qtd") & "', 'G','" & gIdDocCabFX.ToString & "','" & gIdDocDetFX.ToString & "', '" & xUtilizador & "', '" & r("FormaPagtoID") & "', '" & r("ModeloID") & "','" & r("CorID") & "','" & r("Vendedor") & "','" & r("ProductCode") & "')"
                        db.ExecuteData(Sql)
                        xDocLnNr = xDocLnNr + 1

                    Next

                End If


                Sql = "UPDATE DocCab SET EstadoDoc = 'F' WHERE (EstadoDoc = 'C') AND (EmpresaID = '" & xEmp & "') AND (ArmazemID = '" & xArmz & "') AND (TipoDocID IN ('FS','NC', 'DC', 'FT','VC'))"
                db.ExecuteData(Sql)

                'btAtualizar_Click(sender, e)
                FecharEtiquetas(maxDocnr, gIdDocCabFX.ToString)

            End If


            Application.DoEvents()
            Me.Cursor = Cursors.Default


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btFecharCaixa_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btFecharCaixa_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try



    End Sub

    Private Sub FecharCaixaConsignacao()




        If SistemaBloqueado() = True Then
            Exit Sub
        End If


        Dim db As New ClsSqlBDados
        Dim dVendasDinheiro As Double = 0
        Dim dVendasConsignacao As Double = 0
        Dim dVendasMB As Double = 0
        Dim dTotalComissao As Double = 0
        Dim dTVnd As Double = 0
        Dim maxDocnr As String
        Dim xData As String = Format(CType(Now, Date), "yyyy-MM-dd H:mm:ss")
        Dim gIdDocCabFX As Guid = Guid.NewGuid
        Dim gIdDocDetFX As Guid
        Dim dtdetAux As New DataTable
        Dim xVlrIvaAux As Double
        Dim dtfxdetAux As New DataTable




        Try


            Sql = "SELECT isnull(SUM(PVndReal),0) AS Vendas FROM Serie WHERE (ArmazemID = '" & xArmz & "') AND (EstadoID = 'V')"
            dVendasDinheiro = db.GetDataValue(Sql)

            Sql = "SELECT ISNULL(SUM(Comissao * PVndReal),0) AS Comissao FROM Serie WHERE (ArmazemID = '" & xArmz & "') AND (EstadoID = 'V')"
            dTotalComissao = db.GetDataValue(Sql)


            If MsgBox("Confirma o fecho com os Valores:" & Chr(13) & Chr(13) & "           Dinheiro: " & FormatCurrency(dVendasDinheiro), MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Fecho de Caixa") = MsgBoxResult.Yes Then

                Me.Cursor = Cursors.WaitCursor
                maxDocnr = PesquisaMaxNumDoc("FX")

                'TODO : SE ESTIVER ALGUEM A FAZER VENDAS PARA A MESMA LOJA NESTE MOMENTO, PODE DAR PROBLEMAS - SUGESTÃO BLOQUEAR VENDAS!!
                Sql = "INSERT into DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr,  DataDoc, Obs2, Obs3, DescontoDoc, EstadoDoc, IdDocCab, UtilizadorID, OperadorID) " &
               "VALUES ('" & xEmp & "', '" & xArmz & "', 'FX', '" & maxDocnr & "', '" & xData & "', '" & dVendasMB & "','" & dVendasDinheiro & "','" & dTotalComissao & "', 'C', '" & gIdDocCabFX.ToString & "', '" & iUtilizadorID & "', '" & xUtilizador & "')"
                db.ExecuteData(Sql)

                Sql = "SELECT Serie.SerieID, Serie.PVndReal AS VndValor, Serie.Comissao, 1 AS Qtd, 1 AS FormaPagtoID, Serie.Vendedor, Serie.ModeloID, Serie.CorID, Serie.ProductCode, Unidades.UnidDescr
                        FROM   Serie INNER JOIN
                        Modelos ON Serie.ModeloID = Modelos.ModeloID INNER JOIN
                        Unidades ON Modelos.UnidID = Unidades.UnidID
                        WHERE (Serie.ArmazemID = '" & xArmz & "') AND (Serie.EstadoID = 'V')"

                db.GetData(Sql, dtdetAux)


                If dtdetAux.Rows.Count > 0 Then

                    Dim xDocLnNr As Integer = 1
                    For Each r As DataRow In dtdetAux.Rows

                        xVlrIvaAux = r("VndValor") * DevolveIva(DevolveIvaId(xArmz)) / (1 + DevolveIva(DevolveIvaId(xArmz)))

                        gIdDocDetFX = Guid.NewGuid
                        Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, Valor, PercDescLn, Comissao, VlrIVA, Qtd, EstadoLn, IDDocCab, IDDocDet, OperadorID, FormaPagtoID, ModeloID, CorID, UtilizadorID, ProductCode, IvaId, TxIva, Unidade) " &
                                "VALUES ('" & xEmp & "', '" & xArmz & "', 'FX', '" & maxDocnr & "', " & xDocLnNr & ", '" & r("Serieid") & "', '" & r("VndValor") & "', '0','" & r("Comissao") & "',  '" & xVlrIvaAux & "', '" & r("Qtd") & "', 'G','" & gIdDocCabFX.ToString & "','" & gIdDocDetFX.ToString & "', '" & xUtilizador & "', '" & r("FormaPagtoID") & "', '" & r("ModeloID") & "','" & r("CorID") & "','" & r("Vendedor") & "', '" & r("ProductCode") & "', '" & DevolveIvaId(xArmz) & "', '" & DevolveIva(DevolveIvaId(xArmz)) & "', '" & r("UnidDescr") & "')"
                        db.ExecuteData(Sql)
                        xDocLnNr = xDocLnNr + 1

                    Next

                End If

                'AQUI VOU FECHAR OS TALÕES EM ESTADO V QUE ESTÃO NA SEPARAÇÃO
                Sql = "SELECT SerieID FROM DocDet WHERE IdDocCab = '" & gIdDocCabFX.ToString & "'"
                db.GetData(Sql, dtfxdetAux)

                For Each r As DataRow In dtfxdetAux.Rows
                    Sql = "UPDATE Serie SET EstadoID = 'R' WHERE SerieID='" & r("SerieID") & "' AND EstadoID='V'"
                    db.ExecuteData(Sql)
                Next

            End If


            Application.DoEvents()
            Me.Cursor = Cursors.Default


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btFecharCaixa_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btFecharCaixa_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try



    End Sub


End Class