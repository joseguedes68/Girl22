
Imports System.Data.SqlClient
Imports System.Text
Imports C1.Win.C1TrueDBGrid


Public Class frmSepara
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodBarras As System.Windows.Forms.TextBox
    Friend WithEvents C1FGLista As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1TDBGSepDet As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtQtdSep As System.Windows.Forms.TextBox
    Friend WithEvents txtQtdLido As System.Windows.Forms.TextBox
    Friend WithEvents CmdInsSep As System.Windows.Forms.Button
    Friend WithEvents CmdExe As System.Windows.Forms.Button
    Friend WithEvents CmdNovaSep As System.Windows.Forms.Button
    Friend WithEvents CbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents C1TGSepCab As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbQtd As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmdFecharSep As System.Windows.Forms.Button
    Friend WithEvents CmdPrintSep As System.Windows.Forms.Button
    Private WithEvents C1DataView1 As C1.Data.C1DataView
    Friend WithEvents cbVerTodas As System.Windows.Forms.CheckBox
    Friend WithEvents lbDestino As System.Windows.Forms.Label
    Friend WithEvents btCancelar As System.Windows.Forms.Button
    Friend WithEvents lbNrAT As Label
    Friend WithEvents tbObs As TextBox
    Friend WithEvents lbObs As Label
    Friend WithEvents CmdApagaSep As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSepara))
        Me.CmdInsSep = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodBarras = New System.Windows.Forms.TextBox()
        Me.CmdExe = New System.Windows.Forms.Button()
        Me.C1FGLista = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1TDBGSepDet = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtQtdSep = New System.Windows.Forms.TextBox()
        Me.txtQtdLido = New System.Windows.Forms.TextBox()
        Me.CmdNovaSep = New System.Windows.Forms.Button()
        Me.CbDestino = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.C1TGSepCab = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdPrintSep = New System.Windows.Forms.Button()
        Me.CmdApagaSep = New System.Windows.Forms.Button()
        Me.CmdFecharSep = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbQtd = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tbObs = New System.Windows.Forms.TextBox()
        Me.lbObs = New System.Windows.Forms.Label()
        Me.lbNrAT = New System.Windows.Forms.Label()
        Me.lbDestino = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbVerTodas = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.C1DataView1 = New C1.Data.C1DataView()
        CType(Me.C1FGLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TDBGSepDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TGSepCab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.C1DataView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdInsSep
        '
        Me.CmdInsSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdInsSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdInsSep.Location = New System.Drawing.Point(13, 96)
        Me.CmdInsSep.Name = "CmdInsSep"
        Me.CmdInsSep.Size = New System.Drawing.Size(198, 39)
        Me.CmdInsSep.TabIndex = 3
        Me.CmdInsSep.Text = "Anexar  >>>>"
        Me.CmdInsSep.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 32)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Ler Talão"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCodBarras
        '
        Me.txtCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras.Location = New System.Drawing.Point(13, 53)
        Me.txtCodBarras.Name = "txtCodBarras"
        Me.txtCodBarras.Size = New System.Drawing.Size(198, 34)
        Me.txtCodBarras.TabIndex = 8
        Me.txtCodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdExe
        '
        Me.CmdExe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdExe.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdExe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExe.ForeColor = System.Drawing.Color.Maroon
        Me.CmdExe.Location = New System.Drawing.Point(488, 553)
        Me.CmdExe.Name = "CmdExe"
        Me.CmdExe.Size = New System.Drawing.Size(161, 38)
        Me.CmdExe.TabIndex = 15
        Me.CmdExe.Text = "Envio"
        Me.CmdExe.UseVisualStyleBackColor = False
        '
        'C1FGLista
        '
        Me.C1FGLista.AllowDelete = True
        Me.C1FGLista.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.C1FGLista.AutoResize = False
        Me.C1FGLista.BackColor = System.Drawing.SystemColors.Control
        Me.C1FGLista.ColumnInfo = resources.GetString("C1FGLista.ColumnInfo")
        Me.C1FGLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1FGLista.Location = New System.Drawing.Point(13, 182)
        Me.C1FGLista.Name = "C1FGLista"
        Me.C1FGLista.Rows.Count = 1
        Me.C1FGLista.Rows.DefaultSize = 18
        Me.C1FGLista.Size = New System.Drawing.Size(198, 242)
        Me.C1FGLista.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FGLista.Styles"))
        Me.C1FGLista.TabIndex = 17
        Me.C1FGLista.TabStop = False
        '
        'C1TDBGSepDet
        '
        Me.C1TDBGSepDet.AllowDelete = True
        Me.C1TDBGSepDet.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.C1TDBGSepDet.AlternatingRows = True
        Me.C1TDBGSepDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TDBGSepDet.BackColor = System.Drawing.SystemColors.Control
        Me.C1TDBGSepDet.CaptionHeight = 17
        Me.C1TDBGSepDet.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TDBGSepDet.Images.Add(CType(resources.GetObject("C1TDBGSepDet.Images"), System.Drawing.Image))
        Me.C1TDBGSepDet.Location = New System.Drawing.Point(7, 77)
        Me.C1TDBGSepDet.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1TDBGSepDet.Name = "C1TDBGSepDet"
        Me.C1TDBGSepDet.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TDBGSepDet.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TDBGSepDet.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TDBGSepDet.PrintInfo.PageSettings = CType(resources.GetObject("C1TDBGSepDet.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TDBGSepDet.RecordSelectorWidth = 30
        Me.C1TDBGSepDet.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TDBGSepDet.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TDBGSepDet.RowHeight = 20
        Me.C1TDBGSepDet.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TDBGSepDet.Size = New System.Drawing.Size(647, 443)
        Me.C1TDBGSepDet.TabIndex = 18
        Me.C1TDBGSepDet.Text = "C1TrueDBGrid1"
        Me.C1TDBGSepDet.PropBag = resources.GetString("C1TDBGSepDet.PropBag")
        '
        'txtQtdSep
        '
        Me.txtQtdSep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQtdSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQtdSep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQtdSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtdSep.Location = New System.Drawing.Point(358, 559)
        Me.txtQtdSep.Name = "txtQtdSep"
        Me.txtQtdSep.Size = New System.Drawing.Size(124, 27)
        Me.txtQtdSep.TabIndex = 20
        '
        'txtQtdLido
        '
        Me.txtQtdLido.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQtdLido.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQtdLido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtdLido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQtdLido.Location = New System.Drawing.Point(74, 142)
        Me.txtQtdLido.Name = "txtQtdLido"
        Me.txtQtdLido.Size = New System.Drawing.Size(93, 27)
        Me.txtQtdLido.TabIndex = 21
        '
        'CmdNovaSep
        '
        Me.CmdNovaSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdNovaSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNovaSep.Location = New System.Drawing.Point(12, 55)
        Me.CmdNovaSep.Name = "CmdNovaSep"
        Me.CmdNovaSep.Size = New System.Drawing.Size(71, 33)
        Me.CmdNovaSep.TabIndex = 7
        Me.CmdNovaSep.Text = "Nova"
        Me.CmdNovaSep.UseVisualStyleBackColor = False
        '
        'CbDestino
        '
        Me.CbDestino.AllowDrop = True
        Me.CbDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbDestino.DropDownWidth = 150
        Me.CbDestino.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbDestino.Location = New System.Drawing.Point(118, 14)
        Me.CbDestino.MaxDropDownItems = 10
        Me.CbDestino.Name = "CbDestino"
        Me.CbDestino.Size = New System.Drawing.Size(296, 35)
        Me.CbDestino.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 30)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Destino :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1TGSepCab
        '
        Me.C1TGSepCab.AllowDelete = True
        Me.C1TGSepCab.AlternatingRows = True
        Me.C1TGSepCab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TGSepCab.BackColor = System.Drawing.SystemColors.Control
        Me.C1TGSepCab.CaptionHeight = 17
        Me.C1TGSepCab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1TGSepCab.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TGSepCab.Images.Add(CType(resources.GetObject("C1TGSepCab.Images"), System.Drawing.Image))
        Me.C1TGSepCab.Location = New System.Drawing.Point(12, 45)
        Me.C1TGSepCab.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1TGSepCab.Name = "C1TGSepCab"
        Me.C1TGSepCab.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TGSepCab.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TGSepCab.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TGSepCab.PrintInfo.PageSettings = CType(resources.GetObject("C1TGSepCab.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TGSepCab.RecordSelectorWidth = 30
        Me.C1TGSepCab.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TGSepCab.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TGSepCab.RowHeight = 15
        Me.C1TGSepCab.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TGSepCab.Size = New System.Drawing.Size(406, 440)
        Me.C1TGSepCab.TabIndex = 16
        Me.C1TGSepCab.Text = "C1TrueDBGrid1"
        Me.C1TGSepCab.PropBag = resources.GetString("C1TGSepCab.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CbDestino)
        Me.GroupBox1.Controls.Add(Me.CmdPrintSep)
        Me.GroupBox1.Controls.Add(Me.CmdApagaSep)
        Me.GroupBox1.Controls.Add(Me.CmdNovaSep)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(431, 100)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'CmdPrintSep
        '
        Me.CmdPrintSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdPrintSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrintSep.Location = New System.Drawing.Point(336, 55)
        Me.CmdPrintSep.Name = "CmdPrintSep"
        Me.CmdPrintSep.Size = New System.Drawing.Size(78, 33)
        Me.CmdPrintSep.TabIndex = 7
        Me.CmdPrintSep.Text = "Print"
        Me.CmdPrintSep.UseVisualStyleBackColor = False
        '
        'CmdApagaSep
        '
        Me.CmdApagaSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdApagaSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdApagaSep.Location = New System.Drawing.Point(90, 55)
        Me.CmdApagaSep.Name = "CmdApagaSep"
        Me.CmdApagaSep.Size = New System.Drawing.Size(85, 33)
        Me.CmdApagaSep.TabIndex = 7
        Me.CmdApagaSep.Text = "Apagar"
        Me.CmdApagaSep.UseVisualStyleBackColor = False
        '
        'CmdFecharSep
        '
        Me.CmdFecharSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CmdFecharSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFecharSep.Location = New System.Drawing.Point(413, 16)
        Me.CmdFecharSep.Name = "CmdFecharSep"
        Me.CmdFecharSep.Size = New System.Drawing.Size(116, 35)
        Me.CmdFecharSep.TabIndex = 7
        Me.CmdFecharSep.Text = "Fechar"
        Me.CmdFecharSep.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.btCancelar)
        Me.GroupBox2.Controls.Add(Me.txtQtdLido)
        Me.GroupBox2.Controls.Add(Me.C1FGLista)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.CmdInsSep)
        Me.GroupBox2.Controls.Add(Me.txtCodBarras)
        Me.GroupBox2.Location = New System.Drawing.Point(452, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(219, 492)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        '
        'btCancelar
        '
        Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancelar.Location = New System.Drawing.Point(13, 450)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(154, 39)
        Me.btCancelar.TabIndex = 22
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 36)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Qtd:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbQtd
        '
        Me.lbQtd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbQtd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtd.Location = New System.Drawing.Point(295, 556)
        Me.lbQtd.Name = "lbQtd"
        Me.lbQtd.Size = New System.Drawing.Size(57, 33)
        Me.lbQtd.TabIndex = 9
        Me.lbQtd.Text = "Qtd:"
        Me.lbQtd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.tbObs)
        Me.GroupBox3.Controls.Add(Me.lbObs)
        Me.GroupBox3.Controls.Add(Me.lbNrAT)
        Me.GroupBox3.Controls.Add(Me.lbDestino)
        Me.GroupBox3.Controls.Add(Me.lbQtd)
        Me.GroupBox3.Controls.Add(Me.txtQtdSep)
        Me.GroupBox3.Controls.Add(Me.CmdFecharSep)
        Me.GroupBox3.Controls.Add(Me.C1TDBGSepDet)
        Me.GroupBox3.Controls.Add(Me.CmdExe)
        Me.GroupBox3.Location = New System.Drawing.Point(678, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(661, 599)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        '
        'tbObs
        '
        Me.tbObs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.Location = New System.Drawing.Point(7, 527)
        Me.tbObs.Name = "tbObs"
        Me.tbObs.Size = New System.Drawing.Size(277, 27)
        Me.tbObs.TabIndex = 31
        '
        'lbObs
        '
        Me.lbObs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbObs.AutoSize = True
        Me.lbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbObs.Location = New System.Drawing.Point(171, 569)
        Me.lbObs.Name = "lbObs"
        Me.lbObs.Size = New System.Drawing.Size(52, 18)
        Me.lbObs.TabIndex = 30
        Me.lbObs.Text = "lbObs"
        '
        'lbNrAT
        '
        Me.lbNrAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNrAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNrAT.Location = New System.Drawing.Point(380, 523)
        Me.lbNrAT.Name = "lbNrAT"
        Me.lbNrAT.Size = New System.Drawing.Size(254, 25)
        Me.lbNrAT.TabIndex = 29
        Me.lbNrAT.Text = "NºAT: "
        Me.lbNrAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbDestino
        '
        Me.lbDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDestino.AutoSize = True
        Me.lbDestino.Font = New System.Drawing.Font("Arial Black", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDestino.Location = New System.Drawing.Point(70, 22)
        Me.lbDestino.Name = "lbDestino"
        Me.lbDestino.Size = New System.Drawing.Size(162, 48)
        Me.lbDestino.TabIndex = 28
        Me.lbDestino.Text = "Destino"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.cbVerTodas)
        Me.GroupBox4.Controls.Add(Me.C1TGSepCab)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 110)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(431, 492)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        '
        'cbVerTodas
        '
        Me.cbVerTodas.AutoSize = True
        Me.cbVerTodas.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbVerTodas.Location = New System.Drawing.Point(265, 14)
        Me.cbVerTodas.Name = "cbVerTodas"
        Me.cbVerTodas.Size = New System.Drawing.Size(153, 31)
        Me.cbVerTodas.TabIndex = 17
        Me.cbVerTodas.Text = "Ver Todas"
        Me.cbVerTodas.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(310, 30)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Lista de Separações "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1DataView1
        '
        Me.C1DataView1.BindingContextCtrl = Me
        Me.C1DataView1.DataSet = Nothing
        Me.C1DataView1.TableName = ""
        Me.C1DataView1.TableViewName = ""
        '
        'frmSepara
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1347, 623)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSepara"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSepara"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.C1FGLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TDBGSepDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TGSepCab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.C1DataView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dtCab As New DataTable
    Dim dtDestinos As New DataTable
    Dim dtAux As New DataTable

    Dim dtDet As New DataTable
    Dim xPrecoEtiqueta As Boolean
    Dim xNovoDoc As String


    Dim sAddressDetailCarga As String
    Dim sCityCarga As String
    Dim sPostalCodeCarga As String
    Dim sAddressDetailDescarga As String
    Dim sCityDescarga As String
    Dim sPostalCodeDescarga As String
    Dim xNumDocSep As String
    Dim sTercID As String
    Dim sArmzDestino As String
    'Dim sApagaTalaoAux As String
    Dim sObs As String
    Dim sIdDocCab As String
    Dim sIdDocDet As String
    Dim sIdDocCabSep As String
    Dim sIdDocCabSepAux As String
    Dim sNrAT As String
    Dim sIdTerceiro As String




    Public Sub frmSepara_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim db As New ClsSqlBDados

        Try


            ActualizaCabeçalho()

            If bLojaConsignacao = True Then

                Sql = "SELECT Armazens.ArmazemID, RTRIM(Armazens.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) AS Destino, Terceiros.TipoTerc
                FROM     Armazens INNER JOIN
                Terceiros ON Armazens.TercID = Terceiros.TercID
                WHERE  (Armazens.ArmazemID = '0000') AND (Armazens.Activo = '1') AND (Terceiros.TipoTerc <> 'C')"


            ElseIf xArmz = "0000" Then
                Sql = "SELECT ArmazemID, RTRIM(ArmazemID) + ' - ' + RTRIM(ArmAbrev) AS Destino FROM Armazens WHERE ACTIVO='1' ORDER BY ArmAbrev"
            Else
                'Sql = "SELECT ArmazemID, RTRIM(ArmazemID) + ' - ' + RTRIM(ArmAbrev) AS Destino FROM Armazens WHERE ACTIVO='1' And ArmazemID<'0100' ORDER BY ArmAbrev"
                Sql = "SELECT Armazens.ArmazemID, RTRIM(Armazens.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) AS Destino
                    FROM     Armazens INNER JOIN
                    Terceiros ON Armazens.TercID = Terceiros.TercID
                    WHERE  (Armazens.Activo = '1') AND (Armazens.ArmazemID < '0100') AND (Terceiros.TipoTerc = 'I' or Terceiros.TercID='2000')
                    ORDER BY Armazens.ArmAbrev"
            End If


            If bAtrai = True Then
                Sql = "SELECT ArmazemID, RTRIM(ArmazemID) + ' - ' + RTRIM(ArmAbrev) AS Destino FROM Armazens WHERE ACTIVO='1' and armazemid<>'0100' ORDER BY ArmAbrev"
            End If

            db.GetData(Sql, dtDestinos)



            Me.CbDestino.DataSource = dtDestinos
            Me.CbDestino.DisplayMember = "Destino"
            Me.CbDestino.ValueMember = "ArmazemID"
            Me.CbDestino.Text = Nothing


            If bLojaConsignacao = True Then
                Me.CbDestino.SelectedValue = "0000"
                Me.CbDestino.Enabled = False
            End If


            'Inicializar C1FGLista
            With dtAux.Columns
                .Add("SerieID", GetType(String)).Unique = True
                .Add("ModeloID", GetType(String))
                .Add("CorID", GetType(String))
                .Add("TamID", GetType(String))
                .Add("ModCorDescr", GetType(String))
                .Add("UnidDescr", GetType(String))
                .Add("PrecoVenda", GetType(String))
                .Add("Comissao", GetType(String))
                .Add("ProductCode", GetType(String))

            End With


            With Me.C1FGLista

                .DataSource = dtAux
                .Cols("SerieID").Caption = "Talão"
                .Cols("ModeloID").Caption = "Modelo"
                .Cols("CorID").Caption = "Cor"
                .Cols("TamID").Caption = "Tam"
                .Cols("ProductCode").Caption = "Artigo"
                .Cols("ModeloID").Visible = False
                .Cols("CorID").Visible = False
                .Cols("TamID").Visible = False
                .Cols("ModCorDescr").Visible = False
                .Cols("UnidDescr").Visible = False
                .Cols("PrecoVenda").Visible = False
                .Cols("Comissao").Visible = False

            End With


            WindowState = FormWindowState.Maximized
            'Me.txtQtdLido.Enabled = False
            'Me.txtQtdSep.Enabled = False

            Me.lbDestino.DataBindings.Add("Text", dtCab, "ArmAbrev")




            Cursor = Cursors.Default

            'Select Case xAplicacao
            '    Case "POS"
            '        cbVerTodas.Visible = False
            '    Case "BACKOFFICE"
            '        cbVerTodas.Visible = True
            'End Select

            If xGrupoAcesso = "ADMIN" Then
                cbVerTodas.Visible = True
                CmdApagaSep.Visible = True
            Else
                cbVerTodas.Visible = False
                CmdApagaSep.Visible = False
            End If

            If bLojaConsignacao = True Then
                cbVerTodas.Visible = True
                CmdExe.Visible = False
            End If

            CmdExe.Enabled = True


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmSepara_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmSepara_Load")
        End Try


    End Sub

    Private Sub CmdNovaSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNovaSep.Click

        Try

            Dim db As New ClsSqlBDados

            If SistemaBloqueado() = True Then
                Exit Sub
            End If


            If bLojaConsignacao = True And dtCab.Rows.Count > 0 Then
                MsgBox("Só pode ter uma separação em aberto!", MsgBoxStyle.Information, "Girl")
                Exit Sub
            End If



            If Not Me.CbDestino.SelectedValue Is DBNull.Value Then
                If Me.CbDestino.SelectedValue <> "" Then

                    Dim xNovaSep As String = PesquisaMaxNumDoc("SE")
                    Dim xData As String = Format(CType(Now(), Date), "yyyy-MM-dd H:mm:ss")
                    Dim xDestino As String = Me.CbDestino.SelectedValue

                    Sql = "SELECT COUNT(*) FROM Armazens INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (Armazens.ArmazemID = '" & xDestino & "')"
                    If db.GetDataValue(Sql) = 0 Then
                        MsgBox("Falta o Terceiro Correspondente ao Armazem Destino")
                        Exit Sub
                    End If

                    Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, UtilizadorID, OperadorID) " &
                        "VALUES('" & xEmp & "','" & xArmz & "','SE','" & xNovaSep & "','" & xDestino & "','" & xData & "','C','" & iUtilizadorID & "','" & xUtilizador & "')"
                    db.ExecuteData(Sql)

                    ActualizaCabeçalho()
                    If xAplicacao <> "POS" Then
                        Me.CbDestino.Text = Nothing
                        Me.CbDestino.Text = Nothing
                    End If
                    Me.txtCodBarras.Focus()
                Else
                    MsgBox("Seleccione um Destino!")
                    Exit Sub
                End If
            Else
                MsgBox("Seleccione um Destino!")
                Exit Sub
            End If

            AtualizaDetalhe()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CmdNovo_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "CmdNovo_Click")
        Finally
        End Try
    End Sub

    Private Sub GroupBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.Leave
        If Me.C1FGLista.Rows.Count - 1 > 0 Then
            If MsgBox("Tem Registos pendentes. Confirma Saida?", MsgBoxStyle.YesNo, "Confirmação Saida") = MsgBoxResult.No Then
                Me.txtCodBarras.Focus()
                Me.txtCodBarras.SelectAll()
                Me.BringToFront()
            Else
                Me.txtCodBarras.Text = Nothing
                dtAux.Clear()
            End If
        End If
    End Sub


    'EVENTOS NA txtCodBarras

    Private Sub txtCodBarras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBarras.KeyPress

        Dim nLinhas As Integer
        Dim db As New ClsSqlBDados
        Dim xPrecoVenda As Double
        Dim xComissao As Double
        Dim xModelo As String



        Try

            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True


                If Me.txtCodBarras.Text.Length = 8 Then

                    'VERIFICAR COMISSÕES
                    Sql = "SELECT DISTINCT ModeloID from serie where SerieID='" & Me.txtCodBarras.Text & "'"
                    xModelo = db.GetDataValue(Sql)



                    If Len(xModelo) = 0 Then
                        MsgBox("Erro no Talão!")
                        Exit Sub
                    End If

                    sArmzDestino = Me.C1TGSepCab(Me.C1TGSepCab.Row, "TercID")

                    xPrecoVenda = DevolvePv(sArmzDestino, Me.txtCodBarras.Text)
                    xComissao = DevolveComissao(sArmzDestino, xModelo)

                    If xComissao <= 0 Then
                        MsgBox("Falta atribuir comissão!!")
                        Exit Sub
                    End If


                    'VERIFICAR REPETIDOS NA GRID DE LANÇAMENTO
                    If VerificarRepetidos() Then
                        TalaoInvalido()
                    Else

                        Dim xTalao As String = Me.txtCodBarras.Text
                        'VERIFICAR SE JÁ ESTÁ SEPARADO PARA ALGUMA CASA
                        Sql = "SELECT COUNT(*) FROM  DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE DocDet.TipoDocID = 'SE' AND DocDet.SerieID = '" & xTalao & "' AND DocDet.EstadoLn = 'G'"

                        If db.GetDataValue(Sql) > 0 Then
                            Dim xArmzDest As String = Me.C1TGSepCab(Me.C1TGSepCab.Row, "TercID")
                            'Sql = "SELECT COUNT(*) AS Expr1 FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.TipoDocID = 'SE') AND (DocDet.SerieID = '" & xTalao & "') AND (DocDet.EstadoLn = 'G') AND (DocCAB.EstadoDoc = 'C') AND DocCab.TercID = '" & xArmzDest & "'"
                            Sql = "SELECT COUNT(*) AS Expr1 FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.TipoDocID = 'SE') AND (DocDet.SerieID = '" & xTalao & "') AND (DocDet.EstadoLn = 'G') AND (DocCab.EstadoDoc = 'C') AND (DocCab.TercID = '" & xArmzDest & "' AND DocCab.TercID <> DocCab.ArmazemID)"
                            If db.GetDataValue(Sql) > 0 Then
                                'LIMPAR DA ORIGEM - SE A SEPARAÇÃO ESTÁ PARA A MESMA CASA PERMITE MUDAR...
                                Sql = "DELETE FROM DocDet FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.TipoDocID = 'SE') AND (DocDet.SerieID = '" & xTalao & "') AND (DocDet.EstadoLn = 'G') AND (DocCAB.EstadoDoc = 'C') AND (DocCab.TercID = '" & xArmzDest & "') AND (DocCab.EmpresaID = '" & xEmp & "')"
                                db.ExecuteData(Sql)
                                GoTo Continua
                            Else
                                'TALÃO JÁ ESTÁ SEPARADO PARA OUTRA LOJA!! PODIA FAZER AQUI UM SELECT PARA SABER QUAL É A CASA........
                                TalaoInvalido()
                            End If
                        Else
