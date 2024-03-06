<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaDocs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaDocs))
        Me.C1TDBGCDocs = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btListaDocs = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.dpDeData = New System.Windows.Forms.DateTimePicker()
        Me.dpAteData = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tbValor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.C1TDBGCDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1TDBGCDocs
        '
        Me.C1TDBGCDocs.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.C1TDBGCDocs.AllowColMove = False
        Me.C1TDBGCDocs.AlternatingRows = True
        Me.C1TDBGCDocs.CaptionHeight = 28
        Me.TableLayoutPanel1.SetColumnSpan(Me.C1TDBGCDocs, 6)
        Me.C1TDBGCDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1TDBGCDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1TDBGCDocs.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TDBGCDocs.Images.Add(CType(resources.GetObject("C1TDBGCDocs.Images"), System.Drawing.Image))
        Me.C1TDBGCDocs.Location = New System.Drawing.Point(4, 44)
        Me.C1TDBGCDocs.Margin = New System.Windows.Forms.Padding(4)
        Me.C1TDBGCDocs.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1TDBGCDocs.Name = "C1TDBGCDocs"
        Me.C1TDBGCDocs.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TDBGCDocs.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TDBGCDocs.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TDBGCDocs.PrintInfo.PageSettings = CType(resources.GetObject("C1TDBGCDocs.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TDBGCDocs.RecordSelectorWidth = 21
        Me.C1TDBGCDocs.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TDBGCDocs.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TDBGCDocs.RowHeight = 20
        Me.C1TDBGCDocs.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TDBGCDocs.Size = New System.Drawing.Size(1524, 651)
        Me.C1TDBGCDocs.TabIndex = 1
        Me.C1TDBGCDocs.Text = "C1TrueDBGrid1"
        Me.C1TDBGCDocs.PropBag = resources.GetString("C1TDBGCDocs.PropBag")
        '
        'btListaDocs
        '
        Me.btListaDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btListaDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btListaDocs.Location = New System.Drawing.Point(660, 2)
        Me.btListaDocs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btListaDocs.Name = "btListaDocs"
        Me.btListaDocs.Size = New System.Drawing.Size(179, 36)
        Me.btListaDocs.TabIndex = 2
        Me.btListaDocs.Text = "Docs"
        Me.btListaDocs.UseVisualStyleBackColor = True
        '
        'btFechar
        '
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btFechar.Location = New System.Drawing.Point(1364, 4)
        Me.btFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(164, 32)
        Me.btFechar.TabIndex = 92
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'dpDeData
        '
        Me.dpDeData.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpDeData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dpDeData.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dpDeData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDeData.Location = New System.Drawing.Point(4, 4)
        Me.dpDeData.Margin = New System.Windows.Forms.Padding(4)
        Me.dpDeData.Name = "dpDeData"
        Me.dpDeData.Size = New System.Drawing.Size(307, 28)
        Me.dpDeData.TabIndex = 94
        '
        'dpAteData
        '
        Me.dpAteData.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpAteData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dpAteData.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dpAteData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpAteData.Location = New System.Drawing.Point(319, 4)
        Me.dpAteData.Margin = New System.Windows.Forms.Padding(4)
        Me.dpAteData.Name = "dpAteData"
        Me.dpAteData.Size = New System.Drawing.Size(334, 28)
        Me.dpAteData.TabIndex = 95
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.90698!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.09302!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 431.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.C1TDBGCDocs, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dpAteData, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dpDeData, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btFechar, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btListaDocs, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbValor, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.76324!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.23676!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1532, 699)
        Me.TableLayoutPanel1.TabIndex = 96
        '
        'tbValor
        '
        Me.tbValor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValor.Location = New System.Drawing.Point(932, 5)
        Me.tbValor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbValor.Name = "tbValor"
        Me.tbValor.Size = New System.Drawing.Size(425, 30)
        Me.tbValor.TabIndex = 97
        Me.tbValor.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(845, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 25)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Valor:"
        Me.Label1.Visible = False
        '
        'frmConsultaDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1532, 699)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmConsultaDocs"
        Me.Text = "frmConsultaDocs"
        CType(Me.C1TDBGCDocs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1TDBGCDocs As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btListaDocs As Button
    Friend WithEvents btFechar As Button
    Friend WithEvents dpDeData As DateTimePicker
    Friend WithEvents dpAteData As DateTimePicker
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents tbValor As TextBox
End Class
