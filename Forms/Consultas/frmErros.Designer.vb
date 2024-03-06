<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErros
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmErros))
        Me.EventosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.EventosDataGridView = New System.Windows.Forms.DataGridView()
        Me.EventoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EventoDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Artigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtRegisto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EventosTableAdapter = New GirlRootName.GirlDataSetTableAdapters.EventosTableAdapter()
        Me.EventosBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.EventosBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        CType(Me.EventosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventosDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventosBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EventosBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'EventosBindingSource
        '
        Me.EventosBindingSource.DataMember = "Eventos"
        Me.EventosBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EventosDataGridView
        '
        Me.EventosDataGridView.AllowUserToAddRows = False
        Me.EventosDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EventosDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.EventosDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EventoID, Me.EventoDescr, Me.Descr1, Me.Artigo, Me.Descr2, Me.Descr3, Me.DtRegisto})
        Me.EventosDataGridView.DataSource = Me.EventosBindingSource
        Me.EventosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EventosDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.EventosDataGridView.Name = "EventosDataGridView"
        Me.EventosDataGridView.Size = New System.Drawing.Size(928, 527)
        Me.EventosDataGridView.TabIndex = 1
        '
        'EventoID
        '
        Me.EventoID.DataPropertyName = "EventoID"
        Me.EventoID.HeaderText = "Erro"
        Me.EventoID.Name = "EventoID"
        Me.EventoID.ReadOnly = True
        '
        'EventoDescr
        '
        Me.EventoDescr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EventoDescr.DataPropertyName = "EventoDescr"
        Me.EventoDescr.HeaderText = "Descrição"
        Me.EventoDescr.Name = "EventoDescr"
        Me.EventoDescr.Width = 114
        '
        'Descr1
        '
        Me.Descr1.DataPropertyName = "Descr1"
        Me.Descr1.HeaderText = "Local"
        Me.Descr1.Name = "Descr1"
        '
        'Artigo
        '
        Me.Artigo.DataPropertyName = "Artigo"
        Me.Artigo.HeaderText = "Artigo"
        Me.Artigo.Name = "Artigo"
        '
        'Descr2
        '
        Me.Descr2.DataPropertyName = "Descr2"
        Me.Descr2.HeaderText = "Talão"
        Me.Descr2.Name = "Descr2"
        '
        'Descr3
        '
        Me.Descr3.DataPropertyName = "Descr3"
        Me.Descr3.HeaderText = "Estado"
        Me.Descr3.Name = "Descr3"
        '
        'DtRegisto
        '
        Me.DtRegisto.DataPropertyName = "DtRegisto"
        Me.DtRegisto.HeaderText = "Data"
        Me.DtRegisto.Name = "DtRegisto"
        Me.DtRegisto.ReadOnly = True
        '
        'EventosTableAdapter
        '
        Me.EventosTableAdapter.ClearBeforeFill = True
        '
        'EventosBindingNavigator
        '
        Me.EventosBindingNavigator.AddNewItem = Nothing
        Me.EventosBindingNavigator.BindingSource = Me.EventosBindingSource
        Me.EventosBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.EventosBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.EventosBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EventosBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorDeleteItem, Me.EventosBindingNavigatorSaveItem})
        Me.EventosBindingNavigator.Location = New System.Drawing.Point(0, 410)
        Me.EventosBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.EventosBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.EventosBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.EventosBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.EventosBindingNavigator.Name = "EventosBindingNavigator"
        Me.EventosBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.EventosBindingNavigator.Size = New System.Drawing.Size(928, 25)
        Me.EventosBindingNavigator.TabIndex = 2
        Me.EventosBindingNavigator.Text = "BindingNavigator1"
        Me.EventosBindingNavigator.Visible = False
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(45, 22)
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
        'EventosBindingNavigatorSaveItem
        '
        Me.EventosBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EventosBindingNavigatorSaveItem.Image = CType(resources.GetObject("EventosBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.EventosBindingNavigatorSaveItem.Name = "EventosBindingNavigatorSaveItem"
        Me.EventosBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.EventosBindingNavigatorSaveItem.Text = "Save Data"
        '
        'frmErros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 527)
        Me.Controls.Add(Me.EventosBindingNavigator)
        Me.Controls.Add(Me.EventosDataGridView)
        Me.Name = "frmErros"
        Me.Text = "frmErros"
        CType(Me.EventosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventosDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventosBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EventosBindingNavigator.ResumeLayout(False)
        Me.EventosBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents EventosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EventosTableAdapter As GirlRootName.GirlDataSetTableAdapters.EventosTableAdapter
    Friend WithEvents EventosDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents EventosBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents EventosBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents EventoID As DataGridViewTextBoxColumn
    Friend WithEvents EventoDescr As DataGridViewTextBoxColumn
    Friend WithEvents Descr1 As DataGridViewTextBoxColumn
    Friend WithEvents Artigo As DataGridViewTextBoxColumn
    Friend WithEvents Descr2 As DataGridViewTextBoxColumn
    Friend WithEvents Descr3 As DataGridViewTextBoxColumn
    Friend WithEvents DtRegisto As DataGridViewTextBoxColumn
End Class
