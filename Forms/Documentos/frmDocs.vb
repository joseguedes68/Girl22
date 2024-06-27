
Imports System.Data.SqlClient
Imports System.Text


Public Class frmDocs



    Dim dtCab As New DataTable
    Dim dtDestinos As New DataTable
    Dim dtOrigens As New DataTable
    Dim Fechar As Boolean = False
    Dim xDescDoc As Double = 0
    Dim xAuxCalcDesconto As Boolean
    Dim LinhaActual As Integer
    Dim sOrigemID As String
    Dim bRecuperaSep As Boolean = False
    Dim sMsgErro As String

    Dim xDocNr As String = ""

    Dim sIdDocCabOrig As String
    Dim sDocOrigem As String = ""
    Dim txIva1 As Double = 0
    Dim txIva2 As Double = 0
    Dim txIva3 As Double = 0
    Dim txIva4 As Double = 0

    Dim dAuxPrecoUnit As Double
    Dim sIdDocCab As String = ""






    Private Sub frmDocs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.TaxIVATableAdapter.Fill(Me.GirlDataSet.TaxIVA)
        lbIdDocCabOrig.Text = ""

        Dim db As New ClsSqlBDados


        Try


            'LimparForm()



            Select Case xTipoDoc


                Case "GT"

                    Me.PrUniLiq.Visible = False
                    Me.VlrDescLiq.Visible = False
                    Me.IvaID.Visible = False
                    Me.TotalLiq.Visible = False
                    lbTerceiro.Text = "Destino"
                    CbOrigem.Enabled = True
                    tbDescDoc.Visible = False


                    Sql = "SELECT NomeUtilizador FROM Utilizadores WHERE UtilizadorID=" & iUtilizadorID
                    If db.GetDataValue(Sql) = "ADMIN" Then
                        btPedirNrAT.Visible = True
                    Else
                        btPedirNrAT.Visible = False
                    End If



                Case "GD"

                    Me.PrUniLiq.Visible = True
                    Me.VlrDescLiq.Visible = True
                    Me.IvaID.Visible = True
                    Me.TotalLiq.Visible = True
                    lbTerceiro.Text = "Fornecedor"
                    CbOrigem.Enabled = False
                    PTotais.Visible = True


                Case "FT", "NC", "ND"

                    lbTerceiro.Text = "Cliente"
                    PTotais.Visible = True
                    tbDescDoc.Visible = False
                    'If bLojaConsignacao = True Then btSeparacao.Visible = True

                Case "GE" 'GUIAS DE ENTRADA - USO INTERNO

                    Me.PrUniLiq.Visible = False
                    Me.VlrDescLiq.Visible = False
                    Me.IvaID.Visible = False
                    Me.TotalLiq.Visible = False
                    lbTerceiro.Text = "Destino"
                    CbOrigem.Enabled = False
                    tbDescDoc.Visible = False
                    CbDestino.Enabled = False
                    PTotais.Visible = False


                Case "FC", "CC", "GC"

                    'CLIENTES DE CONSIGNAÇÃO
                    'PARA JÁ SÓ VOU PERMITIR CONSULTA
                    CbDestino.Enabled = False
                    btSeparacao.Visible = False
                    btGravarDoc.Enabled = False
                    lbTerceiro.Text = "Cliente"
                    PTotais.Visible = True
                    tbDescDoc.Visible = False



            End Select

            'btSeparacao vai ficar visivel nas: GT e nas FC depois de escolher o 
            'terceiro de forma a o retorno das separações ser só o relativo a esse terceiro
            btSeparacao.Visible = False
            lbOrigem.Visible = True
            CbOrigem.Visible = True
            CarregarOrigens()


            CbOrigem.Enabled = False
            CarregarDestinos()

            Sql = "Select Distinct TipoDocDesc From TipoDoc Where TipoDocId='" & xTipoDoc & "'"
            lbTipoDoc.Text = db.GetDataValue(Sql)

            Me.DocDetDataGridView.RowHeadersWidth = 50

            CarregarInfoCargaDescarga(Me.CbOrigem.SelectedValue, Me.CbDestino.SelectedValue, True)

            lbNrDoc.Visible = False
            tbNrDoc.Visible = False
            lbNrAT.Visible = False
            tbNrAT.Visible = False


            tbDescDoc.Text = 0



            If xTipoDoc = "GE" Then
                dpMovementStartTime.Value = Now.AddMinutes(60)
                DocDetDataGridView.Visible = True
                Me.DocDetDataGridView.Focus()
            Else
                DocDetDataGridView.Visible = False
                Me.lbTerceiro.Focus()
                dpMovementStartTime.Value = Now.AddMinutes(5)
            End If


            tbCountryDescarga.Enabled = False

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmDocumentos_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmDocumentos_Load")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try



    End Sub


    'Eventos na DocDetDataGridView



    Private Sub DocDetDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DocDetDataGridView.CellEndEdit

        Try


            'TODO("FALTA CONTROLAR LINHAS EM BRANCO NOS DOCUMENTOS...DocDetDataGridView_CellEndEdit..")
            If Me.DocDetDataGridView("Artigo", DocDetDataGridView.CurrentRow.Index).Value Is DBNull.Value Then
                MsgBox("FALTA O ARTIGO!!")
                Exit Sub
            End If

            Dim db As New ClsSqlBDados

            If Me.DocDetDataGridView.Columns(DocDetDataGridView.CurrentCell.ColumnIndex).Name = "Artigo" Then

                'Dim sModeloID As String = Microsoft.VisualBasic.Left(Me.DocDetDataGridView("Artigo", DocDetDataGridView.CurrentRow.Index).Value, 5)
                'Dim sCorID As String = Microsoft.VisualBasic.Right(Me.DocDetDataGridView("Artigo", DocDetDataGridView.CurrentRow.Index).Value, 2)
                Dim sModeloID As String = "00000"
                Dim sCorID As String = "00"



                Dim dtArtigo As New DataTable
                'CARREGA DADOS DO ARTIGO
                'Sql = "SELECT ModeloCor.ModeloID, ModeloCor.CorID, ModeloCor.ModCorDescr, ModeloCor.PrVnd, Unidades.UnidDescr FROM Modelos INNER JOIN Unidades ON Modelos.UnidID = Unidades.UnidID INNER JOIN ModeloCor ON Modelos.ModeloID = ModeloCor.ModeloID WHERE (ModeloCor.ModeloID = '" & sModeloID & "') AND (ModeloCor.CorID = '" & sCorID & "')"
                Sql = "SELECT ProductDescription, UnitOfMeasure FROM Product WHERE ProductCode = N'" & Me.DocDetDataGridView("Artigo", DocDetDataGridView.CurrentRow.Index).Value & "'"
                db.GetData(Sql, dtArtigo)

                Me.DocDetDataGridView("ModeloID", DocDetDataGridView.CurrentRow.Index).Value = ""
                Me.DocDetDataGridView("CorID", DocDetDataGridView.CurrentRow.Index).Value = ""
                Me.DocDetDataGridView("Descricao", DocDetDataGridView.CurrentRow.Index).Value = Trim(dtArtigo.Rows(0)("ProductDescription"))
                Me.DocDetDataGridView("PrUniLiq", DocDetDataGridView.CurrentRow.Index).Value = 0
                Me.DocDetDataGridView("VlrDescLiq", DocDetDataGridView.CurrentRow.Index).Value = 0
                Me.DocDetDataGridView("Unidade", DocDetDataGridView.CurrentRow.Index).Value = dtArtigo.Rows(0)("UnitOfMeasure")

                If tbCountryDescarga.Text <> "PT" Then
                    Me.DocDetDataGridView("IvaID", DocDetDataGridView.CurrentRow.Index).Value = 0
                Else
                    Me.DocDetDataGridView("IvaID", DocDetDataGridView.CurrentRow.Index).Value = xIvaID
                End If

            End If

            If Me.DocDetDataGridView.Columns(DocDetDataGridView.CurrentCell.ColumnIndex).Name = "Qtd" Then
                SendKeys.Send("{left}")
                SendKeys.Send("{left}")
                SendKeys.Send("{left}")
                SendKeys.Send("{left}")
                SendKeys.Send("{left}")
                SendKeys.Send("{Down}")
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DocDetDataGridView_CellEndEdit")
        Catch ex As Exception
            ErroVB(ex.Message, "DocDetDataGridView_CellEndEdit")
        End Try


    End Sub


    Private Sub DocDetDataGridView_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DocDetDataGridView.CellValidating


        Try

            Dim db As New ClsSqlBDados

            Select Case DocDetDataGridView.Columns(e.ColumnIndex).Name

                Case "Artigo"

                    If Len(e.FormattedValue.ToString()) > 0 Then
                        If Not ValidarArtigo(e.FormattedValue.ToString()) Then
                            DocDetDataGridView.Rows(e.RowIndex).ErrorText = "Erro no Artigo"
                            e.Cancel = True
                        Else
                            DocDetDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
                        End If
                    End If

                Case "PrUniLiq"
                    'VALIDA DE É NUMÉRICO E MAIOR QUE ZERO
                    If Not IsNumeric(e.FormattedValue.ToString()) And Not String.IsNullOrEmpty(e.FormattedValue.ToString()) Or e.FormattedValue <= 0 Then
                        DocDetDataGridView.Rows(e.RowIndex).ErrorText =
                            "O Valor deve Ser Numérico e maior que Zero"
                        e.Cancel = True
                    Else
                        dAuxPrecoUnit = e.FormattedValue
                        DocDetDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
                        ActualizarTotal()

                    End If

                Case "VlrDescLiq"
                    'VALIDA DE É NUMÉRICO, MAIOR QUE ZERO E MENOR QUE PrUniLiq
                    If Not IsNumeric(e.FormattedValue.ToString()) And Not String.IsNullOrEmpty(e.FormattedValue.ToString()) Or e.FormattedValue > dAuxPrecoUnit Then
                        DocDetDataGridView.Rows(e.RowIndex).ErrorText =
                            "Valor Numérico e menor ou igual ao PrUniLiq"
                        e.Cancel = True
                    Else
                        DocDetDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
                        ActualizarTotal()
                    End If

                Case "Qtd"
                    'VALIDA DE É NUMÉRICO, MAIOR QUE ZERO
                    If Not IsNumeric(e.FormattedValue.ToString()) And Not String.IsNullOrEmpty(e.FormattedValue.ToString()) Or e.FormattedValue < 1 Then
                        DocDetDataGridView.Rows(e.RowIndex).ErrorText =
                            "O Valor deve Ser Numérico e maior ou igual a Um"
                        e.Cancel = True
                    Else
                        DocDetDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
                        ActualizarTotal()
                    End If

            End Select

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DocDetDataGridView_CellValidating")
        Catch ex As Exception
            ErroVB(ex.Message, "DocDetDataGridView_CellValidating")
        End Try

    End Sub



    'EVENTOS DIVERSOS NO FORM


    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Close()
    End Sub

    Private Sub tbDesconto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDesconto.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                'Me.DocDetDataGridView.Focus()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btPrintDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrintDoc.Click


        Dim db As New ClsSqlBDados
        bComunicaçãoAT = False

        Try
            'TODO: como estou a validar e limpar se der erro na criação do documento, posso refazer esta parte do código...
            sIdDocCabOrig = ""

            If btGravarDoc.Visible = True Then

                If GravarDocumento() = True Then
                    'TODO : FALTA VERIFICAR SE É NULO....???
                    ListaDocEmpresa(xDocNr, xTipoDoc, "Original", True)
                    If bDesenvolvimento = False Then


                        If xTipoDoc = "NC" Then
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)
                        End If

                        If xTipoDoc = "FT" Then
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)

                        End If
                        If xTipoDoc = "GC" Then
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                        End If

                        If xTipoDoc = "FC" Then
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)
                        End If

                        If xTipoDoc = "CC" Then
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)
                        End If
                    End If

                Else
                    Me.Cursor = Cursors.Default
                    'Sql = "DELETE FROM DOCCAB WHERE IdDocCab='" & sIdDocCab.ToString & "'"
                    'db.ExecuteData(Sql)
                End If

            Else

                ListaDocEmpresa(xDocNr, xTipoDoc, "Original", True)

                If bDesenvolvimento = False Then


                    If xTipoDoc = "NC" Then
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)
                    End If

                    If xTipoDoc = "FT" Then
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)

                    End If
                    If xTipoDoc = "GC" Then
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)
                    End If

                    If xTipoDoc = "CC" Then
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)
                    End If

                    If xTipoDoc = "FC" Then
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                        ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)
                    End If

                End If


            End If

            LimparForm()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btPrintDoc_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btPrintDoc_Click")
        Finally

        End Try


    End Sub

    Private Sub btDocs_Click(sender As System.Object, e As System.EventArgs) Handles btDocs.Click

        If SistemaBloqueado() = True Then
            Exit Sub
        End If


        LimparForm()
        btGravarDoc.Visible = False
        PTotais.Visible = True
        DocDetDataGridView.AllowUserToAddRows = False

        Dim db As New ClsSqlBDados
        Sql = "SELECT COUNT(*) FROM DOCCAB WHERE TIPODOCID='" & xTipoDoc & "'"
        If db.GetDataValue(Sql) > 0 Then

            frmDocsCab.WindowState = FormWindowState.Normal
            frmDocsCab.StartPosition = FormStartPosition.CenterScreen
            frmDocsCab.ShowDialog(Me)
            frmDocsCab.Dispose()

            CarregarDocumento()

        Else
            MsgBox("Esse tipo de Docs não existe!")
            Exit Sub
        End If

        DocDetDataGridView.Visible = True
        btSeparacao.Visible = False


    End Sub

    Private Sub btSeparacao_Click(sender As System.Object, e As System.EventArgs) Handles btSeparacao.Click

        If SistemaBloqueado() = True Then
            Exit Sub
        End If
        xDestinoAux = CbDestino.SelectedValue
        LimparForm()
        lbNrDoc.Visible = False
        tbNrDoc.Visible = False

        Dim db As New ClsSqlBDados

        Select Case xTipoDoc

            'Case "GT", "GC"
            Case "GT"

                Sql = "SELECT COUNT(*) FROM DOCCAB WHERE TIPODOCID='SE'"
                If db.GetDataValue(Sql) > 0 Then

                    bRecuperaSep = True

                    frmDocsCab.xTipoDocAux = "SE"
                    frmDocsCab.WindowState = FormWindowState.Normal
                    frmDocsCab.StartPosition = FormStartPosition.CenterScreen
                    frmDocsCab.ShowDialog(Me)
                    frmDocsCab.Dispose()
                    Me.Cursor = Cursors.WaitCursor

                    CarregarDocumento()


                    dpMovementStartTime.Value = Now.AddMinutes(10)
                    DocDetDataGridView.Visible = True

                Else
                    MsgBox("Esse tipo de Docs não existe!")
                    Exit Sub
                End If

            Case "GC"

                ''filtrar só as lojas de consignação
                'Sql = "SELECT COUNT(*) FROM DOCCAB WHERE TIPODOCID='SE'"
                'If db.GetDataValue(Sql) > 0 Then

                '    bRecuperaSep = True

                '    frmDocsCab.xTipoDocAux = "SEC"
                '    frmDocsCab.WindowState = FormWindowState.Normal
                '    frmDocsCab.StartPosition = FormStartPosition.CenterScreen
                '    frmDocsCab.ShowDialog(Me)
                '    frmDocsCab.Dispose()
                '    Me.Cursor = Cursors.WaitCursor

                '    CarregarDocumento()


                '    dpMovementStartTime.Value = Now.AddMinutes(10)
                '    DocDetDataGridView.Visible = True

                'Else
                '    MsgBox("Esse tipo de Docs não existe!")
                '    Exit Sub
                'End If

            Case "FC"

                ''FILTRAR O TERCEIRO SELECIONADO!!!
                'Sql = "SELECT COUNT(*) FROM DOCCAB WHERE TIPODOCID='SE'"
                'If db.GetDataValue(Sql) > 0 Then

                '    bRecuperaSep = True
                '    'SEC - SEPARAÇÃO DE CONSIGNAÇÃO
                '    frmDocsCab.xTipoDocAux = "SEC"
                '    frmDocsCab.WindowState = FormWindowState.Normal
                '    frmDocsCab.StartPosition = FormStartPosition.CenterScreen
                '    frmDocsCab.ShowDialog(Me)
                '    frmDocsCab.Dispose()
                '    Me.Cursor = Cursors.WaitCursor

                '    CarregarDocumento()


                '    dpMovementStartTime.Value = Now.AddMinutes(10)
                '    DocDetDataGridView.Visible = True

                'Else
                '    MsgBox("Esse tipo de Docs não existe!")
                '    Exit Sub
                'End If





            Case "NC"

                'Sql = "SELECT COUNT(*) FROM DOCCAB WHERE TIPODOCID='FT'"
                'If db.GetDataValue(Sql) > 0 Then

                '    bRecuperaSep = True

                '    frmDocsCab.xTipoDocAux = "FT"
                '    frmDocsCab.WindowState = FormWindowState.Normal
                '    frmDocsCab.StartPosition = FormStartPosition.CenterScreen
                '    frmDocsCab.ShowDialog(Me)
                '    frmDocsCab.Dispose()
                '    Me.Cursor = Cursors.WaitCursor

                '    CarregarDocumento()

                '    dpMovementStartTime.Value = Now.AddMinutes(5)
                'Else
                '    MsgBox("Esse tipo de Docs não existe!")
                '    Exit Sub
                'End If




        End Select

        Me.lbTerceiro.Focus()
        CbDestino.Enabled = False

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btCancelar.Click

        btGravarDoc.Visible = True
        LimparForm()
        DocDetDataGridView.AllowUserToAddRows = True


    End Sub

    Private Sub btGravarDoc_Click(sender As System.Object, e As System.EventArgs) Handles btGravarDoc.Click
        Try
            sIdDocCabOrig = ""
            dpDataDoc.Text = Now
            bComunicaçãoAT = False

            Dim db As New ClsSqlBDados

            Me.Cursor = Cursors.WaitCursor
            If GravarDocumento() = True Then

                If MsgBox("Quer Imprimir?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'TODO : FALTA VERIFICAR SE É NULO....
                    ListaDocEmpresa(xDocNr, xTipoDoc, "Original", True)
                    If bDesenvolvimento = False Then
                        If xTipoDoc = "NC" Then
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)
                        End If

                        If xTipoDoc = "FT" Then
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Triplicado", True)

                        End If
                        If xTipoDoc = "GC" Then
                            ListaDocEmpresa(xDocNr, xTipoDoc, "Duplicado", True)
                        End If
                    End If


                End If
                LimparForm()
                Me.Cursor = Cursors.Default

            Else
                Me.Cursor = Cursors.Default
                'PARA JÁ NÃO VOU APAGAR O DOCUMENTO MESMO QUE DÊ ERRO......
                'If sIdDocCab.ToString <> "" Then
                '    Sql = "DELETE FROM DOCCAB WHERE IdDocCab='" & sIdDocCab.ToString & "'"
                '    db.ExecuteData(Sql)
                'End If
            End If

            'ElseIf GravarDocumento() = False Then
            '    Me.Cursor = Cursors.Default
            '    MsgBox(sMsgErro)
            '    Sql = "DELETE FROM DOCCAB WHERE IdDocCab='" & sIdDocCab.ToString & "'"
            '    db.ExecuteData(Sql)
            '    Exit Sub
            'End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btGravarDoc_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btGravarDoc_Click")
        Finally


        End Try

    End Sub

    Private Sub tbDescDoc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbDescDoc.KeyPress

        'Try


        '    If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

        '        ActualizarTotal()
        '        lbDescDoc.Focus()

        '    End If


        'Catch ex As Exception
        '    'GIRL.ErroVB(ex.Message, "tbFunc_KeyPressr")
        'Finally

        'End Try

    End Sub

    Private Sub tbDescDoc_TextChanged(sender As Object, e As System.EventArgs) Handles tbDescDoc.TextChanged

        Try
            If IsNumeric(tbDescDoc.Text) Then
                ActualizarTotal()
            End If

        Catch ex As Exception
            'GIRL.ErroVB(ex.Message, "tbFunc_KeyPressr")
        Finally

        End Try
    End Sub

    'Eventos na combobox


    Private Sub CbDestino_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles CbDestino.SelectionChangeCommitted


        CarregarInfoCargaDescarga(Me.CbOrigem.SelectedValue, Me.CbDestino.SelectedValue, True)

        If CbDestino.SelectedValue <> "%" Then
            DocDetDataGridView.Visible = True
            Me.DocDetDataGridView.Focus()
        Else
            DocDetDataGridView.Visible = False
        End If

    End Sub

    Private Sub CbOrigem_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbOrigem.SelectionChangeCommitted

        sOrigemID = Me.CbOrigem.SelectedValue
        'Me.CbOrigem.SelectedValue = sOrigemID

        CarregarInfoCargaDescarga(Me.CbOrigem.SelectedValue, Me.CbDestino.SelectedValue, True)

        'Me.DocDetDataGridView.Focus()


    End Sub

    'FUNÇÕES

    Private Function GravarDocumento() As Boolean


        Dim db As New ClsSqlBDados
        Dim dt As New DataTable
        Dim sNumAT As String = ""
        Dim sDocumentoVazio As Boolean = False

        Try


            If Len(tbNIF.Text) < 9 Then
                sMsgErro = "Falta Preencher o NIF do destino!"
                Return False
            End If

            If Microsoft.VisualBasic.Right(Me.CbDestino.SelectedValue, 4) = "%" Then
                sMsgErro = "Falta Preencher " & lbTerceiro.Text & "!"
                Return False
            End If

            If GirlDataSet.DocDetAux.Rows.Count = 0 Then
                sMsgErro = "Documento sem Linhas preenchidas!"
                Return False
            End If

            If Len(tbAddressDetailCarga.Text) < 3 Or Len(tbCityCarga.Text) < 3 Or Len(tbPostalCodeCarga.Text) < 8 Then
                sMsgErro = "Local de Carga Incompleto!"
                Return False
            End If

            If Len(tbAddressDetailDescarga.Text) < 3 Or Len(tbCityDescarga.Text) < 3 Or Len(tbPostalCodeDescarga.Text) < 4 Then
                sMsgErro = "Local de Descarga Incompleto!"
                Return False
            End If

            'Documento de Origem
            Dim dtOrigem As New DataTable
            'If xTipoDoc = "NC" Then
            If Len(tbDocOrigem.Text) > 0 Then
                Sql = "SELECT IdDocCab FROM DocCab WHERE (TipoDocID + ' ' + SerieDoc + '/' + NrDoc = '" & tbDocOrigem.Text & "')"
                db.GetData(Sql, dt)
                If dt.Rows.Count > 0 Then
                    sIdDocCabOrig = dt.Rows(0)("IdDocCab").ToString
                    sDocOrigem = tbDocOrigem.Text
                Else
                    MsgBox("O Documento de Origem não existe!", MsgBoxStyle.Critical)
                    Return False
                End If
            End If
            'End If

            If tbCountryDescarga.Text = "PT" Then
                If Len(tbPostalCodeDescarga.Text) < 8 Then
                    sMsgErro = "Verificar Código Postal!"
                    Return False
                End If
            End If

            Dim xNovoDoc As String = PesquisaMaxNumDoc(xTipoDoc)
            If xNovoDoc = "" Then Return False
            xDocNr = xNovoDoc
            If xNovoDoc.Length = 0 Then Exit Function

            Dim xData As String = Format(CType(Now(), Date), "yyyy-MM-dd H:mm:ss")

            If dpMovementStartTime.Value < Now.AddMinutes(1) Then
                sMsgErro = "Data/Hora de Inicio de Transp. Ultrapassada!"
                Return False
            End If


            Dim xDestino As String = Microsoft.VisualBasic.Right(Me.CbDestino.SelectedValue, 4)
            Dim xTipoTerc As String = Microsoft.VisualBasic.Left(Me.CbDestino.SelectedValue, 1)
            sOrigemID = Me.CbOrigem.SelectedValue


            Sql = "SELECT CAST(IDTerceiro AS char(36))  from Terceiros where TercID='" & xDestino & "'"
            Dim GuidDestino As String = db.GetDataValue(Sql)

            sIdDocCab = Guid.NewGuid.ToString


            Dim strData As New StringBuilder
            'strData.Append(True)


            'TODO: PASSAR A DINÂMICO
            Dim sCountryCarga As String = "PT"

            Dim sCountryDescarga As String = tbCountryDescarga.Text

            If Len(lbIdDocCabOrig.Text) > 0 Then
                sIdDocCabOrig = lbIdDocCabOrig.Text
            End If

            If sIdDocCabOrig = "" Then
                sIdDocCabOrig = "Null"
            Else
                sIdDocCabOrig = "'" & sIdDocCabOrig & "'"
            End If


            Dim sATCUD As String = DevolveATCUD(sOrigemID, xTipoDoc, xNovoDoc)
            If Now() >= #01/01/2023# And sATCUD = "0" Then Return False


            Sql = "BEGIN TRANSACTION"
            strData.AppendLine(Sql)

            Sql = "INSERT INTO DocCab (EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, Obs1, Obs2, Obs3, DescontoDoc, EstadoDoc, TipoTerc, NIFTerc, FormaPagtoID, IdDocCab, IdDocCabOrig, DocOrig,  UtilizadorID, OperadorID, SAFT, DtUltAlt, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, IDTerceiro, ATCUD) " &
                "VALUES ('" & xEmp & "', '" & sOrigemID & "', '" & xTipoDoc & "', N'" & xNovoDoc & "', '" & xDestino & "', CONVERT(DATETIME, '" & dpDataDoc.Text & "', 102), '', '', '', '0', '', '', '', '', '" & tbObs.Text & "', '0', '0', '0', '0', 'C', N'" & xTipoTerc & "', '" & tbNIF.Text & "', '0', '" & sIdDocCab & "', " & sIdDocCabOrig & ",'" & sDocOrigem & "', '" & iUtilizadorID & "', '" & xUtilizador & "', '0', GETDATE(), N'" & tbAddressDetailCarga.Text & "', N'" & tbCityCarga.Text & "', N'" & tbPostalCodeCarga.Text & "', N'" & sCountryCarga & "', CONVERT(DATETIME, '" & dpMovementStartTime.Text & "', 102), N'" & tbAddressDetailDescarga.Text & "', N'" & tbCityDescarga.Text & "', N'" & tbPostalCodeDescarga.Text & "', N'" & sCountryDescarga & "', CONVERT(DATETIME, '" & dpMovementStartTime.Text & "', 102), '" & GuidDestino & "', '" & sATCUD & "');"
            strData.AppendLine(Sql)

            Dim inLinha As Int16 = 0
            Dim dValor As Double = 0
            Dim dVlrDescLn As Double = 0
            Dim dVlrIVA As Double = 0
            Dim dTxIva As Double = 0

            For Each r As DataRow In GirlDataSet.DocDetAux.Rows

                dTxIva = DevolveIva(r("IvaId"))
                dValor = r("PrUniLiq") * (1 + dTxIva)
                dVlrDescLn = r("VlrDescLiq") * (1 + dTxIva)
                dVlrIVA = (r("PrUniLiq") - r("VlrDescLiq")) * dTxIva
                inLinha = inLinha + 1

                If xTipoDoc = "GT" Or xTipoDoc = "GC" Then
                    dValor = 0
                    dVlrDescLn = 0
                    dVlrIVA = 0
                End If


                If r("Qtd").ToString < "1" Then
                    sMsgErro = "Quantidade menor que 1 na linha :" & inLinha
                    Return False
                End If

                Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, ModeloID, CorID, Descricao, Unidade, Valor, VlrDescLn, IvaID, VlrIVA, TxIva, Qtd, EstadoLn, IDDocCab, ProductCode, OperadorID) " &
                    "VALUES ('" & xEmp & "','" & sOrigemID & "','" & xTipoDoc & "','" & xNovoDoc & "', " & inLinha & ", '" & r("ModeloID") & "', '" & r("CorID") & "', '" & Trim(r("Descricao")) & "', '" & r("Unidade") & "', " & dValor & ", " & dVlrDescLn & ", '" & r("IvaID") & "', " & dVlrIVA & ",  " & dTxIva & ", " & r("Qtd") & ", 'C','" & sIdDocCab & "', '" & r("Artigo") & "', '" & xUtilizador & "');"
                strData.AppendLine(Sql)



            Next

            Sql = "COMMIT TRANSACTION;"
            strData.AppendLine(Sql)
            Sql = strData.ToString
            dberrorAtivo = True

            Dim clsGravaDoc As New ClsDocs
            If Not clsGravaDoc.NovoDoc(Sql, sIdDocCab, xTipoDoc) Then
                MsgBox("Erro 7502 da criação do documento!!",, "Girl")
                EnviarEmail("Erro 7502 da criação do documento!!")
                Return False
            Else
                Return True
            End If

            LimparForm()



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravarDocumento")
            Return False
        Catch ex As Exception
            ErroVB(ex.Message, "GravarDocumento")
            Return False
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            cn.Close()
            dberrorAtivo = False


        End Try

    End Function

    Private Sub ActualizaDetalhe()
        Dim db As New ClsSqlBDados
        Try
            GirlDataSet.DocDet.Clear()


            If xTipoDoc = "GT" Then
                DocDetDataGridView.Columns("Valor").Visible = False
                DocDetDataGridView.Columns("IvaID").Visible = False
                DocDetDataGridView.Columns("TotalLn").Visible = False
                PTotais.Visible = False

            Else
                DocDetDataGridView.Columns("Valor").Visible = True
                DocDetDataGridView.Columns("IvaID").Visible = True
                DocDetDataGridView.Columns("TotalLn").Visible = True
                PTotais.Visible = True
            End If

            txtDescontoAux.Text = IIf(txtDescontoAux.Text = "", 0, txtDescontoAux.Text)
            tbDesconto.Text = txtDescontoAux.Text * 100


            Dim TotalLinhas As Integer = DocDetDataGridView.Rows.Count - 1
            Dim Linha As Integer

            For Linha = 0 To TotalLinhas - 1


                Me.DocDetDataGridView("PrUniLiq", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = DocDetDataGridView.Rows(Linha).Cells("Valor").Value / (1 + DevolveIva(Me.DocDetDataGridView("IvaID", Me.DocDetDataGridView.CurrentCell.RowIndex).Value))
                Me.DocDetDataGridView("VlrDescLnLiq", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = DocDetDataGridView.Rows(Linha).Cells("VlrDescLn").Value / (1 + DevolveIva(Me.DocDetDataGridView("IvaID", Me.DocDetDataGridView.CurrentCell.RowIndex).Value))
                Me.DocDetDataGridView("TotalLn", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = (Me.DocDetDataGridView("PrUniLiq", Me.DocDetDataGridView.CurrentCell.RowIndex).Value - Me.DocDetDataGridView("VlrDescLnLiq", Me.DocDetDataGridView.CurrentCell.RowIndex).Value) * Me.DocDetDataGridView("Qtd", Me.DocDetDataGridView.CurrentCell.RowIndex).Value

            Next

            ActualizarTotal()



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaDetalhe")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaDetalhe")
        Finally
            If db IsNot Nothing Then db.Dispose()
            cn.Close()
            Sql = Nothing
        End Try

    End Sub

    Private Sub ActualizarTotal()
        Try

            If DocDetDataGridView.RowCount = 0 Then
                Exit Sub
            End If


            If xTipoDoc = "GT" Then
                Exit Sub
            End If

            If Me.DocDetDataGridView("Qtd", Me.DocDetDataGridView.CurrentCell.RowIndex).Value > 0 And Me.DocDetDataGridView("PrUniLiq", Me.DocDetDataGridView.CurrentCell.RowIndex).Value > 0 And Me.DocDetDataGridView("VlrDescLiq", Me.DocDetDataGridView.CurrentCell.RowIndex).Value >= 0 Then

                Me.DocDetDataGridView("TotalLiq", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = (Me.DocDetDataGridView("PrUniLiq", Me.DocDetDataGridView.CurrentCell.RowIndex).Value - Me.DocDetDataGridView("VlrDescLiq", Me.DocDetDataGridView.CurrentCell.RowIndex).Value) * Me.DocDetDataGridView("Qtd", Me.DocDetDataGridView.CurrentCell.RowIndex).Value

                Dim xQtd As Double = 0
                Dim xValor As Double = 0
                Dim xIvaValor As Double = 0
                Dim xTxIva As Double = 0

                Dim dDescDoc As Double = 0


                For Each r1 As DataGridViewRow In DocDetDataGridView.Rows
                    xValor = xValor + Me.DocDetDataGridView("TotalLiq", r1.Index).Value
                    xIvaValor = xIvaValor + DevolveIvaDataSet(Me.DocDetDataGridView("IvaID", r1.Index).Value) * Me.DocDetDataGridView("TotalLiq", r1.Index).Value
                Next

                'consignação
                'For Each r1 As DataGridViewRow In DocDetDataGridView.Rows
                '    Me.DocDetDataGridView("TotalLiq", r1.Index).Value = (Me.DocDetDataGridView("PrUniLiq", r1.Index).Value - Me.DocDetDataGridView("VlrDescLiq", r1.Index).Value) * Me.DocDetDataGridView("Qtd", r1.Index).Value
                'Next


                dDescDoc = Me.tbDescDoc.Text
                xValor = xValor * (1 - dDescDoc / 100)
                xIvaValor = xIvaValor * (1 - dDescDoc / 100)


                lbSubTotal.Text = "SubTotal = " & Format(xValor, "Currency")
                lbIva.Text = "Iva = " & Format(xIvaValor, "Currency")
                lblTotal.Text = "Total  " & Format(xValor + xIvaValor, "Currency")

                PTotais.Visible = True

            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, " ActualizarTotal")
            Exit Sub
        Catch ex As Exception
            ErroVB(ex.Message, " ActualizarTotal")
            Exit Sub
        Finally

        End Try


    End Sub

    Private Sub CarregarDestinos()

        Dim db As New ClsSqlBDados

        Try

            If xTipoDoc = "FS" Or (xTipoDoc = "NC" And xAplicacao = "POS") Then
                Sql = "SELECT ClienteLojaID TercID  , Nome FROM ClientesLoja order by Nome"
            ElseIf xTipoDoc = "GT" Or xTipoDoc = "GE" Then
                If xAplicacao = "POS" Then
                    Sql = "SELECT TercID, TercID + '-' + NomeAbrev Nome FROM Terceiros WHERE TipoTerc IN ('I') ORDER BY NomeAbrev"
                Else
                    Sql = "SELECT TercID, TercID + '-' + NomeAbrev Nome FROM Terceiros WHERE TipoTerc IN ('I','C','F') ORDER BY NomeAbrev"
                End If
            ElseIf xTipoDoc = "FT" Or (xTipoDoc = "NC" And xAplicacao = "BACKOFFICE") Then
                Sql = "SELECT TercID, TercID + '-' + NomeAbrev Nome FROM Terceiros WHERE TipoTerc IN ('C') ORDER BY NomeAbrev"

            ElseIf xTipoDoc = "GC" Or xTipoDoc = "FC" Or xTipoDoc = "CC" Then
                Sql = "SELECT TercID, TercID + '-' + NomeAbrev Nome FROM Terceiros WHERE TipoTerc IN ('C') ORDER BY NomeAbrev"

            Else
                Exit Sub
            End If

            db.GetData(Sql, dtDestinos)

            dtDestinos.Rows.Add("%", "Selecionar")

            Me.CbDestino.DataSource = dtDestinos
            Me.CbDestino.DisplayMember = "Nome"
            Me.CbDestino.ValueMember = "TercID"
            Me.CbDestino.SelectedValue = "%"

            If xTipoDoc = "GE" Then Me.CbDestino.SelectedValue = "2000"

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarDestinos")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarDestinos")

        Finally

            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Friend Sub CarregarDocumento()

        Dim db As New ClsSqlBDados
        Dim dtCab As New DataTable
        Dim dtDet As New DataTable
        Dim I As Int16 = 0
        Dim sArmConsignacaoAux As String = ""
        Dim dValorLinhaAux As Double = 0





        Try


            If Len(sIdDocCabAux) = 0 Then
                btGravarDoc.Visible = True
                LimparForm()
                DocDetDataGridView.AllowUserToAddRows = True
                Exit Sub
            End If

            'SÓ VAI CARREGAR PARA IMPRESSÃO....e para as separações

            If bRecuperaSep = True Then
                'Me.tbDocOrigem.Visible = True
                'Me.lbdocOrig.Visible = True


                'Sql = "SELECT TipoDocID+'/'+ArmazemID+'/'+DocNr Origem FROM DocCab WHERE (DocCab.IdDocCab = '" & sIdDocCabAux & "')"
                'tbDocOrigem.Text = db.GetDataValue(Sql)
                lbIdDocCabOrig.Text = sIdDocCabAux
                'Sql = "SELECT DocCab.ArmazemID, Armazens.TercID, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.DataDoc, DocCab.Obs , TipoDocID +' '+ left(DocNr,2) + right(DocCab.ArmazemID,2) +'/'+ right(DocNr,5) NRDOC, DocNr, ATDocCodeID, NIFTerc, DocOrig FROM DocCab INNER JOIN Armazens ON DocCab.TercID = Armazens.ArmazemID WHERE (DocCab.IdDocCab = '" & sIdDocCabAux & "')"

                Sql = "SELECT DocCab.ArmazemID, Armazens.TercID, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.DataDoc, DocCab.Obs, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) 
                + '/' + RIGHT(DocCab.DocNr, 5) AS NRDOC, DocCab.DocNr, DocCab.ATDocCodeID, DocCab.NIFTerc, DocCab.DocOrig, Armazens_1.TercID AS Origem
                FROM     DocCab INNER JOIN Armazens ON DocCab.TercID = Armazens.ArmazemID INNER JOIN
                Armazens AS Armazens_1 ON DocCab.ArmazemID = Armazens_1.ArmazemID
                WHERE (DocCab.IdDocCab = '" & sIdDocCabAux & "')"

            Else
                'Sql = "SELECT ArmazemID, TercID, LocalCarga, HoraCarga, LocDesc, HoraDesc, DataDoc, Obs, TipoDocID +' '+ left(DocNr,2) + right(ArmazemID,2) +'/'+ right(DocNr,5) NRDOC, DocNr, ATDocCodeID FROM DocCab WHERE IdDocCab = '" & sIdDocCabAux & "'"
                'Sql = "SELECT ArmazemID, TercID, LocalCarga, HoraCarga, LocDesc, HoraDesc, DataDoc, Obs, TipoDocID +' '+ left(DocNr,2) + right(ArmazemID,2) +'/'+ right(DocNr,5) NRDOC, DocNr, ATDocCodeID , CountryDescarga FROM DocCab WHERE IdDocCab = '" & sIdDocCabAux & "'"
                Sql = "SELECT ArmazemID, TercID, LocalCarga, HoraCarga, LocDesc, HoraDesc, DataDoc, Obs, TipoDocID + ' ' + LEFT(DocNr, 2) + RIGHT(ArmazemID, 2) + '/' + RIGHT(DocNr, 5) AS NRDOC, DocNr, ATDocCodeID, CountryDescarga, NIFTerc, DocOrig FROM DocCab WHERE (IdDocCab = '" & sIdDocCabAux & "')"
            End If

            db.GetData(Sql, dtCab)

            If bRecuperaSep = True Then
                'Sql = "SELECT ModeloID + CorID AS Artigo, ModeloID, CorID, Descricao, Valor, VlrDescLn, SUM(Qtd) AS Qtd, Unidade, IvaID FROM DocDet WHERE (IdDocCab = '" & sIdDocCabAux & "') GROUP BY ModeloID + CorID, ModeloID, CorID, Descricao, Valor, VlrDescLn, Unidade, IvaID"
                'Sql = "SELECT DocDet.ProductCode AS Artigo, Product.ProductDescription AS Descricao, Product.UnitOfMeasure AS Unidade, SUM(DocDet.Qtd) AS Qtd , Valor - VlrIVA AS Valor FROM DocDet INNER JOIN Product ON DocDet.ProductCode = Product.ProductCode 
                '    WHERE (DocDet.IdDocCab = '" & sIdDocCabAux & "') 
                '    GROUP BY DocDet.ProductCode, Product.ProductDescription, Product.UnitOfMeasure"

                'Sql = "SELECT DocDet.ProductCode AS Artigo, Product.ProductDescription AS Descricao, Product.UnitOfMeasure AS Unidade, SUM(DocDet.Qtd) AS Qtd, 
                '    DocDet.Valor - DocDet.VlrIVA AS Valor FROM DocDet INNER JOIN Product ON DocDet.ProductCode = Product.ProductCode
                '    WHERE  (DocDet.IdDocCab = '" & sIdDocCabAux & "') GROUP BY DocDet.ProductCode, Product.ProductDescription, 
                '    Product.UnitOfMeasure, DocDet.Valor - DocDet.VlrIVA"


                Sql = "SELECT DocDet.ProductCode AS Artigo, Product.ProductDescription AS Descricao, Product.UnitOfMeasure AS Unidade, SUM(DocDet.Qtd) AS Qtd, 0 AS Valor
                    FROM     DocDet INNER JOIN Product ON DocDet.ProductCode = Product.ProductCode
                    WHERE  (DocDet.IdDocCab = '" & sIdDocCabAux & "')
                    GROUP BY DocDet.ProductCode, Product.ProductDescription, Product.UnitOfMeasure"


            Else
                Sql = "SELECT ProductCode AS Artigo, ModeloID, CorID, Descricao, Valor - VlrIVA AS Valor, VlrDescLn / (1+TxIva) AS VlrDescLn, Qtd, Unidade, IvaID, ValorLiquido FROM DocDet 
                    WHERE (IdDocCab = '" & sIdDocCabAux & "')"
            End If

            db.GetData(Sql, dtDet)

            If ArmazemConsignacao(dtCab.Rows(0)("ArmazemID")) Then
                sArmConsignacaoAux = dtCab.Rows(0)("ArmazemID") 'ESTE VAI SER O ARMAZEM DE ORIGEM
                Me.CbOrigem.SelectedValue = xArmz
                Me.CbDestino.SelectedValue = dtCab.Rows(0)("Origem")
            Else
                Me.CbOrigem.SelectedValue = dtCab.Rows(0)("ArmazemID")
                Me.CbDestino.SelectedValue = dtCab.Rows(0)("TercID")
            End If


            xDocNr = dtCab.Rows(0)("DocNr")
            'Me.CbOrigem.SelectedValue = "0000"
            Me.tbAddressDetailCarga.Text = dtCab.Rows(0)("LocalCarga")
            'Me.tbHoraCarga.Text = dtCab.Rows(0)("HoraCarga")
            'Me.tbLocalDesc.Text = dtCab.Rows(0)("LocDesc")
            'Me.tbHoraDesc.Text = dtCab.Rows(0)("HoraDesc")

            Me.tbObs.Text = dtCab.Rows(0)("Obs")
            lbNrDoc.Visible = False
            tbNrDoc.Text = dtCab.Rows(0)("NRDOC")
            tbNrAT.Text = dtCab.Rows(0)("ATDOCCODEID").ToString
            tbNIF.Text = dtCab.Rows(0)("NIFTerc").ToString

            If bRecuperaSep = True Then
                Me.dpDataDoc.Text = Now()
                lbNrAT.Visible = False
                tbNrAT.Visible = False
            Else
                Me.dpDataDoc.Text = dtCab.Rows(0)("DataDoc")
                DocDetDataGridView.AllowUserToAddRows = False
                lbNrDoc.Visible = True
                tbNrDoc.Visible = True
                tbDocOrigem.Text = dtCab.Rows(0)("DocOrig").ToString

                If xTipoDoc = "GT" Or xTipoDoc = "GD" Then
                    lbNrAT.Visible = True
                    tbNrAT.Visible = True
                End If

            End If

            For Each r As DataRow In dtDet.Rows
                dValorLinhaAux = r("Valor")
                If xTipoDoc = "FC" Or xTipoDoc = "CC" Then
                    dValorLinhaAux = r("ValorLiquido")
                End If

                If bRecuperaSep = True Then
                    Me.GirlDataSet.DocDetAux.Rows.Add(r("Artigo"), "00000", "00", r("Descricao"), 0, 0, r("Qtd"), r("Unidade"), xIvaID)
                Else
                    Me.GirlDataSet.DocDetAux.Rows.Add(r("Artigo"), r("ModeloID"), r("CorID"), r("Descricao"), dValorLinhaAux, r("VlrDescLn"), r("Qtd"), r("Unidade"), r("IvaID"))
                End If

            Next

            For Each r1 As DataGridViewRow In DocDetDataGridView.Rows
                Me.DocDetDataGridView("TotalLiq", r1.Index).Value = (Me.DocDetDataGridView("PrUniLiq", r1.Index).Value - Me.DocDetDataGridView("VlrDescLiq", r1.Index).Value) * Me.DocDetDataGridView("Qtd", r1.Index).Value
            Next


            If bRecuperaSep = True Then
                If Len(sArmConsignacaoAux) > 0 Then
                    CarregarInfoCargaDescarga(sArmConsignacaoAux, dtCab.Rows(0)("TercID"), True)
                Else
                    CarregarInfoCargaDescarga(Me.CbOrigem.SelectedValue, Me.CbDestino.SelectedValue, True)
                End If

            Else
                CarregarInfoCargaDescarga(Me.CbOrigem.SelectedValue, Me.CbDestino.SelectedValue, False)
            End If


            'If bRecuperaSep = True Then
            '    DocDetDataGridView.Rows.RemoveAt(DocDetDataGridView.CurrentRow.Index)
            'End If

            bRecuperaSep = False

            ActualizarTotal()





        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarDocumento")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarDocumento")

        Finally
            db = Nothing
            dtCab = Nothing
            dtDet = Nothing
            sArmConsignacaoAux = Nothing
        End Try

    End Sub

    Friend Sub CarregarDocumentoConsignacao()

        Dim db As New ClsSqlBDados
        Dim dtCab As New DataTable
        Dim dtDet As New DataTable
        Dim I As Int16 = 0
        sIdDocCabAuxConsignacao = sIdDocCabAux

        Try


            If Len(sIdDocCabAux) = 0 Then
                btGravarDoc.Visible = True
                LimparForm()
                DocDetDataGridView.AllowUserToAddRows = True
                btSeparacao.Visible = False
                Exit Sub
            End If

            'SÓ VAI CARREGAR PARA IMPRESSÃO....e para as separações - não sei o que isto quer dizer

            Sql = "SELECT DocCab.ArmazemID, Armazens.TercID, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc,
                DocCab.HoraDesc, DocCab.DataDoc, 
                DocCab.Obs, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) +
                '/' + RIGHT(DocCab.DocNr, 5) AS NRDOC, 
                DocCab.DocNr, DocCab.ATDocCodeID, DocCab.NIFTerc, DocCab.DocOrig
                FROM   DocCab INNER JOIN
                Armazens ON DocCab.ArmazemID = Armazens.ArmazemID
                WHERE (DocCab.IdDocCab = '" & sIdDocCabAux & "')"
            db.GetData(Sql, dtCab)


            Sql = "SELECT DocDet.ProductCode AS Artigo, Product.ProductDescription AS Descricao, (DocDet.Valor / (1 + DocDet.TxIva)) * (1 - DocDet.Comissao) AS Valor, DocDet.VlrDescLn / (1 + DocDet.TxIva) AS VlrDescLn, SUM(DocDet.Qtd) AS Qtd, DocDet.Unidade, DocDet.IvaID
                FROM   DocDet INNER JOIN
                Product ON DocDet.ProductCode = Product.ProductCode
                WHERE (DocDet.IdDocCab = '" & sIdDocCabAux & "')
                GROUP BY DocDet.ProductCode, DocDet.Unidade, DocDet.IvaID, (DocDet.Valor / (1 + DocDet.TxIva)) * (1 - DocDet.Comissao), DocDet.VlrDescLn / (1 + DocDet.TxIva), Product.ProductDescription, DocDet.Comissao"

            db.GetData(Sql, dtDet)


            'Me.CbOrigem.SelectedValue = dtCab.Rows(0)("ArmazemID").ToString
            'Me.CbOrigem.SelectedValue = dtCab.Rows(0)("ArmazemID")
            xDocNr = dtCab.Rows(0)("DocNr")
            Me.CbOrigem.SelectedValue = "0000"
            Me.CbDestino.SelectedValue = dtCab.Rows(0)("TercID")
            Me.tbAddressDetailCarga.Text = dtCab.Rows(0)("LocalCarga")
            'Me.tbHoraCarga.Text = dtCab.Rows(0)("HoraCarga")
            'Me.tbLocalDesc.Text = dtCab.Rows(0)("LocDesc")
            'Me.tbHoraDesc.Text = dtCab.Rows(0)("HoraDesc")

            Me.tbObs.Text = dtCab.Rows(0)("Obs")
            lbNrDoc.Visible = False
            tbNrDoc.Text = dtCab.Rows(0)("NRDOC")
            tbNrAT.Text = dtCab.Rows(0)("ATDOCCODEID").ToString
            tbNIF.Text = dtCab.Rows(0)("NIFTerc").ToString
            tbDocOrigem.Text = dtCab.Rows(0)("DocOrig").ToString


            'Me.txtDataDoc.CustomFormat = "yyyy-MM-dd H:mm:ss"

            If bRecuperaSep = True Then
                Me.dpDataDoc.Text = Now()
                lbNrAT.Visible = False
                tbNrAT.Visible = False

            Else
                Me.dpDataDoc.Text = dtCab.Rows(0)("DataDoc")
                DocDetDataGridView.AllowUserToAddRows = False
                lbNrDoc.Visible = True
                tbNrDoc.Visible = True

                If xTipoDoc = "GT" Or xTipoDoc = "GD" Then
                    lbNrAT.Visible = True
                    tbNrAT.Visible = True

                End If

            End If




            For Each r As DataRow In dtDet.Rows

                Me.GirlDataSet.DocDetAux.Rows.Add(r("Artigo"), "00000", "00", r("Descricao"), r("Valor"), r("VlrDescLn"), r("Qtd"), r("Unidade"), r("IvaID"))

            Next

            For Each r1 As DataGridViewRow In DocDetDataGridView.Rows
                Me.DocDetDataGridView("TotalLiq", r1.Index).Value = (Me.DocDetDataGridView("PrUniLiq", r1.Index).Value - Me.DocDetDataGridView("VlrDescLiq", r1.Index).Value) * Me.DocDetDataGridView("Qtd", r1.Index).Value
            Next

            'aqui tenho que mudar o terceiro

            CarregarInfoCargaDescarga(Me.CbOrigem.SelectedValue, Me.CbDestino.SelectedValue, True)

            bRecuperaSep = False

            ActualizarTotal()


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarDocumento")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarDocumento")

        Finally
            db = Nothing
            dtCab = Nothing
            dtDet = Nothing
        End Try

    End Sub



    Private Sub CarregarOrigens()

        Dim db As New ClsSqlBDados


        If xTipoDoc = "GT" Then
            Sql = "SELECT ArmazemID, RTRIM(ArmazemID) + ' - ' + RTRIM(ArmAbrev) AS Origem FROM Armazens WHERE ACTIVO='1' ORDER BY ArmAbrev"
        Else
            Sql = "SELECT ArmazemID, RTRIM(ArmazemID) + ' - ' + RTRIM(ArmAbrev) AS Origem FROM Armazens WHERE ACTIVO='1' AND ArmazemID = '0000' ORDER BY ArmAbrev"
        End If
        db.GetData(Sql, dtOrigens)

        Me.CbOrigem.DataSource = dtOrigens
        Me.CbOrigem.DisplayMember = "Origem"
        Me.CbOrigem.ValueMember = "ArmazemID"
        Me.CbOrigem.SelectedValue = xArmz


    End Sub

    Private Sub LimparForm()


        GirlDataSet.DocDetAux.Clear()
        sIdDocCabAux = ""
        CbDestino.SelectedValue = "%"
        dpDataDoc.Text = ""
        tbObs.Text = ""
        lbTerceiro.Focus()
        tbAddressDetailDescarga.Text = ""
        tbCityDescarga.Text = ""
        tbPostalCodeDescarga.Text = ""
        btGravarDoc.Visible = True
        DocDetDataGridView.AllowUserToAddRows = True
        tbNrDoc.Text = ""
        dpDataDoc.Text = Now
        tbNrAT.Text = ""
        If xTipoDoc = "GT" And DevolveGrupoAcesso() = "ADMIN" Then btSeparacao.Visible = True
        tbCountryDescarga.Text = ""
        PTotais.Visible = False
        tbNIF.Text = ""
        tbDocOrigem.Text = ""
        dpMovementStartTime.Value = Now.AddMinutes(10)
        Me.tbDocOrigem.Visible = False
        Me.lbdocOrig.Visible = False
        lbIdDocCabOrig.Text = ""
        sIdDocCabAuxConsignacao = ""
        If bLojaConsignacao = True Then
            CbDestino.Enabled = False
        Else
            CbDestino.Enabled = True
        End If


    End Sub

    Private Sub CarregarInfoCargaDescarga(ByVal sCarga As String, ByVal sDescarga As String, ByVal bNovoDoc As Boolean)

        Try
            Dim db As New ClsSqlBDados
            Dim dtCarga As New DataTable
            Dim dtDescarga As New DataTable
            Dim dtCargaDescarga As New DataTable

            If bNovoDoc = True Then



                'Sql = "SELECT TercID, Morada, Localidade, CodPostal, PaisID FROM Terceiros WHERE TercID = '" & sCarga & "'"
                Sql = "SELECT Armazens.ArmazemID, Terceiros.Morada, Terceiros.Localidade, Terceiros.CodPostal, Terceiros.PaisID, Terceiros.NIF FROM Terceiros INNER JOIN Armazens ON Terceiros.TercID = Armazens.TercID WHERE (Armazens.ArmazemID = '" & sCarga & "')"
                db.GetData(Sql, dtCarga)

                Sql = "SELECT TercID, Morada, Localidade, CodPostal, PaisID, NIF FROM Terceiros WHERE TercID = '" & sDescarga & "'"
                db.GetData(Sql, dtDescarga)

                If dtCarga.Rows.Count > 0 Then
                    tbAddressDetailCarga.Text = dtCarga.Rows(0)("Morada").ToString
                    tbCityCarga.Text = dtCarga.Rows(0)("Localidade").ToString
                    tbPostalCodeCarga.Text = dtCarga.Rows(0)("CodPostal").ToString
                End If

                If dtDescarga.Rows.Count > 0 Then
                    tbAddressDetailDescarga.Text = dtDescarga.Rows(0)("Morada").ToString
                    tbCityDescarga.Text = dtDescarga.Rows(0)("Localidade").ToString
                    tbPostalCodeDescarga.Text = dtDescarga.Rows(0)("CodPostal").ToString
                    tbCountryDescarga.Text = dtDescarga.Rows(0)("PaisID").ToString



                    If Len(dtDescarga.Rows(0)("NIF").ToString) = 0 Then
                        MsgBox("FALTA O NIF DO CLIENTE!")
                        LimparForm()
                        Me.CbDestino.SelectedValue = "%"
                        Exit Sub
                    Else
                        If tbCountryDescarga.Text = "PT" Then
                            If Not IsValidContrib(dtDescarga.Rows(0)("NIF").ToString()) Then
                                MsgBox("Nº Contribuinte errado!")
                                Me.CbDestino.SelectedValue = "%"
                                LimparForm()
                                Exit Sub
                            End If
                        End If
                        tbNIF.Text = dtDescarga.Rows(0)("NIF").ToString
                    End If

                Else
                    LimparForm()
                End If


            Else

                Sql = "SELECT IdDocCab, AddressDetailCarga, CityCarga, PostalCodeCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga FROM DocCab WHERE (IdDocCab = '" & sIdDocCabAux & "')"
                db.GetData(Sql, dtCargaDescarga)

                If dtCargaDescarga.Rows.Count > 0 Then

                    tbAddressDetailCarga.Text = dtCargaDescarga.Rows(0)("AddressDetailCarga").ToString
                    tbCityCarga.Text = dtCargaDescarga.Rows(0)("CityCarga").ToString
                    tbPostalCodeCarga.Text = dtCargaDescarga.Rows(0)("PostalCodeCarga").ToString
                    tbAddressDetailDescarga.Text = dtCargaDescarga.Rows(0)("AddressDetailDescarga").ToString
                    tbCityDescarga.Text = dtCargaDescarga.Rows(0)("CityDescarga").ToString
                    tbPostalCodeDescarga.Text = dtCargaDescarga.Rows(0)("PostalCodeDescarga").ToString
                    tbCountryDescarga.Text = dtCargaDescarga.Rows(0)("CountryDescarga").ToString
                    dpMovementStartTime.Value = dtCargaDescarga.Rows(0)("MovementStartTime").ToString

                End If


            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarInfoCargaDescarga")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarInfoCargaDescarga")
        Finally

        End Try


    End Sub

    Private Function ValidarArtigo(ByRef sArtigo As String) As Boolean

        Dim db As New ClsSqlBDados

        Try


            'Sql = "SELECT COUNT(*) FROM MODELOCOR WHERE MODELOID + CORID='" & sArtigo & "'"
            Sql = "SELECT COUNT(*) FROM Product WHERE ProductCode = N'" & sArtigo & "'"
            If db.GetDataValue(Sql) = 0 Then
                Return False
                DocDetDataGridView.CurrentCell.Value = ""
                DocDetDataGridView.CurrentCell = DocDetDataGridView.Item("Artigo", DocDetDataGridView.CurrentRow.Index)

            Else
                Return True
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ValidarArtigo")
        Catch ex As Exception
            ErroVB(ex.Message, "ValidarArtigo")
        Finally
            db = Nothing
        End Try


    End Function

    Private Sub btPNº_Click(sender As System.Object, e As System.EventArgs) Handles btPedirNrAT.Click

        Try

            If Len(tbNrAT.Text) > 0 Then
                MsgBox("CÓDIGO JÁ ATRIBUIDO!!")
                Exit Sub
            End If
            If My.Computer.Network.Ping("www.google.com") Then

                Dim db As New ClsSqlBDados
                Dim sNumAT As String = ""

                If tbCountryDescarga.Text = "PT" Then

                    Dim NumAT As New clsWebServiceGTs
                    NumAT.PedidoAT(sIdDocCabAux, sNumAT)

                Else
                    sNumAT = "Estrangeiro"

                End If

                ' GRAVAR NUMERO AT NA GUIA
                If sNumAT <> "" Then
                    Sql = "UPDATE DocCab SET ATDocCodeID = N'" & sNumAT & "' WHERE IdDocCab='" & sIdDocCabAux & "'"
                    db.ExecuteData(Sql)
                    tbNrAT.Text = sNumAT
                End If

            End If

        Catch ex As Exception
            MsgBox("A Ligação à internet não está disponivel!!")
        End Try



    End Sub

    Function DevolveIvaDataSet(ByVal IvaID As Double) As Double


        Try

            For Each r As DataRow In Me.GirlDataSet.TaxIVA.Rows
                If r("IvaID") = IvaID Then
                    Return r("TxIVA")
                End If
            Next
            Return 0


        Catch ex As Exception

        End Try


    End Function



    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

    '    'If keyData = Keys.Enter Then
    '    '    If TypeOf Me.ActiveControl Is DataGridViewTextBoxEditingControl Then
    '    '        If DocDetDataGridView.CurrentCell.ColumnIndex < DocDetDataGridView.ColumnCount - 3 Then
    '    '            DocDetDataGridView.CurrentCell = DocDetDataGridView.Rows(DocDetDataGridView.CurrentCell.RowIndex).Cells(DocDetDataGridView.CurrentCell.ColumnIndex + 1)
    '    '        Else
    '    '            Return MyBase.ProcessCmdKey(msg, keyData)
    '    '        End If
    '    '    End If
    '    'Else
    '    '    Return MyBase.ProcessCmdKey(msg, keyData)
    '    'End If



    '    If keyData = Keys.Enter Then
    '        If TypeOf Me.ActiveControl Is DataGridViewTextBoxEditingControl Then
    '            SendKeys.Send("{Escape}")

    '        End If
    '    End If



    'End Function


    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        If keyData = Keys.Enter Then
            ' DO NOTHING 
            Return True
        End If

        ' Handle all other keys as usual
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        Try
            'PLAY VIDEO
            'Dim prc As New Process
            'prc.StartInfo.FileName = "D:\Fotos e Videos\20160126\123.mp4"
            'prc.StartInfo.Arguments.Insert(0, "-Fullscreen")
            'prc.Start()
            ''My.Computer.Audio.Play("D:\Musica\George Benson- Live Best Of(2005)[Eac Flac Cue](UF SPG)(JazzPlanet)", AudioPlayMode.Background)


        Catch ex As Exception
            MsgBox("ERRO")
        End Try


    End Sub



End Class