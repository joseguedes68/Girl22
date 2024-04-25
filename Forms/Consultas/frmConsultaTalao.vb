
Imports System.Data.SqlClient
Imports C1.Win.C1TrueDBGrid

Public Class frmConsultaTalao

    Dim dtConsultaTalao As New DataTable
    Dim Foto As New ClsFotos
    Dim xModeloCor As String = ""
    Dim xFiltro As String
    Dim sQuery As String = ""
    Dim xSerie As String = ""
    Dim xObs As String = ""
    Dim sLinha As Integer
    Dim xCargaIni As Boolean = True
    Dim xFiltraTaloes As String
    Dim xArmzAux As String
    Dim dComissaoAux As Double
    Dim lblForn As New Label

    Dim WithEvents Dgrid As New DataGridView



    Private Sub frmConsultaTalao_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim val As New clsValidacoes(Me.Name)

        Try

            If xGrupoAcesso = "ADMIN" Then
                btDetTalao.Visible = True
                btAnular.Visible = True
                btDev.Visible = False
                cbVerTodas.Visible = True
                C1DbNavigator.Visible = True
                btValor.Visible = True

            Else
                btDetTalao.Visible = False
                btAnular.Visible = False
                btDev.Visible = False
                cbVerTodas.Visible = False
                C1DbNavigator.Visible = True
                btValor.Visible = False
                btForn.Visible = False

            End If

            Me.Cursor = Cursors.WaitCursor
            'HELDER - QUE COISA ESTRANHA
            cbVerTodas.Checked = False
            xCargaIni = True


            If xArmz = "0000" Then
                xArmzAux = "%"
            Else
                xArmzAux = xArmz
            End If

            'cbVerTodas.CheckState = CheckState.Unchecked

            'C1TDBGCTaloes.AllowUpdate = val.ValidarPermicoes("C1TDBGCTaloes")
            'C1TDBGCTaloes.Enabled = True
            If xAplicacao = "POS" And xGrupoAcesso <> "ADMIN" Then
                C1TDBGCTaloes.AllowUpdate = False

            End If


            'If xAplicacao = "POS" Then C1TDBGCTaloes.Enabled = False


            CarregarDados()
            cbReport.SelectedItem = "RptTaloes_3x2"
            tbFiltraTalao.TextAlign = HorizontalAlignment.Center

            With C1TDBGCTaloes
                .MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                .Columns("PrTalão").NumberFormat = "Currency"
                .Columns("PrVnd").NumberFormat = "Currency"
                .Columns("PrVndReal").NumberFormat = "Currency"
                .Columns("DtUltMov").NumberFormat = "Short Date"
            End With

            Dim xLarguraGrid As VariantType
            For Each Coluna As C1DisplayColumn In Me.C1TDBGCTaloes.Splits(0).DisplayColumns
                Coluna.Style.Font = New Font("Arial", 9, FontStyle.Regular)
                Coluna.HeadingStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                Coluna.HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                Coluna.Style.HorizontalAlignment = AlignHorzEnum.Center
                Coluna.AutoSize()
                Dim xLargColuna As Int16 = Coluna.Width
                xLarguraGrid += xLargColuna
                Coluna.Locked = True
            Next
            '
            With C1TDBGCTaloes
                With .Splits(0)
                    Dim xAuxLarguraGrid As Int16 = .DisplayColumns("Talão").Width + .DisplayColumns("Descrição").Width + .DisplayColumns("Obs").Width + .DisplayColumns("Obs1").Width
                    .DisplayColumns("Talão").Width = 70
                    .DisplayColumns("ProductCode").Width = 50
                    .DisplayColumns("ProductCode").Locked = False
                    .DisplayColumns("Cor").Locked = False
                    .DisplayColumns("Tam").Locked = False
                    .DisplayColumns("Descrição").Visible = False
                    .DisplayColumns("DocNr").Visible = True
                    .DisplayColumns("Obs").Width = 150
                    .DisplayColumns("Obs1").Width = 150
                    .DisplayColumns("Obs3").Width = 150
                    .DisplayColumns("Descrição").Style.HorizontalAlignment = AlignHorzEnum.Near
                    .DisplayColumns("Loja").Style.HorizontalAlignment = AlignHorzEnum.Near
                    .DisplayColumns("PrTalão").Style.HorizontalAlignment = AlignHorzEnum.Far
                    .DisplayColumns("PrVnd").Style.HorizontalAlignment = AlignHorzEnum.Far
                    .DisplayColumns("PrVndReal").Style.HorizontalAlignment = AlignHorzEnum.Far
                    .DisplayColumns("Obs").Locked = False
                    .DisplayColumns("Obs1").Locked = False
                    .DisplayColumns("Comissao").Locked = False
                    .DisplayColumns("Comissao").Visible = True
                    .DisplayColumns("Ln").Visible = False
                    .DisplayColumns("PrTalão").Width = 70
                    .DisplayColumns("PrVnd").Width = 70
                    .DisplayColumns("PrVnd").Locked = False
                    .DisplayColumns("Est").Locked = False
                    .DisplayColumns("PrVndReal").Width = 70
                    .DisplayColumns("Est").Width = 70
                    .DisplayColumns("DocNr").Width = 90
                    .DisplayColumns("DtUltMov").Width = 70
                    .DisplayColumns("PrFixo").Visible = True
                    .DisplayColumns("PrFixo").Locked = False


                    xLarguraGrid = xLarguraGrid + 70 + 150 - xAuxLarguraGrid
                    If xAplicacao = "POS" Then
                        .DisplayColumns("Ep").Visible = False
                        .DisplayColumns("Gr").Visible = True
                        .DisplayColumns("Tip").Visible = True
                        .DisplayColumns("Alt").Visible = False
                        .DisplayColumns("Loja").Visible = False
                        .DisplayColumns("DocNr").Visible = True
                        .DisplayColumns("DtUltMov").Visible = True
                        .DisplayColumns("Ln").Visible = False
                        .DisplayColumns("PrFixo").Visible = False
                        .DisplayColumns("Comissao").Visible = False
                        .DisplayColumns("FornID").Visible = False
                        .DisplayColumns("DtUltMov").Visible = False
                        .DisplayColumns("DocNr").Visible = False



                        If bAtrai = True Then

                            .DisplayColumns("DtUltMov").Visible = False
                            .DisplayColumns("Gr").Visible = False
                            .DisplayColumns("Tip").Visible = False
                            .DisplayColumns("DocNr").Visible = False
                            .DisplayColumns("DtUltMov").Visible = False
                            .DisplayColumns("ProductCode").Visible = False
                            .DisplayColumns("RefForn").Visible = True
                            .DisplayColumns("Obs").Visible = False
                            .DisplayColumns("Obs1").Visible = False
                            .DisplayColumns("Vendedor").Visible = False


                            'PARA JÁ FICA INVISIVEL 
                            .DisplayColumns("Loja").Visible = False
                            .DisplayColumns("PrVndReal").Visible = False
                            .DisplayColumns("PrVnd").Visible = False





                        End If
                    End If


                    If xGrupoAcesso = "ADMIN" Then

                        .DisplayColumns("PrFixo").Visible = True
                        .DisplayColumns("Comissao").Visible = True
                        .DisplayColumns("FornID").Visible = True
                        .DisplayColumns("DtUltMov").Visible = True
                        .DisplayColumns("DocNr").Visible = True

                    End If


                End With
                .Columns("ProductCode").Caption = "Artigo"
                .Columns("Est").Caption = "Estado"
                .Columns("PrVndReal").Caption = "PrVendido"
                .Columns("Obs").EditMask = "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&"
                .Columns("Obs1").EditMask = "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&"
                .FilterBar = True
                .AllowFilter = False
                .FilterBarStyle.BackColor = Color.LightYellow
            End With

            C1TDBGCTaloes.Width = xLarguraGrid * 1.1
            WindowState = FormWindowState.Maximized
        Catch ex As Exception
        Finally
            If val IsNot Nothing Then val.Dispose()
            val = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFechar.Click
        dtConsultaTalao = Nothing
        Me.Close()
    End Sub

    Private Sub cmdActualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActualiza.Click

        Me.Cursor = Cursors.WaitCursor
        Dim db As New ClsSqlBDados
        dtConsultaTalao.Clear()

        Try


            If Me.lbFiltro.Items.Count > 0 Then

                For I As Integer = 0 To Me.lbFiltro.Items.Count - 1
                    xFiltraTaloes += " '" + Me.lbFiltro.Items(I).ToString + "', "
                Next
                xFiltraTaloes = xFiltraTaloes.Substring(0, xFiltraTaloes.Length - 2)


                Sql = "SELECT Serie.SerieID AS Talão, Serie.ProductCode, Modelos.EpocaID AS Ep, Modelos.GrupoID AS Gr, Modelos.TipoID AS Tip, Modelos.Altura AS Alt, Serie.ModeloID AS Modelo, " & _
               "Serie.CorID AS Cor, RTRIM(ModeloCor.ModCorDescr) AS Descrição, Serie.TamID AS Tam, RTRIM(Serie.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) " & _
               "AS Loja, Serie.EstadoID AS Est, Modelos.LinhaID AS Ln, Serie.PrecoEtiqueta AS PrTalão, Serie.PrecoVenda AS PrVnd, Serie.PVndReal AS PrVndReal , Serie.Comissao, DocNr, Serie.DtSaida AS DtUltMov, Serie.Obs, Serie.Obs1, ModeloCor.FornID " & _
               "FROM Serie LEFT OUTER JOIN " & _
               "Modelos ON Serie.ModeloID = Modelos.ModeloID LEFT OUTER JOIN " & _
               "ModeloCor ON Serie.CorID = ModeloCor.CorID AND Serie.ModeloID = ModeloCor.ModeloID LEFT OUTER JOIN " & _
               "Armazens ON Serie.ArmazemID = Armazens.ArmazemID " & _
               "WHERE Serie.SerieID in (" & xFiltraTaloes & ") and Serie.ArmazemID LIKE '" & xArmzAux & "'"

                db.GetData(Sql, dtConsultaTalao)
                C1TrueDBGridFilterChange(C1TDBGCTaloes, Me.C1TDBGCTaloes.Columns, dtConsultaTalao, sQuery)


                Me.lbFiltro.Items.Clear()
                Me.tbFiltraTalao.Clear()
                xFiltraTaloes = ""

            Else
                If xGrupoAcesso = "ADMIN" Then
                    CarregarDados()
                    C1TrueDBGridFilterChange(C1TDBGCTaloes, Me.C1TDBGCTaloes.Columns, dtConsultaTalao, sQuery)
                Else
                    ' ISTO FOI FEITO À PRESSA PARA MOSTRAR OS TALÕES NAS LOJAS....
                    Sql = "SELECT Serie.SerieID AS Talão, Serie.ProductCode, Modelos.EpocaID AS Ep, Modelos.GrupoID AS Gr, Modelos.TipoID AS Tip, Modelos.Altura AS Alt, Serie.ModeloID AS Modelo, Serie.CorID AS Cor,  " &
                        "RTRIM(ModeloCor.ModCorDescr) AS Descrição, Serie.TamID AS Tam, RTRIM(Serie.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) AS Loja,  " &
                        "Serie.EstadoID AS Est, Modelos.LinhaID AS Ln, Serie.PrecoEtiqueta AS PrTalão, Serie.PrecoVenda AS PrVnd, Serie.PVndReal AS PrVndReal, Serie.Comissao, SERIE.VENDEDOR AS Vendedor, DocNr, Serie.DtSaida AS DtUltMov,  Serie.PrFixo, Serie.Obs, Serie.Obs1, ModeloCor.FornID " &
                        "FROM Modelos RIGHT OUTER JOIN " &
                        "Serie ON Modelos.ModeloID = Serie.ModeloID LEFT OUTER JOIN " &
                        "ModeloCor ON Serie.CorID = ModeloCor.CorID AND Serie.ModeloID = ModeloCor.ModeloID LEFT OUTER JOIN " &
                        "Armazens ON Serie.ArmazemID = Armazens.ArmazemID " &
                        "WHERE Serie.ArmazemID LIKE '" & xArmzAux & "' AND Serie.EstadoID IN ('S','V','T') order by Serie.DtSaida desc"
                    db.GetData(Sql, dtConsultaTalao)
                    C1TrueDBGridFilterChange(C1TDBGCTaloes, Me.C1TDBGCTaloes.Columns, dtConsultaTalao, sQuery)
                    'MsgBox("Não tem Etiquetas para filtrar!")
                End If
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "cmdActualiza_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "cmdActualiza_Click")

        Finally
            Me.Cursor = Cursors.Default
            If Not db Is Nothing Then db.Dispose()
            db = Nothing

        End Try

    End Sub

    Private Sub btListarTaloes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListarTaloes.Click
        Try


            Dim I As Integer
            Dim db As New ClsSqlBDados
            Dim iPosicionamento As Double = 1
            xFiltro = ""
            Dim RptSelect As String = ""
            RptSelect = cbReport.SelectedItem

            Sql = "SELECT ISNULL(ImpEtiqAux,0) from Armazens where ArmazemID='" & xArmz & "'"

            If RptSelect = "EtiquetasPreco_13x5" Then
                iPosicionamentoAux = InputBox("Posição 1ªEtiqueta", "Etiquetas", db.GetDataValue(Sql))
            End If

            If dtConsultaTalao.DefaultView.Count > 0 Then
                For I = 0 To dtConsultaTalao.DefaultView.Count - 1
                    xFiltro = xFiltro & "'" & Me.C1TDBGCTaloes(I, "Talão") & "',"
                Next
            End If
            If Len(xFiltro) > 0 Then
                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)

                ListaTaloes(xFiltro, RptSelect, True)

                iPosicionamento = iPosicionamentoAux / 65
                iPosicionamento = (iPosicionamento - Int(iPosicionamento)) * 65
                If iPosicionamento = 0 Then
                    iPosicionamento = 65
                End If

                Sql = ("UPDATE Armazens SET ImpEtiqAux=" & iPosicionamento & "  WHERE ARMAZEMID='" & xArmz & "'")
                db.ExecuteData(Sql)

            Else
                MsgBox("NÃO TEM NADA SELECCIONADO", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tbFiltraTalao_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbFiltraTalao.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If Me.tbFiltraTalao.Text.Length = 8 Then
                    If ValidarTalao(Me.tbFiltraTalao.Text) = True Then
                        lbFiltro.Items.Add(Me.tbFiltraTalao.Text)
                        Me.tbFiltraTalao.Focus()
                        Me.tbFiltraTalao.SelectAll()
                    Else
                        MsgBox("Erro no Talão!")
                        tbFiltraTalao.SelectAll()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFiltrar.Click
        If Me.lbFiltro.Items.Count > 0 Then
            For I As Integer = 0 To Me.lbFiltro.Items.Count - 1
                sQuery += " '" + Me.lbFiltro.Items(I).ToString + "', "
            Next
            Sql = sQuery.Substring(0, sQuery.Length - 2)
            sQuery = "Talão in (" + Sql + ")"
            'Dim dv As DataView
            'dv = dtConsultaTalao.DefaultView
            'dv.RowFilter = sQuery
            dtConsultaTalao.DefaultView.RowFilter = sQuery
            'MsgBox(dv.Count)
            'Me.C1TDBGCTaloes.DataSource = dv
            sQuery = ""
            Me.lbFiltro.Items.Clear()
            Me.tbFiltraTalao.Clear()
        Else
            C1TrueDBGridFilterChange(C1TDBGCTaloes, Me.C1TDBGCTaloes.Columns, dtConsultaTalao, sQuery)
        End If
    End Sub

    Private Sub lbFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lbFiltro.KeyPress
        'TODO ALTERAR A TECLA DE APAGAR PARA DELETE
        If e.KeyChar = ChrW(Keys.D) Then
            e.Handled = True
            Me.lbFiltro.Items.Remove(Me.lbFiltro.SelectedItem.ToString)
        End If
    End Sub

    Private Sub cbVerTodas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodas.CheckedChanged

        Me.Cursor = Cursors.WaitCursor
        CarregarDados()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btDetTalao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDetTalao.Click

        frmMovTalao.StartPosition = FormStartPosition.CenterParent
        frmMovTalao.WindowState = FormWindowState.Normal
        frmMovTalao.ShowInTaskbar = False
        frmMovTalao.MaximizeBox = False
        frmMovTalao.MinimizeBox = False
        frmMovTalao.ShowDialog(Me)

    End Sub

    Private Sub btDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDev.Click

        'Dim frm As New frmDevCliente
        frmDevCliente.StartPosition = FormStartPosition.CenterParent
        frmDevCliente.WindowState = FormWindowState.Normal
        frmDevCliente.ShowInTaskbar = False
        frmDevCliente.MaximizeBox = False
        frmDevCliente.MinimizeBox = False
        frmDevCliente.ShowDialog(Me)

    End Sub


    Private Sub btAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAnular.Click
        Try

            Dim db As New ClsSqlBDados
            Dim I As Integer
            xFiltro = ""
            Dim RptSelect As String = ""
            RptSelect = cbReport.SelectedItem



            If dtConsultaTalao.DefaultView.Count > 0 Then

                If dtConsultaTalao.DefaultView.Count > 5 Then
                    MsgBox("Só permite anular 5 talões de cada vez!!")
                    Exit Sub
                End If


                For I = 0 To dtConsultaTalao.DefaultView.Count - 1


                    If (Me.C1TDBGCTaloes(I, "Est") = "S" Or Me.C1TDBGCTaloes(I, "Est") = "G") And Microsoft.VisualBasic.Left(Me.C1TDBGCTaloes(I, "Loja"), 4) = "0000" And VerificarSeparado(Me.C1TDBGCTaloes(I, "Talão")) = False Then
                        xFiltro = xFiltro & "'" & Me.C1TDBGCTaloes(I, "Talão") & "',"
                    Else
                        MsgBox("O Talão " & Me.C1TDBGCTaloes(I, "Talão") & " não pode ser anulado")
                        xFiltro = ""
                        Exit For
                    End If
                Next
            End If

            If Len(xFiltro) > 0 Then

                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)

                'ROTINA PARA ANULAR!
                If MsgBox("Confirma que quer Anular os talões : " & xFiltro, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


                    Sql = "UPDATE SERIE SET ESTADOID = 'A', DTSAIDA = GETDATE() WHERE SERIEID IN (" & xFiltro & ") AND ESTADOID IN ('S','G') AND ARMAZEMID='0000'"
                    db.ExecuteData(Sql)

                    cmdActualiza_Click(sender, e)

                End If

            Else
                MsgBox("NÃO FOI POSSIVEL ANULAR A SELECÇÃO", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btValor_Click(sender As System.Object, e As System.EventArgs) Handles btValor.Click


        Try

            Dim I As Integer
            Dim sValorVnd As Double

            If dtConsultaTalao.DefaultView.Count > 0 Then
                For I = 0 To dtConsultaTalao.DefaultView.Count - 1
                    sValorVnd = sValorVnd + Me.C1TDBGCTaloes(I, "PrVnd")
                Next

                MsgBox("Valor Total da selecção : " & FormatCurrency(sValorVnd), MsgBoxStyle.Information, "Totais")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    'EVENTOS NA C1TDBGCTaloes


    Private Sub C1TDBGCTaloes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles C1TDBGCTaloes.AfterColEdit

        Try



            If sAplicacao <> "CELFGEST" Then


                sLinha = C1TDBGCTaloes.Row

                Dim db As New ClsSqlBDados


                Select Case e.Column.Name

                    Case "PrVnd"

                        If Not C1TDBGCTaloes(sLinha, "PrVnd") Is DBNull.Value Then
                            Sql = "UPDATE Serie SET PrecoVenda = '" & C1TDBGCTaloes(sLinha, "PrVnd") & "',  OperadorID = '" & xUtilizador & "' WHERE SerieID='" & C1TDBGCTaloes(sLinha, "Talão") & "' and EstadoID not in ('V', 'R')"
                            db.ExecuteData(Sql)
                        End If

                    Case "Comissao"

                        If Not C1TDBGCTaloes(sLinha, "Comissao") Is DBNull.Value Then
                            Sql = "UPDATE Serie SET Comissao = '" & C1TDBGCTaloes(sLinha, "Comissao") & "', OperadorID = '" & xUtilizador & "' WHERE SerieID='" & C1TDBGCTaloes(sLinha, "Talão") & "' and EstadoID not in ('R')"
                            db.ExecuteData(Sql)
                        End If



                    Case "Obs"
                        If Not C1TDBGCTaloes(sLinha, "Obs") Is DBNull.Value Then
                            Sql = "UPDATE Serie SET Obs = '" & C1TDBGCTaloes(sLinha, "Obs") & "', OperadorID = '" & xUtilizador & "' WHERE SerieID='" & C1TDBGCTaloes(sLinha, "Talão") & "'"
                            db.ExecuteData(Sql)
                        End If

                    Case "Obs1"
                        If Not C1TDBGCTaloes(sLinha, "Obs1") Is DBNull.Value Then
                            Sql = "UPDATE Serie SET Obs1 = '" & C1TDBGCTaloes(sLinha, "Obs1") & "', OperadorID = '" & xUtilizador & "' WHERE SerieID='" & C1TDBGCTaloes(sLinha, "Talão") & "'"
                            db.ExecuteData(Sql)
                        End If

                    Case "Estado"

                        Sql = "UPDATE Serie SET EstadoID = '" & Char.ToUpper(C1TDBGCTaloes(sLinha, "Estado")) & "', OperadorID = '" & xUtilizador & "' WHERE SerieID='" & C1TDBGCTaloes(sLinha, "Talão") & "'"
                        db.ExecuteData(Sql)

                    Case "PrFixo"

                        If Not C1TDBGCTaloes(sLinha, "PrFixo") Is DBNull.Value Then
                            Sql = "UPDATE Serie SET PrFixo = '" & C1TDBGCTaloes(sLinha, "PrFixo") & "', OperadorID = '" & xUtilizador & "' WHERE SerieID='" & C1TDBGCTaloes(sLinha, "Talão") & "' and EstadoID not in ('V','R','F')"
                            db.ExecuteData(Sql)
                        End If


                    Case "Artigo"

                        If Not C1TDBGCTaloes(sLinha, "Artigo") Is DBNull.Value Then
                            Sql = "UPDATE Serie SET ProductCode = '" & C1TDBGCTaloes(sLinha, "Artigo") & "', OperadorID = '" & xUtilizador & "' WHERE SerieID='" & C1TDBGCTaloes(sLinha, "Talão") & "' and EstadoID not in ('V','R','F')"
                            db.ExecuteData(Sql)
                        End If



                    Case "Cor"

                        If Not C1TDBGCTaloes(sLinha, "Cor") Is DBNull.Value Then
                            Sql = "UPDATE Serie SET CorID = '" & C1TDBGCTaloes(sLinha, "Cor") & "', OperadorID = '" & xUtilizador & "' WHERE SerieID='" & C1TDBGCTaloes(sLinha, "Talão") & "' and EstadoID not in ('V','R','F')"
                            db.ExecuteData(Sql)
                        End If


                    Case "Tam"

                        If Not C1TDBGCTaloes(sLinha, "Tam") Is DBNull.Value Then
                            Sql = "UPDATE Serie SET TamID = '" & C1TDBGCTaloes(sLinha, "Tam") & "', OperadorID = '" & xUtilizador & "' WHERE SerieID='" & C1TDBGCTaloes(sLinha, "Talão") & "' and EstadoID not in ('V','R','F')"
                            db.ExecuteData(Sql)
                        End If



                End Select




            End If


        Catch ex As Exception

            MsgBox(ex.Message)

        End Try



    End Sub

    Private Sub C1TDBGCTaloes_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1TDBGCTaloes.FilterChange
        Me.PictureBox.Visible = False
        C1TrueDBGridFilterChange(C1TDBGCTaloes, Me.C1TDBGCTaloes.Columns, dtConsultaTalao, sQuery)
    End Sub

    Private Sub C1TDBGCTaloes_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles C1TDBGCTaloes.RowColChange
        Try

            If C1TDBGCTaloes(C1TDBGCTaloes.Row, "Modelo") & C1TDBGCTaloes(C1TDBGCTaloes.Row, "Cor") <> xModeloCor Then
                xModeloCor = C1TDBGCTaloes(C1TDBGCTaloes.Row, "Modelo") & C1TDBGCTaloes(C1TDBGCTaloes.Row, "Cor")
                Foto.CarregarFotoModeloCor(Me.PictureBox, xModeloCor)
            End If

            Me.PictureBox.Visible = True
            C1TDBGCTaloes.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell

            xMovTalao = C1TDBGCTaloes(C1TDBGCTaloes.Row, "Talão")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub C1TDBGCTaloes_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles C1TDBGCTaloes.HeadClick
        C1TDBGCTaloes.MarqueeStyle = MarqueeEnum.NoMarquee
        C1TDBGCTaloes.SelectedRows.Clear()
    End Sub

    Private Sub C1TDBGCTaloes_BeforeColEdit(sender As Object, e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles C1TDBGCTaloes.BeforeColEdit


        Try


            sLinha = C1TDBGCTaloes.Row


            Select Case e.Column.Name

                Case "PrVnd", "Comissao", "PrFixo", "Cor", "Artigo"

                    If C1TDBGCTaloes(C1TDBGCTaloes.Row, "Est") = "V" Or C1TDBGCTaloes(C1TDBGCTaloes.Row, "Est") = "R" Then
                        e.Cancel = True
                        MsgBox("Não pode alterar registo neste estado!")
                    End If



            End Select


        Catch ex As Exception

        End Try



    End Sub

    Private Sub C1TDBGCTaloes_BeforeColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles C1TDBGCTaloes.BeforeColUpdate

        Dim db As New ClsSqlBDados


        Try


            If sAplicacao = "CELFGEST" Then

                e.Cancel = True
                SendKeys.Send("{escape}")

            Else

                Select Case e.Column.Name

                    Case "Comissao"

                        dComissaoAux = C1TDBGCTaloes(C1TDBGCTaloes.Row, "Comissao")


                    Case "Cor"

                        Dim xModelo As String = Me.C1TDBGCTaloes.Columns("Modelo").Text()
                        Dim xCor As String = Me.C1TDBGCTaloes.Columns("Cor").Text()

                        Sql = "SELECT count(*) Existe FROM Serie WHERE (ModeloID = '" & xModelo & "') AND (CorID = '" & xCor & "')"
                        Dim sExiste As String = db.GetDataValue(Sql)

                        If sExiste = 0 Then
                            MsgBox("A cor " & xCor & " não está criada!!", MsgBoxStyle.Information)
                            e.Cancel = True
                            SendKeys.Send("{escape}")
                        End If

                    Case "Estado"


                        If C1TDBGCTaloes(C1TDBGCTaloes.Row, "Est") <> "F" Then
                            MsgBox("Não pode alterar registo neste estado!")
                            e.Cancel = True
                            SendKeys.Send("{escape}")
                        Else
                            If MsgBox("Confirma que quer mudar o estado do talão?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                e.Cancel = True
                                SendKeys.Send("{escape}")
                            End If

                        End If


                End Select

            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarDados")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarDados")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Private Sub C1TDBGCTaloes_DoubleClick(sender As Object, e As EventArgs) Handles C1TDBGCTaloes.DoubleClick


        Try

            If xGrupoAcesso = "ADMIN" And Me.C1TDBGCTaloes.Splits(0).DisplayColumns(C1TDBGCTaloes.Col).Name = "Modelo" Then

                If C1TDBGCTaloes.Row >= 0 Then

                    frmStockLoja.xModelo = C1TDBGCTaloes(C1TDBGCTaloes.Row, "Modelo")
                    frmStockLoja.xCor = C1TDBGCTaloes(C1TDBGCTaloes.Row, "Cor")
                    frmStockLoja.StartPosition = FormStartPosition.CenterParent
                    frmStockLoja.WindowState = FormWindowState.Normal
                    frmStockLoja.ShowInTaskbar = False
                    frmStockLoja.MaximizeBox = False
                    frmStockLoja.MinimizeBox = False
                    frmStockLoja.ShowDialog(Me)

                End If
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TDBGCTaloes_DoubleClick")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TDBGCTaloes_DoubleClick")

        End Try

    End Sub


    'FUNÇÕES


    Private Function ValidarTalao(ByVal Talao As String) As Boolean

        Dim db As New ClsSqlBDados

        Try

            Sql = "SELECT COUNT(*) FROM SERIE WHERE SERIEID='" & Talao & "'"
            If db.GetDataValue(Sql) = 0 Then
                Return False
            Else
                Return True
            End If


            'If dtConsultaTalao.Rows.Count > 0 Then
            '    If dtConsultaTalao.Select("Talão = '" & Talao & "'", "").Length = 0 Then
            '        Return False
            '    End If
            'End If
            'Return True


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ValidarTalao")
        Catch ex As Exception
            ErroVB(ex.Message, "ValidarTalao")

        End Try



    End Function

    Private Sub CarregarDados()

        Dim db As New ClsSqlBDados
        Dim xTempoDev As Double = 90

        Try

            dtConsultaTalao.Clear()


            If xCargaIni = False Then

                If cbVerTodas.Checked = True Then

                    Sql = "SELECT Serie.SerieID AS Talão, Serie.ProductCode, Modelos.EpocaID AS Ep, Modelos.GrupoID AS Gr, Modelos.TipoID AS Tip, Modelos.Altura AS Alt, Serie.ModeloID AS Modelo, Serie.CorID AS Cor, RTRIM(ModeloCor.ModCorDescr) AS Descrição, Serie.TamID AS Tam, RTRIM(Serie.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) " &
                        "AS Loja, Serie.EstadoID AS Est, Modelos.LinhaID AS Ln, Serie.PrecoEtiqueta AS PrTalão, Serie.PrecoVenda AS PrVnd, Serie.PVndReal AS PrVndReal, Serie.Comissao, SERIE.VENDEDOR AS Vendedor, DocNr, Serie.DtSaida AS DtUltMov, Serie.PrFixo, Serie.Obs, Serie.Obs1, ModeloCor.FornID , Serie.Obs3 " &
                        "FROM Serie LEFT OUTER JOIN Modelos ON Serie.ModeloID = Modelos.ModeloID LEFT OUTER JOIN " &
                        "ModeloCor ON Serie.CorID = ModeloCor.CorID AND Serie.ModeloID = ModeloCor.ModeloID LEFT OUTER JOIN " &
                        "Armazens ON Serie.ArmazemID = Armazens.ArmazemID " &
                        "WHERE Serie.ArmazemID LIKE '" & xArmzAux & "' order by Serie.DtSaida desc"
                Else

                    If xArmz = "0000" Then
                        Sql = "SELECT Serie.SerieID AS Talão, Serie.ProductCode, Modelos.EpocaID AS Ep, Modelos.GrupoID AS Gr, Modelos.TipoID AS Tip, Modelos.Altura AS Alt, Serie.ModeloID AS Modelo, Serie.CorID AS Cor,  " &
                        "RTRIM(ModeloCor.ModCorDescr) AS Descrição, Serie.TamID AS Tam, RTRIM(Serie.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) AS Loja,  " &
                        "Serie.EstadoID AS Est, Modelos.LinhaID AS Ln, Serie.PrecoEtiqueta AS PrTalão, Serie.PrecoVenda AS PrVnd, Serie.PVndReal AS PrVndReal, Serie.Comissao, SERIE.VENDEDOR AS Vendedor, DocNr, Serie.DtSaida AS DtUltMov, Serie.PrFixo, Serie.Obs, Serie.Obs1, ModeloCor.FornID , Serie.Obs3  " &
                        "FROM Modelos RIGHT OUTER JOIN " &
                        "Serie ON Modelos.ModeloID = Serie.ModeloID LEFT OUTER JOIN " &
                        "ModeloCor ON Serie.CorID = ModeloCor.CorID AND Serie.ModeloID = ModeloCor.ModeloID LEFT OUTER JOIN " &
                        "Armazens ON Serie.ArmazemID = Armazens.ArmazemID " &
                        "WHERE Serie.ArmazemID LIKE '%' AND (Serie.EstadoID NOT IN ('R') OR (Serie.EstadoID IN ('R') AND (Serie.DtRegisto > (GETDATE() - " & xTempoDev & ")))) order by Serie.DtSaida desc"
                        '"WHERE Serie.EstadoID in ('S','T') AND Serie.ArmazemID like '" & xArmzAux & "'"



                    Else
                        Sql = "SELECT Serie.SerieID AS Talão, Serie.ProductCode, Modelos.EpocaID AS Ep, Modelos.GrupoID AS Gr, Modelos.TipoID AS Tip, Modelos.Altura AS Alt, Serie.ModeloID AS Modelo, Serie.CorID AS Cor,  " &
                        "RTRIM(ModeloCor.ModCorDescr) AS Descrição, Serie.TamID AS Tam, RTRIM(Serie.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) AS Loja,  " &
                        "Serie.EstadoID AS Est, Modelos.LinhaID AS Ln, Serie.PrecoEtiqueta AS PrTalão, Serie.PrecoVenda AS PrVnd, Serie.PVndReal AS PrVndReal, Serie.Comissao, SERIE.VENDEDOR AS Vendedor, DocNr, Serie.DtSaida AS DtUltMov,  Serie.PrFixo, Serie.Obs, Serie.Obs1, ModeloCor.FornID , Serie.Obs3 " &
                        "FROM Modelos RIGHT OUTER JOIN " &
                        "Serie ON Modelos.ModeloID = Serie.ModeloID LEFT OUTER JOIN " &
                        "ModeloCor ON Serie.CorID = ModeloCor.CorID AND Serie.ModeloID = ModeloCor.ModeloID LEFT OUTER JOIN " &
                        "Armazens ON Serie.ArmazemID = Armazens.ArmazemID " &
                        "WHERE Serie.ArmazemID LIKE '" & xArmzAux & "' AND (Serie.EstadoID NOT IN ('R') OR (Serie.EstadoID IN ('R') AND (Serie.DtRegisto > (GETDATE() - " & xTempoDev & ")))) order by Serie.DtSaida desc"
                    End If
                End If
            Else
                Sql = "SELECT Serie.SerieID AS Talão, Serie.ProductCode, Modelos.EpocaID AS Ep, Modelos.GrupoID AS Gr, Modelos.TipoID AS Tip, Modelos.Altura AS Alt, Serie.ModeloID AS Modelo, " &
                        "Serie.CorID AS Cor, RTRIM(ModeloCor.ModCorDescr) AS Descrição, Serie.TamID AS Tam, RTRIM(Serie.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) " &
                        "AS Loja, Serie.EstadoID AS Est, Modelos.LinhaID AS Ln, Serie.PrecoEtiqueta AS PrTalão, Serie.PrecoVenda AS PrVnd, Serie.PVndReal AS PrVndReal, Serie.Comissao, SERIE.VENDEDOR AS Vendedor, DocNr, Serie.DtSaida AS DtUltMov, Serie.PrFixo, Serie.Obs, Serie.Obs1, ModeloCor.FornID, Serie.Obs3  " &
                        "FROM Serie LEFT OUTER JOIN " &
                        "Modelos ON Serie.ModeloID = Modelos.ModeloID LEFT OUTER JOIN " &
                        "ModeloCor ON Serie.CorID = ModeloCor.CorID AND Serie.ModeloID = ModeloCor.ModeloID LEFT OUTER JOIN " &
                        "Armazens ON Serie.ArmazemID = Armazens.ArmazemID " &
                        "WHERE Serie.ArmazemID='xxxx' order by Serie.DtSaida desc"

            End If

            xCargaIni = False

            If bAtrai = True Then
                'Sql = "SELECT Serie.SerieID AS Talão, Serie.ProductCode, Modelos.EpocaID AS Ep, Modelos.GrupoID AS Gr, Modelos.TipoID AS Tip, Modelos.Altura AS Alt, Serie.ModeloID AS Modelo, Serie.CorID AS Cor, RTRIM(ModeloCor.ModCorDescr) AS Descrição, Serie.TamID AS Tam, RTRIM(Serie.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) AS Loja, Serie.EstadoID AS Est, Modelos.LinhaID AS Ln, Serie.PrecoEtiqueta AS PrTalão, Serie.PrecoVenda AS PrVnd, Serie.PVndReal AS PrVndReal, Serie.Comissao, Serie.Vendedor, Serie.DocNr, Serie.DtSaida AS DtUltMov, Serie.PrFixo, Serie.Obs, Serie.Obs1 FROM Serie LEFT OUTER JOIN Modelos ON Serie.ModeloID = Modelos.ModeloID LEFT OUTER JOIN ModeloCor ON Serie.CorID = ModeloCor.CorID AND Serie.ModeloID = ModeloCor.ModeloID LEFT OUTER JOIN Armazens ON Serie.ArmazemID = Armazens.ArmazemID WHERE (ModeloCor.FornID = '1016') ORDER BY Talão DESC"
                Sql = "SELECT Serie.SerieID AS Talão, Serie.ProductCode, Modelos.EpocaID AS Ep, Modelos.GrupoID AS Gr, Modelos.TipoID AS Tip, ModeloCor.RefForn, Modelos.Altura AS Alt, Serie.ModeloID AS Modelo, Serie.CorID AS Cor, RTRIM(ModeloCor.ModCorDescr) AS Descrição, Serie.TamID AS Tam, RTRIM(Serie.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) AS Loja, Serie.EstadoID AS Est, Modelos.LinhaID AS Ln, Serie.PrecoEtiqueta AS PrTalão, Serie.PrecoVenda AS PrVnd, Serie.PVndReal AS PrVndReal, Serie.Comissao, Serie.Vendedor, Serie.DocNr, Serie.DtSaida AS DtUltMov, Serie.PrFixo, Serie.Obs, Serie.Obs1 FROM Serie LEFT OUTER JOIN Modelos ON Serie.ModeloID = Modelos.ModeloID LEFT OUTER JOIN ModeloCor ON Serie.CorID = ModeloCor.CorID AND Serie.ModeloID = ModeloCor.ModeloID LEFT OUTER JOIN Armazens ON Serie.ArmazemID = Armazens.ArmazemID WHERE (ModeloCor.FornID = '1016') ORDER BY Talão DESC"

            End If


            db.GetData(Sql, dtConsultaTalao)

            'dtConsultaTalao.Select("FornId='1016'")

            'If cn.State = ConnectionState.Closed Then cn.Open()
            'da = New SqlDataAdapter(Sql, cn)
            'da.SelectCommand.CommandTimeout = 180
            'da.Fill(dtConsultaTalao)
            '
            C1TDBGCTaloes.DataSource = dtConsultaTalao
            C1DbNavigator.DataSource = dtConsultaTalao
            Application.DoEvents()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarDados")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarDados")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Function VerificarSeparado(ByVal xTalao As String) As Boolean

        Dim db As New ClsSqlBDados


        'VERIFICAR SE JÁ ESTÁ SEPARADO PARA ALGUMA CASA
        Sql = "SELECT COUNT(*) FROM  DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr " & _
        "WHERE DocCab.ArmazemID = '" & xArmz & "' AND DocDet.TipoDocID = 'SE' AND DocDet.SerieID = '" & xTalao & "' AND DocDet.EstadoLn = 'G'"

        If db.GetDataValue(Sql) > 0 Then
            If MsgBox("O TALÃO " & xTalao & " ESTÁ EM SEPARAÇÃO. APAGAR DA SEPARAÇÃO?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Sql = "DELETE FROM DOCDET WHERE EMPRESAID = '" & xEmp & "' AND ARMAZEMID = '" & xArmz & "' AND TIPODOCID = 'SE' AND SERIEID = '" & xTalao & "' AND ESTADOLN = 'G'"
                db.ExecuteData(Sql)
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function


    Private Sub btForn_Click(sender As System.Object, e As System.EventArgs) Handles btForn.Click

        Dim dt As New DataTable
        Dim db As New ClsSqlBDados
        Dim frm As New Form

        Try
            frm = New Form
            Dgrid = New DataGridView
            '_cmd = CType(sender, Button)

            Sql = "SELECT TERCID,NOMEABREV FROM TERCEIROS WHERE TIPOTERC='F' ORDER BY NOMEABREV"
            db.GetData(Sql, dt)

            With Dgrid
                .DataSource = dt
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .Dock = DockStyle.Fill
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .ReadOnly = True
                For c As Integer = 0 To Dgrid.Columns.Count - 1
                    With .Columns(c)
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .ReadOnly = True
                        .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .HeaderCell.Style.Font = New Font("Arial", 10, FontStyle.Bold)
                    End With
                Next
                .AutoSize = True


            End With
            With frm
                .Width = 400
                .Height = 500
                .StartPosition = FormStartPosition.CenterParent
                .Controls.Add(Dgrid)
                .ShowDialog(Me)

            End With
            'AddHandler Dgrid.Click, AddressOf Dgrid_Click
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " btForn_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub C1TDBGCTaloes_MouseClick(sender As Object, e As MouseEventArgs) Handles C1TDBGCTaloes.MouseClick
        Dim db As New ClsSqlBDados
        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then
                'validar se a celula é fornid
                If Me.C1TDBGCTaloes.Splits(0).DisplayColumns(C1TDBGCTaloes.Col).Name = "FornID" Then
                    Sql = "SELECT NomeAbrev FROM Terceiros WHERE TercID='" & C1TDBGCTaloes(C1TDBGCTaloes.Row, "FornID") & "' "

                    lblForn.Text = db.GetDataValue(Sql)
                    lblForn.AutoSize = True
                    lblForn.Location = New Point(e.X, e.Y)
                    C1TDBGCTaloes.Controls.Add(lblForn)
                Else
                    If lblForn IsNot Nothing Then
                        lblForn.Text = ""
                    End If
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub


End Class