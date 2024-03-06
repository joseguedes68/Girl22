<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSepConsignacao
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btFiltra = New System.Windows.Forms.Button()
        Me.cbVerTodas = New System.Windows.Forms.CheckBox()
        Me.tbFiltro = New System.Windows.Forms.TextBox()
        Me.dgvSepCab = New System.Windows.Forms.DataGridView()
        Me.dgvSepDet = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btGerarDocs = New System.Windows.Forms.Button()
        Me.lbNrAT = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSepCab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSepDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.34008!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.65992!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvSepCab, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvSepDet, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.55014!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.44987!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1235, 680)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.btFechar)
        Me.Panel1.Controls.Add(Me.btFiltra)
        Me.Panel1.Controls.Add(Me.cbVerTodas)
        Me.Panel1.Controls.Add(Me.tbFiltro)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1229, 74)
        Me.Panel1.TabIndex = 3
        '
        'btFechar
        '
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btFechar.Location = New System.Drawing.Point(1042, 12)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(141, 37)
        Me.btFechar.TabIndex = 4
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'btFiltra
        '
        Me.btFiltra.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btFiltra.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btFiltra.Location = New System.Drawing.Point(437, 9)
        Me.btFiltra.Name = "btFiltra"
        Me.btFiltra.Size = New System.Drawing.Size(108, 30)
        Me.btFiltra.TabIndex = 3
        Me.btFiltra.Text = "Filtra"
        Me.btFiltra.UseVisualStyleBackColor = False
        '
        'cbVerTodas
        '
        Me.cbVerTodas.AutoSize = True
        Me.cbVerTodas.Location = New System.Drawing.Point(564, 16)
        Me.cbVerTodas.Name = "cbVerTodas"
        Me.cbVerTodas.Size = New System.Drawing.Size(70, 21)
        Me.cbVerTodas.TabIndex = 1
        Me.cbVerTodas.Text = "Todas"
        Me.cbVerTodas.UseVisualStyleBackColor = True
        '
        'tbFiltro
        '
        Me.tbFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFiltro.Location = New System.Drawing.Point(9, 9)
        Me.tbFiltro.Name = "tbFiltro"
        Me.tbFiltro.Size = New System.Drawing.Size(422, 30)
        Me.tbFiltro.TabIndex = 0
        '
        'dgvSepCab
        '
        Me.dgvSepCab.AllowUserToAddRows = False
        Me.dgvSepCab.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSepCab.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvSepCab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSepCab.Location = New System.Drawing.Point(3, 83)
        Me.dgvSepCab.Name = "dgvSepCab"
        Me.TableLayoutPanel1.SetRowSpan(Me.dgvSepCab, 2)
        Me.dgvSepCab.RowTemplate.Height = 24
        Me.dgvSepCab.Size = New System.Drawing.Size(590, 588)
        Me.dgvSepCab.TabIndex = 1
        '
        'dgvSepDet
        '
        Me.dgvSepDet.AllowUserToAddRows = False
        Me.dgvSepDet.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSepDet.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvSepDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSepDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSepDet.Location = New System.Drawing.Point(599, 83)
        Me.dgvSepDet.Name = "dgvSepDet"
        Me.dgvSepDet.RowTemplate.Height = 24
        Me.dgvSepDet.Size = New System.Drawing.Size(633, 509)
        Me.dgvSepDet.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btGerarDocs)
        Me.Panel2.Controls.Add(Me.lbNrAT)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(599, 598)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(633, 79)
        Me.Panel2.TabIndex = 4
        '
        'btGerarDocs
        '
        Me.btGerarDocs.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGerarDocs.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btGerarDocs.Location = New System.Drawing.Point(13, 13)
        Me.btGerarDocs.Name = "btGerarDocs"
        Me.btGerarDocs.Size = New System.Drawing.Size(229, 41)
        Me.btGerarDocs.TabIndex = 1
        Me.btGerarDocs.Text = "Emitir Guia Trasporte"
        Me.btGerarDocs.UseVisualStyleBackColor = False
        '
        'lbNrAT
        '
        Me.lbNrAT.AutoSize = True
        Me.lbNrAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNrAT.Location = New System.Drawing.Point(315, 19)
        Me.lbNrAT.Name = "lbNrAT"
        Me.lbNrAT.Size = New System.Drawing.Size(91, 25)
        Me.lbNrAT.TabIndex = 0
        Me.lbNrAT.Text = "Num AT"
        '
        'frmSepConsignacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1235, 680)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmSepConsignacao"
        Me.Text = "frmSepConsignacao"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvSepCab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSepDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dgvSepCab As DataGridView
    Friend WithEvents dgvSepDet As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cbVerTodas As CheckBox
    Friend WithEvents tbFiltro As TextBox
    Friend WithEvents btFiltra As Button
    Friend WithEvents btFechar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btGerarDocs As Button
    Friend WithEvents lbNrAT As Label
End Class
