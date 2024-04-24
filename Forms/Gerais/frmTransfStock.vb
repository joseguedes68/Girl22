Imports System.Data.SqlClient
Imports System.IO


Public Class frmTransfStock


    Private Sub frmRecodificacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ModelosTableAdapter.Fill(Me.GirlDataSet.Modelos)

        Me.cbModeloOrigem.DataSource = Me.BindingSource1
        Me.cbModeloOrigem.DisplayMember = "ModeloID"
        Me.cbModeloOrigem.ValueMember = "ModeloID"

        Me.cbModeloDestino.DataSource = Me.BindingSource2
        Me.cbModeloDestino.DisplayMember = "ModeloID"
        Me.cbModeloDestino.ValueMember = "ModeloID"


    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Close()
    End Sub

    Private Sub btTranfStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTranfStock.Click

        'Dim dbCelfGest As New ClsSqlBDados
        Dim db As New ClsSqlBDados

        Dim xModeloOrigem As String
        Dim xModeloDestino As String
        Dim xCor As String

        Dim dt As New DataTable

        Try
            xModeloOrigem = Me.cbModeloOrigem.Text
            xModeloDestino = Me.cbModeloDestino.Text

            If MsgBox("Confirma a transferência de stock do Modelo " & xModeloOrigem & " para Modelo " & xModeloDestino, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Sql = "SELECT ModeloID, CorID from ModeloCor where ModeloID='" & xModeloOrigem & "'"
                db.GetData(Sql, dt)
                If dt.Rows.Count > 0 Then
                    For Each r As DataRow In dt.Rows
                        xCor = r("CorID")
                        Sql = "SELECT ModeloID, CorID from ModeloCor where ModeloID='" & xModeloDestino & "' AND CorID='" & xCor & "'"
                        If db.GetDataValue(Sql) = 0 Then
                            MsgBox("A Cor Nº" & xCor & " não existe! " & Chr(13) & "Não vai ser exportar essa cor!")
                        Else

                            If My.Computer.FileSystem.FileExists(xFotosPath + xModeloOrigem + xCor + ".jpg") = True Then
                                If My.Computer.FileSystem.FileExists(xFotosPath + xModeloDestino + xCor + ".jpg") = False Then

                                    Try
                                        My.Computer.FileSystem.CopyFile(xFotosPath + xModeloOrigem + xCor + ".jpg", xModeloDestino + xCor + ".jpg", True)
                                    Catch ex As Exception
                                        MessageBox.Show("Ocorreu um erro não foi possivel copiar a foto: " & ex.Message)
                                    End Try

                                End If
                            End If

                            Sql = "UPDATE SERIE SET ModeloID='" & xModeloDestino & "' WHERE ModeloID='" & xModeloOrigem & "' AND CorID='" & xCor & "'; " &
                               "UPDATE DocDet SET ModeloID='" & xModeloDestino & "' WHERE ModeloID='" & xModeloOrigem & "' AND TipoDocID IN ('CF','DC','DF','EC','RC','RE','SE') AND CorID='" & xCor & "'; " &
                               "UPDATE Encomendas SET ModeloID='" & xModeloDestino & "' WHERE ModeloID='" & xModeloOrigem & "' AND CorID='" & xCor & "'; "
                            db.ExecuteData(Sql)

                            'ACTUALIZAR PREÇOS (vou reaplicar tabelas já aplicadas logo já tem comissão)
                            Dim dtArmAux As New DataTable
                            Sql = "SELECT ArmazemID, TabPrecoId FROM Armazens where Activo='1'"
                            db.GetData(Sql, dtArmAux)
                            For Each r1 As DataRow In dtArmAux.Rows

                                Sql = "UPDATE Serie SET PrecoVenda = TabPVP.PVP FROM (SELECT ModeloCor.ModeloID, ModeloCor.CorID, ISNULL(TabPV.Preco, ModeloCor.PrVnd) AS PVP FROM (SELECT ModeloID, CorID, TabPrecoID, Preco FROM PrecoVenda WHERE (TabPrecoID = '" & r1("TabPrecoId") & "')) AS TabPV RIGHT OUTER JOIN ModeloCor ON TabPV.ModeloID = ModeloCor.ModeloID AND TabPV.CorID = ModeloCor.CorID) AS TabPVP INNER JOIN Serie ON TabPVP.ModeloID = Serie.ModeloID AND TabPVP.CorID = Serie.CorID AND TabPVP.PVP <> Serie.PrecoVenda WHERE (Serie.EstadoID IN ('G', 'S', 'T')) AND (Serie.PrFixo <> 1) AND (Serie.ModeloID = '" & xModeloDestino & "') AND (Serie.CorID = '" & xCor & "')"
                                db.ExecuteData(Sql)

                            Next

                        End If
                    Next
                End If
                MsgBox("Processo Concluido!")
            Else
                MsgBox("Operação Cancelada!")
            End If

        Catch ex As SqlException
            'ErroSQL(ex.Number, ex.Message, "btRecodificar_Click")
            MsgBox("TEM QUE FECHAR A APLICAÇÃO EM TODOS OS TERMINAIS! VERIFICAR A FOTO!")
        Catch ex As Exception
            MsgBox("TEM QUE FECHAR A APLICAÇÃO E AS FOTOS EM TODOS OS TERMINAIS!")
            'ErroVB(ex.Message, "btRecodificar_Click")
        Finally
            If Not dt Is Nothing Then dt.Dispose()
            dt = Nothing
            If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")
        End Try

    End Sub

End Class