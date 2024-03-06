

Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid




'Imports C1.Win.C1FlexGrid
'Imports C1.Win.C1TrueDBGrid


Public Class frmStockLoja

    Friend xModelo As String
    Friend xCor As String
    Dim CarregarFoto As New ClsFotos
    Dim dtEnc As New DataTable
    Dim dtforn As New DataTable
    Dim xGrupo As String
    Dim xTipo As String
    Dim xAltura As String
    Dim xLinha As String
    Dim xModCorDesc As String
    Dim xPrEtiq As Double
    Dim xPrCusto As Double
    Dim xPrVnd As Double
    Dim xRefForn As String
    Dim xCorForn As String
    Dim xObs As String
    Dim xObsEnc As String
    Dim xFornId As String
    Dim xValor As Integer = 0
    Dim xOrigem As String = ""
    Dim xTamTransf As String = ""
    Dim xTalao As String = ""
    Dim xLnTranf As Integer
    Dim xColTranf As Integer
    Dim xDestino As String = ""
    Dim xArmzAux As String
    Dim dtCores As New DataTable
    Dim xCorBase As String
    Dim I As Int16 = 0
    Dim sAuxPesquisa As String = "I"
    Dim sIdReservas As String





    'EVENTOS NO FORM

    Private Sub frmStockLoja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim db As New ClsSqlBDados
        Dim iCorLinha As Int16 = 0
        dtCores.Clear()

        cbIncReservas.Checked = True
        cbVerDetalhe.Checked = False
        lbPr.Visible = False


        xCorBase = xCor
        Sql = "SELECT CORID, 0 as Linha FROM MODELOCOR WHERE MODELOID='" & xModelo & "' ORDER BY CORID ASC"
        db.GetData(Sql, dtCores, False)

        For Each r As DataRow In dtCores.Rows
            iCorLinha += 1
            dtCores.Rows(iCorLinha - 1)("Linha") = iCorLinha
            If r("CorID") = xCor Then
                I = iCorLinha
            End If
        Next

        btUP.BackColor = Color.FromName("Control")
        btDown.BackColor = Color.FromName("Control")
        btUP.Enabled = True
        btDown.Enabled = True

        If I = dtCores.Compute("MAX(Linha)", "") Then
            btUP.BackColor = Color.Red
            btUP.Enabled = False
        End If

        If I = dtCores.Compute("MIN(Linha)", "") Then
            btDown.BackColor = Color.Red
            btDown.Enabled = False
        End If

        'SE ATRAI SÓ VAI MOSTRAR O DETALHE E ESCONDER TODO O CABEÇALHO....
        If bAtrai = True Then
            Panel1.Dock = DockStyle.Fill
        Else
            Panel1.Dock = DockStyle.Bottom
        End If

        ActualizaDetalhe()


    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub CmdConfEnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConfEnc.Click
        Try


            If Not Me.C1FgEnc(1, "Total") Is DBNull.Value Then
                If Me.C1FgEnc(1, "Total") > 0 Then

                    If Len(Trim(Me.txtRefForn.Text)) = 0 Then
                        MsgBox("Falta a refª do Fornecedor!")
                        Exit Sub
                    End If

                    If Len(Trim(Me.txtCorForn.Text)) = 0 Then
                        MsgBox("Falta a Cor do Fornecedor!")
                        Exit Sub
                    End If

                    If Val(txtPrCusto.Text) <= 0 Then
                        MsgBox("Falta o Preço do Fornecedor!")
                        Exit Sub
                    End If

                    If Len(Trim((txtPrCusto.Text))) = 0 Then txtPrCusto.Text = "0"

                    If cn.State = ConnectionState.Closed Then cn.Open()
                    Sql = "SELECT MAX(NrEnc) NrEnc FROM Encomendas WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "'"
                    Cmd = New SqlCommand(Sql, cn)
                    If Not Cmd.ExecuteScalar Is DBNull.Value Then
                        xNumero = Cmd.ExecuteScalar
                        If xNumero.ToString.Substring(0, 4) <> Year(Today) Then
                            xNumero = Year(Today) & "0000"
                        End If
                    Else
                        xNumero = Year(Today) & "0000"
                    End If

                    Dim Incrementar As Integer = Microsoft.VisualBasic.Right(xNumero, 4)
                    Incrementar += 1
                    xNumero = xNumero.Substring(0, 4) & Format(Incrementar, "0000")

                End If

                Dim xNrEnc As String = xNumero
                Dim xForn As String = Me.CbForn.SelectedValue
                Dim txtRefForn As String = Me.txtRefForn.Text
                Dim txtCorForn As String = Me.txtCorForn.Text
                Dim xPrCusto As Double = Me.txtPrCusto.Text
                Dim xDtEnt As String = Format(CDate(Me.txtDtEnt.Text), "yyyy-MM-dd")
                Dim xObs As String = Me.txtObs.Text

                Dim xData As String = Format(Now, "yyyy-MM-dd")

                'Dim xEncPend As Int32 = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "EncPend")

                If xArmz <> "0000" Then
                    'DESCOBRIR PORQUE É QUE POR VEZES NÃO COLOCA O ARM 0000 NAS ENCOMENDAS
                    MsgBox("ARMAZEM " & xArmz & " ERR0!")
                    Application.Exit()
                End If

                Sql = "INSERT INTO Encomendas (EmpresaID, ArmazemID, NrEnc, LnEnc, FornId, RefForn, CorForn, PrCusto, " & _
                    "DtEntrega, GrupoID, TipoID, Altura, ModeloID, CorID, LinhaID, ModCorDescr, PrecoEtiqueta, Obs, " & _
                    "EstadoEnc, TGerado, DataDoc, OperadorID) " & _
                    "VALUES('" & xEmp & "','" & xArmz & "','" & xNrEnc & "',1,'" & xForn & "','" & txtRefForn & "', " & _
                    "'" & txtCorForn & "','" & xPrCusto & "','" & xDtEnt & "','" & xGrupo & "','" & xTipo & "', " & _
                    "'" & xAltura & "','" & xModelo & "','" & xCor & "','" & xLinha & "','" & xModCorDesc & "', " & _
                    "'" & xPrEtiq & "','" & xObs & "','P','0','" & xData & "','" & xUtilizador & "') "
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd.ExecuteNonQuery()

                Dim I As Int16
                Dim QtdCol As Int16 = Me.C1FgEnc.Cols.Count - 1
                Dim QtdTot As Int32
                For I = 0 To QtdCol - 1
                    If Not Me.C1FgEnc(1, I) Is DBNull.Value Then
                        If Me.C1FgEnc(1, I) <> 0 Then
                            Sql = "INSERT INTO EncDetTam(EmpresaID, ArmazemID, NrEnc, LnEnc, TamID, Qtd) " & _
                                  "VALUES('" & xEmp & "', '" & xArmz & "', '" & xNrEnc & "', 1, '" & Me.C1FgEnc(0, I) & "', '" & Me.C1FgEnc(1, I) & "')"
                            Cmd = New SqlCommand(Sql, cn)
                            If cn.State = ConnectionState.Closed Then cn.Open()
                            Cmd.ExecuteNonQuery()
                            cn.Close()
                            QtdTot += Me.C1FgEnc(1, I)
                        End If
                    End If
                Next

                For I = 0 To QtdCol
                    Me.C1FgEnc(1, I) = DBNull.Value
                Next

                'Me.C1DgridCab(Me.C1DgridCab.Bookmark, "EncPend") = xEncPend + QtdTot
                Me.txtObs.Clear()
                Me.txtRefForn.Clear()
                Me.txtCorForn.Clear()
                Me.txtPrCusto.Clear()
                ActualizaDetalhe()

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CmdConfEnc_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "CmdConfEnc_Click")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub C1FgEnc_AfterRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles C1FgEnc.AfterRowColChange
        Try


            If Me.C1FgEnc(0, Me.C1FgEnc.Cols.Count - 1) = "Total" Then
                Dim Coluna As Integer
                Dim Somatorio As Integer = 0
                For Coluna = 0 To Me.C1FgEnc.Cols.Count - 2
                    If IsNumeric(Me.C1FgEnc(1, Coluna)) Then
                        Somatorio += Me.C1FgEnc(1, Coluna)
                    End If
                Next
                If Somatorio > 0 Then
                    Me.C1FgEnc(1, Me.C1FgEnc.Cols.Count - 1) = Somatorio
                    Me.C1FgEnc.Cols(Me.C1FgEnc.Cols.Count - 1).AllowEditing = False
                End If
            End If

        Catch ex As Exception

            ErroVB(ex.Message, "C1FgEnc_AfterRowColChange")

        End Try

    End Sub

    Private Sub cbVerDetalhe_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerDetalhe.CheckedChanged
        Try
            If cbVerDetalhe.Checked = True Then

                txtPrCusto.Text = xPrCusto
                txtRefForn.Text = xRefForn
                txtCorForn.Text = xCorForn
                txtObs.Text = xObs
                'txtObs.Text = xObsEnc
                lbObsOrig.Text = xObsEnc

                CbForn.SelectedValue = xFornId

                If CbForn.SelectedValue <> xFornId Then
                    CbForn.SelectedValue = "2000"
                End If

                'If CbForn.Items.Contains(xFornId) Then
                '        CbForn.SelectedValue = xFornId
                '    Else
                '        CbForn.SelectedValue = "2000"
                '    End If
                '    'If xFornId = "2000" Then MsgBox("2000")
            Else

                txtPrCusto.Text = ""
                txtRefForn.Text = ""
                txtCorForn.Text = ""
                txtObs.Text = ""
                lbObsOrig.Text = ""
                CbForn.SelectedValue = "2000"

            End If

        Catch ex As Exception
            ErroVB(ex.Message, "cbVerDetalhe_CheckedChanged")
        End Try

    End Sub

    Private Sub txtPrCusto_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrCusto.MouseHover
        lbPr.Visible = True
    End Sub

    Private Sub txtPrCusto_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrCusto.MouseLeave
        lbPr.Visible = False
    End Sub

    Private Sub cbIncReservas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIncReservas.CheckedChanged
        ActualizaDetalhe()
    End Sub

    Private Sub btUP_Click(sender As System.Object, e As System.EventArgs) Handles btUP.Click

        btDown.BackColor = Color.FromName("Control")
        btDown.Enabled = True
        I = I + 1
        If I = dtCores.Compute("MAX(Linha)", "") Then
            btUP.BackColor = Color.Red
            btUP.Enabled = False
        End If
        xCor = dtCores.Compute("MIN(CORID)", "Linha=" & I & "")
        ActualizaDetalhe()





        'I = I + 1




        'If btDown.BackColor = Color.Red Then
        '    I = I + 1
        'End If

        'btDown.BackColor = Color.FromName("Control")
        'If sAuxPesquisa = "I" Then
        '    I = dtCores.Rows.Count
        '    sAuxPesquisa = ""
        'End If
        'If I >= dtCores.Rows.Count Then
        '    btUP.BackColor = Color.Red
        '    btUP.Enabled = False
        'End If

        'For Each r As DataRow In dtCores.Rows
        '    If r("Linha") = I Then
        '        If xCor <> r("CORID") Then
        '            xCor = r("CORID")
        '            ActualizaDetalhe()
        '        End If
        '    End If
        'Next

        'If I <> dtCores.Rows.Count Then
        '    I = I + 1
        'End If

        'btDown.Enabled = True

    End Sub

    Private Sub btDown_Click(sender As System.Object, e As System.EventArgs) Handles btDown.Click

        btUP.BackColor = Color.FromName("Control")
        btUP.Enabled = True
        I = I - 1
        If I = dtCores.Compute("MIN(Linha)", "") Then
            btDown.BackColor = Color.Red
            btDown.Enabled = False
        End If
        xCor = dtCores.Compute("MIN(CORID)", "Linha=" & I & "")
        ActualizaDetalhe()

    End Sub

    Private Sub btAnular_Click(sender As System.Object, e As System.EventArgs) Handles btAnular.Click

        Dim db As New ClsSqlBDados

        Try

            Sql = "DELETE FROM Reservas WHERE IDReservas='" & sIdReservas & "'"
            db.ExecuteData(Sql)

            ActualizaDetalhe()


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btAnular_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btAnular_Click")
        Finally
            db = Nothing
        End Try


    End Sub




    'EVENTOS NA CFGDet

    Private Sub CFGDet_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CFGDet.MouseMove
        Try

            Dim tip As String
            If CFGDet.MouseRow > 0 And CFGDet.MouseCol > 0 Then
                tip = Me.CFGDet.GetUserData(CFGDet.MouseRow, CFGDet.MouseCol)
                ToolTip1.SetToolTip(CFGDet, tip)
            End If

        Catch ex As Exception

        End Try


    End Sub

    'VAI FAZER AS TRANSFERÊNCIAS

    Private Sub CFGDet_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CFGDet.MouseDown

        Dim db As New ClsSqlBDados

        Try


            If bAtrai = True Then
                Exit Try
            End If

            If Me.CFGDet.Col() > 4 Then
                If ((Me.CFGDet(Me.CFGDet.Row(), 1) >= "0000" And Me.CFGDet(Me.CFGDet.Row(), 1) <= "9999") Or (Me.CFGDet(Me.CFGDet.Row(), 1) >= "EC")) Then

                    If xValor = 0 Then

                        'VAI RETIRAR DO STOCK 
                        If Not Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) Is DBNull.Value Then
                            If Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) > 0 Then

                                xOrigem = Me.CFGDet(Me.CFGDet.Row(), ("ArmazemID"))
                                xTamTransf = Me.CFGDet.Cols(Me.CFGDet.Col()).Name


                                If ActualizaLigacao("Girl") = False Then Exit Try

                                If xOrigem = "EC" Then
                                    Sql = "SELECT COUNT(*) FROM SERIE WHERE ARMAZEMID = '0000' AND MODELOID='" & xModelo & "' AND CORID='" & xCor & "' AND TAMID='" & xTamTransf & "'AND ESTADOID IN ('G')"
                                Else
                                    Sql = "SELECT COUNT(*) FROM SERIE WHERE ARMAZEMID = '" & xOrigem & "' AND MODELOID='" & xModelo & "' AND CORID='" & xCor & "' AND TAMID='" & xTamTransf & "'AND ESTADOID IN ('S')"
                                End If
                                If db.GetDataValue(Sql) > 0 Then

                                    If xOrigem = "EC" Then
                                        Sql = "SELECT  ISNULL(MIN(Serie.SerieID),'') " &
                                        "FROM Serie LEFT OUTER JOIN Reservas ON Serie.SerieID = Reservas.ReservaSerieID " &
                                        "WHERE (Serie.ArmazemID = '0000') AND (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.TamID = '" & xTamTransf & "')  " &
                                        "AND (Serie.EstadoID IN ('G')) AND (Reservas.ReservaSerieID IS NULL) "
                                        xOrigem = "0000"
                                    Else
                                        Sql = "SELECT RESERVASERIEID INTO #RESERVAS FROM RESERVAS WHERE RESERVAESTADO='0'; " &
                                        "SELECT  ISNULL(MIN(Serie.SerieID),'') " &
                                        "FROM Serie LEFT OUTER JOIN #RESERVAS ON Serie.SerieID = #RESERVAS.ReservaSerieID " &
                                        "WHERE (Serie.ArmazemID = '" & xOrigem & "') AND (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.TamID = '" & xTamTransf & "')  " &
                                        "AND (Serie.EstadoID IN ('S')) AND (#RESERVAS.ReservaSerieID IS NULL) " &
                                        "AND SERIEID NOT IN (SELECT SERIEID FROM DOCDET WHERE TIPODOCID='SE' AND  EstadoLn='G'); " &
                                        "DROP TABLE #RESERVAS;"
                                    End If
                                    xTalao = db.GetDataValue(Sql)
                                    If Len(xTalao) <> 8 Then
                                        MsgBox("Stock Reservado!")
                                        xValor = 0
                                        Exit Sub
                                    Else
                                        xTalao = db.GetDataValue(Sql)
                                    End If
                                Else
                                    MsgBox("Stock Indisponivel!!")
                                    xValor = 0
                                    Exit Sub

                                End If

                                If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")

                                xValor = Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col())
                                xLnTranf = Me.CFGDet.Row.ToString
                                xColTranf = Me.CFGDet.Col.ToString
                                Me.CFGDet.GetCellStyleDisplay(xLnTranf, xColTranf).Border.Style = BorderStyleEnum.Double
                                Me.CFGDet.GetCellStyleDisplay(xLnTranf, xColTranf).Border.Color = Color.DarkRed
                            Else
                                MsgBox("Sem Stock para Transferir !")
                                xValor = 0
                                Exit Sub
                            End If
                        End If
                    ElseIf xValor > 0 Then
                        If Me.CFGDet.Cols(Me.CFGDet.Col()).Name = xTamTransf And (Me.CFGDet(Me.CFGDet.Row(), 1) >= "0000" And Me.CFGDet(Me.CFGDet.Row(), 1) <= "9999") Then
                            'VAI COLOCAR NO STOCK DA LOJA
                            If Not Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) Is DBNull.Value Then
                                xValor = 1 + Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col())
                                Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) = xValor
                            Else
                                Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) = 1
                            End If
                            Me.CFGDet(xLnTranf, xColTranf) = Me.CFGDet(xLnTranf, xColTranf) - 1
                            xDestino = Me.CFGDet(Me.CFGDet.Row(), ("ArmazemID"))
                            If xDestino = xOrigem Then
                            Else

                                If ActualizaLigacao("Girl") = False Then Exit Try
                                sIdReservas = Guid.NewGuid.ToString


                                Sql = "INSERT INTO Reservas(ArmazemID, ArmzDest, ReservaDescr, ReservaSerieId, ReservaModeloId,ReservaCorId, " &
                                    "ReservaTamId,ReservaData,ReservaEstado, IDReservas, OperadorID) " &
                                    "VALUES('" & xOrigem & "', '" & xDestino & "', 'Transferir','" & xTalao & "', '" & xModelo & "','" & xCor & "','" & xTamTransf & "',GETDATE(),'0','" & sIdReservas & "','" & xUtilizador & "')"
                                db.ExecuteData(Sql)



                                'INSERIR DESCRITIVO PARA A RECEPÇÃO
                                Sql = "UPDATE Serie SET Obs1 = 'Transferir C-" & xDestino & "' WHERE SERIEID='" & xTalao & "'"
                                db.ExecuteData(Sql)

                                If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")

                                xValor = 0
                                xTalao = ""
                            End If
                        Else
                            MsgBox("Tamanho Errado!")
                            xValor = 0
                            xTalao = ""
                        End If
                    End If
                Else
                    If xValor <> 0 Then MsgBox("CELULA ERRADA!")
                    xValor = 0
                    xTalao = ""
                End If
            Else

                xValor = 0

            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CFGDet_MouseDown")
        Catch ex As Exception
            ErroVB(ex.Message, "CFGDet_MouseDown")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")

        End Try
    End Sub


    'FUNÇÕES

    Private Sub ActualizaDetalhe()

        Dim db As New ClsSqlBDados
        Dim dtAuxEnc As New DataTable
        Dim dttips As New DataTable
        Dim xtip As String = ""


        Try

            'ESTES DADOS ESTAVAM NO LOAD
            PictureBox.Image = Nothing
            PictureBox.Visible = False
            CarregarFoto.CarregarFotoModeloCor(Me.PictureBox, xModelo & xCor, "xok")




            Me.Cursor = Cursors.WaitCursor
            Me.CFGDet.Visible = False
            Application.DoEvents()


            'Sql = "SELECT ModCorDescr FROM ModeloCor WHERE ModeloID = '" & xModelo & "' AND CorID = '" & xCor & "' "
            'lbArtigo.Text = xModelo + "-" + xCor + " : " + db.GetDataValue(Sql)
            Sql = "SELECT Modelos.TipoID + '-' + ModeloCor.ModeloID + '-' + ModeloCor.CorID + ' - ' + ModeloCor.ModCorDescr AS ModCorDescr, ModeloCor.ModCorDescr AS Expr1 FROM ModeloCor INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID WHERE (ModeloCor.ModeloID = '" & xModelo & "') AND (ModeloCor.CorID = '" & xCor & "')"
            lbArtigo.Text = db.GetDataValue(Sql)

            Dim dtDet As New DataTable

            Dim xIncReservas As Integer = 0
            'If xUtilizador = "Jose Guedes" Then xIncReservas = 1
            If cbIncReservas.Checked = True Then xIncReservas = 1

            Sql = "EXEC prc_TransfDet @ModeloID = '" & xModelo & "', @CorID = '" & xCor & "', @IncReservas='" & xIncReservas & "'"

            'Vou correr o procedimento duas vezes porque se correr só uma vez vai  buscar os valores anteriores
            'Não consegui resolver de outra forma.......
            db.ExecuteData(Sql)
            db.GetData(Sql, dtDet, False)

            'CARREGAR TABELA dttips
            'Sql = "SELECT ISNULL(DocCab.TercID,Serie.ArmazemID) AS ArmzVirtual, Serie.TamID, Serie.SerieID AS Talão, Serie.EstadoID +'/'+ Serie.ArmazemID Estado " & _
            '      "FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND  " & _
            '      "DocCab.DocNr = DocDet.DocNr RIGHT OUTER JOIN Serie ON DocDet.SerieID = Serie.SerieID AND DocDet.TipoDocID = 'SE' AND DocDet.EstadoLn = 'G' " & _
            '      "WHERE (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.EstadoID IN ('S', 'T')) " & _
            '      "ORDER BY ArmzVirtual, Serie.TamID"

            Sql = "SELECT ISNULL(DocCab.TercID, Serie.ArmazemID) AS ArmzVirtual, Serie.TamID, Serie.SerieID AS Talão, Serie.EstadoID + '/' + Serie.ArmazemID AS Estado, Serie.Obs1 FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr RIGHT OUTER JOIN Serie ON DocDet.SerieID = Serie.SerieID AND DocDet.TipoDocID = 'SE' AND DocDet.EstadoLn = 'G' WHERE (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.EstadoID IN ('S', 'T')) ORDER BY ArmzVirtual, Serie.TamID"

            dttips.Clear()
            db.GetData(Sql, dttips, False)

            With Me.CFGDet
                .DataSource = dtDet
                Dim I, J As Integer
                For I = 1 To CFGDet.Rows.Count - 1
                    For J = 3 To CFGDet.Cols.Count - 1
                        If CFGDet(I, J).ToString = "0" Or CFGDet(I, J).ToString = "0.0" Then CFGDet(I, J) = DBNull.Value
                        Me.CFGDet.Cols(J).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                        'PREENCHER TIPS
                        If dttips.Rows.Count > 0 _
                        And Me.CFGDet.Cols(J).Name <> "Cod" _
                        And Me.CFGDet.Cols(J).Name <> "Armazem" _
                        And Me.CFGDet.Cols(J).Name <> "Vnd" _
                        And CFGDet(I, 1).ToString <> "VndP" Then
                            For Each linha As DataRow In dttips.Rows
                                If linha("ArmzVirtual") = Me.CFGDet(I, 1).ToString And linha("TamID") = Me.CFGDet.Cols(J).Name Then
                                    'xtip = linha("Talão") & " - " & linha("Estado") & Chr(13) & xtip
                                    xtip = linha("Talão") & " - " & linha("Estado") & "  " & linha("Obs1") & Chr(13) & xtip
                                End If
                            Next
                            Me.CFGDet.SetUserData(I, J, xtip)
                            xtip = ""
                        End If
                        'FIM PREENCHER TIPS
                    Next
                    If Len(Trim(CFGDet(I, "Vnd").ToString)) = 0 And Trim(CFGDet(I, "ArmazemID").ToString) > "0000" Then
                        xArmzAux = CFGDet(I, "ArmazemID").ToString
                        Sql = "SELECT COUNT(*) FROM DOCDET WHERE EMPRESAID='" & xEmp & "' AND ARMAZEMID = '" & xArmzAux & "' AND TIPODOCID='RC' AND MODELOID='" & xModelo & "' AND CORID='" & xCor & "' GROUP BY ArmazemID"
                        If db.GetDataValue(Sql) > 0 Then
                            CFGDet(I, "Vnd") = "0"
                        End If
                    End If


                Next
                .Cols("ArmazemID").Caption = "Cod"
                .Cols("ArmAbrev").Caption = "Armazem"

                .AllowEditing = False
                .AutoResize = True
                .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None

                .AutoSizeCols()
                Dim LarguraTotalColunas As Double = 0
                Dim AlturaTotalLinhas As Double = 0
                AlturaTotalLinhas = .Rows(0).HeightDisplay * CFGDet.Rows.Count


                For I = 0 To CFGDet.Cols.Count - 1
                    If .Cols(I).Visible = True Then
                        LarguraTotalColunas += .Cols(I).WidthDisplay
                    End If
                Next
                .Width = LarguraTotalColunas * 1.05
                .Height = AlturaTotalLinhas * 1.05
            End With


            'PREENCHER GRELHA PARA ENCOMENDA
            dtEnc = dtDet.Copy
            With dtEnc
                .Clear()
                .Columns.Remove("ArmazemID")
                .Columns.Remove("ArmAbrev")
                .Columns.Remove("VND")
                .Columns.Remove("VndP")
                .Columns.Add("Total")
            End With
            Dim dr As DataRow = dtEnc.NewRow()
            dtEnc.Rows.Add(dr)

            With Me.C1FgEnc
                .DataSource = dtEnc
                .ScrollBars = ScrollBars.None
                .Cols.Fixed = 0
                If .Cols.Count() > 0 Then
                    Dim Largura As Double = .Cols(0).Width * .Cols.Count()
                    .Width = Largura * 1.1 + 10
                End If
                .AllowResizing = AllowResizingEnum.None
                .AllowSorting = AllowSortingEnum.None
                .AllowDragging = AllowDraggingEnum.None
            End With


            'Sql = "SELECT ISNULL(PVndReal,0) FROM Serie WHERE DtSaida = (SELECT MAX(DtSaida)  FROM SERIE  WHERE EstadoID IN ('V', 'R')  AND ModeloID = '" & xModelo & "'  AND CorID = '" & xCor & "')"

            'ESTE QUERY GARANTE QUE SE HOUVER DOIS MOVIMENTOS COM A MESMA DATA VAI BUSCAR O CERTO.
            Sql = "SELECT ISNULL(PVndReal, 0) AS Expr1 FROM Serie WHERE  DtSaida = (SELECT MAX(DtSaida) AS Expr1 FROM Serie WHERE (EstadoID IN ('V','R','F')) AND (ModeloID = '" & xModelo & "') AND (CorID = '" & xCor & "')) AND EstadoID IN ('V', 'R') AND ModeloID = '" & xModelo & "'  AND CorID = '" & xCor & "'"

            'ESTE QUERY VAI BUSCAR O ULTIMO VALOR DE VENDA PELOS DOCUMENTOS
            'Sql = "SELECT DocDet.Valor FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.ModeloID = '07955') AND (DocDet.CorID = '14') AND (DocDet.TipoDocID = 'RE' OR DocDet.TipoDocID = 'FS') AND (DocCab.DataDoc = (SELECT MAX(DocCab_1.DataDoc) AS Data FROM DocDet AS DocDet_1 INNER JOIN DocCab AS DocCab_1 ON DocDet_1.EmpresaID = DocCab_1.EmpresaID AND DocDet_1.ArmazemID = DocCab_1.ArmazemID AND DocDet_1.TipoDocID = DocCab_1.TipoDocID AND DocDet_1.DocNr = DocCab_1.DocNr WHERE (DocDet_1.ModeloID = '07955') AND (DocDet_1.CorID = '14') AND (DocDet_1.TipoDocID = 'RE' OR DocDet_1.TipoDocID = 'FS')))"

            Dim dUltPrVnd As Double = db.GetDataValue(Sql)


            'Sql = "SELECT Modelos.GrupoID, Modelos.TipoID, Modelos.Altura, Modelos.LinhaID, ModeloCor.ModCorDescr, ModeloCor.PrCusto, ModeloCor.FornID, ModeloCor.RefForn, ModeloCor.CorForn, ModeloCor.PrVnd, ModeloCor.Obs FROM ModeloCor INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID WHERE ModeloCor.ModeloID = '" & xModelo & "' AND ModeloCor.CorID = '" & xCor & "'"
            Sql = "SELECT Modelos.GrupoID, Modelos.TipoID, Modelos.Altura, Modelos.LinhaID, ModeloCor.ModCorDescr, ModeloCor.PrCusto, ModeloCor.FornID, ModeloCor.RefForn, ModeloCor.CorForn, ModeloCor.PrVnd, ModeloCor.Obs, Encomendas.Obs AS ObsEnc FROM ModeloCor INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID LEFT OUTER JOIN Encomendas ON ModeloCor.ModeloID = Encomendas.ModeloID AND ModeloCor.CorID = Encomendas.CorID WHERE (ModeloCor.ModeloID = '" & xModelo & "') AND (ModeloCor.CorID = '" & xCor & "') GROUP BY Modelos.GrupoID, Modelos.TipoID, Modelos.Altura, Modelos.LinhaID, ModeloCor.ModCorDescr, ModeloCor.PrCusto, ModeloCor.FornID, ModeloCor.RefForn, ModeloCor.CorForn, ModeloCor.PrVnd, ModeloCor.Obs, Encomendas.Obs"
            db.GetData(Sql, dtAuxEnc)

            xGrupo = IIf(dtAuxEnc.Rows(0)("GrupoID") Is DBNull.Value, "", dtAuxEnc.Rows(0)("GrupoID"))
            xTipo = IIf(dtAuxEnc.Rows(0)("TipoID") Is DBNull.Value, "", dtAuxEnc.Rows(0)("TipoID"))
            xAltura = IIf(dtAuxEnc.Rows(0)("Altura") Is DBNull.Value, "", dtAuxEnc.Rows(0)("Altura"))
            xLinha = IIf(dtAuxEnc.Rows(0)("LinhaID") Is DBNull.Value, "", dtAuxEnc.Rows(0)("LinhaID"))
            xModCorDesc = IIf(dtAuxEnc.Rows(0)("ModCorDescr") Is DBNull.Value, "", dtAuxEnc.Rows(0)("ModCorDescr"))
            xPrEtiq = IIf(dtAuxEnc.Rows(0)("PrVnd") Is DBNull.Value, 0, dtAuxEnc.Rows(0)("PrVnd"))

            xPrCusto = IIf(dtAuxEnc.Rows(0)("PrCusto") Is DBNull.Value, 0, dtAuxEnc.Rows(0)("PrCusto"))
            xRefForn = IIf(dtAuxEnc.Rows(0)("RefForn") Is DBNull.Value, "", dtAuxEnc.Rows(0)("RefForn"))
            xCorForn = IIf(dtAuxEnc.Rows(0)("CorForn") Is DBNull.Value, "", dtAuxEnc.Rows(0)("CorForn"))
            xObs = IIf(dtAuxEnc.Rows(0)("Obs") Is DBNull.Value, "", dtAuxEnc.Rows(0)("Obs"))
            xObsEnc = IIf(dtAuxEnc.Rows(0)("ObsEnc") Is DBNull.Value, "", dtAuxEnc.Rows(0)("ObsEnc"))
            xFornId = IIf(dtAuxEnc.Rows(0)("FornID") Is DBNull.Value, "", dtAuxEnc.Rows(0)("FornID"))
            txtDtEnt.Text = Today().AddDays(10)

            xPrVnd = IIf(dtAuxEnc.Rows(0)("PrVnd") Is DBNull.Value, 0, dtAuxEnc.Rows(0)("PrVnd"))


            dtforn.Clear()


            'Sql = "SELECT TercID, RTRIM(TercID) + ' - ' + RTRIM(NomeAbrev) + '   ' + ISNULL(RTRIM(Telefone),'') AS FornDesc FROM Terceiros where TipoTerc='F' ORDER BY NomeAbrev"
            'TODO: FALTA CRIAR UM NOVO TIPO DE TERCEIRO QUE VAI SER CLIENTE E FORNECEDOR
            Sql = "SELECT TercID, RTRIM(TercID) + ' - ' + RTRIM(NomeAbrev) + '   ' + ISNULL(RTRIM(Telefone),'') AS FornDesc FROM Terceiros ORDER BY NomeAbrev"
            db.GetData(Sql, dtforn)
            'Carregar(ComboBox)
            Me.CbForn.DataSource = dtforn
            Me.CbForn.DisplayMember = "FornDesc"
            Me.CbForn.ValueMember = "TercId"
            CbForn.SelectedValue = "2000"


            lbPr.Text = xPrCusto & " / " & xPrVnd & " / " & dUltPrVnd


            Me.CFGDet.Visible = True


            Me.Cursor = Cursors.Default

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaDetalhe")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaDetalhe")
        Finally

            If cbVerDetalhe.Checked = True Then
                cbVerDetalhe.Checked = False
                cbVerDetalhe.Checked = True
            End If

            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            cn.Close()
            Sql = Nothing
            Me.Cursor = Cursors.Default

        End Try
    End Sub







End Class