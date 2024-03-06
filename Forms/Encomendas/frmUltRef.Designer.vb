<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUltRef
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
        Me.components = New System.ComponentModel.Container
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriçãoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescrAbrevDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UltRefDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UltRefTipoAbrevBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet
        Me.UltRefTipoAbrevTableAdapter = New GirlRootName.GirlDataSetTableAdapters.UltRefTipoAbrevTableAdapter
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltRefTipoAbrevBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GrDataGridViewTextBoxColumn, Me.DescriçãoDataGridViewTextBoxColumn, Me.DescrAbrevDataGridViewTextBoxColumn, Me.UltRefDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.UltRefTipoAbrevBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(502, 420)
        Me.DataGridView1.TabIndex = 0
        '
        'GrDataGridViewTextBoxColumn
        '
        Me.GrDataGridViewTextBoxColumn.DataPropertyName = "Gr"
        Me.GrDataGridViewTextBoxColumn.HeaderText = "Gr"
        Me.GrDataGridViewTextBoxColumn.Name = "GrDataGridViewTextBoxColumn"
        Me.GrDataGridViewTextBoxColumn.ReadOnly = True
        Me.GrDataGridViewTextBoxColumn.Width = 30
        '
        'DescriçãoDataGridViewTextBoxColumn
        '
        Me.DescriçãoDataGridViewTextBoxColumn.DataPropertyName = "Descrição"
        Me.DescriçãoDataGridViewTextBoxColumn.HeaderText = "Descrição"
        Me.DescriçãoDataGridViewTextBoxColumn.Name = "DescriçãoDataGridViewTextBoxColumn"
        Me.DescriçãoDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescriçãoDataGridViewTextBoxColumn.Width = 150
        '
        'DescrAbrevDataGridViewTextBoxColumn
        '
        Me.DescrAbrevDataGridViewTextBoxColumn.DataPropertyName = "DescrAbrev"
        Me.DescrAbrevDataGridViewTextBoxColumn.HeaderText = "DescrAbrev"
        Me.DescrAbrevDataGridViewTextBoxColumn.Name = "DescrAbrevDataGridViewTextBoxColumn"
        Me.DescrAbrevDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescrAbrevDataGridViewTextBoxColumn.Width = 150
        '
        'UltRefDataGridViewTextBoxColumn
        '
        Me.UltRefDataGridViewTextBoxColumn.DataPropertyName = "UltRef"
        Me.UltRefDataGridViewTextBoxColumn.HeaderText = "UltRef"
        Me.UltRefDataGridViewTextBoxColumn.Name = "UltRefDataGridViewTextBoxColumn"
        Me.UltRefDataGridViewTextBoxColumn.ReadOnly = True
        Me.UltRefDataGridViewTextBoxColumn.Width = 80
        '
        'UltRefTipoAbrevBindingSource
        '
        Me.UltRefTipoAbrevBindingSource.DataMember = "UltRefTipoAbrev"
        Me.UltRefTipoAbrevBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltRefTipoAbrevTableAdapter
        '
        Me.UltRefTipoAbrevTableAdapter.ClearBeforeFill = True
        '
        'frmUltRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 420)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmUltRef"
        Me.Text = "Ultima Modelo Criada"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltRefTipoAbrevBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents UltRefTipoAbrevBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UltRefTipoAbrevTableAdapter As GirlRootName.GirlDataSetTableAdapters.UltRefTipoAbrevTableAdapter
    Friend WithEvents GrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriçãoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescrAbrevDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UltRefDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
