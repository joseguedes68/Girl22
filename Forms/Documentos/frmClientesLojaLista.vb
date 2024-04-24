
Imports System.Data.SqlClient





Public Class frmClientesLojaLista


    Dim bPermiteSelectLinha As Boolean = False
    Dim bPesquisa As Boolean = True


    'EVENTOS NO FORM


    Private Sub btGravar_Click(sender As System.Object, e As System.EventArgs) Handles btGravar.Click


        'GRAVA OU ALTERA E PASSA VARIÁVEL..

        Try

            If dgvListaClientes.Rows.Count > 0 Then
                If Me.dgvListaClientes("ClienteLojaID", Me.dgvListaClientes.CurrentCell.RowIndex).Value = 1 Then
                    Me.Cursor = Cursors.Default
                    Me.Dispose()
                    Exit Sub
                End If
            End If

            If Len(Trim(txtCodPostal.Text)) > 1 And Len(txtCodPostal.Text) < 8 Then
                MsgBox("Complete ou limpe o Código Postal do Cliente!!")
                Exit Sub
            End If

            If DevolveTipoNIF(Microsoft.VisualBasic.Left(txtNif.Text, 1)) <> "P" Then
                If Len(txtCodPostal.Text) <> 8 Then
                    MsgBox("Complete o Código Postal do Cliente!!")
                    Exit Sub
                End If
                If Len(txtLocalidade.Text) < 3 Then
                    MsgBox("Complete a Localidadedo Cliente!!")
                    Exit Sub
                End If
                If Len(txtNome.Text) < 5 Then
                    MsgBox("Complete a Designação do Cliente!!")
                    Exit Sub
                End If
                If Len(txtMorada.Text) < 8 Then
                    MsgBox("Complete a Morada do Cliente!!")
                    Exit Sub
                End If
            End If


            'TODO: VALIDAR SE TEM CONTEUDO PARA GRAVAR
            GravarCliente()

            Me.Cursor = Cursors.Default
            Me.Dispose()

        Catch ex As Exception
            ErroVB(ex.Message, "btGravar_Click")
        End Try

    End Sub

    Private Sub txtNIF_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNif.Validating

        Dim db As New ClsSqlBDados

        Try
            Me.Cursor = Cursors.WaitCursor

            If Len(txtNif.Text) = 0 Then Exit Sub
            LimparForm()
            dgvListaClientes.Visible = False

            If IsValidContrib(Trim(txtNif.Text)) = False Then

                MsgBox("Nº Contribuinte Inválido!!")
                txtNif.Text = ""
                txtNif.Focus()
                e.Cancel = True

            Else

                Sql = "SELECT COUNT(*) FROM CLIENTESLOJA WHERE NIF='" & txtNif.Text & "'"
                If db.GetDataValue(Sql) > 0 Then
                    filtraCliente("%")
                Else
                    MsgBox("Novo Cliente! Insira dos dados")
                    LimparForm()
                End If
                txtNif.Enabled = False
                dgvListaClientes.Visible = True

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "txtNIF_Validating")
        Catch ex As Exception
            ErroVB(ex.Message, "txtNIF_Validating")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btCancelar.Click
        'Fecha, limpa variáveis e não faz nada.
        sIDClienteLoja = ""
        Me.Dispose()
    End Sub

    Private Sub txtNif_TextChanged(sender As Object, e As EventArgs) Handles txtNif.TextChanged

        Try


            If txtNif.Text.Length = 9 Then

                If ActiveControl.Name.ToString = "txtNif" Then
                    SendKeys.Send("{Tab}")
                    chamarfiltro()
                    dgvListaClientes.Visible = False

                End If


            End If



        Catch ex As Exception
            'ErroVB(ex.Message, "txtNif_TextChanged")
        End Try

    End Sub


    'EVENTOS NA frmClientesLojaLista


    Private Sub frmClientesLojaLista_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'FALTA LIMITAR ALTERAÇÕES PELAS REGRAS DAS FINANÇAS
        Try

            'dgvListaClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvListaClientes.MultiSelect = False

            dgvListaClientes.Visible = False
            Me.GirlDataSet.ClientesLoja.Clear()
            If Len(sIDClienteLoja) > 0 Then
                txtNif.TabStop = False
                txtNif.Enabled = False
                txtNome.Focus()
                bPermiteSelectLinha = True
                Me.ClientesLojaTableAdapter.FillByIDCliente(Me.GirlDataSet.ClientesLoja, sIDClienteLoja)
                dgvListaClientes.Visible = True

            Else
                txtNif.TabStop = True
                txtNif.Enabled = True
                txtNif.Focus()
            End If
            Me.ControlBox = False

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmClientesLojaLista_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmClientesLojaLista_Load")
        Finally

        End Try



    End Sub

    Private Sub dgvListaClientes_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvListaClientes.MouseDown
        bPermiteSelectLinha = True
    End Sub

    'Private Sub dgvListaClientes_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvListaClientes.SelectionChanged

    '    Dim db As New ClsSqlBDados

    '    Try
    '        bPesquisa = False
    '        If bPermiteSelectLinha = False Then Exit Sub
    '        If IsDataGridViewEmpty(dgvListaClientes) Then Exit Sub


    '        sIDClienteLoja = Me.dgvListaClientes("IDClienteLoja", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString
    '        txtNif.Text = Me.dgvListaClientes("NIF", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString
    '        txtNif.Enabled = False
    '        txtTelemovel.Text = Me.dgvListaClientes("Telemovel", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString
    '        txtNome.Text = Me.dgvListaClientes("Nome", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString
    '        txtMorada.Text = Me.dgvListaClientes("Morada", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString
    '        txtCodPostal.Text = Me.dgvListaClientes("CodPostal", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString
    '        txtLocalidade.Text = Me.dgvListaClientes("Localidade", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString
    '        txtTelefone.Text = Me.dgvListaClientes("Telefone", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString
    '        txtEmail.Text = Me.dgvListaClientes("Email", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString
    '        txtObs.Text = Me.dgvListaClientes("Obs", Me.dgvListaClientes.CurrentCell.RowIndex).Value.ToString



    '    Catch ex As Exception
    '        ErroVB(ex.Message, "dgvListaClientes_SelectionChanged")
    '    End Try

    'End Sub

    Private Sub dgvListaClientes_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListaClientes.RowEnter

        bPesquisa = False
        If bPermiteSelectLinha = False Then Exit Sub
        If IsDataGridViewEmpty(dgvListaClientes) Then Exit Sub


        ' Obtém a linha atualmente selecionada
        Dim selectedRow As DataGridViewRow = dgvListaClientes.Rows(e.RowIndex)

        ' Verifica se há uma linha selecionada
        If selectedRow IsNot Nothing Then
            ' Obtém os valores das células da linha selecionada
            sIDClienteLoja = selectedRow.Cells("IDClienteLoja").Value
            txtNif.Text = selectedRow.Cells("NIF").Value
            txtTelemovel.Text = selectedRow.Cells("Telemovel").Value
            txtNome.Text = selectedRow.Cells("Nome").Value
            txtMorada.Text = selectedRow.Cells("Morada").Value
            txtCodPostal.Text = selectedRow.Cells("CodPostal").Value
            txtLocalidade.Text = selectedRow.Cells("Localidade").Value
            txtTelefone.Text = selectedRow.Cells("Telefone").Value
            txtEmail.Text = selectedRow.Cells("Email").Value
            txtObs.Text = selectedRow.Cells("Obs").Value


        End If
    End Sub











    'FUNÇÕES

    Private Sub Pesquisar(sender As Object, e As EventArgs) Handles txtNif.Validated, txtTelefone.Validated, txtTelemovel.Validated, txtNome.Validated, txtMorada.Validated, txtLocalidade.Validated, txtEmail.Validated, txtCodPostal.Validated, txtObs.Validated

        Try
            If bPesquisa = True Then
                chamarfiltro()
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "Filtro")
        Catch ex As Exception
            ErroVB(ex.Message, "Filtro")
        End Try


    End Sub

    Private Sub filtraCliente(ByVal sLoja As String)

        Try

            'sFiltro = "%" & sFiltro & "%"
            'sFiltro = sFiltro.Replace("+", "%")

            Me.GirlDataSet.ClientesLoja.Clear()


            Dim sNome As String = "%" + Trim(txtNome.Text) + "%"
            Dim sMorada As String = "%" + Trim(txtMorada.Text) + "%"
            Dim sTelemovel As String = "%" + Trim(txtTelemovel.Text) + "%"
            Dim sLocalidade As String = "%" + Trim(txtLocalidade.Text) + "%"
            Dim sCodPostal As String = "%" + Trim(txtCodPostal.Text) + "%"
            Dim sNIF As String = "%" + Trim(txtNif.Text).ToString + "%"
            Dim sTelefone As String = "%" + Trim(txtTelefone.Text) + "%"
            Dim sEmail As String = "%" + Trim(txtEmail.Text) + "%"
            Dim sObs As String = "%" + Trim(txtObs.Text) + "%"
            If Len(sNIF) > 0 Then sLoja = "%"

            If Len(Trim(sNome + sMorada + sTelemovel + sLocalidade + sCodPostal + sNIF + sTelefone + sEmail + sObs)) > 19 Then
                Me.ClientesLojaTableAdapter.FillByFiltroCliente(Me.GirlDataSet.ClientesLoja, sNome, sMorada, sTelemovel, sLocalidade, sNIF, sTelefone, sEmail, sObs, sLoja)
                If Me.GirlDataSet.ClientesLoja.Rows.Count > 0 Then bPermiteSelectLinha = True
                dgvListaClientes.ClearSelection()
                'Else
                '    MsgBox("Não tem filtros para a pesquisa!", , "Filtro")
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "filtraCliente")
        End Try

    End Sub

    Private Sub GravarCliente()

        Dim db As New ClsSqlBDados
        Dim xNovoDoc As String = ""
        Dim sNIF As String = ""


        Try
            Me.Cursor = Cursors.WaitCursor
            If SistemaBloqueado() = True Then
                Exit Sub
            End If

            If Len(Trim(txtNome.Text) + Trim(txtMorada.Text) + Trim(txtTelemovel.Text) + Trim(txtLocalidade.Text) + Trim(txtCodPostal.Text) + Trim(txtNif.Text).ToString + Trim(txtTelefone.Text) + Trim(txtEmail.Text) + Trim(txtObs.Text)) = 0 Then Exit Sub

            If Len(Me.txtNif.Text) = 0 Then
                sNIF = "xxxxxxxxx"
            Else
                sNIF = Me.txtNif.Text
            End If

            If sIDClienteLoja = "" Then

                sIDClienteLoja = Guid.NewGuid.ToString

                Sql = "INSERT INTO ClientesLoja (Nome, Morada, Localidade, CodPostal, NIF ,Telefone, Telemovel, Email, Obs, OperadorID, ArmOrig, IDClienteLoja) " &
                    "VALUES ('" + Me.txtNome.Text + "','" + Me.txtMorada.Text + "','" + Me.txtLocalidade.Text + "','" + Me.txtCodPostal.Text + "','" + sNIF + "','" + Me.txtTelefone.Text + "', '" + Me.txtTelemovel.Text + "', '" + Me.txtEmail.Text + "','" + Me.txtObs.Text + "','" + xUtilizador + "','" + xArmz + "', '" + sIDClienteLoja + "')"
                db.ExecuteData(Sql)

            Else

                Sql = "UPDATE ClientesLoja SET Nome = '" + Me.txtNome.Text + "', Morada = '" + Me.txtMorada.Text + "', Localidade = '" + Me.txtLocalidade.Text + "', CodPostal = '" + Me.txtCodPostal.Text + "', Telefone = '" + Me.txtTelefone.Text + "', Telemovel = '" + Me.txtTelemovel.Text + "', Email = '" + Me.txtEmail.Text + "', Obs = '" + Me.txtObs.Text + "', OperadorID = '" + xUtilizador + "', PaisID = 'PT', DistritoID = '', ArmOrig = '" & xArmz & "' WHERE IDClienteLoja='" & sIDClienteLoja & "'"
                db.ExecuteData(Sql)

            End If




        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravarCliente")
        Catch ex As Exception
            ErroVB(ex.Message, "GravarCliente")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub LimparForm()

        txtTelemovel.Text = ""
        txtNome.Text = ""
        txtMorada.Text = ""
        txtCodPostal.Text = ""
        txtLocalidade.Text = ""
        txtTelefone.Text = ""
        txtEmail.Text = ""
        txtObs.Text = ""
        sIDClienteLoja = ""

    End Sub

    Private Sub chamarfiltro()

        Try



            If DevolveGrupoAcesso() = "ADMIN" Then
                filtraCliente("%")
            Else
                filtraCliente(xArmz)
            End If
            If dgvListaClientes.Rows.Count > 0 Then
                dgvListaClientes.Visible = True
            End If
            dgvListaClientes.ClearSelection()
            bPermiteSelectLinha = False
            btGravar.Enabled = True
            bPesquisa = False


        Catch ex As Exception
            ErroVB(ex.Message, "chamarfiltro")
        End Try

    End Sub

    Private Sub dgvListaClientes_Leave(sender As Object, e As EventArgs) Handles dgvListaClientes.Leave
        bPesquisa = True
    End Sub

    Private Sub EnterTBox(sender As Object, e As EventArgs) Handles txtNif.Enter, txtTelefone.Enter, txtTelemovel.Enter, txtNome.Enter, txtMorada.Enter, txtLocalidade.Enter, txtEmail.Enter, txtCodPostal.Enter, txtObs.Enter
        bPesquisa = True
    End Sub

    Private Sub dgvListaClientes_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListaClientes.CellValueChanged
        bPesquisa = False
    End Sub

End Class