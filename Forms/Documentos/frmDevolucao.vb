
Imports System.Data.SqlClient
Imports C1.Win.C1TrueDBGrid


Public Class frmDevolucao
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodBarras As System.Windows.Forms.TextBox
    Friend WithEvents TimerActDados As System.Windows.Forms.Timer
    Friend WithEvents c1fgDevDet As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtQtdLido As System.Windows.Forms.TextBox
    Friend WithEvents CmdNova As System.Windows.Forms.Button
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents CbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents C1TGDevCab As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmdFechar As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cbVerTodas As System.Windows.Forms.CheckBox
    Friend WithEvents btExecuta As System.Windows.Forms.Button
    Friend WithEvents CmdApaga As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDevolucao))
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCodBarras = New System.Windows.Forms.TextBox
        Me.TimerActDados = New System.Windows.Forms.Timer(Me.components)
        Me.c1fgDevDet = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.txtQtdLido = New System.Windows.Forms.TextBox
        Me.CmdNova = New System.Windows.Forms.Button
        Me.txtData = New System.Windows.Forms.DateTimePicker
        Me.CbDestino = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.C1TGDevCab = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmdFechar = New System.Windows.Forms.Button
        Me.CmdPrint = New System.Windows.Forms.Button
        Me.CmdApaga = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btExecuta = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cbVerTodas = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.c1fgDevDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TGDevCab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 28)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Ler Talão"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCodBarras
        '
        Me.txtCodBarras.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras.Location = New System.Drawing.Point(140, 16)
        Me.txtCodBarras.Name = "txtCodBarras"
        Me.txtCodBarras.Size = New System.Drawing.Size(128, 29)
        Me.txtCodBarras.TabIndex = 8
        Me.txtCodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TimerActDados
        '
        Me.TimerActDados.Interval = 500
        '
        'c1fgDevDet
        '
        Me.c1fgDevDet.AllowDelete = True
        Me.c1fgDevDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.c1fgDevDet.AutoResize = False
        Me.c1fgDevDet.BackColor = System.Drawing.SystemColors.Control
        Me.c1fgDevDet.ColumnInfo = resources.GetString("c1fgDevDet.ColumnInfo")
        Me.c1fgDevDet.Location = New System.Drawing.Point(28, 51)
        Me.c1fgDevDet.Name = "c1fgDevDet"
        Me.c1fgDevDet.Rows.Count = 1
        Me.c1fgDevDet.Rows.DefaultSize = 17
        Me.c1fgDevDet.Size = New System.Drawing.Size(390, 275)
        Me.c1fgDevDet.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("c1fgDevDet.Styles"))
        Me.c1fgDevDet.TabIndex = 17
        Me.c1fgDevDet.TabStop = False
        '
        'txtQtdLido
        '
        Me.txtQtdLido.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtQtdLido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtdLido.Location = New System.Drawing.Point(290, 332)
        Me.txtQtdLido.Name = "txtQtdLido"
        Me.txtQtdLido.Size = New System.Drawing.Size(128, 29)
        Me.txtQtdLido.TabIndex = 21
        Me.txtQtdLido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdNova
        '
        Me.CmdNova.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdNova.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNova.Location = New System.Drawing.Point(7, 82)
        Me.CmdNova.Name = "CmdNova"
        Me.CmdNova.Size = New System.Drawing.Size(86, 29)
        Me.CmdNova.TabIndex = 7
        Me.CmdNova.Text = "Nova"
        Me.CmdNova.UseVisualStyleBackColor = False
        '
        'txtData
        '
        Me.txtData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(248, 8)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(120, 29)
        Me.txtData.TabIndex = 10
        Me.txtData.TabStop = False
        '
        'CbDestino
        '
        Me.CbDestino.AllowDrop = True
        Me.CbDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbDestino.DropDownWidth = 150
        Me.CbDestino.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbDestino.Location = New System.Drawing.Point(6, 43)
        Me.CbDestino.MaxDropDownItems = 10
        Me.CbDestino.Name = "CbDestino"
        Me.CbDestino.Size = New System.Drawing.Size(363, 24)
        Me.CbDestino.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(236, 26)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Seleccionar Destino :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1TGDevCab
        '
        Me.C1TGDevCab.AllowDelete = True
        Me.C1TGDevCab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TGDevCab.CaptionHeight = 17
        Me.C1TGDevCab.Font = New System.Drawing.Font("Lucida Calligraphy", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1TGDevCab.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TGDevCab.Images.Add(CType(resources.GetObject("C1TGDevCab.Images"), System.Drawing.Image))
        Me.C1TGDevCab.Location = New System.Drawing.Point(10, 39)
        Me.C1TGDevCab.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1TGDevCab.Name = "C1TGDevCab"
        Me.C1TGDevCab.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TGDevCab.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TGDevCab.PreviewInfo.ZoomFactor = 75
        Me.C1TGDevCab.PrintInfo.PageSettings = CType(resources.GetObject("C1TGDevCab.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TGDevCab.RecordSelectorWidth = 15
        Me.C1TGDevCab.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TGDevCab.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TGDevCab.RowHeight = 15
        Me.C1TGDevCab.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TGDevCab.Size = New System.Drawing.Size(538, 479)
        Me.C1TGDevCab.TabIndex = 16
        Me.C1TGDevCab.Text = "C1TrueDBGrid1"
        Me.C1TGDevCab.PropBag = resources.GetString("C1TGDevCab.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CbDestino)
        Me.GroupBox1.Controls.Add(Me.txtData)
        Me.GroupBox1.Controls.Add(Me.CmdFechar)
        Me.GroupBox1.Controls.Add(Me.CmdPrint)
        Me.GroupBox1.Controls.Add(Me.CmdApaga)
        Me.GroupBox1.Controls.Add(Me.CmdNova)
        Me.GroupBox1.Location = New System.Drawing.Point(597, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 119)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'CmdFechar
        '
        Me.CmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CmdFechar.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFechar.Location = New System.Drawing.Point(283, 82)
        Me.CmdFechar.Name = "CmdFechar"
        Me.CmdFechar.Size = New System.Drawing.Size(86, 29)
        Me.CmdFechar.TabIndex = 7
        Me.CmdFechar.Text = "Fechar"
        Me.CmdFechar.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdPrint.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.Location = New System.Drawing.Point(191, 82)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(86, 29)
        Me.CmdPrint.TabIndex = 7
        Me.CmdPrint.Text = "Print"
        Me.CmdPrint.UseVisualStyleBackColor = False
        '
        'CmdApaga
        '
        Me.CmdApaga.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdApaga.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdApaga.Location = New System.Drawing.Point(99, 82)
        Me.CmdApaga.Name = "CmdApaga"
        Me.CmdApaga.Size = New System.Drawing.Size(86, 29)
        Me.CmdApaga.TabIndex = 7
        Me.CmdApaga.Text = "Apagar"
        Me.CmdApaga.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btExecuta)
        Me.GroupBox2.Controls.Add(Me.txtQtdLido)
        Me.GroupBox2.Controls.Add(Me.c1fgDevDet)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtCodBarras)
        Me.GroupBox2.Location = New System.Drawing.Point(568, 168)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(439, 367)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        '
        'btExecuta
        '
        Me.btExecuta.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btExecuta.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btExecuta.Location = New System.Drawing.Point(312, 15)
        Me.btExecuta.Name = "btExecuta"
        Me.btExecuta.Size = New System.Drawing.Size(106, 31)
        Me.btExecuta.TabIndex = 28
        Me.btExecuta.Text = "Executar"
        Me.btExecuta.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 332)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 29)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Quantidade a Devolver"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.cbVerTodas)
        Me.GroupBox4.Controls.Add(Me.C1TGDevCab)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 11)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(554, 524)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        '
        'cbVerTodas
        '
        Me.cbVerTodas.AutoSize = True
        Me.cbVerTodas.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbVerTodas.Location = New System.Drawing.Point(412, 12)
        Me.cbVerTodas.Name = "cbVerTodas"
        Me.cbVerTodas.Size = New System.Drawing.Size(127, 25)
        Me.cbVerTodas.TabIndex = 18
        Me.cbVerTodas.Text = "Ver Todas"
        Me.cbVerTodas.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(258, 26)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Lista de Devoluções"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmDevolucao
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 547)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmDevolucao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devoluções"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.c1fgDevDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TGDevCab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dtCab As New DataTable
    Dim dtDestinos As New DataTable
    'Dim dtTaloes As New DataTable
    Dim dtAux As New DataTable
    Dim dtAuxGuia As New DataTable
    Dim db As New ClsSqlBDados





    Public Sub frmDevolucao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ActualizaCabeçalho()

            'Carregar dt Destinos
            Sql = "SELECT TercID, rtrim(TercID) + ' - ' + rtrim(NomeAbrev) as Destino from Terceiros where TipoTerc='F' Order by NomeAbrev"
            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtDestinos)

            'Carregar(ComboBox)
            Me.CbDestino.DataSource = dtDestinos
            Me.CbDestino.DisplayMember = "Destino"
            Me.CbDestino.ValueMember = "TercID"
            Me.CbDestino.Text = Nothing

            WindowState = FormWindowState.Maximized
            Me.txtQtdLido.Enabled = False

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmDevolucao_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmDevolucao_Load")
        End Try
    End Sub

    Private Sub ActualizaCabeçalho()
        Try

            dtCab.Clear()

            If cbVerTodas.Checked = True Then
                Sql = "SELECT DocCab.DocNr, DocCab.TercID, Terceiros.NomeAbrev, DocCab.DataDoc " & _
                    "FROM DocCab, Terceiros " & _
                    "WHERE DocCab.TercID = Terceiros.TercID " & _
                    "AND DocCab.EmpresaID = '" & xEmp & "' " & _
                    "AND DocCab.ArmazemID = '" & xArmz & "' " & _
                    "AND DocCab.TipoDocID = 'DF' " & _
                    "ORDER BY DocCab.DocNr DESC "
            Else
                Sql = "SELECT DocCab.DocNr, DocCab.TercID, Terceiros.NomeAbrev, DocCab.DataDoc " & _
                    "FROM DocCab, Terceiros " & _
                    "WHERE DocCab.TercID = Terceiros.TercID " & _
                    "AND DocCab.EmpresaID = '" & xEmp & "' " & _
                    "AND DocCab.ArmazemID = '" & xArmz & "' " & _
                    "AND DocCab.TipoDocID = 'DF' " & _
                    "AND DocCab.EstadoDoc = 'C' " & _
                    "ORDER BY DocCab.DocNr DESC "
            End If

            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtCab)
            txtCodBarras.Enabled = False

            If dtCab.Rows.Count > 0 Then txtCodBarras.Enabled = True

            With Me.C1TGDevCab
                .DataSource = dtCab
                dtCab.DefaultView.Sort = "DocNr Desc"
                .Columns("DocNr").Caption = "Doc"
                .Columns("TercId").Caption = "Cod"
                .Columns("NomeAbrev").Caption = "Destino"
                .Columns("DataDoc").Caption = "Data"
                .Columns("DataDoc").NumberFormat = "yyyy-MM-dd H:mm:ss"
                .Splits(0).DisplayColumns("DocNr").Width = 66
                .Splits(0).DisplayColumns("TercId").Width = 35
                .Splits(0).DisplayColumns("NomeAbrev").Width = 265
                .Splits(0).DisplayColumns("DataDoc").Width = 75
                .MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                .AllowDelete = False
                Dim ColCab As C1DisplayColumn
                For Each ColCab In Me.C1TGDevCab.Splits(0).DisplayColumns
                    ColCab.Style.Font = New Font("Arial", 10, FontStyle.Regular)
                    ColCab.HeadingStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    ColCab.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    ColCab.Locked = True
                Next
                .Refresh()
            End With
            AtualizaDetalhe()
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaCabeçalho")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaCabeçalho")
        End Try

    End Sub

    Private Sub CmdNova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNova.Click

        Try
            If Not Me.CbDestino.SelectedValue Is DBNull.Value Then
                If Me.CbDestino.SelectedValue <> "" Then
                    Dim xNovaSep As String = PesquisaMaxNumDoc("DF")
                    Dim xData As String = Format(CType(txtData.Text, Date), "yyyy-MM-dd H:mm:ss")
                    Dim xDestino As String = Me.CbDestino.SelectedValue

                    Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, " & _
                        "DataDoc, EstadoDoc, OperadorID) " & _
                        "VALUES('" & xEmp & "','" & xArmz & "','DF','" & xNovaSep & "'," & _
                        "'" & xDestino & "','" & xData & "','C','" & xUtilizador & "')"

                    Cmd = New SqlCommand(Sql, cn)
                    If cn.State = ConnectionState.Closed Then cn.Open()
                    Cmd.ExecuteNonQuery()

                    ActualizaCabeçalho()
                    Me.CbDestino.Text = Nothing
                    Me.CbDestino.Text = Nothing


                    txtData.Text = Now
                    Me.txtCodBarras.Focus()
                Else
                    MsgBox("Seleccione um Destino!")
                End If
            Else
                MsgBox("Seleccione um Destino!")
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CmdNova_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "CmdNova_Click")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub C1TGDevCab_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles C1TGDevCab.RowColChange
        TimerActDados.Stop()
        TimerActDados.Interval = 500
        TimerActDados.Start()
        Me.txtCodBarras.Focus()
    End Sub

    Private Sub TimerActDados_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerActDados.Tick
        TimerActDados.Stop()
        AtualizaDetalhe()
    End Sub

    Private Sub txtCodBarras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBarras.KeyPress

        Dim db As New ClsSqlBDados
        Dim nLinhas As Integer


        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If Me.txtCodBarras.Text.Length = 8 Then
                    'carregar talões
                    Dim xTalao As String = Me.txtCodBarras.Text

                    If VerificarRepetidos() Then
                        TalaoInvalido()
                    Else
                        Sql = "SELECT SerieID, ModeloID, CorID, TamID FROM Serie WHERE SerieID='" & xTalao & "' AND EstadoID='A' AND ArmazemID = '0000'"
                        If cn.State = ConnectionState.Closed Then cn.Open()
                        da = New SqlDataAdapter(Sql, cn)
                        nLinhas = Me.dtAux.Rows.Count
                        da.Fill(dtAux)

                        If Me.dtAux.Rows.Count = nLinhas Then
                            TalaoInvalido()
                            txtCodBarras.Clear()
                            Exit Sub
                        End If
                        Me.txtQtdLido.Text = dtAux.Rows.Count
                        Me.c1fgDevDet.AutoSizeCols()
                        GravaDevDet()
                        Application.DoEvents()
                        Me.txtCodBarras.Focus()

                    End If


                End If
                Me.txtCodBarras.SelectAll()

            End If





        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub AtualizaDetalhe()

        Try
            Dim xDocNr As String
            Dim db As New ClsSqlBDados

            xDocNr = Me.C1TGDevCab(Me.C1TGDevCab.Bookmark, "DocNr")
            dtAux.Clear()

            Sql = "SELECT DocDet.EmpresaID, DocDet.ArmazemID, DocDet.TipoDocID, DocDet.DocNr, DocDet.DocLnNr, DocDet.SerieID, DocDet.ModeloID, DocDet.CorID, DocDet.TamID, Serie.Obs AS Obs FROM DocDet INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmz & "') AND (DocDet.TipoDocID = 'DF') AND (DocDet.DocNr = '" & xDocNr & "')"

            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtAux)
            With Me.c1fgDevDet

                .DataSource = dtAux
                .Cols("SerieID").Caption = "Talão"
                .Cols("ModeloID").Caption = "Modelo"
                .Cols("CorID").Caption = "Cor"
                .Cols("TamID").Caption = "Tam"

                .Cols("SerieID").Width = 70
                .Cols("ModeloID").Width = 57
                .Cols("CorID").Width = 30
                .Cols("TamID").Width = 35
                .Cols("Obs").Width = 170

                .Cols("EmpresaID").Visible = False
                .Cols("ArmazemID").Visible = False
                .Cols("TipoDocID").Visible = False
                .Cols("DocNr").Visible = False
                .Cols("DocLnNr").Visible = False

            End With

            Me.txtCodBarras.Focus()
            Me.txtQtdLido.Text = dtAux.Rows.Count

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "AtualizaDetalhe")
        Catch ex As Exception
            ErroVB(ex.Message, "AtualizaDetalhe")
        Finally
            cn.Close()
            Sql = Nothing
        End Try

    End Sub

    Private Function VerificarRepetidos() As Boolean
        If dtAux.Rows.Count > 0 Then
            If dtAux.Select("SerieID = '" & Me.txtCodBarras.Text & "'", "").Length = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Private Sub CmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFechar.Click
        Close()
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        Dim xNumDoc As String = Me.C1TGDevCab(Me.C1TGDevCab.Row, "DocNr")
        ListaDevolucao(xNumDoc)
    End Sub

    Private Sub GravaDevDet()
        Try

            'ACRESCENTAR LINHAS À SEPARAÇÃO - NOTA : A LINHA LEVA JÁ O ESTADO G - (COM GUIA) 
            Dim xNumDoc As String = Me.C1TGDevCab(Me.C1TGDevCab.Bookmark, "DocNr")
            Dim xDocLnNr As String
            Dim xSerie As String
            Dim xModelo As String
            Dim xCor As String
            Dim xTam As String
            'Dim xFornDest As String = Me.C1TGDevCab(Me.C1TGDevCab.Row, "TercID")  'Me.CbDestino.SelectedValue
            dtAux.AcceptChanges()
            If dtAux.Rows.Count > 0 Then
                If cn.State = ConnectionState.Closed Then cn.Open()
                Sql = "SELECT ISNULL(MAX(DocLnNr),0)+1 FROM DocDet WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'DF' AND DocNr = '" & xNumDoc & "'"
                Cmd = New SqlCommand(Sql, cn)
                xDocLnNr = Cmd.ExecuteScalar
                If CInt(xDocLnNr) >= 1 Then
                    For Each r As DataRow In dtAux.Rows
                        xSerie = r("SerieID")
                        xModelo = r("ModeloID")
                        xCor = r("CorID")
                        xTam = r("TamID")

                        Sql = "SELECT Count(*) " & _
                            "FROM DocDet " & _
                            "WHERE EmpresaID='" & xEmp & "' " & _
                            "AND ArmazemID='" & xArmz & "' " & _
                            "AND TipoDocID='DF' " & _
                            "AND DocNR='" & xNumDoc & "' " & _
                            "AND SerieID = '" & xSerie & "'"
                        If cn.State = ConnectionState.Closed Then cn.Open()
                        Cmd = New SqlCommand(Sql, cn)
                        If Cmd.ExecuteScalar() = 0 Then

                            Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Qtd, EstadoLn, OperadorID) " & _
                               "VALUES ('" & xEmp & "', '" & xArmz & "', 'DF', '" & xNumDoc & "', " & xDocLnNr & ", '" & xSerie & "', '" & xModelo & "', '" & xCor & "', " & xTam & ", 1, 'G','" & xUtilizador & "')"
                            If cn.State = ConnectionState.Closed Then cn.Open()
                            Cmd = New SqlCommand(Sql, cn)
                            Cmd.ExecuteNonQuery()

                            xDocLnNr += 1

                        End If
                    Next
                End If

                Me.txtQtdLido.Text = Nothing
                dtAux.Clear()
                AtualizaDetalhe()
                Me.txtCodBarras.Text = Nothing
                Me.txtCodBarras.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub CmdApaga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdApaga.Click

        Try
            Dim xNumDoc As String = Me.C1TGDevCab(Me.C1TGDevCab.Bookmark, "DocNr")
            Sql = "SELECT COUNT(*) FROM DocDet WHERE docdet.EmpresaID = '" & xEmp & "' AND docdet.ArmazemID = '" & xArmz & "' AND docdet.TipoDocID = 'DF' AND docdet.DocNr = '" & xNumDoc & "'"
            Cmd = New SqlCommand(Sql, cn)
            If cn.State = ConnectionState.Closed Then cn.Open()
            If Cmd.ExecuteScalar = 0 Then
                Sql = "DELETE FROM DocCab WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'DF' AND DocNr = '" & xNumDoc & "'"
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd = New SqlCommand(Sql, cn)
                Cmd.ExecuteNonQuery()
                ActualizaCabeçalho()
                Application.DoEvents()
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CmdApagaSep_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "CmdApagaSep_Click")
        End Try
    End Sub

    Private Sub c1fgDevDet_BeforeDeleteRow(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles c1fgDevDet.BeforeDeleteRow

        Try
            Dim xNumDoc As String = Me.c1fgDevDet(Me.c1fgDevDet.Row, "DocNr")
            Dim xDocLnNr As Integer = Me.c1fgDevDet(Me.c1fgDevDet.Row, "DocLnNr")
            Dim xSerie As String = Me.c1fgDevDet(Me.c1fgDevDet.Row, "SerieID")

            Sql = "DELETE FROM DocDet WHERE EmpresaID='" & xEmp & "' AND ArmazemID='" & xArmz & "' AND TipoDocID='DF' AND DocNr='" & xNumDoc & "' AND DocLnNr=" & xDocLnNr
            If cn.State = ConnectionState.Closed Then cn.Open()
            Cmd = New SqlCommand(Sql, cn)
            Cmd.ExecuteNonQuery()

            ''ACTUALIZA ESTADO DO TALÃO NA TABELA SERIE

            'Sql = "UPDATE Serie SET EstadoID = 'S', ArmazemID = '" & xArmz & "' , DocNr = '', DtSaida = getdate() WHERE SerieID = '" & xSerie & "' and EstadoID = 'A'"

            'If cn.State = ConnectionState.Closed Then cn.Open()
            'Cmd = New SqlCommand(Sql, cn)
            'Cmd.ExecuteNonQuery()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TDBGSepDet_BeforeDelete")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TDBGSepDet_BeforeDelete")
        End Try
    End Sub

    Private Sub btExecuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExecuta.Click
        Try
            If MsgBox("Confirma que quer Executar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim xNumDoc As String = Me.C1TGDevCab(Me.C1TGDevCab.Bookmark, "DocNr")

                Sql = "UPDATE DocCab SET EstadoDoc = 'E'" & _
                    "WHERE EmpresaID='" & xEmp & "'" & _
                    "AND ArmazemId='" & xArmz & "'" & _
                    "AND TipoDocID='DF'" & _
                    "AND DocNr = '" & xNumDoc & "'"

                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd.ExecuteNonQuery()

                ActualizaCabeçalho()

            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CmdApagaSep_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "CmdApagaSep_Click")
        End Try

    End Sub

    Private Sub cbVerTodas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodas.CheckedChanged
        ActualizaCabeçalho()
    End Sub

    Private Function VerificarSeparado(ByVal xTalao As String) As Boolean


        'VERIFICAR SE JÁ ESTÁ SEPARADO PARA ALGUMA CASA
        Sql = "SELECT COUNT(*) FROM  DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr " & _
        "WHERE DocCab.ArmazemID = '" & xArmz & "' AND DocDet.TipoDocID = 'SE' AND DocDet.SerieID = '" & xTalao & "' AND DocDet.EstadoLn = 'G'"

        If db.GetDataValue(Sql) > 0 Then
            If MsgBox("O TALÃO ESTÁ EM SEPARAÇÃO. APAGAR DA SEPARAÇÃO?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Sql = "DELETE FROM DOCDET WHERE EMPRESAID = '" & xEmp & "' AND ARMAZEMID = '" & xArmz & "' AND TIPODOCID = 'SE' AND SERIEID = '" & xTalao & "' AND ESTADOLN = 'G'"
                db.ExecuteData(Sql)
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function


End Class
