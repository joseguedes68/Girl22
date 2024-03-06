<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ValidarXML
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtXML = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnValidaXML = New System.Windows.Forms.Button()
        Me.lstValida = New System.Windows.Forms.ListBox()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtXSD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SairToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1200, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Arquivo XML"
        '
        'txtXML
        '
        Me.txtXML.Location = New System.Drawing.Point(96, 32)
        Me.txtXML.Name = "txtXML"
        Me.txtXML.Size = New System.Drawing.Size(418, 20)
        Me.txtXML.TabIndex = 3
        Me.txtXML.Text = "cliente.xml"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(520, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Abrir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnValidaXML
        '
        Me.btnValidaXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidaXML.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnValidaXML.Location = New System.Drawing.Point(573, 30)
        Me.btnValidaXML.Name = "btnValidaXML"
        Me.btnValidaXML.Size = New System.Drawing.Size(98, 48)
        Me.btnValidaXML.TabIndex = 5
        Me.btnValidaXML.Text = "Validar XML"
        Me.btnValidaXML.UseVisualStyleBackColor = True
        '
        'lstValida
        '
        Me.lstValida.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstValida.FormattingEnabled = True
        Me.lstValida.Location = New System.Drawing.Point(0, 92)
        Me.lstValida.Name = "lstValida"
        Me.lstValida.Size = New System.Drawing.Size(1200, 160)
        Me.lstValida.TabIndex = 6
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(520, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(47, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Abrir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtXSD
        '
        Me.txtXSD.Location = New System.Drawing.Point(96, 58)
        Me.txtXSD.Name = "txtXSD"
        Me.txtXSD.Size = New System.Drawing.Size(418, 20)
        Me.txtXSD.TabIndex = 8
        Me.txtXSD.Text = "cliente.xsd"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Arquivo XSD"
        '
        'ValidarXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 252)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtXSD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lstValida)
        Me.Controls.Add(Me.btnValidaXML)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtXML)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ValidarXML"
        Me.Text = "Validando XML"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtXML As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnValidaXML As System.Windows.Forms.Button
    Friend WithEvents lstValida As System.Windows.Forms.ListBox
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtXSD As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
