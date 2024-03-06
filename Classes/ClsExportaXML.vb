


Imports System.Xml



Public Class ClsExportaXML


    Public Sub Exporta(ByRef valor As String)


        ''ALTERAR CAMINHO E NOME DO FICHEIRO

        'Dim writer As New XmlTextWriter("C:\Girl\123.xml", System.Text.Encoding.Default)

        ''INICIA O DOCUMENTO XML
        'writer.WriteStartDocument()


        ''DEFINE A INDENTAÇÃO DO ARQUIVO
        'writer.Formatting = Formatting.Indented

        'writer.WriteStartElement("Auxiliar")
        'writer.WriteAttributeString("valor", valor)

        'writer.WriteEndElement() 'AuditFile


        Dim fluxoTexto As IO.StreamWriter

        If IO.File.Exists("C:\Girl\123.txt") Then
            fluxoTexto = New IO.StreamWriter("C:\Girl\123.txt", True)
            fluxoTexto.WriteLine(valor)
            fluxoTexto.Close()
        Else
            MessageBox.Show("Arquivo não existe")
        End If





    End Sub

    Public Function exportadocs(ByRef xdoc As String) As Boolean



        Dim db As New ClsSqlBDados
        Dim dtSaftHeader As New DataTable
        Dim dtSaftCustomer As New DataTable
        Dim dtSaftSupplier As New DataTable
        Dim dtSaftProduct As New DataTable
        Dim dtSaftTaxTable As New DataTable
        Dim dtSaftInvoice As New DataTable
        Dim dtSaftInvoiceLinha As New DataTable
        Dim dtSaftGuia As New DataTable
        Dim dtSaftGuiaLinha As New DataTable



        Dim AUXIVA As Double = 0
        Dim AUXTOTLIQ As Double = 0
        Dim AUXTOTLIQ_CREDITO As Double = 0
        Dim AUXTOTLIQ_DEBITO As Double = 0
        Dim QtdDocs As Int32 = 0
        Dim AUXTOTBRUTO As Double = 0
        Dim sMarca As String = "CELFERI" 'TODO: Ir buscar à tabela Empresa


        Try

            AUXIVA = 0
            AUXTOTLIQ = 0
            AUXTOTLIQ_CREDITO = 0
            AUXTOTLIQ_DEBITO = 0
            QtdDocs = 0
            AUXTOTBRUTO = 0

            Dim dpDeData As Date = Now
            Dim dpAteData As Date = dpDeData


            Sql = "SELECT  EmpNome + ' ' + EmpDesigna sCompanyName , EmpContrib, EmpNrRegisto, EmpMorada + ' nº' + EmpNumPolicia sAddressDetail, EmpCodPostal, EmpLocalidade, EmpTelefone, EmpFax FROM Empresas WHERE EmpresaID = '" & xEmp & "'"
            db.GetData(Sql, dtSaftHeader)


            Dim writer As New XmlTextWriter("C:\Girl\Docs\" & xdoc & ".xml", System.Text.Encoding.Default)


            'INICIA O DOCUMENTO XML
            writer.WriteStartDocument()


            'DEFINE A INDENTAÇÃO DO ARQUIVO
            writer.Formatting = Formatting.Indented

            'AuditFile NIVEL 1 
            writer.WriteStartElement("AuditFile")
            writer.WriteAttributeString("xmlns", "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")


            'CARREGAR DADOS E VARIÁVEIS HEADER

            Dim sAuditFileVersion As String = "1.04_01" 'TEXTO 10
            Dim sCompanyID As String = "VNGAIA 509634060" 'TEXTO 50
            Dim iTaxRegistrationNumber As Int32 = dtSaftHeader.Rows(0)("EmpContrib") 'INTEIRO 9
            Dim sTaxAccountingBasis As String = "F" 'TEXTO 1
            Dim sCompanyName As String = dtSaftHeader.Rows(0)("sCompanyName") 'TEXTO 100 
            Dim sAddressDetail As String = dtSaftHeader.Rows(0)("sAddressDetail") 'TEXTO 100
            Dim sCity As String = Trim(dtSaftHeader.Rows(0)("EmpLocalidade")) 'TEXTO 50
            Dim sPostalCode As String = dtSaftHeader.Rows(0)("EmpCodPostal") 'TEXTO 8
            Dim sCountry As String = "PT" 'TEXTO 2
            Dim iFiscalYear As Int16 = Year(dpDeData) 'INTEIRO 4
            Dim dStartDate As String = dpDeData.ToString("yyyy-MM-dd")
            Dim dEndDate As String = dpAteData.ToString("yyyy-MM-dd")
            Dim sCurrencyCode As String = "EUR" 'TEXTO 3
            Dim dDateCreated As String = Now().ToString("yyyy-MM-dd")
            Dim sTaxEntity As String = "Global" 'TEXTO 20
            Dim sProductCompanyTaxID As String = "507687213" 'TEXTO 20  NIF DA ENTIDADE PRODUTORA SOFTWARE
            Dim sSoftwareCertificateNumber As String = "0" 'TEXTO 20
            Dim sProductID As String = "CELFERI/Grande Enigma" 'TEXTO 255
            Dim sProductVersion As String = "1.0" 'TEXTO 30
            Dim sEmpTelefone As String = dtSaftHeader.Rows(0)("EmpTelefone") 'TEXTO 20
            Dim sEmpFax As String = dtSaftHeader.Rows(0)("EmpFax") 'TEXTO 20


            '   Header NIVEL 2 
            writer.WriteStartElement("Header")
            writer.WriteElementString("AuditFileVersion", sAuditFileVersion)
            writer.WriteElementString("CompanyID", sCompanyID)
            writer.WriteElementString("TaxRegistrationNumber", iTaxRegistrationNumber)
            writer.WriteElementString("TaxAccountingBasis", sTaxAccountingBasis)
            writer.WriteElementString("CompanyName", sCompanyName)

            writer.WriteStartElement("CompanyAddress")
            writer.WriteElementString("AddressDetail", sAddressDetail)
            writer.WriteElementString("City", sCity)
            writer.WriteElementString("PostalCode", sPostalCode)
            writer.WriteElementString("Country", sCountry)
            writer.WriteEndElement()  'CompanyAddress

            writer.WriteElementString("FiscalYear", iFiscalYear)
            writer.WriteElementString("StartDate", dStartDate)
            writer.WriteElementString("EndDate", dEndDate)
            writer.WriteElementString("CurrencyCode", sCurrencyCode)
            writer.WriteElementString("DateCreated", dDateCreated)
            writer.WriteElementString("TaxEntity", sTaxEntity)
            writer.WriteElementString("ProductCompanyTaxID", sProductCompanyTaxID)
            writer.WriteElementString("SoftwareCertificateNumber", sSoftwareCertificateNumber)
            writer.WriteElementString("ProductID", sProductID)
            writer.WriteElementString("ProductVersion", sProductVersion)
            writer.WriteElementString("Telephone", sEmpTelefone)
            writer.WriteElementString("Fax", sEmpFax)

            writer.WriteEndElement() 'Header

            '   MasterFiles NIVEL 2 
            writer.WriteStartElement("MasterFiles")


            Sql = "SELECT RTRIM(LTRIM(TERCEIROS.TerceiroID)) AS TerceiroID, TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID FROM (SELECT 'T' + TercID AS TerceiroID, TipoTerc, Nome, Morada, CodPostal, Localidade, NIF, PaisID, DistritoID, TercID FROM Terceiros AS Terceiros_1 UNION SELECT STR(ClienteLojaID) AS TerceiroID, 'L' AS TipoTerc, Nome, Morada, Localidade, CodPostal, NIF, PaisID, DistritoID, ClienteLojaID AS TercID FROM ClientesLoja) AS TERCEIROS INNER JOIN DocCab ON TERCEIROS.TercID = DocCab.TercID WHERE (DocCab.IdDocCab = '" & xdoc & "') GROUP BY RTRIM(LTRIM(TERCEIROS.TerceiroID)), TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID HAVING (TERCEIROS.TipoTerc <> 'F')"
            db.GetData(Sql, dtSaftCustomer, False)

            Dim sCustomerID As String = "1"
            Dim sAccountID As String = "Desconhecido"
            Dim sCustomerTaxID As String = "999999990"
            Dim sCompanyNameCli As String = "Consumidor final"
            Dim sAddressDetailCli As String = "Desconhecido"
            Dim sCityCli As String = "Desconhecido"
            Dim sPostalCodeCli As String = "Desconhecido"
            Dim sCountryCli As String = "Desconhecido"
            Dim iSelfBillingIndicatorCli As Int16 = 0


            For Each lCustomer As DataRow In dtSaftCustomer.Rows

                If lCustomer("TerceiroID") = "0" Then sCustomerID = "0000" Else sCustomerID = lCustomer("TerceiroID").ToString
                sAccountID = "Desconhecido"
                sCustomerTaxID = IIf(Trim(lCustomer("NIF")) = "" Or Trim(lCustomer("NIF")) = "xxxxxxxxx", "999999990", lCustomer("NIF"))
                sCompanyNameCli = IIf(Trim(lCustomer("Nome")) = "", "Desconhecido", lCustomer("Nome"))
                sAddressDetailCli = IIf(Trim(lCustomer("Morada")) = "", "Desconhecido", lCustomer("Morada"))
                sCityCli = IIf(Trim(lCustomer("Localidade")) = "", "Desconhecido", lCustomer("Localidade"))
                sPostalCodeCli = IIf(Trim(lCustomer("CodPostal")) = "", "Desconhecido", lCustomer("CodPostal"))
                sCountryCli = IIf(Trim(lCustomer("PaisId")) = "", "Desconhecido", lCustomer("PaisId"))
                iSelfBillingIndicatorCli = 0

                '    Customer NIVEL 3 
                writer.WriteStartElement("Customer")
                writer.WriteElementString("CustomerID", sCustomerID)
                writer.WriteElementString("AccountID", sAccountID)
                writer.WriteElementString("CustomerTaxID", sCustomerTaxID)
                writer.WriteElementString("CompanyName", sCompanyNameCli)
                writer.WriteStartElement("BillingAddress")
                writer.WriteElementString("AddressDetail", sAddressDetailCli)
                writer.WriteElementString("City", sCityCli)
                writer.WriteElementString("PostalCode", sPostalCodeCli)
                writer.WriteElementString("Country", sCountryCli)
                writer.WriteEndElement() 'BillingAddress
                writer.WriteElementString("SelfBillingIndicator", iSelfBillingIndicatorCli)
                writer.WriteEndElement() 'Customer

            Next



            'FORNECEDOR
            Sql = "SELECT RTRIM(LTRIM(TERCEIROS.TerceiroID)) AS TerceiroID, TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID FROM (SELECT 'T' + TercID AS TerceiroID, TipoTerc, Nome, Morada, CodPostal, Localidade, NIF, PaisID, DistritoID, TercID FROM Terceiros AS Terceiros_1 UNION SELECT STR(ClienteLojaID) AS TerceiroID, 'L' AS TipoTerc, Nome, Morada, Localidade, CodPostal, NIF, PaisID, DistritoID, ClienteLojaID AS TercID FROM ClientesLoja) AS TERCEIROS INNER JOIN DocCab ON TERCEIROS.TercID = DocCab.TercID WHERE (DocCab.IdDocCab = '" & xdoc & "') GROUP BY RTRIM(LTRIM(TERCEIROS.TerceiroID)), TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID HAVING (TERCEIROS.TipoTerc = 'F')"
            db.GetData(Sql, dtSaftSupplier, False)


            Dim sSupplierID As String = "1"
            Dim sAccountIDSup As String = "Desconhecido"
            Dim sSupplierTaxID As String = "999999990"
            Dim sCompanyNameSup As String = "Consumidor final"
            Dim sAddressDetailSup As String = "Desconhecido"
            Dim sCitySup As String = "Desconhecido"
            Dim sPostalCodeSup As String = "Desconhecido"
            Dim sCountrySup As String = "Desconhecido"
            Dim iSelfBillingIndicatorSup As Int16 = 0


            For Each lSupplier As DataRow In dtSaftSupplier.Rows

                If lSupplier("TerceiroID") = "0" Then sSupplierID = "0000" Else sSupplierID = lSupplier("TerceiroID").ToString
                sAccountIDSup = "Desconhecido"
                sSupplierTaxID = IIf(Trim(lSupplier("NIF")) = "", "999999990", lSupplier("NIF"))
                sCompanyNameSup = IIf(Trim(lSupplier("Nome")) = "", "Desconhecido", lSupplier("Nome"))
                sAddressDetailSup = IIf(Trim(lSupplier("Morada")) = "", "Desconhecido", lSupplier("Morada"))
                sCitySup = IIf(Trim(lSupplier("Localidade")) = "", "Desconhecido", lSupplier("Localidade"))
                sPostalCodeSup = IIf(Trim(lSupplier("CodPostal")) = "", "Desconhecido", lSupplier("CodPostal"))
                sCountrySup = IIf(Trim(lSupplier("PaisId")) = "", "", lSupplier("PaisId"))
                iSelfBillingIndicatorSup = 0

                '    Supplier NIVEL 3 
                writer.WriteStartElement("Supplier")
                writer.WriteElementString("SupplierID", sSupplierID)
                writer.WriteElementString("AccountID", sAccountIDSup)
                writer.WriteElementString("SupplierTaxID", sSupplierTaxID)
                writer.WriteElementString("CompanyName", sCompanyNameSup)
                writer.WriteStartElement("BillingAddress")
                writer.WriteElementString("AddressDetail", sAddressDetailSup)
                writer.WriteElementString("City", sCitySup)
                writer.WriteElementString("PostalCode", sPostalCodeSup)
                writer.WriteElementString("Country", sCountrySup)
                writer.WriteEndElement() 'BillingAddress
                writer.WriteElementString("SelfBillingIndicator", iSelfBillingIndicatorSup)
                writer.WriteEndElement() 'Supplier

            Next

            'Sql = "SELECT DocDet.ProductCode AS Artigo, RTRIM(Product.ProductDescription) AS ArtigoDescr, Product.ProductType FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID INNER JOIN Product ON DocDet.ProductCode = Product.ProductCode WHERE (DocCab.IdDocCab = '" & xdoc & "') GROUP BY DocDet.ProductCode, RTRIM(Product.ProductDescription), Product.ProductType ORDER BY Artigo"
            Sql = "SELECT DocDet.ProductCode AS Artigo, RTRIM(Product.ProductDescription) AS ArtigoDescr, Product.ProductType
                    FROM     DocCab INNER JOIN
                    DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN
                    Product ON DocDet.ProductCode = Product.ProductCode
                    WHERE  (DocCab.IdDocCab = '" & xdoc & "')
                    GROUP BY DocDet.ProductCode, RTRIM(Product.ProductDescription), Product.ProductType
                    ORDER BY Artigo"

            db.GetData(Sql, dtSaftProduct)


            Dim sProductType As String = "P"   '"S" PARA SERVIÇO
            Dim sProductCode As String = "11"
            Dim sProductDescription As String = "Sapato de Criança"
            Dim sProductNumberCode As String = "11"

            For Each lProduct As DataRow In dtSaftProduct.Rows

                sProductType = Trim(lProduct("ProductType"))
                sProductCode = Trim(lProduct("Artigo"))
                sProductDescription = Trim(lProduct("ArtigoDescr"))
                sProductNumberCode = Trim(lProduct("Artigo"))

                writer.WriteStartElement("Product")
                writer.WriteElementString("ProductType", sProductType)
                writer.WriteElementString("ProductCode", sProductCode)
                writer.WriteElementString("ProductDescription", sProductDescription)
                writer.WriteElementString("ProductNumberCode", sProductNumberCode)
                writer.WriteEndElement() 'Product


            Next







            'TODO: **********  PASSAR A DINÂMICO    ***********
            '       TAXTABLE NIVEL 3 
            writer.WriteStartElement("TaxTable")
            writer.WriteStartElement("TaxTableEntry")
            writer.WriteElementString("TaxType", "IVA")
            writer.WriteElementString("TaxCountryRegion", "PT-MA")
            writer.WriteElementString("TaxCode", "NOR")
            writer.WriteElementString("Description", "IVA taxa Normal")
            writer.WriteElementString("TaxPercentage", "22.00")
            writer.WriteEndElement() 'TaxTableEntry (1)
            writer.WriteStartElement("TaxTableEntry")
            writer.WriteElementString("TaxType", "IVA")
            writer.WriteElementString("TaxCountryRegion", "PT")
            writer.WriteElementString("TaxCode", "NOR")
            writer.WriteElementString("Description", "IVA taxa Normal")
            writer.WriteElementString("TaxPercentage", "23.00")
            writer.WriteEndElement() 'TaxTableEntry (2)
            writer.WriteEndElement() 'TaxTable

            writer.WriteEndElement() 'MasterFiles


            'CARREGAR DADOS E VARIÁVEIS SalesInvoices

            '   SourceDocuments NIVEL 2
            writer.WriteStartElement("SourceDocuments")


            Dim iNumberOfEntries As Int32 = 1

            Sql = "SELECT ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),0) AS TotalDebit FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE DocCab.IdDocCab = '" & xdoc & "' AND DocCab.EstadoDoc<>'A' AND DocCab.TipoDocID = 'NC'"
            Dim dTotalDebit As Double = Arredondamento(db.GetDataValue(Sql), 2)

            Sql = "SELECT ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),0) AS TotalCredit FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE DocCab.IdDocCab = '" & xdoc & "' AND DocCab.EstadoDoc<>'A' AND DocCab.TipoDocID IN ('FS','FT','ND')"
            Dim dTotalCredit As Double = Arredondamento(db.GetDataValue(Sql), 2)


            writer.WriteStartElement("SalesInvoices")
            writer.WriteElementString("NumberOfEntries", iNumberOfEntries)
            writer.WriteElementString("TotalDebit", dTotalDebit)
            writer.WriteElementString("TotalCredit", dTotalCredit)


            Dim sInvoiceNo As String = ""
            Dim sATCUD As String = "0"
            Dim sInvoiceStatus As String
            Dim dInvoiceStatusDate As String
            'Dim dInvoiceStatusDateAux As Date
            Dim sHash As String
            Dim sHashControl As String = "0"
            Dim dInvoiceDate As String
            'Dim dInvoiceDateAux As Date
            Dim sInvoiceType As String
            Dim iSelfBillingIndicator As Int16
            Dim iCashVATSchemeIndicator As Int16
            Dim iThirdPartiesBillingIndicator As Int16
            Dim sDocAlteraSourceID As String
            Dim sDocCriaSourceID As String



            Dim dSystemEntryDate As String
            'Dim dSystemEntryDateAux As Date
            Dim sCustomerIDInv As String = ""

            'TOTAIS DO DOCUMENTO
            Dim dTaxPayable As Double = 0
            Dim dNetTotal As Double = 0
            Dim dGrossTotal As Double = 0
            'Dim sCurrencyCode1 As String = ""
            Dim dCurrencyAmount As Double = 0


            'VARIAVEIS DE LINHA
            Dim sArmazemID As String = ""
            Dim iLineNumber As Int32 = 1
            Dim sDocOrig As String
            Dim dOrderDate As String
            Dim sProductCodeLinha As String = "11"
            Dim sProductDescriptionLinha As String = "Sapato de Criança"
            Dim dQuantity As Double = 99
            Dim sUnitOfMeasure As String = "Par"
            Dim dUnitPrice As Double = 19.9
            Dim sTaxPointDate As String = "2013-01-01"   'DATA DO ENVIO DO PRODUTO OU DA PRESTAÇÃO DE SERVIÇO
            Dim sDescription As String = "Sapato de Criança"
            'Dim dDebitAmount As Double = 19.9
            'Dim dCreditAmount As Double = 0
            Dim dAmount As Double = 0
            Dim sTaxType As String = "IVA"
            Dim sTaxCountryRegion As String = "PT"
            Dim sTaxCode As String = "NOR"
            Dim dTaxPercentage As Double = 23.0
            Dim dSettlementAmount As Double = 0

            Dim sPaymentMechanism As String = "NU"
            Dim dPaymentAmount As Double = 0
            Dim sPaymentDate As String


            Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev, Utilizadores.NomeUtilizador FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Utilizadores ON DocCab.UtilizadorID = Utilizadores.UtilizadorID LEFT OUTER JOIN FormaPagamento ON DocCab.FormaPagtoID = FormaPagamento.FormaPagtoID WHERE (DocCab.IdDocCab = '" & xdoc & "') GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev, Utilizadores.NomeUtilizador HAVING (DocCab.TipoDocID IN ('FT', 'FS', 'NC')) ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
            db.GetData(Sql, dtSaftInvoice)

            For Each r As DataRow In dtSaftInvoice.Rows



                sInvoiceNo = Trim(r("TipoDocID")) & " " & Microsoft.VisualBasic.Left(r("DocNr"), 2) & Microsoft.VisualBasic.Right(r("ArmazemID"), 2) & "/" & Microsoft.VisualBasic.Right(r("DocNr"), 5)
                'FORMATO DA sInvoiceNo "FS 1013/00001"

                'Dim aux As New ClsExportaXML
                'aux.Exporta(sInvoiceNo)



                If RTrim(LTrim(r("EstadoDoc"))) = "A" Then sInvoiceStatus = "A" Else sInvoiceStatus = "N" '  N-Normal   OU   A-ANULADA
                'dInvoiceStatusDateAux = r("DtUltAlt")
                'dInvoiceStatusDate = dInvoiceStatusDateAux.ToString("s")
                dInvoiceStatusDate = CDate(r("DtUltAlt")).ToString("s")
                sHash = r("Hash")
                sHashControl = r("ChavePrivadaVersao")
                'dInvoiceDateAux = r("DataDoc")
                'dInvoiceDate = Microsoft.VisualBasic.Left(dInvoiceDateAux.ToString("s"), 10)
                ''dInvoiceDate = CDate(r("DataDoc")).ToString("s")
                'dInvoiceDate = Microsoft.VisualBasic.Left(CDate(r("DataDoc")).ToString("s"), 10)
                dInvoiceDate = CDate(r("DataDoc")).ToString("yyyy-MM-dd")
                sInvoiceType = r("TipoDocID")

                iSelfBillingIndicator = 0
                iCashVATSchemeIndicator = 0
                iThirdPartiesBillingIndicator = 0
                sDocAlteraSourceID = Trim(r("NomeUtilizador")) 'A Aplicação não permite alterar documentos
                sDocCriaSourceID = Trim(r("NomeUtilizador"))



                'dSystemEntryDateAux = r("DataDoc")
                'dSystemEntryDate = dSystemEntryDateAux.ToString("s")
                dSystemEntryDate = CDate(r("DataDoc")).ToString("s")
                'dSystemEntryDate = "2013-01-11T10:04:27"


                'DOCUMENTO DE ORIGEM
                sDocOrig = r("DocOrig")

                Select Case sInvoiceType
                    Case "FS"
                        sCustomerIDInv = r("TercID")
                    Case "NC"
                        If r("ArmazemID") = "0000" Then
                            sCustomerIDInv = "T" + r("TercID")
                        Else
                            sCustomerIDInv = r("TercID")
                        End If

                    Case "FT"

                        If r("ArmazemID") = "0000" Then
                            sCustomerIDInv = "T" + r("TercID")
                        Else
                            sCustomerIDInv = r("TercID")
                        End If

                End Select


                'Now.Date.ToString("yyyy-MM-dd")
                'Me.DateTimePicker3.Value.ToString("yyyy-MM-dd")

                'ALTERAR PARA CDate(r("DataDoc")).ToString("s")

                writer.WriteStartElement("Invoice")
                writer.WriteElementString("InvoiceNo", sInvoiceNo)
                writer.WriteElementString("ATCUD", sATCUD)
                writer.WriteStartElement("DocumentStatus")
                writer.WriteElementString("InvoiceStatus", sInvoiceStatus)
                writer.WriteElementString("InvoiceStatusDate", dInvoiceStatusDate)
                writer.WriteElementString("SourceID", sDocAlteraSourceID)  '4.1.4.2.4 - UTILIZADOR RESPONSAVEL PELO ACTUAL ESTADO DO DOCUMENTO
                writer.WriteElementString("SourceBilling", "P") 'TODO: "M" SE PROVENIENTE E RECUPERAÇÃO MANUAL...
                writer.WriteEndElement() 'DocumentStatus

                writer.WriteElementString("Hash", sHash)
                writer.WriteElementString("HashControl", sHashControl)
                writer.WriteElementString("InvoiceDate", dInvoiceDate)
                writer.WriteElementString("InvoiceType", sInvoiceType)

                writer.WriteStartElement("SpecialRegimes")
                writer.WriteElementString("SelfBillingIndicator", iSelfBillingIndicator)
                writer.WriteElementString("CashVATSchemeIndicator", iCashVATSchemeIndicator)
                writer.WriteElementString("ThirdPartiesBillingIndicator", iThirdPartiesBillingIndicator)
                writer.WriteEndElement() 'SpecialRegimes

                writer.WriteElementString("SourceID", sDocCriaSourceID)  '4.1.4.9 - Utilizador que gerou o documento 
                writer.WriteElementString("SystemEntryDate", dSystemEntryDate)
                writer.WriteElementString("CustomerID", sCustomerIDInv)
                'writer.WriteStartElement("ShipTo")
                'writer.WriteEndElement() 'ShipTo
                'writer.WriteStartElement("ShipFrom")
                'writer.WriteEndElement() 'ShipFrom



                'CRIAR CICLO COM AS LINHAS DO DOCUMENTO

                dtSaftInvoiceLinha.Clear()
                Sql = "SELECT DocCab.IdDocCab, DocCab.ArmazemID, DocDet.DocLnNr, DocDet.ProductCode AS Artigo, Product.ProductDescription, DocDet.Qtd, DocDet.Unidade, DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA AS PrecoLiq, CONVERT(char(10), DocCab.DataDoc, 126) AS DataDoc, DocDet.Descricao, (DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd AS ValorLiq, TaxIVA.TxIVA * 100 AS TxIVA, DocDet.VlrDescLn / (1 + TaxIVA.TxIVA) * DocDet.Qtd AS TDescLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID INNER JOIN Product ON DocDet.ProductCode = Product.ProductCode WHERE (DocCab.IdDocCab = '" & xdoc & "') AND (DocCab.IdDocCab = '" & r("IdDocCab").ToString & "') ORDER BY DocDet.DocLnNr"
                db.GetData(Sql, dtSaftInvoiceLinha)




                For Each Linha As DataRow In dtSaftInvoiceLinha.Rows
                    If Linha("ValorLiq") > 0 Then
                        sArmazemID = Linha("ArmazemID")
                        iLineNumber = Linha("DocLnNr")
                        sProductCodeLinha = Linha("Artigo")
                        sProductDescriptionLinha = Trim(Linha("ProductDescription"))
                        dQuantity = Linha("Qtd")
                        sUnitOfMeasure = Linha("Unidade")
                        dUnitPrice = Arredondamento(Linha("PrecoLiq"), 2) 'PASSEI PARA DUAS CASAS DECIMAIS (ESTAVAM 4)
                        sTaxPointDate = Linha("DataDoc")
                        sDescription = Trim(Linha("Descricao"))
                        dAmount = Arredondamento(Linha("ValorLiq"), 2)
                        sTaxType = "IVA"
                        'TODO: HÁ ERROS NOS DOCS DA MADEIRA EM RELAÇÃO AO IVA - ESTUDAR O MOTIVO - INCOERENCIA NOS DADOS EXPORTADOS PARA O SAFT!!!!
                        'TXIVA = 0 ????   IVAID=5 NA C-10????
                        Select Case sArmazemID  'TODO: POR ESTA VARIAVEL DINÂMICA 
                            Case "0002", "0010"
                                sTaxCountryRegion = "PT-MA"
                            Case Else
                                sTaxCountryRegion = "PT"
                        End Select
                        sTaxCode = "NOR"
                        dTaxPercentage = Linha("TxIVA")
                        dSettlementAmount = Arredondamento(Linha("TDescLiq"), 2)

                        writer.WriteStartElement("Line")
                        writer.WriteElementString("LineNumber", iLineNumber)
                        writer.WriteElementString("ProductCode", sProductCodeLinha)
                        writer.WriteElementString("ProductDescription", sProductDescriptionLinha)
                        writer.WriteElementString("Quantity", dQuantity)
                        writer.WriteElementString("UnitOfMeasure", sUnitOfMeasure)
                        writer.WriteElementString("UnitPrice", dUnitPrice)
                        writer.WriteElementString("TaxPointDate", sTaxPointDate) 'ESTÁ COM A DATA DO DOCUMENTO. SE EXISTIR GUIA ASSOCIADA DEVE SER A DATA DA 1ª GUIA DAQUELA FATURA

                        If Len(sDocOrig) > 0 Then
                            Sql = "SELECT DataDoc from DocCab WHERE IdDocCab='" & r("IdDocCabOrig").ToString & "'"
                            dOrderDate = db.GetDataValue(Sql)
                            dOrderDate = CDate(dOrderDate).ToString("yyyy-MM-dd")
                            writer.WriteStartElement("References")
                            writer.WriteElementString("Reference", sDocOrig)
                            writer.WriteEndElement() 'References
                        End If

                        writer.WriteElementString("Description", sDescription)
                        Select Case sInvoiceType    'POSSO PASSAR A USAR O CAMPO MOVFIN DA TABELA TIPODOC
                            Case "NC"
                                writer.WriteElementString("DebitAmount", dAmount) '4.1.4.18.11
                                'AS LINHAS NEGATIVAS NAS FS ENTRA NO DebitAmount  
                            Case "FS", "FT", "ND"
                                writer.WriteElementString("CreditAmount", dAmount)
                        End Select
                        writer.WriteStartElement("Tax")
                        writer.WriteElementString("TaxType", sTaxType)
                        writer.WriteElementString("TaxCountryRegion", sTaxCountryRegion)
                        writer.WriteElementString("TaxCode", sTaxCode)
                        writer.WriteElementString("TaxPercentage", dTaxPercentage)
                        writer.WriteEndElement() 'Tax
                        writer.WriteElementString("SettlementAmount", dSettlementAmount)
                        writer.WriteEndElement() 'Line
                    End If
                Next

                dTaxPayable = Arredondamento(r("TotalIVA"), 2)
                dNetTotal = Arredondamento(r("TotalSIVA"), 2)
                dGrossTotal = Arredondamento(r("TotalCIVA"), 2)
                'sCurrencyCode1 = "EUR"
                dCurrencyAmount = Arredondamento(r("TotalCIVA"), 2)

                writer.WriteStartElement("DocumentTotals")
                writer.WriteElementString("TaxPayable", dTaxPayable)
                writer.WriteElementString("NetTotal", dNetTotal)
                writer.WriteElementString("GrossTotal", dGrossTotal)
                'writer.WriteStartElement("Currency")
                'writer.WriteElementString("CurrencyCode", sCurrencyCode1)
                ''writer.WriteElementString("CurrencyAmount", dCurrencyAmount)   'NOVA VERSÃO???   NA PAG 6735 DA PORTARIA 382/2012 ESTÁ ASSIM!!!!!
                'writer.WriteElementString("CurrencyAmount", dCurrencyAmount)
                ''writer.WriteElementString("CurrencyDebitAmount", dCurrencyAmount) NA VERSÃO DE 23-04-2013 VOLTOU A DAR ERRO
                'writer.WriteEndElement() 'Currency

                sPaymentMechanism = "NU"  'TODO: PASSAR A DINÂMICO  SÓ ESTÁ A PERMITIR UMA FORMA DE PAG./DOC
                If r("FPDescrAbrev") = "MB" Then sPaymentMechanism = "MB"
                dPaymentAmount = dGrossTotal
                sPaymentDate = dInvoiceDate

                writer.WriteStartElement("Payment")
                writer.WriteElementString("PaymentMechanism", sPaymentMechanism)
                writer.WriteElementString("PaymentAmount", dPaymentAmount)
                writer.WriteElementString("PaymentDate", sPaymentDate)
                writer.WriteEndElement() 'Payment


                writer.WriteEndElement() 'DocumentTotals
                writer.WriteEndElement() 'Invoice




                Select Case sInvoiceType    'TODO: POSSO PASSAR A USAR O CAMPO MOVFIN DA TABELA TIPODOC
                    Case "NC"
                        AUXIVA = AUXIVA - dTaxPayable
                        AUXTOTLIQ = AUXTOTLIQ - dNetTotal
                        AUXTOTLIQ_DEBITO = AUXTOTLIQ_DEBITO - dNetTotal
                        AUXTOTBRUTO = AUXTOTBRUTO - dGrossTotal
                    Case "FS", "FT", "ND"
                        AUXIVA = AUXIVA + dTaxPayable
                        AUXTOTLIQ = AUXTOTLIQ + dNetTotal
                        AUXTOTLIQ_CREDITO = AUXTOTLIQ_CREDITO + dNetTotal
                        AUXTOTBRUTO = AUXTOTBRUTO + dGrossTotal
                End Select

                QtdDocs = QtdDocs + 1

            Next

            writer.WriteEndElement() 'SalesInvoices

            'NO SAFT, AQUI ESTÃO AS GUIAS DE TRANSPORTE

            writer.WriteEndElement() 'SourceDocuments
            writer.WriteEndElement() 'AuditFile
            writer.Close()


            'NÃO VOU VALIDAR PORQUE à UMA INCOMPATIBILIDADE DO XSD COM VB-NET, NO COMANDO ValidationEventHandler
            'ValidarEsquema()

            ClearMemory()

            'If Not UploadFile("C:\Girl\Docs\" & xdoc & ".xml", "ftp://" & "137.74.207.187/docs/" & xdoc & ".xml", sUtilizadorTugaTechFTP, sPasswordTugaTechFTP) Then
            '    EnviarEmail("Erro na gravação da Cloud", "", "")
            'End If

            If Not UploadFile("C:\Girl\Docs\" & xdoc & ".xml", "ftp://" & "89.114.159.233/docs/" & xdoc & ".xml", "celferi", "2R>z9J4sPu*7PH:") Then
                EnviarEmail("Erro na gravação para a Cloud do doc: " & xdoc, "", "")
            End If

            'descarregarArquivoFTP("89.114.159.233", "celferi", "2R>z9J4sPu*7PH:", "/celferi/docs/eb327cee-538f-4e97-a11b-f70c1b405ed6.xml")





            Return True


        Catch ex As Exception
            MsgBox(ex.Message)
            Return True
        End Try









    End Function

End Class
