<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipos
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
        Me.C1DbNavigator = New C1.Win.C1Input.C1DbNavigator()
        Me.dgvTipos = New System.Windows.Forms.DataGridView()
        CType(Me.C1DbNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1DbNavigator
        '
        Me.C1DbNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.C1DbNavigator.Location = New System.Drawing.Point(0, 467)
        Me.C1DbNavigator.Name = "C1DbNavigator"
        Me.C1DbNavigator.Size = New System.Drawing.Size(912, 24)
        Me.C1DbNavigator.TabIndex = 1
        Me.C1DbNavigator.UIStrings.Content = New String() {"Row`::Linha:", "Do you want to delete the row?:Confirma que quer Apagar?", "(empty):(Vazio)", "Confirmation:Confirmação", "(inactive):(Inativo)"}
        Me.C1DbNavigator.VisibleButtons = CType(((((((C1.Win.C1Input.NavigatorButtonFlags.First Or C1.Win.C1Input.NavigatorButtonFlags.Previous) _
            Or C1.Win.C1Input.NavigatorButtonFlags.[Next]) _
            Or C1.Win.C1Input.NavigatorButtonFlags.Last) _
            Or C1.Win.C1Input.NavigatorButtonFlags.Add) _
            Or C1.Win.C1Input.NavigatorButtonFlags.Delete) _
            Or C1.Win.C1Input.NavigatorButtonFlags.Cancel), C1.Win.C1Input.NavigatorButtonFlags)
        '
        'dgvTipos
        '
        Me.dgvTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTipos.Location = New System.Drawing.Point(0, 0)
        Me.dgvTipos.Name = "dgvTipos"
        Me.dgvTipos.Size = New System.Drawing.Size(912, 467)
        Me.dgvTipos.TabIndex = 2
        '
        'frmTipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 491)
        Me.Controls.Add(Me.dgvTipos)
        Me.Controls.Add(Me.C1DbNavigator)
        Me.Name = "frmTipos"
        Me.Text = "Tipos"
        CType(Me.C1DbNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1DbNavigator As C1.Win.C1Input.C1DbNavigator
    Friend WithEvents dgvTipos As System.Windows.Forms.DataGridView
End Class
