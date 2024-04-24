
Imports System.Data.SqlClient
Imports System.Linq

Public Class frmArtigos

    Dim xModeloCor As String = ""
    Dim Foto As New ClsFotos
    Dim sModeloCorDescr As String


    Private Sub frmArtigos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try


            Me.EpocasTableAdapter.Fill(Me.GirlDataSet.Epocas)
            'Me.TerceirosTableAdapter.FillByTipoTerc(Me.GirlDataSet.Terceiros, "F")
            'TODO: FALTA CRIAR UM NOVO TIPO DE TERCEIRO QUE VAI SER CLIENTE E FORNECEDOR
            Me.TerceirosTableAdapter.FillByTipoTerc(Me.GirlDataSet.Terceiros, "%")
            Me.CoresTableAdapter.FillByCombo(Me.GirlDataSet.Cores)
            Me.UnidadesTableAdapter.Fill(Me.GirlDataSet.Unidades)
            Me.LinhasTableAdapter.Fill(Me.GirlDataSet.Linhas)
            Me.TiposTableAdapter.FillByCombo(Me.GirlDataSet.Tipos)
            Me.GruposTableAdapter.Fill(Me.GirlDataSet.Grupos)
            Me.ModeloCorTableAdapter.Fill(Me.GirlDataSet.ModeloCor)


            Me.txtModelos.Text = ""

            Me.cbGrupos.DataSource = Me.GirlDataSet.Grupos
            Me.cbGrupos.DisplayMember = "GrupoDesc"
            Me.cbGrupos.ValueMember = "GrupoID"
            Me.GirlDataSet.Grupos.AddGruposRow("%", "Todos Grupos", "", "", Now)
            Me.cbGrupos.SelectedValue = "%"

            Me.cbTipos.DataSource = Me.GirlDataSet.Tipos
            Me.cbTipos.DisplayMember = "DescrTipo"
            Me.cbTipos.ValueMember = "TipoID"
            Me.GirlDataSet.Tipos.AddTiposRow("%", "Todos os Tipos", "", "", 0, "", "", 0, "", Now)
            Me.cbTipos.SelectedValue = "%"

            Me.cbLinhas.DataSource = Me.GirlDataSet.Linhas
            Me.cbLinhas.DisplayMember = "DescrLinha"
            Me.cbLinhas.ValueMember = "LinhaID"
            Me.GirlDataSet.Linhas.AddLinhasRow("%", "Todas Linhas", "", Now)
            Me.cbLinhas.SelectedValue = "%"

            Me.ModelosTableAdapter.FillByFiltro(Me.GirlDataSet.Modelos, "%", "%", "%", "%")


            'DataGridViewTextBoxColumn3

            Me.TipoID.DataPropertyName = "TipoID"
            Me.TipoID.DataSource = Me.TiposBindingSource
            Me.TipoID.DisplayMember = "DescrTipo"
            Me.TipoID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
            Me.TipoID.HeaderText = "Tipo"
            Me.TipoID.Name = "TipoID"
            Me.TipoID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.TipoID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.TipoID.ValueMember = "TipoId"
            Me.TipoID.Width = 285


            'DataGridViewTextBoxColumn12
            '
            Me.DataGridViewTextBoxColumn12.DataPropertyName = "CorID"
            Me.DataGridViewTextBoxColumn12.DataSource = Me.CoresBindingSource
            Me.DataGridViewTextBoxColumn12.DisplayMember = "CorIDDescrCor"
            Me.DataGridViewTextBoxColumn12.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
            Me.DataGridViewTextBoxColumn12.HeaderText = "Cor"
            Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
            Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.DataGridViewTextBoxColumn12.ValueMember = "CorID"
            Me.DataGridViewTextBoxColumn12.Width = 115
            '
            ''DataGridViewTextBoxColumn15


            Me.DataGridViewTextBoxColumn15.DataSource = Me.TerceirosBindingSource
            Me.DataGridViewTextBoxColumn15.DisplayMember = "NomeAbrev"
            Me.DataGridViewTextBoxColumn15.HeaderText = "Fornecedor"
            Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
            Me.DataGridViewTextBoxColumn15.ValueMember = "TercID"
            Me.DataGridViewTextBoxColumn15.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
            Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.DataGridViewTextBoxColumn15.Width = 170

            'If sAplicacao = "CELFGEST" Then
            '    dgvModelos.AllowUserToAddRows = True
            '    dgvModeloCor.AllowUserToAddRows = True
            'Else
            '    dgvModelos.AllowUserToAddRows = False
            '    dgvModeloCor.AllowUserToAddRows = False
            'End If

            dgvModelos.AllowUserToAddRows = True
            dgvModeloCor.AllowUserToAddRows = True

            dgvModelos.AllowUserToDeleteRows = False
            dgvModeloCor.AllowUserToDeleteRows = False


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": frmArtigos_Load")
        End Try


    End Sub

    'Private Sub frmArtigos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    Try


    '        If GirlDataSet.Modelos.GetChanges Is Nothing And GirlDataSet.ModeloCor.GetChanges Is Nothing Then
    '        Else
    '            If MsgBox("Pretende gravar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '                cmdGravar_Click(sender, e)
    '            End If
    '        End If


    '    Catch ex As Exception
    '        ErroVB(ex.Message, Me.Name + ": frmArtigos_FormClosing")
    '    End Try

    'End Sub



    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Itera sobre as células do DataGridView
        For Each row As DataGridViewRow In dgvModelos.Rows
            For Each cell As DataGridViewCell In row.Cells
                ' Verifica se a célula é do tipo DataGridViewComboBoxCell
                If TypeOf cell Is DataGridViewComboBoxCell Then
                    Dim comboCell As DataGridViewComboBoxCell = CType(cell, DataGridViewComboBoxCell)
                    ' Verifica se o valor selecionado é inválido
                    If Not comboCell.Items.Contains(cell.Value) Then
                        ' Valor não válido, exibir mensagem de erro com informações adicionais
                        Dim validOptions As String = String.Join(", ", comboCell.Items.Cast(Of Object)().Select(Function(item) item.ToString()).ToArray())
                        MessageBox.Show($"Valor selecionado não é válido para a célula na linha {row.Index}, coluna {cell.ColumnIndex}! Opções válidas: {validOptions}")

                        ' Impede o fechamento do formulário
                        e.Cancel = True
                        Return
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvModelos.DataError
        ' Impede que o DataGridView gere um erro não controlado
        e.Cancel = True
    End Sub






    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim db As New ClsSqlBDados
        Try
            Me.Validate()
            Me.ModelosBindingSource.EndEdit()
            Me.ModelosTableAdapter.Update(Me.GirlDataSet.Modelos)
            Me.ModeloCorBindingSource.EndEdit()
            Me.ModeloCorTableAdapter.Update(Me.GirlDataSet.ModeloCor)

            Sql = "DELETE FROM Modelos WHERE len(ltrim(rtrim(ModeloID)))=0"
            db.ExecuteData(Sql)

            frmArtigos_Load(sender, e)

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": cmdGravar_Click")
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click

        Try
            Me.ModelosBindingSource.CancelEdit()
            Me.ModeloCorBindingSource.CancelEdit()
            Me.GirlDataSet.Modelos.RejectChanges()
            Me.GirlDataSet.ModeloCor.RejectChanges()
            btFiltro_Click(sender, e)

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": cmdCancelar_Click")
        End Try


    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click

        Try

            Me.Close()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "cmdFechar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "cmdFechar_Click")
        End Try


    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvModelos.CellValidating
        If TypeOf dgvModelos.Rows(e.RowIndex).Cells(e.ColumnIndex) Is DataGridViewComboBoxCell Then
            Dim comboCell As DataGridViewComboBoxCell = CType(dgvModelos.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
            If Not comboCell.Items.Contains(e.FormattedValue) Then
                ' Valor não válido, exibir mensagem de erro com informações adicionais
                e.Cancel = True
                Dim validOptions As String = String.Join(", ", comboCell.Items.Cast(Of Object)().Select(Function(item) item.ToString()).ToArray())
                MessageBox.Show($"Valor selecionado não é válido para esta célula! Opções válidas: {validOptions}")
            End If
        End If
    End Sub




    Private Sub btFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFiltro.Click
        Try

            If GirlDataSet.Modelos.GetChanges Is Nothing And GirlDataSet.ModeloCor.GetChanges Is Nothing Then
            Else
                If MsgBox("Pretende gravar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cmdGravar_Click(sender, e)
                Else
                    GirlDataSet.Modelos.RejectChanges()
                    GirlDataSet.ModeloCor.RejectChanges()
                End If
            End If

            Me.ModelosTableAdapter.FillByFiltro(Me.GirlDataSet.Modelos, IIf(Me.txtModelos.Text = "", "%", Me.txtModelos.Text), Me.cbGrupos.SelectedValue, Me.cbTipos.SelectedValue, Me.cbLinhas.SelectedValue)

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": btFiltro_Click")
        End Try
    End Sub


    'Eventos da dgvModeloCor

    Private Sub dgvModeloCor_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModeloCor.CellEnter
        Try

            If Not dgvModeloCor("DataGridViewTextBoxColumn13", e.RowIndex).Value Is DBNull.Value Then
                sModeloCorDescr = dgvModeloCor("DataGridViewTextBoxColumn13", e.RowIndex).Value
            Else
                Exit Sub
            End If

            If dgvModeloCor("DataGridViewTextBoxColumn11", e.RowIndex).Value & dgvModeloCor("DataGridViewTextBoxColumn12", e.RowIndex).Value <> xModeloCor Then
                xModeloCor = dgvModeloCor("DataGridViewTextBoxColumn11", e.RowIndex).Value & dgvModeloCor("DataGridViewTextBoxColumn12", e.RowIndex).Value
                Foto.CarregarFotoModeloCor(Me.PicBox, xModeloCor)
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "dgvModeloCor_CellEnter")
        Catch ex As Exception
            ErroVB(ex.Message, "dgvModeloCor_CellEnter")
        End Try


    End Sub

    Private Sub dgvModeloCor_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvModeloCor.UserDeletingRow
        Dim db As New ClsSqlBDados
        Dim dt As New DataTable
        Dim xModelo As String
        Dim xModeloCor As String

        Try
            xModelo = Me.dgvModeloCor("DataGridViewTextBoxColumn11", e.Row.Index).Value
            xModeloCor = Me.dgvModeloCor("DataGridViewTextBoxColumn12", e.Row.Index).Value
            Sql = "SELECT COUNT(*) FROM Serie WHERE ModeloID = '" & xModelo & "' AND CorID = '" & xModeloCor & "'"
            If db.GetDataValue(Sql) > 0 Then
                e.Cancel = True
                MsgBox("O Artigo " & xModelo + "-" + xModeloCor & " tem Talões Associados!")
            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": dgvModeloCor_UserDeletingRow")
        Finally
            xModelo = Nothing
            xModeloCor = Nothing
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub dgvModeloCor_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModeloCor.CellEndEdit
        Dim db As New ClsSqlBDados

        Try

            If dgvModeloCor.Columns(e.ColumnIndex).HeaderText = "Descrição" Then
                Sql = "SELECT count(*) FROM DocDet WHERE TipoDocID IN ('FS', 'NC', 'FT', 'GT') AND ModeloID + CorID = '" & xModeloCor & "'"
                If db.GetDataValue(Sql) > 0 Then
                    MsgBox("A descrição não pode ser alterada! Já existem Documentos com esse Artigo!")
                    dgvModeloCor("DataGridViewTextBoxColumn13", e.RowIndex).Value = sModeloCorDescr
                    Exit Sub
                End If
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "dgvModeloCor_CellEndEdit")
        Catch ex As Exception
            ErroVB(ex.Message, "dgvModeloCor_CellEndEdit")
        End Try

    End Sub



    'Eventos da dgvModelo

    Private Sub dgvModelos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModelos.CellEnter
        Static LinhaActual As Integer
        Dim Foto As New ClsFotos
        Dim Modelo As String
        Dim Cor As String
        Try
            If e.RowIndex > 0 Then
                If Me.dgvModeloCor.RowCount > 0 Then
                    If Not Me.dgvModelos("ModeloID", e.RowIndex).Value Is DBNull.Value Then
                        Modelo = Me.dgvModelos("ModeloID", e.RowIndex).Value
                        Cor = Me.dgvModeloCor("DataGridViewTextBoxColumn12", 0).Value
                        If Not LinhaActual = e.RowIndex Then
                            LinhaActual = e.RowIndex
                            Foto.CarregarFotoModeloCor(Me.PicBox, Modelo + Cor)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": dgvModelos_CellEnter")
        Finally
            Foto.Dispose()
            Foto = Nothing
            Modelo = Nothing
            Cor = Nothing
        End Try
    End Sub

    Private Sub dgvModelos_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvModelos.UserDeletingRow
        Dim db As New ClsSqlBDados
        Dim dt As New DataTable
        Dim xModelo As String

        Try
            xModelo = Me.dgvModelos("ModeloID", e.Row.Index).Value
            Sql = "SELECT COUNT(*) FROM Serie WHERE ModeloID = '" & xModelo & "'"
            If db.GetDataValue(Sql) > 0 Then
                e.Cancel = True
                MsgBox("O Modelo " & xModelo & " tem Talões Associados!")
            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": dgvModelos_UserDeletingRow")
        Finally
            xModelo = Nothing
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub




End Class