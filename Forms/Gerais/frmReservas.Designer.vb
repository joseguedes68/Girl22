<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ReservasBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.ReservasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReservasBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.ReservasDataGridView = New System.Windows.Forms.DataGridView()
        Me.ReservaIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaArmazemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaArmzDest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaSerieID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despesas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaModeloId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaCorId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaTamId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SituacaoActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoTalao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArmazemActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservaEstado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReservaDataDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperadorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtRegisto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btListaTrasf = New System.Windows.Forms.Button()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.cbVerTodos = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTam = New System.Windows.Forms.TextBox()
        Me.tbCor = New System.Windows.Forms.TextBox()
        Me.tbModelo = New System.Windows.Forms.TextBox()
        Me.tbDescr = New System.Windows.Forms.TextBox()
        Me.btInserir = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btAtualiza = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ReservasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ReservasTableAdapter()
        CType(Me.ReservasBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ReservasBindingNavigator.SuspendLayout()
        CType(Me.ReservasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservasDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReservasBindingNavigator
        '
        Me.ReservasBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ReservasBindingNavigator.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ReservasBindingNavigator.BindingSource = Me.ReservasBindingSource
        Me.ReservasBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ReservasBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ReservasBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.ReservasBindingNavigator.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ReservasBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ReservasBindingNavigatorSaveItem})
        Me.ReservasBindingNavigator.Location = New System.Drawing.Point(589, -95)
        Me.ReservasBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ReservasBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ReservasBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ReservasBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ReservasBindingNavigator.Name = "ReservasBindingNavigator"
        Me.ReservasBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ReservasBindingNavigator.Size = New System.Drawing.Size(310, 27)
        Me.ReservasBindingNavigator.TabIndex = 0
        Me.ReservasBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(45, 24)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(65, 27)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'ReservasBindingNavigatorSaveItem
        '
        Me.ReservasBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ReservasBindingNavigatorSaveItem.Image = CType(resources.GetObject("ReservasBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ReservasBindingNavigatorSaveItem.Name = "ReservasBindingNavigatorSaveItem"
        Me.ReservasBindingNavigatorSaveItem.Size = New System.Drawing.Size(24, 24)
        Me.ReservasBindingNavigatorSaveItem.Text = "Save Data"
        '
        'ReservasDataGridView
        '
        Me.ReservasDataGridView.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ReservasDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ReservasDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReservasDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReservasDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ReservasDataGridView.ColumnHeadersHeight = 30
        Me.ReservasDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReservaIDDataGridViewTextBoxColumn, Me.ReservaArmazemID, Me.ReservaDescr, Me.ReservaArmzDest, Me.ReservaSerieID, Me.Sinal, Me.ReservaNome, Me.Despesas, Me.ReservaModeloId, Me.ReservaCorId, Me.ReservaTamId, Me.SituacaoActual, Me.EstadoTalao, Me.ArmazemActual, Me.Fornecedor, Me.ReservaEstado, Me.ReservaDataDataGridViewTextBoxColumn, Me.OperadorID, Me.DtRegisto})
        Me.ReservasDataGridView.DataSource = Me.ReservasBindingSource
        Me.ReservasDataGridView.Location = New System.Drawing.Point(0, 213)
        Me.ReservasDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReservasDataGridView.Name = "ReservasDataGridView"
        Me.ReservasDataGridView.Size = New System.Drawing.Size(1545, 388)
        Me.ReservasDataGridView.TabIndex = 1
        '
        'ReservaIDDataGridViewTextBoxColumn
        '
        Me.ReservaIDDataGridViewTextBoxColumn.DataPropertyName = "ReservaID"
        Me.ReservaIDDataGridViewTextBoxColumn.HeaderText = "NºRes"
        Me.ReservaIDDataGridViewTextBoxColumn.Name = "ReservaIDDataGridViewTextBoxColumn"
        Me.ReservaIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReservaIDDataGridViewTextBoxColumn.Width = 60
        '
        'ReservaArmazemID
        '
        Me.ReservaArmazemID.DataPropertyName = "ArmazemID"
        Me.ReservaArmazemID.HeaderText = "Loja"
        Me.ReservaArmazemID.Name = "ReservaArmazemID"
        Me.ReservaArmazemID.ReadOnly = True
        Me.ReservaArmazemID.Width = 56
        '
        'ReservaDescr
        '
        Me.ReservaDescr.DataPropertyName = "ReservaDescr"
        Me.ReservaDescr.HeaderText = "Obs"
        Me.ReservaDescr.Name = "ReservaDescr"
        Me.ReservaDescr.Width = 230
        '
        'ReservaArmzDest
        '
        Me.ReservaArmzDest.DataPropertyName = "ArmzDest"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaArmzDest.DefaultCellStyle = DataGridViewCellStyle3
        Me.ReservaArmzDest.HeaderText = "Destino"
        Me.ReservaArmzDest.Name = "ReservaArmzDest"
        Me.ReservaArmzDest.ReadOnly = True
        Me.ReservaArmzDest.Width = 74
        '
        'ReservaSerieID
        '
        Me.ReservaSerieID.DataPropertyName = "ReservaSerieID"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaSerieID.DefaultCellStyle = DataGridViewCellStyle4
        Me.ReservaSerieID.HeaderText = "Talão"
        Me.ReservaSerieID.Name = "ReservaSerieID"
        Me.ReservaSerieID.ReadOnly = True
        Me.ReservaSerieID.Width = 63
        '
        'Sinal
        '
        Me.Sinal.DataPropertyName = "Sinal"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Sinal.DefaultCellStyle = DataGridViewCellStyle5
        Me.Sinal.HeaderText = "Sinal"
        Me.Sinal.Name = "Sinal"
        Me.Sinal.Width = 60
        '
        'ReservaNome
        '
        Me.ReservaNome.DataPropertyName = "ReservaNome"
        Me.ReservaNome.HeaderText = "Nome"
        Me.ReservaNome.Name = "ReservaNome"
        Me.ReservaNome.ReadOnly = True
        Me.ReservaNome.Width = 130
        '
        'Despesas
        '
        Me.Despesas.DataPropertyName = "Despesas"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Despesas.DefaultCellStyle = DataGridViewCellStyle6
        Me.Despesas.HeaderText = "Despesas"
        Me.Despesas.Name = "Despesas"
        Me.Despesas.Visible = False
        Me.Despesas.Width = 87
        '
        'ReservaModeloId
        '
        Me.ReservaModeloId.DataPropertyName = "ReservaModeloId"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaModeloId.DefaultCellStyle = DataGridViewCellStyle7
        Me.ReservaModeloId.HeaderText = "Modelo"
        Me.ReservaModeloId.Name = "ReservaModeloId"
        Me.ReservaModeloId.ReadOnly = True
        Me.ReservaModeloId.Width = 50
        '
        'ReservaCorId
        '
        Me.ReservaCorId.DataPropertyName = "ReservaCorId"
        Me.ReservaCorId.HeaderText = "Cor"
        Me.ReservaCorId.Name = "ReservaCorId"
        Me.ReservaCorId.ReadOnly = True
        Me.ReservaCorId.Width = 40
        '
        'ReservaTamId
        '
        Me.ReservaTamId.DataPropertyName = "ReservaTamId"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ReservaTamId.DefaultCellStyle = DataGridViewCellStyle8
        Me.ReservaTamId.HeaderText = "Tam"
        Me.ReservaTamId.Name = "ReservaTamId"
        Me.ReservaTamId.ReadOnly = True
        Me.ReservaTamId.Width = 40
        '
        'SituacaoActual
        '
        Me.SituacaoActual.DataPropertyName = "SituacaoActual"
        Me.SituacaoActual.HeaderText = "Situação Actual"
        Me.SituacaoActual.Name = "SituacaoActual"
        Me.SituacaoActual.ReadOnly = True
        Me.SituacaoActual.Visible = False
        Me.SituacaoActual.Width = 50
        '
        'EstadoTalao
        '
        Me.EstadoTalao.DataPropertyName = "EstadoTalao"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.EstadoTalao.DefaultCellStyle = DataGridViewCellStyle9
        Me.EstadoTalao.HeaderText = "ET"
        Me.EstadoTalao.Name = "EstadoTalao"
        Me.EstadoTalao.ReadOnly = True
        Me.EstadoTalao.Visible = False
        Me.EstadoTalao.Width = 47
        '
        'ArmazemActual
        '
        Me.ArmazemActual.DataPropertyName = "ArmazemActual"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ArmazemActual.DefaultCellStyle = DataGridViewCellStyle10
        Me.ArmazemActual.HeaderText = "ArmAct"
        Me.ArmazemActual.Name = "ArmazemActual"
        Me.ArmazemActual.ReadOnly = True
        Me.ArmazemActual.Visible = False
        Me.ArmazemActual.Width = 70
        '
        'Fornecedor
        '
        Me.Fornecedor.DataPropertyName = "ReservaForn"
        Me.Fornecedor.HeaderText = "Fornecedor"
        Me.Fornecedor.Name = "Fornecedor"
        Me.Fornecedor.ReadOnly = True
        Me.Fornecedor.Width = 95
        '
        'ReservaEstado
        '
        Me.ReservaEstado.DataPropertyName = "ReservaEstado"
        Me.ReservaEstado.HeaderText = "E"
        Me.ReservaEstado.Name = "ReservaEstado"
        Me.ReservaEstado.Width = 21
        '
        'ReservaDataDataGridViewTextBoxColumn
        '
        Me.ReservaDataDataGridViewTextBoxColumn.DataPropertyName = "ReservaData"
        Me.ReservaDataDataGridViewTextBoxColumn.HeaderText = "Data"
        Me.ReservaDataDataGridViewTextBoxColumn.Name = "ReservaDataDataGridViewTextBoxColumn"
        Me.ReservaDataDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OperadorID
        '
        Me.OperadorID.DataPropertyName = "OperadorID"
        Me.OperadorID.HeaderText = "OperadorID"
        Me.OperadorID.Name = "OperadorID"
        Me.OperadorID.Visible = False
        Me.OperadorID.Width = 96
        '
        'DtRegisto
        '
        Me.DtRegisto.DataPropertyName = "DtRegisto"
        Me.DtRegisto.HeaderText = "DtRegisto"
        Me.DtRegisto.Name = "DtRegisto"
        Me.DtRegisto.Visible = False
        Me.DtRegisto.Width = 150
        '
        'btListaTrasf
        '
        Me.btListaTrasf.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btListaTrasf.Location = New System.Drawing.Point(335, 15)
        Me.btListaTrasf.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btListaTrasf.Name = "btListaTrasf"
        Me.btListaTrasf.Size = New System.Drawing.Size(213, 28)
        Me.btListaTrasf.TabIndex = 39
        Me.btListaTrasf.Text = "Listar Trasferências"
        Me.btListaTrasf.UseVisualStyleBackColor = False
        '
        'PictureBox
        '
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox.Location = New System.Drawing.Point(895, 10)
        Me.PictureBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(329, 185)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox.TabIndex = 38
        Me.PictureBox.TabStop = False
        '
        'cbVerTodos
        '
        Me.cbVerTodos.AutoSize = True
        Me.cbVerTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVerTodos.Location = New System.Drawing.Point(701, 15)
        Me.cbVerTodos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbVerTodos.Name = "cbVerTodos"
        Me.cbVerTodos.Size = New System.Drawing.Size(126, 29)
        Me.cbVerTodos.TabIndex = 37
        Me.cbVerTodos.Text = "Ver Todos"
        Me.cbVerTodos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(272, 75)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 20)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Tam"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(209, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 20)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Cor"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 75)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Modelo"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 20)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Descrição"
        Me.Label1.Visible = False
        '
        'tbTam
        '
        Me.tbTam.Location = New System.Drawing.Point(276, 100)
        Me.tbTam.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbTam.Name = "tbTam"
        Me.tbTam.Size = New System.Drawing.Size(59, 22)
        Me.tbTam.TabIndex = 30
        Me.tbTam.Visible = False
        '
        'tbCor
        '
        Me.tbCor.Location = New System.Drawing.Point(196, 100)
        Me.tbCor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbCor.Name = "tbCor"
        Me.tbCor.Size = New System.Drawing.Size(72, 22)
        Me.tbCor.TabIndex = 29
        Me.tbCor.Visible = False
        '
        'tbModelo
        '
        Me.tbModelo.Location = New System.Drawing.Point(93, 100)
        Me.tbModelo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbModelo.Name = "tbModelo"
        Me.tbModelo.Size = New System.Drawing.Size(96, 22)
        Me.tbModelo.TabIndex = 32
        Me.tbModelo.Visible = False
        '
        'tbDescr
        '
        Me.tbDescr.Location = New System.Drawing.Point(11, 47)
        Me.tbDescr.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbDescr.Name = "tbDescr"
        Me.tbDescr.Size = New System.Drawing.Size(477, 22)
        Me.tbDescr.TabIndex = 31
        Me.tbDescr.Visible = False
        '
        'btInserir
        '
        Me.btInserir.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btInserir.Location = New System.Drawing.Point(172, 15)
        Me.btInserir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btInserir.Name = "btInserir"
        Me.btInserir.Size = New System.Drawing.Size(155, 28)
        Me.btInserir.TabIndex = 28
        Me.btInserir.Text = "Inserir"
        Me.btInserir.UseVisualStyleBackColor = False
        Me.btInserir.Visible = False
        '
        'btFechar
        '
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFechar.Location = New System.Drawing.Point(1233, 15)
        Me.btFechar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(137, 44)
        Me.btFechar.TabIndex = 27
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'btAtualiza
        '
        Me.btAtualiza.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btAtualiza.Location = New System.Drawing.Point(1233, 68)
        Me.btAtualiza.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btAtualiza.Name = "btAtualiza"
        Me.btAtualiza.Size = New System.Drawing.Size(137, 36)
        Me.btAtualiza.TabIndex = 26
        Me.btAtualiza.Text = "Actualizar"
        Me.btAtualiza.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Crimson
        Me.Label5.Location = New System.Drawing.Point(21, 138)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(551, 17)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "PARA SABER A SITUAÇÃO DA RESERVA CLICAR EM CIMA DO RESPECTIVO TALÃO"
        '
        'ReservasTableAdapter
        '
        Me.ReservasTableAdapter.ClearBeforeFill = True
        '
        'frmReservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1545, 601)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btListaTrasf)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.cbVerTodos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbTam)
        Me.Controls.Add(Me.tbCor)
        Me.Controls.Add(Me.tbModelo)
        Me.Controls.Add(Me.tbDescr)
        Me.Controls.Add(Me.btInserir)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.btAtualiza)
        Me.Controls.Add(Me.ReservasDataGridView)
        Me.Controls.Add(Me.ReservasBindingNavigator)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmReservas"
        Me.Text = "Reservas"
        CType(Me.ReservasBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ReservasBindingNavigator.ResumeLayout(False)
        Me.ReservasBindingNavigator.PerformLayout()
        CType(Me.ReservasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservasDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents ReservasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReservasTableAdapter As GirlRootName.GirlDataSetTableAdapters.ReservasTableAdapter
    Friend WithEvents ReservasBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReservasBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ReservasDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btListaTrasf As System.Windows.Forms.Button
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents cbVerTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbTam As System.Windows.Forms.TextBox
    Friend WithEvents tbCor As System.Windows.Forms.TextBox
    Friend WithEvents tbModelo As System.Windows.Forms.TextBox
    Friend WithEvents tbDescr As System.Windows.Forms.TextBox
    Friend WithEvents btInserir As System.Windows.Forms.Button
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents btAtualiza As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ReservaIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaArmazemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaArmzDest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaSerieID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Despesas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaModeloId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaCorId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaTamId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SituacaoActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoTalao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArmazemActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fornecedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservaEstado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReservaDataDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperadorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtRegisto As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
