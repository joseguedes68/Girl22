<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaModelosCor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaModelosCor))
        Me.C1TDBGCTaloes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.CmdFechar = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.C1DbNavigator = New C1.Win.C1Input.C1DbNavigator
        Me.cmdActualiza = New System.Windows.Forms.Button
        CType(Me.C1TDBGCTaloes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1DbNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1TDBGCTaloes
        '
        Me.C1TDBGCTaloes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TDBGCTaloes.CaptionHeight = 17
        Me.C1TDBGCTaloes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1TDBGCTaloes.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TDBGCTaloes.Images.Add(CType(resources.GetObject("C1TDBGCTaloes.Images"), System.Drawing.Image))
        Me.C1TDBGCTaloes.Location = New System.Drawing.Point(2, 51)
        Me.C1TDBGCTaloes.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1TDBGCTaloes.Name = "C1TDBGCTaloes"
        Me.C1TDBGCTaloes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TDBGCTaloes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TDBGCTaloes.PreviewInfo.ZoomFactor = 75
        Me.C1TDBGCTaloes.PrintInfo.PageSettings = CType(resources.GetObject("C1TDBGCTaloes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TDBGCTaloes.RecordSelectorWidth = 17
        Me.C1TDBGCTaloes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TDBGCTaloes.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TDBGCTaloes.RowHeight = 15
        Me.C1TDBGCTaloes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TDBGCTaloes.Size = New System.Drawing.Size(801, 368)
        Me.C1TDBGCTaloes.TabIndex = 0
        Me.C1TDBGCTaloes.Text = "C1TrueDBGrid1"
        Me.C1TDBGCTaloes.PropBag = resources.GetString("C1TDBGCTaloes.PropBag")
        '
        'CmdFechar
        '
        Me.CmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdFechar.Location = New System.Drawing.Point(710, 12)
        Me.CmdFechar.Name = "CmdFechar"
        Me.CmdFechar.Size = New System.Drawing.Size(75, 23)
        Me.CmdFechar.TabIndex = 2
        Me.CmdFechar.Text = "Fechar"
        Me.CmdFechar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(629, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Listar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'C1DbNavigator
        '
        Me.C1DbNavigator.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.C1DbNavigator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.C1DbNavigator.Location = New System.Drawing.Point(12, 425)
        Me.C1DbNavigator.Name = "C1DbNavigator"
        Me.C1DbNavigator.Size = New System.Drawing.Size(290, 24)
        Me.C1DbNavigator.TabIndex = 4
        '
        'cmdActualiza
        '
        Me.cmdActualiza.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdActualiza.Location = New System.Drawing.Point(548, 12)
        Me.cmdActualiza.Name = "cmdActualiza"
        Me.cmdActualiza.Size = New System.Drawing.Size(75, 23)
        Me.cmdActualiza.TabIndex = 6
        Me.cmdActualiza.Text = "Actualizar"
        Me.cmdActualiza.UseVisualStyleBackColor = True
        '
        'frmConsultaTalao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 452)
        Me.Controls.Add(Me.cmdActualiza)
        Me.Controls.Add(Me.C1DbNavigator)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CmdFechar)
        Me.Controls.Add(Me.C1TDBGCTaloes)
        Me.Name = "frmConsultaTalao"
        Me.Text = "frmConsultaModelosCor"
        CType(Me.C1TDBGCTaloes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1DbNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1TDBGCTaloes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents CmdFechar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents C1DbNavigator As C1.Win.C1Input.C1DbNavigator
    Friend WithEvents cmdActualiza As System.Windows.Forms.Button
End Class
