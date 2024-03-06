Imports System.Xml



Imports System.Xml.Schema



Public Class GerarSaftPT

    Dim AUXIVA As Double = 0
    Dim AUXTOTLIQ As Double = 0
    Dim AUXTOTBRUTO As Double = 0


    Private Sub GerarSaftPT_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        Dim dtAux As Date = Now
        Dim dtMes As Int16 = Month(Now) - 1
        If dtMes = 0 Then dtMes = 12
        Dim dtAno As Int16 = Year(Now)
        If dtMes = 12 Then dtAno = dtAno - 1
        Dim diasdomes As Int16 = System.DateTime.DaysInMonth(dtAno, dtMes)

        Me.Text = "GerarSaftPT"

        dpDeData.Value = Now.AddDays(-(Now.Day - 1) - diasdomes)
        'Dim dtTo As New DateTime(Now.Year, Now.Month, Now.Day)
        'dtTo = dtTo.AddMonths(1)
        'dtTo = dtTo.AddDays(-(dtTo.Day) - diasdomes)
        'dpAteData.Value = dtTo
        dpAteData.Value = Now.AddDays(-Now.Day)

    End Sub

    Private Sub btGeraSAFT_Click(sender As System.Object, e As System.EventArgs) Handles btGeraSAFT.Click

        Dim db As New ClsSqlBDados
        Dim dtSaftHeader As New DataTable
        Dim dtSaftCustomer As New DataTable
        Dim dtSaftProduct As New DataTable
        Dim dtSaftTaxTable As New DataTable
        Dim dtSaftInvoice As New DataTable
        Dim dtSaftInvoiceLinha As New DataTable
        Dim dtSaftGuia As New DataTable
        Dim dtSaftGuiaLinha As New DataTable


        Try

            Me.Cursor = Cursors.WaitCursor

            Sql = "SELECT  EmpNome + ' ' + EmpDesigna sCompanyName , EmpContrib, EmpNrRegisto, EmpMorada + ' nº' + EmpNumPolicia sAddressDetail, EmpCodPostal, EmpLocalidade FROM Empresas WHERE EmpresaID = '" & xEmp & "'"
            db.GetData(Sql, dtSaftHeader)

            'SELECIONAR DOCUMENTOS PARA EXPORTAR   
            Sql = "UPDATE DOCCAB SET SAFT = 0 WHERE SAFT=1 OR SAFT IS NULL"
            db.ExecuteData(Sql)
            'Sql = "UPDATE DocCab SET SAFT = 1 WHERE (TipoDocID = 'FS' OR TipoDocID = 'NC') AND (EmpresaID = '0001') AND (DataDoc >= CONVERT(DATETIME, '2013-02-01 00:00:00', 102)) AND (DataDoc < CONVERT(DATETIME, '2013-02-28 00:00:00', 102))"
            Sql = "UPDATE DocCab SET SAFT = 1 WHERE (TipoDocID = 'FS' OR TipoDocID = 'NC') AND (EmpresaID = '0001') AND (DataDoc >= CONVERT(DATETIME, '" & dpDeData.Value.ToString("yyyy-MM-dd") & "', 102)) AND (DataDoc < CONVERT(DATETIME, '" & dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") & "', 102))"
            'Sql = "UPDATE    DocCab SET SAFT = 1 WHERE IdDocCab IN ('9A5A225B-5C6F-431E-8BB1-35E64682809E','7E96A314-94D2-4BB7-8CB4-3CE607BBD36E')"
            db.ExecuteData(Sql)       'FALTA DATAS DINÂMICAS


            Dim writer As New XmlTextWriter("C:\Girl\SAFT-PT\SAFT-PT.xml", System.Text.Encoding.Default)

            'inicia o documento xml
            writer.WriteStartDocument()


            'define a indentação do arquivo
            writer.Formatting = Formatting.Indented

            'AuditFile NIVEL 1 
            writer.WriteStartElement("AuditFile")
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
            'writer.WriteAttributeString("xmlns", "urn:OECD:StandardAuditFile-Tax:PT_1.02_01")
            writer.WriteAttributeString("xmlns", "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")

            'CARREGAR DADOS E VARIÁVEIS HEADER

            Dim sAuditFileVersion As String = "1.01_01" 'TEXTO 10
            Dim sCompanyID As String = "VNGAIA 509634060" 'TEXTO 50
            Dim iTaxRegistrationNumber As Int32 = dtSaftHeader.Rows(0)("EmpContrib") 'INTEIRO 9
            Dim sTaxAccountingBasis As String = "F" 'TEXTO 1
            Dim sCompanyName As String = dtSaftHeader.Rows(0)("sCompanyName") 'TEXTO 100 
            Dim sAddressDetail As String = dtSaftHeader.Rows(0)("sAddressDetail") 'TEXTO 100
            Dim sCity As String = Trim(dtSaftHeader.Rows(0)("EmpLocalidade")) 'TEXTO 50
            Dim sPostalCode As String = dtSaftHeader.Rows(0)("EmpCodPostal") 'TEXTO 8
            Dim sCountry As String = "PT" 'TEXTO 2
            Dim iFiscalYear As Int16 = 2013 'INTEIRO 4
            Dim dStartDate As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim dEndDate As String = dpAteData.Value.ToString("yyyy-MM-dd")
            Dim sCurrencyCode As String = "EUR" 'TEXTO 3
            Dim dDateCreated As String = Now().ToString("yyyy-MM-dd")
            Dim sTaxEntity As String = "Global" 'TEXTO 20
            Dim sProductCompanyTaxID As String = "507687213" 'TEXTO 20  NIF DA ENTIDADE PRODUTORA SOFTWARE
            Dim sSoftwareCertificateNumber As String = "0" 'TEXTO 20
            Dim sProductID As String = "GIRL/Grande Enigma" 'TEXTO 255
            Dim sProductVersion As String = "1.0" 'TEXTO 30


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

            writer.WriteEndElement() 'Header

            '   MasterFiles NIVEL 2 
            writer.WriteStartElement("MasterFiles")


            Sql = "SELECT DocCab.TercID, ClientesLoja.Nome, ClientesLoja.NIF, ClientesLoja.Morada, ClientesLoja.Localidade, ClientesLoja.CodPostal FROM DocCab INNER JOIN ClientesLoja ON DocCab.TercID = ClientesLoja.ClienteLojaID WHERE DocCab.TipoDocID in ('VD','FS','NC') GROUP BY DocCab.TercID, ClientesLoja.Nome, ClientesLoja.NIF, ClientesLoja.Morada, ClientesLoja.Localidade, ClientesLoja.CodPostal"
            db.GetData(Sql, dtSaftCustomer)

            Dim sCustomerID As String = "1"
            Dim sAccountID As String = "Desconhecido"
            Dim sCustomerTaxID As String = "999999990"
            Dim sCompanyNameCli As String = "Consumidor final"
            Dim sAddressDetailCli As String = "Desconhecido"
            Dim sCityCli As String = "Desconhecido"
            Dim sPostalCodeCli As String = "Desconhecido"
            Dim sCountryCli As String = "Desconhecido"
            Dim iSelfBillingIndicatorCli As Int16 = 1


            For Each lCustomer As DataRow In dtSaftCustomer.Rows

                sCustomerID = lCustomer("TercID")
                sAccountID = "Desconhecido"
                sCustomerTaxID = IIf(Trim(lCustomer("NIF")) = "", "999999990", lCustomer("NIF"))
                sCompanyNameCli = IIf(Trim(lCustomer("Nome")) = "", "Desconhecido", lCustomer("Nome"))
                sAddressDetailCli = IIf(Trim(lCustomer("Morada")) = "", "Desconhecido", lCustomer("Morada"))
                sCityCli = IIf(Trim(lCustomer("Localidade")) = "", "Desconhecido", lCustomer("Localidade"))
                sPostalCodeCli = IIf(Trim(lCustomer("CodPostal")) = "", "Desconhecido", lCustomer("CodPostal"))
                sCountryCli = "PT" 'Alterar para dinâmico
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


            Sql = "SELECT DocDet.ModeloID + DocDet.CorID AS Artigo, RTRIM(ModeloCor.ModCorDescr) ModCorDescr FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.Saft = 1) GROUP BY DocDet.ModeloID + DocDet.CorID, ModeloCor.ModCorDescr ORDER BY Artigo"
            db.GetData(Sql, dtSaftProduct)


            Dim sProductType As String = "P"
            Dim sProductCode As String = "8700001"
            Dim sProductDescription As String = "Sapato de Criança Preto"
            Dim sProductNumberCode As String = "8700001"

            For Each lProduct As DataRow In dtSaftProduct.Rows

                sProductType = "P"
                sProductCode = lProduct("Artigo")
                sProductDescription = Trim(lProduct("ModCorDescr"))
                sProductNumberCode = lProduct("Artigo")

                writer.WriteStartElement("Product")
                writer.WriteElementString("ProductType", sProductType)
                writer.WriteElementString("ProductCode", sProductCode)
                writer.WriteElementString("ProductDescription", sProductDescription)
                writer.WriteElementString("ProductNumberCode", sProductNumberCode)
                writer.WriteEndElement() 'Product


            Next


            '       TaxTable NIVEL 3  passar a dinâmico
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

            'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS DocumentTotals, DocCab.DataDoc, 1 AS NumberOfEntries FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab HAVING (DocCab.TipoDocID = 'FS' OR DocCab.TipoDocID = 'NC') AND (DocCab.EmpresaID = '0001') AND (DocCab.DataDoc >= CONVERT(DATETIME, '2000-01-01 00:00:00', 102)) AND (DocCab.DataDoc < CONVERT(DATETIME, '2013-02-01 00:00:00', 102)) ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
            'db.GetData(Sql, dtSaftInvoice)

            Sql = "SELECT COUNT(*) AS NumberOfEntries FROM DocCab WHERE Saft = 1"
            Dim iNumberOfEntries As Int32 = db.GetDataValue(Sql)

            Sql = "SELECT ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),0) AS TotalDebit FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.Saft = 1) AND DocCab.EstadoDoc<>'A' AND (DocCab.TipoDocID = 'NC')"
            Dim dTotalDebit As Double = Arredondamento(db.GetDataValue(Sql), 2)

            Sql = "SELECT ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),0) AS TotalCredit FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.Saft = 1) AND DocCab.EstadoDoc<>'A' AND (DocCab.TipoDocID = 'FS')"
            Dim dTotalCredit As Double = Arredondamento(db.GetDataValue(Sql), 2)

            '   SourceDocuments NIVEL 2
            writer.WriteStartElement("SourceDocuments")


            writer.WriteStartElement("SalesInvoices")
            writer.WriteElementString("NumberOfEntries", iNumberOfEntries)
            writer.WriteElementString("TotalDebit", dTotalDebit)
            writer.WriteElementString("TotalCredit", dTotalCredit)


            Dim sInvoiceNo As String = ""
            Dim sInvoiceStatus As String
            Dim dInvoiceStatusDate As String
            'Dim dInvoiceStatusDateAux As Date
            Dim sHash As String
            Dim dInvoiceDate As String
            'Dim dInvoiceDateAux As Date
            Dim sInvoiceType As String
            Dim iSelfBillingIndicator As Int16
            Dim dSystemEntryDate As String
            'Dim dSystemEntryDateAux As Date
            Dim sCustomerIDInv As String = ""

            'TOTAIS DO DOCUMENTO
            Dim dTaxPayable As Double = 0
            Dim dNetTotal As Double = 0
            Dim dGrossTotal As Double = 0
            Dim sCurrencyCode1 As String = ""
            Dim dCurrencyAmount As Double = 0


            'VARIAVEIS DE LINHA
            Dim sArmazemID As String = ""
            Dim iLineNumber As Int32 = 1
            Dim sProductCodeLinha As String = "87000"
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



            Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.Saft = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
            'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, 'FT' TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.Saft = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
            db.GetData(Sql, dtSaftInvoice)

            For Each r As DataRow In dtSaftInvoice.Rows



                sInvoiceNo = Trim(r("TipoDocID")) & " " & Microsoft.VisualBasic.Left(r("DocNr"), 2) & Microsoft.VisualBasic.Right(r("ArmazemID"), 2) & "/" & Microsoft.VisualBasic.Right(r("DocNr"), 5)
                'FORMATO DA sInvoiceNo "FS 1013/00001"

                If RTrim(LTrim(r("EstadoDoc"))) = "A" Then sInvoiceStatus = "A" Else sInvoiceStatus = "N" '  N-Normal   OU   A-ANULADA
                'dInvoiceStatusDateAux = r("DtUltAlt")
                'dInvoiceStatusDate = dInvoiceStatusDateAux.ToString("s")
                dInvoiceStatusDate = CDate(r("DtUltAlt")).ToString("s")
                sHash = "0"
                'dInvoiceDateAux = r("DataDoc")
                'dInvoiceDate = Microsoft.VisualBasic.Left(dInvoiceDateAux.ToString("s"), 10)
                ''dInvoiceDate = CDate(r("DataDoc")).ToString("s")
                'dInvoiceDate = Microsoft.VisualBasic.Left(CDate(r("DataDoc")).ToString("s"), 10)
                dInvoiceDate = CDate(r("DataDoc")).ToString("yyyy-MM-dd")
                sInvoiceType = r("TipoDocID")
                iSelfBillingIndicator = 0
                'dSystemEntryDateAux = r("DataDoc")
                'dSystemEntryDate = dSystemEntryDateAux.ToString("s")
                dSystemEntryDate = CDate(r("DataDoc")).ToString("s")
                'dSystemEntryDate = "2013-01-11T10:04:27"
                sCustomerIDInv = r("TercID")
                'Now.Date.ToString("yyyy-MM-dd")
                'Me.DateTimePicker3.Value.ToString("yyyy-MM-dd")

                'ALTERAR PARA CDate(r("DataDoc")).ToString("s")

                writer.WriteStartElement("Invoice")
                writer.WriteElementString("InvoiceNo", sInvoiceNo)
                writer.WriteElementString("InvoiceStatus", sInvoiceStatus)
                'writer.WriteElementString("InvoiceStatusDate", dInvoiceStatusDate)
                'writer.WriteElementString("SourceID", "Admin")
                writer.WriteElementString("Hash", sHash)
                writer.WriteElementString("InvoiceDate", dInvoiceDate)
                writer.WriteElementString("InvoiceType", sInvoiceType)
                writer.WriteElementString("SelfBillingIndicator", iSelfBillingIndicator)
                'writer.WriteElementString("SourceID", "Admin")
                writer.WriteElementString("SystemEntryDate", dSystemEntryDate)
                writer.WriteElementString("CustomerID", sCustomerIDInv)
                'writer.WriteStartElement("ShipTo")
                'writer.WriteEndElement() 'ShipTo
                'writer.WriteStartElement("ShipFrom")
                'writer.WriteEndElement() 'ShipFrom



                'CRIAR CICLO COM AS LINHAS DO DOCUMENTO

                dtSaftInvoiceLinha.Clear()
                Sql = "SELECT DocCab.IdDocCab, DocCab.ArmazemID, DocDet.DocLnNr, DocDet.ModeloID + DocDet.CorID AS Artigo, ModeloCor.ModCorDescr, DocDet.Qtd, DocDet.Unidade, DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA AS PrecoLiq, CONVERT(char(10), DocCab.DataDoc,126) DataDoc,  DocDet.Descricao, (DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd AS ValorLiq, TaxIVA.TxIVA * 100 AS TxIVA, DocDet.VlrDescLn / (1 + TaxIVA.TxIVA) AS TDescLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.Saft = 1) AND (DocCab.IdDocCab = '" & r("IdDocCab").ToString & "') ORDER BY DocDet.DocLnNr"
                db.GetData(Sql, dtSaftInvoiceLinha)

                For Each Linha As DataRow In dtSaftInvoiceLinha.Rows
                    If Linha("ValorLiq") > 0 Then
                        sArmazemID = Linha("ArmazemID")
                        iLineNumber = Linha("DocLnNr")
                        sProductCodeLinha = Linha("Artigo")
                        sProductDescriptionLinha = Trim(Linha("ModCorDescr"))
                        dQuantity = Linha("Qtd")
                        sUnitOfMeasure = Linha("Unidade")
                        dUnitPrice = Arredondamento(Linha("PrecoLiq"), 2)
                        sTaxPointDate = Linha("DataDoc")
                        sDescription = Trim(Linha("Descricao"))
                        dAmount = Arredondamento(Linha("ValorLiq"), 2)
                        sTaxType = "IVA"
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
                        writer.WriteElementString("TaxPointDate", sTaxPointDate)
                        writer.WriteElementString("Description", sDescription)
                        Select Case sInvoiceType    'POSSO A PASSAR A USAR O CAMPO MOVFIN DA TABELA TIPODOC
                            Case "NC"
                                writer.WriteElementString("DebitAmount", dAmount)
                            Case "FS"
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
                sCurrencyCode1 = "EUR"
                dCurrencyAmount = Arredondamento(r("TotalCIVA"), 2)

                writer.WriteStartElement("DocumentTotals")
                writer.WriteElementString("TaxPayable", dTaxPayable)
                writer.WriteElementString("NetTotal", dNetTotal)
                writer.WriteElementString("GrossTotal", dGrossTotal)

                writer.WriteStartElement("Currency")
                writer.WriteElementString("CurrencyCode", sCurrencyCode1)
                'writer.WriteElementString("CurrencyAmount", dCurrencyAmount)   'NOVA VERSÃO???   NA PAG 6735 DA PORTARIA 382/2012 ESTÁ ASSIM!!!!!
                Select Case sInvoiceType    'POSSO A PASSAR A USAR O CAMPO MOVFIN DA TABELA TIPODOC
                    Case "NC"
                        writer.WriteElementString("CurrencyDebitAmount", dCurrencyAmount)
                        AUXIVA = AUXIVA - dTaxPayable
                        AUXTOTLIQ = AUXTOTLIQ - dNetTotal
                        AUXTOTBRUTO = AUXTOTBRUTO - dGrossTotal
                    Case "FS"
                        writer.WriteElementString("CurrencyCreditAmount", dCurrencyAmount)
                        AUXIVA = AUXIVA + dTaxPayable
                        AUXTOTLIQ = AUXTOTLIQ + dNetTotal
                        AUXTOTBRUTO = AUXTOTBRUTO + dGrossTotal
                End Select
                writer.WriteEndElement() 'Currency
                writer.WriteEndElement() 'DocumentTotals
                writer.WriteEndElement() 'Invoice


            Next

            writer.WriteEndElement() 'SalesInvoices

            writer.WriteStartElement("MovementOfGoodes")

            Dim iNumberOfMovementLines As Int16
            Dim dTotalQuantityIssued As Double



            writer.WriteElementString("NumberOfMovementLines", iNumberOfMovementLines)
            writer.WriteElementString("TotalQuantityIssued", dTotalQuantityIssued)



            Dim sGuiasDocumentNumber As String   '  GT 1302/00001  MAX 60 carateres
            'Dim sGuiasDocumentStatus As String  '???
            Dim sGuiasMovementStatus As String 'N - Normal A - ANULADO
            Dim sGuiasMovementStatusDate As String  'AAAA-MM-DDThh:mm:ss
            Dim sGuiasSourceID As String 'UTILIZADOR RESP. PELO ESTADO ACTUAL DO DOCUMENTO
            Dim sGuiasSourceBilling As String 'P - DOC PRODUZIDO PELA APLICAÇÃO   M - DOC. PROV DE RECUPERAÇÃO MANUAL
            Dim sGuiasHasch As String = "0"
            Dim sGuiasMovementDate As String 'DATA DE EMISSÃO DO DOCUMENTO DE TRANSPORTE
            Dim sGuiasMovementType As String ' GR, GT, GC, GD
            Dim sGuiasSystemEntryDate As String 'AAAA-MM-DDThh:mm:ss
            Dim sGuiasCustomerID As String 'SE O DESTINATÁRIO FOR O PRÓPRIO COLOCAR O CLIENTE GENÉRICO
            Dim sGuiasSupplierID As String 'DEVOLUÇÕES OU SUBCONTRATO
            Dim sGuiasDocSourceID As String 'UTILIZADOR RESP. PELA CRIAÇÃO DO DOCUMENTO
            Dim sGuiasDestinoAddressDetail As String 'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
            Dim sGuiasDestinoCity As String
            Dim sGuiasDestinoPostalCode As String
            Dim sGuiasDestinoCountry As String   'ISO 3166 - 1-alpha-2
            Dim sGuiasOrigemAddressDetail As String 'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
            Dim sGuiasOrigemCity As String
            Dim sGuiasOrigemPostalCode As String
            Dim sGuiasOrigemCountry As String   'ISO 3166 - 1-alpha-2
            Dim sGuiasMovementStartTime As String    'AAAA-MM-DDThh:mm:ss
            Dim sGuiasLineNumber As Int16  'MANTER A ORDEM DAS LINHAS
            Dim sGuiasProductCode As String ' CÓDIGO DO PRODUTO
            Dim sGuiasProductDescription As String ' DESCRIÇÃO DA TABELA DE PRODUTOS
            Dim iGuiasQuantity As Int16
            Dim sGuiasUnitOfMeasure As String
            Dim sGuiasUnitPrice As String = "0.00"    'SE A GUIA NÃO LEVA VALORIZADA COLOCAR 0.00 
            Dim sGuiasDescription As String 'DESCRIÇÃO DA LINHA DE DOCUMENTO   MAX : 60
            Dim sGuiasTaxType As String = "IVA"
            Dim sGuiasTaxCountryRegion As String 'ISO 3166 -1-alpha-2 : PT ou PT-MA ou PT-MA
            Dim sGuiasTaxCode As String = "Normal"
            Dim dGuiasTaxPercentage As Double 'TAXA IMPOSTO RELATIVA AO PRODUTO   'CONFIRMAR!!!!!!!!
            Dim sGuiasTaxPayable As String = "0.00"
            Dim sGuiasNetTotal As String = "0.00"
            Dim sGuiasGrossTotal As String = "0.00"
            Dim sGuiasCurrencyCode As String = "EUR" 'ISO 4217
            Dim sGuiasCurrencyAmount As String = "0.00"  'penso que não é obrigatorio








            'Dim sGuiasLineNumber As Int16  'MANTER A ORDEM DAS LINHAS
            'Dim sGuiasProductCode As String ' CÓDIGO DO PRODUTO
            'Dim sGuiasProductDescription As String ' DESCRIÇÃO DA TABELA DE PRODUTOS
            'Dim iGuiasQuantity As Int16
            'Dim sGuiasUnitOfMeasure As String
            'Dim sGuiasUnitPrice As String = "0.00"    'SE A GUIA NÃO LEVA VALORIZADA COLOCAR 0.00 
            'Dim sGuiasDescription As String 'DESCRIÇÃO DA LINHA DE DOCUMENTO   MAX : 60
            'Dim sGuiasTaxType As String = "IVA"
            'Dim sGuiasTaxCountryRegion As String 'ISO 3166 -1-alpha-2 : PT ou PT-MA ou PT-MA
            'Dim sGuiasTaxCode As String = "Normal"
            'Dim dGuiasTaxPercentage As Double 'TAXA IMPOSTO RELATIVA AO PRODUTO   'CONFIRMAR!!!!!!!!
            'Dim sGuiasTaxPayable As String = "0.00"
            'Dim sGuiasNetTotal As String = "0.00"
            'Dim sGuiasGrossTotal As String = "0.00"
            'Dim sGuiasCurrencyCode As String = "EUR" 'ISO 4217
            'Dim sGuiasCurrencyAmount As String = "0.00"  'penso que não é obrigatorio






            Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM(DocDet.Qtd) AS Expr1, DocCab.TipoTerc FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.TipoTerc HAVING (DocCab.TipoDocID = 'GT')"
            db.GetData(Sql, dtSaftGuia)

            For Each r As DataRow In dtSaftInvoice.Rows

                sGuiasDocumentNumber = Trim(r("TipoDocID")) & " " & Microsoft.VisualBasic.Left(r("DocNr"), 2) & Microsoft.VisualBasic.Right(r("ArmazemID"), 2) & "/" & Microsoft.VisualBasic.Right(r("DocNr"), 5)
                'FORMATO "GT 1300/00001"

                If RTrim(LTrim(r("EstadoDoc"))) = "A" Then sGuiasMovementStatus = "A" Else sGuiasMovementStatus = "N" '  N-Normal   OU   A-ANULADA

                sGuiasMovementStatusDate = CDate(r("DtUltAlt")).ToString("s")
                sGuiasSourceID = r("OperadorID")
                sGuiasSourceBilling = "P"
                sGuiasHasch = "0"
                sGuiasMovementDate = CDate(r("DataDoc")).ToString("yyyy-MM-dd")
                sGuiasMovementType = r("TipoDocID")
                sGuiasSystemEntryDate = CDate(r("DataDoc")).ToString("s")
                sGuiasCustomerID = r("TercID") 'ATT COMO TENHO DUAS TABELAS DE TERCEIROS VOU TER PROBLEMAS, TENHO QUE DISTINGUIR
                'sGuiasSupplierID  'DEVOLUÇÕES OU SUBCONTRATO
                'sGuiasDocSourceID  'UTILIZADOR RESP. PELA CRIAÇÃO DO DOCUMENTO
                'sGuiasDestinoAddressDetail  'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
                'sGuiasDestinoCity 
                'sGuiasDestinoPostalCode 
                'sGuiasDestinoCountry    'ISO 3166 - 1-alpha-2
                'sGuiasOrigemAddressDetail  'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
                'sGuiasOrigemCity
                'sGuiasOrigemPostalCode 
                'sGuiasOrigemCountry   'ISO 3166 - 1-alpha-2
                'sGuiasMovementStartTime    'AAAA-MM-DDThh:mm:ss


                'O CODIGO DAQUI PARA BAIXO ESTÁ EM FUNÇÃO DA INVOICE  






                writer.WriteStartElement("Invoice")
                writer.WriteElementString("InvoiceNo", sInvoiceNo)
                writer.WriteElementString("InvoiceStatus", sInvoiceStatus)
                writer.WriteElementString("Hash", sHash)
                writer.WriteElementString("InvoiceDate", dInvoiceDate)
                writer.WriteElementString("InvoiceType", sInvoiceType)
                writer.WriteElementString("SelfBillingIndicator", iSelfBillingIndicator)
                writer.WriteElementString("SystemEntryDate", dSystemEntryDate)
                writer.WriteElementString("CustomerID", sCustomerIDInv)



                'CRIAR CICLO COM AS LINHAS DO DOCUMENTO

                dtSaftInvoiceLinha.Clear()
                Sql = "SELECT DocCab.IdDocCab, DocCab.ArmazemID, DocDet.DocLnNr, DocDet.ModeloID + DocDet.CorID AS Artigo, ModeloCor.ModCorDescr, DocDet.Qtd, DocDet.Unidade, DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA AS PrecoLiq, CONVERT(char(10), DocCab.DataDoc,126) DataDoc,  DocDet.Descricao, (DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd AS ValorLiq, TaxIVA.TxIVA * 100 AS TxIVA, DocDet.VlrDescLn / (1 + TaxIVA.TxIVA) AS TDescLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.Saft = 1) AND (DocCab.IdDocCab = '" & r("IdDocCab").ToString & "') ORDER BY DocDet.DocLnNr"
                db.GetData(Sql, dtSaftInvoiceLinha)

                For Each Linha As DataRow In dtSaftInvoiceLinha.Rows
                    If Linha("ValorLiq") > 0 Then
                        sArmazemID = Linha("ArmazemID")
                        iLineNumber = Linha("DocLnNr")
                        sProductCodeLinha = Linha("Artigo")
                        sProductDescriptionLinha = Trim(Linha("ModCorDescr"))
                        dQuantity = Linha("Qtd")
                        sUnitOfMeasure = Linha("Unidade")
                        dUnitPrice = Arredondamento(Linha("PrecoLiq"), 2)
                        sTaxPointDate = Linha("DataDoc")
                        sDescription = Trim(Linha("Descricao"))
                        dAmount = Arredondamento(Linha("ValorLiq"), 2)
                        sTaxType = "IVA"
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
                        writer.WriteElementString("TaxPointDate", sTaxPointDate)
                        writer.WriteElementString("Description", sDescription)
                        Select Case sInvoiceType    'POSSO A PASSAR A USAR O CAMPO MOVFIN DA TABELA TIPODOC
                            Case "NC"
                                writer.WriteElementString("DebitAmount", dAmount)
                            Case "FS"
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
                sCurrencyCode1 = "EUR"
                dCurrencyAmount = Arredondamento(r("TotalCIVA"), 2)

                writer.WriteStartElement("DocumentTotals")
                writer.WriteElementString("TaxPayable", dTaxPayable)
                writer.WriteElementString("NetTotal", dNetTotal)
                writer.WriteElementString("GrossTotal", dGrossTotal)

                writer.WriteStartElement("Currency")
                writer.WriteElementString("CurrencyCode", sCurrencyCode1)
                'writer.WriteElementString("CurrencyAmount", dCurrencyAmount)   'NOVA VERSÃO???   NA PAG 6735 DA PORTARIA 382/2012 ESTÁ ASSIM!!!!!
                Select Case sInvoiceType    'POSSO A PASSAR A USAR O CAMPO MOVFIN DA TABELA TIPODOC
                    Case "NC"
                        writer.WriteElementString("CurrencyDebitAmount", dCurrencyAmount)
                        AUXIVA = AUXIVA - dTaxPayable
                        AUXTOTLIQ = AUXTOTLIQ - dNetTotal
                        AUXTOTBRUTO = AUXTOTBRUTO - dGrossTotal
                    Case "FS"
                        writer.WriteElementString("CurrencyCreditAmount", dCurrencyAmount)
                        AUXIVA = AUXIVA + dTaxPayable
                        AUXTOTLIQ = AUXTOTLIQ + dNetTotal
                        AUXTOTBRUTO = AUXTOTBRUTO + dGrossTotal
                End Select
                writer.WriteEndElement() 'Currency
                writer.WriteEndElement() 'DocumentTotals
                writer.WriteEndElement() 'Invoice


            Next







            writer.WriteEndElement() 'MovementOfGoodes
            writer.WriteEndElement() 'SourceDocuments
            writer.WriteEndElement() 'AuditFile
            writer.Close()

            ValidarEsquema()

            MsgBox("Totais: " & Chr(13) & "IVA: " & AUXIVA & Chr(13) & "Liquido: " & AUXTOTLIQ & Chr(13) & "Bruto: " & AUXTOTBRUTO)
            MsgBox("Arquivo SAFT-PT gerado com sucesso.")


            Me.Cursor = Cursors.Default

            ClearMemory()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub ValidarEsquema()
        Dim myDocument As New XmlDocument
        myDocument.Load("C:\Girl\SAFT-PT\SAFT-PT.xml")
        'namespace here or empty string
        myDocument.Schemas.Add("urn:OECD:StandardAuditFile-Tax:PT_1.01_01", "C:\Girl\SAFT-PT\Files\SAFTPT.xsd")
        Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)
        myDocument.Validate(eventHandler)
    End Sub

    Private Sub ValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)
        Select Case e.Severity
            Case XmlSeverityType.Error
                Debug.WriteLine("Error: {0}", e.Message)
            Case XmlSeverityType.Warning
                Debug.WriteLine("Warning {0}", e.Message)
        End Select
    End Sub

    Private Sub ExpGT()

    End Sub



End Class