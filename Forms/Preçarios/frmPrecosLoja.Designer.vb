<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrecosLoja
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrecosLoja))
        Me.GirlDataSet = New GirlRootName.GirlDataSet
        Me.TabPrecosLojaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPrecosLojaTableAdapter = New GirlRootName.GirlDataSetTableAdapters.TabPrecosLojaTableAdapter
        Me.TabPrecosLojaBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TabPrecosLojaBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.TabPrecosLojaDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ArmazensBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ArmazensTableAdapter = New GirlRootName.GirlDataSetTableAdapters.ArmazensTableAdapter
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabPrecosLojaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabPrecosLojaBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPrecosLojaBindingNavigator.SuspendLayout()
        CType(Me.TabPrecosLojaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TabPrecosLojaBindingSource
        '
        Me.TabPrecosLojaBindingSource.DataMember = "TabPrecosLoja"
        Me.TabPrecosLojaBindingSource.DataSource = Me.GirlDataSet
        '
        'TabPrecosLojaTableAdapter
        '
        Me.TabPrecosLojaTableAdapter.ClearBeforeFill = True
        '
        'TabPrecosLojaBindingNavigator
        '
        Me.TabPrecosLojaBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.TabPrecosLojaBindingNavigator.BindingSource = Me.TabPrecosLojaBindingSource
        Me.TabPrecosLojaBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TabPrecosLojaBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.TabPrecosLojaBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TabPrecosLojaBindingNavigatorSaveItem})
        Me.TabPrecosLojaBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TabPrecosLojaBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TabPrecosLojaBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TabPrecosLojaBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TabPrecosLojaBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TabPrecosLojaBindingNavigator.Name = "TabPrecosLojaBindingNavigator"
        Me.TabPrecosLojaBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TabPrecosLojaBindingNavigator.Size = New System.Drawing.Size(470, 25)
        Me.TabPrecosLojaBindingNavigator.TabIndex = 0
        Me.TabPrecosLojaBindingNavigator.Text = "BindingNavigator1"
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
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
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
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
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
        'TabPrecosLojaBindingNavigatorSaveItem
        '
        Me.TabPrecosLojaBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TabPrecosLojaBindingNavigatorSaveItem.Image = CType(resources.GetObject("TabPrecosLojaBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.TabPrecosLojaBindingNavigatorSaveItem.Name = "TabPrecosLojaBindingNavigatorSaveItem"
        Me.TabPrecosLojaBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.TabPrecosLojaBindingNavigatorSaveItem.Text = "Save Data"
        '
        'TabPrecosLojaDataGridView
        '
        Me.TabPrecosLojaDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabPrecosLojaDataGridView.AutoGenerateColumns = False
        Me.TabPrecosLojaDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewCheckBoxColumn1})
        Me.TabPrecosLojaDataGridView.DataSource = Me.TabPrecosLojaBindingSource
        Me.TabPrecosLojaDataGridView.Location = New System.Drawing.Point(0, 28)
        Me.TabPrecosLojaDataGridView.Name = "TabPrecosLojaDataGridView"
        Me.TabPrecosLojaDataGridView.Size = New System.Drawing.Size(470, 328)
        Me.TabPrecosLojaDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ArmazemID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Armazem"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "TabPrecoID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Tabela"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Visivel"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Visivel"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'ArmazensBindingSource
        '
        Me.ArmazensBindingSource.DataMember = "Armazens"
        Me.ArmazensBindingSource.DataSource = Me.GirlDataSet
        '
        'ArmazensTableAdapter
        '
        Me.ArmazensTableAdapter.ClearBeforeFill = True
        '
        'frmPrecosLoja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 356)
        Me.Controls.Add(Me.TabPrecosLojaDataGridView)
        Me.Controls.Add(Me.TabPrecosLojaBindingNavigator)
        Me.Name = "frmPrecosLoja"
        Me.Text = "frmPrecosLoja"
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabPrecosLojaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabPrecosLojaBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPrecosLojaBindingNavigator.ResumeLayout(False)
        Me.TabPrecosLojaBindingNavigator.PerformLayout()
        CType(Me.TabPrecosLojaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArmazensBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents TabPrecosLojaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TabPrecosLojaTableAdapter As GirlRootName.GirlDataSetTableAdapters.TabPrecosLojaTableAdapter
    Friend WithEvents TabPrecosLojaBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents TabPrecosLojaBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPrecosLojaDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ArmazensBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ArmazensTableAdapter As GirlRootName.GirlDataSetTableAdapters.ArmazensTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
