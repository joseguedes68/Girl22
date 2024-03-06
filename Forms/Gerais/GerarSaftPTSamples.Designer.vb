<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GerarSaftPTSamples
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btExibeSAFT = New System.Windows.Forms.Button()
        Me.btGeraSAFT = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(59, 60)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(413, 312)
        Me.DataGridView1.TabIndex = 9
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(59, 407)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(102, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Exibe XML"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(167, 378)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Gera XML com atributos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(59, 378)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Gera XML"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(167, 407)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(135, 23)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "Exibe XML"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btExibeSAFT
        '
        Me.btExibeSAFT.Location = New System.Drawing.Point(337, 407)
        Me.btExibeSAFT.Name = "btExibeSAFT"
        Me.btExibeSAFT.Size = New System.Drawing.Size(135, 23)
        Me.btExibeSAFT.TabIndex = 12
        Me.btExibeSAFT.Text = "Exibe SAFT"
        Me.btExibeSAFT.UseVisualStyleBackColor = True
        '
        'btGeraSAFT
        '
        Me.btGeraSAFT.Location = New System.Drawing.Point(337, 378)
        Me.btGeraSAFT.Name = "btGeraSAFT"
        Me.btGeraSAFT.Size = New System.Drawing.Size(135, 23)
        Me.btGeraSAFT.TabIndex = 11
        Me.btGeraSAFT.Text = "Gera SAFT"
        Me.btGeraSAFT.UseVisualStyleBackColor = True
        '
        'GerarSaftPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 474)
        Me.Controls.Add(Me.btExibeSAFT)
        Me.Controls.Add(Me.btGeraSAFT)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "GerarSaftPT"
        Me.Text = "GerarSaftPT"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btExibeSAFT As System.Windows.Forms.Button
    Friend WithEvents btGeraSAFT As System.Windows.Forms.Button
End Class
