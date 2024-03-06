

Imports System.Text


Public Class frmDevCliente
    Dim dt As New DataTable
    Dim xPrecoEtiqueta As Boolean
    Dim CarregarFoto As New ClsFotos




    Private Sub frmDevCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.GirlDataSet.DocCabDet.Clear()
        Me.DocCabDetTableAdapter.FillDocCabDet(Me.GirlDataSet.DocCabDet, "%")
        Inicializa()
        cbReport.SelectedItem = "RptTaloes_3x2"

    End Sub

    Private Sub txtSerieID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieID.KeyPress

        Dim db As New ClsSqlBDados
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If Me.txtSerieID.Text.Length > 0 Then
                    'TODO: FILTRAR OS TALÕES QUE NÃO ESTÃO NAS RECOLHAS (OU SEJAM FORAM VENDIDOS EM FS)
                    'Sql = "SELECT ArmazemID, ModeloID, CorID, TamID, PVndReal, EstadoID, DtSaida FROM Serie WHERE SerieID = '" + Me.txtSerieID.Text.ToString + "' AND EstadoID='R' "
                    Sql = "SELECT ArmazemID, ModeloID, CorID, TamID, PVndReal, EstadoID, DtSaida, DocNr FROM Serie WHERE (SerieID = '" + Me.txtSerieID.Text.ToString + "') AND (EstadoID = 'R') AND (NOT (DocNr LIKE N'FS%'))"
                    dt.Clear()
                    db.GetData(Sql, dt)
                    If dt.Rows.Count > 0 Then

                        Sql = "SELECT COUNT(*) FROM RESERVAS WHERE DESPESAS>0 and RESERVASERIEID='" & Me.txtSerieID.Text & "'"
                        If db.GetDataValue(Sql) > 0 Then
                            MsgBox("Foi um pedido especial!")
                        End If

                        'SÓ DÁ O AVISO!!
                        If dt.Rows(0)("DtSaida") < Now().AddDays(-30) Then
                            MsgBox("Talão Vendido à mais de 30 Dias!")
                        End If

                        PreencherDados()

                    Else
                        'O TALÃO NÃO ESTÁ EM R, NÃO EXISTE NA BDADOS, OU FS
                        EnviarEmail("Erro", "TENTATIVA DE DEVOLUÇÃO DO TALÃO :" + Me.txtSerieID.Text.ToString + " NO P2 " + "Data: " + Now)
                        MsgBox("NÃO É POSSIVEL DEVOLVER O TALÃO :" + Me.txtSerieID.Text.ToString + " !", MsgBoxStyle.Information, My.Application.Info.ProductName)
                    End If

                End If

            End If


        Catch ex As Exception
            ErroVB(ex.Message, "txtSerieID_KeyPress")
        Finally
            If db IsNot Nothing Then db.Dispose()
        End Try
    End Sub

    Private Sub PreencherDados()
        Dim db As New ClsSqlBDados
        Dim foto As New ClsFotos
        Try
            'Validar
            If dt.Rows(0)("EstadoID") = "R" Then
                Me.lblCor.Text = dt.Rows(0)("CorID").ToString
                Me.lblModelo.Text = dt.Rows(0)("ModeloID").ToString
                Me.lblPrVenda.Text = Format(CDbl(dt.Rows(0)("PVndReal")), "# ##0.00€")
                Me.lblTamanho.Text = dt.Rows(0)("TamID").ToString
                Me.lbLoja.Text = dt.Rows(0)("ArmazemID").ToString
                foto.CarregarFotoModeloCor(Me.PicFoto, dt.Rows(0)("ModeloID").ToString + dt.Rows(0)("CorID").ToString)
                Me.PicFoto.Visible = True
            Else
                MsgBox("Talão não está Recolhido!", MsgBoxStyle.Information, My.Application.Info.ProductName)
                Inicializa()
            End If
        Catch ex As Exception
            ErroVB(ex.Message, "PreencherDados")
        Finally
            If db IsNot Nothing Then db.Dispose()
            If foto IsNot Nothing Then foto.Dispose()
        End Try
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click


        Dim db As New ClsSqlBDados
        Dim maxDocnr As String = ""
        dberrorAtivo = True
        Dim gIdDocCab As Guid = Guid.NewGuid



        Try
            'FORÇAR IMPORT/EXPORT
            Me.Cursor = Cursors.WaitCursor

            If SistemaBloqueado() = True Then Exit Sub
            If dt.Rows.Count = 0 Then Exit Sub


            If dt.Rows(0)("EstadoID") = "R" Then

                Dim strData As New StringBuilder

                Sql = "BEGIN TRANSACTION;"
                strData.AppendLine(Sql)

                maxDocnr = PesquisaMaxNumDoc("DC", lbLoja.Text)
                'NÃO ESTÁ A APANHAR A RECOLHA DE ORIGEM
                'NOTA: SE A DEVOLUÇÃO VIER DE UMA FS NÃO FUNCIONA POIS NÃO TEM RECOLHA CORRESPONDENTE

                ' SE VIER DE UMA FS SAIR..
                'SELECT COUNT(*) FROM Serie WHERE SerieID = '15017756' AND LEFT(DocNr,2)='FS'


                Sql = "INSERT into DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, DescontoDoc, EstadoDoc, TipoTerc, OperadorID) " &
                     "SELECT EmpresaID, ArmazemID, 'DC' TipoDocID, '" + maxDocnr + "' DocNr, TercID, dbo.data(getdate()) DataDoc, TipoDocID TipoDocOrig, DocNr DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, DescontoDoc, EstadoDoc, TipoTerc, '" + xUtilizador + "' " &
                     "FROM DocCab " &
                     "WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + lbLoja.Text + "' AND TipoDocID = 'RE' AND DocNr in (SELECT MAX(DocNr) FROM DocDet WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + lbLoja.Text + "' AND TipoDocID = 'RE' AND SerieID = '" + Me.txtSerieID.Text.ToString + "');"
                strData.AppendLine(Sql)

                Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, Qtd, Obs, EstadoLn, OperadorID) " &
                     "SELECT EmpresaID, ArmazemID, 'DC' TipoDocID, '" + maxDocnr + "' DocNr, 1 DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, Qtd, Obs, EstadoLn, '" + xUtilizador + "' " &
                     "FROM DocDet " &
                     "WHERE TipoDocID = 'RE' AND SerieID = '" + Me.txtSerieID.Text.ToString + "' AND Qtd='1' AND DocNr in (SELECT MAX(DocNr) FROM DocDet WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + lbLoja.Text + "' AND TipoDocID = 'RE' AND SerieID = '" + Me.txtSerieID.Text.ToString + "');"
                strData.AppendLine(Sql)

                Sql = "UPDATE Serie SET PVndReal = 0, DtSaida = GETDATE() , OperadorID = '" + xUtilizador + "', EstadoID='S' , Comissao = '0' WHERE SerieID = '" + Me.txtSerieID.Text.ToString + "';"
                strData.AppendLine(Sql)

                Sql = "COMMIT TRANSACTION;"
                strData.AppendLine(Sql)
                Sql = strData.ToString
                db.ExecuteData(Sql)

                If dberror = False Then
                    RECarregarTalao(Me.txtSerieID.Text.ToString)

                    'GERAR UMA RECOLHA COM O TALÃO DEVOLVIDO...
                    'Sql = "SELECT convert(varchar(38), IdDocCab) FROM DocCab WHERE EmpresaID = '" + xEmp + "' AND ArmazemID = '" + lbLoja.Text + "' AND TipoDocID = 'DC' AND DocNr = N'" + maxDocnr + "'"
                    'GerarRecolha(db.GetDataValue(Sql))

                Else
                    EnviarEmail("Erro", "ERRO NA GRAVAÇÃO DA DEV! 665 " + Now)
                    MsgBox("ERRO NA GRAVAÇÃO!")
                End If
            Else
                MsgBox("TALÃO NÃO ESTÁ RECOLHIDO!")
            End If


            'If MsgBox("Imprimir Talão?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '    Using clsPrintTalao As clsPrintTalao = New clsPrintTalao()
            '        frmStockFoto.tbImpTalao.Text = txtSerieID.Text
            '        clsPrintTalao.Run()
            '    End Using
            'End If
            Inicializa()


        Catch ex As Exception
            ErroVB(ex.Message, "cmdGravar_Click")
        Finally
            frmDevCliente_Load(sender, e)
            If db IsNot Nothing Then db.Dispose()
            dberrorAtivo = False
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Close()
    End Sub

    Private Sub Inicializa()

        Me.txtSerieID.Text = Nothing
        Me.PicFoto.Image = Nothing
        Me.lblTamanho.Text = Nothing
        Me.lblPrVenda.Text = Nothing
        Me.lblCor.Text = Nothing
        Me.lblModelo.Text = Nothing
        Me.lbLoja.Text = Nothing
        dt.Clear()
        Me.txtSerieID.Focus()
        Me.txtSerieID.SelectAll()

    End Sub

    Private Sub frmDevCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        Inicializa()
    End Sub

    Private Function DevolvePv(ByVal xArmz As String, ByVal xSerie As String) As Double
        Dim xPv As Double
        Dim db As New ClsSqlBDados
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

    Private Function DevolveComissao(ByVal xArmz As String, ByVal xModelo As String) As Double
        Dim db As New ClsSqlBDados
        Try

            Sql = "SELECT  C.Comissao FROM  Comissoes C, Modelos M, Armazens A  WHERE C.LinhaID = M.LinhaID " & _
                "AND C.ArmazemID = A.ArmazemID AND C.TabPrecoID = A.TabPrecoID AND M.ModeloID = '" & xModelo & "' AND C.ArmazemID = '" & xArmz & "'"
            If xPrecoEtiqueta = False Then
                Return db.GetDataValue(Sql)
                Exit Function
            End If
            Sql = "SELECT  C.Comissao FROM  Comissoes C, Modelos M, Armazens A  WHERE C.LinhaID = M.LinhaID " & _
                "AND C.ArmazemID = A.ArmazemID AND C.TabPrecoID = '00' AND M.ModeloID = '" & xModelo & "' AND C.ArmazemID = '" & xArmz & "'"
            Return db.GetDataValue(Sql)

        Catch ex As Exception
            ErroVB(ex.Message, "DevolveComissao")
        Finally
            If db IsNot Nothing Then db.Dispose()
        End Try

    End Function

    Private Sub btListarTaloes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListarTaloes.Click
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try


            Dim I As Int64
            Dim RptSelect As String = ""
            Dim xFiltro As String = ""
            xFotoReport = False
            RptSelect = cbReport.SelectedItem

            If RptSelect = "RptTaloes_3x2" Then xFotoReport = True
            If RptSelect = "RptTaloes_8x2" Then xFotoReport = True
            If RptSelect = "RptTaloes_10x4SemTam" Then xFotoReport = False
            If RptSelect = "RptRelTaloes" Then xFotoReport = False


            Dim sPath As String = xRptPath & RptSelect & ".xml"
            If Not IO.File.Exists(sPath) Then
                MsgBox("Report não seleccionado")
                Exit Sub
            End If

            For I = 0 To Me.dgvDevCli.SelectedRows.Count - 1
                xFiltro = xFiltro & "'" & Me.dgvDevCli("SerieIDDataGridViewTextBoxColumn", Me.dgvDevCli.SelectedRows(I).Index).Value & "',"
            Next

            If Len(xFiltro) > 0 Then
                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)
                ListaTaloes(xFiltro, RptSelect, True)
            Else
                MsgBox("NÃO TEM NADA SELECCIONADO", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvDevCli_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDevCli.RowEnter
        Try
            Dim xModelo As String = dgvDevCli("ModeloID", e.RowIndex).Value
            Dim xCor As String = dgvDevCli("CorID", e.RowIndex).Value
            CarregarFoto.CarregarFotoModeloCor(Me.PicFoto, xModelo & xCor, "xok")

        Catch ex As Exception

        End Try

    End Sub




End Class