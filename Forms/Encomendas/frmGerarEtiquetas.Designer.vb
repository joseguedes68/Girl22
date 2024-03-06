<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGerarEtiquetas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btGerar = New System.Windows.Forms.Button()
        Me.tbModelo = New System.Windows.Forms.TextBox()
        Me.tbCor = New System.Windows.Forms.TextBox()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.dgvDetTam = New System.Windows.Forms.DataGridView()
        Me.gbTamanhos = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbProductCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbDescrProduct = New System.Windows.Forms.Label()
        Me.btCancelar = New System.Windows.Forms.Button()
        CType(Me.dgvDetTam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTamanhos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Modelo:"
        '
        'btGerar
        '
        Me.btGerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btGerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGerar.Location = New System.Drawing.Point(655, 120)
        Me.btGerar.Name = "btGerar"
        Me.btGerar.Size = New System.Drawing.Size(118, 43)
        Me.btGerar.TabIndex = 3
        Me.btGerar.TabStop = False
        Me.btGerar.Text = "Gerar"
        Me.btGerar.UseVisualStyleBackColor = False
        '
        'tbModelo
        '
        Me.tbModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModelo.Location = New System.Drawing.Point(90, 56)
        Me.tbModelo.Name = "tbModelo"
        Me.tbModelo.Size = New System.Drawing.Size(157, 22)
        Me.tbModelo.TabIndex = 1
        '
        'tbCor
        '
        Me.tbCor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCor.Location = New System.Drawing.Point(299, 56)
        Me.tbCor.Name = "tbCor"
        Me.tbCor.Size = New System.Drawing.Size(52, 22)
        Me.tbCor.TabIndex = 2
        '
        'btFechar
        '
        Me.btFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFechar.Location = New System.Drawing.Point(655, 15)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(118, 43)
        Me.btFechar.TabIndex = 6
        Me.btFechar.TabStop = False
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'dgvDetTam
        '
        Me.dgvDetTam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetTam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetTam.Location = New System.Drawing.Point(3, 18)
        Me.dgvDetTam.Name = "dgvDetTam"
        Me.dgvDetTam.Size = New System.Drawing.Size(791, 96)
        Me.dgvDetTam.TabIndex = 0
        '
        'gbTamanhos
        '
        Me.gbTamanhos.Controls.Add(Me.dgvDetTam)
        Me.gbTamanhos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbTamanhos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTamanhos.Location = New System.Drawing.Point(0, 169)
        Me.gbTamanhos.Name = "gbTamanhos"
        Me.gbTamanhos.Size = New System.Drawing.Size(797, 117)
        Me.gbTamanhos.TabIndex = 16
        Me.gbTamanhos.TabStop = False
        Me.gbTamanhos.Text = "Tamanhos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(257, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Código do Produto :"
        '
        'tbProductCode
        '
        Me.tbProductCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbProductCode.Location = New System.Drawing.Point(171, 12)
        Me.tbProductCode.Name = "tbProductCode"
        Me.tbProductCode.Size = New System.Drawing.Size(76, 22)
        Me.tbProductCode.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(400, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Depois de Lançar o modelo cor, vai buscar o preço e outros elementos necessários"
        Me.Label4.Visible = False
        '
        'lbDescrProduct
        '
        Me.lbDescrProduct.AutoSize = True
        Me.lbDescrProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lbDescrProduct.Location = New System.Drawing.Point(257, 15)
        Me.lbDescrProduct.Name = "lbDescrProduct"
        Me.lbDescrProduct.Size = New System.Drawing.Size(79, 16)
        Me.lbDescrProduct.TabIndex = 24
        Me.lbDescrProduct.Text = "Descrição"
        '
        'btCancelar
        '
        Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancelar.Location = New System.Drawing.Point(655, 67)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(118, 43)
        Me.btCancelar.TabIndex = 25
        Me.btCancelar.TabStop = False
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'frmGerarEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 286)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.lbDescrProduct)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbProductCode)
        Me.Controls.Add(Me.gbTamanhos)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.tbCor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btGerar)
        Me.Controls.Add(Me.tbModelo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmGerarEtiquetas"
        Me.Text = "frmGerarEtiquetas"
        CType(Me.dgvDetTam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTamanhos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btGerar As System.Windows.Forms.Button
    Friend WithEvents tbModelo As System.Windows.Forms.TextBox
    Friend WithEvents tbCor As System.Windows.Forms.TextBox
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents dgvDetTam As System.Windows.Forms.DataGridView
    Friend WithEvents gbTamanhos As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbDescrProduct As System.Windows.Forms.Label
    Friend WithEvents btCancelar As System.Windows.Forms.Button
End Class
