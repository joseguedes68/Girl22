<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistoricos
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.btArquivar = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.tbAno = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 33)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ano :"
        '
        'btArquivar
        '
        Me.btArquivar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btArquivar.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btArquivar.Location = New System.Drawing.Point(337, 102)
        Me.btArquivar.Name = "btArquivar"
        Me.btArquivar.Size = New System.Drawing.Size(163, 49)
        Me.btArquivar.TabIndex = 2
        Me.btArquivar.Text = "Arquivar"
        Me.btArquivar.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(482, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 39)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Fechar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'tbAno
        '
        Me.tbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!)
        Me.tbAno.Location = New System.Drawing.Point(176, 106)
        Me.tbAno.Name = "tbAno"
        Me.tbAno.Size = New System.Drawing.Size(143, 40)
        Me.tbAno.TabIndex = 4
        '
        'frmHistoricos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 221)
        Me.Controls.Add(Me.tbAno)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btArquivar)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmHistoricos"
        Me.Text = "frmHistoricos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btArquivar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbAno As System.Windows.Forms.TextBox
End Class
