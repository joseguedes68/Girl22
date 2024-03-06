<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuPos
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
        Me.MenuStripPos = New System.Windows.Forms.MenuStrip()
        Me.mVendas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mDocs = New System.Windows.Forms.ToolStripMenuItem()
        Me.smFS = New System.Windows.Forms.ToolStripMenuItem()
        Me.smFT = New System.Windows.Forms.ToolStripMenuItem()
        Me.smNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.smFX = New System.Windows.Forms.ToolStripMenuItem()
        Me.smRV = New System.Windows.Forms.ToolStripMenuItem()
        Me.smGT = New System.Windows.Forms.ToolStripMenuItem()
        Me.smVC = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReceçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeparaçõesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreçosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EtiquetasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuComissões = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestarGavetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mFechar = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.MenuStripPos.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStripPos
        '
        Me.MenuStripPos.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStripPos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mVendas, Me.mConsultas, Me.mDocs, Me.MovimentosToolStripMenuItem, Me.mFechar})
        Me.MenuStripPos.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripPos.Name = "MenuStripPos"
        Me.MenuStripPos.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStripPos.Size = New System.Drawing.Size(1712, 39)
        Me.MenuStripPos.TabIndex = 0
        Me.MenuStripPos.Text = "MenuStrip1"
        '
        'mVendas
        '
        Me.mVendas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mVendas.Name = "mVendas"
        Me.mVendas.Size = New System.Drawing.Size(118, 35)
        Me.mVendas.Text = "Vendas"
        '
        'mConsultas
        '
        Me.mConsultas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mConsultas.Name = "mConsultas"
        Me.mConsultas.Size = New System.Drawing.Size(148, 35)
        Me.mConsultas.Text = "Consultas"
        '
        'mDocs
        '
        Me.mDocs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smFS, Me.smFT, Me.smNC, Me.smFX, Me.smRV, Me.smGT, Me.smVC})
        Me.mDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mDocs.Name = "mDocs"
        Me.mDocs.Size = New System.Drawing.Size(179, 35)
        Me.mDocs.Text = "Documentos"
        '
        'smFS
        '
        Me.smFS.Name = "smFS"
        Me.smFS.Size = New System.Drawing.Size(326, 36)
        Me.smFS.Text = "Fatura Simplificada"
        '
        'smFT
        '
        Me.smFT.Name = "smFT"
        Me.smFT.Size = New System.Drawing.Size(326, 36)
        Me.smFT.Text = "Faturas"
        '
        'smNC
        '
        Me.smNC.Name = "smNC"
        Me.smNC.Size = New System.Drawing.Size(326, 36)
        Me.smNC.Text = "Notas de Crédito"
        '
        'smFX
        '
        Me.smFX.Name = "smFX"
        Me.smFX.Size = New System.Drawing.Size(326, 36)
        Me.smFX.Text = "Fecho Caixa"
        '
        'smRV
        '
        Me.smRV.Name = "smRV"
        Me.smRV.Size = New System.Drawing.Size(326, 36)
        Me.smRV.Text = "Relação Vendas"
        '
        'smGT
        '
        Me.smGT.Name = "smGT"
        Me.smGT.Size = New System.Drawing.Size(326, 36)
        Me.smGT.Text = "Guias Transporte"
        '
        'smVC
        '
        Me.smVC.Name = "smVC"
        Me.smVC.Size = New System.Drawing.Size(326, 36)
        Me.smVC.Text = "Consignação"
        Me.smVC.Visible = False
        '
        'MovimentosToolStripMenuItem
        '
        Me.MovimentosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReceçõesToolStripMenuItem, Me.SeparaçõesToolStripMenuItem1, Me.PreçosToolStripMenuItem, Me.EtiquetasToolStripMenuItem, Me.MenuComissões, Me.TestarGavetaToolStripMenuItem})
        Me.MovimentosToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Italic)
        Me.MovimentosToolStripMenuItem.Name = "MovimentosToolStripMenuItem"
        Me.MovimentosToolStripMenuItem.Size = New System.Drawing.Size(133, 35)
        Me.MovimentosToolStripMenuItem.Text = "Diversos"
        '
        'ReceçõesToolStripMenuItem
        '
        Me.ReceçõesToolStripMenuItem.Name = "ReceçõesToolStripMenuItem"
        Me.ReceçõesToolStripMenuItem.Size = New System.Drawing.Size(283, 36)
        Me.ReceçõesToolStripMenuItem.Text = "Receções"
        '
        'SeparaçõesToolStripMenuItem1
        '
        Me.SeparaçõesToolStripMenuItem1.Name = "SeparaçõesToolStripMenuItem1"
        Me.SeparaçõesToolStripMenuItem1.Size = New System.Drawing.Size(283, 36)
        Me.SeparaçõesToolStripMenuItem1.Text = "Separações"
        '
        'PreçosToolStripMenuItem
        '
        Me.PreçosToolStripMenuItem.Name = "PreçosToolStripMenuItem"
        Me.PreçosToolStripMenuItem.Size = New System.Drawing.Size(283, 36)
        Me.PreçosToolStripMenuItem.Text = "Tabelas Preços"
        '
        'EtiquetasToolStripMenuItem
        '
        Me.EtiquetasToolStripMenuItem.Name = "EtiquetasToolStripMenuItem"
        Me.EtiquetasToolStripMenuItem.Size = New System.Drawing.Size(283, 36)
        Me.EtiquetasToolStripMenuItem.Text = "Etiquetas"
        '
        'MenuComissões
        '
        Me.MenuComissões.Name = "MenuComissões"
        Me.MenuComissões.Size = New System.Drawing.Size(283, 36)
        Me.MenuComissões.Text = "Comissões"
        '
        'TestarGavetaToolStripMenuItem
        '
        Me.TestarGavetaToolStripMenuItem.Name = "TestarGavetaToolStripMenuItem"
        Me.TestarGavetaToolStripMenuItem.Size = New System.Drawing.Size(283, 36)
        Me.TestarGavetaToolStripMenuItem.Text = "Testar Gaveta"
        Me.TestarGavetaToolStripMenuItem.Visible = False
        '
        'mFechar
        '
        Me.mFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Italic)
        Me.mFechar.Name = "mFechar"
        Me.mFechar.Size = New System.Drawing.Size(111, 35)
        Me.mFechar.Text = "Fechar"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 502)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1712, 27)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        Me.StatusStrip1.Visible = False
        '
        'StatusStrip2
        '
        Me.StatusStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 507)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip2.Size = New System.Drawing.Size(1712, 22)
        Me.StatusStrip2.TabIndex = 4
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'frmMenuPos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1712, 529)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStripPos)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStripPos
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuPos"
        Me.Text = "POS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStripPos.ResumeLayout(False)
        Me.MenuStripPos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStripPos As System.Windows.Forms.MenuStrip
    Friend WithEvents mConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mDocs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smGT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smFS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mVendas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents smFX As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MovimentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReceçõesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeparaçõesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreçosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smRV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smNC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mFechar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EtiquetasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuComissões As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents TestarGavetaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smFT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smVC As ToolStripMenuItem
End Class
