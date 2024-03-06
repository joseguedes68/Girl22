
Imports System.Data.SqlClient
Imports C1.Win.C1Chart

'Imports System
'Imports System.Collections
'Imports System.Windows.Forms
'Imports System.Data
'Imports System.Diagnostics
'Imports C1.Win.C1Chart


Public Class frmAnaliseVendas
    Dim xDadosApresentar As String

    Private Sub frmAnaliseVendas_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'TODO: APAGAR LIGAÇÃO CELFGEST
        'ActualizaLigacao("CelfGest")
    End Sub

    Private Sub frmAnaliseVendas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        dgvEnviados.Visible = False
        CarregarDados()
        c1Chart1.AutoSize = True
        dtpDe.Value = Today.AddDays(-7)
    End Sub

    Private Sub btActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btActualizar.Click
        Cursor = Cursors.WaitCursor
        c1Chart1.ChartLabels.LabelsCollection.Clear()
        ActualizarDados()
        'dgvEnviados.Visible = True
        c1Chart1.Header.Text = cbItens.Text
        'c1Chart1.Visible = True
        Cursor = Cursors.Default
    End Sub

    Private Sub chart_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles c1Chart1.MouseMove
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim dist As Integer = 0
        Dim lab As C1.Win.C1Chart.Label = Nothing

        If c1Chart1.ChartGroups(0).CoordToDataIndex(e.X, e.Y, C1.Win.C1Chart.CoordinateFocusEnum.XandYCoord, row, col, dist) Then
            If dist <= 1 Then
                c1Chart1.ChartLabels.LabelsCollection.Clear()
                'c1Chart1.Footer.Text = Me.c1Chart1.ChartGroups(0).ChartData.SeriesList(row).Y(col)
                AddBarValueLabel(e.X, e.Y)
            End If
        End If
    End Sub 'chart_MouseMove

    'FUNÇÕES

    Private Sub CarregarDados()

        Dim db As New ClsSqlBDados
        Cursor = Cursors.WaitCursor

        Try
            'dgvVendas

            Me.ArmazensTableAdapter.Fill(Me.GirlDataSet.Armazens)
            Me.GirlDataSet.Armazens.AddArmazensRow("%", "", "Todos os Armazens", "", "", "", "", "", "", True, Now, Now, 0, "", True)
            Me.cbArmazens.SelectedValue = "%"

            Me.GruposTableAdapter.Fill(Me.GirlDataSet.Grupos)
            Me.GirlDataSet.Grupos.AddGruposRow("%", "Todos Grupos", "", "", Now)
            Me.cbGrupos.SelectedValue = "%"

            Me.TiposTableAdapter.Fill(Me.GirlDataSet.Tipos)
            Me.GirlDataSet.Tipos.AddTiposRow("%", "Todos os Tipos", "", "", 0, "", "", 0, "", Now)
            Me.cbTipos.SelectedValue = "%"

            Me.LinhasTableAdapter.Fill(Me.GirlDataSet.Linhas)
            Me.GirlDataSet.Linhas.AddLinhasRow("%", "Todas Linhas", "", Now)
            Me.cbLinhas.SelectedValue = "%"

            Me.EpocasTableAdapter.Fill(Me.GirlDataSet.Epocas)
            Me.GirlDataSet.Epocas.AddEpocasRow("%", "Todas as Epocas", Now, Now, Now, Now, "", Now)
            Me.cbEpocas.SelectedValue = "%"

            Me.TerceirosTableAdapter.FillByTipoTerc(Me.GirlDataSet.Terceiros, "F")
            Me.GirlDataSet.Terceiros.AddTerceirosRow("%", "", "", "Todos Fornecedores", "", "", "", "", "", "", "", "", "", "", 0, 0, "", "", "")
            Me.cbFornecedores.SelectedValue = "%"

            Me.CoresTableAdapter.Fill(Me.GirlDataSet.Cores)
            Me.GirlDataSet.Cores.AddCoresRow("%", "Todas as Cores", "")
            Me.cbCores.SelectedValue = "%"

            Me.cbItens.SelectedItem = "Armazens"

            If MsgBox("Quer carregar dados actuais? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Sql = "EXEC prc_AnaliseEnviados"
                db.ExecuteData(Sql, 160)

                Sql = "EXEC prc_AnaliseVendas"
                db.ExecuteData(Sql, 160)
            End If

            c1Chart1.Visible = False


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, " CarregarDados")
        Catch ex As Exception
            ErroVB(ex.Message, " CarregarDados")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ActualizarDados()

        Dim dt As New DataTable
        Dim dtAux As New DataTable
        Dim dtVnd As New DataTable
        Dim db As New ClsSqlBDados
        Dim xEnv As Double
        Dim xStk As Double
        Dim xVnd As Double

        Try

            Dim xArmazem As String = Me.cbArmazens.SelectedValue.ToString
            Dim xGrupo As String = Me.cbGrupos.SelectedValue.ToString
            Dim xTipo As String = Me.cbTipos.SelectedValue.ToString
            Dim xLinha As String = Me.cbLinhas.SelectedValue.ToString
            Dim xAltura As String = "%"
            Dim xEpoca As String = Me.cbEpocas.SelectedValue.ToString
            Dim xPrVnd As String = "%"
            Dim xForn As String = Me.cbFornecedores.SelectedValue.ToString
            Dim xTam As String = "%"
            Dim xCor As String = Me.cbCores.SelectedValue.ToString
            Dim xItem As String = Me.cbItens.SelectedItem

            Dim xdtpDe As String = Format(dtpDe.Value, "yyyy-MM-dd")
            Dim xdtpAte As String = Format(dtpAte.Value.AddDays(1), "yyyy-MM-dd")


            Dim xdtpDeEntrada As String = Format(dtpdeEntrada.Value, "yyyy-MM-dd")
            Dim xdtpAteEntrada As String = Format(dtpAteEntrada.Value.AddDays(1), "yyyy-MM-dd")

            Me.GirlDataSet.GraficoVnd.Clear()


            Select Case xItem
                Case "Alturas"
                    xItem = "Altura"
                Case "Tamanhos"
                    xItem = "TamID"
                Case "Pr.Etiqueta"
                    xItem = "PrVnd"
            End Select

            dt.Columns.Add("" & xItem & "", GetType(String))
            'dt.Columns.Add("Env", GetType(Double))
            'dt.Columns.Add("Stk", GetType(Double))
            'dt.Columns.Add("Vnd", GetType(Double))
            'dt.Columns.Add("RT", GetType(Double))


            Sql = "SELECT " & xItem & ", Sum(QtdEnv) Env, Sum(QtdStk) Stk, Sum(QtdVnd) Vnd, CAST(Sum(QtdVnd)as decimal)/CAST(Sum(QtdEnv)as decimal) RT " & _
              "FROM tmp_AnaliseEnviados " & _
              "WHERE ArmazemID LIKE '" & xArmazem & "' " & _
              "AND GrupoID LIKE '" & xGrupo & "' " & _
              "AND TipoID LIKE '" & xTipo & "' " & _
              "AND LinhaID LIKE '" & xLinha & "' " & _
              "AND Altura LIKE '" & xAltura & "' " & _
              "AND EpocaID LIKE '" & xEpoca & "' " & _
              "AND PrVnd like '" & xPrVnd & "'  " & _
              "AND FornID LIKE '" & xForn & "' " & _
              "AND CorID LIKE '" & xCor & "' " & _
              "AND TamID LIKE '" & xTam & "' " & _
              "GROUP BY " & xItem & " ORDER BY " & xItem

            db.GetData(Sql, dt)

            dgvEnviados.DataSource = dt
            dgvEnviados.AllowUserToDeleteRows = False
            dgvEnviados.AllowUserToAddRows = False
            dgvEnviados.Columns("RT").DefaultCellStyle.Format = "P"
            dgvEnviados.AutoResizeColumns()
            dgvEnviados.AllowUserToResizeColumns = True

            'ACTUALIZAR TOTAIS

            If dt.Rows.Count > 0 Then
                xEnv = dt.Compute("SUM(Env)", "")
                xStk = dt.Compute("SUM(Stk)", "")
                xVnd = dt.Compute("SUM(Vnd)", "")
                dt.Rows.Add("Total", xEnv, xStk, xVnd, xVnd / xEnv)
                dgvEnviados.Visible = True
            Else
                dgvEnviados.Visible = False
                c1Chart1.Visible = False
                MsgBox("SEM DADOS PARA APRESENTAR!")
                Exit Sub
            End If

            'ACTUALIZAR AS VENDAS ENTRE O PERIODO

            Sql = "SELECT " & xItem & " Item, Sum(QtdVnd) QtdVnd FROM tmp_AnaliseVendas " & _
                "WHERE dtsaida between '" & Format(dtpDe.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAte.Value.AddDays(1), "yyyy-MM-dd") & "' " & _
                "AND ArmazemID LIKE '" & xArmazem & "' " & _
                "AND GrupoID LIKE '" & xGrupo & "' " & _
                "AND TipoID LIKE '" & xTipo & "' " & _
                "AND LinhaID LIKE '" & xLinha & "' " & _
                "AND Altura LIKE '" & xAltura & "' " & _
                "AND EpocaID LIKE '" & xEpoca & "' " & _
                "AND PrVnd like '" & xPrVnd & "'  " & _
                "AND FornID LIKE '" & xForn & "' " & _
                "AND CorID LIKE '" & xCor & "' " & _
                "AND TamID LIKE '" & xTam & "' " & _
                "GROUP BY " & xItem & " ORDER BY " & xItem

            db.GetData(Sql, Me.GirlDataSet.GraficoVnd)


            If Me.GirlDataSet.GraficoVnd.Rows.Count > 0 Then
                c1Chart1.ChartArea.AxisX.Text = xItem
                c1Chart1.Visible = True
            Else
                c1Chart1.Visible = False
                MsgBox("NÃO TEM VENDAS NO PERIODO!")
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, " btActualizar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, " btActualizar_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Close()
    End Sub

    Private Sub AddBarValueLabel(ByVal x As Integer, ByVal y As Integer)
        Const labName As String = "barValueLabel"
        Dim lab As C1.Win.C1Chart.Label = Nothing
        Dim s As Integer = -1
        Dim p As Integer = -1
        Dim d As Integer = -1
        Dim grp As ChartGroup = c1Chart1.ChartGroups(0)
        If grp.CoordToDataIndex(x, y, 0, s, p, d) Then
            'If grp.CoordToDataIndex(x, y, CoordinateFocusEnum.XCoord, s, p, d) Then
            If s >= 0 AndAlso p >= 0 AndAlso d = 0 Then
                lab = c1Chart1.ChartLabels(labName)
                If lab Is Nothing Then
                    lab = c1Chart1.ChartLabels.LabelsCollection.AddNewLabel()
                    lab.Name = labName
                    lab.Style.Border.BorderStyle = BorderStyleEnum.None
                    lab.Style.BackColor = Color.Transparent
                    lab.Compass = LabelCompassEnum.West
                    lab.Connected = False
                    lab.Offset = -10
                    lab.AttachMethod = AttachMethodEnum.DataIndex
                    lab.AttachMethodData.GroupIndex = 0
                    lab.AttachMethodData.SeriesIndex = s
                    lab.AttachMethodData.PointIndex = p
                    lab.Text = CSng(grp.ChartData(s).Y(p)).ToString("0.##")
                    lab.Visible = True
                Else
                    lab.AttachMethodData.SeriesIndex = s
                    lab.AttachMethodData.PointIndex = p
                    lab.Text = CSng(grp.ChartData(s).Y(p)).ToString("0.##")
                End If
                Return
            End If
        End If
    End Sub 'AddBarValueLabel

    Private Sub rbMargem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMargem.CheckedChanged, rbQtd.CheckedChanged, rbValor.CheckedChanged
        If rbMargem.Checked Then
            xDadosApresentar = "Margem"
        ElseIf rbQtd.Checked Then
            xDadosApresentar = "Qtd"
        ElseIf rbValor.Checked Then
            xDadosApresentar = "Valor"
        End If
    End Sub




End Class