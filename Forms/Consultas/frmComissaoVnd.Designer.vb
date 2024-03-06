<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComissaoVnd
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
        Me.lbDeData = New System.Windows.Forms.Label()
        Me.dtPicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.btListar = New System.Windows.Forms.Button()
        Me.lbVendedor = New System.Windows.Forms.Label()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.cbVendedor = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lbDeData
        '
        Me.lbDeData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDeData.AutoSize = True
        Me.lbDeData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDeData.Location = New System.Drawing.Point(571, 10)
        Me.lbDeData.Name = "lbDeData"
        Me.lbDeData.Size = New System.Drawing.Size(143, 16)
        Me.lbDeData.TabIndex = 39
        Me.lbDeData.Text = "Intervalo de Datas :"
        '
        'dtPicker1
        '
        Me.dtPicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPicker1.Location = New System.Drawing.Point(854, 7)
        Me.dtPicker1.Name = "dtPicker1"
        Me.dtPicker1.Size = New System.Drawing.Size(113, 22)
        Me.dtPicker1.TabIndex = 38
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPicker.Location = New System.Drawing.Point(720, 7)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.Size = New System.Drawing.Size(113, 22)
        Me.dtPicker.TabIndex = 37
        '
        'btListar
        '
        Me.btListar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btListar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btListar.Location = New System.Drawing.Point(1001, 4)
        Me.btListar.Name = "btListar"
        Me.btListar.Size = New System.Drawing.Size(115, 28)
        Me.btListar.TabIndex = 40
        Me.btListar.Text = "Listar"
        Me.btListar.UseVisualStyleBackColor = True
        '
        'lbVendedor
        '
        Me.lbVendedor.AutoSize = True
        Me.lbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVendedor.Location = New System.Drawing.Point(17, 10)
        Me.lbVendedor.Name = "lbVendedor"
        Me.lbVendedor.Size = New System.Drawing.Size(102, 20)
        Me.lbVendedor.TabIndex = 41
        Me.lbVendedor.Text = "Vendedor : "
        '
        'btFechar
        '
        Me.btFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFechar.Location = New System.Drawing.Point(1138, 3)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(110, 30)
        Me.btFechar.TabIndex = 42
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'cbVendedor
        '
        Me.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendedor.FormattingEnabled = True
        Me.cbVendedor.Location = New System.Drawing.Point(125, 7)
        Me.cbVendedor.Name = "cbVendedor"
        Me.cbVendedor.Size = New System.Drawing.Size(265, 24)
        Me.cbVendedor.TabIndex = 45
        '
        'frmComissaoVnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 471)
        Me.Controls.Add(Me.cbVendedor)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.lbVendedor)
        Me.Controls.Add(Me.btListar)
        Me.Controls.Add(Me.lbDeData)
        Me.Controls.Add(Me.dtPicker1)
        Me.Controls.Add(Me.dtPicker)
        Me.Name = "frmComissaoVnd"
        Me.Text = "frmComissaoVnd"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbDeData As System.Windows.Forms.Label
    Friend WithEvents dtPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents btListar As System.Windows.Forms.Button
    Friend WithEvents lbVendedor As System.Windows.Forms.Label
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents cbVendedor As ComboBox
End Class
