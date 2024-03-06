<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecepcao
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecepcao))
        Me.TimerActDados = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBoxFoto = New System.Windows.Forms.PictureBox
        Me.txtQtdLido = New System.Windows.Forms.Label
        Me.C1FGRec = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.txtFaltaRec = New System.Windows.Forms.Label
        Me.C1FGRecPend = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.C1FGRecPendCab = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.lbFaltaRec = New System.Windows.Forms.Label
        Me.btRecTotal = New System.Windows.Forms.Button
        Me.cbVerTodas = New System.Windows.Forms.CheckBox
        Me.lbCab = New System.Windows.Forms.Label
        Me.txtCodBarras = New System.Windows.Forms.TextBox
        Me.CmdValidaRec = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.btFechar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.btImprimir = New System.Windows.Forms.Button
        Me.btCancelar = New System.Windows.Forms.Button
        CType(Me.PictureBoxFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FGRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FGRecPend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FGRecPendCab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerActDados
        '
        '
        'PictureBoxFoto
        '
        Me.PictureBoxFoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxFoto.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxFoto.Location = New System.Drawing.Point(663, 12)
        Me.PictureBoxFoto.Name = "PictureBoxFoto"
        Me.PictureBoxFoto.Size = New System.Drawing.Size(211, 166)
        Me.PictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxFoto.TabIndex = 57
        Me.PictureBoxFoto.TabStop = False
        '
        'txtQtdLido
        '
        Me.txtQtdLido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQtdLido.AutoSize = True
        Me.txtQtdLido.BackColor = System.Drawing.Color.Transparent
        Me.txtQtdLido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtQtdLido.Location = New System.Drawing.Point(774, 621)
        Me.txtQtdLido.Name = "txtQtdLido"
        Me.txtQtdLido.Size = New System.Drawing.Size(21, 24)
        Me.txtQtdLido.TabIndex = 54
        Me.txtQtdLido.Text = "0"
        Me.txtQtdLido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'C1FGRec
        '
        Me.C1FGRec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FGRec.ColumnInfo = resources.GetString("C1FGRec.ColumnInfo")
        Me.C1FGRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.C1FGRec.Location = New System.Drawing.Point(530, 268)
        Me.C1FGRec.Name = "C1FGRec"
        Me.C1FGRec.Rows.Count = 1
        Me.C1FGRec.Rows.DefaultSize = 19
        Me.C1FGRec.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGRec.Size = New System.Drawing.Size(486, 344)
        Me.C1FGRec.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FGRec.Styles"))
        Me.C1FGRec.TabIndex = 49
        Me.C1FGRec.TabStop = False
        '
        'txtFaltaRec
        '
        Me.txtFaltaRec.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtFaltaRec.AutoSize = True
        Me.txtFaltaRec.BackColor = System.Drawing.Color.Transparent
        Me.txtFaltaRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtFaltaRec.Location = New System.Drawing.Point(288, 619)
        Me.txtFaltaRec.Name = "txtFaltaRec"
        Me.txtFaltaRec.Size = New System.Drawing.Size(21, 24)
        Me.txtFaltaRec.TabIndex = 53
        Me.txtFaltaRec.Text = "0"
        Me.txtFaltaRec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'C1FGRecPend
        '
        Me.C1FGRecPend.AllowDelete = True
        Me.C1FGRecPend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.C1FGRecPend.ColumnInfo = resources.GetString("C1FGRecPend.ColumnInfo")
        Me.C1FGRecPend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.C1FGRecPend.Location = New System.Drawing.Point(12, 268)
        Me.C1FGRecPend.Name = "C1FGRecPend"
        Me.C1FGRecPend.Rows.Count = 1
        Me.C1FGRecPend.Rows.DefaultSize = 19
        Me.C1FGRecPend.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGRecPend.Size = New System.Drawing.Size(476, 348)
        Me.C1FGRecPend.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FGRecPend.Styles"))
        Me.C1FGRecPend.TabIndex = 48
        Me.C1FGRecPend.TabStop = False
        '
        'C1FGRecPendCab
        '
        Me.C1FGRecPendCab.AllowDelete = True
        Me.C1FGRecPendCab.ColumnInfo = resources.GetString("C1FGRecPendCab.ColumnInfo")
        Me.C1FGRecPendCab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.C1FGRecPendCab.Location = New System.Drawing.Point(12, 57)
        Me.C1FGRecPendCab.Name = "C1FGRecPendCab"
        Me.C1FGRecPendCab.Rows.Count = 1
        Me.C1FGRecPendCab.Rows.DefaultSize = 19
        Me.C1FGRecPendCab.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGRecPendCab.Size = New System.Drawing.Size(476, 190)
        Me.C1FGRecPendCab.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FGRecPendCab.Styles"))
        Me.C1FGRecPendCab.TabIndex = 51
        Me.C1FGRecPendCab.TabStop = False
        '
        'lbFaltaRec
        '
        Me.lbFaltaRec.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbFaltaRec.AutoSize = True
        Me.lbFaltaRec.BackColor = System.Drawing.Color.Transparent
        Me.lbFaltaRec.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFaltaRec.Location = New System.Drawing.Point(125, 623)
        Me.lbFaltaRec.Name = "lbFaltaRec"
        Me.lbFaltaRec.Size = New System.Drawing.Size(157, 19)
        Me.lbFaltaRec.TabIndex = 52
        Me.lbFaltaRec.Text = "Falta Recepcionar :"
        Me.lbFaltaRec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btRecTotal
        '
        Me.btRecTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btRecTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btRecTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRecTotal.Location = New System.Drawing.Point(912, 108)
        Me.btRecTotal.Name = "btRecTotal"
        Me.btRecTotal.Size = New System.Drawing.Size(105, 70)
        Me.btRecTotal.TabIndex = 59
        Me.btRecTotal.Text = "Recepcionar Tudo"
        Me.btRecTotal.UseVisualStyleBackColor = False
        '
        'cbVerTodas
        '
        Me.cbVerTodas.AutoSize = True
        Me.cbVerTodas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbVerTodas.Location = New System.Drawing.Point(335, 29)
        Me.cbVerTodas.Name = "cbVerTodas"
        Me.cbVerTodas.Size = New System.Drawing.Size(110, 24)
        Me.cbVerTodas.TabIndex = 61
        Me.cbVerTodas.Text = "Ver Todas"
        Me.cbVerTodas.UseVisualStyleBackColor = True
        '
        'lbCab
        '
        Me.lbCab.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCab.Location = New System.Drawing.Point(26, 28)
        Me.lbCab.Name = "lbCab"
        Me.lbCab.Size = New System.Drawing.Size(258, 26)
        Me.lbCab.TabIndex = 60
        Me.lbCab.Text = "Lista de Recepções "
        Me.lbCab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodBarras
        '
        Me.txtCodBarras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras.Location = New System.Drawing.Point(530, 233)
        Me.txtCodBarras.Name = "txtCodBarras"
        Me.txtCodBarras.Size = New System.Drawing.Size(125, 29)
        Me.txtCodBarras.TabIndex = 50
        Me.txtCodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdValidaRec
        '
        Me.CmdValidaRec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdValidaRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmdValidaRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CmdValidaRec.Location = New System.Drawing.Point(530, 68)
        Me.CmdValidaRec.Name = "CmdValidaRec"
        Me.CmdValidaRec.Size = New System.Drawing.Size(120, 62)
        Me.CmdValidaRec.TabIndex = 62
        Me.CmdValidaRec.Text = "Recepcionar"
        Me.CmdValidaRec.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(526, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 26)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Ler Talão"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btFechar
        '
        Me.btFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btFechar.Location = New System.Drawing.Point(880, 12)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(136, 34)
        Me.btFechar.TabIndex = 65
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(681, 624)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 19)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Qtd Lida :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btImprimir
        '
        Me.btImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btImprimir.Location = New System.Drawing.Point(529, 12)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(119, 34)
        Me.btImprimir.TabIndex = 67
        Me.btImprimir.Text = "Imprimir"
        Me.btImprimir.UseVisualStyleBackColor = False
        '
        'btCancelar
        '
        Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btCancelar.Location = New System.Drawing.Point(540, 619)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(105, 31)
        Me.btCancelar.TabIndex = 68
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'frmRecepcao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 664)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.btImprimir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmdValidaRec)
        Me.Controls.Add(Me.cbVerTodas)
        Me.Controls.Add(Me.txtCodBarras)
        Me.Controls.Add(Me.lbCab)
        Me.Controls.Add(Me.C1FGRec)
        Me.Controls.Add(Me.btRecTotal)
        Me.Controls.Add(Me.PictureBoxFoto)
        Me.Controls.Add(Me.txtQtdLido)
        Me.Controls.Add(Me.txtFaltaRec)
        Me.Controls.Add(Me.C1FGRecPend)
        Me.Controls.Add(Me.C1FGRecPendCab)
        Me.Controls.Add(Me.lbFaltaRec)
        Me.Name = "frmRecepcao"
        Me.Text = "frmRecepcao"
        CType(Me.PictureBoxFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FGRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FGRecPend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FGRecPendCab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimerActDados As System.Windows.Forms.Timer
    Friend WithEvents PictureBoxFoto As System.Windows.Forms.PictureBox
    Friend WithEvents txtQtdLido As System.Windows.Forms.Label
    Friend WithEvents C1FGRec As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtFaltaRec As System.Windows.Forms.Label
    Friend WithEvents C1FGRecPend As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FGRecPendCab As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lbFaltaRec As System.Windows.Forms.Label
    Friend WithEvents btRecTotal As System.Windows.Forms.Button
    Friend WithEvents cbVerTodas As System.Windows.Forms.CheckBox
    Friend WithEvents lbCab As System.Windows.Forms.Label
    Friend WithEvents txtCodBarras As System.Windows.Forms.TextBox
    Friend WithEvents CmdValidaRec As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btImprimir As System.Windows.Forms.Button
    Friend WithEvents btCancelar As System.Windows.Forms.Button
End Class
