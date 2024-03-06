Public Class frmComissaoVnd



    Friend WithEvents crvComissoes As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Dim dtVendedor As New DataTable
    Dim sVendedorAux As String = sVendedor


    Private Sub frmComissaoVnd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim db As New ClsSqlBDados


        'CARREGAR UTILIZADORES
        Sql = "SELECT UtilizadorID, NomeUtilizador, ArmazemID, PassWord FROM Utilizadores WHERE ArmazemID = '" + xArmz + "' AND NovaPassWord='0'"
        db.GetData(Sql, dtVendedor, False)


        Me.cbVendedor.DataSource = dtVendedor
        Me.cbVendedor.DisplayMember = "NomeUtilizador"
        Me.cbVendedor.ValueMember = "UtilizadorID"
        If Len(sVendedor) > 0 Then
            Me.cbVendedor.SelectedValue = sVendedor
            dtVendedor.Rows.Add("65432154", "Todos")
        Else
            MsgBox("NÃO EXISTE VENDEDOR CRIADO PARA ESSA LOJA!")
            Exit Sub
        End If


        'Sql = "SELECT NomeUtilizador FROM Utilizadores WHERE  UtilizadorID = " & svendedor
        'lbVendedor.Text = db.GetDataValue(Sql)
        dtPicker.Value = Now
        dtPicker1.Value = Now



        Sql = "SELECT GrupoAcesso FROM Utilizadores WHERE  UtilizadorID = " & sVendedor
        Dim xGrupoAcesso As String = db.GetDataValue(Sql)

        If xGrupoAcesso = "NIVEL1" Or xGrupoAcesso = "ADMIN" Then
            Me.cbVendedor.Enabled = True
        Else
            Me.cbVendedor.Enabled = False
        End If



    End Sub



    Private Sub btListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btListar.Click

        If Not crvComissoes Is Nothing Then crvComissoes.Dispose()

        Me.Cursor = Cursors.WaitCursor
        Dim db As New ClsSqlBDados
        Dim dtAuxFecho As New DataTable
        sVendedorAux = cbVendedor.SelectedValue.ToString

        If sVendedorAux = "65432154" Then
            sVendedorAux = "%"
        End If

        Try

            Dim xDeData As String = dtPicker.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dtPicker1.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query
            Dim xAteDataReport As String = dtPicker1.Value.ToString("yyyy-MM-dd") ' data para aparecer no report


            Sql = "SELECT MIN(DocCab.DocNr) AS DEDOC, MAX(DocCab.DocNr) AS ATEDOC, ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd), 0) AS VndValor, ISNULL(SUM(DocDet.Comissao * (DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd), 0) AS Comissao FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocDet.UtilizadorID LIKE '" & sVendedorAux & "')"
            db.GetData(Sql, dtAuxFecho)


            If dtAuxFecho.Rows.Count = 0 Then
                MsgBox("Sem Comissões no Intervalo!")
                Exit Sub
            End If

            If dtAuxFecho.Rows.Count = 0 Then
                Sql = "SELECT MIN(DocNr) AS DEDOC, MAX(DocNr) AS ATEDOC, 0 AS VndValor, 0 AS Comissao, '" & xEmp & "' AS EmpresaID FROM DocCab WHERE (TipoDocID = 'FX') AND (ArmazemID = '" & xArmz & "') AND (EmpresaID = '" & xEmp & "') AND (DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102))"
                db.GetData(Sql, dtAuxFecho)
            End If

            If dtAuxFecho.Rows(0)("DEDOC") Is DBNull.Value Then
                MsgBox("Não existem Comissões no Intervalo!")
                Exit Sub
            End If

            Dim sMinDoc As String = dtAuxFecho.Rows(0)("DEDOC")
            Dim sMaxDoc As String = dtAuxFecho.Rows(0)("ATEDOC")
            Dim dC1 As Double = dtAuxFecho.Rows(0)("Comissao")
            'TAXA IVA : VARIAVEL GLOBAL xTaxaIva = 0.22


            Dim dDep As Double = 0



            Dim cryRpt As New CRComissoes
            Dim ds As New DataSet

            'Sql = "SELECT RECOLHADETALHE.SerieID FROM DocCab INNER JOIN (SELECT DocCab_2.IdDocCabOrig, DocDet_1.SerieID FROM DocCab AS DocCab_2 INNER JOIN DocDet AS DocDet_1 ON DocCab_2.IdDocCab = DocDet_1.IdDocCab) AS RECOLHADETALHE ON DocCab.IdDocCab = RECOLHADETALHE.IdDocCabOrig INNER JOIN Serie ON RECOLHADETALHE.SerieID = Serie.SerieID WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.ArmazemID LIKE '" & xArmz & "') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (Serie.Vendedor LIKE '" & sVendedorAux & "') ORDER BY RECOLHADETALHE.SerieID"
            Sql = "SELECT CASE DocDet.Qtd WHEN '-1' THEN '-'+DocDet.SerieID ELSE DocDet.SerieID END SerieID FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID WHERE (DocCab.TipoDocID = 'FX') AND (DocCab.ArmazemID LIKE '" & xArmz & "') AND (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocDet.UtilizadorID LIKE '" & sVendedorAux & "') AND (Serie.ProductCode not in ('90','96','97')) ORDER BY DocDet.SerieID"

            db.GetData(Sql, ds, False)

            cryRpt.SetDataSource(ds.Tables(0)) 'FUNCIONA PORQUE SÓ TEM UMA TABELA NO REPORT?????

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Sem dados no período!")
                Exit Sub
            End If

            cryRpt.SetParameterValue("deData", xDeData)
            cryRpt.SetParameterValue("ateData", xAteDataReport)
            cryRpt.SetParameterValue("C1", dC1)
            cryRpt.SetParameterValue("deDoc", sMinDoc)
            cryRpt.SetParameterValue("ateDoc", sMaxDoc)
            cryRpt.SetParameterValue("Vendedor", cbVendedor.Text)
            cryRpt.SetParameterValue("TxIva", DevolveIva(xIvaID))



            Me.crvComissoes = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
            Me.crvComissoes.ActiveViewIndex = -1
            Me.crvComissoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.crvComissoes.Cursor = System.Windows.Forms.Cursors.Default
            Me.crvComissoes.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.crvComissoes.Location = New System.Drawing.Point(0, 39)
            Me.crvComissoes.Name = "ncrvComissoes"
            Me.crvComissoes.Size = New System.Drawing.Size(1004, 432)
            Me.crvComissoes.TabIndex = 43
            Me.Controls.Add(crvComissoes)



            Me.crvComissoes.ReportSource = cryRpt
            Me.crvComissoes.Refresh()

        Catch ex As Exception
            ErroVB(ex.Message, "frmRelacaoVendas: btComissões_Click")
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Close()
        If Not crvComissoes Is Nothing Then crvComissoes.Dispose()
        crvComissoes = Nothing
        dtVendedor.Clear()
    End Sub

    Private Sub cbVendedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbVendedor.SelectedValueChanged

        If Not crvComissoes Is Nothing Then crvComissoes.Dispose()

    End Sub

End Class