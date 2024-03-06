<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDocsCab
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDocCab = New System.Windows.Forms.DataGridView()
        Me.lbTipoDoc = New System.Windows.Forms.Label()
        Me.btok = New System.Windows.Forms.Button()
        Me.cbVerTodas = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btCancel = New System.Windows.Forms.Button()
        CType(Me.dgvDocCab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDocCab
        '
        Me.dgvDocCab.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvDocCab.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDocCab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocCab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvDocCab.Location = New System.Drawing.Point(0, 77)
        Me.dgvDocCab.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvDocCab.Name = "dgvDocCab"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDocCab.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDocCab.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDocCab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDocCab.Size = New System.Drawing.Size(858, 506)
        Me.dgvDocCab.TabIndex = 17
        '
        'lbTipoDoc
        '
        Me.lbTipoDoc.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbTipoDoc.Location = New System.Drawing.Point(16, 11)
        Me.lbTipoDoc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTipoDoc.Name = "lbTipoDoc"
        Me.lbTipoDoc.Size = New System.Drawing.Size(307, 32)
        Me.lbTipoDoc.TabIndex = 13
        Me.lbTipoDoc.Text = "Documentos"
        Me.lbTipoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btok
        '
        Me.btok.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btok.Location = New System.Drawing.Point(705, 4)
        Me.btok.Margin = New System.Windows.Forms.Padding(4)
        Me.btok.Name = "btok"
        Me.btok.Size = New System.Drawing.Size(141, 34)
        Me.btok.TabIndex = 18
        Me.btok.Text = "OK"
        Me.btok.UseVisualStyleBackColor = False
        '
        'cbVerTodas
        '
        Me.cbVerTodas.AutoSize = True
        Me.cbVerTodas.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbVerTodas.Location = New System.Drawing.Point(187, 11)
        Me.cbVerTodas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbVerTodas.Name = "cbVerTodas"
        Me.cbVerTodas.Size = New System.Drawing.Size(122, 24)
        Me.cbVerTodas.TabIndex = 19
        Me.cbVerTodas.Text = "Ver Todas"
        Me.cbVerTodas.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Crimson
        Me.Label6.Location = New System.Drawing.Point(16, 50)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(574, 15)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "PARA DEVOLUÇÃO COM MAIS DE 15 DIAS, NAS RESERVAS ESCREVER : DEVOLVER FS AALL/SSSS" &
    "S"
        Me.Label6.Visible = False
        '
        'btCancel
        '
        Me.btCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btCancel.Location = New System.Drawing.Point(555, 4)
        Me.btCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(141, 34)
        Me.btCancel.TabIndex = 18
        Me.btCancel.Text = "Cancelar"
        Me.btCancel.UseVisualStyleBackColor = False
        '
        'frmDocsCab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 583)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbVerTodas)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btok)
        Me.Controls.Add(Me.lbTipoDoc)
        Me.Controls.Add(Me.dgvDocCab)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDocsCab"
        Me.Text = "frmDocsCab"
        CType(Me.dgvDocCab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDocCab As System.Windows.Forms.DataGridView
    Friend WithEvents lbTipoDoc As System.Windows.Forms.Label
    Friend WithEvents btok As System.Windows.Forms.Button
    Friend WithEvents cbVerTodas As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btCancel As Button
End Class
