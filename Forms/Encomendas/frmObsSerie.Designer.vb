<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmObsSerie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmObsSerie))
        Me.tbDescr = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbArtigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.tbEncomenda = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbObsEnc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.c1tgObsSerie = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.c1tgObsSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbDescr
        '
        Me.tbDescr.Location = New System.Drawing.Point(103, 39)
        Me.tbDescr.Name = "tbDescr"
        Me.tbDescr.Size = New System.Drawing.Size(392, 20)
        Me.tbDescr.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Descrição : "
        '
        'tbArtigo
        '
        Me.tbArtigo.Location = New System.Drawing.Point(247, 12)
        Me.tbArtigo.Name = "tbArtigo"
        Me.tbArtigo.Size = New System.Drawing.Size(114, 20)
        Me.tbArtigo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(198, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Artigo : "
        '
        'btFechar
        '
        Me.btFechar.Location = New System.Drawing.Point(397, 521)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(101, 27)
        Me.btFechar.TabIndex = 4
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'tbEncomenda
        '
        Me.tbEncomenda.Location = New System.Drawing.Point(103, 15)
        Me.tbEncomenda.Name = "tbEncomenda"
        Me.tbEncomenda.Size = New System.Drawing.Size(90, 20)
        Me.tbEncomenda.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Encomenda : "
        '
        'tbObsEnc
        '
        Me.tbObsEnc.Location = New System.Drawing.Point(103, 65)
        Me.tbObsEnc.Name = "tbObsEnc"
        Me.tbObsEnc.Size = New System.Drawing.Size(392, 20)
        Me.tbObsEnc.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Obs Encomenda : "
        '
        'c1tgObsSerie
        '
        Me.c1tgObsSerie.AllowArrows = False
        Me.c1tgObsSerie.CaptionHeight = 17
        Me.c1tgObsSerie.GroupByCaption = "Drag a column header here to group by that column"
        Me.c1tgObsSerie.Images.Add(CType(resources.GetObject("c1tgObsSerie.Images"), System.Drawing.Image))
        Me.c1tgObsSerie.Location = New System.Drawing.Point(11, 105)
        Me.c1tgObsSerie.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.c1tgObsSerie.Name = "c1tgObsSerie"
        Me.c1tgObsSerie.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.c1tgObsSerie.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.c1tgObsSerie.PreviewInfo.ZoomFactor = 75.0R
        Me.c1tgObsSerie.PrintInfo.PageSettings = CType(resources.GetObject("c1tgObsSerie.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.c1tgObsSerie.RecordSelectorWidth = 17
        Me.c1tgObsSerie.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.c1tgObsSerie.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.c1tgObsSerie.RowHeight = 15
        Me.c1tgObsSerie.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.c1tgObsSerie.Size = New System.Drawing.Size(488, 410)
        Me.c1tgObsSerie.TabIndex = 5
        Me.c1tgObsSerie.Text = "C1TrueDBGrid1"
        Me.c1tgObsSerie.PropBag = resources.GetString("c1tgObsSerie.PropBag")
        '
        'frmObsSerie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 561)
        Me.Controls.Add(Me.c1tgObsSerie)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbArtigo)
        Me.Controls.Add(Me.tbEncomenda)
        Me.Controls.Add(Me.tbObsEnc)
        Me.Controls.Add(Me.tbDescr)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmObsSerie"
        Me.Text = "frmObsSerie"
        CType(Me.c1tgObsSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbDescr As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbArtigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents tbEncomenda As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbObsEnc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents c1tgObsSerie As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
