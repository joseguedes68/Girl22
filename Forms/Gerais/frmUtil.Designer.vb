<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUtil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUtil))
        Me.UtilizadoresBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.UtilizadoresBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.btSair = New System.Windows.Forms.ToolStripButton()
        Me.UtilizadoresDataGridView = New System.Windows.Forms.DataGridView()
        Me.UtilizadoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.UtilizadoresTableAdapter = New GirlRootName.GirlDataSetTableAdapters.UtilizadoresTableAdapter()
        Me.UtilizadorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeUtilizador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UtilWindows = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrupoAcesso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArmazemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PassWord = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NovaPassWord = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.UtilizadoresBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UtilizadoresBindingNavigator.SuspendLayout()
        CType(Me.UtilizadoresDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UtilizadoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UtilizadoresBindingNavigator
        '
        Me.UtilizadoresBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.UtilizadoresBindingNavigator.BindingSource = Me.UtilizadoresBindingSource
        Me.UtilizadoresBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.UtilizadoresBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.UtilizadoresBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.UtilizadoresBindingNavigatorSaveItem, Me.btSair})
        Me.UtilizadoresBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.UtilizadoresBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.UtilizadoresBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.UtilizadoresBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.UtilizadoresBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.UtilizadoresBindingNavigator.Name = "UtilizadoresBindingNavigator"
        Me.UtilizadoresBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.UtilizadoresBindingNavigator.Size = New System.Drawing.Size(865, 25)
        Me.UtilizadoresBindingNavigator.TabIndex = 0
        Me.UtilizadoresBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'UtilizadoresBindingNavigatorSaveItem
        '
        Me.UtilizadoresBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UtilizadoresBindingNavigatorSaveItem.Image = CType(resources.GetObject("UtilizadoresBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.UtilizadoresBindingNavigatorSaveItem.Name = "UtilizadoresBindingNavigatorSaveItem"
        Me.UtilizadoresBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.UtilizadoresBindingNavigatorSaveItem.Text = "Save Data"
        '
        'btSair
        '
        Me.btSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btSair.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(32, 22)
        Me.btSair.Text = "Sair"
        '
        'UtilizadoresDataGridView
        '
        Me.UtilizadoresDataGridView.AutoGenerateColumns = False
        Me.UtilizadoresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UtilizadoresDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UtilizadorID, Me.NomeUtilizador, Me.UtilWindows, Me.GrupoAcesso, Me.ArmazemID, Me.PassWord, Me.NovaPassWord})
        Me.UtilizadoresDataGridView.DataSource = Me.UtilizadoresBindingSource
        Me.UtilizadoresDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UtilizadoresDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.UtilizadoresDataGridView.Name = "UtilizadoresDataGridView"
        Me.UtilizadoresDataGridView.Size = New System.Drawing.Size(865, 387)
        Me.UtilizadoresDataGridView.TabIndex = 1
        '
        'UtilizadoresBindingSource
        '
        Me.UtilizadoresBindingSource.DataMember = "Utilizadores"
        Me.UtilizadoresBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UtilizadoresTableAdapter
        '
        Me.UtilizadoresTableAdapter.ClearBeforeFill = True
        '
        'UtilizadorID
        '
        Me.UtilizadorID.DataPropertyName = "UtilizadorID"
        Me.UtilizadorID.HeaderText = "Utilizador"
        Me.UtilizadorID.Name = "UtilizadorID"
        '
        'NomeUtilizador
        '
        Me.NomeUtilizador.DataPropertyName = "NomeUtilizador"
        Me.NomeUtilizador.HeaderText = "Nome"
        Me.NomeUtilizador.Name = "NomeUtilizador"
        '
        'UtilWindows
        '
        Me.UtilWindows.DataPropertyName = "UtilWindows"
        Me.UtilWindows.HeaderText = "UtilWindows"
        Me.UtilWindows.Name = "UtilWindows"
        '
        'GrupoAcesso
        '
        Me.GrupoAcesso.DataPropertyName = "GrupoAcesso"
        Me.GrupoAcesso.HeaderText = "GrupoAcesso"
        Me.GrupoAcesso.Name = "GrupoAcesso"
        '
        'ArmazemID
        '
        Me.ArmazemID.DataPropertyName = "ArmazemID"
        Me.ArmazemID.HeaderText = "Armazem"
        Me.ArmazemID.Name = "ArmazemID"
        '
        'PassWord
        '
        Me.PassWord.DataPropertyName = "PassWord"
        Me.PassWord.HeaderText = "PassWord"
        Me.PassWord.Name = "PassWord"
        Me.PassWord.Visible = False
        '
        'NovaPassWord
        '
        Me.NovaPassWord.DataPropertyName = "NovaPassWord"
        Me.NovaPassWord.HeaderText = "NovaPassWord"
        Me.NovaPassWord.Name = "NovaPassWord"
        '
        'frmUtil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 412)
        Me.Controls.Add(Me.UtilizadoresDataGridView)
        Me.Controls.Add(Me.UtilizadoresBindingNavigator)
        Me.Name = "frmUtil"
        Me.Text = "frmUtil"
        CType(Me.UtilizadoresBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UtilizadoresBindingNavigator.ResumeLayout(False)
        Me.UtilizadoresBindingNavigator.PerformLayout()
        CType(Me.UtilizadoresDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UtilizadoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents UtilizadoresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UtilizadoresTableAdapter As GirlRootName.GirlDataSetTableAdapters.UtilizadoresTableAdapter
    Friend WithEvents UtilizadoresBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UtilizadoresBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents UtilizadoresDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents UtilizadorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeUtilizador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UtilWindows As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrupoAcesso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArmazemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PassWord As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NovaPassWord As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
