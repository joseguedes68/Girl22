<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQrCode
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
        Me.btQrcode = New System.Windows.Forms.Button()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.tbtexto = New System.Windows.Forms.TextBox()
        Me.tbString = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btQrcode
        '
        Me.btQrcode.Location = New System.Drawing.Point(12, 399)
        Me.btQrcode.Name = "btQrcode"
        Me.btQrcode.Size = New System.Drawing.Size(139, 39)
        Me.btQrcode.TabIndex = 0
        Me.btQrcode.Text = "QrCode"
        Me.btQrcode.UseVisualStyleBackColor = True
        '
        'pic
        '
        Me.pic.Location = New System.Drawing.Point(460, 226)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(266, 212)
        Me.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'tbtexto
        '
        Me.tbtexto.Location = New System.Drawing.Point(12, 40)
        Me.tbtexto.Multiline = True
        Me.tbtexto.Name = "tbtexto"
        Me.tbtexto.Size = New System.Drawing.Size(683, 37)
        Me.tbtexto.TabIndex = 5
        '
        'tbString
        '
        Me.tbString.Location = New System.Drawing.Point(12, 83)
        Me.tbString.Multiline = True
        Me.tbString.Name = "tbString"
        Me.tbString.Size = New System.Drawing.Size(683, 105)
        Me.tbString.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(265, 399)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmQrCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbString)
        Me.Controls.Add(Me.tbtexto)
        Me.Controls.Add(Me.pic)
        Me.Controls.Add(Me.btQrcode)
        Me.Name = "frmQrCode"
        Me.Text = "frmQrCode"
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btQrcode As Button
    Friend WithEvents pic As PictureBox
    Friend WithEvents tbtexto As TextBox
    Friend WithEvents tbString As TextBox
    Friend WithEvents Button1 As Button
End Class
