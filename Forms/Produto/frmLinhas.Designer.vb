<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLinhas
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
        Me.C1DbNavigator = New C1.Win.C1Input.C1DbNavigator
        Me.dgvLinhas = New System.Windows.Forms.DataGridView
        CType(Me.C1DbNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLinhas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1DbNavigator
        '
        Me.C1DbNavigator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.C1DbNavigator.Location = New System.Drawing.Point(12, 398)
        Me.C1DbNavigator.Name = "C1DbNavigator"
        Me.C1DbNavigator.Size = New System.Drawing.Size(265, 24)
        Me.C1DbNavigator.TabIndex = 1
        Me.C1DbNavigator.UIStrings.Content = New String() {"Row`::Linha:", "Do you want to delete the row?:Confirma que quer Apagar?", "(inactive):(Inativo)", "(empty):(Vazio)", "Confirmation:Confirmação"}
        '
        'dgvLinhas
        '
        Me.dgvLinhas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLinhas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLinhas.Location = New System.Drawing.Point(14, 12)
        Me.dgvLinhas.Name = "dgvLinhas"
        Me.dgvLinhas.Size = New System.Drawing.Size(432, 350)
        Me.dgvLinhas.TabIndex = 2
        '
        'frmLinhas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 434)
        Me.Controls.Add(Me.dgvLinhas)
        Me.Controls.Add(Me.C1DbNavigator)
        Me.Name = "frmLinhas"
        Me.Text = "Linhas"
        CType(Me.C1DbNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLinhas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1DbNavigator As C1.Win.C1Input.C1DbNavigator
    Friend WithEvents dgvLinhas As System.Windows.Forms.DataGridView
End Class
