Imports System.Data.SqlClient




Public Class frmConferencia

    Dim dtCab As New DataTable
    Dim dtDestinos As New DataTable
    Dim dtDet As New DataTable
    Dim dtConfere As New DataTable
    Dim dtSerieID As New DataTable
    Dim dtDepTemp As New DataTable
    Dim xArmzConf As String
    Dim CarregarFoto As New ClsFotos






    Private Sub frmConferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizaCabeçalho()
        CarregarDestinos()
        CarregarSerieID()
        PrepararDepositoTemporario()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CarregarSerieID()
        Dim db As New ClsSqlBDados
        Try
            Sql = "SELECT ArmazemId, serieid, EstadoID FROM Serie"
            db.GetData(Sql, dtSerieID)
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": CarregarSerieID")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub ActualizaCabeçalho()
        Dim db As New ClsSqlBDados
        Try
            dtCab.Clear()
            Sql = "SELECT DocCab.DocNr, DocCab.TercID, Armazens.ArmAbrev, DocCab.DataDoc " & _
                  "FROM DocCab, Armazens " & _
                  "WHERE DocCab.TercID = Armazens.ArmazemID " & _
                  "AND DocCab.EmpresaID = '" & xEmp & "' " & _
                  "AND DocCab.ArmazemID = '" & xArmz & "' " & _
                  "AND DocCab.TipoDocID = 'CF' " & _
                  "ORDER BY DocCab.DocNr DESC"
            db.GetData(Sql, dtCab)
            txtCodBarras.Enabled = dtCab.Rows.Count > 0
            With Me.GVDocCab
                .DataSource = dtCab
                .IniciarDG(GridView.ModoLeitura.Sem_Qualquer_Tipo_Escrita, DataGridViewSelectionMode.FullRowSelect, DataGridViewAutoSizeColumnsMode.None, False, 8)
                .Columns("DocNr").HeaderText = "Doc"
                .Columns("TercID").HeaderText = "Cod"
                .Columns("ArmAbrev").HeaderText = "Armazem"
                .Columns("DataDoc").HeaderText = "Data"
                .Columns("DataDoc").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                .Columns("DocNr").Width = 66
                .Columns("TercID").Width = 35
                .Columns("ArmAbrev").Width = 120
                .Columns("DataDoc").Width = 75
                .Refresh()
            End With
            ActualizaDetalhe()
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": ActualizaCabeçalho")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub ActualizaDetalhe()
        Dim db As New ClsSqlBDados
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.GVDocCab.RowCount > 0 Then
                Dim xDocNr As String = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value
                dtDet.Clear()
                dtConfere.Clear()


                Sql = "SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, EstadoLn as Est, Obs as DataEnvio, Valor " & _
                      "FROM DocDet " & _
                      "WHERE EmpresaID='" & xEmp & "' " & _
                      "AND ArmazemID='" & xArmz & "' " & _
                      "AND TipoDocID='CF' " & _
                      "AND DocNR='" & xDocNr & "' " & _
                      "AND EstadoLn in ('S', 'V')"
                db.GetData(Sql, dtDet)

                With Me.GVDocDet
                    .IniciarDG(GridView.ModoLeitura.Sem_Qualquer_Tipo_Escrita, DataGridViewSelectionMode.FullRowSelect, DataGridViewAutoSizeColumnsMode.None, False, 8)
                    .DataSource = dtDet
                    .Columns("EmpresaID").Visible = False
                    .Columns("ArmazemID").Visible = False
                    .Columns("TipoDocID").Visible = False
                    .Columns("DocNr").Visible = False
                    .Columns("DocLnNr").Visible = False
                    .Columns("SerieID").HeaderText = "Talão"
                    .Columns("SerieID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("ModeloID").HeaderText = "Modelo"
                    .Columns("ModeloID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("CorID").HeaderText = "Cor"
                    .Columns("CorID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("TamID").HeaderText = "Tam"
                    .Columns("TamID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Est").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Valor").HeaderText = "Preço"
                    .Columns("Valor").DefaultCellStyle.Format = "# ##0.00"
                    .Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("DataEnvio").DefaultCellStyle.Format = "yyyy-MM-dd"
                    .Columns("DataEnvio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("SerieID").Width = 58
                    .Columns("ModeloID").Width = 50
                    .Columns("CorID").Width = 28
                    .Columns("TamID").Width = 32
                    .Columns("Est").Width = 26
                    .Columns("DataEnvio").Width = 66
                    .Columns("Valor").Width = 45
                    Me.tbConferir.Text = dtDet.Rows.Count
                    .Refresh()
                End With
                'ACTUALIZA C1tgConf
                Sql = "SELECT SerieID, ModeloID, CorID, TamID, EstadoLn as Est, Obs as DataEnvio, Valor " & _
                      "FROM DocDet " & _
                      "WHERE EmpresaID='" & xEmp & "' " & _
                      "AND ArmazemID='" & xArmz & "' " & _
                      "AND TipoDocID='CF' " & _
                      "AND DocNR='" & xDocNr & "' " & _
                      "AND EstadoLn in ('SC', 'TC', 'VC')"
                db.GetData(Sql, dtConfere)
                With Me.GVConf
                    .IniciarDG(GridView.ModoLeitura.Sem_Qualquer_Tipo_Escrita, DataGridViewSelectionMode.FullRowSelect, DataGridViewAutoSizeColumnsMode.None, False, 8)
                    .DataSource = dtConfere
                    .AllowUserToDeleteRows = True
                    .Columns("SerieID").HeaderText = "Talão"
                    .Columns("ModeloID").HeaderText = "Modelo"
                    .Columns("CorID").HeaderText = "Cor"
                    .Columns("TamID").HeaderText = "Tam"
                    .Columns("Valor").HeaderText = "Preço"
                    .Columns("Valor").DefaultCellStyle.Format = "# ##0.00"
                    .Columns("DataEnvio").DefaultCellStyle.Format = "yyyy-MM-dd"
                    .Columns("SerieID").Width = 58
                    .Columns("ModeloID").Width = 50
                    .Columns("CorID").Width = 28
                    .Columns("TamID").Width = 32
                    .Columns("Est").Width = 26
                    .Columns("DataEnvio").Width = 66
                    .Columns("Valor").Width = 45

                    Me.lbConferido.Text = dtConfere.Rows.Count
                    .Refresh()
                End With
            Else
                dtDet.Clear()
            End If
            Me.txtCodBarras.Focus()
            Me.Cursor = Cursors.Default
            Me.ActualizarContadores()
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": ActualizaDetalhe")
        Finally
            cn.Close()
            Sql = Nothing
        End Try

    End Sub

    Private Sub CarregarDestinos()
        Dim db As New ClsSqlBDados
        Try
            'Carregar dt Destinos
            Sql = "SELECT ArmazemID, rtrim(ArmazemID) + ' - ' + rtrim(ArmAbrev) as Destino from Armazens Order by ArmAbrev"
            db.GetData(Sql, dtDestinos)
            'Carregar(ComboBox)
            Me.CbDestino.DataSource = dtDestinos
            Me.CbDestino.DisplayMember = "Destino"
            Me.CbDestino.ValueMember = "ArmazemID"
            Me.CbDestino.Text = Nothing
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": CarregarDestinos")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub PrepararDepositoTemporario()
        Dim db As New ClsSqlBDados
        Try
            'AO CARREGAR REGISTO VAI SERVIR PARA CRIAR O DT COM OS CAMPOS CORRECTOS MAS DEPOIS É PARA APAGAR
            Sql = "SELECT TOP 1 SerieID, ModeloID, CorID, TamID, EstadoLn as Est, Obs as DataEnvio, Valor FROM DocDet "
            db.GetData(Sql, dtDepTemp)
            dtDepTemp.Clear()
            'PREPARA A GRID DE FORMA QUE SÓ SEJA VISIVEL O NUMERO DE TALÃO 
            With Me.GVDepTemp
                .DataSource = dtDepTemp
                .IniciarDG(GridView.ModoLeitura.Sem_Qualquer_Tipo_Escrita, DataGridViewSelectionMode.FullRowSelect, DataGridViewAutoSizeColumnsMode.None, True, 9)
                .AllowUserToDeleteRows = True
                .RowHeadersWidth = .ColumnHeadersHeight
                .Columns(0).HeaderText = "Talão"
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False
                .Columns(5).Visible = False
                .Columns(6).Visible = False
            End With
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": PrepararDepositoTemporario")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub CmdNovoDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNovoDoc.Click
        Dim db As New ClsSqlBDados
        Dim dtDetAux As New DataTable
        Dim dtEnviosNaoRec As New DataTable
        Dim dtRecPend As New DataTable
        Dim RecPend As Boolean = False
        Dim MSN1 As String = ""

        Try


            Me.Cursor = Cursors.WaitCursor
            If Not Me.CbDestino.SelectedValue Is DBNull.Value Then
                If Me.CbDestino.SelectedValue <> "" Then
                    Dim xNumDoc As String = PesquisaMaxNumDoc("CF")
                    Dim xData As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
                    xArmzConf = Me.CbDestino.SelectedValue
                    Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, OperadorID) " & _
                        "VALUES ('" & xEmp & "','" & xArmz & "','CF','" & xNumDoc & "', '" & xArmzConf & "','" & xData & "','C','" & xUtilizador & "')"
                    db.ExecuteData(Sql)
                    Me.CbDestino.SelectedIndex = -1
                    Me.CbDestino.Text = Nothing




                    'VERIFICAR SE EXISTEM ENVIOS POR RECEPCIONAR NO DESTINO
                    Sql = "SELECT C.TercID DESTINO FROM DocCab C, DocDet D, Armazens A WHERE C.EmpresaID = D.EmpresaID  AND C.ArmazemID = D.ArmazemID AND C.TipoDocID = D.TipoDocID AND C.DocNr = D.DocNr AND D.ArmazemID = A.ArmazemID  AND C.TipoDocID = 'SE' AND C.EstadoDoc = 'G'  and C.ArmazemID='" & xArmzConf & "' Group by C.TercID"
                    db.GetData(Sql, dtEnviosNaoRec, False)
                    If dtEnviosNaoRec.Rows.Count > 0 Then
                        For Each r As DataRow In dtEnviosNaoRec.Rows
                            MSN1 = MSN1 + r("DESTINO") + " "
                        Next
                    End If
                    'VERIFICAR SE EXISTEM RECEPÇÕES PENDENTES
                    Sql = "SELECT C.ArmazemID FROM DocCab C, DocDet D, Armazens A WHERE C.EmpresaID = D.EmpresaID  AND C.ArmazemID = D.ArmazemID AND C.TipoDocID = D.TipoDocID AND C.DocNr = D.DocNr AND D.ArmazemID = A.ArmazemID  AND C.TercID = '" & xArmzConf & "' AND C.TipoDocID = 'SE' AND C.EstadoDoc = 'G'  Group by C.ArmazemID"
                    db.GetData(Sql, dtRecPend, False)
                    If dtRecPend.Rows.Count > 0 Then
                        RecPend = True
                    End If

                    If Len(Trim(MSN1)) > 0 And RecPend = True Then
                        MsgBox("EXISTEM ENVIOS POR RECEPCIONAR NAS CASAS: " + MSN1 + Chr(13) + "E EXISTEM RECEPÇÕES PENDENTES")
                        GoTo SEGUINTE
                    End If

                    If RecPend = True Then
                        MsgBox("EXISTEM RECEPÇÕES PENDENTES")
                        GoTo SEGUINTE
                    End If

                    If Len(Trim(MSN1)) > 0 Then
                        MsgBox("EXISTEM ENVIOS POR RECEPCIONAR NAS CASAS: " + MSN1)
                        GoTo SEGUINTE
                    End If

