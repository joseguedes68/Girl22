<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduct
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
        Me.dgvProdutos = New System.Windows.Forms.DataGridView()
        Me.btGravar = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.GirlDataSet1 = New GirlRootName.GirlDataSet()
        Me.UnidadesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UnidadesTableAdapter = New GirlRootName.GirlDataSetTableAdapters.UnidadesTableAdapter()
        Me.DtProductTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ProductTableAdapter()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductTypeID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ProductGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitOfMeasure = New System.Windows.Forms.DataGridViewComboBoxColumn()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnidadesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtProductTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProdutos
        '
        Me.dgvProdutos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvProdutos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProdutos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProdutos.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductCode, Me.ProductTypeID, Me.ProductGroup, Me.ProductDescription, Me.UnitOfMeasure})
        Me.dgvProdutos.DataSource = Me.ProductBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProdutos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProdutos.Location = New System.Drawing.Point(0, 70)
        Me.dgvProdutos.Name = "dgvProdutos"
        Me.dgvProdutos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvProdutos.Size = New System.Drawing.Size(793, 391)
        Me.dgvProdutos.TabIndex = 0
        '
        'btGravar
        '
        Me.btGravar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGravar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btGravar.Location = New System.Drawing.Point(460, 12)
        Me.btGravar.Name = "btGravar"
        Me.btGravar.Size = New System.Drawing.Size(143, 31)
        Me.btGravar.TabIndex = 1
        Me.btGravar.Text = "Gravar"
        Me.btGravar.UseVisualStyleBackColor = False
        '
        'btFechar
        '
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btFechar.Location = New System.Drawing.Point(634, 12)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(143, 31)
        Me.btFechar.TabIndex = 2
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'GirlDataSet1
        '
        Me.GirlDataSet1.DataSetName = "GirlDataSet"
        Me.GirlDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UnidadesBindingSource
        '
        Me.UnidadesBindingSource.DataMember = "Unidades"
        Me.UnidadesBindingSource.DataSource = Me.GirlDataSet1
        '
        'UnidadesTableAdapter
        '
        Me.UnidadesTableAdapter.ClearBeforeFill = True
        '
        'DtProductTypeBindingSource
        '
        Me.DtProductTypeBindingSource.DataMember = "dtProductType"
        Me.DtProductTypeBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProductBindingSource
        '
        Me.ProductBindingSource.DataMember = "Product"
        Me.ProductBindingSource.DataSource = Me.GirlDataSet
        '
        'ProductTableAdapter
        '
        Me.ProductTableAdapter.ClearBeforeFill = True
        '
        'ProductCode
        '
        Me.ProductCode.DataPropertyName = "ProductCode"
        Me.ProductCode.HeaderText = "Código"
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.Width = 150
        '
        'ProductTypeID
        '
        Me.ProductTypeID.DataPropertyName = "ProductType"
        Me.ProductTypeID.DataSource = Me.DtProductTypeBindingSource
        Me.ProductTypeID.DisplayMember = "ProductTypeDescr"
        Me.ProductTypeID.HeaderText = "Tipo"
        Me.ProductTypeID.Name = "ProductTypeID"
        Me.ProductTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ProductTypeID.ValueMember = "ProductTypeID"
        Me.ProductTypeID.Width = 150
        '
        'ProductGroup
        '
        Me.ProductGroup.DataPropertyName = "ProductGroup"
        Me.ProductGroup.HeaderText = "ProductGroup"
        Me.ProductGroup.Name = "ProductGroup"
        Me.ProductGroup.Visible = False
        '
        'ProductDescription
        '
        Me.ProductDescription.DataPropertyName = "ProductDescription"
        Me.ProductDescription.HeaderText = "Descrição"
        Me.ProductDescription.Name = "ProductDescription"
        Me.ProductDescription.Width = 300
        '
        'UnitOfMeasure
        '
        Me.UnitOfMeasure.DataPropertyName = "UnitOfMeasure"
        Me.UnitOfMeasure.DataSource = Me.UnidadesBindingSource
        Me.UnitOfMeasure.DisplayMember = "UnidDescr"
        Me.UnitOfMeasure.HeaderText = "Un"
        Me.UnitOfMeasure.Name = "UnitOfMeasure"
        Me.UnitOfMeasure.ValueMember = "UnidDescr"
        '
        'frmProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 461)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.btGravar)
        Me.Controls.Add(Me.dgvProdutos)
        Me.Name = "frmProduct"
        Me.Text = "Produtos"
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnidadesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtProductTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvProdutos As System.Windows.Forms.DataGridView
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents ProductBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProductTableAdapter As GirlRootName.GirlDataSetTableAdapters.ProductTableAdapter
    Friend WithEvents DtProductTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btGravar As System.Windows.Forms.Button
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents GirlDataSet1 As GirlRootName.GirlDataSet
    Friend WithEvents UnidadesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UnidadesTableAdapter As GirlRootName.GirlDataSetTableAdapters.UnidadesTableAdapter
    Friend WithEvents ProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTypeID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ProductGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitOfMeasure As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
