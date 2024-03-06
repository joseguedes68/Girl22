
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text


Public Class clsHash

    Dim textbytes, encryptedtextbytes As Byte()
    Dim rsa As New RSACryptoServiceProvider
    Dim encoder As New UTF8Encoding




    Public Sub CriarHashKey(ByRef IDDocCab As String)


        Dim privateKey As RSACryptoServiceProvider


        'VAI SER ALTERADO SE A CHAVE MUDAR.......PEDIDO PELA EMPRESA PRODUTORA DO SOFTWARE
        'pem to xml online converter
        'CONVERTER A CHAVE PRIVADA PEM PARA XML : https://superdry.apphb.com/tools/online-rsa-key-converter
        'CHAVE PRIVADA NO FORMATO PEM : ESTÁ EM C:\Girl\Chaves\

        '        -----BEGIN RSA PRIVATE KEY-----
        'MIICXgIBAAKBgQDci1NLUn4gcYlva1CNrnpsf4cYG8VIiOyNp4hjOgjs4wKHMynm
        'UCEiIeS1oQewACZxFzWJec4oCa5L3PzMV0s/N/222/pAoSaMhDi2d8xWEZQkN5Mx
        'QLhNAnDbsmVQu3MlQpXP1647cw+crLe6TPCbjdUSlVpzhhlqM4C+t1lrLwIDAQAB
        'AoGBAJla3DF9DCz9JebvBVVvpLs7NjIiZV1ZsLuTajgtS7WE6OYgQptezptQXBub
        '/J96i0CKNfUBWMPob2VbJgHlFXF2VZ8K81Z9UbwV8H4UOBkC/x0jFUII7BxkZIJX
        'OrvxSWQ4nsHRP1g97jNyklS+CelfuUslZ+4U0rHoi0nQNgBpAkEA+kBhf6S9JjCq
        'a04PG6ypd1eWS4Dw3DOJJbJSysl+wb3O2cc9IHtAjwFB017os+6/cr7yKbroeYGD
        'j6h9Fph7TQJBAOGcP81+NH+pQbpKVp6eTKc5R1A2073SJseoBVphsDDmQ5iRZRhS
        'MFAQNlGpFkPnBxxS/RCbNwFr06JiEMTQamsCQQDu1os3G686x6+egf2BWCTVNc7H
        'eORoBPeb9rl1uSE1H0ZQKwt3+KoA0h5U8Xv+XppxlTPiB/TgIm/Bp/jam+TxAkAw
        'SMp25k3CDK1ee05ygBqTp3SVvEYw1+soy9LpdwLIVF+fJW7nd5+TYwTdET0Mp0Mk
        'UraKeU2aZkNS+33vQVOlAkEA7b4zw48bMEc6KXwNFUTAysQTKJ9Nc8bVSDPju2LK
        'OaAlGmIfgX+gbXJ8t0H78g7C59j9K6RIirKLoieiJBLLVw==
        ''-----END RSA PRIVATE KEY-----


        Dim iPrivateKeyVersao As Integer = 1
        Dim sPrivateKeyXML As String = "<RSAKeyValue><Modulus>3ItTS1J+IHGJb2tQja56bH+HGBvFSIjsjaeIYzoI7OMChzMp5lAhIiHktaEHsAAmcRc1iXnOKAmuS9z8zFdLPzf9ttv6QKEmjIQ4tnfMVhGUJDeTMUC4TQJw27JlULtzJUKVz9euO3MPnKy3ukzwm43VEpVac4YZajOAvrdZay8=</Modulus><Exponent>AQAB</Exponent><P>+kBhf6S9JjCqa04PG6ypd1eWS4Dw3DOJJbJSysl+wb3O2cc9IHtAjwFB017os+6/cr7yKbroeYGDj6h9Fph7TQ==</P><Q>4Zw/zX40f6lBukpWnp5MpzlHUDbTvdImx6gFWmGwMOZDmJFlGFIwUBA2UakWQ+cHHFL9EJs3AWvTomIQxNBqaw==</Q><DP>7taLNxuvOsevnoH9gVgk1TXOx3jkaAT3m/a5dbkhNR9GUCsLd/iqANIeVPF7/l6acZUz4gf04CJvwaf42pvk8Q==</DP><DQ>MEjKduZNwgytXntOcoAak6d0lbxGMNfrKMvS6XcCyFRfnyVu53efk2ME3RE9DKdDJFK2inlNmmZDUvt970FTpQ==</DQ><InverseQ>7b4zw48bMEc6KXwNFUTAysQTKJ9Nc8bVSDPju2LKOaAlGmIfgX+gbXJ8t0H78g7C59j9K6RIirKLoieiJBLLVw==</InverseQ><D>mVrcMX0MLP0l5u8FVW+kuzs2MiJlXVmwu5NqOC1LtYTo5iBCm17Om1BcG5v8n3qLQIo19QFYw+hvZVsmAeUVcXZVnwrzVn1RvBXwfhQ4GQL/HSMVQgjsHGRkglc6u/FJZDiewdE/WD3uM3KSVL4J6V+5SyVn7hTSseiLSdA2AGk=</D></RSAKeyValue>"


        Dim db As New ClsSqlBDados
        Dim dt As New DataTable


        Dim sChave As String = ""
        Dim sInvoiceDate As String = ""
        Dim sSystemEntryDate As String = ""
        Dim sInvoiceNo As String = ""
        Dim dGrossTotal As Double = 0
        Dim sHashAnterior As String = ""
        Dim sHash As String = ""
        Dim sGrossTotal As String

        Try
            dberrorAtivo = True

            'COM O IDDOCCAB VOU BUSCAR OS ELEMENTOS DO DOCUMENTO
            'VERIFICAR SE É O PRIMEIRO DA SÉRIE, SE NÃO, PEGAR HASH DO REGISTO ANTERIOR 
            'FAZER UPDATE DO CAMPO HASH CRIADO
            Sql = "SELECT DocCab.DataDoc, DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr, DocCab.IdDocCab, ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd),0) AS ValorTotal FROM DocCab LEFT OUTER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr GROUP BY DocCab.DataDoc, DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr, DocCab.IdDocCab HAVING (DocCab.IdDocCab = '" & IDDocCab & "')"
            db.GetData(Sql, dt)

            If dt.Rows.Count = 0 Then
                HashOK = False
                Exit Sub
            End If

            sInvoiceDate = CDate(dt.Rows(0)("DataDoc")).ToString("yyyy-MM-dd")
            sSystemEntryDate = CDate(dt.Rows(0)("DataDoc")).ToString("s")
            'sSystemEntryDate = Format(dt.Rows(0)("DataDoc"), "yyyy-MM-ddTHH:mm:ss")
            sInvoiceNo = Trim(dt.Rows(0)("TipoDocID")) & " " & Microsoft.VisualBasic.Left(dt.Rows(0)("DocNr"), 2) & Microsoft.VisualBasic.Right(dt.Rows(0)("ArmazemID"), 2) & "/" & Microsoft.VisualBasic.Right(dt.Rows(0)("DocNr"), 5)
            dGrossTotal = Arredondamento(dt.Rows(0)("ValorTotal"), 2)

            sGrossTotal = dGrossTotal.ToString("0.00")

            Sql = "SELECT ISNULL(Hash,'') Hash FROM DocCab WHERE (TipoDocID = '" & Trim(dt.Rows(0)("TipoDocID")) & "') AND (ArmazemID = '" & Trim(dt.Rows(0)("ArmazemID")) & "') AND (DocNr = N'" & Trim(HashAnteriorAux) & "')"
            sHashAnterior = db.GetDataValue(Sql)

            If Len(sHashAnterior) > 0 Then
                sChave = sInvoiceDate & ";" & sSystemEntryDate & ";" & sInvoiceNo & ";" + sGrossTotal & ";" & sHashAnterior
            Else
                sChave = sInvoiceDate & ";" & sSystemEntryDate & ";" & sInvoiceNo & ";" & sGrossTotal & ";"
            End If

            'If Len(sHashAnterior) = 0 And Trim(HashAnteriorAux) <> "0000" Then
            '    HashOK = False
            '    EnviarEmail("Erro","Erro 56850 na criação do documento! não gerou a Hash para o docID: " & IDDocCab)
            '    Exit Sub
            'End If

            privateKey = New RSACryptoServiceProvider

            'ACHO QUE ISTO NÃO SERVE PARA NADA!!
            textbytes = encoder.GetBytes(sPrivateKeyXML)

            privateKey.FromXmlString(sPrivateKeyXML)

            Dim buffer As Byte() = Encoding.GetEncoding("Windows-1252").GetBytes(sChave)

            Dim signature As Byte() = privateKey.SignData(buffer, "SHA1")

            sHash = Convert.ToBase64String(signature)

            HashAnteriorAux = dt.Rows(0)("DocNr")
            Dim sHash4d As String = sHash.Substring(0, 1) & sHash.Substring(10, 1) & sHash.Substring(20, 1) & sHash.Substring(30, 1)
            HashOK = False
            If Len(Trim(sHash4d)) = 4 Then
                Sql = "UPDATE DocCab SET ChaveAssinar='" & sChave & "', ChavePrivadaVersao=" & iPrivateKeyVersao & ", SerieDoc='" & sChave.Substring(34, 4) & "', NrDoc='" & sChave.Substring(39, 5) & "', Hash = N'" & sHash & "', Hash4d='" & sHash4d & "' WHERE (IdDocCab='" & IDDocCab & "')"
                db.ExecuteData(Sql)
                If dberror = False Then
                    'VERIFICAR SE A HASH ESTÁ LÁ....
                    HashOK = True
                Else
                    EnviarEmail("Erro", "Erro", "Erro 568 na criação do documento! não gerou a Hash para o docID: " & IDDocCab)
                End If
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CriarHashKey")
        Catch ex As Exception
            ErroVB(ex.Message, "CriarHashKey")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            dberrorAtivo = False
        End Try

    End Sub

    Public Sub CriarHashKeyDireto(ByRef schave As String)

        Dim privateKey As RSACryptoServiceProvider

        Dim iPrivateKeyVersao As Integer = 1
        Dim sPrivateKeyXML As String = "<RSAKeyValue><Modulus>3ItTS1J+IHGJb2tQja56bH+HGBvFSIjsjaeIYzoI7OMChzMp5lAhIiHktaEHsAAmcRc1iXnOKAmuS9z8zFdLPzf9ttv6QKEmjIQ4tnfMVhGUJDeTMUC4TQJw27JlULtzJUKVz9euO3MPnKy3ukzwm43VEpVac4YZajOAvrdZay8=</Modulus><Exponent>AQAB</Exponent><P>+kBhf6S9JjCqa04PG6ypd1eWS4Dw3DOJJbJSysl+wb3O2cc9IHtAjwFB017os+6/cr7yKbroeYGDj6h9Fph7TQ==</P><Q>4Zw/zX40f6lBukpWnp5MpzlHUDbTvdImx6gFWmGwMOZDmJFlGFIwUBA2UakWQ+cHHFL9EJs3AWvTomIQxNBqaw==</Q><DP>7taLNxuvOsevnoH9gVgk1TXOx3jkaAT3m/a5dbkhNR9GUCsLd/iqANIeVPF7/l6acZUz4gf04CJvwaf42pvk8Q==</DP><DQ>MEjKduZNwgytXntOcoAak6d0lbxGMNfrKMvS6XcCyFRfnyVu53efk2ME3RE9DKdDJFK2inlNmmZDUvt970FTpQ==</DQ><InverseQ>7b4zw48bMEc6KXwNFUTAysQTKJ9Nc8bVSDPju2LKOaAlGmIfgX+gbXJ8t0H78g7C59j9K6RIirKLoieiJBLLVw==</InverseQ><D>mVrcMX0MLP0l5u8FVW+kuzs2MiJlXVmwu5NqOC1LtYTo5iBCm17Om1BcG5v8n3qLQIo19QFYw+hvZVsmAeUVcXZVnwrzVn1RvBXwfhQ4GQL/HSMVQgjsHGRkglc6u/FJZDiewdE/WD3uM3KSVL4J6V+5SyVn7hTSseiLSdA2AGk=</D></RSAKeyValue>"

        Dim sHash As String = ""
        Dim sHash4d As String

        Try

            privateKey = New RSACryptoServiceProvider

            'ACHO QUE ISTO NÃO SERVE PARA NADA!!
            textbytes = encoder.GetBytes(sPrivateKeyXML)

            privateKey.FromXmlString(sPrivateKeyXML)

            Dim buffer As Byte() = Encoding.GetEncoding("Windows-1252").GetBytes(schave)

            Dim signature As Byte() = privateKey.SignData(buffer, "SHA1")

            sHash = Convert.ToBase64String(signature)
            sHash4d = sHash.Substring(0, 1) & sHash.Substring(10, 1) & sHash.Substring(20, 1) & sHash.Substring(30, 1)

            MsgBox(sHash)
            MsgBox(sHash4d)


        Catch ex As Exception

            ErroVB(ex.Message, "CriarHashKeyDireto")

        End Try

    End Sub



End Class
