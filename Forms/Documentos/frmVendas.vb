Imports System.Data.SqlClient



Public Class frmVendas


    Dim Foto As New ClsFotos
    Dim CM As CurrencyManager
    Private ds_AuxData As New DataSet
    Friend ds_Vendas As New DataSet
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents SerieTableAdapter As GirlRootName.GirlDataSetTableAdapters.SerieTableAdapter
    Friend WithEvents ModeloCorTableAdapter As GirlRootName.GirlDataSetTableAdapters.ModeloCorTableAdapter
    Friend WithEvents FormaPagamentoTableAdapter As GirlRootName.GirlDataSetTableAdapters.FormaPagamentoTableAdapter
    Friend xNovoTalao As String
    Dim xLinhaC1FlexGrid As Int16
    Friend xNovaVDAux As String
    Friend xNovaTDAux As String
    Friend xNovaTT As String
    Dim dtVendedor As New DataTable
    Dim xTipoPagamento As String
    Dim dtDevolucao As New DataTable
    Friend xIdDocSuspenso As String
    Dim Linha As Integer
    Dim sIdDocCabOrig As String = "Null"
    Dim sVendedorOriginal As String
    Dim sTipoNIF As String
    Dim sNIF As String
    Dim bEditarGrid As Boolean
    Dim dtTalao As New DataTable
    Dim sVendedorDevolu��o As String
    Dim sDevAdiantamento As Boolean = False
    Dim sClienteLojaIdAux As String = 1
    Dim sEtiquetaEstado As String
    Dim dComissao As Double
    Dim xEtiquetaAux As String
    Dim sAuxNovaLinha As String



    'PROCEDIMENTOS NO FORM

    Private Sub frmVendas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New ClsSqlBDados


        Try


            If permite_emitir_docs() = False Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            cbVendedor.Enabled = False
            lbNIF.Visible = False
            sReservasSinais = False 'para garantir que o cliente n�o � chamado pelas reservas!!!

            'cbDevolver.Enabled = True

            'CARREGAR UTILIZADORES

            'Sql = "SELECT UtilizadorID, NomeUtilizador, ArmazemID, PassWord FROM Utilizadores WHERE ArmazemID = '" + xArmz + "' AND NovaPassWord='0'"
            'acho que validar se apassword est� v�lida n�o � relevante neste ponto....
            Sql = "SELECT UtilizadorID, NomeUtilizador, ArmazemID, PassWord FROM Utilizadores WHERE ArmazemID = '" + xArmz + "'"

            db.GetData(Sql, dtVendedor, False)


            Me.cbVendedor.DataSource = dtVendedor
            Me.cbVendedor.DisplayMember = "NomeUtilizador"
            Me.cbVendedor.ValueMember = "UtilizadorID"
            If Len(sVendedor) > 0 Then
                Me.cbVendedor.SelectedValue = sVendedor
            Else
                MsgBox("N�O EXISTE VENDEDOR CRIADO PARA ESSA LOJA!")
                Exit Sub
            End If

            Application.DoEvents()

            Me.GirlDataSet = New GirlRootName.GirlDataSet
            Me.SerieTableAdapter = New GirlRootName.GirlDataSetTableAdapters.SerieTableAdapter
            Me.ModeloCorTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ModeloCorTableAdapter
            Me.FormaPagamentoTableAdapter = New GirlRootName.GirlDataSetTableAdapters.FormaPagamentoTableAdapter

            lbQtdTaloes.Text = "Total Tal�es : " & 0

            Me.Cursor = Cursors.Default
            Application.DoEvents()

            CancelarVenda()
            SendKeys.Send("{Enter}")

            If bLojaConsignacao = True Then
                btVD.Visible = False
                btMB.Visible = False
                btCliente.Visible = False
                lbCliente.Visible = False
                lbNIF.Visible = False
                'vou ter que controlar o que vai fazer na devolu��o
                cbDevolver.Visible = True
                btConsignacao.Visible = True



            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": frmVendas_Load")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": frmVendas_Load")
        End Try

    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub

    Private Sub btMB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btMB.DoubleClick
        'n�o faz nada
    End Sub

    Private Sub btVD_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btVD.DoubleClick
        'n�o faz nada
    End Sub

    Private Sub frmVnd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dgvVendas.AllowUserToAddRows = False
        If dgvVendas.Rows.Count > 0 Then
            MsgBox("Tem Registos pendentes!", MsgBoxStyle.Exclamation, "Aviso!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        CancelarVenda()
    End Sub

    Private Sub btVD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVD.Click

        btVD.Enabled = False
        btMB.Enabled = False
        dgvVendas.AllowUserToAddRows = False
        bEditarGrid = True


        Try


            Dim inLinhas As Integer = 0
            For Each row As DataGridViewRow In dgvVendas.Rows
                If Len(row.Cells.Item("Etiqueta").Value) > 0 Then
                    inLinhas += 1
                End If
            Next
            If inLinhas = 0 Then Exit Sub


            xTipoPagamento = "VD"
            If xArmz = "0000" Then
                MsgBox("N�O � POSSIVEL FAZER VENDAS NO ARMAZEM '0000'")
                btVD.Enabled = True
                btMB.Enabled = True
                Exit Sub
            End If


            If Val(lblValorTotal.Text) > 1000 Then
                MsgBox("N�O � POSSIVEL FAZER FATURAS SIMPLIFICADAS COM VALOR SUPERIOR A 1000�")
                btVD.Enabled = True
                btMB.Enabled = True
                Exit Sub
            End If

            xTipoDoc = "FS"
            sTipoNIF = DevolveTipoNIF(Microsoft.VisualBasic.Left(sNIF, 1))
            If sTipoNIF <> "P" And Val(lblValorTotal.Text) > 100 Then
                xTipoDoc = "FT"
                'TODO: ROTINA PARA GARANTIR QUE QUANDO VAI EMITIR A FATURA, NELA CONSTAM TODOS OS ELEMENTOS OBRIGAT�RIOS..............
                'MsgBox("PARA EMPRESAS N�O � POSSIVEL FAZER FS > 100�!" & Chr(13) & "PE�A AO ARMAZEM PARA EMITIR UMA FATURA!")
                'btVD.Enabled = True
                'btMB.Enabled = True
                'Exit Sub
            End If

            If cbDevolver.Checked Then
                If ValidarDevolucao() Then
                    GravarVenda("NC")
                    Me.cbVendedor.SelectedValue = sVendedor
                End If
            Else
                GravarVenda(xTipoDoc)
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": btVD_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": btVD_Click")
        Finally

            CancelarVenda()
            btVD.Enabled = True
            btMB.Enabled = True
            btCliente.Enabled = True
            sDevAdiantamento = False

        End Try

    End Sub

    Private Sub btMB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMB.Click

        btVD.Enabled = False
        btMB.Enabled = False
        dgvVendas.AllowUserToAddRows = False
        bEditarGrid = True



        Try

            Dim inLinhas As Integer = 0
            For Each row As DataGridViewRow In dgvVendas.Rows
                If Len(row.Cells.Item("Etiqueta").Value) > 0 Then
                    inLinhas += 1
                End If
            Next
            If inLinhas = 0 Then Exit Sub

            xTipoPagamento = "MB"
            If xArmz = "0000" Then
                MsgBox("N�O � POSSIVEL FAZER VENDAS NO ARMAZEM '0000'")
                btVD.Enabled = True
                btMB.Enabled = True
                Exit Sub
            End If

            If Val(lblValorTotal.Text) > 1000 Then
                MsgBox("N�O � POSSIVEL FAZER VENDAS COM VALOR SUPERIOR A 1000�")
                btVD.Enabled = True
                btMB.Enabled = True
                Exit Sub
            End If


            xTipoDoc = "FS"
            sTipoNIF = DevolveTipoNIF(Microsoft.VisualBasic.Left(sNIF, 1))
            If sTipoNIF <> "P" And Val(lblValorTotal.Text) > 100 Then
                xTipoDoc = "FT"
            End If


            If cbDevolver.Checked Then
                If ValidarDevolucao() Then
                    GravarVenda("NC")
                    Me.cbVendedor.SelectedValue = sVendedor
                End If
            Else
                GravarVenda(xTipoDoc)
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": btMB_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": btMB_Click")
        Finally

            CancelarVenda()
            btVD.Enabled = True
            btMB.Enabled = True
            btCliente.Enabled = True

        End Try

    End Sub

    Private Sub btCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCliente.Click


        If SistemaBloqueado() = True Then
            Exit Sub
        End If

        sIDClienteLoja = ""
        frmClientesLojaLista.WindowState = FormWindowState.Normal
        frmClientesLojaLista.StartPosition = FormStartPosition.CenterScreen
        frmClientesLojaLista.ShowDialog(Me)

        ActualizarClienteLoja(sIDClienteLoja, sClienteLojaIdAux, lbCliente.Text, sNIF)

        'Dim db As New ClsSqlBDados
        'Sql = "SELECT NOME FROM CLIENTESLOJA WHERE IDClienteLoja='" & sIDClienteLoja & "'"
        'lbCliente.Text = db.GetDataValue(Sql)
        'Sql = "SELECT ISNULL(NIF,'') FROM CLIENTESLOJA WHERE IDClienteLoja='" & sIDClienteLoja & "'"
        'sNIF = db.GetDataValue(Sql).ToString
        lbNIF.Text = "NIF : " & sNIF
        sTipoNIF = DevolveTipoNIF(Microsoft.VisualBasic.Left(sNIF, 1))

        'If sNIF = "xxxxxxxxx" Then
        '    lbNIF.Visible = False
        'Else
        '    lbNIF.Visible = True
        'End If

        If lbNIF.Text <> "NIF : xxxxxxxxx" And Trim(lbNIF.Text) <> "NIF :" Then
            lbNIF.Visible = True
        Else
            lbNIF.Visible = False
        End If



        Me.dgvVendas.Focus()
        dgvVendas.CurrentCell = dgvVendas.Item("Etiqueta", dgvVendas.RowCount - 1)
        dgvVendas.BeginEdit(True)


    End Sub

    Private Sub cbDevolver_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDevolver.CheckStateChanged

        If SistemaBloqueado() = True Then Exit Sub
        bCancelarEvento = False

        Dim db As New ClsSqlBDados
        sIdDocCabOrig = "Null"
        sNIF = ""

        Try

            If cbDevolver.CheckState Then

                cbDevolver.Enabled = False
                dgvVendas.AllowUserToAddRows = False
                dgvVendas.Enabled = False


                Dim frmvl As New frmVendasLista
                frmvl.WindowState = FormWindowState.Maximized
                frmvl.StartPosition = FormStartPosition.CenterScreen
                frmvl.ShowDialog(Me)
                frmvl.Dispose()


                If bCancelarEvento = True Then
                    CancelarVenda()
                    Exit Sub
                End If

                'CARREGAR CLIENTE DO DOC DE ORIGEM E BLOQUEAR BOT�O.
                Sql = "SELECT TercID FROM DocCab WHERE IdDocCab='" & sIdDocCabAux & "'"
                Dim sCliAux As String = db.GetDataValue(Sql).ToString
                sClienteLojaIdAux = sCliAux
                Sql = "SELECT NOME FROM CLIENTESLOJA WHERE ClienteLojaID='" & sCliAux & "'"
                lbCliente.Text = db.GetDataValue(Sql)
                Sql = "SELECT ISNULL(NIF,'') FROM CLIENTESLOJA WHERE ClienteLojaID='" & sCliAux & "'"
                sNIF = db.GetDataValue(Sql).ToString
                lbNIF.Text = "NIF : " & sNIF
                sTipoNIF = DevolveTipoNIF(Microsoft.VisualBasic.Left(sNIF, 1))

                btCliente.Enabled = False
                sIdDocCabOrig = sIdDocCabAux.ToString

                Sql = "SELECT UtilizadorId FROM DocCab WHERE (IdDocCab = '" & sIdDocCabAux & "') "
                sVendedorDevolu��o = db.GetDataValue(Sql)


                If Len(sVendedorDevolu��o) > 0 Then
                    If sVendedor <> sVendedorDevolu��o Then

                        Sql = "SELECT NomeUtilizador FROM Utilizadores WHERE UtilizadorID=" & sVendedorDevolu��o
                        MsgBox("A VENDA FOI EFECTUADA PELO VENDEDOR : " & db.GetDataValue(Sql))
                        Me.cbVendedor.SelectedValue = sVendedorDevolu��o
                    End If
                End If

                CarregarDevolucao(sIdDocCabAux)

                'Else
                '    'TODO: SE CLIENTE SELECCIONADO FILTAR!!
                '    MsgBox("N�o existem FS!")
                '    CancelarVenda()
                '    Exit Sub
                'End If

            Else
                CancelarVenda()
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": cbDevolver_CheckStateChanged")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": cbDevolver_CheckStateChanged")
        Finally


            ActualizarTotal()

        End Try


    End Sub

    Private Sub cbVendedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVendedor.SelectionChangeCommitted

        dgvVendas.Focus()

    End Sub

    Private Sub cbVendedor_Validated(sender As Object, e As System.EventArgs) Handles cbVendedor.Validated

        Try



            If Not cbVendedor.SelectedValue Is Nothing Then

                'frmPassword.cbVendedorX = Me.Location.X + Me.cbVendedor.Location.X
                'frmPassword.cbVendedorY = Me.Location.Y + Me.cbVendedor.Location.Y + 120

                sVendedorOriginal = sVendedor
                sVendedor = cbVendedor.SelectedValue.ToString

                frmPassword.StartPosition = FormStartPosition.CenterParent
                frmPassword.WindowState = FormWindowState.Normal
                frmPassword.ShowInTaskbar = False
                frmPassword.MaximizeBox = False
                frmPassword.MinimizeBox = False
                frmPassword.ShowDialog(Me)

                If Not bPassWord Then
                    iUtilizadorID = sVendedorOriginal
                    sVendedor = sVendedorOriginal
                    Me.cbVendedor.SelectedValue = sVendedor

                Else
                    iUtilizadorID = sVendedor
                End If

                dgvVendas.Focus()

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": cbVendedor_Validated")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": cbVendedor_Validated")
        Finally

        End Try


    End Sub


    'PROCEDIMENTOS NA dgvVendas


    Private Sub dgvVendas_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvVendas.CellValidating


        'Try
        Dim db As New ClsSqlBDados
        xEtiquetaAux = ""


        If dgvVendas.Columns(e.ColumnIndex).Name = "Etiqueta" Then

            If Len(e.FormattedValue.ToString()) = 0 Or bEditarGrid = True Then
                'e.Cancel = True
                'SendKeys.Send("{escape}")

                'dgvGrid.Rows.RemoveAt(i);
                'dgvVendas.Rows.RemoveAt(e.RowIndex)

                'dgvVendas.Rows.Remove(dgvVendas.SelectedRows(0))

                Exit Sub

            End If

            If Len(e.FormattedValue.ToString()) <> 8 Then


                e.Cancel = True
                MsgBox("Etiqueta inv�lida")
                SendKeys.Send("{escape}")

                btConsignacao.Enabled = True
                btMB.Enabled = True
                btVD.Enabled = True

                Exit Sub

            End If


            xEtiquetaAux = e.FormattedValue.ToString()

            If xEtiquetaAux = "21000002" Or xEtiquetaAux = "21000003" Or xEtiquetaAux = "21000004" Then
                dtTalao.Clear()
                Sql = "SELECT Serie.ProductCode, Product.ProductDescription, Serie.TamID, Serie.PrecoEtiqueta, Serie.PrecoVenda, Product.UnitOfMeasure, Serie.ModeloID AS MODELO, Serie.CorID AS COR FROM Serie INNER JOIN Product ON Serie.ProductCode = Product.ProductCode WHERE (Serie.SerieID = '" & xEtiquetaAux & "')"
                db.GetData(Sql, dtTalao)
                dComissao = 0
                GoTo 200
            End If


            'VAI VALIDAR A ETIQUETA E RETORNAR A COMIS�O!!
            If ValidarEtiqueta(xEtiquetaAux, sEtiquetaEstado, dComissao, bEnviaEmail) Then
                'CARREGAR LINHA
