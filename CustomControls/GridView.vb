Public Class GridView

    Friend Enum ModoLeitura As Byte
        Sem_Qualquer_Tipo_Escrita = 0
        Com_Escrita_Delete_Sem_ADD = 1
    End Enum

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Dim fnt As New Font("Arial", 10, FontStyle.Regular)

    Friend Sub IniciarDG(ByVal ModoLeitura As GirlRootName.GridView.ModoLeitura, _
                     ByVal TipoSelecao As System.Windows.Forms.DataGridViewSelectionMode, _
                     ByVal SizeColumns As System.Windows.Forms.DataGridViewAutoSizeColumnsMode, _
                     Optional ByVal AllowUserToOrderColumns As Boolean = True, _
                     Optional ByVal DefaultFontSize As Integer = 10)
        IniciarDataGridView(DefaultFontSize)
        Me.TipoEscrita(ModoLeitura)
        Me.SelectionMode = TipoSelecao
        Me.AllowUserToOrderColumns = AllowUserToOrderColumns
        Me.AutoSizeColumnsMode = SizeColumns
    End Sub

    Friend Sub TipoEscrita(ByVal _ModoLeitura As GirlRootName.GridView.ModoLeitura)
        Select Case _ModoLeitura
            Case ModoLeitura.Sem_Qualquer_Tipo_Escrita
                SemQualquerTipoEscrita()
            Case ModoLeitura.Com_Escrita_Delete_Sem_ADD
                Com_Escrita_Delete_Sem_ADD()
        End Select
    End Sub

    Private Sub SemQualquerTipoEscrita()
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
        Me.ReadOnly = True
    End Sub

    Private Sub Com_Escrita_Delete_Sem_ADD()
        MyBase.AllowUserToAddRows = False
        MyBase.AllowUserToDeleteRows = True
        MyBase.ReadOnly = False
    End Sub

    Private Sub IniciarDataGridView(ByVal DefaultFontSize As Integer)
        Dim DefCellStyle As New DataGridViewCellStyle
        With DefCellStyle
            .BackColor = Color.LightYellow
            .Font = New Font("ARIAL", DefaultFontSize, FontStyle.Regular)
            .ForeColor = Color.Black
            .SelectionBackColor = Color.Yellow
            .SelectionForeColor = Color.Black
        End With
        Me.AlternatingRowsDefaultCellStyle = DefCellStyle
        DefCellStyle = New DataGridViewCellStyle
        With DefCellStyle
            .Font = New Font("ARIAL", DefaultFontSize, FontStyle.Regular)
            .SelectionBackColor = Color.Yellow
            .SelectionForeColor = Color.Black
        End With
        Me.DefaultCellStyle = DefCellStyle
        DefCellStyle = New DataGridViewCellStyle
        With DefCellStyle
            .Font = New Font("ARIAL", DefaultFontSize, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .BackColor = Color.FromName("Control")
        End With
        Me.ColumnHeadersDefaultCellStyle = DefCellStyle
        Me.RowHeadersDefaultCellStyle = DefCellStyle
    End Sub

    Private Sub GridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellClick
        Try
            Dim myControl As Control
            myControl = CType(sender, DataGridView)
            Dim pointer As System.Drawing.Point
            pointer = Me.CurrentCellAddress
            ct.Show(myControl, pointer)
            'Select Case Me.DataSource.GetType.Name
            '    Case "BindingSource"
            '        Dim bs As New BindingSource
            '        bs = Me.DataSource
            '        bs.Filter = "CodPostal = '3700'"
            '        Me.DataSource = bs
            '    Case "DataTable"
            '        Dim dt As DataTable
            '        Dim dv As DataView
            '        dt = Me.DataSource
            '        dv = dt.DefaultView
            '        Me.DataSource = dv
            '        dv.RowFilter = "CodPostal is null"
            'End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim ct As New System.Windows.Forms.ContextMenu

End Class
