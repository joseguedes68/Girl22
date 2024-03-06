<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaDetalheDocs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDetalheDoc = New System.Windows.Forms.DataGridView()
        Me.DocDetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.DocDetTableAdapter = New GirlRootName.GirlDataSetTableAdapters.DocDetTableAdapter()
        Me.DocNrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModeloIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TamIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerieIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescricaoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalheDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDetalheDoc
        '
        Me.dgvDetalheDoc.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalheDoc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetalheDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalheDoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DocNrDataGridViewTextBoxColumn, Me.ProductCode, Me.ModeloIDDataGridViewTextBoxColumn, Me.CorIDDataGridViewTextBoxColumn, Me.TamIDDataGridViewTextBoxColumn, Me.SerieIDDataGridViewTextBoxColumn, Me.DescricaoDataGridViewTextBoxColumn, Me.ValorDataGridViewTextBoxColumn, Me.Comissao, Me.QtdDataGridViewTextBoxColumn, Me.ObsDataGridViewTextBoxColumn})
        Me.dgvDetalheDoc.DataSource = Me.DocDetBindingSource
        Me.dgvDetalheDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalheDoc.Location = New System.Drawing.Point(0, 0)
        Me.dgvDetalheDoc.Name = "dgvDetalheDoc"
        Me.dgvDetalheDoc.RowTemplate.Height = 24
        Me.dgvDetalheDoc.Size = New System.Drawing.Size(1393, 646)
        Me.dgvDetalheDoc.TabIndex = 0
        '
        'DocDetBindingSource
        '
        Me.DocDetBindingSource.DataMember = "DocDet"
        Me.DocDetBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DocDetTableAdapter
        '
        Me.DocDetTableAdapter.ClearBeforeFill = True
        '
        'DocNrDataGridViewTextBoxColumn
        '
        Me.DocNrDataGridViewTextBoxColumn.DataPropertyName = "DocNr"
        Me.DocNrDataGridViewTextBoxColumn.HeaderText = "DocNr"
        Me.DocNrDataGridViewTextBoxColumn.Name = "DocNrDataGridViewTextBoxColumn"
        Me.DocNrDataGridViewTextBoxColumn.Visible = False
        '
        'ProductCode
        '
        Me.ProductCode.DataPropertyName = "ProductCode"
        Me.ProductCode.HeaderText = "Produto"
        Me.ProductCode.Name = "ProductCode"
        '
        'ModeloIDDataGridViewTextBoxColumn
        '
        Me.ModeloIDDataGridViewTextBoxColumn.DataPropertyName = "ModeloID"
        Me.ModeloIDDataGridViewTextBoxColumn.HeaderText = "Modelo"
        Me.ModeloIDDataGridViewTextBoxColumn.Name = "ModeloIDDataGridViewTextBoxColumn"
        '
        'CorIDDataGridViewTextBoxColumn
        '
        Me.CorIDDataGridViewTextBoxColumn.DataPropertyName = "CorID"
        Me.CorIDDataGridViewTextBoxColumn.HeaderText = "Cor"
        Me.CorIDDataGridViewTextBoxColumn.Name = "CorIDDataGridViewTextBoxColumn"
        '
        'TamIDDataGridViewTextBoxColumn
        '
        Me.TamIDDataGridViewTextBoxColumn.DataPropertyName = "TamID"
        Me.TamIDDataGridViewTextBoxColumn.HeaderText = "Tam"
        Me.TamIDDataGridViewTextBoxColumn.Name = "TamIDDataGridViewTextBoxColumn"
        '
        'SerieIDDataGridViewTextBoxColumn
        '
        Me.SerieIDDataGridViewTextBoxColumn.DataPropertyName = "SerieID"
        Me.SerieIDDataGridViewTextBoxColumn.HeaderText = "Serie"
        Me.SerieIDDataGridViewTextBoxColumn.Name = "SerieIDDataGridViewTextBoxColumn"
        '
        'DescricaoDataGridViewTextBoxColumn
        '
        Me.DescricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao"
        Me.DescricaoDataGridViewTextBoxColumn.HeaderText = "Descrição"
        Me.DescricaoDataGridViewTextBoxColumn.Name = "DescricaoDataGridViewTextBoxColumn"
        '
        'ValorDataGridViewTextBoxColumn
        '
        Me.ValorDataGridViewTextBoxColumn.DataPropertyName = "Valor"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ValorDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ValorDataGridViewTextBoxColumn.HeaderText = "Valor"
        Me.ValorDataGridViewTextBoxColumn.Name = "ValorDataGridViewTextBoxColumn"
        '
        'Comissao
        '
        Me.Comissao.DataPropertyName = "Comissao"
        DataGridViewCellStyle3.Format = "p"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Comissao.DefaultCellStyle = DataGridViewCellStyle3
        Me.Comissao.HeaderText = "Comissão"
        Me.Comissao.Name = "Comissao"
        '
        'QtdDataGridViewTextBoxColumn
        '
        Me.QtdDataGridViewTextBoxColumn.DataPropertyName = "Qtd"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.QtdDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.QtdDataGridViewTextBoxColumn.HeaderText = "Qtd"
        Me.QtdDataGridViewTextBoxColumn.Name = "QtdDataGridViewTextBoxColumn"
        '
        'ObsDataGridViewTextBoxColumn
        '
        Me.ObsDataGridViewTextBoxColumn.DataPropertyName = "Obs"
        Me.ObsDataGridViewTextBoxColumn.HeaderText = "Obs"
        Me.ObsDataGridViewTextBoxColumn.Name = "ObsDataGridViewTextBoxColumn"
        Me.ObsDataGridViewTextBoxColumn.Visible = False
        '
        'frmConsultaDetalheDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1393, 646)
        Me.Controls.Add(Me.dgvDetalheDoc)
        Me.Name = "frmConsultaDetalheDocs"
        Me.Text = "frmConsultaDetalheDocs"
        CType(Me.dgvDetalheDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvDetalheDoc As DataGridView
    Friend WithEvents GirlDataSet As GirlDataSet
    Friend WithEvents DocDetBindingSource As BindingSource
    Friend WithEvents DocDetTableAdapter As GirlDataSetTableAdapters.DocDetTableAdapter
    Friend WithEvents DocNrDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductCode As DataGridViewTextBoxColumn
    Friend WithEvents ModeloIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CorIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TamIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SerieIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescricaoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ValorDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Comissao As DataGridViewTextBoxColumn
    Friend WithEvents QtdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ObsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
