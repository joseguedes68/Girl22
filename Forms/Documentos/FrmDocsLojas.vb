
Imports System.Data.SqlClient


Public Class FrmDocsLojas


    Dim dtCab As New DataTable
    Dim dtDestinos As New DataTable
    Dim xDocNr As String
    Dim Fechar As Boolean = False
    Dim LinhaActual As Integer
    Dim bSair As Boolean = False



    Private Sub frmDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim DB As New ClsSqlBDados


        Me.TaxIVATableAdapter.Fill(Me.GirlDataSet.TaxIVA)

        Try

            If xTipoDoc = "VS" Then btPrintDoc.Visible = False
            If xTipoDoc = "FS" Then btPrintDoc.Visible = True
            If xTipoDoc = "NC" Then btPrintDoc.Visible = True

            If xTipoDoc = "VS" Then btFechar.Text = "Cancelar"
            If xTipoDoc = "VS" Then Me.DocDetDataGridView.AllowUserToDeleteRows = True
            If xTipoDoc = "FS" Then Me.DocDetDataGridView.AllowUserToDeleteRows = False
            If xTipoDoc = "NC" Then Me.DocDetDataGridView.AllowUserToDeleteRows = False

            If xTipoDoc = "FS" Then Me.dgvDocCab.AllowUserToDeleteRows = False
            If xTipoDoc = "NC" Then Me.dgvDocCab.AllowUserToDeleteRows = False





            'Me.DocDetDataGridView.AllowUserToDeleteRows = False
            'If xTipoDoc = "VD" Then gbCabDocs.Visible = False
            If bRecuperaVenda = True Then
                btPrintDoc.Visible = False
            Else
                btPrintDoc.Visible = True
            End If

            CarregarDestinos()

            lbTipoDoc.Text = xTipoDoc

            Sql = "SELECT DISTINCT TIPODOCDESC FROM TIPODOC WHERE TIPODOCID='" & xTipoDoc & "'"
            lbTipoDoc.Text = DB.GetDataValue(Sql)

            ActualizaCabeçalho()

            'Me.CbDestino.DataBindings.Add("Text", dtCab, "CodID")
            Me.txtData.DataBindings.Add("Text", dtCab, "DataDoc")
            Me.tbObs.DataBindings.Add("Text", dtCab, "Obs")

            'WindowState = FormWindowState.Maximized

            Me.DocDetDataGridView.RowHeadersWidth = Me.DocDetDataGridView.ColumnHeadersHeight
            Me.dgvDocCab.RowHeadersWidth = Me.dgvDocCab.ColumnHeadersHeight

            'esta instrução deu a volta a um problema estranho : ao abrir o form não preenchia e detalhe, tinha que fazer refrech!!!!
            If dtCab.Rows.Count = 1 Then
                dgvDocCab.Rows(0).Selected = True
            End If
            If dtCab.Rows.Count > 1 Then
                dgvDocCab.Rows(1).Selected = True
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmDocumentos_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmDocumentos_Load")
        Finally
            If Not DB Is Nothing Then DB.Dispose()
            DB = Nothing
        End Try

    End Sub

    Private Sub frmDocumentos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If bSair = False Then e.Cancel = True

        If dtCab.GetChanges Is Nothing And GirlDataSet.DocDet.GetChanges Is Nothing Then

        Else
            If MsgBox("Pretende Gravar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Fechar = True
                If GravarDocumento() = False Then
                    e.Cancel = True
                End If
            Else
                'e.Cancel = True
                dtCab.RejectChanges()
                GirlDataSet.DocDet.RejectChanges()
            End If

        End If



    End Sub

    'EVENTOS NA DGVDOCCAB

    Private Sub dgvDocCab_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDocCab.SelectionChanged
        Try

            If GirlDataSet.DocDet.GetChanges Is Nothing Then
                ActualizaDetalhe()
            Else

                If MsgBox("Pretende Gravar as alterações?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    If GravarDocumento() = False Then
                        MsgBox("Erro na Gravação!")
                    End If
                Else
                    dtCab.RejectChanges()
                    GirlDataSet.DocDet.RejectChanges()
                    MsgBox("Gravação Cancelada!")
                End If

            End If


            TotaisFormasPagamento(C1tbDH.Value, C1tbMB.Value)


        Catch ex As Exception
            ErroVB(ex.Message, "dgvDocCab_SelectionChanged")
        End Try
    End Sub

    'EVENTOS NA DOCDETDATAGRIDVIEW

    Private Sub DocDetDataGridView_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DocDetDataGridView.CellBeginEdit
        e.Cancel = True
    End Sub

    Private Sub DocDetDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DocDetDataGridView.CellEndEdit
        '    'ERA O EVENTO AfterColEdit

        Try

            If Me.DocDetDataGridView("EmpresaID", Me.DocDetDataGridView.CurrentCell.RowIndex).Value Is DBNull.Value Then
                xDocNr = Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value
                Me.DocDetDataGridView("EmpresaID", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = xEmp
                Me.DocDetDataGridView("ArmazemID", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = xArmz
                Me.DocDetDataGridView("TipoDocID", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = xTipoDoc
                Me.DocDetDataGridView("DocNr", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = xDocNr
                Me.DocDetDataGridView("OperadorID", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = xUtilizador
                If GirlDataSet.DocDet.Rows.Count > 0 Then
                    Me.DocDetDataGridView("DocLnNr", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = GirlDataSet.DocDet.Compute("MAX(DocLnNr)+1", "")
                Else
                    Me.DocDetDataGridView("DocLnNr", Me.DocDetDataGridView.CurrentCell.RowIndex).Value = 1
                End If

            End If

            ActualizarTotal()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DocDetDataGridView_CellEndEdit")
        Catch ex As Exception
            ErroVB(ex.Message, "DocDetDataGridView_CellEndEdit")
        End Try


    End Sub

    Private Sub DocDetDataGridView_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        'ERA O EVENTO AfterDelete
        ActualizarTotal()
    End Sub

    'EVENTOS NA COMBOBOX CBDESTINO

    Private Sub CbDestino_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDestino.Click

        If dtCab.GetChanges Is Nothing And GirlDataSet.DocDet.GetChanges Is Nothing Then
            Exit Sub
        Else
            If MsgBox("Pretende Gravar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Fechar = True
                If GravarDocumento() = False Then
                    MsgBox("Erro na Gravação!!")
                    Exit Sub
                End If
            Else
                dtCab.RejectChanges()
                GirlDataSet.DocDet.RejectChanges()
            End If

        End If

    End Sub

    'EVENTOS DIVERSOS NO FORM

    Private Sub tbDesconto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Me.DocDetDataGridView.Focus()
        End If
    End Sub

    Private Sub tbDesconto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizarTotal()
    End Sub

    Private Sub txtTotGuia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Me.DocDetDataGridView.Focus()
        End If
    End Sub

    Private Sub txtTotGuia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotDoc.LostFocus
        ActualizarTotal()
    End Sub

    Private Sub btPrintDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrintDoc.Click

        'Dim NrLinha As Integer = Me.dgvDocCab.CurrentCell.RowIndex
        'GravarDocumento()
        'If xTipoDoc = "TT" Then
        '    With frmRptVendasTT
        '        frmVndSerie.xNovaTT = Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value
        '        .ShowDialog(Me)
        '    End With
        'Else
        '    ActualizarTotalLn()
        '    ListaDocEmpresa(Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value, xTipoDoc)
        'End If

        ListaDocPOS(Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value, Me.dgvDocCab("TipoDocID", Me.dgvDocCab.CurrentCell.RowIndex).Value, "Original 2ªVia", True)
        'ListaDocPOS(Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value, Me.dgvDocCab("TipoDocID", Me.dgvDocCab.CurrentCell.RowIndex).Value, "Duplicado 2ª Via", True)





    End Sub

    Private Sub btNovoDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNovoDoc.Click
        'HELDER: POR BOTÃO NOVO A CHAMAR O FROM frmNovoCliente
        Dim db As New ClsSqlBDados

        Try

            If dtCab.GetChanges Is Nothing And GirlDataSet.DocDet.GetChanges Is Nothing Then

            Else
                If MsgBox("Pretende Gravar as alterações?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If GravarDocumento() = False Then
                        MsgBox("Erro na Gravação!")
                    End If
                Else
                    dtCab.RejectChanges()
                    GirlDataSet.DocDet.RejectChanges()
                    MsgBox("Gravação Cancelada!")
                End If
            End If

            Dim xNovaGt As String = PesquisaMaxNumDoc(xTipoDoc)
            Dim xData As String = Format(CType(Now(), Date), "yyyy-MM-dd H:mm:ss")
            Dim xDestino As String = Microsoft.VisualBasic.Right(Me.CbDestino.SelectedValue, 4)

            Dim xLocalCarga As String = "N/Instalações"
            Dim xLocDesc As String = "Morada do Cliente"

            If xArmz <> "0000" Then
                Sql = "SELECT TercID FROM ARMAZENS where ArmazemID='" & xArmz & "'"
                Dim xLocalOrigem As String = db.GetDataValue(Sql)
                Sql = "SELECT Morada + '  ' + CodPostal + '-' + Localidade from terceiros where TercID='" & xLocalOrigem & "'"
                xLocalCarga = db.GetDataValue(Sql)
            End If

            Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, LocalCarga, HoraCarga, LocDesc, Obs, TipoTerc, EstadoDoc, OperadorID) " & _
                "VALUES('" & xEmp & "','" & xArmz & "','" & xTipoDoc & "','" & xNovaGt & "','" & xDestino & "','" & xData & "','" & xLocalCarga & "', '', '" & xLocDesc & "','','L','C','" & xUtilizador & "')"
            db.ExecuteData(Sql)

            ActualizaCabeçalho()



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btNovoDoc_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btNovoDoc_Click")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            cn.Close()
            Cmd.Dispose()
        End Try

    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        bSair = True
        bRecuperaVenda = False
        Close()
    End Sub

    Private Sub btGravarDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGravarDoc.Click

        'Dim NrLinha As Integer = Me.dgvDocCab.CurrentCell.RowIndex
        GravarDocumento()

    End Sub

    Private Sub btConsignacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dtCab.GetChanges Is Nothing And GirlDataSet.DocDet.GetChanges Is Nothing Then
            GravarConsignacao()
        Else
            If MsgBox("Pretende Gravar as alterações?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If GravarDocumento() = False Then
                    MsgBox("Erro na Gravação! Consignação Cancelada!")
                Else
                    GravarConsignacao()
                End If
            Else
                dtCab.RejectChanges()
                GirlDataSet.DocDet.RejectChanges()
                MsgBox("Gravação e Consignação Cancelada!")
            End If
        End If
    End Sub

    Private Sub btFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dtCab.GetChanges Is Nothing And GirlDataSet.DocDet.GetChanges Is Nothing Then
            GravarFactura()
        Else
            If MsgBox("Pretende Gravar as alterações?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If GravarDocumento() = False Then
                    MsgBox("Erro na Gravação! Factura Cancelada!")
                Else
                    GravarFactura()
                End If
            Else
                dtCab.RejectChanges()
                GirlDataSet.DocDet.RejectChanges()
                MsgBox("Gravação e Factura Cancelada!")
            End If
        End If
    End Sub



    'FUNÇÕES

    Private Function GravarDocumento() As Boolean

        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim db As New ClsSqlBDados
        Dim xTerc As String = ""
        Try


            'If DevolveGrupoAcesso() <> "ADMIN" Then
            '    GravarEvento("TENTATIVA DE ALTERAÇÃO DA FORMA DE PAGAMENTO", iUtilizadorID, Now, "EMAIL")
            '    MsgBox("Não possível fazer alterações! Contacte o Armazém")
            '    'dtCab.RejectChanges()
            '    'GirlDataSet.DocDet.RejectChanges()
            '    Return False
            'End If



            'If dgvDocCab.Rows.Count > 0 Then
            '    xTerc = Me.dgvDocCab("TercID", Me.dgvDocCab.CurrentCell.RowIndex).Value
            'End If




            'xTerc = Microsoft.VisualBasic.Right(Me.CbDestino.SelectedValue, 10)
            dt = dtCab.GetChanges(DataRowState.Deleted)
            If Not dt Is Nothing Then
                For Each r As DataRow In dt.Rows
                    'Sql = "DELETE FROM DocCab WHERE EmpresaID='" & xEmp & "' AND ArmazemId='" & xArmz & "' AND TipoDocID='" & xTipoDoc & "' AND DocNr = '" & r("DocNr", DataRowVersion.Original).ToString & "'"
                    'db.ExecuteData(Sql)
                Next
                dtCab.AcceptChanges()
                If Not Fechar Then
                    ActualizaCabeçalho()
                End If
                Return True
            End If


            dt1 = dtCab.GetChanges(DataRowState.Modified)
            If Not dt1 Is Nothing Then
                Dim xFP As String
                Dim xIdDocCab As String
                For Each r As DataRow In dt1.Rows
                    xFP = r("FP", DataRowVersion.Current).ToString
                    xIdDocCab = r("IdDocCab", DataRowVersion.Current).ToString
                    If xFP = "MB" Then
                        Sql = "UPDATE DocCab SET  FormaPagtoID = 6 WHERE IdDocCab = '" & xIdDocCab & "' AND EstadoDoc <> 'F'"
                        db.ExecuteData(Sql)
                    ElseIf xFP = "DH" Then
                        Sql = "UPDATE DocCab SET  FormaPagtoID = 1 WHERE IdDocCab = '" & xIdDocCab & "' AND EstadoDoc <> 'F'"
                        db.ExecuteData(Sql)
                    End If
                Next
                dtCab.AcceptChanges()
                If Not Fechar Then
                    ActualizaCabeçalho()
                End If
                Return True
            End If



            'If Me.dgvDocCab.Rows.Count = 0 Then
            '    Return True
            'Else
            '    If Len(xTerc) > 0 Then

            '        xDocNr = Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value

            '        'Dim xData As Date = txtData.Text
            '        'DataDoc='" & Format(xData, "yyyy-MM-dd H:mm:ss") & "',

            '        Sql = "UPDATE DocCab SET TercID ='" & xTerc & "', LocalCarga='', HoraCarga='',  LocDesc='', Obs = '" & tbObs.Text & "',  DescontoDoc = 0, OperadorID = '" & xUtilizador & "', DtRegisto = getdate() " & _
            '                "WHERE EmpresaID='" & xEmp & "' AND ArmazemId='" & xArmz & "' AND TipoDocID='" & xTipoDoc & "' AND DocNr = '" & xDocNr & "'"
            '        Cmd = New SqlCommand(Sql, cn)
            '        If cn.State = ConnectionState.Closed Then cn.Open()
            '        Cmd.ExecuteNonQuery()

            '        DocDetTableAdapter.Update(GirlDataSet.DocDet)
            '        dtCab.AcceptChanges()
            '        GirlDataSet.DocDet.AcceptChanges()
            '        Return True
            '    Else
            '        dtCab.RejectChanges()
            '        GirlDataSet.DocDet.RejectChanges()
            '        Return False
            '    End If
            'End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, " GravarDocumento")
        Catch ex As Exception
            ErroVB(ex.Message, " GravarDocumento")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            If Not dt1 Is Nothing Then dt1.Dispose()
            dt1 = Nothing
        End Try
    End Function

    Private Sub ActualizaCabeçalho()

        Dim db As New ClsSqlBDados

        Try

            dtCab.Clear()

            pDestinos.Enabled = True
            btNovoDoc.Visible = False

            'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(CAST(CAST(DocCab.ArmazemID AS INT) AS CHAR)) + '/' + DocCab.DocNr AS SerieNrDoc, DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + ClientesLoja.Nome AS CodID, ClientesLoja.Nome AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc FROM DocCab INNER JOIN ClientesLoja ON DocCab.TercID = ClientesLoja.ClienteLojaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND DocCab.TipoDocID ='" & xTipoDoc & "' ORDER BY DocCab.DocNr DESC"
            'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, RTRIM(CAST(CAST(DocCab.ArmazemID AS INT) AS CHAR)) + '/' + DocCab.DocNr AS SerieNrDoc, DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + ClientesLoja.Nome AS CodID, ClientesLoja.Nome AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, FormaPagamento.FPDescrAbrev AS FP, DocCab.FormaPagtoID, DocCab.IDDocCab FROM DocCab INNER JOIN ClientesLoja ON DocCab.TercID = ClientesLoja.ClienteLojaID LEFT OUTER JOIN FormaPagamento ON DocCab.FormaPagtoID = FormaPagamento.FormaPagtoID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipoDoc & "') ORDER BY DocCab.DocNr DESC"
            Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, TipoDocID+' '+LEFT(DocNr,2)+right(ArmazemID,2)+'/'+right(DocNr,5) AS SerieNrDoc, DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + ClientesLoja.Nome AS CodID, ClientesLoja.Nome AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, FormaPagamento.FPDescrAbrev AS FP, DocCab.FormaPagtoID, DocCab.IDDocCab FROM DocCab INNER JOIN ClientesLoja ON DocCab.TercID = ClientesLoja.ClienteLojaID LEFT OUTER JOIN FormaPagamento ON DocCab.FormaPagtoID = FormaPagamento.FormaPagtoID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipoDoc & "') ORDER BY DocCab.DocNr DESC"


            db.GetData(Sql, dtCab)


            With Me.dgvDocCab
                .DataSource = dtCab
                .Columns("SerieNrDoc").HeaderText = "Doc"
                .Columns("TercID").HeaderText = "Cod"
                .Columns("DataDoc").HeaderText = "Data"
                .Columns("Destino").HeaderText = "Cliente"
                .Columns("DataDoc").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                .Columns("SerieNrDoc").Width = 90
                .Columns("TercID").Width = 35
                .Columns("Destino").Width = 135
                .Columns("DataDoc").Width = 75
                .Columns("E").Width = 20
                .Columns("FP").Width = 30

                .Columns("EmpresaID").Visible = False
                .Columns("ArmazemID").Visible = False
                .Columns("TipoDocID").Visible = False
                .Columns("DocNr").Visible = False
                .Columns("LocalCarga").Visible = False
                .Columns("HoraCarga").Visible = False
                .Columns("LocDesc").Visible = False
                .Columns("HoraDesc").Visible = False
                .Columns("Obs").Visible = False
                .Columns("DescontoDoc").Visible = False
                .Columns("CodId").Visible = False
                .Columns("FormaPagtoID").Visible = False
                .Columns("IDDocCab").Visible = False

                .Refresh()
            End With

            DocDetDataGridView.Enabled = False
            btPrintDoc.Enabled = False
            btGravarDoc.Enabled = False

            If dtCab.Rows.Count > 0 Then
                DocDetDataGridView.Enabled = True
                btPrintDoc.Enabled = True
                btGravarDoc.Enabled = True
                ActualizaDetalhe()
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaCabeçalho")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaCabeçalho")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub ActualizaDetalhe()
        Dim db As New ClsSqlBDados
        Try
            GirlDataSet.DocDet.Clear()

            If Me.dgvDocCab.CurrentCellAddress.X >= 0 Then


                If Not Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value Is DBNull.Value Then
                    xDocNr = Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value

                    'CARREGAR TABELA AUXILIAR PARA RECUPERAR VENDAS SUSPENSAS
                    Sql = "SELECT SerieID, Qtd FROM DocDet WHERE (EmpresaID = '" & xEmp & "') AND (ArmazemID = '" & xArmz & "') AND (TipoDocID = 'VS') AND (DocNr = N'" & xDocNr & "')"
                    dtRecVendaSuspensa.Clear()
                    db.GetData(Sql, dtRecVendaSuspensa)

                    If xTipoDoc = "GT" And xAplicacao = "BACKOFFICE" Then
                        Sql = "SELECT EstadoDoc FROM DocCab WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + xArmz + "' AND TipoDocID = 'GT' AND DocNr ='" + xDocNr + "'"
                    End If

                    Me.DocDetTableAdapter.FillByNrDoc(GirlDataSet.DocDet, xEmp, xArmz, xTipoDoc, xDocNr)
                    ActualizarTotalLn()
                    ActualizarTotal()
                End If
            End If

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

            Dim xQtd As Double = 0
            Dim xValor As Double = 0
            Dim xIvaValor As Double = 0
            Dim xTxIva As Double = 0
            Dim xValorLinha As Double = 0




            Dim I As Integer = 0


            I = 0


            For I = 0 To Me.DocDetDataGridView.Rows.Count - 1


                If Me.DocDetDataGridView("Qtd", I).Value Is DBNull.Value Then
                    Me.DocDetDataGridView("Qtd", I).Value = 0
                End If
                If Me.DocDetDataGridView("Valor", I).Value Is DBNull.Value Then
                    Me.DocDetDataGridView("Valor", I).Value = 0
                End If
                If Me.DocDetDataGridView("VlrDescLn", I).Value Is DBNull.Value Then
                    Me.DocDetDataGridView("VlrDescLn", I).Value = 0
                End If



                xQtd = xQtd + Me.DocDetDataGridView("Qtd", I).Value
                xValor = xValor + Me.DocDetDataGridView("Qtd", I).Value * (Me.DocDetDataGridView("Valor", I).Value - Me.DocDetDataGridView("VlrDescLn", I).Value)
                xValorLinha = Me.DocDetDataGridView("Qtd", I).Value * (Me.DocDetDataGridView("Valor", I).Value - Me.DocDetDataGridView("VlrDescLn", I).Value)




                If Me.DocDetDataGridView("IvaID", I).Value Is DBNull.Value Then
                    Me.DocDetDataGridView("IvaID", I).Value = xIvaID
                End If

                If Me.GirlDataSet.TaxIVA.Rows.Count > 0 Then
                    xTxIva = Me.GirlDataSet.TaxIVA.Compute("Sum(TxIva)", "IvaID='" + Me.DocDetDataGridView("IvaID", I).Value + "'")
                End If

                xIvaValor = xIvaValor + (xValorLinha - xValorLinha / (1 + xTxIva))


                'Me.DocDetDataGridView("TotalLn", I).Value = xValorLinha * xQtd


            Next

            txtTotIva.Text = Format(xIvaValor, "Currency")
            txtTotDoc.Text = IIf(txtTotDoc.Text = "", 0, txtTotDoc.Text)
            txtTotDoc.Text = Format(xValor, "Currency")

        Catch ex As Exception
            ErroVB(ex.Message, "ActualizarTotal")
        End Try

    End Sub

    Private Sub ActualizarTotalLn()

        Dim I As Integer = 0


        I = 0

        For I = 0 To Me.DocDetDataGridView.Rows.Count - 1
            Me.DocDetDataGridView("TLinha", I).Value = Me.DocDetDataGridView("Qtd", I).Value.ToString * (Me.DocDetDataGridView("Valor", I).Value.ToString - Me.DocDetDataGridView("VlrDescLn", I).Value.ToString)
        Next


    End Sub

    Private Sub GravarFactura()

        Dim db As New ClsSqlBDados
        Dim maxDocnr As String = ""
        Try
            'Sql = "SELECT dbo.MaxNumDoc('" + xEmp + "','" + xArmz + "','FS')"
            'maxDocnr = db.GetDataValue(Sql)

            maxDocnr = PesquisaMaxNumDoc("FS")


            xDocNr = Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value

            Sql = "INSERT into DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, DescontoDoc, EstadoDoc, TipoTerc, OperadorID) " & _
                 "SELECT EmpresaID, ArmazemID, 'FS' TipoDocID, '" + maxDocnr + "' DocNr, TercID, dbo.data(getdate()) DataDoc, TipoDocID TipoDocOrig, DocNr DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, DescontoDoc, EstadoDoc, TipoTerc, '" + xUtilizador + "' " & _
                 "FROM DocCab " & _
                 "WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + xArmz + "' AND TipoDocID = '" & xTipoDoc & "' AND DocNr ='" + xDocNr + "'"
            db.ExecuteData(Sql)

            'TODO: SERÁ QUE ISTO É NECESSÁRIO??
            Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, Qtd, Obs, EstadoLn, OperadorID) " & _
                 "SELECT EmpresaID, ArmazemID, 'FS' TipoDocID, '" + maxDocnr + "' DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, Qtd, Obs, EstadoLn, '" + xUtilizador + "' " & _
                 "FROM DocDet " & _
                 "WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + xArmz + "' AND TipoDocID = '" & xTipoDoc & "' AND DocNr ='" + xDocNr + "'"
            db.ExecuteData(Sql)


            Sql = "UPDATE DocCab SET EstadoDoc = 'F' WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + xArmz + "' AND TipoDocID = '" & xTipoDoc & "' AND DocNr ='" + xDocNr + "'"
            db.ExecuteData(Sql)
            ActualizaCabeçalho()


        Catch ex As Exception
            ErroVB(ex.Message, "GravarFactura")
        Finally

            If db IsNot Nothing Then db.Dispose()
        End Try
    End Sub

    Private Sub GravarConsignacao()

        Dim db As New ClsSqlBDados
        Dim maxDocnr As String = ""
        Try

            Sql = "SELECT dbo.MaxNumDoc('" + xEmp + "','" + xArmz + "','FC')"
            maxDocnr = db.GetDataValue(Sql)
            xDocNr = Me.dgvDocCab("DocNr", Me.dgvDocCab.CurrentCell.RowIndex).Value

            Sql = "INSERT into DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, DescontoDoc, EstadoDoc, TipoTerc, OperadorID) " & _
                 "SELECT EmpresaID, ArmazemID, 'FC' TipoDocID, '" + maxDocnr + "' DocNr, TercID, dbo.data(getdate()) DataDoc, TipoDocID TipoDocOrig, DocNr DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, DescontoDoc, EstadoDoc, TipoTerc, '" + xUtilizador + "' " & _
                 "FROM DocCab " & _
                 "WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + xArmz + "' AND TipoDocID = '" & xTipoDoc & "' AND DocNr ='" + xDocNr + "'"
            db.ExecuteData(Sql)


            'TODO: SERÁ QUE ISTO É NECESSÁRIO??
            Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, Qtd, Obs, EstadoLn, OperadorID) " & _
                 "SELECT EmpresaID, ArmazemID, 'FC' TipoDocID, '" + maxDocnr + "' DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, Qtd, Obs, EstadoLn, '" + xUtilizador + "' " & _
                 "FROM DocDet " & _
                 "WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + xArmz + "' AND TipoDocID = '" & xTipoDoc & "' AND DocNr ='" + xDocNr + "'"
            db.ExecuteData(Sql)


            Sql = "UPDATE DocCab SET EstadoDoc = 'F' WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + xArmz + "' AND TipoDocID = '" & xTipoDoc & "' AND DocNr ='" + xDocNr + "'"
            db.ExecuteData(Sql)
            ActualizaCabeçalho()


        Catch ex As Exception
            ErroVB(ex.Message, "GravarConsignacao")
        Finally

            If db IsNot Nothing Then db.Dispose()
        End Try
    End Sub

    Private Sub CarregarDestinos()

        Dim db As New ClsSqlBDados

        Try

            'dtDestinos.Clear()

            'Sql = "SELECT ClienteLojaID TercID  , Nome FROM ClientesLoja order by Nome"

            'db.GetData(Sql, dtDestinos)

            'Me.CbDestino.DataSource = dtDestinos
            'Me.CbDestino.DisplayMember = "Nome"
            'Me.CbDestino.ValueMember = "TercID"


            'Dim registo As DataRow
            'registo = dtDestinos.NewRow()

            'registo("TercID") = 11000

            'registo("Nome") = "Selecione Cliente"

            'dtDestinos.Rows.Add(registo)


            'Me.CbDestino.SelectedValue = 11000

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarDestinos")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarDestinos")

        Finally

            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim I As Integer = 1

        Try
            If keyData = Keys.Enter Then
                If Me.DocDetDataGridView.Columns(DocDetDataGridView.CurrentCell.ColumnIndex).Name <> "Unidade" Then
                    If TypeOf Me.ActiveControl Is DataGridViewTextBoxEditingControl Or TypeOf Me.ActiveControl Is DataGridViewComboBoxEditingControl Then
                        If DocDetDataGridView.CurrentCell.ColumnIndex < DocDetDataGridView.ColumnCount - 1 Then
                            Do While DocDetDataGridView.Rows(DocDetDataGridView.CurrentCell.RowIndex).Cells(DocDetDataGridView.CurrentCell.ColumnIndex + I).Visible = False
                                I = I + 1
                            Loop
                            DocDetDataGridView.CurrentCell = DocDetDataGridView.Rows(DocDetDataGridView.CurrentCell.RowIndex).Cells(DocDetDataGridView.CurrentCell.ColumnIndex + I)
                        Else
                            Return MyBase.ProcessCmdKey(msg, keyData)
                        End If
                    End If
                Else
                    DocDetDataGridView.CurrentCell = DocDetDataGridView.Rows(DocDetDataGridView.CurrentCell.RowIndex + 1).Cells("ModeloID")

                End If
                ActualizarTotal()
                Return MyBase.ProcessCmdKey(msg, keyData)

            End If

        Catch ex As Exception

            ErroVB(ex.Message, "ProcessCmdKey")

        Finally



        End Try


    End Function

    Private Sub TotaisFormasPagamento(ByRef dDH As Double, ByRef dMB As Double)

        Dim db As New ClsSqlBDados

        Sql = "SELECT ISNULL(SUM((CASE WHEN DOCDET.TIPODOCID = 'NC' THEN - 1 ELSE 1 END) * DocDet.Qtd * (DocDet.Valor - DocDet.VlrDescLn)),0) AS Valor FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.EstadoDoc = 'C') AND (DocCab.FormaPagtoID = 1) AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipoDoc & "')"
        dDH = db.GetDataValue(Sql)

        Sql = "SELECT ISNULL(SUM((CASE WHEN DOCDET.TIPODOCID = 'NC' THEN - 1 ELSE 1 END) * DocDet.Qtd * (DocDet.Valor - DocDet.VlrDescLn)),0) AS Valor FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.EstadoDoc = 'C') AND (DocCab.FormaPagtoID = 6) AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipoDoc & "')"
        dMB = db.GetDataValue(Sql)

    End Sub




End Class