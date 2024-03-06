Imports System.Data.SqlClient
Imports System.Text


Public Class frmRecepcao

    Inherits System.Windows.Forms.Form
    Dim dtRecPndDet As New DataTable
    Dim dtRecPndCab As New DataTable
    Dim dtRec As New DataTable
    Dim CarregarFoto As New ClsFotos
    Dim xArtigoAux As String
    Dim RecTudo As Boolean = False
    Dim dvAux As DataView
    Dim xPrecoEtiqueta As Boolean
    Dim xCancelaRec As Boolean = False
    Dim linhaCabAct As Int16



    'Dim sIdDocCabSep As String
    Dim dsCab As New DataSet
    Dim dsDet As New DataSet
    Dim xNovoDocCC As String
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
    Dim sIdDocCabRec As String









    'Me.CmdValidaRec.Enabled = False
    'Me.txtCodBarras.Enabled = False
    'Me.C1FGRec.Enabled = False


    'Eventos do Form

    Private Sub frmRecepcao_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim Val As New clsValidacoes(Me.Name)
            ArrancarForm()
            ActualizaC1FGRecPendCab()
            btRecTotal.Visible = Val.ValidarPermicoes("btRecTotal")

            'Select Case xAplicacao
            '    Case "POS"
            '        cbVerTodas.Visible = False
            '    Case "BACKOFFICE"
            '        cbVerTodas.Visible = True
            'End Select


            If xGrupoAcesso = "ADMIN" Then
                cbVerTodas.Visible = True
            Else
                cbVerTodas.Visible = False
            End If



        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & "frmRecepcao_Load")
        End Try


    End Sub

    Private Sub txtCodBarras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBarras.KeyPress
        Dim xModelo As String
        Static xModeloActu As String
        Dim xArtigoFormatado As String
        Dim db As New ClsSqlBDados
        Dim xMsgErro As String = ""

        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If txtCodBarras.Text.Length = 8 Then
                    'carregar talões
                    Dim xTalao As String = Me.txtCodBarras.Text

                    'PESQUISAR SE O TALÃO PERTENCE À SEPARAÇÃO
                    Dim xOrigem As String = Me.C1FGRecPendCab(Me.C1FGRecPendCab.Row, "Origem")
                    Dim xDocNr As String = Me.C1FGRecPendCab(Me.C1FGRecPendCab.Row, "DocNr")

                    Sql = "SELECT COUNT(*) AS QTD FROM DocDet INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID WHERE (DocDet.ArmazemID = '" & xOrigem & "') AND (DocDet.TipoDocID = 'SE') AND (DocDet.DocNr = '" & xDocNr & "') GROUP BY DocDet.SerieID HAVING (DocDet.SerieID = '" & xTalao & "')"
                    Dim xTalaoExiste As Integer = db.GetDataValue(Sql)


                    Dim bTalao As Integer = C1FGRecPend.FindRow(xTalao, 0, 1, True)
                    If bTalao > 0 Then
                        Dim xArtigo As String = Me.C1FGRecPend(bTalao, "Artigo")
                        Dim xEstadoLn As String = Me.C1FGRecPend(bTalao, "EstadoLn")
                        Dim xObs As String = Me.C1FGRecPend(bTalao, "Obs")
                        If bTalao = -1 Or xEstadoLn <> "G" Then
                            If xGrupoAcesso = "ADMIN" Then
                                If xEstadoLn = "R" Then
                                    'FORÇAR ENTRADA
                                    If MsgBox("Vou forçar a entrada do talão: " & xTalao & " no Armazem ='" & xArmz & "'", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                        Sql = "UPDATE Serie SET EstadoID = 'S', ArmazemID = '" & xArmz & "' WHERE SerieID = '" & xTalao & "' and Estadoid='T'"
                                        db.ExecuteData(Sql)
                                        Me.txtCodBarras.Clear()
                                        Exit Sub
                                    End If
                                End If
                            End If
                            'ESSE TALÃO NÃO EXISTE OU JÁ FOI RECEPCIONADO
                        Else
                            xArtigoFormatado = Microsoft.VisualBasic.Left(xArtigo, 5) & "-" & Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(xArtigo, 7), 2) & "-" & Microsoft.VisualBasic.Right(xArtigo, 2)
                            dtRec.Rows.Add(xTalao, xArtigoFormatado, xObs)
                            'dtRec.Rows.Add(xTalao, xArtigo, xObs)

                            C1FGRec.Refresh()
                            'Iserir Foto
                            'xModelo = C1FGRecPend(Me.C1FGRecPend.Row, "ModeloID") & C1FGRecPend(C1FGRecPend.Row, "CorID")
                            xModelo = Microsoft.VisualBasic.Left(xArtigo, 7)
                            If xModelo <> xModeloActu Then
                                CarregarFoto.CarregarFotoModelo(Me.PictureBoxFoto, xModelo)
                                xModeloActu = xModelo
                            End If
                            For Each Linha As DataRow In dtRecPndDet.Select("SerieID = '" + xTalao + "'")
                                Linha.Delete()
                            Next
                        End If
                    Else

                        'xMsgErro = "Erro no Talão: " & xTalao & " ao recepcionar na casa " & xArmz
                        If xTalaoExiste = 0 Then
                            GravarEvento("Erro na Recepção", xArmz, xTalao)
                            TalaoInvalido()
                        Else
                            MsgBox("TALÃO JÁ LIDO!")
                        End If


                    End If
                End If
                C1FGRec.AutoSizeCols()
                txtCodBarras.SelectAll()
                txtQtdLido.Text = C1FGRec.Rows.Count - 1
                txtFaltaRec.Text = dvAux.Count

            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & "txtCodBarras_KeyPress")

        End Try
    End Sub

    Private Sub CmdValidaRec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdValidaRec.Click

        Dim xDocLnNr As Integer
        Dim db As New ClsSqlBDados
        Dim xPrecoVenda As Double
        'Dim xComissao As Double
        Dim xModelo As String
        Dim xCor As String
        Dim xProductcode As String
        Dim xNovoDoc As String = ""

        Try

            If SistemaBloqueado() = True Then
                Exit Sub
            End If

            If MsgBox("Confirma Recepção?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                If dtRecPndCab.Rows.Count > 0 Then
                    Dim xNumDoc As String = C1FGRecPendCab(Me.C1FGRecPendCab.Row, ("DocNr"))
                    Dim xOrigem As String = C1FGRecPendCab(Me.C1FGRecPendCab.Row, ("Origem"))
                    If RecTudo = True Then
                        dtRec.Clear()
                        Sql = "SELECT SerieID, ModeloID, CorId, ProductCode FROM docdet " &
                           "WHERE EmpresaID = '" & xEmp & "' " &
                           "AND ArmazemID = '" & xOrigem & "' " &
                           "AND TipoDocID = 'SE' " &
                           "AND DocNr = '" & xNumDoc & "' " &
                           "AND EstadoLn = 'G'"
                        db.GetData(Sql, dtRec)
                        For Each Linha As DataRow In dtRecPndDet.Rows
                            Linha.Delete()
                        Next
                        dtRecPndDet.AcceptChanges()
                    End If

                    xArmzConsignacao = xOrigem
                    'CRIAR DOCUMENTO DE RECEPÇÃO

                    If VerificaRecepcaoCriada(xOrigem, xNumDoc, xNovoDoc, xDocLnNr) = False Then
                        Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, EstadoDoc, TipoTerc, OperadorID, IdDocCab) " &
                            "VALUES('" & xEmp & "','" & xArmz & "','RC','" & xNovoDoc & "', '" & xOrigem & "', GETDATE(), 'SE', '" & xNumDoc & "', 
                            'C', 'A', '" & xUtilizador & "', '" & sIdDocCabRec & "')"
                        db.ExecuteData(Sql)
                        xDocLnNr = 1
                    End If

                    If dtRec.Rows.Count > 0 Then
                        For Each r As DataRow In dtRec.Rows


                            Sql = "SELECT DISTINCT ModeloID from serie where SerieID='" & r("SerieID") & "'"
                            xModelo = db.GetDataValue(Sql)
                            Sql = "SELECT DISTINCT CorID from serie where SerieID='" & r("SerieID") & "'"
                            xCor = db.GetDataValue(Sql)
                            Sql = "SELECT DISTINCT ProductCode from serie where SerieID='" & r("SerieID") & "'"
                            xProductcode = db.GetDataValue(Sql)


                            xPrecoVenda = DevolvePv(xArmz, r("SerieID"))


                            'Criar Documento de Recepção Detalhe


                            Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloId, CorId, ProductCode,  Qtd, EstadoLn, IdDocCab, OperadorID)
                                  VALUES ('" & xEmp & "', '" & xArmz & "', 'RC', '" & xNovoDoc & "', " & xDocLnNr & ", '" & r("SerieID") & "', '" & xModelo & "','" & xCor & "','" & xProductcode & "',  1, 'C', '" & sIdDocCabRec & "', '" & xUtilizador & "')"

                            db.ExecuteData(Sql)
                            xDocLnNr = xDocLnNr + 1

                            Sql = "UPDATE DocDet " & _
                                  "SET EstadoLn = 'R' " & _
                                  "WHERE EmpresaID = '" & xEmp & "' " & _
                                  "AND ArmazemID = '" & xOrigem & "' " & _
                                  "AND TipoDocID = 'SE' " & _
                                  "AND DocNr = '" & xNumDoc & "' " & _
                                  "AND SerieID = '" & r("SerieID") & "' " & _
                                  "AND EstadoLn = 'G'"
                            db.ExecuteData(Sql)


                            Sql = "UPDATE Serie SET EstadoID = 'S', ArmazemID = '" & xArmz & "' , DocNr = '" & xNovoDoc & "', PrecoVenda = '" & xPrecoVenda & "' WHERE SerieID = '" & r("SerieID") & "'"
                            db.ExecuteData(Sql)

                            Sql = "UPDATE Serie SET OBS1='' WHERE SerieID = '" & r("SerieID") & "'"
                            db.ExecuteData(Sql)


                            Sql = "select estadoid from serie where SerieID = '" & r("SerieID") & "'"
                            If db.GetDataValue(Sql) <> "S" Then
                                MsgBox("ERRO GRAVE NO TALÃO " & r("SerieID") & " CONTACTE ARMAZEM")
                                GravarEvento("Falha ao Act Estado", xArmz, r("SerieID"))
                                Sql = "UPDATE Serie SET EstadoID = 'S', ArmazemID = '" & xArmz & "' , DocNr = '" & xNovoDoc & "', PrecoVenda = '" & xPrecoVenda & "' WHERE SerieID = '" & r("SerieID") & "'"
                                db.ExecuteData(Sql)
                            End If

                            forcarvenda(r("SerieID"))
                        Next

                    End If

                    Sql = "SELECT COUNT(*) FROM DocDet " & _
                           "WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xOrigem & "' AND TipoDocID = 'SE' AND DocNr = '" & xNumDoc & "' AND EstadoLn = 'G' "

                    Dim xCount As String = db.GetDataValue(Sql)
                    If xCount = 0 Then
                        ' FAZ UPDATE AO ESTADO DE DOCUMENTO DE G PARA R 
                        Sql = "UPDATE DocCab SET EstadoDoc = 'R' WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xOrigem & "' AND TipoDocID = 'SE' AND DocNr = '" & xNumDoc & "'"
                        db.ExecuteData(Sql)
                        'validar e a recepção é de um armazem de consignação!!
                        If ArmazemConsignacao(xOrigem) Then

                            'vou emitir um credito de consignação

                            If GravarCC() Then

                                MsgBox("Vai imprimir o Crédito de Consignação!!", MsgBoxStyle.Information)
                                ListaDocEmpresa(xNovoDocCC, "CC", "Original", True)
                                If bDesenvolvimento = False Then
                                    ListaDocEmpresa(xNovoDocCC, "CC", "Duplicado", True)
                                    ListaDocEmpresa(xNovoDocCC, "CC", "Triplicado", True)
                                End If
                            Else
                                Sql = "DELETE FROM DOCCAB WHERE IdDocCab='" & sIdDocCabCC.ToString & "'"
                                db.ExecuteData(Sql)
                                MsgBox("ERRO NA CRIAÇÃO NO CREDITO DE CONSIGNAÇÃO!")

                            End If


                        End If


                    End If

                End If

                Sql = "UPDATE DocDet SET ModeloID = Serie.ModeloID, CorID = Serie.CorID FROM Serie INNER JOIN DocDet ON Serie.SerieID = DocDet.SerieID " & _
                "WHERE DocDet.TipoDocID = 'RC' AND DocDet.EmpresaID = '" & xEmp & "' AND DocDet.ArmazemID = '" & xArmz & "' AND DocDet.DocNr = N'" & xNovoDoc & "'"
                db.ExecuteData(Sql)

                dtRec.Clear()
                Me.txtQtdLido.Text = 0
                Me.txtCodBarras.Text = Nothing
                Me.txtCodBarras.Focus()

                Dim a As String = dtRecPndDet.Rows.Count

                If dvAux.Count = 0 Then
                    ActualizaC1FGRecPendCab()
                Else

                End If

                txtCodBarras.Clear()
                PictureBoxFoto.Visible = False


            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, " CmdValidaRec_Click")
        Catch ex As Exception
            ErroVB(ex.Message, " CmdValidaRec_Click")
        Finally
            RecTudo = False
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cbVerTodas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodas.CheckedChanged
        ActualizaC1FGRecPendCab()
    End Sub


    'EVENTOS NA FLEXGRID C1FGRecPendCab


    Private Sub C1FGRecPendCab_RowColChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FGRecPendCab.RowColChange

        TimerActDados.Stop()
        TimerActDados.Interval = 200
        TimerActDados.Start()

    End Sub

    Private Sub TimerActDados_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerActDados.Tick

        Try


            Me.TimerActDados.Stop()

            If dtRecPndCab.Rows.Count() > 0 Then
                Me.txtCodBarras.Enabled = True And Me.txtCodBarras.Focus()
                ActualizaC1FGRecPend()
            Else
                dtRecPndDet.Clear()
                C1FGRecPend.DataSource = dtRecPndDet
            End If

            dtRec.Clear()
            txtCodBarras.Clear()
            PictureBoxFoto.Visible = False


        Catch ex As Exception
            ErroVB(ex.Message, " ActualizaC1FGRecPend")

        End Try

    End Sub


    'FUNÇÕES E ROTINAS

    Private Sub ArrancarForm()
        Try
            'Preencher Grid C1TGRecPendCab
            With dtRecPndCab.Columns
                .Add("Origem", GetType(String))
                .Add("OrigDescr", GetType(String))
                .Add("DocNr", GetType(String))
                .Add("QtdTot", GetType(Integer))
                .Add("DataDoc", GetType(Date))
            End With
            With C1FGRecPendCab
                .DataSource = dtRecPndCab
                .Cols("DocNr").Caption = "NºDoc"
                .Cols("QtdTot").Caption = "QtdTotal"
                .Cols("DataDoc").Caption = "Data"
                .Cols("DataDoc").AllowEditing = False
                .Cols("QtdTot").TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                .AutoResize = True
            End With
            'Preencher Grid C1FGRecPend
            With dtRecPndDet.Columns
                .Add("SerieID", GetType(String))
                .Add("ModeloID", GetType(String))
                .Add("CorID", GetType(String))
                .Add("TamID", GetType(String))
                .Add("EstadoLn", GetType(String))
                .Add("Obs", GetType(String))
                .Add("Artigo", GetType(String))

            End With
            With C1FGRecPend
                .DataSource = dtRecPndDet
                .Cols("SerieID").Caption = "Talão"
                .Cols("SerieID").TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                .Cols("ModeloID").Visible = True
                .Cols("CorID").Visible = True
                .Cols("TamID").Visible = True

                .Cols("ModeloID").Caption = "Modelo"
                .Cols("CorID").Caption = "Cor"
                .Cols("TamID").Caption = "Tam"
                .Cols("Artigo").Caption = "Artigo"
                .Cols("Artigo").Visible = False
                '.Cols("Artigo").TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                .Cols("EstadoLn").Caption = "E"
                .Cols("EstadoLn").TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                .Cols("Obs").Visible = True
                .Cols("EstadoLn").TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter

                .AutoResize = True
            End With
            'Preencher Grid C1FGRec
            With dtRec.Columns
                .Add("SerieID", GetType(String)).Unique = True
                .Add("Artigo", GetType(String))
                .Add("Obs", GetType(String))
                .Add("ModeloId", GetType(String))
                .Add("CorId", GetType(String))
                .Add("ProductCode", GetType(String))
            End With
            With C1FGRec
                .DataSource = dtRec
                .Cols("ModeloId").Visible = False
                .Cols("CorId").Visible = False
                .Cols("ProductCode").Visible = False
                .Cols("SerieID").Caption = "Talão"
                .Cols("SerieID").TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                .Cols("Artigo").Caption = "Artigo"
                .Cols("Artigo").TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                .Cols("Obs").Caption = "Obs"
                .Cols("Obs").TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
                .AutoResize = True
                .AutoSizeCols()
            End With

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & "ArrancarForm")
        End Try
    End Sub

    Private Sub ActualizaC1FGRecPendCab()

        Dim Val As New clsValidacoes(Me.Name)

        Try
            dtRecPndCab.Clear()
            If cbVerTodas.Checked = True Then
                btRecTotal.Visible = False

                Sql = "SELECT C.ArmazemID AS Origem, A.ArmAbrev AS OrigDescr, C.DocNr, C.EstadoDoc as Estado, C.DataDoc, Sum(D.Qtd) AS QtdTot " & _
                      "FROM DocCab C, DocDet D, Armazens A " & _
                      "WHERE C.EmpresaID = D.EmpresaID " & _
                      "AND C.ArmazemID = D.ArmazemID " & _
                      "AND C.TipoDocID = D.TipoDocID " & _
                      "AND C.DocNr = D.DocNr " & _
                      "AND D.ArmazemID = A.ArmazemID " & _
                      "AND C.TercID = '" & xArmz & "' " & _
                       "AND C.ArmazemID <> '" & xArmz & "' " & _
                      "AND C.TipoDocID = 'SE' " & _
                      "AND C.EstadoDoc <> 'C' " & _
                      "Group by C.ArmazemID, A.ArmAbrev, C.DocNr, C.EstadoDoc, C.DataDoc " & _
                      "Order by C.DataDoc Desc"
            Else

                btRecTotal.Visible = Val.ValidarPermicoes("btRecTotal")

                Sql = "SELECT C.ArmazemID AS Origem, A.ArmAbrev AS OrigDescr, C.DocNr, C.EstadoDoc as Estado, C.DataDoc, Sum(D.Qtd) AS QtdTot " & _
                        "FROM DocCab C, DocDet D, Armazens A " & _
                        "WHERE C.EmpresaID = D.EmpresaID " & _
                        "AND C.ArmazemID = D.ArmazemID " & _
                        "AND C.TipoDocID = D.TipoDocID " & _
                        "AND C.DocNr = D.DocNr " & _
                        "AND D.ArmazemID = A.ArmazemID " & _
                        "AND C.TercID = '" & xArmz & "' " & _
                        "AND C.ArmazemID <> '" & xArmz & "' " & _
                        "AND C.TipoDocID = 'SE' " & _
                        "AND C.EstadoDoc = 'G' " & _
                        "Group by C.ArmazemID, A.ArmAbrev, C.DocNr, C.EstadoDoc, C.DataDoc " & _
                        "Order by C.DataDoc Desc"
            End If
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtRecPndCab)

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & "ActualizaC1FGRecPendCab")
        End Try
    End Sub

    Private Sub ActualizaC1FGRecPend()
        Dim db As New ClsSqlBDados

        Try
            txtFaltaRec.Text = 0
            txtQtdLido.Text = 0
            dtRec.Clear()
            dtRecPndDet.Clear()

            If xCancelaRec = True Then
                Me.C1FGRecPendCab.Row = linhaCabAct
            End If
            xCancelaRec = False

            Dim xOrigem As String = Me.C1FGRecPendCab(Me.C1FGRecPendCab.Row, "Origem")
            Dim xDocNr As String = Me.C1FGRecPendCab(Me.C1FGRecPendCab.Row, "DocNr")


            Sql = "SELECT DocDet.SerieID, DocDet.ModeloID, DocDet.CorID, DocDet.TamID, DocDet.EstadoLn, ISNULL(RTRIM(LTRIM(Serie.Obs)),'')+' '+ISNULL(RTRIM(LTRIM(Serie.Obs1)),'') Obs, DocDet.Modeloid + DocDet.corid + DocDet.tamid as Artigo " & _
                  "FROM DocDet, Serie WHERE DocDet.SerieID=Serie.SerieID AND DocDet.ArmazemID = '" & xOrigem & "' " & _
                  "AND DocDet.TipoDocID = 'SE' AND DocDet.DocNr = '" & xDocNr & "' "
            db.GetData(Sql, dtRecPndDet)

            dvAux = dtRecPndDet.DefaultView

            If cbVerTodas.Checked = False Then
                txtFaltaRec.Visible = True
                lbFaltaRec.Visible = True
                dvAux.RowFilter = "EstadoLn = 'G'"
                C1FGRecPend.Cols("EstadoLn").Visible = False
                txtFaltaRec.Text = dvAux.Count
            Else
                dvAux.RowFilter = ""
                C1FGRecPend.Cols("EstadoLn").Visible = True
                txtFaltaRec.Visible = False
                lbFaltaRec.Visible = False

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, " ActualizaC1FGRecPend")
        Catch ex As Exception
            ErroVB(ex.Message, " ActualizaC1FGRecPend")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub btRecTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRecTotal.Click

        Try
            'If MsgBox("Confirma Recepção?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            RecTudo = True
            CmdValidaRec_Click(sender, e)
            'End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & "btRecTotal_Click")
        End Try


    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub

    Private Sub Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        Dim xNumDoc As String = Me.C1FGRecPendCab(Me.C1FGRecPendCab.Row, "DocNr")
        Dim xArmzOrigem As String = Me.C1FGRecPendCab(Me.C1FGRecPendCab.Row, "Origem")
        ListaSeparacao(xNumDoc, xArmzOrigem)
    End Sub

    Private Function VerificaRecepcaoCriada(ByVal xArmzOrig As String, ByVal xDocNrOrig As String, ByRef xNovoDoc As String, ByRef xDocLnNr As Integer) As Boolean
        Dim db As New ClsSqlBDados


        Try

            Sql = "SELECT DocNr FROM DocCab WHERE ArmazemID='" & xArmz & "' AND TipoDocID='RC' AND " &
            "TercID = '" & xArmzOrig & "' AND TipoDocOrig = 'SE' AND DocNrOrig = '" & xDocNrOrig & "'"

            xNovoDoc = db.GetDataValue(Sql)
            If xNovoDoc = "" Then
                xNovoDoc = PesquisaMaxNumDoc("RC")
                xDocLnNr = 1
                sIdDocCabRec = Guid.NewGuid.ToString
                Return False
            Else
                Sql = "SELECT ISNULL(MAX(DocLnNr),0) AS MaxDocLnNr FROM DocDet WHERE " &
                  "ArmazemID = '" & xArmz & "' AND TipoDocID = 'RC' AND DocNr = '" & xNovoDoc & "'"
                xDocLnNr = db.GetDataValue(Sql) + 1

                Sql = "SELECT convert(nvarchar(36), idDocCab)  FROM DocCab WHERE " &
                  "ArmazemID = '" & xArmz & "' AND TipoDocID = 'RC' AND DocNr = '" & xNovoDoc & "'"
                sIdDocCabRec = db.GetDataValue(Sql).ToString

                Return True
            End If

        Catch ex As Exception

            ErroVB(ex.Message, Me.Name & "VerificaRecepcaoCriada")

        End Try


    End Function

    Private Function DevolvePv(ByVal xArmzDest As String, ByVal xSerie As String) As Double
        Dim xPv As Double
        Dim db As New ClsSqlBDados

        Try

            Sql = "SELECT P.Preco FROM Serie S, PrecoVenda P, Armazens A WHERE S.ModeloID = P.ModeloID " & _
                "AND S.CorID = P.CorID And P.TabPrecoID = A.TabPrecoID AND A.ArmazemID = '" & xArmzDest & "' AND S.SerieID = '" & xSerie & "'"
            xPv = db.GetDataValue(Sql)
            If xPv > 0 Then
                xPrecoEtiqueta = False
                Return xPv
                Exit Function
            End If
            Sql = "SELECT PrecoEtiqueta FROM Serie WHERE SerieID = '" & xSerie & "'"
            xPrecoEtiqueta = True
            Return db.GetDataValue(Sql)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DevolvePv")
        Catch ex As Exception
            ErroVB(ex.Message, "DevolvePv")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function

    'Private Function DevolveComissao(ByVal xArmzDest As String, ByVal xModelo As String) As Double
    '    Dim db As New ClsSqlBDados

    '    Try

    '        Sql = "SELECT  C.Comissao FROM  Comissoes C, Modelos M, Armazens A  WHERE C.LinhaID = M.LinhaID " & _
    '            "AND C.ArmazemID = A.ArmazemID AND C.TabPrecoID = A.TabPrecoID AND M.ModeloID = '" & xModelo & "' AND C.ArmazemID = '" & xArmzDest & "'"
    '        If xPrecoEtiqueta = False Then
    '            Return db.GetDataValue(Sql)
    '            Exit Function
    '        End If
    '        Sql = "SELECT  C.Comissao FROM  Comissoes C, Modelos M, Armazens A  WHERE C.LinhaID = M.LinhaID " & _
    '            "AND C.ArmazemID = A.ArmazemID AND C.TabPrecoID = '00' AND M.ModeloID = '" & xModelo & "' AND C.ArmazemID = '" & xArmzDest & "'"
    '        Return db.GetDataValue(Sql)


    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "DevolveComissao")
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "DevolveComissao")
    '    Finally
    '        If db IsNot Nothing Then db.Dispose()
    '        db = Nothing
    '    End Try

    'End Function

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Try
            xCancelaRec = True
            linhaCabAct = Me.C1FGRecPendCab.Row
            ActualizaC1FGRecPend()


        Catch ex As Exception

        End Try



    End Sub

    Private Sub C1FGRecPend_RowColChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FGRecPend.RowColChange

        Dim xModelo As String
        Static xModeloActu As String

        Try

            If Me.C1FGRecPend.Row > 0 Then



                Dim xArtigo As String = Me.C1FGRecPend(Me.C1FGRecPend.Row, "Artigo").ToString


                xModelo = Microsoft.VisualBasic.Left(xArtigo, 7)
                If xModelo <> xModeloActu Then
                    CarregarFoto.CarregarFotoModelo(Me.PictureBoxFoto, xModelo)
                    xModeloActu = xModelo
                End If

            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1FGRecPend_RowColChange")
        Catch ex As Exception
            ErroVB(ex.Message, "C1FGRecPend_RowColChange")
        Finally

        End Try



    End Sub

    Private Sub FORCARVENDA(ByRef xTalao As String)

        Dim db As New ClsSqlBDados
        'Dim xValor As Double

        Try

            Sql = "SELECT COUNT(*) FROM RESERVAS WHERE DESPESAS>0 AND RESERVASERIEID='" & xTalao & "'"
            If db.GetDataValue(Sql) > 0 Then
                MsgBox("O Talão: " & xTalao & " é um pedido especial! " & Chr(13) & "Tem que lançar a venda!")

                'Sql = "SELECT count(*) FROM SERIE WHERE ARMAZEMID='" & xArmz & "' AND ESTADOID='S' AND SERIEID='" & xTalao & "'"
                'If db.GetDataValue(Sql) > 0 Then
                '    Sql = "SELECT ISNULL(PRECOVENDA,'0') FROM SERIE WHERE SERIEID='" & xTalao & "'"
                '    xValor = db.GetDataValue(Sql)
                'End If
                'Sql = "UPDATE Serie SET EstadoID = 'V', PVndReal = '" & xValor & "', OperadorID = '" & xUtilizador & "', DtSaida = Getdate() WHERE SerieID = '" & xTalao & "'"
                'db.ExecuteData(Sql)

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "forcarvenda")
        Catch ex As Exception
            ErroVB(ex.Message, "forcarvenda")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Function GravarCC() As Boolean


        Dim db As New ClsSqlBDados


        Try

            Dim dtdet As New DataTable
            Dim sDescricaoLinha As String
            Dim dComissao As Double = 0
            Dim xTipoTerc As String = "C"
            Dim xTipoDoc As String = "CC"
            Dim dtSerie As New DataTable
            sTercIDCC = DevolveTerceiro(xArmzConsignacao)
            Dim sIdTerceiro As String


            Dim xData As String = Format(CType(Now(), Date), "yyyy-MM-dd H:mm:ss")
            sIdDocCabCC = Guid.NewGuid.ToString
            sIdDocDetCC = Guid.NewGuid.ToString

            Dim strData As New StringBuilder

            Dim sCountryCarga As String = "PT"
            Dim sCountryDescarga As String = "PT"

            xNovoDocCC = PesquisaMaxNumDoc(xTipoDoc)
            'CarregarInfoCargaDescarga(xArmzConsignacao, "0000")

            Sql = "SELECT CAST(IDTerceiro AS char(36))  from Terceiros where TercID='" & sTercIDCC & "'"
            sIdTerceiro = db.GetDataValue(Sql).ToString

            Dim sATCUD As String = DevolveATCUD(xArmz, xTipoDoc, xNovoDocCC)
            If Now() >= #01/01/2023# And sATCUD = "0" Then Return False

            Sql = "BEGIN TRANSACTION"
            strData.AppendLine(Sql)

            Sql = "INSERT INTO DocCab (EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, 
                HoraDesc, Obs, Obs1, Obs2, Obs3, DescontoDoc, EstadoDoc, TipoTerc, FormaPagtoID, IdDocCab, UtilizadorID, OperadorID, SAFT, DtUltAlt, AddressDetailCarga, 
                CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, IdTerceiro, ATCUD) " &
                "VALUES ('" & xEmp & "', '" & xArmz & "', '" & xTipoDoc & "', N'" & xNovoDocCC & "', '" & sTercIDCC & "', CONVERT(DATETIME, '" & xData & "', 102), '', '', '', 
                '0', '', '', '', '', '', '0', '0', '0', '0', 'C', N'" & xTipoTerc & "', '0', '" & sIdDocCabCC & "', '" & iUtilizadorID & "', 
                '" & xUtilizador & "', '0', CONVERT(DATETIME, '" & xData & "', 102), N'" & sAddressDetailCarga & "', N'" & sCityCarga & "', N'" & sPostalCodeCarga & "',
                N'" & sCountryCarga & "', CONVERT(DATETIME, '" & xData & "', 102), N'" & sAddressDetailDescarga & "', N'" & sCityDescarga & "', N'" & sPostalCodeDescarga & "', 
                N'" & sCountryDescarga & "', CONVERT(DATETIME, '" & xData & "', 102), '" & sIdTerceiro & "', '" & sATCUD & "');"

            strData.AppendLine(Sql)

            Dim inLinha As Int16 = 0
            Dim dValor As Double = 0
            Dim dValorLiquido As Double = 0
            Dim dVlrDescLn As Double = 0
            Dim dVlrIVA As Double = 0


            Sql = "SELECT DocDet.ProductCode, DocDet.ModeloID, DocDet.CorID, Product.ProductDescription, SUM(DocDet.Qtd) AS Qtd, Product.UnitOfMeasure, ModeloCor.PrVnd, DocDet.IdDocCab
                FROM     DocDet INNER JOIN
                Product ON DocDet.ProductCode = Product.ProductCode INNER JOIN
                ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN
                DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr
                WHERE  (DocCab.IdDocCab = '" & sIdDocCabRec & "')
                GROUP BY Product.ProductDescription, Product.UnitOfMeasure, DocDet.ProductCode, DocDet.ModeloID, DocDet.CorID, ModeloCor.PrVnd, DocDet.IdDocCab"

            db.GetData(Sql, dtdet, False)

            For Each r As DataRow In dtdet.Rows

                inLinha = inLinha + 1

                Sql = "SELECT ISNULL(MAX(Comissao),0) AS Comissao FROM Comissoes
                    WHERE  ArmazemID = '" & xArmzConsignacao & "' and LinhaID = '01' AND TabPrecoID = '00'"

                dComissao = db.GetDataValue(Sql)
                If dComissao = 0 Then
                    MsgBox("Falta a comissão!!")
                    Return False
                End If

                'dValor = r("PrVnd") * (1 - dComissao) / (1 + DevolveIva(DevolveIvaId(xArmz)))
                dValor = Arredondamento(r("PrVnd") * (1 - dComissao), 2)
                dValorLiquido = Arredondamento(dValor / (1 + DevolveIva(DevolveIvaId(xArmz))), 2)


                sDescricaoLinha = Trim(r("ProductDescription")) + " «" + r("ModeloID") + "-" + r("CorID") + "»"

                Sql = "INSERT INTO dbo.DocDet (EmpresaID,ArmazemID,TipoDocID,DocNr,DocLnNr,ModeloID,CorID,Descricao,Unidade,Valor,ValorLiquido,
                IvaID,VlrIVA,TxIva,Qtd,EstadoLn,IdDocCab,IdDocDet,UtilizadorID,ProductCode) 
                VALUES('" & xEmp & "','" & xArmz & "','" & xTipoDoc & "','" & xNovoDocCC & "', " & inLinha & ", '" & r("ModeloID") & "', '" & r("CorID") & "',
                '" & sDescricaoLinha & "', '" & r("UnitOfMeasure") & "', " & dValor & ", " & dValorLiquido & ", " & 0 & ",  " & 0 & ", " & 0 & "," & r("Qtd") & ", 
                'C','" & sIdDocCabCC & "','" & sIdDocDetCC & "', '" & iUtilizadorID & "', '" & r("ProductCode") & "');"

                strData.AppendLine(Sql)

                Sql = "INSERT INTO DocSerie (IdDocCab, SerieID, IdDocDet)
                    (SELECT '" & sIdDocCabCC & "', SerieID, '" & sIdDocDetCC & "' FROM  DocDet 
                    WHERE  ModeloId = '" & r("ModeloId") & "' and CorId = '" & r("CorId") & "'and IdDocCab = '" & sIdDocCabRec & "');"

                strData.AppendLine(Sql)

            Next


            Sql = "COMMIT TRANSACTION;"
            strData.AppendLine(Sql)
            Sql = strData.ToString
            dberrorAtivo = True


            Dim clsGravaDoc As New ClsDocs
            If Not clsGravaDoc.NovoDoc(Sql, sIdDocCabCC, xTipoDoc) Then
                EnviarEmail("Erro 7600 da criação do documento!!")
                MsgBox("Erro 7600 da criação do documento!!",, "Girl")
                Return False
            Else

                Sql = "SELECT SerieID FROM DocSerie WHERE IDDOCCAB='" & sIdDocCabCC & "';"

                db.GetData(Sql, dtSerie, False)
                For Each r1 As DataRow In dtSerie.Rows
                    Sql = "UPDATE DocSerie SET IdDocCabOrig = 
                        (SELECT IdDocCab
                        FROM     DocSerie a
                        INNER JOIN 
                        (SELECT DocSerie.SerieID, MAX(DocSerie.DtRegisto) AS Data
                        FROM     DocSerie INNER JOIN
                        DocCab ON DocSerie.IdDocCab = DocCab.IdDocCab
                        WHERE  (DocCab.TipoDocID = 'FC')
                        GROUP BY DocSerie.SerieID) b ON a.SerieID = b.SerieID AND a.DtRegisto = b.Data
                        where a.SerieID='" & r1("SerieId") & "')
                        WHERE IDDOCCAB='" & sIdDocCabCC & "' and DocSerie.SerieID='" & r1("SerieId") & "'"
                    db.ExecuteData(Sql)
                Next

                Return True
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravarDocumento")
        Catch ex As Exception
            ErroVB(ex.Message, "GravarDocumento")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            cn.Close()
            Cmd.Dispose()
        End Try

    End Function






End Class