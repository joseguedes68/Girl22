
Imports System.Data.SqlClient
Imports System.Text
Imports C1.Win.C1FlexGrid



Public Class frmStockFoto



    Dim Pic(29) As PictureBox
    Dim Foto() As String
    Dim Pagina As Integer = 1
    Dim xModelo As String = ""
    Dim xGrupo As String = ""
    Dim xTipo As String = ""
    Dim xCor As String = ""
    Dim xAltura As String = ""
    Dim xTamanho As String = ""
    Dim xForn As String = ""
    Dim xRefForn As String = ""
    Dim xPrVnd As String
    Dim frm As New Form
    Dim BotaoPesquisa As String
    Dim WithEvents Dgrid As New DataGridView
    Dim TipoZoom As Boolean
    Dim _Pic As PictureBox
    Dim xLoad As Boolean = True
    Dim xGeral As Boolean
    Dim xZoom As Boolean = False
    Dim dtArmazens As New DataTable
    Dim xEnc As Boolean = False
    Dim uIdDocCabSinal As String = "Null"
    Dim xMarca As String

    Dim sClienteLojaIdAux As String
    Dim sNIFAux As String






    Private Sub frmStockFoto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: esta linha de código carrega dados na tabela 'GirlDataSet.Marcas'. Você pode movê-la ou removê-la conforme necessário.
        Me.MarcasTableAdapter.Fill(Me.GirlDataSet.Marcas)
        Dim Val As New clsValidacoes(Me.Name)
        Try


            If permite_emitir_docs() = False Then
                tbSinal.Visible = False
                lbSinal.Visible = False
                rbDinheiro.Visible = False
                rbMB.Visible = False
            End If

            TableLayoutPanel1.Visible = False
            TableLayoutPanel3.Visible = False
            btdetalhe.Visible = False


            lbPrecoPromocao.Visible = False
            Me.btPromocao.Text = "Promoções"

            Pic(0) = Me.PictureBox1
            Pic(1) = Me.PictureBox2
            Pic(2) = Me.PictureBox3
            Pic(3) = Me.PictureBox4
            Pic(4) = Me.PictureBox5
            Pic(5) = Me.PictureBox6
            Pic(6) = Me.PictureBox7
            Pic(7) = Me.PictureBox8
            Pic(8) = Me.PictureBox9
            Pic(9) = Me.PictureBox10
            Pic(10) = Me.PictureBox11
            Pic(11) = Me.PictureBox12
            Pic(12) = Me.PictureBox13
            Pic(13) = Me.PictureBox14
            Pic(14) = Me.PictureBox15
            Pic(15) = Me.PictureBox16
            Pic(16) = Me.PictureBox17
            Pic(17) = Me.PictureBox18
            Pic(18) = Me.PictureBox19
            Pic(19) = Me.PictureBox20
            Pic(20) = Me.PictureBox21
            Pic(21) = Me.PictureBox22
            Pic(22) = Me.PictureBox23
            Pic(23) = Me.PictureBox24
            Pic(24) = Me.PictureBox25
            Pic(25) = Me.PictureBox26
            Pic(26) = Me.PictureBox27
            Pic(27) = Me.PictureBox28
            Pic(28) = Me.PictureBox29
            Pic(29) = Me.PictureBox30

            For I As Int16 = 0 To Pic.Length - 1
                Pic(I).SizeMode = PictureBoxSizeMode.Zoom
                AddHandler Pic(I).Click, AddressOf Object_Click
                AddHandler Pic(I).MouseDown, AddressOf Object_MouseDown
            Next

            PictureBoxZoom.Cursor = Cursors.WaitCursor
            CFGDet.Visible = False
            cbVerTodos.Visible = False
            lblArtigo.Visible = False
            lbReserva.Visible = True
            tbReserva.Visible = True
            btGravaReserva.Visible = True
            xLoad = False

            PanelReservas.Visible = Val.ValidarPermicoes("PanelReservas")
            lbReserva.Visible = Val.ValidarPermicoes("lbReserva")
            tbReserva.MaxLength = 60
            PanelStock.Visible = False
            PanelReservas.Visible = False
            pTalao.Visible = False


            If xAplicacao = "POS" Then
                pVendas.Visible = False
                btGeral.Visible = True
                lbForn.Visible = False
                lbRefForn.Visible = False
                txtForn.Visible = False
                txtRefForn.Visible = False
                cmdPesqForn.Visible = False
                PanelReservas.Visible = True
                btEncomendas.Visible = False
                pTalao.Visible = True
                btStkArmz.Visible = False
                btStockGeral.Visible = True
                BtStockLoja.Visible = True
                cbArmazem.Visible = False
                cbMarcas.Visible = False

            Else
                btStkArmz.Visible = True
                btStockGeral.Visible = False
                BtStockLoja.Visible = False
                cbArmazem.Visible = True

            End If

            If bAtrai = True Then
                'PanelStock.Visible = False
                pTalao.Visible = False
                PanelReservas.Visible = False
                lbPrecoPromocao.Visible = False
                cbVerTodos.Visible = False
                btPromocao.Visible = False
                pVendas.Visible = True
                btEncomendas.Visible = False
                btGeral.Visible = False
                lbRefForn.Visible = True
                txtRefForn.Visible = True



            End If


            'CARREGAR ARMAZENS

            If xAplicacao = "POS" And bAtrai = False Then
                Sql = "SELECT ArmazemID, rtrim(ArmazemID) + ' - ' + rtrim(ArmAbrev) as Destino from Armazens WHERE ARMAZEMID='" & xArmz & "'"
            Else
                Sql = "SELECT ArmazemID, RTRIM(ArmazemID) + ' - ' + RTRIM(ArmAbrev) AS Destino
                FROM     Armazens
                WHERE  (Activo = 1)"
            End If

            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtArmazens)
            dtArmazens.Rows.Add("%", "Todas as Lojas")
            Me.cbArmazem.DataSource = dtArmazens
            Me.cbArmazem.DisplayMember = "Destino"
            Me.cbArmazem.ValueMember = "ArmazemID"

            Me.MarcasTableAdapter.Fill(Me.GirlDataSet.Marcas)
            Me.GirlDataSet.Marcas.AddMarcasRow(0, "Todas as Marcas")
            Me.cbMarcas.SelectedValue = 0


            If xAplicacao = "POS" And bAtrai = False Then
                Me.cbArmazem.SelectedValue = xArmz
            Else
                Me.cbArmazem.SelectedValue = "%"
            End If

            DataVenda.Text = Today()
            Me.txtModelo.Focus()

            sIDClienteLoja = ""
            ActualizarClienteLoja(sIDClienteLoja, sClienteLojaIdAux, lbCliente.Text, sNIFAux)

            Application.DoEvents()

            TableLayoutPanel1.Visible = True
            TableLayoutPanel3.Visible = True

            rbDinheiro.Checked = True
            tbSinal.Text = ""

            ActualizarNavegador()

            If bLojaConsignacao Then
                lbSinal.Visible = False
                tbSinal.Visible = False
                rbDinheiro.Visible = False
                rbMB.Visible = False
            End If


        Catch ex As Exception
        Finally
            If Val IsNot Nothing Then Val.Dispose()
            Val = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ActualizarNavegador()
        Try
            If Not Foto Is Nothing Then
                Me.ToolStripCmds.Visible = True
                Me.ToolStripCmds.Enabled = True
                If Foto.Length / 30 = Int(Foto.Length / 30) Then
                    Me.lblContador.Text = Pagina.ToString + " / " + (Foto.Length / 30).ToString
                Else
                    Me.lblContador.Text = Pagina.ToString + " / " + CType((Foto.Length / 30).ToString.Substring(0, (Foto.Length / 30).ToString.IndexOf(".")) + 1, Int16).ToString
                End If
            Else
                Me.ToolStripCmds.Visible = False
            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " ActualizarNavegador")
        End Try
    End Sub

    Private Sub tbSinal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tbSinal.Validating
        If Not IsNumeric(tbSinal.Text) Then
            If Len(tbSinal.Text) <> 0 Then
                MsgBox("Valor de Sinal inválido!")
                tbSinal.Text = ""
            End If
        Else
            tbSinal.Text = tbSinal.Text * 1
        End If
    End Sub

    'Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
    '    Dim db As New ClsSqlBDados
    '    Dim dr As System.Data.SqlClient.SqlDataReader
    '    Dim I As Integer = 0
    '    CFGDet.Visible = False
    '    cbVerTodos.Visible = False
    '    Try
    '        FazerRefresh()
    '        xGrupo = Me.txtGrupo.Text
    '        xTipo = Me.txtTipo.Text
    '        xCor = Me.txtCor.Text
    '        xAltura = Me.txtAltura.Text
    '        xModelo = Me.txtModelo.Text
    '        xTamanho = Me.txtTamanho.Text
    '        Me.lblArtigo.Text = Nothing
    '        For I1 As Integer = 0 To Pic.Length - 1
    '            Pic(I1).BorderStyle = BorderStyle.None
    '            Pic(I1).BackColor = Color.Transparent
    '        Next
    '        If xCor.Length > 0 Then
    '            If xTamanho.Length > 0 Then
    '                Sql = "SELECT ModeloID + CorID Foto FROM ModeloCor " & _
    '                      "WHERE ModeloID in (SELECT ModeloID FROM Modelos " + GerarFiltro() + ")  " & _
    '                      "AND CorID = '" + xCor + "'  " & _
    '                      "AND ModeloID + CorID in (SELECT DISTINCT ModeloID + CorID FROM Serie WHERE TamID ='" + xTamanho + "' AND EstadoID = 'S') " & _
    '                      "ORDER BY ModeloID + CorID DESC"
    '            Else
    '                Sql = "SELECT ModeloID + CorID Foto FROM ModeloCor " & _
    '                                      "WHERE ModeloID in (SELECT ModeloID FROM Modelos " + GerarFiltro() + ") " & _
    '                                      "AND CorID = '" + xCor + "' ORDER BY ModeloID + CorID DESC"
    '            End If
    '        Else
    '            If xTamanho.Length > 0 Then
    '                Sql = "SELECT ModeloID + CorID Foto " & _
    '                      "FROM ModeloCor  " & _
    '                      "WHERE ModeloID in (SELECT ModeloID FROM Modelos " + GerarFiltro() + ")  " & _
    '                      "AND ModeloID + CorID in (SELECT DISTINCT ModeloID + CorID FROM Serie WHERE TamID ='" + xTamanho + "' AND EstadoID = 'S') " & _
    '                      "ORDER BY ModeloID + CorID DESC"
    '            Else
    '                Sql = "SELECT ModeloID + CorID Foto FROM ModeloCor " & _
    '                                      "WHERE ModeloID in (SELECT ModeloID FROM Modelos " + GerarFiltro() + ") ORDER BY ModeloID + CorID DESC"
    '            End If

    '        End If

    '        dr = db.GetData(Sql)
    '        If Not dr.IsClosed Then
    '            If dr.HasRows Then
    '                Do While dr.Read
    '                    If Not Foto Is Nothing Then
    '                        Array.Resize(Foto, Foto.Length + 1)
    '                    Else
    '                        Array.Resize(Foto, 1)
    '                    End If
    '                    Foto(I) = dr("Foto").ToString
    '                    I += 1
    '                Loop
    '            Else
    '                FazerRefresh()
    '                ActualizarNavegador()
    '                MsgBox("Sem dados para apresentar!", MsgBoxStyle.Information)
    '            End If
    '        End If
    '        CarregarFotos()
    '        ActualizarNavegador()
    '    Catch ex As Exception
    '        ErroVB(ex.Message, Me.Name + " cmdPesquisar_Click")
    '    End Try
    'End Sub

    Private Function GerarFiltro() As String
        Dim sQuery As String = ""
        If xGrupo.Length > 0 Then
            If xGrupo.IndexOf(",") > 0 Then
                sQuery += " WHERE GrupoID IN ('" + xGrupo.Substring(0, xGrupo.IndexOf(",")) + "','" + xGrupo.Substring(xGrupo.IndexOf(",") + 1) + "')"
            Else
                sQuery += " WHERE GrupoID = '" + xGrupo + "' "
            End If
        End If
        If xTipo.Length > 0 Then
            If sQuery.Length > 0 Then
                If xTipo.IndexOf(",") > 0 Then
                    sQuery += " AND TipoID IN ('" + xTipo.Substring(0, xTipo.IndexOf(",")) + "','" + xTipo.Substring(xTipo.IndexOf(",") + 1) + "')"
                Else
                    sQuery += " AND TipoID = '" + xTipo + "' "
                End If
            Else
                If xTipo.IndexOf(",") > 0 Then
                    sQuery += " WHERE TipoID IN ('" + xTipo.Substring(0, xTipo.IndexOf(",")) + "','" + xTipo.Substring(xTipo.IndexOf(",") + 1) + "')"
                Else
                    sQuery += " WHERE TipoID = '" + xTipo + "' "
                End If
            End If
        End If
        If xAltura.Length > 0 Then
            If sQuery.Length > 0 Then
                If xAltura.IndexOf("..") > 0 Then
                    sQuery += " AND Altura BETWEEN '" + xAltura.Substring(0, xAltura.IndexOf("..")) + "' AND '" + xAltura.Substring(xAltura.IndexOf("..") + 2) + "' "
                Else
                    sQuery += " AND Altura = '" + xAltura + "' "
                End If
            Else
                If xAltura.IndexOf("..") > 0 Then
                    sQuery += " WHERE Altura BETWEEN '" + xAltura.Substring(0, xAltura.IndexOf("..")) + "' AND '" + xAltura.Substring(xAltura.IndexOf("..") + 2) + "' "
                Else
                    sQuery += " WHERE Altura = '" + xAltura + "' "
                End If
            End If
        End If
        If xModelo.Length > 0 Then
            If sQuery.Length > 0 Then
                sQuery += " AND ModeloID = '" + xModelo + "' "
            Else
                sQuery += " WHERE ModeloID = '" + xModelo + "' "
            End If
        End If

        If cbMarcas.SelectedValue <> 0 Then
            If sQuery.Length > 0 Then
                sQuery += " AND MarcaID = " + cbMarcas.SelectedValue.ToString
            Else
                sQuery += " WHERE MarcaID = " + cbMarcas.SelectedValue.ToString
            End If
        End If

        Return sQuery
    End Function

    Private Sub CarregarFotos()
        Dim F As New ClsFotos
        Try
            For I As Int16 = 0 To 29
                If xEnc = True Then
                    F.CarregarFotoAmostra(Pic(I), Foto(I + ((Pagina - 1) * 30)), "Xok")
                Else
                    F.CarregarFotoModeloCor(Pic(I), Foto(I + ((Pagina - 1) * 30)), "Xok")
                End If

                Pic(I).Tag = Foto(I + ((Pagina - 1) * 30))
            Next
        Catch ex As Exception
            If Not F Is Nothing Then F.Dispose()
            F = Nothing
        End Try
    End Sub

    Private Sub Object_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim F As New ClsFotos
        Try


            Me.txtRModelo.Enabled = True
            Me.txtRCor.Enabled = True
            Me.txtRTam.Enabled = True
            Me.tbTalao.Enabled = True

            PanelStock.Visible = False
            'Dim _Pic As PictureBox
            _Pic = CType(sender, PictureBox)

            If _Pic.Tag Is Nothing Then Exit Sub

            If xEnc = False Then
                'CarregarDadosModeloCor(_Pic.Tag)
                If xZoom = True Then
                    If _Pic.Tag.ToString.Length > 0 Then
                        F.CarregarFotoModeloCor(PictureBoxZoom, _Pic.Tag)
                        If Me.PictureBoxZoom.Image IsNot Nothing Then
                            AcertarPaineis(True)
                        Else
                            AcertarPaineis(False)
                        End If

                    End If
                Else
                    For I As Integer = 0 To Pic.Length - 1
                        Pic(I).BorderStyle = BorderStyle.None
                        Pic(I).BackColor = Color.Transparent
                    Next
                    _Pic.BorderStyle = BorderStyle.Fixed3D
                    _Pic.BackColor = Color.Red
                End If
                CarregarDadosModeloCor(_Pic.Tag)
            Else
                MsgBox(_Pic.Tag)
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " Object_Click")
        Finally
            If Not F Is Nothing Then F.Dispose()
            F = Nothing
        End Try
    End Sub

    Private Sub Object_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Try



            If e.Button = Windows.Forms.MouseButtons.Left Then
                TipoZoom = False
                xZoom = False
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                TipoZoom = True
                xZoom = True
            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub CarregarDadosModeloCor(ByVal xModeloCor As String)
        Dim db As New ClsSqlBDados
        Dim lblModelo As String
        Dim lblCor As String
        Dim dPv As Double
        Dim dPEtiq As Double

        Try



            If Me.tbReserva.Text.Length > 0 Then
                If MsgBox("Quer Gravar a Reserva ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    GravarReserva()
                End If
                Me.tbReserva.Text = ""
            End If

            lblModelo = Microsoft.VisualBasic.Left(xModeloCor, 5)
            lblCor = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(xModeloCor, 7), 2)

            frmStockLoja.xModelo = lblModelo
            frmStockLoja.xCor = lblCor

            Sql = "SELECT PrVnd FROM MODELOCOR where Modeloid = '" + lblModelo + "' and Corid = '" + lblCor + "'"
            dPEtiq = db.GetDataValue(Sql)


            'Sql = "SELECT RefForn FROM MODELOCOR where Modeloid = '" + lblModelo + "' and Corid = '" + lblCor + "'"
            'xRefForn = db.GetDataValue(Sql)

            'Sql = "SELECT CorForn FROM MODELOCOR where Modeloid = '" + lblModelo + "' and Corid = '" + lblCor + "'"
            'xCorForn = db.GetDataValue(Sql)


            'TODO: ALTERAR ESTA FORMA DE IR BUSCAR O PREÇO ACTUAL???
            Sql = "SELECT isnull(MAX(PrecoVenda),0) AS PV FROM Serie WHERE (ArmazemID = '" & xArmz & "') AND (ModeloID = '" + lblModelo + "') AND (CorID = '" + lblCor + "') AND ESTADOID IN ('S','T')"
            dPv = db.GetDataValue(Sql)


            'Me.lblArtigo.Text = "Foto: " + Microsoft.VisualBasic.Left(xModeloCor, 5) + " Cor: " + Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(xModeloCor, 7), 2) + "  Preço: " + Format(dPEtiq, "0.00").ToString + "€"
            Me.lblArtigo.Text = "Foto: " + Microsoft.VisualBasic.Left(xModeloCor, 5) + " Cor: " + Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(xModeloCor, 7), 2)

            Me.lblPEtiq.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPEtiq.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblPEtiq.Text = FormatCurrency(dPEtiq).ToString

            If dPv = dPEtiq Then

                'Me.lblPVP.Location = New System.Drawing.Point(225, 10)
                'Me.lblPVP.Size = New System.Drawing.Size(49, 22)

                Me.lblPEtiq.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblPSaldo.Visible = False

            Else

                Me.lblPEtiq.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Strikeout), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblPEtiq.ForeColor = Color.Red

                lblPSaldo.Visible = True
                'lblPSaldo.Text = Format(dPv, "0.00").ToString + "€"
                lblPSaldo.Text = FormatCurrency(dPv).ToString

            End If

            Me.lblArtigo.Visible = True
            Me.lblPVP.Visible = True
            lbReserva.Visible = True
            tbReserva.Visible = True
            btGravaReserva.Visible = True
            Me.txtRModelo.Text = lblModelo
            Me.txtRCor.Text = lblCor





            'lblArtigo.Visible = False
            'lbReserva.Visible = True
            'tbReserva.Visible = True
            'btGravaReserva.Visible = False


            'CARREGAR FLEX GRID SE POS

            If xAplicacao = "POS" Then
                CarregarCFGDet(xModeloCor)

            Else
                If xZoom = False Then
                    'Dim frm As New frmStockLoja
                    frmStockLoja.StartPosition = FormStartPosition.CenterParent
                    frmStockLoja.WindowState = FormWindowState.Normal
                    frmStockLoja.ShowInTaskbar = False
                    frmStockLoja.MaximizeBox = False
                    frmStockLoja.MinimizeBox = False
                    frmStockLoja.ShowDialog(Me)
                End If
            End If


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " Object_DoubleClick")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub Object_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim F As New ClsFotos
        Try
            Dim _Pic As PictureBox
            _Pic = CType(sender, PictureBox)
            If _Pic.Tag.ToString.Length > 0 Then
                F.CarregarFotoModeloCor(PictureBoxZoom, _Pic.Tag)
                AcertarPaineis(True)
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " Object_DoubleClick")
        Finally
            If Not F Is Nothing Then F.Dispose()
            F = Nothing
        End Try
    End Sub

    Private Sub AcertarPaineis(ByVal Zoom As Boolean)
        Me.Panel2.Location = Me.Panel1.Location
        Me.Panel2.Size = Me.Panel1.Size
        Me.Panel2.Anchor = Me.Panel1.Anchor
        Me.Panel1.Visible = Not Zoom
        Me.Panel2.Visible = Zoom
    End Sub

    Private Sub PictureBoxZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxZoom.Click
        AcertarPaineis(False)
    End Sub

    Private Sub Pesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesqGrupo.Click, cmdPesqCor.Click, cmdPesqTipo.Click, cmdPesqForn.Click

        Dim dt As New DataTable
        Dim _cmd As Button
        Dim db As New ClsSqlBDados
        Try
            frm = New Form
            Dgrid = New DataGridView
            _cmd = CType(sender, Button)
            BotaoPesquisa = _cmd.Name
            Select Case BotaoPesquisa
                Case "cmdPesqGrupo"
                    Sql = "SELECT GrupoID Cod, GrupoDesc Descricao FROM Grupos order by GrupoDesc"
                Case "cmdPesqCor"
                    Sql = "SELECT CorID Cod, DescrCor Descricao FROM Cores order by DescrCor"
                Case "cmdPesqTipo"
                    Sql = "SELECT TipoID Cod, DescrTipo Descricao FROM Tipos order by Ordem"
                Case "cmdPesqForn"
                    Sql = "SELECT TERCID,NOMEABREV FROM TERCEIROS WHERE TIPOTERC='F' ORDER BY NOMEABREV"
                Case "cmdPesqMarca"
                    Sql = "SELECT MarcaID,MarcaDescr FROM MARCAS ORDER BY MARCADESCR"
            End Select
            db.GetData(Sql, dt)
            With Dgrid
                .DataSource = dt
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .Dock = DockStyle.Fill
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .ReadOnly = True
                .ColumnHeadersHeight = 55

                For c As Integer = 0 To Dgrid.Columns.Count - 1
                    With .Columns(c)

                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .ReadOnly = True
                        .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .HeaderCell.Style.Font = New Font("Arial", 10, FontStyle.Bold)


                    End With
                Next
                .AutoSize = True




            End With
            With frm
                .Width = 800
                .Height = 550

                .StartPosition = FormStartPosition.CenterParent
                .MinimizeBox = False
                .MaximizeBox = False
                .Controls.Add(Dgrid)
                Dgrid.RowHeadersWidth = 70


                Dim Dgrid1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

                Dgrid1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
                Dgrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.Dgrid.AlternatingRowsDefaultCellStyle = Dgrid1
                .Font = Dgrid1.Font

                Dgrid.RowTemplate.Height = 35
                'Dim row As DataGridViewRow = Dgrid.Rows(0)
                'row.Height = 15


                .ShowDialog(Me)






            End With
            'AddHandler Dgrid.Click, AddressOf Dgrid_Click
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " Pesquisar_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub lbCliente_TextChanged(sender As Object, e As System.EventArgs) Handles lbCliente.TextChanged


        Try

            Dim xReserva As String = Trim(Me.tbReserva.Text) & Trim(Me.txtRModelo.Text) & Trim(Me.txtRCor.Text) & Trim(Me.txtRTam.Text)

            If xReserva.Length > 0 Then
                If Not (lbCliente.Text = "Dados Cliente" Or lbCliente.Text = "Consumidor Final" Or lbCliente.Text = "Cliente Ocasional") Then
                    If MsgBox("Gravar Reserva?", MsgBoxStyle.OkCancel, "Gravar Reserva") = MsgBoxResult.Ok Then
                        btGravaReserva_Click(sender, e)
                    End If
                End If
            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " lbCliente_TextChanged")
        End Try


    End Sub


    'dgrid

    'Private Sub Dgrid_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Dgrid.CellPainting
    '    If e.RowIndex > -1 Then
    '        Dgrid.Rows(e.RowIndex).Height = 50
    '    End If
    'End Sub

    Private Sub Dgrid_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgrid.CellClick
        'ALTEREI CellDoubleClick POR CellClick
        Dim _Dgrid As New DataGridView
        Try
            _Dgrid = CType(sender, DataGridView)
            ConstroiFiltro(_Dgrid(0, _Dgrid.CurrentCell.RowIndex).Value)
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " Pesquisar_Click")
        Finally
            If Not frm Is Nothing Then frm.Dispose()
            frm = Nothing
            If Not _Dgrid Is Nothing Then _Dgrid.Dispose()
            _Dgrid = Nothing
        End Try
    End Sub

    Private Sub ConstroiFiltro(ByVal CodArtigo As String)
        Select Case BotaoPesquisa
            Case "cmdPesqGrupo"
                If Me.txtGrupo.Text.Length > 0 Then
                    Me.txtGrupo.Text += "," + CodArtigo
                Else
                    Me.txtGrupo.Text = CodArtigo
                End If
            Case "cmdPesqCor"

                Me.txtCor.Text = CodArtigo

                'If Me.txtCor.Text.Length > 0 Then
                '    Me.txtCor.Text += "," + CodArtigo
                'Else
                '    Me.txtCor.Text = CodArtigo
                'End If
            Case "cmdPesqTipo"
                If Me.txtTipo.Text.Length > 0 Then
                    Me.txtTipo.Text += "," + CodArtigo
                Else
                    Me.txtTipo.Text = CodArtigo
                End If

            Case "cmdPesqForn"
                Me.txtForn.Text = CodArtigo



        End Select
    End Sub

    Private Sub rbDinheiro_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbDinheiro.CheckedChanged
        Try

            If rbDinheiro.Checked = True Then
                rbMB.Checked = False
            Else
                rbMB.Checked = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbMB_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbMB.CheckedChanged

        Try

            If rbMB.Checked = True Then
                rbDinheiro.Checked = False
            Else
                rbDinheiro.Checked = True
            End If


        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdRetroceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRetroceder.Click

        Try


            For I1 As Integer = 0 To Pic.Length - 1
                Pic(I1).BorderStyle = BorderStyle.None
                Pic(I1).BackColor = Color.Transparent
            Next
            If Pagina > 1 Then
                LimparFotos()
                Pagina -= 1
                CarregarFotos()
                ActualizarNavegador()
            End If


        Catch ex As Exception
            ErroVB(ex.Message, "cmdRetroceder_Click")
        End Try

    End Sub

    Private Sub cmdAvancar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAvancar.Click


        Try



            For I1 As Integer = 0 To Pic.Length - 1
                Pic(I1).BorderStyle = BorderStyle.None
                Pic(I1).BackColor = Color.Transparent
            Next

            If Foto Is Nothing Then Exit Sub
            If Foto.Length / 30 = Int(Foto.Length / 30) Then
                If Pagina < (Foto.Length / 30).ToString Then
                    LimparFotos()
                    Pagina += 1
                    CarregarFotos()
                    ActualizarNavegador()
                End If
            Else
                If Pagina < CType((Foto.Length / 30).ToString.Substring(0, (Foto.Length / 30).ToString.IndexOf(".")) + 1, Int16) Then
                    LimparFotos()
                    Pagina += 1
                    CarregarFotos()
                    ActualizarNavegador()
                End If
            End If


        Catch ex As Exception
            ErroVB(ex.Message, "cmdAvancar_Click")
        End Try

    End Sub

    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click


        Try

            For I1 As Integer = 0 To Pic.Length - 1
                Pic(I1).BorderStyle = BorderStyle.None
                Pic(I1).BackColor = Color.Transparent
            Next
            LimparFotos()
            If Foto Is Nothing Then Exit Sub
            If Foto.Length / 30 = Int(Foto.Length / 30) Then
                Pagina = (Foto.Length / 30).ToString
            Else
                Pagina = CType((Foto.Length / 30).ToString.Substring(0, (Foto.Length / 30).ToString.IndexOf(".")) + 1, Int16).ToString
            End If
            CarregarFotos()
            ActualizarNavegador()


        Catch ex As Exception
            ErroVB(ex.Message, "cmdUltimo_Click")
        End Try

    End Sub

    Private Sub cmdPrimeiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrimeiro.Click


        Try

            For I1 As Integer = 0 To Pic.Length - 1
                Pic(I1).BorderStyle = BorderStyle.None
                Pic(I1).BackColor = Color.Transparent
            Next
            LimparFotos()
            Pagina = 1
            CarregarFotos()
            ActualizarNavegador()

        Catch ex As Exception
            ErroVB(ex.Message, "cmdPrimeiro_Click")
        End Try

    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
        'ActualizaLigacao("CelfGest")
    End Sub

    Private Sub btGravaReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGravaReserva.Click


        Try


            Dim sFormaPagamento As String = ""
            Dim sNIFAux As String = ""
            Dim sClienteLojaIdAux As String = ""

            If sIDClienteLoja = "" And Len(Trim(txtRModelo.Text)) > 0 Then
                MsgBox("Selecione o Cliente!", , "Aviso!!")
                Exit Sub
            End If

            If Len(tbSinal.Text) > 0 Then

                If IsNumeric(tbSinal.Text) And Val(tbSinal.Text) > 0 Then

                    If rbDinheiro.Checked = False And rbMB.Checked = False Then
                        MsgBox("Seleccione a forma de pagamento!", , "Aviso!!")
                        Exit Sub
                    Else
                        If rbDinheiro.Checked = True Then sFormaPagamento = "Dinheiro"
                        If rbMB.Checked = True Then sFormaPagamento = "MB"
                    End If

                    If Val(tbSinal.Text) > 99 Then
                        MsgBox("Não é possivel sinais com valor superior a 99€!", , "Aviso!!")
                        Exit Sub
                    Else
                        If MsgBox("Confirma que o Cliente " & lbCliente.Text & " fez um adiantamento no valor de " & tbSinal.Text & "€ a " & sFormaPagamento & "?", MsgBoxStyle.YesNo, "Adiantamento") = MsgBoxResult.Yes Then
                            If GravarSinal() = False Then
                                MsgBox("Erro na gravação do Sinal!!")
                                EnviarEmail("Erro na gravação do Sinal!!", "", "")
                                Exit Sub
                            End If
                        Else
                            MsgBox("A Reserva não está gravada!", , "Aviso!!")
                            Exit Sub
                        End If
                    End If
                Else
                    MsgBox("Valor de Sinal inválido!", , "Aviso!!")
                    Exit Sub
                End If

            Else

                tbSinal.Text = "0"

            End If


            GravarReserva()
            InicializaReserva()



        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " Pesquisar_Click")
        Finally
            uIdDocCabSinal = "Null"
        End Try

    End Sub

    Private Sub cbVerTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVerTodos.CheckedChanged
        If xLoad = False Then CarregarDadosModeloCor(_Pic.Tag)
    End Sub

    Private Sub btEditaReservas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditaReservas.Click


        Dim frm As New frmReservas
        'frm.MdiParent = Me
        'frm.WindowState = FormWindowState.Maximized
        'frm.Show()


        'frmReservas.MdiParent = Me
        'frmReservas.WindowState = FormWindowState.Maximized
        'frmReservas.Show()


        xEditaReserva = True
        frm.StartPosition = FormStartPosition.CenterParent
        frm.WindowState = FormWindowState.Normal
        'frmReservas.Width = 900
        'frmReservas.Height = 620
        frm.ShowInTaskbar = False
        frm.MaximizeBox = False
        frm.MinimizeBox = False
        frm.ShowDialog(Me)
    End Sub

    Private Sub CarregarDados(ByVal TipoDados As String)


        Dim db As New ClsSqlBDados
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim I As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        CFGDet.Visible = False
        cbVerTodos.Visible = False

        Try



            If SistemaBloqueado() = True Then
                Exit Sub
            End If


            FazerRefresh()
            xGrupo = Trim(Me.txtGrupo.Text)
            xTipo = Trim(Me.txtTipo.Text)
            xCor = Trim(Me.txtCor.Text)
            xAltura = Trim(Me.txtAltura.Text)
            xModelo = Trim(Me.txtModelo.Text)
            xTamanho = Trim(Me.txtTamanho.Text)
            xForn = Trim(Me.txtForn.Text)
            xRefForn = Trim(Me.txtRefForn.Text)
            xPrVnd = Trim(Me.txtPreco.Text)


            Dim xArmzAuxFiltro As String = xArmz
            Me.lblArtigo.Text = Nothing
            'LIMPAR FOTOS
            For I1 As Integer = 0 To Pic.Length - 1
                Pic(I1).BorderStyle = BorderStyle.None
                Pic(I1).BackColor = Color.Transparent
            Next

            If xCor.Length = 0 Then xCor = "%"
            If xTamanho.Length = 0 Then xTamanho = "%"

            If xForn.Length = 0 Then xForn = "%"
            If xRefForn.Length = 0 Then xRefForn = "%"

            If bAtrai = True Then xForn = "1016"




            If TipoDados = "Stock" Then

                Dim sfiltropreco As String = ""
                If Len(xPrVnd) <> 0 Then
                    sfiltropreco = "AND PrecoVenda='" + xPrVnd + "' "
                End If

                'Sql = "SELECT DISTINCT ModeloID + CorID Foto FROM Serie " &
                ' "WHERE ArmazemID like '" + cbArmazem.SelectedValue.ToString + "' " &
                ' "AND ModeloID in (SELECT ModeloID FROM Modelos " + GerarFiltro() + ") " &
                ' "AND ModeloID in (SELECT DISTINCT MODELOID FROM MODELOCOR WHERE FORNID LIKE '" + xForn + "' AND RTRIM(REFFORN) LIKE '" + xRefForn + "') " &
                ' "AND CorID like '" + xCor + "'  " &
                ' "AND TamID like '" + xTamanho + "' " &
                ' "AND EstadoID in ('S','T') " & sfiltropreco &
                ' "ORDER BY Foto DESC"


                Sql = "SELECT DISTINCT Serie.ModeloID + Serie.CorID AS Foto, Tipos.Ordem
                    FROM     Serie INNER JOIN
                    Modelos ON Serie.ModeloID = Modelos.ModeloID INNER JOIN
                    Tipos ON Modelos.TipoID = Tipos.TipoId
                    WHERE  (Serie.ArmazemID LIKE '" + cbArmazem.SelectedValue.ToString + "') AND (Serie.ModeloID IN
                    (SELECT ModeloID
                    FROM      Modelos AS Modelos_1 " + GerarFiltro() + ")) AND (Serie.ModeloID IN
                    (SELECT DISTINCT ModeloID
                    FROM      ModeloCor
                    WHERE   (FornID LIKE '" + xForn + "') AND (RTRIM(RefForn) LIKE '" + xRefForn + "'))) AND (Serie.CorID LIKE '" + xCor + "') 
                    AND (Serie.TamID LIKE '" + xTamanho + "') AND (Serie.EstadoID IN ('S', 'T')) " & sfiltropreco &
                    "ORDER BY Foto DESC"



            End If


            If TipoDados = "Vendas" Then

                Dim DataVnd As Date = DataVenda.Text


                Sql = "SELECT DISTINCT ModeloID + CorID Foto , COUNT(*) AS Qtd FROM Serie " &
                      "WHERE ArmazemID like '" + cbArmazem.SelectedValue.ToString + "' " &
                      "AND ModeloID in (SELECT ModeloID FROM Modelos " + GerarFiltro() + ") " &
                      "AND ModeloID in (SELECT DISTINCT MODELOID FROM MODELOCOR WHERE FORNID LIKE '" + xForn + "' AND REFFORN LIKE '" + xRefForn + "') " &
                      "AND CorID like '" + xCor + "'  " &
                      "AND TamID like '" + xTamanho + "' " &
                      "AND EstadoID in ('V','R','F') " &
                      "AND DtSaida>= '" & Format(DataVnd, "yyyy-MM-dd H:mm:ss") & "' GROUP BY ModeloID, CorID  " &
                      "ORDER BY Qtd DESC, Foto DESC"
            End If


            If TipoDados = "Geral" Then
                Sql = "SELECT DISTINCT ModeloID + CorID Foto FROM Serie " & _
                      "WHERE ArmazemID like '" + cbArmazem.SelectedValue.ToString + "' " & _
                      "AND ModeloID in (SELECT ModeloID FROM Modelos " + GerarFiltro() + ") " & _
                      "AND ModeloID in (SELECT DISTINCT MODELOID FROM MODELOCOR WHERE FORNID LIKE '" + xForn + "' AND REFFORN LIKE '" + xRefForn + "') " & _
                      "AND CorID like '" + xCor + "'  " & _
                      "AND TamID like '" + xTamanho + "' " & _
                      "ORDER BY Foto DESC"
            End If

            If TipoDados = "Encomendas" Then
                Sql = "SELECT LTRIM(FornID + '-' + RefForn) Foto FROM Encomendas " & _
                      "WHERE RefForn in (SELECT RefForn FROM Encomendas " + GerarFiltro() + ") " & _
                      "AND RefForn in (SELECT DISTINCT RefForn FROM Encomendas WHERE rtrim(Ltrim(FornID)) LIKE '" + xForn + "' AND rtrim(Ltrim(refforn)) LIKE '" + xRefForn + "') " & _
                      "AND CorID like '" + xCor + "' AND ESTADOENC<>'E' " & _
                      "ORDER BY Foto DESC"
            End If


            If TipoDados = "Promocoes" Then


                If Len(xPrVnd) = 0 Then

                    Sql = "SELECT DISTINCT Serie.ModeloID + Serie.CorID AS Foto, PrecoVenda.Preco  FROM Serie INNER JOIN PrecoVenda ON Serie.ModeloID = PrecoVenda.ModeloID  AND Serie.CorID = PrecoVenda.CorID AND Serie.PrecoVenda <> PrecoVenda.Preco INNER JOIN Armazens ON Serie.ArmazemID = Armazens.ArmazemID  AND PrecoVenda.TabPrecoID = Armazens.TabPrecoID  INNER JOIN ModeloCor ON PrecoVenda.ModeloID = ModeloCor.ModeloID  AND PrecoVenda.CorID = ModeloCor.CorID WHERE (Serie.ArmazemID LIKE '" + xArmz + "')  AND (Serie.ModeloID IN (SELECT ModeloID FROM Modelos " + GerarFiltro() + "))  AND (Serie.ModeloID IN (SELECT DISTINCT ModeloID FROM ModeloCor AS ModeloCor_1  WHERE (FornID LIKE '" + xForn + "') AND (RefForn LIKE '" + xRefForn + "'))) AND (Serie.CorID LIKE '" + xCor + "')  AND (Serie.TamID LIKE '" + xTamanho + "') AND (Serie.EstadoID IN ('S', 'T'))  AND (ModeloCor.LstPr = 1) ORDER BY PrecoVenda.Preco, Foto DESC"

                Else

                    Sql = "SELECT DISTINCT Serie.ModeloID + Serie.CorID AS Foto, PrecoVenda.Preco  FROM Serie INNER JOIN PrecoVenda ON Serie.ModeloID = PrecoVenda.ModeloID  AND Serie.CorID = PrecoVenda.CorID AND Serie.PrecoVenda <> PrecoVenda.Preco INNER JOIN Armazens ON Serie.ArmazemID = Armazens.ArmazemID  AND PrecoVenda.TabPrecoID = Armazens.TabPrecoID  INNER JOIN ModeloCor ON PrecoVenda.ModeloID = ModeloCor.ModeloID  AND PrecoVenda.CorID = ModeloCor.CorID WHERE (Serie.ArmazemID LIKE '" + xArmz + "')  AND (Serie.ModeloID IN (SELECT ModeloID FROM Modelos " + GerarFiltro() + "))  AND (Serie.ModeloID IN (SELECT DISTINCT ModeloID FROM ModeloCor AS ModeloCor_1  WHERE (FornID LIKE '" + xForn + "') AND (RefForn LIKE '" + xRefForn + "'))) AND (Serie.CorID LIKE '" + xCor + "')  AND (Serie.TamID LIKE '" + xTamanho + "') AND (PrecoVenda.Preco='" + xPrVnd + "') AND (Serie.EstadoID IN ('S', 'T'))  AND (ModeloCor.LstPr = 1) ORDER BY PrecoVenda.Preco, Foto DESC"

                End If



            End If


            If TipoDados = "PromocoesGerais" Then

                If Len(xPrVnd) = 0 Then

                    Sql = "SELECT DISTINCT Serie.ModeloID + Serie.CorID AS Foto, PrecoVenda.Preco  FROM Serie INNER JOIN PrecoVenda ON Serie.ModeloID = PrecoVenda.ModeloID  AND Serie.CorID = PrecoVenda.CorID INNER JOIN Armazens ON Serie.ArmazemID = Armazens.ArmazemID  AND PrecoVenda.TabPrecoID = Armazens.TabPrecoID  INNER JOIN ModeloCor ON PrecoVenda.ModeloID = ModeloCor.ModeloID  AND PrecoVenda.CorID = ModeloCor.CorID WHERE (Serie.ArmazemID LIKE '" + xArmz + "')  AND (Serie.ModeloID IN (SELECT ModeloID FROM Modelos " + GerarFiltro() + "))  AND (Serie.ModeloID IN (SELECT DISTINCT ModeloID FROM ModeloCor AS ModeloCor_1  WHERE (FornID LIKE '" + xForn + "') AND (RefForn LIKE '" + xRefForn + "'))) AND (Serie.CorID LIKE '" + xCor + "')  AND (Serie.TamID LIKE '" + xTamanho + "') AND (Serie.EstadoID IN ('S', 'T'))  AND (ModeloCor.LstPr = 1) ORDER BY PrecoVenda.Preco, Foto DESC"

                Else

                    Sql = "SELECT DISTINCT Serie.ModeloID + Serie.CorID AS Foto, PrecoVenda.Preco  FROM Serie INNER JOIN PrecoVenda ON Serie.ModeloID = PrecoVenda.ModeloID  AND Serie.CorID = PrecoVenda.CorID INNER JOIN Armazens ON Serie.ArmazemID = Armazens.ArmazemID  AND PrecoVenda.TabPrecoID = Armazens.TabPrecoID  INNER JOIN ModeloCor ON PrecoVenda.ModeloID = ModeloCor.ModeloID  AND PrecoVenda.CorID = ModeloCor.CorID WHERE (Serie.ArmazemID LIKE '" + xArmz + "')  AND (Serie.ModeloID IN (SELECT ModeloID FROM Modelos " + GerarFiltro() + "))  AND (Serie.ModeloID IN (SELECT DISTINCT ModeloID FROM ModeloCor AS ModeloCor_1  WHERE (FornID LIKE '" + xForn + "') AND (RefForn LIKE '" + xRefForn + "'))) AND (Serie.CorID LIKE '" + xCor + "')  AND (Serie.TamID LIKE '" + xTamanho + "') AND (Serie.EstadoID IN ('S', 'T'))  AND (PrecoVenda='" + xPrVnd + "') AND (ModeloCor.LstPr = 1) ORDER BY PrecoVenda.Preco, Foto DESC"

                End If


            End If

            'If bAtrai = True Then
            '    Dim dtatrai As New DataTable
            '    db.GetData(Sql, dtatrai)
            '    dtatrai.Select(Foto Is (SELECT ModeloID + CorID Foto FROM ModeloCor WHERE FornID = '1016'))
            'End If



            dr = db.GetData(Sql)
            If Not dr.IsClosed Then
                If dr.HasRows Then


                    Do While dr.Read

                        'If bAtrai = True Then

                        '    ''ESTE PROCESSO PROVOCA MUITA LENTIDÃO, DEVIA RETIRAR O QUE NÃO FOR ATRAI DO dr.......
                        '    'If ModeloCorAtrai(dr("Foto").ToString) Then

                        '    '    If Not Foto Is Nothing Then
                        '    '        Array.Resize(Foto, Foto.Length + 1)
                        '    '    Else
                        '    '        Array.Resize(Foto, 1)
                        '    '    End If
                        '    '    Foto(I) = dr("Foto").ToString
                        '    '    I += 1

                        '    'End If

                        'Else

                        '    If Not Foto Is Nothing Then
                        '        Array.Resize(Foto, Foto.Length + 1)
                        '    Else
                        '        Array.Resize(Foto, 1)
                        '    End If
                        '    Foto(I) = dr("Foto").ToString
                        '    I += 1

                        'End If


                        If Not Foto Is Nothing Then
                            Array.Resize(Foto, Foto.Length + 1)
                        Else
                            Array.Resize(Foto, 1)
                        End If
                        Foto(I) = dr("Foto").ToString
                        I += 1
                    Loop

                Else
                    FazerRefresh()
                    ActualizarNavegador()
                    MsgBox("Sem dados para apresentar!", MsgBoxStyle.Information)
                End If
            End If
            CarregarFotos()
            ActualizarNavegador()
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " cmdPesquisar_Click")
        Finally
            Me.Cursor = Cursors.Default
            Me.txtGrupo.Text = ""
            Me.txtTipo.Text = ""
            Me.txtCor.Text = ""
            Me.txtAltura.Text = ""
            Me.txtModelo.Text = ""
            Me.txtTamanho.Text = ""
            Me.txtForn.Text = ""
            Me.txtRefForn.Text = ""
            Me.cbMarcas.SelectedValue = 0

            PanelStock.Visible = False
            Me.lbPrecoPromocao.Visible = False

        End Try
    End Sub

    Private Sub btStkGeral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        xGeral = False
        CarregarDados(False)
    End Sub

    Private Sub btGeral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGeral.Click
        xEnc = False
        cbArmazem.SelectedValue = "%"
        CarregarDados("Geral")
        cbArmazem.SelectedValue = xArmz

    End Sub

    Private Sub ToolStripCmds_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripCmds.Click
        PanelStock.Visible = False
    End Sub

    Private Sub tbTalao_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbTalao.KeyPress

        Dim db As New ClsSqlBDados
        Dim xArtigo As String

        Try

            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If Len(Trim(tbTalao.Text)) = 8 Then

                    Sql = "SELECT COUNT(*) FROM SERIE WHERE SERIEID='" & Trim(tbTalao.Text) & "' AND ARMAZEMID='" & xArmz & "'"
                    If db.GetDataValue(Sql) = 0 Then
                        MsgBox("SÓ PODE RESERVAR TALÕES DA SUA LOJA")
                        Me.txtRModelo.Text = ""
                        Me.txtRCor.Text = ""
                        Me.txtRTam.Text = ""
                        Me.tbTalao.Text = ""
                        Exit Sub
                    End If


                    Sql = "SELECT MODELOID+CORID+TAMID FROM SERIE WHERE SERIEID='" & Trim(tbTalao.Text) & "' AND ESTADOID='S' AND ARMAZEMID='" & xArmz & "' AND SERIE.SERIEID NOT IN (SELECT RESERVASERIEID FROM RESERVAS WHERE RESERVAESTADO='0')"
                    xArtigo = db.GetDataValue(Sql)
                    If Not xArtigo = Nothing Then
                        Me.txtRModelo.Text = Microsoft.VisualBasic.Left(xArtigo, 5)
                        Me.txtRCor.Text = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(xArtigo, 7), 2)
                        Me.txtRTam.Text = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(xArtigo, 9), 2)
                        Me.txtRModelo.Enabled = False
                        Me.txtRCor.Enabled = False
                        Me.txtRTam.Enabled = False
                        Me.tbTalao.Enabled = False
                    Else
                        Sql = "SELECT COUNT(*) FROM RESERVAS WHERE RESERVASERIEID='" & Trim(tbTalao.Text) & "' AND RESERVAESTADO='0'"
                        If db.GetDataValue(Sql) > 0 Then
                            MsgBox("O Talão: " & Trim(tbTalao.Text) & " está Reservado!")
                        Else
                            MsgBox("Talão Inválido!!")
                        End If
                        tbTalao.Text = ""

                    End If
                End If
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "tbTalao_KeyPress")
        Catch ex As Exception
            ErroVB(ex.Message, "tbTalao_KeyPress")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            Sql = Nothing
        End Try
    End Sub

    Private Sub btStkArmz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btStkArmz.Click
        xEnc = False
        CarregarDados("Stock")
        Me.txtModelo.Focus()
    End Sub

    Private Sub BtStockLoja_Click(sender As Object, e As EventArgs) Handles BtStockLoja.Click
        xEnc = False
        cbArmazem.SelectedValue = xArmz
        CarregarDados("Stock")
        Me.txtModelo.Focus()
    End Sub

    Private Sub btStockGeral_Click(sender As Object, e As EventArgs) Handles btStockGeral.Click
        xEnc = False
        cbArmazem.SelectedValue = "%"
        CarregarDados("Stock")
        cbArmazem.SelectedValue = xArmz
        Me.txtModelo.Focus()
    End Sub


    Private Sub btVendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVendas.Click
        xEnc = False
        CarregarDados("Vendas")
        Me.txtModelo.Focus()
    End Sub

    Private Sub btEncomendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEncomendas.Click
        xEnc = True
        CarregarDados("Encomendas")
    End Sub




    Private Sub txtModelo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtModelo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btStkArmz_Click(sender, e)
        End If
    End Sub

    Private Sub btEncomendas_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btEncomendas.MouseHover
        ToolTip1.SetToolTip(btEncomendas, "MOSTRA OS ARTIGOS ENCOMENDADOS")
    End Sub

    Private Sub btPromocao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPromocao.Click

        xEnc = False

        If Me.btPromocao.Text = "Promoções" Then
            CarregarDados("Promocoes")
            Me.btPromocao.Text = "Promoções Gerais"
        Else
            CarregarDados("PromocoesGerais")
            Me.btPromocao.Text = "Promoções"
        End If

        Me.txtModelo.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        'REPORT VB STUDIO 2005
        'Using clsPrintTalao As clsPrintTalao = New clsPrintTalao()
        '    clsPrintTalao.Run()
        '    tbImpTalao.Clear()
        'End Using





        'VOLTAR A USAR O REPORT DO COMPONENTONE


        If Len(tbImpTalao.Text) = 8 Then

            ListaTaloes(tbImpTalao.Text, "RptTaloesReimpressao", True)

        Else
            MsgBox("NÃO TEM NADA SELECCIONADO", MsgBoxStyle.Information)
        End If







    End Sub

    Private Sub btCliente_Click(sender As System.Object, e As System.EventArgs) Handles btCliente.Click




        If SistemaBloqueado() = True Then
            Exit Sub
        End If

        sIDClienteLoja = ""
        frmClientesLojaLista.WindowState = FormWindowState.Normal
        frmClientesLojaLista.StartPosition = FormStartPosition.CenterScreen
        frmClientesLojaLista.ShowDialog(Me)

        ActualizarClienteLoja(sIDClienteLoja, sClienteLojaIdAux, lbCliente.Text, "")

    End Sub






    Private Function GravarSinal() As Boolean


        Dim db As New ClsSqlBDados

        Try

            Dim gIdDocCab As Guid = Guid.NewGuid
            Dim gIdDocDet As Guid = Guid.NewGuid
            Dim sIdDocCabOrig As String = "Null"
            Dim xNovoDocSinal As String = PesquisaMaxNumDoc("FS")
            If xNovoDocSinal = "" Then Return False

            Dim xFormaPagamento As String = ""
            uIdDocCabSinal = "'" + gIdDocCab.ToString + "'"
            dberrorAtivo = True


            If rbMB.Checked = True Then xFormaPagamento = "6" Else xFormaPagamento = "1"

            If sIdDocCabOrig <> "Null" Then sIdDocCabOrig = "'" & sIdDocCabOrig & "'"

            Dim xVlrIva As Double = tbSinal.Text * DevolveIva(xIvaID) / (1 + DevolveIva(xIvaID))
            'TODO: TESTAR SE O ARTIGO EXISTE
            Sql = "SELECT ProductDescription FROM Product WHERE ProductCode = N'99'"
            Dim xDescricao As String = db.GetDataValue(Sql)

            Sql = "SELECT UnitOfMeasure FROM Product WHERE ProductCode = N'99'"
            Dim xUnidade As String = db.GetDataValue(Sql)

            Dim strData As New StringBuilder

            Dim sATCUD As String = DevolveATCUD(xArmz, "FS", xNovoDocSinal)
            If Now() >= #01/01/2023# And sATCUD = "0" Then Return False


            Sql = "BEGIN TRANSACTION;"
            strData.AppendLine(Sql)

            Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, TipoTerc, NIFTerc, FormaPagtoID, IDDocCab, IdDocCabOrig, DocOrig, UtilizadorID, OperadorID, ATCUD) " &
             "VALUES('" & xEmp & "','" & xArmz & "','FS','" & xNovoDocSinal & "', '" & sClienteLojaIdAux & "', GETDATE(), 'C', 'L','" & sNIFAux & "', '" & xFormaPagamento & "', '" & gIdDocCab.ToString & "'," & sIdDocCabOrig.ToString & ",'', '" & iUtilizadorID & "', '" & xUtilizador & "', '" & sATCUD & "');"
            strData.AppendLine(Sql)

            'NOTA : ProductCode=99
            Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, Valor, PercDescLn, VlrDescLn, IvaID, VlrIva, TxIva, Comissao, Qtd, IdDocCab, IdDocDet, ProductCode) " &
            "VALUES('" & xEmp & "', '" & xArmz & "', 'FS', '" & xNovoDocSinal & "', 1, 'Sinal', '', '', '', '" & xDescricao & "','" & xUnidade & "'," & tbSinal.Text & ",0 ,0 , '" & xIvaID & "',  " & xVlrIva & ",  " & DevolveIva(xIvaID) & ", 0, 1,  '" & gIdDocCab.ToString & "',  '" & gIdDocDet.ToString & "', '99');"
            strData.AppendLine(Sql)


            Sql = "COMMIT TRANSACTION;"
            strData.AppendLine(Sql)
            Sql = strData.ToString
            db.ExecuteData(Sql)

            Dim HashKey As New clsHash
            HashKey.CriarHashKey(gIdDocCab.ToString)

            Dim cQrCode As New clsQrCode
            cQrCode.CarregaQrCode(gIdDocCab.ToString)

            If dberror = True Or HashOK = False Then

                'Sql = "DELETE FROM DocCab WHERE IdDocCab = '" & gIdDocCab.ToString & "'"
                'db.ExecuteData(Sql)

                EnviarEmail("Erro", "ERRO Nº225S NA CRIAÇÃO DO DOC " + " " + xArmz + "" + gIdDocCab.ToString)
                MsgBox("ERRO Nº225S NA CRIAÇÃO DO DOCUMENTO - AVISE O TECNICO!")
                Return False
            Else
                ListaDocPOS(xNovoDocSinal, "FS", "Original", True)
                'ListaDocPOS(xNovoDocSinal, "FS", "Duplicado", True)
                Return True
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravarSinal")
        Catch ex As Exception
            ErroVB(ex.Message, "GravarSinal")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            dberrorAtivo = False
        End Try

    End Function

    Private Sub FazerRefresh()
        Try
            Pagina = 1
            LimparFotos()
            If Not Foto Is Nothing Then Erase Foto
            ActualizarNavegador()
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": FazerRefresh")
        End Try
    End Sub

    Private Sub LimparFotos()
        For I As Int16 = 0 To Pic.Length - 1
            Pic(I).Tag = Nothing
            Pic(I).Image = Nothing
        Next
    End Sub

    Private Sub GravarReserva()


        Dim db As New ClsSqlBDados
        Dim AuxTipoReserva As String
        Dim xVarGrupo As String


        Try
            If Len(Trim(tbTalao.Text)) > 0 Then AuxTipoReserva = "R" Else AuxTipoReserva = "M"

            Dim xReserva As String = Trim(Me.tbReserva.Text) & Trim(Me.txtRModelo.Text) & Trim(Me.txtRCor.Text) & Trim(Me.txtRTam.Text)
            If xReserva.Length > 0 Then
                Sql = "SELECT ISNULL(GRUPOID,'') FROM MODELOS WHERE MODELOID='" & txtRModelo.Text & "'"
                xVarGrupo = db.GetDataValue(Sql)
                If xVarGrupo = "6" Then Me.txtRTam.Text = "00"

                If Len(Trim(Me.tbReserva.Text)) = 0 Then Me.tbReserva.Text = "Medida"

                'Sql = "SELECT COUNT(*) FROM SERIE WHERE SERIEID='" & Len(Trim(tbTalao.Text)) & "' AND ARMAZEMID='" & xArmz & "'"
                'If db.GetDataValue(Sql) > 0 Then
                Sql = "INSERT INTO Reservas (ArmazemID, ArmzDest, ReservaSerieID, ReservaDescr, ReservaModeloId, ReservaCorId, ReservaTamId, ReservaData, ReservaEstado, TipoReserva, Sinal, ReservaNome, ReservaClienteLojaID, IdDocCabSinal, UtilizadorID, OperadorID) " & _
                      "VALUES ('" & xArmz & "', '" & xArmz & "', '" & Me.tbTalao.Text & "', '" & Me.tbReserva.Text & "','" & Me.txtRModelo.Text & "','" & Me.txtRCor.Text & "','" & Me.txtRTam.Text & "',GETDATE(),'0','R','" & Me.tbSinal.Text & "', '" & Me.lbCliente.Text & "','" & sClienteLojaIdAux & "',  " & uIdDocCabSinal & " , '" & iUtilizadorID & "', '" & xUtilizador & "')"
                db.ExecuteData(Sql)

                'MsgBox("Gravação efectuada com sucesso!")
                'Else
                '    MsgBox("SÓ PODE RESERVAR TALÕES DA SUA LOJA")
                'End If
                Me.tbReserva.Text = ""
                Me.txtRTam.Text = ""

            End If


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " btGravaReserva_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub InicializaReserva()

        Try

            Me.txtRModelo.Enabled = True
            Me.txtRCor.Enabled = True
            Me.txtRTam.Enabled = True
            Me.tbTalao.Enabled = True
            Me.txtRModelo.Text = ""
            Me.txtRCor.Text = ""
            Me.txtRTam.Text = ""
            Me.tbTalao.Text = ""

            sIDClienteLoja = ""
            ActualizarClienteLoja(sIDClienteLoja, sClienteLojaIdAux, lbCliente.Text, sNIFAux)

            tbSinal.Text = ""
            rbDinheiro.Checked = True


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " InicializaReserva")
        End Try

    End Sub




    'EVENTOS NA CFGDET
    'CFGDet

    Private Sub CFGDet_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CFGDet.MouseClick

        Dim dt As New DataTable
        Dim db As New ClsSqlBDados
        Dim xModelo As String
        Dim xCor As String
        Dim xTam As String

        Try
            frm = New Form
            Dgrid = New DataGridView

            xModelo = Microsoft.VisualBasic.Left(_Pic.Tag, 5)
            xCor = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(_Pic.Tag, 7), 2)
            xTam = Me.CFGDet.Cols(Me.CFGDet.Col).Caption

            'xModelo = Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.ColSel)
            'xCor = Me.CFGDet(Me.CFGDet.Row(), "CorID")


            'Sql = "SELECT ARMAZEMID Armazem, Estadoid, '          ' Estado, '          ' Destino, Serieid, MeiosPontos, DtRegisto AS Data  INTO #SERIE FROM SERIE WHERE MODELOID='" & xModelo & "' AND CORID='" & xCor & "' AND TAMID='" & xTam & "' AND EstadoID IN ('S','T')"
            Sql = "SELECT ARMAZEMID Armazem, Estadoid, '          ' Estado, '          ' Destino, Serieid, MeiosPontos, DtSaida AS Data  INTO #SERIE FROM SERIE WHERE MODELOID='" & xModelo & "' AND CORID='" & xCor & "' AND TAMID='" & xTam & "' AND EstadoID IN ('S','T')"

            db.ExecuteData(Sql)

            Sql = "UPDATE #SERIE SET ESTADO='Stock' WHERE ESTADOid='S'; UPDATE #SERIE SET Destino = DocCab.TercID, Estado='Separado' FROM #SERIE INNER JOIN DocDet ON #SERIE.SerieID = DocDet.SerieID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID  AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.EstadoLn = 'G') AND (DocCab.TipoDocID = 'SE'); UPDATE #SERIE SET ESTADO='Transito' WHERE ESTADOid='T';"
            db.ExecuteData(Sql)

            Sql = "UPDATE #Serie SET Estado = 'Reservado' FROM #Serie INNER JOIN Reservas ON #Serie.SerieID = Reservas.ReservaSerieID	WHERE (Reservas.ReservaDescr<>RTRIM(LTRIM('Transferir'))) AND ReservaEstado='0';"
            db.ExecuteData(Sql)

            'Sql = "SELECT Armazem, Estado, Destino, Serieid Talão FROM #SERIE order by Armazem"

            If DevolveGrupoAcesso() = "ADMIN" Then
                Sql = "SELECT Armazens_1.ArmAbrev AS Armz, Estado, isnull(Armazens.ArmAbrev,'') AS Destino, Serieid Talão, MeiosPontos MP, Data FROM  #Serie LEFT OUTER JOIN Armazens ON #Serie.Destino = Armazens.ArmazemID LEFT OUTER JOIN Armazens AS Armazens_1 ON #Serie.Armazem = Armazens_1.ArmazemID ORDER BY #SERIE.ARMAZEM"
            Else
                'Sql = "SELECT Armazens_1.ArmAbrev AS Armz, Estado, isnull(Armazens.ArmAbrev,'') AS Destino, Serieid Talão, MeiosPontos MP FROM  #Serie LEFT OUTER JOIN Armazens ON #Serie.Destino = Armazens.ArmazemID LEFT OUTER JOIN Armazens AS Armazens_1 ON #Serie.Armazem = Armazens_1.ArmazemID ORDER BY #SERIE.ARMAZEM"

                Sql = "SELECT Estado, SUM(1) AS Qtd
                FROM [#Serie] LEFT OUTER JOIN
                Armazens ON [#Serie].Destino = Armazens.ArmazemID LEFT OUTER JOIN
                Armazens AS Armazens_1 ON [#Serie].Armazem = Armazens_1.ArmazemID
                GROUP BY Estado"

            End If
            db.GetData(Sql, dt)

            If dt.Rows.Count = 0 Then
                MsgBox("Não Existe Stock!!")
            Else


                With Dgrid
                    .DataSource = dt
                    .AllowUserToAddRows = False
                    .AllowUserToDeleteRows = False
                    .AllowUserToResizeColumns = False
                    .AllowUserToResizeRows = False
                    .Dock = DockStyle.Fill
                    .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    .ReadOnly = True
                    For c As Integer = 0 To Dgrid.Columns.Count - 1
                        With .Columns(c)
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .ReadOnly = True
                            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .HeaderCell.Style.Font = New Font("Arial", 12, FontStyle.Bold)
                        End With
                    Next
                    .AutoSize = True


                End With
                With frm
                    .Width = 510
                    .Height = 100 + dt.Rows.Count * 27
                    If .Height > 500 Then .Height = 500
                    .StartPosition = FormStartPosition.CenterParent
                    .MinimizeBox = False
                    .MaximizeBox = False
                    .Controls.Add(Dgrid)
                    .Text = "Refª:  " & xModelo & "-" & xCor & "   Tam: " & xTam
                    .ShowDialog(Me)

                End With


            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " CFGDet_MouseClick")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub CarregarCFGDet(ByVal xModeloCor As String)

        Dim db As New ClsSqlBDados
        Dim dtDetAux As New DataTable
        Dim dtDetAux1 As New DataTable

        Try


            'DevolvePalavras()

            If Trim(xModeloCor) <> "" Then
                Me.Cursor = Cursors.WaitCursor
                Dim xModelo As String = Microsoft.VisualBasic.Left(xModeloCor, 5)
                Dim xCor As String = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(xModeloCor, 7), 2)
                If cbVerTodos.Checked = False And bAtrai = False Then
                    Sql = "EXEC prc_ConsultaDetStockLoja @ModeloID = '" & xModelo & "', @CorID = '" & xCor & "', @ArmazemID='" & xArmz & "'"
                    btdetalhe.Visible = False
                Else
                    btdetalhe.Visible = True
                    Sql = "EXEC prc_ConsultaDetStock @ModeloID = '" & xModelo & "', @CorID = '" & xCor & "'"
                End If

                'Vou correr o procedimento duas vezes porque se correr só uma vez vai  buscar os valores anteriores
                'Não consegui resolver de outra forma.......
                db.ExecuteData(Sql)
                db.GetData(Sql, dtDetAux, False)


                'MsgBox(dtDetAux.Rows(1).Item(3).ToString())
                'MsgBox(dtDetAux.Columns(3).ColumnName)
                'Exit Try


                If Me.btPromocao.Text = "Promoções Gerais" Then
                    Me.lbPrecoPromocao.Visible = True
                    Sql = "SELECT DISTINCT isnull(PrecoVenda.Preco,0) PVPromo FROM PrecoVenda INNER JOIN Armazens ON PrecoVenda.TabPrecoID = Armazens.TabPrecoID INNER JOIN ModeloCor ON PrecoVenda.ModeloID = ModeloCor.ModeloID AND PrecoVenda.CorID = ModeloCor.CorID WHERE (Armazens.ArmazemID = '" & xArmz & "') AND (PrecoVenda.ModeloID = '" & xModelo & "') AND (PrecoVenda.CorID = '" & xCor & "')"
                    Me.lbPrecoPromocao.Text = "Promoção: " & FormatCurrency(db.GetDataValue(Sql))
                Else
                    Me.lbPrecoPromocao.Visible = False
                End If

                With Me.CFGDet
                    .DataSource = dtDetAux
                    Dim I, J As Integer
                    For I = 1 To CFGDet.Rows.Count - 1
                        For J = 3 To CFGDet.Cols.Count - 1
                            If CFGDet(I, J).ToString = "0" Or CFGDet(I, J).ToString = "0.0" Then CFGDet(I, J) = DBNull.Value
                            Me.CFGDet.Cols(J).TextAlign = TextAlignEnum.CenterCenter
                        Next
                    Next
                    If bAtrai = False Then
                        .Cols("ArmazemID").Visible = False
                        .Cols("ArmAbrev").Visible = False
                        .Cols("Stk").Visible = False
                        .Cols("ArmAbrev").Caption = "Loja"
                    End If


                    'CFGDet.SetCellStyle(2, 2, Khaki)
                    'CFGDet.cellbackcolour(3, 3) = khaki

                    'c1.Win.C1FlexGrid.CellStyle


                    'Dim low_score_style As New DataGridViewCellStyle()
                    'low_score_style.BackColor = Color.Pink
                    'low_score_style.ForeColor = Color.Red
                    '.Item(3, 3).Style = low_score_style

                    .AutoSizeCols()
                    .AllowEditing = False
                    .AutoResize = True
                    .AllowDragging = AllowDraggingEnum.None

                    'Dim LarguraTotalColunas As Double = 0
                    'Dim AlturaTotalLinhas As Double = 0
                    'AlturaTotalLinhas = .Rows(0).HeightDisplay * CFGDet.Rows.Count


                    'For I = 0 To CFGDet.Cols.Count - 1
                    '    If .Cols(I).Visible = True Then
                    '        LarguraTotalColunas += .Cols(I).WidthDisplay
                    '    End If
                    'Next
                    '.Width = LarguraTotalColunas * 1.05
                    '.Height = AlturaTotalLinhas * 1.05

                End With

                Application.DoEvents()
                PanelStock.Visible = True
                CFGDet.Visible = True
                cbVerTodos.Visible = False
                Me.Cursor = Cursors.Default

            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarCFGDet")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarCFGDet")
        Finally
            cn.Close()
            Sql = Nothing
            da = Nothing
            db = Nothing
            dtDetAux = Nothing


        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btdetalhe.Click
        Dim db As New ClsSqlBDados
        Dim xRefFornAtrai As String
        Dim xCorFornAtrai As String



        Try


            Sql = "SELECT RefForn FROM MODELOCOR where Modeloid = '" + Microsoft.VisualBasic.Left(_Pic.Tag, 5) + "' and Corid = '" + Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(_Pic.Tag, 7), 2) + "'"
            xRefFornAtrai = db.GetDataValue(Sql)

            Sql = "SELECT CorForn FROM MODELOCOR where Modeloid = '" + Microsoft.VisualBasic.Left(_Pic.Tag, 5) + "' and Corid = '" + Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(_Pic.Tag, 7), 2) + "'"
            xCorFornAtrai = db.GetDataValue(Sql)




            frmStockLoja.StartPosition = FormStartPosition.CenterParent
            frmStockLoja.WindowState = FormWindowState.Normal
            frmStockLoja.ShowInTaskbar = False
            frmStockLoja.MaximizeBox = False
            frmStockLoja.MinimizeBox = False
            If bAtrai = True Then frmStockLoja.Text = "Refª:  " & Microsoft.VisualBasic.Left(_Pic.Tag, 5) & "-" & Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(_Pic.Tag, 7), 2) & "   Refª Fornecedor : " & xRefFornAtrai & "  " & xCorFornAtrai
            frmStockLoja.ShowDialog(Me)

        Catch ex As Exception

        End Try


    End Sub



    'Private Sub CFGDet_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles customerDataGridView.CellFormatting

    '    ' If the column being formatted is the column named 'Status' ..

    '    If Me.CFGDet.Columns(e.ColumnIndex).Name = "Status" Then

    '        If e.Value IsNot Nothing Then

    '            ' If the value of the cell is "Inactive" AND this form's inactiveCustomersCheckBox control is checked..

    '            If e.Value.ToString = "Inactive" And Me.inactiveCustomersCheckBox.Checked Then

    '                ' Set the BackColor of the cell to yellow.

    '                e.CellStyle.BackColor = Color.Yellow

    '            End If

    '        End If

    '    End If



    '    ' If the column being formatted is the column named 'LastOrderDate'..

    '    If Me.CFGDet.Columns(e.ColumnIndex).Name = "LastOrderDate" Then

    '        If e.Value IsNot Nothing Then

    '            ' If LastOrderDate was more than 30 days ago AND this form's ordersOverdueCheckBox control is checked..

    '            If Date.Now.Subtract(CType(e.Value, Date)).Days > 30 And Me.orderOverdueCheckBox.Checked Then

    '                ' Set the BackColor of the cell to yellow-green.

    '                e.CellStyle.BackColor = Color.YellowGreen

    '            End If

    '        End If

    '    End If

    'End Sub



    'Private Sub CFGDet_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles customerDataGridView.CellFormatting

    '    ' If the column being formatted is the column named 'Status' ..

    '    If Me.CFGDet.Columns(e.ColumnIndex).Name = "Status" Then

    '        If e.Value IsNot Nothing Then

    '            ' If the value of the cell is "Inactive" AND this form's inactiveCustomersCheckBox control is checked..

    '            If e.Value.ToString = "Inactive" And Me.inactiveCustomersCheckBox.Checked Then

    '                ' Set the BackColor of the cell to yellow.

    '                e.CellStyle.BackColor = Color.Yellow

    '            End If

    '        End If

    '    End If



    '    ' If the column being formatted is the column named 'LastOrderDate'..

    '    If Me.CFGDet.Columns(e.ColumnIndex).Name = "LastOrderDate" Then

    '        If e.Value IsNot Nothing Then

    '            ' If LastOrderDate was more than 30 days ago AND this form's ordersOverdueCheckBox control is checked..

    '            If Date.Now.Subtract(CType(e.Value, Date)).Days > 30 And Me.orderOverdueCheckBox.Checked Then

    '                ' Set the BackColor of the cell to yellow-green.

    '                e.CellStyle.BackColor = Color.YellowGreen

    '            End If

    '        End If

    '    End If

    'End Sub






End Class