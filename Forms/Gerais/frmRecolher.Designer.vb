<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecolher
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
        Me.dgvRecolherCab = New System.Windows.Forms.DataGridView()
        Me.cbVerTodas = New System.Windows.Forms.CheckBox()
        Me.cmdFechar = New System.Windows.Forms.Button()
        Me.CmdGerRecolha = New System.Windows.Forms.Button()
        CType(Me.dgvRecolherCab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRecolherCab
        '
        Me.dgvRecolherCab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvRecolherCab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecolherCab.Location = New System.Drawing.Point(12, 43)
        Me.dgvRecolherCab.Name = "dgvRecolherCab"
        Me.dgvRecolherCab.Size = New System.Drawing.Size(399, 381)
        Me.dgvRecolherCab.TabIndex = 0
        '
        'cbVerTodas
        '
        Me.cbVerTodas.AutoSize = True
        Me.cbVerTodas.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbVerTodas.Location = New System.Drawing.Point(207, 12)
        Me.cbVerTodas.Name = "cbVerTodas"
        Me.cbVerTodas.Size = New System.Drawing.Size(127, 25)
        Me.cbVerTodas.TabIndex = 33
        Me.cbVerTodas.Text = "Ver Todas"
        Me.cbVerTodas.UseVisualStyleBackColor = True
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdFechar.Location = New System.Drawing.Point(822, 9)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(122, 28)
        Me.cmdFechar.TabIndex = 35
        Me.cmdFechar.Text = "Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'CmdGerRecolha
        '
        Me.CmdGerRecolha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdGerRecolha.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdGerRecolha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CmdGerRecolha.Location = New System.Drawing.Point(683, 9)
        Me.CmdGerRecolha.Name = "CmdGerRecolha"
        Me.CmdGerRecolha.Size = New System.Drawing.Size(119, 28)
        Me.CmdGerRecolha.TabIndex = 34
        Me.CmdGerRecolha.Text = "Recolher"
        Me.CmdGerRecolha.UseVisualStyleBackColor = False
        '
        'frmRecolher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 436)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.CmdGerRecolha)
        Me.Controls.Add(Me.cbVerTodas)
        Me.Controls.Add(Me.dgvRecolherCab)
        Me.Name = "frmRecolher"
        Me.Text = "frmRecolher1"
        CType(Me.dgvRecolherCab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvRecolherCab As System.Windows.Forms.DataGridView
    Friend WithEvents cbVerTodas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents CmdGerRecolha As System.Windows.Forms.Button
End Class
