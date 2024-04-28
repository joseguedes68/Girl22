<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArtigos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArtigos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.ModelosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModelosTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ModelosTableAdapter()
        Me.ModelosBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvModelos = New System.Windows.Forms.DataGridView()
        Me.GruposBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LinhasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UnidadesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EpocasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MarcasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModeloCorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModeloCorTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ModeloCorTableAdapter()
        Me.dgvModeloCor = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TerceirosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GruposTableAdapter = New GirlRootName.GirlDataSetTableAdapters.GruposTableAdapter()
        Me.TiposTableAdapter = New GirlRootName.GirlDataSetTableAdapters.TiposTableAdapter()
        Me.LinhasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.LinhasTableAdapter()
        Me.UnidadesTableAdapter = New GirlRootName.GirlDataSetTableAdapters.UnidadesTableAdapter()
        Me.CoresTableAdapter = New GirlRootName.GirlDataSetTableAdapters.CoresTableAdapter()
        Me.PicBox = New System.Windows.Forms.PictureBox()
        Me.cmdGravar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdFechar = New System.Windows.Forms.Button()
        Me.TiposBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtModelos = New System.Windows.Forms.TextBox()
        Me.cbGrupos = New System.Windows.Forms.ComboBox()
        Me.cbTipos = New System.Windows.Forms.ComboBox()
        Me.cbMarcas = New System.Windows.Forms.ComboBox()
        Me.btFiltro = New System.Windows.Forms.Button()
        Me.FKModelosTiposBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EpocasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.EpocasTableAdapter()
        Me.TerceirosTableAdapter = New GirlRootName.GirlDataSetTableAdapters.TerceirosTableAdapter()
        Me.MarcasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.MarcasTableAdapter()
        Me.ModeloID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrupoID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TipoID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LinhaID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.UnidID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Altura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EpocaID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MarcaID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.EscalaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModelosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModelosBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ModelosBindingNavigator.SuspendLayout()
        CType(Me.dgvModelos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GruposBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LinhasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnidadesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EpocasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MarcasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModeloCorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvModeloCor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TerceirosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TiposBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKModelosTiposBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ModelosBindingSource
        '
        Me.ModelosBindingSource.DataMember = "Modelos"
        Me.ModelosBindingSource.DataSource = Me.GirlDataSet
        '
        'ModelosTableAdapter
        '
        Me.ModelosTableAdapter.ClearBeforeFill = True
        '
        'ModelosBindingNavigator
        '
        Me.ModelosBindingNavigator.AddNewItem = Nothing
        Me.ModelosBindingNavigator.BindingSource = Me.ModelosBindingSource
        Me.ModelosBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ModelosBindingNavigator.DeleteItem = Nothing
        Me.ModelosBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ModelosBindingNavigator.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModelosBindingNavigator.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ModelosBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.ModelosBindingNavigator.Location = New System.Drawing.Point(0, 617)
        Me.ModelosBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ModelosBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ModelosBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ModelosBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ModelosBindingNavigator.Name = "ModelosBindingNavigator"
        Me.ModelosBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ModelosBindingNavigator.Size = New System.Drawing.Size(1412, 32)
        Me.ModelosBindingNavigator.TabIndex = 0
        Me.ModelosBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(78, 29)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(29, 29)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(29, 29)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 32)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(65, 32)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 32)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(29, 29)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(29, 29)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 32)
        '
        'dgvModelos
        '
        Me.dgvModelos.AllowUserToDeleteRows = False
        Me.dgvModelos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvModelos.AutoGenerateColumns = False
        Me.dgvModelos.ColumnHeadersHeight = 29
        Me.dgvModelos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ModeloID, Me.GrupoID, Me.TipoID, Me.DataGridViewTextBoxColumn4, Me.LinhaID, Me.UnidID, Me.Altura, Me.EpocaID, Me.MarcaID, Me.EscalaID})
        Me.dgvModelos.DataSource = Me.ModelosBindingSource
        Me.dgvModelos.Location = New System.Drawing.Point(16, 48)
        Me.dgvModelos.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvModelos.Name = "dgvModelos"
        Me.dgvModelos.RowHeadersWidth = 51
        Me.dgvModelos.Size = New System.Drawing.Size(1065, 366)
        Me.dgvModelos.TabIndex = 1
        '
        'GruposBindingSource
        '
        Me.GruposBindingSource.DataMember = "Grupos"
        Me.GruposBindingSource.DataSource = Me.GirlDataSet
        '
        'LinhasBindingSource
        '
        Me.LinhasBindingSource.DataMember = "Linhas"
        Me.LinhasBindingSource.DataSource = Me.GirlDataSet
        '
        'UnidadesBindingSource
        '
        Me.UnidadesBindingSource.DataMember = "Unidades"
        Me.UnidadesBindingSource.DataSource = Me.GirlDataSet
        '
        'EpocasBindingSource
        '
        Me.EpocasBindingSource.DataMember = "Epocas"
        Me.EpocasBindingSource.DataSource = Me.GirlDataSet
        '
        'MarcasBindingSource
        '
        Me.MarcasBindingSource.DataMember = "Marcas"
        Me.MarcasBindingSource.DataSource = Me.GirlDataSet
        '
        'ModeloCorBindingSource
        '
        Me.ModeloCorBindingSource.DataMember = "FK_ModeloCor_Modelos"
        Me.ModeloCorBindingSource.DataSource = Me.ModelosBindingSource
        '
        'ModeloCorTableAdapter
        '
        Me.ModeloCorTableAdapter.ClearBeforeFill = True
        '
        'dgvModeloCor
        '
        Me.dgvModeloCor.AllowUserToDeleteRows = False
        Me.dgvModeloCor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvModeloCor.AutoGenerateColumns = False
        Me.dgvModeloCor.ColumnHeadersHeight = 29
        Me.dgvModeloCor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn14})
        Me.dgvModeloCor.DataSource = Me.ModeloCorBindingSource
        Me.dgvModeloCor.Location = New System.Drawing.Point(16, 421)
        Me.dgvModeloCor.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvModeloCor.Name = "dgvModeloCor"
        Me.dgvModeloCor.RowHeadersWidth = 51
        Me.dgvModeloCor.Size = New System.Drawing.Size(1380, 174)
        Me.dgvModeloCor.TabIndex = 2
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "ModeloID"
        Me.DataGridViewTextBoxColumn11.HeaderText = "ModeloID"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 125
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "CorID"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Cor"
        Me.DataGridViewTextBoxColumn12.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn12.Width = 125
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "ModCorDescr"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Descrição"
        Me.DataGridViewTextBoxColumn13.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 225
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "FornID"
        Me.DataGridViewTextBoxColumn15.DataSource = Me.TerceirosBindingSource
        Me.DataGridViewTextBoxColumn15.DisplayMember = "NomeAbrev"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Fornecedor"
        Me.DataGridViewTextBoxColumn15.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn15.ValueMember = "TercID"
        Me.DataGridViewTextBoxColumn15.Width = 125
        '
        'TerceirosBindingSource
        '
        Me.TerceirosBindingSource.DataMember = "Terceiros"
        Me.TerceirosBindingSource.DataSource = Me.GirlDataSet
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "RefForn"
        Me.DataGridViewTextBoxColumn16.HeaderText = "RefForn"
        Me.DataGridViewTextBoxColumn16.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Width = 75
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "CorForn"
        Me.DataGridViewTextBoxColumn17.HeaderText = "CorForn"
        Me.DataGridViewTextBoxColumn17.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 125
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "PrCusto"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DataGridViewTextBoxColumn18.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn18.HeaderText = "PrCusto"
        Me.DataGridViewTextBoxColumn18.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Width = 65
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "PrVnd"
        DataGridViewCellStyle2.Format = "C4"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn14.HeaderText = "PrEtiqueta"
        Me.DataGridViewTextBoxColumn14.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 65
        '
        'CoresBindingSource
        '
        Me.CoresBindingSource.DataMember = "Cores"
        Me.CoresBindingSource.DataSource = Me.GirlDataSet
        '
        'GruposTableAdapter
        '
        Me.GruposTableAdapter.ClearBeforeFill = True
        '
        'TiposTableAdapter
        '
        Me.TiposTableAdapter.ClearBeforeFill = True
        '
        'LinhasTableAdapter
        '
        Me.LinhasTableAdapter.ClearBeforeFill = True
        '
        'UnidadesTableAdapter
        '
        Me.UnidadesTableAdapter.ClearBeforeFill = True
        '
        'CoresTableAdapter
        '
        Me.CoresTableAdapter.ClearBeforeFill = True
        '
        'PicBox
        '
        Me.PicBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicBox.Location = New System.Drawing.Point(1089, 121)
        Me.PicBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PicBox.Name = "PicBox"
        Me.PicBox.Size = New System.Drawing.Size(307, 203)
        Me.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBox.TabIndex = 4
        Me.PicBox.TabStop = False
        '
        'cmdGravar
        '
        Me.cmdGravar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGravar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdGravar.Location = New System.Drawing.Point(1101, 15)
        Me.cmdGravar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(96, 31)
        Me.cmdGravar.TabIndex = 5
        Me.cmdGravar.Text = "Gravar"
        Me.cmdGravar.UseVisualStyleBackColor = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdCancelar.Location = New System.Drawing.Point(1205, 15)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(96, 31)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdFechar.Location = New System.Drawing.Point(1309, 15)
        Me.cmdFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(96, 31)
        Me.cmdFechar.TabIndex = 7
        Me.cmdFechar.Text = "Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'TiposBindingSource
        '
        Me.TiposBindingSource.DataMember = "Tipos"
        Me.TiposBindingSource.DataSource = Me.GirlDataSet
        '
        'txtModelos
        '
        Me.txtModelos.Location = New System.Drawing.Point(76, 15)
        Me.txtModelos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtModelos.Name = "txtModelos"
        Me.txtModelos.Size = New System.Drawing.Size(80, 22)
        Me.txtModelos.TabIndex = 8
        Me.txtModelos.Text = "MODELOS"
        Me.txtModelos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbGrupos
        '
        Me.cbGrupos.DataSource = Me.GruposBindingSource
        Me.cbGrupos.DisplayMember = "GrupoDesc"
        Me.cbGrupos.FormattingEnabled = True
        Me.cbGrupos.Location = New System.Drawing.Point(175, 15)
        Me.cbGrupos.Margin = New System.Windows.Forms.Padding(4)
        Me.cbGrupos.Name = "cbGrupos"
        Me.cbGrupos.Size = New System.Drawing.Size(255, 24)
        Me.cbGrupos.TabIndex = 9
        Me.cbGrupos.ValueMember = "GrupoID"
        '
        'cbTipos
        '
        Me.cbTipos.FormattingEnabled = True
        Me.cbTipos.Location = New System.Drawing.Point(438, 15)
        Me.cbTipos.Margin = New System.Windows.Forms.Padding(4)
        Me.cbTipos.Name = "cbTipos"
        Me.cbTipos.Size = New System.Drawing.Size(403, 24)
        Me.cbTipos.TabIndex = 9
        '
        'cbMarcas
        '
        Me.cbMarcas.FormattingEnabled = True
        Me.cbMarcas.Location = New System.Drawing.Point(849, 15)
        Me.cbMarcas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbMarcas.Name = "cbMarcas"
        Me.cbMarcas.Size = New System.Drawing.Size(164, 24)
        Me.cbMarcas.TabIndex = 9
        '
        'btFiltro
        '
        Me.btFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btFiltro.Location = New System.Drawing.Point(1021, 15)
        Me.btFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.btFiltro.Name = "btFiltro"
        Me.btFiltro.Size = New System.Drawing.Size(60, 28)
        Me.btFiltro.TabIndex = 10
        Me.btFiltro.Text = "Filtrar"
        Me.btFiltro.UseVisualStyleBackColor = False
        '
        'FKModelosTiposBindingSource
        '
        Me.FKModelosTiposBindingSource.DataMember = "FK_Modelos_Tipos"
        Me.FKModelosTiposBindingSource.DataSource = Me.TiposBindingSource
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Modelo :"
        '
        'EpocasTableAdapter
        '
        Me.EpocasTableAdapter.ClearBeforeFill = True
        '
        'TerceirosTableAdapter
        '
        Me.TerceirosTableAdapter.ClearBeforeFill = True
        '
        'MarcasTableAdapter
        '
        Me.MarcasTableAdapter.ClearBeforeFill = True
        '
        'ModeloID
        '
        Me.ModeloID.DataPropertyName = "ModeloID"
        Me.ModeloID.HeaderText = "Modelo"
        Me.ModeloID.MinimumWidth = 6
        Me.ModeloID.Name = "ModeloID"
        Me.ModeloID.Width = 50
        '
        'GrupoID
        '
        Me.GrupoID.DataPropertyName = "GrupoID"
        Me.GrupoID.DataSource = Me.GruposBindingSource
        Me.GrupoID.DisplayMember = "GrupoDesc"
        Me.GrupoID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.GrupoID.HeaderText = "Grupo"
        Me.GrupoID.MinimumWidth = 6
        Me.GrupoID.Name = "GrupoID"
        Me.GrupoID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrupoID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.GrupoID.ValueMember = "GrupoID"
        Me.GrupoID.Width = 180
        '
        'TipoID
        '
        Me.TipoID.DataPropertyName = "TipoID"
        Me.TipoID.HeaderText = "Tipo"
        Me.TipoID.MinimumWidth = 6
        Me.TipoID.Name = "TipoID"
        Me.TipoID.Width = 125
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "FamiliaID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "FamiliaID"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'LinhaID
        '
        Me.LinhaID.DataPropertyName = "LinhaID"
        Me.LinhaID.DataSource = Me.LinhasBindingSource
        Me.LinhaID.DisplayMember = "DescrLinha"
        Me.LinhaID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.LinhaID.HeaderText = "Linha"
        Me.LinhaID.MinimumWidth = 6
        Me.LinhaID.Name = "LinhaID"
        Me.LinhaID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LinhaID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.LinhaID.ValueMember = "LinhaID"
        Me.LinhaID.Width = 72
        '
        'UnidID
        '
        Me.UnidID.DataPropertyName = "UnidID"
        Me.UnidID.DataSource = Me.UnidadesBindingSource
        Me.UnidID.DisplayMember = "UnidDescr"
        Me.UnidID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.UnidID.HeaderText = "Unid"
        Me.UnidID.MinimumWidth = 6
        Me.UnidID.Name = "UnidID"
        Me.UnidID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UnidID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.UnidID.ValueMember = "UnidID"
        Me.UnidID.Width = 46
        '
        'Altura
        '
        Me.Altura.DataPropertyName = "Altura"
        Me.Altura.HeaderText = "Altura"
        Me.Altura.MinimumWidth = 6
        Me.Altura.Name = "Altura"
        Me.Altura.Width = 50
        '
        'EpocaID
        '
        Me.EpocaID.DataPropertyName = "EpocaID"
        Me.EpocaID.DataSource = Me.EpocasBindingSource
        Me.EpocaID.DisplayMember = "EpocaDescr"
        Me.EpocaID.HeaderText = "Epoca"
        Me.EpocaID.MinimumWidth = 6
        Me.EpocaID.Name = "EpocaID"
        Me.EpocaID.ValueMember = "EpocaID"
        Me.EpocaID.Width = 60
        '
        'MarcaID
        '
        Me.MarcaID.DataPropertyName = "MarcaID"
        Me.MarcaID.DataSource = Me.MarcasBindingSource
        Me.MarcaID.DisplayMember = "MarcaDescr"
        Me.MarcaID.HeaderText = "Marca"
        Me.MarcaID.MinimumWidth = 6
        Me.MarcaID.Name = "MarcaID"
        Me.MarcaID.ValueMember = "MarcaID"
        Me.MarcaID.Width = 200
        '
        'EscalaID
        '
        Me.EscalaID.DataPropertyName = "EscalaID"
        Me.EscalaID.HeaderText = "Escala"
        Me.EscalaID.MinimumWidth = 6
        Me.EscalaID.Name = "EscalaID"
        Me.EscalaID.Width = 55
        '
        'frmArtigos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1412, 649)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btFiltro)
        Me.Controls.Add(Me.cbMarcas)
        Me.Controls.Add(Me.cbTipos)
        Me.Controls.Add(Me.cbGrupos)
        Me.Controls.Add(Me.txtModelos)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.PicBox)
        Me.Controls.Add(Me.dgvModeloCor)
        Me.Controls.Add(Me.dgvModelos)
        Me.Controls.Add(Me.ModelosBindingNavigator)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmArtigos"
        Me.Text = "Artigos"
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModelosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModelosBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ModelosBindingNavigator.ResumeLayout(False)
        Me.ModelosBindingNavigator.PerformLayout()
        CType(Me.dgvModelos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GruposBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LinhasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnidadesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EpocasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MarcasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModeloCorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvModeloCor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TerceirosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TiposBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKModelosTiposBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents ModelosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ModelosBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvModelos As System.Windows.Forms.DataGridView
    Friend WithEvents ModeloCorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dgvModeloCor As System.Windows.Forms.DataGridView
    Friend WithEvents GruposBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LinhasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UnidadesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CoresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PicBox As System.Windows.Forms.PictureBox
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents ModelosTableAdapter As GirlRootName.GirlDataSetTableAdapters.ModelosTableAdapter
    Friend WithEvents ModeloCorTableAdapter As GirlRootName.GirlDataSetTableAdapters.ModeloCorTableAdapter
    Friend WithEvents GruposTableAdapter As GirlRootName.GirlDataSetTableAdapters.GruposTableAdapter
    Friend WithEvents TiposTableAdapter As GirlRootName.GirlDataSetTableAdapters.TiposTableAdapter
    Friend WithEvents LinhasTableAdapter As GirlRootName.GirlDataSetTableAdapters.LinhasTableAdapter
    Friend WithEvents UnidadesTableAdapter As GirlRootName.GirlDataSetTableAdapters.UnidadesTableAdapter
    Friend WithEvents CoresTableAdapter As GirlRootName.GirlDataSetTableAdapters.CoresTableAdapter
    Friend WithEvents TiposBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents txtModelos As System.Windows.Forms.TextBox
    Friend WithEvents cbGrupos As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipos As System.Windows.Forms.ComboBox
    Friend WithEvents cbMarcas As System.Windows.Forms.ComboBox
    Friend WithEvents btFiltro As System.Windows.Forms.Button
    Friend WithEvents FKModelosTiposBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents EpocasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EpocasTableAdapter As GirlRootName.GirlDataSetTableAdapters.EpocasTableAdapter
    Friend WithEvents TerceirosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TerceirosTableAdapter As GirlRootName.GirlDataSetTableAdapters.TerceirosTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarcasBindingSource As BindingSource
    Friend WithEvents MarcasTableAdapter As GirlDataSetTableAdapters.MarcasTableAdapter
    Friend WithEvents ModeloID As DataGridViewTextBoxColumn
    Friend WithEvents GrupoID As DataGridViewComboBoxColumn
    Friend WithEvents TipoID As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents LinhaID As DataGridViewComboBoxColumn
    Friend WithEvents UnidID As DataGridViewComboBoxColumn
    Friend WithEvents Altura As DataGridViewTextBoxColumn
    Friend WithEvents EpocaID As DataGridViewComboBoxColumn
    Friend WithEvents MarcaID As DataGridViewComboBoxColumn
    Friend WithEvents EscalaID As DataGridViewTextBoxColumn
End Class
