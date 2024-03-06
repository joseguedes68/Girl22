

Imports System.Data.SqlClient
Imports C1.Win.C1TrueDBGrid


Public Class frmConsultaDocs

    Dim dtDocs As New DataTable
    Dim db As New ClsSqlBDados


    Friend dValorTotal As Double = 0



    Private Sub frmConsultaDocs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.C1TDBGCDocs.ColumnFooters = True
        C1TDBGCDocs.MarqueeStyle = MarqueeEnum.HighlightRow

    End Sub

    Private Sub btListaDocs_Click(sender As Object, e As EventArgs) Handles btListaDocs.Click

        dtDocs.Clear()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim xDeData As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim xAteData As String = dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") 'data para a query


            Sql = "SELECT Armazens.ArmazemID + '-' + Armazens.ArmAbrev AS Loja, CAST(Terc.codigo AS varchar(20)) AS Terceiro, Terc.Nome, Terc.NIF, Terc.Telemovel, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS Doc, 
                ISNULL(DocCab.DocOrig, '') + ISNULL(DocCab.ObsOrigem, '') AS DocOrig, DocCab.DataDoc AS Data, DocCab.ObsPag, ISNULL(TOTAIS.Valor, 0) AS Valor, FormaPagamento.FPDescr AS FP, DocCab.IdDocCab
                FROM     DocCab LEFT OUTER JOIN
                Armazens ON DocCab.ArmazemID = Armazens.ArmazemID LEFT OUTER JOIN
                FormaPagamento ON DocCab.FormaPagtoID = FormaPagamento.FormaPagtoID LEFT OUTER JOIN
                (SELECT ClienteLojaID AS codigo, Nome, NIF, Telemovel, IDClienteLoja AS ID
                FROM      ClientesLoja
                UNION
                SELECT TercID AS codigo, NomeAbrev AS Nome, NIF, Movel AS Telemovel, IDTerceiro AS ID
                FROM     Terceiros) AS Terc ON DocCab.IDTerceiro = Terc.ID LEFT OUTER JOIN
                (SELECT DocDet.IdDocCab, SUM(DocDet.Valor * TipoDoc.MovFinValor * DocDet.Qtd) AS Valor
                FROM      DocDet INNER JOIN
                TipoDoc ON DocDet.TipoDocID = TipoDoc.TipoDocID
                GROUP BY DocDet.IdDocCab) AS TOTAIS ON DocCab.IdDocCab = TOTAIS.IdDocCab
                WHERE  (DocCab.DataDoc >= CONVERT(DATETIME, '" & xDeData & "', 102)) AND (DocCab.DataDoc <= CONVERT(DATETIME, '" & xAteData & "', 102)) AND (DocCab.TipoDocID IN ('FS', 'NC', 'FT', 'GT', 'GC','FC','CC'))"

            db.GetData(Sql, dtDocs)
            C1TDBGCDocs.DataSource = dtDocs



            Dim xLarguraGrid As VariantType
            For Each Coluna As C1DisplayColumn In Me.C1TDBGCDocs.Splits(0).DisplayColumns
                Coluna.Style.Font = New Font("Arial", 9, FontStyle.Regular)
                Coluna.HeadingStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                Coluna.HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                Coluna.Style.HorizontalAlignment = AlignHorzEnum.Center
                Coluna.AutoSize()
                Dim xLargColuna As Int16 = Coluna.Width
                xLarguraGrid += (xLargColuna + 10)
                Coluna.Locked = True
            Next

            Me.C1TDBGCDocs.Splits(0).DisplayColumns("IdDocCab").Visible = False
            Me.C1TDBGCDocs.Columns("Valor").NumberFormat = "Currency"
            Me.C1TDBGCDocs.Splits(0).DisplayColumns("Valor").Width = 150
            Me.C1TDBGCDocs.Splits(0).DisplayColumns("ObsPag").Width = 100
            Me.C1TDBGCDocs.Splits(0).DisplayColumns("ObsPag").Locked = False




            C1TDBGCDocs.FilterBar = True
            'C1TDBGCDocs.AllowFilter = False
            C1TDBGCDocs.FilterBarStyle.BackColor = Color.LightYellow


            CalculateFooter()

            Me.Cursor = Cursors.Default


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "btListaDocs_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "btListaDocs_Click")

        End Try

    End Sub



    'eventos na C1TDBGCDocs

    Private Sub C1TDBGCDocs_BeforeColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles C1TDBGCDocs.BeforeColUpdate









        'Dim db As New ClsSqlBDados


        'Try



        '    If sAplicacao = "CELFGEST" Then

        '        e.Cancel = True
        '        SendKeys.Send("{escape}")

        '    Else

        '        Select Case e.Column.Name

        '            Case "Comissao"

        '                dComissaoAux = C1TDBGCDocs(C1TDBGCDocs.Row, "Comissao")

        '                'Case "PrVnd"
        '                '    If C1TDBGCTaloes(sLinha, "Comissao") = 0 Then
        '                '        MsgBox("A Comissão não pode ser Zero!")
        '                '        e.Cancel = True
        '                '        SendKeys.Send("{escape}")
        '                '    End If



        '            Case "Cor"

        '                Dim xModelo As String = Me.C1TDBGCDocs.Columns("Modelo").Text()
        '                Dim xCor As String = Me.C1TDBGCDocs.Columns("Cor").Text()

        '                Sql = "SELECT count(*) Existe FROM Serie WHERE (ModeloID = '" & xModelo & "') AND (CorID = '" & xCor & "')"
        '                Dim sExiste As String = db.GetDataValue(Sql)

        '                If sExiste = 0 Then
        '                    MsgBox("A cor " & xCor & " não está criada!!", MsgBoxStyle.Information)
        '                    e.Cancel = True
        '                    SendKeys.Send("{escape}")
        '                End If



        '        End Select


        '    End If




        'Catch ex As SqlException
        '    ErroSQL(ex.Number, ex.Message, "CarregarDados")
        'Catch ex As Exception
        '    ErroVB(ex.Message, "CarregarDados")
        'Finally
        '    If Not db Is Nothing Then db.Dispose()
        '    db = Nothing
        'End Try


    End Sub

    Private Sub C1TDBGCDocs_DoubleClick(sender As Object, e As EventArgs) Handles C1TDBGCDocs.DoubleClick


        Try

            Dim sNomeColuna As String = Me.C1TDBGCDocs.Splits(0).DisplayColumns(C1TDBGCDocs.Col).Name

            If xGrupoAcesso = "ADMIN" And (sNomeColuna = "Doc" Or sNomeColuna = "DocOrig") Then

                If C1TDBGCDocs.Row >= 0 Then

                    frmConsultaDetalheDocs.xdoc = C1TDBGCDocs(C1TDBGCDocs.Row, "IdDocCab").ToString
                    frmConsultaDetalheDocs.StartPosition = FormStartPosition.CenterParent
                    frmConsultaDetalheDocs.WindowState = FormWindowState.Normal
                    frmConsultaDetalheDocs.ShowInTaskbar = False
                    frmConsultaDetalheDocs.MaximizeBox = False
                    frmConsultaDetalheDocs.MinimizeBox = False
                    frmConsultaDetalheDocs.ShowDialog(Me)


                End If

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TDBGCDocs_MouseClick")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TDBGCDocs_MouseClick")

        End Try

    End Sub

    Private Sub C1TDBGCTaloes_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1TDBGCDocs.FilterChange
        C1TrueDBGridFilterChange(C1TDBGCDocs, Me.C1TDBGCDocs.Columns, dtDocs)
        CalculateFooter()
    End Sub



    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub

    Public Sub CalculateFooter()

        Try


            Dim i As Integer
            Dim sum As Double
            For i = 0 To Me.C1TDBGCDocs.Splits(0).Rows.Count - 1
                sum += Me.C1TDBGCDocs.Columns("Valor").CellValue(i)
            Next
            Me.C1TDBGCDocs.Columns("Valor").FooterText = FormatCurrency(sum)



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CalculateFooter")
        Catch ex As Exception
            ErroVB(ex.Message, "CalculateFooter")

        End Try

    End Sub



    Private Sub C1TDBGCDocs_AfterColEdit(sender As Object, e As ColEventArgs) Handles C1TDBGCDocs.AfterColEdit



        Dim sObsPag As String = ""
        Dim sIDDocCab As String = ""
        Dim db As New ClsSqlBDados




        Try

            sObsPag = C1TDBGCDocs(C1TDBGCDocs.Row, "ObsPag").ToString
            sIDDocCab = C1TDBGCDocs(C1TDBGCDocs.Row, "IdDocCab").ToString


            Sql = "Update DocCab set ObsPag='" & sObsPag & "' where IdDocCab='" & sIDDocCab & "'"
            db.ExecuteData(Sql)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TDBGCDocs_AfterColEdit")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TDBGCDocs_AfterColEdit")

        End Try


    End Sub



End Class