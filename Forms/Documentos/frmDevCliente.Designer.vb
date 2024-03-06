<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDevCliente
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtSerieID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblModelo = New System.Windows.Forms.Label()
        Me.lblCor = New System.Windows.Forms.Label()
        Me.lblTamanho = New System.Windows.Forms.Label()
        Me.lblPrVenda = New System.Windows.Forms.Label()
        Me.PicFoto = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbLoja = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdGravar = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.dgvDevCli = New System.Windows.Forms.DataGridView()
        Me.ArmazemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerieIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModeloID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TamID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtRegistoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocCabDetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btListarTaloes = New System.Windows.Forms.Button()
        Me.cbReport = New System.Windows.Forms.ComboBox()
        Me.DocDetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DocDetTableAdapter = New GirlRootName.GirlDataSetTableAdapters.DocDetTableAdapter()
        Me.DocCabDetTableAdapter = New GirlRootName.GirlDataSetTableAdapters.DocCabDetTableAdapter()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvDevCli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocCabDetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DocDetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSerieID
        '
        Me.txtSerieID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSerieID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieID.Location = New System.Drawing.Point(153, 4)
        Me.txtSerieID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSerieID.Name = "txtSerieID"
        Me.txtSerieID.Size = New System.Drawing.Size(188, 30)
        Me.txtSerieID.TabIndex = 0
        Me.txtSerieID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 72)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 36)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Modelo:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 108)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 36)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Cor:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 144)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 36)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Tam:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 180)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 42)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Pr Venda:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModelo
        '
        Me.lblModelo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModelo.AutoSize = True
        Me.lblModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModelo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelo.Location = New System.Drawing.Point(153, 72)
        Me.lblModelo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(188, 36)
        Me.lblModelo.TabIndex = 1
        Me.lblModelo.Text = "..."
        Me.lblModelo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCor
        '
        Me.lblCor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCor.AutoSize = True
        Me.lblCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCor.Location = New System.Drawing.Point(153, 108)
        Me.lblCor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCor.Name = "lblCor"
        Me.lblCor.Size = New System.Drawing.Size(188, 36)
        Me.lblCor.TabIndex = 1
        Me.lblCor.Text = "..."
        Me.lblCor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTamanho
        '
        Me.lblTamanho.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTamanho.AutoSize = True
        Me.lblTamanho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTamanho.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTamanho.Location = New System.Drawing.Point(153, 144)
        Me.lblTamanho.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTamanho.Name = "lblTamanho"
        Me.lblTamanho.Size = New System.Drawing.Size(188, 36)
        Me.lblTamanho.TabIndex = 1
        Me.lblTamanho.Text = "..."
        Me.lblTamanho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPrVenda
        '
        Me.lblPrVenda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrVenda.AutoSize = True
        Me.lblPrVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrVenda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrVenda.Location = New System.Drawing.Point(153, 180)
        Me.lblPrVenda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPrVenda.Name = "lblPrVenda"
        Me.lblPrVenda.Size = New System.Drawing.Size(188, 42)
        Me.lblPrVenda.TabIndex = 1
        Me.lblPrVenda.Text = "..."
        Me.lblPrVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PicFoto
        '
        Me.PicFoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicFoto.Location = New System.Drawing.Point(740, 463)
        Me.PicFoto.Margin = New System.Windows.Forms.Padding(4)
        Me.PicFoto.Name = "PicFoto"
        Me.PicFoto.Size = New System.Drawing.Size(345, 225)
        Me.PicFoto.TabIndex = 2
        Me.PicFoto.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.47826!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.52174!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtSerieID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPrVenda, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTamanho, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCor, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblModelo, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbLoja, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(740, 223)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(345, 222)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 36)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 36)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Loja:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbLoja
        '
        Me.lbLoja.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbLoja.AutoSize = True
        Me.lbLoja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbLoja.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLoja.Location = New System.Drawing.Point(153, 36)
        Me.lbLoja.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbLoja.Name = "lbLoja"
        Me.lbLoja.Size = New System.Drawing.Size(188, 36)
        Me.lbLoja.TabIndex = 1
        Me.lbLoja.Text = "..."
        Me.lbLoja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Talão:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGravar
        '
        Me.cmdGravar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGravar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdGravar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGravar.Location = New System.Drawing.Point(740, 165)
        Me.cmdGravar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(341, 42)
        Me.cmdGravar.TabIndex = 4
        Me.cmdGravar.Text = "Gravar"
        Me.cmdGravar.UseVisualStyleBackColor = False
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFechar.Location = New System.Drawing.Point(916, 11)
        Me.btFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(159, 42)
        Me.btFechar.TabIndex = 5
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'dgvDevCli
        '
        Me.dgvDevCli.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.dgvDevCli.AllowUserToAddRows = False
        Me.dgvDevCli.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvDevCli.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDevCli.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDevCli.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDevCli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDevCli.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ArmazemID, Me.SerieIDDataGridViewTextBoxColumn, Me.ModeloID, Me.CorID, Me.TamID, Me.DtRegistoDataGridViewTextBoxColumn})
        Me.dgvDevCli.DataSource = Me.DocCabDetBindingSource
        Me.dgvDevCli.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvDevCli.Location = New System.Drawing.Point(0, 0)
        Me.dgvDevCli.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvDevCli.Name = "dgvDevCli"
        Me.dgvDevCli.ReadOnly = True
        Me.dgvDevCli.RowHeadersWidth = 25
        Me.dgvDevCli.Size = New System.Drawing.Size(709, 703)
        Me.dgvDevCli.TabIndex = 6
        '
        'ArmazemID
        '
        Me.ArmazemID.DataPropertyName = "ArmazemID"
        Me.ArmazemID.HeaderText = "Loja"
        Me.ArmazemID.Name = "ArmazemID"
        Me.ArmazemID.ReadOnly = True
        '
        'SerieIDDataGridViewTextBoxColumn
        '
        Me.SerieIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.SerieIDDataGridViewTextBoxColumn.DataPropertyName = "SerieID"
        Me.SerieIDDataGridViewTextBoxColumn.HeaderText = "Talões"
        Me.SerieIDDataGridViewTextBoxColumn.Name = "SerieIDDataGridViewTextBoxColumn"
        Me.SerieIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SerieIDDataGridViewTextBoxColumn.Width = 88
        '
        'ModeloID
        '
        Me.ModeloID.DataPropertyName = "ModeloID"
        Me.ModeloID.HeaderText = "Modelo"
        Me.ModeloID.Name = "ModeloID"
        Me.ModeloID.ReadOnly = True
        Me.ModeloID.Width = 60
        '
        'CorID
        '
        Me.CorID.DataPropertyName = "CorID"
        Me.CorID.HeaderText = "Cor"
        Me.CorID.Name = "CorID"
        Me.CorID.ReadOnly = True
        Me.CorID.Width = 48
        '
        'TamID
        '
        Me.TamID.DataPropertyName = "TamID"
        Me.TamID.HeaderText = "Tam"
        Me.TamID.Name = "TamID"
        Me.TamID.ReadOnly = True
        Me.TamID.Width = 48
        '
        'DtRegistoDataGridViewTextBoxColumn
        '
        Me.DtRegistoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DtRegistoDataGridViewTextBoxColumn.DataPropertyName = "DataDoc"
        Me.DtRegistoDataGridViewTextBoxColumn.HeaderText = "Data"
        Me.DtRegistoDataGridViewTextBoxColumn.Name = "DtRegistoDataGridViewTextBoxColumn"
        Me.DtRegistoDataGridViewTextBoxColumn.ReadOnly = True
        Me.DtRegistoDataGridViewTextBoxColumn.Width = 72
        '
        'DocCabDetBindingSource
        '
        Me.DocCabDetBindingSource.DataMember = "DocCabDet"
        Me.DocCabDetBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.btListarTaloes)
        Me.GroupBox1.Controls.Add(Me.cbReport)
        Me.GroupBox1.Location = New System.Drawing.Point(740, 60)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(340, 97)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        '
        'btListarTaloes
        '
        Me.btListarTaloes.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btListarTaloes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btListarTaloes.Location = New System.Drawing.Point(8, 20)
        Me.btListarTaloes.Margin = New System.Windows.Forms.Padding(4)
        Me.btListarTaloes.Name = "btListarTaloes"
        Me.btListarTaloes.Size = New System.Drawing.Size(324, 30)
        Me.btListarTaloes.TabIndex = 2
        Me.btListarTaloes.Text = "Imprimir Talões"
        Me.btListarTaloes.UseVisualStyleBackColor = False
        '
        'cbReport
        '
        Me.cbReport.DisplayMember = "RptTaloes_3x2"
        Me.cbReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReport.FormattingEnabled = True
        Me.cbReport.Items.AddRange(New Object() {"RptTaloes_10x4SemTam", "RptTaloes_3x2", "RptRelTaloes", "RptRelaTaloesCB"})
        Me.cbReport.Location = New System.Drawing.Point(8, 57)
        Me.cbReport.Margin = New System.Windows.Forms.Padding(4)
        Me.cbReport.Name = "cbReport"
        Me.cbReport.Size = New System.Drawing.Size(323, 28)
        Me.cbReport.TabIndex = 37
        '
        'DocDetBindingSource
        '
        Me.DocDetBindingSource.DataMember = "DocDet"
        Me.DocDetBindingSource.DataSource = Me.GirlDataSet
        '
        'DocDetTableAdapter
        '
        Me.DocDetTableAdapter.ClearBeforeFill = True
        '
        'DocCabDetTableAdapter
        '
        Me.DocCabDetTableAdapter.ClearBeforeFill = True
        '
        'frmDevCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 703)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDevCli)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.PicFoto)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmDevCliente"
        Me.Text = "Devoçuções de Clientes"
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvDevCli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocCabDetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DocDetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSerieID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblModelo As System.Windows.Forms.Label
    Friend WithEvents lblCor As System.Windows.Forms.Label
    Friend WithEvents lblTamanho As System.Windows.Forms.Label
    Friend WithEvents lblPrVenda As System.Windows.Forms.Label
    Friend WithEvents PicFoto As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents dgvDevCli As System.Windows.Forms.DataGridView
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents DocDetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DocDetTableAdapter As GirlRootName.GirlDataSetTableAdapters.DocDetTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btListarTaloes As System.Windows.Forms.Button
    Friend WithEvents cbReport As System.Windows.Forms.ComboBox
    Friend WithEvents DocCabDetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DocCabDetTableAdapter As GirlRootName.GirlDataSetTableAdapters.DocCabDetTableAdapter
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbLoja As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ArmazemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerieIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModeloID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TamID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtRegistoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
