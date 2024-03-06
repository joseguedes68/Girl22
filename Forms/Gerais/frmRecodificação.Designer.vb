<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecodificacao
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
        Me.tbModeloNovo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btRecodificar = New System.Windows.Forms.Button
        Me.cbModeloOrigem = New System.Windows.Forms.ComboBox
        Me.ModelosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet
        Me.ModelosTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ModelosTableAdapter
        Me.btFechar = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btTranfStock = New System.Windows.Forms.Button
        CType(Me.ModelosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbModeloNovo
        '
        Me.tbModeloNovo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModeloNovo.Location = New System.Drawing.Point(240, 79)
        Me.tbModeloNovo.Name = "tbModeloNovo"
        Me.tbModeloNovo.Size = New System.Drawing.Size(130, 32)
        Me.tbModeloNovo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(54, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Modelo Original :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(76, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Modelo Novo :"
        '
        'btRecodificar
        '
        Me.btRecodificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btRecodificar.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRecodificar.ForeColor = System.Drawing.Color.Red
        Me.btRecodificar.Location = New System.Drawing.Point(164, 140)
        Me.btRecodificar.Name = "btRecodificar"
        Me.btRecodificar.Size = New System.Drawing.Size(269, 42)
        Me.btRecodificar.TabIndex = 4
        Me.btRecodificar.TabStop = False
        Me.btRecodificar.Text = "RECODIFICAR"
        Me.btRecodificar.UseVisualStyleBackColor = False
        '
        'cbModeloOrigem
        '
        Me.cbModeloOrigem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbModeloOrigem.DataSource = Me.ModelosBindingSource
        Me.cbModeloOrigem.DisplayMember = "ModeloID"
        Me.cbModeloOrigem.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbModeloOrigem.FormattingEnabled = True
        Me.cbModeloOrigem.Location = New System.Drawing.Point(240, 16)
        Me.cbModeloOrigem.Name = "cbModeloOrigem"
        Me.cbModeloOrigem.Size = New System.Drawing.Size(130, 32)
        Me.cbModeloOrigem.TabIndex = 5
        Me.cbModeloOrigem.ValueMember = "ModeloID"
        '
        'ModelosBindingSource
        '
        Me.ModelosBindingSource.DataMember = "Modelos"
        Me.ModelosBindingSource.DataSource = Me.GirlDataSetBindingSource
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
        Me.btFechar.Location = New System.Drawing.Point(412, 12)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(97, 35)
        Me.btFechar.TabIndex = 6
        Me.btFechar.TabStop = False
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Button2.Location = New System.Drawing.Point(412, 70)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(97, 36)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'btTranfStock
        '
        Me.btTranfStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btTranfStock.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTranfStock.ForeColor = System.Drawing.Color.Red
        Me.btTranfStock.Location = New System.Drawing.Point(164, 212)
        Me.btTranfStock.Name = "btTranfStock"
        Me.btTranfStock.Size = New System.Drawing.Size(269, 42)
        Me.btTranfStock.TabIndex = 8
        Me.btTranfStock.TabStop = False
        Me.btTranfStock.Text = "TRANSFERIR STOCK"
        Me.btTranfStock.UseVisualStyleBackColor = False
        '
        'frmRecodificacao
        '
        Me.AcceptButton = Me.btRecodificar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(599, 278)
        Me.Controls.Add(Me.btTranfStock)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.cbModeloOrigem)
        Me.Controls.Add(Me.btRecodificar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbModeloNovo)
        Me.Name = "frmRecodificacao"
        Me.Text = "Recodificação"
        CType(Me.ModelosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbModeloNovo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btRecodificar As System.Windows.Forms.Button
    Friend WithEvents cbModeloOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents GirlDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents ModelosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ModelosTableAdapter As GirlRootName.GirlDataSetTableAdapters.ModelosTableAdapter
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btTranfStock As System.Windows.Forms.Button
End Class
