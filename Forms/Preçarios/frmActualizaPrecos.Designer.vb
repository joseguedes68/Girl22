<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActualizaPrecos
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbArmazens = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTabela = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdAplicar = New System.Windows.Forms.Button()
        Me.DGView = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btAplicarTodas = New System.Windows.Forms.Button()
        Me.CmdFecharSep = New System.Windows.Forms.Button()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        CType(Me.DGView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Armazem"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbArmazens
        '
        Me.cmbArmazens.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbArmazens.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArmazens.FormattingEnabled = True
        Me.cmbArmazens.Location = New System.Drawing.Point(133, 21)
        Me.cmbArmazens.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbArmazens.Name = "cmbArmazens"
        Me.cmbArmazens.Size = New System.Drawing.Size(329, 24)
        Me.cmbArmazens.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tabela a aplicar"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTabela
        '
        Me.cmbTabela.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbTabela.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTabela.FormattingEnabled = True
        Me.cmbTabela.Location = New System.Drawing.Point(133, 53)
        Me.cmbTabela.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTabela.Name = "cmbTabela"
        Me.cmbTabela.Size = New System.Drawing.Size(329, 24)
        Me.cmbTabela.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(774, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Data:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Visible = False
        '
        'cmdAplicar
        '
        Me.cmdAplicar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdAplicar.Location = New System.Drawing.Point(485, 21)
        Me.cmdAplicar.Name = "cmdAplicar"
        Me.cmdAplicar.Size = New System.Drawing.Size(87, 56)
        Me.cmdAplicar.TabIndex = 3
        Me.cmdAplicar.Text = "Aplicar Tabela"
        Me.cmdAplicar.UseVisualStyleBackColor = False
        '
        'DGView
        '
        Me.DGView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGView.Location = New System.Drawing.Point(12, 123)
        Me.DGView.Name = "DGView"
        Me.DGView.Size = New System.Drawing.Size(930, 379)
        Me.DGView.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btAplicarTodas)
        Me.Panel1.Controls.Add(Me.CmdFecharSep)
        Me.Panel1.Controls.Add(Me.txtData)
        Me.Panel1.Controls.Add(Me.cmbArmazens)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmdAplicar)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbTabela)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(930, 105)
        Me.Panel1.TabIndex = 5
        '
        'btAplicarTodas
        '
        Me.btAplicarTodas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btAplicarTodas.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btAplicarTodas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btAplicarTodas.Location = New System.Drawing.Point(615, 24)
        Me.btAplicarTodas.Name = "btAplicarTodas"
        Me.btAplicarTodas.Size = New System.Drawing.Size(141, 48)
        Me.btAplicarTodas.TabIndex = 9
        Me.btAplicarTodas.Text = "Aplicar Todas"
        Me.btAplicarTodas.UseVisualStyleBackColor = False
        '
        'CmdFecharSep
        '
        Me.CmdFecharSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CmdFecharSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFecharSep.Location = New System.Drawing.Point(821, 11)
        Me.CmdFecharSep.Name = "CmdFecharSep"
        Me.CmdFecharSep.Size = New System.Drawing.Size(97, 30)
        Me.CmdFecharSep.TabIndex = 8
        Me.CmdFecharSep.Text = "Fechar"
        Me.CmdFecharSep.UseVisualStyleBackColor = False
        '
        'txtData
        '
        Me.txtData.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(821, 56)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(98, 22)
        Me.txtData.TabIndex = 4
        Me.txtData.Visible = False
        '
        'frmActualizaPrecos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 514)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGView)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmActualizaPrecos"
        Me.Text = "frmActualizaPrecos"
        CType(Me.DGView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbArmazens As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTabela As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdAplicar As System.Windows.Forms.Button
    Friend WithEvents DGView As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmdFecharSep As System.Windows.Forms.Button
    Friend WithEvents btAplicarTodas As System.Windows.Forms.Button
End Class
