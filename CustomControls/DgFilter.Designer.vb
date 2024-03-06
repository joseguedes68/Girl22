<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DgFilter
    Inherits System.Windows.Forms.Panel

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgFiltro As GirlRootName.GridView
    Friend WithEvents dgMovimentos As GirlRootName.GridView

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.dgFiltro = New GirlRootName.GridView
        Me.dgMovimentos = New GirlRootName.GridView
        Me.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMovimentos, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                            Or System.Windows.Forms.AnchorStyles.Left) _
                            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgFiltro, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgMovimentos, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dgFiltro
        '
        Me.dgFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFiltro.Location = New System.Drawing.Point(0, 0)
        Me.dgFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.dgFiltro.Name = "dgFiltro"
        Me.dgFiltro.TabIndex = 0
        '
        'dgMovimentos
        '
        Me.dgMovimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMovimentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMovimentos.Location = New System.Drawing.Point(0, 43)
        Me.dgMovimentos.Margin = New System.Windows.Forms.Padding(0)
        Me.dgMovimentos.Name = "dgMovimentos"
        Me.dgMovimentos.TabIndex = 1

        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(0)
    End Sub

End Class
