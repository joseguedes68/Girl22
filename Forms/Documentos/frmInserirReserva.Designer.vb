<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInserirReserva
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.btCliente = New System.Windows.Forms.Button()
        Me.tbSinal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbTalao = New System.Windows.Forms.TextBox()
        Me.txtRTam = New System.Windows.Forms.TextBox()
        Me.btEditaReservas = New System.Windows.Forms.Button()
        Me.txtRCor = New System.Windows.Forms.TextBox()
        Me.lbReserva = New System.Windows.Forms.Label()
        Me.txtRModelo = New System.Windows.Forms.TextBox()
        Me.btGravaReserva = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbReserva = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(32, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Sinal : "
        Me.Label9.Visible = False
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCliente.Location = New System.Drawing.Point(120, 165)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(86, 13)
        Me.lbCliente.TabIndex = 26
        Me.lbCliente.Text = "Dados Cliente"
        Me.lbCliente.Visible = False
        '
        'btCliente
        '
        Me.btCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCliente.Location = New System.Drawing.Point(32, 158)
        Me.btCliente.Name = "btCliente"
        Me.btCliente.Size = New System.Drawing.Size(82, 24)
        Me.btCliente.TabIndex = 25
        Me.btCliente.Text = "Cliente"
        Me.btCliente.UseVisualStyleBackColor = False
        Me.btCliente.Visible = False
        '
        'tbSinal
        '
        Me.tbSinal.Location = New System.Drawing.Point(85, 200)
        Me.tbSinal.Name = "tbSinal"
        Me.tbSinal.Size = New System.Drawing.Size(139, 20)
        Me.tbSinal.TabIndex = 24
        Me.tbSinal.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(355, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Talão : "
        Me.Label5.Visible = False
        '
        'tbTalao
        '
        Me.tbTalao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbTalao.Location = New System.Drawing.Point(412, 13)
        Me.tbTalao.Name = "tbTalao"
        Me.tbTalao.Size = New System.Drawing.Size(130, 21)
        Me.tbTalao.TabIndex = 21
        Me.tbTalao.Visible = False
        '
        'txtRTam
        '
        Me.txtRTam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRTam.Location = New System.Drawing.Point(235, 77)
        Me.txtRTam.Name = "txtRTam"
        Me.txtRTam.Size = New System.Drawing.Size(32, 21)
        Me.txtRTam.TabIndex = 18
        '
        'btEditaReservas
        '
        Me.btEditaReservas.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btEditaReservas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEditaReservas.Location = New System.Drawing.Point(168, 19)
        Me.btEditaReservas.Name = "btEditaReservas"
        Me.btEditaReservas.Size = New System.Drawing.Size(129, 24)
        Me.btEditaReservas.TabIndex = 20
        Me.btEditaReservas.Text = "Consultar"
        Me.btEditaReservas.UseVisualStyleBackColor = False
        '
        'txtRCor
        '
        Me.txtRCor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCor.Location = New System.Drawing.Point(163, 77)
        Me.txtRCor.Name = "txtRCor"
        Me.txtRCor.Size = New System.Drawing.Size(33, 21)
        Me.txtRCor.TabIndex = 18
        '
        'lbReserva
        '
        Me.lbReserva.AutoSize = True
        Me.lbReserva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbReserva.Location = New System.Drawing.Point(12, 18)
        Me.lbReserva.Name = "lbReserva"
        Me.lbReserva.Size = New System.Drawing.Size(96, 24)
        Me.lbReserva.TabIndex = 15
        Me.lbReserva.Text = "Reservas"
        '
        'txtRModelo
        '
        Me.txtRModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRModelo.Location = New System.Drawing.Point(76, 77)
        Me.txtRModelo.Name = "txtRModelo"
        Me.txtRModelo.Size = New System.Drawing.Size(54, 21)
        Me.txtRModelo.TabIndex = 18
        '
        'btGravaReserva
        '
        Me.btGravaReserva.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGravaReserva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGravaReserva.Location = New System.Drawing.Point(444, 149)
        Me.btGravaReserva.Name = "btGravaReserva"
        Me.btGravaReserva.Size = New System.Drawing.Size(155, 62)
        Me.btGravaReserva.TabIndex = 16
        Me.btGravaReserva.Text = "Gravar"
        Me.btGravaReserva.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(203, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Tam"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(132, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Cor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Modelo"
        '
        'tbReserva
        '
        Me.tbReserva.AcceptsTab = True
        Me.tbReserva.Location = New System.Drawing.Point(111, 115)
        Me.tbReserva.MaxLength = 55
        Me.tbReserva.Multiline = True
        Me.tbReserva.Name = "tbReserva"
        Me.tbReserva.Size = New System.Drawing.Size(304, 23)
        Me.tbReserva.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Descrição : "
        Me.Label1.Visible = False
        '
        'frmInserirReserva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 232)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbCliente)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btCliente)
        Me.Controls.Add(Me.btGravaReserva)
        Me.Controls.Add(Me.lbReserva)
        Me.Controls.Add(Me.tbReserva)
        Me.Controls.Add(Me.btEditaReservas)
        Me.Controls.Add(Me.tbSinal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRTam)
        Me.Controls.Add(Me.txtRCor)
        Me.Controls.Add(Me.tbTalao)
        Me.Controls.Add(Me.txtRModelo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Name = "frmInserirReserva"
        Me.Text = "frmInserirReserva"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbCliente As System.Windows.Forms.Label
    Friend WithEvents btCliente As System.Windows.Forms.Button
    Friend WithEvents tbSinal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbTalao As System.Windows.Forms.TextBox
    Friend WithEvents txtRTam As System.Windows.Forms.TextBox
    Friend WithEvents btEditaReservas As System.Windows.Forms.Button
    Friend WithEvents txtRCor As System.Windows.Forms.TextBox
    Friend WithEvents lbReserva As System.Windows.Forms.Label
    Friend WithEvents txtRModelo As System.Windows.Forms.TextBox
    Friend WithEvents btGravaReserva As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbReserva As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
