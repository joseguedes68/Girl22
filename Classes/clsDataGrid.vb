Public Class clsDataGrid

    Implements IDisposable
    Private _dv As DataView
    Private _Bs As BindingSource
    Private _dg As DataGridView
    Private Sql As String
    Private disposedValue As Boolean = False        ' To detect redundant calls
    Private WithEvents _Frm As Form
    Private WithEvents _txt As TextBox
    Private WithEvents _cmd As Button
    Private _lbl As Label
    Private _Query As String = ""



    Public Sub New(ByVal DataGrid As DataGridView, Optional ByVal _DataView As DataView = Nothing, Optional ByVal _BindingSource As BindingSource = Nothing)
        _dg = DataGrid

        If Not _DataView Is Nothing Then
            _dv = _DataView
        End If
        If Not _BindingSource Is Nothing Then
            _Bs = _BindingSource
            If _dv IsNot Nothing Then _dv.Dispose()

        End If
    End Sub

#Region " IDisposable Support "
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ''TODO: free unmanaged resources when explicitly called
            End If

            ''TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

    Friend Property Frm(Optional ByVal ColunaText As String = Nothing) As Form
        Get
            If _Frm Is Nothing Then
                iniFrom(ColunaText)
            End If
            Return _Frm
        End Get
        Set(ByVal value As Form)
            _Frm = value
        End Set
    End Property

    Protected Sub iniFrom(ByVal ColunaText As String)
        _Frm = New Form
        _txt = New TextBox
        _lbl = New Label
        _cmd = New Button
        Try
            With _Frm
                '_dg.CurrentCell.Frozen
                'TODO: HR Tentar fazer com que o form abra junto da Cell

                With _lbl
                    .Text = ColunaText
                    .AutoSize = False
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Size = New Size(90, _txt.Size.Height)
                    .Location = New Point(10, 10)
                    .BorderStyle = BorderStyle.None
                    .TextAlign = ContentAlignment.MiddleCenter
                End With


                With _txt
                    .Location = New Point(_lbl.Location.X + _lbl.Width, _lbl.Location.Y)
                    .TextAlign = HorizontalAlignment.Center
                    .Focus()
                End With



                With _cmd
                    .Location = New Point(_lbl.Location.X + 10, _lbl.Location.Y + 90)
                    .Size = New Size(_lbl.Width + _txt.Width - 20, 20)
                    .FlatStyle = FlatStyle.Popup
                    .Text = "Remover Filtro"
                    .Name = "cmdRemoveFiltro"
                End With
                AddHandler _cmd.Click, AddressOf cmd_Click
                .Controls.Add(_cmd)
                _cmd = New Button

                With _cmd
                    .Location = New Point(_lbl.Location.X + 10, _lbl.Location.Y + 30)
                    .Size = New Size(_lbl.Width + _txt.Width - 20, 20)
                    .FlatStyle = FlatStyle.Popup
                    .Text = "Filtrar Selecção"
                    .Name = "cmdFiltroSeleccao"
                End With

                AddHandler _cmd.Click, AddressOf cmd_Click
                .Controls.Add(_cmd)
                _cmd = New Button



                With _cmd
                    .Location = New Point(_lbl.Location.X + 10, _lbl.Location.Y + 60)
                    .Size = New Size(_lbl.Width + _txt.Width - 20, 20)
                    .FlatStyle = FlatStyle.Popup
                    .Text = "Excluir Selecção"
                    .Name = "cmdExcluirSeleccao"
                End With






                AddHandler _cmd.Click, AddressOf cmd_Click
                .Controls.Add(_cmd)
                .BackColor = Color.FromName("PapayaWhip")
                .StartPosition = FormStartPosition.CenterScreen
                .FormBorderStyle = FormBorderStyle.FixedDialog
                .ControlBox = False
                '.AutoSizeMode = AutoSizeMode.GrowAndShrink
                '.AutoSize = True
                .Controls.Add(_txt)
                .Controls.Add(_lbl)
                .Size = New Size(215, 150)

            End With
        Catch ex As Exception
            ErroVB(ex.Message, "clsDataGrid: iniFrom")
        Finally
        End Try
    End Sub

    Friend Property DataViewer() As DataView
        Get
            Return _dv
        End Get
        Set(ByVal value As DataView)
            _dv = value
        End Set
    End Property

    Friend Property DataGrid() As DataGridView
        Get
            Return _dg
        End Get
        Set(ByVal value As DataGridView)
            _dg = value
        End Set
    End Property

    Friend Sub MostraFiltroForm(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Try
            _dg.CurrentCell = _dg(e.ColumnIndex, e.RowIndex)
            Frm(_dg.Columns(e.ColumnIndex).HeaderText).Show()
        Catch ex As Exception
            'ErroVB(ex.Message, "clsDataGrid: MostraFiltroForm")
        End Try


    End Sub

    Friend Sub RemoverFiltro(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Try
            _Query = ""
            If Not _dv Is Nothing Then _dv.RowFilter = ""
            If Not _Bs Is Nothing Then _Bs.Filter = ""
            xFiltraDataGrid = ""
        Catch ex As Exception
            '  ErroVB(ex.Message, "clsDataGrid: MostraFiltroForm")
        End Try


    End Sub

    Private Sub _txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _txt.KeyPress
        Dim xTipoData As String = ""
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If Me._txt.Text.Length > 0 Then
                    'xFiltraDataGrid = AfinarFiltro(_dg.Columns(_dg.CurrentCell.ColumnIndex).Name, Me._txt.Text)

                    Select Case _dg.DataSource.GetType.Name
                        Case Is = "BindingSource"
                            'xTipoData = _dg.DataSource(0)(_dg.CurrentCell.ColumnIndex - 1).GetType.Name

                            'ISTO OBRIGA A QUE O NOME DA COLUNA SEJA IGUAL AO NOME DO CAMPO
                            'xTipoData = _dg.DataSource(0)(_dg.Columns(_dg.CurrentCell.ColumnIndex).Name).GetType.Name
                            xTipoData = "String"

                        Case Is = "DataTable"
                            'HELDER: PASSAR A VARIÁVEL
                            xTipoData = "String"
                    End Select


                    xFiltraDataGrid = AfinarFiltro(Me._txt.Text, xTipoData, _dg.Columns(_dg.CurrentCell.ColumnIndex).DataPropertyName)
                    If Not xFiltraDataGrid Is Nothing Then
                        If xFiltraDataGrid.Length > 0 Then
                            If Not _dv Is Nothing Then
                                _dv.RowFilter = xFiltraDataGrid
                            ElseIf Not _Bs Is Nothing Then
                                _Bs.Filter = xFiltraDataGrid
                            End If
                        End If
                    End If
                End If
                Me.Frm.Dispose()
                Me.Frm = Nothing
            End If
        Catch ex As Exception
            ErroVB(ex.Message, "clsDataGrid: _txt_KeyPress")
        Finally
        End Try
    End Sub

    Private Function AfinarFiltro(ByVal Filtro As String, ByVal TipoData As String, ByVal Campo As String) As String
        Dim Sql As String = ""
        Dim TipoDados As String = ""
        Try
            'TODO: NO CASO DO BindingSource NÃO DEVOLVE O TIPO CORRETO
            TipoDados = TipoData
            Select Case TipoDados
                Case "String"
                    If Filtro.IndexOf("..") > 0 Then
                        Filtro = Campo + " >= '" + Filtro.Substring(0, Filtro.IndexOf("..")) + "' AND " + Campo + " <= '" + Filtro.Substring(Filtro.IndexOf("..") + 2) + "'"
                        Sql = Filtro
                    ElseIf Filtro.IndexOf("*") > -1 Then
                        Filtro = Campo + " LIKE '" + Filtro.Replace("*", "%") + "'"
                        Sql = Filtro
                    Else
                        Sql = Campo + " = '" + Filtro + "'"
                    End If
                Case "Double", "Decimal"
                    If Filtro.IndexOf("..") > 0 Then
                        Filtro = Campo + " >= " + Filtro.Substring(0, Filtro.IndexOf("..")) + " AND " + Campo + " <= " + Filtro.Substring(Filtro.IndexOf("..") + 2)
                        Sql = Filtro
                    ElseIf Filtro.IndexOf("*") > -1 Then
                        'Filtro = Campo + " LIKE '" + Filtro.Replace("*", "%") + "'"
                        Sql = "" 'Filtro
                    Else
                        Sql = Campo + " = " + Filtro
                    End If
                Case "Boolean"
                    Sql = Campo + " = " + Filtro
                Case Else
                    Sql = Campo + " = " + Filtro
            End Select

            If _Query.Length > 0 Then
                _Query = _Query + " AND " + Sql
                Return Query
            Else
                _Query = Sql
                Return Sql
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "clsDataGrid: AfinarFiltro")
            Return Nothing
        Finally
        End Try
    End Function

    'Private Function GetDataType(ByVal Campo As String) As String
    '    If Not _dv Is Nothing Then Return _dv.Table.Columns(Campo).DataType.Name
    '    If Not _Bs Is Nothing Then Return _Bs.Current.GetType.Name
    '    Return Nothing
    'End Function

    Private Property Query() As String
        Get
            Return _Query
        End Get
        Set(ByVal value As String)
            value.Replace("*", "%")
            _Query = value
        End Set
    End Property

    Private Sub _Frm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Frm.Deactivate
        Me.Frm.Dispose()
        Me.Frm = Nothing
    End Sub

    Private Sub cmd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim xCmd As Button
        Try
            xCmd = CType(sender, Button)
            Select Case xCmd.Name
                Case "cmdRemoveFiltro"
                    _Query = ""
                    If Not _dv Is Nothing Then _dv.RowFilter = ""
                    If Not _Bs Is Nothing Then _Bs.Filter = ""
                    xFiltraDataGrid = ""
                Case "cmdFiltroSeleccao"
                    Dim Campo As String = _dg.Columns(_dg.CurrentCell.ColumnIndex).DataPropertyName
                    Dim Valor As String = ValidarCampo(_dg(_dg.CurrentCell.ColumnIndex, _dg.CurrentCell.RowIndex).Value)
                    If Len(Trim(xFiltraDataGrid)) > 0 Then
                        xFiltraDataGrid = xFiltraDataGrid + " And " + Campo + " = " + Valor
                    Else
                        xFiltraDataGrid = Campo + " = " + Valor
                    End If
                    'Dim xString As String = Campo + " = " + Valor
                    If Not _dv Is Nothing Then _dv.RowFilter = xFiltraDataGrid
                    If Not _Bs Is Nothing Then _Bs.Filter = xFiltraDataGrid
                Case "cmdExcluirSeleccao"
                    Dim Campo As String = _dg.Columns(_dg.CurrentCell.ColumnIndex).Name
                    Dim Valor As String = ValidarCampo(_dg(_dg.CurrentCell.ColumnIndex, _dg.CurrentCell.RowIndex).Value)
                    If Len(Trim(xFiltraDataGrid)) > 0 Then
                        xFiltraDataGrid = xFiltraDataGrid + " And " + Campo + " <> " + Valor
                    Else
                        xFiltraDataGrid = Campo + " <> " + Valor
                    End If
                    'Dim xString As String = Campo + " = " + Valor
                    If Not _dv Is Nothing Then _dv.RowFilter = xFiltraDataGrid
                    If Not _Bs Is Nothing Then _Bs.Filter = xFiltraDataGrid



            End Select
        Catch ex As Exception
            ErroVB(ex.Message, "clsDataGrid: cmd_Click")
        Finally
            Me.Frm.Dispose()
            Me.Frm = Nothing

        End Try
    End Sub

    Private Function ValidarCampo(ByVal Campo As String) As String
        Try
            Select Case Campo.GetType.Name
                Case "String"
                    Return "'" + Campo.ToString + "'"
                Case "DateTime"
                    Return "'" + Campo.ToString + "'"
            End Select
            Return Campo
        Catch ex As Exception
            ErroVB(ex.Message, "clsDataGrid: ValidarCampo")
            Return Nothing
        End Try
    End Function

    'Private Sub cmd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim xCmd As Button
    '    Try
    '        xCmd = CType(sender, Button)
    '        Select Case xCmd.Name
    '            Case "cmdRemoveFiltro"
    '                _Query = ""
    '                If Not _dv Is Nothing Then _dv.RowFilter = Nothing
    '                If Not _Bs Is Nothing Then _Bs.Filter = Nothing
    '                xFiltraDataGrid = ""
    '            Case "cmdFiltroSeleccao"
    '                Dim Campo As String = _dg.Columns(_dg.CurrentCell.ColumnIndex).Name
    '                Dim Valor As String = _dg(_dg.CurrentCell.ColumnIndex, _dg.CurrentCell.RowIndex).Value
    '                If Len(Trim(xFiltraDataGrid)) > 0 Then
    '                    xFiltraDataGrid = xFiltraDataGrid + " And " + Campo + " = " + Valor
    '                Else
    '                    xFiltraDataGrid = Campo + " = " + Valor
    '                End If
    '                'Dim xString As String = Campo + " = " + Valor
    '                If Not _dv Is Nothing Then _dv.RowFilter = xFiltraDataGrid
    '                If Not _Bs Is Nothing Then _Bs.Filter = xFiltraDataGrid
    '            Case "cmdExcluirSeleccao"
    '                Dim Campo As String = _dg.Columns(_dg.CurrentCell.ColumnIndex).Name
    '                Dim Valor As String = _dg(_dg.CurrentCell.ColumnIndex, _dg.CurrentCell.RowIndex).Value
    '                If Len(Trim(xFiltraDataGrid)) > 0 Then
    '                    xFiltraDataGrid = xFiltraDataGrid + " And " + Campo + " <> " + Valor
    '                Else
    '                    xFiltraDataGrid = Campo + " <> " + Valor
    '                End If
    '                'Dim xString As String = Campo + " = " + Valor
    '                If Not _dv Is Nothing Then _dv.RowFilter = xFiltraDataGrid
    '                If Not _Bs Is Nothing Then _Bs.Filter = xFiltraDataGrid



    '        End Select
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "clsDataGrid: cmd_Click")
    '    Finally
    '        Me.Frm.Dispose()
    '        Me.Frm = Nothing

    '    End Try
    'End Sub


End Class
