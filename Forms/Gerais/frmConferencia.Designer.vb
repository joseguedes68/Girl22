<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConferencia
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
        Me.lbConferir = New System.Windows.Forms.Label()
        Me.lbConferidos = New System.Windows.Forms.Label()
        Me.CmdApagaSep = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GVDocDet = New GirlRootName.GridView()
        Me.btActualizar = New System.Windows.Forms.Button()
        Me.CmdConferir = New System.Windows.Forms.Button()
        Me.tbConferir = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GVDocCab = New GirlRootName.GridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btPrintConferidos = New System.Windows.Forms.Button()
        Me.GVConf = New GirlRootName.GridView()
        Me.lbConferido = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.TimerActDados = New System.Windows.Forms.Timer(Me.components)
        Me.txtCodBarras = New System.Windows.Forms.TextBox()
        Me.CbDestino = New System.Windows.Forms.ComboBox()
        Me.PictureBoxFoto = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmdFecharSep = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btCriarFC = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.CmdNovoDoc = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdConfirmar = New System.Windows.Forms.Button()
        Me.GVDepTemp = New GirlRootName.GridView()
        Me.lblQtdDepTemp = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GVDocDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GVDocCab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GVConf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.GVDepTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbConferir
        '
        Me.lbConferir.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbConferir.Location = New System.Drawing.Point(2, 15)
        Me.lbConferir.Name = "lbConferir"
        Me.lbConferir.Size = New System.Drawing.Size(109, 31)
        Me.lbConferir.TabIndex = 9
        Me.lbConferir.Text = "Conferir :"
        Me.lbConferir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbConferidos
        '
        Me.lbConferidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbConferidos.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbConferidos.Location = New System.Drawing.Point(6, 16)
        Me.lbConferidos.Name = "lbConferidos"
        Me.lbConferidos.Size = New System.Drawing.Size(125, 23)
        Me.lbConferidos.TabIndex = 9
        Me.lbConferidos.Text = "Conferidos :"
        Me.lbConferidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmdApagaSep
        '
        Me.CmdApagaSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdApagaSep.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdApagaSep.Location = New System.Drawing.Point(85, 82)
        Me.CmdApagaSep.Name = "CmdApagaSep"
        Me.CmdApagaSep.Size = New System.Drawing.Size(82, 29)
        Me.CmdApagaSep.TabIndex = 7
        Me.CmdApagaSep.Text = "Apagar"
        Me.CmdApagaSep.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GVDocDet)
        Me.GroupBox2.Controls.Add(Me.btActualizar)
        Me.GroupBox2.Controls.Add(Me.CmdConferir)
        Me.GroupBox2.Controls.Add(Me.tbConferir)
        Me.GroupBox2.Controls.Add(Me.lbConferir)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 233)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(380, 310)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        '
        'GVDocDet
        '
        Me.GVDocDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GVDocDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVDocDet.Location = New System.Drawing.Point(10, 49)
        Me.GVDocDet.Name = "GVDocDet"
        Me.GVDocDet.Size = New System.Drawing.Size(364, 258)
        Me.GVDocDet.TabIndex = 14
        '
        'btActualizar
        '
        Me.btActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btActualizar.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btActualizar.Location = New System.Drawing.Point(203, 15)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Size = New System.Drawing.Size(98, 28)
        Me.btActualizar.TabIndex = 23
        Me.btActualizar.Text = "Actualizar"
        Me.btActualizar.UseVisualStyleBackColor = False
        '
        'CmdConferir
        '
        Me.CmdConferir.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdConferir.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CmdConferir.Location = New System.Drawing.Point(306, 15)
        Me.CmdConferir.Name = "CmdConferir"
        Me.CmdConferir.Size = New System.Drawing.Size(68, 28)
        Me.CmdConferir.TabIndex = 23
        Me.CmdConferir.Text = "Print"
        Me.CmdConferir.UseVisualStyleBackColor = False
        '
        'tbConferir
        '
        Me.tbConferir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbConferir.Location = New System.Drawing.Point(104, 15)
        Me.tbConferir.Name = "tbConferir"
        Me.tbConferir.Size = New System.Drawing.Size(93, 29)
        Me.tbConferir.TabIndex = 21
        Me.tbConferir.Text = "Conferir"
        Me.tbConferir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GVDocCab)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(380, 226)
        Me.GroupBox4.TabIndex = 64
        Me.GroupBox4.TabStop = False
        '
        'GVDocCab
        '
        Me.GVDocCab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVDocCab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GVDocCab.Location = New System.Drawing.Point(3, 42)
        Me.GVDocCab.Name = "GVDocCab"
        Me.GVDocCab.Size = New System.Drawing.Size(374, 181)
        Me.GVDocCab.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(258, 26)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Conferência de Stocks "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btPrintConferidos)
        Me.GroupBox3.Controls.Add(Me.GVConf)
        Me.GroupBox3.Controls.Add(Me.lbConferidos)
        Me.GroupBox3.Controls.Add(Me.lbConferido)
        Me.GroupBox3.Location = New System.Drawing.Point(607, 132)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(411, 411)
        Me.GroupBox3.TabIndex = 63
        Me.GroupBox3.TabStop = False
        '
        'btPrintConferidos
        '
        Me.btPrintConferidos.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btPrintConferidos.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btPrintConferidos.Location = New System.Drawing.Point(292, 12)
        Me.btPrintConferidos.Name = "btPrintConferidos"
        Me.btPrintConferidos.Size = New System.Drawing.Size(94, 29)
        Me.btPrintConferidos.TabIndex = 21
        Me.btPrintConferidos.Text = "Print"
        Me.btPrintConferidos.UseVisualStyleBackColor = False
        '
        'GVConf
        '
        Me.GVConf.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GVConf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVConf.Location = New System.Drawing.Point(10, 54)
        Me.GVConf.Name = "GVConf"
        Me.GVConf.Size = New System.Drawing.Size(395, 349)
        Me.GVConf.TabIndex = 14
        '
        'lbConferido
        '
        Me.lbConferido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbConferido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbConferido.Location = New System.Drawing.Point(131, 12)
        Me.lbConferido.Name = "lbConferido"
        Me.lbConferido.Size = New System.Drawing.Size(89, 29)
        Me.lbConferido.TabIndex = 20
        Me.lbConferido.Text = "Conferidos"
        Me.lbConferido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(435, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 27)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Ler Talão"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtData
        '
        Me.txtData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(248, 8)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(120, 29)
        Me.txtData.TabIndex = 10
        Me.txtData.TabStop = False
        '
        'TimerActDados
        '
        Me.TimerActDados.Interval = 500
        '
        'txtCodBarras
        '
        Me.txtCodBarras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras.Location = New System.Drawing.Point(435, 204)
        Me.txtCodBarras.Name = "txtCodBarras"
        Me.txtCodBarras.Size = New System.Drawing.Size(128, 29)
        Me.txtCodBarras.TabIndex = 59
        Me.txtCodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CbDestino
        '
        Me.CbDestino.AllowDrop = True
        Me.CbDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbDestino.DropDownWidth = 150
        Me.CbDestino.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbDestino.Location = New System.Drawing.Point(6, 43)
        Me.CbDestino.MaxDropDownItems = 10
        Me.CbDestino.Name = "CbDestino"
        Me.CbDestino.Size = New System.Drawing.Size(363, 24)
        Me.CbDestino.TabIndex = 12
        '
        'PictureBoxFoto
        '
        Me.PictureBoxFoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxFoto.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxFoto.Location = New System.Drawing.Point(406, 14)
        Me.PictureBoxFoto.Name = "PictureBoxFoto"
        Me.PictureBoxFoto.Size = New System.Drawing.Size(186, 154)
        Me.PictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxFoto.TabIndex = 65
        Me.PictureBoxFoto.TabStop = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(236, 26)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Seleccionar Armazem :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmdFecharSep
        '
        Me.CmdFecharSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CmdFecharSep.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFecharSep.Location = New System.Drawing.Point(314, 82)
        Me.CmdFecharSep.Name = "CmdFecharSep"
        Me.CmdFecharSep.Size = New System.Drawing.Size(86, 29)
        Me.CmdFecharSep.TabIndex = 7
        Me.CmdFecharSep.Text = "Fechar"
        Me.CmdFecharSep.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btCriarFC)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CbDestino)
        Me.GroupBox1.Controls.Add(Me.txtData)
        Me.GroupBox1.Controls.Add(Me.CmdFecharSep)
        Me.GroupBox1.Controls.Add(Me.CmdPrint)
        Me.GroupBox1.Controls.Add(Me.CmdApagaSep)
        Me.GroupBox1.Controls.Add(Me.CmdNovoDoc)
        Me.GroupBox1.Location = New System.Drawing.Point(607, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 119)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        '
        'btCriarFC
        '
        Me.btCriarFC.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCriarFC.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btCriarFC.Location = New System.Drawing.Point(173, 82)
        Me.btCriarFC.Name = "btCriarFC"
        Me.btCriarFC.Size = New System.Drawing.Size(62, 29)
        Me.btCriarFC.TabIndex = 14
        Me.btCriarFC.Text = "Doc"
        Me.btCriarFC.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdPrint.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.Location = New System.Drawing.Point(241, 82)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(68, 29)
        Me.CmdPrint.TabIndex = 7
        Me.CmdPrint.Text = "Print"
        Me.CmdPrint.UseVisualStyleBackColor = False
        '
        'CmdNovoDoc
        '
        Me.CmdNovoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdNovoDoc.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNovoDoc.Location = New System.Drawing.Point(9, 82)
        Me.CmdNovoDoc.Name = "CmdNovoDoc"
        Me.CmdNovoDoc.Size = New System.Drawing.Size(71, 29)
        Me.CmdNovoDoc.TabIndex = 7
        Me.CmdNovoDoc.Text = "Nova"
        Me.CmdNovoDoc.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.cmdCancelar)
        Me.GroupBox5.Controls.Add(Me.cmdConfirmar)
        Me.GroupBox5.Controls.Add(Me.GVDepTemp)
        Me.GroupBox5.Controls.Add(Me.lblQtdDepTemp)
        Me.GroupBox5.Location = New System.Drawing.Point(429, 233)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(139, 310)
        Me.GroupBox5.TabIndex = 67
        Me.GroupBox5.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdCancelar.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancelar.Location = New System.Drawing.Point(6, 10)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(127, 27)
        Me.cmdCancelar.TabIndex = 68
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'cmdConfirmar
        '
        Me.cmdConfirmar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConfirmar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConfirmar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdConfirmar.Location = New System.Drawing.Point(6, 262)
        Me.cmdConfirmar.Name = "cmdConfirmar"
        Me.cmdConfirmar.Size = New System.Drawing.Size(127, 42)
        Me.cmdConfirmar.TabIndex = 68
        Me.cmdConfirmar.Text = "ANEXAR"
        Me.cmdConfirmar.UseVisualStyleBackColor = False
        '
        'GVDepTemp
        '
        Me.GVDepTemp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GVDepTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVDepTemp.Location = New System.Drawing.Point(6, 43)
        Me.GVDepTemp.Name = "GVDepTemp"
        Me.GVDepTemp.Size = New System.Drawing.Size(127, 188)
        Me.GVDepTemp.TabIndex = 66
        '
        'lblQtdDepTemp
        '
        Me.lblQtdDepTemp.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblQtdDepTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lblQtdDepTemp.Location = New System.Drawing.Point(37, 235)
        Me.lblQtdDepTemp.Name = "lblQtdDepTemp"
        Me.lblQtdDepTemp.Size = New System.Drawing.Size(66, 24)
        Me.lblQtdDepTemp.TabIndex = 67
        Me.lblQtdDepTemp.Text = "Label1"
        Me.lblQtdDepTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmConferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 551)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodBarras)
        Me.Controls.Add(Me.PictureBoxFoto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmConferencia"
        Me.Text = "Conferencia de Stocks"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GVDocDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GVDocCab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GVConf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.GVDepTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbConferir As System.Windows.Forms.Label
    Friend WithEvents lbConferidos As System.Windows.Forms.Label
    Friend WithEvents CmdApagaSep As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GVDocDet As GirlRootName.GridView
    Friend WithEvents CmdConferir As System.Windows.Forms.Button
    Friend WithEvents tbConferir As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GVDocCab As GirlRootName.GridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GVConf As GirlRootName.GridView
    Friend WithEvents lbConferido As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents TimerActDados As System.Windows.Forms.Timer
    Friend WithEvents txtCodBarras As System.Windows.Forms.TextBox
    Friend WithEvents CbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBoxFoto As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmdFecharSep As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents CmdNovoDoc As System.Windows.Forms.Button
    Friend WithEvents GVDepTemp As GirlRootName.GridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdConfirmar As System.Windows.Forms.Button
    Friend WithEvents lblQtdDepTemp As System.Windows.Forms.Label
    Friend WithEvents btPrintConferidos As System.Windows.Forms.Button
    Friend WithEvents btCriarFC As System.Windows.Forms.Button
    Friend WithEvents btActualizar As System.Windows.Forms.Button
End Class
