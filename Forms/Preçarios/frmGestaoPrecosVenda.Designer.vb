<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestaoPrecosVenda
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PicBox = New System.Windows.Forms.PictureBox()
        Me.cbReport = New System.Windows.Forms.ComboBox()
        Me.gbCopiarTabelas = New System.Windows.Forms.GroupBox()
        Me.btListaTabPUnico = New System.Windows.Forms.Button()
        Me.btCopiarTabela = New System.Windows.Forms.Button()
        Me.lbDestino = New System.Windows.Forms.Label()
        Me.lbOrigem = New System.Windows.Forms.Label()
        Me.cbTabDestino = New System.Windows.Forms.ComboBox()
        Me.cbTabOrigem = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdFechar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGravar = New System.Windows.Forms.Button()
        Me.GruposBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvPrecos = New GirlRootName.GridView()
        Me.Panel1.SuspendLayout()
        CType(Me.PicBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCopiarTabelas.SuspendLayout()
        CType(Me.GruposBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvPrecos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PicBox)
        Me.Panel1.Controls.Add(Me.cbReport)
        Me.Panel1.Controls.Add(Me.gbCopiarTabelas)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmdImprimir)
        Me.Panel1.Controls.Add(Me.cmdFechar)
        Me.Panel1.Controls.Add(Me.cmdCancelar)
        Me.Panel1.Controls.Add(Me.cmdGravar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 421)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(861, 129)
        Me.Panel1.TabIndex = 1
        '
        'PicBox
        '
        Me.PicBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicBox.Location = New System.Drawing.Point(358, 10)
        Me.PicBox.Name = "PicBox"
        Me.PicBox.Size = New System.Drawing.Size(146, 112)
        Me.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBox.TabIndex = 1
        Me.PicBox.TabStop = False
        '
        'cbReport
        '
        Me.cbReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbReport.DisplayMember = "RptTaloes_3x2"
        Me.cbReport.FormattingEnabled = True
        Me.cbReport.Items.AddRange(New Object() {"RptTaloes_8x2", "RptTaloes_10x4SemTam", "RptTaloes_3x2", "RptRelTaloes", "RptTabelaPrecos"})
        Me.cbReport.Location = New System.Drawing.Point(635, 15)
        Me.cbReport.Name = "cbReport"
        Me.cbReport.Size = New System.Drawing.Size(171, 21)
        Me.cbReport.TabIndex = 38
        '
        'gbCopiarTabelas
        '
        Me.gbCopiarTabelas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbCopiarTabelas.BackColor = System.Drawing.SystemColors.Control
        Me.gbCopiarTabelas.Controls.Add(Me.btListaTabPUnico)
        Me.gbCopiarTabelas.Controls.Add(Me.btCopiarTabela)
        Me.gbCopiarTabelas.Controls.Add(Me.lbDestino)
        Me.gbCopiarTabelas.Controls.Add(Me.lbOrigem)
        Me.gbCopiarTabelas.Controls.Add(Me.cbTabDestino)
        Me.gbCopiarTabelas.Controls.Add(Me.cbTabOrigem)
        Me.gbCopiarTabelas.Location = New System.Drawing.Point(12, 17)
        Me.gbCopiarTabelas.Name = "gbCopiarTabelas"
        Me.gbCopiarTabelas.Size = New System.Drawing.Size(339, 67)
        Me.gbCopiarTabelas.TabIndex = 13
        Me.gbCopiarTabelas.TabStop = False
        Me.gbCopiarTabelas.Text = "Copiar Tabelas"
        '
        'btListaTabPUnico
        '
        Me.btListaTabPUnico.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btListaTabPUnico.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btListaTabPUnico.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btListaTabPUnico.Location = New System.Drawing.Point(273, 15)
        Me.btListaTabPUnico.Name = "btListaTabPUnico"
        Me.btListaTabPUnico.Size = New System.Drawing.Size(60, 21)
        Me.btListaTabPUnico.TabIndex = 5
        Me.btListaTabPUnico.Text = "Listar"
        Me.btListaTabPUnico.UseVisualStyleBackColor = False
        '
        'btCopiarTabela
        '
        Me.btCopiarTabela.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btCopiarTabela.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCopiarTabela.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCopiarTabela.Location = New System.Drawing.Point(273, 41)
        Me.btCopiarTabela.Name = "btCopiarTabela"
        Me.btCopiarTabela.Size = New System.Drawing.Size(60, 21)
        Me.btCopiarTabela.TabIndex = 4
        Me.btCopiarTabela.Text = "Copiar"
        Me.btCopiarTabela.UseVisualStyleBackColor = False
        '
        'lbDestino
        '
        Me.lbDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDestino.AutoSize = True
        Me.lbDestino.Location = New System.Drawing.Point(10, 46)
        Me.lbDestino.Name = "lbDestino"
        Me.lbDestino.Size = New System.Drawing.Size(43, 13)
        Me.lbDestino.TabIndex = 3
        Me.lbDestino.Text = "Destino"
        '
        'lbOrigem
        '
        Me.lbOrigem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbOrigem.AutoSize = True
        Me.lbOrigem.Location = New System.Drawing.Point(10, 18)
        Me.lbOrigem.Name = "lbOrigem"
        Me.lbOrigem.Size = New System.Drawing.Size(40, 13)
        Me.lbOrigem.TabIndex = 2
        Me.lbOrigem.Text = "Origem"
        '
        'cbTabDestino
        '
        Me.cbTabDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbTabDestino.DisplayMember = "DescTabPreco"
        Me.cbTabDestino.FormattingEnabled = True
        Me.cbTabDestino.Location = New System.Drawing.Point(58, 41)
        Me.cbTabDestino.Name = "cbTabDestino"
        Me.cbTabDestino.Size = New System.Drawing.Size(211, 21)
        Me.cbTabDestino.TabIndex = 1
        '
        'cbTabOrigem
        '
        Me.cbTabOrigem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbTabOrigem.FormattingEnabled = True
        Me.cbTabOrigem.Location = New System.Drawing.Point(58, 15)
        Me.cbTabOrigem.Name = "cbTabOrigem"
        Me.cbTabOrigem.Size = New System.Drawing.Size(211, 21)
        Me.cbTabOrigem.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(517, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Listar Talões :"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdImprimir.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(812, 15)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(33, 21)
        Me.cmdImprimir.TabIndex = 0
        Me.cmdImprimir.Tag = ""
        Me.cmdImprimir.Text = "...."
        Me.cmdImprimir.UseVisualStyleBackColor = False
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdFechar.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdFechar.Location = New System.Drawing.Point(740, 75)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(111, 46)
        Me.cmdFechar.TabIndex = 0
        Me.cmdFechar.Text = "Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdCancelar.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdCancelar.Location = New System.Drawing.Point(625, 75)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(111, 46)
        Me.cmdCancelar.TabIndex = 0
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'cmdGravar
        '
        Me.cmdGravar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGravar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdGravar.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdGravar.Location = New System.Drawing.Point(510, 75)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(111, 46)
        Me.cmdGravar.TabIndex = 0
        Me.cmdGravar.Text = "Gravar"
        Me.cmdGravar.UseVisualStyleBackColor = False
        '
        'GruposBindingSource
        '
        Me.GruposBindingSource.DataMember = "Grupos"
        Me.GruposBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.dgvPrecos)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(861, 425)
        Me.Panel2.TabIndex = 2
        '
        'dgvPrecos
        '
        Me.dgvPrecos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrecos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrecos.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrecos.Name = "dgvPrecos"
        Me.dgvPrecos.Size = New System.Drawing.Size(861, 425)
        Me.dgvPrecos.TabIndex = 1
        '
        'frmGestaoPrecosVenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 550)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmGestaoPrecosVenda"
        Me.Text = "frmGestaoPrecosVenda"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PicBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCopiarTabelas.ResumeLayout(False)
        Me.gbCopiarTabelas.PerformLayout()
        CType(Me.GruposBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvPrecos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents PicBox As System.Windows.Forms.PictureBox
    Friend WithEvents cmdImprimir As System.Windows.Forms.Button
    Friend WithEvents GruposBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents gbCopiarTabelas As System.Windows.Forms.GroupBox
    Friend WithEvents cbTabDestino As System.Windows.Forms.ComboBox
    Friend WithEvents cbTabOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents lbDestino As System.Windows.Forms.Label
    Friend WithEvents lbOrigem As System.Windows.Forms.Label
    Friend WithEvents btCopiarTabela As System.Windows.Forms.Button
    Friend WithEvents dgvPrecos As GirlRootName.GridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbReport As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btListaTabPUnico As System.Windows.Forms.Button
End Class
