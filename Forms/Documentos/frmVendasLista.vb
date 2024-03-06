Imports System.Data.SqlClient


Public Class frmVendasLista

    Dim dt As New DataTable
    Dim dtLojas As New DataTable
    Dim sAuxEntrada As Boolean = True
    Dim Foto As New ClsFotos



    Private Sub frmVendasLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvListaDocs.Visible = False

        Dim db As New ClsSqlBDados


        Try

            If DevolveGrupoAcesso() = "ADMIN" Then
                iDiasDevolver = 9999
            Else
                iDiasDevolver = 16
            End If


            'PREENCHER COMBOBOX ARMAZEM

            Sql = "SELECT ArmazemID, rtrim(ArmazemID) + ' - ' + rtrim(ArmAbrev) as Lojas from Armazens where Activo='True'"
            db.GetData(Sql, dtLojas)
            'dtLojas.Rows.Add("%", "Todas as Lojas")
            Me.CbLojas.DataSource = dtLojas
            Me.CbLojas.DisplayMember = "Lojas"
            Me.CbLojas.ValueMember = "ArmazemID"
            Me.CbLojas.SelectedValue = xArmz
            If xArmz = "0000" Then
                Me.CbLojas.Enabled = True
                btFechar.Visible = True
                btok.Visible = False
                btCancel.Visible = False
                cbDA.Checked = False
                cbDA.Visible = False
            Else
                Me.CbLojas.Enabled = False
                btFechar.Visible = False
                btok.Visible = True
                btCancel.Visible = True
                cbDA.Checked = True
            End If
            sAuxEntrada = False

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmVendasLista_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmVendasLista_Load")

        End Try


    End Sub

    Private Sub ListaDocs()

        Dim db As New ClsSqlBDados

        Try

            dt.Clear()

            ''ESTE SCRIPT FALTA PASSAR AS VARIAVEIS
            'Sql = "SELECT DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, DocCab.TercID + ' ' + ClientesLoja.Nome AS CodID, DocCab.DataDoc, DocDet.SerieID, DocCab.IdDocCab, 
            '    DocCab.EstadoDoc AS E
            '    FROM     ClientesLoja INNER JOIN
            '    DocCab ON ClientesLoja.ClienteLojaID = DocCab.TercID INNER JOIN
            '    DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr
            '    WHERE  (DocDet.EstadoLn <> 'D')
            '    GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5), DocCab.TercID + ' ' + ClientesLoja.Nome, DocCab.DataDoc, 
            '    DocCab.EstadoDoc, DocCab.IdDocCab, DocCab.Obs1, DocDet.SerieID
            '    HAVING (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID = '0009') AND (DocCab.TipoDocID IN ('FS', 'FT')) AND (DocCab.DataDoc >= { fn NOW() } - 100 OR
            '    DocCab.Obs1 = 'DEVOLUÇÃO AUTORIZADA')
            '    ORDER BY DocCab.DataDoc DESC"


            'TRATAR ESTE SCRIPT
            'Sql = "SELECT DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, CONCAT(ClientesLoja.ClienteLojaID, ' ', ClientesLoja.Nome, ' ', ClientesLoja.Morada, ' ', 
            '        ClientesLoja.Localidade, ' ', ClientesLoja.CodPostal, ' ', ClientesLoja.NIF, ' ', ClientesLoja.Telefone, ' ', ClientesLoja.Telemovel, ' ', ClientesLoja.Email, ' ', ClientesLoja.Obs)  AS Cliente, DocCab.DataDoc, DocDet.SerieID, 
            '        DocCab.EstadoDoc AS E, DocDet.IdDocDet, DocDet.ModeloID, DocDet.CorID, DocDet.TamID, DocDet.Obs
            '        FROM     ClientesLoja INNER JOIN
            '        DocCab ON ClientesLoja.ClienteLojaID = DocCab.TercID INNER JOIN
            '        DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr
            '        WHERE  (DocDet.EstadoLn <> 'D') AND (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID = '0009') AND (DocCab.TipoDocID IN ('FS', 'FT')) AND (DocCab.DataDoc >= { fn NOW() } - 100) OR
            '        (DocDet.EstadoLn <> 'D') AND (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID = '0009') AND (DocCab.TipoDocID IN ('FS', 'FT'))
            '        ORDER BY DocCab.DataDoc DESC"


            If ArmazemConsignacao(Me.CbLojas.SelectedValue.ToString) = True Then

                cbDA.Visible = False

                Sql = "SELECT DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, 
                    CONCAT(ClientesLoja.ClienteLojaID, ' ', ClientesLoja.Nome, ' ', ClientesLoja.Morada, ' ', 
                                      ClientesLoja.Localidade, ' ', ClientesLoja.CodPostal, ' ', ClientesLoja.NIF, ' ', 
				                      ClientesLoja.Telefone, ' ', ClientesLoja.Telemovel, ' ', ClientesLoja.Email, ' ', ClientesLoja.Obs) AS Cliente, 
				                      DocCab.DataDoc AS Data, 
				                      DocDet.SerieID As Talão, 
                                      Serie.EstadoID AS Estado, 
				                      CONCAT(DocDet.ModeloID,'-', DocDet.CorID, '-',DocDet.TamID) AS Artigo, 
				                      DocDet.DevolucaoAutorizada As Devolver,
                                      DocCab.IdDocCab,
				                      DocDet.IdDocDet,
                                      DocDet.ModeloID,
                                      DocDet.CorID
                    FROM DocCab 
                    INNER JOIN DocDET ON DocDet.IdDocCab = DocCab.IdDocCab 
                    INNER JOIN ClientesLoja ON DocCab.TercID = ClientesLoja.ClienteLojaID
                    INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID
                    WHERE  (DocDet.EstadoLn <> 'D')
                    AND (DocCab.EmpresaID = '0001')
                    AND (DocCab.ArmazemID = '" & CbLojas.SelectedValue.ToString & "') 
                    AND (DocCab.TipoDocID IN ('VC'))
                    AND (SERIE.EstadoID='V')
                    ORDER BY DocCab.DataDoc DESC"

            Else

                If cbDA.Checked = True Then

                    Sql = "SELECT DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, 
                    CONCAT(ClientesLoja.ClienteLojaID, ' ', ClientesLoja.Nome, ' ', ClientesLoja.Morada, ' ', 
                                      ClientesLoja.Localidade, ' ', ClientesLoja.CodPostal, ' ', ClientesLoja.NIF, ' ', 
				                      ClientesLoja.Telefone, ' ', ClientesLoja.Telemovel, ' ', ClientesLoja.Email, ' ', ClientesLoja.Obs) AS Cliente, 
				                      DocCab.DataDoc AS Data, 
				                      DocDet.SerieID As Talão, 
                                      Serie.EstadoID AS Estado, 
				                      CONCAT(DocDet.ModeloID,'-', DocDet.CorID, '-',DocDet.TamID) AS Artigo, 
				                      DocDet.DevolucaoAutorizada As Devolver,
                                      DocCab.IdDocCab,
				                      DocDet.IdDocDet,
                                      DocDet.ModeloID,
                                      DocDet.CorID
                    FROM DocCab 
                    LEFT OUTER JOIN DocDET ON DocDet.IdDocCab = DocCab.IdDocCab 
                    LEFT OUTER JOIN ClientesLoja ON DocCab.TercID = ClientesLoja.ClienteLojaID
                    LEFT OUTER JOIN Serie ON DocDet.SerieID = Serie.SerieID
                    WHERE  (DocDet.EstadoLn <> 'D') 
                    AND (DocCab.EmpresaID = '0001') 
                    AND (DocCab.ArmazemID = '" & CbLojas.SelectedValue.ToString & "') 
                    AND (DocCab.TipoDocID IN ('FS', 'FT')) 
                    AND (DocDet.DevolucaoAutorizada='1' or DocCab.DataDoc >= '" & Now.AddDays(-iDiasDevolver).ToString("yyyy-MM-dd") & "')
                    ORDER BY DocCab.DataDoc DESC"
                Else

                    Sql = "SELECT DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, 
                    CONCAT(ClientesLoja.ClienteLojaID, ' ', ClientesLoja.Nome, ' ', ClientesLoja.Morada, ' ', 
                                      ClientesLoja.Localidade, ' ', ClientesLoja.CodPostal, ' ', ClientesLoja.NIF, ' ', 
				                      ClientesLoja.Telefone, ' ', ClientesLoja.Telemovel, ' ', ClientesLoja.Email, ' ', ClientesLoja.Obs) AS Cliente, 
				                      DocCab.DataDoc AS Data, 
				                      DocDet.SerieID As Talão, 
                                      Serie.EstadoID AS Estado, 
				                      CONCAT(DocDet.ModeloID,'-', DocDet.CorID, '-',DocDet.TamID) AS Artigo, 
				                      DocDet.DevolucaoAutorizada As Devolver,
                                      DocCab.IdDocCab,
				                      DocDet.IdDocDet,
                                      DocDet.ModeloID,
                                      DocDet.CorID
                    FROM DocCab 
                    LEFT OUTER JOIN DocDET ON DocDet.IdDocCab = DocCab.IdDocCab 
                    LEFT OUTER JOIN ClientesLoja ON DocCab.TercID = ClientesLoja.ClienteLojaID
                    LEFT OUTER JOIN Serie ON DocDet.SerieID = Serie.SerieID
                    WHERE  (DocDet.EstadoLn <> 'D') 
                    AND (DocCab.EmpresaID = '0001') 
                    AND (DocCab.ArmazemID = '" & CbLojas.SelectedValue.ToString & "') 
                    AND (DocCab.TipoDocID IN ('FS', 'FT')) 
                    ORDER BY DocCab.DataDoc DESC"


                End If


            End If




            db.GetData(Sql, dt, False)


            With Me.dgvListaDocs

                .DataSource = dt
                '.Columns("SerieNrDoc").HeaderText = "Doc"


                .Columns("Data").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"

                '.Columns("E").Width = 20
                '.Columns("ATDocCodeID").Width = 135

                .Columns("IdDocDet").Visible = False
                .Columns("IdDocCab").Visible = False
                .Columns("ModeloId").Visible = False
                .Columns("CorId").Visible = False


                If bLojaConsignacao = True Then
                    .Columns("SerieNrDoc").Visible = False
                    .Columns("Cliente").Visible = False
                    .Columns("Estado").Visible = False
                    .Columns("Devolver").Visible = False
                End If

                .Refresh()


            End With
            If dt.Rows.Count > 0 Then
                dgvListaDocs.CurrentCell = dgvListaDocs("Data", 0)
                dgvListaDocs.Visible = True
            Else
                dgvListaDocs.Visible = False
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListaDocs")
        Catch ex As Exception
            ErroVB(ex.Message, "ListaDocs")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        bCancelarEvento = True
        Me.Close()
    End Sub

    Private Sub btok_Click(sender As Object, e As EventArgs) Handles btok.Click

        Try

            If Me.dgvListaDocs.Rows.Count > 0 Then
                sIdDocCabAux = Me.dgvListaDocs("IdDocCab", Me.dgvListaDocs.CurrentCell.RowIndex).Value.ToString
                sIdDocDetAux = Me.dgvListaDocs("IdDocDet", Me.dgvListaDocs.CurrentCell.RowIndex).Value.ToString
            Else
                bCancelarEvento = True
                sIdDocCabAux = ""
                sIdDocDetAux = ""
            End If

            Me.Close()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "bt_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "bt_Click")
        Finally

        End Try
    End Sub

    Private Sub dgvListaDocs_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListaDocs.CellEndEdit

        Dim db As New ClsSqlBDados

        Try


            'Sql = "UPDATE DocDet SET  Obs ='" & Me.dgvListaDocs("Obs", Me.dgvListaDocs.CurrentCell.RowIndex).Value.ToString & "' 
            'WHERE IdDocDet='" & Me.dgvListaDocs("IdDocDet", Me.dgvListaDocs.CurrentCell.RowIndex).Value.ToString & "'"
            'db.ExecuteData(Sql)


            Sql = "UPDATE DocDet SET  DevolucaoAutorizada ='" & Me.dgvListaDocs("Devolver", Me.dgvListaDocs.CurrentCell.RowIndex).Value.ToString & "' 
            WHERE IdDocDet='" & Me.dgvListaDocs("IdDocDet", Me.dgvListaDocs.CurrentCell.RowIndex).Value.ToString & "'"
            db.ExecuteData(Sql)




        Catch ex As Exception

        End Try


    End Sub

    Private Sub CbLojas_SelectedValueChanged(sender As Object, e As EventArgs) Handles CbLojas.SelectedValueChanged
        Try
            If sAuxEntrada = False Then
                ListaDocs()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvListaDocs_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvListaDocs.CellBeginEdit

        If Not e.ColumnIndex = dgvListaDocs.Columns("Devolver").Index Or xArmz <> "0000" Then
            e.Cancel = True
        End If

    End Sub

    Private Sub btPesquisa_Click(sender As Object, e As EventArgs) Handles btPesquisa.Click



        Try

            If tbPesquisa.TextLength = 0 Then
                Exit Sub
            End If

            dgvListaDocs.DataSource = Nothing
            dgvListaDocs.DataSource = dt
            dgvListaDocs.Columns("IdDocDet").Visible = False
            dgvListaDocs.Columns("IdDocCab").Visible = False
            dgvListaDocs.Columns("ModeloId").Visible = False
            dgvListaDocs.Columns("CorId").Visible = False

            Dim searchText As String = tbPesquisa.Text.ToLower()

            Dim filteredTable As New DataTable()

            ' Adiciona as colunas da DataGridView à nova DataTable
            For Each column As DataGridViewColumn In dgvListaDocs.Columns
                filteredTable.Columns.Add(column.Name, column.ValueType)
            Next

            ' Adiciona as linhas que correspondem ao critério de pesquisa à nova DataTable
            For Each row As DataGridViewRow In dgvListaDocs.Rows
                If Not row.IsNewRow Then ' Ignora a linha de novo registro
                    Dim rowVisible As Boolean = False

                    For Each cell As DataGridViewCell In row.Cells
                        If cell.Value IsNot Nothing AndAlso cell.Value.ToString().ToLower().Contains(searchText) Then
                            rowVisible = True
                            Exit For
                        End If
                    Next

                    If rowVisible Then
                        Dim newRow As DataRow = filteredTable.NewRow()

                        For Each cell As DataGridViewCell In row.Cells
                            newRow(cell.ColumnIndex) = cell.Value
                        Next

                        filteredTable.Rows.Add(newRow)
                    End If
                End If
            Next

            ' Vincula a nova DataTable à DataGridView
            dgvListaDocs.DataSource = filteredTable


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "TbPesquisa_TextChanged")
        Catch ex As Exception
            ErroVB(ex.Message, "TbPesquisa_TextChanged")

        End Try

    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Close()
    End Sub

    Private Sub cbDA_CheckedChanged(sender As Object, e As EventArgs) Handles cbDA.CheckedChanged
        ListaDocs()
    End Sub

    Private Sub dgvListaDocs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvListaDocs.SelectionChanged
        Dim sModelo As String = ""
        Dim sCor As String = ""

        ' Verifica se há pelo menos uma linha selecionada
        If dgvListaDocs.SelectedRows.Count > 0 Then
            ' Acessa a célula da coluna desejada na linha selecionada e obtém o valor
            sModelo = dgvListaDocs.SelectedRows(0).Cells("ModeloId").Value.ToString()
            sCor = dgvListaDocs.SelectedRows(0).Cells("CorId").Value.ToString()

        End If

        Foto.CarregarFotoModeloCor(Me.PictureBox, sModelo & sCor) 'Carregar IMAGEM

    End Sub



End Class