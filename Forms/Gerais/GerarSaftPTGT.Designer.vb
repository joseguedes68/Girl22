<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GerarSaftPTGT
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
        Me.btGuias = New System.Windows.Forms.Button()
        Me.tbNrGuia = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btGeraSAFT
        '
        Me.btGeraSAFT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGeraSAFT.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btGeraSAFT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGeraSAFT.Location = New System.Drawing.Point(257, 38)
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
        Me.dpDeData.Location = New System.Drawing.Point(38, 28)
        Me.dpDeData.Name = "dpDeData"
        Me.dpDeData.Size = New System.Drawing.Size(182, 29)
        Me.dpDeData.TabIndex = 12
        '
        'dpAteData
        '
        Me.dpAteData.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpAteData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpAteData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpAteData.Location = New System.Drawing.Point(38, 62)
        Me.dpAteData.Name = "dpAteData"
        Me.dpAteData.Size = New System.Drawing.Size(182, 29)
        Me.dpAteData.TabIndex = 13
        '
        'btGuias
        '
        Me.btGuias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGuias.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btGuias.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGuias.Location = New System.Drawing.Point(257, 179)
        Me.btGuias.Name = "btGuias"
        Me.btGuias.Size = New System.Drawing.Size(159, 53)
        Me.btGuias.TabIndex = 11
        Me.btGuias.Text = "Guia Transporte"
        Me.btGuias.UseVisualStyleBackColor = False
        Me.btGuias.Visible = False
        '
        'tbNrGuia
        '
        Me.tbNrGuia.Location = New System.Drawing.Point(38, 193)
        Me.tbNrGuia.Name = "tbNrGuia"
        Me.tbNrGuia.Size = New System.Drawing.Size(182, 20)
        Me.tbNrGuia.TabIndex = 14
        Me.tbNrGuia.Visible = False
        '
        'GerarSaftPTGT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 244)
        Me.Controls.Add(Me.tbNrGuia)
        Me.Controls.Add(Me.dpAteData)
        Me.Controls.Add(Me.dpDeData)
        Me.Controls.Add(Me.btGuias)
        Me.Controls.Add(Me.btGeraSAFT)
        Me.Name = "GerarSaftPTGT"
        Me.Text = "GerarSaftPT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btGeraSAFT As System.Windows.Forms.Button
    Friend WithEvents dpDeData As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpAteData As System.Windows.Forms.DateTimePicker
    Friend WithEvents btGuias As System.Windows.Forms.Button
    Friend WithEvents tbNrGuia As System.Windows.Forms.TextBox
End Class
