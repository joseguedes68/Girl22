Imports System.Data.SqlClient
Imports C1.Win.C1TrueDBGrid



Public Class frmManutEncClientes




    'TODO: ACRESCENTAR UMA GRID DE TAMANHOS COM A QTD EXECUTADA
    'TODO: FALTA COLOCAR A FOTO NO REPORT
    'TODO: FALTA O REPORT DAS ENCOMENDAS
    'TODO: FALTA UM FORM PARA LANÇAR AS OBS DAS FICHAS
    'TODO: COLOCAR AS OBS DOS TALÕES NO REPORT

    Inherits System.Windows.Forms.Form

    Dim WithEvents Dgrid As New DataGridView

    Dim dtForn As New DataTable
    Dim dtClientes As New DataTable
    Dim dtGrupo As New DataTable
    Dim dtTipo As New DataTable
    Dim dtCor As New DataTable
    Dim dtLinha As New DataTable
    Dim DtDropDown As New DataTable

    Dim DtDetTam As New DataTable
    Dim Contador As Integer
    Dim daEnc As SqlDataAdapter
    Dim QtdEnc As Integer = 0
    Dim LnAux As String

    Dim xNrEnc As String
    Dim xNrLn As String
    Dim xForn As String
    Dim xCliente As String
    Dim xRefForn As String
    Dim xCorForn As String
    Dim xPrCusto As String
    Dim xDtEntrega As String
    Dim xGrupoID As String
    Dim xTipoID As String
    Dim xAltura As String
    Dim xModeloID As String
    Dim xCorID As String
    Dim xModCorDescr As String
    Dim xLinhaId As String
    Dim xPrecoEtiqueta As String
    Dim xObs As String
    Dim xQtdEnc As Double
    Dim xEstadoEnc As String
    Dim xTGerado As String
    Dim xDataDoc As String
    Dim xload As Boolean = False


    Friend WithEvents CmdFechar As System.Windows.Forms.Button
    Friend WithEvents cbGrupo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Friend WithEvents cbTipo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Friend WithEvents cbCor As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Friend WithEvents cbLinha As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Friend WithEvents cbReport As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btListarEncFoto As System.Windows.Forms.Button
    Friend WithEvents btUltRef As System.Windows.Forms.Button
    Friend WithEvents btFecharEncomenda As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btListaConfFact As System.Windows.Forms.Button
    Friend WithEvents btForn As System.Windows.Forms.Button
    Friend WithEvents cbClientes As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Dim CmdBuilder As SqlCommandBuilder


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
    Friend WithEvents gbTamanhos As System.Windows.Forms.GroupBox
    Friend WithEvents C1DGEncDetTam As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GirldataSet As GirlRootName.GirlDataSet
    Friend WithEvents C1DGEnc As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents CmdNovo As System.Windows.Forms.Button
    Friend WithEvents CmdPrintTaloes As System.Windows.Forms.Button
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents TimerFoto As System.Windows.Forms.Timer
    Friend WithEvents CmdPrintEnc As System.Windows.Forms.Button
    Friend WithEvents cbExecutadas As System.Windows.Forms.CheckBox
    Friend WithEvents cbForn As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Friend WithEvents cbEstado As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Friend WithEvents btRelaTaloes As System.Windows.Forms.Button
    Friend WithEvents btGerarRef As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManutEncClientes))
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style9 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style10 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style11 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style12 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style13 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style14 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style15 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style16 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style17 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style18 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style19 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style20 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style21 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style22 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style23 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style24 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style25 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style26 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style27 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style28 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style29 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style30 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style31 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style32 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style33 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style34 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style35 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style36 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style37 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style38 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style39 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style40 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style41 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style42 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style43 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style44 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style45 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style46 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style47 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style48 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style49 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style50 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style51 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style52 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style53 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style54 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style55 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style56 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Me.gbTamanhos = New System.Windows.Forms.GroupBox()
        Me.C1DGEncDetTam = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.CmdNovo = New System.Windows.Forms.Button()
        Me.CmdPrintTaloes = New System.Windows.Forms.Button()
        Me.btListarEncFoto = New System.Windows.Forms.Button()
        Me.CmdPrintEnc = New System.Windows.Forms.Button()
        Me.TimerFoto = New System.Windows.Forms.Timer(Me.components)
        Me.btRelaTaloes = New System.Windows.Forms.Button()
        Me.cbExecutadas = New System.Windows.Forms.CheckBox()
        Me.cbForn = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.cbEstado = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.btGerarRef = New System.Windows.Forms.Button()
        Me.CmdFechar = New System.Windows.Forms.Button()
        Me.cbGrupo = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.cbTipo = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.cbCor = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.cbLinha = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.cbReport = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btUltRef = New System.Windows.Forms.Button()
        Me.btFecharEncomenda = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btListaConfFact = New System.Windows.Forms.Button()
        Me.btForn = New System.Windows.Forms.Button()
        Me.cbClientes = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.C1DGEnc = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GirldataSet = New GirlRootName.GirlDataSet()
        Me.gbTamanhos.SuspendLayout()
        CType(Me.C1DGEncDetTam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbForn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbLinha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cbClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1DGEnc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirldataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbTamanhos
        '
        Me.gbTamanhos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbTamanhos.Controls.Add(Me.C1DGEncDetTam)
        Me.gbTamanhos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTamanhos.Location = New System.Drawing.Point(8, 537)
        Me.gbTamanhos.Name = "gbTamanhos"
        Me.gbTamanhos.Size = New System.Drawing.Size(488, 67)
        Me.gbTamanhos.TabIndex = 15
        Me.gbTamanhos.TabStop = False
        Me.gbTamanhos.Text = "Tamanhos"
        '
        'C1DGEncDetTam
        '
        Me.C1DGEncDetTam.ColumnInfo = "10,1,0,0,0,95,Columns:0{Width:21;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1DGEncDetTam.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1DGEncDetTam.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1DGEncDetTam.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1DGEncDetTam.Location = New System.Drawing.Point(12, 17)
        Me.C1DGEncDetTam.Name = "C1DGEncDetTam"
        Me.C1DGEncDetTam.Rows.DefaultSize = 19
        Me.C1DGEncDetTam.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1DGEncDetTam.Size = New System.Drawing.Size(470, 42)
        Me.C1DGEncDetTam.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1DGEncDetTam.Styles"))
        Me.C1DGEncDetTam.TabIndex = 0
        '
        'PictureBox
        '
        Me.PictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox.Location = New System.Drawing.Point(1073, 9)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(284, 187)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox.TabIndex = 22
        Me.PictureBox.TabStop = False
        '
        'CmdNovo
        '
        Me.CmdNovo.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdNovo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNovo.Location = New System.Drawing.Point(8, 15)
        Me.CmdNovo.Name = "CmdNovo"
        Me.CmdNovo.Size = New System.Drawing.Size(82, 72)
        Me.CmdNovo.TabIndex = 23
        Me.CmdNovo.Text = "Nova"
        Me.CmdNovo.UseVisualStyleBackColor = False
        '
        'CmdPrintTaloes
        '
        Me.CmdPrintTaloes.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdPrintTaloes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrintTaloes.Location = New System.Drawing.Point(245, 18)
        Me.CmdPrintTaloes.Name = "CmdPrintTaloes"
        Me.CmdPrintTaloes.Size = New System.Drawing.Size(40, 21)
        Me.CmdPrintTaloes.TabIndex = 24
        Me.CmdPrintTaloes.TabStop = False
        Me.CmdPrintTaloes.Text = "..."
        Me.CmdPrintTaloes.UseVisualStyleBackColor = False
        '
        'btListarEncFoto
        '
        Me.btListarEncFoto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btListarEncFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btListarEncFoto.Location = New System.Drawing.Point(143, 46)
        Me.btListarEncFoto.Name = "btListarEncFoto"
        Me.btListarEncFoto.Size = New System.Drawing.Size(51, 20)
        Me.btListarEncFoto.TabIndex = 37
        Me.btListarEncFoto.Text = "C/Foto"
        Me.btListarEncFoto.UseVisualStyleBackColor = False
        '
        'CmdPrintEnc
        '
        Me.CmdPrintEnc.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdPrintEnc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrintEnc.Location = New System.Drawing.Point(97, 46)
        Me.CmdPrintEnc.Name = "CmdPrintEnc"
        Me.CmdPrintEnc.Size = New System.Drawing.Size(40, 20)
        Me.CmdPrintEnc.TabIndex = 25
        Me.CmdPrintEnc.TabStop = False
        Me.CmdPrintEnc.Text = "..."
        Me.CmdPrintEnc.UseVisualStyleBackColor = False
        '
        'TimerFoto
        '
        '
        'btRelaTaloes
        '
        Me.btRelaTaloes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btRelaTaloes.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btRelaTaloes.Location = New System.Drawing.Point(1248, 560)
        Me.btRelaTaloes.Name = "btRelaTaloes"
        Me.btRelaTaloes.Size = New System.Drawing.Size(93, 49)
        Me.btRelaTaloes.TabIndex = 27
        Me.btRelaTaloes.Text = "Relação de Talões"
        Me.btRelaTaloes.UseVisualStyleBackColor = False
        '
        'cbExecutadas
        '
        Me.cbExecutadas.AutoSize = True
        Me.cbExecutadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbExecutadas.Location = New System.Drawing.Point(501, 15)
        Me.cbExecutadas.Name = "cbExecutadas"
        Me.cbExecutadas.Size = New System.Drawing.Size(100, 20)
        Me.cbExecutadas.TabIndex = 30
        Me.cbExecutadas.Text = "Ver Todas"
        Me.cbExecutadas.UseVisualStyleBackColor = True
        '
        'cbForn
        '
        Me.cbForn.AllowColMove = True
        Me.cbForn.AllowColSelect = True
        Me.cbForn.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.cbForn.AlternatingRows = True
        Me.cbForn.CaptionHeight = 17
        Me.cbForn.CaptionStyle = Style1
        Me.cbForn.ColumnCaptionHeight = 17
        Me.cbForn.ColumnFooterHeight = 17
        Me.cbForn.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbForn.EvenRowStyle = Style2
        Me.cbForn.FetchRowStyles = False
        Me.cbForn.FooterStyle = Style3
        Me.cbForn.HeadingStyle = Style4
        Me.cbForn.HighLightRowStyle = Style5
        Me.cbForn.Images.Add(CType(resources.GetObject("cbForn.Images"), System.Drawing.Image))
        Me.cbForn.Location = New System.Drawing.Point(43, 373)
        Me.cbForn.Name = "cbForn"
        Me.cbForn.OddRowStyle = Style6
        Me.cbForn.RecordSelectorStyle = Style7
        Me.cbForn.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cbForn.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.cbForn.RowHeight = 15
        Me.cbForn.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cbForn.ScrollTips = False
        Me.cbForn.Size = New System.Drawing.Size(282, 112)
        Me.cbForn.Style = Style8
        Me.cbForn.TabIndex = 31
        Me.cbForn.TabStop = False
        Me.cbForn.Text = "C1TDBDdForn"
        Me.cbForn.Visible = False
        Me.cbForn.PropBag = resources.GetString("cbForn.PropBag")
        '
        'cbEstado
        '
        Me.cbEstado.AllowColMove = True
        Me.cbEstado.AllowColSelect = True
        Me.cbEstado.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.cbEstado.AlternatingRows = False
        Me.cbEstado.CaptionHeight = 17
        Me.cbEstado.CaptionStyle = Style9
        Me.cbEstado.ColumnCaptionHeight = 17
        Me.cbEstado.ColumnFooterHeight = 17
        Me.cbEstado.EvenRowStyle = Style10
        Me.cbEstado.FetchRowStyles = False
        Me.cbEstado.FooterStyle = Style11
        Me.cbEstado.HeadingStyle = Style12
        Me.cbEstado.HighLightRowStyle = Style13
        Me.cbEstado.Images.Add(CType(resources.GetObject("cbEstado.Images"), System.Drawing.Image))
        Me.cbEstado.Location = New System.Drawing.Point(837, 351)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.OddRowStyle = Style14
        Me.cbEstado.RecordSelectorStyle = Style15
        Me.cbEstado.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cbEstado.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.cbEstado.RowHeight = 15
        Me.cbEstado.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cbEstado.ScrollTips = False
        Me.cbEstado.Size = New System.Drawing.Size(317, 97)
        Me.cbEstado.Style = Style16
        Me.cbEstado.TabIndex = 32
        Me.cbEstado.TabStop = False
        Me.cbEstado.Text = "C1TrueDBDropdown1"
        Me.cbEstado.Visible = False
        Me.cbEstado.PropBag = resources.GetString("cbEstado.PropBag")
        '
        'btGerarRef
        '
        Me.btGerarRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGerarRef.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGerarRef.Location = New System.Drawing.Point(964, 102)
        Me.btGerarRef.Name = "btGerarRef"
        Me.btGerarRef.Size = New System.Drawing.Size(83, 30)
        Me.btGerarRef.TabIndex = 33
        Me.btGerarRef.Text = "Gerar Refª"
        Me.btGerarRef.UseVisualStyleBackColor = False
        Me.btGerarRef.Visible = False
        '
        'CmdFechar
        '
        Me.CmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CmdFechar.Location = New System.Drawing.Point(964, 15)
        Me.CmdFechar.Name = "CmdFechar"
        Me.CmdFechar.Size = New System.Drawing.Size(83, 33)
        Me.CmdFechar.TabIndex = 34
        Me.CmdFechar.Text = "Fechar"
        Me.CmdFechar.UseVisualStyleBackColor = False
        '
        'cbGrupo
        '
        Me.cbGrupo.AllowColMove = True
        Me.cbGrupo.AllowColSelect = True
        Me.cbGrupo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.cbGrupo.AlternatingRows = False
        Me.cbGrupo.CaptionHeight = 17
        Me.cbGrupo.CaptionStyle = Style17
        Me.cbGrupo.ColumnCaptionHeight = 17
        Me.cbGrupo.ColumnFooterHeight = 17
        Me.cbGrupo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbGrupo.EvenRowStyle = Style18
        Me.cbGrupo.FetchRowStyles = False
        Me.cbGrupo.FooterStyle = Style19
        Me.cbGrupo.HeadingStyle = Style20
        Me.cbGrupo.HighLightRowStyle = Style21
        Me.cbGrupo.Images.Add(CType(resources.GetObject("cbGrupo.Images"), System.Drawing.Image))
        Me.cbGrupo.Location = New System.Drawing.Point(172, 351)
        Me.cbGrupo.Name = "cbGrupo"
        Me.cbGrupo.OddRowStyle = Style22
        Me.cbGrupo.RecordSelectorStyle = Style23
        Me.cbGrupo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cbGrupo.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.cbGrupo.RowHeight = 15
        Me.cbGrupo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cbGrupo.ScrollTips = False
        Me.cbGrupo.Size = New System.Drawing.Size(246, 100)
        Me.cbGrupo.Style = Style24
        Me.cbGrupo.TabIndex = 31
        Me.cbGrupo.TabStop = False
        Me.cbGrupo.Text = "C1TDBDdForn"
        Me.cbGrupo.Visible = False
        Me.cbGrupo.PropBag = resources.GetString("cbGrupo.PropBag")
        '
        'cbTipo
        '
        Me.cbTipo.AllowColMove = True
        Me.cbTipo.AllowColSelect = True
        Me.cbTipo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.cbTipo.AlternatingRows = False
        Me.cbTipo.CaptionHeight = 17
        Me.cbTipo.CaptionStyle = Style25
        Me.cbTipo.ColumnCaptionHeight = 17
        Me.cbTipo.ColumnFooterHeight = 17
        Me.cbTipo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbTipo.EvenRowStyle = Style26
        Me.cbTipo.FetchRowStyles = False
        Me.cbTipo.FooterStyle = Style27
        Me.cbTipo.HeadingStyle = Style28
        Me.cbTipo.HighLightRowStyle = Style29
        Me.cbTipo.Images.Add(CType(resources.GetObject("cbTipo.Images"), System.Drawing.Image))
        Me.cbTipo.Location = New System.Drawing.Point(331, 385)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.OddRowStyle = Style30
        Me.cbTipo.RecordSelectorStyle = Style31
        Me.cbTipo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cbTipo.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.cbTipo.RowHeight = 15
        Me.cbTipo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cbTipo.ScrollTips = False
        Me.cbTipo.Size = New System.Drawing.Size(378, 100)
        Me.cbTipo.Style = Style32
        Me.cbTipo.TabIndex = 31
        Me.cbTipo.TabStop = False
        Me.cbTipo.Text = "C1TDBDdForn"
        Me.cbTipo.Visible = False
        Me.cbTipo.PropBag = resources.GetString("cbTipo.PropBag")
        '
        'cbCor
        '
        Me.cbCor.AllowColMove = True
        Me.cbCor.AllowColSelect = True
        Me.cbCor.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.cbCor.AlternatingRows = False
        Me.cbCor.CaptionHeight = 17
        Me.cbCor.CaptionStyle = Style33
        Me.cbCor.ColumnCaptionHeight = 17
        Me.cbCor.ColumnFooterHeight = 17
        Me.cbCor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCor.EvenRowStyle = Style34
        Me.cbCor.FetchRowStyles = False
        Me.cbCor.FooterStyle = Style35
        Me.cbCor.HeadingStyle = Style36
        Me.cbCor.HighLightRowStyle = Style37
        Me.cbCor.Images.Add(CType(resources.GetObject("cbCor.Images"), System.Drawing.Image))
        Me.cbCor.Location = New System.Drawing.Point(532, 337)
        Me.cbCor.Name = "cbCor"
        Me.cbCor.OddRowStyle = Style38
        Me.cbCor.RecordSelectorStyle = Style39
        Me.cbCor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cbCor.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.cbCor.RowHeight = 15
        Me.cbCor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cbCor.ScrollTips = False
        Me.cbCor.Size = New System.Drawing.Size(246, 100)
        Me.cbCor.Style = Style40
        Me.cbCor.TabIndex = 31
        Me.cbCor.TabStop = False
        Me.cbCor.Text = "C1TDBDdForn"
        Me.cbCor.Visible = False
        Me.cbCor.PropBag = resources.GetString("cbCor.PropBag")
        '
        'cbLinha
        '
        Me.cbLinha.AllowColMove = True
        Me.cbLinha.AllowColSelect = True
        Me.cbLinha.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.cbLinha.AlternatingRows = False
        Me.cbLinha.CaptionHeight = 17
        Me.cbLinha.CaptionStyle = Style41
        Me.cbLinha.ColumnCaptionHeight = 17
        Me.cbLinha.ColumnFooterHeight = 17
        Me.cbLinha.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbLinha.EvenRowStyle = Style42
        Me.cbLinha.FetchRowStyles = False
        Me.cbLinha.FooterStyle = Style43
        Me.cbLinha.HeadingStyle = Style44
        Me.cbLinha.HighLightRowStyle = Style45
        Me.cbLinha.Images.Add(CType(resources.GetObject("cbLinha.Images"), System.Drawing.Image))
        Me.cbLinha.Location = New System.Drawing.Point(670, 385)
        Me.cbLinha.Name = "cbLinha"
        Me.cbLinha.OddRowStyle = Style46
        Me.cbLinha.RecordSelectorStyle = Style47
        Me.cbLinha.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cbLinha.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.cbLinha.RowHeight = 15
        Me.cbLinha.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cbLinha.ScrollTips = False
        Me.cbLinha.Size = New System.Drawing.Size(246, 100)
        Me.cbLinha.Style = Style48
        Me.cbLinha.TabIndex = 31
        Me.cbLinha.TabStop = False
        Me.cbLinha.Text = "C1TDBDdForn"
        Me.cbLinha.Visible = False
        Me.cbLinha.PropBag = resources.GetString("cbLinha.PropBag")
        '
        'cbReport
        '
        Me.cbReport.DisplayMember = "RptTaloes_3x2"
        Me.cbReport.FormattingEnabled = True
        Me.cbReport.Items.AddRange(New Object() {"RptTaloes_8x2", "RptTaloes_10x4SemTam", "RptTaloes_3x2", "RptRelTaloes", "RptRelaTaloesCB"})
        Me.cbReport.Location = New System.Drawing.Point(68, 19)
        Me.cbReport.Name = "cbReport"
        Me.cbReport.Size = New System.Drawing.Size(171, 21)
        Me.cbReport.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Talões :"
        '
        'btUltRef
        '
        Me.btUltRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btUltRef.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btUltRef.Location = New System.Drawing.Point(964, 57)
        Me.btUltRef.Name = "btUltRef"
        Me.btUltRef.Size = New System.Drawing.Size(83, 33)
        Me.btUltRef.TabIndex = 37
        Me.btUltRef.Text = "Ultima Refª"
        Me.btUltRef.UseVisualStyleBackColor = False
        '
        'btFecharEncomenda
        '
        Me.btFecharEncomenda.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btFecharEncomenda.Location = New System.Drawing.Point(501, 40)
        Me.btFecharEncomenda.Name = "btFecharEncomenda"
        Me.btFecharEncomenda.Size = New System.Drawing.Size(93, 40)
        Me.btFecharEncomenda.TabIndex = 38
        Me.btFecharEncomenda.Text = "Fechar Encomenda"
        Me.btFecharEncomenda.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Encomendas :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btListaConfFact)
        Me.GroupBox1.Controls.Add(Me.cbReport)
        Me.GroupBox1.Controls.Add(Me.CmdPrintEnc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CmdPrintTaloes)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btListarEncFoto)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(110, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(308, 76)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Listagens"
        '
        'btListaConfFact
        '
        Me.btListaConfFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btListaConfFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btListaConfFact.Location = New System.Drawing.Point(200, 46)
        Me.btListaConfFact.Name = "btListaConfFact"
        Me.btListaConfFact.Size = New System.Drawing.Size(85, 20)
        Me.btListaConfFact.TabIndex = 40
        Me.btListaConfFact.Text = "Conferência"
        Me.btListaConfFact.UseVisualStyleBackColor = False
        '
        'btForn
        '
        Me.btForn.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btForn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btForn.Location = New System.Drawing.Point(8, 112)
        Me.btForn.Name = "btForn"
        Me.btForn.Size = New System.Drawing.Size(127, 32)
        Me.btForn.TabIndex = 42
        Me.btForn.TabStop = False
        Me.btForn.Text = "Terceiros"
        Me.btForn.UseVisualStyleBackColor = False
        '
        'cbClientes
        '
        Me.cbClientes.AllowColMove = True
        Me.cbClientes.AllowColSelect = True
        Me.cbClientes.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.cbClientes.AlternatingRows = True
        Me.cbClientes.CaptionHeight = 17
        Me.cbClientes.CaptionStyle = Style49
        Me.cbClientes.ColumnCaptionHeight = 17
        Me.cbClientes.ColumnFooterHeight = 17
        Me.cbClientes.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbClientes.EvenRowStyle = Style50
        Me.cbClientes.FetchRowStyles = False
        Me.cbClientes.FooterStyle = Style51
        Me.cbClientes.HeadingStyle = Style52
        Me.cbClientes.HighLightRowStyle = Style53
        Me.cbClientes.Images.Add(CType(resources.GetObject("cbClientes.Images"), System.Drawing.Image))
        Me.cbClientes.Location = New System.Drawing.Point(1029, 312)
        Me.cbClientes.Name = "cbClientes"
        Me.cbClientes.OddRowStyle = Style54
        Me.cbClientes.RecordSelectorStyle = Style55
        Me.cbClientes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cbClientes.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.cbClientes.RowHeight = 15
        Me.cbClientes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cbClientes.ScrollTips = False
        Me.cbClientes.Size = New System.Drawing.Size(282, 112)
        Me.cbClientes.Style = Style56
        Me.cbClientes.TabIndex = 43
        Me.cbClientes.TabStop = False
        Me.cbClientes.Text = "C1TDBDdCli"
        Me.cbClientes.Visible = False
        Me.cbClientes.PropBag = resources.GetString("cbClientes.PropBag")
        '
        'C1DGEnc
        '
        Me.C1DGEnc.AllowColMove = False
        Me.C1DGEnc.AllowDelete = True
        Me.C1DGEnc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1DGEnc.CaptionHeight = 17
        Me.C1DGEnc.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1DGEnc.DataSource = Me.GirldataSet.Encomendas
        Me.C1DGEnc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1DGEnc.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1DGEnc.Images.Add(CType(resources.GetObject("C1DGEnc.Images"), System.Drawing.Image))
        Me.C1DGEnc.Images.Add(CType(resources.GetObject("C1DGEnc.Images1"), System.Drawing.Image))
        Me.C1DGEnc.Images.Add(CType(resources.GetObject("C1DGEnc.Images2"), System.Drawing.Image))
        Me.C1DGEnc.LinesPerRow = 3
        Me.C1DGEnc.Location = New System.Drawing.Point(8, 202)
        Me.C1DGEnc.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1DGEnc.Name = "C1DGEnc"
        Me.C1DGEnc.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1DGEnc.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1DGEnc.PreviewInfo.ZoomFactor = 75.0R
        Me.C1DGEnc.PrintInfo.PageSettings = CType(resources.GetObject("C1DGEnc.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1DGEnc.RecordSelectorWidth = 17
        Me.C1DGEnc.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1DGEnc.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1DGEnc.RowHeight = 15
        Me.C1DGEnc.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1DGEnc.Size = New System.Drawing.Size(1353, 321)
        Me.C1DGEnc.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.GridNavigation
        Me.C1DGEnc.TabIndex = 7
        Me.C1DGEnc.Text = "C1TrueDBGrid2"
        Me.C1DGEnc.PropBag = resources.GetString("C1DGEnc.PropBag")
        '
        'GirldataSet
        '
        Me.GirldataSet.DataSetName = "GirldataSet"
        Me.GirldataSet.Locale = New System.Globalization.CultureInfo("pt-PT")
        Me.GirldataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmManutEncClientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1369, 623)
        Me.Controls.Add(Me.cbClientes)
        Me.Controls.Add(Me.btForn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btFecharEncomenda)
        Me.Controls.Add(Me.btUltRef)
        Me.Controls.Add(Me.CmdNovo)
        Me.Controls.Add(Me.CmdFechar)
        Me.Controls.Add(Me.btGerarRef)
        Me.Controls.Add(Me.cbEstado)
        Me.Controls.Add(Me.cbLinha)
        Me.Controls.Add(Me.cbCor)
        Me.Controls.Add(Me.cbTipo)
        Me.Controls.Add(Me.cbGrupo)
        Me.Controls.Add(Me.cbForn)
        Me.Controls.Add(Me.cbExecutadas)
        Me.Controls.Add(Me.btRelaTaloes)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.gbTamanhos)
        Me.Controls.Add(Me.C1DGEnc)
        Me.Name = "frmManutEncClientes"
        Me.Text = "frmManutEnc"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbTamanhos.ResumeLayout(False)
        CType(Me.C1DGEncDetTam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbForn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbLinha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cbClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1DGEnc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirldataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmManutEnc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New ClsSqlBDados

        Try

            xload = True
            'Carregar Encomendas
            C1DGEnc.RowHeight = 20
            CarregarDadosEnc()
            Arrancar_C1DGEnc()
            cbReport.SelectedItem = "RptTaloes_3x2"

            'REGULARIZAR TIPOS
            Sql = "UPDATE Encomendas SET TipoID = Modelos.TipoID FROM  Encomendas INNER JOIN Modelos ON Encomendas.ModeloID = Modelos.ModeloID AND Encomendas.TipoID <> Modelos.TipoID"
            db.ExecuteData(Sql)

            'FECHAR ENCOMENDAS EXECUTADAS
            Sql = "UPDATE ENCOMENDAS SET ESTADOENC='E' WHERE NrENC in (SELECT CRIADOS.EncCriada EncExecutadas FROM (SELECT Encomendas.NrEnc AS EncParaExecutar FROM Encomendas INNER JOIN Serie ON Encomendas.NrEnc = Serie.NrEnc WHERE (Encomendas.TGerado = 'TRUE') AND (Serie.EstadoID = 'G') AND (Encomendas.EstadoEnc = 'C') GROUP BY Encomendas.NrEnc) AS NEXECUTADOS RIGHT OUTER JOIN (SELECT NrEnc AS EncCriada FROM Encomendas AS Encomendas_1 WHERE (TGerado = 'TRUE') AND (EstadoEnc = 'C') GROUP BY NrEnc) AS CRIADOS ON NEXECUTADOS.EncParaExecutar = CRIADOS.EncCriada WHERE (NEXECUTADOS.EncParaExecutar IS NULL))"
            db.ExecuteData(Sql)

            'Carregar DropDown Fornecedores
            Sql = "SELECT TercID as Forn, NomeAbrev as Nome FROM Terceiros ORDER BY Nome"
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtForn)
            With cbForn
                .Width = 250
                .DataSource = dtForn
                .DisplayColumns(0).Width = 40
                .DisplayColumns(1).Width = 180
                .AlternatingRows = True
                .EvenRowStyle.BackColor = Color.Khaki
            End With

            'Carregar DropDown Clientes
            Sql = "SELECT TercID as Forn, NomeAbrev as Nome FROM Terceiros ORDER BY Nome"
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtClientes)
            With cbClientes
                .Width = 250
                .DataSource = dtClientes
                .DisplayColumns(0).Width = 40
                .DisplayColumns(1).Width = 180
                .AlternatingRows = True
                .EvenRowStyle.BackColor = Color.Ivory
            End With


            'Carregar DropDown Grupos
            Sql = "SELECT GrupoID AS Grupo, GrupoDesc AS Descrição FROM Grupos ORDER BY GrupoDesc"
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtGrupo)
            With cbGrupo
                .Width = 250
                .DataSource = dtGrupo
                .DisplayColumns(0).Width = 40
                .DisplayColumns(1).Width = 180
                .AlternatingRows = True
                .EvenRowStyle.BackColor = Color.Khaki
            End With

            'Carregar DropDown Tipos
            Sql = "SELECT TipoId AS Tipo, DescrTipo AS Descrição FROM Tipos ORDER BY Ordem"
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtTipo)
            With cbTipo
                .Width = 350
                .DataSource = dtTipo
                .DisplayColumns(0).Width = 40
                .DisplayColumns(1).Width = 280
                .AlternatingRows = True
                .EvenRowStyle.BackColor = Color.Khaki
            End With

            'Carregar DropDown Cores
            Sql = "SELECT CorID AS Cor, DescrCor AS Descrição FROM Cores ORDER BY DescrCor"
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtCor)
            With cbCor
                .Width = 250
                .DataSource = dtCor
                .DisplayColumns(0).Width = 40
                .DisplayColumns(1).Width = 180
                .AlternatingRows = True
                .EvenRowStyle.BackColor = Color.Khaki
            End With

            'Carregar DropDown Linhas
            Sql = "SELECT LinhaID AS Linha, DescrLinha AS Descrição FROM Linhas ORDER BY DescrLinha"
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtLinha)
            With cbLinha
                .Width = 250
                '.Width = 0
                .DataSource = dtLinha
                .DisplayColumns(0).Width = 40
                .DisplayColumns(1).Width = 180
                .AlternatingRows = True
                .EvenRowStyle.BackColor = Color.Khaki

            End With

            'Carregar DropDown Estado

            DtDropDown.Columns.Add("EstadoID", GetType(String))
            DtDropDown.Columns.Add("Estado", GetType(String))
            DtDropDown.Rows.Add(New Object() {"P", "Pendente"})
            DtDropDown.Rows.Add(New Object() {"C", "Confirmado"})
            With Me.cbEstado
                .DataSource = DtDropDown
                .DisplayColumns(0).Width = 15
                .DisplayColumns(1).Width = 90
                .Width = 115
                .EvenRowStyle.BackColor = Color.Khaki
            End With

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmManutEnc_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmManutEnc_Load")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub CmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNovo.Click
        'TODO: QUANDO CLIK NOVO IMEDIATAMENTE DEPOIS DE APAGAR A ULTIMA LINHA DÁ ERRO!!

        Dim db As New ClsSqlBDados
        Dim xNovaEnc As String = ""

        Try

            Sql = "SELECT ISNULL(MAX(NrEnc),0) NrEnc FROM Encomendas WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "'"
            xNovaEnc = db.GetDataValue(Sql)

            If Not xNovaEnc = "0" Then
                If xNovaEnc.ToString.Substring(0, 4) <> Year(Today) Then
                    xNovaEnc = Year(Today) & "0000"
                End If
            Else
                xNovaEnc = Year(Today) & "0000"
            End If
            Dim Incrementar As Integer = Microsoft.VisualBasic.Right(xNovaEnc, 4)
            Incrementar += 1
            xNovaEnc = xNovaEnc.Substring(0, 4) & Format(Incrementar, "0000")



            Sql = "INSERT INTO Encomendas (EmpresaID, ArmazemID, NrEnc, LnEnc, FornId, RefForn, CorForn, PrCusto, DtEntrega, GrupoID, TipoID, Altura, ModeloID, CorID, ModCorDescr, LinhaID, PrecoEtiqueta, Obs, EstadoEnc, TGerado, DataDoc, OperadorID) " & _
               "VALUES ('" & xEmp & "', '" & xArmz & "', '" & xNovaEnc & "', '1', '', '', '',0,'" & Format(Today().AddDays(10), "yyyy-MM-dd") & "','','','','','','','',0,'', 'P',0,GETDATE(),'" & xUtilizador & "')"
            db.ExecuteData(Sql)

            CarregarDadosEnc()
            Me.C1DGEnc.Focus()
            Me.C1DGEnc.Col = 4
            Me.C1DGEnc.MoveLast()

            'Me.GirldataSet.Tables("Encomendas").Rows.Add(New Object() {xEmp, xArmz, xNumDocNovo, "1", "", "", "", 0, Today().AddDays(10), "", "", "", "", "", "", "", 0, "", "P", False, Now(), xUtilizador, Now()})
            'Dim UltReg As Integer = Me.C1DGEnc.Splits(0).Rows.Count - 1 
            'Me.GirldataSet.Tables("Encomendas").Rows(UltReg)("OperadorID") = xUtilizador
            'Me.GirldataSet.Tables("Encomendas").Rows(UltReg)("DtRegisto") = Now
            ''Quando uma encomenda é criada, fica no Estado P-Pendente 
            'Me.GirldataSet.Tables("Encomendas").Rows(UltReg)("EstadoEnc") = "P"
            'Me.GirldataSet.Tables("Encomendas").Rows(UltReg)("TGerado") = False
            'GirldataSet.Encomendas.AcceptChanges()
            'Me.daEnc.Update(Me.GirldataSet, "Encomendas")
            'GravaEncomenda()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CmdNovo_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "CmdNovo_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub btGerarRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGerarRef.Click
        Try
            Dim xMaximo As String = ""
            Dim xMaxMod As String = ""
            Dim xMaxEnc As String = ""
            If Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID") Is DBNull.Value Then Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID") = ""
            If Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") Is DBNull.Value Then Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") = ""
            If Trim(Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID")) = "" Then
                If Trim(Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID")) <> "" Then
                    Dim xGrupo As String = Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID")
                    Sql = "SELECT MAX(ModeloID) FROM Modelos  where GrupoID = '" & xGrupo & "'GROUP BY GrupoID"
                    Cmd = New SqlCommand(Sql, cn)
                    If cn.State = ConnectionState.Closed Then cn.Open()
                    If Not Cmd.ExecuteScalar Is DBNull.Value Then
                        xMaxMod = Cmd.ExecuteScalar
                    End If
                    Sql = "SELECT MAX(ModeloID) FROM Encomendas  where GrupoID = '" & xGrupo & "'GROUP BY GrupoID"
                    Cmd = New SqlCommand(Sql, cn)
                    If cn.State = ConnectionState.Closed Then cn.Open()
                    If Not Cmd.ExecuteScalar Is DBNull.Value Then
                        xMaxEnc = Cmd.ExecuteScalar
                    End If
                    If xMaxMod > xMaxEnc Then
                        xMaximo = xMaxMod
                    Else
                        xMaximo = xMaxEnc
                    End If
                    If xMaximo = "" Then
                        MsgBox("Não existe Máximo para o Grupo")
                    Else
                        'xMaximo = Microsoft.VisualBasic.Right(xGrupo & xMaximo + 1, Len(xMaximo) - 1)
                        xMaximo = xMaximo + 1
                        If Len(xMaximo) = 4 Then xMaximo = "0" & xMaximo
                        If Len(xMaximo) = 3 Then xMaximo = "00" & xMaximo
                        If Len(xMaximo) = 2 Then xMaximo = "000" & xMaximo
                        If Len(xMaximo) = 1 Then xMaximo = "0000" & xMaximo
                        Sql = "SELECT count(*) FROM Modelos where ModeloID = '" & xMaximo & "'"
                        Cmd = New SqlCommand(Sql, cn)
                        If cn.State = ConnectionState.Closed Then cn.Open()
                        If Cmd.ExecuteScalar > 0 Then
                            MsgBox("A Refª seguinte (" & xMaximo & ") já existe noutro Grupo. Fazer geração manual!")
                            Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") = ""
                        Else
                            Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") = xMaximo
                        End If
                    End If
                Else
                    MsgBox("Falta o Grupo!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CmdPrintTaloes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintTaloes.Click
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

            For I = 0 To Me.C1DGEnc.SelectedRows.Count - 1
                If Not Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "TGerado").GetType.Name = "String" Then
                    If Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "TGerado") = True Then
                        xFiltro = xFiltro & "'" & Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "NrEnc") & "',"
                    End If
                End If
            Next
            If Len(xFiltro) > 0 Then
                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)
                frmRpt = New frmReport
                With frmRpt
                    .MdiParent = frmMenuCelfGest
                    '.MdiParent = frmMenuGirl
                    .StartPosition = FormStartPosition.CenterScreen
                    'Sql = "SELECT S.SerieID, M.GrupoID, M.TipoID, S.ModeloID, S.CorID, S.TamID, C.ModCorDescr, S.PrecoEtiqueta, S.ModeloID + S.CorID Foto, L.DescrLinha, S.Obs " & _
                    '        "FROM Serie S, Modelos M, ModeloCor C, Linhas L WHERE(S.ModeloID = M.ModeloID) AND S.ModeloID = C.ModeloID AND S.CorID = C.CorID AND M.LinhaID = L.LinhaID AND S.NrEnc in (" & xFiltro & ") ORDER BY S.ModeloID, S.CorID, S.TamID"
                    Sql = "SELECT S.SerieID, M.GrupoID, M.TipoID, S.ModeloID, S.CorID, S.TamID, C.ModCorDescr, S.PrecoEtiqueta, S.ModeloID + S.CorID AS Foto, L.DescrLinha, S.Obs, Product.ProductCode, Product.ProductDescription, Cores.DescrCor FROM Serie AS S INNER JOIN Modelos AS M ON S.ModeloID = M.ModeloID INNER JOIN ModeloCor AS C ON S.ModeloID = C.ModeloID AND S.CorID = C.CorID INNER JOIN Linhas AS L ON M.LinhaID = L.LinhaID INNER JOIN Product ON S.ProductCode = Product.ProductCode INNER JOIN Cores ON S.CorID = Cores.CorID WHERE (S.NrEnc IN (" & xFiltro & ")) ORDER BY S.ModeloID, S.CorID, S.TamID"
                    .C1RptTaloes.Load(xRptPath & RptSelect & ".xml", "Talões")
                    .C1RptTaloes.DataSource.ConnectionString = sconnectionstringReport
                    .C1RptTaloes.DataSource.RecordSource = Sql

                    '.C1PrtPreview.Document = .C1RptTaloes.Document
                    '.Show()
                    JustPrint(.C1RptTaloes)

                End With
                Me.WindowState = FormWindowState.Minimized
            Else
                MsgBox("NÃO TEM NADA SELECCIONADO", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmManutEnc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim db As New ClsSqlBDados

        Try
            GravaEncomenda()
            Me.daEnc.Update(Me.GirldataSet, "Encomendas")
            'frmObsSerie.Close()

            Sql = "UPDATE Empresas SET Var2 ='0' WHERE EmpresaID = '" & xEmp & "'"
            db.ExecuteData(Sql)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btRelaTaloes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRelaTaloes.Click
        'TODO: LISTAR RELAÇÃO DE TALÕES DA LINHA SELECCIONADA. PERMITIR INSERIR OBS POR TALÃO - TABELA SERIEOBS
        sFormChamador = Me.Name
        If C1DGEnc.Item(C1DGEnc.Row, "TG") = True Then
            frmObsSerie.StartPosition = FormStartPosition.CenterParent
            frmObsSerie.WindowState = FormWindowState.Normal
            frmObsSerie.ShowInTaskbar = False
            frmObsSerie.MaximizeBox = False
            frmObsSerie.MinimizeBox = False
            frmObsSerie.ShowDialog(Me)
        Else
            MsgBox("Talões não Gerados!!")
        End If
    End Sub

    Private Sub CmdPrintEnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintEnc.Click
        Try
            'TODO: FAZER REPORT DA ENCOMENDA
            Dim I As Int64
            Dim xGrupo As String
            Dim xFiltro As String = ""
            For I = 0 To Me.C1DGEnc.SelectedRows.Count - 1
                If Not Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "FornID") Is DBNull.Value Then
                    If Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "FornID") <> "" Then
                        xFiltro = xFiltro & "''" & Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "NrEnc") & "'',"
                        If Not Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "GrupoID") Is DBNull.Value Then
                            xGrupo = IIf(Me.C1DGEnc(Me.C1DGEnc.SelectedRows(0), "GrupoID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.SelectedRows(0), "GrupoID"))
                            If xGrupo <> IIf(Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "GrupoID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "GrupoID")) Then
                                MsgBox("Não pode Imprimir Grupos diferentes!")
                                Exit Sub
                            End If
                        End If
                    Else
                        MsgBox("Falta o Fornecedor na Encomenda : " & Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "NrEnc"))
                        Exit Sub
                    End If
                Else
                    MsgBox("Falta o Fornecedor na Encomenda : " & Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "NrEnc"))
                    Exit Sub
                End If
            Next
            If Len(xFiltro) > 0 Then



                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)
                Dim frm As New frmReport
                With frm
                    ds_Enc.Clear()
                    Sql = "EXEC prc_RptEncomenda @Filtro = '" + xFiltro + "'"
                    da = New SqlDataAdapter(Sql, cn)
                    da.Fill(ds_Enc)
                    If ds_Enc.Tables(0).Rows.Count > 10 Then Exit Sub

                    .C1RptEncomendas.Load(xRptPath & "RptEncomendas.xml", "Encomendas")
                    .C1RptEncomendas.DataSource.ConnectionString = sconnectionstringReport
                    .C1RptEncomendas.DataSource.RecordSource = "SELECT * from ##TempEncomenda"


                    JustPrint(.C1RptEncomendas)


                    '.C1PrtPreview.Document = .C1RptEncomendas.Document
                    '.C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize

                    '.MdiParent = frmMenuCelfGest
                    '.Show()
                End With
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": CmdPrintEnc_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": CmdPrintEnc_Click")
        Finally
            ds.Clear()
            ds.Dispose()
            da.Dispose()
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub CmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmManutEnc_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If xload = True Then
            GravaEncomenda()
            CarregarDadosEnc()
        End If
    End Sub

    Private Sub cbExecutadas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbExecutadas.CheckedChanged
        GravaEncomenda()
        CarregarDadosEnc()
    End Sub


    Private Sub btFecharEncomenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFecharEncomenda.Click
        Dim db As New ClsSqlBDados
        Try
            LnAux = Me.C1DGEnc.Row
            If Me.C1DGEnc.SelectedRows.Count > 0 Then

                Dim I As Int64
                Dim xFiltro As String = "("
                For I = 0 To Me.C1DGEnc.SelectedRows.Count - 1
                    xFiltro = xFiltro & "'" & Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "NrEnc") & "',"
                Next
                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)
                xFiltro = xFiltro & ")"
                If Len(xFiltro) > 7 Then

                    Sql = "UPDATE Encomendas SET EstadoEnc='E' where EmpresaID = '" & xEmp & "' and ArmazemID = '" & xArmz & "' and NrEnc in " & xFiltro
                    db.ExecuteData(Sql)

                    'Sql = "DELETE FROM SERIE WHERE NrEnc in " & xFiltro & " AND ESTADOID='G'"
                    'db.ExecuteData(Sql)

                    CarregarDadosEnc()
                    Me.C1DGEnc.Row = LnAux


                End If
            Else
                MsgBox("Não tem nenhuma encomenda seleccionada !!")
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": btFecharEncomenda_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": btFecharEncomenda_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub btListarEncFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListarEncFoto.Click
        Try
            'TODO: FAZER REPORT DA ENCOMENDA
            Dim I As Int64
            Dim xGrupo As String
            Dim xFiltro As String = ""
            For I = 0 To Me.C1DGEnc.SelectedRows.Count - 1
                If Not Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "FornID") Is DBNull.Value Then
                    If Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "FornID") <> "" Then
                        xFiltro = xFiltro & "''" & Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "NrEnc") & "'',"
                        If Not Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "GrupoID") Is DBNull.Value Then
                            xGrupo = IIf(Me.C1DGEnc(Me.C1DGEnc.SelectedRows(0), "GrupoID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.SelectedRows(0), "GrupoID"))
                            If xGrupo <> IIf(Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "GrupoID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "GrupoID")) Then
                                MsgBox("Não pode Imprimir Grupos diferentes!")
                                Exit Sub
                            End If
                        End If
                    Else
                        MsgBox("Falta o Fornecedor na Encomenda : " & Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "NrEnc"))
                        Exit Sub
                    End If
                Else
                    MsgBox("Falta o Fornecedor na Encomenda : " & Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "NrEnc"))
                    Exit Sub
                End If
            Next
            If Len(xFiltro) > 0 Then



                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)
                Dim frm As New frmReport
                With frm
                    ds_Enc.Clear()
                    Sql = "EXEC prc_RptEncomenda @Filtro = '" + xFiltro + "'"
                    da = New SqlDataAdapter(Sql, cn)
                    da.Fill(ds_Enc)
                    If ds_Enc.Tables(0).Rows.Count > 10 Then Exit Sub

                    .C1RptEncomendasFoto.Load(xRptPath & "RptEncomendasFoto.xml", "Encomendas")
                    .C1RptEncomendasFoto.DataSource.ConnectionString = sconnectionstringReport
                    .C1RptEncomendasFoto.DataSource.RecordSource = "SELECT * from ##TempEncomenda"

                    JustPrint(.C1RptEncomendasFoto)

                    '.C1PrtPreview.Document = .C1RptEncomendasFoto.Document
                    '.C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize

                    '.MdiParent = frmMenuCelfGest
                    '.Show()
                End With
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": CmdPrintEnc_Click")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": CmdPrintEnc_Click")
        Finally
            ds.Clear()
            ds.Dispose()
            da.Dispose()
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub btUltRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUltRef.Click

        With frmUltRef
            .WindowState = FormWindowState.Normal
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog(Me)
        End With

    End Sub




    ' EVENTOS NA GRID C1DGENC

    Private Sub C1DGEnc_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DGEnc.FetchRowStyle
        'TODO: DEI AQUI UMA MARTELADA PARA NÃO DAR ERRO . (ESTÁVA A DAR ERRO NOS NULOS)
        Try
            If Not Me.C1DGEnc.Columns("TGerado").CellValue(e.Row) Is DBNull.Value Then
                If Not Me.C1DGEnc.Columns("EstadoEnc").CellValue(e.Row) = "C" Is DBNull.Value Then
                    If Me.C1DGEnc.Columns("TGerado").CellValue(e.Row) = True Then
                        'Dim xfont As New Font("Arial", 9, FontStyle.Regular)
                        'e.CellStyle.Font = xfont
                        e.CellStyle.ForeColor = System.Drawing.Color.White
                        e.CellStyle.BackColor = System.Drawing.Color.SaddleBrown
                    End If

                    If Me.C1DGEnc.Columns("EstadoEnc").CellValue(e.Row) = "C" And Me.C1DGEnc.Columns("TGerado").CellValue(e.Row) = False Then
                        e.CellStyle.ForeColor = System.Drawing.Color.Black
                        e.CellStyle.BackColor = System.Drawing.Color.SeaGreen
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub C1DGEnc_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DGEnc.FilterChange
        C1TrueDBGridFilterChange(C1DGEnc, Me.C1DGEnc.Columns, Me.GirldataSet.Tables("Encomendas"))
        gbTamanhos.Visible = False
        'btRelaTaloes.Visible = False
    End Sub

    Private Sub C1DGEnc_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles C1DGEnc.RowColChange
        Try

            If Me.C1DGEnc.Bookmark >= 0 Then
                If e.LastRow <> Me.C1DGEnc.Row Then  ' Eventos na mudança de linha !!
                    Act_Grelha_Tamanhos()
                    'GRAVA E ACTUALIZA A FOTO
                    Me.TimerFoto.Interval = 300
                    Me.TimerFoto.Enabled = True
                End If
            End If

            If Me.GirldataSet.Encomendas.Rows.Count > 0 Then
                ActualizaLocks()
            End If
            'Me.daEnc.Update(Me.GirldataSet, "Encomendas")
            GravaEncomenda()
            Select Case e.LastCol
                Case Is = 9                 'GRUPO
                    Act_Grelha_Tamanhos()
                Case Is = 12                 'MODELO
                    ActDadosModelo()
                    Act_Grelha_Tamanhos()
                Case Is = 13                'COR
                    ActDadosModeloCor()
                    'Case Is = 18                'ESTADO
                    '    Me.C1DGEnc(Me.C1DGEnc.Row, "DataDoc") = Now()
            End Select


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1DGEnc_RowColChange")
        Catch ex As Exception
            ErroVB(ex.Message, "C1DGEnc_RowColChange")
        Finally
            cn.Close()
            Sql = Nothing
        End Try
    End Sub

    Private Sub C1DGEnc_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles C1DGEnc.BeforeColEdit
        Dim db As New ClsSqlBDados
        Dim TGeradoAux As Double
        Try
            If Me.C1DGEnc.FilterActive Then Exit Sub
            ActualizaLocks()

            Select Case e.Column.DataColumn.DataField


                Case Is = "EstadoEnc"
                    e.Cancel = False
                    If Not Me.C1DGEnc(C1DGEnc.Row, "EstadoEnc") = "C" Then
                        If ExisteEnc(QtdEnc) = False Then
                            e.Cancel = True
                            MsgBox("Ainda não existe encomenda!")
                        End If
                    End If

                Case Is = "TGerado"          'GERADO
                    e.Cancel = True
                    'If ExisteEnc(QtdEnc) = False Then
                    '    e.Cancel = True
                    '    MsgBox("Ainda não existe encomenda!")
                    '    Exit Sub
                    'End If
                    If Not Me.C1DGEnc(C1DGEnc.Row, "TGerado") Is DBNull.Value Then
                        If Not Me.C1DGEnc(C1DGEnc.Row, "EstadoEnc") Is DBNull.Value Then
                            If Not Me.C1DGEnc(C1DGEnc.Row, "ModeloID") Is DBNull.Value Then
                                If Len(Trim(Me.C1DGEnc(C1DGEnc.Row, "ModeloID"))) > 0 Then
                                    If Len(Trim(Me.C1DGEnc(C1DGEnc.Row, "CorID"))) > 0 Then
                                        If Not Me.C1DGEnc(C1DGEnc.Row, "CorID") Is DBNull.Value Then
                                            If Not Me.C1DGEnc(C1DGEnc.Row, "TGerado") = "1" Then
                                                'Sql = "SELECT TGerado FROM ENCOMENDAS WHERE EmpresaID='" & xEmp & "' and ArmazemID='" & xArmz & "' and NrEnc='" & Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc") & "' and LnEnc='" & Me.C1DGEnc(Me.C1DGEnc.Row, "LnEnc") & "'"
                                                Sql = "SELECT COUNT(*) FROM SERIE WHERE NRENC='" & Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc") & "'"
                                                TGeradoAux = db.GetDataValue(Sql)
                                                If Not TGeradoAux > 0 Then
                                                    If Me.C1DGEnc(C1DGEnc.Row, "EstadoEnc") = "C" Then
                                                        If GravaModeloCor(Me.C1DGEnc(Me.C1DGEnc.Bookmark, "ModeloID"), Me.C1DGEnc(Me.C1DGEnc.Bookmark, "CorID")) = True Then
                                                            If GerarTaloes() = True Then
                                                                'ExportToGirl()
                                                                e.Cancel = False
                                                            Else
                                                                MsgBox("FALHA NO PROCESSO !!", MsgBoxStyle.Critical, "ERRO GRAVE")
                                                                e.Cancel = True
                                                            End If
                                                        End If
                                                    End If
                                                Else
                                                    e.Cancel = False
                                                    MsgBox("ESSES TALÕES JÁ FORAM GERADOS POR OUTRO UTILIZADOR!")
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If e.Cancel = True Then MsgBox("Não é possivel gerar Talões!!")

            End Select
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1DGEnc_BeforeColEdit")
        Catch ex As Exception
            ErroVB(ex.Message, "C1DGEnc_BeforeColEdit")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub C1DGEnc_BeforeColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles C1DGEnc.BeforeColUpdate

        Try

            If e.Column.Name = "Linha" Then
                If dtLinha.Compute("COUNT(Linha)", "Linha='" & Me.C1DGEnc.Columns("Linha").Text & "'") = 0 Then
                    MsgBox("ESSA LINHA NÃO EXISTE!!!")
                    e.Cancel = True
                End If
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "C1DGEnc_BeforeColUpdate")
        End Try



    End Sub

    Private Sub C1DGEnc_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles C1DGEnc.AfterColUpdate
        Try
            Select Case e.Column.Name

                Case Is = "Estado"
                    Me.C1DGEnc.MovePrevious()
                    Me.C1DGEnc.MoveNext()
                    If Me.C1DGEnc(Me.C1DGEnc.Row, "Estado") = "C" Then
                        Me.C1DGEnc(Me.C1DGEnc.Row, "DataDoc") = Now()
                    End If
                Case Is = "TG"
                    If Me.C1DGEnc(Me.C1DGEnc.Row, "TG") = True Then
                        Me.C1DGEnc.MovePrevious()
                        Me.C1DGEnc.MoveNext()
                    End If

            End Select
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1DGEnc_AfterColUpdate")
        Catch ex As Exception
            ErroVB(ex.Message, "C1DGEnc_AfterColUpdate")
        End Try
    End Sub

    Private Sub C1DGEnc_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles C1DGEnc.BeforeDelete
        Dim db As New ClsSqlBDados

        Try

            Dim xNrEnc As String = Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc").ToString

            If MsgBox("CONFIRMA QUE QUE APAGAR A ENCOMENDA " & xNrEnc & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                Sql = "SELECT COUNT(*) FROM SERIE WHERE NrEnc='" & xNrEnc & "'"
                If db.GetDataValue(Sql) > 0 Then
                    e.Cancel = True
                    MsgBox("Não pode apagar! Já tem fichas Geradas")
                End If
                LnAux = Me.C1DGEnc.Row
            Else
                e.Cancel = True
            End If

            'e.Cancel = True
            'If Not Me.C1DGEnc(Me.C1DGEnc.Row, "TGerado") Is DBNull.Value Then
            '    If Me.C1DGEnc(Me.C1DGEnc.Row, "TGerado") = False Then
            '        e.Cancel = False
            '    End If
            'End If
            'If e.Cancel = True Then
            '    MsgBox("Não pode apagar! Já tem fichas Geradas")
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub C1DGEnc_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DGEnc.AfterDelete

        Try

            Me.Validate()
            Me.daEnc.Update(Me.GirldataSet, "Encomendas")
            Me.GirldataSet.Tables("Encomendas").AcceptChanges()
            Me.C1DGEnc.Row = LnAux

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1DGEnc_AfterDelete")
        Catch ex As Exception
            ErroVB(ex.Message, "C1DGEnc_AfterDelete")
        End Try

    End Sub

    Private Sub C1DGEnc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DGEnc.Leave
        GravaEncomenda()
    End Sub

    Private Sub C1DGEnc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DGEnc.GotFocus
        With C1DGEnc
            .MarqueeStyle = MarqueeEnum.HighlightRowRaiseCell
        End With

        'DataGrid.SelectedRows.Clear()
    End Sub




    ' EVENTOS NA GRID C1DGEncDetTam

    Private Sub C1DGEncDetTam_RowColChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DGEncDetTam.RowColChange
        Actualizar_TotalTam()
    End Sub

    Private Sub C1DGEncDetTam_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DGEncDetTam.Validated

        Try
            'C1DGEncDetTam_LostFocus(sender, e)
            Dim QtdCol As Int16 = Me.C1DGEncDetTam.Cols.Count - 3
            Dim I As Int16
            xNrEnc = Me.C1DGEnc(Me.C1DGEnc.Bookmark, "NrEnc")
            'xNrEnc = Me.GirldataSet.Tables("Encomendas").Rows(Me.C1DGEnc.Bookmark)("NrEnc")
            'Dim xLnEnc As String = Me.GirldataSet.Tables("Encomendas").Rows(Me.C1DGEnc.Bookmark)("LnEnc")
            Dim xLnEnc As String = "1"

            For I = 2 To QtdCol
                Sql = "SELECT COUNT(*) FROM EncDetTam WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND NrEnc = '" & xNrEnc & "' AND LnEnc = " & xLnEnc & " AND TamID = '" & Me.C1DGEncDetTam(0, I) & "'"
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                If Cmd.ExecuteScalar() = 0 Then
                    Sql = "INSERT INTO EncDetTam(EmpresaID, ArmazemID, NrEnc, LnEnc, TamID, Qtd) " &
                          "VALUES('" & xEmp & "', '" & xArmz & "', '" & xNrEnc & "', " & xLnEnc & ", '" & Me.C1DGEncDetTam(0, I) & "', 0)"
                    Cmd = New SqlCommand(Sql, cn)
                    If cn.State = ConnectionState.Closed Then cn.Open()
                    Cmd.ExecuteNonQuery()
                End If
                Sql = "UPDATE EncDetTam " &
                      "SET Qtd = " & Me.C1DGEncDetTam(1, I) & " " &
                      "WHERE EmpresaID = '" & xEmp & "' " &
                      "AND ArmazemID = '" & xArmz & "' " &
                      "AND NrEnc = '" & xNrEnc & "' " &
                      "AND LnEnc = " & xLnEnc & " " &
                      "AND TamID = '" & Me.C1DGEncDetTam(0, I) & "'"
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd.ExecuteNonQuery()
                Sql = "DELETE EncDetTam WHERE Qtd=0"
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd.ExecuteNonQuery()
                cn.Close()
            Next
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1DGEncDetTam_Validated")
        Catch ex As Exception
            ErroVB(ex.Message, "C1DGEncDetTam_Validated")
        End Try

    End Sub


    ' FUNÇÕES E ROTINAS

    Friend Sub CarregarDadosEnc()
        Dim db As New ClsSqlBDados
        Try

            'TODO: FALTA CONTROLAR A SITUAÇÃO DE NÃO DEVOLVER NENHUMA ENCOMENDA
            'CARREGAR DATASET NA TABELA ENCOMENDAS
            GirldataSet.Tables("Encomendas").Clear()
            If cbExecutadas.Checked = True Then
                Sql = "SELECT EmpresaID, ArmazemID, NrEnc, LnEnc, FornId, RefForn, CorForn, PrCusto, DtEntrega, GrupoID, TipoID, Altura, ModeloID, CorID, ModCorDescr, LinhaID, PrecoEtiqueta, EstadoEnc, TGerado, Obs, QtdEnc, DataDoc, OperadorID, DtRegisto, ClienteID " &
                      "FROM Encomendas " &
                      "WHERE EmpresaID = '" & xEmp & "'  " &
                      "AND ArmazemID = '" & xArmz & "' "
                '"And EstadoEnc = 'E'"
            Else
                Sql = "SELECT EmpresaID, ArmazemID, NrEnc, LnEnc, FornId, RefForn, CorForn, PrCusto, DtEntrega, GrupoID, TipoID, Altura, ModeloID, CorID, ModCorDescr, LinhaID, PrecoEtiqueta, EstadoEnc, TGerado, Obs, QtdEnc, DataDoc, OperadorID, DtRegisto, ClienteID " &
                        "FROM Encomendas " &
                        "WHERE EmpresaID = '" & xEmp & "'  " &
                        "AND ArmazemID = '" & xArmz & "' " &
                        "And EstadoEnc <> 'E' And EstadoEnc <> 'F'"
            End If

            'db.GetData(Sql, Me.GirldataSet.Encomendas)

            daEnc = New SqlDataAdapter(Sql, cn)
            daEnc.Fill(Me.GirldataSet, "Encomendas")
            CmdBuilder = New SqlCommandBuilder(daEnc)
            'EXEMPLO: CmdBuilder.ConflictOption
            CmdBuilder.ConflictOption = ConflictOption.OverwriteChanges

            Me.C1DGEnc.MoveLast()


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarDadosEnc")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarDadosEnc")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Friend Sub Arrancar_C1DGEnc()

        Try
            'TODO: FALTA CONTROLAR A SITUAÇÃO DE NÃO DEVOLVER NENHUMA ENCOMENDA
            'ATENÇÃO retirei este comando
            'CarregarDadosEnc()

            'ARRANJAR A DATAGRID
            Dim coluna As C1DisplayColumn
            With Me.C1DGEnc
                With .Splits(0)
                    .DisplayColumns("EmpresaID").Visible = False
                    .DisplayColumns("ArmazemID").Visible = False
                    .DisplayColumns("NrEnc").Locked = True
                    .DisplayColumns("LnEnc").Visible = False
                    .DisplayColumns("OperadorID").Visible = False
                    .DisplayColumns("DtRegisto").Visible = False


                End With
                .FetchRowStyles = True
                .MarqueeStyle = MarqueeEnum.HighlightRowRaiseCell
                .Styles("HighlightRow").BackColor = Color.Pink
                .Columns("FornId").Caption = "Forn "
                '.Columns("ClienteID").Caption = "Cliente"
                .Columns("RefForn").Caption = "RefForn"
                .Columns("CorForn").Caption = "CorForn"
                .Columns("PrCusto").Caption = "PrCusto"
                .Columns("DtEntrega").Caption = "DtEntrega"
                .Columns("GrupoID").Caption = "Grupo"
                .Columns("TipoID").Caption = "Tipo"
                .Columns("Altura").Caption = "Altura"
                .Columns("ModeloID").Caption = "Modelo"
                .Columns("CorID").Caption = "Cor"
                .Columns("ModCorDescr").Caption = "Descrição"
                .Columns("LinhaId").Caption = "Linha"
                .Columns("PrecoEtiqueta").Caption = "PrTalão"
                .Columns("EstadoEnc").Caption = "Estado"
                .Columns("DataDoc").Caption = "Data"
                .Columns("TGerado").Caption = "TG"
                .Columns("PrCusto").NumberFormat = "Currency"
                .Columns("PrecoEtiqueta").NumberFormat = "Currency"
                .Columns("DtEntrega").NumberFormat = "yyyy-MM-dd"
                .Columns("DataDoc").NumberFormat = "yyyy-MM-dd"
                .Columns("RefForn").EditMask = "&&&&&&&&&&&&&&&&&&&&"
                .Columns("CorForn").EditMask = "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&"
                .Columns("ModCorDescr").EditMask = "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&"

                .Refresh()

                For Each coluna In Me.C1DGEnc.Splits(0).DisplayColumns
                    coluna.Style.Font = New Font("Arial", 8, FontStyle.Regular)
                    coluna.HeadingStyle.Font = New Font("Arial", 8, FontStyle.Bold)
                    coluna.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    coluna.Style.VerticalAlignment = AlignVertEnum.Center
                    coluna.AutoSize()
                Next
                .FilterBar = True
                .AllowFilter = False
                .FilterBarStyle.BackColor = Color.LightYellow
                .Splits(0).DisplayColumns("CorID").Width = 30
                '.Splits(0).DisplayColumns("ModCorDescr").Width = 200
                .Splits(0).DisplayColumns("Obs").Width = 95
                .Splits(0).DisplayColumns("FornId").Width = 45
                .Splits(0).DisplayColumns("TipoID").Width = 45
                .Splits(0).DisplayColumns("CorID").Width = 45

                .Splits(0).DisplayColumns("RefForn").Width = 50
                .Splits(0).DisplayColumns("CorForn").Width = 75
                .Splits(0).DisplayColumns("ModCorDescr").Width = 75

                .Splits(0).DisplayColumns("FornId").Style.HorizontalAlignment = AlignHorzEnum.Center
                '.Splits(0).DisplayColumns("ClienteID").Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("GrupoID").Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("TipoID").Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("CorID").Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("LinhaId").Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("EstadoEnc").Style.HorizontalAlignment = AlignHorzEnum.Center

            End With
            Me.C1DGEnc.Focus()
            Me.C1DGEnc.MoveLast()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "Arrancar_C1DGEnc")
        Catch ex As Exception
            ErroVB(ex.Message, "Arrancar_C1DGEnc")
        End Try
    End Sub

    Private Function GerarTaloes() As Boolean
        Dim db As New ClsSqlBDados
        GerarTaloes = False
        Try
            Dim xSerie As String
            Dim xContador As Integer
            Dim xModelo As String
            Dim xCor As String
            Dim xTam As String
            Dim xPrecoEtic As Double
            Dim xPrecoVND As Double
            Dim xData As String = Today.Year & "-" & Today.Month & "-" & Today.Day
            'IR BUSCAR O CONTADOR
            Sql = "SELECT ISNULL(MAX(RIGHT(SerieID,6)),0) AS NUM FROM Serie WHERE left(SerieID,2) = SUBSTRING(CONVERT(CHAR,GETDATE(),120),3,2)"
            Cmd = New SqlCommand(Sql, cn)
            If cn.State = ConnectionState.Closed Then cn.Open()
            If Cmd.ExecuteScalar > 0 Then
                xContador = Cmd.ExecuteScalar + 1
            Else
                xContador = 1
            End If
            'CARREGAR VARIAVEIS DA GRID C1DGENC
            With Me.C1DGEnc
                xModelo = Me.C1DGEnc(.Row, "ModeloID")
                xCor = Me.C1DGEnc(.Row, "CorID")
                xNrEnc = Me.C1DGEnc(.Row, "NrEnc")
                xPrecoEtic = Me.C1DGEnc(.Row, "PrecoEtiqueta")
                xPrecoVND = Me.C1DGEnc(.Row, "PrecoEtiqueta")
            End With

            Dim sProductCode As String = DevolveProductCode(xModelo).ToString

            Dim ANO As String = Today.Year
            ANO = Microsoft.VisualBasic.Right(ANO, 2)

            Dim I As Int16
            Dim J As Int16
            For I = 2 To Me.C1DGEncDetTam.Cols.Count - 3
                xTam = Me.C1DGEncDetTam(0, I)
                For J = 1 To Me.C1DGEncDetTam(1, I)
                    xSerie = ANO & Format(xContador, "000000")
                    Sql = "INSERT INTO  Serie (SerieID, ModeloID, CorID, TamID, ArmazemID, PrecoEtiqueta, PrecoVenda, NrEnc, DtEntrada, EstadoID, ProductCode, OperadorID ) " &
                          "VALUES ('" & xSerie & "', '" & xModelo & "', '" & xCor & "', '" & xTam & "', '" & xArmz & "', " & Format(xPrecoEtic, "#,##0.00") & ", " & Format(xPrecoEtic, "#,##0.00") & ", '" & xNrEnc & "', '" & xData & "', 'G','" & sProductCode & "','" & xUtilizador & "')"
                    Cmd = New SqlCommand(Sql, cn)
                    If cn.State = ConnectionState.Closed Then cn.Open()
                    Cmd.ExecuteNonQuery()
                    xContador += 1
                Next
            Next
            'Sql = "Update Encomendas set TGerado='1' WHERE EmpresaID='" & xEmp & "' and ArmazemID='" & xArmz & "' and NrEnc='" & Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc") & "' and LnEnc='" & Me.C1DGEnc(Me.C1DGEnc.Row, "LnEnc") & "' "
            'db.ExecuteData(Sql)

            'ImpFotos(xModelo & xCor)

            Return True
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GerarTaloes")
        Catch ex As Exception
            ErroVB(ex.Message, "GerarTaloes")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            cn.Close()
            Cmd.Dispose()
            Sql = Nothing
        End Try
    End Function

    Private Function ExisteModelo(ByVal xModeloID As String) As Boolean

        Dim db As New ClsSqlBDados

        Sql = "DELETE FROM Modelos WHERE len(ltrim(rtrim(ModeloID)))=0"
        db.ExecuteData(Sql)

        Sql = "SELECT COUNT(*) FROM Modelos Where ModeloID='" & xModeloID & "'"
        Cmd = New SqlCommand(Sql, cn)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim QtdMod As String = Cmd.ExecuteScalar
        Cmd.Dispose()
        If QtdMod = 1 Then ExisteModelo = True

    End Function

    Private Function ExisteModeloCor(ByVal xModeloID As String, ByVal xCorID As String) As Boolean

        Sql = "SELECT COUNT(*) FROM Modelos, ModeloCor Where Modelos.ModeloID = ModeloCor.ModeloID " &
                           "And Modelos.ModeloID='" & xModeloID & "' and ModeloCor.CorID='" & xCorID & "'"
        Cmd = New SqlCommand(Sql, cn)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim QtdModCor As String = Cmd.ExecuteScalar
        Cmd.Dispose()
        If QtdModCor = 1 Then ExisteModeloCor = True

    End Function

    Private Function ValidarLnEnc() As Boolean
        Try
            ValidarLnEnc = False
            If Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") Is DBNull.Value Then Exit Function
            If Me.C1DGEnc(Me.C1DGEnc.Row, "CorID") Is DBNull.Value Then Exit Function
            If Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID") Is DBNull.Value Then Exit Function
            If Me.C1DGEnc(Me.C1DGEnc.Row, "TipoID") Is DBNull.Value Then Exit Function
            If Me.C1DGEnc(Me.C1DGEnc.Row, "Altura") Is DBNull.Value Then Exit Function
            If Me.C1DGEnc(Me.C1DGEnc.Row, "ModCorDescr") Is DBNull.Value Then Exit Function
            If Me.C1DGEnc(Me.C1DGEnc.Row, "LinhaID") Is DBNull.Value Then Exit Function
            If Me.C1DGEnc(Me.C1DGEnc.Row, "EstadoEnc") = "P" Then Exit Function
            ValidarLnEnc = True


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ValidarLnEnc")
        Catch ex As Exception
            ErroVB(ex.Message, "ValidarLnEnc")

        End Try

    End Function

    Private Sub Actualizar_TotalTam()

        Try
            If Me.C1DGEncDetTam.Rows.Count = 2 Then
                Dim Coluna As Integer
                Dim Somatorio As Integer = 0
                For Coluna = 2 To Me.C1DGEncDetTam.Cols.Count - 3
                    If IsNumeric(Me.C1DGEncDetTam(1, Coluna)) Then
                        Somatorio += Me.C1DGEncDetTam(1, Coluna)
                    End If
                Next
                If Somatorio >= 0 Then
                    Me.C1DGEncDetTam(1, "Total") = Somatorio
                    Me.C1DGEncDetTam.Cols("Total").AllowEditing = False
                End If
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "Actualizar_TotalTam")
        Catch ex As Exception
            ErroVB(ex.Message, "Actualizar_TotalTam")
        End Try
    End Sub

    Private Function GravaModeloCor(ByVal xModeloID As String, ByVal xCorID As String) As Boolean

        Try
            GravaModeloCor = False
            Dim xRefForn As String
            Dim xCorForn As String
            Dim xGrupoID As String = ""
            Dim xTipoID As String = ""
            Dim xAltura As String = ""
            Dim xLinhaID As String = ""
            Dim xEscala As String = ""
            Dim xUnid As Integer = 0
            Dim xModCorDescr As String = ""
            Dim xFornId As String = ""
            Dim xPrCusto As Double = 0
            Dim xPrVnd As Double = 0
            Dim xEpoca As String = ""

            With Me.C1DGEnc
                If Me.C1DGEnc(.Row, "GrupoID") Is DBNull.Value Then Exit Function
                If Trim(Me.C1DGEnc(.Row, "GrupoID")).Length = 0 Then Exit Function
                If Me.C1DGEnc(.Row, "TipoID") Is DBNull.Value Then Exit Function
                If Trim(Me.C1DGEnc(.Row, "TipoID")).Length = 0 Then Exit Function
                If Me.C1DGEnc(.Row, "Altura") Is DBNull.Value Then Exit Function
                If Trim(Me.C1DGEnc(.Row, "Altura")).Length = 0 Then Exit Function
                If Me.C1DGEnc(.Row, "LinhaID") Is DBNull.Value Then Exit Function
                If Trim(Me.C1DGEnc(.Row, "LinhaID")).Length = 0 Then Exit Function
                If Me.C1DGEnc(.Row, "ModCorDescr") Is DBNull.Value Then Exit Function
                If Trim(Me.C1DGEnc(.Row, "ModCorDescr")).Length = 0 Then Exit Function
                If Me.C1DGEnc(.Row, "FornId") Is DBNull.Value Then Exit Function
                If Trim(Me.C1DGEnc(.Row, "FornId")).Length = 0 Then Exit Function
                If Me.C1DGEnc(.Row, "PrCusto") Is DBNull.Value Then Exit Function
                If Trim(Me.C1DGEnc(.Row, "PrCusto")).Length = 0 Or Me.C1DGEnc(.Row, "PrCusto") = 0 Then Exit Function
                If Me.C1DGEnc(.Row, "PrecoEtiqueta") Is DBNull.Value Then Exit Function
                If Trim(Me.C1DGEnc(.Row, "PrecoEtiqueta")).Length = 0 Or Me.C1DGEnc(.Row, "PrecoEtiqueta") = 0 Then Exit Function
                If Me.C1DGEnc(.Row, "RefForn") Is DBNull.Value Then xRefForn = "" Else xRefForn = Me.C1DGEnc(Me.C1DGEnc.Bookmark, "RefForn")
                If Me.C1DGEnc(.Row, "CorForn") Is DBNull.Value Then xCorForn = "" Else xCorForn = Me.C1DGEnc(.Bookmark, "CorForn")
                If Me.C1DGEnc(.Row, "EstadoEnc") <> "C" Then Exit Function

            End With

            With Me.C1DGEnc
                xGrupoID = Me.C1DGEnc(.Row, "GrupoID")
                xTipoID = Me.C1DGEnc(.Row, "TipoID")
                xAltura = Me.C1DGEnc(.Row, "Altura")
                xLinhaID = Me.C1DGEnc(.Row, "LinhaID")
                xModCorDescr = Me.C1DGEnc(.Row, "ModCorDescr")
                xFornId = Me.C1DGEnc(.Row, "FornId")
                xPrCusto = Me.C1DGEnc(.Row, "PrCusto")
                xPrVnd = Me.C1DGEnc(.Row, "PrecoEtiqueta")
            End With


            If ExisteModelo(xModeloID) = False Then

                Sql = "Select GrupoId, EscalaIDDef, UnidIdDef  from Grupos where GrupoID=" & xGrupoID
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                dr = Cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    xEscala = dr("EscalaIDDef")
                    xUnid = dr("UnidIdDef")
                Else
                    MsgBox("Escala ou Unidade Errada!!")
                    Exit Function
                End If
                dr.Close()
                Cmd.Dispose()

                'TODO : ALETAR ESTE PROCEDIMENTO - IR BUSCAR AS DATAS À TABELA ENCOMENDAS
                If Today() >= "01-09-2006" And Today() <= "31-01-2007" Then xEpoca = "07"
                If Today() >= "01-02-2007" And Today() <= "31-08-2007" Then xEpoca = "08"

                If Today() >= "01-09-2007" And Today() <= "31-01-2008" Then xEpoca = "09"
                If Today() >= "01-02-2008" And Today() <= "31-08-2008" Then xEpoca = "10"

                If Today() >= "01-09-2008" And Today() <= "31-01-2009" Then xEpoca = "11"
                If Today() >= "01-02-2009" And Today() <= "31-08-2009" Then xEpoca = "12"

                If Today() >= "01-09-2009" And Today() <= "31-01-2010" Then xEpoca = "13"
                If Today() >= "01-02-2010" And Today() <= "31-08-2010" Then xEpoca = "14"

                If Today() >= "01-09-2010" And Today() <= "31-01-2011" Then xEpoca = "15"
                If Today() >= "01-02-2011" And Today() <= "31-08-2011" Then xEpoca = "16"

                If Today() >= "01-09-2011" And Today() <= "31-01-2012" Then xEpoca = "17"
                If Today() >= "01-02-2012" And Today() <= "31-08-2012" Then xEpoca = "18"

                If Today() >= "01-09-2012" And Today() <= "31-01-2013" Then xEpoca = "19"
                If Today() >= "01-02-2013" And Today() <= "31-08-2013" Then xEpoca = "20"

                If Today() >= "01-09-2013" And Today() <= "31-01-2014" Then xEpoca = "21"
                If Today() >= "01-02-2014" And Today() <= "31-08-2014" Then xEpoca = "22"

                If Today() >= "01-09-2014" And Today() <= "31-01-2015" Then xEpoca = "23"
                If Today() >= "01-02-2015" And Today() <= "31-08-2015" Then xEpoca = "24"

                If Today() >= "01-09-2015" And Today() <= "31-01-2016" Then xEpoca = "25"
                If Today() >= "01-02-2016" And Today() <= "31-08-2016" Then xEpoca = "26"

                If Today() >= "01-09-2016" And Today() <= "31-01-2017" Then xEpoca = "27"
                If Today() >= "01-02-2017" And Today() <= "31-08-2017" Then xEpoca = "28"

                If Today() >= "01-09-2017" And Today() <= "31-01-2018" Then xEpoca = "29"
                If Today() >= "01-02-2018" And Today() <= "31-08-2018" Then xEpoca = "30"

                If Today() >= "01-09-2018" And Today() <= "31-01-2019" Then xEpoca = "31"
                If Today() >= "01-02-2019" And Today() <= "31-08-2019" Then xEpoca = "32"

                If Today() >= "01-09-2019" And Today() <= "31-01-2020" Then xEpoca = "33"
                If Today() >= "01-02-2020" And Today() <= "31-08-2020" Then xEpoca = "34"

                If Today() >= "01-09-2020" And Today() <= "31-01-2021" Then xEpoca = "35"
                If Today() >= "01-02-2021" And Today() <= "31-08-2021" Then xEpoca = "36"

                If Today() >= "01-09-2021" And Today() <= "31-01-2022" Then xEpoca = "37"
                If Today() >= "01-02-2022" And Today() <= "31-08-2022" Then xEpoca = "38"

                If Today() >= "01-09-2022" And Today() <= "31-01-2023" Then xEpoca = "39"
                If Today() >= "01-02-2023" And Today() <= "31-08-2023" Then xEpoca = "40"

                If Today() >= "01-09-2023" And Today() <= "31-01-2024" Then xEpoca = "41"
                If Today() >= "01-02-2024" And Today() <= "31-08-2024" Then xEpoca = "42"

                If Today() >= "01-09-2024" And Today() <= "31-01-2025" Then xEpoca = "43"
                If Today() >= "01-02-2025" And Today() <= "31-08-2025" Then xEpoca = "44"



                Sql = "INSERT INTO Modelos (ModeloID, GrupoID, TipoID, Altura, EpocaID, LinhaID, UnidId, EscalaId, OperadorID) " &
                        "VALUES ('" & xModeloID & "', '" & xGrupoID & "', '" & xTipoID & "', '" & xAltura & "', '" & xEpoca & "', '" & xLinhaID & "', '" & xUnid & "', '" & xEscala & "', '" & xUtilizador & "') "
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd.ExecuteNonQuery()
                Cmd.Dispose()
                cn.Close()

            End If

            If ExisteModeloCor(xModeloID, xCorID) = True Then
                'REGRA : O FORNECEDOR POR DEFEITO VAI SER AQUELE AO QUAL SE FEZ A ULTIMA COMPRA
                Sql = "UPDATE ModeloCor SET FornID='" & xFornId & "', RefForn='" & xRefForn & "', CorForn='" & xCorForn & "', PrCusto=" & xPrCusto & ", OperadorID='" & xUtilizador & "', DtRegisto=GetDate() " &
                    "WHERE ModeloID='" & xModeloID & "' AND CorID = '" & xCorID & "'"
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd.ExecuteNonQuery()


            Else
                Sql = "INSERT INTO ModeloCor (ModeloID, CorID, ModCorDescr, FornId, RefForn, CorForn, PrCusto, PrVnd, OperadorID) " &
                        "VALUES('" & xModeloID & "', '" & xCorID & "', '" & xModCorDescr & "', '" & xFornId & "', '" & xRefForn & "', '" & xCorForn & "', " & xPrCusto & ", " & xPrVnd & ", '" & xUtilizador & "') "
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd.ExecuteNonQuery()

                'GRAVAÇÃO DO MODELO/COR EFECTUADA COM SUCESSO


            End If
            Return True
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravaModeloCor")
        Catch ex As Exception
            ErroVB(ex.Message, "GravaModeloCor")
        Finally
            cn.Close()
            Sql = Nothing
            Cmd.Dispose()

        End Try
    End Function

    Friend Sub Act_Grelha_Tamanhos()

        If Not Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID") Is DBNull.Value Then
            If Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID") <> "" Then
                DtDetTam = New DataTable("DocDetTam")
                Dim dc As DataColumn
                If cn.State = ConnectionState.Closed Then cn.Open()
                Sql = "SELECT DISTINCT TamId FROM Escalas WHERE EscalaID = (SELECT EscalaIDDef FROM Grupos WHERE GrupoID = '" & Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID") & "')"
                Cmd = New SqlCommand(Sql, cn)
                dr = Cmd.ExecuteReader
                Dim Sumatorio As String = ""
                If dr.HasRows Then
                    With DtDetTam.Columns
                        .Add("Enc", GetType(Integer))
                        While dr.Read()
                            .Add(dr(0), GetType(Integer))
                        End While
                        .Add("Total", GetType(Integer))
                        .Add("Exec", GetType(Integer))

                    End With
                    Me.C1DGEncDetTam.DataSource = DtDetTam
                    Me.C1DGEncDetTam.AutoResize = True
                    Me.C1DGEncDetTam.AllowAddNew = False

                    dr.Close()
                    Cmd.Dispose()

                    Dim xNrEnc As String = Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc")
                    Dim xLnEnc As String = Me.C1DGEnc(Me.C1DGEnc.Row, "LnEnc")
                    Dim drAux As DataRow

                    drAux = DtDetTam.NewRow()
                    DtDetTam.Rows.Add(drAux)

                    Me.C1DGEncDetTam(1, "Enc") = xNrEnc
                    Me.C1DGEncDetTam.Cols("Enc").Width = 65
                    Me.C1DGEncDetTam.Cols("Enc").AllowEditing = False


                    For Each dc In DtDetTam.Columns
                        If dc.ColumnName <> "Total" And dc.ColumnName <> "Enc" And dc.ColumnName <> "Exec" Then
                            Dim xTam As String = dc.Caption
                            Sql = "Select ISNULL(SUM(Qtd),0) Qtd " &
                                    "FROM EncDetTam " &
                                    "WHERE EmpresaID = '" & xEmp & "' " &
                                    "AND ArmazemID = '" & xArmz & "' " &
                                    "AND NrEnc = '" & xNrEnc & "' " &
                                    "AND LnEnc = " & xLnEnc & " " &
                                    "AND TamID = '" & xTam & "'"
                            Cmd = New SqlCommand(Sql, cn)
                            Dim xValor As Integer = Cmd.ExecuteScalar
                            With DtDetTam
                                .Rows(0).BeginEdit()
                                .Rows(0)(xTam) = xValor
                                .Rows(0).EndEdit()
                            End With
                        End If
                    Next
                    Actualizar_TotalTam()
                    QtdExecutada()

                    Me.gbTamanhos.Visible = True
                    'btRelaTaloes.Visible = True
                Else
                    Me.gbTamanhos.Visible = False
                    'btRelaTaloes.Visible = False
                End If
            Else
                Me.gbTamanhos.Visible = False
                'btRelaTaloes.Visible = False
            End If
        Else
            Me.gbTamanhos.Visible = False
            'btRelaTaloes.Visible = False
        End If
    End Sub

    Private Function ExisteEnc(ByRef QtdEnc As Integer) As Boolean
        Try
            QtdEnc = 0
            If Not Me.C1DGEnc(C1DGEnc.Row, "GrupoID") Is DBNull.Value Then
                xNrEnc = Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc")
                xNrLn = Me.C1DGEnc(Me.C1DGEnc.Row, "LnEnc")
                Sql = "SELECT SUM(Qtd) FROM EncDetTam where NrEnc ='" & xNrEnc & "' and LnEnc ='" & xNrLn & "'"
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                If Not Cmd.ExecuteScalar Is DBNull.Value Then   'VERIFICA SE NÃO É NULO
                    If Cmd.ExecuteScalar = 0 Then
                        Return False
                    Else
                        QtdEnc = Cmd.ExecuteScalar
                        Return True
                    End If
                End If
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ExisteEnc")
        Catch ex As Exception
            ErroVB(ex.Message, "ExisteEnc")
        Finally
            cn.Close()
            Cmd.Dispose()
            Sql = Nothing

        End Try
    End Function

    Private Sub ActualizaLocks()
        Try

            For Each C As C1DisplayColumn In Me.C1DGEnc.Splits(0).DisplayColumns
                C.Locked = False
            Next
            Me.C1DGEnc.Splits(0).DisplayColumns("NrEnc").Locked = True
            Me.cbForn.Enabled = True
            Me.cbGrupo.Enabled = True
            Me.cbTipo.Enabled = True
            Me.cbCor.Enabled = True
            Me.cbLinha.Enabled = True
            Me.cbEstado.Enabled = True
            Me.C1DGEncDetTam.Enabled = True
            If Me.C1DGEnc.Splits(0).Rows.Count > 0 Then
                If Not Me.C1DGEnc(Me.C1DGEnc.Row, "TGerado") Is DBNull.Value Then
                    If Me.C1DGEnc(Me.C1DGEnc.Row, "TGerado") = True Then
                        Me.C1DGEncDetTam.Enabled = False
                        For Each C As C1DisplayColumn In Me.C1DGEnc.Splits(0).DisplayColumns
                            C.Locked = True
                        Next
                        Me.cbForn.Enabled = False
                        Me.cbGrupo.Enabled = False
                        Me.cbTipo.Enabled = False
                        Me.cbCor.Enabled = False
                        Me.cbLinha.Enabled = False
                        Me.cbEstado.Enabled = False
                        Exit Sub
                    End If
                End If
                If Not Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") Is DBNull.Value Then
                    If ExisteModelo(Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID")) = True Then
                        With Me.C1DGEnc
                            .Splits(0).DisplayColumns("ModeloID").Locked = True
                            .Splits(0).DisplayColumns("GrupoID").Locked = True
                            .Splits(0).DisplayColumns("TipoID").Locked = True
                            .Splits(0).DisplayColumns("Altura").Locked = True
                            .Splits(0).DisplayColumns("LinhaID").Locked = True
                        End With
                        If Not Me.C1DGEnc(Me.C1DGEnc.Row, "CorID") Is DBNull.Value Then
                            If ExisteModeloCor(Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID"), Me.C1DGEnc(Me.C1DGEnc.Row, "CorID")) = True Then
                                With Me.C1DGEnc
                                    .Splits(0).DisplayColumns("CorID").Locked = True
                                    .Splits(0).DisplayColumns("ModCorDescr").Locked = True
                                    .Splits(0).DisplayColumns("PrecoEtiqueta").Locked = True
                                End With
                            End If
                        End If
                    End If
                End If
                If Not Me.C1DGEnc(C1DGEnc.Row, "GrupoID") Is DBNull.Value Then
                    If ExisteEnc(QtdEnc) = True Then
                        Me.C1DGEnc.Splits(0).DisplayColumns("GrupoID").Locked = True
                    End If
                End If
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaLocks")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaLocks")
        Finally
            Me.C1DGEnc.Splits(0).DisplayColumns("Obs").Locked = False
            Me.C1DGEnc.Splits(0).DisplayColumns("QtdEnc").Locked = False
        End Try
    End Sub

    Private Sub ActDadosModelo()

        'TODO: FALTA VALIDAR A EXISTENCIA DO MODELO NA TABELA ENCOMENDAS


        Try

            With Me.C1DGEnc

                If Me.C1DGEnc(.Row, "TGerado") = True Then Exit Sub
                If Me.C1DGEnc(.Row, "EstadoEnc") = "C" Then Exit Sub
                If Me.C1DGEnc(.Row, "GrupoID") Is DBNull.Value Then Me.C1DGEnc(.Row, "GrupoID") = ""
                If Me.C1DGEnc(.Row, "TipoID") Is DBNull.Value Then Me.C1DGEnc(.Row, "TipoID") = ""
                If Me.C1DGEnc(.Row, "Altura") Is DBNull.Value Then Me.C1DGEnc(.Row, "Altura") = ""
                If Me.C1DGEnc(.Row, "LinhaID") Is DBNull.Value Then Me.C1DGEnc(.Row, "LinhaID") = ""

                If Not Me.C1DGEnc(.Row, "ModeloID") Is DBNull.Value Then
                    If Not Me.C1DGEnc(.Row, "ModeloID") = "" Then
                        Dim xModelo As String = Me.C1DGEnc(.Row, "ModeloID")
                        If xModelo.Length <> 5 Then
                            MsgBox("O Modelo : " + Me.C1DGEnc(.Row, "ModeloID") + " não é Válido!")
                            Me.C1DGEnc.Col = 12
                            Me.C1DGEnc(.Row, "ModeloID") = ""
                        Else
                            Sql = "SELECT GrupoID, TipoID, Altura, LinhaID FROM Modelos WHERE ModeloID = '" & xModelo & "'"
                            Cmd = New SqlCommand(Sql, cn)
                            If cn.State = ConnectionState.Closed Then cn.Open()
                            dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            If dr.HasRows Then
                                dr.Read()
                                Dim xGrupo As String = ""
                                If Not dr("GrupoID") Is DBNull.Value Then xGrupo = dr("GrupoID")
                                If Me.C1DGEnc(.Row, "GrupoID") Is DBNull.Value Then Me.C1DGEnc(.Row, "GrupoID") = ""
                                Dim xTipo As String = ""
                                If Not dr("TipoID") Is DBNull.Value Then xTipo = dr("TipoID")
                                If Me.C1DGEnc(.Row, "TipoID") Is DBNull.Value Then Me.C1DGEnc(.Row, "TipoID") = ""
                                If Me.C1DGEnc(.Row, "GrupoID") <> "" And Me.C1DGEnc(.Row, "GrupoID") <> xGrupo Then
                                    MsgBox("Refª Existente! Erro no Grupo ", MsgBoxStyle.Exclamation)
                                    Me.C1DGEnc(.Row, "ModeloID") = ""
                                Else
                                    If Me.C1DGEnc(.Row, "TipoID") <> "" And Me.C1DGEnc(.Row, "TipoID") <> xTipo Then
                                        MsgBox("Refª Existente! Erro no Tipo ", MsgBoxStyle.Exclamation)
                                        Me.C1DGEnc(.Row, "ModeloID") = ""
                                    Else
                                        Me.C1DGEnc(.Row, "GrupoID") = dr("GrupoID")
                                        Me.C1DGEnc(.Row, "TipoID") = dr("TipoID")
                                        Me.C1DGEnc(.Row, "Altura") = dr("Altura")
                                        Me.C1DGEnc(.Row, "LinhaID") = dr("LinhaID")
                                        .Splits(0).DisplayColumns("GrupoID").Locked = True
                                        .Splits(0).DisplayColumns("TipoID").Locked = True
                                        .Splits(0).DisplayColumns("Altura").Locked = True
                                        .Splits(0).DisplayColumns("LinhaID").Locked = True
                                        dr.Close()
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End With

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActDadosModelo")
        Catch ex As Exception
            ErroVB(ex.Message, "ActDadosModelo")
        Finally
            cn.Close()
            Cmd.Dispose()
            Sql = Nothing
        End Try

    End Sub

    Private Sub ActDadosModeloCor()

        'TODO: FALTA VALIDAR A EXISTENCIA DO MODELOCOR NA TABELA ENCOMENDAS
        Try
            If Not Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") Is DBNull.Value Then
                If Len(Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID")) = 5 Then
                    Dim xModelo As String = Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID")
                    With Me.C1DGEnc
                        If Not Me.C1DGEnc(.Row, "CorID") Is DBNull.Value Then
                            If Len(Me.C1DGEnc(.Row, "CorID")) = 2 Then
                                Dim xCor As String = Me.C1DGEnc(Me.C1DGEnc.Row, "CorID")
                                Sql = "SELECT ModCorDescr, FornId, RefForn, CorForn, PrCusto, PrVnd FROM ModeloCor WHERE ModeloID = '" & xModelo & "' AND CorID = '" & xCor & "'"
                                Cmd = New SqlCommand(Sql, cn)
                                dr.Close()
                                If cn.State = ConnectionState.Closed Then cn.Open()
                                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                                If dr.HasRows Then
                                    dr.Read()
                                    Me.C1DGEnc(.Row, "ModCorDescr") = dr("ModCorDescr")
                                    Me.C1DGEnc(.Row, "PrecoEtiqueta") = dr("PrVnd")
                                    If Trim(Me.C1DGEnc(.Row, "FornId")) = "" Then Me.C1DGEnc(.Row, "FornId") = dr("FornId")
                                    If Trim(Me.C1DGEnc(.Row, "RefForn")) = "" Then Me.C1DGEnc(.Row, "RefForn") = dr("RefForn")
                                    If Trim(Me.C1DGEnc(.Row, "CorForn")) = "" Then Me.C1DGEnc(.Row, "CorForn") = dr("CorForn")
                                    If Trim(Me.C1DGEnc(.Row, "PrCusto")) = 0 Then Me.C1DGEnc(.Row, "PrCusto") = dr("PrCusto")
                                End If

                            End If
                        End If
                    End With
                End If
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActDados_ModeloCor")
        Catch ex As Exception
            ErroVB(ex.Message, "ActDados_ModeloCor")
        Finally
            cn.Close()
            Sql = Nothing
        End Try
    End Sub

    Private Sub ActDados_Modelo()
        Try
            If Not Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") Is DBNull.Value Then
                If Not Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") = "" Then
                    Dim xModelo As String = Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID")
                    Sql = "SELECT GrupoID, TipoID, Altura, LinhaID FROM Modelos WHERE ModeloID = '" & xModelo & "'"
                    Cmd = New SqlCommand(Sql, cn)
                    If cn.State = ConnectionState.Closed Then cn.Open()
                    dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If dr.HasRows Then
                        dr.Read()
                        With Me.C1DGEnc
                            If Me.C1DGEnc(.Row, "GrupoID") Is DBNull.Value Then Me.C1DGEnc(.Row, "GrupoID") = dr("GrupoID")
                            If Me.C1DGEnc(.Row, "TipoID") Is DBNull.Value Then Me.C1DGEnc(.Row, "TipoID") = dr("TipoID")
                            If Me.C1DGEnc(.Row, "Altura") Is DBNull.Value Then Me.C1DGEnc(.Row, "Altura") = dr("Altura")
                            If Me.C1DGEnc(.Row, "LinhaID") Is DBNull.Value Then Me.C1DGEnc(.Row, "LinhaID") = dr("LinhaID")
                            If Not Me.C1DGEnc(.Row, "CorID") Is DBNull.Value Then
                                If Not Me.C1DGEnc(.Row, "CorID") = "" Then
                                    Dim xCor As String = Me.C1DGEnc(Me.C1DGEnc.Row, "CorID")
                                    Sql = "SELECT ModCorDescr, FornId, RefForn, CorForn, PrCusto, PrVnd FROM ModeloCor WHERE ModeloID = '" & xModelo & "' AND CorID = '" & xCor & "'"
                                    Cmd = New SqlCommand(Sql, cn)
                                    dr.Close()
                                    If cn.State = ConnectionState.Closed Then cn.Open()
                                    dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                                    If dr.HasRows Then
                                        dr.Read()
                                        If Me.C1DGEnc(.Row, "ModCorDescr") Is DBNull.Value Then Me.C1DGEnc(.Row, "ModCorDescr") = dr("ModCorDescr")
                                        If Me.C1DGEnc(.Row, "FornId") Is DBNull.Value Then Me.C1DGEnc(.Row, "FornId") = dr("FornId")
                                        If Me.C1DGEnc(.Row, "RefForn") Is DBNull.Value Then Me.C1DGEnc(.Row, "RefForn") = dr("RefForn")
                                        If Me.C1DGEnc(.Row, "CorForn") Is DBNull.Value Then Me.C1DGEnc(.Row, "CorForn") = dr("CorForn")
                                        If Me.C1DGEnc(.Row, "PrCusto") Is DBNull.Value Then Me.C1DGEnc(.Row, "PrCusto") = dr("PrCusto")
                                        If Me.C1DGEnc(.Row, "PrecoEtiqueta") Is DBNull.Value Then Me.C1DGEnc(.Row, "PrecoEtiqueta") = dr("PrVnd")
                                    End If

                                End If
                            End If
                        End With
                    End If
                End If
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActDados_Modelo")
        Catch ex As Exception
            ErroVB(ex.Message, "ActDados_Modelo")
        Finally
            cn.Close()
            Sql = Nothing
        End Try
    End Sub

    Private Function FotoModeloCor() As Boolean
        FotoModeloCor = False
        Me.PictureBox.Visible = False
        If IO.Directory.Exists(xFotosPath) Then
            If Not Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") Is DBNull.Value Then
                If Not Me.C1DGEnc(Me.C1DGEnc.Row, "CorID") Is DBNull.Value Then
                    Dim xFoto As String = Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") & Me.C1DGEnc(Me.C1DGEnc.Row, "CorID") & ".jpg"
                    If IO.File.Exists(xFotosPath & xFoto) Then
                        'InserirFoto(Me.PictureBox, xFotosPath & xFoto)
                        With Me.PictureBox
                            .SizeMode = PictureBoxSizeMode.Zoom
                            .Image = Image.FromFile(xFotosPath & xFoto)
                            .Visible = True
                            Return True
                        End With
                    End If
                End If
            End If
        End If
    End Function

    Private Sub TimerFoto_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerFoto.Tick
        Me.TimerFoto.Enabled = False
        If FotoModeloCor() = False Then
            If FotoFornec() = False Then
                Me.PictureBox.Visible = False
            Else
                Me.PictureBox.Visible = True
            End If
        Else
            Me.PictureBox.Visible = True
        End If
    End Sub

    Private Sub QtdExecutada()

        Dim QtdExe As Integer
        xNrEnc = Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc")
        Sql = "SELECT COUNT(*) FROM SERIE WHERE NrEnc = '" & xNrEnc & "' AND EstadoID<>'G'"
        Cmd = New SqlCommand(Sql, cn)
        If cn.State = ConnectionState.Closed Then cn.Open()
        If Not Cmd.ExecuteScalar Is DBNull.Value Then
            QtdExe = Cmd.ExecuteScalar
        Else
            QtdExe = 0
        End If
        Me.C1DGEncDetTam(1, "Exec") = QtdExe
        Me.C1DGEncDetTam.Cols("Exec").AllowEditing = False

    End Sub

    Private Sub GravaEncomenda()
        Dim db As New ClsSqlBDados
        Try

            'GirldataSet.Encomendas.AcceptChanges()
            'If Not GirldataSet.Encomendas.GetChanges Is Nothing Then
            If Not Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc") Is DBNull.Value Then
                If Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc") <> "" Then
                    xNrEnc = Me.C1DGEnc(Me.C1DGEnc.Row, "NrEnc")
                    xNrLn = Me.C1DGEnc(Me.C1DGEnc.Row, "LnEnc")
                    xForn = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "FornID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "FornID"))
                    xCliente = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "ClienteID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "ClienteID"))
                    xRefForn = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "RefForn") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "RefForn"))
                    xCorForn = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "CorForn") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "CorForn"))
                    xPrCusto = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "PrCusto") Is DBNull.Value, "Null", Me.C1DGEnc(Me.C1DGEnc.Row, "PrCusto"))
                    If Not Me.C1DGEnc(Me.C1DGEnc.Row, "DtEntrega") Is DBNull.Value Then
                        If CStr(Me.C1DGEnc(Me.C1DGEnc.Row, "DtEntrega")) <> "" Then
                            xDtEntrega = Format(CType(Me.C1DGEnc(Me.C1DGEnc.Row, "DtEntrega"), Date), "yyyy-MM-dd")
                        End If
                    End If
                    xGrupoID = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "GrupoID"))
                    xTipoID = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "TipoID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "TipoID"))
                    xAltura = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "Altura") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "Altura"))
                    xModeloID = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "ModeloID"))
                    xCorID = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "CorID") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "CorID"))
                    xModCorDescr = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "ModCorDescr") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "ModCorDescr"))
                    xLinhaId = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "LinhaId") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "LinhaId"))
                    xPrecoEtiqueta = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "PrecoEtiqueta") Is DBNull.Value, "Null", Me.C1DGEnc(Me.C1DGEnc.Row, "PrecoEtiqueta"))
                    xObs = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "Obs") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "Obs"))
                    xQtdEnc = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "QtdEnc") Is DBNull.Value, 0, Me.C1DGEnc(Me.C1DGEnc.Row, "QtdEnc"))
                    xEstadoEnc = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "EstadoEnc") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "EstadoEnc"))
                    xTGerado = IIf(Me.C1DGEnc(Me.C1DGEnc.Row, "TGerado") Is DBNull.Value, "", Me.C1DGEnc(Me.C1DGEnc.Row, "TGerado"))
                    If Not Me.C1DGEnc(Me.C1DGEnc.Row, "DataDoc") Is DBNull.Value Then
                        If CStr(Me.C1DGEnc(Me.C1DGEnc.Row, "DataDoc")) <> "" Then
                            xDataDoc = Format(CType(Me.C1DGEnc(Me.C1DGEnc.Row, "DataDoc"), Date), "yyyy-MM-dd")
                        End If
                    End If

                    Sql = "UPDATE Encomendas " &
                          "SET FornId ='" & Trim(xForn) & "', " &
                          "RefForn ='" & Trim(xRefForn) & "', " &
                          "ClienteID ='" & Trim(xCliente) & "', " &
                          "CorForn ='" & Trim(xCorForn) & "', " &
                          "PrCusto =" & Trim(xPrCusto) & ", " &
                          "DtEntrega ='" & Trim(xDtEntrega) & "', " &
                          "GrupoID ='" & Trim(xGrupoID) & "', " &
                          "TipoID ='" & Trim(xTipoID) & "', " &
                          "Altura ='" & Trim(xAltura) & "', " &
                          "ModeloID ='" & Trim(xModeloID) & "', " &
                          "CorID ='" & Trim(xCorID) & "', " &
                          "ModCorDescr ='" & Trim(xModCorDescr) & "', " &
                          "LinhaID ='" & Trim(xLinhaId) & "', " &
                          "PrecoEtiqueta =" & Trim(xPrecoEtiqueta) & ", " &
                          "Obs ='" & Trim(xObs) & "', " &
                          "QtdEnc ='" & Trim(xQtdEnc) & "', " &
                          "EstadoEnc ='" & Trim(xEstadoEnc) & "', " &
                          "TGerado ='" & Trim(xTGerado) & "', " &
                          "DataDoc ='" & Trim(xDataDoc) & "', " &
                          "OperadorID ='" & Trim(xUtilizador) & "' " &
                          "WHERE EmpresaID='" & Trim(xEmp) & "' " &
                          "AND ArmazemID='" & Trim(xArmz) & "' " &
                          "AND NrEnc='" & Trim(xNrEnc) & "' " &
                          "AND LnEnc='" & Trim(xNrLn) & "'"

                    db.ExecuteData(Sql)

                End If


                'Cmd = New SqlCommand(Sql, cn)
                'If cn.State = ConnectionState.Closed Then cn.Open()
                'Cmd.ExecuteNonQuery()

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravaEncomenda")
        Catch ex As Exception
            ErroVB(ex.Message, "GravaEncomenda")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    'VAI BUSCAR A FOTO À PASTA COM O CODIGO DO FORNECEDOR........
    'Private Function FotoFornec() As Boolean
    '    FotoFornec = False
    '    If Not Me.C1DGEnc(Me.C1DGEnc.Row, "FornId") Is DBNull.Value Then
    '        Dim xFornecedor As String = Me.C1DGEnc(Me.C1DGEnc.Row, "FornId")
    '        If Not Me.C1DGEnc(Me.C1DGEnc.Row, "RefForn") Is DBNull.Value Then
    '            Dim xForncfoto As String = Trim(Me.C1DGEnc(Me.C1DGEnc.Row, "RefForn")) & ".jpg"
    '            If IO.Directory.Exists(xFotosPath & xFornecedor) Then
    '                If IO.File.Exists(xFotosPath & xFornecedor & "/" & xForncfoto) Then
    '                    With Me.PictureBox
    '                        .SizeMode = PictureBoxSizeMode.Zoom
    '                        .Image = Image.FromFile(xFotosPath & xFornecedor & "/" & xForncfoto)
    '                        .Visible = True
    '                        Return True
    '                    End With
    '                    'InserirFoto(Me.PictureBox, xFotosPath & xFornecedor & "/" & xForncfoto)
    '                    Return True
    '                End If
    '            End If
    '        End If
    '    End If

    'End Function

    Private Function FotoFornec() As Boolean
        FotoFornec = False
        If Not Me.C1DGEnc(Me.C1DGEnc.Row, "FornId") Is DBNull.Value Then
            Dim xFornecedor As String = Me.C1DGEnc(Me.C1DGEnc.Row, "FornId")
            If Not Me.C1DGEnc(Me.C1DGEnc.Row, "RefForn") Is DBNull.Value Then
                Dim xForncfoto As String = xFornecedor & "-" & Trim(Me.C1DGEnc(Me.C1DGEnc.Row, "RefForn")) & ".jpg"
                Dim xFotoPathAux As String = Microsoft.VisualBasic.Left(xFotosPath, Len(xFotosPath) - 1) & "_MAQ\ENCOMENDAS"
                If IO.Directory.Exists(xFotoPathAux) Then
                    If IO.File.Exists(xFotoPathAux & "/" & xForncfoto) Then
                        With Me.PictureBox
                            .SizeMode = PictureBoxSizeMode.Zoom
                            .Image = Image.FromFile(xFotoPathAux & "/" & xForncfoto)
                            .Visible = True
                            Return True
                        End With
                        'InserirFoto(Me.PictureBox, xFotosPath & xFornecedor & "/" & xForncfoto)
                        Return True
                    End If
                End If
            End If
        End If

    End Function

    Private Sub btListaConfFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListaConfFact.Click

        Try
            Dim I As Int64
            Dim xFiltro As String = ""

            Me.daEnc.Update(Me.GirldataSet, "Encomendas")

            'IMPRIMIR CONFERÊNCIA

            For I = 0 To Me.C1DGEnc.SelectedRows.Count - 1
                If Not Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "TGerado").GetType.Name = "String" Then
                    If Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "TGerado") = True Then
                        xFiltro = xFiltro & "'" & Me.C1DGEnc(Me.C1DGEnc.SelectedRows(I), "NrEnc") & "',"
                    End If
                End If
            Next
            If Len(xFiltro) > 0 Then
                xFiltro = Microsoft.VisualBasic.Left(xFiltro, Len(xFiltro) - 1)
                frmRpt = New frmReport
                With frmRpt
                    .MdiParent = frmMenuCelfGest
                    .StartPosition = FormStartPosition.CenterScreen

                    Sql = "SELECT Empresas.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, " &
                        "Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpLogo, " &
                        "Empresas.EmpMarca, Terceiros.Nome, Terceiros.NomeAbrev, Terceiros.Morada, Terceiros.CodPostal, Terceiros.Localidade, " &
                        "Terceiros.Nome, Terceiros.NIF, Terceiros.Telefone, Terceiros.Fax, Terceiros.Email, Terceiros.Site, Terceiros.PPagID, " &
                        "Terceiros.ExpID, Terceiros.Obs, Terceiros.OperadorID, Encomendas.FornId, Encomendas.NrEnc, Encomendas.RefForn, Encomendas.CorForn, " &
                        "Encomendas.PrCusto, SUM(Encomendas.PrCusto) AS Valor, Serie.ModeloID, Serie.CorID, SUM(1) AS Qtd " &
                        "FROM Empresas INNER JOIN " &
                        "Encomendas ON Empresas.EmpresaID = Encomendas.EmpresaID INNER JOIN " &
                        "Serie ON Encomendas.NrEnc = Serie.NrEnc INNER JOIN " &
                        "Terceiros ON Encomendas.FornId = Terceiros.TercId " &
                        "WHERE (Serie.EstadoID IN ('S', 'T', 'R', 'V')) and Encomendas.NrEnc in (" & xFiltro & ") " &
                        "GROUP BY Serie.ModeloID, Serie.CorID, Terceiros.Nome, Terceiros.NomeAbrev, Terceiros.Morada, Terceiros.CodPostal,  " &
                        "Terceiros.Localidade, Terceiros.Nome, Terceiros.NIF, Terceiros.Telefone, Terceiros.Fax, Terceiros.Email,  " &
                        "Terceiros.Site, Terceiros.PPagID, Terceiros.ExpID, Terceiros.Obs, Terceiros.OperadorID, Empresas.EmpresaID, Empresas.EmpNome, " &
                        "Empresas.EmpDesigna, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpMorada, " &
                        "Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpLogo, Empresas.EmpMarca, " &
                        "Encomendas.RefForn, Encomendas.CorForn, Encomendas.PrCusto, Encomendas.NrEnc, Encomendas.FornId "


                    .C1Report1.Load(xRptPath & "RptConfPag.xml", "ConfPag")
                    .C1Report1.DataSource.ConnectionString = sconnectionstringReport
                    .C1Report1.DataSource.RecordSource = Sql

                    JustPrint(.C1Report1)

                    '.C1PrtPreview.Document = .C1Report1.Document
                    '.C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize

                    '.Show()
                End With
                Me.WindowState = FormWindowState.Minimized
            Else
                MsgBox("NÃO TEM NADA SELECCIONADO", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btForn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btForn.Click
        Dim dt As New DataTable
        Dim db As New ClsSqlBDados
        Dim frm As New Form

        Try
            frm = New Form
            Dgrid = New DataGridView
            '_cmd = CType(sender, Button)

            Sql = "SELECT TERCID,NOMEABREV FROM TERCEIROS WHERE TIPOTERC in ('F','C') ORDER BY NOMEABREV"
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
                .Width = 400
                .Height = 500
                .StartPosition = FormStartPosition.CenterParent
                .Controls.Add(Dgrid)
                .ShowDialog(Me)

            End With
            'AddHandler Dgrid.Click, AddressOf Dgrid_Click
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " btForn_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub



End Class
