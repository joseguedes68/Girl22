Imports System.Data.SqlClient


Public Class frmReservas



    Dim CarregarFoto As New ClsFotos

    Dim xActualizaGeral As Boolean




    Private Sub ReservasBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservasBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ReservasBindingSource.EndEdit()
        Me.ReservasTableAdapter.Update(Me.GirlDataSet.Reservas)

    End Sub

    Private Sub frmReservas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        xFiltraDataGrid = ""
    End Sub

    Private Sub frmReservas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If SistemaBloqueado() = True Then
                Exit Sub
            End If


            'Me.ReservasTableAdapter.Fill(Me.GirlDataSet.Reservas)
            sReservasSinais = True
            Me.ReservasBindingNavigator.Visible = False

            cbVerTodos.Checked = False
            Me.ReservasDataGridView.Columns("ReservaSerieID").ReadOnly = False

            If xGrupoAcesso <> "ADMIN" Then
                ReservasDataGridView.AllowUserToDeleteRows = False
                ReservasDataGridView.Columns("ReservaSerieID").ReadOnly = True
                ReservasDataGridView.Columns("Despesas").ReadOnly = True
            End If

            xActualizaGeral = False
            'ActualizarDados()
            ActualizaEstadosReservas()
            CarregarDados()


            'VndPendentes()



        Catch ex As Exception
            ErroVB(ex.Message, "frmReservas_Load")
        End Try


    End Sub

    'RESERVASDATAGRIDVIEW

    Private Sub ReservasDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReservasDataGridView.CellEndEdit

        Me.Validate()
        Me.ReservasBindingSource.EndEdit()
        Me.ReservasTableAdapter.Update(Me.GirlDataSet.Reservas)


    End Sub

    Private Sub ReservasDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ReservasDataGridView.CellMouseClick

        Dim db As New ClsSqlBDados
        Dim sNIFCliente As String = ""

        Try

            If e.ColumnIndex < 0 Then
                Exit Sub
            End If

            If SistemaBloqueado() = True Then
                Exit Sub
            End If


            Dim dg As New clsDataGrid(Me.ReservasDataGridView, , Me.ReservasBindingSource)
            Try
                If e.Button = Windows.Forms.MouseButtons.Right Then

                    dg.MostraFiltroForm(e)


                Else

                    If ReservasDataGridView.Columns(e.ColumnIndex).Name = "ReservaSerieID" Then

                        If Len(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value) = 8 Then
                            MsgBox(SituacaoTalao(ReservasDataGridView("ReservaSerieID", e.RowIndex).Value), , "Situação da Reserva")
                        End If

                    End If

                    If ReservasDataGridView.Columns(e.ColumnIndex).Name = "ReservaNome" Then

                        If Len(Trim(ReservasDataGridView("ReservaNome", e.RowIndex).Value.ToString)) > 0 Then


                            Sql = "SELECT CAST(ClientesLoja.IDClienteLoja AS char(36)) FROM Reservas INNER JOIN ClientesLoja ON Reservas.ReservaClienteLojaID = ClientesLoja.ClienteLojaID WHERE (Reservas.ReservaID = " & ReservasDataGridView("ReservaIDDataGridViewTextBoxColumn", e.RowIndex).Value & ")"
                            sIDClienteLoja = db.GetDataValue(Sql)

                            Sql = "SELECT ClienteLojaID FROM ClientesLoja WHERE IDClienteLoja='" & sIDClienteLoja & "'"
                            If Trim(db.GetDataValue(Sql)) = "1" Then
                                Exit Sub
                            Else
                                frmClientesLojaLista.WindowState = FormWindowState.Normal
                                frmClientesLojaLista.StartPosition = FormStartPosition.CenterScreen
                                frmClientesLojaLista.ShowDialog(Me)
                            End If



                        End If

                    End If

                End If

            Catch ex As Exception
                ErroVB(ex.Message, Me.Name + ": IniciarDataGrid")
            Finally
                dg.Dispose()
                dg = Nothing
            End Try

        Catch ex As Exception

            ErroVB(ex.Message, Me.Name + ": ReservasDataGridView_CellMouseClick")
        End Try

    End Sub

    Private Sub ReservasDataGridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReservasDataGridView.SelectionChanged

        Try
            Dim xModelo As String = ""
            Dim xCor As String = ""
            If Not Me.ReservasDataGridView.CurrentCell Is Nothing Then
                If Not Me.ReservasDataGridView("ReservaModeloID", Me.ReservasDataGridView.CurrentCell.RowIndex).Value Is DBNull.Value Then
                    If Not Me.ReservasDataGridView("ReservaCorId", Me.ReservasDataGridView.CurrentCell.RowIndex).Value Is DBNull.Value Then
                        xModelo = Me.ReservasDataGridView("ReservaModeloID", Me.ReservasDataGridView.CurrentCell.RowIndex).Value
                        xCor = Me.ReservasDataGridView("ReservaCorId", Me.ReservasDataGridView.CurrentCell.RowIndex).Value
                    End If
                End If
                CarregarFoto.CarregarFotoModeloCor(Me.PictureBox, xModelo & xCor, "xok")
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ReservasDataGridView_SelectionChanged")
        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_SelectionChanged")
        End Try
    End Sub

    Private Sub ReservasDataGridView_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ReservasDataGridView.ColumnHeaderMouseClick
        Try
            Dim dv As New DataView
            dv = Me.GirlDataSet.Reservas.DefaultView
            Dim dg As New clsDataGrid(Me.ReservasDataGridView, , Me.ReservasBindingSource)
            Try
                If e.Button = Windows.Forms.MouseButtons.Right Then

                    dg.RemoverFiltro(e)

                End If
            Catch ex As Exception
                ErroVB(ex.Message, Me.Name + ": IniciarDataGrid")
            Finally
                dg.Dispose()
                dg = Nothing
            End Try
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": ReservasDataGridView_CellMouseClick")
        End Try
    End Sub

    Private Sub ReservasDataGridView_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles ReservasDataGridView.RowsRemoved

        Try

            btGravar_Click(sender, e)

        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_RowsRemoved")
        End Try


    End Sub

    Private Sub ReservasDataGridView_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles ReservasDataGridView.CellBeginEdit

        Try




            If Me.ReservasDataGridView.CurrentCell.ColumnIndex = 13 Then
                If ReservasDataGridView("Despesas", Me.ReservasDataGridView.CurrentRow.Index).Value > 0 Then
                    e.Cancel = True
                    MsgBox("Reserva com despesas associadas!!")
                End If
            End If

            If Me.ReservasDataGridView.CurrentCell.ColumnIndex = Me.ReservasDataGridView.Columns("Sinal").Index Then

                If DevolveGrupoAcesso() <> "ADMIN" Then
                    e.Cancel = True
                End If

            End If


            If Me.ReservasDataGridView.CurrentCell.ColumnIndex = Me.ReservasDataGridView.Columns("ReservaEstado").Index Then

                If Me.ReservasDataGridView("Sinal", ReservasDataGridView.CurrentRow.Index).Value > 0 Then

                    If DevolveGrupoAcesso() <> "ADMIN" Then
                        MsgBox("Tem um sinal associado, não pode fechar!")
                        e.Cancel = True

                    End If

                End If

            End If


        Catch ex As Exception

        End Try



    End Sub


    Private Sub ReservasDataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReservasDataGridView.RowEnter

        Try

            If ReservasDataGridView("ReservaEstado", e.RowIndex).Value = "1" Then
                ReservasDataGridView.Rows(e.RowIndex).ReadOnly = True
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "ReservasDataGridView_RowEnter")
        End Try

    End Sub

    'EVENTOS

    Private Sub btGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If Not GirlDataSet.Reservas.GetChanges Is Nothing Then
                Me.Validate()
                Me.ReservasBindingSource.EndEdit()
                Me.ReservasTableAdapter.Update(Me.GirlDataSet.Reservas)
                Me.GirlDataSet.Reservas.AcceptChanges()

            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btGravar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btGravar_Click")
        End Try


    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        sReservasSinais = False
        Me.GirlDataSet.Reservas.Clear()
        xFiltraDataGrid = ""
        Me.Close()
    End Sub

    Private Sub btInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInserir.Click
        GravarReserva()
    End Sub

    'Private Sub cbVerTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodos.Click
    '    Cursor = Cursors.WaitCursor
    'End Sub

    Private Sub cbVerTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodos.CheckedChanged
        Cursor = Cursors.WaitCursor
        xActualizaGeral = True
        'ActualizarDados()  NÃO SEI MUITO BEM AS CONSEQUENCIAS DE TIRAR ISTO???
        CarregarDados()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btListaTrasf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListaTrasf.Click

        Dim db As New ClsSqlBDados

        Dim I As Integer
        Dim xDestino As String = ""
        Dim xModelo As String = ""
        Dim xCor As String = ""
        Dim xTam As String = ""
        Dim xTalao As String = ""
        Dim xDescr As String = ""
        Dim dt As New DataTable
        Dim xReservaID As String = ""




        Try

            Me.GirlDataSet.ApoioTrasf.Clear()


            If Len(xFiltraDataGrid) = 0 Then
                Me.ReservasBindingSource.Filter = "ArmzDest<>'" & xArmz & "' AND ArmazemID='" & xArmz & "' AND ReservaEstado=0"
            Else
                Me.ReservasBindingSource.Filter = "ArmzDest<>'" & xArmz & "' AND ArmazemID='" & xArmz & "' AND ReservaEstado=0 AND " & xFiltraDataGrid
            End If
            Me.ReservasBindingSource.Sort = "ArmzDest ASC, ReservaModeloId ASC,ReservaCorId ASC,ReservaTamId ASC"


            If ReservasDataGridView.Rows.Count > 0 Then

                For I = 0 To Me.ReservasDataGridView.Rows.Count - 1
                    If Me.ReservasDataGridView("ReservaArmazemID", I).Value.ToString = xArmz Then
                        xDestino = Me.ReservasDataGridView("ReservaArmzDest", I).Value.ToString
                        xModelo = Me.ReservasDataGridView("ReservaModeloID", I).Value.ToString
                        xCor = Me.ReservasDataGridView("ReservaCorID", I).Value.ToString
                        Do While Me.ReservasDataGridView("ReservaArmzDest", I).Value.ToString = xDestino _
                                And Me.ReservasDataGridView("ReservaModeloID", I).Value.ToString = xModelo _
                                And Me.ReservasDataGridView("ReservaCorID", I).Value.ToString = xCor
                            xTam = Me.ReservasDataGridView("ReservaTamID", I).Value.ToString
                            xTalao = Me.ReservasDataGridView("ReservaSerieID", I).Value.ToString
                            xDescr = xDescr + xTam + " - " + xTalao + "  "
                            xReservaID = "'" & Me.ReservasDataGridView("ReservaIDDataGridViewTextBoxColumn", I).Value.ToString & "'," + xReservaID
                            I = I + 1
                            If I >= Me.ReservasDataGridView.Rows.Count Then Exit Do
                        Loop
                        I = I - 1
                        Me.GirlDataSet.ApoioTrasf.AddApoioTrasfRow(xDestino, xModelo, xCor, xDescr)
                        xDescr = ""
                    End If
                Next
                xReservaID = Microsoft.VisualBasic.Left(xReservaID, Len(xReservaID) - 1)

                dtAuxReport = Me.GirlDataSet.ApoioTrasf

                ''PARA IMPRIMIR DIRECTO PARA A IMPRESSORA...
                'Dim cryRpt As New CRTransferencias
                'cryRpt.SetDataSource(dtAuxReport)
                'cryRpt.SetParameterValue("Origem", xArmz)
                'cryRpt.PrintToPrinter(1, False, 0, 0)

                NListagem = "TRASFERENCIAS"
                Pausa = True
                frmCRReports.Show(Me)
                'Application.DoEvents()

                'frmRptTransf.ShowDialog(Me)


                Do While Pausa = True
                    Application.DoEvents()
                Loop



                If xArmz = "0000" Then
                    If MsgBox("QUER FECHAR OS REGISTOS LISTADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'O SEGUINTE UPDATE QUE ESTÁ COMENTADO 
                        'DEPOIS DE LISTAR -- LIMPA OS ARTIGOS '8*'  ----  O UPDATE ATIVO NÃO LIMPA
                        'Sql = "UPDATE RESERVAS SET ReservaEstado=1, OperadorID='" & xUtilizador & "' WHERE ArmazemID='" & xArmz & "' AND ArmzDest<>ArmazemID AND ReservaEstado=0 AND ReservaID in (" & xReservaID & ") AND ReservaModeloID not like '8%'"

                        Sql = "UPDATE RESERVAS SET ReservaEstado=1, OperadorID='" & xUtilizador & "' WHERE ArmazemID='" & xArmz & "' AND ArmzDest<>ArmazemID AND ReservaEstado=0 AND ReservaID in (" & xReservaID & ") AND ReservaModeloID not like '8%'"
                        db.ExecuteData(Sql)
                        CarregarDados()
                    End If
                End If

            Else
                MsgBox("NÃO TEM TRANSFERÊNCIAS PENDENTES!!")
            End If
            xReservaID = ""
            ReservasBindingSource.Filter = ""




        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btListaTrasf_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btListaTrasf_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try





    End Sub

    Private Sub btAtualiza_Click(sender As System.Object, e As System.EventArgs) Handles btAtualiza.Click
        ActualizaEstadosReservas()
        MsgBox("Actualização Concluida!")
    End Sub





    'FUNÇÕES

    Private Sub GravarReserva()

        Dim db As New ClsSqlBDados
        Try
            Dim xReserva As String = Trim(Me.tbDescr.Text) & Trim(Me.tbModelo.Text)
            If xReserva.Length > 0 Then
                'Me.ReservasDataGridView.Rows.Add()
                Sql = "INSERT INTO Reservas (ArmazemID, ReservaDescr,ReservaModeloId, ReservaCorId, ReservaTamId, ReservaData, ReservaEstado) " & _
                        "VALUES ('" & xArmz & "','" & Me.tbDescr.Text & "','" & Me.tbModelo.Text & "','" & Me.tbCor.Text & "','" & Me.tbTam.Text & "',GETDATE(),'0')"
                db.ExecuteData(Sql)

                Me.tbDescr.Text = ""
                Me.tbModelo.Text = ""
                Me.tbCor.Text = ""
                Me.tbTam.Text = ""

                CarregarDados()


            End If


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " btGravaReserva_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub CarregarDados()
        Try
            Me.GirlDataSet.Reservas.Clear()
            If cbVerTodos.Checked = True Then

                If xArmz = "0000" Then
                    Me.ReservasTableAdapter.FillByArmz(Me.GirlDataSet.Reservas, "%")
                Else
                    Me.ReservasTableAdapter.FillByArmz(Me.GirlDataSet.Reservas, xArmz)
                End If
            Else
                If xArmz = "0000" Then
                    Me.ReservasTableAdapter.FillByArmzAbertos(Me.GirlDataSet.Reservas, "%")
                Else
                    Me.ReservasTableAdapter.FillByArmzAbertos(Me.GirlDataSet.Reservas, xArmz)
                End If
            End If

            If xArmz <> "0000" Then
                Me.ReservasDataGridView.Columns("ReservaArmazemID").Visible = False
                Me.ReservasDataGridView.Columns("Fornecedor").Visible = False
            End If

            Me.ReservasDataGridView.RowHeadersWidth = Me.ReservasDataGridView.ColumnHeadersHeight + 10
            'tbDescr.MaxLength = 60



        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": CarregarDados")
        End Try
    End Sub

    Private Sub ActualizarDados()



        Dim db As New ClsSqlBDados

        Try

            'Sql = "DELETE FROM RESERVAS WHERE ReservaDescr='Transferir' and ReservaEstado='1' "
            'db.ExecuteData(Sql)

            'Sql = "Update Reservas SET EstadoTalao = isnull(Serie.EstadoID+'/'+Serie.ArmazemID,'xxx'), ReservaForn = Terceiros.NomeAbrev FROM Serie RIGHT OUTER JOIN Reservas LEFT OUTER JOIN Terceiros INNER JOIN ModeloCor ON Terceiros.TercID = ModeloCor.FornID ON Reservas.ReservaModeloId = ModeloCor.ModeloID AND Reservas.ReservaCorId = ModeloCor.CorID ON Serie.SerieID = Reservas.ReservaSerieID; UPDATE Reservas SET EstadoTalao='Stk'+RIGHT(EstadoTalao,5) WHERE LEFT(EstadoTalao,1)='S'; UPDATE Reservas SET EstadoTalao='Sep' + '/' + DocCab.TercID FROM Reservas INNER JOIN DocDet ON Reservas.reservaserieid = DocDet.SerieID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.EstadoLn = 'G') AND (DocCab.TipoDocID = 'SE'); UPDATE Reservas SET EstadoTalao='Tra'+RIGHT(EstadoTalao,5) WHERE LEFT(EstadoTalao,1)='T';"
            'db.ExecuteData(Sql)

            Sql = "Update Reservas SET EstadoTalao = ISNULL(Serie.EstadoID,'xx'), ArmazemActual = ISNULL(Serie.ArmazemID,'xxxx'), ReservaForn = Terceiros.NomeAbrev  FROM Serie RIGHT OUTER JOIN Reservas  LEFT OUTER JOIN Terceiros  INNER JOIN ModeloCor  ON Terceiros.TercID = ModeloCor.FornID  ON Reservas.ReservaModeloId = ModeloCor.ModeloID  AND Reservas.ReservaCorId = ModeloCor.CorID  ON Serie.SerieID = Reservas.ReservaSerieID;  UPDATE Reservas SET EstadoTalao='Gerado'  WHERE LEFT(EstadoTalao,1)='G'; UPDATE Reservas SET EstadoTalao='Stock'  WHERE LEFT(EstadoTalao,1)='S';  UPDATE Reservas SET EstadoTalao='Transito' WHERE LEFT(EstadoTalao,1)='T'; UPDATE Reservas SET EstadoTalao='Vendido'  WHERE LEFT(EstadoTalao,1)='V';  UPDATE Reservas SET EstadoTalao='Recolhido' WHERE LEFT(EstadoTalao,1)='R'; UPDATE Reservas SET EstadoTalao='Anulado' WHERE LEFT(EstadoTalao,1)='A'; UPDATE Reservas SET EstadoTalao='Separado'  FROM Reservas INNER JOIN DocDet  ON Reservas.reservaserieid = DocDet.SerieID  INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID  AND DocDet.ArmazemID = DocCab.ArmazemID  AND DocDet.TipoDocID = DocCab.TipoDocID  AND DocDet.DocNr = DocCab.DocNr  WHERE (DocDet.EstadoLn = 'G') AND (DocCab.TipoDocID = 'SE') AND (RTRIM(LTRIM(Reservas.EstadoTalao)) <> 'Transito');  UPDATE Reservas SET ArmazemActual = Serie.ArmazemID FROM Reservas INNER JOIN Serie ON Reservas.ReservaSerieID = Serie.SerieID;"
            db.ExecuteData(Sql)


            If xActualizaGeral = True Then

                Sql = "UPDATE Reservas SET SituacaoActual=''"
                db.ExecuteData(Sql)

                Sql = "UPDATE Reservas SET SituacaoActual=N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) + ' ' + Reservas.EstadoTalao + ' C-' + cast(cast(DocCab.TercID as int) as varchar) FROM Reservas INNER JOIN DocDet  ON Reservas.reservaserieid = DocDet.SerieID  INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID  AND DocDet.ArmazemID = DocCab.ArmazemID  AND DocDet.TipoDocID = DocCab.TipoDocID  AND DocDet.DocNr = DocCab.DocNr  WHERE (DocDet.EstadoLn = 'G') AND (DocCab.TipoDocID = 'SE');"
                db.ExecuteData(Sql)


                Sql = "UPDATE Reservas SET SituacaoActual = EstadoTalao + N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) WHERE (LEN(ISNULL(SituacaoActual, '')) = 0) AND ArmazemActual <> 'xxxx'"
                db.ExecuteData(Sql)

                Sql = "UPDATE Reservas SET ReservaEstado = 1 WHERE ((EstadoTalao IN ('Transito','Separado') AND ReservaDescr like 'Transferir%') OR EstadoTalao IN ('Vendido', 'Recolhido','Anulado')) "
                db.ExecuteData(Sql)

            Else

                Sql = "UPDATE Reservas SET SituacaoActual='' WHERE Reservas.ReservaEstado = 0"
                db.ExecuteData(Sql)

                Sql = "UPDATE Reservas SET SituacaoActual=N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) + ' ' + Reservas.EstadoTalao + ' C-' + cast(cast(DocCab.TercID as int) as varchar) FROM Reservas INNER JOIN DocDet  ON Reservas.reservaserieid = DocDet.SerieID  INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID  AND DocDet.ArmazemID = DocCab.ArmazemID  AND DocDet.TipoDocID = DocCab.TipoDocID  AND DocDet.DocNr = DocCab.DocNr  WHERE (DocDet.EstadoLn = 'G') AND (DocCab.TipoDocID = 'SE') AND (Reservas.ReservaEstado = 0);"
                db.ExecuteData(Sql)


                Sql = "UPDATE Reservas SET SituacaoActual = EstadoTalao + N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) WHERE (LEN(ISNULL(SituacaoActual, '')) = 0) AND ReservaEstado = 0 AND ArmazemActual <> 'xxxx'"
                db.ExecuteData(Sql)

                Sql = "UPDATE Reservas SET ReservaEstado = 1 WHERE ((EstadoTalao IN ('Transito','Separado') AND ReservaDescr like 'Transferir%') OR EstadoTalao IN ('Vendido', 'Recolhido','Anulado')) AND ReservaEstado =0 "
                db.ExecuteData(Sql)


            End If

            'Sql = "UPDATE Reservas SET ReservaEstado = 1 WHERE LEFT(EstadoTalao,1) IN ('S','V','R','F') AND RIGHT(EstadoTalao,4)=ArmazemID AND ArmzDest=ArmazemID AND ReservaEstado =0"
            'Sql = "UPDATE Reservas SET ReservaEstado = 1 WHERE (ArmzDest = ArmazemActual or EstadoTalao IN ('Vendido', 'Recolhido','Anulado')) AND ReservaEstado =0 AND ReservaDescr='Transferir'"

            Sql = "UPDATE RESERVAS SET RESERVADESCR=' ' WHERE RESERVADESCR IS NULL "
            db.ExecuteData(Sql)

            'Sql = "UPDATE SERIE SET SERIE.Obs = N'MED:C-' + rtrim(R.ArmazemID*1) + ' ' + R.ReservaDescr FROM SERIE, Reservas R " & _
            '    "Where SERIE.SerieID = R.ReservaSerieID AND ReservaEstado = '0' AND (R.ReservaDescr <> N'Transferir')"
            'db.ExecuteData(Sql)

            db = Nothing

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizarDados")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizarDados")
        End Try

    End Sub

    Private Function SituacaoTalao(ByVal xTalao As String) As String

        Dim db As New ClsSqlBDados
        Dim xSituacaoTalao As String = ""


        Try


            Sql = "SELECT ARMAZEMID FROM SERIE WHERE SERIEID='" & xTalao & "'"
            Dim xArmazemActual As String = db.GetDataValue(Sql)

            Sql = "SELECT EstadoID FROM SERIE WHERE SERIEID='" & xTalao & "'"
            Dim xEstadoActual As String = db.GetDataValue(Sql)

            Sql = "SELECT DocCab.TercID Destino FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.EstadoLn = 'G') AND (DocDet.SerieID = '" & xTalao & "') AND (DocCab.TipoDocID = 'SE') GROUP BY DocCab.TercID"
            Dim xArmDestino As String = db.GetDataValue(Sql)

            Select Case xEstadoActual
                Case "G"
                    xEstadoActual = "Gerado"
                Case "S"
                    If xArmDestino = Nothing Then
                        xEstadoActual = "Stock C-" & xArmazemActual
                    Else
                        xEstadoActual = "Stock C-" & xArmazemActual & " Separado C-" & xArmDestino
                    End If
                Case "T"
                    If xArmDestino = Nothing Then
                        xEstadoActual = "ERRO"
                    Else
                        xEstadoActual = "Stock C-" & xArmazemActual & " Transito C-" & xArmDestino
                    End If
                Case "V"
                    xEstadoActual = "Vendido C-" & xArmazemActual
                Case "R"
                    xEstadoActual = "Recolhido C-" & xArmazemActual
                Case "A"
                    xEstadoActual = "Anulado"
            End Select


            'Sql = "UPDATE Reservas SET SituacaoActual=N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) + ' ' + Reservas.EstadoTalao + ' C-' + cast(cast(DocCab.TercID as int) as varchar) FROM Reservas INNER JOIN DocDet  ON Reservas.reservaserieid = DocDet.SerieID  INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID  AND DocDet.ArmazemID = DocCab.ArmazemID  AND DocDet.TipoDocID = DocCab.TipoDocID  AND DocDet.DocNr = DocCab.DocNr  WHERE (DocDet.EstadoLn = 'G') AND (DocCab.TipoDocID = 'SE');"
            'db.ExecuteData(Sql)


            'Sql = "UPDATE Reservas SET SituacaoActual = EstadoTalao + N' C-' + CAST(CAST(ArmazemActual AS int) AS varchar) WHERE (LEN(ISNULL(SituacaoActual, '')) = 0) AND ArmazemActual <> 'xxxx'"
            'db.ExecuteData(Sql)


            'Sql = "UPDATE Reservas SET ReservaEstado = 1 WHERE ((EstadoTalao IN ('Transito','Separado') AND ReservaDescr like 'Transferir%') OR EstadoTalao IN ('Vendido', 'Recolhido','Anulado')) "
            'db.ExecuteData(Sql)


            Return xEstadoActual



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizarDados")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizarDados")
        Finally
            db = Nothing
        End Try

    End Function

    Private Sub VndPendentes()

        Dim db As New ClsSqlBDados

        Try


            'AVISO DE VENDAS PENDENTES
            Dim dtVndPendentes As New DataTable
            Dim xVndPend As String = ""
            'Sql = "SELECT Reservas.ReservaSerieID FROM Reservas INNER JOIN Serie ON Reservas.ReservaSerieID = Serie.SerieID WHERE (Reservas.Despesas > 0) AND (Serie.EstadoID = 'S') AND (Serie.ArmazemID = Reservas.ArmzDest) AND (Serie.ArmazemID = '" & xArmz & "')"
            ' PARA JÁ VOU ALTERAR AS DESPESAS PELO SINAL.....
            'Sql = "SELECT Reservas.ReservaSerieID FROM Reservas INNER JOIN Serie ON Reservas.ReservaSerieID = Serie.SerieID WHERE (Reservas.Sinal > 0) AND (Serie.EstadoID = 'S') AND (Serie.ArmazemID = Reservas.ArmzDest) AND (Serie.ArmazemID = '" & xArmz & "')"
            Sql = "SELECT Reservas.ReservaSerieID FROM Reservas INNER JOIN Serie ON Reservas.ReservaSerieID = Serie.SerieID AND Reservas.ArmzDest = Serie.ArmazemID WHERE Reservas.Sinal > 0 AND Serie.EstadoID = 'S' AND Serie.ArmazemID = '" & xArmz & "' AND Reservas.ReservaEstado = 0"

            db.GetData(Sql, dtVndPendentes, False)
            For Each r As DataRow In dtVndPendentes.Rows
                xVndPend += r("ReservaSerieID") + "  "
            Next
            If Len(xVndPend) > 0 Then
                MsgBox("Dar baixa da medida: " & xVndPend, MsgBoxStyle.Exclamation, "MEDIDAS PENDENTES")
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": VndPendentes")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": VndPendentes")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub




End Class