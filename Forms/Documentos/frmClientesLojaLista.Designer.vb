<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientesLojaLista
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNif = New System.Windows.Forms.TextBox()
        Me.btGravar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCodPostal = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLocalidade = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtMorada = New System.Windows.Forms.TextBox()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.txtTelemovel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvListaClientes = New System.Windows.Forms.DataGridView()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telemovel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Localidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Morada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodPostal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Obs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArmOrig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClienteLojaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaisID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DistritoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDClienteLoja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientesLojaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefone = New System.Windows.Forms.TextBox()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.txtCodPostal = New System.Windows.Forms.MaskedTextBox()
        Me.btPesquisar = New System.Windows.Forms.Button()
        Me.ClientesLojaTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ClientesLojaTableAdapter()
        CType(Me.dgvListaClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientesLojaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NIF:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNif
        '
        Me.txtNif.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNif.Location = New System.Drawing.Point(123, 16)
        Me.txtNif.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNif.MaxLength = 15
        Me.txtNif.Name = "txtNif"
        Me.txtNif.Size = New System.Drawing.Size(152, 26)
        Me.txtNif.TabIndex = 1
        '
        'btGravar
        '
        Me.btGravar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGravar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGravar.Enabled = False
        Me.btGravar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btGravar.Location = New System.Drawing.Point(675, 18)
        Me.btGravar.Margin = New System.Windows.Forms.Padding(4)
        Me.btGravar.Name = "btGravar"
        Me.btGravar.Size = New System.Drawing.Size(169, 54)
        Me.btGravar.TabIndex = 12
        Me.btGravar.Text = "Gravar / Ok"
        Me.btGravar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(49, 192)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 23)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Obs:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodPostal
        '
        Me.lblCodPostal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodPostal.Location = New System.Drawing.Point(24, 123)
        Me.lblCodPostal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodPostal.Name = "lblCodPostal"
        Me.lblCodPostal.Size = New System.Drawing.Size(91, 23)
        Me.lblCodPostal.TabIndex = 52
        Me.lblCodPostal.Text = "CPostal:"
        Me.lblCodPostal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(263, 158)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 23)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Email:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 89)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 23)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Morada:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(44, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 23)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Nome:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLocalidade
        '
        Me.txtLocalidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocalidade.Location = New System.Drawing.Point(268, 121)
        Me.txtLocalidade.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLocalidade.MaxLength = 20
        Me.txtLocalidade.Name = "txtLocalidade"
        Me.txtLocalidade.Size = New System.Drawing.Size(332, 26)
        Me.txtLocalidade.TabIndex = 6
        '
        'txtNome
        '
        Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNome.Location = New System.Drawing.Point(123, 52)
        Me.txtNome.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNome.MaxLength = 80
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(477, 26)
        Me.txtNome.TabIndex = 3
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(341, 155)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmail.MaxLength = 60
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(259, 26)
        Me.txtEmail.TabIndex = 8
        '
        'txtMorada
        '
        Me.txtMorada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMorada.Location = New System.Drawing.Point(123, 86)
        Me.txtMorada.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMorada.MaxLength = 160
        Me.txtMorada.Name = "txtMorada"
        Me.txtMorada.Size = New System.Drawing.Size(477, 26)
        Me.txtMorada.TabIndex = 4
        '
        'txtObs
        '
        Me.txtObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(123, 190)
        Me.txtObs.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObs.MaxLength = 1000
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObs.Size = New System.Drawing.Size(477, 29)
        Me.txtObs.TabIndex = 9
        '
        'txtTelemovel
        '
        Me.txtTelemovel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelemovel.Location = New System.Drawing.Point(449, 16)
        Me.txtTelemovel.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelemovel.MaxLength = 20
        Me.txtTelemovel.Name = "txtTelemovel"
        Me.txtTelemovel.Size = New System.Drawing.Size(151, 26)
        Me.txtTelemovel.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(333, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 23)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Telemóvel:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvListaClientes
        '
        Me.dgvListaClientes.AllowUserToAddRows = False
        Me.dgvListaClientes.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvListaClientes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListaClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListaClientes.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListaClientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nome, Me.NIF, Me.Telemovel, Me.Localidade, Me.Email, Me.Morada, Me.CodPostal, Me.Obs, Me.Telefone, Me.ArmOrig, Me.ClienteLojaID, Me.PaisID, Me.DistritoID, Me.IDClienteLoja})
        Me.dgvListaClientes.DataSource = Me.ClientesLojaBindingSource
        Me.dgvListaClientes.Location = New System.Drawing.Point(0, 247)
        Me.dgvListaClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvListaClientes.MultiSelect = False
        Me.dgvListaClientes.Name = "dgvListaClientes"
        Me.dgvListaClientes.ReadOnly = True
        Me.dgvListaClientes.RowHeadersWidth = 51
        Me.dgvListaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListaClientes.Size = New System.Drawing.Size(887, 322)
        Me.dgvListaClientes.TabIndex = 69
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Nome"
        Me.Nome.HeaderText = "Nome"
        Me.Nome.MinimumWidth = 6
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 120
        '
        'NIF
        '
        Me.NIF.DataPropertyName = "NIF"
        Me.NIF.HeaderText = "NIF"
        Me.NIF.MinimumWidth = 6
        Me.NIF.Name = "NIF"
        Me.NIF.ReadOnly = True
        Me.NIF.Width = 125
        '
        'Telemovel
        '
        Me.Telemovel.DataPropertyName = "Telemovel"
        Me.Telemovel.HeaderText = "Telemovel"
        Me.Telemovel.MinimumWidth = 6
        Me.Telemovel.Name = "Telemovel"
        Me.Telemovel.ReadOnly = True
        Me.Telemovel.Width = 125
        '
        'Localidade
        '
        Me.Localidade.DataPropertyName = "Localidade"
        Me.Localidade.HeaderText = "Localidade"
        Me.Localidade.MinimumWidth = 6
        Me.Localidade.Name = "Localidade"
        Me.Localidade.ReadOnly = True
        Me.Localidade.Width = 125
        '
        'Email
        '
        Me.Email.DataPropertyName = "Email"
        Me.Email.HeaderText = "Email"
        Me.Email.MinimumWidth = 6
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 125
        '
        'Morada
        '
        Me.Morada.DataPropertyName = "Morada"
        Me.Morada.HeaderText = "Morada"
        Me.Morada.MinimumWidth = 6
        Me.Morada.Name = "Morada"
        Me.Morada.ReadOnly = True
        Me.Morada.Width = 125
        '
        'CodPostal
        '
        Me.CodPostal.DataPropertyName = "CodPostal"
        Me.CodPostal.HeaderText = "CodPostal"
        Me.CodPostal.MinimumWidth = 6
        Me.CodPostal.Name = "CodPostal"
        Me.CodPostal.ReadOnly = True
        Me.CodPostal.Width = 125
        '
        'Obs
        '
        Me.Obs.DataPropertyName = "Obs"
        Me.Obs.HeaderText = "Obs"
        Me.Obs.MinimumWidth = 6
        Me.Obs.Name = "Obs"
        Me.Obs.ReadOnly = True
        Me.Obs.Width = 125
        '
        'Telefone
        '
        Me.Telefone.DataPropertyName = "Telefone"
        Me.Telefone.HeaderText = "Telefone"
        Me.Telefone.MinimumWidth = 6
        Me.Telefone.Name = "Telefone"
        Me.Telefone.ReadOnly = True
        Me.Telefone.Width = 125
        '
        'ArmOrig
        '
        Me.ArmOrig.DataPropertyName = "ArmOrig"
        Me.ArmOrig.HeaderText = "Loja"
        Me.ArmOrig.MinimumWidth = 6
        Me.ArmOrig.Name = "ArmOrig"
        Me.ArmOrig.ReadOnly = True
        Me.ArmOrig.Width = 125
        '
        'ClienteLojaID
        '
        Me.ClienteLojaID.DataPropertyName = "ClienteLojaID"
        Me.ClienteLojaID.HeaderText = "Id"
        Me.ClienteLojaID.MinimumWidth = 6
        Me.ClienteLojaID.Name = "ClienteLojaID"
        Me.ClienteLojaID.ReadOnly = True
        Me.ClienteLojaID.Width = 125
        '
        'PaisID
        '
        Me.PaisID.DataPropertyName = "PaisID"
        Me.PaisID.HeaderText = "Pais"
        Me.PaisID.MinimumWidth = 6
        Me.PaisID.Name = "PaisID"
        Me.PaisID.ReadOnly = True
        Me.PaisID.Visible = False
        Me.PaisID.Width = 125
        '
        'DistritoID
        '
        Me.DistritoID.DataPropertyName = "DistritoID"
        Me.DistritoID.HeaderText = "Distrito"
        Me.DistritoID.MinimumWidth = 6
        Me.DistritoID.Name = "DistritoID"
        Me.DistritoID.ReadOnly = True
        Me.DistritoID.Visible = False
        Me.DistritoID.Width = 125
        '
        'IDClienteLoja
        '
        Me.IDClienteLoja.DataPropertyName = "IDClienteLoja"
        Me.IDClienteLoja.HeaderText = "IDClienteLoja"
        Me.IDClienteLoja.MinimumWidth = 6
        Me.IDClienteLoja.Name = "IDClienteLoja"
        Me.IDClienteLoja.ReadOnly = True
        Me.IDClienteLoja.Visible = False
        Me.IDClienteLoja.Width = 125
        '
        'ClientesLojaBindingSource
        '
        Me.ClientesLojaBindingSource.DataMember = "ClientesLoja"
        Me.ClientesLojaBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 158)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 23)
        Me.Label7.TabIndex = 75
        Me.Label7.Text = "Telefone:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTelefone
        '
        Me.txtTelefone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefone.Location = New System.Drawing.Point(123, 155)
        Me.txtTelefone.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelefone.MaxLength = 20
        Me.txtTelefone.Name = "txtTelefone"
        Me.txtTelefone.Size = New System.Drawing.Size(136, 26)
        Me.txtTelefone.TabIndex = 7
        '
        'btCancelar
        '
        Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btCancelar.Location = New System.Drawing.Point(675, 80)
        Me.btCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(169, 54)
        Me.btCancelar.TabIndex = 79
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'txtCodPostal
        '
        Me.txtCodPostal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtCodPostal.Location = New System.Drawing.Point(122, 121)
        Me.txtCodPostal.Mask = "0000-000"
        Me.txtCodPostal.Name = "txtCodPostal"
        Me.txtCodPostal.Size = New System.Drawing.Size(139, 26)
        Me.txtCodPostal.TabIndex = 80
        '
        'btPesquisar
        '
        Me.btPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btPesquisar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btPesquisar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btPesquisar.Location = New System.Drawing.Point(675, 142)
        Me.btPesquisar.Margin = New System.Windows.Forms.Padding(4)
        Me.btPesquisar.Name = "btPesquisar"
        Me.btPesquisar.Size = New System.Drawing.Size(169, 54)
        Me.btPesquisar.TabIndex = 81
        Me.btPesquisar.Text = "Pesquisar"
        Me.btPesquisar.UseVisualStyleBackColor = False
        '
        'ClientesLojaTableAdapter
        '
        Me.ClientesLojaTableAdapter.ClearBeforeFill = True
        '
        'frmClientesLojaLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 570)
        Me.Controls.Add(Me.btPesquisar)
        Me.Controls.Add(Me.txtCodPostal)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTelefone)
        Me.Controls.Add(Me.dgvListaClientes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTelemovel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNif)
        Me.Controls.Add(Me.btGravar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblCodPostal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLocalidade)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtMorada)
        Me.Controls.Add(Me.txtObs)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmClientesLojaLista"
        Me.Text = "ClientesLojaLista"
        CType(Me.dgvListaClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientesLojaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNif As System.Windows.Forms.TextBox
    Friend WithEvents btGravar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCodPostal As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLocalidade As System.Windows.Forms.TextBox
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtMorada As System.Windows.Forms.TextBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents txtTelemovel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvListaClientes As System.Windows.Forms.DataGridView
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents ClientesLojaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClientesLojaTableAdapter As GirlRootName.GirlDataSetTableAdapters.ClientesLojaTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTelefone As System.Windows.Forms.TextBox
    Friend WithEvents btCancelar As System.Windows.Forms.Button
    Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Telemovel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Localidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Morada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodPostal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Obs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Telefone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArmOrig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClienteLojaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaisID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DistritoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDClienteLoja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCodPostal As MaskedTextBox
    Friend WithEvents btPesquisar As Button
End Class
