Imports System.Data.SqlClient
Imports C1.Win.C1TrueDBGrid


Public Class frmRecolha

    Dim dtCab As New DataTable
    Dim dtDestinos As New DataTable
    Dim dtDet As New DataTable
    Dim dtdetResumo As New DataTable
    Dim xArmzAux As String
    Dim xDocNr As String
    Dim xEstadoDoc As String
    Dim sLinha As Integer
    Dim sQuery As String = ""







    Private Sub frmRecolha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Val As New clsValidacoes(Me.Name)

        'WindowState = FormWindowState.Maximized


        'HELDER : NO REPORT ESCONDER O CABEÇALHO DA PAG NA 1ªPAG  

        Select Case xAplicacao
            Case "POS"
                d2d = "0"
                Me.CmdGerRecolha.Visible = False
                Me.CmdValidarRecolha.Visible = False
                cbVerTodas.Visible = False
                'APARECEM TODAS AS RECOLHAS EFECTUADAS
                lbCab.Text = "Lista de Recolhas"

            Case "BACKOFFICE"
                Me.CmdGerRecolha.Visible = False
                Me.CmdValidarRecolha.Visible = True
                cbVerTodas.Visible = True
                cbVerTodas.CheckState = CheckState.Unchecked
                lbCab.Text = "Recolhas Pendentes"
        End Select
        C1TGReCab.AllowDelete = Val.ValidarPermicoes("ApagarRecolhas")
        'btFacturar.Visible = Val.ValidarPermicoes("BtFacturar")
        ActualizaCabeçalho()


    End Sub


    'EVENTOS NA C1TGRECAB



    Private Sub C1TGReCab_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles C1TGReCab.BeforeDelete
        Dim dtDeleteAux As New DataTable
        Dim db As New ClsSqlBDados
        Try

            Dim xArmzDoc As String = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "ArmazemID")
            Dim xNumDoc As String = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "DocNr")
            Dim xSerie As String

            If MsgBox("Vai Apagar a Recolha " & xNumDoc & " do Armazem " & xArmzDoc & "!! Confirma?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Sql = "SELECT SerieID, Descricao, Qtd FROM docdet WHERE EmpresaID='" & xEmp & "' and ArmazemID='" & xArmzDoc & "' and TipoDocID='RE' and DocNr='" & xNumDoc & "'"
                db.GetData(Sql, dtDeleteAux)
                If dtDeleteAux.Rows.Count > 0 Then
                    For Each r As DataRow In dtDeleteAux.Rows
                        xSerie = r("SerieID")
                        If r("Qtd") > 0 Then
                            Sql = "UPDATE Serie SET EstadoID = 'V' WHERE SerieID = '" & r("SerieID") & "' AND EstadoID = 'R' "
                        Else
                            Sql = "UPDATE DocDet SET EstadoLN = 'G' WHERE EmpresaID='" & xEmp & "' AND ArmazemID = '" & xArmzDoc & "' AND TipoDocID='DC' AND EstadoLN = 'R' AND SerieID = '" & r("SerieID") & "' AND DocNr = '" & r("Descricao") & "'"
                        End If
                        db.ExecuteData(Sql)
                    Next
                End If

                Application.DoEvents()
                Sql = "DELETE FROM DocCab WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmzDoc & "' AND TipoDocID = 'RE' AND DocNr = '" & xNumDoc & "' "
                db.ExecuteData(Sql)
                dtDeleteAux.Clear()

                'Sql = "UPDATE DocDet SET EstadoLN = 'R' WHERE EmpresaID='" & xEmp & "' AND ArmazemID = '" & xArmzDoc & "' AND DocCab.DocNrOrig = '" & xNumDoc & "' AND TipoDocID='DC' AND EstadoLN = 'G'"


                Sql = "UPDATE DocDet SET EstadoLn = 'R' FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID " & _
                    "AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr " & _
                    "WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmzDoc & "') AND (DocDet.TipoDocID = 'DC') " & _
                    "AND (DocDet.EstadoLn = 'G') AND (DocCab.DocNrOrig = '" & xNumDoc & "')"


                db.ExecuteData(Sql)


            Else
                e.Cancel = True
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TGReCab_BeforeDelete")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TGReCab_BeforeDelete")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing

        End Try

    End Sub

    Private Sub C1TGReCab_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1TGReCab.AfterDelete
        Try

            dtCab.AcceptChanges()
            ActualizaDetalhe()

            C1TGReCab.MarqueeStyle = MarqueeEnum.NoMarquee
            C1TGReCab.SelectedRows.Clear()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TGReCab_AfterDelete")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TGReCab_AfterDelete")

        End Try

    End Sub

    Private Sub C1TGReCab_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles C1TGReCab.RowColChange
        'VAI ACTUALIZAR O DETALHE
        TimerActDados.Stop()
        TimerActDados.Interval = 500
        TimerActDados.Start()
    End Sub

    Private Sub TimerActDados_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerActDados.Tick
        TimerActDados.Stop()
        ActualizaDetalhe()
    End Sub

    Private Sub C1TGReCab_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1TGReCab.AfterUpdate
        Dim db As New ClsSqlBDados

        Try

            Dim xReArmz As String = C1TGReCab(sLinha, "ArmazemID")
            Dim xReDocNr As String = C1TGReCab(sLinha, "DocNr")
            Dim xReObs As String = ""
            Dim xReObs1 As String = ""

            If Not C1TGReCab(sLinha, "Obs") Is DBNull.Value Then
                xReObs = C1TGReCab(sLinha, "Obs")
            End If

            Sql = "UPDATE DocCab SET Obs='" & xReObs & "' where EmpresaID='" & xEmp & "' AND ArmazemID='" & xReArmz & "' AND  TipoDocID = 'RE' AND DocNr = '" & xReDocNr & "'"
            db.ExecuteData(Sql)

            '--------------------ACTUALIZA OBS LOJA---------------------------
            If Not C1TGReCab(sLinha, "Obs1") Is DBNull.Value Then
                xReObs1 = C1TGReCab(sLinha, "Obs1")
            End If

            Sql = "UPDATE DocCab SET Obs1='" & xReObs1 & "' where EmpresaID='" & xEmp & "' AND ArmazemID='" & xReArmz & "' AND  TipoDocID = 'RE' AND DocNr = '" & xReDocNr & "'"
            db.ExecuteData(Sql)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TGReCab_AfterUpdate")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TGReCab_AfterUpdate")

        End Try
    End Sub

    Private Sub C1TGReCab_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles C1TGReCab.BeforeRowColChange
        sLinha = C1TGReCab.Row
    End Sub

    Private Sub C1TGReCab_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1TGReCab.FilterChange
        C1TrueDBGridFilterChange(C1TGReCab, Me.C1TGReCab.Columns, dtCab, sQuery)
    End Sub


    'EVENTOS NA dgvDespesas


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim I As Integer = 1

        Try


            If keyData = Keys.Enter Then
                'If Me.dgvDespesas.Columns(dgvDespesas.CurrentCell.ColumnIndex).Name <> "Valor" Then
                '    If TypeOf Me.ActiveControl Is DataGridViewTextBoxEditingControl Or TypeOf Me.ActiveControl Is DataGridViewComboBoxEditingControl Then
                '        If dgvDespesas.CurrentCell.ColumnIndex < dgvDespesas.ColumnCount - 1 Then
                '            Do While dgvDespesas.Rows(dgvDespesas.CurrentCell.RowIndex).Cells(dgvDespesas.CurrentCell.ColumnIndex + I).Visible = False
                '                I = I + 1
                '            Loop
                '            dgvDespesas.CurrentCell = dgvDespesas.Rows(dgvDespesas.CurrentCell.RowIndex).Cells(dgvDespesas.CurrentCell.ColumnIndex + I)
                '        Else
                '            Return MyBase.ProcessCmdKey(msg, keyData)
                '        End If
                '    End If
                'Else
                '    dgvDespesas.CurrentCell = dgvDespesas.Rows(dgvDespesas.CurrentCell.RowIndex + 1).Cells("Descricao")

                'End If

                'Return MyBase.ProcessCmdKey(msg, keyData)

            End If




        Catch ex As Exception

            ErroVB(ex.Message, "ProcessCmdKey")

        Finally



        End Try


    End Function

    Private Sub dgvDespesas_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDespesas.CellEndEdit

        If (e.ColumnIndex = 1) Then   ' Checking numeric value for Column1 only
            Dim xValor As String = ""
            xValor = dgvDespesas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
            'If Not Char.IsDigit(value) Then
            If Not IsNumeric(xValor) Then
                MessageBox.Show("Introduzir Valor Numérico.")
                dgvDespesas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
                SendKeys.Send("{up}")
                SendKeys.Send("{right}")
            End If

            dgvDespesas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(Val(xValor), "#.00€")

        End If



    End Sub

    Private Sub dgvDespesas_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvDespesas.CellValidating
        'If e.ColumnIndex = 1 Then
        '    If Not IsNumeric(e.FormattedValue) Then
        '        MessageBox.Show("Please enter numeric value.")
        '        e.Cancel = True
        '    End If
        'End If
    End Sub



    'Private Sub btDespesas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    'Dim db As New ClsSqlBDados

    '    'Dim xDocNrOrig As String = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "DocNr")
    '    'Dim xArmzAux As String = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "ArmazemID")
    '    'Dim xData As String = Format(CType(Now(), Date), "yyyy-MM-dd H:mm:ss")

    '    'Dim xNovoDoc As String = PesquisaMaxNumDoc("DP")


    '    'Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, DataDoc, TipoDocOrig, DocNrOrig, EstadoDoc, OperadorID) " & _
    '    '"VALUES('" & xEmp & "','" & xArmzAux & "','DP','" & xNovoDoc & "','" & xData & "','RE', '" & xDocNrOrig & "','C','" & xUtilizador & "')"
    '    'db.ExecuteData(Sql)

    '    'Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, EstadoLn, OperadorID) " & _
    '    '"VALUES ('" & xEmp & "', '" & xArmzAux & "', 'DP', '" & xNovoDoc & "', '1', 'C', '" & xUtilizador & "')"
    '    'db.ExecuteData(Sql)

    '    'btDespesas.Visible = False

    '    'AtualizaDespesas()

    'End Sub




    'Private Sub dgvDespesas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDespesas.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Dim numCols As Integer = dgvDespesas.ColumnCount
    '        Dim numRows As Integer = dgvDespesas.RowCount
    '        Dim currCell As DataGridViewCell = dgvDespesas.CurrentCell

    '        If currCell.ColumnIndex = numCols - 1 Then
    '            If currCell.RowIndex < numRows - 1 Then
    '                dgvDespesas.CurrentCell = dgvDespesas.Item(0, currCell.RowIndex + 1)
    '            End If
    '        Else
    '            dgvDespesas.CurrentCell = dgvDespesas.Item(currCell.ColumnIndex + 1, currCell.RowIndex)
    '        End If
    '        e.Handled = True
    '    End If



    'End Sub




    'SendKeys.Send("{Enter}")
    'SendKeys.Send("{up}")
    ''SendKeys.Send("{right}")




    'Private Sub btDespesas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    'Dim db As New ClsSqlBDados

    '    'Dim xDocNrOrig As String = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "DocNr")
    '    'Dim xArmzAux As String = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "ArmazemID")
    '    'Dim xData As String = Format(CType(Now(), Date), "yyyy-MM-dd H:mm:ss")

    '    'Dim xNovoDoc As String = PesquisaMaxNumDoc("DP")


    '    'Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, DataDoc, TipoDocOrig, DocNrOrig, EstadoDoc, OperadorID) " & _
    '    '"VALUES('" & xEmp & "','" & xArmzAux & "','DP','" & xNovoDoc & "','" & xData & "','RE', '" & xDocNrOrig & "','C','" & xUtilizador & "')"
    '    'db.ExecuteData(Sql)

    '    'Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, EstadoLn, OperadorID) " & _
    '    '"VALUES ('" & xEmp & "', '" & xArmzAux & "', 'DP', '" & xNovoDoc & "', '1', 'C', '" & xUtilizador & "')"
    '    'db.ExecuteData(Sql)

    '    'btDespesas.Visible = False

    '    'AtualizaDespesas()

    'End Sub



    'FUNÇÕES

    Private Sub ActualizaCabeçalho()

        Dim db As New ClsSqlBDados
        Cursor = Cursors.WaitCursor


        Try

            dtCab.Clear()

            If xAplicacao = "POS" Then
                'VAI CARREGAR TODAS AS RECOLHAS EFECTUADAS NA RESPECTIVA LOJA
                Sql = "SELECT DocCab.DataDoc, DocCab.ArmazemID, Armazens.ArmAbrev, DocCab.DocNr, DocCab.Obs1, DocCab.Obs, DocCab.EstadoDoc " & _
                "FROM DocCab, Armazens WHERE DocCab.ArmazemID = Armazens.ArmazemID AND DocCab.EmpresaID = '" & xEmp & "' AND DocCab.ArmazemID = '" & xArmz & "' AND DocCab.TipoDocID = 'RE' AND DocCab.EstadoDoc = 'P' ORDER BY DocCab.DataDoc DESC, DocCab.ArmazemID DESC, DocCab.DocNr DESC"
            Else
                If cbVerTodas.CheckState = CheckState.Checked Then
                    'VAI CARREGAR TODAS AS RECOLHAS EFECTUADAS
                    Sql = "SELECT DocCab.DataDoc, DocCab.ArmazemID, Armazens.ArmAbrev, DocCab.DocNr, DocCab.Obs1, DocCab.Obs, DocCab.EstadoDoc " & _
                    "FROM DocCab, Armazens WHERE DocCab.ArmazemID = Armazens.ArmazemID AND DocCab.EmpresaID = '" & xEmp & "' AND DocCab.TipoDocID = 'RE' ORDER BY DocCab.DataDoc DESC, DocCab.ArmazemID DESC, DocCab.DocNr DESC"
                Else
                    'VAI CARREGAR TODAS AS RECOLHAS EFECTUADAS MAS AINDA NÃO VALIDADAS
                    Sql = "SELECT DocCab.DataDoc, DocCab.ArmazemID, Armazens.ArmAbrev, DocCab.DocNr, DocCab.Obs1, DocCab.Obs, DocCab.EstadoDoc " & _
                    "FROM DocCab, Armazens WHERE DocCab.ArmazemID = Armazens.ArmazemID AND DocCab.EmpresaID = '" & xEmp & "' AND DocCab.TipoDocID = 'RE' AND DocCab.EstadoDoc = 'P' ORDER BY DocCab.DataDoc DESC, DocCab.ArmazemID DESC, DocCab.DocNr DESC"
                End If

            End If

            If d2d = "1" Then
                Me.CmdGerRecolha.Visible = False
                Me.CmdValidarRecolha.Visible = False
                'Me.btFacturar.Visible = False
                cbVerTodas.Visible = False


                lbCab.Text = "Recolha de Malas"
                Sql = "SELECT C.DataDoc, C.ArmazemID, A.ArmAbrev, C.DocNr, C.Obs1, C.Obs, C.EstadoDoc " & _
                    "FROM DocCab C,DocDet D, Modelos M, Armazens A " & _
                    "WHERE(C.ArmazemID = A.ArmazemID) " & _
                    "AND C.EmpresaID = D.EmpresaID " & _
                    "AND C.ArmazemID = D.ArmazemID " & _
                    "AND C.TipoDocID = D.TipoDocID " & _
                    "AND C.DocNr = D.DocNr " & _
                    "AND D.ModeloID = M.ModeloID " & _
                    "AND C.EmpresaID = '" & xEmp & "'  " & _
                    "AND C.TipoDocID = 'RE'  " & _
                    "AND M.GrupoID in ('6','4') " & _
                    "GROUP BY C.ArmazemID, A.ArmAbrev, C.DocNr, C.Obs1, C.Obs, C.DataDoc,C.EstadoDoc " & _
                    "ORDER BY C.DataDoc DESC, C.ArmazemID DESC, C.DocNr DESC"

            End If


            db.GetData(Sql, dtCab)

            If d2d <> "1" Then

                If dtCab.Columns.Count = 7 Then
                    dtCab.Columns.Add("Deposito", GetType(Double))
                End If


                Dim xDespesas As Double
                'For Each r As DataRow In dtCab.Rows
                '    Sql = "SELECT ISNULL(SUM(Valor * Qtd - PercDescLn * Valor * Qtd),0) AS Deposito FROM DocDet " & _
                '    "WHERE (EmpresaID = '" & xEmp & "') AND (ArmazemID = '" & r("ArmazemID") & "') AND (TipoDocID = 'RE') AND (DocNr = '" & r("DocNr") & "')"
                '    r("Deposito") = db.GetDataValue(Sql)
                '    'Sql = "SELECT ISNULL(SUM(TamReservas.Despesas), 0) AS DespTotal FROM (SELECT ReservaSerieID, Despesas FROM Reservas WHERE (ReservaID IN (SELECT DISTINCT MAX(ReservaID) AS Expr1 FROM Reservas AS Reservas_1 GROUP BY ReservaSerieID)) AND (Despesas <> 0) GROUP BY ReservaSerieID, Despesas) AS TamReservas INNER JOIN DocDet AS DocDet ON TamReservas.ReservaSerieID = DocDet.SerieID WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & r("ArmazemID") & "') AND (DocDet.TipoDocID = 'RE') AND (DocDet.DocNr = N'" & r("DocNr") & "')"
                '    Sql = "SELECT ISNULL(SUM(TamReservas.Despesas), 0) AS DespTotal FROM (SELECT ReservaSerieID, Despesas FROM Reservas WHERE (ReservaID IN (SELECT DISTINCT MAX(ReservaID) AS Expr1 FROM Reservas AS Reservas_1 GROUP BY ReservaSerieID)) AND (Despesas <> 0) GROUP BY ReservaSerieID, Despesas) AS TamReservas INNER JOIN DocDet AS DocDet ON TamReservas.ReservaSerieID = DocDet.SerieID WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & r("ArmazemID") & "') AND (DocDet.TipoDocID = 'RE') AND (DocDet.DocNr = N'" & r("DocNr") & "') AND (DocDet.Qtd > 0)"
                '    xDespesas = db.GetDataValue(Sql)
                '    r("Deposito") = r("Deposito") + xDespesas
                'Next

            End If

            Dim ColCab As C1DisplayColumn

            With Me.C1TGReCab
                .DataSource = dtCab
                .Columns("DocNr").Caption = "Doc"
                .Columns("ArmazemID").Caption = "Cod"
                .Columns("ArmAbrev").Caption = "Loja"
                .Columns("DataDoc").Caption = "Data"
                .Columns("Obs1").Caption = "ObsLoja"
                .Columns("DataDoc").NumberFormat = "yyyy-MM-dd"
                If xAplicacao = "POS" Then
                    .Splits(0).DisplayColumns("EstadoDoc").Visible = False
                    .Splits(0).DisplayColumns("Obs").Visible = False
                    .Splits(0).DisplayColumns("ArmazemID").Visible = False
                    .Splits(0).DisplayColumns("ArmAbrev").Visible = False
                Else
                    .Splits(0).DisplayColumns("EstadoDoc").Visible = True
                    .Splits(0).DisplayColumns("Obs").Visible = True
                    .Columns("EstadoDoc").Caption = "E"
                End If

                .Splits(0).DisplayColumns("DataDoc").Width = 63
                .Splits(0).DisplayColumns("ArmazemID").Width = 30
                .Splits(0).DisplayColumns("ArmAbrev").Width = 70
                .Splits(0).DisplayColumns("DocNr").Width = 0
                .Splits(0).DisplayColumns("Obs").Width = 120
                .Splits(0).DisplayColumns("EstadoDoc").Width = 15
                If d2d <> "1" Then
                    .Splits(0).DisplayColumns("Deposito").Width = 65
                End If


                .Splits(0).DisplayColumns("Deposito").Visible = False





                .MarqueeStyle = MarqueeEnum.HighlightRow
                Dim xTamLetra As Single = 8
                If xAplicacao = "POS" Then xTamLetra = 10
                For Each ColCab In Me.C1TGReCab.Splits(0).DisplayColumns
                    ColCab.Style.Font = New Font("Arial", xTamLetra, FontStyle.Regular)
                    ColCab.HeadingStyle.Font = New Font("Arial", xTamLetra, FontStyle.Bold)
                    ColCab.HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                    ColCab.Locked = True
                    'ColCab.AutoSize()
                Next
                .Splits(0).DisplayColumns("Obs").Locked = False
                If xAplicacao = "POS" Then
                    .Splits(0).DisplayColumns("DataDoc").Width = 80
                    .Splits(0).DisplayColumns("Obs1").Width = 300
                    .Splits(0).DisplayColumns("Obs1").Locked = False
                Else
                    .Splits(0).DisplayColumns("Obs1").Width = 130
                End If

                If d2d <> "1" Then
                    .Columns("Deposito").NumberFormat = "Currency"

                End If

                .RowHeight = 20
                .Refresh()
                .FilterBar = True
            End With

            ActualizaDetalhe()


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaCabeçalho")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaCabeçalho")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ActualizaDetalhe()
        Try
            xDocNr = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "DocNr")
            xArmzAux = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "ArmazemID")
            Dim coluna As C1DisplayColumn
            dtDet.Clear()

            If d2d = "1" Then
                Sql = "SELECT DocDet.SerieID as Talão, DocDet.ModeloID as Modelo, DocDet.CorID as Cor, DocDet.TamID as Tam, Modelos.LinhaID, Linhas.DescrLinha as Linha, DocDet.PercDescLn as '%C', DocDet.Valor * DocDet.Qtd as ValorVnd, dtSaida as DtVenda, (DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) as Comissão, (DocDet.Valor-DocDet.PercDescLn * DocDet.Valor)*DocDet.Qtd as Deposito " & _
                 "FROM DocDet INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID " & _
                 "WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmzAux & "') AND (DocDet.TipoDocID = 'RE') AND (DocDet.DocNr = '" & xDocNr & "') AND (Modelos.GrupoId in ('6','4'))"

            Else
                Sql = "SELECT DocDet.SerieID as Talão, DocDet.ModeloID as Modelo, DocDet.CorID as Cor, DocDet.TamID as Tam, Modelos.LinhaID, Linhas.DescrLinha as Linha, DocDet.PercDescLn as '%C', DocDet.Valor * DocDet.Qtd as ValorVnd, dtSaida as DtVenda, (DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) as Comissão, (DocDet.Valor-DocDet.PercDescLn * DocDet.Valor)*DocDet.Qtd as Deposito " & _
                "FROM DocDet INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID " & _
                "WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmzAux & "') AND (DocDet.TipoDocID = 'RE') AND (DocDet.DocNr = '" & xDocNr & "')"

                'Sql = "SELECT DocDet.SerieID as Talão, DocDet.ModeloID as Modelo, DocDet.CorID as Cor, DocDet.TamID as Tam, Modelos.LinhaID, Linhas.DescrLinha as Linha, Serie.Comissao as '%C', Serie.PVndReal as ValorVnd, dtSaida as DtVenda, (Serie.Comissao * Serie.PVndReal) as Comissão, (Serie.PVndReal-Serie.Comissao * Serie.PVndReal) as Deposito " & _
                '  "FROM DocDet INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID " & _
                '  "WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmzAux & "') AND (DocDet.TipoDocID = 'RE') AND (DocDet.DocNr = '" & xDocNr & "')"
            End If



            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtDet)
            'C1FlexGReDet  C1TGReDet
            With Me.C1TGReDet
                .DataSource = dtDet
                .Columns("ValorVnd").NumberFormat = "Currency"
                .Columns("Comissão").NumberFormat = "Currency"
                .Columns("Deposito").NumberFormat = "Currency"
                .Columns("%C").NumberFormat = "p"
                .Columns("DtVenda").NumberFormat = "Short Date"


                .Splits(0).DisplayColumns("LinhaID").Visible = False


                .Splits(0).DisplayColumns("Comissão").Visible = False
                .Splits(0).DisplayColumns("DtVenda").Visible = False



                For Each coluna In .Splits(0).DisplayColumns
                    coluna.Style.Font = New Font("Arial", 9, FontStyle.Regular)
                    coluna.HeadingStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                    coluna.HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                    coluna.AutoSize()
                Next
                .Refresh()
            End With
            'ACTUALIZAR RESUMO : c1fgRecolhaResumo

            dtdetResumo.Clear()

            If d2d = "1" Then

                Sql = "SELECT Modelos.LinhaID, Linhas.DescrLinha as Linha, DocDet.PercDescLn as '%C', " & _
                    "SUM(DocDet.Qtd) as Qtd, SUM(DocDet.Valor*DocDet.Qtd) as ValorVnd, " & _
                    "SUM(DocDet.PercDescLn * DocDet.Valor*Qtd) as Comissão, " & _
                    "SUM(DocDet.Valor*Qtd-DocDet.PercDescLn * DocDet.Valor*Qtd) as Deposito " & _
                    "FROM DocDet " & _
                    "INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID " & _
                    "INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID " & _
                    "WHERE DocDet.EmpresaID = '" & xEmp & "' " & _
                    "AND DocDet.ArmazemID = '" & xArmzAux & "' " & _
                    "AND DocDet.TipoDocID = 'RE' " & _
                    "AND DocDet.DocNr = '" & xDocNr & "' " & _
                    "AND (Modelos.GrupoId in ('6','4')) " & _
                    "GROUP BY Modelos.LinhaID, Linhas.DescrLinha, DocDet.PercDescLn"

            Else

                Sql = "SELECT Modelos.LinhaID, Linhas.DescrLinha as Linha, DocDet.PercDescLn as '%C', " & _
                    "SUM(DocDet.Qtd) as Qtd, SUM(DocDet.Valor*DocDet.Qtd) as ValorVnd, " & _
                    "SUM(DocDet.PercDescLn * DocDet.Valor*Qtd) as Comissão, " & _
                    "SUM(DocDet.Valor*Qtd-DocDet.PercDescLn * DocDet.Valor*Qtd) as Deposito " & _
                    "FROM DocDet " & _
                    "INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID " & _
                    "INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID " & _
                    "WHERE DocDet.EmpresaID = '" & xEmp & "' " & _
                    "AND DocDet.ArmazemID = '" & xArmzAux & "' " & _
                    "AND DocDet.TipoDocID = 'RE' " & _
                    "AND DocDet.DocNr = '" & xDocNr & "' " & _
                    "GROUP BY Modelos.LinhaID, Linhas.DescrLinha, DocDet.PercDescLn"
            End If



            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtdetResumo)

            With c1fgRecolhaResumo
                .DataSource = dtdetResumo
                .Cols("LinhaID").Visible = False
                .SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
                .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
                .Tree.Column = 0
                .Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear)
                .Cols(0).Width = 65
                Dim c As Integer
                For c = 4 To .Cols.Count - 1
                    .Subtotal(AggregateEnum.Sum, 0, -1, c, "Total")
                Next
                .Cols("%C").Format = "00%"
                .Cols("ValorVnd").Format = "#.00€"
                .Cols("Comissão").Format = "#.00€"
                .Cols("Deposito").Format = "#.00€"

                .Cols("ValorVnd").Caption = "Valor"
                .Cols("Comissão").Caption = "Loja%"
                .Cols("Deposito").Caption = "Dep"

                'ESCONDER AS COLUNAS DE COMISSÃO E DEPOSITO


                If xGrupoAcesso = "ADMIN" Then
                    .Cols("Comissão").Visible = True
                    .Cols("Deposito").Visible = True
                Else
                    .Cols("Comissão").Visible = False
                    .Cols("Deposito").Visible = False
                End If




                .AutoSizeCols()
                .Tree.Show(0)


                AtualizaDespesas()



            End With
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaDetalhe")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaDetalhe")
        Finally
            cn.Close()
            Sql = Nothing
        End Try

    End Sub

    Private Sub CmdGerRecolha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGerRecolha.Click
        'TODO: ESTA FUNÇÃO SÓ VAI FUNCIONAR NO POS
        GerarRecolha()
        ActualizaCabeçalho()
    End Sub

    Private Sub CmdValidarRecolha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdValidarRecolha.Click

        Try
            If MsgBox("Confirma Validação da Recolha nº" & xDocNr & " no Armazém " & xArmzAux & " ?", MsgBoxStyle.YesNo, "Confirmação Envio") <> MsgBoxResult.No Then

                xEstadoDoc = Trim(Me.C1TGReCab(Me.C1TGReCab.Bookmark, "EstadoDoc"))
                If xEstadoDoc = "P" Then
                    Sql = "UPDATE DocCab SET EstadoDoc = 'C' WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmzAux & "' AND TipoDocID = 'RE' AND DocNr = '" & xDocNr & "' AND EstadoDoc = 'P'"
                    If cn.State = ConnectionState.Closed Then cn.Open()
                    Cmd = New SqlCommand(Sql, cn)
                    Cmd.ExecuteNonQuery()
                    cn.Close()
                    ActualizaCabeçalho()
                End If

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaCabeçalho")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaCabeçalho")
        End Try

    End Sub

    Private Sub GerarRecolha()

        Try

            'TODO: ANTES DE INTEGRAR ESTE DOCUMENTO NA BASE, TEM QUE SER INTEGRADO O DOCUMENTO DAS VENDAS
            'TODO: AO INTEGRAR ESTES DOIS DOCUMENTOS, TEMOS QUE ACTUALIZAR A TABELA SERIE

            Dim xNovaRe As String = PesquisaMaxNumDoc("RE")
            Dim xData As String = Format(Now, "yyyy-MM-dd hh:mm:ss")
            Dim dtReAux As New DataTable
            Dim dtReDev As New DataTable

            'Sql = "SELECT Serie.* FROM Serie WHERE (EstadoID = 'V') AND ArmazemID = '" & xArmz & "'"

            Sql = "SELECT Unidades.UnidDescr, ModeloCor.ModCorDescr, Serie.* " & _
                "FROM Serie INNER JOIN " & _
                "Modelos ON Serie.ModeloID = Modelos.ModeloID INNER JOIN " & _
                "Unidades ON Modelos.UnidID = Unidades.UnidID INNER JOIN " & _
                "ModeloCor ON Serie.ModeloID = ModeloCor.ModeloID AND Serie.CorID = ModeloCor.CorID " & _
                "WHERE Serie.EstadoID = 'V' AND Serie.ArmazemID =  '" & xArmz & "'"


            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtReAux)

            If dtReAux.Rows.Count() > 0 Then
                If MsgBox("Vai Gerar uma nova Recolha! Confirma ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, OperadorID) " & _
                                         "VALUES('" & xEmp & "','" & xArmz & "','RE','" & xNovaRe & "','" & xArmz & "','" & xData & "','P','" & xUtilizador & "')"

                    If cn.State = ConnectionState.Closed Then cn.Open()
                    Cmd = New SqlCommand(Sql, cn)
                    Cmd.ExecuteNonQuery()

                    Dim xDocLnNr As String

                    If dtReAux.Rows.Count > 0 Then
                        If cn.State = ConnectionState.Closed Then cn.Open()
                        Sql = "SELECT ISNULL(MAX(DocLnNr),0)+1 FROM DocDet WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'RE' AND DocNr = '" & xNovaRe & "'"
                        Cmd = New SqlCommand(Sql, cn)
                        xDocLnNr = Cmd.ExecuteScalar
                        If CInt(xDocLnNr) >= 1 Then
                            For Each r As DataRow In dtReAux.Rows
                                Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, Valor, PercDescLn, IvaID, Qtd, EstadoLn, OperadorID) " & _
                                    "VALUES ('" & xEmp & "', '" & xArmz & "', 'RE', '" & xNovaRe & "', " & xDocLnNr & ", '" & r("SerieID") & "', '" & r("ModeloID") & "', '" & r("CorID") & "', " & r("TamID") & ", '" & r("ModCorDescr") & "', '" & r("UnidDescr") & "', '" & r("PVndReal") & "', '" & r("Comissao") & "', '" & xIvaID & "', 1, 'G','" & xUtilizador & "')"
                                If cn.State = ConnectionState.Closed Then cn.Open()
                                Cmd = New SqlCommand(Sql, cn)
                                Cmd.ExecuteNonQuery()

                                'ACTUALIZA ESTADO DO TALÃO NA TABELA SERIE
                                'Sql = "UPDATE Serie SET EstadoID = 'R', DtSaida = GETDATE(), DocNr = '" & xNovaRe & "', DtRegisto = GETDATE() WHERE SerieID = '" & r("SerieID") & "'"
                                Sql = "UPDATE Serie SET EstadoID = 'R', DocNr = '" & xNovaRe & "', DtRegisto = GETDATE() WHERE SerieID = '" & r("SerieID") & "'"
                                If cn.State = ConnectionState.Closed Then cn.Open()
                                Cmd = New SqlCommand(Sql, cn)
                                Cmd.ExecuteNonQuery()
                                xDocLnNr += 1
                            Next
                        End If

                        'INSERIR DEVOLUÇÕES NA RECOLHA

                        Sql = "SELECT * FROM DocDet WHERE EmpresaID='" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID='DC' AND EstadoLN = 'G'"
                        da = New SqlDataAdapter(Sql, cn)
                        da.Fill(dtReDev)

                        For Each r As DataRow In dtReDev.Rows
                            Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Qtd, EstadoLn, Valor, PercDescLn, VlrDescLn, OperadorID) " & _
                                "VALUES ('" & xEmp & "', '" & xArmz & "', 'RE', '" & xNovaRe & "', " & xDocLnNr & ", '" & r("SerieID") & "', '" & r("ModeloID") & "', '" & r("CorID") & "', " & r("TamID") & ", -1, 'G', " & r("Valor") & ", '" & r("PercDescLn") & "','" & r("VlrDescLn") & "' , '" & xUtilizador & "')"
                            If cn.State = ConnectionState.Closed Then cn.Open()
                            Cmd = New SqlCommand(Sql, cn)
                            Cmd.ExecuteNonQuery()
                            xDocLnNr += 1
                        Next

                        Sql = "UPDATE DocDet SET EstadoLN = 'R' WHERE EmpresaID='" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID='DC' AND EstadoLN = 'G'"
                        If cn.State = ConnectionState.Closed Then cn.Open()
                        Cmd = New SqlCommand(Sql, cn)
                        Cmd.ExecuteNonQuery()

                    End If

                Else
                    MsgBox("Recolha Cancelada!")

                End If
            Else
                MsgBox("NADA PARA RECOLHER")
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GerarRecolha")
        Catch ex As Exception
            ErroVB(ex.Message, "GerarRecolha")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try

    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cbVerTodas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodas.CheckedChanged
        If cbVerTodas.CheckState = CheckState.Checked Then
            lbCab.Text = "Lista de Recolhas"
        Else
            lbCab.Text = "Recolhas Pendentes"
        End If
        ActualizaCabeçalho()
    End Sub

    Private Sub btLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLista.Click
        xDocNr = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "DocNr")
        xArmzAux = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "ArmazemID")

        ListaRecolha(xDocNr, xArmzAux)


    End Sub


    Private Sub AtualizaDespesas()

        Dim db As New ClsSqlBDados
        GirlDataSet.Despesas.Clear()

        Dim xDocNrOrig As String = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "DocNr")
        Dim xArmzAux As String = Me.C1TGReCab(Me.C1TGReCab.Bookmark, "ArmazemID")


        Try

            Sql = "SELECT DocDet.Descricao, DocDet.Valor FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID = '" & xArmzAux & "') AND (DocCab.TipoDocID = 'DP') AND (DocCab.TipoDocOrig = N'RE') AND (DocCab.DocNrOrig = N'" & xDocNrOrig & "')"
            db.GetData(Sql, GirlDataSet.Despesas)

            dgvDespesas.DataSource = GirlDataSet.Despesas



            'btDespesas.Visible = False
            'dgvDespesas.DataSource = dtDespesas
            'dgvDespesas.Columns(0).Width = 320
            'dgvDespesas.Columns(1).DefaultCellStyle.Format = "c"
            'dgvDespesas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvDespesas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight





        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "AtualizaDespesas")

        Catch ex As Exception
            ErroVB(ex.Message, "AtualizaDespesas")

        Finally

        End Try

    End Sub





End Class