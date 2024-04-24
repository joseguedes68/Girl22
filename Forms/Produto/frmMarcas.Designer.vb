<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMarcas
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.MarcasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MarcasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.MarcasTableAdapter()
        Me.MarcasDataGridView = New System.Windows.Forms.DataGridView()
        Me.MarcaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarcaDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MarcasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MarcasDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MarcasBindingSource
        '
        Me.MarcasBindingSource.DataMember = "Marcas"
        Me.MarcasBindingSource.DataSource = Me.GirlDataSet
        '
        'MarcasTableAdapter
        '
        Me.MarcasTableAdapter.ClearBeforeFill = True
        '
        'MarcasDataGridView
        '
        Me.MarcasDataGridView.AllowUserToOrderColumns = True
        Me.MarcasDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MarcasDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MarcasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MarcasDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MarcaID, Me.MarcaDescr, Me.DataGridViewTextBoxColumn3})
        Me.MarcasDataGridView.DataSource = Me.MarcasBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MarcasDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.MarcasDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MarcasDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.MarcasDataGridView.Name = "MarcasDataGridView"
        Me.MarcasDataGridView.RowHeadersWidth = 51
        Me.MarcasDataGridView.RowTemplate.Height = 24
        Me.MarcasDataGridView.Size = New System.Drawing.Size(864, 556)
        Me.MarcasDataGridView.TabIndex = 1
        '
        'MarcaID
        '
        Me.MarcaID.DataPropertyName = "MarcaID"
        Me.MarcaID.HeaderText = "MarcaID"
        Me.MarcaID.MinimumWidth = 6
        Me.MarcaID.Name = "MarcaID"
        Me.MarcaID.ReadOnly = True
        Me.MarcaID.Visible = False
        Me.MarcaID.Width = 125
        '
        'MarcaDescr
        '
        Me.MarcaDescr.DataPropertyName = "MarcaDescr"
        Me.MarcaDescr.HeaderText = "Marcas"
        Me.MarcaDescr.MinimumWidth = 6
        Me.MarcaDescr.Name = "MarcaDescr"
        Me.MarcaDescr.Width = 350
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "OperadorID"
        Me.DataGridViewTextBoxColumn3.HeaderText = "OperadorID"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 125
        '
        'frmMarcas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 556)
        Me.Controls.Add(Me.MarcasDataGridView)
        Me.Name = "frmMarcas"
        Me.Text = "frmMarcas"
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MarcasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MarcasDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GirlDataSet As GirlDataSet
    Friend WithEvents MarcasBindingSource As BindingSource
    Friend WithEvents MarcasTableAdapter As GirlDataSetTableAdapters.MarcasTableAdapter
    Friend WithEvents MarcasDataGridView As DataGridView
    Friend WithEvents MarcaID As DataGridViewTextBoxColumn
    Friend WithEvents MarcaDescr As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
End Class
