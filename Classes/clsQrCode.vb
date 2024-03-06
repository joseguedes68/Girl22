

Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports QRCoder


Public Class clsQrCode


    Public Function CarregaQrCode(ByRef idDocCab As String) As Boolean


        Dim db As New ClsSqlBDados

        Try




            'Sql = "UPDATE DOCCAB SET DOCCAB.QrCodeValor =(SELECT 
            '        concat('A:',Empresas.EmpContrib,'*B:',IIF(DocCab.NIFTerc='xxxxxxxxx','999999990',DocCab.NIFTerc),'*C:','PT',*D:',
            '        DocCab.TipoDocID,'*E:N*F:',YEAR(DataDoc),FORMAT(MONTH(DataDoc),'00'),
            '        FORMAT(DAY(DATADOC),'00'),'*G:',DocCab.TipoDocID,' ',DocCab.SerieDoc,TRIM('/'),DocCab.NrDoc,
            '        '*H:0*I1:',Armazens.TaxCountryRegion,
            '        '*I7:',format(round(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),2),'0.00'),
            '        '*I8:',format(round(SUM(DocDet.VlrIVA * DocDet.Qtd),2),'0.00'), 
            '        '*N:',format(round(SUM(DocDet.VlrIVA * DocDet.Qtd),2),'0.00'), 
            '        '*O:',format(round(SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd),2),'0.00'), 
            '        '*Q:', DocCab.Hash4d, 
            '        '*R:',2054) AS QRCODE
            '        FROM   Empresas INNER JOIN
            '                     DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN
            '                     Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN
            '                     DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr
            '        WHERE (CONVERT(varchar(36), DocCab.IdDocCab) = '" & idDocCab & "')
            '        GROUP BY Empresas.EmpContrib, DocCab.NIFTerc, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.SerieDoc, DocCab.NrDoc, Armazens.TaxCountryRegion, DocCab.Hash4d)
            '        WHERE (CONVERT(varchar(36), DocCab.IdDocCab) = '" & idDocCab & "')"

            'Sql = "UPDATE DOCCAB SET DOCCAB.QrCodeValor =(SELECT
            '        concat('A:',Empresas.EmpContrib,'*B:',IIF(DocCab.NIFTerc='xxxxxxxxx','999999990',DocCab.NIFTerc),'*C:PT',DocCab.CountryDescarga,'*D:',
            '        DocCab.TipoDocID,'*E:N*F:',YEAR(DataDoc),FORMAT(MONTH(DataDoc),'00'),
            '        FORMAT(DAY(DATADOC),'00'),'*G:',DocCab.TipoDocID,' ',DocCab.SerieDoc,TRIM('/'),DocCab.NrDoc,
            '        '*H:0*I1:',Armazens.TaxCountryRegion,
            '        '*I7:',format(round(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),2),'0.00'),
            '        '*I8:',format(round(SUM(DocDet.VlrIVA * DocDet.Qtd),2),'0.00'), 
            '        '*N:',format(round(SUM(DocDet.VlrIVA * DocDet.Qtd),2),'0.00'), 
            '        '*O:',format(round(SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd),2),'0.00'), 
            '        '*Q:', DocCab.Hash4d, 
            '        '*R:',2054) AS QRCODE
            '        FROM  Empresas 
            '        INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID 
            '        INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID 
            '        INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr
            '        WHERE (CONVERT(varchar(36), DocCab.IdDocCab) = '" & idDocCab & "')
            '        GROUP BY Empresas.EmpContrib, DocCab.NIFTerc, DocCab.CountryDescarga, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.SerieDoc, DocCab.NrDoc, Armazens.TaxCountryRegion, DocCab.Hash4d)
            '        WHERE (CONVERT(varchar(36), DocCab.IdDocCab) = '" & idDocCab & "')"
            'db.ExecuteData(Sql)


            'Dim phrase As String = "OLÁ-123".Split("-")(0)


            Sql = "UPDATE DOCCAB SET DOCCAB.QrCodeValor =(SELECT
                    concat('A:',Empresas.EmpContrib,'*B:',IIF(DocCab.NIFTerc='xxxxxxxxx','999999990',DocCab.NIFTerc),'*C:PT',DocCab.CountryDescarga,'*D:',
                    DocCab.TipoDocID,'*E:N*F:',YEAR(DataDoc),FORMAT(MONTH(DataDoc),'00'),
                    FORMAT(DAY(DATADOC),'00'),'*G:',DocCab.TipoDocID,' ',DocCab.SerieDoc,TRIM('/'),DocCab.NrDoc,
                    '*H:',DocCab.ATCUD,
                    '*I1:',Armazens.TaxCountryRegion,
                    '*I7:',format(round(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),2),'0.00'),
                    '*I8:',format(round(SUM(DocDet.VlrIVA * DocDet.Qtd),2),'0.00'), 
                    '*N:',format(round(SUM(DocDet.VlrIVA * DocDet.Qtd),2),'0.00'), 
                    '*O:',format(round(SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd),2),'0.00'), 
                    '*Q:', DocCab.Hash4d, 
                    '*R:',2054) AS QRCODE
                    FROM  Empresas 
                    INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID 
                    INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID 
                    INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr
                    WHERE (CONVERT(varchar(36), DocCab.IdDocCab) = '" & idDocCab & "')
                    GROUP BY Empresas.EmpContrib, DocCab.NIFTerc, DocCab.CountryDescarga, DocCab.TipoDocID, DocCab.EstadoDoc, DocCab.DataDoc, DocCab.SerieDoc, DocCab.NrDoc, Armazens.TaxCountryRegion, DocCab.Hash4d, DocCab.ATCUD)
                    WHERE (CONVERT(varchar(36), DocCab.IdDocCab) = '" & idDocCab & "')"
            db.ExecuteData(Sql)




            Sql = "SELECT QrCodeValor FROM DOCCAB WHERE (CONVERT(varchar(36), DocCab.IdDocCab) = '" & idDocCab & "')"
            Dim sQrCode As String = db.GetDataValue(Sql)

            Dim gen As New QRCodeGenerator
            Dim iVersao As Int16 = -1
            If Len(sQrCode) < 150 Then iVersao = 9
            Dim data = gen.CreateQrCode(sQrCode, QRCodeGenerator.ECCLevel.M, False, False, QRCodeGenerator.EciMode.Default, iVersao)
            Dim cod As New QRCode(data)

            'pic.Image = cod.GetGraphic(6)
            'store_pic_Sql(cod.GetGraphic(6))



            Dim conn1 As SqlConnection = New SqlConnection()
            conn1.ConnectionString = sconnectionstring
            Sql = "UPDATE DOCCAB SET DOCCAB.QrCode=@imgData WHERE CONVERT(varchar(36), DocCab.IdDocCab) = '" & idDocCab & "'"
            'Sql = "UPDATE DOCCAB SET DOCCAB.QrCode=@imgData WHERE DocCab.IdDocCab=@idDocCab"

            'Sql = "insert into aux4 values(10,@imgData)"



            Dim command1 As SqlCommand = New SqlCommand(Sql, conn1)
            Dim sqlparaImag As New SqlParameter("imgData", SqlDbType.Image)
            'Dim sqlparaGuid As New SqlParameter("idDocCab", SqlDbType.UniqueIdentifier)

            Dim mStream As IO.MemoryStream = New MemoryStream()
            cod.GetGraphic(6).Save(mStream, ImageFormat.Jpeg)
            sqlparaImag.SqlValue = mStream.GetBuffer

            'sqlparaGuid.SqlValue = idDocCab


            command1.Parameters.Add(sqlparaImag)
            'command1.Parameters.Add(sqlparaGuid)

            conn1.Open()
            command1.ExecuteNonQuery()
            conn1.Close()


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregaQrCode")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregaQrCode")
        Finally
            db = Nothing
        End Try

    End Function




End Class
