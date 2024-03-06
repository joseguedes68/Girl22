<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdisco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmdisco))
        Me.btnSerial = New System.Windows.Forms.Button()
        Me.btnEspacoLivre = New System.Windows.Forms.Button()
        Me.btnTamanho = New System.Windows.Forms.Button()
        Me.btnTipo = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDrive = New System.Windows.Forms.ComboBox()
        Me.btnInfoSistema = New System.Windows.Forms.Button()
        Me.btnModelo = New System.Windows.Forms.Button()
        Me.btnInfoDispositivos = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSerial
        '
        Me.btnSerial.BackColor = System.Drawing.Color.White
        Me.btnSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSerial.Image = CType(resources.GetObject("btnSerial.Image"), System.Drawing.Image)
        Me.btnSerial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSerial.Location = New System.Drawing.Point(24, 55)
        Me.btnSerial.Name = "btnSerial"
        Me.btnSerial.Size = New System.Drawing.Size(312, 50)
        Me.btnSerial.TabIndex = 0
        Me.btnSerial.Text = "Número Serial do HD"
        Me.btnSerial.UseVisualStyleBackColor = False
        '
        'btnEspacoLivre
        '
        Me.btnEspacoLivre.BackColor = System.Drawing.Color.White
        Me.btnEspacoLivre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEspacoLivre.Image = CType(resources.GetObject("btnEspacoLivre.Image"), System.Drawing.Image)
        Me.btnEspacoLivre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEspacoLivre.Location = New System.Drawing.Point(24, 115)
        Me.btnEspacoLivre.Name = "btnEspacoLivre"
        Me.btnEspacoLivre.Size = New System.Drawing.Size(312, 50)
        Me.btnEspacoLivre.TabIndex = 0
        Me.btnEspacoLivre.Text = "Espaço Livre Disponível no HD"
        Me.btnEspacoLivre.UseVisualStyleBackColor = False
        '
        'btnTamanho
        '
        Me.btnTamanho.BackColor = System.Drawing.Color.White
        Me.btnTamanho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTamanho.Image = CType(resources.GetObject("btnTamanho.Image"), System.Drawing.Image)
        Me.btnTamanho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTamanho.Location = New System.Drawing.Point(24, 175)
        Me.btnTamanho.Name = "btnTamanho"
        Me.btnTamanho.Size = New System.Drawing.Size(312, 50)
        Me.btnTamanho.TabIndex = 0
        Me.btnTamanho.Text = "Tamanho do HD"
        Me.btnTamanho.UseVisualStyleBackColor = False
        '
        'btnTipo
        '
        Me.btnTipo.BackColor = System.Drawing.Color.White
        Me.btnTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTipo.Image = CType(resources.GetObject("btnTipo.Image"), System.Drawing.Image)
        Me.btnTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTipo.Location = New System.Drawing.Point(24, 235)
        Me.btnTipo.Name = "btnTipo"
        Me.btnTipo.Size = New System.Drawing.Size(312, 50)
        Me.btnTipo.TabIndex = 0
        Me.btnTipo.Text = "Tipo de drive do HD"
        Me.btnTipo.UseVisualStyleBackColor = False
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Blue
        Me.lblInfo.Location = New System.Drawing.Point(24, 469)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(312, 77)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Informe a Letra Associada ao Hardware : "
        '
        'cboDrive
        '
        Me.cboDrive.FormattingEnabled = True
        Me.cboDrive.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Z", "Y", "W"})
        Me.cboDrive.Location = New System.Drawing.Point(284, 21)
        Me.cboDrive.Name = "cboDrive"
        Me.cboDrive.Size = New System.Drawing.Size(48, 21)
        Me.cboDrive.TabIndex = 3
        '
        'btnInfoSistema
        '
        Me.btnInfoSistema.BackColor = System.Drawing.Color.White
        Me.btnInfoSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInfoSistema.Image = CType(resources.GetObject("btnInfoSistema.Image"), System.Drawing.Image)
        Me.btnInfoSistema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInfoSistema.Location = New System.Drawing.Point(24, 295)
        Me.btnInfoSistema.Name = "btnInfoSistema"
        Me.btnInfoSistema.Size = New System.Drawing.Size(312, 50)
        Me.btnInfoSistema.TabIndex = 0
        Me.btnInfoSistema.Text = "Informação do sistema"
        Me.btnInfoSistema.UseVisualStyleBackColor = False
        '
        'btnModelo
        '
        Me.btnModelo.BackColor = System.Drawing.Color.White
        Me.btnModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModelo.Image = CType(resources.GetObject("btnModelo.Image"), System.Drawing.Image)
        Me.btnModelo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModelo.Location = New System.Drawing.Point(24, 355)
        Me.btnModelo.Name = "btnModelo"
        Me.btnModelo.Size = New System.Drawing.Size(312, 50)
        Me.btnModelo.TabIndex = 0
        Me.btnModelo.Text = "Tipo Midia"
        Me.btnModelo.UseVisualStyleBackColor = False
        '
        'btnInfoDispositivos
        '
        Me.btnInfoDispositivos.BackColor = System.Drawing.Color.Transparent
        Me.btnInfoDispositivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInfoDispositivos.Image = CType(resources.GetObject("btnInfoDispositivos.Image"), System.Drawing.Image)
        Me.btnInfoDispositivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInfoDispositivos.Location = New System.Drawing.Point(24, 411)
        Me.btnInfoDispositivos.Name = "btnInfoDispositivos"
        Me.btnInfoDispositivos.Size = New System.Drawing.Size(312, 50)
        Me.btnInfoDispositivos.TabIndex = 0
        Me.btnInfoDispositivos.Text = "Informações dos dispositivos"
        Me.btnInfoDispositivos.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(360, 555)
        Me.Controls.Add(Me.cboDrive)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.btnInfoDispositivos)
        Me.Controls.Add(Me.btnModelo)
        Me.Controls.Add(Me.btnInfoSistema)
        Me.Controls.Add(Me.btnTipo)
        Me.Controls.Add(Me.btnTamanho)
        Me.Controls.Add(Me.btnEspacoLivre)
        Me.Controls.Add(Me.btnSerial)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informações do HD"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSerial As System.Windows.Forms.Button
    Friend WithEvents btnEspacoLivre As System.Windows.Forms.Button
    Friend WithEvents btnTamanho As System.Windows.Forms.Button
    Friend WithEvents btnTipo As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDrive As System.Windows.Forms.ComboBox
    Friend WithEvents btnInfoSistema As System.Windows.Forms.Button
    Friend WithEvents btnModelo As System.Windows.Forms.Button
    Friend WithEvents btnInfoDispositivos As System.Windows.Forms.Button

End Class
