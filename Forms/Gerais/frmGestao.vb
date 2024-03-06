Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmGestao
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
    Friend WithEvents C1DgridCab As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents C1FgEnc As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents gbDetalhesEnc As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TimerActDados As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CbForn As System.Windows.Forms.ComboBox
    Friend WithEvents txtRefForn As System.Windows.Forms.TextBox
    Friend WithEvents txtPrCusto As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CmdConfEnc As System.Windows.Forms.Button
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents txtCorForn As System.Windows.Forms.TextBox
    Friend WithEvents txtDtEnt As System.Windows.Forms.TextBox
    Friend WithEvents DataVenda As System.Windows.Forms.DateTimePicker
    Friend WithEvents btFiltraVendas As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbFiltraData As System.Windows.Forms.CheckBox
    Friend WithEvents CmdFechar As System.Windows.Forms.Button
    Friend WithEvents cbArmazem As System.Windows.Forms.ComboBox
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents ReservasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReservasTableAdapter As GirlRootName.GirlDataSetTableAdapters.ReservasTableAdapter
    Friend WithEvents ReservasDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents gbReservas As System.Windows.Forms.GroupBox
    Friend WithEvents cbFiltraLoja As System.Windows.Forms.CheckBox
    Friend WithEvents btlistar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ArmazensBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ArmazensTableAdapter As GirlRootName.GirlDataSetTableAdapters.ArmazensTableAdapter
    Friend WithEvents cbArmazemReserva As System.Windows.Forms.ComboBox
    Friend WithEvents txtRTam As System.Windows.Forms.TextBox
    Friend WithEvents txtRCor As System.Windows.Forms.TextBox
    Friend WithEvents txtRModelo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btGravaReserva As System.Windows.Forms.Button
    Friend WithEvents tbReserva As System.Windows.Forms.TextBox
    Friend WithEvents ArmazensBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CFGDet As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pC1DgridCab As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cbDetalhe As System.Windows.Forms.CheckBox
    Friend WithEvents cbIncReservas As System.Windows.Forms.CheckBox
    Friend WithEvents ReservaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArmazemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaModeloId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaCorId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaTamId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaSerieID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Despesas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaEstado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReservaData As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGestao))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.C1DgridCab = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbDetalhe = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.C1FgEnc = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.CmdConfEnc = New System.Windows.Forms.Button()
        Me.gbDetalhesEnc = New System.Windows.Forms.GroupBox()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.txtPrCusto = New System.Windows.Forms.TextBox()
        Me.txtCorForn = New System.Windows.Forms.TextBox()
        Me.txtRefForn = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbForn = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.txtDtEnt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimerActDados = New System.Windows.Forms.Timer(Me.components)
        Me.DataVenda = New System.Windows.Forms.DateTimePicker()
        Me.btFiltraVendas = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btlistar = New System.Windows.Forms.Button()
        Me.cbArmazem = New System.Windows.Forms.ComboBox()
        Me.cbFiltraLoja = New System.Windows.Forms.CheckBox()
        Me.cbFiltraData = New System.Windows.Forms.CheckBox()
        Me.CmdFechar = New System.Windows.Forms.Button()
        Me.ReservasDataGridView = New System.Windows.Forms.DataGridView()
        Me.ReservaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArmazemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaModeloId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaCorId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaTamId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaSerieID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despesas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaEstado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReservaData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.gbReservas = New System.Windows.Forms.GroupBox()
        Me.tbReserva = New System.Windows.Forms.TextBox()
        Me.btGravaReserva = New System.Windows.Forms.Button()
        Me.txtRTam = New System.Windows.Forms.TextBox()
        Me.txtRCor = New System.Windows.Forms.TextBox()
        Me.txtRModelo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbArmazemReserva = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ArmazensBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReservasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ReservasTableAdapter()
        Me.ArmazensTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ArmazensTableAdapter()
        Me.ArmazensBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CFGDet = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pC1DgridCab = New System.Windows.Forms.Panel()
        Me.cbIncReservas = New System.Windows.Forms.CheckBox()
        CType(Me.C1DgridCab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.C1FgEnc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalhesEnc.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.ReservasDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReservas.SuspendLayout()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArmazensBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.CFGDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pC1DgridCab.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1DgridCab
        '
        Me.C1DgridCab.AllowColMove = False
        Me.C1DgridCab.AlternatingRows = True
        Me.C1DgridCab.BackColor = System.Drawing.SystemColors.Control
        Me.C1DgridCab.CaptionHeight = 17
        Me.C1DgridCab.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        Me.C1DgridCab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DgridCab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1DgridCab.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1DgridCab.Images.Add(CType(resources.GetObject("C1DgridCab.Images"), System.Drawing.Image))
        Me.C1DgridCab.Location = New System.Drawing.Point(0, 0)
        Me.C1DgridCab.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
        Me.C1DgridCab.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.C1DgridCab.Name = "C1DgridCab"
        Me.C1DgridCab.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1DgridCab.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1DgridCab.PreviewInfo.ZoomFactor = 75.0R
        Me.C1DgridCab.PrintInfo.PageSettings = CType(resources.GetObject("C1DgridCab.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1DgridCab.RecordSelectorWidth = 21
        Me.C1DgridCab.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1DgridCab.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1DgridCab.RowHeight = 15
        Me.C1DgridCab.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1DgridCab.Size = New System.Drawing.Size(508, 190)
        Me.C1DgridCab.TabIndex = 0
        Me.C1DgridCab.Text = "C1TrueDBGrid1"
        Me.C1DgridCab.PropBag = resources.GetString("C1DgridCab.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbDetalhe)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.CmdConfEnc)
        Me.GroupBox1.Controls.Add(Me.gbDetalhesEnc)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1249, 407)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 251)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ENCOMENDA"
        '
        'cbDetalhe
        '
        Me.cbDetalhe.AutoSize = True
        Me.cbDetalhe.Location = New System.Drawing.Point(321, 119)
        Me.cbDetalhe.Name = "cbDetalhe"
        Me.cbDetalhe.Size = New System.Drawing.Size(90, 23)
        Me.cbDetalhe.TabIndex = 14
        Me.cbDetalhe.Text = "Detalhe"
        Me.cbDetalhe.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.C1FgEnc)
        Me.Panel3.Location = New System.Drawing.Point(11, 39)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(430, 79)
        Me.Panel3.TabIndex = 15
        '
        'C1FgEnc
        '
        Me.C1FgEnc.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FgEnc.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FgEnc.ColumnInfo = "10,1,0,0,0,85,Columns:"
        Me.C1FgEnc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FgEnc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1FgEnc.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.C1FgEnc.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.C1FgEnc.Location = New System.Drawing.Point(0, 0)
        Me.C1FgEnc.Name = "C1FgEnc"
        Me.C1FgEnc.Rows.DefaultSize = 17
        Me.C1FgEnc.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.C1FgEnc.Size = New System.Drawing.Size(430, 79)
        Me.C1FgEnc.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FgEnc.Styles"))
        Me.C1FgEnc.TabIndex = 0
        '
        'CmdConfEnc
        '
        Me.CmdConfEnc.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdConfEnc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdConfEnc.Location = New System.Drawing.Point(201, 0)
        Me.CmdConfEnc.Name = "CmdConfEnc"
        Me.CmdConfEnc.Size = New System.Drawing.Size(198, 29)
        Me.CmdConfEnc.TabIndex = 14
        Me.CmdConfEnc.Text = "Gravar Encomenda"
        Me.CmdConfEnc.UseVisualStyleBackColor = False
        '
        'gbDetalhesEnc
        '
        Me.gbDetalhesEnc.Controls.Add(Me.txtObs)
        Me.gbDetalhesEnc.Controls.Add(Me.txtPrCusto)
        Me.gbDetalhesEnc.Controls.Add(Me.txtCorForn)
        Me.gbDetalhesEnc.Controls.Add(Me.txtRefForn)
        Me.gbDetalhesEnc.Controls.Add(Me.Label5)
        Me.gbDetalhesEnc.Controls.Add(Me.Label4)
        Me.gbDetalhesEnc.Controls.Add(Me.Label3)
        Me.gbDetalhesEnc.Controls.Add(Me.Label2)
        Me.gbDetalhesEnc.Controls.Add(Me.CbForn)
        Me.gbDetalhesEnc.Controls.Add(Me.Label6)
        Me.gbDetalhesEnc.Location = New System.Drawing.Point(11, 125)
        Me.gbDetalhesEnc.Name = "gbDetalhesEnc"
        Me.gbDetalhesEnc.Size = New System.Drawing.Size(430, 118)
        Me.gbDetalhesEnc.TabIndex = 1
        Me.gbDetalhesEnc.TabStop = False
        Me.gbDetalhesEnc.Text = "Dados da Encomenda"
        '
        'txtObs
        '
        Me.txtObs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(307, 81)
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(116, 25)
        Me.txtObs.TabIndex = 4
        Me.txtObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrCusto
        '
        Me.txtPrCusto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrCusto.Location = New System.Drawing.Point(213, 81)
        Me.txtPrCusto.Name = "txtPrCusto"
        Me.txtPrCusto.Size = New System.Drawing.Size(86, 25)
        Me.txtPrCusto.TabIndex = 3
        Me.txtPrCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCorForn
        '
        Me.txtCorForn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorForn.Location = New System.Drawing.Point(117, 81)
        Me.txtCorForn.Name = "txtCorForn"
        Me.txtCorForn.Size = New System.Drawing.Size(86, 25)
        Me.txtCorForn.TabIndex = 2
        Me.txtCorForn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRefForn
        '
        Me.txtRefForn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefForn.Location = New System.Drawing.Point(21, 81)
        Me.txtRefForn.Name = "txtRefForn"
        Me.txtRefForn.Size = New System.Drawing.Size(86, 25)
        Me.txtRefForn.TabIndex = 1
        Me.txtRefForn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(307, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 21)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Obs"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(213, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "PrCusto"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(117, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "CorForn"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "RefForn"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CbForn
        '
        Me.CbForn.AllowDrop = True
        Me.CbForn.DropDownWidth = 150
        Me.CbForn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbForn.Location = New System.Drawing.Point(117, 27)
        Me.CbForn.MaxDropDownItems = 10
        Me.CbForn.Name = "CbForn"
        Me.CbForn.Size = New System.Drawing.Size(306, 25)
        Me.CbForn.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 27)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Ult.Forn. :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox
        '
        Me.PictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox.Location = New System.Drawing.Point(1435, 5)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(272, 190)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox.TabIndex = 23
        Me.PictureBox.TabStop = False
        '
        'txtDtEnt
        '
        Me.txtDtEnt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDtEnt.Location = New System.Drawing.Point(55, 99)
        Me.txtDtEnt.Name = "txtDtEnt"
        Me.txtDtEnt.Size = New System.Drawing.Size(96, 25)
        Me.txtDtEnt.TabIndex = 14
        Me.txtDtEnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDtEnt.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Data Ent"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'TimerActDados
        '
        '
        'DataVenda
        '
        Me.DataVenda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataVenda.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DataVenda.Location = New System.Drawing.Point(15, 44)
        Me.DataVenda.Name = "DataVenda"
        Me.DataVenda.Size = New System.Drawing.Size(205, 26)
        Me.DataVenda.TabIndex = 25
        '
        'btFiltraVendas
        '
        Me.btFiltraVendas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFiltraVendas.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btFiltraVendas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFiltraVendas.Location = New System.Drawing.Point(237, 44)
        Me.btFiltraVendas.Name = "btFiltraVendas"
        Me.btFiltraVendas.Size = New System.Drawing.Size(106, 75)
        Me.btFiltraVendas.TabIndex = 26
        Me.btFiltraVendas.Text = "Filtar"
        Me.btFiltraVendas.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btlistar)
        Me.Panel1.Controls.Add(Me.cbArmazem)
        Me.Panel1.Controls.Add(Me.cbFiltraLoja)
        Me.Panel1.Controls.Add(Me.cbFiltraData)
        Me.Panel1.Controls.Add(Me.btFiltraVendas)
        Me.Panel1.Controls.Add(Me.CmdFechar)
        Me.Panel1.Controls.Add(Me.DataVenda)
        Me.Panel1.Location = New System.Drawing.Point(1305, 261)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 126)
        Me.Panel1.TabIndex = 27
        '
        'btlistar
        '
        Me.btlistar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btlistar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btlistar.Location = New System.Drawing.Point(259, 89)
        Me.btlistar.Name = "btlistar"
        Me.btlistar.Size = New System.Drawing.Size(82, 28)
        Me.btlistar.TabIndex = 29
        Me.btlistar.Text = "Listar"
        Me.btlistar.UseVisualStyleBackColor = False
        '
        'cbArmazem
        '
        Me.cbArmazem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbArmazem.FormattingEnabled = True
        Me.cbArmazem.Location = New System.Drawing.Point(15, 89)
        Me.cbArmazem.Name = "cbArmazem"
        Me.cbArmazem.Size = New System.Drawing.Size(205, 26)
        Me.cbArmazem.TabIndex = 28
        '
        'cbFiltraLoja
        '
        Me.cbFiltraLoja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbFiltraLoja.AutoSize = True
        Me.cbFiltraLoja.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFiltraLoja.Location = New System.Drawing.Point(141, 10)
        Me.cbFiltraLoja.Name = "cbFiltraLoja"
        Me.cbFiltraLoja.Size = New System.Drawing.Size(76, 23)
        Me.cbFiltraLoja.TabIndex = 27
        Me.cbFiltraLoja.Text = "Stock"
        Me.cbFiltraLoja.UseVisualStyleBackColor = True
        '
        'cbFiltraData
        '
        Me.cbFiltraData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbFiltraData.AutoSize = True
        Me.cbFiltraData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFiltraData.Location = New System.Drawing.Point(27, 10)
        Me.cbFiltraData.Name = "cbFiltraData"
        Me.cbFiltraData.Size = New System.Drawing.Size(88, 23)
        Me.cbFiltraData.TabIndex = 27
        Me.cbFiltraData.Text = "Vendas"
        Me.cbFiltraData.UseVisualStyleBackColor = True
        '
        'CmdFechar
        '
        Me.CmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CmdFechar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFechar.Location = New System.Drawing.Point(236, 8)
        Me.CmdFechar.Name = "CmdFechar"
        Me.CmdFechar.Size = New System.Drawing.Size(105, 29)
        Me.CmdFechar.TabIndex = 28
        Me.CmdFechar.Text = "Fechar"
        Me.CmdFechar.UseVisualStyleBackColor = False
        '
        'ReservasDataGridView
        '
        Me.ReservasDataGridView.AllowUserToAddRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ReservasDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.ReservasDataGridView.AutoGenerateColumns = False
        Me.ReservasDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReservasDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.ReservasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReservasDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReservaID, Me.ArmazemID, Me.ReservaModeloId, Me.ReservaCorId, Me.ReservaTamId, Me.ReservaSerieID, Me.ReservaDescr, Me.Despesas, Me.ReservaEstado, Me.ReservaData})
        Me.ReservasDataGridView.DataSource = Me.ReservasBindingSource
        Me.ReservasDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ReservasDataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ReservasDataGridView.Location = New System.Drawing.Point(3, 53)
        Me.ReservasDataGridView.MultiSelect = False
        Me.ReservasDataGridView.Name = "ReservasDataGridView"
        Me.ReservasDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.ReservasDataGridView.RowHeadersWidth = 35
        Me.ReservasDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservasDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle20
        Me.ReservasDataGridView.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservasDataGridView.RowTemplate.Height = 500
        Me.ReservasDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReservasDataGridView.Size = New System.Drawing.Size(816, 138)
        Me.ReservasDataGridView.TabIndex = 7
        '
        'ReservaID
        '
        Me.ReservaID.DataPropertyName = "ReservaID"
        Me.ReservaID.HeaderText = "ReservaID"
        Me.ReservaID.Name = "ReservaID"
        Me.ReservaID.ReadOnly = True
        Me.ReservaID.Visible = False
        '
        'ArmazemID
        '
        Me.ArmazemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ArmazemID.DataPropertyName = "ArmazemID"
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArmazemID.DefaultCellStyle = DataGridViewCellStyle13
        Me.ArmazemID.FillWeight = 93.9561!
        Me.ArmazemID.HeaderText = "Arm"
        Me.ArmazemID.Name = "ArmazemID"
        Me.ArmazemID.ReadOnly = True
        Me.ArmazemID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ArmazemID.Width = 64
        '
        'ReservaModeloId
        '
        Me.ReservaModeloId.DataPropertyName = "ReservaModeloId"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaModeloId.DefaultCellStyle = DataGridViewCellStyle14
        Me.ReservaModeloId.FillWeight = 116.7516!
        Me.ReservaModeloId.HeaderText = "Modelo"
        Me.ReservaModeloId.Name = "ReservaModeloId"
        Me.ReservaModeloId.ReadOnly = True
        Me.ReservaModeloId.Width = 50
        '
        'ReservaCorId
        '
        Me.ReservaCorId.DataPropertyName = "ReservaCorId"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaCorId.DefaultCellStyle = DataGridViewCellStyle15
        Me.ReservaCorId.FillWeight = 78.52423!
        Me.ReservaCorId.HeaderText = "Cor"
        Me.ReservaCorId.Name = "ReservaCorId"
        Me.ReservaCorId.ReadOnly = True
        Me.ReservaCorId.Width = 35
        '
        'ReservaTamId
        '
        Me.ReservaTamId.DataPropertyName = "ReservaTamId"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaTamId.DefaultCellStyle = DataGridViewCellStyle16
        Me.ReservaTamId.FillWeight = 68.98174!
        Me.ReservaTamId.HeaderText = "Tam"
        Me.ReservaTamId.Name = "ReservaTamId"
        Me.ReservaTamId.ReadOnly = True
        Me.ReservaTamId.Width = 35
        '
        'ReservaSerieID
        '
        Me.ReservaSerieID.DataPropertyName = "ReservaSerieID"
        Me.ReservaSerieID.HeaderText = "Talão"
        Me.ReservaSerieID.Name = "ReservaSerieID"
        Me.ReservaSerieID.Width = 75
        '
        'ReservaDescr
        '
        Me.ReservaDescr.DataPropertyName = "ReservaDescr"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ReservaDescr.DefaultCellStyle = DataGridViewCellStyle17
        Me.ReservaDescr.FillWeight = 177.9643!
        Me.ReservaDescr.HeaderText = "Observações"
        Me.ReservaDescr.MaxInputLength = 60
        Me.ReservaDescr.Name = "ReservaDescr"
        Me.ReservaDescr.Width = 245
        '
        'Despesas
        '
        Me.Despesas.DataPropertyName = "Despesas"
        DataGridViewCellStyle18.Format = "C2"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.Despesas.DefaultCellStyle = DataGridViewCellStyle18
        Me.Despesas.HeaderText = "€"
        Me.Despesas.Name = "Despesas"
        Me.Despesas.Width = 40
        '
        'ReservaEstado
        '
        Me.ReservaEstado.DataPropertyName = "ReservaEstado"
        Me.ReservaEstado.FillWeight = 35.53299!
        Me.ReservaEstado.HeaderText = "F"
        Me.ReservaEstado.Name = "ReservaEstado"
        Me.ReservaEstado.Width = 30
        '
        'ReservaData
        '
        Me.ReservaData.DataPropertyName = "ReservaData"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.Format = "d"
        DataGridViewCellStyle19.NullValue = "=Now()"
        Me.ReservaData.DefaultCellStyle = DataGridViewCellStyle19
        Me.ReservaData.HeaderText = "Data"
        Me.ReservaData.Name = "ReservaData"
        Me.ReservaData.ReadOnly = True
        Me.ReservaData.Visible = False
        Me.ReservaData.Width = 80
        '
        'ReservasBindingSource
        '
        Me.ReservasBindingSource.DataMember = "Reservas"
        Me.ReservasBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gbReservas
        '
        Me.gbReservas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbReservas.Controls.Add(Me.tbReserva)
        Me.gbReservas.Controls.Add(Me.btGravaReserva)
        Me.gbReservas.Controls.Add(Me.txtRTam)
        Me.gbReservas.Controls.Add(Me.txtRCor)
        Me.gbReservas.Controls.Add(Me.txtRModelo)
        Me.gbReservas.Controls.Add(Me.Label7)
        Me.gbReservas.Controls.Add(Me.Label8)
        Me.gbReservas.Controls.Add(Me.Label9)
        Me.gbReservas.Controls.Add(Me.cbArmazemReserva)
        Me.gbReservas.Controls.Add(Me.ReservasDataGridView)
        Me.gbReservas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReservas.Location = New System.Drawing.Point(525, 5)
        Me.gbReservas.Name = "gbReservas"
        Me.gbReservas.Size = New System.Drawing.Size(822, 194)
        Me.gbReservas.TabIndex = 35
        Me.gbReservas.TabStop = False
        Me.gbReservas.Text = "RESERVAS"
        '
        'tbReserva
        '
        Me.tbReserva.AcceptsTab = True
        Me.tbReserva.Location = New System.Drawing.Point(451, 15)
        Me.tbReserva.MaxLength = 55
        Me.tbReserva.Multiline = True
        Me.tbReserva.Name = "tbReserva"
        Me.tbReserva.Size = New System.Drawing.Size(286, 29)
        Me.tbReserva.TabIndex = 4
        '
        'btGravaReserva
        '
        Me.btGravaReserva.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGravaReserva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGravaReserva.Location = New System.Drawing.Point(744, 15)
        Me.btGravaReserva.Name = "btGravaReserva"
        Me.btGravaReserva.Size = New System.Drawing.Size(65, 29)
        Me.btGravaReserva.TabIndex = 5
        Me.btGravaReserva.Text = "Criar"
        Me.btGravaReserva.UseVisualStyleBackColor = False
        '
        'txtRTam
        '
        Me.txtRTam.Location = New System.Drawing.Point(400, 16)
        Me.txtRTam.Name = "txtRTam"
        Me.txtRTam.Size = New System.Drawing.Size(43, 25)
        Me.txtRTam.TabIndex = 3
        '
        'txtRCor
        '
        Me.txtRCor.Location = New System.Drawing.Point(319, 16)
        Me.txtRCor.Name = "txtRCor"
        Me.txtRCor.Size = New System.Drawing.Size(44, 25)
        Me.txtRCor.TabIndex = 2
        '
        'txtRModelo
        '
        Me.txtRModelo.Location = New System.Drawing.Point(216, 16)
        Me.txtRModelo.Name = "txtRModelo"
        Me.txtRModelo.Size = New System.Drawing.Size(72, 25)
        Me.txtRModelo.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(360, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 17)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Tam"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(285, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 17)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Cor"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(176, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 17)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Mod"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbArmazemReserva
        '
        Me.cbArmazemReserva.FormattingEnabled = True
        Me.cbArmazemReserva.Location = New System.Drawing.Point(8, 15)
        Me.cbArmazemReserva.Name = "cbArmazemReserva"
        Me.cbArmazemReserva.Size = New System.Drawing.Size(161, 25)
        Me.cbArmazemReserva.TabIndex = 0
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100
        '
        'ArmazensBindingSource
        '
        Me.ArmazensBindingSource.DataMember = "Armazens"
        Me.ArmazensBindingSource.DataSource = Me.GirlDataSet
        '
        'ReservasTableAdapter
        '
        Me.ReservasTableAdapter.ClearBeforeFill = True
        '
        'ArmazensTableAdapter
        '
        Me.ArmazensTableAdapter.ClearBeforeFill = True
        '
        'ArmazensBindingSource1
        '
        Me.ArmazensBindingSource1.DataMember = "Armazens"
        Me.ArmazensBindingSource1.DataSource = Me.GirlDataSet
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.CFGDet)
        Me.Panel2.Location = New System.Drawing.Point(11, 210)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(872, 448)
        Me.Panel2.TabIndex = 36
        '
        'CFGDet
        '
        Me.CFGDet.ColumnInfo = "10,1,0,0,0,85,Columns:0{Width:18;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.CFGDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFGDet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CFGDet.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.CFGDet.Location = New System.Drawing.Point(0, 0)
        Me.CFGDet.Name = "CFGDet"
        Me.CFGDet.Rows.DefaultSize = 17
        Me.CFGDet.Size = New System.Drawing.Size(872, 448)
        Me.CFGDet.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("CFGDet.Styles"))
        Me.CFGDet.TabIndex = 2
        '
        'pC1DgridCab
        '
        Me.pC1DgridCab.Controls.Add(Me.C1DgridCab)
        Me.pC1DgridCab.Location = New System.Drawing.Point(11, 9)
        Me.pC1DgridCab.Name = "pC1DgridCab"
        Me.pC1DgridCab.Size = New System.Drawing.Size(508, 190)
        Me.pC1DgridCab.TabIndex = 38
        '
        'cbIncReservas
        '
        Me.cbIncReservas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbIncReservas.AutoSize = True
        Me.cbIncReservas.Location = New System.Drawing.Point(1256, 210)
        Me.cbIncReservas.Name = "cbIncReservas"
        Me.cbIncReservas.Size = New System.Drawing.Size(108, 23)
        Me.cbIncReservas.TabIndex = 37
        Me.cbIncReservas.Text = "I.Reservas"
        Me.cbIncReservas.UseVisualStyleBackColor = True
        '
        'frmGestao
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1715, 673)
        Me.Controls.Add(Me.pC1DgridCab)
        Me.Controls.Add(Me.cbIncReservas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gbReservas)
        Me.Controls.Add(Me.txtDtEnt)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmGestao"
        Me.Text = "frmGestao"
        CType(Me.C1DgridCab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.C1FgEnc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalhesEnc.ResumeLayout(False)
        Me.gbDetalhesEnc.PerformLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ReservasDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReservas.ResumeLayout(False)
        Me.gbReservas.PerformLayout()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArmazensBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.CFGDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pC1DgridCab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Dim dtCab As New DataTable
    Dim dtEnc As New DataTable
    Dim dtForn As New DataTable
    Dim dtArmazens As New DataTable
    Dim dtArmazensReserva As New DataTable
    Dim xValor As Integer = 0
    Dim xOrigem As String = ""
    Dim xDestino As String = ""
    Dim xTamTransf As String = ""
    Dim xLnTranf As Integer
    Dim xColTranf As Integer
    Dim CarregarFoto As New ClsFotos
    Dim xLoja As String = "%"
    Dim xcbFiltraData As String
    Dim dataVendaConv As Date
    Dim xTalao As String = ""
    Dim xModelo As String = ""
    Dim xCor As String = ""


    'TODO: COLOCAR UM FILTRO COM A DATA DA VENDA está quase ok??
    'TODO: GERAR RELATÓRIO DE TRANSFERÊNCIAS COM O DRAG AND DROP DAS QTDs
    'TODO: ALTERAR AS ENCOMENDAS CONFIRMADAS PARA ENC. CONF. NÃO EXECUTADAS

    Private Sub frmTransf_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'GirlDataSet.Armazens' table. You can move, or remove it, as needed.
        Me.ArmazensTableAdapter.Fill(Me.GirlDataSet.Armazens)

        Try
            Me.gbDetalhesEnc.Visible = False
            Me.cbDetalhe.Checked = False

            Me.btlistar.Visible = False
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            cbFiltraData.Checked = False
            DataVenda.Visible = False
            btFiltraVendas.Visible = False
            cbArmazem.Visible = False


            'CARREGAR ARMAZENS

            Sql = "SELECT ArmazemID, rtrim(ArmazemID) + ' - ' + rtrim(ArmAbrev) as Destino from Armazens"
            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtArmazens)
            da.Fill(dtArmazensReserva)
            dtArmazens.Rows.Add("%", "Escolha a Loja")
            Me.cbArmazem.DataSource = dtArmazens
            Me.cbArmazem.DisplayMember = "Destino"
            Me.cbArmazem.ValueMember = "ArmazemID"
            Me.cbArmazem.SelectedValue = "%"

            Me.cbArmazemReserva.DataSource = dtArmazensReserva
            Me.cbArmazemReserva.DisplayMember = "Destino"
            Me.cbArmazemReserva.ValueMember = "ArmazemID"
            Me.cbArmazemReserva.SelectedValue = "%"



            CarregarC1DgridCab()

            Dim coluna As C1.Win.C1TrueDBGrid.C1DisplayColumn
            With Me.C1DgridCab
                .Splits(0).DisplayColumns("FornID").Visible = True
                .Splits(0).DisplayColumns("RefForn").Visible = True
                .Splits(0).DisplayColumns("CorForn").Visible = False
                .Splits(0).DisplayColumns("PrCusto").Visible = False
                .Splits(0).DisplayColumns("Rotacao").Visible = False
                .Columns("GrupoID").Caption = "Gr"
                .Columns("TipoId").Caption = "Tp"
                .Columns("Altura").Caption = "Al"
                .Columns("ModeloID").Caption = "Modelo"
                .Columns("LinhaID").Caption = "Ln"
                .Columns("CorID").Caption = "Cor"
                .Columns("ModCorDescr").Caption = "Descrição"
                .Columns("FornID").Caption = "Forn"
                .Columns("EncPend").Caption = "Pnd"

                .MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                '.Splits(0).DisplayColumns(2).AllowFocus = False
                '.FetchRowStyles = True
                '.Columns("PrCusto").NumberFormat = "#,##0.00"
                '.Columns("DataDoc").NumberFormat = "yyyy-MM-dd"
                .Columns("Rotacao").NumberFormat = "Percent"
                For Each coluna In Me.C1DgridCab.Splits(0).DisplayColumns
                    coluna.Style.Font = New Font("Arial", 8, FontStyle.Regular)
                    coluna.HeadingStyle.Font = New Font("Arial", 8, FontStyle.Bold)
                    coluna.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    coluna.Locked = True
                    coluna.AutoSize()
                Next
                .Splits(0).DisplayColumns("FornID").Width = 35
                .Splits(0).DisplayColumns("ModCorDescr").Width = 110
                .Splits(0).DisplayColumns("RefForn").Width = 60

                Dim LarguraTotalColunas As Double = 0
                For Each coluna In Me.C1DgridCab.Splits(0).DisplayColumns
                    If coluna.Visible = True Then
                        LarguraTotalColunas += coluna.Width
                    End If
                Next
                .Width = LarguraTotalColunas * 1.1
                .Refresh()
            End With

            ' turn the filterbar on na TrueGrid
            Me.C1DgridCab.FilterBar = True
            ' we'll do the filtering ourselves na TrueGrid
            Me.C1DgridCab.AllowFilter = False

            'Carregar(DataSet - -Fornecerdores)
            'Sql = "select FornId, Nome, rtrim(FornId) + ' - ' + rtrim(Nome) as FornDesc from Fornecedores Order by Nome"
            Sql = "SELECT TercID, RTRIM(TercID) + ' - ' + RTRIM(NomeAbrev) AS FornDesc FROM Terceiros where TipoTerc='F' ORDER BY NomeAbrev"

            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtForn)

            'Carregar(ComboBox)
            Me.CbForn.DataSource = dtForn
            Me.CbForn.DisplayMember = "FornDesc"
            Me.CbForn.ValueMember = "TercId"
            Me.CbForn.DataBindings.Add("SelectedValue", dtCab, "FornID")

            Me.txtRefForn.DataBindings.Add("Text", dtCab, "RefForn")
            Me.txtCorForn.DataBindings.Add("Text", dtCab, "CorForn")
            Me.txtPrCusto.DataBindings.Add("Text", dtCab, "PrCusto")
            Me.txtDtEnt.Text = Today().AddDays(10)

            Me.WindowState = FormWindowState.Maximized

            Me.Cursor = Cursors.Default
            Application.DoEvents()
            C1DgridCab.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
            C1DgridCab.SelectedRows.Clear()

            Me.GirlDataSet.Reservas.Clear()
            Me.ReservasTableAdapter.FillByArmzAbertosPend(Me.GirlDataSet.Reservas)


            'Me.ReservasDataGridView(1, Me.ReservasDataGridView.Rows.Count - 1).Selected = True



            'EXEMPLO BOM .... NÃO APAGAR
            If Me.GirlDataSet.Reservas.Rows.Count > 0 Then
                Me.ReservasDataGridView.RowHeadersWidth = Me.ReservasDataGridView.ColumnHeadersHeight + 5
                Me.ActiveControl = Me.ReservasDataGridView
                If Me.ReservasDataGridView.RowCount > 2 Then
                    'Me.ReservasDataGridView.CurrentCell = Me.ReservasDataGridView(1, Me.ReservasDataGridView.Rows.Count - 2)
                    ReservasDataGridView.CurrentCell = ReservasDataGridView.Rows(ReservasDataGridView.Rows.Count - 2).Cells(ReservasDataGridView.CurrentCell.ColumnIndex)
                End If
            End If

            'Me.ReservasDataGridView("ReservaCorId", Me.ReservasDataGridView.Rows.Count - 1).Selected = True


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmTransf_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmTransf_Load")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            If Not Cmd Is Nothing Then Cmd.Dispose()
            Cmd = Nothing
        End Try


    End Sub

    Private Sub frmGestao_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If Me.ActiveControl.Name <> "C1DgridCab" Then
            Me.C1DgridCab.AllowRowSelect = True
            C1DgridCab_FilterChange(sender, e)
        End If
    End Sub

    Private Sub frmGestao_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'GravarReserva()
        'If GirlDataSet.Reservas.GetChanges Is Nothing Then
        'Else
        '    If MsgBox("Pretende Gravar as Alterações nas Reservas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        btGravarReserva_Click(sender, e)
        '    End If
        'End If
    End Sub

    Private Sub cbArmazem_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbArmazem.SelectedValueChanged
        Me.btlistar.Visible = False
    End Sub



    'EVENTOS NA C1DgridCab

    Private Sub C1DgridCab_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles C1DgridCab.HeadClick
        C1DgridCab.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
        C1DgridCab.SelectedRows.Clear()
        Me.PictureBox.Visible = False


    End Sub

    Private Sub C1DgridCab_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles C1DgridCab.RowColChange
        xValor = 0
        xTalao = ""
        TimerActDados.Stop()
        TimerActDados.Interval = 50
        TimerActDados.Start()
    End Sub

    Private Sub TimerActDados_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerActDados.Tick
        Try
            TimerActDados.Stop()
            ActualizaDetalhe()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "TimerActDados_Tick")
        Catch ex As Exception
            ErroVB(ex.Message, "TimerActDados_Tick")
        Finally
            cn.Close()
            Sql = Nothing
        End Try

    End Sub

    Private Sub C1DgridCab_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DgridCab.FilterChange

        Try
            'C1DgridCab.Columns(5).FilterText.Insert(1, "1")
            Me.PictureBox.Visible = False
            Me.CFGDet.Visible = False
            C1TrueDBGridFilterChange(C1DgridCab, Me.C1DgridCab.Columns, dtCab)

        Catch ex As Exception
            ErroVB(ex.Message, "C1DgridCab_FilterChange")
        End Try

    End Sub

    'EVENTOS NA C1FgEnc

    Private Sub C1FgEnc_AfterRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles C1FgEnc.AfterRowColChange
        Try


            If Me.C1FgEnc(0, Me.C1FgEnc.Cols.Count - 1) = "Total" Then
                Dim Coluna As Integer
                Dim Somatorio As Integer = 0
                For Coluna = 0 To Me.C1FgEnc.Cols.Count - 2
                    If IsNumeric(Me.C1FgEnc(1, Coluna)) Then
                        Somatorio += Me.C1FgEnc(1, Coluna)
                    End If
                Next
                If Somatorio > 0 Then
                    Me.C1FgEnc(1, Me.C1FgEnc.Cols.Count - 1) = Somatorio
                    Me.C1FgEnc.Cols(Me.C1FgEnc.Cols.Count - 1).AllowEditing = False
                End If
            End If

        Catch ex As Exception

            ErroVB(ex.Message, "C1FgEnc_AfterRowColChange")

        End Try

    End Sub

    'EVENTOS NA CFGDet

    Private Sub CFGDet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CFGDet.LostFocus
        If Me.ReservasDataGridView.Focus = False Then
            xValor = 0
            xTalao = ""
        End If
    End Sub

    Private Sub CFGDet_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CFGDet.MouseDown

        Dim db As New ClsSqlBDados

        Try


            xModelo = Me.C1DgridCab(Me.C1DgridCab.Row(), "ModeloID")
            xCor = Me.C1DgridCab(Me.C1DgridCab.Row(), "CorID")

            If Me.CFGDet.Col() > 4 Then
                If ((Me.CFGDet(Me.CFGDet.Row(), 1) >= "0000" And Me.CFGDet(Me.CFGDet.Row(), 1) <= "9999") Or (Me.CFGDet(Me.CFGDet.Row(), 1) >= "EC")) Then

                    If xValor = 0 Then

                        'VAI RETIRAR DO STOCK 
                        If Not Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) Is DBNull.Value Then
                            If Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) > 0 Then

                                xOrigem = Me.CFGDet(Me.CFGDet.Row(), ("ArmazemID"))
                                xTamTransf = Me.CFGDet.Cols(Me.CFGDet.Col()).Name

                                If ActualizaLigacao("Girl") = False Then Exit Try

                                If xOrigem = "EC" Then
                                    Sql = "SELECT COUNT(*) FROM SERIE WHERE ARMAZEMID = '0000' AND MODELOID='" & xModelo & "' AND CORID='" & xCor & "' AND TAMID='" & xTamTransf & "'AND ESTADOID IN ('G')"
                                Else
                                    Sql = "SELECT COUNT(*) FROM SERIE WHERE ARMAZEMID = '" & xOrigem & "' AND MODELOID='" & xModelo & "' AND CORID='" & xCor & "' AND TAMID='" & xTamTransf & "'AND ESTADOID IN ('S')"
                                End If
                                If db.GetDataValue(Sql) > 0 Then
                                    If xOrigem = "EC" Then
                                        Sql = "SELECT  ISNULL(MIN(Serie.SerieID),'') " & _
                                             "FROM Serie LEFT OUTER JOIN Reservas ON Serie.SerieID = Reservas.ReservaSerieID " & _
                                             "WHERE (Serie.ArmazemID = '0000') AND (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.TamID = '" & xTamTransf & "')  " & _
                                             "AND (Serie.EstadoID IN ('G')) AND (Reservas.ReservaSerieID IS NULL) "
                                        xOrigem = "0000"
                                    Else

                                        'Sql = "SELECT  ISNULL(MIN(Serie.SerieID),'') " & _
                                        ' "FROM Serie LEFT OUTER JOIN Reservas ON Serie.SerieID = Reservas.ReservaSerieID " & _
                                        ' "WHERE (Serie.ArmazemID = '" & xOrigem & "') AND (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.TamID = '" & xTamTransf & "')  " & _
                                        ' "AND (Serie.EstadoID IN ('S')) AND (Reservas.ReservaSerieID IS NULL) " & _
                                        ' "AND SERIEID NOT IN (SELECT SERIEID FROM DOCDET WHERE TIPODOCID='SE' AND  EstadoLn='G'); "



                                        Sql = "SELECT RESERVASERIEID INTO #RESERVAS FROM RESERVAS WHERE RESERVAESTADO='0'; " & _
                                            "SELECT  ISNULL(MIN(Serie.SerieID),'') " & _
                                           "FROM Serie LEFT OUTER JOIN #RESERVAS ON Serie.SerieID = #RESERVAS.ReservaSerieID " & _
                                           "WHERE (Serie.ArmazemID = '" & xOrigem & "') AND (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.TamID = '" & xTamTransf & "')  " & _
                                           "AND (Serie.EstadoID IN ('S')) AND (#RESERVAS.ReservaSerieID IS NULL) " & _
                                           "AND SERIEID NOT IN (SELECT SERIEID FROM DOCDET WHERE TIPODOCID='SE' AND  EstadoLn='G'); " & _
                                           "DROP TABLE #RESERVAS;"


                                    End If
                                    xTalao = db.GetDataValue(Sql)
                                    If Len(xTalao) <> 8 Then
                                        MsgBox("Stock Reservado!")
                                        xValor = 0
                                        Exit Sub
                                    Else
                                        xTalao = db.GetDataValue(Sql)
                                    End If
                                Else
                                    MsgBox("Stock Indisponivel!!")
                                    xValor = 0
                                    Exit Sub

                                End If


                                If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")


                                xValor = Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col())
                                xLnTranf = Me.CFGDet.Row.ToString
                                xColTranf = Me.CFGDet.Col.ToString
                                Me.CFGDet.GetCellStyleDisplay(xLnTranf, xColTranf).Border.Style = BorderStyleEnum.Double
                                Me.CFGDet.GetCellStyleDisplay(xLnTranf, xColTranf).Border.Color = Color.DarkRed

                            Else
                                MsgBox("Sem Stock para Transferir !")
                                xValor = 0
                                Exit Sub
                            End If
                        End If
                    ElseIf xValor > 0 Then
                        If Me.CFGDet.Cols(Me.CFGDet.Col()).Name = xTamTransf And (Me.CFGDet(Me.CFGDet.Row(), 1) >= "0000" And Me.CFGDet(Me.CFGDet.Row(), 1) <= "9999") Then


                            'VAI COLOCAR NO STOCK DA LOJA
                            If Not Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) Is DBNull.Value Then
                                xValor = 1 + Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col())
                                Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) = xValor
                            Else
                                Me.CFGDet(Me.CFGDet.Row(), Me.CFGDet.Col()) = 1
                            End If
                            Me.CFGDet(xLnTranf, xColTranf) = Me.CFGDet(xLnTranf, xColTranf) - 1
                            xDestino = Me.CFGDet(Me.CFGDet.Row(), ("ArmazemID"))
                            If xDestino = xOrigem Then
                            Else

                                If ActualizaLigacao("Girl") = False Then Exit Try


                                Sql = "INSERT INTO Reservas(ArmazemID, ArmzDest, ReservaDescr, ReservaSerieId, ReservaModeloId,ReservaCorId, " & _
                                    "ReservaTamId,ReservaData,ReservaEstado, OperadorID) " & _
                                    "VALUES('" & xOrigem & "', '" & xDestino & "', 'Transferir','" & xTalao & "', '" & xModelo & "','" & xCor & "','" & xTamTransf & "',GETDATE(),'0','" & xUtilizador & "')"
                                db.ExecuteData(Sql)

                                'Sql = "UPDATE Serie SET Obs = SUBSTRING(Obs, 1, LEN(Obs)-CHARINDEX('Transferir' ,Obs)) WHERE SERIEID='" & xTalao & "'"
                                'db.ExecuteData(Sql)

                                'Sql = "UPDATE Serie SET Obs = ISNULL(RTRIM(LTRIM(Obs)),'') + ' Transferir C-" & xDestino & "' WHERE SERIEID='" & xTalao & "'"
                                'db.ExecuteData(Sql)

                                'INSERIR DESCRITIVO PARA A RECEPÇÃO
                                Sql = "UPDATE Serie SET Obs1 = 'Transferir C-" & xDestino & "' WHERE SERIEID='" & xTalao & "'"
                                db.ExecuteData(Sql)

                                If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")



                                'dtTransf.Rows.Add(New Object() {xOrigem, xDestino, xModelo, xCor, xTamTransf})
                                xValor = 0
                                xTalao = ""
                            End If
                        Else
                            MsgBox("Tamanho Errado!")
                            xValor = 0
                            xTalao = ""
                        End If
                    End If
                Else
                    If xValor <> 0 Then MsgBox("CELULA ERRADA!")
                    xValor = 0
                    xTalao = ""
                End If
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CFGDet_MouseDown")
        Catch ex As Exception
            ErroVB(ex.Message, "CFGDet_MouseDown")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")


        End Try
    End Sub

    Private Sub CFGDet_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CFGDet.MouseMove
        Try

            Dim tip As String
            If CFGDet.MouseRow > 0 And CFGDet.MouseCol > 0 Then
                tip = Me.CFGDet.GetUserData(CFGDet.MouseRow, CFGDet.MouseCol)
                ToolTip1.SetToolTip(CFGDet, tip)
            End If

        Catch ex As Exception

        End Try
    End Sub

    'EVENTOS NA CFGDet ReservasDataGridView

    Private Sub btGravaReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGravaReserva.Click
        Try

            'If cbArmazemReserva.SelectedValue <> "%" Then
            If Not cbArmazemReserva.SelectedValue Is Nothing Then
                InserirReserva(False)
                Me.GirlDataSet.Reservas.Clear()
                Me.ReservasTableAdapter.FillByArmzAbertosPend(Me.GirlDataSet.Reservas)
            Else
                If MsgBox("Falta o Armazem!! Quer Lançar para todas?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    InserirReserva(True)
                    Me.GirlDataSet.Reservas.Clear()
                    Me.ReservasTableAdapter.FillByArmzAbertosPend(Me.GirlDataSet.Reservas)
                End If
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "btGravaReserva_Click")
        End Try

    End Sub

    Private Sub ReservasDataGridView_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles ReservasDataGridView.CellBeginEdit
        Try
            If ReservasDataGridView.CurrentCell.OwningColumn.HeaderText <> "Armazém" Then
                If ReservasDataGridView("ArmazemID", e.RowIndex).Value Is DBNull.Value Then
                    e.Cancel = True
                    MsgBox("FALTA O ARMAZEM!!", MsgBoxStyle.Critical)
                    Me.GirlDataSet.Reservas.RejectChanges()
                End If
            End If
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_CellBeginEdit")
        End Try
    End Sub

    Private Sub ReservasDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReservasDataGridView.CellEndEdit

        Dim db As New ClsSqlBDados
        Dim dt As New DataTable

        Try

            Dim xSerie As String = ""
            Dim xModelo As String = ""
            Dim xCor As String = ""
            Dim xTam As String = ""


            If e.ColumnIndex = 5 Then

                If Not IsDBNull(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value) Then
                    xSerie = ReservasDataGridView("ReservaSerieID", e.RowIndex).Value
                End If
                If Not IsDBNull(ReservasDataGridView("ReservaModeloId", e.RowIndex).Value) Then
                    xModelo = ReservasDataGridView("ReservaModeloId", e.RowIndex).Value
                End If
                If Not IsDBNull(ReservasDataGridView("ReservaCorId", e.RowIndex).Value) Then
                    xCor = ReservasDataGridView("ReservaCorId", e.RowIndex).Value
                End If
                If Not IsDBNull(ReservasDataGridView("ReservaTamId", e.RowIndex).Value) Then
                    xTam = ReservasDataGridView("ReservaTamId", e.RowIndex).Value
                End If

                If Len(xSerie) > 0 Then

                    Sql = "SELECT * FROM Serie WHERE SerieId='" & xSerie & "' AND ESTADOID NOT IN ('R')"
                    db.GetData(Sql, dt)

                    If Not dt Is Nothing And dt.Rows.Count > 0 Then
                        For Each r As DataRow In dt.Rows
                            If r("ModeloId") = xModelo And r("CorId") = xCor And r("TamId") = xTam Then
                            Else
                                If Trim(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value) <> "T" Then
                                    MsgBox("O TALÃO " & xSerie & "  NÃO CORRESPONDE AO PEDIDO")
                                    ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = ""
                                End If
                            End If
                            'Exit For
                        Next
                    Else
                        If Trim(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value) <> "T" Then
                            MsgBox("O TALÃO " & xSerie & " NÃO EXISTE")
                            ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = ""
                        End If
                    End If

                    'AVANÇA UMA LINHA
                End If
            End If


            'ALTERAR RESERVA

            If ReservasDataGridView("ReservaSerieID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaDescr", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaDescr", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaEstado", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaID", e.RowIndex).Value = 0
            If ReservasDataGridView("Despesas", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("Despesas", e.RowIndex).Value = 0


            Dim xReservaID As String = ReservasDataGridView("ReservaID", e.RowIndex).Value
            Dim xReservaSerieID As String = ReservasDataGridView("ReservaSerieID", e.RowIndex).Value
            Dim xReservaDescr As String = ReservasDataGridView("ReservaDescr", e.RowIndex).Value
            Dim xReservaEstado As String = ReservasDataGridView("ReservaEstado", e.RowIndex).Value
            Dim Despesas As String = ReservasDataGridView("Despesas", e.RowIndex).Value





            If Len(Trim(xReservaSerieID)) > 0 Then
                Sql = "UPDATE Reservas SET ReservaSerieID = '" & xReservaSerieID & "', OperadorID = '" & xUtilizador & "', DtRegisto = GETDATE() WHERE ReservaID='" & xReservaID & "'"
                db.ExecuteData(Sql)
            End If
            Sql = "UPDATE Reservas SET ReservaDescr = '" & xReservaDescr & "' , Despesas = '" & Despesas & "', ReservaEstado = '" & xReservaEstado & "', OperadorID = '" & xUtilizador & "', DtRegisto = GETDATE() WHERE ReservaID='" & xReservaID & "'"
            db.ExecuteData(Sql)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ReservasDataGridView_CellEndEdit")
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_CellEndEdit")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            dt = Nothing
        End Try

    End Sub

    Private Sub ReservasDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ReservasDataGridView.CellMouseClick
        Dim db As New ClsSqlBDados
        'Dim xOperador As String
        'Dim xReservaID As Integer

        Try

            'xReservaID = ReservasDataGridView("ReservaID", e.RowIndex).Value
            'Sql = "SELECT ISNULL(OPERADORID,'XXXX') FROM RESERVAS WHERE RESERVAID='" & xReservaID & "'"
            'xOperador = db.GetDataValue(Sql)
            'If xUtilizador <> xOperador Then
            '    Sql = "UPDATE RESERVAS SET OPERADORID='" & xUtilizador & "' WHERE RESERVAID='" & xReservaID & "'"
            '    db.ExecuteData(Sql)
            '    Me.GirlDataSet.Reservas.Clear()
            '    Me.ReservasTableAdapter.FillByArmzAbertosPend(Me.GirlDataSet.Reservas)
            '    Exit Sub
            'End If


            'If e.ColumnIndex = 5 Then
            If ReservasDataGridView.CurrentCell.OwningColumn.HeaderText = "Talão" Then

                Dim xModeloReserva As String = ""
                Dim xCorReserva As String = ""
                Dim xSerie As String = ""
                Dim xTamReserva As String = ""


                'Me.PictureBox.Visible = False
                'Me.CFGDet.Visible = False


                If Not IsDBNull(ReservasDataGridView("ReservaModeloId", e.RowIndex).Value) Then
                    xModeloReserva = ReservasDataGridView("ReservaModeloId", e.RowIndex).Value
                    If Not IsDBNull(ReservasDataGridView("ReservaCorId", e.RowIndex).Value) Then
                        xCorReserva = ReservasDataGridView("ReservaCorId", e.RowIndex).Value
                    End If
                End If

                ' VERIFICAR TALÃO

                If xValor > 0 Then
                    If Len(ReservasDataGridView("ReservaSerieID", e.RowIndex).ToString) <> 8 Then
                        If Not IsDBNull(ReservasDataGridView("ReservaTamId", e.RowIndex).Value) Then
                            xTamReserva = ReservasDataGridView("ReservaTamId", e.RowIndex).Value
                        End If

                        Sql = "SELECT MODELOID + CORID + TAMID ARTIGO FROM SERIE WHERE SERIEID = '" & xTalao & "'"

                        If xModeloReserva & xCorReserva & xTamReserva = db.GetDataValue(Sql) Then
                            ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = xTalao

                            'If ReservasDataGridView("ArmazemID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ArmazemID", e.RowIndex).Value = ""
                            'If ReservasDataGridView("ReservaDescr", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaDescr", e.RowIndex).Value = ""

                            'Dim xReservaID As Integer = ReservasDataGridView("ReservaID", e.RowIndex).Value
                            'Dim xReservaDescrID As String = ReservasDataGridView("ReservaDescr", e.RowIndex).Value
                            'Dim xArmazemID As Integer = ReservasDataGridView("ArmazemID", e.RowIndex).Value

                            'Sql = "UPDATE SERIE SET OBS='MED:C' + '" & xArmazemID & "' + '/R' + '" & xReservaID & "' WHERE SerieId='" & xTalao & "'"
                            'db.ExecuteData(Sql)

                            ReservasDataGridView.CurrentCell = ReservasDataGridView.Rows(ReservasDataGridView.CurrentCell.RowIndex).Cells(ReservasDataGridView.CurrentCell.ColumnIndex + 1)

                        Else
                            MsgBox("ERRO! Talão do Artigo :" & xModelo & "-" & xCor & "-" & xTamTransf)
                        End If
                    Else
                        MsgBox("Já tem Talão atribuido!!")
                    End If
                End If

            End If
            xValor = 0
            xTalao = ""

        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_CellMouseClick")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub ReservasDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ReservasDataGridView.CellMouseDoubleClick
        Dim db As New ClsSqlBDados
        Try


            Dim xSerie As String = ""
            Dim xTam As String = ""


            If e.ColumnIndex = 5 Then

                If Not IsDBNull(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value) Then
                    xSerie = ReservasDataGridView("ReservaSerieID", e.RowIndex).Value
                End If
                If Not IsDBNull(ReservasDataGridView("ReservaModeloId", e.RowIndex).Value) Then
                    xModelo = ReservasDataGridView("ReservaModeloId", e.RowIndex).Value
                End If
                If Not IsDBNull(ReservasDataGridView("ReservaCorId", e.RowIndex).Value) Then
                    xCor = ReservasDataGridView("ReservaCorId", e.RowIndex).Value
                End If
                If Not IsDBNull(ReservasDataGridView("ReservaTamId", e.RowIndex).Value) Then
                    xTam = ReservasDataGridView("ReservaTamId", e.RowIndex).Value
                End If


                Sql = "SELECT ISNULL(MIN(SerieID),0) FROM Serie LEFT JOIN Reservas ON Serie.SerieID = Reservas.ReservaSerieID " & _
                    "WHERE ReservaSerieID Is Null AND EstadoID='G' AND ModeloID = '" & xModelo & "' AND CorID = '" & xCor & "' AND TamID = '" & xTam & "' AND Serie.EstadoID = 'G';"

                xSerie = db.GetDataValue(Sql)
                If Len(xSerie) = 8 Then
                    ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = xSerie
                    ReservasDataGridView.CurrentCell = ReservasDataGridView.Rows(ReservasDataGridView.CurrentCell.RowIndex).Cells(ReservasDataGridView.CurrentCell.ColumnIndex + 1)

                Else
                    MsgBox("Não hà Talões Gerados disponiveis")
                End If

            End If
            'GravarReserva()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ReservasDataGridView_CellMouseDoubleClick")
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_CellMouseDoubleClick")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing

        End Try
    End Sub

    Private Sub ReservasDataGridView_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ReservasDataGridView.RowHeaderMouseClick
        Dim db As New ClsSqlBDados

        Try
            Dim xModeloReserva As String = ""
            Dim xCorReserva As String = ""


            If dtCab.Rows.Count > 0 Then

                If Not IsDBNull(ReservasDataGridView("ReservaModeloId", e.RowIndex).Value) Then
                    xModeloReserva = ReservasDataGridView("ReservaModeloId", e.RowIndex).Value
                    dtCab.DefaultView.RowFilter = "ModeloID='" & xModeloReserva & "'"
                    If Not IsDBNull(ReservasDataGridView("ReservaCorId", e.RowIndex).Value) Then
                        xCorReserva = ReservasDataGridView("ReservaCorId", e.RowIndex).Value
                    End If

                    Dim Linha As Integer = 0
                    Do Until Me.C1DgridCab(Linha, "CorID") = xCorReserva
                        Linha = Linha + 1
                        If Linha = 15 Then Exit Do
                    Loop
                    C1DgridCab.Row = Linha
                Else
                    dtCab.DefaultView.RowFilter = ""
                End If
                TimerActDados.Stop()
                TimerActDados.Interval = 50
                TimerActDados.Start()

            End If


        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_RowHeaderMouseClick")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Private Sub ReservasDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles ReservasDataGridView.RowValidating
        Dim db As New ClsSqlBDados

        Try


            If ReservasDataGridView("ArmazemID", e.RowIndex).Value Is DBNull.Value Then
                'MsgBox("FALTA O ARMAZEM!!", MsgBoxStyle.Critical)
                Me.GirlDataSet.Reservas.RejectChanges()
            Else

                If ReservasDataGridView("ReservaData", e.RowIndex).Value Is DBNull.Value Then
                    ReservasDataGridView("ReservaData", e.RowIndex).Value = Now()
                End If
                If ReservasDataGridView("ReservaEstado", e.RowIndex).Value Is DBNull.Value Then
                    ReservasDataGridView("ReservaEstado", e.RowIndex).Value = False
                End If

                'Me.Validate()
                Me.ReservasBindingSource.EndEdit()

                If Not GirlDataSet.Reservas.GetChanges Is Nothing Then


                    'Me.ReservasBindingSource.EndEdit()


                    'Sql = "UPDATE SERIE SET SERIE.Obs = N'MED:C-' + rtrim(R.ArmazemID*1) + ' ' + ISNULL(R.ReservaDescr,'') FROM SERIE, Reservas R " & _
                    '    "Where SERIE.SerieID = R.ReservaSerieID AND ReservaEstado = '0'"
                    'db.ExecuteData(Sql)

                    If ReservasDataGridView("ArmazemID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ArmazemID", e.RowIndex).Value = ""
                    If ReservasDataGridView("ReservaSerieID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = ""
                    If ReservasDataGridView("ReservaDescr", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaDescr", e.RowIndex).Value = ""
                    If ReservasDataGridView("Despesas", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("Despesas", e.RowIndex).Value = ""




                    Dim xReservaID As Integer = ReservasDataGridView("ReservaID", e.RowIndex).Value
                    Dim xReservaDescrID As String = ReservasDataGridView("ReservaDescr", e.RowIndex).Value
                    Dim xArmazemID As Integer = ReservasDataGridView("ArmazemID", e.RowIndex).Value.ToString
                    Dim xSerie As String = ReservasDataGridView("ReservaSerieID", e.RowIndex).Value
                    Dim Despesas As String = ReservasDataGridView("Despesas", e.RowIndex).Value


                    Sql = "SELECT ISNULL(OBS,'') FROM SERIE WHERE SERIEID='" & xSerie & "'"
                    Dim xObsTalao As String = ""
                    xObsTalao = Trim(db.GetDataValue(Sql))

                    Dim xObsReservaTalao As String = ""
                    'xObsReservaTalao = "MED:C' + '" & xArmazemID & "' + '/R' + '" & xReservaID & "'+ '"
                    xObsReservaTalao = "MED:C" & xArmazemID & "/R" & xReservaID & " *"


                    Dim i As Int16
                    For i = 1 To 15 - Len(xObsReservaTalao)
                        xObsReservaTalao = xObsReservaTalao + " "
                    Next


                    If Len(xSerie) > 0 Then
                        If Len(xObsTalao) = 0 Then
                            Sql = "UPDATE SERIE SET OBS='" & xObsReservaTalao & "' WHERE SerieId='" & xSerie & "'"
                            db.ExecuteData(Sql)
                        ElseIf Microsoft.VisualBasic.Left(xObsTalao, 3) = "MED" And Len(xObsTalao) <= 16 Then
                            Sql = "UPDATE SERIE SET OBS='" & xObsReservaTalao & "' WHERE SerieId='" & xSerie & "'"
                            db.ExecuteData(Sql)
                        ElseIf Microsoft.VisualBasic.Left(xObsTalao, 3) <> "MED" Then
                            Sql = "UPDATE SERIE SET OBS = OBS + '" & xObsReservaTalao & "'  WHERE SerieId='" & xSerie & "'"
                            db.ExecuteData(Sql)
                        ElseIf Microsoft.VisualBasic.Left(xObsTalao, 3) = "MED" And Len(xObsTalao) > 16 Then
                            xObsTalao = Microsoft.VisualBasic.Right(xObsTalao, Len(xObsTalao) - 16)
                            Sql = "UPDATE SERIE SET OBS = OBS + '" & xObsReservaTalao & "' WHERE SerieId='" & xSerie & "'"
                            db.ExecuteData(Sql)
                        End If
                    End If
                End If

                Sql = "UPDATE RESERVAS SET ARMZDEST=ARMAZEMID WHERE ARMZDEST IS NULL"
                db.ExecuteData(Sql)

                'Me.ReservasTableAdapter.Update(Me.GirlDataSet.Reservas)

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ReservasDataGridView_RowValidating")
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_RowValidating")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try




    End Sub

    Private Sub ReservasDataGridView_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReservasDataGridView.RowLeave
        Dim db As New ClsSqlBDados

        Try
            If Not ReservasDataGridView("ArmazemID", e.RowIndex).Value Is DBNull.Value Then
                If ReservasDataGridView("ReservaModeloID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaModeloID", e.RowIndex).Value = ""
                If ReservasDataGridView("ReservaCorID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaCorID", e.RowIndex).Value = ""
                If ReservasDataGridView("ReservaTamID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaTamID", e.RowIndex).Value = ""
                If ReservasDataGridView("ReservaSerieID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = ""
                If ReservasDataGridView("ReservaDescr", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaDescr", e.RowIndex).Value = ""
                If ReservasDataGridView("Despesas", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("Despesas", e.RowIndex).Value = ""


                Dim xReservaID As Integer = ReservasDataGridView("ReservaID", e.RowIndex).Value
                Dim xArmazemID As String = ReservasDataGridView("ArmazemID", e.RowIndex).Value
                Dim xReservaModeloID As String = ReservasDataGridView("ReservaModeloID", e.RowIndex).Value
                Dim xReservaCorID As String = ReservasDataGridView("ReservaCorID", e.RowIndex).Value
                Dim xReservaTamID As String = ReservasDataGridView("ReservaTamID", e.RowIndex).Value
                Dim xReservaSerieID As String = ReservasDataGridView("ReservaSerieID", e.RowIndex).Value
                Dim xReservaDescrID As String = ReservasDataGridView("ReservaDescr", e.RowIndex).Value
                Dim Despesas As String = ReservasDataGridView("Despesas", e.RowIndex).Value

                Sql = "UPDATE RESERVAS SET ArmazemID='" & xArmazemID & "', ReservaModeloID='" & xReservaModeloID & "', ReservaCorID='" & xReservaCorID & "',ReservaTamID='" & xReservaTamID & "',ReservaSerieID='" & xReservaSerieID & "',ReservaDescr='" & xReservaDescrID & "', Despesas='" & Despesas & "' WHERE ReservaID='" & xReservaID & "'"
                db.ExecuteData(Sql)

            End If

            'MsgBox(xReservaID)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ReservasDataGridView_RowLeave")
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_RowLeave")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Private Sub ReservasDataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReservasDataGridView.RowEnter
        Dim db As New ClsSqlBDados

        Try

            If ReservasDataGridView("ArmazemID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ArmazemID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaModeloID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaModeloID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaCorID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaCorID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaTamID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaTamID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaSerieID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaDescr", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaDescr", e.RowIndex).Value = ""



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ReservasDataGridView_RowEnter")
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_RowEnter")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing

        End Try


    End Sub

    Private Sub ReservasDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles ReservasDataGridView.UserDeletingRow
        Dim db As New ClsSqlBDados

        Try

            If MsgBox("Confirma que quer apagar?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            Else
                Sql = "DELETE RESERVAS WHERE RESERVAID='" & ReservasDataGridView("ReservaID", e.Row.Index).Value & "'"
                db.ExecuteData(Sql)
            End If
            'Me.GirlDataSet.Reservas.AcceptChanges()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ReservasDataGridView_UserDeletingRow")
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_UserDeletingRow")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub



    'FUNÇÕES

    Private Function FotoModeloCor(ByVal xModCor As String) As Boolean
        FotoModeloCor = False
        Me.PictureBox.Visible = False
        If IO.Directory.Exists(xFotosPath) Then
            If IO.File.Exists(xFotosPath & xModCor & ".jpg") Then
                With Me.PictureBox
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Image = Image.FromFile(xFotosPath & xModCor & ".jpg")
                    .Visible = True
                    Return True
                End With
            End If
        End If
    End Function

    Private Sub CarregarC1DgridCab()

        Dim db As New ClsSqlBDados

        Try
            Me.Cursor = Cursors.WaitCursor
            dtCab.Clear()
            dataVendaConv = DataVenda.Text
            xcbFiltraData = 0
            If cbFiltraData.Checked = False Then xcbFiltraData = 0
            If cbFiltraData.Checked = True Then xcbFiltraData = 1
            xLoja = cbArmazem.SelectedValue.ToString

            'LIMPAR OS REGISTOS FECHADOS DA TABELA RESERVAS
            'Sql = "DELETE FROM RESERVAS WHERE ReservaDescr='Transferir' and ReservaEstado='1' "
            'db.ExecuteData(Sql)

            Sql = "EXEC prc_TransfCab @EmpresaID = '" & xEmp & "', @ArmazemID = '" & xArmz & "', @LojaID = '" & xLoja & "', @FiltroVD = '" & xcbFiltraData & "', @DataVD ='" & Format(dataVendaConv, "yyyy-MM-dd") & "'"
            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.SelectCommand.CommandTimeout = 0
            da.Fill(dtCab)
            Me.C1DgridCab.DataSource = dtCab
            Application.DoEvents()
            Me.Cursor = Cursors.Default

            C1DgridCab.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
            C1DgridCab.SelectedRows.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btFiltraVendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFiltraVendas.Click
        CarregarC1DgridCab()
    End Sub

    Private Sub cbFiltraData_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFiltraData.CheckedChanged
        If cbFiltraData.Checked = False Then
            cbFiltraLoja.Visible = True
            DataVenda.Visible = False
            btFiltraVendas.Visible = False
            cbArmazem.Visible = False
            Me.cbArmazem.SelectedValue = "%"
            'xLoja = "%"
            CarregarC1DgridCab()
        Else
            cbFiltraLoja.Visible = False
            DataVenda.Text = Today().AddDays(-10)
            DataVenda.Visible = True
            btFiltraVendas.Visible = True
            cbArmazem.Visible = True

        End If
    End Sub

    Private Sub CmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFechar.Click
        Close()
    End Sub

    Private Sub cmdPrintSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ListarTranf()
    End Sub

    'Private Sub ListarTranf()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim frm As New frmReport
    '    Try
    '        With frm
    '            If MsgBox("Listar com Imagem?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '                .C1RptTranfFoto.Load(xRptPath & "RptTransfFoto.xml", "TransfFoto")
    '            Else
    '                .C1RptTranfFoto.Load(xRptPath & "RptTransf.xml", "Transf")
    '            End If
    '            .C1RptTranfFoto.DataSource.ConnectionString = sconnectionstringReport
    '            .C1RptTranfFoto.DataSource.RecordSource = "SELECT *, ModeloID + CorID Foto FROM TRANSFAUX ORDER BY ORIGEM, MODELOID,CORID,TAMID, DESTINO"
    '            .C1PrtPreview.Document = .C1RptTranfFoto.Document
    '            .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize
    '            Application.DoEvents()
    '            Me.Cursor = Cursors.Default
    '            .Show()
    '        End With

    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "ListarTranf")
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "ListarTranf")
    '    Finally
    '        If cn.State = ConnectionState.Open Then cn.Close()
    '        Me.Cursor = Cursors.Default
    '    End Try
    'End Sub

    Private Sub cbFiltraLoja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFiltraLoja.CheckedChanged
        If cbFiltraLoja.Checked = False Then
            cbFiltraData.Visible = True
            DataVenda.Visible = False
            btFiltraVendas.Visible = False
            cbArmazem.Visible = False
            Me.cbArmazem.SelectedValue = "%"
            xLoja = "%"
            CarregarC1DgridCab()
        Else
            cbFiltraData.Visible = False
            DataVenda.Visible = False
            btFiltraVendas.Visible = True
            cbArmazem.Visible = True
        End If
    End Sub

    Private Sub ActualizaDetalhe()

        Dim db As New ClsSqlBDados


        Try
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox.Visible = False
            Me.CFGDet.Visible = False
            Application.DoEvents()

            Dim xModelo As String
            Dim xCor As String
            Dim dtDet As New DataTable
            Dim dttips As New DataTable
            Dim xtip As String = ""
            Dim xArmzAux As String

            If dtCab.DefaultView.Count > 0 Then
                Me.C1DgridCab.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                xModelo = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "ModeloID")
                xCor = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "CorID")
                Dim iEnv As Integer = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "Comprados")
                Dim iVnd As Integer = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "Vendidos")

                Dim xIncReservas As Integer = 0
                'If xUtilizador = "Jose Guedes" Then xIncReservas = 1
                If cbIncReservas.Checked = True Then xIncReservas = 1

                Sql = "EXEC prc_TransfDet @ModeloID = '" & xModelo & "', @CorID = '" & xCor & "', @IncReservas='" & xIncReservas & "'"

                If cn.State = ConnectionState.Closed Then cn.Open()
                da = New SqlDataAdapter(Sql, cn)
                da.Fill(dtDet)


                Sql = "SELECT ISNULL(DocCab.TercID,Serie.ArmazemID)ArmzVirtual, Serie.TamID, Serie.SerieID AS Talão, Serie.EstadoID +'/'+ Serie.ArmazemID Estado " &
                   "FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND  " &
                   "DocCab.DocNr = DocDet.DocNr RIGHT OUTER JOIN Serie ON DocDet.SerieID = Serie.SerieID AND DocDet.TipoDocID = 'SE' AND DocDet.EstadoLn = 'G' " &
                   "WHERE (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.EstadoID IN ('S', 'T')) " &
                   "ORDER BY ArmzVirtual, Serie.TamID"

                dttips.Clear()
                db.GetData(Sql, dttips)



                With Me.CFGDet
                    .DataSource = dtDet
                    Dim I, J As Integer
                    For I = 1 To CFGDet.Rows.Count - 1
                        For J = 3 To CFGDet.Cols.Count - 1
                            If CFGDet(I, J).ToString = "0" Or CFGDet(I, J).ToString = "0.0" Then CFGDet(I, J) = DBNull.Value
                            'If dttips.Rows.Count > 0 And Me.CFGDet.Cols(J).Name not in ("Cod", "Armazem","Vnd","VndP") Then
                            If dttips.Rows.Count > 0 _
                            And Me.CFGDet.Cols(J).Name <> "Cod" _
                            And Me.CFGDet.Cols(J).Name <> "Armazem" _
                            And Me.CFGDet.Cols(J).Name <> "Vnd" _
                            And CFGDet(I, 1).ToString <> "VndP" Then
                                For Each linha As DataRow In dttips.Rows
                                    If linha("ArmzVirtual") = Me.CFGDet(I, 1).ToString And linha("TamID") = Me.CFGDet.Cols(J).Name Then
                                        xtip = linha("Talão") & " - " & linha("Estado") & Chr(13) & xtip
                                    End If
                                Next
                                Me.CFGDet.SetUserData(I, J, xtip)
                                xtip = ""
                            End If
                            Me.CFGDet.Cols(J).TextAlign = TextAlignEnum.CenterCenter
                        Next

                        If Len(Trim(CFGDet(I, "Vnd").ToString)) = 0 And Trim(CFGDet(I, "ArmazemID").ToString) > "0000" Then
                            xArmzAux = CFGDet(I, "ArmazemID").ToString
                            Sql = "SELECT COUNT(*) FROM DOCDET WHERE EMPRESAID='" & xEmp & "' AND ARMAZEMID = '" & xArmzAux & "' AND TIPODOCID='RC' AND MODELOID='" & xModelo & "' AND CORID='" & xCor & "' GROUP BY ArmazemID"
                            If db.GetDataValue(Sql) > 0 Then
                                CFGDet(I, "Vnd") = "0"
                            End If
                        End If
                    Next

                    'CARREGAR A TOOLTIP
                    'Me.CFGDet.SetUserData(I, J, "Linha " & I & Chr(13) & "Coluna " & J)

                    'Dim I, J As Integer
                    'For I = 1 To CFGDet.Rows.Count - 1
                    '    For J = 3 To CFGDet.Cols.Count - 1
                    '        If CFGDet(I, "ArmazemID").ToString = "0000" Then
                    '            If CFGDet(I, J).ToString.LastIndexOf("/") <> -1 Then
                    '                CFGDet(I, J) = CFGDet(I, J).ToString.LastIndexOf("/").ToString
                    '            End If
                    '        Else
                    '            If CFGDet(I, J).ToString = "0/0" Or CFGDet(I, J).ToString = "0" Or CFGDet(I, J).ToString = "0.0" Then CFGDet(I, J) = DBNull.Value
                    '        End If
                    '        Me.CFGDet.Cols(J).TextAlign = TextAlignEnum.CenterCenter
                    '    Next
                    'Next

                    '.Cols("RT").Format = "00%"
                    .Cols("ArmazemID").Caption = "Cod"
                    .Cols("ArmAbrev").Caption = "Armazem"

                    .AllowEditing = False
                    .AutoResize = True
                    .AllowDragging = AllowDraggingEnum.None

                    '.SubtotalPosition = SubtotalPositionEnum.BelowData
                    '.Tree.Column = 1
                    '.Subtotal(AggregateEnum.Clear)
                    'Dim c As Integer
                    'For c = 3 To .Cols.Count - 1
                    '    If c = 6 Then
                    '        .Subtotal(AggregateEnum.None, 0, -1, c, "Total")
                    '    Else
                    '        .Subtotal(AggregateEnum.Sum, 0, -1, c, "Total")
                    '    End If
                    'Next

                    .AutoSizeCols()
                    Dim LarguraTotalColunas As Double = 0
                    Dim AlturaTotalLinhas As Double = 0
                    AlturaTotalLinhas = .Rows(0).HeightDisplay * CFGDet.Rows.Count

                    'For I = 0 To CFGDet.Rows.Count - 1
                    '    AlturaTotalLinhas += .Rows(I).HeightDisplay
                    'Next
                    For I = 0 To CFGDet.Cols.Count - 1
                        If .Cols(I).Visible = True Then
                            LarguraTotalColunas += .Cols(I).WidthDisplay
                        End If
                    Next
                    .Width = LarguraTotalColunas * 1.05
                    .Height = AlturaTotalLinhas * 1.05
                End With

                dtEnc = dtDet.Copy
                With dtEnc
                    .Clear()
                    .Columns.Remove("ArmazemID")
                    .Columns.Remove("ArmAbrev")
                    '.Columns.Remove("ENV")
                    .Columns.Remove("VND")
                    .Columns.Remove("VndP")
                    '.Columns.Remove("RT")
                    .Columns.Add("Total")
                End With
                Dim dr As DataRow = dtEnc.NewRow()
                dtEnc.Rows.Add(dr)

                With Me.C1FgEnc
                    .DataSource = dtEnc
                    .ScrollBars = ScrollBars.None
                    .Cols.Fixed = 0
                    If .Cols.Count() > 0 Then
                        Dim Largura As Double = .Cols(0).Width * .Cols.Count()
                        .Width = Largura * 1.1 + 10
                    End If
                    .AllowResizing = AllowResizingEnum.None
                    .AllowSorting = AllowSortingEnum.None
                    .AllowDragging = AllowDraggingEnum.None
                End With
                CarregarFoto.CarregarFotoModeloCor(Me.PictureBox, xModelo & xCor, "xok")
                'FotoModeloCor(xModelo & xCor)

                Application.DoEvents()
                Me.PictureBox.Visible = True
                Me.CFGDet.Visible = True
                Me.Cursor = Cursors.Default
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaDetalhe")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaDetalhe")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            cn.Close()
            Sql = Nothing

            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub CmdConfEnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConfEnc.Click
        Try

            If Not Me.C1FgEnc(1, "Total") Is DBNull.Value Then
                If Me.C1FgEnc(1, "Total") > 0 Then

                    If cn.State = ConnectionState.Closed Then cn.Open()
                    Sql = "SELECT MAX(NrEnc) NrEnc FROM Encomendas WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "'"
                    Cmd = New SqlCommand(Sql, cn)
                    If Not Cmd.ExecuteScalar Is DBNull.Value Then
                        xNumero = Cmd.ExecuteScalar
                        If xNumero.ToString.Substring(0, 4) <> Year(Today) Then
                            xNumero = Year(Today) & "0000"
                        End If
                    Else
                        xNumero = Year(Today) & "0000"
                    End If

                    Dim Incrementar As Integer = Microsoft.VisualBasic.Right(xNumero, 4)
                    Incrementar += 1
                    xNumero = xNumero.Substring(0, 4) & Format(Incrementar, "0000")

                End If

                Dim xNrEnc As String = xNumero
                Dim xForn As String = Me.CbForn.SelectedValue
                Dim txtRefForn As String = Me.txtRefForn.Text
                Dim txtCorForn As String = Me.txtCorForn.Text
                Dim xPrCusto As Double = Me.txtPrCusto.Text
                Dim xDtEnt As String = Format(CDate(Me.txtDtEnt.Text), "yyyy-MM-dd")
                Dim xObs As String = Me.txtObs.Text

                Dim xGrupo As String = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "GrupoID")
                Dim xTipo As String = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "TipoID")
                Dim xAltura As String = ""
                If Not Me.C1DgridCab(Me.C1DgridCab.Bookmark, "Altura") Is DBNull.Value Then
                    xAltura = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "Altura")
                End If

                Dim xModelo As String = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "ModeloID")
                Dim xCor As String = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "CorID")
                Dim xLinha As String = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "LinhaID")
                Dim xModCorDesc As String = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "ModCorDescr")
                Dim xPrEtiq As String = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "PrEtiq")
                Dim xData As String = Format(Now, "yyyy-MM-dd")

                Dim xEncPend As Int32 = Me.C1DgridCab(Me.C1DgridCab.Bookmark, "EncPend")

                If xArmz <> "0000" Then
                    'DESCOBRIR PORQUE É QUE POR VEZES NÃO COLOCA O ARM 0000 NAS ENCOMENDAS
                    MsgBox("ARMAZEM " & xArmz & " ERRADO! CONTACTE O ADMINISTRADOR DO SISTEMA")
                    Application.Exit()
                End If

                Sql = "INSERT INTO Encomendas (EmpresaID, ArmazemID, NrEnc, LnEnc, FornId, RefForn, CorForn, PrCusto, " &
                    "DtEntrega, GrupoID, TipoID, Altura, ModeloID, CorID, LinhaID, ModCorDescr, PrecoEtiqueta, Obs, " &
                    "EstadoEnc, TGerado, DataDoc, OperadorID) " &
                    "VALUES('" & xEmp & "','" & xArmz & "','" & xNrEnc & "',1,'" & xForn & "','" & txtRefForn & "', " &
                    "'" & txtCorForn & "','" & xPrCusto & "','" & xDtEnt & "','" & xGrupo & "','" & xTipo & "', " &
                    "'" & xAltura & "','" & xModelo & "','" & xCor & "','" & xLinha & "','" & xModCorDesc & "', " &
                    "'" & xPrEtiq & "','" & xObs & "','P','0','" & xData & "','" & xUtilizador & "') "
                Cmd = New SqlCommand(Sql, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                Cmd.ExecuteNonQuery()

                Dim I As Int16
                Dim QtdCol As Int16 = Me.C1FgEnc.Cols.Count - 1
                Dim QtdTot As Int32
                For I = 0 To QtdCol - 1
                    If Not Me.C1FgEnc(1, I) Is DBNull.Value Then
                        If Me.C1FgEnc(1, I) <> 0 Then
                            Sql = "INSERT INTO EncDetTam(EmpresaID, ArmazemID, NrEnc, LnEnc, TamID, Qtd) " &
                                  "VALUES('" & xEmp & "', '" & xArmz & "', '" & xNrEnc & "', 1, '" & Me.C1FgEnc(0, I) & "', '" & Me.C1FgEnc(1, I) & "')"
                            Cmd = New SqlCommand(Sql, cn)
                            If cn.State = ConnectionState.Closed Then cn.Open()
                            Cmd.ExecuteNonQuery()
                            cn.Close()
                            QtdTot += Me.C1FgEnc(1, I)
                        End If
                    End If
                Next

                For I = 0 To QtdCol
                    Me.C1FgEnc(1, I) = DBNull.Value
                Next

                Me.C1DgridCab(Me.C1DgridCab.Bookmark, "EncPend") = xEncPend + QtdTot
                Me.txtObs.Clear()

                ActualizaDetalhe()

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CmdConfEnc_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "CmdConfEnc_Click")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub btlistar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btlistar.Click
        ListarAnaliseGeral()
    End Sub

    Private Sub ListarAnaliseGeral()
        Me.Cursor = Cursors.WaitCursor
        Dim frm As New frmReport
        Dim db As New ClsSqlBDados

        Try
            Sql = "SELECT ModeloCor.ModeloID+ModeloCor.CorID txtFoto, ModeloCor.PrCusto, ModeloCor.PrVnd, Stock.Stk, Vendas.Vnd " &
                    "FROM (SELECT ModeloID, CorID, ISNULL(SUM(1),0) Vnd FROM Serie AS Serie_1 WHERE (EstadoID IN ('V', 'R')) " &
                    "GROUP BY ModeloID, CorID) AS Vendas RIGHT OUTER JOIN Modelos INNER JOIN ModeloCor ON Modelos.ModeloID = ModeloCor.ModeloID ON Vendas.ModeloID = ModeloCor.ModeloID AND " &
                    "Vendas.CorID = ModeloCor.CorID LEFT OUTER JOIN (SELECT ModeloID, CorID, ISNULL(SUM(1),0) AS Stk " &
                    "FROM Serie WHERE (EstadoID IN ('S', 'T')) GROUP BY ModeloID, CorID) Stock ON ModeloCor.ModeloID = Stock.ModeloID AND ModeloCor.CorID = Stock.CorID " &
                    "WHERE (Modelos.GrupoID = '6') AND (Modelos.EpocaID = '08') ORDER BY PrVnd, Vendas.Vnd DESC"
            db.ExecuteData(Sql)
            db = Nothing

            With frm
                .C1RptAnaliseGeral.Load(xRptPath & "RptAnaliseGeral.xml", "AnaliseGeral")
                .C1RptAnaliseGeral.DataSource.ConnectionString = sconnectionstringReport
                .C1RptAnaliseGeral.DataSource.RecordSource = Sql

                JustPrint(.C1RptAnaliseGeral)


                '.C1PrtPreview.Document = .C1RptAnaliseGeral.Document
                '.C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize
                'Application.DoEvents()
                '.Show()
            End With

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListarAnaliseGeral")
        Catch ex As Exception
            ErroVB(ex.Message, "ListarAnaliseGeral")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GravarReserva()

        Dim db As New ClsSqlBDados
        Try

            If Not GirlDataSet.Reservas.GetChanges Is Nothing Then

                Me.Validate()
                Me.ReservasBindingSource.EndEdit()
                Me.ReservasTableAdapter.Update(Me.GirlDataSet.Reservas)

                Sql = "UPDATE RESERVAS SET ARMZDEST=ARMAZEMID WHERE ARMZDEST IS NULL"
                db.ExecuteData(Sql)

                Me.GirlDataSet.Reservas.AcceptChanges()
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravarReserva")
        Catch ex As Exception
            ErroVB(ex.Message, "GravarReserva")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Function ReservasDataGridView_ValidarArmazem() As Boolean

        Dim db As New ClsSqlBDados
        Try
            If ReservasDataGridView.Rows.Count > 0 Then
                If ReservasDataGridView("ArmazemID", ReservasDataGridView.CurrentCell.RowIndex).Value Is Nothing Then
                    'SendKeys.Send("{ESCAPE}")
                    Return False
                Else
                    If ReservasDataGridView("ArmazemID", ReservasDataGridView.CurrentCell.RowIndex).Value Is DBNull.Value Then
                        'SendKeys.Send("{ESCAPE}")
                        Return False
                    Else
                        Dim xArmzAux As String = ReservasDataGridView("ArmazemID", ReservasDataGridView.CurrentCell.RowIndex).Value
                        Sql = "SELECT COUNT(ArmazemID) FROM Armazens WHERE ArmazemID = '" + xArmzAux + "'"
                        If db.GetDataValue(Sql) <= 0 Then
                            MsgBox("ARMAZEM ERRADO !!", MsgBoxStyle.Critical)
                            'ReservasDataGridView.CurrentCell = Me.ReservasDataGridView(1, Me.ReservasDataGridView.CurrentCell.RowIndex)
                            Return False
                        End If
                    End If
                End If
                Return True
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ReservasDataGridView_ValidarArmazem")
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_ValidarArmazem")
        Finally

            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function

    Private Sub InserirReserva(ByVal xLancarTodas As Boolean)
        Dim db As New ClsSqlBDados
        Dim xArmReservas As String = cbArmazemReserva.SelectedValue
        Dim dt As New DataTable


        Try

            Sql = "SELECT ArmazemID FROM Armazens WHERE Activo='1'"
            db.GetData(Sql, dt, False)

            'If xLancarTodas = True Then
            '    xArmReservas = "MSN"
            'End If
            Dim xReserva As String = Trim(Me.tbReserva.Text) & Trim(Me.txtRModelo.Text) & Trim(Me.txtRCor.Text) & Trim(Me.txtRTam.Text)
            If xReserva.Length > 0 Then
                If Len(Trim(Me.tbReserva.Text)) = 0 Then Me.tbReserva.Text = "Medida"

                If xLancarTodas = False Then
                    Sql = "INSERT INTO Reservas (ArmazemID, ArmzDest, ReservaDescr,ReservaModeloId, ReservaCorId, ReservaTamId, ReservaData, ReservaEstado, OperadorID) " & _
                        "VALUES ('" & xArmReservas & "', '" & xArmReservas & "', '" & Me.tbReserva.Text & "','" & Me.txtRModelo.Text & "','" & Me.txtRCor.Text & "','" & Me.txtRTam.Text & "',GETDATE(),'0','" & xUtilizador & "')"
                    db.ExecuteData(Sql)
                Else
                    For Each r As DataRow In dt.Rows
                        Sql = "INSERT INTO Reservas (ArmazemID, ArmzDest, ReservaDescr,ReservaModeloId, ReservaCorId, ReservaTamId, ReservaData, ReservaEstado, OperadorID) " & _
                        "VALUES ('" & r("ArmazemID") & "', '" & r("ArmazemID") & "', '" & Me.tbReserva.Text & "','" & Me.txtRModelo.Text & "','" & Me.txtRCor.Text & "','" & Me.txtRTam.Text & "',GETDATE(),'0','" & xUtilizador & "')"
                        db.ExecuteData(Sql)
                    Next
                End If

                'MsgBox("Gravação efectuada com sucesso!")
                Me.cbArmazemReserva.SelectedValue = "%"
                Me.txtRModelo.Text = ""
                Me.txtRCor.Text = ""
                Me.txtRTam.Text = ""
                Me.tbReserva.Text = ""

            End If


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " InserirReserva")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub cbIncReservas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIncReservas.CheckedChanged
        ActualizaDetalhe()
    End Sub

    Private Sub cbDetalhe_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDetalhe.CheckedChanged
        If cbDetalhe.Checked = False Then
            Me.gbDetalhesEnc.Visible = False
        Else
            Me.gbDetalhesEnc.Visible = True
        End If
    End Sub



End Class