200:

                Me.dgvVendas("ProductCode", dgvVendas.CurrentRow.Index).Value = dtTalao.Rows(0)("ProductCode")
                Me.dgvVendas("TamID", dgvVendas.CurrentRow.Index).Value = dtTalao.Rows(0)("TamID")
                Me.dgvVendas("ProductDescription", dgvVendas.CurrentRow.Index).Value = dtTalao.Rows(0)("ProductDescription")
                Me.dgvVendas("Qtd", dgvVendas.CurrentRow.Index).Value = 1
                Me.dgvVendas("UnitOfMeasure", dgvVendas.CurrentRow.Index).Value = dtTalao.Rows(0)("UnitOfMeasure")
                Me.dgvVendas("PrecoEtiqueta", dgvVendas.CurrentRow.Index).Value = dtTalao.Rows(0)("PrecoEtiqueta")
                Me.dgvVendas("Desconto", dgvVendas.CurrentRow.Index).Value = dtTalao.Rows(0)("PrecoEtiqueta") - dtTalao.Rows(0)("PrecoVenda")
                Me.dgvVendas("Valor", dgvVendas.CurrentRow.Index).Value = dtTalao.Rows(0)("PrecoVenda")
                Me.dgvVendas("Modelo", dgvVendas.CurrentRow.Index).Value = dtTalao.Rows(0)("Modelo")
                Me.dgvVendas("Cor", dgvVendas.CurrentRow.Index).Value = dtTalao.Rows(0)("Cor")
                Me.dgvVendas("IVAId", dgvVendas.CurrentRow.Index).Value = xIvaID
                Me.dgvVendas("Comissao", dgvVendas.CurrentRow.Index).Value = dComissao
                Me.dgvVendas("TxIva", dgvVendas.CurrentRow.Index).Value = DevolveIva(xIvaID)
                Foto.CarregarFotoModeloCor(Me.PictureBox, dtTalao.Rows(0)("Modelo") & dtTalao.Rows(0)("Cor")) 'Carregar IMAGEM

            Else
                If bEnviaEmail = True Then EnviarEmail("Vendas - Erro Tal�o", "Erro ao Validar o Tal�o: " & xEtiquetaAux & " Motivo : " & sEtiquetaEstado & " Local : " & xArmz)
                e.Cancel = True
                SendKeys.Send("{escape}")
            End If



        End If

        btConsignacao.Enabled = True
        btMB.Enabled = True
        btVD.Enabled = True


        'falta controlar os erros, mas se n�o tiver cuidado, controla o erro mas deixa ficar o tal�o disponivel para venda......

        'Catch ex As Exception
        '    'ErroVB(ex.Message, "dgvVendas_CellValidating")
        'End Try


    End Sub

    Private Sub dgvVendas_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvVendas.CellBeginEdit

        'btConsignacao.Enabled = False
        'btMB.Enabled = False
        'btVD.Enabled = False

        If dgvVendas.Columns(e.ColumnIndex).Name <> "Etiqueta" Then
            e.Cancel = True
        Else
            If Len(dgvVendas(e.ColumnIndex, e.RowIndex).Value) > 0 Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub dgvVendas_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVendas.RowEnter

        If Len(dgvVendas("Etiqueta", e.RowIndex).Value) > 0 Then
            bEditarGrid = True
        Else
            bEditarGrid = False
        End If
        ActualizarTotal()

    End Sub



    'PROCEDIMENTOS NA TXTBOX VALORRECEBIDO

    Private Sub txtValorRecebido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValorRecebido.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Me.btVD.Focus()
        End If
    End Sub

    Private Sub txtValorRecebido_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorRecebido.TextChanged
        Dim ValRecebido As Double = 0
        If IsNumeric(Me.txtValorRecebido.Text) Then
            ValRecebido = CDbl(Me.txtValorRecebido.Text)
        End If
        Dim ValTotal As Double = 0
        If IsNumeric(Me.lblValorTotal.Text) Then
            ValTotal = CDbl(Me.lblValorTotal.Text)
        End If
        If ValTotal >= ValRecebido Then
            'Me.lblTroco.Text = "0.00�"
            Me.lblTroco.Text = FormatCurrency(0)
        Else
            'Me.lblTroco.Text = Format(ValRecebido - ValTotal, "#,##0.00")
            Me.lblTroco.Text = FormatCurrency(ValRecebido - ValTotal)
        End If
    End Sub

    Private Sub txtValorRecebido_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorRecebido.LostFocus
        If IsNumeric(Me.txtValorRecebido.Text) Then
            Me.txtValorRecebido.Text = Format(CDbl(Me.txtValorRecebido.Text), "#,##0.00")
        Else
            Me.txtValorRecebido.Text = Format(0, "#,##0.00")
        End If
    End Sub

    Private Sub txtValorRecebido_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtValorRecebido.MouseClick
        txtValorRecebido.SelectAll()
    End Sub


    'ROTINAS E FUN��ES


    Private Sub ActualizarTotal()
        Try

            Dim Valor As Double
            Dim QtdTotal As Integer


            For Each row As DataGridViewRow In dgvVendas.Rows
                Valor += row.Cells.Item("Valor").Value
                QtdTotal += row.Cells.Item("Qtd").Value
            Next

            lblValorTotal.Text = FormatCurrency(Valor)
            lbQtdTaloes.Text = "Quantidade Total  : " & QtdTotal

        Catch ex As Exception
            ErroVB(ex.Message, "frmPainelPrincipal: ActualizarTotal")
        Finally
        End Try
    End Sub

    Friend Sub CancelarVenda()

        Me.cbVendedor.SelectedValue = sVendedor
        dgvVendas.AllowUserToAddRows = True
        dgvVendas.Rows.Clear()
        ActualizarTotal()
        Me.PictureBox.Image = Nothing
        cbDevolver.Enabled = True
        cbDevolver.CheckState = False
        btVD.Enabled = True
        btMB.Enabled = True
        btCliente.Enabled = True
        sIDClienteLoja = ""
        sDevAdiantamento = False
        ActualizarClienteLoja(sIDClienteLoja, sClienteLojaIdAux, lbCliente.Text, sNIF)
        Me.dgvVendas.Focus()
        dgvVendas.CurrentCell = dgvVendas.Item("Etiqueta", dgvVendas.RowCount - 1)
        dgvVendas.BeginEdit(True)
        lbNIF.Text = ""
        'If lbNIF.Text <> "NIF : xxxxxxxxx" And Trim(lbNIF.Text) <> "NIF :" Then
        '    lbNIF.Visible = True
        'Else
        '    lbNIF.Visible = False
        'End If

    End Sub

    Private Sub GravarDocumento(ByVal xTipoDoc As String)

        Dim I As Int16 = 1
        Dim db As New ClsSqlBDados
        Dim Filtro As String = ""
        Dim xFormaPagamento As String = ""

        Dim xNovoDoc As String = PesquisaMaxNumDoc(xTipoDoc)
        Dim gIdDocCab As Guid = Guid.NewGuid
        Dim gIdDocDet As Guid
        dberrorAtivo = True
        'j� est� tratado nos doc ft e gt

        'ATT: ESTE COMANDO TB EXISTE EM frmStockFoto
        Try

            Select Case xTipoPagamento
                Case "MB"
                    xFormaPagamento = "6"
                Case "VD"
                    xFormaPagamento = "1"
            End Select

            If sIdDocCabOrig <> "Null" Then sIdDocCabOrig = "'" & sIdDocCabOrig & "'"

            Sql = "SELECT TipoDocID + ' ' + SerieDoc + '/' + NrDoc AS DOC FROM DocCab WHERE IdDocCab = " & sIdDocCabOrig.ToString
            Dim sDocOrigem As String = db.GetDataValue(Sql)


            Sql = "SELECT CAST(IDClienteLoja AS char(36))  from ClientesLoja where ClienteLojaID='" & sClienteLojaIdAux & "'"
            Dim GuidDestino As String = db.GetDataValue(Sql)


            Dim sATCUD As String = DevolveATCUD(xArmz, xTipoDoc, xNovoDoc)

            If Now() >= #01/01/2023# And sATCUD = "0" Then
                dberror = True
            End If


            Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, TipoTerc, NIFTerc, FormaPagtoID, IDDocCab, IdDocCabOrig, DocOrig, UtilizadorID, OperadorID, IDTerceiro, ATCUD) " &
                  "VALUES('" & xEmp & "','" & xArmz & "','" & xTipoDoc & "','" & xNovoDoc & "', '" & sClienteLojaIdAux & "', GETDATE(), 'C', 'L','" & sNIF & "', '" & xFormaPagamento & "', '" & gIdDocCab.ToString & "'," & sIdDocCabOrig.ToString & ",'" & sDocOrigem & "', '" & cbVendedor.SelectedValue.ToString & "', '" & xUtilizador & "', '" & GuidDestino & "', '" & sATCUD & "')"
            db.ExecuteData(Sql)

            For Each row As DataGridViewRow In dgvVendas.Rows

                If Len(Me.dgvVendas("Etiqueta", row.Index).Value) = 0 Then
                    Exit For
                End If

                gIdDocDet = Guid.NewGuid

                'CARREGAR VARIAVEIS
                Dim xDocLnNr As Int32 = I

                Dim xSerieID As String = Me.dgvVendas("Etiqueta", row.Index).Value
                Dim sProductCode As String = Me.dgvVendas("ProductCode", row.Index).Value
                Dim xModeloID As String = Me.dgvVendas("Modelo", row.Index).Value
                Dim xCorID As String = Me.dgvVendas("Cor", row.Index).Value
                Dim xTamID As String = Me.dgvVendas("TamID", row.Index).Value
                Dim xDescricao As String = Me.dgvVendas("ProductDescription", row.Index).Value
                Dim xUnidade As String = Me.dgvVendas("UnitOfMeasure", row.Index).Value
                'Dim xPreco As Double = Me.dgvVendas("PrecoEtiqueta", row.Index).Value
                Dim xValor As Double = Me.dgvVendas("Valor", row.Index).Value

                'VOU PASSAR OS VALORES SEM DESCONTO!!
                'Dim xPercDescLn As Double = 0
                'Dim xVlrDescLn As Double = Me.dgvVendas("Desconto", row.Index).Value
                'Dim xQtd As Int16 = Me.dgvVendas("Qtd", row.Index).Value

                Dim dTxIva As Double = Me.dgvVendas("TxIva", row.Index).Value
                Dim sIVAIdAux As String = Me.dgvVendas("IVAId", row.Index).Value
                Dim xVlrIva As Double = Arredondamento(xValor * dTxIva / (1 + dTxIva), 2)
                Dim xValorLiquido As Double = xValor - xVlrIva

                Dim dComissao As Double = Me.dgvVendas("Comissao", row.Index).Value

                Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, Valor, PercDescLn, VlrDescLn, IvaID, VlrIva, TxIva, Comissao, Qtd, EstadoLn, IdDocCab, IdDocDet, ProductCode, ValorLiquido) " &
                "VALUES('" & xEmp & "', '" & xArmz & "', '" & xTipoDoc & "', '" & xNovoDoc & "', " & xDocLnNr & ", '" & xSerieID & "', '" & xModeloID & "', '" & xCorID & "', '" & xTamID & "', '" & xDescricao & "','" & xUnidade & "'," & xValor & ", 0,0, '" & sIVAIdAux & "',  " & xVlrIva & ",  " & dTxIva & "," & dComissao & ",1,'C','" & gIdDocCab.ToString & "','" & gIdDocDet.ToString & "','" & sProductCode & "', '" & xValorLiquido & "')"

                db.ExecuteData(Sql)
                I += 1

            Next


            Dim HashKey As New clsHash
            HashKey.CriarHashKey(gIdDocCab.ToString)


            Dim cQrCode As New clsQrCode
            cQrCode.CarregaQrCode(gIdDocCab.ToString)




            If HashOK = True Or xTipoDoc = "VC" Then


                For Each row As DataGridViewRow In dgvVendas.Rows

                    Dim xSerieID As String = Me.dgvVendas("Etiqueta", row.Index).Value
                    Dim xValor As Double = Me.dgvVendas("Valor", row.Index).Value
                    Dim dComissao As Double = Me.dgvVendas("Comissao", row.Index).Value

                    'GRAVAR ATERA��ES NOS TAL�ES
                    If cbDevolver.Checked = True Then

                        'REP�R O PRE�O DE VENDA DA TABELA
                        Dim xPrecoVenda As Double = DevolvePv(xArmz, xSerieID)

                        If sDevAdiantamento = False Then

                            Sql = "UPDATE Serie SET PVndReal = 0, DtSaida = GETDATE() , Vendedor = '', DocNr = '', OperadorID = '" + xUtilizador + "', EstadoID='S' , PrecoVenda = '" & xPrecoVenda & "', Comissao = '0' WHERE SerieID = '" + xSerieID + "'"
                            db.ExecuteData(Sql)

                            Sql = "UPDATE DocDet SET EstadoLn = 'D' FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.IdDocCab = " & sIdDocCabOrig & ") AND (DocDet.SerieID = '" + xSerieID + "')"
                            db.ExecuteData(Sql)

                            If MsgBox("Reimprimir Etiqueta " & xSerieID & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                ListaTaloes(xSerieID, "RptTaloesReimpressao", True)
                            End If

                        Else

                            Sql = "UPDATE DocDet SET EstadoLn = 'D' FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.IdDocCab = " & sIdDocCabOrig & ")"
                            db.ExecuteData(Sql)

                        End If

                    Else

                        If sDevAdiantamento = False Then
                            'se estivermos a vender os tal�es de sacos, n�o vai fazer update na tabela tal�es.....
                            If xSerieID = "" Then
                                Sql = "UPDATE Serie SET Comissao= '0' WHERE SerieID = '" & xSerieID & "'"
                            Else
                                Sql = "UPDATE Serie SET EstadoID = 'V', PVndReal = '" & xValor & "', Comissao= '" & dComissao & "', DocNr='" + xTipoDoc + " " + Microsoft.VisualBasic.Left(xNovoDoc, 2) + Microsoft.VisualBasic.Right(xArmz, 2) + "/" + Microsoft.VisualBasic.Right(xNovoDoc, 5) + "', Vendedor = '" & cbVendedor.SelectedValue.ToString & "', OperadorID = '" & xUtilizador & "', DtSaida = Getdate() WHERE SerieID = '" & xSerieID & "'"
                                db.ExecuteData(Sql)
                            End If
                        End If
                    End If
                Next


                Dim backupdoc As New ClsExportaXML
                backupdoc.exportadocs(gIdDocCab.ToString)


                If bLojaConsignacao = True Then Exit Sub

                If dberror = False Then
                    ListaDocPOS(xNovoDoc, xTipoDoc, "Original", True)
                    If bDesenvolvimento = False Then
                        'ListaDocPOS(xNovoDoc, xTipoDoc, "Duplicado", True)
                    End If

                Else
                    'MELHORAR ESTE PROCESSO!!!!
                    Sql = "DELETE FROM DocCab WHERE IdDocCab = '" & gIdDocCab.ToString & "'"
                    db.ExecuteData(Sql)

                    EnviarEmail("Erro", "ERRO N�684 NA CRIA��O DO DOC " + " " + xArmz + "" + gIdDocCab.ToString)
                    MsgBox("ERRO N�684 NA CRIA��O DO DOCUMENTO - AVISE O TECNICO!")
                End If


            Else
                'APAGAR DOCUMENTO NOTA : SE DER ERRO NA CRIA��O DA HASH J� N�O CHEGA AQUI....PENSO QUE AGORA CHEGA....
                Sql = "DELETE FROM DocCab WHERE IdDocCab = '" & gIdDocCab.ToString & "'"
                db.ExecuteData(Sql)

                EnviarEmail("Erro", "ERRO N�225V NA CRIA��O DO DOC " + " " + xArmz + "  " + gIdDocCab.ToString)
                MsgBox("ERRO N�225V NA CRIA��O DO DOCUMENTO - AVISE O TECNICO!")

                ''VERIFICAR SE EST� VAI APAGAR A ULTIMA!! 
                'Sql = "SELECT DocCab_1.IdDocCab FROM (SELECT EmpresaID, ArmazemID, TipoDocID, MAX(DocNr) AS ULTIMO FROM DocCab GROUP BY EmpresaID, ArmazemID, TipoDocID HAVING (EmpresaID = '0001') AND (ArmazemID = '0003') AND (TipoDocID = 'FS')) AS MAXIMO INNER JOIN DocCab AS DocCab_1 ON MAXIMO.EmpresaID = DocCab_1.EmpresaID AND MAXIMO.ArmazemID = DocCab_1.ArmazemID AND MAXIMO.TipoDocID = DocCab_1.TipoDocID AND MAXIMO.ULTIMO = DocCab_1.DocNr"
                'Dim sIdDocCabAux As String = db.GetDataValue(Sql)


            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " GravarDocumento")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub GravarVenda(ByRef TipoDoc As String)

        Try
            If SistemaBloqueado() = True Then
                Exit Sub
            End If

            For Each row As DataGridViewRow In dgvVendas.Rows
                If Len(Me.dgvVendas("Etiqueta", row.Index).Value) = 0 Then
                    'dgvVendas.Rows.RemoveAt(dgvVendas.CurrentRow.Index)
                    Exit Sub
                End If
            Next


            AbrirGaveta()

            Dim db As New ClsSqlBDados

            'Verificar Vendedor
            If dtVendedor.Rows.Count > 0 Then
                If Len(cbVendedor.Text) = 0 Then
                    MsgBox("FALTA O VENDEDOR")
                    Exit Sub
                End If
            End If


            If dgvVendas.Rows.Count > 0 Then

                GravarDocumento(TipoDoc)
                dgvVendas.Rows.Clear()

            End If


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": cmdVndGravar_Click")
        Finally
            sIdDocCabOrig = "Null"
        End Try

    End Sub

    Private Function ValidarEtiqueta(ByVal sEtiqueta As String, ByRef sEtiquetaEstado As String, ByRef dComissao As Double, ByRef bEnviaEmail As Boolean) As Boolean

        Dim db As New ClsSqlBDados
        dtTalao.Clear()
        Dim sVendedorReserva As String
        sEtiquetaEstado = ""
        bEnviaEmail = False

        Try
            'VERIFICAR SE A ETIQUETA J� EST� NA GRID
            For Each row As DataGridViewRow In dgvVendas.Rows
                'MsgBox(dgvVendas.Rows.Count)
                'If dgvVendas.Rows.Count = 1 Then Exit For
                If row.Cells.Item("Etiqueta").Value = sEtiqueta Then
                    MsgBox("Etiqueta j� lan�ada!")
                    sEtiquetaEstado = "Etiqueta j� Lan�ada!"
                    bEnviaEmail = False
                    Return False
                End If
            Next

            'VERIFICAR SE A ETIQUETA EXISTE E EST� EM STOCK
            Sql = "SELECT Serie.ProductCode, Product.ProductDescription, Serie.TamID, Serie.PrecoEtiqueta, Serie.PrecoVenda, Product.UnitOfMeasure, Serie.ModeloID AS MODELO, Serie.CorID AS COR FROM Serie INNER JOIN Product ON Serie.ProductCode = Product.ProductCode WHERE (Serie.SerieID = '" & sEtiqueta & "') AND (Serie.ArmazemID = '" & xArmz & "') AND (Serie.EstadoID = 'S')"
            db.GetData(Sql, dtTalao)
            If dtTalao.Rows.Count = 0 Then
                MsgBox("Erro! Informe o Armaz�m!")
                GravarEvento("Tentativa de venda de Etiqueta que n�o est� no stock!", xArmz, sEtiqueta)
                sEtiquetaEstado = "Etiqueta n�o est� no stock da loja!"
                bEnviaEmail = True
                Return False
            End If


            'VERIFICAR SE A ETIQUETA EST� EM SEPARA��O
            Sql = "SELECT COUNT(*) FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE DocCab.ArmazemID = '" & xArmz & "' AND DocDet.TipoDocID = 'SE' AND DocCab.EstadoDoc = 'C' AND DocDet.SerieID = '" & sEtiqueta & "' AND DocDet.EstadoLn = 'G'"
            If db.GetDataValue(Sql) > 0 Then

                Sql = "SELECT DocDet.SerieID FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.TipoDocID = 'SE') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = DocCab.TercID) AND (DocCab.EstadoDoc = 'C') AND (DocDet.SerieID = '" & sEtiqueta & "')"

                If db.GetDataValue(Sql) = 0 Then

                    If MsgBox("O TAL�O EST� EM SEPARA��O! APAGAR DA SEPARA��O?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Sql = "DELETE FROM DOCDET WHERE EMPRESAID = '" & xEmp & "' AND ARMAZEMID = '" & xArmz & "' AND TIPODOCID = 'SE' AND SERIEID = '" & sEtiqueta & "' AND ESTADOLN = 'G'"
                        db.ExecuteData(Sql)
                    Else
                        Return False
                    End If

                Else
                    'EST� EM SEPARA��O PARA A PROPRIA CASA! N�O DEIXA APAGAR!!
                    MsgBox("Tal�o em Separa��o! N�o � possivel vender!")
                    sEtiquetaEstado = "Tal�o em Separa��o! N�o � possivel vender!"
                    bEnviaEmail = False
                    Return False
                End If


            End If

            'VERIFICAR SE EXISTE ALGUMA RESERVA DE OUTRA LOJA PARA O TAL�O
            Sql = "SELECT COUNT(*) FROM Reservas WHERE (ReservaSerieID = '" & sEtiqueta & "') AND (ReservaEstado = '0') AND (ReservaDescr LIKE '%RESERVA%') AND ArmazemID<>ArmzDest"
            If db.GetDataValue(Sql) > 0 Then
                MsgBox("Esse tal�o est� reservado!")
                GravarEvento("Esse tal�o est� reservado p/ outra loja!", xArmz, sEtiqueta)
                sEtiquetaEstado = "Esse tal�o est� reservado p/ outra loja!"
                bEnviaEmail = False
                Return False
            End If


            'VERIFICAR SE � UMA RESERVA/MEDIDA E SE O VENDEDOR � O MESMO
            Sql = "SELECT ISNULL(UtilizadorID,'0') FROM Reservas WHERE (ReservaEstado = 0) AND (ArmazemID = '" & xArmz & "') AND (ReservaSerieID = '" & sEtiqueta & "') ORDER BY ReservaID DESC"
            sVendedorReserva = db.GetDataValue(Sql)
            If Val(sVendedorReserva) > 0 And bLojaConsignacao = False Then
                If sVendedor <> sVendedorReserva Then
                    If dtVendedor.Compute("COUNT(UtilizadorID)", "UtilizadorID=" & sVendedorReserva & "") = 0 Then
                        MsgBox("Utilizador inv�lido! Verifique a Reserva")
                        Return False
                    Else
                        Me.cbVendedor.SelectedValue = sVendedorReserva
                    End If
                End If
            End If


            'VERIFICAR SE EXISTE COMISS�O PARA O TAL�O

            'Dim sVendedorAux As Integer
            'sVendedorAux = cbVendedor.SelectedValue.ToString

            dComissao = DevolveComissao(dtTalao.Rows(0)("Modelo"), dtTalao.Rows(0)("Cor"), cbVendedor.SelectedValue.ToString, dtTalao.Rows(0)("PrecoVenda"), sEtiqueta)



            'dComissao = DevolveComissao(dtTalao.Rows(0)("Modelo"), dtTalao.Rows(0)("Cor"), cbVendedor.SelectedValue.ToString, dtTalao.Rows(0)("PrecoVenda"), sEtiqueta)
            If dComissao = 0.00000111 Then
                sEtiquetaEstado = "Falta o valor da Comiss�o do Vendedor!"
                MsgBox("Falta o valor da Comiss�o do Vendedor!", MsgBoxStyle.Exclamation, "Erro Tal�o!")
                bEnviaEmail = True
                Return False
            End If

            Return True


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ValidarEtiqueta")
        Catch ex As Exception
            ErroVB(ex.Message, "ValidarEtiqueta")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try



    End Function

    'FUN��ES DE DEVOLU��O

    Private Function DevolvePv(ByVal xArmz As String, ByVal xSerie As String) As Double
        Dim xPv As Double
        Dim db As New ClsSqlBDados
        Dim xPrecoEtiqueta As String
        Try

            Sql = "SELECT P.Preco FROM Serie S, PrecoVenda P, Armazens A WHERE S.ModeloID = P.ModeloID " & _
                "AND S.CorID = P.CorID And P.TabPrecoID = A.TabPrecoID AND A.ArmazemID = '" & xArmz & "' AND S.SerieID = '" & xSerie & "'"
            xPv = db.GetDataValue(Sql)
            If xPv > 0 Then
                xPrecoEtiqueta = False
                Return xPv
                Exit Function
            End If
            Sql = "SELECT PrecoEtiqueta FROM Serie WHERE SerieID = '" & xSerie & "'"
            xPrecoEtiqueta = True
            Return db.GetDataValue(Sql)

        Catch ex As Exception
            ErroVB(ex.Message, "DevolvePv")
        Finally
            If db IsNot Nothing Then db.Dispose()
        End Try

    End Function

    Private Sub CarregarDevolucao(ByVal DocCab As String)

        Dim db As New ClsSqlBDados
        Dim dtTalaoDoc As New DataTable
        Dim dtTalaoDocAux As New DataTable
        Dim I As Integer = 0
        Dim Imagem As String = ""
        Try

            Sql = "SELECT 'Sinal' SerieID, DocDet.ProductCode, DocDet.Descricao, DocDet.TamID, DocDet.Valor AS PrecoEtiqueta, DocDet.Valor AS PrecoVenda, DocDet.Unidade AS UnitOfMeasure, DocDet.ModeloID AS MODELO, DocDet.CorID AS COR, DocDet.IvaID, DocDet.VlrIVA, DocDet.Qtd, DocDet.Comissao, DocDet.TxIva FROM Serie RIGHT OUTER JOIN DocDet ON Serie.SerieID = DocDet.SerieID WHERE DocDet.EstadoLn <> 'D' and (IdDocCab = '" & DocCab & "')"
            db.GetData(Sql, dtTalaoDocAux)

            If dtTalaoDocAux.Rows.Count = 0 Then
                MsgBox("Documento j� devolvido!")
                CancelarVenda()
                Exit Sub
            End If

            If dtTalaoDocAux.Rows(0)("ProductCode") <> "99" Then
                'Sql = "SELECT DocDet.SerieID, DocDet.ProductCode, DocDet.Descricao, DocDet.TamID, Serie.PrecoEtiqueta, DocDet.Valor AS PrecoVenda, DocDet.Unidade AS UnitOfMeasure, DocDet.ModeloID AS MODELO, DocDet.CorID AS COR FROM Serie INNER JOIN DocDet ON Serie.SerieID = DocDet.SerieID WHERE (Serie.EstadoID IN ('V', 'R')) AND (DocDet.EstadoLn <> 'D') AND (DocDet.IdDocCab = '" & DocCab & "')"
                'Sql = "SELECT DocDet.SerieID, DocDet.ProductCode, DocDet.Descricao, DocDet.TamID, Serie.PrecoEtiqueta, DocDet.Valor AS PrecoVenda, DocDet.Unidade AS UnitOfMeasure, DocDet.ModeloID AS MODELO, DocDet.CorID AS COR, DocDet.IvaID, DocDet.VlrIVA, DocDet.Qtd, DocDet.Comissao, DocDet.TxIva FROM Serie INNER JOIN DocDet ON Serie.SerieID = DocDet.SerieID WHERE (Serie.EstadoID IN ('V', 'R')) AND (DocDet.EstadoLn <> 'D') AND (DocDet.IdDocCab = '" & DocCab & "')"

                'Sql = "SELECT DocDet.SerieID, DocDet.ProductCode, DocDet.Descricao, DocDet.TamID, Serie.PrecoEtiqueta, DocDet.Valor AS PrecoVenda, DocDet.Unidade AS UnitOfMeasure, DocDet.ModeloID AS MODELO, DocDet.CorID AS COR, DocDet.IvaID, 
                '    DocDet.VlrIVA, DocDet.Qtd, DocDet.Comissao, DocDet.TxIva
                '    FROM Serie INNER JOIN
                '    DocDet ON Serie.SerieID = DocDet.SerieID
                '    WHERE  (Serie.EstadoID IN ('V', 'R')) 
                '    AND (DocDet.EstadoLn <> 'D') 
                '    AND (DocDet.IdDocCab = '" & DocCab & "') 
                '    --AND (DocDet.IdDocDet = '" & sIdDocDetAux & "') 
                '    AND (DocDet.DevolucaoAutorizada = '1' or DocCab.DataDoc >= '" & Now.AddDays(-60).ToString("yyyy-MM-dd") & "')"



                Sql = "SELECT DocDet.SerieID, DocDet.ProductCode, DocDet.Descricao, DocDet.TamID, Serie.PrecoEtiqueta, DocDet.Valor AS PrecoVenda, DocDet.Unidade AS UnitOfMeasure, DocDet.ModeloID AS MODELO, DocDet.CorID AS COR, DocDet.IvaID, 
                    DocDet.VlrIVA, DocDet.Qtd, DocDet.Comissao, DocDet.TxIva
                    FROM     Serie INNER JOIN
                    DocDet ON Serie.SerieID = DocDet.SerieID INNER JOIN
                    DocCab ON DocDet.IdDocCab = DocCab.IdDocCab
                    WHERE  (Serie.EstadoID IN ('V', 'R')) 
                    AND (DocDet.EstadoLn <> 'D') 
                    AND (DocDet.IdDocCab = '" & DocCab & "') 
                    AND (DocDet.IdDocDet = '" & sIdDocDetAux & "')
                    AND (DocDet.DevolucaoAutorizada = '1' OR DocCab.DataDoc >= '" & Now.AddDays(-iDiasDevolver).ToString("yyyy-MM-dd") & "')"




                db.GetData(Sql, dtTalaoDoc)
            Else
                sDevAdiantamento = True
                dtTalaoDoc = dtTalaoDocAux
            End If



            For Each r As DataRow In dtTalaoDoc.Rows

                dgvVendas.Rows.Add(r("SerieID"), r("ProductCode"), r("TamID"), r("Descricao"), r("PrecoEtiqueta"), r("PrecoEtiqueta") - r("PrecoVenda"), 1, r("PrecoVenda"), r("UnitOfMeasure"), r("Modelo"), r("Cor"), r("IvaID"), r("Comissao"), r("TxIva"))
                Imagem = r("Modelo") & r("Cor")
                I += 1

            Next

            If I = 0 Then
                MsgBox("Devolu��o n�o permitida!")
                CancelarVenda()
            Else
                Foto.CarregarFotoModeloCor(Me.PictureBox, Imagem) 'Carregar IMAGEM
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": CarregarDevolucao")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": CarregarDevolucao")
        Finally
            dtTalaoDoc = Nothing
            dtTalaoDocAux = Nothing
            db = Nothing

        End Try



    End Sub


    Private Function ValidarDevolucao() As Boolean

        Try

            If MsgBox("Validar devolu��o de : " & dgvVendas.Rows.Count & " artigo(s) ?", MsgBoxStyle.YesNo, "Confirmar devolu��o!!") = MsgBoxResult.Yes Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": ValidarDevolucao")
        End Try


    End Function

    Private Sub btConsignacao_Click(sender As Object, e As EventArgs) Handles btConsignacao.Click


        Dim db As New ClsSqlBDados

        btConsignacao.Enabled = False
        xTipoDoc = "VC"
        dgvVendas.AllowUserToAddRows = False
        xTipoPagamento = "VD"
        Dim sEstado As String = ""


        Try

            Dim inLinhas As Integer = 0
            For Each row As DataGridViewRow In dgvVendas.Rows
                If Len(row.Cells.Item("Etiqueta").Value) > 0 Then
                    inLinhas += 1
                End If
            Next
            If inLinhas = 0 Then Exit Sub


            If cbDevolver.Checked Then
                'testar se o tal�o est� em estado V ou R (j� faturado ou n�o)
                For Each row As DataGridViewRow In dgvVendas.Rows

                    Sql = "SELECT EstadoID FROM Serie WHERE SerieID = '" & Me.dgvVendas("Etiqueta", row.Index).Value & "'"
                    sEstado = db.GetDataValue(Sql)
                    If sEstado = "V" Then
                        'S� VAI ALTERAR O ESTADO DO TAL�O DE V PARA S PORQUE ESTA VENDA AINDA N�O FOI FATURADA � LOJA DE CONSIGNA��O 
                        'S� EST� A PERMITIR DEVOLVER UM TAL�O DE CADA VEZ
                        Sql = "UPDATE Serie SET PVndReal = 0, DtSaida = GETDATE() , OperadorID = '" + xUtilizador + "', EstadoID='S' , Comissao = '0' WHERE SerieID = '" + Me.dgvVendas("Etiqueta", row.Index).Value + "';"
                        db.ExecuteData(Sql)
                    ElseIf sEstado = "R" Then
                        'VAI EMITIR UMA NOTA DE CR�DITO � LOJA DE CONSIGNA��O E UMA NOVA FATURA DE CONSIGNA��O
                        'PARA J� N�O VAI DEIXAR PORQUE ESTE PROCEDIMENTO TEM QUE SER FEITO NO ARMAZEM....
                        MsgBox("N�o � possivel devolver porque o artigo j� foi faturado, por favor contacte o armazem!")
                        Exit Sub
                        'GravarDocumento("NC")
                        'dgvVendas.Rows.Clear()
                        'Me.cbVendedor.SelectedValue = sVendedor
                    End If
                Next

            Else
                GravarVenda(xTipoDoc)
            End If




            'For Each row As DataGridViewRow In dgvVendas.Rows

            '    Dim xSerieID As String = Me.dgvVendas("Etiqueta", row.Index).Value
            '    Dim xValor As Double = Me.dgvVendas("Valor", row.Index).Value
            '    Dim dComissao As Double = Me.dgvVendas("Comissao", row.Index).Value

            '    If cbDevolver.Checked = True Then

            '        'REP�R O PRE�O DE VENDA DA TABELA
            '        Dim xPrecoVenda As Double = DevolvePv(xArmz, xSerieID)

            '        'validar se o tal�o est� em estado v
            '        Sql = "UPDATE Serie SET PVndReal = 0, DtSaida = GETDATE() , Vendedor = '', DocNr = '', OperadorID = '" + xUtilizador + "', EstadoID='S' , PrecoVenda = '" & xPrecoVenda & "', Comissao = '0' WHERE SerieID = '" + xSerieID + "'"
            '        db.ExecuteData(Sql)


            '        If MsgBox("Reimprimir Etiqueta " & xSerieID & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '            ListaTaloes(xSerieID, "RptTaloesReimpressao", True)
            '        End If

            '    Else

            '        Sql = "UPDATE Serie SET EstadoID = 'V', PVndReal = '" & xValor & "', Comissao= '" & dComissao & "', DocNr='', Vendedor = '" & cbVendedor.SelectedValue.ToString & "', OperadorID = '" & xUtilizador & "', DtSaida = Getdate() WHERE SerieID = '" & xSerieID & "'"
            '        db.ExecuteData(Sql)

            '    End If


            'Next





            '*************************************************************************************
            ''ALTERAR O PROCEDIMENTO DE DEVOLU��O....
            'If cbDevolver.Checked Then
            '    If ValidarDevolucao() Then
            '        GravarVenda("NC")
            '        Me.cbVendedor.SelectedValue = sVendedor
            '    End If
            'Else
            '    GravarVenda(xTipoDoc)
            'End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": btConsignacao_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": btConsignacao_Click")
        Finally

            CancelarVenda()
            btConsignacao.Enabled = True
            sDevAdiantamento = False

        End Try


    End Sub


End Class
