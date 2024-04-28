<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaTalao
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaTalao))
        Me.C1TDBGCTaloes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.CmdFechar = New System.Windows.Forms.Button()
        Me.btListarTaloes = New System.Windows.Forms.Button()
        Me.C1DbNavigator = New C1.Win.C1Input.C1DbNavigator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdActualiza = New System.Windows.Forms.Button()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.tbFiltraTalao = New System.Windows.Forms.TextBox()
        Me.lbFiltro = New System.Windows.Forms.ListBox()
        Me.cmdFiltrar = New System.Windows.Forms.Button()
        Me.cbVerTodas = New System.Windows.Forms.CheckBox()
        Me.btDetTalao = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btDev = New System.Windows.Forms.Button()
        Me.btAnular = New System.Windows.Forms.Button()
        Me.cbReport = New System.Windows.Forms.ComboBox()
        Me.btValor = New System.Windows.Forms.Button()
        Me.btForn = New System.Windows.Forms.Button()
        Me.btValidaTalao = New System.Windows.Forms.Button()
        Me.btCancelar = New System.Windows.Forms.Button()
        CType(Me.C1TDBGCTaloes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1DbNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1TDBGCTaloes
        '
        Me.C1TDBGCTaloes.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.C1TDBGCTaloes.AllowColMove = False
        Me.C1TDBGCTaloes.AlternatingRows = True
        Me.C1TDBGCTaloes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TDBGCTaloes.CaptionHeight = 28
        Me.C1TDBGCTaloes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1TDBGCTaloes.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TDBGCTaloes.Images.Add(CType(resources.GetObject("C1TDBGCTaloes.Images"), System.Drawing.Image))
        Me.C1TDBGCTaloes.Location = New System.Drawing.Point(5, 260)
        Me.C1TDBGCTaloes.Margin = New System.Windows.Forms.Padding(4)
        Me.C1TDBGCTaloes.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1TDBGCTaloes.Name = "C1TDBGCTaloes"
        Me.C1TDBGCTaloes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TDBGCTaloes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TDBGCTaloes.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TDBGCTaloes.PrintInfo.PageSettings = CType(resources.GetObject("C1TDBGCTaloes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TDBGCTaloes.RecordSelectorWidth = 21
        Me.C1TDBGCTaloes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TDBGCTaloes.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TDBGCTaloes.RowHeight = 20
        Me.C1TDBGCTaloes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TDBGCTaloes.Size = New System.Drawing.Size(1658, 428)
        Me.C1TDBGCTaloes.TabIndex = 0
        Me.C1TDBGCTaloes.Text = "C1TrueDBGrid1"
        Me.C1TDBGCTaloes.PropBag = resources.GetString("C1TDBGCTaloes.PropBag")
        '
        'CmdFechar
        '
        Me.CmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CmdFechar.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.CmdFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFechar.Location = New System.Drawing.Point(1417, 18)
        Me.CmdFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdFechar.Name = "CmdFechar"
        Me.CmdFechar.Size = New System.Drawing.Size(133, 39)
        Me.CmdFechar.TabIndex = 2
        Me.CmdFechar.Text = "Fechar"
        Me.CmdFechar.UseVisualStyleBackColor = False
        '
        'btListarTaloes
        '
        Me.btListarTaloes.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btListarTaloes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btListarTaloes.Location = New System.Drawing.Point(304, 94)
        Me.btListarTaloes.Margin = New System.Windows.Forms.Padding(4)
        Me.btListarTaloes.Name = "btListarTaloes"
        Me.btListarTaloes.Size = New System.Drawing.Size(111, 30)
        Me.btListarTaloes.TabIndex = 2
        Me.btListarTaloes.Text = "Imprimir"
        Me.btListarTaloes.UseVisualStyleBackColor = False
        '
        'C1DbNavigator
        '
        Me.C1DbNavigator.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.C1DbNavigator.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1DbNavigator.Location = New System.Drawing.Point(16, 201)
        Me.C1DbNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.C1DbNavigator.Name = "C1DbNavigator"
        Me.C1DbNavigator.Size = New System.Drawing.Size(513, 30)
        Me.C1DbNavigator.TabIndex = 4
        Me.C1DbNavigator.UIStrings.Content = New String() {"of {0}:de {0}", "Row`::Linha :"}
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(287, 239)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(562, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Legenda :  G - Gerada  |  S - Stock  |  T - Transito  |   V - Vendida  |  R - Rec" &
    "olhida   |  A - Anulado"
        Me.Label1.Visible = False
        '
        'cmdActualiza
        '
        Me.cmdActualiza.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdActualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActualiza.Location = New System.Drawing.Point(537, 95)
        Me.cmdActualiza.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdActualiza.Name = "cmdActualiza"
        Me.cmdActualiza.Size = New System.Drawing.Size(169, 42)
        Me.cmdActualiza.TabIndex = 6
        Me.cmdActualiza.Text = "Listar Talões"
        Me.cmdActualiza.UseVisualStyleBackColor = False
        '
        'PictureBox
        '
        Me.PictureBox.Location = New System.Drawing.Point(1099, 10)
        Me.PictureBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(310, 241)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox.TabIndex = 7
        Me.PictureBox.TabStop = False
        '
        'tbFiltraTalao
        '
        Me.tbFiltraTalao.AcceptsReturn = True
        Me.tbFiltraTalao.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFiltraTalao.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFiltraTalao.Location = New System.Drawing.Point(15, 36)
        Me.tbFiltraTalao.Margin = New System.Windows.Forms.Padding(4)
        Me.tbFiltraTalao.Name = "tbFiltraTalao"
        Me.tbFiltraTalao.Size = New System.Drawing.Size(169, 30)
        Me.tbFiltraTalao.TabIndex = 9
        '
        'lbFiltro
        '
        Me.lbFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFiltro.FormattingEnabled = True
        Me.lbFiltro.ItemHeight = 25
        Me.lbFiltro.Location = New System.Drawing.Point(15, 78)
        Me.lbFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.lbFiltro.Name = "lbFiltro"
        Me.lbFiltro.Size = New System.Drawing.Size(169, 129)
        Me.lbFiltro.TabIndex = 10
        '
        'cmdFiltrar
        '
        Me.cmdFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFiltrar.Location = New System.Drawing.Point(567, 144)
        Me.cmdFiltrar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdFiltrar.Name = "cmdFiltrar"
        Me.cmdFiltrar.Size = New System.Drawing.Size(115, 32)
        Me.cmdFiltrar.TabIndex = 11
        Me.cmdFiltrar.Text = "Filtrar"
        Me.cmdFiltrar.UseVisualStyleBackColor = True
        Me.cmdFiltrar.Visible = False
        '
        'cbVerTodas
        '
        Me.cbVerTodas.AutoSize = True
        Me.cbVerTodas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVerTodas.Location = New System.Drawing.Point(567, 11)
        Me.cbVerTodas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbVerTodas.Name = "cbVerTodas"
        Me.cbVerTodas.Size = New System.Drawing.Size(130, 28)
        Me.cbVerTodas.TabIndex = 39
        Me.cbVerTodas.Text = "Ver Todos"
        Me.cbVerTodas.UseVisualStyleBackColor = True
        '
        'btDetTalao
        '
        Me.btDetTalao.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btDetTalao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDetTalao.Location = New System.Drawing.Point(537, 46)
        Me.btDetTalao.Margin = New System.Windows.Forms.Padding(4)
        Me.btDetTalao.Name = "btDetTalao"
        Me.btDetTalao.Size = New System.Drawing.Size(169, 42)
        Me.btDetTalao.TabIndex = 41
        Me.btDetTalao.Text = "Detalhe Talão"
        Me.btDetTalao.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 20)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Localizar Etiquetas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(289, 36)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Consulta de Talões"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tbFiltraTalao)
        Me.Panel1.Controls.Add(Me.lbFiltro)
        Me.Panel1.Location = New System.Drawing.Point(731, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(204, 214)
        Me.Panel1.TabIndex = 45
        '
        'btDev
        '
        Me.btDev.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btDev.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btDev.Location = New System.Drawing.Point(1417, 107)
        Me.btDev.Margin = New System.Windows.Forms.Padding(4)
        Me.btDev.Name = "btDev"
        Me.btDev.Size = New System.Drawing.Size(133, 39)
        Me.btDev.TabIndex = 46
        Me.btDev.Text = "Devoluções"
        Me.btDev.UseVisualStyleBackColor = False
        Me.btDev.Visible = False
        '
        'btAnular
        '
        Me.btAnular.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btAnular.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btAnular.Location = New System.Drawing.Point(1417, 60)
        Me.btAnular.Margin = New System.Windows.Forms.Padding(4)
        Me.btAnular.Name = "btAnular"
        Me.btAnular.Size = New System.Drawing.Size(133, 39)
        Me.btAnular.TabIndex = 47
        Me.btAnular.Text = "Anular"
        Me.btAnular.UseVisualStyleBackColor = False
        Me.btAnular.Visible = False
        '
        'cbReport
        '
        Me.cbReport.DisplayMember = "RptTaloes_3x2"
        Me.cbReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReport.FormattingEnabled = True
        Me.cbReport.Items.AddRange(New Object() {"RptTaloes_10x4SemTam", "RptTaloes_3x2", "RptRelTaloes", "RptRelaTaloesCB", "EtiquetasPreco_13x5", "RptEtiqAuto_100x38", "RptRelaTaloesCB", "RptTaloes_105x37", "RptContinuo_102x38"})
        Me.cbReport.Location = New System.Drawing.Point(16, 95)
        Me.cbReport.Margin = New System.Windows.Forms.Padding(4)
        Me.cbReport.Name = "cbReport"
        Me.cbReport.Size = New System.Drawing.Size(279, 28)
        Me.cbReport.TabIndex = 37
        '
        'btValor
        '
        Me.btValor.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btValor.Location = New System.Drawing.Point(431, 10)
        Me.btValor.Margin = New System.Windows.Forms.Padding(4)
        Me.btValor.Name = "btValor"
        Me.btValor.Size = New System.Drawing.Size(99, 36)
        Me.btValor.TabIndex = 49
        Me.btValor.Text = "Valor"
        Me.btValor.UseVisualStyleBackColor = False
        Me.btValor.Visible = False
        '
        'btForn
        '
        Me.btForn.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btForn.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btForn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btForn.Location = New System.Drawing.Point(1417, 201)
        Me.btForn.Margin = New System.Windows.Forms.Padding(4)
        Me.btForn.Name = "btForn"
        Me.btForn.Size = New System.Drawing.Size(133, 39)
        Me.btForn.TabIndex = 50
        Me.btForn.TabStop = False
        Me.btForn.Text = "Fornecedores"
        Me.btForn.UseVisualStyleBackColor = False
        '
        'btValidaTalao
        '
        Me.btValidaTalao.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btValidaTalao.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btValidaTalao.Location = New System.Drawing.Point(943, 26)
        Me.btValidaTalao.Margin = New System.Windows.Forms.Padding(4)
        Me.btValidaTalao.Name = "btValidaTalao"
        Me.btValidaTalao.Size = New System.Drawing.Size(151, 78)
        Me.btValidaTalao.TabIndex = 51
        Me.btValidaTalao.Text = "Validar Talões"
        Me.btValidaTalao.UseVisualStyleBackColor = False
        '
        'btCancelar
        '
        Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancelar.Location = New System.Drawing.Point(943, 107)
        Me.btCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(151, 78)
        Me.btCancelar.TabIndex = 52
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'frmConsultaTalao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1676, 688)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.btValidaTalao)
        Me.Controls.Add(Me.btForn)
        Me.Controls.Add(Me.btValor)
        Me.Controls.Add(Me.cbReport)
        Me.Controls.Add(Me.btListarTaloes)
        Me.Controls.Add(Me.C1DbNavigator)
        Me.Controls.Add(Me.btAnular)
        Me.Controls.Add(Me.btDev)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btDetTalao)
        Me.Controls.Add(Me.cbVerTodas)
        Me.Controls.Add(Me.cmdFiltrar)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.cmdActualiza)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmdFechar)
        Me.Controls.Add(Me.C1TDBGCTaloes)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmConsultaTalao"
        Me.Text = "Consulta de Talões "
        CType(Me.C1TDBGCTaloes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1DbNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1TDBGCTaloes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents CmdFechar As System.Windows.Forms.Button
    Friend WithEvents btListarTaloes As System.Windows.Forms.Button
    Friend WithEvents C1DbNavigator As C1.Win.C1Input.C1DbNavigator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdActualiza As System.Windows.Forms.Button
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents tbFiltraTalao As System.Windows.Forms.TextBox
    Friend WithEvents lbFiltro As System.Windows.Forms.ListBox
    Friend WithEvents cmdFiltrar As System.Windows.Forms.Button
    Friend WithEvents cbVerTodas As System.Windows.Forms.CheckBox
    Friend WithEvents btDetTalao As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btDev As System.Windows.Forms.Button
    Friend WithEvents btAnular As System.Windows.Forms.Button
    Friend WithEvents cbReport As System.Windows.Forms.ComboBox
    Friend WithEvents btValor As System.Windows.Forms.Button
    Friend WithEvents btForn As System.Windows.Forms.Button
    Friend WithEvents btValidaTalao As Button
    Friend WithEvents btCancelar As Button
End Class
