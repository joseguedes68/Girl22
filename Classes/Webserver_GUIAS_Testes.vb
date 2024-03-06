'Imports System.Net
'Imports System.Security.Cryptography.X509Certificates
'Imports System.Text
'Imports System.IO
'Imports System.Security.Cryptography
'Imports <xmlns:wss="[url="http://schemas.xmlsoap.org/ws/2002/12/secext%22>"]http://schemas.xmlsoap.org/ws/2002/12/secext">[/url]


Public Class Webserver_GUIAS_Testes



    'Private Sub Webserver_GUIAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    '####################################################################
    '    '################# APAGA O FICHEIRO DA RESPOSTA SE EXISTIR  #########
    '    '####################################################################

    '    Try
    '        Kill("RespostaGT.xml")
    '    Catch ex As Exception
    '    End Try


    '    Dim NomedoFicheiroOriginal = "WebServerTRANSP.xml"

    '    '####################################################################
    '    '################# Abre o Ficheiro Sem Codificação  #################
    '    '####################################################################

    '    Dim xmlFile = Xdocument.Load(NomedoFicheiroOriginal)

    '    Dim FX As FileStream
    '    Dim ESCRstream As StreamWriter

    '    FX = New FileStream(NomedoFicheiroOriginal, FileMode.Append, FileAccess.Write)
    '    ESCRstream = New StreamWriter(FX)
    '    ESCRstream.BaseStream.Seek(0, SeekOrigin.End)

    '    Dim UserFinancas = xmlFile...<wss:Username>.Value '### USERNAME DO XML NÃO CODIFICADO ############
    '    Dim PassFinancas = xmlFile...<wss:Password>.Value '### PASSWORD DO XML NÃO CODIFICADO ############
    '    Dim PassFinancasEncriptada
    '    Dim DataCriacaoEncriptada
    '    Dim ChaveSimetricaEncriptada

    '    Dim CaminhoChavePublica = "ChavePublicaAT.cer"

    '    Dim certCP As New X509Certificate2()
    '    certCP.Import(CaminhoChavePublica)
    '    Dim publicKey As [String] = certCP.PublicKey.Key.ToXmlString(False)


    '    Dim DataCriacao As [String] = xmlFile...<wss:Created>.Value  '### DATA DO XML NÃO CODIFICADA #######
    '    'Dim DataCriacao As [String] = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.ff") & "Z"
    '    'Dim DataCriacao As [String] = DateTime.Now().ToString("yyyy-MM-ddTHH:mm:ss.ff") & "Z"

    '    ESCRstream.Close()
    '    FX.Close()

    '    Dim rijndaelCipher As New RijndaelManaged()
    '    rijndaelCipher.GenerateKey()
    '    rijndaelCipher.Mode = CipherMode.ECB
    '    rijndaelCipher.Padding = PaddingMode.PKCS7
    '    Dim simetrickey As String = rijndaelCipher.Key.ToString()
    '    Dim chaveSimetrica As [Byte]() = rijndaelCipher.Key
    '    Dim rijn As SymmetricAlgorithm = SymmetricAlgorithm.Create()
    '    rijn.Key = rijndaelCipher.IV
    '    rijn.IV = rijndaelCipher.IV
    '    rijn.Mode = CipherMode.ECB
    '    Dim msPassFinancas As New MemoryStream()
    '    Dim csPassFinancas As New CryptoStream(msPassFinancas, rijn.CreateEncryptor(rijn.Key, rijn.IV), CryptoStreamMode.Write)
    '    Using swPassFinancas As New StreamWriter(csPassFinancas)
    '        swPassFinancas.Write(PassFinancas)
    '    End Using
    '    Dim msDataCriacao As New MemoryStream()
    '    Dim csDataCriacao As New CryptoStream(msDataCriacao, rijn.CreateEncryptor(rijn.Key, rijn.IV), CryptoStreamMode.Write)
    '    Using swDataCriacao As New StreamWriter(csDataCriacao)
    '        swDataCriacao.Write(DataCriacao)
    '    End Using

    '    '####################################################################
    '    '################# Converter Password BASE64 ########################
    '    '####################################################################
    '    PassFinancasEncriptada = Convert.ToBase64String(msPassFinancas.ToArray())

    '    '####################################################################
    '    '################# Converter Data para BASE64 #######################
    '    '####################################################################
    '    DataCriacaoEncriptada = Convert.ToBase64String(msDataCriacao.ToArray())

    '    Dim AlgRSA As New RSACryptoServiceProvider()
    '    AlgRSA.FromXmlString(publicKey)
    '    Dim Chave As [Byte]() = AlgRSA.Encrypt(rijn.Key, False)

    '    '####################################################################
    '    '################# Converter NOCE ###################################
    '    '####################################################################
    '    ChaveSimetricaEncriptada = Convert.ToBase64String(Chave)

    '    '####################################################################
    '    '#######         ALTERA E GRAVA O NOVO XML JÁ CODIFICADO  ###############
    '    '####################################################################

    '    Dim xmlFile2 = Xdocument.Load(NomedoFicheiroOriginal)

    '    xmlFile2...<wss:Username>.Value = UserFinancas
    '    xmlFile2...<wss:Password>.Value = PassFinancasEncriptada
    '    xmlFile2...<wss:Created>.Value = DataCriacaoEncriptada
    '    xmlFile2...<wss:Nonce>.Value = ChaveSimetricaEncriptada

    '    xmlFile2.Save(NomedoFicheiroOriginal)


    '    '####################################################################
    '    '#######         ENVIAR FICHEIRO                                #########################
    '    '####################################################################

    '            Dim EnderecoWebService As String = "[url="https://servicos.portaldasfinancas.gov.pt:701/sgdtws/documentosTransporte"]https://servicos.portaldasfinancas.gov.pt:701/sgdtws/documentosTransporte"[/url]
    '    Dim CaminhoCertificado As String = "TestesWebservices.pfx"
    '    Dim SenhaCertificado As String = "TESTEwebservice"

    '    Dim doc As New System.Xml.XmlDocument
    '    doc.Load(NomedoFicheiroOriginal) 'CAMINHO DO ARQUIVO A ENVIAR

    '    Dim oRequest = doc.OuterXml

    '    Try

    '                    Dim request As HttpWebRequest = HttpWebRequest.Create("[url="https://servicos.portaldasfinancas.gov.pt:701/sgdtws/documentosTransporte"]https://servicos.portaldasfinancas.gov.pt:701/sgdtws/documentosTransporte"[/url])
    '                    request.Headers.Add("SOAPAction", "[url="https://servicos.portaldasfinancas.gov.pt:701/sgdtws/documentosTransporte/"]https://servicos.portaldasfinancas.gov.pt:701/sgdtws/documentosTransporte/"[/url])
    '        Dim cert As New X509Certificate2
    '        cert.Import(CaminhoCertificado, SenhaCertificado, X509KeyStorageFlags.DefaultKeySet)
    '        request.ClientCertificates.Add(cert)
    '        request.Method = "POST"
    '        request.ContentType = "text/xml; charset=utf-8"
    '        request.Accept = "text/xml"
    '        Dim postData As String = oRequest
    '        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
    '        request.ContentLength = byteArray.Length
    '        Dim dataStream As Stream = request.GetRequestStream()
    '        dataStream.Write(byteArray, 0, byteArray.Length)
    '        dataStream.Close()
    '        Dim response As HttpWebResponse = request.GetResponse()
    '        dataStream = response.GetResponseStream()
    '        Dim reader As New StreamReader(dataStream)
    '        Dim responseFromServer As String = reader.ReadToEnd()
    '        reader.Close()
    '        dataStream.Close()
    '        response.Close()



    '        '####################################################################
    '        '################# CRIA O FICHEIRO PARA SE LA GRAVAR AS LINHAS  ######
    '        '####################################################################

    '        'Apaga o ficheiro velho
    '        Try
    '            Kill("RespostaGT.xml")
    '        Catch ex As Exception

    '        End Try

    '        'Grava o da Resposta
    '        Dim FX1 As FileStream
    '        Dim ESCRstream1 As StreamWriter

    '        FX1 = New FileStream("RespostaGT.xml", FileMode.Append, FileAccess.Write)
    '        ESCRstream1 = New StreamWriter(FX1)
    '        ESCRstream1.BaseStream.Seek(0, SeekOrigin.End)


    '        ESCRstream1.WriteLine(responseFromServer)
    '        ESCRstream1.Close()
    '        FX1.Close()

    '        xmlFile = Xdocument.Load("RespostaGT.xml")

    '        If xmlFile...<ReturnCode>.Value = 0 Then
    '            MsgBox("Codigo.:  " + xmlFile...<ReturnCode>.Value + vbCrLf + "Mensagem.:  " + xmlFile...<ReturnMessage>.Value, MsgBoxStyle.Information, "Envio Documento via WEBSERVER")
    '        Else
    '            MsgBox("Codigo.:  " + xmlFile...<ReturnCode>.Value + vbCrLf + "Mensagem.:  " + xmlFile...<ReturnMessage>.Value, MsgBoxStyle.Critical, "Envio Documento via WEBSERVER")
    '        End If


    '        Return

    '    Catch ex As WebException
    '        If ex.Status = WebExceptionStatus.ProtocolError Then
    '            Dim resp As WebResponse = ex.Response
    '            Dim sr As StreamReader = New StreamReader(resp.GetResponseStream())

    '            MsgBox(sr.ReadToEnd())
    '            '  MsgBox("Codigo.:  " + xmlFile...<ReturnCode>.Value + vbCrLf + "Mensagem.:  " + xmlFile...<ReturnMessage>.Value, MsgBoxStyle.Critical, "Envio Documento via WEBSERVER")

    '        Else

    '            MsgBox(ex.Message)

    '        End If

    '    End Try

    'End Sub



End Class
