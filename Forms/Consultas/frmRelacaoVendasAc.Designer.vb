<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRelacaoVendasAc
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CRViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.dpDeData = New System.Windows.Forms.DateTimePicker()
        Me.dpAteData = New System.Windows.Forms.DateTimePicker()
        Me.cbLojas = New System.Windows.Forms.ComboBox()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btAnulados = New System.Windows.Forms.Button()
        Me.btVnd = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.CRViewer, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dpDeData, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dpAteData, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbLojas, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btFechar, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btAnulados, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btVnd, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.616257!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.38374!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1630, 682)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CRViewer
        '
        Me.CRViewer.ActiveViewIndex = -1
        Me.CRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.CRViewer, 10)
        Me.CRViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRViewer.Location = New System.Drawing.Point(4, 49)
        Me.CRViewer.Margin = New System.Windows.Forms.Padding(4)
        Me.CRViewer.Name = "CRViewer"
        Me.CRViewer.Size = New System.Drawing.Size(1628, 629)
        Me.CRViewer.TabIndex = 1
        Me.CRViewer.ToolPanelWidth = 267
        '
        'dpDeData
        '
        Me.dpDeData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dpDeData.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpDeData.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dpDeData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDeData.Location = New System.Drawing.Point(4, 4)
        Me.dpDeData.Margin = New System.Windows.Forms.Padding(4)
        Me.dpDeData.Name = "dpDeData"
        Me.dpDeData.Size = New System.Drawing.Size(203, 28)
        Me.dpDeData.TabIndex = 2
        '
        'dpAteData
        '
        Me.dpAteData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dpAteData.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpAteData.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dpAteData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpAteData.Location = New System.Drawing.Point(215, 4)
        Me.dpAteData.Margin = New System.Windows.Forms.Padding(4)
        Me.dpAteData.Name = "dpAteData"
        Me.dpAteData.Size = New System.Drawing.Size(192, 28)
        Me.dpAteData.TabIndex = 2
        '
        'cbLojas
        '
        Me.cbLojas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbLojas.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbLojas.FormattingEnabled = True
        Me.cbLojas.Location = New System.Drawing.Point(415, 4)
        Me.cbLojas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbLojas.Name = "cbLojas"
        Me.cbLojas.Size = New System.Drawing.Size(380, 28)
        Me.cbLojas.TabIndex = 3
        '
        'btFechar
        '
        Me.btFechar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btFechar.Location = New System.Drawing.Point(1483, 4)
        Me.btFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(149, 37)
        Me.btFechar.TabIndex = 5
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'btAnulados
        '
        Me.btAnulados.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btAnulados.Location = New System.Drawing.Point(1255, 4)
        Me.btAnulados.Margin = New System.Windows.Forms.Padding(4)
        Me.btAnulados.Name = "btAnulados"
        Me.btAnulados.Size = New System.Drawing.Size(214, 37)
        Me.btAnulados.TabIndex = 0
        Me.btAnulados.Text = "Defeitos Acessórios"
        Me.btAnulados.UseVisualStyleBackColor = True
        '
        'btVnd
        '
        Me.btVnd.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btVnd.Location = New System.Drawing.Point(1033, 4)
        Me.btVnd.Margin = New System.Windows.Forms.Padding(4)
        Me.btVnd.Name = "btVnd"
        Me.btVnd.Size = New System.Drawing.Size(214, 37)
        Me.btVnd.TabIndex = 4
        Me.btVnd.Text = "Vnd Acessorios"
        Me.btVnd.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(812, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(214, 37)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Defeitos Calçado"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmRelacaoVendasAc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1630, 682)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmRelacaoVendasAc"
        Me.Text = "Relação de Vendas"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btAnulados As System.Windows.Forms.Button
    Friend WithEvents dpDeData As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpAteData As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbLojas As System.Windows.Forms.ComboBox
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents btVnd As System.Windows.Forms.Button
    Private WithEvents CRViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Button1 As Button
End Class
