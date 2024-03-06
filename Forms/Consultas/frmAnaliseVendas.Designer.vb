<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnaliseVendas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnaliseVendas))
        Me.dgvEnviados = New System.Windows.Forms.DataGridView()
        Me.cbFornecedores = New System.Windows.Forms.ComboBox()
        Me.FornecedoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.TerceirosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbArmazens = New System.Windows.Forms.ComboBox()
        Me.ArmazensBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbArmazem = New System.Windows.Forms.Label()
        Me.lbGrupo = New System.Windows.Forms.Label()
        Me.cbGrupos = New System.Windows.Forms.ComboBox()
        Me.GruposBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbTipo = New System.Windows.Forms.Label()
        Me.cbTipos = New System.Windows.Forms.ComboBox()
        Me.TiposBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbLinha = New System.Windows.Forms.Label()
        Me.cbLinhas = New System.Windows.Forms.ComboBox()
        Me.LinhasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbEpocas = New System.Windows.Forms.ComboBox()
        Me.EpocasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbItens = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btActualizar = New System.Windows.Forms.Button()
        Me.cbCores = New System.Windows.Forms.ComboBox()
        Me.CoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btSair = New System.Windows.Forms.Button()
        Me.dtpAte = New System.Windows.Forms.DateTimePicker()
        Me.dtpDe = New System.Windows.Forms.DateTimePicker()
        Me.gbFiltros = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpdeEntrada = New System.Windows.Forms.DateTimePicker()
        Me.dtpAteEntrada = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.c1Chart1 = New C1.Win.C1Chart.C1Chart()
        Me.ArmazensTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ArmazensTableAdapter()
        Me.GruposTableAdapter = New GirlRootName.GirlDataSetTableAdapters.GruposTableAdapter()
        Me.TiposTableAdapter = New GirlRootName.GirlDataSetTableAdapters.TiposTableAdapter()
        Me.LinhasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.LinhasTableAdapter()
        Me.EpocasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.EpocasTableAdapter()
        Me.CoresTableAdapter = New GirlRootName.GirlDataSetTableAdapters.CoresTableAdapter()
        Me.gbGrafico = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbRotacao = New System.Windows.Forms.GroupBox()
        Me.gbDados = New System.Windows.Forms.GroupBox()
        Me.rbMargem = New System.Windows.Forms.RadioButton()
        Me.rbQtd = New System.Windows.Forms.RadioButton()
        Me.rbValor = New System.Windows.Forms.RadioButton()
        Me.TerceirosTableAdapter = New GirlRootName.GirlDataSetTableAdapters.TerceirosTableAdapter()
        CType(Me.dgvEnviados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FornecedoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TerceirosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GruposBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TiposBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LinhasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EpocasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFiltros.SuspendLayout()
        CType(Me.c1Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGrafico.SuspendLayout()
        Me.gbRotacao.SuspendLayout()
        Me.gbDados.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvEnviados
        '
        Me.dgvEnviados.AllowUserToAddRows = False
        Me.dgvEnviados.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvEnviados.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEnviados.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvEnviados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEnviados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEnviados.Location = New System.Drawing.Point(4, 20)
        Me.dgvEnviados.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvEnviados.Name = "dgvEnviados"
        Me.dgvEnviados.ReadOnly = True
        Me.dgvEnviados.Size = New System.Drawing.Size(641, 401)
        Me.dgvEnviados.TabIndex = 0
        '
        'cbFornecedores
        '
        Me.cbFornecedores.DataSource = Me.FornecedoresBindingSource
        Me.cbFornecedores.DisplayMember = "NomeAbrev"
        Me.cbFornecedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFornecedores.FormattingEnabled = True
        Me.cbFornecedores.Location = New System.Drawing.Point(161, 202)
        Me.cbFornecedores.Margin = New System.Windows.Forms.Padding(4)
        Me.cbFornecedores.Name = "cbFornecedores"
        Me.cbFornecedores.Size = New System.Drawing.Size(428, 28)
        Me.cbFornecedores.TabIndex = 2
        Me.cbFornecedores.ValueMember = "TercID"
        '
        'FornecedoresBindingSource
        '
        Me.FornecedoresBindingSource.DataMember = "Terceiros"
        Me.FornecedoresBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TerceirosBindingSource
        '
        Me.TerceirosBindingSource.DataMember = "Terceiros"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 206)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fornecedor :"
        '
        'cbArmazens
        '
        Me.cbArmazens.DataSource = Me.ArmazensBindingSource
        Me.cbArmazens.DisplayMember = "ArmAbrev"
        Me.cbArmazens.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArmazens.FormattingEnabled = True
        Me.cbArmazens.Location = New System.Drawing.Point(160, 30)
        Me.cbArmazens.Margin = New System.Windows.Forms.Padding(4)
        Me.cbArmazens.Name = "cbArmazens"
        Me.cbArmazens.Size = New System.Drawing.Size(429, 28)
        Me.cbArmazens.TabIndex = 4
        Me.cbArmazens.ValueMember = "ArmazemID"
        '
        'ArmazensBindingSource
        '
        Me.ArmazensBindingSource.DataMember = "Armazens"
        Me.ArmazensBindingSource.DataSource = Me.GirlDataSet
        '
        'lbArmazem
        '
        Me.lbArmazem.AutoSize = True
        Me.lbArmazem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbArmazem.Location = New System.Drawing.Point(45, 33)
        Me.lbArmazem.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbArmazem.Name = "lbArmazem"
        Me.lbArmazem.Size = New System.Drawing.Size(100, 20)
        Me.lbArmazem.TabIndex = 5
        Me.lbArmazem.Text = "Armazem :"
        '
        'lbGrupo
        '
        Me.lbGrupo.AutoSize = True
        Me.lbGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGrupo.Location = New System.Drawing.Point(75, 68)
        Me.lbGrupo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbGrupo.Name = "lbGrupo"
        Me.lbGrupo.Size = New System.Drawing.Size(72, 20)
        Me.lbGrupo.TabIndex = 7
        Me.lbGrupo.Text = "Grupo :"
        '
        'cbGrupos
        '
        Me.cbGrupos.DataSource = Me.GruposBindingSource
        Me.cbGrupos.DisplayMember = "GrupoDesc"
        Me.cbGrupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGrupos.FormattingEnabled = True
        Me.cbGrupos.Location = New System.Drawing.Point(160, 64)
        Me.cbGrupos.Margin = New System.Windows.Forms.Padding(4)
        Me.cbGrupos.Name = "cbGrupos"
        Me.cbGrupos.Size = New System.Drawing.Size(429, 28)
        Me.cbGrupos.TabIndex = 6
        Me.cbGrupos.ValueMember = "GrupoID"
        '
        'GruposBindingSource
        '
        Me.GruposBindingSource.DataMember = "Grupos"
        Me.GruposBindingSource.DataSource = Me.GirlDataSet
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.Location = New System.Drawing.Point(88, 102)
        Me.lbTipo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(57, 20)
        Me.lbTipo.TabIndex = 9
        Me.lbTipo.Text = "Tipo :"
        '
        'cbTipos
        '
        Me.cbTipos.DataSource = Me.TiposBindingSource
        Me.cbTipos.DisplayMember = "DescrTipo"
        Me.cbTipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipos.FormattingEnabled = True
        Me.cbTipos.Location = New System.Drawing.Point(160, 98)
        Me.cbTipos.Margin = New System.Windows.Forms.Padding(4)
        Me.cbTipos.Name = "cbTipos"
        Me.cbTipos.Size = New System.Drawing.Size(429, 28)
        Me.cbTipos.TabIndex = 8
        Me.cbTipos.ValueMember = "TipoId"
        '
        'TiposBindingSource
        '
        Me.TiposBindingSource.DataMember = "Tipos"
        Me.TiposBindingSource.DataSource = Me.GirlDataSet
        '
        'lbLinha
        '
        Me.lbLinha.AutoSize = True
        Me.lbLinha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLinha.Location = New System.Drawing.Point(81, 137)
        Me.lbLinha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbLinha.Name = "lbLinha"
        Me.lbLinha.Size = New System.Drawing.Size(67, 20)
        Me.lbLinha.TabIndex = 11
        Me.lbLinha.Text = "Linha :"
        '
        'cbLinhas
        '
        Me.cbLinhas.DataSource = Me.LinhasBindingSource
        Me.cbLinhas.DisplayMember = "DescrLinha"
        Me.cbLinhas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLinhas.FormattingEnabled = True
        Me.cbLinhas.Location = New System.Drawing.Point(160, 133)
        Me.cbLinhas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbLinhas.Name = "cbLinhas"
        Me.cbLinhas.Size = New System.Drawing.Size(429, 28)
        Me.cbLinhas.TabIndex = 10
        Me.cbLinhas.ValueMember = "LinhaID"
        '
        'LinhasBindingSource
        '
        Me.LinhasBindingSource.DataMember = "Linhas"
        Me.LinhasBindingSource.DataSource = Me.GirlDataSet
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(71, 171)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Epoca :"
        '
        'cbEpocas
        '
        Me.cbEpocas.DataSource = Me.EpocasBindingSource
        Me.cbEpocas.DisplayMember = "EpocaDescr"
        Me.cbEpocas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEpocas.FormattingEnabled = True
        Me.cbEpocas.Location = New System.Drawing.Point(160, 167)
        Me.cbEpocas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbEpocas.Name = "cbEpocas"
        Me.cbEpocas.Size = New System.Drawing.Size(429, 28)
        Me.cbEpocas.TabIndex = 12
        Me.cbEpocas.ValueMember = "EpocaID"
        '
        'EpocasBindingSource
        '
        Me.EpocasBindingSource.DataMember = "Epocas"
        Me.EpocasBindingSource.DataSource = Me.GirlDataSet
        '
        'cbItens
        '
        Me.cbItens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbItens.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbItens.FormattingEnabled = True
        Me.cbItens.Items.AddRange(New Object() {"Armazens", "Cores", "Grupos", "Tipos", "Linhas", "Alturas", "Epocas", "Pr.Etiqueta", "Fornecedores", "Tamanhos"})
        Me.cbItens.Location = New System.Drawing.Point(139, 9)
        Me.cbItens.Margin = New System.Windows.Forms.Padding(4)
        Me.cbItens.Name = "cbItens"
        Me.cbItens.Size = New System.Drawing.Size(351, 33)
        Me.cbItens.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Opção :"
        '
        'btActualizar
        '
        Me.btActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.btActualizar.Location = New System.Drawing.Point(1063, 7)
        Me.btActualizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Size = New System.Drawing.Size(189, 41)
        Me.btActualizar.TabIndex = 15
        Me.btActualizar.Text = "Actualizar"
        Me.btActualizar.UseVisualStyleBackColor = True
        '
        'cbCores
        '
        Me.cbCores.DataSource = Me.CoresBindingSource
        Me.cbCores.DisplayMember = "DescrCor"
        Me.cbCores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCores.FormattingEnabled = True
        Me.cbCores.Location = New System.Drawing.Point(161, 236)
        Me.cbCores.Margin = New System.Windows.Forms.Padding(4)
        Me.cbCores.Name = "cbCores"
        Me.cbCores.Size = New System.Drawing.Size(428, 28)
        Me.cbCores.TabIndex = 2
        Me.cbCores.ValueMember = "CorID"
        '
        'CoresBindingSource
        '
        Me.CoresBindingSource.DataMember = "Cores"
        Me.CoresBindingSource.DataSource = Me.GirlDataSet
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(99, 240)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cor :"
        '
        'btSair
        '
        Me.btSair.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.btSair.Location = New System.Drawing.Point(1260, 7)
        Me.btSair.Margin = New System.Windows.Forms.Padding(4)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(189, 41)
        Me.btSair.TabIndex = 16
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = True
        '
        'dtpAte
        '
        Me.dtpAte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAte.Location = New System.Drawing.Point(424, 32)
        Me.dtpAte.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpAte.Name = "dtpAte"
        Me.dtpAte.Size = New System.Drawing.Size(179, 29)
        Me.dtpAte.TabIndex = 17
        '
        'dtpDe
        '
        Me.dtpDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDe.Location = New System.Drawing.Point(161, 31)
        Me.dtpDe.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDe.Name = "dtpDe"
        Me.dtpDe.Size = New System.Drawing.Size(179, 29)
        Me.dtpDe.TabIndex = 18
        '
        'gbFiltros
        '
        Me.gbFiltros.Controls.Add(Me.Label7)
        Me.gbFiltros.Controls.Add(Me.dtpdeEntrada)
        Me.gbFiltros.Controls.Add(Me.dtpAteEntrada)
        Me.gbFiltros.Controls.Add(Me.Label8)
        Me.gbFiltros.Controls.Add(Me.Label6)
        Me.gbFiltros.Controls.Add(Me.cbEpocas)
        Me.gbFiltros.Controls.Add(Me.lbLinha)
        Me.gbFiltros.Controls.Add(Me.cbLinhas)
        Me.gbFiltros.Controls.Add(Me.lbTipo)
        Me.gbFiltros.Controls.Add(Me.cbTipos)
        Me.gbFiltros.Controls.Add(Me.lbGrupo)
        Me.gbFiltros.Controls.Add(Me.cbGrupos)
        Me.gbFiltros.Controls.Add(Me.lbArmazem)
        Me.gbFiltros.Controls.Add(Me.cbArmazens)
        Me.gbFiltros.Controls.Add(Me.Label2)
        Me.gbFiltros.Controls.Add(Me.cbCores)
        Me.gbFiltros.Controls.Add(Me.Label1)
        Me.gbFiltros.Controls.Add(Me.cbFornecedores)
        Me.gbFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiltros.Location = New System.Drawing.Point(16, 55)
        Me.gbFiltros.Margin = New System.Windows.Forms.Padding(4)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Padding = New System.Windows.Forms.Padding(4)
        Me.gbFiltros.Size = New System.Drawing.Size(649, 320)
        Me.gbFiltros.TabIndex = 19
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Filtros"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(352, 277)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 24)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Até :"
        Me.Label7.Visible = False
        '
        'dtpdeEntrada
        '
        Me.dtpdeEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdeEntrada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdeEntrada.Location = New System.Drawing.Point(161, 272)
        Me.dtpdeEntrada.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpdeEntrada.Name = "dtpdeEntrada"
        Me.dtpdeEntrada.Size = New System.Drawing.Size(179, 29)
        Me.dtpdeEntrada.TabIndex = 25
        Me.dtpdeEntrada.Visible = False
        '
        'dtpAteEntrada
        '
        Me.dtpAteEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAteEntrada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAteEntrada.Location = New System.Drawing.Point(411, 273)
        Me.dtpAteEntrada.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpAteEntrada.Name = "dtpAteEntrada"
        Me.dtpAteEntrada.Size = New System.Drawing.Size(179, 29)
        Me.dtpAteEntrada.TabIndex = 24
        Me.dtpAteEntrada.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 277)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 24)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Entrada De :"
        Me.Label8.Visible = False
        '
        'c1Chart1
        '
        Me.c1Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.c1Chart1.DataSource = Me.GirlDataSet
        Me.c1Chart1.Location = New System.Drawing.Point(4, 70)
        Me.c1Chart1.Margin = New System.Windows.Forms.Padding(4)
        Me.c1Chart1.Name = "c1Chart1"
        Me.c1Chart1.PropBag = resources.GetString("c1Chart1.PropBag")
        Me.c1Chart1.Size = New System.Drawing.Size(720, 682)
        Me.c1Chart1.TabIndex = 21
        '
        'ArmazensTableAdapter
        '
        Me.ArmazensTableAdapter.ClearBeforeFill = True
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
        'EpocasTableAdapter
        '
        Me.EpocasTableAdapter.ClearBeforeFill = True
        '
        'CoresTableAdapter
        '
        Me.CoresTableAdapter.ClearBeforeFill = True
        '
        'gbGrafico
        '
        Me.gbGrafico.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbGrafico.Controls.Add(Me.Label5)
        Me.gbGrafico.Controls.Add(Me.c1Chart1)
        Me.gbGrafico.Controls.Add(Me.dtpDe)
        Me.gbGrafico.Controls.Add(Me.dtpAte)
        Me.gbGrafico.Controls.Add(Me.Label4)
        Me.gbGrafico.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGrafico.Location = New System.Drawing.Point(708, 55)
        Me.gbGrafico.Margin = New System.Windows.Forms.Padding(4)
        Me.gbGrafico.Name = "gbGrafico"
        Me.gbGrafico.Padding = New System.Windows.Forms.Padding(4)
        Me.gbGrafico.Size = New System.Drawing.Size(732, 756)
        Me.gbGrafico.TabIndex = 22
        Me.gbGrafico.TabStop = False
        Me.gbGrafico.Text = "Vendas entre Datas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(368, 36)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 24)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Até :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(109, 34)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 24)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "De :"
        '
        'gbRotacao
        '
        Me.gbRotacao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbRotacao.Controls.Add(Me.dgvEnviados)
        Me.gbRotacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRotacao.Location = New System.Drawing.Point(16, 383)
        Me.gbRotacao.Margin = New System.Windows.Forms.Padding(4)
        Me.gbRotacao.Name = "gbRotacao"
        Me.gbRotacao.Padding = New System.Windows.Forms.Padding(4)
        Me.gbRotacao.Size = New System.Drawing.Size(649, 425)
        Me.gbRotacao.TabIndex = 23
        Me.gbRotacao.TabStop = False
        Me.gbRotacao.Text = "Rotação Compras"
        '
        'gbDados
        '
        Me.gbDados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDados.Controls.Add(Me.rbMargem)
        Me.gbDados.Controls.Add(Me.rbQtd)
        Me.gbDados.Controls.Add(Me.rbValor)
        Me.gbDados.Location = New System.Drawing.Point(708, 5)
        Me.gbDados.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDados.Name = "gbDados"
        Me.gbDados.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDados.Size = New System.Drawing.Size(300, 55)
        Me.gbDados.TabIndex = 24
        Me.gbDados.TabStop = False
        Me.gbDados.Text = "Dados a Apresentar"
        Me.gbDados.Visible = False
        '
        'rbMargem
        '
        Me.rbMargem.AutoSize = True
        Me.rbMargem.Location = New System.Drawing.Point(207, 23)
        Me.rbMargem.Margin = New System.Windows.Forms.Padding(4)
        Me.rbMargem.Name = "rbMargem"
        Me.rbMargem.Size = New System.Drawing.Size(80, 21)
        Me.rbMargem.TabIndex = 2
        Me.rbMargem.TabStop = True
        Me.rbMargem.Text = "Margem"
        Me.rbMargem.UseVisualStyleBackColor = True
        '
        'rbQtd
        '
        Me.rbQtd.AutoSize = True
        Me.rbQtd.Location = New System.Drawing.Point(112, 23)
        Me.rbQtd.Margin = New System.Windows.Forms.Padding(4)
        Me.rbQtd.Name = "rbQtd"
        Me.rbQtd.Size = New System.Drawing.Size(52, 21)
        Me.rbQtd.TabIndex = 1
        Me.rbQtd.TabStop = True
        Me.rbQtd.Text = "Qtd"
        Me.rbQtd.UseVisualStyleBackColor = True
        '
        'rbValor
        '
        Me.rbValor.AutoSize = True
        Me.rbValor.Location = New System.Drawing.Point(8, 23)
        Me.rbValor.Margin = New System.Windows.Forms.Padding(4)
        Me.rbValor.Name = "rbValor"
        Me.rbValor.Size = New System.Drawing.Size(62, 21)
        Me.rbValor.TabIndex = 0
        Me.rbValor.TabStop = True
        Me.rbValor.Text = "Valor"
        Me.rbValor.UseVisualStyleBackColor = True
        '
        'TerceirosTableAdapter
        '
        Me.TerceirosTableAdapter.ClearBeforeFill = True
        '
        'frmAnaliseVendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1456, 812)
        Me.Controls.Add(Me.gbDados)
        Me.Controls.Add(Me.gbGrafico)
        Me.Controls.Add(Me.gbFiltros)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.btActualizar)
        Me.Controls.Add(Me.cbItens)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbRotacao)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmAnaliseVendas"
        Me.Text = "frmAnaliseVendas"
        CType(Me.dgvEnviados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FornecedoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TerceirosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GruposBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TiposBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LinhasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EpocasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        CType(Me.c1Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGrafico.ResumeLayout(False)
        Me.gbGrafico.PerformLayout()
        Me.gbRotacao.ResumeLayout(False)
        Me.gbDados.ResumeLayout(False)
        Me.gbDados.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvEnviados As System.Windows.Forms.DataGridView
    Friend WithEvents cbFornecedores As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents FornecedoresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cbArmazens As System.Windows.Forms.ComboBox
    Friend WithEvents lbArmazem As System.Windows.Forms.Label
    Friend WithEvents lbGrupo As System.Windows.Forms.Label
    Friend WithEvents cbGrupos As System.Windows.Forms.ComboBox
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbTipos As System.Windows.Forms.ComboBox
    Friend WithEvents lbLinha As System.Windows.Forms.Label
    Friend WithEvents cbLinhas As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbEpocas As System.Windows.Forms.ComboBox
    Friend WithEvents ArmazensBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ArmazensTableAdapter As GirlRootName.GirlDataSetTableAdapters.ArmazensTableAdapter
    Friend WithEvents GruposBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GruposTableAdapter As GirlRootName.GirlDataSetTableAdapters.GruposTableAdapter
    Friend WithEvents TiposBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TiposTableAdapter As GirlRootName.GirlDataSetTableAdapters.TiposTableAdapter
    Friend WithEvents LinhasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LinhasTableAdapter As GirlRootName.GirlDataSetTableAdapters.LinhasTableAdapter
    Friend WithEvents EpocasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EpocasTableAdapter As GirlRootName.GirlDataSetTableAdapters.EpocasTableAdapter
    Friend WithEvents cbItens As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btActualizar As System.Windows.Forms.Button
    Friend WithEvents cbCores As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CoresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CoresTableAdapter As GirlRootName.GirlDataSetTableAdapters.CoresTableAdapter
    Friend WithEvents btSair As System.Windows.Forms.Button
    Friend WithEvents dtpAte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents c1Chart1 As C1.Win.C1Chart.C1Chart
    Friend WithEvents gbGrafico As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbRotacao As System.Windows.Forms.GroupBox
    Friend WithEvents gbDados As System.Windows.Forms.GroupBox
    Friend WithEvents rbValor As System.Windows.Forms.RadioButton
    Friend WithEvents rbMargem As System.Windows.Forms.RadioButton
    Friend WithEvents rbQtd As System.Windows.Forms.RadioButton
    Friend WithEvents TerceirosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TerceirosTableAdapter As GirlRootName.GirlDataSetTableAdapters.TerceirosTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpdeEntrada As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAteEntrada As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
