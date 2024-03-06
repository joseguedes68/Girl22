
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Text






Public Class frmWebservicesTestes


    Dim strEncryptPasswordAT As String, strEncryptCreatedAT As String, strEncryptNonceAT As String
    Dim MyPassCER As String = "158507687213"
    Dim CaminhoFileCER As String = "C:\Girl\SAFT-PT\Files\ChavePublicaAT.cer" 'AMBIENTE DE PRODUÇÃO 507687213.cer ???
    Dim NIF_ID As String = "507687213/1"
    Dim CaminhoPFX As String = "C:\Girl\SAFT-PT\Files\Teste WebServices.pfx" 'AMBIENTE DE PRODUÇÃO 507687213.pfx
    Dim MyPassPFX As String = "TESTEwebservice" 'AMBIENTE DE PRODUÇÃO 851507687213


    Private Sub EncryptAT(ByVal pPwdAT As String, ByVal pPathCertf As String)
        Try
            Dim CaminhoChavePublica As String = pPathCertf
            ' Variaveis a encriptar
            Dim PassFinancas As String = pPwdAT
            'Dim DataCriacao As String = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "Z"
            Dim DataCriacao As String = DateTime.UtcNow.ToString("s") & "Z"
            ' Carregar chave pública
            Dim certCP As New System.Security.Cryptography.X509Certificates.X509Certificate2
            certCP.Import(CaminhoChavePublica)
            Dim ChavePublica As String = certCP.PublicKey.Key.ToXmlString(False)
            ' Gerar Chave Simétrica para o envio da informação
            ' Esta chave tem que ser diferente em todos os envios, pelo que deverão arranjar um método de ser sempre diferente
            ' Comprimento: 16
            ' Exemplo
            'Dim ChaveSimetrica As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
            'Dim ChaveSimetrica() As Byte = GerarChaveSimetrica()
            Dim aleatorios As New Random()
            Dim ChaveSimetrica(15) As Byte
            aleatorios.NextBytes(ChaveSimetrica)
            ' Inserir Chave Simetrica nos parametros de encriptação
            Dim rijn As System.Security.Cryptography.SymmetricAlgorithm = System.Security.Cryptography.SymmetricAlgorithm.Create()
            rijn.Key = ChaveSimetrica
            rijn.IV = ChaveSimetrica
            rijn.Mode = System.Security.Cryptography.CipherMode.ECB
            rijn.Padding = System.Security.Cryptography.PaddingMode.PKCS7
            ' Encriptar password das financas
            Dim msPassFinancas As New System.IO.MemoryStream
            Dim csPassFinancas As New System.Security.Cryptography.CryptoStream(msPassFinancas, rijn.CreateEncryptor(rijn.Key, rijn.IV), System.Security.Cryptography.CryptoStreamMode.Write)
            Using swPassFinancas As New System.IO.StreamWriter(csPassFinancas)
                swPassFinancas.Write(PassFinancas)
            End Using
            ' Encriptar data de criação
            Dim msDataCriacao As New System.IO.MemoryStream
            Dim csDataCriacao As New System.Security.Cryptography.CryptoStream(msDataCriacao, rijn.CreateEncryptor(rijn.Key, rijn.IV), System.Security.Cryptography.CryptoStreamMode.Write)
            Using swDataCriacao As New System.IO.StreamWriter(csDataCriacao)
                swDataCriacao.Write(DataCriacao)
            End Using
            ' Converter de bytes para string
            Dim PassFinancasEncriptada As String = Convert.ToBase64String(msPassFinancas.ToArray())
            Dim DataCriacaoEncriptada As String = Convert.ToBase64String(msDataCriacao.ToArray())
            ' Encriptar a chave simetrica com o algoritmo RSA e com a chave pública
            Dim AlgRSA As New System.Security.Cryptography.RSACryptoServiceProvider
            AlgRSA.FromXmlString(ChavePublica)
            Dim Chave() As Byte = AlgRSA.Encrypt(ChaveSimetrica, False)
            Dim ChaveSimetricaEncriptada As String = Convert.ToBase64String(Chave)
            strEncryptPasswordAT = PassFinancasEncriptada
            strEncryptCreatedAT = DataCriacaoEncriptada
            strEncryptNonceAT = ChaveSimetricaEncriptada
        Catch ex As Exception
            strEncryptPasswordAT = ""
            strEncryptCreatedAT = ""
            strEncryptNonceAT = ""
        End Try
    End Sub

    Private Function GenerateSoapFile(ByVal pUserAT As String) As String
        Try
            Dim strSoap As String
            GenerateSoapFile = ""
            strSoap = ""
            strSoap = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:doc='https://servicos.portaldasfinancas.gov.pt/sgdtws/documentosTransporte/'>"
            strSoap = strSoap & "<soapenv:Header>"
            strSoap = strSoap & "<wss:Security xmlns:wss='http://schemas.xmlsoap.org/ws/2002/12/secext'>"
            strSoap = strSoap & "<wss:UsernameToken>"
            strSoap = strSoap & "<wss:Username>" + pUserAT + "</wss:Username>"
            strSoap = strSoap & "<wss:Password>" + strEncryptPasswordAT + "</wss:Password>"
            strSoap = strSoap & "<wss:Nonce>" + strEncryptNonceAT + "</wss:Nonce>"
            strSoap = strSoap & "<wss:Created>" + strEncryptCreatedAT + "</wss:Created>"
            strSoap = strSoap & "</wss:UsernameToken>"
            strSoap = strSoap & "</wss:Security>"
            strSoap = strSoap & "</soapenv:Header>"
            strSoap = strSoap & "<soapenv:Body>"
            strSoap = strSoap & "<doc:envioDocumentoTransporteRequestElem>"
            strSoap = strSoap & "<TaxRegistrationNumber>507687213</TaxRegistrationNumber>"
            strSoap = strSoap & "<CompanyName>Grande Enigma Comercio de Calçado, Lda</CompanyName>"
            strSoap = strSoap & "<CompanyAddress>"
            strSoap = strSoap & "<Addressdetail>Rua Almeida Garrett, 20</Addressdetail>"
            strSoap = strSoap & "<City>Vila Nova de Gaia</City>"
            strSoap = strSoap & "<PostalCode>4430-300</PostalCode>"
            strSoap = strSoap & "<Country>PT</Country>"
            strSoap = strSoap & "</CompanyAddress>"




            strSoap = strSoap & "<DocumentNumber>GT 13/30</DocumentNumber>"               'XXXXXXXXXXXXXXXXXXXXXXXXXXX ALTERAR NUMERO DA GUIA    XXXXXXXXXXXXXXXXXX
            'Uma de 3 opções: N-Normal, T-Por conta de terceiros, A-Anulada
            strSoap = strSoap & "<MovementStatus>N</MovementStatus>"
            strSoap = strSoap & "<MovementDate>" & Date.Now.ToString("yyyy-MM-dd") & "</MovementDate>"
            'Uma de 5 opções: GR-Guia de remessa,
            '                 GT-Guia de transporte,
            '                 GA-Guia de movimentação de ativos próprios,
            '                 GC-Guia de consignação,
            '                 GD-Guia ou nota de devolução afetuada pelo cliente.
            strSoap = strSoap & "<MovementType>GT</MovementType>"
            strSoap = strSoap & "<CustomerTaxID>507687213</CustomerTaxID>"
            'strSoap = strSoap & "<SupplierTaxID>?</SupplierTaxID>"
            strSoap = strSoap & "<CustomerAddress>"
            strSoap = strSoap & "<Addressdetail>Rua dele</Addressdetail>"
            strSoap = strSoap & "<City>Aveiro</City>"
            strSoap = strSoap & "<PostalCode>4430-300</PostalCode>"
            strSoap = strSoap & "<Country>PT</Country>"
            strSoap = strSoap & "</CustomerAddress>"
            strSoap = strSoap & "<CustomerName>Gajo qualquer</CustomerName>"
            strSoap = strSoap & "<AddressTo>"
            strSoap = strSoap & "<Addressdetail>Rua do Cliente</Addressdetail>"
            strSoap = strSoap & "<City>Aveiro</City>"
            strSoap = strSoap & "<PostalCode>4430-300</PostalCode>"
            strSoap = strSoap & "<Country>PT</Country>"
            strSoap = strSoap & "</AddressTo>"
            strSoap = strSoap & "<AddressFrom>"
            strSoap = strSoap & "<Addressdetail>Rua da Empresa</Addressdetail>"
            strSoap = strSoap & "<City>Aveiro</City>"
            strSoap = strSoap & "<PostalCode>4430-300</PostalCode>"
            strSoap = strSoap & "<Country>PT</Country>"
            strSoap = strSoap & "</AddressFrom>"
            'strSoap = strSoap & "<MovementEndTime>2013-04-11T13:00:00</MovementEndTime>"
            strSoap = strSoap & "<MovementStartTime>" & Date.Now.ToString("yyyy-MM-ddTHH:mm:ss") & "</MovementStartTime>"
            strSoap = strSoap & "<VehicleID>12-ZZ-34</VehicleID>"
            strSoap = strSoap & "<Line>"
            strSoap = strSoap & "<ProductDescription>Artigo de testes</ProductDescription>"
            strSoap = strSoap & "<Quantity>2</Quantity>"
            strSoap = strSoap & "<UnitOfMeasure>UN</UnitOfMeasure>"
            strSoap = strSoap & "<UnitPrice>1.00</UnitPrice>"
            strSoap = strSoap & "</Line>"
            strSoap = strSoap & "</doc:envioDocumentoTransporteRequestElem>"
            strSoap = strSoap & "</soapenv:Body>"
            strSoap = strSoap & "</soapenv:Envelope>"
            GenerateSoapFile = strSoap
        Catch ex As Exception
            GenerateSoapFile = ""
        End Try
    End Function

    Private Function GetATGTCode(ByVal pSoapFile As String, ByVal pWebService As String, ByVal pServiceAction As String, ByVal pCertifPath As String, ByVal pCertifPassword As String)
        Dim EnderecoWebService As String = pWebService
        Dim CaminhoCertificado As String = pCertifPath
        Dim SenhaCertificado As String = pCertifPassword
        Try
            Dim request As HttpWebRequest = CType(HttpWebRequest.Create(EnderecoWebService), HttpWebRequest)
            request.Headers.Add("SOAPAction", pServiceAction)
            Dim cert As New X509Certificate2
            cert.Import(CaminhoCertificado, SenhaCertificado, X509KeyStorageFlags.DefaultKeySet)
            request.ClientCertificates.Add(cert)
            request.Method = "POST"
            request.ContentType = "text/xml; charset=utf-8"
            request.Accept = "text/xml"
            Dim postData As String = pSoapFile
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            dataStream = response.GetResponseStream
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd
            reader.Close()
            dataStream.Close()
            response.Close()
            LerXml(responseFromServer)
            Return "OK|" & responseFromServer
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.ProtocolError Then
                Dim resp As WebResponse = ex.Response
                Dim sr As StreamReader = New StreamReader(resp.GetResponseStream())
                Return "NOK|" & sr.ReadToEnd
            Else
                Return "NOK|" & ex.Message
            End If
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        EncryptAT(MyPassCER, CaminhoFileCER)
        Dim soap As String = GenerateSoapFile(NIF_ID)
        txtResultado.Text = GetATGTCode(soap, "https://servicos.portaldasfinancas.gov.pt:701/sgdtws/documentosTransporte", "https://servicos.portaldasfinancas.gov.pt/sgdtws/documentosTransporte/", CaminhoPFX, MyPassPFX)
    End Sub

    Private Sub LerXml(ByVal txtxml As String)

        Try

            Dim sr As New System.IO.StringReader(txtxml)
            Dim doc As New Xml.XmlDocument
            doc.Load(sr)

            Dim sReturnCode As String = doc.ChildNodes(1).ChildNodes(1).ChildNodes(0).ChildNodes(0).ChildNodes(0).InnerText
            If sReturnCode <> 0 Then
                Dim sReturnMessage As String = doc.ChildNodes(1).ChildNodes(1).ChildNodes(0).ChildNodes(0).ChildNodes(1).InnerText
                MsgBox("ERRO: " & Chr(13) & sReturnMessage)
            Else
                Dim sDocumentNumber As String = doc.ChildNodes(1).ChildNodes(1).ChildNodes(0).ChildNodes(1).InnerText
                Dim sATDocCodID As String = doc.ChildNodes(1).ChildNodes(1).ChildNodes(0).ChildNodes(2).InnerText
                MsgBox("DocumentNumber " & sDocumentNumber & Chr(13) & "ATDocCodID " & sATDocCodID)
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "LerXml")
        End Try
    End Sub





End Class