
Imports System.Data.SqlClient


Public Class frmGerarEtiquetas


    Dim dtGrelha As New DataTable
    Dim dPreco As Double
    Dim dtGrelhaHorizAux As New DataTable
    Dim bFechar As Boolean = False



    Private Sub frmGerarEtiquetas_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        LimparForm()

    End Sub


    Private Sub tbProductCode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbProductCode.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            'TODO: VALIDAR O CAMPO : ESTÁ A VALIDAR NO LEAVE
            e.Handled = True
            tbProductCode_Leave(sender, e)
        End If

    End Sub

    Private Sub tbProductCode_Leave(sender As Object, e As System.EventArgs) Handles tbProductCode.Leave

        Dim db As New ClsSqlBDados


        Try

            If bFechar = True Then Exit Sub
            If Len(tbProductCode.Text) = 0 Then Exit Sub

            Sql = "SELECT ISNULL(ProductDescription,'')  FROM Product WHERE ProductCode = '" & tbProductCode.Text & "'"
            lbDescrProduct.Text = db.GetDataValue(Sql)
            If Len(lbDescrProduct.Text) = 0 Then
                MsgBox("Produto não existe!")
                tbProductCode.SelectAll()
            Else
                tbProductCode.Enabled = False
                tbModelo.Focus()
                lbDescrProduct.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub tbModelo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbModelo.KeyPress


        If e.KeyChar = ChrW(Keys.Enter) Then
            'TODO: VALIDAR O CAMPO : ESTÁ A VALIDAR NO LEAVE
            e.Handled = True
            tbModelo_Leave(sender, e)

        End If


    End Sub

    Private Sub tbModelo_Leave(sender As Object, e As System.EventArgs) Handles tbModelo.Leave

        Dim db As New ClsSqlBDados
        dtGrelha.Clear()

        Try

            If bFechar = True Then Exit Sub
            If Len(tbModelo.Text) = 0 Then Exit Sub

            Sql = "SELECT ISNULL(Escalas.TamId,'') AS TamID FROM Modelos INNER JOIN Escalas ON Modelos.EscalaID = Escalas.EscalaID WHERE (Modelos.ModeloID = '" & tbModelo.Text & "') ORDER BY Escalas.TamId"
            db.GetData(Sql, dtGrelha)
            If dtGrelha.Rows.Count = 0 Then
                MsgBox("Modelo não existe ou não tem Grelha associada!")
                tbModelo.SelectAll()
            Else
                Act_Grelha_Tamanhos()
                tbCor.Focus()
                tbModelo.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub tbCor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbCor.KeyPress


        If e.KeyChar = ChrW(Keys.Enter) Then
            'TODO: VALIDAR O CAMPO : ESTÁ A VALIDAR NO LEAVE
            e.Handled = True
            tbCor_Leave(sender, e)

        End If



    End Sub

    Private Sub tbCor_Leave(sender As Object, e As System.EventArgs) Handles tbCor.Leave

        Dim db As New ClsSqlBDados

        Try

            If bFechar = True Then Exit Sub
            If Len(tbCor.Text) = 0 Then Exit Sub


            Sql = "SELECT ISNULL(PrVnd,0) FROM ModeloCor WHERE (ModeloID = '" & tbModelo.Text & "') AND (CorID = '" & tbCor.Text & "')"
            dPreco = db.GetDataValue(Sql)
            If dPreco = 0 Then
                MsgBox("Cor não existe ou falta Preço de Venda!")
                tbCor.SelectAll()
            Else
                gbTamanhos.Visible = True
                dgvDetTam.Focus()
                tbCor.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        bFechar = True
        Close()
    End Sub

    Private Sub btGerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGerar.Click


        Try

            If dgvDetTam.Item("Total", 0).Value > 0 Then

                For Each c As DataColumn In dtGrelhaHorizAux.Columns
                    If c.ColumnName <> "Total" Then
                        If Not dtGrelhaHorizAux.Rows(0).Item(c.ColumnName) Is DBNull.Value Then
                            GerarTaloes(c.ColumnName, dtGrelhaHorizAux.Rows(0).Item(c.ColumnName))
                        End If
                    End If
                Next

            End If

            MsgBox("Etiquetas Geradas!")

            LimparForm()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub


    'EVENTOS NA dgvDetTam 

    Private Sub dgvDetTam_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetTam.CellEndEdit
        Dim iTotal As Integer


        Try


            For Each c As DataColumn In dtGrelhaHorizAux.Columns
                If c.ColumnName <> "Total" Then
                    If Not dtGrelhaHorizAux.Rows(0).Item(c.ColumnName) Is DBNull.Value Then
                        iTotal += dtGrelhaHorizAux.Rows(0).Item(c.ColumnName)
                    End If
                End If
            Next
            dgvDetTam.Item("Total", dgvDetTam.CurrentRow.Index).Value = iTotal


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    'FUNÇÕES

    Private Function GerarTaloes(ByVal sTam As String, ByVal iQtd As Integer) As Boolean
        Dim db As New ClsSqlBDados

        Try
            Dim xSerie As String
            Dim xContador As Integer
            Dim xData As String = Today.Year & "-" & Today.Month & "-" & Today.Day

            'IR BUSCAR O CONTADOR
            Sql = "SELECT ISNULL(MAX(RIGHT(SerieID,6)),0) AS NUM FROM Serie WHERE left(SerieID,2) = SUBSTRING(CONVERT(CHAR,GETDATE(),120),3,2)"
            If db.GetDataValue(Sql) > 0 Then
                xContador = db.GetDataValue(Sql) + 1
            Else
                xContador = 1
            End If


            Dim ANO As String = Today.Year
            ANO = Microsoft.VisualBasic.Right(ANO, 2)

            Dim J As Int16
            For J = 1 To iQtd
                xSerie = ANO & Format(xContador, "000000")
                Sql = "INSERT INTO Serie (SerieID, ProductCode, ModeloID, CorID, TamID, ArmazemID, PrecoEtiqueta, PrecoVenda, DtSaida, EstadoID, Vendedor, OperadorID ) " & _
                      "VALUES ('" & xSerie & "', '" & tbProductCode.Text & "', '" & tbModelo.Text & "', '" & tbCor.Text & "', '" & sTam & "', '0000', " & dPreco & ", " & dPreco & ", '" & xData & "', 'G',Null, '" & xUtilizador & "')"
                db.ExecuteData(Sql)
                xContador += 1
            Next

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GerarTaloes")
        Catch ex As Exception
            ErroVB(ex.Message, "GerarTaloes")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            Sql = Nothing
        End Try
    End Function

    Private Sub LimparForm()


        lbDescrProduct.Visible = False
        dPreco = 0
        tbProductCode.Text = ""
        tbModelo.Text = ""
        tbCor.Text = ""
        gbTamanhos.Visible = False
        tbProductCode.Enabled = True
        tbProductCode.Focus()
        dtGrelhaHorizAux.Clear()
        tbModelo.Enabled = True
        tbCor.Enabled = True

    End Sub

    Private Sub btCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btCancelar.Click

        LimparForm()

    End Sub

    Private Sub Act_Grelha_Tamanhos()


        Try

            Dim dtGrelhaHoriz As New DataTable
            dgvDetTam.DataSource = dtGrelhaHoriz
            Dim I As Integer = 0
            For Each r As DataRow In dtGrelha.Rows
                dtGrelhaHoriz.Columns.Add(r("TamID"))
                dgvDetTam.Columns(I).Width = 35
                I += 1
            Next

            dtGrelhaHoriz.Columns.Add("Total", GetType(Integer))
            dtGrelhaHoriz.Rows.Add()


            dgvDetTam.Columns("Total").Width = 50
            dgvDetTam.Columns("Total").ReadOnly = True
            dgvDetTam.AllowUserToAddRows = False

            dtGrelhaHorizAux = dtGrelhaHoriz


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub



End Class