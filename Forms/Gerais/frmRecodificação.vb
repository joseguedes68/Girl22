Imports System.Data.SqlClient


Public Class frmRecodificacao


    Private Sub frmRecodificacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ModelosTableAdapter.Fill(Me.GirlDataSet.Modelos)

        Me.cbModeloOrigem.DataSource = Me.ModelosBindingSource
        Me.cbModeloOrigem.DisplayMember = "ModeloID"
        Me.cbModeloOrigem.ValueMember = "ModeloID"



    End Sub

    Private Sub btRecodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRecodificar.Click
        Dim db As New ClsSqlBDados
        Dim xModelo As String
        Dim xModeloNovo As String
        Dim xCor As String


        Dim dt As New DataTable

        Try
            xModelo = Me.cbModeloOrigem.Text
            xModeloNovo = Me.tbModeloNovo.Text

            If Len(xModeloNovo) > 0 Then
                Sql = "SELECT COUNT(*) FROM MODELOS WHERE ModeloID='" & xModeloNovo & "'"
                If db.GetDataValue(Sql) = 0 Then
                    If MsgBox("Confirma alteração do Modelo " & xModelo & " para Modelo " & xModeloNovo, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Sql = "SELECT ModeloID, CorID from ModeloCor where ModeloID='" & xModelo & "'"
                        db.GetData(Sql, dt)
                        If dt.Rows.Count > 0 Then
                            For Each r As DataRow In dt.Rows
                                xCor = r("CorID")
                                If My.Computer.FileSystem.FileExists(xFotosPath + xModelo + xCor + ".jpg") = True Then
                                    If My.Computer.FileSystem.FileExists(xFotosPath + xModeloNovo + xCor + ".jpg") = False Then
                                        My.Computer.FileSystem.RenameFile(xFotosPath + xModelo + xCor + ".jpg", xModeloNovo + xCor + ".jpg")
                                        'If My.Computer.FileSystem.GetFileInfo(xFotosPath + xModelo + xCor + ".jpg").IsReadOnly = True Then
                                    End If
                                End If
                            Next
                        End If

                        'VERIFICAR SE EXISTE



                        Sql = "UPDATE MODELOS SET ModeloID='" & xModeloNovo & "' WHERE ModeloID='" & xModelo & "'; " & _
                            "UPDATE SERIE SET ModeloID='" & xModeloNovo & "' WHERE ModeloID='" & xModelo & "'; " & _
                            "UPDATE DocDet SET ModeloID='" & xModeloNovo & "' WHERE ModeloID='" & xModelo & "' AND TipoDocID IN ('CF','DC','DF','EC','RC','RE','SE'); " & _
                            "UPDATE Encomendas SET ModeloID='" & xModeloNovo & "' WHERE ModeloID='" & xModelo & "'; " & _
                            "UPDATE PRECOVENDA SET ModeloID='" & xModeloNovo & "' WHERE ModeloID='" & xModelo & "'; "
                        db.ExecuteData(Sql)
                    Else
                        MsgBox("Operação Cancelada!")
                    End If
                Else
                    MsgBox("O Modelo " & xModeloNovo & " já existe!")
                End If
            End If


        Catch ex As SqlException
            'ErroSQL(ex.Number, ex.Message, "btRecodificar_Click")
            MsgBox("TEM QUE FECHAR A APLICAÇÃO EM TODOS OS TERMINAIS! VERIFICAR A FOTO!")
        Catch ex As Exception
            MsgBox("TEM QUE FECHAR A APLICAÇÃO E AS FOTOS EM TODOS OS TERMINAIS!")
            'ErroVB(ex.Message, "btRecodificar_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            If Not dt Is Nothing Then dt.Dispose()
            dt = Nothing

        End Try
    End Sub

    Private Sub btTranfStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTranfStock.Click
        Dim db As New ClsSqlBDados
        Dim xModelo As String
        Dim xCor As String
        Dim xModeloNovo As String



        Dim dt As New DataTable

        Try
            xModelo = Me.cbModeloOrigem.Text
            xModeloNovo = Me.tbModeloNovo.Text
            If Len(xModeloNovo) > 0 Then
                Sql = "SELECT COUNT(*) FROM MODELOS WHERE ModeloID='" & xModeloNovo & "'"
                If db.GetDataValue(Sql) > 0 Then

                    Sql = "SELECT ModeloID, CorID from ModeloCor where ModeloID='" & xModelo & "'"
                    db.GetData(Sql, dt)
                    If dt.Rows.Count > 0 Then
                        For Each r As DataRow In dt.Rows
                            xCor = r("CorID")
                            Sql = "SELECT count(*) from ModeloCor where ModeloID='" & xModeloNovo & "' and CorID='" & xCor & "'"
                            If db.GetDataValue(Sql) = 0 Then
                                MsgBox("Falta a cor " & xCor & " no Modelo " & xModeloNovo & Chr(13) & "ATENÇÃO À TABELA DE PREÇOS!")
                                Exit Sub
                            End If
                        Next
                    End If

                    If MsgBox("Confirma transferência dos talões do Modelo " & xModelo & " para Modelo " & xModeloNovo, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Sql = "UPDATE SERIE SET ModeloID='" & xModeloNovo & "' WHERE ModeloID='" & xModelo & "'; " & _
                           "UPDATE DocDet SET ModeloID='" & xModeloNovo & "' WHERE ModeloID='" & xModelo & "' AND TipoDocID IN ('CF','DC','DF','EC','RC','RE','SE'); " & _
                           "UPDATE Encomendas SET ModeloID='" & xModeloNovo & "' WHERE ModeloID='" & xModelo & "'; "
                        db.ExecuteData(Sql)

                        'APAGAR O MODELO ANTIGO
                        'If MsgBox("Pretende Apagar o Modelo antigo e a Fotografia?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        '    Sql = "SELECT ModeloID, CorID from ModeloCor where ModeloID='" & xModelo & "'"
                        '    db.GetData(Sql, dt)
                        '    If dt.Rows.Count > 0 Then
                        '        For Each r As DataRow In dt.Rows
                        '            xCor = r("CorID")
                        '            If My.Computer.FileSystem.FileExists(xFotosPath + xModelo + xCor + ".jpg") = True Then
                        '                My.Computer.FileSystem.DeleteFile(xFotosPath + xModelo + xCor + ".jpg")
                        '            End If
                        '        Next
                        '    End If
                        '    Sql = "DELETE MODELOS WHERE ModeloID='" & xModelo & "'"
                        '    db.ExecuteData(Sql)
                        'End If

                        'ALTERAÇÃO PEDIDA PELO FERNANDO - Vai limpar modelo sem perguntar e não apaga a foto
                        Sql = "DELETE MODELOS WHERE ModeloID='" & xModelo & "'"
                        db.ExecuteData(Sql)

                    Else
                        MsgBox("Operação Cancelada!")
                    End If
                Else
                    MsgBox("O Modelo " & xModeloNovo & " ainda não existe!")
                End If
            End If


        Catch ex As SqlException
            'ErroSQL(ex.Number, ex.Message, "btTranfStock_Click")
            MsgBox("TEM QUE FECHAR A APLICAÇÃO EM TODOS OS TERMINAIS! VERIFICAR A FOTO!")
        Catch ex As Exception
            MsgBox("TEM QUE FECHAR A APLICAÇÃO E AS FOTOS EM TODOS OS TERMINAIS!")
            'ErroVB(ex.Message, "btTranfStock_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            If Not dt Is Nothing Then dt.Dispose()
            dt = Nothing

        End Try

    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Close()
    End Sub




    'não usado

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim cnAuxKill As New SqlConnection
        Try


            sconnectionstring = "Data Source=" + xServidor + "\SQLEXPRESS;Initial Catalog=MASTER; Persist Security Info=True;UserID=sa;Password=gRANDEeNIGMA50768721330Lc42"

            cnAuxKill.ConnectionString = sconnectionstring

            Sql = "EXEC sp_kill_database_users @arg_dbname = '" & xBdados & "'"
            Cmd = New SqlCommand(Sql, cnAuxKill)
            If cnAuxKill.State = ConnectionState.Closed Then cnAuxKill.Open()
            Cmd.ExecuteNonQuery()



        Catch ex As SqlException

        Catch ex As Exception

        Finally
            cnAuxKill.Close()

        End Try


    End Sub





End Class