SEGUINTE:

                    Sql = "SELECT S.SerieID, S.ModeloID, S.CorID, M.ModCorDescr, S.TamID, S.PrecoEtiqueta, S.DocNr, S.EstadoID, UltimosEnvios.DtUltimoEnvio,  Unidades.UnidDescr FROM Modelos INNER JOIN ModeloCor AS M ON Modelos.ModeloID = M.ModeloID INNER JOIN Unidades ON Modelos.UnidID = Unidades.UnidID RIGHT OUTER JOIN Serie AS S ON M.ModeloID = S.ModeloID AND M.CorID = S.CorID LEFT OUTER JOIN (SELECT     MAX(DC.DataDoc) AS DtUltimoEnvio, DD.SerieID FROM          DocCab AS DC INNER JOIN DocDet AS DD ON DC.EmpresaID = DD.EmpresaID AND DC.ArmazemID = DD.ArmazemID AND DC.TipoDocID = DD.TipoDocID AND  DC.DocNr = DD.DocNr WHERE      (DC.TipoDocID = 'SE') AND (DC.TercID = '" & xArmzConf & "') GROUP BY DD.SerieID) AS UltimosEnvios ON S.SerieID = UltimosEnvios.SerieID WHERE (S.ArmazemID = '" & xArmzConf & "') AND (S.EstadoID IN ('S', 'V')) ORDER BY S.SerieID"

                    db.GetData(Sql, dtDetAux, True)
                    'CRIAR DETALHE DA CONFERÊNCIA - NOTA : A LINHA LEVA ESTADO DO TALÃO 
                    Dim xDocLnNr As Integer
                    Dim xSerie As String
                    Dim xModelo As String
                    Dim xCor As String
                    Dim xDescr As String
                    Dim xTam As String
                    Dim xPreco As Double
                    Dim xEstadoTalao As String
                    Dim xDataEnvio As String
                    Dim xUnidade As String

                    If dtDetAux.Rows.Count > 0 Then

                        xDocLnNr = 1
                        For Each r As DataRow In dtDetAux.Rows
                            'Debug.Print(r("SerieID"))
                            xSerie = r("SerieID")
                            xModelo = IIf(r("ModeloID") Is DBNull.Value, "", r("ModeloID"))
                            xCor = IIf(r("CorID") Is DBNull.Value, "", r("CorID"))
                            xDescr = IIf(r("ModCorDescr") Is DBNull.Value, "", r("ModCorDescr"))
                            xTam = IIf(r("TamID") Is DBNull.Value, "", r("TamID"))
                            xPreco = IIf(r("PrecoEtiqueta") Is DBNull.Value, 0, r("PrecoEtiqueta"))
                            xEstadoTalao = r("EstadoID")
                            xDataEnvio = IIf(r("DtUltimoEnvio") Is DBNull.Value, "1900-01-01", r("DtUltimoEnvio"))
                            xUnidade = IIf(r("UnidDescr") Is DBNull.Value, "", r("UnidDescr"))

                            Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, Descricao, TamID, Qtd, EstadoLn, Valor, Obs, Unidade, OperadorID) " & _
                                "VALUES ('" & xEmp & "', '" & xArmz & "', 'CF', '" & xNumDoc & "', " & xDocLnNr & ", '" & xSerie & "', '" & xModelo & "', '" & xCor & "',  '" & xDescr & "', " & xTam & ", 1, '" & xEstadoTalao & "', '" & xPreco & "', '" & xDataEnvio & "', '" & xUnidade & "', '" & xUtilizador & "')"
                            db.ExecuteData(Sql)
                            xDocLnNr += 1
                        Next
                        Me.txtCodBarras.Text = Nothing
                        Me.txtCodBarras.Focus()
                    End If
                    ActualizaCabeçalho()
                Else
                    MsgBox("Seleccione um Destino!")
                End If
            Else
                MsgBox("Seleccione um Destino!")
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": CmdNovo_ClickXXXX")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CmdFecharSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFecharSep.Click
        Close()
    End Sub

    Private Sub CmdApagaSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdApagaSep.Click
        Dim db As New ClsSqlBDados
        Try
            Dim xNumDoc As String = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value.ToString
            If MsgBox("Vai apagar o Conferência : " & xNumDoc, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Me.Cursor = Cursors.WaitCursor
                Sql = "DELETE FROM DocDet WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'CF' AND DocNr = '" & xNumDoc & "'"
                db.ExecuteData(Sql)
                Sql = "DELETE FROM DocCab WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'CF' AND DocNr = '" & xNumDoc & "'"
                db.ExecuteData(Sql)
                ActualizaCabeçalho()
                Application.DoEvents()
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": CmdApagaSep_Click")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim xNumDoc As String = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value.ToString
            ListaConferencia(xNumDoc)
            Application.DoEvents()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CmdConferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConferir.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim xNumDoc As String = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value.ToString
            ListaConferir(xNumDoc)
            Application.DoEvents()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GVDocCab_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVDocCab.SelectionChanged
        If Me.GVDocCab.SelectedRows.Count > 0 Then
            ActualizaDetalhe()
        End If
    End Sub

    Private Sub txtCodBarras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBarras.KeyPress
        'TODO: COLOCAR MSG ESSE TALÃO NÃO EXISTE OU ESSE TALÃO ESTÁ NA CASA XXXXX
        Dim db As New ClsSqlBDados
        Dim dr() As DataRow
        Dim xSerieID, xModeloID, xCorID, xTamID, xEstConf, xDataEnvio As String
        Dim xModeloCor As String = ""
        Dim xModeloCorAnterior As String = ""
        Dim xValor As Double
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If txtCodBarras.Text.Length = 8 Then
                    xSerieID = Me.txtCodBarras.Text
                    If ValidarTalao(xSerieID) = True Then
                        'CARREGAR TALÕES
                        dr = dtDet.Select("SerieID = '" + xSerieID + "'")
                        xModeloID = dr(0)("ModeloID").ToString()
                        xCorID = dr(0)("CorID").ToString()
                        xTamID = dr(0)("TamID").ToString()
                        xEstConf = dr(0)("Est").ToString()
                        xDataEnvio = dr(0)("DataEnvio").ToString()
                        xValor = dr(0)("Valor")

                        'RETIRAR A FICHA DA DTDET
                        For Each Linha As DataRow In dtDet.Select("SerieID = '" + xSerieID + "'")
                            Linha.Delete()
                        Next
                        'CARREGAR NA TABELA DTDEPTEMP
                        dtDepTemp.Rows.Add(New Object() {xSerieID, xModeloID, xCorID, xTamID, xEstConf, xDataEnvio, xValor})
                        'ISERIR FOTO
                        xModeloCor = xModeloID & xCorID
                        If xModeloCor <> xModeloCorAnterior Then
                            CarregarFoto.CarregarFotoModeloCor(Me.PictureBoxFoto, xModeloCor, "xok")
                            xModeloCorAnterior = xModeloCor
                        End If
                        'ACTUALIZAR OS CONTADORES
                        ActualizarContadores()
                    End If
                End If
                txtCodBarras.SelectAll()
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & "txtCodBarras_KeyPress")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            dr = Nothing
            xSerieID = Nothing
            xModeloID = Nothing
            xCorID = Nothing
            xTamID = Nothing
            xEstConf = Nothing
            xDataEnvio = Nothing
            xModeloCor = Nothing
            xModeloCorAnterior = Nothing
            xValor = Nothing
            Sql = Nothing
        End Try
    End Sub

    Private Sub ActualizarContadores()
        Me.tbConferir.Text = dtDet.DefaultView.Count
        Me.lblQtdDepTemp.Text = dtDepTemp.Rows.Count
        Me.lbConferido.Text = dtConfere.Rows.Count
    End Sub

    Private Function ValidarTalao(ByVal xSerie As String) As Boolean
        Dim xArmzAux As String
        Dim xMensagem As String
        Dim xEstado As String
        Dim dr() As DataRow
        Try
            If dtDet.Select("SerieID = '" & Me.txtCodBarras.Text & "'", "").Length > 0 Then
                Return True
            Else
                If dtConfere.Select("SerieID = '" & Me.txtCodBarras.Text & "'", "").Length > 0 Then
                    xMensagem = "Talão já Conferido!!"
                    TalaoInvalido(xMensagem)
                    Return False
                Else
                    dr = dtSerieID.Select("SerieID = '" & Me.txtCodBarras.Text & "'", "")
                    If dr.Length > 0 Then
                        xArmzAux = dr(0)("ArmazemId")
                        xEstado = dr(0)("EstadoID")
                        xMensagem = "Esse Talão está no Armazem: " & xArmzAux & " no Estado: " & xEstado
                        TalaoInvalido(xMensagem)
                        Return False
                    Else
                        xMensagem = "Esse Talão não Existe!!"
                        TalaoInvalido(xMensagem)
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": ValidarTalao")
        End Try
    End Function

    Public Sub TalaoInvalido(ByVal xMensagem As String)
        Do While MsgBox(xMensagem, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok
            Beep()
        Loop
    End Sub

    Private Sub GVConf_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles GVConf.UserDeletedRow
        dtConfere.AcceptChanges()
        ActualizaDetalhe()
    End Sub

    Private Sub GVConf_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles GVConf.UserDeletingRow
        Dim db As New ClsSqlBDados
        Try
            Dim xEst As String
            Dim xNumDoc As String = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value.ToString
            Dim xSerie As String = Me.GVConf("SerieID", Me.GVConf.CurrentCell.RowIndex).Value.ToString
            Dim xEstConf As String = Me.GVConf("Est", Me.GVConf.CurrentCell.RowIndex).Value.ToString
            If xEstConf = "TC" Then
                xEst = "T"
            Else
                xEst = "S"
            End If
            'ACTUALIZAR ESTADO DA LINHA NO DETALHE DO DOC. DE CONFERÊNCIA
            Sql = "UPDATE DocDet " & _
                  "SET EstadoLn = '" & xEst & "' " & _
                  "WHERE EmpresaID = '" & xEmp & "' " & _
                  "AND ArmazemID = '" & xArmz & "' " & _
                  "AND TipoDocID = 'CF' " & _
                  "AND DocNr = '" & xNumDoc & "' " & _
                  "AND SerieID = '" & xSerie & "' "
            db.ExecuteData(Sql)
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + "GVConf_UserDeletingRow")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub GVDocDet_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVDocDet.CurrentCellChanged
        Try
            'Iserir Foto
            If Me.GVDocDet.CurrentCell IsNot Nothing Then
                If GVDocDet.Rows.Count > 0 Then
                    If GVDocDet.SelectedRows.Count > 0 Then
                        Dim xModeloCor, xModeloID, xCorID As String
                        xModeloID = Me.GVDocDet("ModeloID", Me.GVDocDet.CurrentCell.RowIndex).Value.ToString
                        xCorID = Me.GVDocDet("CorID", Me.GVDocDet.CurrentCell.RowIndex).Value.ToString
                        xModeloCor = xModeloID & xCorID
                        CarregarFoto.CarregarFotoModeloCor(Me.PictureBoxFoto, xModeloCor, "xok")
                    End If
                End If
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": GVDocDet_CurrentCellChanged")
        End Try
    End Sub

    Private Sub GVConf_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVConf.CurrentCellChanged
        Try
            'Iserir Foto
            If Me.GVConf.CurrentCell IsNot Nothing Then
                If GVConf.Rows.Count > 0 Then
                    If GVConf.SelectedRows.Count > 0 Then
                        Dim xModeloCor, xModeloID, xCorID As String
                        xModeloID = Me.GVConf("ModeloID", Me.GVConf.CurrentCell.RowIndex).Value
                        xCorID = Me.GVConf("CorID", Me.GVConf.CurrentCell.RowIndex).Value
                        xModeloCor = xModeloID & xCorID
                        CarregarFoto.CarregarFotoModeloCor(Me.PictureBoxFoto, xModeloCor, "xok")
                    End If
                End If
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": GVConf_CurrentCellChanged")
        End Try
    End Sub

    Private Sub cmdConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfirmar.Click
        Dim db As New ClsSqlBDados
        Dim xNumDoc, xSerieID, xEstConf As String
        xEstConf = ""
        Try
            xNumDoc = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value.ToString
            For Each r As DataRow In dtDepTemp.Rows
                xSerieID = r("SerieID")
                If r("Est") = "T" Then
                    xEstConf = "TC"
                ElseIf r("Est") = "S" Then
                    xEstConf = "SC"
                ElseIf r("Est") = "V" Then
                    xEstConf = "VC"
                End If
                dtConfere.Rows.Add(New Object() {r("SerieID"), r("ModeloID"), r("CorID"), r("TamID"), xEstConf, r("DataEnvio"), r("Valor")})
                ActulizarEstadoLn(db, xSerieID, xNumDoc, xEstConf)
            Next
            Me.dtDepTemp.Clear()
            CarregarFoto.CarregarFotoModeloCor(Me.PictureBoxFoto, "", "xok")
            ActualizarContadores()
            Me.txtCodBarras.Text = Nothing
            Me.txtCodBarras.Focus()
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": cmdConfirmar_Click")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            xNumDoc = Nothing
        End Try
    End Sub

    Private Sub ActulizarEstadoLn(ByVal db As ClsSqlBDados, ByVal xSerieID As String, ByVal xNumDoc As String, ByVal xEstConf As String)
        Try
            'ACTUALIZAR ESTADO DA LINHA NO DETALHE DO DOC. DE CONFERÊNCIA
            Sql = "UPDATE DocDet " & _
                  "SET EstadoLn = '" & xEstConf & "' " & _
                  "WHERE EmpresaID = '" & xEmp & "' " & _
                  "AND ArmazemID = '" & xArmz & "' " & _
                  "AND TipoDocID = 'CF' " & _
                  "AND DocNr = '" & xNumDoc & "' " & _
                  "AND SerieID = '" & xSerieID & "' "
            db.ExecuteData(Sql)
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": ActulizarEstadoLn")
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Dim xDocNr As String
        Dim db As New ClsSqlBDados
        Try
            xDocNr = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value
            dtDet.Clear()
            'ACTUALIZA C1tgDocDet
            Sql = "SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, EstadoLn as Est, Obs as DataEnvio, Valor " & _
                  "FROM DocDet " & _
                  "WHERE EmpresaID='" & xEmp & "' " & _
                  "AND ArmazemID='" & xArmz & "' " & _
                  "AND TipoDocID='CF' " & _
                  "AND DocNR='" & xDocNr & "' " & _
                  "AND EstadoLn in ('S', 'T', 'V')"
            db.GetData(Sql, dtDet)
            Me.dtDepTemp.Clear()
            CarregarFoto.CarregarFotoModeloCor(Me.PictureBoxFoto, "", "xok")
            ActualizarContadores()
            Me.txtCodBarras.Text = Nothing
            Me.txtCodBarras.Focus()
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": cmdConfirmar_Click")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub btPrintConferidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrintConferidos.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim xNumDoc As String = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value.ToString
            ListaConferidos(xNumDoc)
            Application.DoEvents()


        Catch ex As Exception

            ErroVB(ex.Message, Me.Name + ": btPrintConferidos_Click")

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btCriarFC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCriarFC.Click
        GravarConsignacao()
    End Sub

    Private Sub GravarConsignacao()

        Dim db As New ClsSqlBDados
        Dim maxDocnr As String = ""
        Dim xDocNr As String
        Dim xTercID As String
        'Dim LnAux As Integer



        Try

            maxDocnr = PesquisaMaxNumDoc("FC")

            xDocNr = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value

            Sql = "SELECT TercID FROM ARMAZENS where ArmazemID='" & Me.GVDocCab("TercID", Me.GVDocCab.CurrentCell.RowIndex).Value & "'"
            xTercID = db.GetDataValue(Sql)

            Sql = "INSERT into DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, DescontoDoc, EstadoDoc, TipoTerc, OperadorID) " & _
                 "SELECT EmpresaID, ArmazemID, 'FC' TipoDocID, '" + maxDocnr + "' DocNr, '" & xTercID & "', dbo.data(getdate()) DataDoc, TipoDocID TipoDocOrig, DocNr DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, DescontoDoc, EstadoDoc, TipoTerc, '" + xUtilizador + "' " & _
                 "FROM DocCab " & _
                 "WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + xArmz + "' AND TipoDocID = 'CF' AND DocNr ='" + xDocNr + "'"
            db.ExecuteData(Sql)

            Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, ModeloID, CorID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, Qtd,  Obs, EstadoLn, OperadorID) SELECT     EmpresaID, ArmazemID, 'FC' AS TipoDocID, '" + maxDocnr + "' AS DocNr, MIN(DocLnNr) AS Expr8, ModeloID, CorID, Descricao, Unidade, MIN(DocNrLnOrig)  AS Expr7, MIN(Valor)*0.6 AS Expr2, AVG(PercDescLn) AS Expr3, SUM(VlrDescLn) AS Expr4, '" & xIvaID & "', SUM(Qtd) AS Qtd, MIN(Obs) AS Expr5, MIN(EstadoLn)  AS Expr6, '" + xUtilizador + "' AS Expr1 FROM         DocDet AS DocDet_1 WHERE     (TipoDocID = 'CF') AND (DocNr = '" + xDocNr + "') GROUP BY EmpresaID, ArmazemID, ModeloID, CorID, Descricao, Unidade, IvaID HAVING      (EmpresaID = '" + xEmp + "') AND (ArmazemID = '" + xArmz + "')"
            db.ExecuteData(Sql)

            'HELDER: FAZER CICLO PARA RECTIFICA NUMERO DA LINHA

        Catch ex As Exception
            ErroVB(ex.Message, "GravarConsignacao")
        Finally

            If db IsNot Nothing Then db.Dispose()
        End Try
    End Sub



    Private Sub btActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btActualizar.Click

        Me.Cursor = Cursors.WaitCursor


        'ACTUALIZAR ESTADO DOS TALÕES NA TABELA GRID: GVDOCDET
        Dim db As New ClsSqlBDados


        Try


            Dim xDocNr As String = Me.GVDocCab("DocNr", Me.GVDocCab.CurrentCell.RowIndex).Value
            'Sql = "UPDATE DocDet SET EstadoLn = Serie.EstadoID FROM DocDet INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmz & "') AND (DocDet.TipoDocID = 'CF') AND (DocDet.DocNr = '" & xDocNr & "')"
            Sql = "UPDATE DocDet SET EstadoLn = Serie.EstadoID FROM DocDet INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmz & "') AND (DocDet.TipoDocID = 'CF') AND (DocDet.DocNr = '" & xDocNr & "') AND DocDet.EstadoLn NOT IN ('SC','TC','VC')"
            db.ExecuteData(Sql)

            If Me.GVDocCab.SelectedRows.Count > 0 Then
                ActualizaDetalhe()
            End If






        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btActualizar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btActualizar_Click")


        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub





End Class
