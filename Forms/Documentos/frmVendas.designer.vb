<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVendas
    Inherits Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.cbVendedor = New System.Windows.Forms.ComboBox()
        Me.btMB = New System.Windows.Forms.Button()
        Me.btVD = New System.Windows.Forms.Button()
        Me.lbQtdTaloes = New System.Windows.Forms.Label()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.btCliente = New System.Windows.Forms.Button()
        Me.txtValorRecebido = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblValorTotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTroco = New System.Windows.Forms.Label()
        Me.cbDevolver = New System.Windows.Forms.CheckBox()
        Me.lbNIF = New System.Windows.Forms.Label()
        Me.dgvVendas = New System.Windows.Forms.DataGridView()
        Me.Etiqueta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TamID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecoEtiqueta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qtd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitOfMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVAId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxIva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btConsignacao = New System.Windows.Forms.Button()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVendas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdCancelar.Location = New System.Drawing.Point(422, 149)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(94, 30)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'PictureBox
        '
        Me.PictureBox.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox.Location = New System.Drawing.Point(657, 7)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(245, 175)
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'cbVendedor
        '
        Me.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendedor.FormattingEnabled = True
        Me.cbVendedor.Location = New System.Drawing.Point(12, 7)
        Me.cbVendedor.Name = "cbVendedor"
        Me.cbVendedor.Size = New System.Drawing.Size(188, 28)
        Me.cbVendedor.TabIndex = 33
        '
        'btMB
        '
        Me.btMB.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btMB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btMB.Location = New System.Drawing.Point(121, 149)
        Me.btMB.Name = "btMB"
        Me.btMB.Size = New System.Drawing.Size(94, 30)
        Me.btMB.TabIndex = 89
        Me.btMB.Text = "MB"
        Me.btMB.UseVisualStyleBackColor = False
        '
        'btVD
        '
        Me.btVD.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btVD.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btVD.Location = New System.Drawing.Point(12, 149)
        Me.btVD.Name = "btVD"
        Me.btVD.Size = New System.Drawing.Size(94, 30)
        Me.btVD.TabIndex = 88
        Me.btVD.Text = "€€"
        Me.btVD.UseVisualStyleBackColor = False
        '
        'lbQtdTaloes
        '
        Me.lbQtdTaloes.AutoSize = True
        Me.lbQtdTaloes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtdTaloes.Location = New System.Drawing.Point(484, 394)
        Me.lbQtdTaloes.Name = "lbQtdTaloes"
        Me.lbQtdTaloes.Size = New System.Drawing.Size(96, 25)
        Me.lbQtdTaloes.TabIndex = 35
        Me.lbQtdTaloes.Text = "QtdTotal"
        '
        'btFechar
        '
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFechar.Location = New System.Drawing.Point(539, 149)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(94, 30)
        Me.btFechar.TabIndex = 91
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Enabled = False
        Me.lbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCliente.Location = New System.Drawing.Point(322, 9)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(80, 25)
        Me.lbCliente.TabIndex = 99
        Me.lbCliente.Text = "Cliente"
        '
        'btCliente
        '
        Me.btCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btCliente.Location = New System.Drawing.Point(219, 3)
        Me.btCliente.Name = "btCliente"
        Me.btCliente.Size = New System.Drawing.Size(97, 30)
        Me.btCliente.TabIndex = 98
        Me.btCliente.Text = "Cliente"
        Me.btCliente.UseVisualStyleBackColor = False
        '
        'txtValorRecebido
        '
        Me.txtValorRecebido.BackColor = System.Drawing.SystemColors.Window
        Me.txtValorRecebido.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValorRecebido.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorRecebido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValorRecebido.Location = New System.Drawing.Point(729, 446)
        Me.txtValorRecebido.Name = "txtValorRecebido"
        Me.txtValorRecebido.Size = New System.Drawing.Size(160, 43)
        Me.txtValorRecebido.TabIndex = 1
        Me.txtValorRecebido.Text = "0.00"
        Me.txtValorRecebido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(736, 422)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(153, 26)
        Me.Label11.TabIndex = 105
        Me.Label11.Text = "Valor Recebido"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(667, 391)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 27)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Total"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblValorTotal
        '
        Me.lblValorTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblValorTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTotal.ForeColor = System.Drawing.Color.Teal
        Me.lblValorTotal.Location = New System.Drawing.Point(729, 391)
        Me.lblValorTotal.Name = "lblValorTotal"
        Me.lblValorTotal.Size = New System.Drawing.Size(160, 27)
        Me.lblValorTotal.TabIndex = 103
        Me.lblValorTotal.Text = "0.00"
        Me.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(735, 484)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 23)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Troco"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTroco
        '
        Me.lblTroco.BackColor = System.Drawing.Color.Transparent
        Me.lblTroco.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTroco.ForeColor = System.Drawing.Color.Teal
        Me.lblTroco.Location = New System.Drawing.Point(729, 507)
        Me.lblTroco.Name = "lblTroco"
        Me.lblTroco.Size = New System.Drawing.Size(160, 40)
        Me.lblTroco.TabIndex = 100
        Me.lblTroco.Text = "0.00"
        Me.lblTroco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbDevolver
        '
        Me.cbDevolver.AutoSize = True
        Me.cbDevolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDevolver.Location = New System.Drawing.Point(30, 108)
        Me.cbDevolver.Name = "cbDevolver"
        Me.cbDevolver.Size = New System.Drawing.Size(136, 29)
        Me.cbDevolver.TabIndex = 106
        Me.cbDevolver.Text = "Devolução"
        Me.cbDevolver.UseVisualStyleBackColor = True
        '
        'lbNIF
        '
        Me.lbNIF.AutoSize = True
        Me.lbNIF.Enabled = False
        Me.lbNIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNIF.Location = New System.Drawing.Point(221, 36)
        Me.lbNIF.Name = "lbNIF"
        Me.lbNIF.Size = New System.Drawing.Size(46, 25)
        Me.lbNIF.TabIndex = 110
        Me.lbNIF.Text = "NIF"
        Me.lbNIF.Visible = False
        '
        'dgvVendas
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvVendas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVendas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVendas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Etiqueta, Me.ProductCode, Me.TamID, Me.ProductDescription, Me.PrecoEtiqueta, Me.Desconto, Me.Qtd, Me.Valor, Me.UnitOfMeasure, Me.Modelo, Me.Cor, Me.IVAId, Me.Comissao, Me.TxIva})
        Me.dgvVendas.Location = New System.Drawing.Point(12, 203)
        Me.dgvVendas.Name = "dgvVendas"
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvVendas.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvVendas.Size = New System.Drawing.Size(896, 185)
        Me.dgvVendas.TabIndex = 0
        '
        'Etiqueta
        '
        Me.Etiqueta.Frozen = True
        Me.Etiqueta.HeaderText = "Etiqueta"
        Me.Etiqueta.Name = "Etiqueta"
        '
        'ProductCode
        '
        Me.ProductCode.Frozen = True
        Me.ProductCode.HeaderText = "Artigo"
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.ReadOnly = True
        '
        'TamID
        '
        Me.TamID.Frozen = True
        Me.TamID.HeaderText = "Tam"
        Me.TamID.Name = "TamID"
        Me.TamID.ReadOnly = True
        Me.TamID.Width = 50
        '
        'ProductDescription
        '
        Me.ProductDescription.Frozen = True
        Me.ProductDescription.HeaderText = "Descrição"
        Me.ProductDescription.Name = "ProductDescription"
        Me.ProductDescription.ReadOnly = True
        Me.ProductDescription.Width = 200
        '
        'PrecoEtiqueta
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.PrecoEtiqueta.DefaultCellStyle = DataGridViewCellStyle10
        Me.PrecoEtiqueta.Frozen = True
        Me.PrecoEtiqueta.HeaderText = "Preço"
        Me.PrecoEtiqueta.Name = "PrecoEtiqueta"
        Me.PrecoEtiqueta.ReadOnly = True
        '
        'Desconto
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C2"
        DataGridViewCellStyle11.NullValue = "0"
        Me.Desconto.DefaultCellStyle = DataGridViewCellStyle11
        Me.Desconto.Frozen = True
        Me.Desconto.HeaderText = "Desc."
        Me.Desconto.Name = "Desconto"
        '
        'Qtd
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.NullValue = "0"
        Me.Qtd.DefaultCellStyle = DataGridViewCellStyle12
        Me.Qtd.Frozen = True
        Me.Qtd.HeaderText = "Qtd."
        Me.Qtd.Name = "Qtd"
        Me.Qtd.ReadOnly = True
        Me.Qtd.Width = 40
        '
        'Valor
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "C2"
        DataGridViewCellStyle13.NullValue = "0"
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle13
        Me.Valor.Frozen = True
        Me.Valor.HeaderText = "PV"
        Me.Valor.Name = "Valor"
        '
        'UnitOfMeasure
        '
        Me.UnitOfMeasure.Frozen = True
        Me.UnitOfMeasure.HeaderText = "Un"
        Me.UnitOfMeasure.Name = "UnitOfMeasure"
        Me.UnitOfMeasure.ReadOnly = True
        Me.UnitOfMeasure.Width = 40
        '
        'Modelo
        '
        Me.Modelo.HeaderText = "Modelo"
        Me.Modelo.Name = "Modelo"
        Me.Modelo.Visible = False
        '
        'Cor
        '
        Me.Cor.HeaderText = "Cor"
        Me.Cor.Name = "Cor"
        Me.Cor.Visible = False
        '
        'IVAId
        '
        Me.IVAId.HeaderText = "IVAId"
        Me.IVAId.Name = "IVAId"
        Me.IVAId.Visible = False
        '
        'Comissao
        '
        Me.Comissao.HeaderText = "Comissao"
        Me.Comissao.Name = "Comissao"
        Me.Comissao.Visible = False
        '
        'TxIva
        '
        Me.TxIva.HeaderText = "TxIva"
        Me.TxIva.Name = "TxIva"
        Me.TxIva.Visible = False
        '
        'btConsignacao
        '
        Me.btConsignacao.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btConsignacao.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btConsignacao.Location = New System.Drawing.Point(281, 149)
        Me.btConsignacao.Name = "btConsignacao"
        Me.btConsignacao.Size = New System.Drawing.Size(121, 30)
        Me.btConsignacao.TabIndex = 111
        Me.btConsignacao.Text = "Validar"
        Me.btConsignacao.UseVisualStyleBackColor = False
        Me.btConsignacao.Visible = False
        '
        'frmVendas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(922, 576)
        Me.Controls.Add(Me.btConsignacao)
        Me.Controls.Add(Me.dgvVendas)
        Me.Controls.Add(Me.lbNIF)
        Me.Controls.Add(Me.cbDevolver)
        Me.Controls.Add(Me.txtValorRecebido)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblValorTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTroco)
        Me.Controls.Add(Me.lbCliente)
        Me.Controls.Add(Me.btCliente)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.lbQtdTaloes)
        Me.Controls.Add(Me.btMB)
        Me.Controls.Add(Me.btVD)
        Me.Controls.Add(Me.cbVendedor)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.PictureBox)
        Me.Name = "frmVendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cod. Barras"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVendas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents cbVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents btMB As System.Windows.Forms.Button
    Friend WithEvents btVD As System.Windows.Forms.Button
    Friend WithEvents lbQtdTaloes As System.Windows.Forms.Label
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents lbCliente As System.Windows.Forms.Label
    Friend WithEvents btCliente As System.Windows.Forms.Button
    Friend WithEvents txtValorRecebido As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblValorTotal As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTroco As System.Windows.Forms.Label
    Friend WithEvents cbDevolver As System.Windows.Forms.CheckBox
    Friend WithEvents lbNIF As System.Windows.Forms.Label
    Friend WithEvents dgvVendas As System.Windows.Forms.DataGridView
    Friend WithEvents Etiqueta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TamID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecoEtiqueta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desconto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qtd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitOfMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modelo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVAId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxIva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btConsignacao As Button
End Class
