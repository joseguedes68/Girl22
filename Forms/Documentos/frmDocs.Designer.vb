<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocs
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DocDetDataGridView = New System.Windows.Forms.DataGridView()
        Me.Artigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModeloID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrUniLiq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VlrDescLiq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qtd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IvaID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TaxIVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.TotalLiq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocDetAuxBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbTipoDoc = New System.Windows.Forms.Label()
        Me.PTotais = New System.Windows.Forms.Panel()
        Me.tbDescDoc = New System.Windows.Forms.TextBox()
        Me.lbDescDoc = New System.Windows.Forms.Label()
        Me.lbDesconto = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtDescontoAux = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbIva = New System.Windows.Forms.Label()
        Me.tbDesconto = New System.Windows.Forms.TextBox()
        Me.txtTotDoc = New C1.Win.C1Input.C1TextBox()
        Me.lbSubTotal = New System.Windows.Forms.Label()
        Me.txtTotIva = New C1.Win.C1Input.C1TextBox()
        Me.txtSubTot = New C1.Win.C1Input.C1TextBox()
        Me.pDestinos = New System.Windows.Forms.Panel()
        Me.CbOrigem = New System.Windows.Forms.ComboBox()
        Me.lbOrigem = New System.Windows.Forms.Label()
        Me.CbDestino = New System.Windows.Forms.ComboBox()
        Me.lbTerceiro = New System.Windows.Forms.Label()
        Me.dpDataDoc = New System.Windows.Forms.DateTimePicker()
        Me.pBotoes = New System.Windows.Forms.Panel()
        Me.btGravarDoc = New System.Windows.Forms.Button()
        Me.btSeparacao = New System.Windows.Forms.Button()
        Me.btDocs = New System.Windows.Forms.Button()
        Me.btPrintDoc = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.pObsDoc = New System.Windows.Forms.Panel()
        Me.lbdocOrig = New System.Windows.Forms.Label()
        Me.tbDocOrigem = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbNIF = New System.Windows.Forms.TextBox()
        Me.tbCountryDescarga = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dpMovementStartTime = New System.Windows.Forms.DateTimePicker()
        Me.tbPostalCodeDescarga = New System.Windows.Forms.TextBox()
        Me.tbCityDescarga = New System.Windows.Forms.TextBox()
        Me.tbAddressDetailDescarga = New System.Windows.Forms.TextBox()
        Me.tbPostalCodeCarga = New System.Windows.Forms.TextBox()
        Me.tbCityCarga = New System.Windows.Forms.TextBox()
        Me.tbObs = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbAddressDetailCarga = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbNrDoc = New System.Windows.Forms.Label()
        Me.tbNrDoc = New System.Windows.Forms.TextBox()
        Me.lbNrAT = New System.Windows.Forms.Label()
        Me.tbNrAT = New System.Windows.Forms.TextBox()
        Me.btPedirNrAT = New System.Windows.Forms.Button()
        Me.lbIdDocCab = New System.Windows.Forms.Label()
        Me.TaxIVATableAdapter = New GirlRootName.GirlDataSetTableAdapters.TaxIVATableAdapter()
        Me.lbIdDocCabOrig = New System.Windows.Forms.Label()
        CType(Me.DocDetDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TaxIVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDetAuxBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PTotais.SuspendLayout()
        CType(Me.txtTotDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pDestinos.SuspendLayout()
        Me.pBotoes.SuspendLayout()
        Me.pObsDoc.SuspendLayout()
        Me.SuspendLayout()
        '
        'DocDetDataGridView
        '
        Me.DocDetDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DocDetDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DocDetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DocDetDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Artigo, Me.ModeloID, Me.CorID, Me.Descricao, Me.PrUniLiq, Me.VlrDescLiq, Me.Qtd, Me.Unidade, Me.IvaID, Me.TotalLiq})
        Me.DocDetDataGridView.DataSource = Me.DocDetAuxBindingSource
        Me.DocDetDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DocDetDataGridView.Location = New System.Drawing.Point(0, 435)
        Me.DocDetDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.DocDetDataGridView.Name = "DocDetDataGridView"
        Me.DocDetDataGridView.RowHeadersWidth = 50
        Me.DocDetDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DocDetDataGridView.ShowCellErrors = False
        Me.DocDetDataGridView.Size = New System.Drawing.Size(1437, 231)
        Me.DocDetDataGridView.TabIndex = 0
        '
        'Artigo
        '
        Me.Artigo.DataPropertyName = "Artigo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Artigo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Artigo.HeaderText = "Artigo"
        Me.Artigo.Name = "Artigo"
        '
        'ModeloID
        '
        Me.ModeloID.DataPropertyName = "ModeloID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ModeloID.DefaultCellStyle = DataGridViewCellStyle3
        Me.ModeloID.HeaderText = "Modelo"
        Me.ModeloID.Name = "ModeloID"
        Me.ModeloID.Visible = False
        Me.ModeloID.Width = 80
        '
        'CorID
        '
        Me.CorID.DataPropertyName = "CorID"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CorID.DefaultCellStyle = DataGridViewCellStyle4
        Me.CorID.HeaderText = "Cor"
        Me.CorID.Name = "CorID"
        Me.CorID.Visible = False
        Me.CorID.Width = 50
        '
        'Descricao
        '
        Me.Descricao.DataPropertyName = "Descricao"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Descricao.DefaultCellStyle = DataGridViewCellStyle5
        Me.Descricao.HeaderText = "Descrição"
        Me.Descricao.Name = "Descricao"
        Me.Descricao.Width = 300
        '
        'PrUniLiq
        '
        Me.PrUniLiq.DataPropertyName = "PrUniLiq"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C4"
        Me.PrUniLiq.DefaultCellStyle = DataGridViewCellStyle6
        Me.PrUniLiq.HeaderText = "PrUniLiq"
        Me.PrUniLiq.Name = "PrUniLiq"
        Me.PrUniLiq.Width = 80
        '
        'VlrDescLiq
        '
        Me.VlrDescLiq.DataPropertyName = "VlrDescLiq"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C2"
        Me.VlrDescLiq.DefaultCellStyle = DataGridViewCellStyle7
        Me.VlrDescLiq.HeaderText = "VlrDescLiq"
        Me.VlrDescLiq.Name = "VlrDescLiq"
        Me.VlrDescLiq.Width = 80
        '
        'Qtd
        '
        Me.Qtd.DataPropertyName = "Qtd"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.Qtd.DefaultCellStyle = DataGridViewCellStyle8
        Me.Qtd.HeaderText = "Qtd"
        Me.Qtd.Name = "Qtd"
        Me.Qtd.Width = 70
        '
        'Unidade
        '
        Me.Unidade.DataPropertyName = "Unidade"
        Me.Unidade.HeaderText = "Unidade"
        Me.Unidade.Name = "Unidade"
        Me.Unidade.ReadOnly = True
        Me.Unidade.Width = 70
        '
        'IvaID
        '
        Me.IvaID.DataPropertyName = "IvaID"
        Me.IvaID.DataSource = Me.TaxIVABindingSource
        DataGridViewCellStyle9.Format = "#%"
        Me.IvaID.DefaultCellStyle = DataGridViewCellStyle9
        Me.IvaID.DisplayMember = "TxIVA"
        Me.IvaID.HeaderText = "TxIva"
        Me.IvaID.Name = "IvaID"
        Me.IvaID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IvaID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IvaID.ValueMember = "IvaID"
        Me.IvaID.Width = 80
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
        'TotalLiq
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C2"
        Me.TotalLiq.DefaultCellStyle = DataGridViewCellStyle10
        Me.TotalLiq.HeaderText = "TotalLiq"
        Me.TotalLiq.Name = "TotalLiq"
        Me.TotalLiq.ReadOnly = True
        Me.TotalLiq.Width = 80
        '
        'DocDetAuxBindingSource
        '
        Me.DocDetAuxBindingSource.DataMember = "DocDetAux"
        Me.DocDetAuxBindingSource.DataSource = Me.GirlDataSet
        '
        'lbTipoDoc
        '
        Me.lbTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lbTipoDoc.Location = New System.Drawing.Point(12, 9)
        Me.lbTipoDoc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTipoDoc.Name = "lbTipoDoc"
        Me.lbTipoDoc.Size = New System.Drawing.Size(335, 32)
        Me.lbTipoDoc.TabIndex = 75
        Me.lbTipoDoc.Text = "Documentos"
        Me.lbTipoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PTotais
        '
        Me.PTotais.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PTotais.Controls.Add(Me.tbDescDoc)
        Me.PTotais.Controls.Add(Me.lbDescDoc)
        Me.PTotais.Controls.Add(Me.lbDesconto)
        Me.PTotais.Controls.Add(Me.lblTotal)
        Me.PTotais.Controls.Add(Me.txtDescontoAux)
        Me.PTotais.Controls.Add(Me.Label8)
        Me.PTotais.Controls.Add(Me.lbIva)
        Me.PTotais.Controls.Add(Me.tbDesconto)
        Me.PTotais.Controls.Add(Me.txtTotDoc)
        Me.PTotais.Controls.Add(Me.lbSubTotal)
        Me.PTotais.Controls.Add(Me.txtTotIva)
        Me.PTotais.Controls.Add(Me.txtSubTot)
        Me.PTotais.Location = New System.Drawing.Point(1037, 233)
        Me.PTotais.Margin = New System.Windows.Forms.Padding(4)
        Me.PTotais.Name = "PTotais"
        Me.PTotais.Size = New System.Drawing.Size(384, 194)
        Me.PTotais.TabIndex = 74
        '
        'tbDescDoc
        '
        Me.tbDescDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDescDoc.Location = New System.Drawing.Point(201, 16)
        Me.tbDescDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.tbDescDoc.Name = "tbDescDoc"
        Me.tbDescDoc.Size = New System.Drawing.Size(77, 34)
        Me.tbDescDoc.TabIndex = 81
        Me.tbDescDoc.Text = "0"
        Me.tbDescDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbDescDoc.Visible = False
        '
        'lbDescDoc
        '
        Me.lbDescDoc.AutoSize = True
        Me.lbDescDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescDoc.Location = New System.Drawing.Point(29, 23)
        Me.lbDescDoc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbDescDoc.Name = "lbDescDoc"
        Me.lbDescDoc.Size = New System.Drawing.Size(155, 25)
        Me.lbDescDoc.TabIndex = 82
        Me.lbDescDoc.Text = "Desc. Doc.(%) : "
        Me.lbDescDoc.Visible = False
        '
        'lbDesconto
        '
        Me.lbDesconto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbDesconto.AutoSize = True
        Me.lbDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesconto.Location = New System.Drawing.Point(39, 95)
        Me.lbDesconto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbDesconto.Name = "lbDesconto"
        Me.lbDesconto.Size = New System.Drawing.Size(100, 25)
        Me.lbDesconto.TabIndex = 69
        Me.lbDesconto.Text = "Desc(%) :"
        Me.lbDesconto.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(73, 164)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(67, 25)
        Me.lblTotal.TabIndex = 54
        Me.lblTotal.Text = "Total :"
        '
        'txtDescontoAux
        '
        Me.txtDescontoAux.Location = New System.Drawing.Point(707, 10)
        Me.txtDescontoAux.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescontoAux.Name = "txtDescontoAux"
        Me.txtDescontoAux.Size = New System.Drawing.Size(132, 22)
        Me.txtDescontoAux.TabIndex = 68
        Me.txtDescontoAux.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(348, 256)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 20)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Total :"
        '
        'lbIva
        '
        Me.lbIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbIva.AutoSize = True
        Me.lbIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbIva.Location = New System.Drawing.Point(84, 129)
        Me.lbIva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbIva.Name = "lbIva"
        Me.lbIva.Size = New System.Drawing.Size(56, 25)
        Me.lbIva.TabIndex = 57
        Me.lbIva.Text = "IVA :"
        '
        'tbDesconto
        '
        Me.tbDesconto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbDesconto.Location = New System.Drawing.Point(436, 188)
        Me.tbDesconto.Margin = New System.Windows.Forms.Padding(4)
        Me.tbDesconto.Name = "tbDesconto"
        Me.tbDesconto.Size = New System.Drawing.Size(135, 24)
        Me.tbDesconto.TabIndex = 63
        Me.tbDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotDoc
        '
        Me.txtTotDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotDoc.Location = New System.Drawing.Point(436, 252)
        Me.txtTotDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotDoc.Name = "txtTotDoc"
        Me.txtTotDoc.Size = New System.Drawing.Size(136, 24)
        Me.txtTotDoc.TabIndex = 59
        Me.txtTotDoc.Tag = Nothing
        Me.txtTotDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbSubTotal
        '
        Me.lbSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbSubTotal.AutoSize = True
        Me.lbSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTotal.Location = New System.Drawing.Point(29, 60)
        Me.lbSubTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbSubTotal.Name = "lbSubTotal"
        Me.lbSubTotal.Size = New System.Drawing.Size(108, 25)
        Me.lbSubTotal.TabIndex = 56
        Me.lbSubTotal.Text = "Sub Total :"
        '
        'txtTotIva
        '
        Me.txtTotIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotIva.Location = New System.Drawing.Point(436, 219)
        Me.txtTotIva.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotIva.Name = "txtTotIva"
        Me.txtTotIva.Size = New System.Drawing.Size(136, 24)
        Me.txtTotIva.TabIndex = 60
        Me.txtTotIva.Tag = Nothing
        Me.txtTotIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTot
        '
        Me.txtSubTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTot.Location = New System.Drawing.Point(436, 159)
        Me.txtSubTot.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubTot.Name = "txtSubTot"
        Me.txtSubTot.Size = New System.Drawing.Size(136, 24)
        Me.txtSubTot.TabIndex = 62
        Me.txtSubTot.Tag = Nothing
        Me.txtSubTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pDestinos
        '
        Me.pDestinos.Controls.Add(Me.lbTipoDoc)
        Me.pDestinos.Controls.Add(Me.CbOrigem)
        Me.pDestinos.Controls.Add(Me.lbOrigem)
        Me.pDestinos.Controls.Add(Me.CbDestino)
        Me.pDestinos.Controls.Add(Me.lbTerceiro)
        Me.pDestinos.Location = New System.Drawing.Point(16, 1)
        Me.pDestinos.Margin = New System.Windows.Forms.Padding(4)
        Me.pDestinos.Name = "pDestinos"
        Me.pDestinos.Size = New System.Drawing.Size(785, 97)
        Me.pDestinos.TabIndex = 73
        '
        'CbOrigem
        '
        Me.CbOrigem.AllowDrop = True
        Me.CbOrigem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbOrigem.DropDownWidth = 150
        Me.CbOrigem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.CbOrigem.Location = New System.Drawing.Point(447, 15)
        Me.CbOrigem.Margin = New System.Windows.Forms.Padding(4)
        Me.CbOrigem.MaxDropDownItems = 10
        Me.CbOrigem.Name = "CbOrigem"
        Me.CbOrigem.Size = New System.Drawing.Size(332, 33)
        Me.CbOrigem.TabIndex = 43
        '
        'lbOrigem
        '
        Me.lbOrigem.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid
        Me.lbOrigem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbOrigem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lbOrigem.Location = New System.Drawing.Point(355, 17)
        Me.lbOrigem.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbOrigem.Name = "lbOrigem"
        Me.lbOrigem.Size = New System.Drawing.Size(85, 23)
        Me.lbOrigem.TabIndex = 44
        Me.lbOrigem.Text = "Serie :"
        Me.lbOrigem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbDestino
        '
        Me.CbDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDestino.DropDownWidth = 150
        Me.CbDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.CbDestino.Location = New System.Drawing.Point(176, 54)
        Me.CbDestino.Margin = New System.Windows.Forms.Padding(4)
        Me.CbDestino.MaxDropDownItems = 10
        Me.CbDestino.Name = "CbDestino"
        Me.CbDestino.Size = New System.Drawing.Size(603, 33)
        Me.CbDestino.TabIndex = 41
        Me.CbDestino.TabStop = False
        '
        'lbTerceiro
        '
        Me.lbTerceiro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTerceiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lbTerceiro.Location = New System.Drawing.Point(9, 59)
        Me.lbTerceiro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTerceiro.Name = "lbTerceiro"
        Me.lbTerceiro.Size = New System.Drawing.Size(165, 23)
        Me.lbTerceiro.TabIndex = 42
        Me.lbTerceiro.Text = "Terceiro"
        Me.lbTerceiro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dpDataDoc
        '
        Me.dpDataDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dpDataDoc.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpDataDoc.CustomFormat = "yyyy-MM-dd H:mm"
        Me.dpDataDoc.Enabled = False
        Me.dpDataDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpDataDoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpDataDoc.Location = New System.Drawing.Point(1177, 154)
        Me.dpDataDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.dpDataDoc.Name = "dpDataDoc"
        Me.dpDataDoc.Size = New System.Drawing.Size(243, 26)
        Me.dpDataDoc.TabIndex = 39
        Me.dpDataDoc.TabStop = False
        '
        'pBotoes
        '
        Me.pBotoes.Controls.Add(Me.btGravarDoc)
        Me.pBotoes.Controls.Add(Me.btSeparacao)
        Me.pBotoes.Controls.Add(Me.btDocs)
        Me.pBotoes.Controls.Add(Me.btPrintDoc)
        Me.pBotoes.Location = New System.Drawing.Point(16, 108)
        Me.pBotoes.Margin = New System.Windows.Forms.Padding(4)
        Me.pBotoes.Name = "pBotoes"
        Me.pBotoes.Size = New System.Drawing.Size(785, 46)
        Me.pBotoes.TabIndex = 72
        '
        'btGravarDoc
        '
        Me.btGravarDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGravarDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGravarDoc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGravarDoc.Location = New System.Drawing.Point(349, 5)
        Me.btGravarDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.btGravarDoc.Name = "btGravarDoc"
        Me.btGravarDoc.Size = New System.Drawing.Size(123, 36)
        Me.btGravarDoc.TabIndex = 43
        Me.btGravarDoc.Text = "Gravar"
        Me.btGravarDoc.UseVisualStyleBackColor = False
        '
        'btSeparacao
        '
        Me.btSeparacao.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSeparacao.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btSeparacao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSeparacao.Location = New System.Drawing.Point(13, 5)
        Me.btSeparacao.Margin = New System.Windows.Forms.Padding(4)
        Me.btSeparacao.Name = "btSeparacao"
        Me.btSeparacao.Size = New System.Drawing.Size(161, 34)
        Me.btSeparacao.TabIndex = 42
        Me.btSeparacao.Text = "Doc Origem"
        Me.btSeparacao.UseVisualStyleBackColor = False
        '
        'btDocs
        '
        Me.btDocs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btDocs.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btDocs.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDocs.Location = New System.Drawing.Point(611, 5)
        Me.btDocs.Margin = New System.Windows.Forms.Padding(4)
        Me.btDocs.Name = "btDocs"
        Me.btDocs.Size = New System.Drawing.Size(153, 36)
        Me.btDocs.TabIndex = 41
        Me.btDocs.Text = "Consultar"
        Me.btDocs.UseVisualStyleBackColor = False
        '
        'btPrintDoc
        '
        Me.btPrintDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btPrintDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btPrintDoc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPrintDoc.Location = New System.Drawing.Point(480, 5)
        Me.btPrintDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.btPrintDoc.Name = "btPrintDoc"
        Me.btPrintDoc.Size = New System.Drawing.Size(123, 36)
        Me.btPrintDoc.TabIndex = 37
        Me.btPrintDoc.Text = "Imprimir"
        Me.btPrintDoc.UseVisualStyleBackColor = False
        '
        'btFechar
        '
        Me.btFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFechar.Location = New System.Drawing.Point(1277, 23)
        Me.btFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(123, 36)
        Me.btFechar.TabIndex = 40
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'pObsDoc
        '
        Me.pObsDoc.Controls.Add(Me.lbdocOrig)
        Me.pObsDoc.Controls.Add(Me.tbDocOrigem)
        Me.pObsDoc.Controls.Add(Me.Label11)
        Me.pObsDoc.Controls.Add(Me.Label10)
        Me.pObsDoc.Controls.Add(Me.tbNIF)
        Me.pObsDoc.Controls.Add(Me.tbCountryDescarga)
        Me.pObsDoc.Controls.Add(Me.Label6)
        Me.pObsDoc.Controls.Add(Me.Label5)
        Me.pObsDoc.Controls.Add(Me.Label4)
        Me.pObsDoc.Controls.Add(Me.Label3)
        Me.pObsDoc.Controls.Add(Me.dpMovementStartTime)
        Me.pObsDoc.Controls.Add(Me.tbPostalCodeDescarga)
        Me.pObsDoc.Controls.Add(Me.tbCityDescarga)
        Me.pObsDoc.Controls.Add(Me.tbAddressDetailDescarga)
        Me.pObsDoc.Controls.Add(Me.tbPostalCodeCarga)
        Me.pObsDoc.Controls.Add(Me.tbCityCarga)
        Me.pObsDoc.Controls.Add(Me.tbObs)
        Me.pObsDoc.Controls.Add(Me.Label1)
        Me.pObsDoc.Controls.Add(Me.Label2)
        Me.pObsDoc.Controls.Add(Me.tbAddressDetailCarga)
        Me.pObsDoc.Controls.Add(Me.Label7)
        Me.pObsDoc.Location = New System.Drawing.Point(16, 165)
        Me.pObsDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.pObsDoc.Name = "pObsDoc"
        Me.pObsDoc.Size = New System.Drawing.Size(785, 262)
        Me.pObsDoc.TabIndex = 71
        '
        'lbdocOrig
        '
        Me.lbdocOrig.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbdocOrig.AutoSize = True
        Me.lbdocOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdocOrig.Location = New System.Drawing.Point(9, 187)
        Me.lbdocOrig.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbdocOrig.Name = "lbdocOrig"
        Me.lbdocOrig.Size = New System.Drawing.Size(224, 25)
        Me.lbdocOrig.TabIndex = 85
        Me.lbdocOrig.Text = "Documento de Origem : "
        Me.lbdocOrig.Visible = False
        '
        'tbDocOrigem
        '
        Me.tbDocOrigem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDocOrigem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDocOrigem.Location = New System.Drawing.Point(259, 186)
        Me.tbDocOrigem.Margin = New System.Windows.Forms.Padding(4)
        Me.tbDocOrigem.Name = "tbDocOrigem"
        Me.tbDocOrigem.Size = New System.Drawing.Size(301, 26)
        Me.tbDocOrigem.TabIndex = 84
        Me.tbDocOrigem.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(599, 186)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 25)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "País :"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(452, 146)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 25)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "NIF :"
        '
        'tbNIF
        '
        Me.tbNIF.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNIF.Location = New System.Drawing.Point(513, 145)
        Me.tbNIF.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNIF.Name = "tbNIF"
        Me.tbNIF.Size = New System.Drawing.Size(192, 26)
        Me.tbNIF.TabIndex = 81
        '
        'tbCountryDescarga
        '
        Me.tbCountryDescarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCountryDescarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCountryDescarga.Location = New System.Drawing.Point(669, 186)
        Me.tbCountryDescarga.Margin = New System.Windows.Forms.Padding(4)
        Me.tbCountryDescarga.Name = "tbCountryDescarga"
        Me.tbCountryDescarga.Size = New System.Drawing.Size(89, 26)
        Me.tbCountryDescarga.TabIndex = 80
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 146)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 25)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Saida : "
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 112)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 25)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "C.Postal : "
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 80)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 25)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Cidade : "
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 48)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 25)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Morada : "
        '
        'dpMovementStartTime
        '
        Me.dpMovementStartTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dpMovementStartTime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpMovementStartTime.CustomFormat = "yyyy-MM-dd H:mm"
        Me.dpMovementStartTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpMovementStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpMovementStartTime.Location = New System.Drawing.Point(120, 145)
        Me.dpMovementStartTime.Margin = New System.Windows.Forms.Padding(4)
        Me.dpMovementStartTime.Name = "dpMovementStartTime"
        Me.dpMovementStartTime.Size = New System.Drawing.Size(243, 26)
        Me.dpMovementStartTime.TabIndex = 75
        Me.dpMovementStartTime.TabStop = False
        '
        'tbPostalCodeDescarga
        '
        Me.tbPostalCodeDescarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPostalCodeDescarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPostalCodeDescarga.Location = New System.Drawing.Point(447, 110)
        Me.tbPostalCodeDescarga.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPostalCodeDescarga.Name = "tbPostalCodeDescarga"
        Me.tbPostalCodeDescarga.Size = New System.Drawing.Size(316, 26)
        Me.tbPostalCodeDescarga.TabIndex = 45
        '
        'tbCityDescarga
        '
        Me.tbCityDescarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCityDescarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCityDescarga.Location = New System.Drawing.Point(447, 78)
        Me.tbCityDescarga.Margin = New System.Windows.Forms.Padding(4)
        Me.tbCityDescarga.Name = "tbCityDescarga"
        Me.tbCityDescarga.Size = New System.Drawing.Size(316, 26)
        Me.tbCityDescarga.TabIndex = 44
        '
        'tbAddressDetailDescarga
        '
        Me.tbAddressDetailDescarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAddressDetailDescarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddressDetailDescarga.Location = New System.Drawing.Point(447, 46)
        Me.tbAddressDetailDescarga.Margin = New System.Windows.Forms.Padding(4)
        Me.tbAddressDetailDescarga.Name = "tbAddressDetailDescarga"
        Me.tbAddressDetailDescarga.Size = New System.Drawing.Size(316, 26)
        Me.tbAddressDetailDescarga.TabIndex = 43
        '
        'tbPostalCodeCarga
        '
        Me.tbPostalCodeCarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPostalCodeCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPostalCodeCarga.Location = New System.Drawing.Point(120, 111)
        Me.tbPostalCodeCarga.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPostalCodeCarga.Name = "tbPostalCodeCarga"
        Me.tbPostalCodeCarga.Size = New System.Drawing.Size(317, 26)
        Me.tbPostalCodeCarga.TabIndex = 42
        '
        'tbCityCarga
        '
        Me.tbCityCarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCityCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCityCarga.Location = New System.Drawing.Point(120, 79)
        Me.tbCityCarga.Margin = New System.Windows.Forms.Padding(4)
        Me.tbCityCarga.Name = "tbCityCarga"
        Me.tbCityCarga.Size = New System.Drawing.Size(317, 26)
        Me.tbCityCarga.TabIndex = 41
        '
        'tbObs
        '
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.Location = New System.Drawing.Point(73, 220)
        Me.tbObs.Margin = New System.Windows.Forms.Padding(4)
        Me.tbObs.Multiline = True
        Me.tbObs.Name = "tbObs"
        Me.tbObs.Size = New System.Drawing.Size(685, 32)
        Me.tbObs.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(116, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 25)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Carga"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(443, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 25)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Descarga"
        '
        'tbAddressDetailCarga
        '
        Me.tbAddressDetailCarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAddressDetailCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddressDetailCarga.Location = New System.Drawing.Point(120, 47)
        Me.tbAddressDetailCarga.Margin = New System.Windows.Forms.Padding(4)
        Me.tbAddressDetailCarga.Name = "tbAddressDetailCarga"
        Me.tbAddressDetailCarga.Size = New System.Drawing.Size(317, 26)
        Me.tbAddressDetailCarga.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 223)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 25)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Obs : "
        '
        'btCancelar
        '
        Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancelar.Location = New System.Drawing.Point(1136, 23)
        Me.btCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(123, 36)
        Me.btCancelar.TabIndex = 37
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1096, 155)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 25)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Data : "
        '
        'lbNrDoc
        '
        Me.lbNrDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNrDoc.AutoSize = True
        Me.lbNrDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNrDoc.Location = New System.Drawing.Point(1032, 118)
        Me.lbNrDoc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbNrDoc.Name = "lbNrDoc"
        Me.lbNrDoc.Size = New System.Drawing.Size(128, 25)
        Me.lbNrDoc.TabIndex = 78
        Me.lbNrDoc.Text = "Documento : "
        '
        'tbNrDoc
        '
        Me.tbNrDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNrDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNrDoc.Location = New System.Drawing.Point(1177, 116)
        Me.tbNrDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNrDoc.Name = "tbNrDoc"
        Me.tbNrDoc.Size = New System.Drawing.Size(243, 30)
        Me.tbNrDoc.TabIndex = 77
        Me.tbNrDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbNrAT
        '
        Me.lbNrAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNrAT.AutoSize = True
        Me.lbNrAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNrAT.Location = New System.Drawing.Point(1032, 79)
        Me.lbNrAT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbNrAT.Name = "lbNrAT"
        Me.lbNrAT.Size = New System.Drawing.Size(81, 25)
        Me.lbNrAT.TabIndex = 78
        Me.lbNrAT.Text = "Nº AT : "
        Me.lbNrAT.Visible = False
        '
        'tbNrAT
        '
        Me.tbNrAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNrAT.Enabled = False
        Me.tbNrAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNrAT.Location = New System.Drawing.Point(1177, 75)
        Me.tbNrAT.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNrAT.Name = "tbNrAT"
        Me.tbNrAT.Size = New System.Drawing.Size(243, 30)
        Me.tbNrAT.TabIndex = 77
        Me.tbNrAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbNrAT.Visible = False
        '
        'btPedirNrAT
        '
        Me.btPedirNrAT.Location = New System.Drawing.Point(1116, 75)
        Me.btPedirNrAT.Margin = New System.Windows.Forms.Padding(4)
        Me.btPedirNrAT.Name = "btPedirNrAT"
        Me.btPedirNrAT.Size = New System.Drawing.Size(47, 32)
        Me.btPedirNrAT.TabIndex = 79
        Me.btPedirNrAT.Text = "..."
        Me.btPedirNrAT.UseVisualStyleBackColor = True
        Me.btPedirNrAT.Visible = False
        '
        'lbIdDocCab
        '
        Me.lbIdDocCab.AutoSize = True
        Me.lbIdDocCab.Location = New System.Drawing.Point(836, 11)
        Me.lbIdDocCab.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbIdDocCab.Name = "lbIdDocCab"
        Me.lbIdDocCab.Size = New System.Drawing.Size(69, 17)
        Me.lbIdDocCab.TabIndex = 80
        Me.lbIdDocCab.Text = "IdDocCab"
        Me.lbIdDocCab.Visible = False
        '
        'TaxIVATableAdapter
        '
        Me.TaxIVATableAdapter.ClearBeforeFill = True
        '
        'lbIdDocCabOrig
        '
        Me.lbIdDocCabOrig.AutoSize = True
        Me.lbIdDocCabOrig.Location = New System.Drawing.Point(839, 55)
        Me.lbIdDocCabOrig.Name = "lbIdDocCabOrig"
        Me.lbIdDocCabOrig.Size = New System.Drawing.Size(107, 17)
        Me.lbIdDocCabOrig.TabIndex = 81
        Me.lbIdDocCabOrig.Text = "lbIdDocCabOrig"
        Me.lbIdDocCabOrig.Visible = False
        '
        'frmDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1437, 666)
        Me.Controls.Add(Me.lbIdDocCabOrig)
        Me.Controls.Add(Me.lbIdDocCab)
        Me.Controls.Add(Me.pObsDoc)
        Me.Controls.Add(Me.btPedirNrAT)
        Me.Controls.Add(Me.lbNrAT)
        Me.Controls.Add(Me.tbNrAT)
        Me.Controls.Add(Me.lbNrDoc)
        Me.Controls.Add(Me.tbNrDoc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PTotais)
        Me.Controls.Add(Me.dpDataDoc)
        Me.Controls.Add(Me.pDestinos)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.pBotoes)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.DocDetDataGridView)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDocs"
        Me.Text = "frmDocs"
        CType(Me.DocDetDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TaxIVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDetAuxBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PTotais.ResumeLayout(False)
        Me.PTotais.PerformLayout()
        CType(Me.txtTotDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pDestinos.ResumeLayout(False)
        Me.pBotoes.ResumeLayout(False)
        Me.pObsDoc.ResumeLayout(False)
        Me.pObsDoc.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DocDetDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DocDetAuxBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents TaxIVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TaxIVATableAdapter As GirlRootName.GirlDataSetTableAdapters.TaxIVATableAdapter
    Friend WithEvents lbTipoDoc As System.Windows.Forms.Label
    Friend WithEvents PTotais As System.Windows.Forms.Panel
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtDescontoAux As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbIva As System.Windows.Forms.Label
    Friend WithEvents tbDesconto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotDoc As C1.Win.C1Input.C1TextBox
    Friend WithEvents lbSubTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotIva As C1.Win.C1Input.C1TextBox
    Friend WithEvents txtSubTot As C1.Win.C1Input.C1TextBox
    Friend WithEvents pDestinos As System.Windows.Forms.Panel
    Friend WithEvents CbOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents lbOrigem As System.Windows.Forms.Label
    Friend WithEvents dpDataDoc As System.Windows.Forms.DateTimePicker
    Friend WithEvents CbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents lbTerceiro As System.Windows.Forms.Label
    Friend WithEvents pBotoes As System.Windows.Forms.Panel
    Friend WithEvents btDocs As System.Windows.Forms.Button
    Friend WithEvents btPrintDoc As System.Windows.Forms.Button
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents pObsDoc As System.Windows.Forms.Panel
    Friend WithEvents tbObs As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbAddressDetailCarga As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbCityCarga As System.Windows.Forms.TextBox
    Friend WithEvents tbPostalCodeDescarga As System.Windows.Forms.TextBox
    Friend WithEvents tbCityDescarga As System.Windows.Forms.TextBox
    Friend WithEvents tbAddressDetailDescarga As System.Windows.Forms.TextBox
    Friend WithEvents dpMovementStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btSeparacao As System.Windows.Forms.Button
    Friend WithEvents btCancelar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbNrDoc As System.Windows.Forms.Label
    Friend WithEvents tbNrDoc As System.Windows.Forms.TextBox
    Friend WithEvents btGravarDoc As System.Windows.Forms.Button
    Friend WithEvents lbNrAT As System.Windows.Forms.Label
    Friend WithEvents tbNrAT As System.Windows.Forms.TextBox
    Friend WithEvents btPedirNrAT As System.Windows.Forms.Button
    Friend WithEvents tbCountryDescarga As System.Windows.Forms.TextBox
    Friend WithEvents lbIdDocCab As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbNIF As System.Windows.Forms.TextBox
    Friend WithEvents lbDesconto As System.Windows.Forms.Label
    Friend WithEvents lbDescDoc As System.Windows.Forms.Label
    Friend WithEvents tbDescDoc As System.Windows.Forms.TextBox
    Friend WithEvents lbdocOrig As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbPostalCodeCarga As System.Windows.Forms.TextBox
    Friend WithEvents tbDocOrigem As System.Windows.Forms.TextBox
    Friend WithEvents Artigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModeloID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrUniLiq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VlrDescLiq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qtd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IvaID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TotalLiq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbIdDocCabOrig As Label
End Class
