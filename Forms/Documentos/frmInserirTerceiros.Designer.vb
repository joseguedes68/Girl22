<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInserirTerceiros
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbCodigo = New System.Windows.Forms.TextBox()
        Me.lbCodigo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbNome = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbMorada = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbNomeAbrev = New System.Windows.Forms.TextBox()
        Me.cbTipoTerc = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbNIF = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbLocalidade = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbTelefone = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbContacto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbMovel = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbObs = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbSite = New System.Windows.Forms.TextBox()
        Me.cbPaisID = New System.Windows.Forms.ComboBox()
        Me.btGravar = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.dgvListaTerc = New System.Windows.Forms.DataGridView()
        Me.TercID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeAbrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TerceirosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.btNovo = New System.Windows.Forms.Button()
        Me.btApagar = New System.Windows.Forms.Button()
        Me.TerceirosTableAdapter = New GirlRootName.GirlDataSetTableAdapters.TerceirosTableAdapter()
        Me.lbNifEspanha = New System.Windows.Forms.Label()
        Me.tbCodPostal = New System.Windows.Forms.MaskedTextBox()
        CType(Me.dgvListaTerc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TerceirosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbCodigo
        '
        Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigo.Location = New System.Drawing.Point(136, 21)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.Size = New System.Drawing.Size(142, 26)
        Me.tbCodigo.TabIndex = 1
        '
        'lbCodigo
        '
        Me.lbCodigo.AutoSize = True
        Me.lbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCodigo.Location = New System.Drawing.Point(61, 23)
        Me.lbCodigo.Name = "lbCodigo"
        Me.lbCodigo.Size = New System.Drawing.Size(75, 25)
        Me.lbCodigo.TabIndex = 1
        Me.lbCodigo.Text = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(307, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo Terceiro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(70, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nome"
        '
        'tbNome
        '
        Me.tbNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNome.Location = New System.Drawing.Point(136, 63)
        Me.tbNome.Name = "tbNome"
        Me.tbNome.Size = New System.Drawing.Size(495, 26)
        Me.tbNome.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 25)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Codigo Postal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 25)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Morada"
        '
        'tbMorada
        '
        Me.tbMorada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMorada.Location = New System.Drawing.Point(136, 141)
        Me.tbMorada.Name = "tbMorada"
        Me.tbMorada.Size = New System.Drawing.Size(495, 26)
        Me.tbMorada.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Nome Abr."
        '
        'tbNomeAbrev
        '
        Me.tbNomeAbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNomeAbrev.Location = New System.Drawing.Point(136, 102)
        Me.tbNomeAbrev.Name = "tbNomeAbrev"
        Me.tbNomeAbrev.Size = New System.Drawing.Size(495, 26)
        Me.tbNomeAbrev.TabIndex = 4
        '
        'cbTipoTerc
        '
        Me.cbTipoTerc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoTerc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoTerc.FormattingEnabled = True
        Me.cbTipoTerc.Location = New System.Drawing.Point(433, 21)
        Me.cbTipoTerc.Name = "cbTipoTerc"
        Me.cbTipoTerc.Size = New System.Drawing.Size(199, 28)
        Me.cbTipoTerc.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(359, 219)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 25)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "NIF"
        '
        'tbNIF
        '
        Me.tbNIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNIF.Location = New System.Drawing.Point(407, 219)
        Me.tbNIF.Name = "tbNIF"
        Me.tbNIF.Size = New System.Drawing.Size(224, 26)
        Me.tbNIF.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(84, 221)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 25)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Pais"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(300, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 25)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Localidade"
        '
        'tbLocalidade
        '
        Me.tbLocalidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLocalidade.Location = New System.Drawing.Point(407, 180)
        Me.tbLocalidade.MaxLength = 20
        Me.tbLocalidade.Name = "tbLocalidade"
        Me.tbLocalidade.Size = New System.Drawing.Size(224, 26)
        Me.tbLocalidade.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(47, 322)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 25)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Telefone"
        '
        'tbTelefone
        '
        Me.tbTelefone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTelefone.Location = New System.Drawing.Point(136, 322)
        Me.tbTelefone.Name = "tbTelefone"
        Me.tbTelefone.Size = New System.Drawing.Size(207, 26)
        Me.tbTelefone.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(43, 281)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 25)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Contacto"
        '
        'tbContacto
        '
        Me.tbContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbContacto.Location = New System.Drawing.Point(136, 280)
        Me.tbContacto.Name = "tbContacto"
        Me.tbContacto.Size = New System.Drawing.Size(495, 26)
        Me.tbContacto.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(73, 360)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 25)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Email"
        '
        'tbEmail
        '
        Me.tbEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEmail.Location = New System.Drawing.Point(136, 361)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(228, 26)
        Me.tbEmail.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(356, 322)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 25)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Telemóvel"
        '
        'tbMovel
        '
        Me.tbMovel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMovel.Location = New System.Drawing.Point(456, 322)
        Me.tbMovel.Name = "tbMovel"
        Me.tbMovel.Size = New System.Drawing.Size(175, 26)
        Me.tbMovel.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(85, 401)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 25)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Obs"
        '
        'tbObs
        '
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.Location = New System.Drawing.Point(136, 401)
        Me.tbObs.Name = "tbObs"
        Me.tbObs.Size = New System.Drawing.Size(495, 26)
        Me.tbObs.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(385, 361)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 25)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Site"
        '
        'tbSite
        '
        Me.tbSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSite.Location = New System.Drawing.Point(435, 361)
        Me.tbSite.Name = "tbSite"
        Me.tbSite.Size = New System.Drawing.Size(196, 26)
        Me.tbSite.TabIndex = 14
        '
        'cbPaisID
        '
        Me.cbPaisID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPaisID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPaisID.FormattingEnabled = True
        Me.cbPaisID.Location = New System.Drawing.Point(136, 219)
        Me.cbPaisID.Name = "cbPaisID"
        Me.cbPaisID.Size = New System.Drawing.Size(215, 28)
        Me.cbPaisID.TabIndex = 8
        '
        'btGravar
        '
        Me.btGravar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGravar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGravar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGravar.Location = New System.Drawing.Point(1050, 9)
        Me.btGravar.Name = "btGravar"
        Me.btGravar.Size = New System.Drawing.Size(135, 33)
        Me.btGravar.TabIndex = 31
        Me.btGravar.Text = "Gravar"
        Me.btGravar.UseVisualStyleBackColor = False
        '
        'btFechar
        '
        Me.btFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btFechar.Location = New System.Drawing.Point(1199, 9)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(135, 33)
        Me.btFechar.TabIndex = 32
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'dgvListaTerc
        '
        Me.dgvListaTerc.AllowUserToAddRows = False
        Me.dgvListaTerc.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvListaTerc.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListaTerc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListaTerc.AutoGenerateColumns = False
        Me.dgvListaTerc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaTerc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TercID, Me.NomeAbrev, Me.Nome})
        Me.dgvListaTerc.DataSource = Me.TerceirosBindingSource
        Me.dgvListaTerc.Location = New System.Drawing.Point(656, 63)
        Me.dgvListaTerc.MultiSelect = False
        Me.dgvListaTerc.Name = "dgvListaTerc"
        Me.dgvListaTerc.ReadOnly = True
        Me.dgvListaTerc.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvListaTerc.Size = New System.Drawing.Size(769, 338)
        Me.dgvListaTerc.TabIndex = 33
        '
        'TercID
        '
        Me.TercID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TercID.DataPropertyName = "TercID"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TercID.DefaultCellStyle = DataGridViewCellStyle2
        Me.TercID.HeaderText = "Código"
        Me.TercID.Name = "TercID"
        Me.TercID.ReadOnly = True
        Me.TercID.Width = 80
        '
        'NomeAbrev
        '
        Me.NomeAbrev.DataPropertyName = "NomeAbrev"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NomeAbrev.DefaultCellStyle = DataGridViewCellStyle3
        Me.NomeAbrev.HeaderText = "Abreviado"
        Me.NomeAbrev.Name = "NomeAbrev"
        Me.NomeAbrev.ReadOnly = True
        Me.NomeAbrev.Width = 180
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Nome"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Nome.DefaultCellStyle = DataGridViewCellStyle4
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 350
        '
        'TerceirosBindingSource
        '
        Me.TerceirosBindingSource.DataMember = "Terceiros"
        Me.TerceirosBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btNovo
        '
        Me.btNovo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btNovo.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btNovo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNovo.Location = New System.Drawing.Point(903, 9)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(135, 33)
        Me.btNovo.TabIndex = 34
        Me.btNovo.Text = "Novo"
        Me.btNovo.UseVisualStyleBackColor = False
        '
        'btApagar
        '
        Me.btApagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btApagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btApagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btApagar.Location = New System.Drawing.Point(758, 9)
        Me.btApagar.Name = "btApagar"
        Me.btApagar.Size = New System.Drawing.Size(135, 33)
        Me.btApagar.TabIndex = 35
        Me.btApagar.Text = "Apagar"
        Me.btApagar.UseVisualStyleBackColor = False
        '
        'TerceirosTableAdapter
        '
        Me.TerceirosTableAdapter.ClearBeforeFill = True
        '
        'lbNifEspanha
        '
        Me.lbNifEspanha.AutoSize = True
        Me.lbNifEspanha.Location = New System.Drawing.Point(285, 250)
        Me.lbNifEspanha.Name = "lbNifEspanha"
        Me.lbNifEspanha.Size = New System.Drawing.Size(346, 17)
        Me.lbNifEspanha.TabIndex = 82
        Me.lbNifEspanha.Text = "Nota: Formato do NIF de Espanha: B99999999"
        Me.lbNifEspanha.Visible = False
        '
        'tbCodPostal
        '
        Me.tbCodPostal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.tbCodPostal.Location = New System.Drawing.Point(139, 180)
        Me.tbCodPostal.Mask = "0000-000"
        Me.tbCodPostal.Name = "tbCodPostal"
        Me.tbCodPostal.Size = New System.Drawing.Size(155, 26)
        Me.tbCodPostal.TabIndex = 81
        '
        'frmInserirTerceiros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1437, 463)
        Me.Controls.Add(Me.lbNifEspanha)
        Me.Controls.Add(Me.tbCodPostal)
        Me.Controls.Add(Me.btApagar)
        Me.Controls.Add(Me.btNovo)
        Me.Controls.Add(Me.dgvListaTerc)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.btGravar)
        Me.Controls.Add(Me.cbPaisID)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.tbObs)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.tbSite)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tbEmail)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tbMovel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbTelefone)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tbContacto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbNIF)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbLocalidade)
        Me.Controls.Add(Me.cbTipoTerc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbMorada)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbNomeAbrev)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbNome)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbCodigo)
        Me.Controls.Add(Me.tbCodigo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmInserirTerceiros"
        Me.Text = "frmInserirTerceiros"
        CType(Me.dgvListaTerc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TerceirosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lbCodigo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbNome As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbMorada As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbNomeAbrev As System.Windows.Forms.TextBox
    Friend WithEvents cbTipoTerc As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbNIF As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbLocalidade As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbTelefone As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbMovel As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbObs As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbSite As System.Windows.Forms.TextBox
    Friend WithEvents cbPaisID As System.Windows.Forms.ComboBox
    Friend WithEvents btGravar As System.Windows.Forms.Button
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents TerceirosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TerceirosTableAdapter As GirlRootName.GirlDataSetTableAdapters.TerceirosTableAdapter
    Friend WithEvents btNovo As System.Windows.Forms.Button
    Friend WithEvents btApagar As System.Windows.Forms.Button
    Friend WithEvents TercID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeAbrev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvListaTerc As System.Windows.Forms.DataGridView
    Friend WithEvents lbNifEspanha As Label
    Friend WithEvents tbCodPostal As MaskedTextBox
End Class
