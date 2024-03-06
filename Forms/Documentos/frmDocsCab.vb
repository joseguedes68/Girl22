
Imports System.Data.SqlClient


Public Class frmDocsCab



    Dim dtCab As New DataTable
    Friend xTipoDocAux As String = ""
    Dim bFechar As Boolean = False



    'EVENTOS NO FORMULÁRIO

    Private Sub frmDocsCab_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim db As New ClsSqlBDados

        Try

            Me.Visible = False


            Me.MaximizeBox = False
            Me.MinimizeBox = False

            If xTipoDocAux = "SE" Then
                lbTipoDoc.Text = "SE"
                cbVerTodas.Visible = True

            ElseIf xTipoDocAux = "FT" Then
                lbTipoDoc.Text = "FT"
                cbVerTodas.Visible = True

            ElseIf xTipoDocAux = "FS" Then
                lbTipoDoc.Text = "FS"
                cbVerTodas.Visible = True

            ElseIf xTipoDocAux = "FX" Then
                lbTipoDoc.Text = "FX"
                cbVerTodas.Visible = True


            Else
                cbVerTodas.Visible = False
                lbTipoDoc.Text = xTipoDoc
            End If

            ActualizaCabeçalho()


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmDocsCab_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmDocsCab_Load")
        Finally
            If Not DB Is Nothing Then DB.Dispose()
            DB = Nothing
        End Try


    End Sub


    Private Sub cbVerConsignacao_CheckStateChanged(sender As Object, e As EventArgs)
        ActualizaCabeçalho()
    End Sub

    Private Sub cbVerTodas_CheckStateChanged(sender As Object, e As System.EventArgs) Handles cbVerTodas.CheckStateChanged
        ActualizaCabeçalho()
    End Sub

    Private Sub bt_Click(sender As System.Object, e As System.EventArgs) Handles btok.Click
        Try

            bFechar = True
            If Me.dgvDocCab.Rows.Count > 0 And MsgBox("Confirma que quer selecionar o documento?", MsgBoxStyle.YesNo, "Confirma Selecção") = MsgBoxResult.Yes Then
                sIdDocCabAux = Me.dgvDocCab("IdDocCab", Me.dgvDocCab.CurrentCell.RowIndex).Value.ToString
            Else
                bCancelarEvento = True
                sIdDocCabAux = ""
            End If

            Me.Close()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "bt_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "bt_Click")
        Finally

        End Try

    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        bFechar = True
        bCancelarEvento = True
        Me.Close()
    End Sub

    Private Sub frmDocsCab_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bFechar = False Then
            e.Cancel = True
        End If
    End Sub

    'FUNÇÕES

    Private Sub ActualizaCabeçalho()

        Dim db As New ClsSqlBDados

        Try

            dtCab.Clear()

            If xTipoDocAux = "SE" Then

                If cbVerTodas.Checked = True Then
                    'Sql = "Select DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(Armazens.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + Terceiros.NomeAbrev AS CodID, Terceiros.NomeAbrev AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.ATDocCodeID FROM Armazens INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID INNER JOIN DocCab ON Armazens.ArmazemID = DocCab.TercID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = 'SE') ORDER BY DocCab.DocNr DESC"

                    Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(Armazens.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, DocCab.DocNr, DocCab.TercID, 
                            DocCab.TercID + '-' + Terceiros.NomeAbrev AS CodID, Terceiros.NomeAbrev AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, 
                            DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, 
                            DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.ATDocCodeID FROM Armazens INNER JOIN
                            Terceiros ON Armazens.TercID = Terceiros.TercID INNER JOIN  DocCab ON Armazens.ArmazemID = DocCab.TercID
                            WHERE  (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = 'SE') 
                            AND (Terceiros.TipoTerc <> 'C')
                            ORDER BY DocCab.DocNr DESC"
                Else
                    'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(Armazens.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + Terceiros.NomeAbrev AS CodID, Terceiros.NomeAbrev AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.ATDocCodeID FROM Armazens INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID INNER JOIN DocCab ON Armazens.ArmazemID = DocCab.TercID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = 'SE') AND (DocCab.EstadoDoc = 'C') ORDER BY DocCab.DocNr DESC"

                    Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(Armazens.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, DocCab.DocNr, DocCab.TercID, 
                            DocCab.TercID + '-' + Terceiros.NomeAbrev AS CodID, Terceiros.NomeAbrev AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, 
                            DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, 
                            DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.ATDocCodeID FROM Armazens INNER JOIN
                            Terceiros ON Armazens.TercID = Terceiros.TercID INNER JOIN  DocCab ON Armazens.ArmazemID = DocCab.TercID
                            WHERE  (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = 'SE') AND (DocCab.EstadoDoc = 'C') 
                            AND (Terceiros.TipoTerc <> 'C')
                            ORDER BY DocCab.DocNr DESC"

                End If

            ElseIf xTipoDocAux = "SEC" Then

                'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, 
                '        DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(Armazens.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, 
                '        DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + Terceiros.NomeAbrev AS CodID, Terceiros.NomeAbrev AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.ATDocCodeID FROM Armazens INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID INNER JOIN DocCab ON Armazens.ArmazemID = DocCab.TercID 
                '        WHERE (DocCab.EmpresaID = '0001') 
                '        AND (DocCab.ArmazemID = '0000') 
                '        AND (DocCab.TipoDocID = 'SE') 
                '        AND (DocCab.EstadoDoc = 'C') 
                '        AND DocCab.TercID IN
                '        (SELECT Armazens.ArmazemID
                '        FROM Terceiros INNER JOIN
                '        Armazens ON Terceiros.TercID = Armazens.TercID
                '        WHERE (Terceiros.TipoTerc = 'C'))
                '        ORDER BY DocCab.DocNr DESC"


            ElseIf xTipoDocAux = "FT" Then

                Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, TipoDocID+' '+LEFT(DocNr,2)+right(ArmazemID,2)+'/'+right(DocNr,5) AS SerieNrDoc, DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + Terceiros.NomeAbrev AS CodID, Terceiros.NomeAbrev AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.ATDocCodeID FROM Terceiros INNER JOIN DocCab ON Terceiros.TercID = DocCab.TercID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = 'FT')  ORDER BY DocCab.DocNr DESC"

            ElseIf xTipoDocAux = "FX" Then


                If cbVerTodas.Checked = True Then

                    Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, DocCab.DocNr, Terceiros.TercID, Terceiros.TercID + '-' + Terceiros.NomeAbrev AS CodID, 
                Terceiros.NomeAbrev AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.ATDocCodeID, Terceiros.TipoTerc
                FROM   Armazens INNER JOIN
                DocCab ON Armazens.ArmazemID = DocCab.ArmazemID INNER JOIN
                Terceiros ON Armazens.TercID = Terceiros.TercID
                WHERE DocCab.TipoDocID = 'FX' AND Terceiros.TipoTerc = 'C' AND Terceiros.TercId='" & xDestinoAux & "' ORDER BY DocCab.DocNr DESC"

                Else

                    Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, DocCab.DocNr, Terceiros.TercID, Terceiros.TercID + '-' + Terceiros.NomeAbrev AS CodID, 
                Terceiros.NomeAbrev AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.ATDocCodeID, Terceiros.TipoTerc
                FROM   Armazens INNER JOIN
                DocCab ON Armazens.ArmazemID = DocCab.ArmazemID INNER JOIN
                Terceiros ON Armazens.TercID = Terceiros.TercID
                WHERE (DocCab.TipoDocID = 'FX') AND (Terceiros.TipoTerc = 'C') AND (DocCab.EstadoDoc = 'C') AND Terceiros.TercId='" & xDestinoAux & "' ORDER BY DocCab.DocNr DESC"



                End If





            ElseIf xTipoDocAux = "FS-FTS" Then

                Dim sClienteLojaIDFiltro As String = "%"
                ActualizarClienteLoja(sIDClienteLoja, sClienteLojaIDFiltro, "", "")
                'If sClienteLojaIDFiltro = "1" Then sClienteLojaIDFiltro = "%"
                Dim iDiasDevolver As Integer = 21
                If DevolveGrupoAcesso() = "ADMIN" Then
                    iDiasDevolver = 9999
                End If

                'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + ClientesLoja.Nome AS CodID, ClientesLoja.Nome AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab FROM ClientesLoja INNER JOIN DocCab ON ClientesLoja.ClienteLojaID = DocCab.TercID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocDet.EstadoLn <> 'D') AND (ClientesLoja.ClienteLojaID LIKE '" & sClienteLojaIDFiltro & "') GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5), DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + ClientesLoja.Nome, ClientesLoja.Nome, DocCab.DataDoc, DocCab.EstadoDoc, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab HAVING (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = 'FS') ORDER BY DocCab.DocNr DESC"

                Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS SerieNrDoc, 
                    DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + ClientesLoja.Nome AS CodID, ClientesLoja.Nome AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, 
                    DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.Obs1 FROM ClientesLoja 
                    INNER JOIN DocCab ON ClientesLoja.ClienteLojaID = DocCab.TercID 
                    INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr 
                    WHERE (DocDet.EstadoLn <> 'D') AND (ClientesLoja.ClienteLojaID LIKE '" & sClienteLojaIDFiltro & "') 
                    GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5), 
                    DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + ClientesLoja.Nome, ClientesLoja.Nome, DocCab.DataDoc, DocCab.EstadoDoc, DocCab.LocalCarga, DocCab.HoraCarga, 
                    DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.Obs1 
                    HAVING (DocCab.EmpresaID = '0001') 
                    AND (DocCab.ArmazemID = '" & xArmz & "') 
                    AND (DocCab.TipoDocID IN ('FS','FT')) 
                    AND ((DocCab.DataDoc >= { fn NOW() } - " & iDiasDevolver & ") OR DocCab.obs1='DEVOLUÇÃO AUTORIZADA') ORDER BY DocCab.DataDoc DESC"


            Else
                Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, TipoDocID+' '+LEFT(DocNr,2)+right(ArmazemID,2)+'/'+right(DocNr,5) SerieNrDoc, DocCab.DocNr, DocCab.TercID, DocCab.TercID + '-' + Terceiros.NomeAbrev CodID, Terceiros.NomeAbrev AS Destino, DocCab.DataDoc, DocCab.EstadoDoc AS E, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs, DocCab.DescontoDoc, DocCab.IdDocCab, DocCab.ATDocCodeID FROM DocCab INNER JOIN Terceiros ON DocCab.TercID = Terceiros.TercID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipoDoc & "') ORDER BY DocCab.DocNr DESC"
            End If

            db.GetData(Sql, dtCab, False)

            If dtCab.Rows.Count = 0 Then
                MsgBox("Não tem documentos autorizados para devolver!!",, "Aviso")
                bFechar = True
                bCancelarEvento = True
                Me.Close()
            End If

            With Me.dgvDocCab

                .DataSource = dtCab
                .Columns("SerieNrDoc").HeaderText = "Doc"
                .Columns("TercID").HeaderText = "Cod"
                .Columns("DataDoc").HeaderText = "Data"
                .Columns("DataDoc").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                .Columns("SerieNrDoc").Width = 90
                .Columns("TercID").Width = 35
                .Columns("Destino").Width = 135
                .Columns("DataDoc").Width = 75
                .Columns("E").Width = 20
                '.Columns("ATDocCodeID").Width = 135


                .Columns("EmpresaID").Visible = False
                .Columns("ArmazemID").Visible = False
                .Columns("TipoDocID").Visible = False
                .Columns("DocNr").Visible = False
                .Columns("LocalCarga").Visible = False
                .Columns("HoraCarga").Visible = False
                .Columns("LocDesc").Visible = False
                .Columns("HoraDesc").Visible = False
                .Columns("Obs").Visible = False
                .Columns("DescontoDoc").Visible = False
                .Columns("CodId").Visible = False
                .Columns("IdDocCab").Visible = False
                .Refresh()


            End With

            Me.Visible = True

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaCabeçalho")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaCabeçalho")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub


End Class