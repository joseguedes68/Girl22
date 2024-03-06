<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFechoCaixa
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvFechosCaixa = New System.Windows.Forms.DataGridView()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btFecharCaixa = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbLojas = New System.Windows.Forms.ComboBox()
        Me.btDetalhe = New System.Windows.Forms.Button()
        Me.dpDeData = New System.Windows.Forms.DateTimePicker()
        Me.dpAteData = New System.Windows.Forms.DateTimePicker()
        Me.btAtualizar = New System.Windows.Forms.Button()
        Me.btImprimir = New System.Windows.Forms.Button()
        Me.btValidar = New System.Windows.Forms.Button()
        Me.cbVerTodas = New System.Windows.Forms.CheckBox()
        CType(Me.dgvFechosCaixa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvFechosCaixa
        '
        Me.dgvFechosCaixa.AllowUserToAddRows = False
        Me.dgvFechosCaixa.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFechosCaixa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFechosCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvFechosCaixa, 10)
        Me.dgvFechosCaixa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFechosCaixa.Location = New System.Drawing.Point(4, 49)
        Me.dgvFechosCaixa.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvFechosCaixa.Name = "dgvFechosCaixa"
        Me.dgvFechosCaixa.Size = New System.Drawing.Size(1648, 475)
        Me.dgvFechosCaixa.TabIndex = 0
        '
        'btFechar
        '
        Me.btFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btFechar.Location = New System.Drawing.Point(1501, 4)
        Me.btFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(151, 37)
        Me.btFechar.TabIndex = 95
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'btFecharCaixa
        '
        Me.btFecharCaixa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFecharCaixa.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btFecharCaixa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFecharCaixa.Location = New System.Drawing.Point(948, 4)
        Me.btFecharCaixa.Margin = New System.Windows.Forms.Padding(4)
        Me.btFecharCaixa.Name = "btFecharCaixa"
        Me.btFecharCaixa.Size = New System.Drawing.Size(151, 37)
        Me.btFecharCaixa.TabIndex = 93
        Me.btFecharCaixa.Text = "Fechar Caixa"
        Me.btFecharCaixa.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.cbLojas, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btDetalhe, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dpDeData, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dpAteData, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btFecharCaixa, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btAtualizar, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btImprimir, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btValidar, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbVerTodas, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvFechosCaixa, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btFechar, 9, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1656, 527)
        Me.TableLayoutPanel1.TabIndex = 101
        '
        'cbLojas
        '
        Me.cbLojas.DropDownHeight = 200
        Me.cbLojas.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbLojas.FormattingEnabled = True
        Me.cbLojas.IntegralHeight = False
        Me.cbLojas.Location = New System.Drawing.Point(498, 4)
        Me.cbLojas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbLojas.MaxDropDownItems = 12
        Me.cbLojas.Name = "cbLojas"
        Me.cbLojas.Size = New System.Drawing.Size(317, 28)
        Me.cbLojas.TabIndex = 99
        '
        'btDetalhe
        '
        Me.btDetalhe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btDetalhe.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btDetalhe.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDetalhe.Location = New System.Drawing.Point(1107, 4)
        Me.btDetalhe.Margin = New System.Windows.Forms.Padding(4)
        Me.btDetalhe.Name = "btDetalhe"
        Me.btDetalhe.Size = New System.Drawing.Size(131, 37)
        Me.btDetalhe.TabIndex = 98
        Me.btDetalhe.Text = "Detalhe"
        Me.btDetalhe.UseVisualStyleBackColor = False
        '
        'dpDeData
        '
        Me.dpDeData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpDeData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDeData.Location = New System.Drawing.Point(184, 4)
        Me.dpDeData.Margin = New System.Windows.Forms.Padding(4)
        Me.dpDeData.Name = "dpDeData"
        Me.dpDeData.Size = New System.Drawing.Size(149, 26)
        Me.dpDeData.TabIndex = 97
        '
        'dpAteData
        '
        Me.dpAteData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dpAteData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpAteData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpAteData.Location = New System.Drawing.Point(341, 4)
        Me.dpAteData.Margin = New System.Windows.Forms.Padding(4)
        Me.dpAteData.Name = "dpAteData"
        Me.dpAteData.Size = New System.Drawing.Size(149, 26)
        Me.dpAteData.TabIndex = 98
        '
        'btAtualizar
        '
        Me.btAtualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAtualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btAtualizar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAtualizar.Location = New System.Drawing.Point(823, 4)
        Me.btAtualizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btAtualizar.Name = "btAtualizar"
        Me.btAtualizar.Size = New System.Drawing.Size(117, 37)
        Me.btAtualizar.TabIndex = 98
        Me.btAtualizar.Text = "Atualizar"
        Me.btAtualizar.UseVisualStyleBackColor = False
        '
        'btImprimir
        '
        Me.btImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btImprimir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btImprimir.Location = New System.Drawing.Point(1246, 4)
        Me.btImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(113, 37)
        Me.btImprimir.TabIndex = 94
        Me.btImprimir.Text = "Imprimir"
        Me.btImprimir.UseVisualStyleBackColor = False
        '
        'btValidar
        '
        Me.btValidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btValidar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btValidar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btValidar.Location = New System.Drawing.Point(1367, 4)
        Me.btValidar.Margin = New System.Windows.Forms.Padding(4)
        Me.btValidar.Name = "btValidar"
        Me.btValidar.Size = New System.Drawing.Size(121, 37)
        Me.btValidar.TabIndex = 96
        Me.btValidar.Text = "Validar"
        Me.btValidar.UseVisualStyleBackColor = False
        '
        'cbVerTodas
        '
        Me.cbVerTodas.AutoSize = True
        Me.cbVerTodas.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbVerTodas.Location = New System.Drawing.Point(4, 4)
        Me.cbVerTodas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbVerTodas.Name = "cbVerTodas"
        Me.cbVerTodas.Size = New System.Drawing.Size(153, 31)
        Me.cbVerTodas.TabIndex = 97
        Me.cbVerTodas.Text = "Ver Todas"
        Me.cbVerTodas.UseVisualStyleBackColor = True
        '
        'frmFechoCaixa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1656, 527)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmFechoCaixa"
        Me.Text = "Fecho Caixa"
        CType(Me.dgvFechosCaixa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvFechosCaixa As System.Windows.Forms.DataGridView
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents btFecharCaixa As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btValidar As System.Windows.Forms.Button
    Friend WithEvents cbVerTodas As System.Windows.Forms.CheckBox
    Friend WithEvents cbLojas As System.Windows.Forms.ComboBox
    Friend WithEvents btDetalhe As System.Windows.Forms.Button
    Friend WithEvents dpDeData As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpAteData As System.Windows.Forms.DateTimePicker
    Friend WithEvents btAtualizar As System.Windows.Forms.Button
    Friend WithEvents btImprimir As System.Windows.Forms.Button
End Class
