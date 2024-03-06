Public Class frmFechoCaixaDet




    Private Sub frmFechoCaixaDet_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim db As New ClsSqlBDados
        Dim dtFechoCaixaDet As New DataTable


        Try


            'Sql = "SELECT DocDet.SerieID Etiqueta, DocDet.Valor, DocDet.Comissao, FormaPagamento.FPDescrAbrev FP FROM DocDet LEFT OUTER JOIN FormaPagamento ON DocDet.FormaPagtoID = FormaPagamento.FormaPagtoID WHERE (DocDet.IdDocCab = '" & frmFechoCaixa.sIdDocCabFechoAux & "') ORDER BY DocDet.SerieID"
            Sql = "SELECT DocDet.SerieID AS Etiqueta, DocDet.Qtd, DocDet.Valor, DocDet.Comissao, FormaPagamento.FPDescrAbrev AS FP FROM DocDet LEFT OUTER JOIN FormaPagamento ON DocDet.FormaPagtoID = FormaPagamento.FormaPagtoID WHERE (DocDet.IdDocCab = '" & frmFechoCaixa.sIdDocCabFechoAux & "') ORDER BY Etiqueta"
            db.GetData(Sql, dtFechoCaixaDet)
            dgvFechoCaixaDet.DataSource = dtFechoCaixaDet

            dgvFechoCaixaDet.Columns("Qtd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFechoCaixaDet.Columns("Qtd").DefaultCellStyle.Format = "N0"
            dgvFechoCaixaDet.Columns("Qtd").Width = 30


            dgvFechoCaixaDet.Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFechoCaixaDet.Columns("Valor").DefaultCellStyle.Format = "C2"

            dgvFechoCaixaDet.Columns("Comissao").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFechoCaixaDet.Columns("Comissao").DefaultCellStyle.Format = "p"

        Catch ex As Exception

        End Try


    End Sub



End Class