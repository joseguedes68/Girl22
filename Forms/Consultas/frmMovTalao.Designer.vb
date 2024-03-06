<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovTalao
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvMovTalao = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTalao = New System.Windows.Forms.Label
        Me.btFechar = New System.Windows.Forms.Button
        Me.lbEstado = New System.Windows.Forms.Label
        CType(Me.dgvMovTalao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMovTalao
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvMovTalao.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMovTalao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.dgvMovTalao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovTalao.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvMovTalao.Location = New System.Drawing.Point(0, 89)
        Me.dgvMovTalao.Name = "dgvMovTalao"
        Me.dgvMovTalao.Size = New System.Drawing.Size(712, 319)
        Me.dgvMovTalao.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(323, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Talão :"
        '
        'lblTalao
        '
        Me.lblTalao.AutoSize = True
        Me.lblTalao.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTalao.Location = New System.Drawing.Point(403, 20)
        Me.lblTalao.Name = "lblTalao"
        Me.lblTalao.Size = New System.Drawing.Size(72, 22)
        Me.lblTalao.TabIndex = 1
        Me.lblTalao.Text = "Label1"
        '
        'btFechar
        '
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFechar.Location = New System.Drawing.Point(595, 15)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(93, 27)
        Me.btFechar.TabIndex = 2
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'lbEstado
        '
        Me.lbEstado.AutoSize = True
        Me.lbEstado.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEstado.Location = New System.Drawing.Point(12, 20)
        Me.lbEstado.Name = "lbEstado"
        Me.lbEstado.Size = New System.Drawing.Size(161, 22)
        Me.lbEstado.TabIndex = 3
        Me.lbEstado.Text = "Estado do Talão"
        '
        'frmMovTalao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 408)
        Me.Controls.Add(Me.lbEstado)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.lblTalao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvMovTalao)
        Me.Name = "frmMovTalao"
        Me.Text = "Movimentos do Talão"
        CType(Me.dgvMovTalao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvMovTalao As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTalao As System.Windows.Forms.Label
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents lbEstado As System.Windows.Forms.Label
End Class
