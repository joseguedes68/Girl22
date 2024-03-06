<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecolha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecolha))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbVerTodas = New System.Windows.Forms.CheckBox()
        Me.C1TGReCab = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lbCab = New System.Windows.Forms.Label()
        Me.C1TGReDet = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TimerActDados = New System.Windows.Forms.Timer(Me.components)
        Me.CmdGerRecolha = New System.Windows.Forms.Button()
        Me.btLista = New System.Windows.Forms.Button()
        Me.CmdValidarRecolha = New System.Windows.Forms.Button()
        Me.cmdFechar = New System.Windows.Forms.Button()
        Me.c1fgRecolhaResumo = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.dgvDespesas = New System.Windows.Forms.DataGridView()
        Me.Descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DespesasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.GroupBox4.SuspendLayout()
        CType(Me.C1TGReCab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TGReDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1fgRecolhaResumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDespesas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DespesasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.cbVerTodas)
        Me.GroupBox4.Controls.Add(Me.C1TGReCab)
        Me.GroupBox4.Controls.Add(Me.lbCab)
        Me.GroupBox4.Location = New System.Drawing.Point(1, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(550, 547)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        '
        'cbVerTodas
        '
        Me.cbVerTodas.AutoSize = True
        Me.cbVerTodas.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbVerTodas.Location = New System.Drawing.Point(231, 10)
        Me.cbVerTodas.Name = "cbVerTodas"
        Me.cbVerTodas.Size = New System.Drawing.Size(127, 25)
        Me.cbVerTodas.TabIndex = 32
        Me.cbVerTodas.Text = "Ver Todas"
        Me.cbVerTodas.UseVisualStyleBackColor = True
        '
        'C1TGReCab
        '
        Me.C1TGReCab.AllowDelete = True
        Me.C1TGReCab.AlternatingRows = True
        Me.C1TGReCab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TGReCab.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.C1TGReCab.CaptionHeight = 17
        Me.C1TGReCab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1TGReCab.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TGReCab.Images.Add(CType(resources.GetObject("C1TGReCab.Images"), System.Drawing.Image))
        Me.C1TGReCab.Location = New System.Drawing.Point(10, 45)
        Me.C1TGReCab.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1TGReCab.Name = "C1TGReCab"
        Me.C1TGReCab.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TGReCab.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TGReCab.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TGReCab.PrintInfo.PageSettings = CType(resources.GetObject("C1TGReCab.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TGReCab.RecordSelectorWidth = 25
        Me.C1TGReCab.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TGReCab.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TGReCab.RowHeight = 15
        Me.C1TGReCab.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TGReCab.Size = New System.Drawing.Size(534, 496)
        Me.C1TGReCab.TabIndex = 16
        Me.C1TGReCab.Text = "C1TrueDBGrid1"
        Me.C1TGReCab.PropBag = resources.GetString("C1TGReCab.PropBag")
        '
        'lbCab
        '
        Me.lbCab.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCab.Location = New System.Drawing.Point(6, 10)
        Me.lbCab.Name = "lbCab"
        Me.lbCab.Size = New System.Drawing.Size(208, 26)
        Me.lbCab.TabIndex = 13
        Me.lbCab.Text = "Dinâmico"
        Me.lbCab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1TGReDet
        '
        Me.C1TGReDet.AllowDelete = True
        Me.C1TGReDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TGReDet.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.C1TGReDet.CaptionHeight = 17
        Me.C1TGReDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1TGReDet.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TGReDet.Images.Add(CType(resources.GetObject("C1TGReDet.Images"), System.Drawing.Image))
        Me.C1TGReDet.Location = New System.Drawing.Point(571, 57)
        Me.C1TGReDet.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1TGReDet.Name = "C1TGReDet"
        Me.C1TGReDet.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TGReDet.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TGReDet.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TGReDet.PrintInfo.PageSettings = CType(resources.GetObject("C1TGReDet.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TGReDet.RecordSelectorWidth = 17
        Me.C1TGReDet.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TGReDet.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TGReDet.RowHeight = 15
        Me.C1TGReDet.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TGReDet.Size = New System.Drawing.Size(481, 409)
        Me.C1TGReDet.TabIndex = 16
        Me.C1TGReDet.Text = "C1TrueDBGrid1"
        Me.C1TGReDet.PropBag = resources.GetString("C1TGReDet.PropBag")
        '
        'TimerActDados
        '
        '
        'CmdGerRecolha
        '
        Me.CmdGerRecolha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdGerRecolha.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdGerRecolha.Location = New System.Drawing.Point(899, 11)
        Me.CmdGerRecolha.Name = "CmdGerRecolha"
        Me.CmdGerRecolha.Size = New System.Drawing.Size(60, 28)
        Me.CmdGerRecolha.TabIndex = 29
        Me.CmdGerRecolha.Text = "Recolher"
        Me.CmdGerRecolha.UseVisualStyleBackColor = False
        '
        'btLista
        '
        Me.btLista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btLista.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btLista.Location = New System.Drawing.Point(825, 11)
        Me.btLista.Name = "btLista"
        Me.btLista.Size = New System.Drawing.Size(60, 28)
        Me.btLista.TabIndex = 29
        Me.btLista.Text = "Imprimir"
        Me.btLista.UseVisualStyleBackColor = False
        '
        'CmdValidarRecolha
        '
        Me.CmdValidarRecolha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdValidarRecolha.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdValidarRecolha.ForeColor = System.Drawing.Color.Red
        Me.CmdValidarRecolha.Location = New System.Drawing.Point(734, 11)
        Me.CmdValidarRecolha.Name = "CmdValidarRecolha"
        Me.CmdValidarRecolha.Size = New System.Drawing.Size(76, 28)
        Me.CmdValidarRecolha.TabIndex = 30
        Me.CmdValidarRecolha.Text = "Validar"
        Me.CmdValidarRecolha.UseVisualStyleBackColor = False
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdFechar.Location = New System.Drawing.Point(973, 11)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(68, 28)
        Me.cmdFechar.TabIndex = 31
        Me.cmdFechar.Text = "Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'c1fgRecolhaResumo
        '
        Me.c1fgRecolhaResumo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.c1fgRecolhaResumo.ColumnInfo = "10,1,0,0,0,85,Columns:0{Width:18;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1fgRecolhaResumo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.c1fgRecolhaResumo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.c1fgRecolhaResumo.Location = New System.Drawing.Point(571, 472)
        Me.c1fgRecolhaResumo.Name = "c1fgRecolhaResumo"
        Me.c1fgRecolhaResumo.Rows.DefaultSize = 17
        Me.c1fgRecolhaResumo.Size = New System.Drawing.Size(481, 87)
        Me.c1fgRecolhaResumo.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("c1fgRecolhaResumo.Styles"))
        Me.c1fgRecolhaResumo.TabIndex = 32
        Me.c1fgRecolhaResumo.Tree.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        '
        'dgvDespesas
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvDespesas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDespesas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDespesas.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDespesas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDespesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDespesas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descricao, Me.Valor})
        Me.dgvDespesas.DataSource = Me.DespesasBindingSource
        Me.dgvDespesas.Location = New System.Drawing.Point(571, 12)
        Me.dgvDespesas.Name = "dgvDespesas"
        Me.dgvDespesas.RowHeadersWidth = 30
        Me.dgvDespesas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDespesas.Size = New System.Drawing.Size(143, 35)
        Me.dgvDespesas.TabIndex = 34
        Me.dgvDespesas.Visible = False
        '
        'Descricao
        '
        Me.Descricao.DataPropertyName = "Descricao"
        Me.Descricao.HeaderText = "Despesa"
        Me.Descricao.Name = "Descricao"
        Me.Descricao.Width = 320
        '
        'Valor
        '
        Me.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Valor.DataPropertyName = "Valor"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "c"
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle3
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.Width = 70
        '
        'DespesasBindingSource
        '
        Me.DespesasBindingSource.DataMember = "Despesas"
        Me.DespesasBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmRecolha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1054, 571)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.c1fgRecolhaResumo)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.CmdValidarRecolha)
        Me.Controls.Add(Me.C1TGReDet)
        Me.Controls.Add(Me.btLista)
        Me.Controls.Add(Me.CmdGerRecolha)
        Me.Controls.Add(Me.dgvDespesas)
        Me.Name = "frmRecolha"
        Me.Text = "frmRecolha"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.C1TGReCab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TGReDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1fgRecolhaResumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDespesas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DespesasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents C1TGReCab As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lbCab As System.Windows.Forms.Label
    Friend WithEvents C1TGReDet As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TimerActDados As System.Windows.Forms.Timer
    Friend WithEvents CmdGerRecolha As System.Windows.Forms.Button
    Friend WithEvents btLista As System.Windows.Forms.Button
    Friend WithEvents CmdValidarRecolha As System.Windows.Forms.Button
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cbVerTodas As System.Windows.Forms.CheckBox
    Friend WithEvents c1fgRecolhaResumo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents dgvDespesas As System.Windows.Forms.DataGridView
    Friend WithEvents DespesasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents Descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
