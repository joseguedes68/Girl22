Imports System.Data.SqlClient


Public Class frmGestaoPrecosVenda

    Private DT_Precos As New DataTable
    Dim Fechar As Boolean = False
    Dim dtCopiaOrigem As New DataTable
    Dim dtCopiaDestino As New DataTable
    Dim xLinaActual As Integer
    'Dim xModelo As String
    'Dim xCor As String


    Private Sub frmGestaoPrecosVenda_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not DT_Precos.GetChanges Is Nothing Then
            If DT_Precos.GetChanges.Rows.Count > 0 Then
                e.Cancel = True
                If xAplicacao = "POS" And xGrupoAcesso <> "ADMIN" Then
                    DT_Precos.RejectChanges()
                    Me.Close()
                    Exit Sub
                End If
                If MsgBox("Pretende gravar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Fechar = True
                    cmdGravar_Click(sender, e)
                Else
                    DT_Precos.RejectChanges()
                    Me.Close()
                End If
            End If
        End If
        xFiltraDataGrid = ""
    End Sub

    Private Sub frmGestaoPrecosVenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New ClsSqlBDados


        Try

            Sql = "SELECT TabPrecoID, TabPrecoID +'-'+ DescTabPreco DescTabPreco FROM TabelaPrecos WHERE Visivel = 1 ORDER BY Ordem"
            db.GetData(Sql, dtCopiaDestino)

            If xAplicacao = "POS" Then
                Sql = "SELECT TabelaPrecos.TabPrecoID, TabelaPrecos.TabPrecoID + '-' + TabelaPrecos.DescTabPreco AS DescTabPreco FROM TabelaPrecos INNER JOIN TabPrecosLoja ON TabelaPrecos.TabPrecoID = TabPrecosLoja.TabPrecoID WHERE (TabPrecosLoja.ArmazemID = '" & xArmz & "') AND (TabPrecosLoja.Visivel = 1) ORDER BY TabelaPrecos.Ordem"
            Else
                Sql = "SELECT TabPrecoID, TabPrecoID +'-'+ DescTabPreco DescTabPreco FROM TabelaPrecos WHERE Visivel = 1 ORDER BY Ordem"
            End If
            db.GetData(Sql, dtCopiaOrigem)



            Me.cbTabDestino.DataSource = dtCopiaDestino
            Me.cbTabDestino.ValueMember = "TabPrecoID"
            Me.cbTabDestino.DisplayMember = "DescTabPreco"
            Me.cbTabDestino.SelectedValue = ""

            Me.cbTabOrigem.DataSource = dtCopiaOrigem
            Me.cbTabOrigem.ValueMember = "TabPrecoID"
            Me.cbTabOrigem.DisplayMember = "DescTabPreco"
            Me.cbTabOrigem.SelectedValue = ""

            'Me.StartPosition = FormStartPosition.CenterScreen
            'Me.WindowState = FormWindowState.Maximized
            Me.Cursor = Cursors.WaitCursor

            Me.Panel1.Visible = False
            Me.Panel2.Visible = False
            Application.DoEvents()

            'If xAplicacao = "POS" Then gbCopiarTabelas.Visible = False
            If xAplicacao = "POS" Then
                'If xAplicacao = "POS" And xGrupoAcesso <> "ADMIN" Then

                Me.gbCopiarTabelas.Text = "Lista Preços Unicos"

                Me.lbOrigem.Text = "Tabela"
                Me.lbDestino.Visible = False
                Me.cbTabOrigem.Visible = True
                Me.cbTabDestino.Visible = False
                Me.btListaTabPUnico.Visible = True
                Me.btCopiarTabela.Visible = False
                Me.cmdGravar.Visible = False
                Me.cmdCancelar.Visible = False


            Else
                Me.gbCopiarTabelas.Text = "Copiar Tabelas"
                Me.lbOrigem.Text = "Origem"
                Me.lbDestino.Visible = True
                Me.cbTabOrigem.Visible = True
                Me.cbTabDestino.Visible = True
                Me.btListaTabPUnico.Visible = False
                Me.btCopiarTabela.Visible = True
                Me.cmdGravar.Visible = True
                Me.cmdCancelar.Visible = True


            End If


            ActualizarDT_Precos()
            IniciarDataGrid()

            Me.cmdImprimir.Enabled = False

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name + ": frmGestaoPrecosVenda_Load")

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": frmGestaoPrecosVenda_Load")

        Finally

            If Not db Is Nothing Then db.Dispose()
            db = Nothing

        End Try
    End Sub

    Private Sub IniciarDataGrid()
        Try
            If Not Me.dgvPrecos.DataSource Is Nothing Then Me.dgvPrecos.DataSource = Nothing
            Me.dgvPrecos.DataSource = DT_Precos

            Me.cmdGravar.Enabled = False
            Me.cmdCancelar.Enabled = False
            With dgvPrecos
                .AllowDrop = False
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToResizeColumns = True
                .AllowUserToResizeRows = False
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                .RowHeadersWidth = .ColumnHeadersHeight * 2
                If .RowCount > 0 Then
                    For Each c As DataGridViewColumn In Me.dgvPrecos.Columns
                        'c.SortMode = DataGridViewColumnSortMode.NotSortable
                        With c.DefaultCellStyle
                            .SelectionBackColor = Color.Yellow
                            .SelectionForeColor = Color.Black
                            .WrapMode = DataGridViewTriState.True
                            .Font = New Font("Arial", 9, FontStyle.Regular)
                            Select Case c.ValueType.Name.ToString
                                Case "Boolean"
                                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                                    c.Width = 50
                                Case "String"
                                    .Alignment = DataGridViewContentAlignment.MiddleLeft
                                    c.Width = 50
                                Case "Decimal"
                                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                                    .Format = "#,##0"
                                    c.Width = 50
                                Case "Double"
                                    .Alignment = DataGridViewContentAlignment.MiddleRight
                                    .Format = "#,##0.00"
                                    c.Width = 50
                            End Select
                        End With
                        With c.HeaderCell.Style
                            .Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Font = New Font("Arial", 8, FontStyle.Bold)
                        End With
                        If c.Name = "ModCorDescr" Then c.Visible = False
                    Next

                    .AutoResizeColumn(7)
                    .AutoSize = True
                End If
            End With
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name + ": IniciarDataGrid")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": IniciarDataGrid")
        Finally
            Me.Panel1.Visible = True
            Me.Panel2.Visible = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ActualizarDT_Precos()
        Dim db As New ClsSqlBDados
        Try
            If Not DT_Precos Is Nothing Then DT_Precos.Clear()
            If xAplicacao = "POS" Then
                Sql = "EXEC prc_Gestao_Precos_Loja @Armz='" & xArmz & "'"
            Else
                Sql = "EXEC prc_Gestao_Precos"
            End If
            db.GetData(Sql, DT_Precos, False)
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name + ": ActualizarDT_Precos")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": ActualizarDT_Precos")
        Finally
            db.Dispose()
            db = Nothing
            Sql = Nothing
        End Try
    End Sub

    Private Sub dgvPrecos_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrecos.CellBeginEdit

        If xAplicacao = "POS" And xGrupoAcesso <> "ADMIN" Then
            e.Cancel = True
        End If

    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrecos.CellEnter
        Static LinhaActual As Integer
        Dim Foto As New ClsFotos
        Dim Modelo As String
        Dim Cor As String
        Try
            If e.RowIndex >= 0 Then
                Modelo = Me.dgvPrecos("Modelo", e.RowIndex).Value
                Cor = Me.dgvPrecos("Cor", e.RowIndex).Value
                If Not LinhaActual = e.RowIndex Then
                    LinhaActual = e.RowIndex
                    Foto.CarregarFotoModeloCor(Me.PicBox, Modelo + Cor)
                End If
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": IniciarDataGrid")
        Finally
            Foto.Dispose()
            Foto = Nothing
            Modelo = Nothing
            Cor = Nothing
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPrecos.CellMouseClick
        Dim dg_Preco As New clsDataGrid(Me.dgvPrecos, DT_Precos.DefaultView)
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                'MsgBox(Me.DataGridView1.Columns(e.ColumnIndex).Name)
                'xFiltro = dg_Preco.xFiltraDataGrid.ToString()
                dg_Preco.MostraFiltroForm(e)
                'dg_Preco.xfiltro.ToString()
                'MsgBox(xFiltro)
                'dg_Preco.Frm.Close()
                'DT_Precos.DefaultView.RowFilter = "Modelo >='00001' and Modelo <='00002'"
            End If


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": IniciarDataGrid")
        Finally
            dg_Preco.Dispose()
            dg_Preco = Nothing
        End Try
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrecos.CellValueChanged
        Me.dgvPrecos.Rows(Me.dgvPrecos.CurrentRow.Index).ErrorText = "Sofreu Alterações"
        Me.cmdGravar.Enabled = True
        Me.cmdCancelar.Enabled = True
        If DT_Precos.Select("Prt = true").Length > 0 Then
            Me.cmdImprimir.Enabled = True
        Else
            Me.cmdImprimir.Enabled = False
        End If

        If e.ColumnIndex = Me.dgvPrecos.Columns("PrEti").Index Then
            'If e.ColumnIndex = 11 Or e.ColumnIndex = 12 Then
            Me.dgvPrecos(0, e.RowIndex).Value = True
            Me.cmdImprimir.Enabled = True
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim Dt_Linhas As New DataTable
        Dim I As Int16 = Me.dgvPrecos.Columns("PrEti").Index + 2
        Dim C As Int16
        Dim xModelo As String = ""
        Dim xCor As String = ""
        Dim xPrecoEtiq As Single
        Dim xLinhaID As String = ""
        Dim xTabPreco As String = ""
        Dim xPreco As Single = 0
        Dim xLstPr As Boolean

        Try
            Dt_Linhas = DT_Precos.GetChanges(DataRowState.Modified).Copy
            Me.dgvPrecos.DataSource = Dt_Linhas
            For Each L As DataGridViewRow In Me.dgvPrecos.Rows
                xModelo = L.Cells("Modelo").Value.ToString
                xCor = L.Cells("Cor").Value.ToString
                xPrecoEtiq = L.Cells("PrEti").Value.ToString
                xLinhaID = L.Cells("Linha").Value.ToString
                xLstPr = L.Cells("LstPr").Value

                With Me.dgvPrecos
                    For C = I To .Columns.Count - 1
                        xTabPreco = .Columns(C).Name.ToString.Substring(1, 2)
                        xPreco = L.Cells(C).Value
                        Sql = "EXEC prc_Gestao_Precos_Gravar " & _
                              "@ModeloID = '" & xModelo & "', " & _
                              "@CorID = '" & xCor & "', " & _
                              "@TabPrecoID = '" & xTabPreco & "', " & _
                              "@LinhaID = '" & xLinhaID & "', " & _
                              "@PrecoEtiq = " & xPrecoEtiq & ", " & _
                              "@Preco = " & xPreco & ",  " & _
                              "@LstPr = " & xLstPr & ",  " & _
                              "@OperadorID = '" & xUtilizador & "'"
                        Cmd = New SqlCommand(Sql, cn)
                        If cn.State = ConnectionState.Closed Then cn.Open()
                        Cmd.ExecuteNonQuery()
                    Next
                End With
            Next
            Me.DT_Precos.AcceptChanges()
            If Not Fechar Then IniciarDataGrid()
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name + ": cmdGravar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": cmdGravar_Click")
        Finally
            If Not Cmd Is Nothing Then Cmd.Dispose()
            Cmd = Nothing
            If cn.State = ConnectionState.Open Then cn.Close()
            Dt_Linhas.Clear()
            Dt_Linhas.Dispose()
            Dt_Linhas = Nothing
            I = Nothing
            C = Nothing
            xTabPreco = Nothing
            xModelo = Nothing
            xCor = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            DT_Precos.RejectChanges()
            For Each L As DataGridViewRow In Me.dgvPrecos.Rows
                L.ErrorText = ""
            Next
            Me.cmdCancelar.Enabled = False
            Me.cmdGravar.Enabled = False
            Me.cmdImprimir.Enabled = False
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name + ": cmdGravar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": cmdGravar_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btCopiarTabela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCopiarTabela.Click
        Me.Cursor = Cursors.WaitCursor
        Dim db As New ClsSqlBDados
        Try

            Fechar = False
            If Not DT_Precos.GetChanges Is Nothing Then
                If DT_Precos.GetChanges.Rows.Count > 0 Then
                    If MsgBox("Tem alterações pendentes! Pretende gravar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        cmdGravar_Click(sender, e)
                    Else
                        DT_Precos.RejectChanges()
                    End If
                End If
            End If


            Dim xTabOrigem As String = cbTabOrigem.SelectedValue
            Dim xTabDestino As String = cbTabDestino.SelectedValue

            If MsgBox("Confirma Copiar tabela?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If MsgBox("QUER LIMPAR TODOS OS PREÇOS DA TABELA " & xTabDestino & " ??", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Sql = "DELETE FROM PrecoVenda WHERE TabPrecoID = '" & xTabDestino & "'"
                    Me.Cursor = Cursors.WaitCursor
                    db.ExecuteData(Sql)

                    If xTabOrigem = "00" Then
                        'ESTA PARTE NÃO ESTÁ ATIVA
                        Dim xDesconto As Double = InputBox("Qual o desconto a aplicar?", "Girl", "20") / 100
                        Sql = "INSERT INTO PrecoVenda(ModeloID, CorID, TabPrecoID, Preco, OperadorID) " & _
                        "SELECT MODELOID, CORID, '" & xTabDestino & "', ISNULL(PrVnd * (1-" & xDesconto & "),0), '" & xUtilizador & "' FROM MODELOCOR"
                        db.ExecuteData(Sql)
                    Else
                        Sql = "INSERT INTO PrecoVenda(ModeloID, CorID, TabPrecoID, Preco, OperadorID) " & _
                        "SELECT ModeloID,CorID,'" & xTabDestino & "',Preco,'" & xUtilizador & "' FROM PRECOVENDA WHERE TABPRECOID='" & xTabOrigem & "'"
                        db.ExecuteData(Sql)
                    End If


                Else
                    'VAI REPOR TODOS OS VALORES QUE ESTÃO A ZERO 
                    'E OS VALORES QUE NA TABELA DE ORIGEM SÃO INFERIORES AOS DA TABELA DESTINO!

                    Sql = "INSERT INTO PrecoVenda(ModeloID, CorID, TabPrecoID, Preco, OperadorID) " & _
                        "SELECT ModeloID, CorID, '" & xTabDestino & "' AS TabPrecoID, Preco, '" & xUtilizador & "' AS OperadorID  " & _
                        "FROM PRECOVENDA WHERE MODELOID+CORID NOT IN ( " & _
                        "SELECT PrecoVenda.ModeloID+PrecoVenda.CorID FROM PrecoVenda INNER JOIN PrecoVenda AS PrecoVenda_1 ON PrecoVenda.ModeloID = PrecoVenda_1.ModeloID AND PrecoVenda.CorID = PrecoVenda_1.CorID " & _
                        "WHERE (PrecoVenda.TabPrecoID = '" & xTabOrigem & "') AND (PrecoVenda_1.TabPrecoID = '" & xTabDestino & "')) AND TABPRECOID='" & xTabOrigem & "'"
                    db.ExecuteData(Sql, 100)

                    Sql = "UPDATE PrecoVenda SET  PrecoVenda.preco=TOrig.preco   " & _
                        "FROM PrecoVenda , PrecoVenda AS TOrig WHERE PrecoVenda.modeloid=TOrig.modeloid  " & _
                        "AND PrecoVenda.corid=TOrig.corid AND TOrig.tabprecoid='" & xTabOrigem & "' AND PrecoVenda.tabprecoid='" & xTabDestino & "'  " & _
                        "AND (PrecoVenda.preco=0 OR TOrig.preco<PrecoVenda.preco) AND TOrig.preco>0"
                    db.ExecuteData(Sql, 100)


                End If

                frmGestaoPrecosVenda_Load(sender, e)
                MsgBox("Copia concluida com sucesso!")
                Me.Cursor = Cursors.Default

            Else
                Exit Sub
            End If

        Catch ex As SqlException
            'ErroSQL(ex.Number, ex.Message, Me.Name + ": btCopiarTabela_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": btCopiarTabela_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim xFiltro As String = ""
        Me.Cursor = Cursors.WaitCursor
        Dim db As New ClsSqlBDados


        Try
            Dim RptSelect As String = ""
            xFotoReport = False
            RptSelect = cbReport.SelectedItem

            If RptSelect = "RptTaloes_3x2" Then xFotoReport = True
            If RptSelect = "RptTaloes_8x2" Then xFotoReport = True
            If RptSelect = "RptTaloes_10x4SemTam" Then xFotoReport = False
            If RptSelect = "RptRelTaloes" Then xFotoReport = False
            'If RptSelect = "RptPrecosCFoto" Then xFotoReport = True


            Dim sPath As String = xRptPath & RptSelect & ".xml"
            If Not IO.File.Exists(sPath) Then
                MsgBox("Report não seleccionado")
                Exit Sub
            End If
            If RptSelect = "RptPrecosCFoto" Then
                'Dim I As Integer
                'For I = 0 To dgvPrecos.Rows.Count - 1
                '    xFiltro += "'" + dgvPrecos("Modelo", I).Value.ToString + dgvPrecos("Cor", I).Value.ToString + "',"
                'Next
            Else

                For Each r As DataRow In DT_Precos.Select("Prt = true")
                    xFiltro += "'" + r("Modelo").ToString + r("Cor").ToString + "',"
                Next

            End If


            If Len(xFiltro) > 0 Then
                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)
                frmRpt = New frmReport



                With frmRpt

                    .StartPosition = FormStartPosition.CenterScreen

                    Sql = "SELECT S.SerieID, M.GrupoID, M.TipoID, S.ModeloID, S.CorID, S.TamID, C.ModCorDescr, S.PrecoEtiqueta, S.ModeloID + S.CorID Foto, L.DescrLinha, S.Obs " & _
                       "FROM Serie S, Modelos M, ModeloCor C, Linhas L " & _
                       "WHERE (S.ModeloID = M.ModeloID) AND S.ModeloID = C.ModeloID AND S.CorID = C.CorID AND M.LinhaID = L.LinhaID AND (S.ModeloID+S.CorID IN (" & xFiltro & ") AND S.EstadoID in ('S','T')) " & _
                       "ORDER BY S.ModeloID, S.CorID, S.TamID"

                    .C1RptTaloes.Load(xRptPath & RptSelect & ".xml", "Talões")
                    .C1RptTaloes.DataSource.ConnectionString = sconnectionstringReport
                    .C1RptTaloes.DataSource.RecordSource = Sql

                    JustPrint(.C1RptTaloes)

                End With


                Me.WindowState = FormWindowState.Minimized
            Else
                MsgBox("NÃO TEM NADA SELECCIONADO", MsgBoxStyle.Information)
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": cmdImprimir_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": cmdImprimir_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
            xFiltro = Nothing
        End Try
    End Sub

    Private Sub btListaTabPUnico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListaTabPUnico.Click
        Me.Cursor = Cursors.WaitCursor
        Dim db As New ClsSqlBDados
        Dim xFiltro As String = ""

        Try
            frmRpt = New frmReport

            xFotoReport = True

            Dim I As Integer
            For I = 0 To dgvPrecos.Rows.Count - 1
                xFiltro += "'" + dgvPrecos("Modelo", I).Value.ToString + dgvPrecos("Cor", I).Value.ToString + "',"
            Next
            If Len(xFiltro) > 0 Then
                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)
                frmRpt = New frmReport


                With frmRpt
                    '.MdiParent = frmMenuGirl
                    .StartPosition = FormStartPosition.CenterScreen

                    Sql = "SELECT PrecoVenda.Preco, PrecoVenda.ModeloID + '-' + PrecoVenda.CorID ModelosCor, PrecoVenda.ModeloID + PrecoVenda.CorID Foto " &
                      "FROM ModeloCor INNER JOIN PrecoVenda ON ModeloCor.ModeloID = PrecoVenda.ModeloID " &
                      "AND ModeloCor.CorID = PrecoVenda.CorID INNER JOIN Serie ON ModeloCor.ModeloID = Serie.ModeloID " &
                      "AND ModeloCor.CorID = Serie.CorID WHERE (PrecoVenda.TabPrecoID = '" & cbTabOrigem.SelectedValue & "') " &
                      "AND PrecoVenda.ModeloID+PrecoVenda.CorID IN (" & xFiltro & ") " &
                      "GROUP BY PrecoVenda.ModeloID, PrecoVenda.CorID, PrecoVenda.Preco " &
                      "ORDER BY PrecoVenda.Preco, PrecoVenda.ModeloID, PrecoVenda.CorID"


                    .C1RptTaloes.Load(xRptPath & "RptPrecosCFoto.xml", "Precos")
                    .C1RptTaloes.DataSource.ConnectionString = sconnectionstringReport
                    .C1RptTaloes.DataSource.RecordSource = Sql


                    '.C1PrtPreview.Document = .C1RptTaloes.Document
                    '.Show()


                    JustPrint(.C1RptTaloes)



                    'Sql = "SELECT PrecoVenda.Preco, PrecoVenda.ModeloID + '-' + PrecoVenda.CorID ModelosCor " & _
                    '"FROM ModeloCor INNER JOIN PrecoVenda ON ModeloCor.ModeloID = PrecoVenda.ModeloID " & _
                    '"AND ModeloCor.CorID = PrecoVenda.CorID INNER JOIN Serie ON ModeloCor.ModeloID = Serie.ModeloID " & _
                    '"AND ModeloCor.CorID = Serie.CorID WHERE (PrecoVenda.TabPrecoID = '" & cbTabOrigem.SelectedValue & "') AND (ModeloCor.LstPr = 1) " & _
                    '"AND (Serie.ArmazemID = '" & xArmz & "') AND (Serie.EstadoID = 'S') " & _
                    '"GROUP BY PrecoVenda.ModeloID, PrecoVenda.CorID, PrecoVenda.Preco " & _
                    '"ORDER BY PrecoVenda.Preco, PrecoVenda.ModeloID, PrecoVenda.CorID"
                    '.C1RptTaloes.Load(xRptPath & "RptPrecosUnicos.xml", "PrecosUnicos")
                    '.C1RptTaloes.DataSource.ConnectionString = sconnectionstringReport
                    '.C1RptTaloes.DataSource.RecordSource = Sql
                    '.C1PrtPreview.Document = .C1RptTaloes.Document
                    '.Show()

                End With
                Me.WindowState = FormWindowState.Maximized

            Else
                MsgBox("NÃO TEM NADA SELECCIONADO", MsgBoxStyle.Information)
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": btListaTabPUnico_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": btListaTabPUnico_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrecos.CellDoubleClick
        Try

            If xAplicacao = "BACKOFFICE" Or xGrupoAcesso = "ADMIN" Then

                If xLinaActual >= 0 Then

                    frmStockLoja.xModelo = Me.dgvPrecos("Modelo", xLinaActual).Value
                    frmStockLoja.xCor = Me.dgvPrecos("Cor", xLinaActual).Value
                    frmStockLoja.StartPosition = FormStartPosition.CenterParent
                    frmStockLoja.WindowState = FormWindowState.Normal
                    frmStockLoja.ShowInTaskbar = False
                    frmStockLoja.MaximizeBox = False
                    frmStockLoja.MinimizeBox = False
                    frmStockLoja.ShowDialog(Me)

                End If
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DataGridView1_CellDoubleClick")
        Catch ex As Exception
            ErroVB(ex.Message, "DataGridView1_CellDoubleClick")

        End Try


    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrecos.RowEnter

        Try
            xLinaActual = e.RowIndex

        Catch ex As Exception
            ErroVB(ex.Message, "frmGestaoPrecosVenda_KeyPress")
        End Try

    End Sub












End Class