Imports System.Data.SqlClient


Public Class frmActualizaPrecos



    Private Sub frmActualizaPrecos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Normal
        StartPosition = FormStartPosition.CenterScreen
        CarregarComboBox()
        ActualizarDGView()
    End Sub

    Private Sub CarregarComboBox()

        Dim db As New ClsSqlBDados
        Dim dtArm As New DataTable
        Dim dtTab As New DataTable
        Try
            Sql = "SELECT ArmazemID, ArmazemID + ' - ' + ArmAbrev ArmAbrev FROM Armazens union SELECT '9999', '<ESCOLHER LOJA>'"
            db.GetData(Sql, dtArm)
            With Me.cmbArmazens
                .DataSource = dtArm
                .ValueMember = "ArmazemID"
                .DisplayMember = "ArmAbrev"
                .SelectedValue = "9999"
            End With
            Sql = "SELECT TabPrecoID, TabPrecoID + ' - ' + DescTabPreco DescTabPreco FROM (SELECT TabPrecoID, DescTabPreco, Ordem FROM TabelaPrecos UNION SELECT '99', 'Escolher Tabela', 0) T1 order by Ordem"
            db.GetData(Sql, dtTab)
            dtTab.Select(Nothing, "TabPrecoID")
            With Me.cmbTabela
                .DataSource = dtTab
                .ValueMember = "TabPrecoID"
                .DisplayMember = "DescTabPreco"
                .SelectedValue = "99"
            End With
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " frmActualizaPrecos_Load")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub ActualizarDGView()
        Dim db As New ClsSqlBDados
        Dim dt As New DataTable
        Try
            Sql = "SELECT A.ArmazemID, A.ArmAbrev, T.TabPrecoID, T.DescTabPreco " & _
                  "FROM Armazens A, TabelaPrecos T " & _
                  "WHERE A.TabPrecoID=T.TabPrecoID order by 1 "
            db.GetData(Sql, dt)
            Me.DGView.DataSource = dt
            Me.DGView.Columns(3).Width = 250

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + " frmActualizaPrecos_Load")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub cmdAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAplicar.Click
        Dim ArmazemID As String
        Dim Tabela As String
        Dim db As New ClsSqlBDados
        Dim Resultado As String
        Me.Cursor = Cursors.WaitCursor
        Try
            ArmazemID = Me.cmbArmazens.SelectedValue
            Tabela = Me.cmbTabela.SelectedValue

            'VAI CARREGAR AS COMISSÕES EM FALTA
            'CarregarComissoes(ArmazemID, Tabela)

            If FaltaComissao(ArmazemID, Tabela) = False Then
                Sql = "EXEC prc_ActualizaPreco @ArmazemID = '" + ArmazemID + "', @Tabela = '" + Tabela + "', @OperadorID = '" + xUtilizador + "' "
                Resultado = db.GetDataValue(Sql)
                If Resultado = "Sucesso" Then
                    ActualizarDGView()
                End If
                'Else
                '    MsgBox("VERIFICAR COMISSÕES EM FALTA!", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + "  cmdAplicar_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function FaltaComissao(ByVal ArmazemID As String, ByVal TabPreco As String) As Boolean
        Dim db As New ClsSqlBDados
        Dim dtLinhas As New DataTable
        Dim dtUtilizadores As New DataTable


        Try



            Sql = "SELECT Linhaid FROM LINHAS"
            db.GetData(Sql, dtLinhas, False)

            Sql = "SELECT UtilizadorID FROM Utilizadores WHERE (ArmazemID = '" & ArmazemID & "')"
            db.GetData(Sql, dtUtilizadores, False)


            For Each rL As DataRow In dtLinhas.Rows
                For Each rU As DataRow In dtUtilizadores.Rows
                    Sql = "SELECT COUNT(*) AS Expr1 FROM Comissoes WHERE (ArmazemID = '" & ArmazemID & "') AND (LinhaID = '" & rL("LinhaId") & "') AND (TabPrecoID = '" & TabPreco & "') AND (UtilizadorID = " & rU("UtilizadorID") & ")"
                    If db.GetDataValue(Sql) = 0 Then
                        MsgBox("Comissão em falta para:" & Chr(13) & "Armazem: " & ArmazemID & Chr(13) & "Linha : " & rL("LinhaId") & Chr(13) & "Tabela: " & TabPreco & Chr(13) & "Utilizador : " & rU("UtilizadorID"), MsgBoxStyle.Exclamation, "Comissão em falta")
                        Return True
                    End If
                Next
            Next

            For Each rL As DataRow In dtLinhas.Rows
                For Each rU As DataRow In dtUtilizadores.Rows
                    Sql = "SELECT COUNT(*) AS Expr1 FROM Comissoes WHERE (ArmazemID = '" & ArmazemID & "') AND (LinhaID = '" & rL("LinhaId") & "') AND (TabPrecoID = '00') AND (UtilizadorID = " & rU("UtilizadorID") & ")"
                    If db.GetDataValue(Sql) = 0 Then
                        MsgBox("Comissão em falta para:" & Chr(13) & "Armazem: " & ArmazemID & Chr(13) & "Linha : " & rL("LinhaId") & Chr(13) & "Tabela: 00" & Chr(13) & "Utilizador : " & rU("UtilizadorID"), MsgBoxStyle.Exclamation, "Comissão em falta")
                        Return True
                    End If
                Next
            Next

            Return False


            'Sql = "SELECT COUNT(*) FROM Comissoes WHERE COMISSAO=0 AND ARMAZEMID='" & ArmazemID & "'"
            'If db.GetDataValue(Sql) > 0 Then
            '    Return True
            'Else
            '    Return False
            'End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, " FaltaComissao")
        Catch ex As Exception
            ErroVB(ex.Message, " FaltaComissao")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            'dt.Clear()
            'dt = Nothing
        End Try
    End Function

    Private Sub CmdFecharSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFecharSep.Click
        Close()
    End Sub

    Private Sub btAplicarTodas_Click(sender As System.Object, e As System.EventArgs) Handles btAplicarTodas.Click


        Dim db As New ClsSqlBDados
        Dim Resultado As String
        Me.Cursor = Cursors.WaitCursor
        Dim dtArmAux As New DataTable
        Try

            Sql = "SELECT ArmazemID, TabPrecoId FROM Armazens where Activo='1'"
            db.GetData(Sql, dtArmAux)

            For Each r As DataRow In dtArmAux.Rows
                'VAI CARREGAR AS COMISSÕES EM FALTA
                CarregarComissoes(r("ArmazemID"), r("TabPrecoId"))

                If FaltaComissao(r("ArmazemID"), r("TabPrecoId")) = False Then
                    Sql = "EXEC prc_ActualizaPreco @ArmazemID = '" + r("ArmazemID") + "', @Tabela = '" + r("TabPrecoId") + "', @OperadorID = '" + xUtilizador + "' "
                    Resultado = db.GetDataValue(Sql)
                    If Resultado <> "Sucesso" Then
                        GravarEvento("Erro Actualizar Preços", r("ArmazemID"), "00000000", "xxxx")
                        MsgBox("Erro!")
                        Exit For
                    End If
                Else
                    MsgBox("VERIFICAR COMISSÕES EM FALTA!", MsgBoxStyle.Critical)
                End If
            Next

            ActualizarDGView()


        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + "  btAplicarTodas_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub


End Class


