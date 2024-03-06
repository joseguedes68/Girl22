Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid


Public Class frmRecEncomenda
    Inherits System.Windows.Forms.Form

    Dim dtRecPndDet As New DataTable
    Dim dtRecPndCab As New DataTable
    Dim dtRec As New DataTable
    Dim xOrigem As String
    Dim xNrEnc As String
    Dim xFoto As String
    Dim xFotoAux As String = ""


    'TODO: SÓ FUNCIONA O CABEÇALHO
    'TODO: NÃO LIMPA A TEXTBOX FALTA RECEPCIONAR
    'TODO: DEPOIS DE EXECUTAR DEVE MANTER-SE NA MESMA LINHA DE CABEÇALHO



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents C1FGRecPend As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FGRec As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtCodBarras As System.Windows.Forms.TextBox
    Friend WithEvents txtQtdLido As System.Windows.Forms.TextBox
    Friend WithEvents CmdValidaRec As System.Windows.Forms.Button
    Friend WithEvents TimerActDados As System.Windows.Forms.Timer
    Friend WithEvents C1FGRecPendCab As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ChBVerTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PBFotoModCor As System.Windows.Forms.PictureBox
    Friend WithEvents txtFaltaRec As System.Windows.Forms.TextBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecEncomenda))
        Me.C1FGRecPend = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FGRec = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtCodBarras = New System.Windows.Forms.TextBox()
        Me.txtQtdLido = New System.Windows.Forms.TextBox()
        Me.CmdValidaRec = New System.Windows.Forms.Button()
        Me.C1FGRecPendCab = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ChBVerTodos = New System.Windows.Forms.CheckBox()
        Me.TimerActDados = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFaltaRec = New System.Windows.Forms.TextBox()
        Me.PBFotoModCor = New System.Windows.Forms.PictureBox()
        CType(Me.C1FGRecPend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FGRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FGRecPendCab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBFotoModCor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1FGRecPend
        '
        Me.C1FGRecPend.AllowDelete = True
        Me.C1FGRecPend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.C1FGRecPend.AutoResize = False
        Me.C1FGRecPend.ColumnInfo = resources.GetString("C1FGRecPend.ColumnInfo")
        Me.C1FGRecPend.Location = New System.Drawing.Point(30, 172)
        Me.C1FGRecPend.Name = "C1FGRecPend"
        Me.C1FGRecPend.Rows.Count = 1
        Me.C1FGRecPend.Rows.DefaultSize = 17
        Me.C1FGRecPend.Size = New System.Drawing.Size(431, 243)
        Me.C1FGRecPend.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FGRecPend.Styles"))
        Me.C1FGRecPend.TabIndex = 18
        Me.C1FGRecPend.TabStop = False
        '
        'C1FGRec
        '
        Me.C1FGRec.AllowDelete = True
        Me.C1FGRec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FGRec.AutoResize = False
        Me.C1FGRec.ColumnInfo = resources.GetString("C1FGRec.ColumnInfo")
        Me.C1FGRec.Location = New System.Drawing.Point(387, 73)
        Me.C1FGRec.Name = "C1FGRec"
        Me.C1FGRec.Rows.Count = 1
        Me.C1FGRec.Rows.DefaultSize = 17
        Me.C1FGRec.Size = New System.Drawing.Size(295, 342)
        Me.C1FGRec.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FGRec.Styles"))
        Me.C1FGRec.TabIndex = 21
        Me.C1FGRec.TabStop = False
        '
        'txtCodBarras
        '
        Me.txtCodBarras.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras.Location = New System.Drawing.Point(514, 28)
        Me.txtCodBarras.Name = "txtCodBarras"
        Me.txtCodBarras.Size = New System.Drawing.Size(221, 34)
        Me.txtCodBarras.TabIndex = 23
        Me.txtCodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtQtdLido
        '
        Me.txtQtdLido.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtQtdLido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtdLido.Location = New System.Drawing.Point(579, 437)
        Me.txtQtdLido.Name = "txtQtdLido"
        Me.txtQtdLido.Size = New System.Drawing.Size(134, 34)
        Me.txtQtdLido.TabIndex = 25
        Me.txtQtdLido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdValidaRec
        '
        Me.CmdValidaRec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdValidaRec.Location = New System.Drawing.Point(743, 286)
        Me.CmdValidaRec.Name = "CmdValidaRec"
        Me.CmdValidaRec.Size = New System.Drawing.Size(155, 37)
        Me.CmdValidaRec.TabIndex = 26
        Me.CmdValidaRec.Text = "Executar"
        '
        'C1FGRecPendCab
        '
        Me.C1FGRecPendCab.AllowDelete = True
        Me.C1FGRecPendCab.AutoResize = False
        Me.C1FGRecPendCab.ColumnInfo = resources.GetString("C1FGRecPendCab.ColumnInfo")
        Me.C1FGRecPendCab.Location = New System.Drawing.Point(30, 14)
        Me.C1FGRecPendCab.Name = "C1FGRecPendCab"
        Me.C1FGRecPendCab.Rows.Count = 1
        Me.C1FGRecPendCab.Rows.DefaultSize = 17
        Me.C1FGRecPendCab.Size = New System.Drawing.Size(431, 231)
        Me.C1FGRecPendCab.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FGRecPendCab.Styles"))
        Me.C1FGRecPendCab.TabIndex = 27
        Me.C1FGRecPendCab.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(802, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 36)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Imprimir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ChBVerTodos
        '
        Me.ChBVerTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChBVerTodos.AutoSize = True
        Me.ChBVerTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChBVerTodos.Location = New System.Drawing.Point(649, 14)
        Me.ChBVerTodos.Name = "ChBVerTodos"
        Me.ChBVerTodos.Size = New System.Drawing.Size(117, 24)
        Me.ChBVerTodos.TabIndex = 29
        Me.ChBVerTodos.Text = "Ver Todas"
        Me.ChBVerTodos.UseVisualStyleBackColor = True
        '
        'TimerActDados
        '
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 437)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 24)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Falta Recepcionar :"
        '
        'txtFaltaRec
        '
        Me.txtFaltaRec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFaltaRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaltaRec.Location = New System.Drawing.Point(221, 437)
        Me.txtFaltaRec.Name = "txtFaltaRec"
        Me.txtFaltaRec.Size = New System.Drawing.Size(65, 34)
        Me.txtFaltaRec.TabIndex = 31
        '
        'PBFotoModCor
        '
        Me.PBFotoModCor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBFotoModCor.Location = New System.Drawing.Point(705, 87)
        Me.PBFotoModCor.Name = "PBFotoModCor"
        Me.PBFotoModCor.Size = New System.Drawing.Size(217, 158)
        Me.PBFotoModCor.TabIndex = 32
        Me.PBFotoModCor.TabStop = False
        '
        'frmRecEncomenda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(936, 517)
        Me.Controls.Add(Me.PBFotoModCor)
        Me.Controls.Add(Me.txtFaltaRec)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChBVerTodos)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.C1FGRecPendCab)
        Me.Controls.Add(Me.CmdValidaRec)
        Me.Controls.Add(Me.txtQtdLido)
        Me.Controls.Add(Me.txtCodBarras)
        Me.Controls.Add(Me.C1FGRec)
        Me.Controls.Add(Me.C1FGRecPend)
        Me.Name = "frmRecEncomenda"
        Me.Text = "RecEncomendas"
        CType(Me.C1FGRecPend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FGRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FGRecPendCab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBFotoModCor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'EVENTOS

    Private Sub frmRecepcao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            'Preencher Grid C1TGRecPendCab

            With dtRecPndCab.Columns
                .Add("CodForn", GetType(String))
                .Add("Nome", GetType(String))
                .Add("NrEnc", GetType(String))
                .Add("QtdEnc", GetType(Integer))
            End With

            With C1FGRecPendCab

                .DataSource = dtRecPndCab
                .Cols("QtdEnc").TextAlignFixed = TextAlignEnum.CenterCenter
                .AutoResize = True

            End With

            'Preencher Grid C1FGRecPend

            With dtRecPndDet.Columns
                .Add("SerieID", GetType(String))
                .Add("ModeloID", GetType(String))
                .Add("CorID", GetType(String))
                .Add("TamId", GetType(String))
                .Add("EstadoId", GetType(String))


            End With

            With C1FGRecPend

                .DataSource = dtRecPndDet
                .Cols("SerieID").Caption = "Talão"
                .Cols("SerieID").TextAlignFixed = TextAlignEnum.CenterCenter
                .Cols("ModeloID").TextAlignFixed = TextAlignEnum.CenterCenter
                .Cols("CorID").TextAlignFixed = TextAlignEnum.CenterCenter
                .Cols("TamId").TextAlignFixed = TextAlignEnum.CenterCenter
                .Cols("EstadoId").Caption = "E"
                .Cols("EstadoId").TextAlignFixed = TextAlignEnum.CenterCenter
                .AutoResize = True

            End With

            'Preencher Grid C1FGRec

            With dtRec.Columns
                .Add("SerieID", GetType(String)).Unique = True
                .Add("Artigo", GetType(String))
            End With

            With C1FGRec
                .DataSource = dtRec
                .Cols("SerieID").Caption = "Talão"
                .Cols("SerieID").TextAlignFixed = TextAlignEnum.CenterCenter
                .Cols("Artigo").Caption = "Artigo"
                .Cols("Artigo").TextAlignFixed = TextAlignEnum.CenterCenter
                .AutoResize = True
                .AutoSizeCols()
            End With

            ActualizaC1FGRecPendCab()


            'e.CellStyle.ForeColor = System.Drawing.Color.Black
            'e.CellStyle.BackColor = System.Drawing.Color.SeaGreen


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmRecepcao_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmRecepcao_Load")
        End Try

    End Sub

    Private Sub txtCodBarras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBarras.KeyPress
        'TODO: SE LER UM Nº QUE NÃO EXISTE DAR MENSAGEM 
        'TODO: COLOCAR COLUNA COM O Nº DA SEPARAÇÃO??
        Try

            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If txtCodBarras.Text.Length = 8 Then
                    'carregar talões
                    Dim xTalao As String = Me.txtCodBarras.Text
                    Dim bTalao As Integer = C1FGRecPend.FindRow(xTalao, 0, 1, True)
                    Dim xArtigo As String = Me.C1FGRecPend(bTalao, "Artigo")
                    Dim xEstadoLn As String = Me.C1FGRecPend(bTalao, "EstadoLn")

                    If bTalao = -1 Or xEstadoLn <> "G" Then
                        'Esse talão não existe
                    Else
                        dtRec.Rows.Add(xTalao, xArtigo)
                        C1FGRec.AutoSizeCols()
                        'Iserir Foto
                        xFoto = C1FGRecPend(Me.C1FGRecPend.Row, "ModeloID") & C1FGRecPend(C1FGRecPend.Row, "CorID") & ".jpg"
                        If xFoto <> xFotoAux Then
                            If IO.File.Exists(xFotosPath & xFoto) Then
                                PBFotoModCor.SizeMode = PictureBoxSizeMode.Zoom
                                PBFotoModCor.Image = Image.FromFile(xFotosPath & xFoto)
                                PBFotoModCor.Visible = True
                            Else
                                'MsgBox("A foto não existe")
                            End If

                            xFotoAux = xFoto
                        End If
                    End If
                    txtCodBarras.SelectAll()
                End If
            End If
            dtRec.AcceptChanges()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CmdValidaRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdValidaRec.Click

        Try

            Dim xNumDoc As String
            Dim xSerie As String
            Dim xOrigem As String

            'dtAux.AcceptChanges()
            If dtRec.Rows.Count > 0 Then
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd = New SqlCommand(Sql, cn)
                xOrigem = C1FGRecPendCab(Me.C1FGRecPendCab.Row, ("Origem"))
                xNumDoc = C1FGRecPendCab(Me.C1FGRecPendCab.Row, ("DocNr"))

                For Each r As DataRow In dtRec.Rows

                    xSerie = r("SerieID")

                    Sql = "UPDATE DocDet SET EstadoLn='R',DtRegisto=GETDATE() " & _
                        "WHERE EmpresaID='" & xEmp & "' AND ArmazemID='" & xOrigem & "' AND TipoDocID='SE' AND DocNr='" & xNumDoc & "' AND SerieID='" & xSerie & "' AND EstadoLn='G'"
                    Cmd = New SqlCommand(Sql, cn)
                    Cmd.ExecuteNonQuery()

                    Sql = "UPDATE Serie SET EstadoID = 'S' WHERE SerieID = '" & xSerie & "'"
                    Cmd = New SqlCommand(Sql, cn)
                    Cmd.ExecuteNonQuery()
                Next

                Sql = "SELECT COUNT(*) " & _
                    "FROM DocDet " & _
                    "WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xOrigem & "' AND TipoDocID = 'SE' AND DocNr = '" & xNumDoc & "' AND EstadoLn = 'G' " & _
                    "GROUP BY EmpresaID, ArmazemID, TipoDocID, DocNr, EstadoLn "
                Cmd = New SqlCommand(Sql, cn)
                Dim xCount As String = Cmd.ExecuteScalar
                'MsgBox(aux)
                If xCount Is Nothing Then
                    ' FAZ UPDATE AO ESTADO DE DOCUMENTO DE G PARA R 
                    Sql = "UPDATE DocCab SET EstadoDoc = 'R' WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xOrigem & "' AND TipoDocID = 'SE' AND DocNr = '" & xNumDoc & "'"
                    Cmd = New SqlCommand(Sql, cn)
                    Cmd.ExecuteNonQuery()
                End If

            End If
            dtRec.Clear()
            Me.txtQtdLido.Text = Nothing
            Me.txtCodBarras.Text = Nothing
            ActualizaC1FGRecPendCab()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub C1FGRecPendCab_RowColChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FGRecPendCab.RowColChange

        TimerActDados.Stop()
        TimerActDados.Interval = 500
        TimerActDados.Start()

    End Sub

    Private Sub TimerActDados_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerActDados.Tick
        Me.TimerActDados.Stop()
        ActualizaC1FGRecPend()
        dtRec.Clear()
        txtCodBarras.Clear()
        PBFotoModCor.Visible = False
    End Sub

    Private Sub ChBVerTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBVerTodos.CheckedChanged
        ActualizaC1FGRecPendCab()
        'ActualizaC1FGRecPend()
    End Sub



    'FUNÇÕES


    Private Function VerificarRepetidos() As Boolean
        If dtRec.Rows.Count > 0 Then
            If dtRec.Select("SerieID = '" & Me.txtCodBarras.Text & "'", "").Length = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Private Sub ActualizaC1FGRecPend()
        Try
            dtRecPndDet.Clear()

            If dtRecPndCab.Rows.Count() > 0 Then

                xOrigem = Me.C1FGRecPendCab(Me.C1FGRecPendCab.Row, "CodForn")
                xNrEnc = Me.C1FGRecPendCab(Me.C1FGRecPendCab.Row, "NrEnc")

                Sql = "SELECT SERIEID, MODELOID, CORID, TAMID, ESTADOID "
                Sql += "FROM SERIE WHERE ARMAZEMID = '" & xOrigem & "' AND NRENC = '" & xNrEnc & "'"

                da = New SqlDataAdapter(Sql, cn)
                da.Fill(dtRecPndDet)

                Dim dvAux As DataView
                dvAux = dtRecPndDet.DefaultView
                If ChBVerTodos.Checked = False Then
                    dvAux.RowFilter = "ESTADOID = 'G'"
                    C1FGRecPend.Cols("EstadoLn").Visible = False
                    txtFaltaRec.Text = dvAux.Count

                Else
                    dvAux.RowFilter = ""
                    C1FGRecPend.Cols("EstadoLn").Visible = True
                    txtFaltaRec.Text = dtRecPndDet.Rows.Count
                End If
                txtFaltaRec.TextAlign = HorizontalAlignment.Center
            Else
                MsgBox("Não tem nada para recepcionar")
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaC1FGRecPend")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaC1FGRecPend")
        End Try

    End Sub

    Private Sub ActualizaC1FGRecPendCab()
        Try
            dtRecPndCab.Clear()

            Dim xEstado As String
            If ChBVerTodos.Checked = False Then
                xEstado = "G"
            Else
                xEstado = "%"
            End If


            Sql = "SELECT Encomendas.NrEnc, Encomendas.FornId as CodForn, Fornecedores.NomeAbrev as Nome, SUM(EncDetTam.Qtd) AS QtdEnc " & _
            "FROM Encomendas INNER JOIN Fornecedores ON Encomendas.FornId = Fornecedores.FornID INNER JOIN EncDetTam ON Encomendas.EmpresaID = EncDetTam.EmpresaID AND Encomendas.ArmazemID = EncDetTam.ArmazemID AND Encomendas.NrEnc = EncDetTam.NrEnc And Encomendas.LnEnc = EncDetTam.LnEnc " & _
            "WHERE Encomendas.EstadoEnc = 'C' AND Encomendas.EmpresaID = '0001' AND Encomendas.ArmazemID = '0000' " & _
            "GROUP BY Encomendas.NrEnc, Encomendas.FornId, Fornecedores.NomeAbrev"

            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtRecPndCab)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmRecepcao_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmRecepcao_Load")
        End Try

    End Sub



End Class
