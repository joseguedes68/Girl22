
Imports System.Data.SqlClient


Public Class frmInserirReserva


    Friend xClienteLojaID As String


    Private Sub btEditaReservas_Click(sender As System.Object, e As System.EventArgs) Handles btEditaReservas.Click
        Dim frm As New frmReservas
        'frm.MdiParent = Me
        'frm.WindowState = FormWindowState.Maximized
        'frm.Show()


        'frmReservas.MdiParent = Me
        'frmReservas.WindowState = FormWindowState.Maximized
        'frmReservas.Show()


        xEditaReserva = True
        frm.StartPosition = FormStartPosition.CenterParent
        frm.WindowState = FormWindowState.Normal
        'frmReservas.Width = 900
        'frmReservas.Height = 620
        frm.ShowInTaskbar = False
        frm.MaximizeBox = False
        frm.MinimizeBox = False
        frm.ShowDialog(Me)
    End Sub

    Private Sub btCliente_Click(sender As System.Object, e As System.EventArgs) Handles btCliente.Click

        If SistemaBloqueado() = True Then
            Exit Sub
        End If

        Dim db As New ClsSqlBDados

        sIDClienteLoja = ""
        frmClientesLojaLista.WindowState = FormWindowState.Normal
        frmClientesLojaLista.StartPosition = FormStartPosition.CenterScreen
        frmClientesLojaLista.ShowDialog(Me)

        ActualizarCliente(xClienteLojaID.ToString)

    End Sub

    Private Sub ActualizarCliente(ByRef iClienteID As Integer)

        Dim db As New ClsSqlBDados

        Try

            Sql = "SELECT NOME FROM CLIENTESLOJA WHERE CLIENTELOJAID='" & iClienteID & "'"
            lbCliente.Text = db.GetDataValue(Sql)
            xClienteLojaID = iClienteID.ToString



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizarCliente")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizarCliente")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Private Sub btGravaReserva_Click(sender As System.Object, e As System.EventArgs) Handles btGravaReserva.Click
        If tbSinal.Text > 0 Then
            GravarSinal()
        End If




        GravarReserva()

        Me.txtRModelo.Enabled = True
        Me.txtRCor.Enabled = True
        Me.txtRTam.Enabled = True
        Me.tbTalao.Enabled = True
        Me.txtRModelo.Text = ""
        Me.txtRCor.Text = ""
        Me.txtRTam.Text = ""
        Me.tbTalao.Text = ""



    End Sub

    Private Sub GravarReserva()
        Dim db As New ClsSqlBDados
        Dim AuxTipoReserva As String
        Dim xVarGrupo As String


        Try
            If Len(Trim(tbTalao.Text)) > 0 Then AuxTipoReserva = "R" Else AuxTipoReserva = "M"

            Dim xReserva As String = Trim(Me.tbReserva.Text) & Trim(Me.txtRModelo.Text) & Trim(Me.txtRCor.Text) & Trim(Me.txtRTam.Text)
            If xReserva.Length > 0 Then
                Sql = "select isnull(GrupoID,'') from Modelos where modeloid='" & txtRModelo.Text & "'"
                xVarGrupo = db.GetDataValue(Sql)
                If xVarGrupo = "6" Then Me.txtRTam.Text = "00"

                If Len(Trim(Me.tbReserva.Text)) = 0 Then Me.tbReserva.Text = "Medida"

                'Sql = "SELECT COUNT(*) FROM SERIE WHERE SERIEID='" & Len(Trim(tbTalao.Text)) & "' AND ARMAZEMID='" & xArmz & "'"
                'If db.GetDataValue(Sql) > 0 Then
                Sql = "INSERT INTO Reservas (ArmazemID, ArmzDest, ReservaSerieID, ReservaDescr, ReservaModeloId, ReservaCorId, ReservaTamId, ReservaData, ReservaEstado, TipoReserva, OperadorID) " & _
                                      "VALUES ('" & xArmz & "', '" & xArmz & "', '" & Me.tbTalao.Text & "', '" & Me.tbReserva.Text & "','" & Me.txtRModelo.Text & "','" & Me.txtRCor.Text & "','" & Me.txtRTam.Text & "',GETDATE(),'0','R','" & xUtilizador & "')"
                db.ExecuteData(Sql)
                MsgBox("Gravação efectuada com sucesso!")
                'Else
                '    MsgBox("SÓ PODE RESERVAR TALÕES DA SUA LOJA")
                'End If
                Me.tbReserva.Text = ""
                Me.txtRTam.Text = ""

            End If


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " btGravaReserva_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub GravarSinal()
        Dim db As New ClsSqlBDados

        If xClienteLojaID <> 1 Then
            Dim dSinal As Double = InputBox("Valor do Sinal:", "Adiantamento de Cliente", 0)
            'GravarDocumento("FS", PesquisaMaxNumDoc("FS"))

            Dim xNovoDocSinal As String = PesquisaMaxNumDoc("FS")
            Dim gIDDocCab As Guid = Guid.NewGuid

            'Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, TipoTerc, FormaPagtoID, IDDocCab, UtilizadorID, OperadorID) " & _
            '    "VALUES('" & xEmp & "','" & xArmz & "','" & "FS" & "','" & xNovoDocSinal & "', '" & xClienteLojaID & "', GETDATE(), 'C', 'L', '0', '" & gIDDocCab.ToString & "','" & cbVendedor.SelectedValue.ToString & "', '" & xUtilizador & "')"
            'db.ExecuteData(Sql)

            'Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, Valor, PercDescLn, VlrDescLn, IvaID, VlrIva, Comissao, Qtd, IdDocCab, IdDocDet) " & _
            ' "VALUES('" & xEmp & "', '" & xArmz & "', '" & "FS" & "', '" & xNovoDocSinal & "', " & "1" & ", '', '" & xModeloID & "', '" & xCorID & "', '" & xTamID & "', '" & xDescricao & "','" & xUnidade & "'," & Format(xPreco, "#,##0.00") & ", " & xPercDescLn & ", " & xVlrDescLn & ", " & xIvaID & ",  " & xVlrIva & ", " & dComissao & ", " & xQtd & ",  '" & gIDDocCab.ToString & "',  '" & gIdDocDet.ToString & "')"
            'db.ExecuteData(Sql)

        Else
            'devolução ou sinal????
            MsgBox("A devolução não é permitida para cliente Indiferenciado!")

        End If


    End Sub

    Private Sub tbTalao_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbTalao.KeyPress

        Dim db As New ClsSqlBDados
        Dim xArtigo As String

        Try

            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If Len(Trim(tbTalao.Text)) = 8 Then

                    Sql = "SELECT COUNT(*) FROM SERIE WHERE SERIEID='" & Trim(tbTalao.Text) & "' AND ARMAZEMID='" & xArmz & "'"
                    If db.GetDataValue(Sql) = 0 Then
                        MsgBox("SÓ PODE RESERVAR TALÕES DA SUA LOJA")
                        Me.txtRModelo.Text = ""
                        Me.txtRCor.Text = ""
                        Me.txtRTam.Text = ""
                        Me.tbTalao.Text = ""
                        Exit Sub
                    End If


                    Sql = "SELECT MODELOID+CORID+TAMID FROM SERIE WHERE SERIEID='" & Trim(tbTalao.Text) & "' AND ESTADOID='S' AND ARMAZEMID='" & xArmz & "' AND SERIE.SERIEID NOT IN (SELECT RESERVASERIEID FROM RESERVAS WHERE RESERVAESTADO='0')"
                    xArtigo = db.GetDataValue(Sql)
                    If Not xArtigo = Nothing Then
                        Me.txtRModelo.Text = Microsoft.VisualBasic.Left(xArtigo, 5)
                        Me.txtRCor.Text = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(xArtigo, 7), 2)
                        Me.txtRTam.Text = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(xArtigo, 9), 2)
                        Me.txtRModelo.Enabled = False
                        Me.txtRCor.Enabled = False
                        Me.txtRTam.Enabled = False
                        Me.tbTalao.Enabled = False
                    Else
                        Sql = "SELECT COUNT(*) FROM RESERVAS WHERE RESERVASERIEID='" & Trim(tbTalao.Text) & "' AND RESERVAESTADO='0'"
                        If db.GetDataValue(Sql) > 0 Then
                            MsgBox("O Talão: " & Trim(tbTalao.Text) & " está Reservado!")
                        Else
                            MsgBox("Talão Inválido!!")
                        End If
                        tbTalao.Text = ""

                    End If
                End If
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "tbTalao_KeyPress")
        Catch ex As Exception
            ErroVB(ex.Message, "tbTalao_KeyPress")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            Sql = Nothing
        End Try
    End Sub

End Class