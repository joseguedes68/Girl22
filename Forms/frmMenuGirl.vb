
Imports System.Data.SqlClient
Imports System.Linq

Public Class frmMenuGirl
    Inherits System.Windows.Forms.Form
    Dim dtLojas As New DataTable
    Dim SubMenu As New ToolStripMenuItem
    Dim WithEvents client As New System.Net.WebClient()



    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim db As New ClsSqlBDados
        Dim Val As New clsValidacoes(Me.Name)
        btsair = False


        Dim nLojas As Integer = 0

        Try

            Me.Cursor = Cursors.WaitCursor

            'If xUtilizador = "GUEDES" Then
            '    MenuTestes.Visible = True
            'Else
            '    MenuTestes.Visible = False
            'End If

            ''CARREGAR MENU DAS LOJAS

            'Carregar dt Lojas
            Sql = "SELECT ArmazemID, ArmAbrev FROM Armazens WHERE (Activo = 1) ORDER BY ArmazemID"
            db.GetData(Sql, dtLojas)
            nLojas = dtLojas.Rows.Count


            If nLojas > 0 Then

                If nLojas > 0 Then L1ToolStripMenuItem.Text = dtLojas.Rows(0)(1).ToString
                If nLojas > 1 Then L2ToolStripMenuItem.Text = dtLojas.Rows(1)(1).ToString
                If nLojas > 2 Then L3ToolStripMenuItem.Text = dtLojas.Rows(2)(1).ToString
                If nLojas > 3 Then L4ToolStripMenuItem.Text = dtLojas.Rows(3)(1).ToString
                If nLojas > 4 Then L5ToolStripMenuItem.Text = dtLojas.Rows(4)(1).ToString
                If nLojas > 5 Then L6ToolStripMenuItem.Text = dtLojas.Rows(5)(1).ToString
                If nLojas > 6 Then L7ToolStripMenuItem.Text = dtLojas.Rows(6)(1).ToString
                If nLojas > 7 Then L8ToolStripMenuItem.Text = dtLojas.Rows(7)(1).ToString
                If nLojas > 8 Then L9ToolStripMenuItem.Text = dtLojas.Rows(8)(1).ToString
                If nLojas > 9 Then L10ToolStripMenuItem.Text = dtLojas.Rows(9)(1).ToString
                If nLojas > 10 Then L11ToolStripMenuItem.Text = dtLojas.Rows(10)(1).ToString
                If nLojas > 11 Then L12ToolStripMenuItem.Text = dtLojas.Rows(11)(1).ToString
                If nLojas > 12 Then L13ToolStripMenuItem.Text = dtLojas.Rows(12)(1).ToString
                If nLojas > 13 Then L14ToolStripMenuItem.Text = dtLojas.Rows(13)(1).ToString
                If nLojas > 14 Then L15ToolStripMenuItem.Text = dtLojas.Rows(14)(1).ToString
                If nLojas > 15 Then L15ToolStripMenuItem.Text = dtLojas.Rows(15)(1).ToString
                If nLojas > 16 Then L15ToolStripMenuItem.Text = dtLojas.Rows(16)(1).ToString
                If nLojas > 17 Then L15ToolStripMenuItem.Text = dtLojas.Rows(17)(1).ToString
                If nLojas > 18 Then L15ToolStripMenuItem.Text = dtLojas.Rows(18)(1).ToString
                If nLojas > 19 Then L15ToolStripMenuItem.Text = dtLojas.Rows(19)(1).ToString
                If nLojas > 20 Then L15ToolStripMenuItem.Text = dtLojas.Rows(20)(1).ToString


                If nLojas > 0 Then L1ToolStripMenuItem.Visible = True
                If nLojas > 1 Then L2ToolStripMenuItem.Visible = True
                If nLojas > 2 Then L3ToolStripMenuItem.Visible = True
                If nLojas > 3 Then L4ToolStripMenuItem.Visible = True
                If nLojas > 4 Then L5ToolStripMenuItem.Visible = True
                If nLojas > 5 Then L6ToolStripMenuItem.Visible = True
                If nLojas > 6 Then L7ToolStripMenuItem.Visible = True
                If nLojas > 7 Then L8ToolStripMenuItem.Visible = True
                If nLojas > 8 Then L9ToolStripMenuItem.Visible = True
                If nLojas > 9 Then L10ToolStripMenuItem.Visible = True
                If nLojas > 10 Then L11ToolStripMenuItem.Visible = True
                If nLojas > 11 Then L12ToolStripMenuItem.Visible = True
                If nLojas > 12 Then L13ToolStripMenuItem.Visible = True
                If nLojas > 13 Then L14ToolStripMenuItem.Visible = True
                If nLojas > 14 Then L15ToolStripMenuItem.Visible = True
                If nLojas > 15 Then L15ToolStripMenuItem.Visible = True
                If nLojas > 16 Then L15ToolStripMenuItem.Visible = True
                If nLojas > 17 Then L15ToolStripMenuItem.Visible = True
                If nLojas > 18 Then L15ToolStripMenuItem.Visible = True
                If nLojas > 19 Then L15ToolStripMenuItem.Visible = True
                If nLojas > 20 Then L15ToolStripMenuItem.Visible = True


            End If


            RepôrCópiaToolStripMenuItem.Visible = False
            If xUtilizador = "joseg" Then
                MenuTestes.Visible = True
            Else
                MenuTestes.Visible = False
            End If



            Sql = "SELECT ArmAbrev as Loja FROM armazens WHERE ArmazemID='" & xArmz & "'"
            Dim sLojas As String = db.GetDataValue(Sql) & "  "

            Sql = "SELECT NomeUtilizador FROM Utilizadores WHERE UtilizadorID=" & iUtilizadorID
            Dim sUtil As String = db.GetDataValue(Sql)

            Me.Text = "Menu Principal - " & sUtil & " / " & sLojas & " / " & xBdados

            'lb0.BackColor = Color.FromArgb(57, 81, 105)
            'lb2.BackColor = Color.FromArgb(57, 81, 105)
            'lb3.BackColor = Color.FromArgb(57, 81, 105)

            If ImagemFundo Then

                If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then

                    Me.BackgroundImage = Global.GirlRootName.My.Resources.Resources.BackOffice
                    Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

                Else

                    Me.BackgroundImage = Global.GirlRootName.My.Resources.Resources.FundoGirl
                    Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

                End If

            End If



        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": frmMenuPos_Load")
        Finally
            Me.Cursor = Cursors.Default
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub POSSubMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MessageBox.Show("You clicked the File menu.", "The Event Information")
    End Sub 'menuItem1_Click



    Private Sub Sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
        LogoffPC()
    End Sub

    Private Sub Grupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GruposToolStripMenuItem.Click
        frmGrupos.MdiParent = Me
        frmGrupos.WindowState = FormWindowState.Normal
        frmGrupos.StartPosition = FormStartPosition.CenterScreen
        frmGrupos.Show()
    End Sub

    Private Sub Cores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoresToolStripMenuItem.Click
        frmCores.MdiParent = Me
        frmCores.WindowState = FormWindowState.Normal
        frmCores.StartPosition = FormStartPosition.CenterScreen
        frmCores.Show()
    End Sub

    Private Sub Tipos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposToolStripMenuItem.Click
        frmTipos.MdiParent = Me
        frmTipos.WindowState = FormWindowState.Normal
        frmTipos.StartPosition = FormStartPosition.CenterScreen
        frmTipos.Show()
    End Sub

    Private Sub Linhas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinhasToolStripMenuItem.Click
        frmLinhas.MdiParent = Me
        frmLinhas.WindowState = FormWindowState.Normal
        frmLinhas.StartPosition = FormStartPosition.CenterScreen
        frmLinhas.Show()
    End Sub

    Private Sub Escalas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EscalasToolStripMenuItem.Click
        frmEscalas.MdiParent = Me
        frmEscalas.WindowState = FormWindowState.Normal
        frmEscalas.StartPosition = FormStartPosition.CenterScreen
        frmEscalas.Show()
    End Sub

    Private Sub Armazens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Armazens.Click
        frmArmz.MdiParent = Me
        frmArmz.WindowState = FormWindowState.Normal
        frmArmz.StartPosition = FormStartPosition.CenterScreen
        frmArmz.Show()
    End Sub

    Private Sub TerceirosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerceirosToolStripMenuItem1.Click
        'frmTerceiros.MdiParent = Me
        'frmTerceiros.WindowState = FormWindowState.Maximized
        'frmTerceiros.Show()

        frmInserirTerceiros.MdiParent = Me
        frmInserirTerceiros.WindowState = FormWindowState.Maximized
        frmInserirTerceiros.Show()

    End Sub

    Private Sub TabelasPreco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabelasDePreçoToolStripMenuItem.Click
        frmTabPrecos.MdiParent = Me
        frmTabPrecos.StartPosition = FormStartPosition.CenterScreen
        frmTabPrecos.WindowState = FormWindowState.Normal
        frmTabPrecos.Show()
    End Sub

    Private Sub Comissoes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComissõesToolStripMenuItem.Click
        frmComissoes.MdiParent = Me
        frmComissoes.WindowState = FormWindowState.Normal
        frmComissoes.StartPosition = FormStartPosition.CenterScreen
        frmComissoes.Show()
    End Sub

    Private Sub Empresas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Empresas.Click
        frmEmpresa.MdiParent = Me
        frmEmpresa.WindowState = FormWindowState.Normal
        frmEmpresa.StartPosition = FormStartPosition.CenterScreen
        frmEmpresa.Show()
    End Sub

    Private Sub Artigos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Artigos.Click
        frmArtigos.MdiParent = Me
        frmArtigos.WindowState = FormWindowState.Maximized
        frmArtigos.Show()
    End Sub

    Private Sub POS_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSToolStripMenuItem.Click
        'Dim frmPos As New frmMenuPos
        'Dim xArmzAux As String
        'Dim db As New ClsSqlBDados

        'Try
        '    xArmzAux = InputBox("Qual a Loja que quer entrar ?", "Escolha a Loja")
        '    If Len(xArmzAux) > 0 Then
        '        Sql = "SELECT COUNT(*) FROM ARMAZENS WHERE ARMAZEMID='" & xArmzAux & "'"
        '        If db.GetDataValue(Sql) > 0 Then
        '            xArmz = xArmzAux

        '            'ACTUALIZA O TIPO DE ARMAZEM

        '            TipodeArmazem()

        '            xPosCallByBackOffice = True
        '            xAplicacao = "POS"
        '            frmPos.StartPosition = FormStartPosition.CenterScreen
        '            'frmPos.WindowState = FormWindowState.Maximized
        '            frmPos.Show()
        '            btsair = True
        '            Me.Close()
        '            btsair = False

        '        Else
        '            MsgBox("Armazem inexistente!")
        '        End If
        '    End If




        'Catch ex As SqlException
        '    ErroSQL(ex.Number, ex.Message, "POS_Click_1")
        'Catch ex As Exception
        '    ErroVB(ex.Message, "POS_Click_1")
        'Finally
        '    If Not db Is Nothing Then db.Dispose()
        '    db = Nothing
        'End Try
    End Sub

    Private Sub PrecosVenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrecosDeVendasToolStripMenuItem.Click
        'Dim frm As New frmGestaoPrecosVenda
        frmGestaoPrecosVenda.MdiParent = Me
        frmGestaoPrecosVenda.WindowState = FormWindowState.Maximized
        frmGestaoPrecosVenda.Show()
    End Sub

    Private Sub AplicarTabelas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AplicarTabelasToolStripMenuItem.Click
        frmActualizaPrecos.MdiParent = Me
        frmActualizaPrecos.WindowState = FormWindowState.Normal
        frmActualizaPrecos.StartPosition = FormStartPosition.CenterScreen
        frmActualizaPrecos.Show()
    End Sub

    Private Sub EpocasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EpocasToolStripMenuItem.Click
        Dim frm As New frmEpocas
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub

    Private Sub TaxasIVAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxasIVAToolStripMenuItem.Click
        Dim frm As New frmtxIva
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub

    Private Sub TabelasPreçoLojaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabelasPreçoLojaToolStripMenuItem.Click
        frmPrecosLoja.MdiParent = Me
        frmPrecosLoja.StartPosition = FormStartPosition.CenterScreen
        frmPrecosLoja.WindowState = FormWindowState.Normal
        frmPrecosLoja.Show()
    End Sub

    Private Sub Operadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilizadoresToolStripMenuItem.Click
        frmUtil.MdiParent = Me
        frmUtil.StartPosition = FormStartPosition.CenterScreen
        frmUtil.WindowState = FormWindowState.Normal
        frmUtil.Show()
    End Sub

    Private Sub GuiaDeTransporteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuiaDeTransporteToolStripMenuItem1.Click
        xTipoDoc = "GT"
        Dim frm As New frmDocs
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub



    Private Sub FacturasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasToolStripMenuItem1.Click

        xTipoDoc = "FT"
        Dim frm As New frmDocs
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()


    End Sub

    Private Sub SeparaçõesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeparaçõesToolStripMenuItem.Click
        frmSepara.MdiParent = Me
        frmSepara.WindowState = FormWindowState.Maximized
        frmSepara.Show()
    End Sub

    Private Sub RecepçõesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecepçõesToolStripMenuItem.Click
        frmRecepcao.MdiParent = Me
        frmRecepcao.WindowState = FormWindowState.Maximized
        frmRecepcao.Show()
    End Sub

    Private Sub CriarCópiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CriarCópiaToolStripMenuItem.Click

        Dim cCopia As New ClsCopias
        Dim db As New ClsSqlBDados

        Try

            Me.Cursor = Cursors.WaitCursor
            cCopia.CriarCopiaManual()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": MenuItem67_Click")
        Finally

            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub RepôrCópiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepôrCópiaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim dbManut As New ClsManutencaoBD
        Try
            dbManut.ReporCopia()
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": MenuItem68_Click")
        Finally
            If dbManut IsNot Nothing Then dbManut.Dispose()
            dbManut = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImportarFotosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarFotosToolStripMenuItem1.Click
        Dim Fotos As New clsImportarFotos
        Try
            Fotos.VerificarFotos()
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": ImportarFotosToolStripMenuItem1_Click")
        Finally
            If Fotos IsNot Nothing Then Fotos.Dispose()
            Fotos = Nothing
        End Try
    End Sub


    Private Sub RelaçãoDeVendasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelaçãoDeVendasToolStripMenuItem1.Click
        xCallByPosDocs = False
        frmRelacaoVendas.MdiParent = Me
        frmRelacaoVendas.StartPosition = FormStartPosition.CenterScreen
        frmRelacaoVendas.WindowState = FormWindowState.Maximized
        frmRelacaoVendas.Show()
    End Sub



    Private Sub EntredasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntredasToolStripMenuItem.Click
        frmExeEnc.MdiParent = Me
        frmExeEnc.WindowState = FormWindowState.Maximized
        frmExeEnc.Show()
    End Sub


    Private Sub RecodificaçãoToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecodificaçãoToolStripMenuItem2.Click
        'frmRecodificacao.MdiParent = Me
        'frmRecodificacao.WindowState = FormWindowState.Normal
        'frmRecodificacao.StartPosition = FormStartPosition.CenterScreen
        'frmRecodificacao.Show()
    End Sub

    Private Sub GerarEtiquetasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GerarEtiquetasToolStripMenuItem1.Click
        frmGerarEtiquetas.MdiParent = Me
        frmGerarEtiquetas.WindowState = FormWindowState.Normal
        frmGerarEtiquetas.StartPosition = FormStartPosition.CenterScreen
        frmGerarEtiquetas.Show()
    End Sub

    Private Sub ReservasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservasToolStripMenuItem1.Click

        frmGestaoReservas.MdiParent = Me
        frmGestaoReservas.StartPosition = FormStartPosition.CenterScreen
        frmGestaoReservas.WindowState = FormWindowState.Maximized
        frmGestaoReservas.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        frmGestaoReservas.Show()

        bArranque = False

    End Sub


    Private Sub ChamaLoja()
        'Dim frmPos As New frmMenuPos
        Dim db As New ClsSqlBDados


        Try

            Sql = "SELECT ISNULL(MIN(UtilizadorID),0) FROM Utilizadores
                WHERE  (ArmazemID = '" & xArmz & "') AND (GrupoAcesso = 'ADMIN')"
            iUtilizadorID = db.GetDataValue(Sql)

            If iUtilizadorID = 0 Then
                MsgBox("Falta o ADMIN para essa loja!!")
                Exit Sub
            End If

            iUtilizadorIDAux = iUtilizadorID

            Me.Close()

            DevolveIvaId(xArmz)

            If ArmazemConsignacao(xArmz) = True Then
                bLojaConsignacao = True
            End If

            xPosCallByBackOffice = True
            xAplicacao = "POS"

            frmMenuPos.StartPosition = FormStartPosition.CenterScreen
            frmMenuPos.WindowState = FormWindowState.Maximized
            frmMenuPos.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            frmMenuPos.Show()


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ChamaLoja")
        Catch ex As Exception
            ErroVB(ex.Message, "ChamaLoja")
        End Try
    End Sub

    Private Sub L1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L1ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(0)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L2ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(1)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L3ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(2)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L4ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(3)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L5ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(4)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L6ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(5)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L7ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L7ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(6)(0).ToString
        ChamaLoja()

    End Sub

    Private Sub L8ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L8ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(7)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L9ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L9ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(8)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L10ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L10ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(9)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L11ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L11ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(10)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L12ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L12ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(11)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L13ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L13ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(12)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L14ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L14ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(13)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L15ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L15ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(14)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L16ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles L16ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(15)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L17ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles L17ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(16)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L18ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles L18ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(17)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L19ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles L19ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(18)(0).ToString
        ChamaLoja()
    End Sub

    Private Sub L20ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles L20ToolStripMenuItem.Click
        xArmz = dtLojas.Rows(19)(0).ToString
        ChamaLoja()
    End Sub


    Private Sub SAFTPTGUIASToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SAFTPTGUIASToolStripMenuItem.Click
        'GerarSaftPT_V1.04_01
        GerarSaftV10401.MdiParent = Me
        GerarSaftV10401.WindowState = FormWindowState.Normal
        GerarSaftV10401.StartPosition = FormStartPosition.CenterScreen
        GerarSaftV10401.Show()
    End Sub


    Private Sub SPOOLERToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SPOOLERToolStripMenuItem1.Click
        ReiniciarSpoler()
    End Sub


    Private Sub RecordToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RecordToolStripMenuItem1.Click
        Record1.MdiParent = Me
        Record1.WindowState = FormWindowState.Normal
        Record1.StartPosition = FormStartPosition.CenterScreen
        Record1.Show()
    End Sub


    Private Sub ValidarXmlToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ValidarXmlToolStripMenuItem1.Click
        ValidarXML.MdiParent = Me
        ValidarXML.WindowState = FormWindowState.Normal
        ValidarXML.StartPosition = FormStartPosition.CenterScreen
        ValidarXML.Show()
    End Sub


    Private Sub NotasDeCréditoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NotasDeCréditoToolStripMenuItem.Click
        xTipoDoc = "NC"
        Dim frm As New frmDocs
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub


    Private Sub GerarHashToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GerarHashToolStripMenuItem.Click


        'HashAnteriorAux
        Dim db As New ClsSqlBDados
        Dim dt As New DataTable
        Dim HashKey As New clsHash

        Me.Cursor = Cursors.WaitCursor




        'Sql = "SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, IdDocCab, Hash FROM DocCab WHERE TipoDocID IN('FT') ORDER BY EmpresaID, TipoDocID, ArmazemID , DocNr"
        Sql = "SELECT TipoDocID + LEFT(DocNr, 2) + RIGHT(ArmazemID, 2) AS Serie, IdDocCab FROM DocCab WHERE TipoDocID ='" & InputBox("TIPO DE DOC?").ToString & "' AND LEFT(DocNr, 2)='14' AND MONTH(DataDoc) = " & InputBox("MÊS") & " ORDER BY Serie, RIGHT(DocNr, 5)"
        MsgBox("muita atenção vai refazer o hash de toda a serie!!")

        db.GetData(Sql, dt)

        Dim schave As String = ""
        For Each r As DataRow In dt.Rows
            If Not schave = r("Serie") Then
                HashAnteriorAux = ""
            End If
            HashKey.CriarHashKey(r("IdDocCab").ToString)
            schave = r("Serie")
        Next



        Me.Cursor = Cursors.Default

    End Sub


    Private Sub TesteDataToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TesteDataToolStripMenuItem.Click
        DataArq("C:\Girl\Reports\DocFactura.xml")
    End Sub


    Private Sub ConferênciaDeStocksToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub AnaliseDeVendasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub HASHFROMFILEToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles HASHFROMFILEToolStripMenuItem1.Click
        frmHashFromFile.MdiParent = Me
        frmHashFromFile.WindowState = FormWindowState.Normal
        frmHashFromFile.Show()
    End Sub


    Private Sub EtiquetasToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles EtiquetasToolStripMenuItem1.Click
        Application.DoEvents()
        frmConsultaTalao.MdiParent = Me
        frmConsultaTalao.WindowState = FormWindowState.Maximized
        frmConsultaTalao.StartPosition = FormStartPosition.CenterScreen
        frmConsultaTalao.WindowState = FormWindowState.Normal
        frmConsultaTalao.Show()
    End Sub


    Private Sub ErrosToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ErrosToolStripMenuItem1.Click
        frmErros.MdiParent = Me
        frmErros.StartPosition = FormStartPosition.CenterScreen
        frmErros.WindowState = FormWindowState.Normal
        frmErros.Show()
    End Sub


    Private Sub FechosCaixaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FechosCaixaToolStripMenuItem.Click

        frmFechoCaixa.MdiParent = Me
        frmFechoCaixa.StartPosition = FormStartPosition.CenterScreen
        frmFechoCaixa.WindowState = FormWindowState.Maximized
        frmFechoCaixa.Show()
    End Sub


    Private Sub ProdutoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProdutoToolStripMenuItem.Click
        frmProduct.MdiParent = Me
        frmProduct.WindowState = FormWindowState.Normal
        frmProduct.StartPosition = FormStartPosition.CenterScreen
        frmProduct.Show()
    End Sub


    Private Sub MovStockToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MovStockToolStripMenuItem.Click
        frmControlStock.MdiParent = Me
        frmControlStock.WindowState = FormWindowState.Normal
        frmControlStock.StartPosition = FormStartPosition.CenterScreen
        frmControlStock.Show()

    End Sub


    Private Sub GuiasDeEntradaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GuiasDeEntradaToolStripMenuItem.Click
        xTipoDoc = "GE"
        Dim frm As New frmDocs
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub


    Private Sub ChatToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChatToolStripMenuItem.Click
        frmChat.MdiParent = Me
        frmChat.WindowState = FormWindowState.Normal
        frmChat.StartPosition = FormStartPosition.CenterScreen
        frmChat.Show()
    End Sub


    Private Sub LimparFotosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LimparFotosToolStripMenuItem.Click


        LimparFotos()


    End Sub


    Private Sub ListaTerceirosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListaTerceirosToolStripMenuItem.Click

        sIDClienteLoja = ""
        frmClientesLojaLista.MdiParent = Me
        frmClientesLojaLista.WindowState = FormWindowState.Normal
        frmClientesLojaLista.StartPosition = FormStartPosition.CenterScreen
        frmClientesLojaLista.Show()

    End Sub


    Private Sub GAVETAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GAVETAToolStripMenuItem.Click
        AbrirGaveta()
    End Sub


    Private Sub CopiarWebToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopiarWebToolStripMenuItem.Click


        ''Using wc As New System.Net.WebClient()
        ''    wc.UploadFile("https://hubic.com/home/pub/?ruid=aHR0cHM6Ly9sYjEuaHViaWMub3ZoLm5ldC92MS9BVVRIX2VjZTBiMzI2ZjFkOTZmMjVkZTk1NmJiNmI4MTJiYzViL2RlZmF1bHQvLm92aFB1Yi8xNDg2ODUxNTY3XzE0ODc3MTU1Njc/dGVtcF91cmxfc2lnPTVhOTdkZDgxNmU0ODJkZTNmYmM2MzYwMDdiMmQzY2EzN2M3ZDg0NTImdGVtcF91cmxfZXhwaXJlcz0xNDg3NzE1NTY3", "D:\BackUps\teste.txt")
        ''End Using

        'Dim uriString As New System.Uri("https://a22a.myqnapcloud.com:443/share.cgi?ssid=08lSTcI")
        'Me.client.UploadFileAsync(uriString, "D:\BackUps\teste.txt")

        ''FileUploadCompleted(sender, e)

        'UploadFile(foundFile + ".jpg", "ftp://ftp.gestiprod.com/" + "fotos1/" + snomeficheiro + ".jpg", "celferi_backups@gestiprod.com", "wi=4+]Q1;Fxk")


        'UploadFile("C:\Girl\backup\Girl20220306.bak", "ftp://ftp.iloveshoes.pt/celferi/Girl20220306.bak", "celferi@iloveshoes.pt", "30..Cl..42")




        UploadFile("C:\Girl\backup\Girl20220306.bak", "ftp://137.74.207.187/Girl20220306.bak", "celferi@iloveshoes.pt", "30..Cl..42")




        'UploadFile(, "/home/ilovesho/iloveshoes.pt/celferi")






    End Sub



    Private Sub FileUploadCompleted(ByVal sender As Object, ByVal e As System.Net.UploadFileCompletedEventArgs) Handles client.UploadFileCompleted
        Dim response As String = System.Text.Encoding.ASCII.GetString(e.Result)
        MsgBox(response)

        ' further process your response string
    End Sub




    Private Sub HashDiretoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HashDiretoToolStripMenuItem.Click


        Dim HashKey As New clsHash

        'HashKey.CriarHashKeyDireto("2017-03-22;2017-03-22T09:13:03;GT 1700/00060;0.00;jSBUEKzfCDcKbMLUqucO3mEboaZkOz3bh4XBfa5OExUPgSGDQt30HpF1I/Y04hMvsCPR43WbLHraVJ31+OFAbjKv7G1t6zqvjrsKxDxGopOltw64fkSXNDO73PtJClHxOFK89T4RLS3/erhzwsgq94fqTIZUF1eKWQ43KYDBIxE=")
        HashKey.CriarHashKeyDireto("2017-03-22;2017-03-22T09:13:00;GT 1700/00060;0.00;jSBUEKzfCDcKbMLUqucO3mEboaZkOz3bh4XBfa5OExUPgSGDQt30HpF1I/Y04hMvsCPR43WbLHraVJ31+OFAbjKv7G1t6zqvjrsKxDxGopOltw64fkSXNDO73PtJClHxOFK89T4RLS3/erhzwsgq94fqTIZUF1eKWQ43KYDBIxE=")




    End Sub


    Private Sub NOTIFICAÇÕESToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NOTIFICAÇÕESToolStripMenuItem.Click


        Me.Hide()

        NotifyIcon1.Visible = True

        NotifyIcon1.BalloonTipText = "Texto" 'O texto que será exibido na mensagem.
        NotifyIcon1.BalloonTipTitle = "Título" 'O título da mensagem.
        NotifyIcon1.ShowBalloonTip(1000000) 'Comando para mostrar a mensagem, onde Tempo é o tempo em milissegundos que a mensagem será exibida.






    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click

    End Sub


    'Private Sub criarCopias() Handles MenuStrip1.MouseClick


    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        'Copiasbd()

    '        Me.Cursor = Cursors.Default

    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub GuiasConsignaçãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuiasConsignaçãoToolStripMenuItem.Click

        xTipoDoc = "GC"
        Dim frm As New frmDocs With {
            .MdiParent = Me,
            .WindowState = FormWindowState.Normal,
            .StartPosition = FormStartPosition.CenterScreen
        }
        frm.Show()

    End Sub

    Private Sub ConsultasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultasToolStripMenuItem.Click


        Dim frm As New frmConsultaDocs With {
            .MdiParent = Me,
            .WindowState = FormWindowState.Normal,
            .StartPosition = FormStartPosition.CenterScreen
        }
        frm.Show()


    End Sub

    Private Sub QrCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QrCodeToolStripMenuItem.Click


        Dim cQrCode As New clsQrCode
        cQrCode.CarregaQrCode("5e66b88b-1714-4f28-8891-095ed88d620d")


    End Sub

    Private Sub FaturasConsignaçãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaturasConsignaçãoToolStripMenuItem.Click

        'No saft vai para as tabelas WorkingDocuments
        xTipoDoc = "FC"
        Dim frm As New frmDocs
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()



    End Sub

    Private Sub CreditoDeConsignaçãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditoDeConsignaçãoToolStripMenuItem.Click

        'No saft vai para as tabelas WorkingDocuments
        xTipoDoc = "CC"
        Dim frm As New frmDocs
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()



    End Sub

    Private Sub ConsignaçãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsignaçãoToolStripMenuItem.Click
        frmSepConsignacao.MdiParent = Me
        frmSepConsignacao.WindowState = FormWindowState.Maximized
        frmSepConsignacao.Show()
    End Sub

    Private Sub CopiasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiasToolStripMenuItem.Click



        'UploadFile("C:\Girl\BackUp\GirlLocal20220903 163252.bak.gz", "ftp://137.74.207.187/docs/teste.bak", "celferi@iloveshoes.pt", "30..Cl..42")

        'UploadFile("C:\Girl\BackUp\GirlLocal20220903 163252.bak.gz", "ftp://celferi@89.114.159.233/teste.bak", "celferi", "2R>z9J4sPu*7PH:")
        'UploadFile("C:\Girl\BackUp\GirlLocal20220903 163252.bak.gz", "ftp://89.114.159.233/bdados/teste.bak", "celferi", "2R>z9J4sPu*7PH:")


        UploadFile("C:\Girl\BackUp\GirlLocal20220903 163252.bak.gz", "ftp://89.114.159.233/bdados/GirlLocal20220903 163252.bak.gz", "celferi", "2R>z9J4sPu*7PH:")



    End Sub

    Private Sub EnviarEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarEmailToolStripMenuItem.Click


        Cursor = Cursors.WaitCursor


        EnviarEmail("ERRO 56896 NA COPIA", "Não foi possivel fazer upload para a web do ficheiro")

        'EnviarEmail1()

        Cursor = Cursors.Default




    End Sub

    Private Sub DevoluçõesLojasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevoluçõesLojasToolStripMenuItem.Click


        Try


            frmVendasLista.WindowState = FormWindowState.Maximized
            frmVendasLista.StartPosition = FormStartPosition.CenterScreen
            frmVendasLista.ShowDialog(Me)
            frmVendasLista.Dispose()



            'Dim frmvl As New frmVendasLista
            'frmvl.WindowState = FormWindowState.Maximized
            'frmvl.StartPosition = FormStartPosition.CenterScreen
            'frmvl.ShowDialog(Me)
            'frmvl.Dispose()


        Catch ex As Exception

        End Try


    End Sub

    Private Sub MenuStrip1_MouseClick(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseClick
        'xArmz = "0000"

        If Application.OpenForms.OfType(Of frmMenuPos)().Any Then
            ' Formulário está aberto
            btsair = True
            frmMenuPos.Close()
            xArmz = "0000"
            xAplicacao = "BACKOFFICE"
        End If


        'For Each frm As Form In Application.OpenForms
        '    If frm.Name = "frmMenuPos" Then
        '        frm.Close()
        '        xArmz = "0000"
        '        Exit For
        '    End If
        'Next


    End Sub

    Private Sub TransferirStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferirStockToolStripMenuItem.Click
        Try


            frmTransfStock.MdiParent = Me
            frmTransfStock.StartPosition = FormStartPosition.CenterScreen
            frmTransfStock.WindowState = FormWindowState.Normal
            frmTransfStock.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub EncomendasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncomendasToolStripMenuItem.Click


        Try


            frmManutEncClientes.MdiParent = Me
            frmManutEncClientes.WindowState = FormWindowState.Maximized
            frmManutEncClientes.Show()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub CatalogoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatalogoToolStripMenuItem.Click
        Try


            frmStockFoto.MdiParent = Me
            frmStockFoto.WindowState = FormWindowState.Minimized
            frmStockFoto.Show()
            For i As Integer = 1 To 10000
                i += 1
            Next
            frmStockFoto.WindowState = FormWindowState.Maximized
            frmStockFoto.txtModelo.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ReposiçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReposiçõesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frm As New frmReport
        Dim xData As String = ""
        Dim db As New ClsSqlBDados

        Try
            Dim xDataAux As String = Format(CType(Now.AddDays(-30), Date), "yyyy-MM-dd")
            xData = InputBox("Digite data pretendida!", "Reposição de Vendas", xDataAux)
            If xData <> "" Then
                xData = Format(CType(xData, Date), "yyyy-MM-dd")
                'xData = Format(CType(InputBox("Digite data pretendida!", "Reposição de Vendas", xDataAux), Date), "yyyy-MM-dd")
                With frm
                    ds.Clear()
                    Sql = "prc_DevolveMapaReposicao '" + xData + "'"
                    Cmd = New SqlClient.SqlCommand(Sql, cn)
                    If cn.State = ConnectionState.Closed Then cn.Open()
                    da = New SqlDataAdapter(Sql, cn)
                    da.Fill(ds)
                    If ds.Tables(0).Rows.Count > 0 Then


                        .C1RptReposicao.Load(xRptPath & "RptReposicao.xml", "Reposicao")
                        .C1RptReposicao.DataSource.ConnectionString = sconnectionstringReport
                        .C1RptReposicao.DataSource.RecordSource = "SELECT * from ##TempDetalheAux"

                        Sql = "SELECT COUNT(*) FROM ##TempDetalheAux"
                        Dim nlinhas As Double = db.GetDataValue(Sql)
                        If nlinhas / 47 > 1 Then
                            If MsgBox("Vai Imprimir : " & Int(nlinhas / 47) + 1 & " páginas. Confirma Impressão?", MsgBoxStyle.YesNo, "REPOSIÇÕES") = MsgBoxResult.No Then
                                Exit Sub
                            End If
                        End If

                        JustPrint(.C1RptReposicao)


                        '.C1PrtPreview.Document = .C1RptReposicao.Document
                        '.C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize
                        'Application.DoEvents()
                        'Me.Cursor = Cursors.Default
                        '.Show()
                    End If
                End With
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "MenuItem10_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "MenuItem10_Click")
        Finally
            Me.Cursor = Cursors.Default
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub DevFornecedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevFornecedoresToolStripMenuItem.Click
        frmDevolucao.MdiParent = Me
        frmDevolucao.WindowState = FormWindowState.Maximized
        frmDevolucao.Show()
    End Sub

    Private Sub DevoluçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevoluçõesToolStripMenuItem.Click

        frmDevCliente.StartPosition = FormStartPosition.CenterParent
        frmDevCliente.WindowState = FormWindowState.Normal
        frmDevCliente.ShowInTaskbar = False
        frmDevCliente.MaximizeBox = False
        frmDevCliente.MinimizeBox = False
        frmDevCliente.ShowDialog(Me)
    End Sub

    Private Sub RecolhasToolStripMenuItem_Click(sender As Object, e As EventArgs)

        frmRecolha.MdiParent = Me
        frmRecolha.StartPosition = FormStartPosition.CenterScreen
        frmRecolha.WindowState = FormWindowState.Normal
        frmRecolha.Show()
    End Sub

    Private Sub AnaliseDeVendasToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AnaliseDeVendasToolStripMenuItem.Click
        frmAnaliseVendas.MdiParent = Me
        frmAnaliseVendas.WindowState = FormWindowState.Maximized
        frmAnaliseVendas.Show()
    End Sub

    Private Sub ResumoMensalToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmResumoMensal.MdiParent = Me
        frmResumoMensal.StartPosition = FormStartPosition.CenterScreen
        frmResumoMensal.WindowState = FormWindowState.Maximized
        frmResumoMensal.Show()
        Application.DoEvents()
    End Sub

    Private Sub ConferênciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConferênciasToolStripMenuItem.Click

        frmConferencia.MdiParent = Me
        frmConferencia.WindowState = FormWindowState.Maximized
        frmConferencia.Show()
    End Sub


    Private Sub AcessóriosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AcessóriosToolStripMenuItem1.Click

        Try

            xCallByPosDocs = False
            frmRelacaoVendasAc.MdiParent = Me
            frmRelacaoVendasAc.StartPosition = FormStartPosition.CenterScreen
            frmRelacaoVendasAc.WindowState = FormWindowState.Maximized
            frmRelacaoVendasAc.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub MarcasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcasToolStripMenuItem.Click


        xCallByPosDocs = False
        frmMarcas.MdiParent = Me
        frmMarcas.StartPosition = FormStartPosition.CenterScreen
        frmMarcas.WindowState = FormWindowState.Normal
        frmMarcas.Show()


    End Sub

    Private Sub ExportarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ExportaWeb()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ActualizarPVPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarPVPToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ActualizaPVPWeb()
        ActualizaLigacao("CelfGest")
        Me.Cursor = Cursors.Default
        MsgBox("Preços Web Actualizados com sucesso!")
    End Sub

    Private Sub ActualizarTamanhosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarTamanhosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ActualizaTamWeb()
        ActualizaLigacao("CelfGest")
        Me.Cursor = Cursors.Default
        MsgBox("Tamanhos Web Actualizados com sucesso!")
    End Sub

    Private Sub ActualizarMarcaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarMarcaToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        ActualizaMarcaWeb()
        ActualizaLigacao("CelfGest")
        Me.Cursor = Cursors.Default

    End Sub
End Class



