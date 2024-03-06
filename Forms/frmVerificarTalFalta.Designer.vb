<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerificarTalFalta
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
        Me.dgvRelacaoTaloes = New System.Windows.Forms.DataGridView()
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.GirlDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SerieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SerieTableAdapter = New GirlRootName.GirlDataSetTableAdapters.SerieTableAdapter()
        Me.SerieIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModeloIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TamIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArmazemIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecoEtiquetaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecoVendaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComissaoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NrEncDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtEntradaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocNrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PVndRealDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtSaidaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperadorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtRegistoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvRelacaoTaloes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SerieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRelacaoTaloes
        '
        Me.dgvRelacaoTaloes.AutoGenerateColumns = False
        Me.dgvRelacaoTaloes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRelacaoTaloes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SerieIDDataGridViewTextBoxColumn, Me.ModeloIDDataGridViewTextBoxColumn, Me.CorIDDataGridViewTextBoxColumn, Me.TamIDDataGridViewTextBoxColumn, Me.ArmazemIDDataGridViewTextBoxColumn, Me.PrecoEtiquetaDataGridViewTextBoxColumn, Me.PrecoVendaDataGridViewTextBoxColumn, Me.ComissaoDataGridViewTextBoxColumn, Me.NrEncDataGridViewTextBoxColumn, Me.DtEntradaDataGridViewTextBoxColumn, Me.DocNrDataGridViewTextBoxColumn, Me.PVndRealDataGridViewTextBoxColumn, Me.DtSaidaDataGridViewTextBoxColumn, Me.EstadoIDDataGridViewTextBoxColumn, Me.OperadorIDDataGridViewTextBoxColumn, Me.DtRegistoDataGridViewTextBoxColumn})
        Me.dgvRelacaoTaloes.DataSource = Me.SerieBindingSource
        Me.dgvRelacaoTaloes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvRelacaoTaloes.Location = New System.Drawing.Point(0, 123)
        Me.dgvRelacaoTaloes.Name = "dgvRelacaoTaloes"
        Me.dgvRelacaoTaloes.Size = New System.Drawing.Size(1769, 327)
        Me.dgvRelacaoTaloes.TabIndex = 0
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GirlDataSetBindingSource
        '
        Me.GirlDataSetBindingSource.DataSource = Me.GirlDataSet
        Me.GirlDataSetBindingSource.Position = 0
        '
        'SerieBindingSource
        '
        Me.SerieBindingSource.DataMember = "Serie"
        Me.SerieBindingSource.DataSource = Me.GirlDataSetBindingSource
        '
        'SerieTableAdapter
        '
        Me.SerieTableAdapter.ClearBeforeFill = True
        '
        'SerieIDDataGridViewTextBoxColumn
        '
        Me.SerieIDDataGridViewTextBoxColumn.DataPropertyName = "SerieID"
        Me.SerieIDDataGridViewTextBoxColumn.HeaderText = "SerieID"
        Me.SerieIDDataGridViewTextBoxColumn.Name = "SerieIDDataGridViewTextBoxColumn"
        '
        'ModeloIDDataGridViewTextBoxColumn
        '
        Me.ModeloIDDataGridViewTextBoxColumn.DataPropertyName = "ModeloID"
        Me.ModeloIDDataGridViewTextBoxColumn.HeaderText = "ModeloID"
        Me.ModeloIDDataGridViewTextBoxColumn.Name = "ModeloIDDataGridViewTextBoxColumn"
        '
        'CorIDDataGridViewTextBoxColumn
        '
        Me.CorIDDataGridViewTextBoxColumn.DataPropertyName = "CorID"
        Me.CorIDDataGridViewTextBoxColumn.HeaderText = "CorID"
        Me.CorIDDataGridViewTextBoxColumn.Name = "CorIDDataGridViewTextBoxColumn"
        '
        'TamIDDataGridViewTextBoxColumn
        '
        Me.TamIDDataGridViewTextBoxColumn.DataPropertyName = "TamID"
        Me.TamIDDataGridViewTextBoxColumn.HeaderText = "TamID"
        Me.TamIDDataGridViewTextBoxColumn.Name = "TamIDDataGridViewTextBoxColumn"
        '
        'ArmazemIDDataGridViewTextBoxColumn
        '
        Me.ArmazemIDDataGridViewTextBoxColumn.DataPropertyName = "ArmazemID"
        Me.ArmazemIDDataGridViewTextBoxColumn.HeaderText = "ArmazemID"
        Me.ArmazemIDDataGridViewTextBoxColumn.Name = "ArmazemIDDataGridViewTextBoxColumn"
        '
        'PrecoEtiquetaDataGridViewTextBoxColumn
        '
        Me.PrecoEtiquetaDataGridViewTextBoxColumn.DataPropertyName = "PrecoEtiqueta"
        Me.PrecoEtiquetaDataGridViewTextBoxColumn.HeaderText = "PrecoEtiqueta"
        Me.PrecoEtiquetaDataGridViewTextBoxColumn.Name = "PrecoEtiquetaDataGridViewTextBoxColumn"
        '
        'PrecoVendaDataGridViewTextBoxColumn
        '
        Me.PrecoVendaDataGridViewTextBoxColumn.DataPropertyName = "PrecoVenda"
        Me.PrecoVendaDataGridViewTextBoxColumn.HeaderText = "PrecoVenda"
        Me.PrecoVendaDataGridViewTextBoxColumn.Name = "PrecoVendaDataGridViewTextBoxColumn"
        '
        'ComissaoDataGridViewTextBoxColumn
        '
        Me.ComissaoDataGridViewTextBoxColumn.DataPropertyName = "Comissao"
        Me.ComissaoDataGridViewTextBoxColumn.HeaderText = "Comissao"
        Me.ComissaoDataGridViewTextBoxColumn.Name = "ComissaoDataGridViewTextBoxColumn"
        '
        'NrEncDataGridViewTextBoxColumn
        '
        Me.NrEncDataGridViewTextBoxColumn.DataPropertyName = "NrEnc"
        Me.NrEncDataGridViewTextBoxColumn.HeaderText = "NrEnc"
        Me.NrEncDataGridViewTextBoxColumn.Name = "NrEncDataGridViewTextBoxColumn"
        '
        'DtEntradaDataGridViewTextBoxColumn
        '
        Me.DtEntradaDataGridViewTextBoxColumn.DataPropertyName = "DtEntrada"
        Me.DtEntradaDataGridViewTextBoxColumn.HeaderText = "DtEntrada"
        Me.DtEntradaDataGridViewTextBoxColumn.Name = "DtEntradaDataGridViewTextBoxColumn"
        '
        'DocNrDataGridViewTextBoxColumn
        '
        Me.DocNrDataGridViewTextBoxColumn.DataPropertyName = "DocNr"
        Me.DocNrDataGridViewTextBoxColumn.HeaderText = "DocNr"
        Me.DocNrDataGridViewTextBoxColumn.Name = "DocNrDataGridViewTextBoxColumn"
        '
        'PVndRealDataGridViewTextBoxColumn
        '
        Me.PVndRealDataGridViewTextBoxColumn.DataPropertyName = "PVndReal"
        Me.PVndRealDataGridViewTextBoxColumn.HeaderText = "PVndReal"
        Me.PVndRealDataGridViewTextBoxColumn.Name = "PVndRealDataGridViewTextBoxColumn"
        '
        'DtSaidaDataGridViewTextBoxColumn
        '
        Me.DtSaidaDataGridViewTextBoxColumn.DataPropertyName = "DtSaida"
        Me.DtSaidaDataGridViewTextBoxColumn.HeaderText = "DtSaida"
        Me.DtSaidaDataGridViewTextBoxColumn.Name = "DtSaidaDataGridViewTextBoxColumn"
        '
        'EstadoIDDataGridViewTextBoxColumn
        '
        Me.EstadoIDDataGridViewTextBoxColumn.DataPropertyName = "EstadoID"
        Me.EstadoIDDataGridViewTextBoxColumn.HeaderText = "EstadoID"
        Me.EstadoIDDataGridViewTextBoxColumn.Name = "EstadoIDDataGridViewTextBoxColumn"
        '
        'OperadorIDDataGridViewTextBoxColumn
        '
        Me.OperadorIDDataGridViewTextBoxColumn.DataPropertyName = "OperadorID"
        Me.OperadorIDDataGridViewTextBoxColumn.HeaderText = "OperadorID"
        Me.OperadorIDDataGridViewTextBoxColumn.Name = "OperadorIDDataGridViewTextBoxColumn"
        '
        'DtRegistoDataGridViewTextBoxColumn
        '
        Me.DtRegistoDataGridViewTextBoxColumn.DataPropertyName = "DtRegisto"
        Me.DtRegistoDataGridViewTextBoxColumn.HeaderText = "DtRegisto"
        Me.DtRegistoDataGridViewTextBoxColumn.Name = "DtRegistoDataGridViewTextBoxColumn"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(122, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(274, 55)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cruzar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmVerificarTalFalta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1769, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvRelacaoTaloes)
        Me.Name = "frmVerificarTalFalta"
        Me.Text = "frmVerificarTalFalta"
        CType(Me.dgvRelacaoTaloes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SerieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvRelacaoTaloes As DataGridView
    Friend WithEvents GirlDataSetBindingSource As BindingSource
    Friend WithEvents GirlDataSet As GirlDataSet
    Friend WithEvents SerieBindingSource As BindingSource
    Friend WithEvents SerieTableAdapter As GirlDataSetTableAdapters.SerieTableAdapter
    Friend WithEvents SerieIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModeloIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CorIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TamIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ArmazemIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrecoEtiquetaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrecoVendaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ComissaoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NrEncDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DtEntradaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DocNrDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PVndRealDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DtSaidaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EstadoIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OperadorIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DtRegistoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
End Class
