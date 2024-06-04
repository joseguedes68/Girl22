<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVendasLista
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CbLojas = New System.Windows.Forms.ComboBox()
        Me.tbPesquisa = New System.Windows.Forms.TextBox()
        Me.btok = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.btPesquisa = New System.Windows.Forms.Button()
        Me.cbDA = New System.Windows.Forms.CheckBox()
        Me.dgvListaDocs = New System.Windows.Forms.DataGridView()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvListaDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CbLojas, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPesquisa, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btok, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btFechar, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btCancel, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btPesquisa, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbDA, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvListaDocs, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox, 2, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1688, 759)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CbLojas
        '
        Me.CbLojas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbLojas.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.CbLojas.FormattingEnabled = True
        Me.CbLojas.Location = New System.Drawing.Point(3, 3)
        Me.CbLojas.Name = "CbLojas"
        Me.CbLojas.Size = New System.Drawing.Size(1175, 31)
        Me.CbLojas.TabIndex = 22
        '
        'tbPesquisa
        '
        Me.tbPesquisa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPesquisa.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPesquisa.Location = New System.Drawing.Point(3, 46)
        Me.tbPesquisa.Name = "tbPesquisa"
        Me.tbPesquisa.Size = New System.Drawing.Size(1175, 30)
        Me.tbPesquisa.TabIndex = 23
        '
        'btok
        '
        Me.btok.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btok.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btok.Location = New System.Drawing.Point(1521, 4)
        Me.btok.Margin = New System.Windows.Forms.Padding(4)
        Me.btok.Name = "btok"
        Me.btok.Size = New System.Drawing.Size(163, 35)
        Me.btok.TabIndex = 20
        Me.btok.Text = "OK"
        Me.btok.UseVisualStyleBackColor = False
        '
        'btFechar
        '
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFechar.Location = New System.Drawing.Point(1520, 46)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(165, 35)
        Me.btFechar.TabIndex = 25
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'btCancel
        '
        Me.btCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancel.Location = New System.Drawing.Point(1353, 4)
        Me.btCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(160, 35)
        Me.btCancel.TabIndex = 19
        Me.btCancel.Text = "Cancelar"
        Me.btCancel.UseVisualStyleBackColor = False
        '
        'btPesquisa
        '
        Me.btPesquisa.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btPesquisa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btPesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPesquisa.Location = New System.Drawing.Point(1184, 46)
        Me.btPesquisa.Name = "btPesquisa"
        Me.btPesquisa.Size = New System.Drawing.Size(162, 35)
        Me.btPesquisa.TabIndex = 24
        Me.btPesquisa.Text = "Pesquisar"
        Me.btPesquisa.UseVisualStyleBackColor = False
        '
        'cbDA
        '
        Me.cbDA.AutoSize = True
        Me.cbDA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDA.Location = New System.Drawing.Point(1184, 3)
        Me.cbDA.Name = "cbDA"
        Me.cbDA.Size = New System.Drawing.Size(162, 37)
        Me.cbDA.TabIndex = 26
        Me.cbDA.Text = "Devoluções Autorizadas"
        Me.cbDA.UseVisualStyleBackColor = True
        '
        'dgvListaDocs
        '
        Me.dgvListaDocs.AllowUserToAddRows = False
        Me.dgvListaDocs.AllowUserToDeleteRows = False
        Me.dgvListaDocs.AllowUserToOrderColumns = True
        Me.dgvListaDocs.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvListaDocs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListaDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvListaDocs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvListaDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvListaDocs, 2)
        Me.dgvListaDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvListaDocs.Location = New System.Drawing.Point(3, 87)
        Me.dgvListaDocs.MultiSelect = False
        Me.dgvListaDocs.Name = "dgvListaDocs"
        Me.dgvListaDocs.RowHeadersWidth = 51
        Me.dgvListaDocs.RowTemplate.Height = 24
        Me.dgvListaDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListaDocs.Size = New System.Drawing.Size(1343, 669)
        Me.dgvListaDocs.TabIndex = 21
        '
        'PictureBox
        '
        Me.PictureBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.PictureBox, 2)
        Me.PictureBox.Location = New System.Drawing.Point(1352, 87)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(333, 237)
        Me.PictureBox.TabIndex = 27
        Me.PictureBox.TabStop = False
        '
        'frmVendasLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1688, 759)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmVendasLista"
        Me.Text = "frmVendasLista"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvListaDocs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btCancel As Button
    Friend WithEvents btok As Button
    Friend WithEvents dgvListaDocs As DataGridView
    Friend WithEvents CbLojas As ComboBox
    Friend WithEvents tbPesquisa As TextBox
    Friend WithEvents btPesquisa As Button
    Friend WithEvents btFechar As Button
    Friend WithEvents cbDA As CheckBox
    Friend WithEvents PictureBox As PictureBox
End Class