Continua:

                            'VERIFICAR SE O TALÃO ESTÁ EM STOCK NO RESPECTIVO ARMAZEM
                            'Sql = "SELECT SerieID, ModeloID, CorID, TamID FROM Serie WHERE SerieID='" & xTalao & "' AND EstadoID = 'S' AND ArmazemID = '" & xArmz & "'"
                            Sql = "SELECT Serie.SerieID, Serie.ModeloID, Serie.CorID, Serie.TamID, ModeloCor.ModCorDescr, Unidades.UnidDescr, Serie.PrecoVenda, Serie.Comissao, Serie.ProductCode FROM Serie INNER JOIN ModeloCor ON Serie.ModeloID = ModeloCor.ModeloID AND Serie.CorID = ModeloCor.CorID INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID INNER JOIN Unidades ON Modelos.UnidID = Unidades.UnidID WHERE (Serie.SerieID = '" & xTalao & "') AND (Serie.EstadoID = 'S') AND (Serie.ArmazemID = '" & xArmz & "')"
                            If cn.State = ConnectionState.Closed Then cn.Open()
                            da = New SqlDataAdapter(Sql, cn)
                            nLinhas = Me.dtAux.Rows.Count
                            da.Fill(dtAux)
                            If Me.dtAux.Rows.Count = nLinhas Then
                                TalaoInvalido()
                            End If
                        End If
                        Me.txtQtdLido.Text = dtAux.Rows.Count
                        Me.C1FGLista.AutoSizeCols()
                        Me.txtCodBarras.Focus()

                    End If
                    Me.txtCodBarras.SelectAll()
                End If
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "txtCodBarras_KeyPress")
        Catch ex As Exception
            ErroVB(ex.Message, "txtCodBarras_KeyPress")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing

            cn.Close()
            Sql = Nothing
        End Try
    End Sub

    Private Sub CmdInsSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdInsSep.Click
        Dim db As New ClsSqlBDados

        Try

            'ACRESCENTAR LINHAS À SEPARAÇÃO - NOTA : A LINHA LEVA JÁ O ESTADO G - (COM GUIA) 
            Dim xNumDoc As String = Me.C1TGSepCab(Me.C1TGSepCab.Bookmark, "DocNr")
            Dim sIdDocCab As String = Me.C1TGSepCab(Me.C1TGSepCab.Bookmark, "IdDocCab").ToString
            Dim xDocLnNr As String
            Dim xSerie As String
            Dim xModelo As String
            Dim xCor As String
            Dim xTam As String
            Dim xDescricao As String
            Dim xUnidade As String

            'Dim xPrecoVenda As Double
            'Dim xComissao As Double
            Dim xArmzDest As String = Me.C1TGSepCab(Me.C1TGSepCab.Row, "TercID")  'Me.CbDestino.SelectedValue
            dtAux.AcceptChanges()
            If dtAux.Rows.Count > 0 Then

                Sql = "SELECT ISNULL(MAX(DocLnNr),0)+1 FROM DocDet WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'SE' AND DocNr = '" & xNumDoc & "'"
                xDocLnNr = db.GetDataValue(Sql) ' VAI BUSCAR O NUMERO DA LINHA DA TABELA DOCDET
                If CInt(xDocLnNr) >= 1 Then
                    For Each r As DataRow In dtAux.Rows
                        xSerie = r("SerieID")
                        xModelo = r("ModeloID")
                        xCor = r("CorID")
                        xTam = r("TamID")
                        xDescricao = r("ModCorDescr")
                        xUnidade = r("UnidDescr")


                        If xArmz = xArmzDest Then
                            Sql = "UPDATE Serie SET EstadoID = 'V', PVndReal = PrecoVenda, OperadorID = 'SEP', Vendedor = '" & iUtilizadorID & "' , DtSaida = CONVERT(datetime, '" & Now & "', 105) WHERE SerieID = '" & xSerie & "'"
                            db.ExecuteData(Sql)
                        End If


                        'TESTAR ESTE INSERT - ACRESCENTEI O PRECO VENDA E A COMISSAO PARA JÁ A COMISSÃO PASSA ZERO

                        'ESTE UPDATE É PARA PERMITIR UMA CONSULTA DIRECTA DOS DEFEITOS NA TABELA SERIE!!!!
                        Sql = "UPDATE Serie SET DocNr = '" & xNumDoc & "', DtSaida = GETDATE() WHERE SerieID = '" & xSerie & "'"
                        db.ExecuteData(Sql)

                        Dim dPv As Double = r("PrecoVenda")
                        Sql = "SELECT COUNT(*) AS EXISTE FROM Modelos INNER JOIN Serie ON Modelos.ModeloID = Serie.ModeloID WHERE (Modelos.GrupoID IN ('6', '4')) AND (Serie.SerieID = '" & xSerie & "') AND (Serie.PrecoEtiqueta = Serie.PrecoVenda) AND (Serie.ArmazemID = '0009')"

                        'VOU FORÇAR A COMISSÃO DE 20% NAS VENDAS COM DEFEITO!!
                        If db.GetDataValue(Sql) > 0 Then
                            'dPv = dPv * 0.999999
                        End If

                        Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Qtd, EstadoLn, Descricao, Valor, Comissao, DtRegisto, Unidade, IdDocCab, ProductCode, OperadorID) " &
                            "VALUES ('" & xEmp & "', '" & xArmz & "', 'SE', '" & xNumDoc & "', " & xDocLnNr & ", '" & xSerie & "', '" & xModelo & "', '" & xCor & "', " & xTam & ", 1, 'G','" & xDescricao & "','" & dPv & "','" & r("Comissao") & "', GETDATE(),  '" & xUnidade & "','" & sIdDocCab & "','" & r("ProductCode") & "', '" & xUtilizador & "')"
                        db.ExecuteData(Sql)
                        xDocLnNr += 1

                    Next
                End If

                Me.txtQtdLido.Text = Nothing
                dtAux.Clear()
                AtualizaDetalhe()
                Me.txtCodBarras.Text = Nothing
                Me.txtCodBarras.Focus()
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, " CmdInsSep_Click")
        Catch ex As Exception
            ErroVB(ex.Message, " CmdInsSep_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Private Sub CmdFecharSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFecharSep.Click
        Close()
    End Sub

    Private Sub CmdPrintSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintSep.Click
        Dim xNumDoc As String = Me.C1TGSepCab(Me.C1TGSepCab.Row, "DocNr")
        ListaSeparacao(xNumDoc, xArmz)
    End Sub

    Private Sub CmdApagaSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdApagaSep.Click
        'NOTA EM VEZ DE APAGAR VAI PASSAR PARA ESTADO F
        Dim db As New ClsSqlBDados

        Try
            Dim xNumDoc As String = Me.C1TGSepCab(Me.C1TGSepCab.Bookmark, "DocNr")
            Sql = "SELECT COUNT(*) FROM docdet WHERE docdet.EmpresaID = '" & xEmp & "' AND docdet.ArmazemID = '" & xArmz & "' AND docdet.TipoDocID = 'SE' AND docdet.DocNr = '" & xNumDoc & "'"
            If db.GetDataValue(Sql) = 0 Then
                Sql = "UPDATE DocCab SET EstadoDoc = 'F' WHERE (TipoDocID = 'SE') AND (EstadoDoc = 'C') AND (DocNr = N'" & xNumDoc & "') AND (ArmazemID = '" & xArmz & "')"
                db.ExecuteData(Sql)
                ActualizaCabeçalho()
                Application.DoEvents()
            Else
                MsgBox("SÓ PODE APAGAR SEPARAÇÕES VAZIAS")
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CmdApagaSep_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "CmdApagaSep_Click")
        End Try
    End Sub

    Private Sub cbVerTodas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodas.CheckedChanged
        ActualizaCabeçalho()
    End Sub

    Private Sub CmdExe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExe.Click

        Dim xNifDestino As String = "NIF_DEST"
        Dim xNifOrigem As String = "NIF_ORIG"
        Dim xArmzAux As String = ""
        Dim xLocalOrigem As String = ""


        Dim db As New ClsSqlBDados

        Try

            If SistemaBloqueado() = True Then
                Exit Sub
            End If

            'validar se a separação já foi enviada

            If Trim(Me.C1TGSepCab(Me.C1TGSepCab.Row, "EstadoDoc")) <> "C" Then
                MsgBox("Envio já executado!")
                Exit Sub
            End If

            If dtDet.Rows.Count > 0 Then
                'If MsgBox("Confirma o Envio para " & lbDestino.Text & " ?", MsgBoxStyle.YesNo, "Confirmação Envio") = MsgBoxResult.Yes Then
                sObs = InputBox("Confirma o Envio para " & lbDestino.Text & " ?                                                                                   " & Chr(13) & Chr(13) & Chr(13) & "Insira Observações!", Application.ProductName, " ")

                If sObs <> "" Then

                    xNumDocSep = Me.C1TGSepCab(Me.C1TGSepCab.Row, "DocNr")
                    sArmzDestino = Me.C1TGSepCab(Me.C1TGSepCab.Row, "TercID")
                    sIdDocCabSepAux = Me.C1TGSepCab(Me.C1TGSepCab.Row, "IdDocCab").ToString

                    If xArmz = sArmzDestino Then
                        'ENVIO PARA A PRÓPRIA CASA. DEFEITOS....
                        Sql = "Update DocCab SET EstadoDoc = 'D', Obs1='" & sObs & "', DataDoc = '" & Format(Now(), "yyyy-MM-dd H:mm:ss") & "' WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID='SE' AND DocNR = '" & xNumDocSep & "' AND EstadoDoc = 'C'"
                        db.ExecuteData(Sql)
                        For Each r As DataRow In dtDet.Rows
                            'ACTUALIZA ESTADO DO TALÃO NA TABELA SERIE - PARA JÁ VOU DEIXAR, MAS PODIA APAGAR AQUI. VOU APAGAR NA IMP.
                            Sql = "UPDATE Serie SET EstadoID = 'F' WHERE SerieID = '" & r("SerieID") & "' AND EstadoID = 'V' AND ArmazemID = '" & xArmz & "'"
                            db.ExecuteData(Sql)
                            Sql = "UPDATE DocDet SET EstadoLn = 'R' WHERE (IdDocCab = '" & Me.C1TGSepCab(Me.C1TGSepCab.Row, "IdDocCab").ToString & "') AND (SerieID = '" & r("SerieID") & "') AND (EstadoLn = 'G')"
                            db.ExecuteData(Sql)
                        Next
                        ActualizaCabeçalho()
                        Exit Sub
                    End If

                    For Each r As DataRow In dtDet.Rows
                        'ACTUALIZA ESTADO DO TALÃO NA TABELA SERIE
                        Sql = "UPDATE Serie SET EstadoID = 'T' WHERE SerieID = '" & r("SerieID") & "' AND EstadoID = 'S' AND ArmazemID = '" & xArmz & "'"
                        db.ExecuteData(Sql)
                    Next

                    Sql = "Update DocCab SET EstadoDoc = 'G',DataDoc = '" & Format(Now(), "yyyy-MM-dd H:mm:ss") & "' WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID='SE' AND DocNR = '" & xNumDocSep & "' AND EstadoDoc = 'C'"
                    db.ExecuteData(Sql)

                    ActualizaCabeçalho()
                    Application.DoEvents()
                    bTriplicado = False

                    If xArmz <> "0000" And xArmz <> sArmzDestino And bLojaConsignacao = False Then
                        If MsgBox("Quer Imprimir a Guia de Transporte?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            If GravarDocumento("GT") Then
                                'SÓ SAI ORIGINAL A PEDIDO DO FERNANDO EM 15-05-2014
                                ListaDocEmpresa(xNovoDoc, "GT", "Original", True)
                                'ListaDocEmpresa(xNovoDoc, xTipoDoc, "Duplicado", True)
                            Else
                                Sql = "DELETE FROM DOCCAB WHERE IdDocCab='" & sIdDocCab.ToString & "'"
                                db.ExecuteData(Sql)
                                MsgBox("ERRO NA CRIAÇÃO DA GUIA DE TRANSPORTE!")
                            End If
                        End If


                    ElseIf xArmz <> "0000" And xArmz <> sArmzDestino And bLojaConsignacao = True Then

                        'comentei isto, não sei o que estava aqui a fazer.......
                        'If Not GravarDocumento("GT") Then
                        '    Sql = "DELETE FROM DOCCAB WHERE IdDocCab='" & sIdDocCab.ToString & "'"
                        '    db.ExecuteData(Sql)
                        '    MsgBox("ERRO NA CRIAÇÃO DA GUIA DE TRANSPORTE!")
                        'Else
                        '    Exit Sub
                        'End If


                    End If

                    'vou emitir uma fatura de consignação:
                    If xArmz = "0000" And ArmazemConsignacao(sArmzDestino) = True Then
                        MsgBox("Vai imprimir a Fatura de Consignação!!", MsgBoxStyle.Information)
                        If GravarDocumento("FC") Then
                            ListaDocEmpresa(xNovoDoc, "FC", "Original", True)
                            If bDesenvolvimento = False Then
                                ListaDocEmpresa(xNovoDoc, "FC", "Duplicado", True)
                                ListaDocEmpresa(xNovoDoc, "FC", "Triplicado", True)
                            End If
                        Else
                            Sql = "DELETE FROM DOCCAB WHERE IdDocCab='" & sIdDocCab.ToString & "'"
                            db.ExecuteData(Sql)
                            MsgBox("ERRO NA CRIAÇÃO DA GUIA DE TRANSPORTE!")
                        End If
                    End If
                End If
            End If


            If dtCab.Rows.Count = 0 Then
                C1TDBGSepDet.Visible = False
                CmdExe.Enabled = False
                lbNrAT.Visible = False
                lbQtd.Visible = False
            Else
                AtualizaDetalhe()
                Me.txtCodBarras.Focus()
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CmdExe_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "CmdExe_Click")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub frmSepara_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.C1FGLista.Rows.Count - 1 > 0 Then
            If MsgBox("Tem Registos pendentes. Confirma Fecho?", MsgBoxStyle.YesNo, "Confirmação Fecho") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                Me.txtCodBarras.Text = Nothing
                dtAux.Clear()
            End If
        End If
    End Sub

    Private Sub txtQtdSep_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtQtdSep.MouseClick

        Dim db As New ClsSqlBDados
        Dim dtSeparados As New DataTable
        Dim sMsg As String = ""
        Dim xDocNr As String


        Try

            xDocNr = Me.C1TGSepCab(Me.C1TGSepCab.Bookmark, "DocNr")

            '            Sql = "SELECT Grupos.GrupoDesc AS Grupo, COUNT(DocDet.SerieID) AS Qtd 
            'FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID 
            'AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr 
            'INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID 
            'INNER JOIN Grupos ON Modelos.GrupoID = Grupos.GrupoID 
            'WHERE (DocCab.DocNr = N'" & xDocNr & "') AND (DocCab.EmpresaID = '" & xEmp & "') 
            'AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = 'SE') 
            'GROUP BY Grupos.GrupoDesc, Grupos.GrupoID HAVING (COUNT(DocDet.SerieID) > 0) 
            'ORDER BY Grupos.GrupoID"


            Sql = "SELECT Grupos.GrupoDesc AS Grupo, COUNT(DocDet.SerieID) AS Qtd, DocCab.Obs1
                FROM     DocCab INNER JOIN
                DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
                Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN
                Grupos ON Modelos.GrupoID = Grupos.GrupoID
                WHERE  (DocCab.DocNr = N'" & xDocNr & "') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = 'SE')
                GROUP BY Grupos.GrupoDesc, Grupos.GrupoID, DocCab.Obs1
                HAVING (COUNT(DocDet.SerieID) > 0)
                ORDER BY Grupos.GrupoID"
            db.GetData(Sql, dtSeparados)

            If dtSeparados.Rows.Count = 0 Then Exit Sub

            Dim obs As String = ""

            For Each r As DataRow In dtSeparados.Rows
                sMsg = sMsg & r("Grupo") & "  - " & r("Qtd") & Chr(13)
                obs = r("Obs1")
            Next

            sArmzDestino = Me.C1TGSepCab(Me.C1TGSepCab.Row, "TercID")
            If xArmz = sArmzDestino And xGrupoAcesso = "ADMIN" Then
                Sql = "SELECT SUM(Serie.PrecoVenda) AS Valor FROM DocDet INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID WHERE (DocDet.DocNr = N'" & xDocNr & "') AND (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmz & "') AND (DocDet.TipoDocID = 'SE')"
                sMsg = sMsg & "TOTAL : " & FormatCurrency(db.GetDataValue(Sql))
                sMsg = sMsg & vbCrLf & "Obs: " & obs
            End If
            MsgBox(sMsg, , "Resumo")

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "txtQtdSep_MouseClick")
        Catch ex As Exception
            ErroVB(ex.Message, "txtQtdSep_MouseClick")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    'EVENTOS NA tbObs

    Private Sub tbObs_Validated(sender As Object, e As EventArgs) Handles tbObs.Validated
        Try

            Dim db As New ClsSqlBDados

            Sql = "UPDATE DocCab SET  Obs = N'" & tbObs.Text & "' WHERE  (IdDocCab LIKE '" & sIdDocCabSep & "')"
            db.ExecuteData(Sql)

        Catch ex As Exception

        End Try
    End Sub


    'EVENTOS NA C1TGSepCab

    Private Sub C1TGSepCab_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles C1TGSepCab.BeforeDelete
        'TODO: LIMPAR ISTO. NÃO FAZ NADA
        Dim db As New ClsSqlBDados

        Try
            'função para apagar uma separação
            Dim xNumDoc As String = Me.C1TGSepCab(Me.C1TGSepCab.Row, "DocNr")

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TGSepCab_BeforeDelete")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TGSepCab_BeforeDelete")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub C1TGSepCab_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles C1TGSepCab.RowColChange
        Try

            If dtCab.Rows.Count = 0 Then
                C1TDBGSepDet.Visible = False
                CmdExe.Enabled = False
                Exit Sub
            Else
                AtualizaDetalhe()
                Me.txtCodBarras.Focus()
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TGSepCab_RowColChange")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TGSepCab_RowColChange")
        Finally
        End Try


    End Sub


    'EVENTOS NA C1TDBGSepDet

    Private Sub C1TDBGSepDet_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles C1TDBGSepDet.BeforeDelete
        Dim db As New ClsSqlBDados

        Dim xArmzDest As String = Me.C1TGSepCab(Me.C1TGSepCab.Row, "TercID")


        Try

            If xGrupoAcesso <> "ADMIN" And xArmzDest = xArmz Then
                e.Cancel = True
                Exit Sub
            End If


            Dim xNumDoc As String = Me.C1TDBGSepDet(Me.C1TDBGSepDet.Row, "DocNr")
            Dim xDocLnNr As Integer = Me.C1TDBGSepDet(Me.C1TDBGSepDet.Row, "DocLnNr")
            Dim xSerie As String = Me.C1TDBGSepDet(Me.C1TDBGSepDet.Row, "SerieID")
            'Dim xPrecoVenda As Double
            'LnAux = Me.C1TDBGSepDet.Row.ToString

            ''ISTO DEVIA SERVIR PARA QUANDO O TALÃO PASSAVA PARA T LOGO QUE ESTAVA SEPARADO! TENHO DUVIDAS
            ''AGORA VAI SERVIR PARA FORÇAR UPDATE DO ARM. PARA ARM.
            ''TODO: REVER ESTE PROCESSO
            'If xAplicacao = "BACKOFFICE" Then
            '    Sql = "SELECT PrecoEtiqueta FROM Serie WHERE SerieID = '" & xSerie & "'"
            '    xPrecoVenda = db.GetDataValue(Sql)
            '    Sql = "UPDATE Serie SET EstadoID = 'S', ArmazemID = '" & xArmz & "' , DocNr = '', PrecoVenda = '" & xPrecoVenda & "', Comissao = '0', DtSaida=GETDATE() WHERE SerieID = '" & xSerie & "'"
            'Else
            '    Sql = "UPDATE Serie SET EstadoID = 'S', ArmazemID = '" & xArmz & "' , DocNr = '' , DtSaida=GETDATE() WHERE SerieID = '" & xSerie & "'"
            'End If
            'db.ExecuteData(Sql)


            Sql = "UPDATE Serie SET PrecoVenda=PrecoEtiqueta, Vendedor='0', PVndReal='0', EstadoID = 'S', DocNr = '' , DtSaida='' WHERE SerieID = '" & xSerie & "'"
            db.ExecuteData(Sql)


            Sql = "Select ArmazemID from Serie WHERE SerieID = '" & xSerie & "'"
            If db.GetDataValue(Sql) <> xArmz Then
                Do While MsgBox("ERRO DO SISTEMA! O TALÃO NÃO FOI ELIMINADO!", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok
                Loop
                e.Cancel = True
            Else
                Sql = "DELETE FROM DocDet WHERE EmpresaID='" & xEmp & "' AND ArmazemID='" & xArmz & "' AND TipoDocID='SE' AND DocNr='" & xNumDoc & "' AND DocLnNr=" & xDocLnNr
                db.ExecuteData(Sql)
                'sApagaTalaoAux = xSerie

            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TDBGSepDet_BeforeDelete")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TDBGSepDet_BeforeDelete")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub C1TDBGSepDet_AfterDelete(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1TDBGSepDet.AfterDelete
        dtDet.AcceptChanges()
        Me.txtQtdSep.Text = dtDet.Rows.Count

        Dim db As New ClsSqlBDados

        Try

            ''ORDEM PARA UPDATE DE 'V' PARA 'S' NO P2
            'Sql = "UPDATE Serie SET OperadorID='DSEP' WHERE SerieID = '" & sApagaTalaoAux & "'"
            'db.ExecuteData(Sql)
            'sApagaTalaoAux = ""

        Catch ex As Exception

        End Try

    End Sub


    'EVENTOS EM C1FGLista

    Private Sub C1FGLista_AfterDeleteRow(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FGLista.AfterDeleteRow
        dtAux.AcceptChanges()
        Me.txtQtdLido.Text = dtAux.Rows.Count
        Me.txtCodBarras.Focus()
    End Sub

    Private Sub C1FGLista_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FGLista.BeforeEdit
        e.Cancel = True
    End Sub

    'FUNÇOES

    Private Sub AtualizaDetalhe()

        Dim db As New ClsSqlBDados


        Try

            If dtCab.Rows.Count = 0 Then
                Exit Sub
            End If


            Dim xDocNr As String
            Dim coluna As C1.Win.C1TrueDBGrid.C1DisplayColumn

            C1TDBGSepDet.Enabled = True
            txtCodBarras.Enabled = True
            CmdInsSep.Enabled = True

            txtQtdSep.Text = ""
            lbNrAT.Text = ""

            dtDet.Clear()
            Me.txtQtdSep.Clear()
            xDocNr = Me.C1TGSepCab(Me.C1TGSepCab.Bookmark, "DocNr")

            If bLojaConsignacao = True Then
                lbNrAT.Text = ""
                lbNrAT.Visible = False
                CmdExe.Enabled = False
                If Len(sIdDocCabSep) > 0 Then
                    'IR BUSCAR O NUMERO AT....DA GUIA CORRESPONDENTE
                    Sql = "SELECT ISNULL(ATDocCodeID,'') FROM DocCab WHERE IdDocCabOrig = '" & sIdDocCabSep & "'"
                    sNrAT = db.GetDataValue(Sql)
                    If Len(sNrAT) > 0 Then
                        C1TDBGSepDet.Enabled = False
                        txtCodBarras.Enabled = False
                        CmdInsSep.Enabled = False
                        CmdExe.Enabled = True
                        lbNrAT.Text = "Nr. AT: " & sNrAT
                        lbNrAT.Visible = True
                    End If
                End If

            Else
                lbNrAT.Visible = False
            End If


            Sql = "SELECT convert(nvarchar(36), IdDocCab) FROM DocCab WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'SE' AND DocNr = '" & xDocNr & "'"
            sIdDocCabSep = db.GetDataValue(Sql)


            Sql = "SELECT COUNT(*) FROM DocCab WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'SE' AND EstadoDoc <> 'C' AND DocNr = '" & xDocNr & "'"
            Cmd = New SqlCommand(Sql, cn)
            If cn.State = ConnectionState.Closed Then cn.Open()
            If Cmd.ExecuteScalar > 0 Then
                GroupBox2.Enabled = False
                C1TDBGSepDet.AllowDelete = False
                CmdInsSep.Enabled = False
                CmdExe.Enabled = False
            Else
                GroupBox2.Enabled = True
                GroupBox3.Enabled = True
                C1TDBGSepDet.AllowDelete = True
                CmdInsSep.Enabled = True
                CmdExe.Enabled = True
            End If


            Sql = "SELECT DocDet.EmpresaID, DocDet.ArmazemID, DocDet.TipoDocID, DocDet.DocNr, DocDet.DocLnNr, DocDet.SerieID, Serie.ProductCode AS Artigo, DocDet.ModeloID, DocDet.CorID, DocDet.TamID, ISNULL(RTRIM(LTRIM(Serie.Obs)), '') + ' ' + ISNULL(RTRIM(LTRIM(Serie.Obs1)), '') AS Obs FROM DocDet LEFT OUTER JOIN Serie ON DocDet.SerieID = Serie.SerieID WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmz & "') AND (DocDet.TipoDocID = 'SE') AND (DocDet.DocNr = '" & xDocNr & "') ORDER BY DocDet.SerieID"
            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(dtDet)

            lbObs.Text = ""
            Sql = "SELECT Obs1 FROM DocCab WHERE IdDocCab LIKE '" & sIdDocCabSep & "'"
            lbObs.Text = db.GetDataValue(Sql).ToString


            Sql = "SELECT Obs FROM DocCab WHERE IdDocCab LIKE '" & sIdDocCabSep & "'"
            tbObs.Text = db.GetDataValue(Sql).ToString


            With Me.C1TDBGSepDet
                .DataSource = dtDet
                .Splits(0).DisplayColumns("EmpresaID").Visible = False
                .Splits(0).DisplayColumns("ArmazemID").Visible = False
                .Splits(0).DisplayColumns("TipoDocID").Visible = False
                .Splits(0).DisplayColumns("DocNr").Visible = False
                .Splits(0).DisplayColumns("DocLnNr").Visible = False
                .Columns("SerieID").Caption = "Talão"
                .Columns("ModeloID").Caption = "Modelo"
                .Columns("CorID").Caption = "Cor"
                .Columns("TamID").Caption = "Tam"
                .Columns("SerieID").SortDirection = SortDirEnum.Ascending

                For Each coluna In Me.C1TDBGSepDet.Splits(0).DisplayColumns
                    coluna.Style.Font = New Font("Arial", 10, FontStyle.Regular)
                    coluna.HeadingStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    coluna.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    coluna.AutoSize()
                    coluna.Locked = True
                Next

                Me.txtQtdSep.Text = dtDet.Rows.Count
                dtAux.Clear()
                Me.txtQtdLido.Clear()
                lbQtd.Visible = False
                If dtDet.Rows.Count > 0 Then lbQtd.Visible = True
                .Refresh()

            End With
            C1TDBGSepDet.Visible = True
            Me.txtCodBarras.Focus()

            lbObs.Visible = False

            'If Trim(Me.C1TGSepCab(Me.C1TGSepCab.Row, "EstadoDoc")) <> "C" Or bLojaConsignacao = True Then
            '    CmdExe.Enabled = False
            'Else
            '    CmdExe.Enabled = True
            'End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "AtualizaDetalhe")
        Catch ex As Exception
            ErroVB(ex.Message, "AtualizaDetalhe")
        Finally
            cn.Close()
            Sql = Nothing
        End Try

    End Sub

    Private Sub ActualizaCabeçalho()


        Dim db As New ClsSqlBDados

        Try

            dtCab.Clear()

            If cbVerTodas.Checked = True Then

                Sql = "SELECT DocCab.DocNr, DocCab.TercID, Armazens.ArmAbrev, DocCab.DataDoc, DocCab.IdDocCab, DocCab.Obs, DocCab.EstadoDoc " &
                    "FROM DocCab, Armazens " &
                    "WHERE DocCab.TercID = Armazens.ArmazemID AND DocCab.EmpresaID = '" & xEmp & "' AND DocCab.ArmazemID = '" & xArmz & "' AND DocCab.TipoDocID = 'SE' ORDER BY Armazens.ArmAbrev DESC"
            Else

                Sql = "SELECT DocCab.DocNr, DocCab.TercID, Armazens.ArmAbrev, DocCab.DataDoc, DocCab.IdDocCab, DocCab.Obs, DocCab.EstadoDoc FROM DocCab, Armazens " &
                "WHERE DocCab.TercID = Armazens.ArmazemID AND DocCab.EmpresaID = '" & xEmp & "' AND DocCab.ArmazemID = '" & xArmz & "' AND DocCab.TipoDocID = 'SE' AND DocCab.EstadoDoc = 'C' ORDER BY Armazens.ArmAbrev DESC"
            End If
            db.GetData(Sql, dtCab)

            If dtCab.Rows.Count = 0 Then
                txtCodBarras.Enabled = False
                Exit Sub
            End If

            If dtCab.Rows.Count > 0 Then txtCodBarras.Enabled = True

            With Me.C1TGSepCab
                .DataSource = dtCab
                dtCab.DefaultView.Sort = "DocNr Desc"
                .Columns("DocNr").Caption = "Doc"
                .Columns("TercId").Caption = "Cod"
                .Columns("ArmAbrev").Caption = "Destino"
                .Columns("DataDoc").Caption = "Data"
                .Columns("DataDoc").NumberFormat = "yyyy-MM-dd"
                .Splits(0).DisplayColumns("IdDocCab").Visible = False
                .Splits(0).DisplayColumns("DocNr").Width = 60
                .Splits(0).DisplayColumns("TercId").Width = 40
                .Splits(0).DisplayColumns("ArmAbrev").Width = 105
                .Splits(0).DisplayColumns("DataDoc").Width = 75
                .Splits(0).Style.VerticalAlignment = AlignVertEnum.Center
                .Splits(0).DisplayColumns("TercId").Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Obs").Visible = False
                .Splits(0).DisplayColumns("EstadoDoc").Visible = False
                .RowHeight = 25
                .MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                .AllowDelete = False
                Dim ColCab As C1DisplayColumn
                For Each ColCab In Me.C1TGSepCab.Splits(0).DisplayColumns
                    ColCab.Style.Font = New Font("Arial", 10, FontStyle.Regular)
                    ColCab.HeadingStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    ColCab.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    ColCab.Locked = True
                    'ColCab.AutoSize()
                    'MsgBox(ColCab.Width)
                Next
                .Refresh()
            End With

            AtualizaDetalhe()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaCabeçalho")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaCabeçalho")
        End Try

    End Sub

    Private Function VerificarRepetidos() As Boolean
        If dtAux.Rows.Count > 0 Then
            If dtAux.Select("SerieID = '" & Me.txtCodBarras.Text & "'", "").Length = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Private Function DevolveDestino(ByRef xDestino As String) As Boolean

        Dim db As New ClsSqlBDados

        Try
            Sql = "SELECT isnull(TercID,'') FROM Armazens WHERE ArmazemID='" & xDestino & "'"
            xDestino = db.GetDataValue(Sql)
            If xDestino = "" Then
                xDestino = "xxxx"
                Return True
            Else
                Sql = "SELECT isnull(TercID,'') FROM Terceiros WHERE TercID='" & xDestino & "'"
                If db.GetDataValue(Sql) Is DBNull.Value Or db.GetDataValue(Sql) = "" Then
                    Return False
                Else
                    Return True
                End If
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DevolveDestino")
        Catch ex As Exception
            ErroVB(ex.Message, "DevolveDestino")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        If MsgBox("Confirma que quer cancelar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.txtCodBarras.Text = Nothing
            dtAux.Clear()
        End If

    End Sub

    Private Function DevolveComissao(ByVal xArmzDest As String, ByVal xModelo As String) As Double
        Dim db As New ClsSqlBDados

        Try

            Sql = "SELECT  C.Comissao FROM  Comissoes C, Modelos M, Armazens A  WHERE C.LinhaID = M.LinhaID " &
                "AND C.ArmazemID = A.ArmazemID AND C.TabPrecoID = A.TabPrecoID AND M.ModeloID = '" & xModelo & "' AND C.ArmazemID = '" & xArmzDest & "'"
            If xPrecoEtiqueta = False Then
                Return db.GetDataValue(Sql)
                Exit Function
            End If
            Sql = "SELECT  C.Comissao FROM  Comissoes C, Modelos M, Armazens A  WHERE C.LinhaID = M.LinhaID " &
                "AND C.ArmazemID = A.ArmazemID AND C.TabPrecoID = '00' AND M.ModeloID = '" & xModelo & "' AND C.ArmazemID = '" & xArmzDest & "'"
            Return db.GetDataValue(Sql)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DevolveComissao")
        Catch ex As Exception
            ErroVB(ex.Message, "DevolveComissao")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function

    Private Function DevolvePv(ByVal xArmzDest As String, ByVal xSerie As String) As Double
        Dim xPv As Double
        Dim db As New ClsSqlBDados

        Try

            Sql = "SELECT P.Preco FROM Serie S, PrecoVenda P, Armazens A WHERE S.ModeloID = P.ModeloID " &
                "AND S.CorID = P.CorID And P.TabPrecoID = A.TabPrecoID AND A.ArmazemID = '" & xArmzDest & "' AND S.SerieID = '" & xSerie & "'"
            xPv = db.GetDataValue(Sql)
            If xPv > 0 Then
                xPrecoEtiqueta = False
                Return xPv
                Exit Function
            End If
            Sql = "SELECT PrecoEtiqueta FROM Serie WHERE SerieID = '" & xSerie & "'"
            xPrecoEtiqueta = True
            Return db.GetDataValue(Sql)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DevolvePv")
        Catch ex As Exception
            ErroVB(ex.Message, "DevolvePv")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function

    Private Function GravarDocumento(ByVal xTipoDoc As String) As Boolean


        Dim db As New ClsSqlBDados

        Try

            Dim dtAuxDoc As New DataTable
            Dim dtAuxGuia As New DataTable
            Dim xTipoTerc As String = "I"
            Dim sDescricaoLinha As String
            Dim dComissao As Double = 0

            Dim xData As String = Format(CType(Now(), Date), "yyyy-MM-dd H:mm:ss")
            sIdDocCab = Guid.NewGuid.ToString
            sIdDocDet = Guid.NewGuid.ToString

            Dim strData As New StringBuilder

            Dim sCountryCarga As String = "PT"
            Dim sCountryDescarga As String = "PT"

            xNovoDoc = PesquisaMaxNumDoc(xTipoDoc)
            CarregarInfoCargaDescarga(xArmz, sArmzDestino)


            Dim sATCUD As String = DevolveATCUD(xArmz, xTipoDoc, xNovoDoc)
            If Now() >= #01/01/2023# And sATCUD = "0" Then Return False

            Select Case xTipoDoc


                Case "GT"
                    xTipoTerc = "I"


                    Sql = "BEGIN TRANSACTION"
                    strData.AppendLine(Sql)

                    Sql = "INSERT INTO DocCab (EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, 
                        HoraDesc, Obs, Obs1, Obs2, Obs3, DescontoDoc, EstadoDoc, TipoTerc, FormaPagtoID, IdDocCab, IdDocCabOrig, UtilizadorID, OperadorID, SAFT, DtUltAlt, AddressDetailCarga, 
                        CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, ATCUD) " &
                        "VALUES ('" & xEmp & "', '" & xArmz & "', '" & xTipoDoc & "', N'" & xNovoDoc & "', '" & sTercID & "', CONVERT(DATETIME, '" & xData & "', 102), '', 
                        '', '', '0', '', '', '', '', '', '0', '0', '0', '0', 'C', N'" & xTipoTerc & "', '0', '" & sIdDocCab & "', NULL, '" & iUtilizadorID & "', '" & xUtilizador & "',
                        '0', CONVERT(DATETIME, '" & xData & "', 102), N'" & sAddressDetailCarga & "', N'" & sCityCarga & "', N'" & sPostalCodeCarga & "', N'" & sCountryCarga & "', 
                        CONVERT(DATETIME, '" & xData & "', 102), N'" & sAddressDetailDescarga & "', N'" & sCityDescarga & "', N'" & sPostalCodeDescarga & "', N'" & sCountryDescarga & "', 
                        CONVERT(DATETIME, '" & xData & "', 102), '" & sATCUD & "');"
                    strData.AppendLine(Sql)

                    Dim inLinha As Int16 = 0
                    Dim dValor As Double = 0
                    Dim dVlrDescLn As Double = 0
                    Dim dVlrIVA As Double = 0



                    Sql = "SELECT DocDet.ProductCode, Product.ProductDescription, SUM(DocDet.Qtd) AS Qtd, Product.UnitOfMeasure FROM DocDet INNER JOIN Product 
                        ON DocDet.ProductCode = Product.ProductCode WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmz & "') AND (DocDet.TipoDocID = 'SE') 
                        AND (DocDet.DocNr = N'" & xNumDocSep & "') GROUP BY Product.ProductDescription, Product.UnitOfMeasure, DocDet.ProductCode"
                    db.GetData(Sql, dtAuxGuia, False)

                    For Each r As DataRow In dtAuxGuia.Rows

                        inLinha = inLinha + 1
                        Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, ModeloID, CorID, Descricao, Unidade, Valor, VlrDescLn, IvaID, VlrIVA, 
                            TxIva, Qtd, EstadoLn, IDDocCab, ProductCode, OperadorID) VALUES ('" & xEmp & "','" & xArmz & "','" & xTipoDoc & "','" & xNovoDoc & "', " & inLinha & ", 
                            '00000', '00', '" & Trim(r("ProductDescription")) & "', '" & r("UnitOfMeasure") & "', 0, 0, '" & xIvaID & "', 0,  " & DevolveIva(xIvaID) & ", " & r("Qtd") & ", 'C',
                            '" & sIdDocCab & "', '" & r("ProductCode") & "', '" & xUtilizador & "');"
                        strData.AppendLine(Sql)

                    Next

                    Sql = "COMMIT TRANSACTION;"
                    strData.AppendLine(Sql)
                    Sql = strData.ToString
                    dberrorAtivo = True


                Case "FC"
                    xTipoTerc = "C"

                    Sql = "SELECT CAST(IDTerceiro AS char(36))  from Terceiros where TercID='" & sTercID & "'"
                    sIdTerceiro = db.GetDataValue(Sql).ToString

                    Sql = "BEGIN TRANSACTION"
                    strData.AppendLine(Sql)

                    Sql = "INSERT INTO DocCab (EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, TipoDocOrig, DocNrOrig, Exp, PPagID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, Obs1, Obs2, Obs3, DescontoDoc, EstadoDoc, TipoTerc, FormaPagtoID, IdDocCab, IdDocCabOrig, UtilizadorID, OperadorID, SAFT, DtUltAlt, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, IdTerceiro, ATCUD) " &
                        "VALUES ('" & xEmp & "', '" & xArmz & "', '" & xTipoDoc & "', N'" & xNovoDoc & "', '" & sTercID & "', CONVERT(DATETIME, '" & xData & "', 102), '', '', '', '0', '', '', '', '', '', '0', '0', '0', '0', 'C', N'" & xTipoTerc & "', '0', '" & sIdDocCab & "', '" & sIdDocCabSepAux & "', '" & iUtilizadorID & "', '" & xUtilizador & "', '0', CONVERT(DATETIME, '" & xData & "', 102), N'" & sAddressDetailCarga & "', N'" & sCityCarga & "', N'" & sPostalCodeCarga & "', N'" & sCountryCarga & "', CONVERT(DATETIME, '" & xData & "', 102), N'" & sAddressDetailDescarga & "', N'" & sCityDescarga & "', N'" & sPostalCodeDescarga & "', N'" & sCountryDescarga & "', CONVERT(DATETIME, '" & xData & "', 102), '" & sIdTerceiro & "', '" & sATCUD & "');"
                    strData.AppendLine(Sql)

                    Dim inLinha As Int16 = 0
                    Dim dValor As Double = 0
                    Dim dVlrDescLn As Double = 0
                    Dim dVlrIVA As Double = 0
                    Dim dValorLiquido As Double = 0

                    Sql = "SELECT DocDet.ProductCode, DocDet.ModeloID, DocDet.CorID, Product.ProductDescription, SUM(DocDet.Qtd) AS Qtd, Product.UnitOfMeasure, ModeloCor.PrVnd, DocDet.IdDocCab
                FROM     DocDet INNER JOIN
                Product ON DocDet.ProductCode = Product.ProductCode INNER JOIN
                ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID
                WHERE  (DocDet.EmpresaID = '0001') AND (DocDet.ArmazemID = '" & xArmz & "') AND (DocDet.TipoDocID = 'SE') AND (DocDet.DocNr = N'" & xNumDocSep & "')
                GROUP BY Product.ProductDescription, Product.UnitOfMeasure, DocDet.ProductCode, DocDet.ModeloID, DocDet.CorID, ModeloCor.PrVnd, DocDet.IdDocCab;"

                    db.GetData(Sql, dtAuxDoc, False)

                    For Each r As DataRow In dtAuxDoc.Rows

                        inLinha = inLinha + 1

                        Sql = "SELECT ISNULL(MAX(Comissao),0) AS Comissao FROM Comissoes
                    WHERE  ArmazemID = '" & sArmzDestino & "' and LinhaID = '01' AND TabPrecoID = '00'"
                        dComissao = db.GetDataValue(Sql)
                        If dComissao = 0 Then
                            MsgBox("Falta a comissão!!")
                            Return False
                        End If

                        'dValor = r("PrVnd") * (1 - dComissao) / (1 + DevolveIva(DevolveIvaId(xArmz)))
                        dValor = Arredondamento(r("PrVnd") * (1 - dComissao), 2)
                        dValorLiquido = Arredondamento(dValor / (1 + DevolveIva(DevolveIvaId(xArmz))), 2)

                        sDescricaoLinha = Trim(r("ProductDescription")) + " «" + r("ModeloID") + "-" + r("CorID") + "»"

                        Sql = "INSERT INTO dbo.DocDet (EmpresaID,ArmazemID,TipoDocID,DocNr,DocLnNr,ModeloID,CorID,Descricao,Unidade,Valor,ValorLiquido,
                IvaID,VlrIVA,TxIva,Qtd,EstadoLn,IdDocCab,IdDocDet,IdDocDetOrig,UtilizadorID,ProductCode) 
                VALUES('" & xEmp & "','" & xArmz & "','" & xTipoDoc & "','" & xNovoDoc & "', " & inLinha & ", '" & r("ModeloID") & "', '" & r("CorID") & "',
                '" & sDescricaoLinha & "', '" & r("UnitOfMeasure") & "', " & dValor & ", " & dValorLiquido & ", " & 0 & ",  " & 0 & ", " & 0 & "," & r("Qtd") & ", 
                'C','" & sIdDocCab & "','" & sIdDocDet & "', '" & sIdDocCabSepAux & "', '" & iUtilizadorID & "', '" & r("ProductCode") & "');"
                        strData.AppendLine(Sql)

                    Next

                    Sql = "INSERT INTO DocSerie (IdDocCab, SerieID)
                    (SELECT '" & sIdDocCab & "', SerieID FROM  DocDet
                    WHERE  (IdDocCab = '" & sIdDocCabSepAux & "'));"
                    strData.AppendLine(Sql)

                    Sql = "COMMIT TRANSACTION;"
                    strData.AppendLine(Sql)
                    Sql = strData.ToString
                    dberrorAtivo = True

            End Select


            Dim clsGravaDoc As New ClsDocs
            If Not clsGravaDoc.NovoDoc(Sql, sIdDocCab, xTipoDoc) Then
                MsgBox("Erro 7500 da criação do documento!!",, "Girl")
                Return False
            Else
                Return True
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravarDocumento")
        Catch ex As Exception
            ErroVB(ex.Message, "GravarDocumento")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            cn.Close()
            Cmd.Dispose()
        End Try

    End Function

    Private Sub CarregarInfoCargaDescarga(ByVal sCarga As String, ByVal sDescarga As String)

        Try
            Dim db As New ClsSqlBDados
            Dim dtCarga As New DataTable
            Dim dtDescarga As New DataTable


            Sql = "SELECT Armazens.ArmazemID, Terceiros.Morada, Terceiros.Localidade, Terceiros.CodPostal, Terceiros.PaisID FROM Terceiros INNER JOIN Armazens ON Terceiros.TercID = Armazens.TercID WHERE (Armazens.ArmazemID = '" & sCarga & "')"
            db.GetData(Sql, dtCarga)

            Sql = "SELECT Armazens.ArmazemID, Terceiros.Morada, Terceiros.Localidade, Terceiros.CodPostal, Terceiros.PaisID, Terceiros.TercID FROM Terceiros INNER JOIN Armazens ON Terceiros.TercID = Armazens.TercID WHERE (Armazens.ArmazemID = '" & sDescarga & "')"
            db.GetData(Sql, dtDescarga)

            'Sql = "SELECT TercID, Morada, Localidade, CodPostal, PaisID FROM Terceiros WHERE TercID = '" & sDescarga & "'"
            'db.GetData(Sql, dtDescarga)

            If dtCarga.Rows.Count > 0 Then
                sAddressDetailCarga = dtCarga.Rows(0)("Morada").ToString
                sCityCarga = dtCarga.Rows(0)("Localidade").ToString
                sPostalCodeCarga = dtCarga.Rows(0)("CodPostal").ToString
            End If

            If dtDescarga.Rows.Count > 0 Then
                sAddressDetailDescarga = dtDescarga.Rows(0)("Morada").ToString
                sCityDescarga = dtDescarga.Rows(0)("Localidade").ToString
                sPostalCodeDescarga = dtDescarga.Rows(0)("CodPostal").ToString
                sTercID = dtDescarga.Rows(0)("TercID").ToString
            End If

        Catch ex As Exception

        End Try


    End Sub


End Class
