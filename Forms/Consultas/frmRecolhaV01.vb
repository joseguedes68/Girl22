Imports System.Data.SqlClient

Public Class frmRecolhaV01

    Dim xFiltraEstado As String = "= 'P'"
    Dim bs As New BindingSource
    Dim dtRecolhaTaloes As New DataTable
    Dim dtLojas As New DataTable
    Dim sLoad As Boolean = True





    Private Sub frmRecolhaTaloes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New ClsSqlBDados
        dtRecolhaTaloes.Clear()
        xFiltraDataGrid = ""

        Try

            dpDeData.Value = Today.AddDays(-40)

            If sLoad = True Then

                'PREENCHER COMBOBOX ARMAZEM
                Sql = "SELECT ArmazemID, rtrim(ArmazemID) + ' - ' + rtrim(ArmAbrev) as Lojas from Armazens where Activo='True'"
                db.GetData(Sql, dtLojas)
                dtLojas.Rows.Add("%", "Todas as Lojas")
                Me.cbLojas.DataSource = dtLojas
                Me.cbLojas.DisplayMember = "Lojas"
                Me.cbLojas.ValueMember = "ArmazemID"
                Me.cbLojas.SelectedValue = "%"

                sLoad = False
            End If

            'btActualizar.Enabled = False

            'Sql = "SELECT ArmAbrev AS Loja, DocNr, DataDoc AS Data, VDMB, VDD, VDC, TotComissão - VDC AS Comissão, TotVnd - (VDMB + VDD) - TotComissão - VDC AS Deposito FROM (SELECT Armazens.ArmAbrev, DocCab.DocNr, DocCab.DataDoc, SUM(ISNULL(Fecho.MB, 0)) AS VDMB, SUM(ISNULL(Fecho.DN, 0)) AS VDD, SUM(ISNULL(Fecho.CM, 0)) AS VDC, SUM(DocDet.Valor * DocDet.Qtd) AS TotVnd, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS TotComissão FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, DocNr, Obs2 AS MB, Obs3 AS DN, DescontoDoc AS CM FROM DocCab AS DocCab_1 WHERE (TipoDocID = 'FX')) AS Fecho ON DocCab.ArmazemID = Fecho.ArmazemID AND DocCab.EmpresaID = Fecho.EmpresaID AND DocCab.DocNr = Fecho.DocNr GROUP BY DocCab.EmpresaID, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.DocNr, Armazens.ArmAbrev HAVING (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.TipoDocID = 'RE') AND (DocCab.EstadoDoc = '" & xFiltraEstado & "')) AS RECOLHAS ORDER BY DocNr DESC"
            'Sql = "SELECT ArmazemID AS NLoja, ArmAbrev AS Loja, DocNr, DataDoc AS Data, VDMB, VDD, VDC , TotComissão - VDC AS Comissão, TotVnd - (VDMB + VDD) - TotComissão - VDC AS Deposito, Obs, Obs1 FROM (SELECT DocCab.ArmazemID, Armazens.ArmAbrev, DocCab.DocNr, DocCab.DataDoc, SUM(ISNULL(Fecho.MB, 0)) AS VDMB, SUM(ISNULL(Fecho.DN, 0)) AS VDD, SUM(ISNULL(Fecho.CM, 0)) AS VDC, SUM(DocDet.Valor * DocDet.Qtd) AS TotVnd, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS TotComissão, DocCab.Obs, DocCab.Obs1 FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, DocNr, Obs2 AS MB, Obs3 AS DN, DescontoDoc AS CM FROM DocCab AS DocCab_1 WHERE (TipoDocID = 'FX')) AS Fecho ON DocCab.ArmazemID = Fecho.ArmazemID AND DocCab.EmpresaID = Fecho.EmpresaID AND DocCab.DocNr = Fecho.DocNr GROUP BY DocCab.EmpresaID, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.DocNr, Armazens.ArmAbrev, DocCab.ArmazemID, DocCab.Obs, DocCab.Obs1 HAVING (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.TipoDocID = 'RE') AND (DocCab.EstadoDoc = '" & xFiltraEstado & "')) AS RECOLHAS ORDER BY Data DESC"
            'Sql = "SELECT ArmazemID AS NLoja, ArmAbrev AS Loja, DocNr, DataDoc AS Data, VDMB, VDD, VDC, TotComissão - VDC AS Comissão, TotVnd - (VDMB + VDD) - TotComissão - VDC AS Deposito, Obs, Obs1, IDDocCab, IDDocCabOrig FROM (SELECT DocCab.ArmazemID, Armazens.ArmAbrev, DocCab.DocNr, DocCab.DataDoc, SUM(ISNULL(Fecho.MB, 0)) AS VDMB, SUM(ISNULL(Fecho.DN, 0)) AS VDD, SUM(ISNULL(Fecho.CM, 0)) AS VDC, SUM(DocDet.Valor * DocDet.Qtd) AS TotVnd, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS TotComissão, DocCab.Obs, DocCab.Obs1, DocCab.IdDocCabOrig, DocCab.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, DocNr, Obs2 AS MB, Obs3 AS DN, DescontoDoc AS CM FROM DocCab AS DocCab_1 WHERE (TipoDocID = 'FX')) AS Fecho ON DocCab.ArmazemID = Fecho.ArmazemID AND DocCab.EmpresaID = Fecho.EmpresaID AND DocCab.DocNr = Fecho.DocNr GROUP BY DocCab.EmpresaID, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.DocNr, Armazens.ArmAbrev, DocCab.ArmazemID, DocCab.Obs, DocCab.Obs1, DocCab.IdDocCabOrig, DocCab.IdDocCab HAVING (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.TipoDocID = 'RE') AND (DocCab.EstadoDoc = '" & xFiltraEstado & "')) AS RECOLHAS ORDER BY Data DESC"
            'Sql = "SELECT DocCab.ArmazemID AS NLOJA, Armazens.ArmAbrev AS LOJA, RECOLHA.RECDOC AS DocNr, RECOLHA.RECDATA AS Data, DocCab.Obs2 AS VDMB, DocCab.Obs3 AS VDD, DocCab.DescontoDoc AS VDC,    RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc)) AS Deposito, RECOLHA.RECCOMISSOES - DocCab.DescontoDoc AS Comissão, RECOLHA.RECOBS AS Obs, DocCab.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs1 AS RECOBS, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") ORDER BY DocCab.DataDoc DESC"
            'Sql = "SELECT DocCab.ArmazemID AS NL, Armazens.ArmAbrev AS LOJA, RECOLHA.RECDOC AS DocNr, RECOLHA.RECDATA AS Data, DocCab.Obs2 AS VDMB, DocCab.Obs3 AS VDD, DocCab.DescontoDoc AS VDC, RECOLHA.RECOBSLOJA AS ObsLoja, RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc)) AS Deposito, RECOLHA.RECCOMISSOES - DocCab.DescontoDoc AS Comissão,  RECOLHA.RECOBS AS Obs, RECOLHA.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs AS RECOBS, DocCab_1.Obs1 AS RECOBSLOJA, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab, DocCab_1.Obs) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") ORDER BY DocCab.DataDoc DESC"

            'Sql = "SELECT DocCab.ArmazemID AS NL, Armazens.ArmAbrev AS LOJA, RECOLHA.RECDOC AS DocNr, RECOLHA.RECDATA AS Data, DocCab.Obs2 AS VDMB, DocCab.Obs3 AS VDD, RECOLHA.RECTOTAL - DocCab.Obs2 - DocCab.Obs3 AS VE, DocCab.DescontoDoc AS VDC, RECOLHA.RECOBSLOJA AS ObsLoja, RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc)) AS Deposito, RECOLHA.RECCOMISSOES - DocCab.DescontoDoc AS Comissão, RECOLHA.RECOBS AS Obs, RECOLHA.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs AS RECOBS, DocCab_1.Obs1 AS RECOBSLOJA, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab, DocCab_1.Obs) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") ORDER BY DocCab.DataDoc DESC"
            'db.GetData(Sql, dtRecolhaTaloes)

            ''BindingSource1.DataSource = dtRecolhaTaloes
            'dgvRecolhaTaloes.DataSource = BindingSource1


            btActualizar_Click(sender, e)

            dgvRecolhaTaloes.Columns("NL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvRecolhaTaloes.Columns("NL").Width = 50

            dgvRecolhaTaloes.Columns("Loja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvRecolhaTaloes.Columns("Loja").Width = 95

            dgvRecolhaTaloes.Columns("DocNr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRecolhaTaloes.Columns("DocNr").Width = 60

            dgvRecolhaTaloes.Columns("Data").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRecolhaTaloes.Columns("Data").DefaultCellStyle.Format = "d"
            dgvRecolhaTaloes.Columns("Data").Width = 80

            dgvRecolhaTaloes.Columns("VDMB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecolhaTaloes.Columns("VDMB").DefaultCellStyle.Format = "C2"
            dgvRecolhaTaloes.Columns("VDMB").Width = 80

            dgvRecolhaTaloes.Columns("VDD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecolhaTaloes.Columns("VDD").DefaultCellStyle.Format = "C2"
            dgvRecolhaTaloes.Columns("VDD").Width = 80

            dgvRecolhaTaloes.Columns("VE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecolhaTaloes.Columns("VE").DefaultCellStyle.Format = "C2"
            dgvRecolhaTaloes.Columns("VE").Width = 80

            dgvRecolhaTaloes.Columns("DESPESAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecolhaTaloes.Columns("DESPESAS").DefaultCellStyle.Format = "C2"
            dgvRecolhaTaloes.Columns("DESPESAS").Width = 90

            dgvRecolhaTaloes.Columns("DEPOSITO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecolhaTaloes.Columns("DEPOSITO").DefaultCellStyle.Format = "C2"
            dgvRecolhaTaloes.Columns("DEPOSITO").Width = 90

            dgvRecolhaTaloes.Columns("ObsLoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvRecolhaTaloes.Columns("ObsLoja").Width = 100

            dgvRecolhaTaloes.Columns("Obs").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvRecolhaTaloes.Columns("Obs").Width = 200

            dgvRecolhaTaloes.Columns("IDDocCab").Visible = False


            'FORMATAR COLUNAS TOTAIS

            dgvRTTotais.Columns("Vendedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvRTTotais.Columns("Vendedor").Width = 150

            dgvRTTotais.Columns("C1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRTTotais.Columns("C1").DefaultCellStyle.Format = "C2"
            dgvRTTotais.Columns("C1").Width = 70

            dgvRTTotais.Columns("C2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRTTotais.Columns("C2").DefaultCellStyle.Format = "C2"
            dgvRTTotais.Columns("C2").Width = 70


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmRecolhaTaloes_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmRecolhaTaloes_Load")
        End Try

    End Sub

    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click

        Dim db As New ClsSqlBDados
        Try



            'Dim cryRpt As New rptResumoMensal

            'Dim ds As New DataSet

            ''cryRpt.Load("C:\Girl\Reports\rptResumoMensal.rpt")

            'Sql = "EXECUTE prc_ResumoMensal @deData='" & xDeData & "', @ateData='" & xAteData & "'"
            'db.GetData(Sql, ds, False)

            ''cryRpt.Database.Tables("dtMapaVendas").SetDataSource(ds.Tables(0))
            'cryRpt.SetDataSource(ds.Tables(0)) 'FUNCIONA PORQUE SÓ TEM UMA TABELA NO REPORT?????


            'Me.CRViewer.ReportSource = cryRpt
            'Me.CRViewer.Refresh()

            'CRViewer.Visible = True


        Catch ex As Exception
            ErroVB(ex.Message, "frmResumoMensal: btListar_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Close()
    End Sub

    Private Sub btValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btValidar.Click
        Try

            Dim db As New ClsSqlBDados

            Dim xDocNr As String = Me.dgvRecolhaTaloes("DocNr", Me.dgvRecolhaTaloes.CurrentCell.RowIndex).Value
            Dim xArmzAux As String = Me.dgvRecolhaTaloes("NL", Me.dgvRecolhaTaloes.CurrentCell.RowIndex).Value


            If MsgBox("Confirma Validação da Recolha nº" & xDocNr & " no Armazém " & xArmzAux & " ?", MsgBoxStyle.YesNo, "Confirmação Envio") <> MsgBoxResult.No Then

                Sql = "UPDATE DocCab SET EstadoDoc = 'C' WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmzAux & "' AND TipoDocID = 'RE' AND DocNr = '" & xDocNr & "' AND EstadoDoc = 'P'"
                db.ExecuteData(Sql)
                frmRecolhaTaloes_Load(sender, e)


            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaCabeçalho")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaCabeçalho")
        End Try
    End Sub

    Private Sub cbVerTodas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodas.CheckedChanged
        If cbVerTodas.Checked = True Then
            xFiltraEstado = "LIKE '%'"
            btValidar.Enabled = False
        Else
            xFiltraEstado = "= 'P'"
            btValidar.Enabled = True
        End If
        'btActualizar_Click(sender, e)
        frmRecolhaTaloes_Load(sender, e)
    End Sub

    Private Sub dgvRecolhaTaloes_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecolhaTaloes.CellEndEdit
        GravarObsRecolhasBackOffice(Me.dgvRecolhaTaloes("IdDocCab", Me.dgvRecolhaTaloes.CurrentCell.RowIndex).Value.ToString, Me.dgvRecolhaTaloes("ObsLoja", Me.dgvRecolhaTaloes.CurrentCell.RowIndex).Value.ToString, Me.dgvRecolhaTaloes("Obs", Me.dgvRecolhaTaloes.CurrentCell.RowIndex).Value.ToString)
    End Sub

    Private Sub dgvRecolhaTaloes_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRecolhaTaloes.CellMouseClick

        ''bs.DataMember = "Reservas"
        ''bs.DataSource = Me.GirlDataSet



        ''bs.DataSource = dgvRecolhaTaloes
        'Dim dg As New clsDataGrid(Me.dgvRecolhaTaloes, , BindingSource1)
        'Try
        '    If e.Button = Windows.Forms.MouseButtons.Right Then

        '        dg.MostraFiltroForm(e)

        '    End If

        'Catch ex As Exception
        '    ErroVB(ex.Message, Me.Name + ": IniciarDataGrid")
        'Finally
        '    dg.Dispose()
        '    dg = Nothing
        'End Try
    End Sub

    Private Sub btActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btActualizar.Click

        'FALTA TROCAR A VARIAVEL DocDet.PercDescLn POR DocDet.Comissao
        Dim db As New ClsSqlBDados
        dtRecolhaTaloes.Clear()
        Dim dtRecolhaTaloesTotais As New DataTable
        Dim dtRecolhaVendedor As New DataTable
        Dim dtRecolhaComissoes As New DataTable
        dgvRTTotais.Visible = False
        Me.Cursor = Cursors.WaitCursor


        Try

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query

            'Sql = "SELECT DocCab.ArmazemID AS NL, Armazens.ArmAbrev AS LOJA, RECOLHA.RECDOC AS DocNr, RECOLHA.RECDATA AS Data, DocCab.Obs2 AS VDMB, DocCab.Obs3 AS VDD, RECOLHA.RECTOTAL - DocCab.Obs2 - DocCab.Obs3 AS VE, DocCab.DescontoDoc AS VDC, RECOLHA.RECOBSLOJA AS ObsLoja, RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc)) AS Deposito, RECOLHA.RECCOMISSOES - DocCab.DescontoDoc AS Comissão,  RECOLHA.RECOBS AS Obs, RECOLHA.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs AS RECOBS, DocCab_1.Obs1 AS RECOBSLOJA, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab, DocCab_1.Obs) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102))  AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) ORDER BY DocCab.DataDoc DESC"
            'Sql = "SELECT DocCab.ArmazemID AS NL, Armazens.ArmAbrev AS LOJA, RECOLHA.RECDOC AS DocNr, RECOLHA.RECDATA AS Data, DocCab.Obs2 AS VDMB, DocCab.Obs3 AS VDD, RECOLHA.RECTOTAL - DocCab.Obs2 - DocCab.Obs3 AS VE, RECOLHA.RECOBSLOJA AS ObsLoja, RECOLHA.RECOBS AS Obs, RECOLHA.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs AS RECOBS, DocCab_1.Obs1 AS RECOBSLOJA, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab, DocCab_1.Obs) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102))  AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) ORDER BY DocCab.DataDoc DESC"
            Sql = "SELECT DocCab.ArmazemID AS NL, Armazens.ArmAbrev AS LOJA, DocCab.DocNr, DocCab.DataDoc AS Data, DocCab.Obs2 AS VDMB, DocCab.Obs3 AS VDD, RECOLHA.RECTOTAL - DocCab.Obs2 - DocCab.Obs3 AS VE, ISNULL(DESPESAS.ValDespesas,0) AS DESPESAS, RECOLHA.RECTOTAL - DocCab.Obs2 - DocCab.Obs3 - RECOLHA.RECCOMISSOES + DocCab.DescontoDoc + ISNULL(DESPESAS.ValDespesas,0) AS DEPOSITO, DocCab.Obs1 AS ObsLoja, DocCab.Obs, DocCab.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCab) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCab LEFT OUTER JOIN (SELECT DocDet_1.IdDocCab, SUM(DocDet_1.Valor) AS ValDespesas FROM DocCab AS DocCab_1 INNER JOIN DocDet AS DocDet_1 ON DocCab_1.IdDocCab = DocDet_1.IdDocCab WHERE (DocDet_1.Obs = 'DESPESA') GROUP BY DocDet_1.IdDocCab) AS DESPESAS ON DocCab.IdDocCab = DESPESAS.IdDocCab WHERE (DocCab.TipoDocID = 'RE') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.EstadoDoc " & xFiltraEstado & ") ORDER BY Data DESC"
            db.GetData(Sql, dtRecolhaTaloes)

            dgvRecolhaTaloes.DataSource = dtRecolhaTaloes

            If dtRecolhaTaloes.Rows.Count > 0 And cbLojas.SelectedValue.ToString <> "%" Then

                Dim TotalVDMB As String = dtRecolhaTaloes.Compute("sum(VDMB)", "").ToString
                Dim TotalVDD As String = dtRecolhaTaloes.Compute("sum(VDD)", "").ToString
                Dim TotalVE As String = dtRecolhaTaloes.Compute("sum(VE)", "").ToString
                Dim TotalDesp As String = dtRecolhaTaloes.Compute("sum(DESPESAS)", "").ToString
                Dim TotalDep As String = dtRecolhaTaloes.Compute("sum(DEPOSITO)", "").ToString

                If TotalVDMB = "" Then TotalVDMB = "0"
                If TotalVDD = "" Then TotalVDD = "0"
                If TotalVE = "" Then TotalVE = "0"
                If TotalDesp = "" Then TotalDesp = "0"
                If TotalDep = "" Then TotalDep = "0"

                dtRecolhaTaloes.Rows.Add("", "TOTAIS", "", DBNull.Value, TotalVDMB, TotalVDD, TotalVE, TotalDesp, TotalDep, "", "")
                dgvRecolhaTaloes.Rows(dgvRecolhaTaloes.RowCount - 1).DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

            End If



            'TOTAIS......

            ''Sql = "SELECT RECOLHA.NomeUtilizador, SUM(DocCab.Obs2) AS VDMB, SUM(DocCab.Obs3) AS VDD, SUM(RECOLHA.RECTOTAL - DocCab.Obs2 - DocCab.Obs3) AS VE, SUM(DocCab.DescontoDoc) AS VDC, SUM(RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc))) AS Deposito, SUM(RECOLHA.RECCOMISSOES - DocCab.DescontoDoc) AS Comissão FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT Utilizadores.NomeUtilizador, DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs AS RECOBS, DocCab_1.Obs1 AS RECOBSLOJA, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab INNER JOIN Utilizadores ON DocDet.UtilizadorID = Utilizadores.UtilizadorID GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab, DocCab_1.Obs, Utilizadores.NomeUtilizador) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') GROUP BY RECOLHA.NomeUtilizador"
            'Sql = "SELECT rtrim(ltrim(STR(RECOLHA.UtilizadorID))) VND, SUM(DocCab.Obs2) AS VDMB, SUM(DocCab.Obs3) AS VDD, SUM(RECOLHA.RECTOTAL - DocCab.Obs2 - DocCab.Obs3) AS VE, SUM(DocCab.DescontoDoc) AS VDC, SUM(RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc))) AS Deposito, SUM(RECOLHA.RECCOMISSOES - DocCab.DescontoDoc) AS Comissão FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs AS RECOBS, DocCab_1.Obs1 AS RECOBSLOJA, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO, DocDet.UtilizadorID FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab, DocCab_1.Obs, DocDet.UtilizadorID) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') GROUP BY RECOLHA.UtilizadorID"
            'db.GetData(Sql, dtRecolhaVendedor)

            'Sql = "SELECT '   Total   ' VND, SUM(DocCab.Obs2) AS VDMB, SUM(DocCab.Obs3) AS VDD, SUM(RECOLHA.RECTOTAL - DocCab.Obs2 - DocCab.Obs3) AS VE, SUM(DocCab.DescontoDoc) AS VDC, SUM(RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc))) AS Deposito, SUM(RECOLHA.RECCOMISSOES - DocCab.DescontoDoc) AS Comissão FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs AS RECOBS, DocCab_1.Obs1 AS RECOBSLOJA, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab, DocCab_1.Obs) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "')"
            'db.GetData(Sql, dtRecolhaTaloesTotais)


            ''VOU FAZER O MERGE MAS PODIA CARREGAR OS DOIS SELECTS NA MESMA TABELA
            ''ATENÇÃO AOS PROBLEMAS DO TAMANHO DO CAMPO VND
            ''dtRecolhaVendedor.Merge(dtRecolhaTaloesTotais)
            'If dtRecolhaVendedor.Rows.Count > 1 Then
            '    dtRecolhaTaloesTotais.Merge(dtRecolhaVendedor)
            'End If

            'dgvRTTotais.DataSource = dtRecolhaTaloesTotais


            'Sql = "SELECT SUM(DocCab.Obs2) AS VDMB, SUM(DocCab.Obs3) AS VDD, SUM(RECOLHA.RECTOTAL - DocCab.Obs2 - DocCab.Obs3) AS VE, SUM(DocCab.DescontoDoc) AS VDC, SUM(RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc))) AS Deposito, SUM(RECOLHA.RECCOMISSOES - DocCab.DescontoDoc) AS Comissão FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs AS RECOBS, DocCab_1.Obs1 AS RECOBSLOJA, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab, DocCab_1.Obs) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "')"
            'db.GetData(Sql, dtRecolhaTaloesTotais)
            'dgvRTTotais.DataSource = dtRecolhaTaloesTotais

            Sql = "SELECT COMISSOES.NomeUtilizador as Vendedor, SUM(COMISSOES.C1) AS C1, SUM(COMISSOES.C2) AS C2 FROM DocCab INNER JOIN (SELECT DocDet.IdDocCab, Utilizadores.UtilizadorID, Utilizadores.NomeUtilizador, SUM(DocDet.Valor * DocDet.PercDescLn * DocDet.Qtd * ISNULL(DocDet.DocNrLnOrig, 0)) AS C1, SUM(DocDet.Valor * DocDet.PercDescLn * DocDet.Qtd - DocDet.Valor * DocDet.PercDescLn * DocDet.Qtd * ISNULL(DocDet.DocNrLnOrig, 0)) AS C2 FROM DocDet INNER JOIN Utilizadores ON DocDet.UtilizadorID = Utilizadores.UtilizadorID GROUP BY DocDet.IdDocCab, Utilizadores.NomeUtilizador, Utilizadores.UtilizadorID) AS COMISSOES ON DocCab.IdDocCab = COMISSOES.IdDocCab WHERE (DocCab.TipoDocID = 'RE') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID LIKE '" + cbLojas.SelectedValue.ToString + "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.EstadoDoc " & xFiltraEstado & ") GROUP BY COMISSOES.NomeUtilizador"
            db.GetData(Sql, dtRecolhaComissoes)
            dgvRTTotais.DataSource = dtRecolhaComissoes

            If dtRecolhaTaloes.Rows.Count > 0 And cbLojas.SelectedValue.ToString <> "%" Then

                dgvRTTotais.Visible = True

                If dtRecolhaComissoes.Rows.Count > 1 Then
                    'ADICIONA TOTAIS
                    Dim TotalC1 As String = dtRecolhaComissoes.Compute("sum(C1)", "").ToString
                    Dim TotalC2 As String = dtRecolhaComissoes.Compute("sum(C2)", "").ToString
                    If TotalC1 = "" Then TotalC1 = "0"
                    If TotalC2 = "" Then TotalC2 = "0"
                    dtRecolhaComissoes.Rows.Add("TOTAIS", TotalC1, TotalC2)
                    dgvRTTotais.Rows(dgvRTTotais.RowCount - 1).DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

                End If
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btActualizar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btActualizar_Click")


        Finally
            Me.Cursor = Cursors.Default


        End Try

    End Sub

    Private Sub cbLojas_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbLojas.SelectedValueChanged

        'If Me.cbLojas.SelectedValue.ToString = "%" Then
        'btActualizar.Enabled = False
        'Else
        '    btActualizar.Enabled = True
        'End If

    End Sub

    Private Sub frmRecolhaV01_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'TODO: APAGAR LIGAÇÃO CELFGEST
        'ActualizaLigacao("CelfGest")
    End Sub


End Class