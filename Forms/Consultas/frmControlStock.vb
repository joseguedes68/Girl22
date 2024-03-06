
Imports System.Data.SqlClient


Public Class frmControlStock

    Dim dtaux As New DataTable
    Dim xTipoArmz As String

    Private Sub frmControlStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Me.ArmazensTableAdapter.Fill(Me.GirlDataSet.Armazens)
            'Me.GirlDataSet.Armazens.AddArmazensRow("9999", "GERAL", "GERAL", "", "", "", "", "", "", True, Now(), Now(), "", "")
            tbAno.Text = Year(Now)
            tbDeDoc.Text = "0000000"
            tbAteDoc.Text = "9999999"
            cbArmazem.SelectedValue = ""

        Catch ex As Exception
            ErroVB(ex.Message, "frmControlStock_Load")
        Finally

        End Try

    End Sub

    Private Sub btLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLimpar.Click
        Dim db As New ClsSqlBDados
        Dim I As Integer
        Dim xMinDoc As String = ""
        Dim xTercID As String
        Dim xModelo As String
        Dim xCor As String
        Dim xDeDoc As String = tbDeDoc.Text
        Dim xAteDoc As String = tbAteDoc.Text


        Try

            Sql = "SELECT TercID FROM ARMAZENS where ArmazemID='" & cbArmazem.SelectedValue & "'"
            xTercID = db.GetDataValue(Sql)

            If Not xTercID Is DBNull.Value Then
                If Not dtaux Is Nothing Then
                    For Each r As DataRow In dtaux.Rows
                        For I = 1 To r("ABATER")

                            xModelo = r("MODELO")
                            xCor = r("COR")

                            Sql = "SELECT MIN(DocCab.DocNr) AS MinDoc FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND  DocDet.DocNr = DocCab.DocNr WHERE     (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.TipoDocID = 'FC') AND (DocCab.TercID = '" & xTercID & "') AND (DocDet.ModeloID = '" & xModelo & "') AND (DocDet.CorID = '" & xCor & "') GROUP BY DocDet.Qtd HAVING DocDet.Qtd > 0 AND MIN(DocCab.DocNr) BETWEEN '" & xDeDoc & "' and '" & xAteDoc & "'"
                            xMinDoc = db.GetDataValue(Sql)
                            If Len(xMinDoc) > 0 Then
                                Sql = "UPDATE DocDet SET Qtd = DocDet.Qtd - 1 FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND  DocDet.DocNr = DocCab.DocNr WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.TipoDocID = 'FC') AND (DocCab.TercID = '" & xTercID & "') AND (DocDet.ModeloID = '" & xModelo & "') AND (DocDet.CorID = '" & xCor & "') AND (DocCab.DocNr = N'" & xMinDoc & "')"
                                db.ExecuteData(Sql)
                                'Sql = "UPDATE DocCab SET Obs = 'Reimprimir' WHERE (EmpresaID = '" & xEmp & "') AND (TipoDocID = 'FC') AND (TercID = '" & xTercID & "') AND (DocNr = N'" & xMinDoc & "') AND (ArmazemID = '0000')"
                                'db.ExecuteData(Sql)
                            Else
                                Exit For
                            End If
                        Next
                    Next
                    Sql = "UPDATE DocCab SET Obs = 'Reimprimir ' + RTRIM(LTRIM(DocCab.Obs)) FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND  DocCab.DocNr = DocDet.DocNr WHERE (DocDet.Qtd = 0) AND (DocCab.TipoDocID = 'FC')"
                    db.ExecuteData(Sql)
                    Sql = "DELETE FROM DocDet WHERE (TipoDocID = 'FC') AND (Qtd = 0)"
                    db.ExecuteData(Sql)

                    CarregarDados()

                End If
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btLimpar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btLimpar_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing

        End Try
    End Sub

    Private Sub btFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFacturar.Click
        Dim db As New ClsSqlBDados
        Dim xNovoDoc As String
        Dim nLinha As Double = 1
        Dim xTercID As String

        Try
            If dtaux.Rows.Count > 0 Then

                xNovoDoc = PesquisaMaxNumDoc("FT")



                Sql = "SELECT TercID FROM ARMAZENS where ArmazemID='" & cbArmazem.SelectedValue & "'"
                xTercID = db.GetDataValue(Sql)


                Sql = "INSERT INTO DocCab(EmpresaID,ArmazemID,TipoDocID,DocNr,TercID,DataDoc,TipoDocOrig,DocNrOrig,Exp,PPagID, " & _
                    "LocalCarga,HoraCarga,LocDesc,HoraDesc,Obs,DescontoDoc,EstadoDoc,TipoTerc,OperadorID) " & _
                    "VALUES('" & xEmp & "','" & xArmz & "','FT','" & xNovoDoc & "','" & xTercID & "',GETDATE(),'','','','','', " & _
                    "'','',null,'',0.45,'C','','" & xUtilizador & "') "
                db.ExecuteData(Sql)

                For Each r As DataRow In dtaux.Rows
                    If IIf(r("Facturar") Is DBNull.Value, 0, r("Facturar")) > 0 Then

                        Sql = "INSERT INTO DocDet(EmpresaID,ArmazemID,TipoDocID,DocNr,DocLnNr,SerieID,ModeloID,CorID,TamID,Descricao,Unidade, " & _
                    "DocNrLnOrig,Valor,PercDescLn,VlrDescLn,IvaID,Qtd,Obs,EstadoLn,OperadorID) " & _
                    "VALUES('" & xEmp & "','" & xArmz & "','FT','" & xNovoDoc & "','" & nLinha & "',null,'" & r("Modelo") & "','" & r("Cor") & "',null,'" & r("Descr") & "','" & r("Un") & "', " & _
                    "null, " & r("Valor") & ", null, null, '" & xIvaID & "', " & r("Facturar") & ", '', 'C', '" & xUtilizador & "')"
                        db.ExecuteData(Sql)
                    End If
                    nLinha = nLinha + 1

                Next
            End If

            CarregarDados()
            Me.tbDeposito.Text = ""



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btFacturar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btFacturar_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub btActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btActualizar.Click

        Try
            If Len(tbAno.Text) > 0 And Len(cbArmazem.SelectedValue.ToString) > 0 Then
                CarregarDados()
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btActualizar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btActualizar_Click")
        Finally

        End Try
    End Sub

    'EVENTOS NA GRID dgvControloStock

    Private Sub dgvControloStock_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvControloStock.CellMouseClick
        Dim dg_filtro As New clsDataGrid(Me.dgvControloStock, dtaux.DefaultView)
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then

                dg_filtro.MostraFiltroForm(e)

            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": dgvControloStock_CellMouseClick")
        Finally
            dg_filtro.Dispose()
            dg_filtro = Nothing
        End Try
    End Sub

    Private Sub dgvControloStock_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvControloStock.CellEndEdit

        Dim xSubTotal As Double = 0

        Try

            Me.dgvControloStock("VALORTOT", e.RowIndex).Value = Me.dgvControloStock("VALOR", e.RowIndex).Value * Me.dgvControloStock("FACTURAR", e.RowIndex).Value

            dtaux.AcceptChanges()

            xSubTotal = dtaux.Compute("Sum(VALORTOT)", "")

            Me.tbDeposito.Text = xSubTotal * (1 - Me.tbDesconto.Text / 100) * (1 + DevolveIva(xIvaID))

            Me.lbFacturar.Text = "Quantidade: " & dtaux.Compute("Sum(FACTURAR)", "").ToString

            If e.RowIndex + 1 < Me.dgvControloStock.Rows.Count Then
                dgvControloStock.CurrentCell = dgvControloStock("FACTURAR", e.RowIndex + 1)
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "dgvControloStock_CellEndEdit")
        End Try

    End Sub

    'FUNÇÕES

    Private Sub CarregarDados()

        Dim db As New ClsSqlBDados
        Dim xAno As Integer = IIf(Len(tbAno.Text) = 4, tbAno.Text, 0)
        Dim xTotEnviados As Double = 0
        Dim xTotSaidas As Double = 0
        Dim I As Integer


        Try

            xTipoArmz = DevolveTipoArmz(cbArmazem.SelectedValue.ToString)

            If xAno = 0 Then
                MsgBox("Introduza o Ano!")
            Else

                dtaux.Clear()

                If cbArmazem.SelectedValue = "9999" Then xTipoArmz = "Empresa"
                If xTipoArmz = "Interno" Then
                    Sql = "SELECT ENVIADOS.MODELO, ENVIADOS.COR, ENVIADOS.ENVIADOS, ISNULL(STOCK.STOCK, 0) AS STOCK, ISNULL(FACTURADOS.FACTURADOS, 0) AS FACTURADOS, ISNULL(ISNULL(ENVIADOS.ENVIADOS,0) - (ISNULL(STOCK.STOCK,0) + ISNULL(FACTURADOS.FACTURADOS,0)), 0) AS ABATER FROM (SELECT     DocDet.ModeloID AS MODELO, DocDet.CorID AS COR, ISNULL(SUM(DocDet.Qtd), 0) AS ENVIADOS FROM          DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND  DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.TercID = Armazens.TercID WHERE      (DocCab.TipoDocID = 'GT') AND (Armazens.ArmazemID = '" & cbArmazem.SelectedValue & "') AND (YEAR(DocCab.DataDoc) = '" & xAno & "') GROUP BY DocDet.ModeloID, DocDet.CorID) AS ENVIADOS LEFT OUTER JOIN (SELECT     DocDet_1.ModeloID, DocDet_1.CorID, ISNULL(SUM(DocDet_1.Qtd), 0) AS FACTURADOS FROM          DocCab AS DocCab_1 INNER JOIN DocDet AS DocDet_1 ON DocCab_1.EmpresaID = DocDet_1.EmpresaID AND DocCab_1.ArmazemID = DocDet_1.ArmazemID AND  DocCab_1.TipoDocID = DocDet_1.TipoDocID AND DocCab_1.DocNr = DocDet_1.DocNr INNER JOIN Armazens AS Armazens_1 ON DocCab_1.ArmazemID = Armazens_1.TercID WHERE   (DocCab_1.TipoDocID IN ('FT', 'VD', 'FC', 'GT')) AND (Armazens_1.ArmazemID = '" & cbArmazem.SelectedValue & "') AND (YEAR(DocCab_1.DataDoc) = '" & xAno & "') GROUP BY DocDet_1.ModeloID, DocDet_1.CorID) AS FACTURADOS ON ENVIADOS.MODELO = FACTURADOS.ModeloID AND  ENVIADOS.COR = FACTURADOS.CorID LEFT OUTER JOIN (SELECT     ModeloID, CorID, COUNT(*) AS STOCK FROM          Serie WHERE      (EstadoID IN ('S', 'V')) AND (ArmazemID = '" & cbArmazem.SelectedValue & "') GROUP BY ModeloID, CorID) AS STOCK ON ENVIADOS.MODELO = STOCK.ModeloID AND ENVIADOS.COR = STOCK.CorID"
                ElseIf xTipoArmz = "Externo" Then
                    'Sql = "SELECT MODELOS.GRUPO, MODELOS.MODELO, MODELOS.COR, ISNULL(ENVIADOS.QtdEnv, 0) AS ENVIADOS, ISNULL(STOCK.QtdStk, 0) AS STOCK, ISNULL(FACTURADOS.QtdFacturados, 0) AS FACTURADOS, ISNULL(ISNULL(ENVIADOS.QtdEnv, 0) - (ISNULL(STOCK.QtdStk, 0) + ISNULL(FACTURADOS.QtdFacturados, 0)), 0) AS ABATER, MODELOS.VALOR, NULL AS FACTURAR ,NULL AS VALORTOT FROM (SELECT Modelos_1.GrupoID AS GRUPO, ModeloCor.ModeloID AS MODELO, ModeloCor.CorID AS COR, ModeloCor.PrVnd AS VALOR, Unidades.UnidDescr, ModeloCor.ModCorDescr FROM ModeloCor INNER JOIN Modelos AS Modelos_1 ON ModeloCor.ModeloID = Modelos_1.ModeloID INNER JOIN Unidades ON Modelos_1.UnidID = Unidades.UnidID) AS MODELOS LEFT OUTER JOIN (SELECT ModeloID, CorID, COUNT(*) AS QtdStk FROM Serie WHERE (EstadoID IN ('S', 'V')) AND (ArmazemID = '" & cbArmazem.SelectedValue & "') GROUP BY ModeloID, CorID) AS STOCK ON MODELOS.MODELO = STOCK.ModeloID AND MODELOS.COR = STOCK.CorID LEFT OUTER JOIN (SELECT DocDet_1.ModeloID, DocDet_1.CorID, ISNULL(SUM(DocDet_1.Qtd), 0) AS QtdFacturados FROM DocCab AS DocCab_1 INNER JOIN DocDet AS DocDet_1 ON DocCab_1.EmpresaID = DocDet_1.EmpresaID AND DocCab_1.ArmazemID = DocDet_1.ArmazemID AND DocCab_1.TipoDocID = DocDet_1.TipoDocID AND DocCab_1.DocNr = DocDet_1.DocNr INNER JOIN Armazens AS Armazens_1 ON DocCab_1.TercID = Armazens_1.TercID WHERE (DocCab_1.TipoDocID = 'FT') AND (Armazens_1.ArmazemID = '" & cbArmazem.SelectedValue & "') AND (YEAR(DocCab_1.DataDoc) = '" & xAno & "') GROUP BY DocDet_1.ModeloID, DocDet_1.CorID) AS FACTURADOS ON MODELOS.MODELO = FACTURADOS.ModeloID AND MODELOS.COR = FACTURADOS.CorID LEFT OUTER JOIN (SELECT DocDet.ModeloID AS MODELO, DocDet.CorID AS COR, ISNULL(SUM(DocDet.Qtd), 0) AS QtdEnv FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.TercID = Armazens.TercID WHERE (DocCab.TipoDocID = 'FC') AND (Armazens.ArmazemID = '" & cbArmazem.SelectedValue & "') AND (YEAR(DocCab.DataDoc) = '" & xAno & "') GROUP BY DocDet.ModeloID, DocDet.CorID) AS ENVIADOS ON MODELOS.MODELO = ENVIADOS.MODELO AND MODELOS.COR = ENVIADOS.COR WHERE (ISNULL(ENVIADOS.QtdEnv, 0) + ISNULL(STOCK.QtdStk, 0) + ISNULL(FACTURADOS.QtdFacturados, 0) > 0)"
                    Sql = "SELECT MODELOS.GRUPO, MODELOS.MODELO, MODELOS.COR, ISNULL(ENVIADOS.QtdEnv, 0) AS ENVIADOS, ISNULL(STOCK.QtdStk, 0) AS STOCK, ISNULL(FACTURADOS.QtdFacturados, 0) AS FACTURADOS, ISNULL(ISNULL(ENVIADOS.QtdEnv, 0) - (ISNULL(STOCK.QtdStk, 0)+ ISNULL(FACTURADOS.QtdFacturados, 0)), 0) AS Abater, MODELOS.VALOR, NULL AS FACTURAR, NULL AS VALORTOT, MODELOS.UnidDescr AS Un, MODELOS.ModCorDescr AS Descr FROM (SELECT Modelos_1.GrupoID AS GRUPO, ModeloCor.ModeloID AS MODELO, ModeloCor.CorID AS COR, ModeloCor.PrVnd AS VALOR, Unidades.UnidDescr, ModeloCor.ModCorDescr FROM ModeloCor INNER JOIN Modelos AS Modelos_1 ON ModeloCor.ModeloID = Modelos_1.ModeloID INNER JOIN Unidades ON Modelos_1.UnidID = Unidades.UnidID) AS MODELOS LEFT OUTER JOIN (SELECT ModeloID, CorID, COUNT(*) AS QtdStk FROM Serie WHERE (EstadoID IN ('S', 'V')) AND (ArmazemID = '" & cbArmazem.SelectedValue & "') GROUP BY ModeloID, CorID) AS STOCK ON MODELOS.MODELO = STOCK.ModeloID AND MODELOS.COR = STOCK.CorID LEFT OUTER JOIN (SELECT DocDet_1.ModeloID, DocDet_1.CorID, ISNULL(SUM(DocDet_1.Qtd), 0) AS QtdFacturados FROM DocCab AS DocCab_1 INNER JOIN DocDet AS DocDet_1 ON DocCab_1.EmpresaID = DocDet_1.EmpresaID AND DocCab_1.ArmazemID = DocDet_1.ArmazemID AND DocCab_1.TipoDocID = DocDet_1.TipoDocID AND DocCab_1.DocNr = DocDet_1.DocNr INNER JOIN Armazens AS Armazens_1 ON DocCab_1.TercID = Armazens_1.TercID WHERE (DocCab_1.TipoDocID = 'FT') AND (Armazens_1.ArmazemID = '" & cbArmazem.SelectedValue & "') AND (YEAR(DocCab_1.DataDoc) = '" & xAno & "') GROUP BY DocDet_1.ModeloID, DocDet_1.CorID) AS FACTURADOS ON MODELOS.MODELO = FACTURADOS.ModeloID AND MODELOS.COR = FACTURADOS.CorID LEFT OUTER JOIN (SELECT DocDet.ModeloID AS MODELO, DocDet.CorID AS COR, ISNULL(SUM(DocDet.Qtd), 0) AS QtdEnv FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.TercID = Armazens.TercID WHERE (DocCab.TipoDocID = 'FC') AND (Armazens.ArmazemID = '" & cbArmazem.SelectedValue & "') AND (YEAR(DocCab.DataDoc) = '" & xAno & "') GROUP BY DocDet.ModeloID, DocDet.CorID) AS ENVIADOS ON MODELOS.MODELO = ENVIADOS.MODELO AND MODELOS.COR = ENVIADOS.COR WHERE (ISNULL(ENVIADOS.QtdEnv, 0) + ISNULL(STOCK.QtdStk, 0) + ISNULL(FACTURADOS.QtdFacturados, 0) > 0)"
                    'Sql = "SELECT ENVIADOS.MODELO, ENVIADOS.COR, ENVIADOS.ENVIADOS, ISNULL(STOCK.STOCK, 0) AS STOCK, ISNULL(FACTURADOS.FACTURADOS, 0) AS FACTURADOS, ISNULL(ISNULL(ENVIADOS.ENVIADOS,0) - (ISNULL(STOCK.STOCK,0) + ISNULL(FACTURADOS.FACTURADOS,0)), 0) AS ABATER FROM (SELECT     DocDet.ModeloID AS MODELO, DocDet.CorID AS COR, ISNULL(SUM(DocDet.Qtd), 0) AS ENVIADOS FROM          DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND  DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Armazens ON DocCab.TercID = Armazens.TercID WHERE      (DocCab.TipoDocID = 'FC') AND (Armazens.ArmazemID = '" & cbArmazem.SelectedValue & "') AND (YEAR(DocCab.DataDoc) = '" & xAno & "') GROUP BY DocDet.ModeloID, DocDet.CorID) AS ENVIADOS LEFT OUTER JOIN (SELECT     DocDet_1.ModeloID, DocDet_1.CorID, ISNULL(SUM(DocDet_1.Qtd), 0) AS FACTURADOS FROM          DocCab AS DocCab_1 INNER JOIN DocDet AS DocDet_1 ON DocCab_1.EmpresaID = DocDet_1.EmpresaID AND DocCab_1.ArmazemID = DocDet_1.ArmazemID AND  DocCab_1.TipoDocID = DocDet_1.TipoDocID AND DocCab_1.DocNr = DocDet_1.DocNr INNER JOIN Armazens AS Armazens_1 ON DocCab_1.TercID = Armazens_1.TercID WHERE      (DocCab_1.TipoDocID = 'FT') AND (Armazens_1.ArmazemID = '" & cbArmazem.SelectedValue & "')  AND (YEAR(DocCab_1.DataDoc) = '" & xAno & "') GROUP BY DocDet_1.ModeloID, DocDet_1.CorID) AS FACTURADOS ON ENVIADOS.MODELO = FACTURADOS.ModeloID AND  ENVIADOS.COR = FACTURADOS.CorID LEFT OUTER JOIN (SELECT     ModeloID, CorID, COUNT(*) AS STOCK FROM          Serie WHERE      (EstadoID IN ('S', 'V')) AND (ArmazemID = '" & cbArmazem.SelectedValue & "') GROUP BY ModeloID, CorID) AS STOCK ON ENVIADOS.MODELO = STOCK.ModeloID AND ENVIADOS.COR = STOCK.CorID  "
                ElseIf xTipoArmz = "Empresa" Then

                End If
                db.GetData(Sql, dtaux, False)

                If Not dtaux.Compute("Sum(ENVIADOS)", "") Is DBNull.Value Then
                    xTotEnviados = dtaux.Compute("Sum(ENVIADOS)", "")
                End If

                If Not dtaux.Compute("Sum(FACTURADOS)", "") Is DBNull.Value Then
                    xTotSaidas = dtaux.Compute("Sum(FACTURADOS)", "")
                End If

                Me.dgvControloStock.DataSource = dtaux

                Me.lbEnt.Text = "Enviados: " & xTotEnviados.ToString
                Me.lbSai.Text = "Facturados: " & xTotSaidas.ToString
                Me.lbExiste.Text = "Existe: " & xTotEnviados - xTotSaidas
                Me.lbStock.Text = "Stock: " & dtaux.Compute("Sum(STOCK)", "").ToString

                Dim NC As Int16 = Me.dgvControloStock.ColumnCount
                For I = 0 To Me.dgvControloStock.ColumnCount - 1
                    Me.dgvControloStock.Columns(I).ReadOnly = True
                Next

                If xTipoArmz = "Externo" Then
                    Me.dgvControloStock.Columns("FACTURAR").ReadOnly = False
                    Me.dgvControloStock.Columns("VALOR").ReadOnly = False
                    Me.dgvControloStock.Columns("VALORTOT").Visible = False
                    Me.dgvControloStock.Columns("Un").Visible = False
                    Me.dgvControloStock.Columns("Descr").Visible = False

                    Me.dgvControloStock.Columns("GRUPO").HeaderText = "Gr"


                End If

                Me.dgvControloStock.Columns("ENVIADOS").HeaderText = "Env"
                Me.dgvControloStock.Columns("STOCK").HeaderText = "Stk"
                Me.dgvControloStock.Columns("FACTURADOS").HeaderText = "Fact"


            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarDados")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarDados")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub


    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click

        Me.Close()

    End Sub
End Class