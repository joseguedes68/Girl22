
Imports System.Data.SqlClient



'PARA TESTES
Imports System.Xml
'FIM PARA TESTES






Public Class frmMenuCelfGest
    Inherits System.Windows.Forms.Form


    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Dim db As New ClsSqlBDados
        Dim Val As New clsValidacoes(Me.Name)

        Try

            Me.Cursor = Cursors.WaitCursor


            'Sql = "SELECT 'Loja : ' + ArmazemID +' - '+ ArmAbrev as Loja FROM armazens WHERE ArmazemID='" & xArmz & "'"
            'Me.ToolStripStatusData.Text = "Data: " & Format(Today, "yyyy-MM-dd")
            'Me.ToolStripStatusArmazem.Text = db.GetDataValue(Sql)
            'Me.ToolStripStatusServidor.Text = "  BDados: " & xBdados




            Sql = "SELECT ArmAbrev as Loja FROM armazens WHERE ArmazemID='" & xArmz & "'"
            Dim sLojas As String = db.GetDataValue(Sql) & "  "

            Sql = "SELECT NomeUtilizador FROM Utilizadores WHERE UtilizadorID=" & iUtilizadorID
            Dim sUtil As String = db.GetDataValue(Sql)

            Me.Text = "Menu Principal - " & sUtil & " / " & sLojas & " / " & xBdados

            If sUtil = "GUEDES" Then
                TestesToolStripMenuItem.Visible = True
            Else
                TestesToolStripMenuItem.Visible = False
            End If



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

    Private Sub Sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
        LogoffPC()
        Application.Exit()
    End Sub

    Private Sub EncomendasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncomendasToolStripMenuItem.Click
        Dim db As New ClsSqlBDados

        Try

            Sql = "SELECT isnull(VAR2,0) FROM EMPRESAS WHERE EMPRESAID='" & xEmp & "'"
            If db.GetDataValue(Sql) = 0 Then
                Sql = "UPDATE Empresas SET Var2 = N'1' WHERE (EmpresaID = '" & xEmp & "')"
                db.ExecuteData(Sql)
                frmManutEnc.MdiParent = Me
                frmManutEnc.WindowState = FormWindowState.Maximized
                frmManutEnc.Show()
            Else
                MsgBox("Está outro utilizador a fazer encomendas!")
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "EncomendasToolStripMenuItem_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "EncomendasToolStripMenuItem_Click")
        Finally
        End Try

    End Sub

    Private Sub TaloesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.DoEvents()
        frmConsultaTalao.MdiParent = Me
        frmConsultaTalao.WindowState = FormWindowState.Maximized
        frmConsultaTalao.Show()
    End Sub

    Private Sub FotosStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FotosStockToolStripMenuItem.Click
        frmStockFoto.MdiParent = Me
        frmStockFoto.WindowState = FormWindowState.Minimized
        frmStockFoto.Show()
        For i As Integer = 1 To 10000
            i += 1
        Next
        frmStockFoto.WindowState = FormWindowState.Maximized
        frmStockFoto.txtModelo.Focus()
    End Sub

    Private Sub GestãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestãoToolStripMenuItem.Click
        frmGestao.MdiParent = Me
        frmGestao.WindowState = FormWindowState.Maximized
        frmGestao.Show()
    End Sub

    Private Sub EtiquetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtiquetasToolStripMenuItem.Click
        Application.DoEvents()
        frmConsultaTalao.MdiParent = Me
        frmConsultaTalao.WindowState = FormWindowState.Normal
        frmConsultaTalao.StartPosition = FormStartPosition.CenterScreen
        frmConsultaTalao.Show()
    End Sub

    Private Sub DevFornecedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevFornecedoresToolStripMenuItem.Click
        frmDevolucao.MdiParent = Me
        frmDevolucao.WindowState = FormWindowState.Maximized
        frmDevolucao.Show()
    End Sub


    Private Sub ImpFotosRecentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpFotosRecentesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ImpFotosRecentes()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ImpFotosTodasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpFotosTodasToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ImpFotos()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem.Click

        'Dim db As New ClsSqlBDados

        'Sql = "SELECT ISNULL(Var4,'0') Var4 FROM Empresas WHERE EmpresaID = '" & xEmp & "' "
        'If db.GetDataValue(Sql) = "0" Then
        '    LigarDesligarToolStripMenuItem.Text = "Desativar Imp"
        'Else
        '    LigarDesligarToolStripMenuItem.Text = "Ativar Imp"
        'End If

    End Sub

    Private Sub RecolhasToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RecolhasToolStripMenuItem1.Click
        frmRecolhaV01.MdiParent = Me
        frmRecolhaV01.StartPosition = FormStartPosition.CenterScreen
        frmRecolhaV01.WindowState = FormWindowState.Normal
        frmRecolhaV01.Show()
    End Sub

    Private Sub CópiaToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CópiaToolStripMenuItem1.Click


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

    Private Sub TerceirosToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles TerceirosToolStripMenuItem1.Click
        'frmTerceiros.MdiParent = Me
        'frmTerceiros.WindowState = FormWindowState.Maximized
        'frmTerceiros.Show()

        frmInserirTerceiros.MdiParent = Me
        frmInserirTerceiros.WindowState = FormWindowState.Maximized
        frmInserirTerceiros.Show()

    End Sub

    Private Sub TransferirStockToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles TransferirStockToolStripMenuItem1.Click
        frmTransfStock.MdiParent = Me
        frmTransfStock.StartPosition = FormStartPosition.CenterScreen
        frmTransfStock.WindowState = FormWindowState.Normal
        frmTransfStock.Show()
    End Sub

    Private Sub MovimentoStocksToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MovimentoStocksToolStripMenuItem.Click

    End Sub

    Private Sub ResumoMensalToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ResumoMensalToolStripMenuItem1.Click

        frmResumoMensal.MdiParent = Me
        frmResumoMensal.StartPosition = FormStartPosition.CenterScreen
        frmResumoMensal.WindowState = FormWindowState.Normal
        frmResumoMensal.Show()
        Application.DoEvents()
    End Sub

    Private Sub ReposiçõesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReposiçõesToolStripMenuItem.Click
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

    Private Sub EmpresaToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles EmpresaToolStripMenuItem1.Click
        frmEmpresa.MdiParent = Me
        frmEmpresa.WindowState = FormWindowState.Normal
        frmEmpresa.StartPosition = FormStartPosition.CenterScreen
        frmEmpresa.Show()
    End Sub

    Private Sub DevoluçõesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DevoluçõesToolStripMenuItem.Click

        frmDevCliente.StartPosition = FormStartPosition.CenterParent
        frmDevCliente.WindowState = FormWindowState.Normal
        frmDevCliente.ShowInTaskbar = False
        frmDevCliente.MaximizeBox = False
        frmDevCliente.MinimizeBox = False
        frmDevCliente.ShowDialog(Me)
    End Sub

    Private Sub RecolherToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RecolherToolStripMenuItem.Click



        frmRecolha.MdiParent = Me
        frmRecolha.StartPosition = FormStartPosition.CenterScreen
        frmRecolha.WindowState = FormWindowState.Normal
        frmRecolha.Show()




    End Sub

    Private Sub AnáliseVendasToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AnáliseVendasToolStripMenuItem1.Click
        frmAnaliseVendas.MdiParent = Me
        frmAnaliseVendas.WindowState = FormWindowState.Maximized
        frmAnaliseVendas.Show()
    End Sub

    Private Sub RecolhasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RecolhasToolStripMenuItem.Click
        'GerarRecolha("6A56102B-3251-4660-B292-08EFC40D24E3")
    End Sub

    Private Sub RECOLHASToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles RECOLHASToolStripMenuItem2.Click
        frmRecolha.MdiParent = Me
        frmRecolha.StartPosition = FormStartPosition.CenterScreen
        frmRecolha.WindowState = FormWindowState.Normal
        frmRecolha.Show()
    End Sub

    Private Sub RecolherToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RecolherToolStripMenuItem1.Click

        frmRecolher.MdiParent = Me
        frmRecolher.StartPosition = FormStartPosition.CenterScreen
        frmRecolher.WindowState = FormWindowState.Normal
        frmRecolher.Show()

    End Sub

    Private Sub ResumoMensalReToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResumoMensalReToolStripMenuItem.Click
        frmResumoMensal.MdiParent = Me
        frmResumoMensal.StartPosition = FormStartPosition.CenterScreen
        frmResumoMensal.WindowState = FormWindowState.Maximized
        frmResumoMensal.Show()
        Application.DoEvents()
    End Sub

    Private Sub ExportarWebToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportarWebToolStripMenuItem.Click


        'Me.Cursor = Cursors.WaitCursor
        'ExportaWeb()
        'Me.Cursor = Cursors.Default


        'frmExportaWeb.MdiParent = Me
        'frmExportaWeb.StartPosition = FormStartPosition.CenterScreen
        'frmExportaWeb.WindowState = FormWindowState.Normal
        'frmExportaWeb.Show()




    End Sub





    Private Sub DiscoRigidoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DiscoRigidoToolStripMenuItem.Click
        frmdisco.MdiParent = Me
        frmdisco.WindowState = FormWindowState.Normal
        frmdisco.StartPosition = FormStartPosition.CenterScreen
        frmdisco.Show()
    End Sub

    Private Sub ConferênciasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConferênciasToolStripMenuItem.Click

        frmConferencia.MdiParent = Me
        frmConferencia.WindowState = FormWindowState.Maximized
        frmConferencia.Show()

    End Sub

    Private Sub ArquivarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ArquivarToolStripMenuItem.Click
        frmHistoricos.MdiParent = Me
        frmHistoricos.StartPosition = FormStartPosition.CenterScreen
        frmHistoricos.WindowState = FormWindowState.Normal
        frmHistoricos.Show()
    End Sub

    Private Sub LimparFotosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LimparFotosToolStripMenuItem.Click

        LimparFotos()

    End Sub

    Private Sub ExportarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportarToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        ExportaWeb()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ActualizarPVPToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ActualizarPVPToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        ActualizaPVPWeb()
        ActualizaLigacao("CelfGest")
        Me.Cursor = Cursors.Default
        MsgBox("Preços Web Actualizados com sucesso!")

    End Sub

    Private Sub ActualizarTamanhosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ActualizarTamanhosToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        ActualizaTamWeb()
        ActualizaLigacao("CelfGest")
        Me.Cursor = Cursors.Default
        MsgBox("Tamanhos Web Actualizados com sucesso!")


    End Sub



    Private Sub EncClientesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EncClientesToolStripMenuItem.Click

        frmManutEncClientes.MdiParent = Me
        frmManutEncClientes.WindowState = FormWindowState.Maximized
        frmManutEncClientes.Show()

    End Sub

    Private Sub ActualizarMarcaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarMarcaToolStripMenuItem.Click



        Me.Cursor = Cursors.WaitCursor
        ActualizaMarcaWeb()
        ActualizaLigacao("CelfGest")
        Me.Cursor = Cursors.Default




    End Sub

    Private Sub VelocidadeCpuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VelocidadeCpuToolStripMenuItem.Click






    End Sub

    Private Sub UploadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadToolStripMenuItem.Click




    End Sub

    Private Sub criarCopias() Handles MenuStrip1.MouseClick


        Try
            Me.Cursor = Cursors.WaitCursor

            'Copiasbd()

            Me.Cursor = Cursors.Default

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Teste1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Teste1ToolStripMenuItem.Click



        Dim filepath As String = "C:\Girl\logtime.xml"
        If Not System.IO.File.Exists(filepath) Then
            System.IO.File.Create(filepath).Dispose()
        End If

        Dim xmldoc As XmlDocument = New XmlDocument()
        xmldoc.Load("C:\Girl\logtime.xml")

        Dim xmlRoot As XmlElement = xmldoc.SelectSingleNode("/main")
        Dim xmlChild As XmlElement = xmldoc.CreateElement("sub")

        xmlChild.InnerText = "asp"
        xmlRoot.AppendChild(xmlChild)

        xmldoc.Save("C:\Girl\logtime.xml")



        'Dim i As Integer

        'Dim objWriter As New System.IO.StreamWriter("C:\Girl\logtime.xml", True)

        'For i = 1 To 10
        '    objWriter.WriteLine(Format(Now, "yyyy/MM/dd hh.mm.ss.fff tt"))
        'Next
        'objWriter.Close()





        'If (File.Exists(myXMLLog)) Then
        '                {              
        '        XDocument xmldoc = XDocument.Load(myXMLLog);
        '        XElement root = New XElement("Batch",
        '            New XAttribute("ID", BatchID),
        '            New XAttribute("Date", Now),
        '            New XElement("Step",
        '                New XElement("Name", step),
        '                New XElement("Success", success),
        '                New XElement("Message", Message),
        '                New XElement("Transaction",
        '                    New XAttribute("IDTrans", transID),
        '                    New XAttribute("Details", details))));
        '        xmldoc.Root.Add(root);
        '        xmldoc.Save(myXMLLog);
        '    }
        '    Else
        '    {
        '        Using (XmlWriter writer = XmlWriter.Create(myXMLLog, settings))
        '        {
        '            writer.WriteStartDocument();
        '            writer.WriteComment("This log was created by the Application.");
        '            writer.WriteStartElement("Root");
        '            writer.WriteStartElement("Batch");
        '            writer.WriteAttributeString("ID", BatchID);
        '            writer.WriteAttributeString("Date", Now);
        '            writer.WriteStartElement("Step");
        '            writer.WriteElementString("Name", step);
        '            writer.WriteElementString("Success", success);
        '            writer.WriteElementString("Message", Message);
        '            writer.WriteStartElement("Transaction");
        '            writer.WriteElementString("IDTrans", transID);
        '            writer.WriteElementString("Details", details);
        '            writer.WriteEndElement();
        '            writer.Flush();
        '            writer.WriteEndDocument();
        '        }
        '    }




        'MsgBox(Format(Now, "yyyy/MM/dd hh.mm.ss.fff tt"))



    End Sub

    Private Sub Teste2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Teste2ToolStripMenuItem.Click


        SendKeys.Send("{PRTSC}")
        Dim Screenshot As Image = Clipboard.GetImage()
        Screenshot.Save("c:\ScreenShot.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)


    End Sub

    Private Sub Teste3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Teste3ToolStripMenuItem.Click

        Dim bm As New Bitmap(Width, Height)
        DrawToBitmap(bm, New Rectangle(0, 0, Width, Height))
        Dim name As String = InputBox("Name it:")
        bm.Save(Application.StartupPath & "\ScreenShot\" & name & ".png", System.Drawing.Imaging.ImageFormat.Png)

    End Sub

    Private Sub TestarQRCODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestarQRCODEToolStripMenuItem.Click



    End Sub

    Private Sub QrcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QrcodeToolStripMenuItem.Click


        frmQrCode.MdiParent = Me
        frmQrCode.StartPosition = FormStartPosition.CenterScreen
        frmQrCode.WindowState = FormWindowState.Normal
        frmQrCode.Show()


    End Sub

End Class



