<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlStock
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvControloStock = New System.Windows.Forms.DataGridView
        Me.cbArmazem = New System.Windows.Forms.ComboBox
        Me.ArmazensBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet
        Me.lbEnt = New System.Windows.Forms.Label
        Me.lbSai = New System.Windows.Forms.Label
        Me.lbExiste = New System.Windows.Forms.Label
        Me.lbStock = New System.Windows.Forms.Label
        Me.btLimpar = New System.Windows.Forms.Button
        Me.ArmazensTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ArmazensTableAdapter
        Me.tbAno = New System.Windows.Forms.TextBox
        Me.tbDeDoc = New System.Windows.Forms.TextBox
        Me.tbAteDoc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbFacturar = New System.Windows.Forms.Label
        Me.btFacturar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbDesconto = New System.Windows.Forms.TextBox
        Me.tbDeposito = New System.Windows.Forms.TextBox
        Me.btActualizar = New System.Windows.Forms.Button
        Me.btFechar = New System.Windows.Forms.Button
        CType(Me.dgvControloStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvControloStock
        '
        Me.dgvControloStock.AllowUserToAddRows = False
        Me.dgvControloStock.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvControloStock.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvControloStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvControloStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvControloStock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvControloStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvControloStock.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvControloStock.Location = New System.Drawing.Point(12, 174)
        Me.dgvControloStock.Name = "dgvControloStock"
        Me.dgvControloStock.Size = New System.Drawing.Size(890, 272)
        Me.dgvControloStock.TabIndex = 0
        '
        'cbArmazem
        '
        Me.cbArmazem.DataSource = Me.ArmazensBindingSource
        Me.cbArmazem.DisplayMember = "ArmAbrev"
        Me.cbArmazem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArmazem.FormattingEnabled = True
        Me.cbArmazem.Location = New System.Drawing.Point(40, 13)
        Me.cbArmazem.Name = "cbArmazem"
        Me.cbArmazem.Size = New System.Drawing.Size(207, 28)
        Me.cbArmazem.TabIndex = 1
        Me.cbArmazem.ValueMember = "ArmazemID"
        '
        'ArmazensBindingSource
        '
        Me.ArmazensBindingSource.DataMember = "Armazens"
        Me.ArmazensBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lbEnt
        '
        Me.lbEnt.AutoSize = True
        Me.lbEnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lbEnt.Location = New System.Drawing.Point(21, 143)
        Me.lbEnt.Name = "lbEnt"
        Me.lbEnt.Size = New System.Drawing.Size(94, 24)
        Me.lbEnt.TabIndex = 6
        Me.lbEnt.Text = "Entradas :"
        '
        'lbSai
        '
        Me.lbSai.AutoSize = True
        Me.lbSai.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lbSai.Location = New System.Drawing.Point(320, 143)
        Me.lbSai.Name = "lbSai"
        Me.lbSai.Size = New System.Drawing.Size(76, 24)
        Me.lbSai.TabIndex = 7
        Me.lbSai.Text = "Saidas :"
        '
        'lbExiste
        '
        Me.lbExiste.AutoSize = True
        Me.lbExiste.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lbExiste.Location = New System.Drawing.Point(480, 143)
        Me.lbExiste.Name = "lbExiste"
        Me.lbExiste.Size = New System.Drawing.Size(115, 24)
        Me.lbExiste.TabIndex = 8
        Me.lbExiste.Text = "Existências :"
        '
        'lbStock
        '
        Me.lbStock.AutoSize = True
        Me.lbStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lbStock.Location = New System.Drawing.Point(177, 143)
        Me.lbStock.Name = "lbStock"
        Me.lbStock.Size = New System.Drawing.Size(77, 24)
        Me.lbStock.TabIndex = 6
        Me.lbStock.Text = "Talões :"
        '
        'btLimpar
        '
        Me.btLimpar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btLimpar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btLimpar.Location = New System.Drawing.Point(177, 16)
        Me.btLimpar.Name = "btLimpar"
        Me.btLimpar.Size = New System.Drawing.Size(84, 38)
        Me.btLimpar.TabIndex = 9
        Me.btLimpar.Text = "Limpar"
        Me.btLimpar.UseVisualStyleBackColor = False
        '
        'ArmazensTableAdapter
        '
        Me.ArmazensTableAdapter.ClearBeforeFill = True
        '
        'tbAno
        '
        Me.tbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAno.Location = New System.Drawing.Point(331, 17)
        Me.tbAno.Name = "tbAno"
        Me.tbAno.Size = New System.Drawing.Size(100, 26)
        Me.tbAno.TabIndex = 10
        '
        'tbDeDoc
        '
        Me.tbDeDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDeDoc.Location = New System.Drawing.Point(60, 10)
        Me.tbDeDoc.Name = "tbDeDoc"
        Me.tbDeDoc.Size = New System.Drawing.Size(105, 22)
        Me.tbDeDoc.TabIndex = 11
        '
        'tbAteDoc
        '
        Me.tbAteDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAteDoc.Location = New System.Drawing.Point(60, 37)
        Me.tbAteDoc.Name = "tbAteDoc"
        Me.tbAteDoc.Size = New System.Drawing.Size(104, 22)
        Me.tbAteDoc.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label1.Location = New System.Drawing.Point(275, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 24)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Ano:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 18)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "De :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 18)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Até :"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tbAteDoc)
        Me.Panel1.Controls.Add(Me.tbDeDoc)
        Me.Panel1.Controls.Add(Me.btLimpar)
        Me.Panel1.Location = New System.Drawing.Point(40, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(282, 72)
        Me.Panel1.TabIndex = 16
        '
        'lbFacturar
        '
        Me.lbFacturar.AutoSize = True
        Me.lbFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lbFacturar.Location = New System.Drawing.Point(663, 143)
        Me.lbFacturar.Name = "lbFacturar"
        Me.lbFacturar.Size = New System.Drawing.Size(89, 24)
        Me.lbFacturar.TabIndex = 17
        Me.lbFacturar.Text = "Facturar :"
        '
        'btFacturar
        '
        Me.btFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFacturar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btFacturar.Location = New System.Drawing.Point(783, 100)
        Me.btFacturar.Name = "btFacturar"
        Me.btFacturar.Size = New System.Drawing.Size(114, 33)
        Me.btFacturar.TabIndex = 18
        Me.btFacturar.Text = "Facturar"
        Me.btFacturar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label4.Location = New System.Drawing.Point(692, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 24)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Desconto % :"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label5.Location = New System.Drawing.Point(683, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 24)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Deposito :"
        '
        'tbDesconto
        '
        Me.tbDesconto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDesconto.Location = New System.Drawing.Point(812, 39)
        Me.tbDesconto.Name = "tbDesconto"
        Me.tbDesconto.Size = New System.Drawing.Size(48, 26)
        Me.tbDesconto.TabIndex = 21
        Me.tbDesconto.Text = "45"
        Me.tbDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbDeposito
        '
        Me.tbDeposito.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDeposito.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDeposito.Location = New System.Drawing.Point(783, 72)
        Me.tbDeposito.Name = "tbDeposito"
        Me.tbDeposito.Size = New System.Drawing.Size(114, 19)
        Me.tbDeposito.TabIndex = 22
        '
        'btActualizar
        '
        Me.btActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btActualizar.Location = New System.Drawing.Point(452, 17)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Size = New System.Drawing.Size(109, 26)
        Me.btActualizar.TabIndex = 23
        Me.btActualizar.Text = "Actualizar"
        Me.btActualizar.UseVisualStyleBackColor = False
        '
        'btFechar
        '
        Me.btFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btFechar.Location = New System.Drawing.Point(781, 4)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(121, 29)
        Me.btFechar.TabIndex = 24
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'frmControlStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(914, 496)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.btActualizar)
        Me.Controls.Add(Me.tbDeposito)
        Me.Controls.Add(Me.tbDesconto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btFacturar)
        Me.Controls.Add(Me.lbFacturar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbAno)
        Me.Controls.Add(Me.lbExiste)
        Me.Controls.Add(Me.lbSai)
        Me.Controls.Add(Me.lbStock)
        Me.Controls.Add(Me.lbEnt)
        Me.Controls.Add(Me.cbArmazem)
        Me.Controls.Add(Me.dgvControloStock)
        Me.Name = "frmControlStock"
        Me.Text = "frmControlStock"
        CType(Me.dgvControloStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvControloStock As System.Windows.Forms.DataGridView
    Friend WithEvents cbArmazem As System.Windows.Forms.ComboBox
    Friend WithEvents lbEnt As System.Windows.Forms.Label
    Friend WithEvents lbSai As System.Windows.Forms.Label
    Friend WithEvents lbExiste As System.Windows.Forms.Label
    Friend WithEvents lbStock As System.Windows.Forms.Label
    Friend WithEvents btLimpar As System.Windows.Forms.Button
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents ArmazensBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ArmazensTableAdapter As GirlRootName.GirlDataSetTableAdapters.ArmazensTableAdapter
    Friend WithEvents tbAno As System.Windows.Forms.TextBox
    Friend WithEvents tbDeDoc As System.Windows.Forms.TextBox
    Friend WithEvents tbAteDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbFacturar As System.Windows.Forms.Label
    Friend WithEvents btFacturar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbDesconto As System.Windows.Forms.TextBox
    Friend WithEvents tbDeposito As System.Windows.Forms.TextBox
    Friend WithEvents btActualizar As System.Windows.Forms.Button
    Friend WithEvents btFechar As System.Windows.Forms.Button
End Class
