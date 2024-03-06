
Imports System.Data.SqlClient



Public Class frmInserirTerceiros

    Dim sTercID As String
    Dim sPaisAux As String = ""

    Private Sub frmInserirTerceiros_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try

            tbCodigo.Enabled = False
            tbNIF.Enabled = False


            'Format(tbCodPostal.Text, "####-###")


            Me.TerceirosTableAdapter.Fill(Me.GirlDataSet.Terceiros)

            cbTipoTerc.Items.Add("Interno")
            cbTipoTerc.Items.Add("Fornecedor")
            cbTipoTerc.Items.Add("Cliente")
            cbTipoTerc.Items.Add("")
            'cbTipoTerc.SelectedItem = ""

            cbPaisID.Items.Add("Portugal")
            cbPaisID.Items.Add("Espanha")
            'COMENTEI ESTA LINHA PARA NÃO TER PROBLEMAS COM O QRCODE
            'cbPaisID.Items.Add("Outro")
            cbPaisID.Items.Add("")
            'cbPaisID.SelectedItem = ""


            'tbCodPostal.Mask = "0000-000"


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmInserirTerceiros_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmInserirTerceiros_Load")
        End Try

    End Sub

    Private Sub btFechar_Click(sender As System.Object, e As System.EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub

    Private Sub btGravar_Click(sender As System.Object, e As System.EventArgs) Handles btGravar.Click


        Dim db As New ClsSqlBDados
        Try

            Me.Cursor = Cursors.WaitCursor


            'para carregar mais paises: ISO 3166-1
            'https://rm.wikipedia.org/wiki/ISO_3166-1

            Select Case cbPaisID.SelectedItem.ToString
                Case "Portugal"
                    sPaisAux = "PT"
                Case "Espanha"
                    sPaisAux = "ES"
                Case "Outro"
                    sPaisAux = "OO"
            End Select


            If Not Validar() Then Exit Sub


            Dim sTipoTercAux As String = ""
            Select Case cbTipoTerc.SelectedItem.ToString
                Case "Interno"
                    sTipoTercAux = "I"
                Case "Fornecedor"
                    sTipoTercAux = "F"
                Case "Cliente"
                    sTipoTercAux = "C"
            End Select


            'VERIFICAR SE EXISTE
            Sql = "SELECT COUNT(*) FROM TERCEIROS WHERE TERCID='" & Me.tbCodigo.Text & "'"
            If db.GetDataValue(Sql) = 0 Then
                'NOVO
                Sql = "INSERT INTO dbo.Terceiros (TercID, TipoTerc, Nome, NomeAbrev, Morada, CodPostal, Localidade, PaisID, NIF, Contacto, Telefone, Movel, Fax, Email, Site, PPagID, ExpID, Obs, OperadorID) VALUES ('" & tbCodigo.Text & "', '" & sTipoTercAux & "', '" & tbNome.Text & "','" & tbNomeAbrev.Text & "','" & tbMorada.Text & "', '" & tbCodPostal.Text & "', '" & tbLocalidade.Text & "', '" & sPaisAux & "','" & tbNIF.Text & "', '" & tbContacto.Text & "', '" & tbTelefone.Text & "','" & tbMovel.Text & "','', '" & tbEmail.Text & "', '" & tbSite.Text & "', '', '', '" & tbObs.Text & "', '" & xUtilizador & "')"
                db.ExecuteData(Sql)
                Me.GirlDataSet.Terceiros.Clear()
                Me.TerceirosTableAdapter.Fill(Me.GirlDataSet.Terceiros)
                Limpar()
            Else
                'UPDATE
                Sql = "UPDATE Terceiros SET TipoTerc = '" & sTipoTercAux & "', Nome = '" & tbNome.Text & "', NomeAbrev = '" & tbNomeAbrev.Text & "', Morada = '" & tbMorada.Text & "', CodPostal = '" & tbCodPostal.Text & "', Localidade = '" & tbLocalidade.Text & "', DistritoID = '' , PaisID = '" & sPaisAux & "', Contacto = '" & tbContacto.Text & "', Telefone = '" & tbTelefone.Text & "', Movel = '" & tbMovel.Text & "', Fax = '', Email = '" & tbEmail.Text & "', Site = '" & tbSite.Text & "', PPagID = '', ExpID = '', Obs = '" & tbObs.Text & "', OperadorID = '" & xUtilizador & "', DtRegisto = GETDATE() WHERE TercID='" & tbCodigo.Text & "'"
                db.ExecuteData(Sql)
                ActualizaDados(tbCodigo.Text)
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btGravar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btGravar_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try



    End Sub

    'Private Sub tbNIF_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tbNIF.Validating



    '    Try


    '        If Me.cbPaisID.SelectedItem = "Espanha" Then

    '            'VALIDAR NIF E CODIGO POSTAL PARA PORTUGAL......
    '            If Len(Trim(Me.tbNIF.Text)) <> 9 Or Not IsValidContrib(Trim(Me.tbNIF.Text)) Then
    '                MsgBox("Nº Contribuinte Inválido")
    '                Me.tbNIF.SelectAll()
    '                Me.tbNIF.Focus()
    '                'e.Cancel = True
    '            End If

    '        End If


    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "tbNIF_Validating")
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "tbNIF_Validating")
    '    End Try


    'End Sub

    Private Sub btNovo_Click(sender As System.Object, e As System.EventArgs) Handles btNovo.Click
        Limpar()
        tbCodigo.Enabled = True
        tbNIF.Enabled = True
        tbCodigo.Focus()

    End Sub

    Private Sub btApagar_Click(sender As System.Object, e As System.EventArgs) Handles btApagar.Click


        Dim db As New ClsSqlBDados

        Try

            'TODO : SEPARA TABELA CLIENTE DE TERCEIROS VAI DAR PROB......
            Sql = "SELECT COUNT(*) FROM DOCCAB WHERE TERCID='" & Me.tbCodigo.Text & "'"
            If db.GetDataValue(Sql) = 0 Then
                'APAGAR
                Sql = "DELETE FROM Terceiros WHERE TERCID='" & Me.tbCodigo.Text & "'"
                db.ExecuteData(Sql)
                Me.GirlDataSet.Terceiros.Clear()
                Me.TerceirosTableAdapter.Fill(Me.GirlDataSet.Terceiros)
            Else
                MsgBox("Já Existem registos para esse Terceiro!")
            End If




        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btApagar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btApagar_Click")
        End Try


    End Sub

    Private Sub tbCodigo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tbCodigo.Validating

        Dim db As New ClsSqlBDados
        Try

            'VERIFICAR SE EXISTE
            Sql = "SELECT COUNT(*) FROM TERCEIROS WHERE TERCID='" & Me.tbCodigo.Text & "'"
            If db.GetDataValue(Sql) > 0 Then
                MsgBox("Esse Terceiro já existe")
                tbCodigo.Text = ""
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "lbCodigo_Validating")
        Catch ex As Exception
            ErroVB(ex.Message, "lbCodigo_Validating")
        End Try



    End Sub





    'NA GRID

    Private Sub dgvListaTerc_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvListaTerc.SelectionChanged

        Try


            If dgvListaTerc.CurrentRow IsNot Nothing Then
                ActualizaDados(Me.dgvListaTerc("TercID", dgvListaTerc.CurrentRow.Index).Value.ToString)
            End If

        Catch ex As Exception

        End Try


    End Sub


    'FUNÇÕES

    Private Sub Limpar()

        Try



            Me.tbCodigo.Text = ""
            Me.cbTipoTerc.Text = ""
            Me.tbNome.Text = ""
            Me.tbNomeAbrev.Text = ""
            Me.tbMorada.Text = ""
            Me.tbCodPostal.Text = ""
            Me.tbLocalidade.Text = ""
            Me.cbPaisID.Text = ""
            Me.tbNIF.Text = ""
            Me.tbContacto.Text = ""
            Me.tbTelefone.Text = ""
            Me.tbMovel.Text = ""
            Me.tbEmail.Text = ""
            Me.tbSite.Text = ""
            Me.tbObs.Text = ""

            tbCodigo.Enabled = False
            tbNIF.Enabled = False


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "Limpar")
        Catch ex As Exception
            ErroVB(ex.Message, "Limpar")

        End Try

    End Sub

    Private Sub ActualizaDados(ByVal sTerc As String)

        Dim db As New ClsSqlBDados
        Dim dt As New DataTable
        Try




            Sql = "SELECT TercID, TipoTerc, Nome, NomeAbrev, Morada, CodPostal, Localidade, PaisID, NIF, Contacto, Telefone, Movel, Fax, Email, Site, PPagID, ExpID, Obs, OperadorID, DtRegisto  FROM Terceiros WHERE TercID='" & sTerc & "'"
            db.GetData(Sql, dt, False)


            Select Case Trim(dt.Rows(0)("TipoTerc").ToString)
                Case "I"
                    cbTipoTerc.SelectedIndex = cbTipoTerc.FindString("Interno")
                Case "F"
                    cbTipoTerc.SelectedIndex = cbTipoTerc.FindString("Fornecedor")
                Case "C"
                    cbTipoTerc.SelectedIndex = cbTipoTerc.FindString("Cliente")
            End Select

            Select Case Trim(dt.Rows(0)("PaisID").ToString)
                Case "PT"
                    cbPaisID.SelectedIndex = cbPaisID.FindString("Portugal")
                Case "ES"
                    cbPaisID.SelectedIndex = cbPaisID.FindString("Espanha")
                Case "OO"
                    cbPaisID.SelectedIndex = cbPaisID.FindString("Outro")
            End Select

            Me.tbCodigo.Text = dt.Rows(0)("TercID").ToString
            Me.tbNome.Text = dt.Rows(0)("Nome").ToString
            Me.tbNomeAbrev.Text = dt.Rows(0)("NomeAbrev").ToString
            Me.tbMorada.Text = dt.Rows(0)("Morada").ToString
            Me.tbCodPostal.Text = dt.Rows(0)("CodPostal").ToString
            Me.tbLocalidade.Text = dt.Rows(0)("Localidade").ToString
            Me.tbNIF.Text = dt.Rows(0)("NIF").ToString
            Me.tbContacto.Text = dt.Rows(0)("Contacto").ToString
            Me.tbTelefone.Text = dt.Rows(0)("Telefone").ToString
            Me.tbMovel.Text = dt.Rows(0)("Movel").ToString
            Me.tbEmail.Text = dt.Rows(0)("Email").ToString
            Me.tbSite.Text = dt.Rows(0)("Site").ToString
            Me.tbObs.Text = dt.Rows(0)("Obs").ToString



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaDados")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaDados")
        End Try



    End Sub

    Private Function Validar() As Boolean


        Try


            If Not ValidarNifUE(sPaisAux, tbNIF.Text) Then
                MsgBox("O NIF Introduzido não é válido!!!")
                Return False
            End If

            'If Len(Me.tbCodigo.Text) <> 4 Then
            '    MsgBox("CÓDIGO : 4 DIGITOS")
            '    Return False
            'End If

            If Len(Me.tbNome.Text) > 80 Or Len(Me.tbNome.Text) < 4 Then
                MsgBox("NOME : MIN 4 MÁXIMO 80 DIGITOS")
                Return False
            End If

            If Len(Me.tbNomeAbrev.Text) > 25 Or Len(Me.tbNomeAbrev.Text) < 3 Then
                MsgBox("NOME ABREV. : MIN 2 MÁXIMO 25 DIGITOS")
                Return False
            End If

            If Len(Me.tbMorada.Text) > 160 Or Len(Me.tbMorada.Text) < 3 Then
                MsgBox("MORADA: MIN 2 MÁXIMO 160 DIGITOS")
                Return False
            End If

            If Len(Me.tbLocalidade.Text) > 20 Or Len(Me.tbLocalidade.Text) < 3 Then
                MsgBox("LOCALIDADE: MIN 2 MÁXIMO 20 DIGITOS")
                Return False
            End If

            If Len(Me.tbCodPostal.Text) > 20 Or Len(Me.tbCodPostal.Text) < 4 Then
                MsgBox("CODIGO POSTAL: MIN 4 MÁXIMO 20 DIGITOS")
                Return False
            End If

            If Len(Trim(tbCodPostal.Text)) < 8 Then
                MsgBox("Complete o Código Postal")
                Return False
            End If


            'If Len(Me.tbNIF.Text) > 15 Or Len(Me.tbNIF.Text) < 4 Then
            '    MsgBox("NIF: MIN 4 MÁXIMO 15 DIGITOS")
            '    Return False
            'End If

            'If Len(cbPaisID.SelectedItem.ToString) = 0 Then
            '    MsgBox("FALTA O PAÍS")
            '    Return False
            'End If

            If Len(cbTipoTerc.SelectedItem.ToString) = 0 Then
                MsgBox("FALTA O TIPO DE TERCEIRO")
                Return False
            End If



            If Me.cbPaisID.SelectedItem = "Portugal" Then

                'VALIDAR NIF E CODIGO POSTAL PARA PORTUGAL......
                'ESTA VALIDAÇÃO DO NIF ESTÁ REDUNDANTE........
                If Len(Trim(Me.tbNIF.Text)) <> 9 Or Not IsValidContrib(Trim(Me.tbNIF.Text)) Then
                    'If MsgBox("Nº Contribuinte Inválido!!", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                    '    Me.tbNIF.Text = ""
                    '    Me.cbPaisID.Focus()
                    'End If
                    MsgBox("Nº Contribuinte Inválido!!")
                    Return False
                End If

                'VALIDAR CÓDIGO POSTAL
                If Len(Me.tbCodPostal.Text) < 8 Then
                    MsgBox("Verificar Código Postal!")
                    Return False
                End If

            End If

            Return True

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "Validar")
        Catch ex As Exception
            ErroVB(ex.Message, "Validar")
        End Try

    End Function

    Private Sub tbCodPostal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        IsValidZip(tbCodigo.Text)
    End Sub



    Private Sub cbPaisID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbPaisID.Validating

        Try
            If Me.cbPaisID.SelectedItem = "Espanha" Then
                lbNifEspanha.Visible = True
            Else
                lbNifEspanha.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub


End Class