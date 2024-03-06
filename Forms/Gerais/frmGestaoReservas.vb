Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmGestaoReservas
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
    Friend WithEvents TimerActDados As System.Windows.Forms.Timer
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents ReservasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReservasTableAdapter As GirlRootName.GirlDataSetTableAdapters.ReservasTableAdapter
    Friend WithEvents ReservasDataGridView As System.Windows.Forms.DataGridView
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
    Friend WithEvents CFGDet As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents CmdFechar As System.Windows.Forms.Button
    Friend WithEvents gbCReservas As System.Windows.Forms.GroupBox
    Friend WithEvents rbTratadas As System.Windows.Forms.RadioButton
    Friend WithEvents rbPendentes As System.Windows.Forms.RadioButton
    Friend WithEvents btListaTrasf As System.Windows.Forms.Button
    Friend WithEvents rbTransf As System.Windows.Forms.RadioButton
    Friend WithEvents btAtualiza As System.Windows.Forms.Button
    Friend WithEvents btCliente As System.Windows.Forms.Button
    Friend WithEvents lbCliente As System.Windows.Forms.Label
    Friend WithEvents ArmazemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArmzDest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaModeloId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaCorId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaTamId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaSerieID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Despesas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaEstado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReservaData As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaClienteLojaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbTodas As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGestaoReservas))
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.TimerActDados = New System.Windows.Forms.Timer(Me.components)
        Me.ReservasDataGridView = New System.Windows.Forms.DataGridView()
        Me.ArmazemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArmzDest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaModeloId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaCorId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaTamId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaSerieID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despesas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaEstado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReservaData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaClienteLojaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
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
        Me.CFGDet = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.CmdFechar = New System.Windows.Forms.Button()
        Me.gbCReservas = New System.Windows.Forms.GroupBox()
        Me.rbTransf = New System.Windows.Forms.RadioButton()
        Me.rbTratadas = New System.Windows.Forms.RadioButton()
        Me.rbPendentes = New System.Windows.Forms.RadioButton()
        Me.rbTodas = New System.Windows.Forms.RadioButton()
        Me.btListaTrasf = New System.Windows.Forms.Button()
        Me.btAtualiza = New System.Windows.Forms.Button()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.btCliente = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ArmazensBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReservasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ReservasTableAdapter()
        Me.ArmazensTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ArmazensTableAdapter()
        Me.ArmazensBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservasDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CFGDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCReservas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArmazensBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox
        '
        Me.PictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox.Location = New System.Drawing.Point(1051, 10)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(336, 221)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox.TabIndex = 23
        Me.PictureBox.TabStop = False
        '
        'ReservasDataGridView
        '
        Me.ReservasDataGridView.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ReservasDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ReservasDataGridView.AutoGenerateColumns = False
        Me.ReservasDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReservasDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ReservasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReservasDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ArmazemID, Me.ArmzDest, Me.ReservaModeloId, Me.ReservaCorId, Me.ReservaTamId, Me.ReservaSerieID, Me.ReservaDescr, Me.Despesas, Me.Sinal, Me.ReservaEstado, Me.ReservaData, Me.ReservaClienteLojaID, Me.ReservaNome, Me.ReservaID})
        Me.ReservasDataGridView.DataSource = Me.ReservasBindingSource
        Me.ReservasDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ReservasDataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ReservasDataGridView.Location = New System.Drawing.Point(0, 402)
        Me.ReservasDataGridView.Name = "ReservasDataGridView"
        Me.ReservasDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.ReservasDataGridView.RowHeadersWidth = 35
        Me.ReservasDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservasDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.ReservasDataGridView.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservasDataGridView.RowTemplate.Height = 500
        Me.ReservasDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReservasDataGridView.Size = New System.Drawing.Size(1397, 291)
        Me.ReservasDataGridView.TabIndex = 7
        '
        'ArmazemID
        '
        Me.ArmazemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ArmazemID.DataPropertyName = "ArmazemID"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArmazemID.DefaultCellStyle = DataGridViewCellStyle3
        Me.ArmazemID.FillWeight = 93.9561!
        Me.ArmazemID.HeaderText = "Arm"
        Me.ArmazemID.Name = "ArmazemID"
        Me.ArmazemID.ReadOnly = True
        Me.ArmazemID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ArmazemID.Width = 68
        '
        'ArmzDest
        '
        Me.ArmzDest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ArmzDest.DataPropertyName = "ArmzDest"
        Me.ArmzDest.HeaderText = "Destino"
        Me.ArmzDest.Name = "ArmzDest"
        Me.ArmzDest.Visible = False
        '
        'ReservaModeloId
        '
        Me.ReservaModeloId.DataPropertyName = "ReservaModeloId"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaModeloId.DefaultCellStyle = DataGridViewCellStyle4
        Me.ReservaModeloId.FillWeight = 116.7516!
        Me.ReservaModeloId.HeaderText = "Modelo"
        Me.ReservaModeloId.Name = "ReservaModeloId"
        Me.ReservaModeloId.ReadOnly = True
        Me.ReservaModeloId.Width = 50
        '
        'ReservaCorId
        '
        Me.ReservaCorId.DataPropertyName = "ReservaCorId"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaCorId.DefaultCellStyle = DataGridViewCellStyle5
        Me.ReservaCorId.FillWeight = 78.52423!
        Me.ReservaCorId.HeaderText = "Cor"
        Me.ReservaCorId.Name = "ReservaCorId"
        Me.ReservaCorId.ReadOnly = True
        Me.ReservaCorId.Width = 35
        '
        'ReservaTamId
        '
        Me.ReservaTamId.DataPropertyName = "ReservaTamId"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaTamId.DefaultCellStyle = DataGridViewCellStyle6
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ReservaDescr.DefaultCellStyle = DataGridViewCellStyle7
        Me.ReservaDescr.FillWeight = 177.9643!
        Me.ReservaDescr.HeaderText = "Observações"
        Me.ReservaDescr.MaxInputLength = 80
        Me.ReservaDescr.Name = "ReservaDescr"
        Me.ReservaDescr.Width = 245
        '
        'Despesas
        '
        Me.Despesas.DataPropertyName = "Despesas"
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Despesas.DefaultCellStyle = DataGridViewCellStyle8
        Me.Despesas.HeaderText = "€"
        Me.Despesas.Name = "Despesas"
        Me.Despesas.Visible = False
        Me.Despesas.Width = 40
        '
        'Sinal
        '
        Me.Sinal.DataPropertyName = "Sinal"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "C2"
        Me.Sinal.DefaultCellStyle = DataGridViewCellStyle9
        Me.Sinal.HeaderText = "€€"
        Me.Sinal.Name = "Sinal"
        Me.Sinal.ReadOnly = True
        Me.Sinal.Width = 40
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
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "d"
        DataGridViewCellStyle10.NullValue = "=Now()"
        Me.ReservaData.DefaultCellStyle = DataGridViewCellStyle10
        Me.ReservaData.HeaderText = "Data"
        Me.ReservaData.Name = "ReservaData"
        Me.ReservaData.ReadOnly = True
        Me.ReservaData.Width = 80
        '
        'ReservaClienteLojaID
        '
        Me.ReservaClienteLojaID.DataPropertyName = "ReservaClienteLojaID"
        Me.ReservaClienteLojaID.HeaderText = "ReservaClienteLojaID"
        Me.ReservaClienteLojaID.Name = "ReservaClienteLojaID"
        Me.ReservaClienteLojaID.Visible = False
        '
        'ReservaNome
        '
        Me.ReservaNome.DataPropertyName = "ReservaNome"
        Me.ReservaNome.HeaderText = "ReservaNome"
        Me.ReservaNome.Name = "ReservaNome"
        '
        'ReservaID
        '
        Me.ReservaID.DataPropertyName = "ReservaID"
        Me.ReservaID.HeaderText = "ReservaID"
        Me.ReservaID.Name = "ReservaID"
        Me.ReservaID.ReadOnly = True
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
        'tbReserva
        '
        Me.tbReserva.AcceptsTab = True
        Me.tbReserva.Location = New System.Drawing.Point(13, 87)
        Me.tbReserva.MaxLength = 80
        Me.tbReserva.Multiline = True
        Me.tbReserva.Name = "tbReserva"
        Me.tbReserva.Size = New System.Drawing.Size(520, 30)
        Me.tbReserva.TabIndex = 4
        '
        'btGravaReserva
        '
        Me.btGravaReserva.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGravaReserva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGravaReserva.Location = New System.Drawing.Point(368, 6)
        Me.btGravaReserva.Name = "btGravaReserva"
        Me.btGravaReserva.Size = New System.Drawing.Size(77, 35)
        Me.btGravaReserva.TabIndex = 5
        Me.btGravaReserva.Text = "Criar"
        Me.btGravaReserva.UseVisualStyleBackColor = False
        '
        'txtRTam
        '
        Me.txtRTam.Location = New System.Drawing.Point(491, 51)
        Me.txtRTam.Name = "txtRTam"
        Me.txtRTam.Size = New System.Drawing.Size(42, 26)
        Me.txtRTam.TabIndex = 3
        '
        'txtRCor
        '
        Me.txtRCor.Location = New System.Drawing.Point(388, 51)
        Me.txtRCor.Name = "txtRCor"
        Me.txtRCor.Size = New System.Drawing.Size(44, 26)
        Me.txtRCor.TabIndex = 2
        '
        'txtRModelo
        '
        Me.txtRModelo.Location = New System.Drawing.Point(264, 51)
        Me.txtRModelo.Name = "txtRModelo"
        Me.txtRModelo.Size = New System.Drawing.Size(72, 26)
        Me.txtRModelo.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(441, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 19)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Tam"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(348, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 19)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Cor"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(219, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 19)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Mod"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbArmazemReserva
        '
        Me.cbArmazemReserva.FormattingEnabled = True
        Me.cbArmazemReserva.Location = New System.Drawing.Point(13, 48)
        Me.cbArmazemReserva.Name = "cbArmazemReserva"
        Me.cbArmazemReserva.Size = New System.Drawing.Size(198, 26)
        Me.cbArmazemReserva.TabIndex = 0
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100
        '
        'CFGDet
        '
        Me.CFGDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CFGDet.ColumnInfo = "10,1,0,0,0,85,Columns:0{Width:18;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.CFGDet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CFGDet.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.CFGDet.Location = New System.Drawing.Point(5, 10)
        Me.CFGDet.Name = "CFGDet"
        Me.CFGDet.Rows.DefaultSize = 17
        Me.CFGDet.Size = New System.Drawing.Size(810, 357)
        Me.CFGDet.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("CFGDet.Styles"))
        Me.CFGDet.TabIndex = 2
        '
        'CmdFechar
        '
        Me.CmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CmdFechar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFechar.Location = New System.Drawing.Point(943, 194)
        Me.CmdFechar.Name = "CmdFechar"
        Me.CmdFechar.Size = New System.Drawing.Size(106, 37)
        Me.CmdFechar.TabIndex = 37
        Me.CmdFechar.Text = "Fechar"
        Me.CmdFechar.UseVisualStyleBackColor = False
        '
        'gbCReservas
        '
        Me.gbCReservas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCReservas.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gbCReservas.Controls.Add(Me.rbTransf)
        Me.gbCReservas.Controls.Add(Me.rbTratadas)
        Me.gbCReservas.Controls.Add(Me.rbPendentes)
        Me.gbCReservas.Controls.Add(Me.rbTodas)
        Me.gbCReservas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.gbCReservas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCReservas.Location = New System.Drawing.Point(829, 10)
        Me.gbCReservas.Name = "gbCReservas"
        Me.gbCReservas.Size = New System.Drawing.Size(218, 176)
        Me.gbCReservas.TabIndex = 42
        Me.gbCReservas.TabStop = False
        Me.gbCReservas.Text = "Carregar Reservas"
        '
        'rbTransf
        '
        Me.rbTransf.AutoSize = True
        Me.rbTransf.Location = New System.Drawing.Point(35, 30)
        Me.rbTransf.Name = "rbTransf"
        Me.rbTransf.Size = New System.Drawing.Size(145, 23)
        Me.rbTransf.TabIndex = 3
        Me.rbTransf.TabStop = True
        Me.rbTransf.Text = "Transferências"
        Me.rbTransf.UseVisualStyleBackColor = True
        '
        'rbTratadas
        '
        Me.rbTratadas.AutoSize = True
        Me.rbTratadas.Location = New System.Drawing.Point(35, 96)
        Me.rbTratadas.Name = "rbTratadas"
        Me.rbTratadas.Size = New System.Drawing.Size(98, 23)
        Me.rbTratadas.TabIndex = 2
        Me.rbTratadas.TabStop = True
        Me.rbTratadas.Text = "Tratadas"
        Me.rbTratadas.UseVisualStyleBackColor = True
        '
        'rbPendentes
        '
        Me.rbPendentes.AutoSize = True
        Me.rbPendentes.Location = New System.Drawing.Point(35, 63)
        Me.rbPendentes.Name = "rbPendentes"
        Me.rbPendentes.Size = New System.Drawing.Size(113, 23)
        Me.rbPendentes.TabIndex = 1
        Me.rbPendentes.TabStop = True
        Me.rbPendentes.Text = "Pendentes"
        Me.rbPendentes.UseVisualStyleBackColor = True
        '
        'rbTodas
        '
        Me.rbTodas.AutoSize = True
        Me.rbTodas.Location = New System.Drawing.Point(35, 129)
        Me.rbTodas.Name = "rbTodas"
        Me.rbTodas.Size = New System.Drawing.Size(77, 23)
        Me.rbTodas.TabIndex = 0
        Me.rbTodas.TabStop = True
        Me.rbTodas.Text = "Todas"
        Me.rbTodas.UseVisualStyleBackColor = True
        '
        'btListaTrasf
        '
        Me.btListaTrasf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btListaTrasf.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btListaTrasf.Location = New System.Drawing.Point(821, 194)
        Me.btListaTrasf.Name = "btListaTrasf"
        Me.btListaTrasf.Size = New System.Drawing.Size(122, 37)
        Me.btListaTrasf.TabIndex = 40
        Me.btListaTrasf.Text = "Listar Trasf."
        Me.btListaTrasf.UseVisualStyleBackColor = False
        '
        'btAtualiza
        '
        Me.btAtualiza.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btAtualiza.Location = New System.Drawing.Point(461, 6)
        Me.btAtualiza.Name = "btAtualiza"
        Me.btAtualiza.Size = New System.Drawing.Size(78, 35)
        Me.btAtualiza.TabIndex = 44
        Me.btAtualiza.Text = "Act."
        Me.btAtualiza.UseVisualStyleBackColor = False
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Location = New System.Drawing.Point(99, 13)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(59, 19)
        Me.lbCliente.TabIndex = 46
        Me.lbCliente.Text = "Cliente"
        '
        'btCliente
        '
        Me.btCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCliente.Location = New System.Drawing.Point(15, 9)
        Me.btCliente.Name = "btCliente"
        Me.btCliente.Size = New System.Drawing.Size(76, 29)
        Me.btCliente.TabIndex = 45
        Me.btCliente.Text = "Cliente"
        Me.btCliente.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btAtualiza)
        Me.Panel1.Controls.Add(Me.btGravaReserva)
        Me.Panel1.Controls.Add(Me.btCliente)
        Me.Panel1.Controls.Add(Me.txtRModelo)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtRCor)
        Me.Panel1.Controls.Add(Me.cbArmazemReserva)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.tbReserva)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtRTam)
        Me.Panel1.Controls.Add(Me.lbCliente)
        Me.Panel1.Location = New System.Drawing.Point(823, 274)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 122)
        Me.Panel1.TabIndex = 47
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
        'frmGestaoReservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1397, 693)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbCReservas)
        Me.Controls.Add(Me.CFGDet)
        Me.Controls.Add(Me.CmdFechar)
        Me.Controls.Add(Me.ReservasDataGridView)
        Me.Controls.Add(Me.btListaTrasf)
        Me.Controls.Add(Me.PictureBox)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmGestaoReservas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmGestao"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservasDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CFGDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCReservas.ResumeLayout(False)
        Me.gbCReservas.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArmazensBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



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
    Dim iDespesa As Double = 0
    Dim sIdReservas As String
    Dim sApagarReservasAux As String = ""
    Dim nLinhas As Integer = 1000000
    Dim xModeloReservaAux As String
    Dim xCorReservaAux As String

    Dim sClienteLojaIdAux As String
    Dim sNIF As String


    'Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
    '    If Not Me.IsHandleCreated Then
    '        Me.CreateHandle()
    '        value = False
    '    End If
    '    MyBase.SetVisibleCore(value)
    'End Sub



    Private Sub frmGestaoReservas_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try

            Me.Cursor = Cursors.WaitCursor

            ReservasDataGridView.MultiSelect = False
            ReservasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect




            CFGDet.Visible = False
            bArranque = True
            PictureBox.Visible = False

            rbPendentes.Checked = True
            Me.ArmzDest.Visible = False
            xFiltraDataGrid = ""

            'Me.ReservasDataGridView.ScrollBars.Vertical.

            'CARREGAR ARMAZEM

            Sql = "SELECT ArmazemID, rtrim(ArmazemID) + ' - ' + rtrim(ArmAbrev) as Destino from Armazens"
            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtArmazensReserva)
            Me.cbArmazemReserva.DataSource = dtArmazensReserva
            Me.cbArmazemReserva.DisplayMember = "Destino"
            Me.cbArmazemReserva.ValueMember = "ArmazemID"
            Me.cbArmazemReserva.SelectedValue = "%"


            Application.DoEvents()

            If Me.GirlDataSet.Reservas.Rows.Count > 0 Then
                Me.ReservasDataGridView.RowHeadersWidth = Me.ReservasDataGridView.ColumnHeadersHeight + 5
                Me.ActiveControl = Me.ReservasDataGridView
                If Me.ReservasDataGridView.RowCount > 2 Then
                    ReservasDataGridView.CurrentCell = ReservasDataGridView.Rows(ReservasDataGridView.Rows.Count - 2).Cells(ReservasDataGridView.CurrentCell.ColumnIndex)
                End If
            End If


            ActualizaEstadosReservas()

            'ReservasDataGridView.FirstDisplayedScrollingColumnIndex = 5
            'CFGDet.Cols.Frozen = 4


            Me.ReservasDataGridView.CurrentCell = Me.ReservasDataGridView(0, 0)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmTransf_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmTransf_Load")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            If Not Cmd Is Nothing Then Cmd.Dispose()
            Cmd = Nothing
            PictureBox.Visible = False
            Application.DoEvents()
            Me.Cursor = Cursors.Default



        End Try

    End Sub

    Private Sub rbPendentes_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbPendentes.CheckedChanged

        Me.Cursor = Cursors.WaitCursor

        PictureBox.Visible = False

        If rbPendentes.Checked = True Then
            Me.ArmzDest.Visible = False
            CarregarReservas()
        End If



    End Sub

    Private Sub rbTodas_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbTodas.CheckedChanged


        Me.Cursor = Cursors.WaitCursor

        PictureBox.Visible = False

        If rbTodas.Checked = True Then
            Me.ArmzDest.Visible = True
            CarregarReservas()
        End If



    End Sub

    Private Sub rbTratadas_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbTratadas.CheckedChanged

        Me.Cursor = Cursors.WaitCursor

        PictureBox.Visible = False

        If rbTratadas.Checked = True Then
            Me.ArmzDest.Visible = True
            CarregarReservas()
        End If



    End Sub

    Private Sub rbTransf_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbTransf.CheckedChanged

        Me.Cursor = Cursors.WaitCursor

        PictureBox.Visible = False

        If rbTransf.Checked = True Then
            Me.ArmzDest.Visible = True
            CarregarReservas()
        End If



    End Sub

    Private Sub btListaTrasf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListaTrasf.Click

        Dim db As New ClsSqlBDados

        Dim I As Integer
        Dim xDestino As String = ""
        Dim xModelo As String = ""
        Dim xCor As String = ""
        Dim xTam As String = ""
        Dim xTalao As String = ""
        Dim xDescr As String = ""
        Dim dt As New DataTable
        Dim xReservaID As String = ""

        'TODO: REPENSAR ESTE QUERY PARA FAZER A LISTAGEM........



        PictureBox.Visible = False

        Try

            Me.GirlDataSet.ApoioTrasf.Clear()


            If Len(xFiltraDataGrid) = 0 Then
                Me.ReservasBindingSource.Filter = "ArmzDest<>'" & xArmz & "' AND ArmazemID='" & xArmz & "' AND ReservaEstado=0"
            Else
                Me.ReservasBindingSource.Filter = "ArmzDest<>'" & xArmz & "' AND ArmazemID='" & xArmz & "' AND ReservaEstado=0 AND " & xFiltraDataGrid
            End If
            Me.ReservasBindingSource.Sort = "ArmzDest ASC, ReservaModeloId ASC,ReservaCorId ASC,ReservaTamId ASC"


            If ReservasDataGridView.Rows.Count > 0 Then

                For I = 0 To Me.ReservasDataGridView.Rows.Count - 1
                    If Me.ReservasDataGridView("ArmazemID", I).Value.ToString = xArmz Then
                        xDestino = Me.ReservasDataGridView("ArmzDest", I).Value.ToString
                        xModelo = Me.ReservasDataGridView("ReservaModeloID", I).Value.ToString
                        xCor = Me.ReservasDataGridView("ReservaCorID", I).Value.ToString
                        Do While Me.ReservasDataGridView("ArmzDest", I).Value.ToString = xDestino _
                                And Me.ReservasDataGridView("ReservaModeloID", I).Value.ToString = xModelo _
                                And Me.ReservasDataGridView("ReservaCorID", I).Value.ToString = xCor
                            xTam = Me.ReservasDataGridView("ReservaTamID", I).Value.ToString
                            xTalao = Me.ReservasDataGridView("ReservaSerieID", I).Value.ToString
                            xDescr = xDescr + xTam + " - " + xTalao + "  "
                            xReservaID = "'" & Me.ReservasDataGridView("ReservaID", I).Value.ToString & "'," + xReservaID
                            I = I + 1
                            If I >= Me.ReservasDataGridView.Rows.Count Then Exit Do
                        Loop
                        I = I - 1
                        Me.GirlDataSet.ApoioTrasf.AddApoioTrasfRow(xDestino, xModelo, xCor, xDescr)
                        xDescr = ""
                    End If
                Next
                xReservaID = Microsoft.VisualBasic.Left(xReservaID, Len(xReservaID) - 1)

                dtAuxReport = Me.GirlDataSet.ApoioTrasf

                ''PARA IMPRIMIR DIRECTO PARA A IMPRESSORA...
                'Dim cryRpt As New CRTransferencias
                'cryRpt.SetDataSource(dtAuxReport)
                'cryRpt.SetParameterValue("Origem", xArmz)
                'cryRpt.PrintToPrinter(1, False, 0, 0)

                NListagem = "TRASFERENCIAS"
                Pausa = True
                frmCRReports.Show(Me)
                'Application.DoEvents()

                'frmRptTransf.ShowDialog(Me)


                Do While Pausa = True
                    Application.DoEvents()
                Loop



                If xArmz = "0000" Then
                    If MsgBox("QUER FECHAR OS REGISTOS LISTADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'O SEGUINTE UPDATE QUE ESTÁ COMENTADO 
                        'DEPOIS DE LISTAR -- LIMPA OS ARTIGOS '8*'  ----  O UPDATE ATIVO NÃO LIMPA
                        'Sql = "UPDATE RESERVAS SET ReservaEstado=1, OperadorID='" & xUtilizador & "' WHERE ArmazemID='" & xArmz & "' AND ArmzDest<>ArmazemID AND ReservaEstado=0 AND ReservaID in (" & xReservaID & ") AND ReservaModeloID not like '8%'"

                        Sql = "UPDATE RESERVAS SET ReservaEstado=1, OperadorID='" & xUtilizador & "' WHERE ArmazemID='" & xArmz & "' AND ArmzDest<>ArmazemID AND ReservaEstado=0 AND ReservaID in (" & xReservaID & ") AND ReservaModeloID not like '8%'"
                        db.ExecuteData(Sql)
                        CarregarReservas()
                    End If
                End If

            Else
                MsgBox("NÃO TEM TRANSFERÊNCIAS PENDENTES!!")
            End If
            xReservaID = ""
            ReservasBindingSource.Filter = ""




        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btListaTrasf_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btListaTrasf_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing


            PictureBox.Visible = True


        End Try





    End Sub

    Private Sub btAtualiza_Click_1(sender As System.Object, e As System.EventArgs) Handles btAtualiza.Click

        Try

            rbPendentes.Checked = True
            ActualizaEstadosReservas()
            MsgBox("Actualização Concluida!")


        Catch ex As Exception
            ErroVB(ex.Message, "btAtualiza_Click")
        End Try



    End Sub

    Private Sub CmdFechar_Click(sender As System.Object, e As System.EventArgs) Handles CmdFechar.Click
        xFiltraDataGrid = ""
        Close()
    End Sub

    Private Sub cbArmazemReserva_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbArmazemReserva.SelectedValueChanged
        Try

            txtRModelo.Focus()

        Catch ex As Exception
            ErroVB(ex.Message, "cbArmazemReserva_SelectedValueChanged")
        End Try

    End Sub

    Private Sub txtRModelo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRModelo.KeyPress


        Try


            If e.KeyChar = ChrW(Keys.Enter) Then
                'TODO: VALIDAR O CAMPO
                e.Handled = True
                txtRCor.Focus()
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "txtRModelo_KeyPress")
        End Try


    End Sub

    Private Sub txtRCor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRCor.KeyPress


        Try


            If e.KeyChar = ChrW(Keys.Enter) Then
                'TODO: VALIDAR O CAMPO
                e.Handled = True
                txtRTam.Focus()
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "txtRCor_KeyPress")
        End Try


    End Sub

    Private Sub txtRTam_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRTam.KeyPress

        Try


            If e.KeyChar = ChrW(Keys.Enter) Then
                'TODO: VALIDAR O CAMPO
                e.Handled = True
                tbReserva.Focus()
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "txtRTam_KeyPress")
        End Try

    End Sub

    Private Sub tbReserva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbReserva.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'TODO: VALIDAR O CAMPO
            e.Handled = True
            btGravaReserva.Focus()
        End If
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

            Me.Cursor = Cursors.WaitCursor

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
                            GravarOrdemTransferencia("Stock")
                            xValor = 0
                            xTalao = ""
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
            Me.Cursor = Cursors.Default


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
        Finally
            rbPendentes.Checked = True
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

                    If xSerie = "T" Then
                        If ReservasDataGridView("ReservaDescr", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaDescr", e.RowIndex).Value = ""
                        Dim sDescr As String = ReservasDataGridView("ReservaDescr", e.RowIndex).Value.ToString
                        Dim sDescrFiltro As String = InStr(sDescr, "DEVOLVER")
                        If sDescrFiltro = 1 Then
                            If ReservasDataGridView("ArmazemID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ArmazemID", e.RowIndex).Value = ""
                            Dim sArm As String = ReservasDataGridView("ArmazemID", e.RowIndex).Value.ToString
                            'Dim sSerie As String = sDescr.Substring(sDescr.IndexOf("/") - 4, 2)
                            'Dim sContador As String = sDescr.Substring(sDescr.IndexOf("/") + 1, 5)
                            Dim sDocNr As String = sDescr.Substring(sDescr.IndexOf("/") - 4, 2) & sDescr.Substring(sDescr.IndexOf("/") + 1, 5)
                            'fazer update ao campo docCab.obs1 com : DEVOLUÇÃO AUTORIZADA.
                            Sql = "UPDATE DocCab SET Obs1 = N'DEVOLUÇÃO AUTORIZADA' WHERE (EmpresaID = '" & xEmp & "') AND (ArmazemID = '" & sArm & "') AND (TipoDocID = 'FS') AND (DocNr = N'" & sDocNr & "')"
                            db.ExecuteData(Sql)
                        End If
                    End If


                    'Sql = "SELECT COUNT(*) RESERVADO FROM RESERVAS WHERE RESERVASERIEID='" & xSerie & "' AND RESERVAESTADO='0' AND RESERVAID<>'" & ReservasDataGridView("ReservaID", e.RowIndex).Value & "'"
                    Sql = "SELECT COUNT(*) AS RESERVADO FROM Reservas WHERE (ReservaSerieID = '" & xSerie & "' AND LEN(ReservaSerieID) = 8) AND (ReservaEstado = '0') AND (ReservaID <> '" & ReservasDataGridView("ReservaID", e.RowIndex).Value & "')"


                    If db.GetDataValue(Sql) > 0 Then
                        MsgBox("O TALÃO Nº: " & xSerie & " ESTÁ RESERVADO", MsgBoxStyle.Exclamation, "RESERVAS")
                        ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = ""
                    End If
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

                    Sql = "SELECT * FROM Serie WHERE SerieId='" & xSerie & "' AND ESTADOID<>'R'"
                    db.GetData(Sql, dt)

                    If Not dt Is Nothing And dt.Rows.Count > 0 Then
                        For Each r As DataRow In dt.Rows
                            'como os valores introduzidos não estão limitados à lista pode dar problemas na comparação... 
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
                            MsgBox("O TALÃO " & xSerie & " NÃO EXISTE OU ESTÁ VENDIDO")
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
            'If ReservasDataGridView("Sinal", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("Sinal", e.RowIndex).Value = 0


            Dim xReservaID As String = ReservasDataGridView("ReservaID", e.RowIndex).Value
            Dim xReservaSerieID As String = ReservasDataGridView("ReservaSerieID", e.RowIndex).Value
            Dim xReservaDescr As String = ReservasDataGridView("ReservaDescr", e.RowIndex).Value
            Dim xReservaEstado As String = ReservasDataGridView("ReservaEstado", e.RowIndex).Value
            Dim Despesas As String = ReservasDataGridView("Despesas", e.RowIndex).Value
            'Dim Sinal As String = ReservasDataGridView("Sinal", e.RowIndex).Value





            If Len(Trim(xReservaSerieID)) > 0 Then
                Sql = "UPDATE Reservas SET ReservaSerieID = '" & xReservaSerieID & "', OperadorID = '" & xUtilizador & "', DtRegisto = GETDATE() WHERE ReservaID='" & xReservaID & "'"
                db.ExecuteData(Sql)
            End If
            'Sql = "UPDATE Reservas SET ReservaDescr = '" & xReservaDescr & "' , Despesas = '" & Despesas & "', Sinal = '" & Sinal & "' , ReservaEstado = '" & xReservaEstado & "', OperadorID = '" & xUtilizador & "', DtRegisto = GETDATE() WHERE ReservaID='" & xReservaID & "'"
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
        Dim iLojaOrigem As Int16

        If e.ColumnIndex < 0 Then
            Exit Sub
        End If

        If SistemaBloqueado() = True Then
            Exit Sub
        End If


        Dim dg As New clsDataGrid(Me.ReservasDataGridView, , Me.ReservasBindingSource)

        Try


            If e.Button = Windows.Forms.MouseButtons.Right Then

                dg.MostraFiltroForm(e)

            Else

                If e.ColumnIndex = 5 Then
                    If Len(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value) = 8 Then
                        'ReservasDataGridView("ReservaSerieID", e.RowIndex).ToolTipText = SituacaoTalao(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value)
                        MsgBox(SituacaoTalao(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value), , "Situação da Reserva")
                    End If
                End If

                If ReservasDataGridView.Columns(e.ColumnIndex).Name = "ReservaSerieID" Then

                    If Len(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value) = 8 Then
                        MsgBox(SituacaoTalao(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value), , "Situação da Reserva")
                    End If

                End If

                If ReservasDataGridView.Columns(e.ColumnIndex).Name = "ReservaNome" Then
                    If Len(Trim(ReservasDataGridView("ReservaNome", e.RowIndex).Value.ToString)) > 0 Then
                        Sql = "SELECT CAST(ClientesLoja.IDClienteLoja AS char(36)) FROM Reservas INNER JOIN ClientesLoja ON Reservas.ReservaClienteLojaID = ClientesLoja.ClienteLojaID WHERE (Reservas.ReservaID = " & ReservasDataGridView("ReservaID", e.RowIndex).Value & ")"
                        sIDClienteLoja = db.GetDataValue(Sql)
                        frmClientesLojaLista.WindowState = FormWindowState.Normal
                        frmClientesLojaLista.StartPosition = FormStartPosition.CenterScreen
                        frmClientesLojaLista.ShowDialog(Me)
                    End If
                End If

                If ReservasDataGridView.CurrentCell.OwningColumn.HeaderText = "Talão" Then

                    Dim xModeloReserva As String = ""
                    Dim xCorReserva As String = ""
                    Dim xSerie As String = ""
                    Dim xTamReserva As String = ""


                    If Not IsDBNull(ReservasDataGridView("ReservaModeloId", e.RowIndex).Value) Then
                        xModeloReserva = ReservasDataGridView("ReservaModeloId", e.RowIndex).Value
                        If Not IsDBNull(ReservasDataGridView("ReservaCorId", e.RowIndex).Value) Then
                            xCorReserva = ReservasDataGridView("ReservaCorId", e.RowIndex).Value
                        End If
                    End If


                    xModeloReservaAux = xModeloReserva
                    xCorReservaAux = xCorReserva



                    ' VERIFICAR TALÃO

                    If xValor > 0 Then
                        If Len(ReservasDataGridView("ReservaSerieID", e.RowIndex).ToString) <> 8 Then
                            If Not IsDBNull(ReservasDataGridView("ReservaTamId", e.RowIndex).Value) Then
                                xTamReserva = ReservasDataGridView("ReservaTamId", e.RowIndex).Value
                            End If

                            Sql = "SELECT MODELOID + CORID + TAMID ARTIGO FROM SERIE WHERE SERIEID = '" & xTalao & "'"

                            If xModeloReserva & xCorReserva & xTamReserva = db.GetDataValue(Sql) Then
                                ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = xTalao
                                ReservasDataGridView.CurrentCell = ReservasDataGridView.Rows(ReservasDataGridView.CurrentCell.RowIndex).Cells(ReservasDataGridView.CurrentCell.ColumnIndex + 1)

                                xDestino = ReservasDataGridView("ArmazemID", e.RowIndex).Value
                                GravarOrdemTransferencia("Reserva")
                                iLojaOrigem = xOrigem
                                ReservasDataGridView("ReservaDescr", e.RowIndex).Value = ReservasDataGridView("ReservaDescr", e.RowIndex).Value & " «C-" & iLojaOrigem.ToString & "»"
                                ReservasDataGridView("Despesas", e.RowIndex).Value = iDespesa
                                'ReservasDataGridView("Sinal", e.RowIndex).Value = iDespesa
                                iDespesa = 0


                            Else
                                MsgBox("ERRO! Talão do Artigo :" & xModelo & "-" & xCor & "-" & xTamTransf)
                            End If
                        Else
                            MsgBox("Já tem Talão atribuido!!")
                        End If
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
            Application.DoEvents()
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


                Sql = "SELECT ISNULL(MIN(SerieID),0) FROM Serie LEFT JOIN Reservas ON Serie.SerieID = Reservas.ReservaSerieID " &
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

    'Private Sub ReservasDataGridView_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ReservasDataGridView.RowHeaderMouseClick
    '    Dim db As New ClsSqlBDados

    '    Try



    '        If Not IsDBNull(ReservasDataGridView("ReservaModeloId", e.RowIndex).Value) Then
    '            xModelo = ReservasDataGridView("ReservaModeloId", e.RowIndex).Value
    '            If xModelo = "" Then
    '                CFGDet.Visible = False
    '                Exit Sub
    '            End If
    '            If Not IsDBNull(ReservasDataGridView("ReservaCorId", e.RowIndex).Value) Then
    '                xCor = ReservasDataGridView("ReservaCorId", e.RowIndex).Value
    '                If xCor = "" Then
    '                    CFGDet.Visible = False
    '                    Exit Sub
    '                End If
    '                ActualizaDetalhe()
    '                CFGDet.Visible = True
    '                PictureBox.Visible = True
    '            Else
    '                CFGDet.Visible = False
    '            End If
    '        Else
    '            CFGDet.Visible = False
    '        End If



    '    Catch ex As Exception
    '        ErroVB(ex.Message, "ReservasDataGridView_RowHeaderMouseClick")
    '    Finally
    '        If Not db Is Nothing Then db.Dispose()
    '        db = Nothing
    '    End Try


    'End Sub

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
                    If ReservasDataGridView("Sinal", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("Sinal", e.RowIndex).Value = ""




                    Dim xReservaID As Integer = ReservasDataGridView("ReservaID", e.RowIndex).Value
                    Dim xReservaDescrID As String = ReservasDataGridView("ReservaDescr", e.RowIndex).Value
                    Dim xArmazemID As Integer = ReservasDataGridView("ArmazemID", e.RowIndex).Value.ToString
                    Dim xSerie As String = ReservasDataGridView("ReservaSerieID", e.RowIndex).Value
                    Dim Despesas As String = ReservasDataGridView("Despesas", e.RowIndex).Value
                    Dim Sinal As String = ReservasDataGridView("Sinal", e.RowIndex).Value


                    Sql = "SELECT ISNULL(OBS,'') FROM SERIE WHERE SERIEID='" & xSerie & "'"
                    Dim xObsTalao As String = ""
                    xObsTalao = Trim(db.GetDataValue(Sql))

                    Dim xObsReservaTalao As String = ""
                    'xObsReservaTalao = "MED:C' + '" & xArmazemID & "' + '/R' + '" & xReservaID & "'+ '"
                    xObsReservaTalao = "MED:C" & xArmazemID & "/R" & xReservaID


                    'Dim i As Int16
                    'For i = 1 To 15 - Len(xObsReservaTalao)
                    '    xObsReservaTalao = xObsReservaTalao + " "
                    'Next


                    If Len(xSerie) > 0 Then
                        'If Len(xObsTalao) = 0 Then
                        '    Sql = "UPDATE SERIE SET OBS='" & xObsReservaTalao & "' WHERE SerieId='" & xSerie & "'"
                        '    db.ExecuteData(Sql)
                        'ElseIf Microsoft.VisualBasic.Left(xObsTalao, 3) = "MED" And Len(xObsTalao) <= 15 Then
                        '    Sql = "UPDATE SERIE SET OBS='" & xObsReservaTalao & "' WHERE SerieId='" & xSerie & "'"
                        '    db.ExecuteData(Sql)
                        'ElseIf Microsoft.VisualBasic.Left(xObsTalao, 3) <> "MED" Then
                        '    'Sql = "UPDATE SERIE SET OBS='" & xObsReservaTalao & "' + OBS WHERE SerieId='" & xSerie & "'"
                        '    Sql = "UPDATE SERIE SET OBS='" & xObsReservaTalao & "' WHERE SerieId='" & xSerie & "'"
                        '    db.ExecuteData(Sql)
                        'ElseIf Microsoft.VisualBasic.Left(xObsTalao, 3) = "MED" And Len(xObsTalao) > 15 Then
                        '    xObsTalao = Microsoft.VisualBasic.Right(xObsTalao, Len(xObsTalao) - 15)

                        '    Sql = "SELECT OBS FROM SERIE WHERE SERIEID='" & xSerie & "'"
                        '    If Len(db.GetDataValue(Sql) & xObsReservaTalao) > 65 Then
                        '        'TODO: REVER ESTE PROCEDIMENTO.....
                        '        'MsgBox("LIMPAR AS OBS DO TALÃO Nº: " & xSerie)
                        '        'e.Cancel = True
                        '        Sql = "UPDATE SERIE SET OBS='" & xObsReservaTalao & "' WHERE SerieId='" & xSerie & "'"
                        '        db.ExecuteData(Sql)
                        '    Else
                        '        Sql = "UPDATE SERIE SET OBS='" & xObsReservaTalao & "' + OBS WHERE SerieId='" & xSerie & "'"
                        '        db.ExecuteData(Sql)
                        '    End If

                        'End If

                        If Len(xObsTalao) <> 0 Then
                            If Microsoft.VisualBasic.Left(xObsTalao, 3) <> "MED" Then
                                'GravarEvento(xSerie + " : " + xObsTalao, "", Now, "EMAIL")
                                EnviarEmail("Erro", xSerie + " : " + xObsTalao + " " + Now)
                            End If
                        End If
                        Sql = "UPDATE SERIE SET OBS='" & xObsReservaTalao & "' WHERE SerieId='" & xSerie & "'"
                        db.ExecuteData(Sql)


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
                If ReservasDataGridView("Despesas", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("Despesas", e.RowIndex).Value = 0
                If ReservasDataGridView("Sinal", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("Sinal", e.RowIndex).Value = 0


                Dim xReservaID As Integer = ReservasDataGridView("ReservaID", e.RowIndex).Value
                Dim xArmazemID As String = ReservasDataGridView("ArmazemID", e.RowIndex).Value
                Dim xReservaModeloID As String = ReservasDataGridView("ReservaModeloID", e.RowIndex).Value
                Dim xReservaCorID As String = ReservasDataGridView("ReservaCorID", e.RowIndex).Value
                Dim xReservaTamID As String = ReservasDataGridView("ReservaTamID", e.RowIndex).Value
                Dim xReservaSerieID As String = ReservasDataGridView("ReservaSerieID", e.RowIndex).Value
                Dim xReservaDescrID As String = ReservasDataGridView("ReservaDescr", e.RowIndex).Value
                Dim Despesas As String = ReservasDataGridView("Despesas", e.RowIndex).Value
                Dim Sinal As String = ReservasDataGridView("Sinal", e.RowIndex).Value

                Sql = "UPDATE RESERVAS SET ArmazemID='" & xArmazemID & "', ReservaModeloID='" & xReservaModeloID & "', ReservaCorID='" & xReservaCorID & "',ReservaTamID='" & xReservaTamID & "',ReservaSerieID='" & xReservaSerieID & "',ReservaDescr='" & xReservaDescrID & "', Sinal='" & Sinal & "', Despesas='" & Despesas & "' WHERE ReservaID='" & xReservaID & "'"
                db.ExecuteData(Sql)

            End If

            'CFGDet.Visible = False
            'PictureBox.Visible = False



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


        Try

            If ReservasDataGridView("ArmazemID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ArmazemID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaModeloID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaModeloID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaCorID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaCorID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaTamID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaTamID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaSerieID", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaSerieID", e.RowIndex).Value = ""
            If ReservasDataGridView("ReservaDescr", e.RowIndex).Value Is DBNull.Value Then ReservasDataGridView("ReservaDescr", e.RowIndex).Value = ""

            If ReservasDataGridView("ReservaEstado", e.RowIndex).Value = "1" Then
                ReservasDataGridView.Rows(e.RowIndex).ReadOnly = True
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_RowEnter")
        Finally


        End Try


    End Sub

    Private Sub ReservasDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles ReservasDataGridView.UserDeletingRow
        Dim db As New ClsSqlBDados

        Try

            Me.Cursor = Cursors.WaitCursor
            If nLinhas = 1000000 Then
                nLinhas = ReservasDataGridView.SelectedRows.Count
            End If

            sApagarReservasAux = sApagarReservasAux & ",'" & ReservasDataGridView("ReservaID", e.Row.Index).Value & "'"

            nLinhas = nLinhas - 1

            If nLinhas = 0 Then

                sApagarReservasAux = sApagarReservasAux.Substring(sApagarReservasAux.IndexOf(",") + 1)
                Sql = "DELETE FROM Reservas WHERE ReservaID in (" & sApagarReservasAux & ") AND ReservaEstado = 1"
                db.ExecuteData(Sql)
                nLinhas = 1000000

            End If

            'sApagarReservasAux = sApagarReservasAux & "," & ReservasDataGridView("ReservaID", e.Row.Index).Value


            'If MsgBox("Confirma que quer apagar?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '    e.Cancel = True
            'Else
            '    Sql = "DELETE RESERVAS WHERE RESERVAID='" & ReservasDataGridView("ReservaID", e.Row.Index).Value & "'"
            '    db.ExecuteData(Sql)
            'End If
            ''Me.GirlDataSet.Reservas.AcceptChanges()




        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ReservasDataGridView_UserDeletingRow")
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_UserDeletingRow")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ReservasDataGridView_SelectionChanged(sender As Object, e As System.EventArgs) Handles ReservasDataGridView.SelectionChanged

        Dim db As New ClsSqlBDados

        Try

            Me.Cursor = Cursors.WaitCursor
            If nLinhas <> 1000000 Then
                Exit Sub
            End If

            'If Not ReservasDataGridView.Focused Then
            '    Exit Sub
            'End If

            'If Me.GirlDataSet.Reservas.Rows.Count = 0 Then
            '    Exit Sub
            'End If

            If bArranque = True Then
                Exit Sub
            End If

            If Not Me.ReservasDataGridView.CurrentCell Is Nothing Then

                If Not Me.ReservasDataGridView("ReservaModeloID", Me.ReservasDataGridView.CurrentCell.RowIndex).Value Is DBNull.Value Then
                    If Not Me.ReservasDataGridView("ReservaCorId", Me.ReservasDataGridView.CurrentCell.RowIndex).Value Is DBNull.Value Then
                        Dim xModelosAux1 As String = xModelo
                        Dim xCorAux1 As String = xCor

                        xModelo = Me.ReservasDataGridView("ReservaModeloID", Me.ReservasDataGridView.CurrentCell.RowIndex).Value
                        xCor = Me.ReservasDataGridView("ReservaCorId", Me.ReservasDataGridView.CurrentCell.RowIndex).Value

                        If Not xModelo + xCor = xModelosAux1 + xCorAux1 Then
                            ActualizaDetalhe()
                            CFGDet.Visible = True
                            PictureBox.Visible = True
                        Else
                            Exit Sub
                        End If
                    Else
                        CFGDet.Visible = False
                        PictureBox.Visible = False

                    End If
                End If

            End If

        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_SelectionChanged")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
            CmdFechar.Focus()


        End Try
    End Sub

    'FUNÇÕES


    Private Sub ActualizaDetalhe()


        Dim db As New ClsSqlBDados

        CmdFechar.Enabled = False
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox.Visible = False
            Me.CFGDet.Visible = False
            Application.DoEvents()


            Dim dtDet As New DataTable
            Dim dttips As New DataTable
            Dim xtip As String = ""
            Dim xArmzAux As String



            Dim xIncReservas As Integer = 0

            Sql = "EXEC prc_TransfDet @ModeloID = '" & xModelo & "', @CorID = '" & xCor & "', @IncReservas='1'"

            'If cn.State = ConnectionState.Closed Then cn.Open()
            'da = New SqlDataAdapter(Sql, cn)
            'da.Fill(dtDet)

            'Vou correr o procedimento duas vezes porque se correr só uma vez vai  buscar os valores anteriores
            'Não consegui resolver de outra forma.......
            db.ExecuteData(Sql)
            db.GetData(Sql, dtDet, False)



            'Sql = "SELECT ISNULL(DocCab.TercID,Serie.ArmazemID)ArmzVirtual, Serie.TamID, Serie.SerieID AS Talão, Serie.EstadoID +'/'+ Serie.ArmazemID Estado " & _
            '   "FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND  " & _
            '   "DocCab.DocNr = DocDet.DocNr RIGHT OUTER JOIN Serie ON DocDet.SerieID = Serie.SerieID AND DocDet.TipoDocID = 'SE' AND DocDet.EstadoLn = 'G' " & _
            '   "WHERE (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.EstadoID IN ('S', 'T')) " & _
            '   "ORDER BY ArmzVirtual, Serie.TamID"

            Sql = "SELECT ISNULL(DocCab.TercID, Serie.ArmazemID) AS ArmzVirtual, Serie.TamID, Serie.SerieID AS Talão, Serie.EstadoID + '/' + Serie.ArmazemID AS Estado, Serie.Obs1 FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr RIGHT OUTER JOIN Serie ON DocDet.SerieID = Serie.SerieID AND DocDet.TipoDocID = 'SE' AND DocDet.EstadoLn = 'G' WHERE (Serie.ModeloID = '" & xModelo & "') AND (Serie.CorID = '" & xCor & "') AND (Serie.EstadoID IN ('S', 'T')) ORDER BY ArmzVirtual, Serie.TamID"


            dttips.Clear()
            db.GetData(Sql, dttips)



            With Me.CFGDet
                .DataSource = dtDet
                Dim I, J As Integer
                For I = 1 To CFGDet.Rows.Count - 1
                    For J = 3 To CFGDet.Cols.Count - 1
                        If CFGDet(I, J).ToString = "0" Or CFGDet(I, J).ToString = "0.0" Then CFGDet(I, J) = DBNull.Value
                        If dttips.Rows.Count > 0 _
                        And Me.CFGDet.Cols(J).Name <> "Cod" _
                        And Me.CFGDet.Cols(J).Name <> "Armazem" _
                        And Me.CFGDet.Cols(J).Name <> "Vnd" _
                        And CFGDet(I, 1).ToString <> "VndP" Then
                            For Each linha As DataRow In dttips.Rows
                                If linha("ArmzVirtual") = Me.CFGDet(I, 1).ToString And linha("TamID") = Me.CFGDet.Cols(J).Name Then
                                    xtip = linha("Talão") & " - " & linha("Estado") & "  " & linha("Obs1") & Chr(13) & xtip
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


                .Cols("ArmazemID").Caption = "Cod"
                .Cols("ArmAbrev").Caption = "Armazem"

                .AllowEditing = False
                .AutoResize = True
                .AllowDragging = AllowDraggingEnum.None



                .AutoSizeCols()
                Dim LarguraTotalColunas As Double = 0
                Dim AlturaTotalLinhas As Double = 0
                AlturaTotalLinhas = .Rows(0).HeightDisplay * CFGDet.Rows.Count


                For I = 0 To CFGDet.Cols.Count - 1
                    If .Cols(I).Visible = True Then
                        LarguraTotalColunas += .Cols(I).WidthDisplay
                    End If
                Next
                .Width = LarguraTotalColunas * 1.05
                .Height = AlturaTotalLinhas * 1.05
            End With





            CarregarFoto.CarregarFotoModeloCor(Me.PictureBox, xModelo & xCor, "xok")


            Application.DoEvents()
            Me.PictureBox.Visible = True
            Me.CFGDet.Visible = True




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
            CmdFechar.Enabled = True

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
                    'Sql = "INSERT INTO Reservas (ArmazemID, ArmzDest, ReservaDescr,ReservaModeloId, ReservaCorId, ReservaTamId, ReservaData, ReservaEstado, OperadorID) " & _
                    '    "VALUES ('" & xArmReservas & "', '" & xArmReservas & "', '" & Me.tbReserva.Text & "','" & Me.txtRModelo.Text & "','" & Me.txtRCor.Text & "','" & Me.txtRTam.Text & "',GETDATE(),'0','" & xUtilizador & "')"
                    'db.ExecuteData(Sql)

                    Sql = "INSERT INTO Reservas (ArmazemID, ArmzDest , ReservaDescr, ReservaModeloId, ReservaCorId, ReservaTamId, ReservaData, ReservaEstado, TipoReserva,  ReservaNome, ReservaClienteLojaID, UtilizadorID, OperadorID) " &
                     "VALUES ('" & xArmReservas & "', '" & xArmReservas & "',  '" & Me.tbReserva.Text & "','" & Me.txtRModelo.Text & "','" & Me.txtRCor.Text & "','" & Me.txtRTam.Text & "',GETDATE(),'0','R', '" & Me.lbCliente.Text & "','" & sClienteLojaIdAux & "', '" & iUtilizadorID & "', '" & xUtilizador & "')"
                    db.ExecuteData(Sql)




                Else
                    For Each r As DataRow In dt.Rows
                        Sql = "INSERT INTO Reservas (ArmazemID, ArmzDest, ReservaDescr,ReservaModeloId, ReservaCorId, ReservaTamId, ReservaData, ReservaEstado, OperadorID) " &
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
                Me.lbCliente.Text = "Cliente"
                sIDClienteLoja = Guid.NewGuid.ToString




            End If


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " InserirReserva")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub GravarOrdemTransferencia(ByVal sTipoOT As String)


        Dim db As New ClsSqlBDados
        Dim sReservaDescr As String = ""

        Try

            If xDestino <> xOrigem Then

                If ActualizaLigacao("Girl") = False Then Exit Try

                If sTipoOT = "Reserva" Then

                    'TODO: CARREGAR ESTA INFORMAÇÃO.....NAS TABELAS
                    sReservaDescr = "Transferir Reserva"
                    'If MsgBox("Envio directo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    '    sReservaDescr = "Transferir Reserva «« DIRECTO »»"
                    '    iDespesa = InputBox("Valor da Despesa?", "Despesas Associadas", "0")
                    'End If

                    xModelo = xModeloReservaAux
                    xCor = xCorReservaAux

                ElseIf sTipoOT = "Stock" Then
                    sReservaDescr = "Transferir"
                End If

                sIdReservas = Guid.NewGuid.ToString

                Sql = "INSERT INTO Reservas(ArmazemID, ArmzDest, ReservaDescr, ReservaSerieId, ReservaModeloId,ReservaCorId, " &
                "ReservaTamId,ReservaData,ReservaEstado, IDReservas, OperadorID) " &
                "VALUES('" & xOrigem & "', '" & xDestino & "', '" & sReservaDescr & "','" & xTalao & "', '" & xModelo & "','" & xCor & "','" & xTamTransf & "',GETDATE(),'0', '" & sIdReservas & "' ,'" & xUtilizador & "')"
                db.ExecuteData(Sql)

                'INSERIR DESCRITIVO PARA A RECEPÇÃO
                Sql = "UPDATE Serie SET Obs1 = '" & Trim(sReservaDescr) & " C-" & xDestino & "' WHERE SERIEID='" & xTalao & "'"

                db.ExecuteData(Sql)

                If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")

            Else

                xValor = 0
                xTalao = ""

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravarOrdemTransferencia")
        Catch ex As Exception
            ErroVB(ex.Message, "GravarOrdemTransferencia")
        Finally

            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    'Private Function SituacaoTalao(ByVal xTalao As String) As String

    '    Dim db As New ClsSqlBDados
    '    Dim xSituacaoTalao As String = ""


    '    Try


    '        Sql = "SELECT ARMAZEMID FROM SERIE WHERE SERIEID='" & xTalao & "'"
    '        Dim xArmazemActual As String = db.GetDataValue(Sql)

    '        Sql = "SELECT EstadoID FROM SERIE WHERE SERIEID='" & xTalao & "'"
    '        Dim xEstadoActual As String = db.GetDataValue(Sql)

    '        Sql = "SELECT DocCab.TercID Destino FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.EstadoLn = 'G') AND (DocDet.SerieID = '" & xTalao & "') AND (DocCab.TipoDocID = 'SE') GROUP BY DocCab.TercID"
    '        Dim xArmDestino As String = db.GetDataValue(Sql)

    '        Select Case xEstadoActual
    '            Case "G"
    '                xEstadoActual = "Gerado"
    '            Case "S"
    '                If xArmDestino = Nothing Then
    '                    xEstadoActual = "Stock C-" & xArmazemActual
    '                Else
    '                    xEstadoActual = "Stock C-" & xArmazemActual & " Separado C-" & xArmDestino
    '                End If
    '            Case "T"
    '                If xArmDestino = Nothing Then
    '                    xEstadoActual = "ERRO"
    '                Else
    '                    xEstadoActual = "Stock C-" & xArmazemActual & " Transito C-" & xArmDestino
    '                End If
    '            Case "V"
    '                xEstadoActual = "Vendido C-" & xArmazemActual
    '            Case "R"
    '                xEstadoActual = "Recolhido C-" & xArmazemActual
    '            Case "A"
    '                xEstadoActual = "Anulado"
    '        End Select


    '        'Sql = "UPDATE Reservas SET SituacaoActual=N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) + ' ' + Reservas.EstadoTalao + ' C-' + cast(cast(DocCab.TercID as int) as varchar) FROM Reservas INNER JOIN DocDet  ON Reservas.reservaserieid = DocDet.SerieID  INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID  AND DocDet.ArmazemID = DocCab.ArmazemID  AND DocDet.TipoDocID = DocCab.TipoDocID  AND DocDet.DocNr = DocCab.DocNr  WHERE (DocDet.EstadoLn = 'G') AND (DocCab.TipoDocID = 'SE');"
    '        'db.ExecuteData(Sql)


    '        'Sql = "UPDATE Reservas SET SituacaoActual = EstadoTalao + N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) WHERE (LEN(ISNULL(SituacaoActual, '')) = 0) AND ArmazemActual <> 'xxxx'"
    '        'db.ExecuteData(Sql)


    '        'Sql = "UPDATE Reservas SET ReservaEstado = 1 WHERE ((EstadoTalao IN ('Transito','Separado') AND ReservaDescr like 'Transferir%') OR EstadoTalao IN ('Vendido', 'Recolhido','Anulado')) "
    '        'db.ExecuteData(Sql)


    '        Return xEstadoActual



    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "ActualizarDados")
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "ActualizarDados")
    '    Finally
    '        db = Nothing
    '    End Try

    'End Function

    Private Sub CarregarReservas()

        Try


            Me.Cursor = Cursors.WaitCursor

            Me.GirlDataSet.Reservas.Clear()
            xFiltraDataGrid = ""
            If rbPendentes.Checked = True Then
                Me.ReservasTableAdapter.FillByArmzAbertosPend(Me.GirlDataSet.Reservas)
            ElseIf rbTodas.Checked = True Then
                Me.ReservasTableAdapter.FillByArmz(Me.GirlDataSet.Reservas, "%")
            ElseIf rbTratadas.Checked = True Then
                Me.ReservasTableAdapter.FillByReservasAbertas(Me.GirlDataSet.Reservas, "%")
            ElseIf rbTransf.Checked = True Then
                Me.ReservasTableAdapter.FillByTransf(Me.GirlDataSet.Reservas)
            End If

        Catch ex As Exception

            ErroVB(ex.Message, "CarregarReservas")

        Finally

            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function SituacaoTalao(ByVal xTalao As String) As String

        Dim db As New ClsSqlBDados
        Dim xSituacaoTalao As String = ""


        Try


            Sql = "SELECT ARMAZEMID FROM SERIE WHERE SERIEID='" & xTalao & "'"
            Dim xArmazemActual As String = db.GetDataValue(Sql)

            Sql = "SELECT EstadoID FROM SERIE WHERE SERIEID='" & xTalao & "'"
            Dim xEstadoActual As String = db.GetDataValue(Sql)

            Sql = "SELECT DocCab.TercID Destino FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.EstadoLn = 'G') AND (DocDet.SerieID = '" & xTalao & "') AND (DocCab.TipoDocID = 'SE') GROUP BY DocCab.TercID"
            Dim xArmDestino As String = db.GetDataValue(Sql)

            Select Case xEstadoActual
                Case "G"
                    xEstadoActual = "Gerado"
                Case "S"
                    If xArmDestino = Nothing Then
                        xEstadoActual = "Stock C-" & xArmazemActual
                    Else
                        xEstadoActual = "Stock C-" & xArmazemActual & " Separado C-" & xArmDestino
                    End If
                Case "T"
                    If xArmDestino = Nothing Then
                        xEstadoActual = "ERRO"
                    Else
                        xEstadoActual = "Stock C-" & xArmazemActual & " Transito C-" & xArmDestino
                    End If
                Case "V"
                    xEstadoActual = "Vendido C-" & xArmazemActual
                Case "R"
                    xEstadoActual = "Recolhido C-" & xArmazemActual
                Case "A"
                    xEstadoActual = "Anulado"
            End Select


            'Sql = "UPDATE Reservas SET SituacaoActual=N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) + ' ' + Reservas.EstadoTalao + ' C-' + cast(cast(DocCab.TercID as int) as varchar) FROM Reservas INNER JOIN DocDet  ON Reservas.reservaserieid = DocDet.SerieID  INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID  AND DocDet.ArmazemID = DocCab.ArmazemID  AND DocDet.TipoDocID = DocCab.TipoDocID  AND DocDet.DocNr = DocCab.DocNr  WHERE (DocDet.EstadoLn = 'G') AND (DocCab.TipoDocID = 'SE');"
            'db.ExecuteData(Sql)


            'Sql = "UPDATE Reservas SET SituacaoActual = EstadoTalao + N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) WHERE (LEN(ISNULL(SituacaoActual, '')) = 0) AND ArmazemActual <> 'xxxx'"
            'db.ExecuteData(Sql)


            'Sql = "UPDATE Reservas SET ReservaEstado = 1 WHERE ((EstadoTalao IN ('Transito','Separado') AND ReservaDescr like 'Transferir%') OR EstadoTalao IN ('Vendido', 'Recolhido','Anulado')) "
            'db.ExecuteData(Sql)


            Return xEstadoActual



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizarDados")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizarDados")
        Finally
            db = Nothing
        End Try

    End Function

    Private Sub btCliente_Click(sender As System.Object, e As System.EventArgs) Handles btCliente.Click


        If SistemaBloqueado() = True Then
            Exit Sub
        End If

        Dim db As New ClsSqlBDados


        sIDClienteLoja = ""
        frmClientesLojaLista.WindowState = FormWindowState.Normal
        frmClientesLojaLista.StartPosition = FormStartPosition.CenterScreen
        frmClientesLojaLista.ShowDialog(Me)

        ActualizarClienteLoja(sIDClienteLoja, sClienteLojaIdAux, lbCliente.Text, sNIF)


    End Sub








End Class



