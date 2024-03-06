<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockLoja
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockLoja))
        Me.CFGDet = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lbArtigo = New System.Windows.Forms.Label()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.gbEncomendas = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbVerDetalhe = New System.Windows.Forms.CheckBox()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.CmdConfEnc = New System.Windows.Forms.Button()
        Me.txtPrCusto = New System.Windows.Forms.TextBox()
        Me.txtCorForn = New System.Windows.Forms.TextBox()
        Me.txtRefForn = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbForn = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.C1FgEnc = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtDtEnt = New System.Windows.Forms.TextBox()
        Me.lbPr = New System.Windows.Forms.Label()
        Me.cmdFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbIncReservas = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btUP = New System.Windows.Forms.Button()
        Me.btDown = New System.Windows.Forms.Button()
        Me.btAnular = New System.Windows.Forms.Button()
        Me.lbObsOrig = New System.Windows.Forms.Label()
        CType(Me.CFGDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEncomendas.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.C1FgEnc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CFGDet
        '
        Me.CFGDet.ColumnInfo = "10,1,0,0,0,85,Columns:0{Width:18;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.CFGDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFGDet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CFGDet.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.CFGDet.Location = New System.Drawing.Point(0, 0)
        Me.CFGDet.Margin = New System.Windows.Forms.Padding(4)
        Me.CFGDet.Name = "CFGDet"
        Me.CFGDet.Rows.DefaultSize = 17
        Me.CFGDet.Size = New System.Drawing.Size(1064, 425)
        Me.CFGDet.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("CFGDet.Styles"))
        Me.CFGDet.TabIndex = 2
        '
        'lbArtigo
        '
        Me.lbArtigo.AutoSize = True
        Me.lbArtigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbArtigo.Location = New System.Drawing.Point(21, 26)
        Me.lbArtigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbArtigo.Name = "lbArtigo"
        Me.lbArtigo.Size = New System.Drawing.Size(94, 25)
        Me.lbArtigo.TabIndex = 3
        Me.lbArtigo.Text = "ARTIGO"
        '
        'PictureBox
        '
        Me.PictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox.Location = New System.Drawing.Point(728, 54)
        Me.PictureBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(328, 246)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox.TabIndex = 25
        Me.PictureBox.TabStop = False
        '
        'gbEncomendas
        '
        Me.gbEncomendas.Controls.Add(Me.GroupBox2)
        Me.gbEncomendas.Controls.Add(Me.C1FgEnc)
        Me.gbEncomendas.Controls.Add(Me.lbArtigo)
        Me.gbEncomendas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEncomendas.Location = New System.Drawing.Point(16, 38)
        Me.gbEncomendas.Margin = New System.Windows.Forms.Padding(4)
        Me.gbEncomendas.Name = "gbEncomendas"
        Me.gbEncomendas.Padding = New System.Windows.Forms.Padding(4)
        Me.gbEncomendas.Size = New System.Drawing.Size(632, 263)
        Me.gbEncomendas.TabIndex = 26
        Me.gbEncomendas.TabStop = False
        Me.gbEncomendas.Text = "ENCOMENDA"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbVerDetalhe)
        Me.GroupBox2.Controls.Add(Me.txtObs)
        Me.GroupBox2.Controls.Add(Me.CmdConfEnc)
        Me.GroupBox2.Controls.Add(Me.txtPrCusto)
        Me.GroupBox2.Controls.Add(Me.txtCorForn)
        Me.GroupBox2.Controls.Add(Me.txtRefForn)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CbForn)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 49)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(604, 128)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'cbVerDetalhe
        '
        Me.cbVerDetalhe.AutoSize = True
        Me.cbVerDetalhe.Location = New System.Drawing.Point(495, 30)
        Me.cbVerDetalhe.Margin = New System.Windows.Forms.Padding(4)
        Me.cbVerDetalhe.Name = "cbVerDetalhe"
        Me.cbVerDetalhe.Size = New System.Drawing.Size(90, 23)
        Me.cbVerDetalhe.TabIndex = 16
        Me.cbVerDetalhe.Text = "Detalhe"
        Me.cbVerDetalhe.UseVisualStyleBackColor = True
        '
        'txtObs
        '
        Me.txtObs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(304, 79)
        Me.txtObs.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(191, 25)
        Me.txtObs.TabIndex = 4
        Me.txtObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdConfEnc
        '
        Me.CmdConfEnc.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdConfEnc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdConfEnc.Location = New System.Drawing.Point(512, 91)
        Me.CmdConfEnc.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdConfEnc.Name = "CmdConfEnc"
        Me.CmdConfEnc.Size = New System.Drawing.Size(80, 28)
        Me.CmdConfEnc.TabIndex = 14
        Me.CmdConfEnc.Text = "Gravar"
        Me.CmdConfEnc.UseVisualStyleBackColor = False
        '
        'txtPrCusto
        '
        Me.txtPrCusto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrCusto.Location = New System.Drawing.Point(211, 79)
        Me.txtPrCusto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPrCusto.Name = "txtPrCusto"
        Me.txtPrCusto.Size = New System.Drawing.Size(84, 25)
        Me.txtPrCusto.TabIndex = 3
        Me.txtPrCusto.Text = "0"
        Me.txtPrCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCorForn
        '
        Me.txtCorForn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorForn.Location = New System.Drawing.Point(115, 79)
        Me.txtCorForn.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCorForn.Name = "txtCorForn"
        Me.txtCorForn.Size = New System.Drawing.Size(84, 25)
        Me.txtCorForn.TabIndex = 2
        Me.txtCorForn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRefForn
        '
        Me.txtRefForn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefForn.Location = New System.Drawing.Point(19, 79)
        Me.txtRefForn.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRefForn.Name = "txtRefForn"
        Me.txtRefForn.Size = New System.Drawing.Size(84, 25)
        Me.txtRefForn.TabIndex = 1
        Me.txtRefForn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(304, 58)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 21)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Obs"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(211, 59)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "PrCusto"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(115, 59)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "CorForn"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "RefForn"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CbForn
        '
        Me.CbForn.AllowDrop = True
        Me.CbForn.DropDownWidth = 150
        Me.CbForn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbForn.Location = New System.Drawing.Point(124, 26)
        Me.CbForn.Margin = New System.Windows.Forms.Padding(4)
        Me.CbForn.MaxDropDownItems = 10
        Me.CbForn.Name = "CbForn"
        Me.CbForn.Size = New System.Drawing.Size(352, 25)
        Me.CbForn.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 26)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 27)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Ult.Forn. :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'C1FgEnc
        '
        Me.C1FgEnc.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FgEnc.ColumnInfo = "10,1,0,0,0,85,Columns:"
        Me.C1FgEnc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1FgEnc.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.C1FgEnc.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.C1FgEnc.Location = New System.Drawing.Point(20, 185)
        Me.C1FgEnc.Margin = New System.Windows.Forms.Padding(4)
        Me.C1FgEnc.Name = "C1FgEnc"
        Me.C1FgEnc.Rows.DefaultSize = 17
        Me.C1FgEnc.Size = New System.Drawing.Size(603, 68)
        Me.C1FgEnc.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FgEnc.Styles"))
        Me.C1FgEnc.TabIndex = 0
        '
        'txtDtEnt
        '
        Me.txtDtEnt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDtEnt.Location = New System.Drawing.Point(820, 143)
        Me.txtDtEnt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDtEnt.Name = "txtDtEnt"
        Me.txtDtEnt.Size = New System.Drawing.Size(95, 25)
        Me.txtDtEnt.TabIndex = 15
        Me.txtDtEnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDtEnt.Visible = False
        '
        'lbPr
        '
        Me.lbPr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbPr.AutoSize = True
        Me.lbPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPr.Location = New System.Drawing.Point(33, 11)
        Me.lbPr.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbPr.Name = "lbPr"
        Me.lbPr.Size = New System.Drawing.Size(52, 17)
        Me.lbPr.TabIndex = 27
        Me.lbPr.Text = "Preços"
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdFechar.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFechar.Location = New System.Drawing.Point(904, 6)
        Me.cmdFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(133, 39)
        Me.cmdFechar.TabIndex = 28
        Me.cmdFechar.Text = "Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CFGDet)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 309)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1064, 425)
        Me.Panel1.TabIndex = 100
        '
        'cbIncReservas
        '
        Me.cbIncReservas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbIncReservas.AutoSize = True
        Me.cbIncReservas.Location = New System.Drawing.Point(790, 26)
        Me.cbIncReservas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbIncReservas.Name = "cbIncReservas"
        Me.cbIncReservas.Size = New System.Drawing.Size(97, 21)
        Me.cbIncReservas.TabIndex = 38
        Me.cbIncReservas.Text = "I.Reservas"
        Me.cbIncReservas.UseVisualStyleBackColor = True
        '
        'btUP
        '
        Me.btUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btUP.Location = New System.Drawing.Point(656, 122)
        Me.btUP.Margin = New System.Windows.Forms.Padding(4)
        Me.btUP.Name = "btUP"
        Me.btUP.Size = New System.Drawing.Size(64, 28)
        Me.btUP.TabIndex = 39
        Me.btUP.Text = "Up"
        Me.btUP.UseVisualStyleBackColor = True
        '
        'btDown
        '
        Me.btDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btDown.Location = New System.Drawing.Point(656, 158)
        Me.btDown.Margin = New System.Windows.Forms.Padding(4)
        Me.btDown.Name = "btDown"
        Me.btDown.Size = New System.Drawing.Size(64, 28)
        Me.btDown.TabIndex = 39
        Me.btDown.Text = "Down"
        Me.btDown.UseVisualStyleBackColor = True
        '
        'btAnular
        '
        Me.btAnular.Location = New System.Drawing.Point(656, 206)
        Me.btAnular.Margin = New System.Windows.Forms.Padding(4)
        Me.btAnular.Name = "btAnular"
        Me.btAnular.Size = New System.Drawing.Size(64, 28)
        Me.btAnular.TabIndex = 40
        Me.btAnular.Text = "Anular"
        Me.btAnular.UseVisualStyleBackColor = True
        '
        'lbObsOrig
        '
        Me.lbObsOrig.AutoSize = True
        Me.lbObsOrig.Location = New System.Drawing.Point(479, 10)
        Me.lbObsOrig.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbObsOrig.Name = "lbObsOrig"
        Me.lbObsOrig.Size = New System.Drawing.Size(0, 17)
        Me.lbObsOrig.TabIndex = 41
        '
        'frmStockLoja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 734)
        Me.Controls.Add(Me.lbObsOrig)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtDtEnt)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.gbEncomendas)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.lbPr)
        Me.Controls.Add(Me.btUP)
        Me.Controls.Add(Me.btDown)
        Me.Controls.Add(Me.btAnular)
        Me.Controls.Add(Me.cbIncReservas)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmStockLoja"
        Me.Text = "frmStockLoja"
        CType(Me.CFGDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEncomendas.ResumeLayout(False)
        Me.gbEncomendas.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.C1FgEnc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CFGDet As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lbArtigo As System.Windows.Forms.Label
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents gbEncomendas As System.Windows.Forms.GroupBox
    Friend WithEvents CmdConfEnc As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents txtPrCusto As System.Windows.Forms.TextBox
    Friend WithEvents txtCorForn As System.Windows.Forms.TextBox
    Friend WithEvents txtRefForn As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CbForn As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents C1FgEnc As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtDtEnt As System.Windows.Forms.TextBox
    Friend WithEvents cbVerDetalhe As System.Windows.Forms.CheckBox
    Friend WithEvents lbPr As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbIncReservas As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btUP As System.Windows.Forms.Button
    Friend WithEvents btDown As System.Windows.Forms.Button
    Friend WithEvents btAnular As System.Windows.Forms.Button
    Friend WithEvents lbObsOrig As System.Windows.Forms.Label
End Class
