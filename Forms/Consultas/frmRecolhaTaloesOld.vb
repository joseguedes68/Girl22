Imports System.Data.SqlClient

Public Class frmRecolhaTaloesOld

    Dim xFiltraEstado As String = "= 'P'"
    Dim bs As New BindingSource


    Private Sub frmRecolhaTaloes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New ClsSqlBDados
        Dim dtRecolhaTaloes As New DataTable
        xFiltraDataGrid = ""

        Try

            'Sql = "SELECT ArmAbrev AS Loja, DocNr, DataDoc AS Data, VDMB, VDD, VDC, TotComissão - VDC AS Comissão, TotVnd - (VDMB + VDD) - TotComissão - VDC AS Deposito FROM (SELECT Armazens.ArmAbrev, DocCab.DocNr, DocCab.DataDoc, SUM(ISNULL(Fecho.MB, 0)) AS VDMB, SUM(ISNULL(Fecho.DN, 0)) AS VDD, SUM(ISNULL(Fecho.CM, 0)) AS VDC, SUM(DocDet.Valor * DocDet.Qtd) AS TotVnd, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS TotComissão FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, DocNr, Obs2 AS MB, Obs3 AS DN, DescontoDoc AS CM FROM DocCab AS DocCab_1 WHERE (TipoDocID = 'FX')) AS Fecho ON DocCab.ArmazemID = Fecho.ArmazemID AND DocCab.EmpresaID = Fecho.EmpresaID AND DocCab.DocNr = Fecho.DocNr GROUP BY DocCab.EmpresaID, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.DocNr, Armazens.ArmAbrev HAVING (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.TipoDocID = 'RE') AND (DocCab.EstadoDoc = '" & xFiltraEstado & "')) AS RECOLHAS ORDER BY DocNr DESC"
            'Sql = "SELECT ArmazemID AS NLoja, ArmAbrev AS Loja, DocNr, DataDoc AS Data, VDMB, VDD, VDC , TotComissão - VDC AS Comissão, TotVnd - (VDMB + VDD) - TotComissão - VDC AS Deposito, Obs, Obs1 FROM (SELECT DocCab.ArmazemID, Armazens.ArmAbrev, DocCab.DocNr, DocCab.DataDoc, SUM(ISNULL(Fecho.MB, 0)) AS VDMB, SUM(ISNULL(Fecho.DN, 0)) AS VDD, SUM(ISNULL(Fecho.CM, 0)) AS VDC, SUM(DocDet.Valor * DocDet.Qtd) AS TotVnd, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS TotComissão, DocCab.Obs, DocCab.Obs1 FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, DocNr, Obs2 AS MB, Obs3 AS DN, DescontoDoc AS CM FROM DocCab AS DocCab_1 WHERE (TipoDocID = 'FX')) AS Fecho ON DocCab.ArmazemID = Fecho.ArmazemID AND DocCab.EmpresaID = Fecho.EmpresaID AND DocCab.DocNr = Fecho.DocNr GROUP BY DocCab.EmpresaID, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.DocNr, Armazens.ArmAbrev, DocCab.ArmazemID, DocCab.Obs, DocCab.Obs1 HAVING (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.TipoDocID = 'RE') AND (DocCab.EstadoDoc = '" & xFiltraEstado & "')) AS RECOLHAS ORDER BY Data DESC"
            'Sql = "SELECT ArmazemID AS NLoja, ArmAbrev AS Loja, DocNr, DataDoc AS Data, VDMB, VDD, VDC, TotComissão - VDC AS Comissão, TotVnd - (VDMB + VDD) - TotComissão - VDC AS Deposito, Obs, Obs1, IDDocCab, IDDocCabOrig FROM (SELECT DocCab.ArmazemID, Armazens.ArmAbrev, DocCab.DocNr, DocCab.DataDoc, SUM(ISNULL(Fecho.MB, 0)) AS VDMB, SUM(ISNULL(Fecho.DN, 0)) AS VDD, SUM(ISNULL(Fecho.CM, 0)) AS VDC, SUM(DocDet.Valor * DocDet.Qtd) AS TotVnd, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS TotComissão, DocCab.Obs, DocCab.Obs1, DocCab.IdDocCabOrig, DocCab.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, DocNr, Obs2 AS MB, Obs3 AS DN, DescontoDoc AS CM FROM DocCab AS DocCab_1 WHERE (TipoDocID = 'FX')) AS Fecho ON DocCab.ArmazemID = Fecho.ArmazemID AND DocCab.EmpresaID = Fecho.EmpresaID AND DocCab.DocNr = Fecho.DocNr GROUP BY DocCab.EmpresaID, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.DocNr, Armazens.ArmAbrev, DocCab.ArmazemID, DocCab.Obs, DocCab.Obs1, DocCab.IdDocCabOrig, DocCab.IdDocCab HAVING (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.TipoDocID = 'RE') AND (DocCab.EstadoDoc = '" & xFiltraEstado & "')) AS RECOLHAS ORDER BY Data DESC"

            'Sql = "SELECT DocCab.ArmazemID AS NLOJA, Armazens.ArmAbrev AS LOJA, RECOLHA.RECDOC AS DocNr, RECOLHA.RECDATA AS Data, DocCab.Obs2 AS VDMB, DocCab.Obs3 AS VDD, DocCab.DescontoDoc AS VDC,    RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc)) AS Deposito, RECOLHA.RECCOMISSOES - DocCab.DescontoDoc AS Comissão, RECOLHA.RECOBS AS Obs, DocCab.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs1 AS RECOBS, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") ORDER BY DocCab.DataDoc DESC"
            Sql = "SELECT DocCab.ArmazemID AS NL, Armazens.ArmAbrev AS LOJA, RECOLHA.RECDOC AS DocNr, RECOLHA.RECDATA AS Data, DocCab.Obs2 AS VDMB, DocCab.Obs3 AS VDD, DocCab.DescontoDoc AS VDC, RECOLHA.RECOBSLOJA AS ObsLoja, RECOLHA.RECTOTAL - ((DocCab.Obs2 + DocCab.Obs3) + (RECOLHA.RECCOMISSOES - DocCab.DescontoDoc)) AS Deposito, RECOLHA.RECCOMISSOES - DocCab.DescontoDoc AS Comissão,  RECOLHA.RECOBS AS Obs, RECOLHA.IdDocCab FROM DocCab INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN (SELECT DocCab_1.IdDocCab, DocCab_1.IdDocCabOrig, DocCab_1.DocNr AS RECDOC, DocCab_1.DataDoc AS RECDATA, DocCab_1.Obs AS RECOBS, DocCab_1.Obs1 AS RECOBSLOJA, SUM(DocDet.Valor * DocDet.Qtd) AS RECTOTAL, SUM(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS RECCOMISSOES, DocCab_1.EstadoDoc AS RECESTADO FROM DocCab AS DocCab_1 INNER JOIN DocDet ON DocCab_1.IdDocCab = DocDet.IdDocCab GROUP BY DocCab_1.IdDocCabOrig, DocCab_1.DocNr, DocCab_1.DataDoc, DocCab_1.Obs1, DocCab_1.EstadoDoc, DocCab_1.IdDocCab, DocCab_1.Obs) AS RECOLHA ON DocCab.IdDocCab = RECOLHA.IdDocCabOrig WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.EmpresaID = '" & xEmp & "') AND (RECOLHA.RECESTADO  " & xFiltraEstado & ") ORDER BY DocCab.DataDoc DESC"


            db.GetData(Sql, dtRecolhaTaloes)
            BindingSource1.DataSource = dtRecolhaTaloes

            'dgvRecolhaTaloes.DataSource = dtRecolhaTaloes
            dgvRecolhaTaloes.DataSource = BindingSource1




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
            dgvRecolhaTaloes.Columns("VDMB").Width = 70

            dgvRecolhaTaloes.Columns("VDD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecolhaTaloes.Columns("VDD").DefaultCellStyle.Format = "C2"
            dgvRecolhaTaloes.Columns("VDD").Width = 70

            dgvRecolhaTaloes.Columns("VDC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecolhaTaloes.Columns("VDC").DefaultCellStyle.Format = "C2"
            dgvRecolhaTaloes.Columns("VDC").Width = 70

            dgvRecolhaTaloes.Columns("Comissão").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecolhaTaloes.Columns("Comissão").DefaultCellStyle.Format = "C2"
            dgvRecolhaTaloes.Columns("Comissão").Width = 80

            dgvRecolhaTaloes.Columns("Deposito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecolhaTaloes.Columns("Deposito").DefaultCellStyle.Format = "C2"
            dgvRecolhaTaloes.Columns("Deposito").Width = 80

            dgvRecolhaTaloes.Columns("ObsLoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvRecolhaTaloes.Columns("ObsLoja").Width = 100

            dgvRecolhaTaloes.Columns("Obs").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvRecolhaTaloes.Columns("Obs").Width = 200

            'dgvRecolhaTaloes.Columns("Obs1").Visible = False
            dgvRecolhaTaloes.Columns("IDDocCab").Visible = False
            'dgvRecolhaTaloes.Columns("IDDocCabOrig").Visible = False



        Catch ex As Exception

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
        frmRecolhaTaloes_Load(sender, e)
    End Sub

    Private Sub dgvRecolhaTaloes_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecolhaTaloes.CellEndEdit
        GravarObsRecolhasBackOffice(Me.dgvRecolhaTaloes("IdDocCab", Me.dgvRecolhaTaloes.CurrentCell.RowIndex).Value.ToString, Me.dgvRecolhaTaloes("ObsLoja", Me.dgvRecolhaTaloes.CurrentCell.RowIndex).Value.ToString, Me.dgvRecolhaTaloes("Obs", Me.dgvRecolhaTaloes.CurrentCell.RowIndex).Value.ToString)
    End Sub



    Private Sub dgvRecolhaTaloes_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRecolhaTaloes.CellMouseClick

        'bs.DataMember = "Reservas"
        'bs.DataSource = Me.GirlDataSet



        'bs.DataSource = dgvRecolhaTaloes
        Dim dg As New clsDataGrid(Me.dgvRecolhaTaloes, , BindingSource1)
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then

                dg.MostraFiltroForm(e)

            End If

        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": IniciarDataGrid")
        Finally
            dg.Dispose()
            dg = Nothing
        End Try
    End Sub



End Class