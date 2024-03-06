

Imports System.IO
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Xml
Imports System.Xml.Schema




Public Class clsWebServiceGTs


    Dim strEncryptPasswordAT As String, strEncryptCreatedAT As String, strEncryptNonceAT As String
    Dim MyPassCER As String = "158507687213"
    'Dim MyPassCER As String = "testes1234"

    Dim CaminhoFileCER As String
    Dim CaminhoPFX As String
    Dim MyPassPFX As String
    Dim pWebServiceAux As String
    Dim pServiceAction As String


    'Dim NIF_ID As String = "599999993/0037"
    Dim NIF_ID As String = "507687213/1"



    Public Function PedidoAT(ByVal sDocID As String, ByRef sNumAt As String) As Boolean

        Try


            CarregarVariaveis()

            EncryptAT(MyPassCER, CaminhoFileCER)
            Dim soap As String = GenerateSoapFile(NIF_ID, sDocID)

            'VALIDAR SOAP FILE
            'TODO: FAZER FUNÇÃO ValidarEsquema
            'ValidarEsquema(soap)
            If soap = "" Then
                EnviarEmail("Erro", "ERRO nº185 NO PEDIDO À AT NO ARMAZEM : " & xArmz)
                sNumAt = ""
                Return False
            End If

            'CarregarXML(soap)


            'AMBIENTE DE PRODUÇÃO e TESTES
            Dim stxtxml As String = GetATGTCode(soap, pWebServiceAux, "https://servicos.portaldasfinancas.gov.pt/sgdtws/documentosTransporte/", CaminhoPFX, MyPassPFX)

            'Dim stxtxml As String = GetATGTCode(soap, pWebServiceAux, pServiceAction, CaminhoPFX, MyPassPFX)



            'If Left(stxtxml, 3) = "NOK" Then
            '    'TODO: MELHORAR ESTE PROCESSO
            '    MsgBox("ERRO NO PEDIDO À AT")
            '    Exit Sub
            'End If

            Dim sr As New System.IO.StringReader(stxtxml)
            Dim doc As New Xml.XmlDocument
            doc.Load(sr)

            Dim sReturnCode As String = doc.ChildNodes(1).ChildNodes(1).ChildNodes(0).ChildNodes(0).ChildNodes(0).InnerText

            If sReturnCode = 0 Then bComunicaçãoAT = True
            If sReturnCode = -3 And bDesenvolvimento = True Then
                bComunicaçãoAT = True
                sNumAt = "Erro Modo Teste"
                Return True
            End If


            If sReturnCode <> 0 Then
                If sReturnCode = "-100" Then
                    '-100 - A data início de transporte é inferior à data atual, pelo que esta informação será considerada uma mera comunicação de dados à AT;
                    sNumAt = "COMUNICADO"
                Else
                    Dim sReturnMessage As String = doc.ChildNodes(1).ChildNodes(1).ChildNodes(0).ChildNodes(0).ChildNodes(1).InnerText
                    'MsgBox("ERRO: " & Chr(13) & sReturnMessage)
                    sNumAt = ""
                    EnviarEmail("Erro", "Erro Exp AT nº " & sReturnCode + " " + xArmz + " " + sReturnMessage & " " & sDocID.ToString)
                    Return False
                End If

            ElseIf sReturnCode = 0 Then

                Dim sDocumentNumber As String = doc.ChildNodes(1).ChildNodes(1).ChildNodes(0).ChildNodes(1).InnerText
                Dim sATDocCodID As String = doc.ChildNodes(1).ChildNodes(1).ChildNodes(0).ChildNodes(3).InnerText
                'MsgBox("DocumentNumber " & sDocumentNumber & Chr(13) & "ATDocCodID " & sATDocCodID)
                sNumAt = sATDocCodID

            End If

            Return True

        Catch ex As Exception
            'ErroVB(ex.Message, "ERRO NO PedidoAT")
            EnviarEmail("Erro", "ERRO NO PEDIDO À AT  " & xArmz)
            Return False

        End Try


    End Function

    Private Sub CarregarVariaveis()

        pServiceAction = "https://servicos.portaldasfinancas.gov.pt/sgdtws/documentosTransporte"

        If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Or xServidor = "192.168.1.65" Then
            'AMBIENTE DE PRODUÇÃO
            CaminhoFileCER = "C:\Girl\SAFT-PT\Files\ChavePublicaAT.cer"
            CaminhoPFX = "C:\Girl\SAFT-PT\Files\507687213.pfx"
            MyPassPFX = "851507687213"
            pWebServiceAux = "https://servicos.portaldasfinancas.gov.pt:401/sgdtws/documentosTransporte"

        Else
            'AMBIENTE DE TESTE
            CaminhoFileCER = "C:\Girl\SAFT-PT\Files\ChavePublicaAT.cer"
            CaminhoPFX = "C:\Girl\SAFT-PT\Files\TesteWebServices.pfx"
            MyPassPFX = "TESTEwebservice"
            pWebServiceAux = "https://servicos.portaldasfinancas.gov.pt:701/sgdtws/documentosTransporte"
        End If

    End Sub

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

    Private Function GenerateSoapFile(ByVal pUserAT As String, ByVal sDocID As String) As String
        Try


            Dim db As New ClsSqlBDados
            Dim dtGuiaAT As New DataTable
            Dim dtGuiaATDet As New DataTable

            Dim strSoap As String
            GenerateSoapFile = ""
            strSoap = ""
            strSoap = "<?xml version='1.0' encoding='UTF-8'?>"    'este encoding é o que está a versão actual
            'strSoap = "<?xml version='1.0'?>"
            'strSoap = "<?xml version='1.0' encoding='utf-8' standalone='no'?>"
            'strSoap = "<?xml version='1.0' encoding='iso-8859-1'?>"
            'strSoap = "<?xml version='1.0' encoding='WINDOWS-1252'?>"
            strSoap = strSoap & "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:doc='https://servicos.portaldasfinancas.gov.pt/sgdtws/documentosTransporte/'>"
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

            'Body


            Sql = "SELECT Empresas.EmpContrib, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpNumPolicia, Empresas.EmpLocalidade, Empresas.EmpCodPostal, DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr, DocCab.EstadoDoc, DocCab.DataDoc, Terceiros.TipoTerc TercTipo, Terceiros.NIF TercNIF, Terceiros.Morada TercMorada, Terceiros.Localidade TercLocalidade, Terceiros.CodPostal TercCodPostal, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.MovementStartTime, DocCab.ATDocCodeID, DocCab.IdDocCab, DocCab.ATCUD FROM DocCab INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab INNER JOIN Terceiros ON DocCab.TercID = Terceiros.TercID WHERE (DocCab.IdDocCab='" & sDocID & "')"
            db.GetData(Sql, dtGuiaAT)


            strSoap = strSoap & "<soapenv:Body>"
            strSoap = strSoap & "<doc:envioDocumentoTransporteRequestElem>"
            strSoap = strSoap & "<TaxRegistrationNumber>" & dtGuiaAT.Rows(0)("EmpContrib") & "</TaxRegistrationNumber>"
            strSoap = strSoap & "<CompanyName>" & dtGuiaAT.Rows(0)("EmpNome") & " " & dtGuiaAT.Rows(0)("EmpDesigna") & "</CompanyName>"
            strSoap = strSoap & "<CompanyAddress>"
            strSoap = strSoap & "<Addressdetail>" & dtGuiaAT.Rows(0)("EmpMorada") & ", " & dtGuiaAT.Rows(0)("EmpNumPolicia") & "</Addressdetail>"
            strSoap = strSoap & "<City>" & Trim(dtGuiaAT.Rows(0)("EmpLocalidade")) & "</City>"
            strSoap = strSoap & "<PostalCode>" & dtGuiaAT.Rows(0)("EmpCodPostal") & "</PostalCode>"
            strSoap = strSoap & "<Country>PT</Country>"
            strSoap = strSoap & "</CompanyAddress>"




            Dim sDocumentNumber As String = Trim(dtGuiaAT.Rows(0)("TipoDocID")) & " " & Microsoft.VisualBasic.Left(dtGuiaAT.Rows(0)("DocNr"), 2) & Microsoft.VisualBasic.Right(dtGuiaAT.Rows(0)("ArmazemID"), 2) & "/" & Microsoft.VisualBasic.Right(dtGuiaAT.Rows(0)("DocNr"), 5)

            'dtGuiaAT.Rows(0)

            strSoap = strSoap & "<DocumentNumber>" & sDocumentNumber & "</DocumentNumber>"
            strSoap = strSoap & "<ATCUD>" & dtGuiaAT.Rows(0)("ATCUD") & "</ATCUD>"
            'Uma de 3 opções: N-Normal, T-Por conta de terceiros, A-Anulada
            strSoap = strSoap & "<MovementStatus>N</MovementStatus>"
            strSoap = strSoap & "<MovementDate>" & Format(dtGuiaAT.Rows(0)("DataDoc"), "yyyy-MM-dd") & "</MovementDate>"
            'Uma de 5 opções: GR-Guia de remessa,
            '                 GT-Guia de transporte,
            '                 GA-Guia de movimentação de ativos próprios,
            '                 GC-Guia de consignação,
            '                 GD-Guia ou nota de devolução afetuada pelo cliente.
            strSoap = strSoap & "<MovementType>" & dtGuiaAT.Rows(0)("TipoDocID") & "</MovementType>"



            'TODO: PASSAR DADOS DO TERCEIRO DE OUTRA FORMA!! OU SEJA NA TABELA TERCEIROS NÃO DEVEM CONSTAR OS ARMAZENS
            'A INFORMAÇÃO DOS ARMAZENS DEVE VIR DA TABELA ARMAZENS




            Dim sTercTipo As String = Trim(dtGuiaAT.Rows(0)("TercTipo"))

            Select Case sTercTipo
                Case "I"
                    strSoap = strSoap & "<CustomerTaxID>" & dtGuiaAT.Rows(0)("TercNIF") & "</CustomerTaxID>"
                Case "C"
                    strSoap = strSoap & "<CustomerTaxID>" & dtGuiaAT.Rows(0)("TercNIF") & "</CustomerTaxID>"
                Case "F"
                    strSoap = strSoap & "<SupplierTaxID>" & dtGuiaAT.Rows(0)("TercNIF") & "</SupplierTaxID>"
            End Select

            If sTercTipo = "I" Then

                'strSoap = strSoap & "<CustomerName>Gajo qualquer</CustomerName>"
                strSoap = strSoap & "<CustomerAddress>"
                strSoap = strSoap & "<Addressdetail>" & dtGuiaAT.Rows(0)("EmpMorada") & ", " & dtGuiaAT.Rows(0)("EmpNumPolicia") & "</Addressdetail>"
                strSoap = strSoap & "<City>" & Trim(dtGuiaAT.Rows(0)("EmpLocalidade")) & "</City>"
                strSoap = strSoap & "<PostalCode>" & dtGuiaAT.Rows(0)("EmpCodPostal") & "</PostalCode>"
                strSoap = strSoap & "<Country>PT</Country>"
                strSoap = strSoap & "</CustomerAddress>"

            Else

                'strSoap = strSoap & "<CustomerName>Gajo qualquer</CustomerName>"
                strSoap = strSoap & "<CustomerAddress>"
                strSoap = strSoap & "<Addressdetail>" & dtGuiaAT.Rows(0)("TercMorada") & "</Addressdetail>"
                strSoap = strSoap & "<City>" & Trim(dtGuiaAT.Rows(0)("TercLocalidade")) & "</City>"
                strSoap = strSoap & "<PostalCode>" & dtGuiaAT.Rows(0)("TercCodPostal") & "</PostalCode>"
                strSoap = strSoap & "<Country>PT</Country>"
                strSoap = strSoap & "</CustomerAddress>"


            End If

            strSoap = strSoap & "<AddressTo>"
            strSoap = strSoap & "<Addressdetail>" & dtGuiaAT.Rows(0)("AddressDetailDescarga") & "</Addressdetail>"
            strSoap = strSoap & "<City>" & dtGuiaAT.Rows(0)("CityDescarga") & "</City>"
            strSoap = strSoap & "<PostalCode>" & dtGuiaAT.Rows(0)("PostalCodeDescarga") & "</PostalCode>"
            strSoap = strSoap & "<Country>PT</Country>"
            strSoap = strSoap & "</AddressTo>"
            strSoap = strSoap & "<AddressFrom>"
            strSoap = strSoap & "<Addressdetail>" & dtGuiaAT.Rows(0)("AddressDetailCarga") & "</Addressdetail>"
            strSoap = strSoap & "<City>" & dtGuiaAT.Rows(0)("CityCarga") & "</City>"
            strSoap = strSoap & "<PostalCode>" & dtGuiaAT.Rows(0)("PostalCodeCarga") & "</PostalCode>"
            strSoap = strSoap & "<Country>PT</Country>"
            strSoap = strSoap & "</AddressFrom>"
            'strSoap = strSoap & "<MovementEndTime>2013-04-11T13:00:00</MovementEndTime>"
            strSoap = strSoap & "<MovementStartTime>" & Format(dtGuiaAT.Rows(0)("MovementStartTime"), "yyyy-MM-ddTHH:mm:ss") & "</MovementStartTime>"
            'strSoap = strSoap & "<VehicleID>12-ZZ-34</VehicleID>"
            '

            Sql = "SELECT DocCab.IdDocCab, DocDet.Descricao, DocDet.Qtd, DocDet.Unidade FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab WHERE (DocCab.IdDocCab='" & sDocID & "')"
            db.GetData(Sql, dtGuiaATDet)

            For Each r As DataRow In dtGuiaATDet.Rows

                strSoap = strSoap & "<Line>"
                strSoap = strSoap & "<ProductDescription>" & r("Descricao") & "</ProductDescription>"
                strSoap = strSoap & "<Quantity>" & r("Qtd") & "</Quantity>"
                strSoap = strSoap & "<UnitOfMeasure>" & r("Unidade") & "</UnitOfMeasure>"
                strSoap = strSoap & "<UnitPrice>0.00</UnitPrice>"
                strSoap = strSoap & "</Line>"

            Next
            strSoap = strSoap & "</doc:envioDocumentoTransporteRequestElem>"
            strSoap = strSoap & "</soapenv:Body>"
            strSoap = strSoap & "</soapenv:Envelope>"
            GenerateSoapFile = strSoap


            'Dim docxml As New XmlDocument
            'docxml.LoadXml(strSoap)

            'Dim writer As XmlTextWriter = New XmlTextWriter("C:\BackUpGTAT.xml", Nothing)
            'writer.Formatting = Formatting.Indented
            'docxml.Save(writer)

            'Dim doc As XDocument = XDocument.Parse(Str)
            'Console.WriteLine(doc)

        Catch ex As Exception
            ErroVB(ex.Message, "GenerateSoapFile")
            GenerateSoapFile = ""
        End Try


    End Function

    Private Function GetATGTCode(ByVal pSoapFile As String, ByVal pWebService As String, ByVal pServiceAction As String, ByVal pCertifPath As String, ByVal pCertifPassword As String) As String
        Dim EnderecoWebService As String = pWebService
        Dim CaminhoCertificado As String = pCertifPath
        Dim SenhaCertificado As String = pCertifPassword
        Try

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12



            Dim request As HttpWebRequest = CType(HttpWebRequest.Create(EnderecoWebService), HttpWebRequest)
            request.Headers.Add("SOAPAction", pServiceAction)
            Dim cert As New X509Certificate2
            cert.Import(CaminhoCertificado, SenhaCertificado, X509KeyStorageFlags.DefaultKeySet)
            request.ClientCertificates.Add(cert)
            request.Method = "POST"
            request.ContentType = "text/xml; charset=utf-8"
            'request.ContentType = "text/xml; charset=iso-8859-1"
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
            Return responseFromServer



        Catch ex As WebException
            MsgBox(ex.Message)
            If ex.Status = WebExceptionStatus.ProtocolError Then
                Dim resp As WebResponse = ex.Response
                Dim sr As StreamReader = New StreamReader(resp.GetResponseStream())
                Return "NOK|" & sr.ReadToEnd
            Else
                Return "NOK|" & ex.Message
            End If

        Catch ex1 As Exception
            EnviarEmail("Erro", "ERRO nº185343 NO PEDIDO À AT NO ARMAZEM : " & xArmz)
            MsgBox(ex1.Message)
        End Try


    End Function




    'PENSO QUE NÃO ESTÁ A SER USADO
    Private Sub ValidarEsquema(ByVal sSoap As String)


        Try



            Dim myDocument As New XmlDocument
            myDocument.Load("C:\Girl\SAFT-PT\Files\Documento.xml")
            'myDocument.Schemas.Add("namespace here or empty string", "C:\someschema.xsd")
            myDocument.Schemas.Add("http://www.w3.org/2001/XMLSchema", "C:\Girl\SAFT-PT\Files\DocumentosTransporte.xsd")
            Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)
            myDocument.Validate(eventHandler)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)
        Select Case e.Severity
            Case XmlSeverityType.Error
                Debug.WriteLine("Error: {0}", e.Message)
            Case XmlSeverityType.Warning
                Debug.WriteLine("Warning {0}", e.Message)
        End Select
    End Sub






End Class
