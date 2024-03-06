<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArranque
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
        Me.components = New System.ComponentModel.Container()
        Me.PanelUser = New System.Windows.Forms.Panel()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUtilizador = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.lblVersao = New System.Windows.Forms.Label()
        Me.lblDesenvolvimento = New System.Windows.Forms.Label()
        Me.gbAplicacao = New System.Windows.Forms.GroupBox()
        Me.rbPOS = New System.Windows.Forms.RadioButton()
        Me.rbBackOffice = New System.Windows.Forms.RadioButton()
        Me.TimerCopias = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAlerta = New System.Windows.Forms.Timer(Me.components)
        Me.PanelUser.SuspendLayout()
        Me.gbAplicacao.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelUser
        '
        Me.PanelUser.BackColor = System.Drawing.Color.DarkKhaki
        Me.PanelUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelUser.Controls.Add(Me.txtPassword)
        Me.PanelUser.Controls.Add(Me.txtUtilizador)
        Me.PanelUser.Controls.Add(Me.Label2)
        Me.PanelUser.Controls.Add(Me.Label1)
        Me.PanelUser.Controls.Add(Me.cmdOK)
        Me.PanelUser.Controls.Add(Me.cmdCancelar)
        Me.PanelUser.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelUser.Location = New System.Drawing.Point(120, 216)
        Me.PanelUser.Name = "PanelUser"
        Me.PanelUser.Size = New System.Drawing.Size(260, 123)
        Me.PanelUser.TabIndex = 6
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(90, 36)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(142, 22)
        Me.txtPassword.TabIndex = 1
        '
        'txtUtilizador
        '
        Me.txtUtilizador.Location = New System.Drawing.Point(90, 10)
        Me.txtUtilizador.Name = "txtUtilizador"
        Me.txtUtilizador.Size = New System.Drawing.Size(142, 22)
        Me.txtUtilizador.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(2, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Utilizador"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOK
        '
        Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(39, 77)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 24)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "Ok"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(133, 77)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(81, 24)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Cancelar"
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(6, 162)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(496, 40)
        Me.lblDescription.TabIndex = 10
        Me.lblDescription.Text = "Description"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCompanyName
        '
        Me.lblCompanyName.BackColor = System.Drawing.Color.Transparent
        Me.lblCompanyName.Location = New System.Drawing.Point(6, 8)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(496, 40)
        Me.lblCompanyName.TabIndex = 9
        Me.lblCompanyName.Text = "CompanyName"
        '
        'lblProductName
        '
        Me.lblProductName.BackColor = System.Drawing.Color.Transparent
        Me.lblProductName.Font = New System.Drawing.Font("Arial", 54.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.Location = New System.Drawing.Point(39, 82)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(490, 80)
        Me.lblProductName.TabIndex = 8
        Me.lblProductName.Text = "ProductName"
        Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVersao
        '
        Me.lblVersao.BackColor = System.Drawing.Color.Transparent
        Me.lblVersao.Location = New System.Drawing.Point(33, 395)
        Me.lblVersao.Name = "lblVersao"
        Me.lblVersao.Size = New System.Drawing.Size(496, 40)
        Me.lblVersao.TabIndex = 7
        Me.lblVersao.Text = "ProductVersion"
        Me.lblVersao.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblDesenvolvimento
        '
        Me.lblDesenvolvimento.BackColor = System.Drawing.Color.Transparent
        Me.lblDesenvolvimento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesenvolvimento.Location = New System.Drawing.Point(337, 9)
        Me.lblDesenvolvimento.Name = "lblDesenvolvimento"
        Me.lblDesenvolvimento.Size = New System.Drawing.Size(142, 40)
        Me.lblDesenvolvimento.TabIndex = 11
        Me.lblDesenvolvimento.Text = "Desenvolvimento"
        Me.lblDesenvolvimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbAplicacao
        '
        Me.gbAplicacao.Controls.Add(Me.rbPOS)
        Me.gbAplicacao.Controls.Add(Me.rbBackOffice)
        Me.gbAplicacao.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAplicacao.Location = New System.Drawing.Point(386, 216)
        Me.gbAplicacao.Name = "gbAplicacao"
        Me.gbAplicacao.Size = New System.Drawing.Size(143, 123)
        Me.gbAplicacao.TabIndex = 12
        Me.gbAplicacao.TabStop = False
        Me.gbAplicacao.Text = "Aplicação"
        Me.gbAplicacao.Visible = False
        '
        'rbPOS
        '
        Me.rbPOS.AutoSize = True
        Me.rbPOS.Location = New System.Drawing.Point(15, 61)
        Me.rbPOS.Name = "rbPOS"
        Me.rbPOS.Size = New System.Drawing.Size(54, 20)
        Me.rbPOS.TabIndex = 1
        Me.rbPOS.TabStop = True
        Me.rbPOS.Text = "POS"
        Me.rbPOS.UseVisualStyleBackColor = True
        '
        'rbBackOffice
        '
        Me.rbBackOffice.AutoSize = True
        Me.rbBackOffice.Location = New System.Drawing.Point(15, 35)
        Me.rbBackOffice.Name = "rbBackOffice"
        Me.rbBackOffice.Size = New System.Drawing.Size(94, 20)
        Me.rbBackOffice.TabIndex = 0
        Me.rbBackOffice.TabStop = True
        Me.rbBackOffice.Text = "BackOffice"
        Me.rbBackOffice.UseVisualStyleBackColor = True
        '
        'TimerCopias
        '
        '
        'TimerAlerta
        '
        '
        'frmArranque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(17.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.YellowGreen
        Me.ClientSize = New System.Drawing.Size(541, 455)
        Me.Controls.Add(Me.gbAplicacao)
        Me.Controls.Add(Me.lblDesenvolvimento)
        Me.Controls.Add(Me.PanelUser)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblCompanyName)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.lblVersao)
        Me.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Name = "frmArranque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmArranque"
        Me.PanelUser.ResumeLayout(False)
        Me.PanelUser.PerformLayout()
        Me.gbAplicacao.ResumeLayout(False)
        Me.gbAplicacao.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelUser As System.Windows.Forms.Panel
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUtilizador As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents lblVersao As System.Windows.Forms.Label
    Friend WithEvents lblDesenvolvimento As System.Windows.Forms.Label
    Friend WithEvents gbAplicacao As System.Windows.Forms.GroupBox
    Friend WithEvents rbPOS As System.Windows.Forms.RadioButton
    Friend WithEvents rbBackOffice As System.Windows.Forms.RadioButton
    Friend WithEvents TimerCopias As System.Windows.Forms.Timer
    Friend WithEvents TimerAlerta As System.Windows.Forms.Timer
End Class
