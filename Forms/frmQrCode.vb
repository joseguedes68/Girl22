Imports QRCoder

Public Class frmQrCode


    Private Sub BtQrcode_Click(sender As Object, e As EventArgs) Handles btQrcode.Click

        Dim db As New ClsSqlBDados

        Try

            'Dim sqrcod As String = Me.tbtexto.Text
            'b3ca42e5-464f-43fd-817d-bb766c72c21d
            Sql = "SELECT 
                concat('A:',Empresas.EmpContrib,'*B:'+DocCab.NIFTerc,'*C:PT*D:'+
                DocCab.TipoDocID,'*E:N*F:',YEAR(DataDoc),FORMAT(MONTH(DataDoc),'00'),
                FORMAT(DAY(DATADOC),'00'),'*G:',DocCab.TipoDocID,' ',DocCab.SerieDoc,TRIM('/'),DocCab.NrDoc,
                '*H:0*I1:',Armazens.TaxCountryRegion,
                '*I7:',format(round(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),2),'0.00'),
                '*I8:',format(round(SUM(DocDet.VlrIVA * DocDet.Qtd),2),'0.00'), 
                '*N:',format(round(SUM(DocDet.VlrIVA * DocDet.Qtd),2),'0.00'), 
                '*O:',format(round(SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd),2),'0.00'), 
                '*Q:', DocCab.Hash4d, 
                '*R:',2054) AS QRCODE
                FROM   Empresas INNER JOIN
                             DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN
                             Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
                             DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr
                WHERE (CONVERT(varchar(36), DocCab.IdDocCab) = '" & tbtexto.Text & "')
                GROUP BY Empresas.EmpContrib, DocCab.NIFTerc, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.SerieDoc, DocCab.NrDoc, Armazens.TaxCountryRegion, DocCab.Hash4d"
            Dim sQrCode As String = db.GetDataValue(Sql)

            tbString.Text = sQrCode
            '"A:123456789*B:999999990*C:PT*D:FS*E:N*F:20190812*G:FSCDVF/12345*H:CDF7T5HD12345*I1:PT*I7:0.65*I8:0.15*N:0.15*O:0.80*Q:YhGV*R:9999*S:NU;0.80"
            Dim gen As New QRCodeGenerator
            Dim iVersao As Int16 = -1
            If Len(sQrCode) < 150 Then iVersao = 9
            Dim data = gen.CreateQrCode(sQrCode, QRCodeGenerator.ECCLevel.M, False, False, QRCodeGenerator.EciMode.Default, iVersao)
            Dim cod As New QRCode(data)

            pic.Image = cod.GetGraphic(6)
            store_pic_Sql(cod.GetGraphic(6))


            'Dim mStream As MemoryStream = New MemoryStream()
            'cod.GetGraphic(6).Save(mStream, ImageFormat.Jpeg)
            'MsgBox(mStream.GetBuffer)

            'Dim sql As String = "insert into aux4 values(1,@imgData)"



        Catch ex As Exception
            ErroVB(ex.Message, "BtQrcode_Click")
        Finally

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click






    End Sub
End Class