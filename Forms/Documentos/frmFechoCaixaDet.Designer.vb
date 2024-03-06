<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFechoCaixaDet
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
        Me.dgvFechoCaixaDet = New System.Windows.Forms.DataGridView()
        CType(Me.dgvFechoCaixaDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFechoCaixaDet
        '
        Me.dgvFechoCaixaDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFechoCaixaDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFechoCaixaDet.Location = New System.Drawing.Point(0, 0)
        Me.dgvFechoCaixaDet.Name = "dgvFechoCaixaDet"
        Me.dgvFechoCaixaDet.Size = New System.Drawing.Size(520, 380)
        Me.dgvFechoCaixaDet.TabIndex = 0
        '
        'frmFechoCaixaDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 380)
        Me.Controls.Add(Me.dgvFechoCaixaDet)
        Me.Name = "frmFechoCaixaDet"
        Me.Text = "frmFechoCaixaDet"
        CType(Me.dgvFechoCaixaDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvFechoCaixaDet As System.Windows.Forms.DataGridView
End Class
