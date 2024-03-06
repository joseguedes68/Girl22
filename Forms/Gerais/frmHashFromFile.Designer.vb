<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHashFromFile
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
        Me.btGerarHash = New System.Windows.Forms.Button()
        Me.tbHash = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btGerarHash
        '
        Me.btGerarHash.Location = New System.Drawing.Point(55, 22)
        Me.btGerarHash.Name = "btGerarHash"
        Me.btGerarHash.Size = New System.Drawing.Size(118, 23)
        Me.btGerarHash.TabIndex = 0
        Me.btGerarHash.Text = "Gerar Hash"
        Me.btGerarHash.UseVisualStyleBackColor = True
        '
        'tbHash
        '
        Me.tbHash.Location = New System.Drawing.Point(55, 69)
        Me.tbHash.Multiline = True
        Me.tbHash.Name = "tbHash"
        Me.tbHash.Size = New System.Drawing.Size(334, 127)
        Me.tbHash.TabIndex = 1
        '
        'frmHashFromFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 262)
        Me.Controls.Add(Me.tbHash)
        Me.Controls.Add(Me.btGerarHash)
        Me.Name = "frmHashFromFile"
        Me.Text = "Gerar Hash"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btGerarHash As System.Windows.Forms.Button
    Friend WithEvents tbHash As System.Windows.Forms.TextBox
End Class
