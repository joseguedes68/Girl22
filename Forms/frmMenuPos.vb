

Public Class frmMenuPos



    Dim xPass As String
    Dim xNivelAcesso As String


    Private Sub frmMenuPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New ClsSqlBDados
        Dim Val As New clsValidacoes(Me.Name)
        Try

            If permite_emitir_docs() = False Then
                mVendas.Visible = False
                mDocs.Visible = False
            End If


            Me.Cursor = Cursors.WaitCursor


            Sql = "SELECT ArmAbrev as Loja FROM armazens WHERE ArmazemID='" & xArmz & "'"
            Dim sLojas As String = db.GetDataValue(Sql) & "  "

            Sql = "SELECT NomeUtilizador FROM Utilizadores WHERE UtilizadorID=" & iUtilizadorID
            Dim sUtil As String = db.GetDataValue(Sql)

            Me.Text = "Menu Principal - " & sUtil & " / " & sLojas & " / " & xBdados


            'xGrupoAcesso NÃO ESTÁ COMO VARIAVEL GLOBAL, MAS A VARIAVEL GLOBAL TB EXISTE.....
            Sql = "SELECT GrupoAcesso FROM Utilizadores WHERE UtilizadorID=" & iUtilizadorID
            Dim xGrupoAcesso As String = db.GetDataValue(Sql)

            If xGrupoAcesso = "NIVEL2" Then
                smRV.Visible = False
            End If

            'If xUtilizador = "GUEDES" Then
            '    mFechar.Visible = True
            'Else
            '    mFechar.Visible = False
            'End If

            If ImagemFundo Then


                If Val.ValidarPermicoes("Background") Then
                    If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then
                        Me.BackgroundImage = Global.GirlRootName.My.Resources.Resources.FrontOffice
                    Else
                        Me.BackgroundImage = Global.GirlRootName.My.Resources.Resources.FundoGirl
                    End If
                Else
                    Me.BackgroundImage = Global.GirlRootName.My.Resources.Resources.FundoGirl
                End If
                Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch


            End If





            sVendedor = iUtilizadorID


            If bLojaConsignacao = True Then

                'mVendas.Visible = False
                'mDocs.Visible = False
                PreçosToolStripMenuItem.Visible = False
                EtiquetasToolStripMenuItem.Visible = True
                MenuComissões.Visible = False
                smFS.Visible = False
                smFT.Visible = False
                smNC.Visible = False
                smFX.Visible = True
                smRV.Visible = False
                smGT.Visible = False
                smVC.Visible = False
                smFX.Text = "Fecho"
            Else
                smVC.Visible = False


            End If



        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": frmMenuPos_Load")
        Finally
            Me.Cursor = Cursors.Default
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub frmMenuPos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btsair <> True Then
            e.Cancel = True
        End If
    End Sub

    Private Sub VendasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mVendas.Click

        frmVendas.MdiParent = Me
        frmVendas.WindowState = FormWindowState.Normal
        frmVendas.StartPosition = FormStartPosition.CenterScreen
        frmVendas.Show()
        frmVendas.BringToFront()
        frmVendas.WindowState = FormWindowState.Normal


    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smFS.Click
        xTipoDoc = "FS"

        'If FrmDocsLojas.IsHandleCreated Then
        '    FrmDocsLojas = Nothing
        'End If
        FrmDocsLojas.MdiParent = Me
        FrmDocsLojas.WindowState = FormWindowState.Normal
        FrmDocsLojas.StartPosition = FormStartPosition.CenterScreen
        FrmDocsLojas.Show()

    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smGT.Click
        xTipoDoc = "GT"
        frmDocs.MdiParent = Me
        frmDocs.WindowState = FormWindowState.Normal
        frmDocs.StartPosition = FormStartPosition.CenterScreen
        frmDocs.Show()
    End Sub

    Private Sub ConsultasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mConsultas.Click
        frmStockFoto.MdiParent = Me
        frmStockFoto.WindowState = FormWindowState.Minimized
        frmStockFoto.Show()
        frmStockFoto.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub FechoCaixaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smFX.Click
        frmFechoCaixa.MdiParent = Me
        frmFechoCaixa.StartPosition = FormStartPosition.CenterScreen
        frmFechoCaixa.WindowState = FormWindowState.Normal
        frmFechoCaixa.Show()
    End Sub

    Private Sub ReceçõesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceçõesToolStripMenuItem.Click
        frmRecepcao.MdiParent = Me
        frmRecepcao.WindowState = FormWindowState.Maximized
        frmRecepcao.Show()
    End Sub

    Private Sub SeparaçõesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeparaçõesToolStripMenuItem1.Click
        frmSepara.MdiParent = Me
        frmSepara.WindowState = FormWindowState.Maximized
        frmSepara.Show()
    End Sub

    Private Sub PreçosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreçosToolStripMenuItem.Click
        frmGestaoPrecosVenda.MdiParent = Me
        frmGestaoPrecosVenda.StartPosition = FormStartPosition.CenterScreen
        frmGestaoPrecosVenda.WindowState = FormWindowState.Normal
        frmGestaoPrecosVenda.Show()
    End Sub

    Private Sub VendasSuspensasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        xTipoDoc = "VS"
        FrmDocsLojas.MdiParent = Me
        FrmDocsLojas.WindowState = FormWindowState.Normal
        FrmDocsLojas.StartPosition = FormStartPosition.CenterScreen
        FrmDocsLojas.Show()
    End Sub


    Private Sub RelaçãoVendasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smRV.Click
        xCallByPosDocs = True
        frmRelacaoVendas.MdiParent = Me
        frmRelacaoVendas.StartPosition = FormStartPosition.CenterScreen
        frmRelacaoVendas.WindowState = FormWindowState.Maximized
        frmRelacaoVendas.Show()
    End Sub

    Private Sub NotasDeCréditoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles smNC.Click
        If xArmz = "0000" Then
            Exit Sub
        End If
        xTipoDoc = "NC"
        FrmDocsLojas.MdiParent = Me
        FrmDocsLojas.WindowState = FormWindowState.Normal
        FrmDocsLojas.StartPosition = FormStartPosition.CenterScreen
        FrmDocsLojas.Show()
    End Sub


    Private Sub FecharToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mFechar.Click

        Try

            If xPosCallByBackOffice = True Then
                btsair = True
                Close()
                xArmz = "0000"
                iUtilizadorID = iUtilizadorIDAux
                DevolveIvaId(xArmz)
                bLojaConsignacao = False
                xPosCallByBackOffice = False
                xAplicacao = "BACKOFFICE"
                frmMenuGirl.Show()

            Else
                btsair = True
                LogoffPC()
            End If

        Catch ex As Exception

        End Try


    End Sub


    Private Sub EtiquetasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EtiquetasToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        frmConsultaTalao.MdiParent = Me
        frmConsultaTalao.WindowState = FormWindowState.Maximized
        frmConsultaTalao.Show()
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub ComissõesToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles MenuComissões.Click
        frmComissaoVnd.StartPosition = FormStartPosition.CenterParent
        frmComissaoVnd.WindowState = FormWindowState.Normal
        frmComissaoVnd.ShowInTaskbar = False
        frmComissaoVnd.MaximizeBox = False
        frmComissaoVnd.MinimizeBox = False
        frmComissaoVnd.ShowDialog(Me)
    End Sub


    Private Sub TestarGavetaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TestarGavetaToolStripMenuItem.Click

    End Sub

    Private Sub FaturasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles smFT.Click
        xTipoDoc = "FT"

        FrmDocsLojas.MdiParent = Me
        FrmDocsLojas.WindowState = FormWindowState.Normal
        FrmDocsLojas.StartPosition = FormStartPosition.CenterScreen
        FrmDocsLojas.Show()

    End Sub


    Private Sub criarCopias() Handles MenuStripPos.MouseClick


        Try
            Me.Cursor = Cursors.WaitCursor

            'Copiasbd()

            Me.Cursor = Cursors.Default

        Catch ex As Exception

        End Try

    End Sub

    Private Sub smVC_Click(sender As Object, e As EventArgs) Handles smVC.Click
        'bConsignacaoAuxListagens = True
        'xCallByPosDocs = True
        'frmRelacaoVendas.MdiParent = Me
        'frmRelacaoVendas.StartPosition = FormStartPosition.CenterScreen
        'frmRelacaoVendas.WindowState = FormWindowState.Maximized
        'frmRelacaoVendas.Show()
    End Sub


End Class