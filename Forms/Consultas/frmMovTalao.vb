Imports System.Data.SqlClient

Public Class frmMovTalao

    Private Sub frmMovTalao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim db As New ClsSqlBDados
        Dim dt As New DataTable
        Dim xEstado As String = ""

        Try

            Sql = "Select EstadoID FROM serie where SerieID='" & xMovTalao & "'"
            xEstado = db.GetDataValue(Sql)
            If Len(Trim(xEstado)) = 0 Then
                MsgBox("O Talão Inserido não é válido!")
                Me.Close()
            Else
                Me.lbEstado.Text = "O Talão está no estado : " & xEstado
            End If

            Me.lblTalao.Text = xMovTalao

            '    Sql = "SELECT DocCab.DataDoc as Data, Armazens.ArmAbrev as Armazém, TipoDoc.TipoDocDesc as 'Tipo Documento', DocCab.DocNr as 'nºDoc', DocCab.TercID as Terceiro, DocCab.OperadorID as Operador " & _
            '"FROM DocDet INNER JOIN " & _
            '"DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND  " & _
            '"DocDet.DocNr = DocCab.DocNr INNER JOIN " & _
            '"TipoDoc ON DocCab.TipoDocID = TipoDoc.TipoDocID INNER JOIN " & _
            '"Armazens ON DocDet.ArmazemID = Armazens.ArmazemID " & _
            '"WHERE TipoDoc.TipoDocID <> N'CF' AND DocDet.SerieID = '" & xMovTalao & "' " & _
            '"ORDER BY DocCab.DataDoc "

            Sql = "SELECT DocDet.DtRegisto as Data, Armazens.ArmAbrev as Armazém, TipoDoc.TipoDocDesc as 'Tipo Documento', DocCab.DocNr as 'nºDoc', DocCab.TercID as Terceiro, DocCab.OperadorID as Operador " & _
        "FROM DocDet INNER JOIN " & _
        "DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND  " & _
        "DocDet.DocNr = DocCab.DocNr INNER JOIN " & _
        "TipoDoc ON DocCab.TipoDocID = TipoDoc.TipoDocID INNER JOIN " & _
        "Armazens ON DocDet.ArmazemID = Armazens.ArmazemID " & _
        "WHERE TipoDoc.TipoDocID <> N'CF' AND DocDet.SerieID = '" & xMovTalao & "' " & _
        "ORDER BY DocDet.DtRegisto "

            db.GetData(Sql, dt)
            dgvMovTalao.DataSource = dt
            dgvMovTalao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvMovTalao.AllowUserToDeleteRows = False
            dgvMovTalao.AllowUserToAddRows = False






        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmMovTalao_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmMovTalao_Load")
        Finally
            Sql = Nothing
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try



    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub
End Class