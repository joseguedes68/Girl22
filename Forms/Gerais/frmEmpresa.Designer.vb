<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpresa
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
        Dim EmpresaIDLabel As System.Windows.Forms.Label
        Dim EmpNomeLabel As System.Windows.Forms.Label
        Dim EmpDesignaLabel As System.Windows.Forms.Label
        Dim EmpContribLabel As System.Windows.Forms.Label
        Dim EmpCapSocialLabel As System.Windows.Forms.Label
        Dim EmpNrRegistoLabel As System.Windows.Forms.Label
        Dim EmpMoradaLabel As System.Windows.Forms.Label
        Dim EmpCodPostalLabel As System.Windows.Forms.Label
        Dim EmpLocalidadeLabel As System.Windows.Forms.Label
        Dim EmpTelefoneLabel As System.Windows.Forms.Label
        Dim EmpFaxLabel As System.Windows.Forms.Label
        Dim EmpLogoLabel As System.Windows.Forms.Label
        Dim EmpMarcaLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpresa))
        Dim Label1 As System.Windows.Forms.Label
        Me.EmpresasBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.EmpresasBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.EmpresaIDTextBox = New System.Windows.Forms.TextBox()
        Me.EmpNomeTextBox = New System.Windows.Forms.TextBox()
        Me.EmpDesignaTextBox = New System.Windows.Forms.TextBox()
        Me.EmpContribTextBox = New System.Windows.Forms.TextBox()
        Me.EmpCapSocialTextBox = New System.Windows.Forms.TextBox()
        Me.EmpNrRegistoTextBox = New System.Windows.Forms.TextBox()
        Me.EmpMoradaTextBox = New System.Windows.Forms.TextBox()
        Me.EmpCodPostalTextBox = New System.Windows.Forms.TextBox()
        Me.EmpLocalidadeTextBox = New System.Windows.Forms.TextBox()
        Me.EmpTelefoneTextBox = New System.Windows.Forms.TextBox()
        Me.EmpFaxTextBox = New System.Windows.Forms.TextBox()
        Me.EmpLogoTextBox = New System.Windows.Forms.TextBox()
        Me.EmpMarcaTextBox = New System.Windows.Forms.TextBox()
        Me.lbVersao = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbBloquear = New System.Windows.Forms.CheckBox()
        Me.cbImp = New System.Windows.Forms.CheckBox()
        Me.cbVar1 = New System.Windows.Forms.CheckBox()
        Me.cbVar2 = New System.Windows.Forms.CheckBox()
        Me.cbVar3 = New System.Windows.Forms.CheckBox()
        Me.cbVar4 = New System.Windows.Forms.CheckBox()
        Me.tbNIB = New System.Windows.Forms.TextBox()
        Me.EmpresasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GirlDataSet = New GirlRootName.GirlDataSet()
        Me.EmpresasTableAdapter = New GirlRootName.GirlDataSetTableAdapters.EmpresasTableAdapter()
        EmpresaIDLabel = New System.Windows.Forms.Label()
        EmpNomeLabel = New System.Windows.Forms.Label()
        EmpDesignaLabel = New System.Windows.Forms.Label()
        EmpContribLabel = New System.Windows.Forms.Label()
        EmpCapSocialLabel = New System.Windows.Forms.Label()
        EmpNrRegistoLabel = New System.Windows.Forms.Label()
        EmpMoradaLabel = New System.Windows.Forms.Label()
        EmpCodPostalLabel = New System.Windows.Forms.Label()
        EmpLocalidadeLabel = New System.Windows.Forms.Label()
        EmpTelefoneLabel = New System.Windows.Forms.Label()
        EmpFaxLabel = New System.Windows.Forms.Label()
        EmpLogoLabel = New System.Windows.Forms.Label()
        EmpMarcaLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        CType(Me.EmpresasBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpresasBindingNavigator.SuspendLayout()
        CType(Me.EmpresasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmpresaIDLabel
        '
        EmpresaIDLabel.AutoSize = True
        EmpresaIDLabel.Location = New System.Drawing.Point(119, 63)
        EmpresaIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpresaIDLabel.Name = "EmpresaIDLabel"
        EmpresaIDLabel.Size = New System.Drawing.Size(68, 17)
        EmpresaIDLabel.TabIndex = 1
        EmpresaIDLabel.Text = "Empresa:"
        EmpresaIDLabel.Visible = False
        '
        'EmpNomeLabel
        '
        EmpNomeLabel.AutoSize = True
        EmpNomeLabel.Location = New System.Drawing.Point(136, 95)
        EmpNomeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpNomeLabel.Name = "EmpNomeLabel"
        EmpNomeLabel.Size = New System.Drawing.Size(49, 17)
        EmpNomeLabel.TabIndex = 3
        EmpNomeLabel.Text = "Nome:"
        '
        'EmpDesignaLabel
        '
        EmpDesignaLabel.AutoSize = True
        EmpDesignaLabel.Location = New System.Drawing.Point(101, 127)
        EmpDesignaLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpDesignaLabel.Name = "EmpDesignaLabel"
        EmpDesignaLabel.Size = New System.Drawing.Size(83, 17)
        EmpDesignaLabel.TabIndex = 5
        EmpDesignaLabel.Text = "Designação"
        '
        'EmpContribLabel
        '
        EmpContribLabel.AutoSize = True
        EmpContribLabel.Location = New System.Drawing.Point(103, 159)
        EmpContribLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpContribLabel.Name = "EmpContribLabel"
        EmpContribLabel.Size = New System.Drawing.Size(84, 17)
        EmpContribLabel.TabIndex = 7
        EmpContribLabel.Text = "Contribuinte"
        '
        'EmpCapSocialLabel
        '
        EmpCapSocialLabel.AutoSize = True
        EmpCapSocialLabel.Location = New System.Drawing.Point(92, 191)
        EmpCapSocialLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpCapSocialLabel.Name = "EmpCapSocialLabel"
        EmpCapSocialLabel.Size = New System.Drawing.Size(93, 17)
        EmpCapSocialLabel.TabIndex = 9
        EmpCapSocialLabel.Text = "Capital Social"
        '
        'EmpNrRegistoLabel
        '
        EmpNrRegistoLabel.AutoSize = True
        EmpNrRegistoLabel.Location = New System.Drawing.Point(111, 223)
        EmpNrRegistoLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpNrRegistoLabel.Name = "EmpNrRegistoLabel"
        EmpNrRegistoLabel.Size = New System.Drawing.Size(75, 17)
        EmpNrRegistoLabel.TabIndex = 11
        EmpNrRegistoLabel.Text = "Nr Registo"
        '
        'EmpMoradaLabel
        '
        EmpMoradaLabel.AutoSize = True
        EmpMoradaLabel.Location = New System.Drawing.Point(129, 255)
        EmpMoradaLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpMoradaLabel.Name = "EmpMoradaLabel"
        EmpMoradaLabel.Size = New System.Drawing.Size(56, 17)
        EmpMoradaLabel.TabIndex = 13
        EmpMoradaLabel.Text = "Morada"
        '
        'EmpCodPostalLabel
        '
        EmpCodPostalLabel.AutoSize = True
        EmpCodPostalLabel.Location = New System.Drawing.Point(109, 287)
        EmpCodPostalLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpCodPostalLabel.Name = "EmpCodPostalLabel"
        EmpCodPostalLabel.Size = New System.Drawing.Size(76, 17)
        EmpCodPostalLabel.TabIndex = 15
        EmpCodPostalLabel.Text = "Cod Postal"
        '
        'EmpLocalidadeLabel
        '
        EmpLocalidadeLabel.AutoSize = True
        EmpLocalidadeLabel.Location = New System.Drawing.Point(108, 319)
        EmpLocalidadeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpLocalidadeLabel.Name = "EmpLocalidadeLabel"
        EmpLocalidadeLabel.Size = New System.Drawing.Size(77, 17)
        EmpLocalidadeLabel.TabIndex = 17
        EmpLocalidadeLabel.Text = "Localidade"
        '
        'EmpTelefoneLabel
        '
        EmpTelefoneLabel.AutoSize = True
        EmpTelefoneLabel.Location = New System.Drawing.Point(121, 351)
        EmpTelefoneLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpTelefoneLabel.Name = "EmpTelefoneLabel"
        EmpTelefoneLabel.Size = New System.Drawing.Size(64, 17)
        EmpTelefoneLabel.TabIndex = 19
        EmpTelefoneLabel.Text = "Telefone"
        '
        'EmpFaxLabel
        '
        EmpFaxLabel.AutoSize = True
        EmpFaxLabel.Location = New System.Drawing.Point(155, 383)
        EmpFaxLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpFaxLabel.Name = "EmpFaxLabel"
        EmpFaxLabel.Size = New System.Drawing.Size(30, 17)
        EmpFaxLabel.TabIndex = 21
        EmpFaxLabel.Text = "Fax"
        '
        'EmpLogoLabel
        '
        EmpLogoLabel.AutoSize = True
        EmpLogoLabel.Location = New System.Drawing.Point(145, 415)
        EmpLogoLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpLogoLabel.Name = "EmpLogoLabel"
        EmpLogoLabel.Size = New System.Drawing.Size(40, 17)
        EmpLogoLabel.TabIndex = 23
        EmpLogoLabel.Text = "Logo"
        '
        'EmpMarcaLabel
        '
        EmpMarcaLabel.AutoSize = True
        EmpMarcaLabel.Location = New System.Drawing.Point(137, 447)
        EmpMarcaLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmpMarcaLabel.Name = "EmpMarcaLabel"
        EmpMarcaLabel.Size = New System.Drawing.Size(47, 17)
        EmpMarcaLabel.TabIndex = 25
        EmpMarcaLabel.Text = "Marca"
        '
        'EmpresasBindingNavigator
        '
        Me.EmpresasBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.EmpresasBindingNavigator.BindingSource = Me.EmpresasBindingSource
        Me.EmpresasBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.EmpresasBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.EmpresasBindingNavigator.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.EmpresasBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.EmpresasBindingNavigatorSaveItem})
        Me.EmpresasBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.EmpresasBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.EmpresasBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.EmpresasBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.EmpresasBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.EmpresasBindingNavigator.Name = "EmpresasBindingNavigator"
        Me.EmpresasBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.EmpresasBindingNavigator.Size = New System.Drawing.Size(881, 31)
        Me.EmpresasBindingNavigator.TabIndex = 0
        Me.EmpresasBindingNavigator.Text = "BindingNavigator1"
        Me.EmpresasBindingNavigator.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(24, 28)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(56, 28)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(24, 28)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(24, 28)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(24, 28)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 31)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(65, 31)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(24, 28)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(24, 28)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'EmpresasBindingNavigatorSaveItem
        '
        Me.EmpresasBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EmpresasBindingNavigatorSaveItem.Image = CType(resources.GetObject("EmpresasBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.EmpresasBindingNavigatorSaveItem.Name = "EmpresasBindingNavigatorSaveItem"
        Me.EmpresasBindingNavigatorSaveItem.Size = New System.Drawing.Size(24, 28)
        Me.EmpresasBindingNavigatorSaveItem.Text = "Save Data"
        '
        'EmpresaIDTextBox
        '
        Me.EmpresaIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpresaID", True))
        Me.EmpresaIDTextBox.Location = New System.Drawing.Point(200, 59)
        Me.EmpresaIDTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpresaIDTextBox.Name = "EmpresaIDTextBox"
        Me.EmpresaIDTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpresaIDTextBox.TabIndex = 2
        Me.EmpresaIDTextBox.Visible = False
        '
        'EmpNomeTextBox
        '
        Me.EmpNomeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpNome", True))
        Me.EmpNomeTextBox.Location = New System.Drawing.Point(200, 91)
        Me.EmpNomeTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpNomeTextBox.Name = "EmpNomeTextBox"
        Me.EmpNomeTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpNomeTextBox.TabIndex = 4
        '
        'EmpDesignaTextBox
        '
        Me.EmpDesignaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpDesigna", True))
        Me.EmpDesignaTextBox.Location = New System.Drawing.Point(200, 123)
        Me.EmpDesignaTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpDesignaTextBox.Name = "EmpDesignaTextBox"
        Me.EmpDesignaTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpDesignaTextBox.TabIndex = 6
        '
        'EmpContribTextBox
        '
        Me.EmpContribTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpContrib", True))
        Me.EmpContribTextBox.Location = New System.Drawing.Point(200, 155)
        Me.EmpContribTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpContribTextBox.Name = "EmpContribTextBox"
        Me.EmpContribTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpContribTextBox.TabIndex = 8
        '
        'EmpCapSocialTextBox
        '
        Me.EmpCapSocialTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpCapSocial", True))
        Me.EmpCapSocialTextBox.Location = New System.Drawing.Point(200, 187)
        Me.EmpCapSocialTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpCapSocialTextBox.Name = "EmpCapSocialTextBox"
        Me.EmpCapSocialTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpCapSocialTextBox.TabIndex = 10
        '
        'EmpNrRegistoTextBox
        '
        Me.EmpNrRegistoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpNrRegisto", True))
        Me.EmpNrRegistoTextBox.Location = New System.Drawing.Point(200, 219)
        Me.EmpNrRegistoTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpNrRegistoTextBox.Name = "EmpNrRegistoTextBox"
        Me.EmpNrRegistoTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpNrRegistoTextBox.TabIndex = 12
        '
        'EmpMoradaTextBox
        '
        Me.EmpMoradaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpMorada", True))
        Me.EmpMoradaTextBox.Location = New System.Drawing.Point(200, 251)
        Me.EmpMoradaTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpMoradaTextBox.Name = "EmpMoradaTextBox"
        Me.EmpMoradaTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpMoradaTextBox.TabIndex = 14
        '
        'EmpCodPostalTextBox
        '
        Me.EmpCodPostalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpCodPostal", True))
        Me.EmpCodPostalTextBox.Location = New System.Drawing.Point(200, 283)
        Me.EmpCodPostalTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpCodPostalTextBox.Name = "EmpCodPostalTextBox"
        Me.EmpCodPostalTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpCodPostalTextBox.TabIndex = 16
        '
        'EmpLocalidadeTextBox
        '
        Me.EmpLocalidadeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpLocalidade", True))
        Me.EmpLocalidadeTextBox.Location = New System.Drawing.Point(200, 315)
        Me.EmpLocalidadeTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpLocalidadeTextBox.Name = "EmpLocalidadeTextBox"
        Me.EmpLocalidadeTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpLocalidadeTextBox.TabIndex = 18
        '
        'EmpTelefoneTextBox
        '
        Me.EmpTelefoneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpTelefone", True))
        Me.EmpTelefoneTextBox.Location = New System.Drawing.Point(200, 347)
        Me.EmpTelefoneTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpTelefoneTextBox.Name = "EmpTelefoneTextBox"
        Me.EmpTelefoneTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpTelefoneTextBox.TabIndex = 20
        '
        'EmpFaxTextBox
        '
        Me.EmpFaxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpFax", True))
        Me.EmpFaxTextBox.Location = New System.Drawing.Point(200, 379)
        Me.EmpFaxTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpFaxTextBox.Name = "EmpFaxTextBox"
        Me.EmpFaxTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpFaxTextBox.TabIndex = 22
        '
        'EmpLogoTextBox
        '
        Me.EmpLogoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpLogo", True))
        Me.EmpLogoTextBox.Location = New System.Drawing.Point(200, 411)
        Me.EmpLogoTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpLogoTextBox.Name = "EmpLogoTextBox"
        Me.EmpLogoTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpLogoTextBox.TabIndex = 24
        '
        'EmpMarcaTextBox
        '
        Me.EmpMarcaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "EmpMarca", True))
        Me.EmpMarcaTextBox.Location = New System.Drawing.Point(200, 443)
        Me.EmpMarcaTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpMarcaTextBox.Name = "EmpMarcaTextBox"
        Me.EmpMarcaTextBox.Size = New System.Drawing.Size(452, 22)
        Me.EmpMarcaTextBox.TabIndex = 26
        '
        'lbVersao
        '
        Me.lbVersao.AutoSize = True
        Me.lbVersao.Location = New System.Drawing.Point(727, 500)
        Me.lbVersao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbVersao.Name = "lbVersao"
        Me.lbVersao.Size = New System.Drawing.Size(53, 17)
        Me.lbVersao.TabIndex = 27
        Me.lbVersao.Text = "Versão"
        Me.lbVersao.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(731, 78)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 49)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Gravar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(731, 15)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 48)
        Me.Button2.TabIndex = 29
        Me.Button2.Text = "Fechar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cbBloquear
        '
        Me.cbBloquear.AutoSize = True
        Me.cbBloquear.Location = New System.Drawing.Point(723, 443)
        Me.cbBloquear.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbBloquear.Name = "cbBloquear"
        Me.cbBloquear.Size = New System.Drawing.Size(87, 21)
        Me.cbBloquear.TabIndex = 30
        Me.cbBloquear.Text = "Bloquear"
        Me.cbBloquear.UseVisualStyleBackColor = True
        '
        'cbImp
        '
        Me.cbImp.AutoSize = True
        Me.cbImp.Location = New System.Drawing.Point(723, 414)
        Me.cbImp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbImp.Name = "cbImp"
        Me.cbImp.Size = New System.Drawing.Size(95, 21)
        Me.cbImp.TabIndex = 31
        Me.cbImp.Text = "Impressão"
        Me.cbImp.UseVisualStyleBackColor = True
        Me.cbImp.Visible = False
        '
        'cbVar1
        '
        Me.cbVar1.AutoSize = True
        Me.cbVar1.Location = New System.Drawing.Point(723, 223)
        Me.cbVar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbVar1.Name = "cbVar1"
        Me.cbVar1.Size = New System.Drawing.Size(66, 21)
        Me.cbVar1.TabIndex = 32
        Me.cbVar1.Text = "VAR1"
        Me.cbVar1.UseVisualStyleBackColor = True
        '
        'cbVar2
        '
        Me.cbVar2.AutoSize = True
        Me.cbVar2.Location = New System.Drawing.Point(723, 255)
        Me.cbVar2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbVar2.Name = "cbVar2"
        Me.cbVar2.Size = New System.Drawing.Size(66, 21)
        Me.cbVar2.TabIndex = 33
        Me.cbVar2.Text = "VAR2"
        Me.cbVar2.UseVisualStyleBackColor = True
        '
        'cbVar3
        '
        Me.cbVar3.AutoSize = True
        Me.cbVar3.Location = New System.Drawing.Point(723, 283)
        Me.cbVar3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbVar3.Name = "cbVar3"
        Me.cbVar3.Size = New System.Drawing.Size(66, 21)
        Me.cbVar3.TabIndex = 34
        Me.cbVar3.Text = "VAR3"
        Me.cbVar3.UseVisualStyleBackColor = True
        '
        'cbVar4
        '
        Me.cbVar4.AutoSize = True
        Me.cbVar4.Location = New System.Drawing.Point(723, 311)
        Me.cbVar4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbVar4.Name = "cbVar4"
        Me.cbVar4.Size = New System.Drawing.Size(66, 21)
        Me.cbVar4.TabIndex = 35
        Me.cbVar4.Text = "VAR4"
        Me.cbVar4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(137, 477)
        Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(30, 17)
        Label1.TabIndex = 36
        Label1.Text = "NIB"
        '
        'tbNIB
        '
        Me.tbNIB.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresasBindingSource, "Nib", True))
        Me.tbNIB.Location = New System.Drawing.Point(200, 473)
        Me.tbNIB.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNIB.Name = "tbNIB"
        Me.tbNIB.Size = New System.Drawing.Size(452, 22)
        Me.tbNIB.TabIndex = 37
        '
        'EmpresasBindingSource
        '
        Me.EmpresasBindingSource.DataMember = "Empresas"
        Me.EmpresasBindingSource.DataSource = Me.GirlDataSet
        '
        'GirlDataSet
        '
        Me.GirlDataSet.DataSetName = "GirlDataSet"
        Me.GirlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmpresasTableAdapter
        '
        Me.EmpresasTableAdapter.ClearBeforeFill = True
        '
        'frmEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(881, 527)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.tbNIB)
        Me.Controls.Add(Me.cbVar4)
        Me.Controls.Add(Me.cbVar3)
        Me.Controls.Add(Me.cbVar2)
        Me.Controls.Add(Me.cbVar1)
        Me.Controls.Add(Me.cbImp)
        Me.Controls.Add(Me.cbBloquear)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbVersao)
        Me.Controls.Add(EmpresaIDLabel)
        Me.Controls.Add(Me.EmpresaIDTextBox)
        Me.Controls.Add(EmpNomeLabel)
        Me.Controls.Add(Me.EmpNomeTextBox)
        Me.Controls.Add(EmpDesignaLabel)
        Me.Controls.Add(Me.EmpDesignaTextBox)
        Me.Controls.Add(EmpContribLabel)
        Me.Controls.Add(Me.EmpContribTextBox)
        Me.Controls.Add(EmpCapSocialLabel)
        Me.Controls.Add(Me.EmpCapSocialTextBox)
        Me.Controls.Add(EmpNrRegistoLabel)
        Me.Controls.Add(Me.EmpNrRegistoTextBox)
        Me.Controls.Add(EmpMoradaLabel)
        Me.Controls.Add(Me.EmpMoradaTextBox)
        Me.Controls.Add(EmpCodPostalLabel)
        Me.Controls.Add(Me.EmpCodPostalTextBox)
        Me.Controls.Add(EmpLocalidadeLabel)
        Me.Controls.Add(Me.EmpLocalidadeTextBox)
        Me.Controls.Add(EmpTelefoneLabel)
        Me.Controls.Add(Me.EmpTelefoneTextBox)
        Me.Controls.Add(EmpFaxLabel)
        Me.Controls.Add(Me.EmpFaxTextBox)
        Me.Controls.Add(EmpLogoLabel)
        Me.Controls.Add(Me.EmpLogoTextBox)
        Me.Controls.Add(EmpMarcaLabel)
        Me.Controls.Add(Me.EmpMarcaTextBox)
        Me.Controls.Add(Me.EmpresasBindingNavigator)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmEmpresa"
        Me.Text = "frmEmpresa"
        CType(Me.EmpresasBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpresasBindingNavigator.ResumeLayout(False)
        Me.EmpresasBindingNavigator.PerformLayout()
        CType(Me.EmpresasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GirlDataSet As GirlRootName.GirlDataSet
    Friend WithEvents EmpresasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmpresasTableAdapter As GirlRootName.GirlDataSetTableAdapters.EmpresasTableAdapter
    Friend WithEvents EmpresasBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents EmpresasBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents EmpresaIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpNomeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpDesignaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpContribTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpCapSocialTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpNrRegistoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpMoradaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpCodPostalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpLocalidadeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpTelefoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpFaxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpLogoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmpMarcaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lbVersao As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbBloquear As System.Windows.Forms.CheckBox
    Friend WithEvents cbImp As System.Windows.Forms.CheckBox
    Friend WithEvents cbVar1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbVar2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbVar3 As System.Windows.Forms.CheckBox
    Friend WithEvents cbVar4 As System.Windows.Forms.CheckBox
    Friend WithEvents tbNIB As TextBox
End Class
