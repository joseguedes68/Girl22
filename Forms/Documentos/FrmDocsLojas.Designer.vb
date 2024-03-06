<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDocsLojas
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvDocCab = New System.Windows.Forms.DataGridView()
        Me.lbTipoDoc = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CbDestino = New System.Windows.Forms.ComboBox()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btPrintDoc = New System.Windows.Forms.Button()
        Me.btNovoDoc = New System.Windows.Forms.Button()
        Me.txtTotDoc = New C1.Win.C1Input.C1TextBox()
        Me.txtTotIva = New C1.Win.C1Input.C1TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DocDetDataGridView = New System.Windows.Forms.DataGridView()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VlrDescLn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TLinha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pBotoes = New System.Windows.Forms.Panel()
        Me.btGravarDoc = New System.Windows.Forms.Button()
        Me.pDestinos = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbObs = New System.Windows.Forms.TextBox()
        Me.C1tbMB = New C1.Win.C1Input.C1TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C1tbDH = New C1.Win.C1Input.C1TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ModeloID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qtd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IvaID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TaxIVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.DocLnNr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerieID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TamID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpresaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocNr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArmazemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocNrLnOrig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercDescLn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Obs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoLn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperadorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtRegisto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocDetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DocDetTableAdapter = New GirlRootName.GirlDataSetTableAdapters.DocDetTableAdapter()
        Me.TaxIVATableAdapter = New GirlRootName.GirlDataSetTableAdapters.TaxIVATableAdapter()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvDocCab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDetDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pBotoes.SuspendLayout()
        Me.pDestinos.SuspendLayout()
        CType(Me.C1tbMB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1tbDH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TaxIVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.dgvDocCab)
        Me.GroupBox4.Controls.Add(Me.lbTipoDoc)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(475, 462)
        Me.GroupBox4.TabIndex = 40
        Me.GroupBox4.TabStop = False
        '
        'dgvDocCab
        '
        Me.dgvDocCab.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvDocCab.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDocCab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDocCab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocCab.Location = New System.Drawing.Point(6, 36)
        Me.dgvDocCab.Name = "dgvDocCab"
        Me.dgvDocCab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDocCab.Size = New System.Drawing.Size(463, 417)
        Me.dgvDocCab.TabIndex = 17
        '
        'lbTipoDoc
        '
        Me.lbTipoDoc.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbTipoDoc.Location = New System.Drawing.Point(6, 10)
        Me.lbTipoDoc.Name = "lbTipoDoc"
        Me.lbTipoDoc.Size = New System.Drawing.Size(230, 26)
        Me.lbTipoDoc.TabIndex = 13
        Me.lbTipoDoc.Text = "Documentos"
        Me.lbTipoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtData
        '
        Me.txtData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtData.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtData.CustomFormat = "yyyy-MM-dd H:mm:ss"
        Me.txtData.Enabled = False
        Me.txtData.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtData.Location = New System.Drawing.Point(133, 6)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(185, 24)
        Me.txtData.TabIndex = 39
        Me.txtData.TabStop = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(37, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 16)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Data Doc: "
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(40, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 19)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Destino :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbDestino
        '
        Me.CbDestino.AllowDrop = True
        Me.CbDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbDestino.DropDownWidth = 150
        Me.CbDestino.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.CbDestino.Location = New System.Drawing.Point(133, 36)
        Me.CbDestino.MaxDropDownItems = 10
        Me.CbDestino.Name = "CbDestino"
        Me.CbDestino.Size = New System.Drawing.Size(311, 24)
        Me.CbDestino.TabIndex = 41
        '
        'btFechar
        '
        Me.btFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btFechar.Location = New System.Drawing.Point(480, 5)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(83, 29)
        Me.btFechar.TabIndex = 40
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'btPrintDoc
        '
        Me.btPrintDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btPrintDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btPrintDoc.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btPrintDoc.Location = New System.Drawing.Point(265, 5)
        Me.btPrintDoc.Name = "btPrintDoc"
        Me.btPrintDoc.Size = New System.Drawing.Size(83, 29)
        Me.btPrintDoc.TabIndex = 37
        Me.btPrintDoc.Text = "Print"
        Me.btPrintDoc.UseVisualStyleBackColor = False
        '
        'btNovoDoc
        '
        Me.btNovoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btNovoDoc.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btNovoDoc.Location = New System.Drawing.Point(43, 5)
        Me.btNovoDoc.Name = "btNovoDoc"
        Me.btNovoDoc.Size = New System.Drawing.Size(83, 29)
        Me.btNovoDoc.TabIndex = 39
        Me.btNovoDoc.Text = "Nova"
        Me.btNovoDoc.UseVisualStyleBackColor = False
        Me.btNovoDoc.Visible = False
        '
        'txtTotDoc
        '
        Me.txtTotDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotDoc.Location = New System.Drawing.Point(967, 346)
        Me.txtTotDoc.Name = "txtTotDoc"
        Me.txtTotDoc.Size = New System.Drawing.Size(102, 21)
        Me.txtTotDoc.TabIndex = 59
        Me.txtTotDoc.Tag = Nothing
        Me.txtTotDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotIva
        '
        Me.txtTotIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotIva.Location = New System.Drawing.Point(767, 346)
        Me.txtTotIva.Name = "txtTotIva"
        Me.txtTotIva.Size = New System.Drawing.Size(86, 21)
        Me.txtTotIva.TabIndex = 60
        Me.txtTotIva.Tag = Nothing
        Me.txtTotIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(676, 348)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 16)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Total IVA :"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(907, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 16)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Total :"
        '
        'DocDetDataGridView
        '
        Me.DocDetDataGridView.AllowUserToAddRows = False
        Me.DocDetDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DocDetDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DocDetDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DocDetDataGridView.AutoGenerateColumns = False
        Me.DocDetDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ModeloID, Me.CorID, Me.ProductCode, Me.Descricao, Me.Valor, Me.VlrDescLn, Me.Qtd, Me.Unidade, Me.IvaID, Me.TLinha, Me.DocLnNr, Me.SerieID, Me.TamID, Me.EmpresaID, Me.TipoDocID, Me.DocNr, Me.ArmazemID, Me.DocNrLnOrig, Me.PercDescLn, Me.DataGridViewTextBoxColumn1, Me.Obs, Me.EstadoLn, Me.OperadorID, Me.DtRegisto})
        Me.DocDetDataGridView.DataSource = Me.DocDetBindingSource
        Me.DocDetDataGridView.Enabled = False
        Me.DocDetDataGridView.Location = New System.Drawing.Point(487, 177)
        Me.DocDetDataGridView.Name = "DocDetDataGridView"
        Me.DocDetDataGridView.Size = New System.Drawing.Size(589, 151)
        Me.DocDetDataGridView.TabIndex = 64
        '
        'ProductCode
        '
        Me.ProductCode.DataPropertyName = "ProductCode"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ProductCode.DefaultCellStyle = DataGridViewCellStyle5
        Me.ProductCode.HeaderText = "Artigo"
        Me.ProductCode.Name = "ProductCode"
        '
        'VlrDescLn
        '
        Me.VlrDescLn.DataPropertyName = "VlrDescLn"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.VlrDescLn.DefaultCellStyle = DataGridViewCellStyle8
        Me.VlrDescLn.HeaderText = "Desc"
        Me.VlrDescLn.Name = "VlrDescLn"
        Me.VlrDescLn.Width = 55
        '
        'TLinha
        '
        Me.TLinha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "C2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.TLinha.DefaultCellStyle = DataGridViewCellStyle12
        Me.TLinha.HeaderText = "TotalLn"
        Me.TLinha.Name = "TLinha"
        Me.TLinha.Width = 68
        '
        'pBotoes
        '
        Me.pBotoes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pBotoes.Controls.Add(Me.btGravarDoc)
        Me.pBotoes.Controls.Add(Me.btNovoDoc)
        Me.pBotoes.Controls.Add(Me.btPrintDoc)
        Me.pBotoes.Controls.Add(Me.btFechar)
        Me.pBotoes.Location = New System.Drawing.Point(487, 101)
        Me.pBotoes.Name = "pBotoes"
        Me.pBotoes.Size = New System.Drawing.Size(589, 37)
        Me.pBotoes.TabIndex = 66
        '
        'btGravarDoc
        '
        Me.btGravarDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGravarDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGravarDoc.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btGravarDoc.Location = New System.Drawing.Point(160, 5)
        Me.btGravarDoc.Name = "btGravarDoc"
        Me.btGravarDoc.Size = New System.Drawing.Size(83, 29)
        Me.btGravarDoc.TabIndex = 38
        Me.btGravarDoc.Text = "Gravar"
        Me.btGravarDoc.UseVisualStyleBackColor = False
        Me.btGravarDoc.Visible = False
        '
        'pDestinos
        '
        Me.pDestinos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pDestinos.Controls.Add(Me.txtData)
        Me.pDestinos.Controls.Add(Me.CbDestino)
        Me.pDestinos.Controls.Add(Me.Label9)
        Me.pDestinos.Controls.Add(Me.Label5)
        Me.pDestinos.Location = New System.Drawing.Point(487, 22)
        Me.pDestinos.Name = "pDestinos"
        Me.pDestinos.Size = New System.Drawing.Size(589, 73)
        Me.pDestinos.TabIndex = 67
        Me.pDestinos.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(484, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Obs : "
        '
        'tbObs
        '
        Me.tbObs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbObs.Location = New System.Drawing.Point(539, 151)
        Me.tbObs.Name = "tbObs"
        Me.tbObs.Size = New System.Drawing.Size(537, 20)
        Me.tbObs.TabIndex = 68
        '
        'C1tbMB
        '
        Me.C1tbMB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.C1tbMB.Enabled = False
        Me.C1tbMB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1tbMB.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.C1tbMB.Location = New System.Drawing.Point(101, 480)
        Me.C1tbMB.Name = "C1tbMB"
        Me.C1tbMB.Size = New System.Drawing.Size(86, 21)
        Me.C1tbMB.TabIndex = 70
        Me.C1tbMB.Tag = Nothing
        Me.C1tbMB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1tbMB.Value = "0"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 482)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "MB :"
        '
        'C1tbDH
        '
        Me.C1tbDH.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.C1tbDH.Enabled = False
        Me.C1tbDH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1tbDH.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.C1tbDH.Location = New System.Drawing.Point(296, 482)
        Me.C1tbDH.Name = "C1tbDH"
        Me.C1tbDH.Size = New System.Drawing.Size(86, 21)
        Me.C1tbDH.TabIndex = 72
        Me.C1tbDH.Tag = Nothing
        Me.C1tbDH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1tbDH.Value = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(205, 484)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Dinheiro :"
        '
        'ModeloID
        '
        Me.ModeloID.DataPropertyName = "ModeloID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeloID.DefaultCellStyle = DataGridViewCellStyle3
        Me.ModeloID.HeaderText = "Modelo"
        Me.ModeloID.Name = "ModeloID"
        Me.ModeloID.Visible = False
        Me.ModeloID.Width = 58
        '
        'CorID
        '
        Me.CorID.DataPropertyName = "CorID"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CorID.DefaultCellStyle = DataGridViewCellStyle4
        Me.CorID.HeaderText = "Cor"
        Me.CorID.Name = "CorID"
        Me.CorID.Visible = False
        Me.CorID.Width = 36
        '
        'Descricao
        '
        Me.Descricao.DataPropertyName = "Descricao"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Descricao.DefaultCellStyle = DataGridViewCellStyle6
        Me.Descricao.HeaderText = "Descrição"
        Me.Descricao.Name = "Descricao"
        Me.Descricao.Width = 140
        '
        'Valor
        '
        Me.Valor.DataPropertyName = "Valor"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle7
        Me.Valor.HeaderText = "PVnd"
        Me.Valor.Name = "Valor"
        Me.Valor.Width = 55
        '
        'Qtd
        '
        Me.Qtd.DataPropertyName = "Qtd"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Qtd.DefaultCellStyle = DataGridViewCellStyle9
        Me.Qtd.HeaderText = "Qtd"
        Me.Qtd.Name = "Qtd"
        Me.Qtd.Width = 47
        '
        'Unidade
        '
        Me.Unidade.DataPropertyName = "Unidade"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Unidade.DefaultCellStyle = DataGridViewCellStyle10
        Me.Unidade.HeaderText = "Unid"
        Me.Unidade.Name = "Unidade"
        Me.Unidade.Width = 45
        '
        'IvaID
        '
        Me.IvaID.DataPropertyName = "IvaID"
        Me.IvaID.DataSource = Me.TaxIVABindingSource
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "p0"
        Me.IvaID.DefaultCellStyle = DataGridViewCellStyle11
        Me.IvaID.DisplayMember = "TxIVA"
        Me.IvaID.HeaderText = "TxIva"
        Me.IvaID.Name = "IvaID"
        Me.IvaID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IvaID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IvaID.ValueMember = "IvaID"
        Me.IvaID.Width = 57
        '
        'TaxIVABindingSource
        '
        Me.TaxIVABindingSource.DataMember = "TaxIVA"
        Me.TaxIVABindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DocLnNr
        '
        Me.DocLnNr.DataPropertyName = "DocLnNr"
        Me.DocLnNr.HeaderText = "DocLnNr"
        Me.DocLnNr.Name = "DocLnNr"
        Me.DocLnNr.Visible = False
        '
        'SerieID
        '
        Me.SerieID.DataPropertyName = "SerieID"
        Me.SerieID.HeaderText = "SerieID"
        Me.SerieID.Name = "SerieID"
        Me.SerieID.Visible = False
        '
        'TamID
        '
        Me.TamID.DataPropertyName = "TamID"
        Me.TamID.HeaderText = "TamID"
        Me.TamID.Name = "TamID"
        Me.TamID.Visible = False
        '
        'EmpresaID
        '
        Me.EmpresaID.DataPropertyName = "EmpresaID"
        Me.EmpresaID.HeaderText = "EmpresaID"
        Me.EmpresaID.Name = "EmpresaID"
        Me.EmpresaID.Visible = False
        '
        'TipoDocID
        '
        Me.TipoDocID.DataPropertyName = "TipoDocID"
        Me.TipoDocID.HeaderText = "TipoDocID"
        Me.TipoDocID.Name = "TipoDocID"
        Me.TipoDocID.Visible = False
        '
        'DocNr
        '
        Me.DocNr.DataPropertyName = "DocNr"
        Me.DocNr.HeaderText = "DocNr"
        Me.DocNr.Name = "DocNr"
        Me.DocNr.Visible = False
        '
        'ArmazemID
        '
        Me.ArmazemID.DataPropertyName = "ArmazemID"
        Me.ArmazemID.HeaderText = "ArmazemID"
        Me.ArmazemID.Name = "ArmazemID"
        Me.ArmazemID.Visible = False
        '
        'DocNrLnOrig
        '
        Me.DocNrLnOrig.DataPropertyName = "DocNrLnOrig"
        Me.DocNrLnOrig.HeaderText = "DocNrLnOrig"
        Me.DocNrLnOrig.Name = "DocNrLnOrig"
        Me.DocNrLnOrig.Visible = False
        '
        'PercDescLn
        '
        Me.PercDescLn.DataPropertyName = "PercDescLn"
        Me.PercDescLn.HeaderText = "PercDescLn"
        Me.PercDescLn.Name = "PercDescLn"
        Me.PercDescLn.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "VlrDescLn"
        Me.DataGridViewTextBoxColumn1.HeaderText = "VlrDescLn"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'Obs
        '
        Me.Obs.DataPropertyName = "Obs"
        Me.Obs.HeaderText = "Obs"
        Me.Obs.Name = "Obs"
        Me.Obs.Visible = False
        '
        'EstadoLn
        '
        Me.EstadoLn.DataPropertyName = "EstadoLn"
        Me.EstadoLn.HeaderText = "EstadoLn"
        Me.EstadoLn.Name = "EstadoLn"
        Me.EstadoLn.Visible = False
        '
        'OperadorID
        '
        Me.OperadorID.DataPropertyName = "OperadorID"
        Me.OperadorID.HeaderText = "OperadorID"
        Me.OperadorID.Name = "OperadorID"
        Me.OperadorID.Visible = False
        '
        'DtRegisto
        '
        Me.DtRegisto.DataPropertyName = "DtRegisto"
        Me.DtRegisto.HeaderText = "DtRegisto"
        Me.DtRegisto.Name = "DtRegisto"
        Me.DtRegisto.Visible = False
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
        'TaxIVATableAdapter
        '
        Me.TaxIVATableAdapter.ClearBeforeFill = True
        '
        'FrmDocsLojas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1080, 552)
        Me.Controls.Add(Me.C1tbDH)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.C1tbMB)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbObs)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pDestinos)
        Me.Controls.Add(Me.pBotoes)
        Me.Controls.Add(Me.DocDetDataGridView)
        Me.Controls.Add(Me.txtTotDoc)
        Me.Controls.Add(Me.txtTotIva)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDocsLojas"
        Me.Text = "FrmDocsBase"
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvDocCab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDetDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pBotoes.ResumeLayout(False)
        Me.pDestinos.ResumeLayout(False)
        Me.pDestinos.PerformLayout()
        CType(Me.C1tbMB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1tbDH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TaxIVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDocCab As System.Windows.Forms.DataGridView
    Friend WithEvents lbTipoDoc As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents btPrintDoc As System.Windows.Forms.Button
    Friend WithEvents btNovoDoc As System.Windows.Forms.Button
    Friend WithEvents txtTotDoc As C1.Win.C1Input.C1TextBox
    Friend WithEvents txtTotIva As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents DocDetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DocDetTableAdapter As GirlRootName.GirlDataSetTableAdapters.DocDetTableAdapter
    Friend WithEvents DocDetDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TaxIVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TaxIVATableAdapter As GirlRootName.GirlDataSetTableAdapters.TaxIVATableAdapter
    Friend WithEvents pBotoes As System.Windows.Forms.Panel
    Friend WithEvents pDestinos As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btGravarDoc As System.Windows.Forms.Button
    Friend WithEvents tbObs As System.Windows.Forms.TextBox
    Friend WithEvents C1tbMB As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C1tbDH As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ModeloID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VlrDescLn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qtd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IvaID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TLinha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocLnNr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerieID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TamID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpresaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocNr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArmazemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocNrLnOrig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PercDescLn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Obs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoLn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperadorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtRegisto As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
