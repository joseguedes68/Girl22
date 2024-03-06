<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransfStock
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbModeloOrigem = New System.Windows.Forms.ComboBox()
        Me.GirlDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.ModelosTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ModelosTableAdapter()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btTranfStock = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbModeloDestino = New System.Windows.Forms.ComboBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.GirlDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(54, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Origem:"
        '
        'cbModeloOrigem
        '
        Me.cbModeloOrigem.AllowDrop = True
        Me.cbModeloOrigem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbModeloOrigem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbModeloOrigem.DisplayMember = "ModeloID"
        Me.cbModeloOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModeloOrigem.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbModeloOrigem.FormattingEnabled = True
        Me.cbModeloOrigem.Location = New System.Drawing.Point(148, 16)
        Me.cbModeloOrigem.Name = "cbModeloOrigem"
        Me.cbModeloOrigem.Size = New System.Drawing.Size(269, 32)
        Me.cbModeloOrigem.TabIndex = 5
        Me.cbModeloOrigem.ValueMember = "ModeloID"
        '
        'GirlDataSetBindingSource
        '
        Me.GirlDataSetBindingSource.DataSource = Me.GirlDataSet
        Me.GirlDataSetBindingSource.Position = 0
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ModelosTableAdapter
        '
        Me.ModelosTableAdapter.ClearBeforeFill = True
        '
        'btFechar
        '
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFechar.Location = New System.Drawing.Point(490, 12)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(97, 35)
        Me.btFechar.TabIndex = 6
        Me.btFechar.TabStop = False
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'btTranfStock
        '
        Me.btTranfStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btTranfStock.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTranfStock.ForeColor = System.Drawing.Color.Red
        Me.btTranfStock.Location = New System.Drawing.Point(148, 128)
        Me.btTranfStock.Name = "btTranfStock"
        Me.btTranfStock.Size = New System.Drawing.Size(269, 42)
        Me.btTranfStock.TabIndex = 8
        Me.btTranfStock.TabStop = False
        Me.btTranfStock.Text = "TRANSFERIR"
        Me.btTranfStock.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Destino:"
        '
        'cbModeloDestino
        '
        Me.cbModeloDestino.AllowDrop = True
        Me.cbModeloDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbModeloDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbModeloDestino.DisplayMember = "ModeloID"
        Me.cbModeloDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModeloDestino.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbModeloDestino.FormattingEnabled = True
        Me.cbModeloDestino.Location = New System.Drawing.Point(148, 64)
        Me.cbModeloDestino.Name = "cbModeloDestino"
        Me.cbModeloDestino.Size = New System.Drawing.Size(269, 32)
        Me.cbModeloDestino.TabIndex = 10
        Me.cbModeloDestino.ValueMember = "ModeloID"
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "Modelos"
        Me.BindingSource1.DataSource = Me.GirlDataSetBindingSource
        '
        'BindingSource2
        '
        Me.BindingSource2.DataMember = "Modelos"
        Me.BindingSource2.DataSource = Me.GirlDataSetBindingSource
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(131, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(440, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Não esquecer actualizar o Preço na respectiva Tabela"
        '
        'frmTransfStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(599, 249)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbModeloDestino)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btTranfStock)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.cbModeloOrigem)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTransfStock"
        Me.Text = "Recodificação"
        CType(Me.GirlDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbModeloOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents GirlDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents ModelosTableAdapter As GirlRootName.GirlDataSetTableAdapters.ModelosTableAdapter
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents btTranfStock As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbModeloDestino As System.Windows.Forms.ComboBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
