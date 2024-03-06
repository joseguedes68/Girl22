<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GerarSaftV10401
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
        Me.btGeraSAFT = New System.Windows.Forms.Button()
        Me.dpDeData = New System.Windows.Forms.DateTimePicker()
        Me.dpAteData = New System.Windows.Forms.DateTimePicker()
        Me.cbIncGuiasTransp = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btGeraSAFT
        '
        Me.btGeraSAFT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGeraSAFT.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btGeraSAFT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGeraSAFT.Location = New System.Drawing.Point(257, 93)
        Me.btGeraSAFT.Name = "btGeraSAFT"
        Me.btGeraSAFT.Size = New System.Drawing.Size(159, 53)
        Me.btGeraSAFT.TabIndex = 11
        Me.btGeraSAFT.Text = "Gerar SAFT"
        Me.btGeraSAFT.UseVisualStyleBackColor = False
        '
        'dpDeData
        '
        Me.dpDeData.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpDeData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpDeData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDeData.Location = New System.Drawing.Point(40, 93)
        Me.dpDeData.Name = "dpDeData"
        Me.dpDeData.Size = New System.Drawing.Size(182, 29)
        Me.dpDeData.TabIndex = 12
        '
        'dpAteData
        '
        Me.dpAteData.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpAteData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpAteData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpAteData.Location = New System.Drawing.Point(40, 127)
        Me.dpAteData.Name = "dpAteData"
        Me.dpAteData.Size = New System.Drawing.Size(182, 29)
        Me.dpAteData.TabIndex = 13
        '
        'cbIncGuiasTransp
        '
        Me.cbIncGuiasTransp.AutoSize = True
        Me.cbIncGuiasTransp.Location = New System.Drawing.Point(257, 175)
        Me.cbIncGuiasTransp.Name = "cbIncGuiasTransp"
        Me.cbIncGuiasTransp.Size = New System.Drawing.Size(153, 17)
        Me.cbIncGuiasTransp.TabIndex = 15
        Me.cbIncGuiasTransp.Text = "Incluir Guias de Transporte"
        Me.cbIncGuiasTransp.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(287, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 34)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Fechar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GerarSaftV10301
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 244)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbIncGuiasTransp)
        Me.Controls.Add(Me.dpAteData)
        Me.Controls.Add(Me.dpDeData)
        Me.Controls.Add(Me.btGeraSAFT)
        Me.Name = "GerarSaftV10301"
        Me.Text = "GerarSaftPT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btGeraSAFT As System.Windows.Forms.Button
    Friend WithEvents dpDeData As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpAteData As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbIncGuiasTransp As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
