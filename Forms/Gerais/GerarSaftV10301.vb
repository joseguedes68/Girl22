Imports System
Imports System.IO
Imports System.Xml
Imports System.Data
Imports Microsoft.VisualBasic

Imports System.Xml.Schema
Imports System.Xml.XPath


Public Class GerarSaftV10301


    Dim AUXIVA As Double = 0
    Dim AUXTOTLIQ As Double = 0
    Dim AUXTOTLIQ_CREDITO As Double = 0
    Dim AUXTOTLIQ_DEBITO As Double = 0
    Dim QtdDocs As Int32 = 0
    Dim AUXTOTBRUTO As Double = 0
    Dim sNomeAux As String
    Dim sMarca As String = "CELFERI" 'TODO: Ir buscar à tabela Empresa


    Private Sub GerarSaftPT_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        Dim dtAux As Date = Now
        Dim dtMes As Int16 = Month(Now) - 1
        If dtMes = 0 Then dtMes = 12
        Dim dtAno As Int16 = Year(Now)
        If dtMes = 12 Then dtAno = dtAno - 1
        Dim diasdomes As Int16 = System.DateTime.DaysInMonth(dtAno, dtMes)

        Me.Text = "GerarSaftPT"

        dpDeData.Value = Now.AddDays(-(Now.Day - 1) - diasdomes)
        dpAteData.Value = Now.AddDays(-Now.Day)
        sNomeAux = "SAFT-PT_" & sMarca & "_" & Year(dpDeData.Value) & "_" & Month(dpDeData.Value)


    End Sub

    Private Sub btGeraSAFT_Click(sender As System.Object, e As System.EventArgs) Handles btGeraSAFT.Click

        Try

            GeraSAFT()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub dpDeData_ValueChanged(sender As Object, e As System.EventArgs) Handles dpDeData.ValueChanged

        'If dpDeData.Value.Day <> 1 Then
        '    btGeraSAFT.Enabled = False
        '    If MsgBox("Confirma a data de Inicio?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If
        'btGeraSAFT.Enabled = True
        'sNomeAux = "SAFT-PT_" & sMarca & "_" & Year(dpDeData.Value) & "_" & Month(dpDeData.Value)

    End Sub

    Private Sub dpAteData_ValueChanged(sender As Object, e As System.EventArgs) Handles dpAteData.ValueChanged

        'If dpAteData.Value.Day <> System.DateTime.DaysInMonth(dpAteData.Value.Year, dpAteData.Value.Month) Then
        '    btGeraSAFT.Enabled = False
        '    If MsgBox("Confirma a data de Fim?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If
        'btGeraSAFT.Enabled = True
        'sNomeAux = "SAFT-PT_" & sMarca & "_" & Year(dpDeData.Value) & "_" & Month(dpDeData.Value)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ValidarEsquema()

        Try
            Dim myDocument As New XmlDocument
            myDocument.Load("C:\Girl\SAFT-PT\" & sNomeAux & ".xml")
            'namespace here or empty string
            myDocument.Schemas.Add("urn:OECD:StandardAuditFile-Tax:PT_1.03_01", "C:\Girl\SAFT-PT\Files\SAFTPT1.03_01.xsd")
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

    'FUNÇÕES

    Private Sub GeraSAFT()



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


        Try

            AUXIVA = 0
            AUXTOTLIQ = 0
            AUXTOTLIQ_CREDITO = 0
            AUXTOTLIQ_DEBITO = 0
            QtdDocs = 0
            AUXTOTBRUTO = 0

            'Sql = "UPDATE  DocCab SET  SAFT = 0"
            'db.ExecuteData(Sql)

            Sql = "SELECT COUNT(*) FROM DOCCAB WHERE SAFT = 1"
            If db.GetDataValue(Sql) > 0 Then
                MsgBox("Outro Ulilizador está a exportar P.F. Tente mais tarde!")
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Sql = "SELECT  EmpNome + ' ' + EmpDesigna sCompanyName , EmpContrib, EmpNrRegisto, EmpMorada + ' nº' + EmpNumPolicia sAddressDetail, EmpCodPostal, EmpLocalidade, EmpTelefone, EmpFax FROM Empresas WHERE EmpresaID = '" & xEmp & "'"
            db.GetData(Sql, dtSaftHeader)


            'SELECIONAR DOCUMENTOS PARA EXPORTAR   

            If cbIncGuiasTransp.Checked = True Then
                Sql = "UPDATE DocCab SET SAFT = 1 WHERE TipoDocID in ('FS','NC','FT','ND','GT') AND (EmpresaID = '" & xEmp & "') AND (DataDoc >= CONVERT(DATETIME, '" & dpDeData.Value.ToString("yyyy-MM-dd") & "', 102)) AND (DataDoc < CONVERT(DATETIME, '" & dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") & "', 102))"
            Else
                Sql = "UPDATE DocCab SET SAFT = 1 WHERE TipoDocID in ('FS','NC','FT','ND') AND (EmpresaID = '" & xEmp & "') AND (DataDoc >= CONVERT(DATETIME, '" & dpDeData.Value.ToString("yyyy-MM-dd") & "', 102)) AND (DataDoc < CONVERT(DATETIME, '" & dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") & "', 102))"
            End If
            db.ExecuteData(Sql)


            'ALTERAR CAMINHO E NOME DO FICHEIRO
            Dim writer As New XmlTextWriter("C:\Girl\SAFT-PT\" & sNomeAux & ".xml", System.Text.Encoding.Default)

            'INICIA O DOCUMENTO XML
            writer.WriteStartDocument()


            'DEFINE A INDENTAÇÃO DO ARQUIVO
            writer.Formatting = Formatting.Indented

            'AuditFile NIVEL 1 
            writer.WriteStartElement("AuditFile")
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
            writer.WriteAttributeString("xmlns", "urn:OECD:StandardAuditFile-Tax:PT_1.03_01")


            'CARREGAR DADOS E VARIÁVEIS HEADER

            Dim sAuditFileVersion As String = "1.03_01" 'TEXTO 10
            Dim sCompanyID As String = "VNGAIA 509634060" 'TEXTO 50
            Dim iTaxRegistrationNumber As Int32 = dtSaftHeader.Rows(0)("EmpContrib") 'INTEIRO 9
            Dim sTaxAccountingBasis As String = "F" 'TEXTO 1
            Dim sCompanyName As String = dtSaftHeader.Rows(0)("sCompanyName") 'TEXTO 100 
            Dim sAddressDetail As String = dtSaftHeader.Rows(0)("sAddressDetail") 'TEXTO 100
            Dim sCity As String = Trim(dtSaftHeader.Rows(0)("EmpLocalidade")) 'TEXTO 50
            Dim sPostalCode As String = dtSaftHeader.Rows(0)("EmpCodPostal") 'TEXTO 8
            Dim sCountry As String = "PT" 'TEXTO 2
            Dim iFiscalYear As Int16 = Year(dpDeData.Value) 'INTEIRO 4
            Dim dStartDate As String = dpDeData.Value.ToString("yyyy-MM-dd")
            Dim dEndDate As String = dpAteData.Value.ToString("yyyy-MM-dd")
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


            'Sql = "SELECT RTRIM(LTRIM(TERCEIROS.TerceiroID)) AS TerceiroID, TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID FROM (SELECT('T') + TercID AS TerceiroID, TipoTerc, Nome, Morada, CodPostal, Localidade, NIF, PaisID, DistritoID, TercID FROM Terceiros AS Terceiros_1 UNION SELECT STR(ClienteLojaID) AS TerceiroID, 'L' AS TipoTerc, Nome, Morada, Localidade, CodPostal, NIF, PaisID, DistritoID, ClienteLojaID AS TercID FROM ClientesLoja) AS TERCEIROS INNER JOIN DocCab ON TERCEIROS.TercID = DocCab.TercID WHERE (DocCab.SAFT = 1) GROUP BY RTRIM(LTRIM(TERCEIROS.TerceiroID)), TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID"
            Sql = "SELECT RTRIM(LTRIM(TERCEIROS.TerceiroID)) AS TerceiroID, TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID FROM (SELECT 'T' + TercID AS TerceiroID, TipoTerc, Nome, Morada, CodPostal, Localidade, NIF, PaisID, DistritoID, TercID FROM Terceiros AS Terceiros_1 UNION SELECT STR(ClienteLojaID) AS TerceiroID, 'L' AS TipoTerc, Nome, Morada, Localidade, CodPostal, NIF, PaisID, DistritoID, ClienteLojaID AS TercID FROM ClientesLoja) AS TERCEIROS INNER JOIN DocCab ON TERCEIROS.TercID = DocCab.TercID WHERE (DocCab.SAFT = 1) GROUP BY RTRIM(LTRIM(TERCEIROS.TerceiroID)), TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID HAVING (TERCEIROS.TipoTerc <> 'F')"
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
            Sql = "SELECT RTRIM(LTRIM(TERCEIROS.TerceiroID)) AS TerceiroID, TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID FROM (SELECT 'T' + TercID AS TerceiroID, TipoTerc, Nome, Morada, CodPostal, Localidade, NIF, PaisID, DistritoID, TercID FROM Terceiros AS Terceiros_1 UNION SELECT STR(ClienteLojaID) AS TerceiroID, 'L' AS TipoTerc, Nome, Morada, Localidade, CodPostal, NIF, PaisID, DistritoID, ClienteLojaID AS TercID FROM ClientesLoja) AS TERCEIROS INNER JOIN DocCab ON TERCEIROS.TercID = DocCab.TercID WHERE (DocCab.SAFT = 1) GROUP BY RTRIM(LTRIM(TERCEIROS.TerceiroID)), TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID HAVING (TERCEIROS.TipoTerc = 'F')"
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


            'Sql = "SELECT DocDet.ModeloID + DocDet.CorID AS Artigo, RTRIM(ModeloCor.ModCorDescr) ModCorDescr FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.Saft = 1) GROUP BY DocDet.ModeloID + DocDet.CorID, ModeloCor.ModCorDescr ORDER BY Artigo"
            'Sql = "SELECT DocDet.ModeloID + DocDet.CorID AS Artigo, RTRIM(ModeloCor.ModCorDescr) AS ModCorDescr, Modelos.TipoID FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID WHERE (DocCab.SAFT = 1) GROUP BY DocDet.ModeloID + DocDet.CorID, ModeloCor.ModCorDescr, Modelos.TipoID ORDER BY Artigo"
            Sql = "SELECT DocDet.ProductCode AS Artigo, RTRIM(Product.ProductDescription) AS ArtigoDescr, Product.ProductType FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID INNER JOIN Product ON DocDet.ProductCode = Product.ProductCode WHERE (DocCab.SAFT = 1) GROUP BY DocDet.ProductCode, RTRIM(Product.ProductDescription), Product.ProductType ORDER BY Artigo"

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
            writer.WriteElementString("Description", "IVA taxa normal")
            writer.WriteElementString("TaxPercentage", "22.00")
            writer.WriteEndElement() 'TaxTableEntry (1)
            writer.WriteStartElement("TaxTableEntry")
            writer.WriteElementString("TaxType", "IVA")
            writer.WriteElementString("TaxCountryRegion", "PT")
            writer.WriteElementString("TaxCode", "NOR")
            writer.WriteElementString("Description", "IVA taxa normal")
            writer.WriteElementString("TaxPercentage", "23.00")
            writer.WriteEndElement() 'TaxTableEntry (2)
            writer.WriteEndElement() 'TaxTable

            writer.WriteEndElement() 'MasterFiles


            'CARREGAR DADOS E VARIÁVEIS SalesInvoices

            '   SourceDocuments NIVEL 2
            writer.WriteStartElement("SourceDocuments")


            Sql = "SELECT COUNT(*) AS NumberOfEntries FROM DocCab WHERE Saft = 1 AND TipoDocID in ('FS','NC','FT','ND')"
            Dim iNumberOfEntries As Int32 = db.GetDataValue(Sql)

            Sql = "SELECT ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),0) AS TotalDebit FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE DocCab.Saft = 1 AND DocCab.EstadoDoc<>'A' AND DocCab.TipoDocID = 'NC'"
            Dim dTotalDebit As Double = Arredondamento(db.GetDataValue(Sql), 2)

            Sql = "SELECT ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),0) AS TotalCredit FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE DocCab.Saft = 1 AND DocCab.EstadoDoc<>'A' AND DocCab.TipoDocID IN ('FS','FT','ND')"
            Dim dTotalCredit As Double = Arredondamento(db.GetDataValue(Sql), 2)


            writer.WriteStartElement("SalesInvoices")
            writer.WriteElementString("NumberOfEntries", iNumberOfEntries)
            writer.WriteElementString("TotalDebit", dTotalDebit)
            writer.WriteElementString("TotalCredit", dTotalCredit)


            Dim sInvoiceNo As String = ""
            Dim sInvoiceStatus As String
            Dim dInvoiceStatusDate As String
            'Dim dInvoiceStatusDateAux As Date
            Dim sHash As String
            Dim sHashControl As String
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


            'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, 'FT' TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.Saft = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
            'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA , DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.Saft = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
            'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.SAFT = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig HAVING DocCab.TipoDocID IN ('FT','FS','NC','ND') ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
            'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr LEFT OUTER JOIN FormaPagamento ON DocCab.FormaPagtoID = FormaPagamento.FormaPagtoID WHERE (DocCab.SAFT = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev HAVING (DocCab.TipoDocID IN ('FT', 'FS', 'NC')) ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
            Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev, Utilizadores.NomeUtilizador FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Utilizadores ON DocCab.UtilizadorID = Utilizadores.UtilizadorID LEFT OUTER JOIN FormaPagamento ON DocCab.FormaPagtoID = FormaPagamento.FormaPagtoID WHERE (DocCab.SAFT = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev, Utilizadores.NomeUtilizador HAVING (DocCab.TipoDocID IN ('FT', 'FS', 'NC')) ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"



            db.GetData(Sql, dtSaftInvoice)

            For Each r As DataRow In dtSaftInvoice.Rows



                sInvoiceNo = Trim(r("TipoDocID")) & " " & Microsoft.VisualBasic.Left(r("DocNr"), 2) & Microsoft.VisualBasic.Right(r("ArmazemID"), 2) & "/" & Microsoft.VisualBasic.Right(r("DocNr"), 5)
                'FORMATO DA sInvoiceNo "FS 1013/00001"

                'Dim aux As New ClsExportaXML
                'aux.Exporta(sInvoiceNo)



                If RTrim(LTrim(r("EstadoDoc"))) = "A" Then sInvoiceStatus = "A" Else sInvoiceStatus = "N" '  N-NORMAL   OU   A-ANULADA
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
                        sCustomerIDInv = "T" + r("TercID")
                End Select


                'Now.Date.ToString("yyyy-MM-dd")
                'Me.DateTimePicker3.Value.ToString("yyyy-MM-dd")

                'ALTERAR PARA CDate(r("DataDoc")).ToString("s")




                writer.WriteStartElement("Invoice")
                writer.WriteElementString("InvoiceNo", sInvoiceNo)
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
                'Sql = "SELECT DocCab.IdDocCab, DocCab.ArmazemID, DocDet.DocLnNr, DocDet.ModeloID + DocDet.CorID AS Artigo, ModeloCor.ModCorDescr, DocDet.Qtd, DocDet.Unidade, DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA AS PrecoLiq, CONVERT(char(10), DocCab.DataDoc,126) AS DataDoc,  DocDet.Descricao, (DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd AS ValorLiq, TaxIVA.TxIVA * 100 AS TxIVA, DocDet.VlrDescLn / (1 + TaxIVA.TxIVA) * DocDet.Qtd AS TDescLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.Saft = 1) AND (DocCab.IdDocCab = '" & r("IdDocCab").ToString & "') ORDER BY DocDet.DocLnNr"
                'Sql = "SELECT DocCab.IdDocCab, DocCab.ArmazemID, DocDet.DocLnNr, DocDet.ProductCode AS Artigo, Product.ProductDescription, DocDet.Qtd, DocDet.Unidade, DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA AS PrecoLiq, CONVERT(char(10), DocCab.DataDoc, 126) AS DataDoc, DocDet.Descricao, (DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd AS ValorLiq, TaxIVA.TxIVA * 100 AS TxIVA, DocDet.VlrDescLn / (1 + TaxIVA.TxIVA) * DocDet.Qtd AS TDescLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID INNER JOIN Product ON DocDet.ProductCode = Product.ProductCode WHERE (DocCab.SAFT = 1) AND (DocCab.IdDocCab = '" & r("IdDocCab").ToString & "') ORDER BY DocDet.DocLnNr"
                Sql = "SELECT DocCab.IdDocCab, DocCab.ArmazemID, DocDet.DocLnNr, DocDet.ProductCode AS Artigo, Product.ProductDescription, DocDet.Qtd, DocDet.Unidade, DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA AS PrecoLiq, CONVERT(char(10), DocCab.DataDoc, 126) AS DataDoc, DocDet.Descricao, (DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd AS ValorLiq, TaxIVA.TxIVA * 100 AS TxIVA, DocDet.VlrDescLn / (1 + TaxIVA.TxIVA) * DocDet.Qtd AS TDescLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID INNER JOIN Product ON DocDet.ProductCode = Product.ProductCode WHERE (DocCab.SAFT = 1) AND (DocCab.IdDocCab = '" & r("IdDocCab").ToString & "') ORDER BY DocDet.DocLnNr"
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
                        writer.WriteElementString("TaxPointDate", sTaxPointDate)

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

            'GUIAS DE TRANSPORTE

            'NOTA : NÃO ESTOU A IR BUSCAR OS DOCUMENTOS DE ORIGEM NAS GUIAS DE TRANSPORTE

            Sql = "SELECT COUNT(*) FROM DocCab WHERE (DocCab.SAFT = 1) AND DocCab.TipoDocID in ('GT')"
            If cbIncGuiasTransp.Checked = True And db.GetDataValue(Sql) > 0 Then

                writer.WriteStartElement("MovementOfGoods")

                Sql = "SELECT COUNT(DocDet.DocLnNr) AS iNumberOfMovementLines FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.SAFT = 1) AND DocCab.TipoDocID in ('GT')"
                Dim iNumberOfMovementLines As Int32 = db.GetDataValue(Sql)

                Sql = "SELECT SUM(DocDet.Qtd) AS dTotalQuantityIssued FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.SAFT = 1)  AND DocCab.TipoDocID in ('GT')"
                Dim dTotalQuantityIssued As Double = db.GetDataValue(Sql)

                writer.WriteElementString("NumberOfMovementLines", iNumberOfMovementLines)
                writer.WriteElementString("TotalQuantityIssued", dTotalQuantityIssued)


                Dim sGuiasDocumentNumber As String   '  GT 1302/00001  MAX 60 carateres
                'Dim sGuiasDocumentStatus As String  '???
                Dim sGuiasMovementStatus As String 'N - NORMAL A - ANULADO
                Dim sGuiasMovementStatusDate As String  'AAAA-MM-DDThh:mm:ss
                Dim sGuiasAlteraSourceID As String 'UTILIZADOR RESP. PELO ESTADO ACTUAL DO DOCUMENTO
                Dim sGuiasSourceBilling As String 'P - DOC PRODUZIDO PELA APLICAÇÃO   M - DOC. PROV DE RECUPERAÇÃO MANUAL
                Dim sGuiasHash As String
                Dim sGuiasHashControl As String
                Dim sGuiasMovementDate As String 'DATA DE EMISSÃO DO DOCUMENTO DE TRANSPORTE
                Dim sGuiasMovementType As String ' GR, GT, GC, GD
                Dim sGuiasSystemEntryDate As String 'AAAA-MM-DDThh:mm:ss
                Dim sGuiasCustomerID As String 'SE O DESTINATÁRIO FOR O PRÓPRIO COLOCAR O CLIENTE GENÉRICO
                Dim sGuiasSupplierID As String 'DEVOLUÇÕES OU SUBCONTRATO
                Dim sGuiasCriaSourceID As String 'UTILIZADOR RESP. PELA CRIAÇÃO DO DOCUMENTO
                Dim sGuiasDestinoAddressDetail As String 'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
                Dim sGuiasDestinoCity As String
                Dim sGuiasDestinoPostalCode As String
                Dim sGuiasDestinoCountry As String   'ISO 3166 - 1-alpha-2
                Dim sGuiasOrigemAddressDetail As String 'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
                Dim sGuiasOrigemCity As String
                Dim sGuiasOrigemPostalCode As String
                Dim sGuiasOrigemCountry As String   'ISO 3166 - 1-alpha-2
                Dim sGuiasMovementStartTime As String    'AAAA-MM-DDThh:mm:ss
                Dim sGuiasATDocCodeID As String



                Dim sGuiasLineNumber As Int16  'MANTER A ORDEM DAS LINHAS
                Dim sGuiasProductCode As String ' CÓDIGO DO PRODUTO
                Dim sGuiasProductDescription As String ' DESCRIÇÃO DA TABELA DE PRODUTOS
                Dim iGuiasQuantity As Int16
                Dim sGuiasUnitOfMeasure As String
                Dim sGuiasUnitPrice As String = "0.0000"    'SE A GUIA NÃO LEVA VALORIZADA COLOCAR 0.00 
                Dim sGuiasDescription As String 'DESCRIÇÃO DA LINHA DE DOCUMENTO   MAX : 60
                'Dim sGuiasTaxType As String = "IVA"
                'Dim sGuiasTaxCountryRegion As String 'ISO 3166 -1-alpha-2 : PT ou PT-MA ou PT-MA
                'Dim sGuiasTaxCode As String = "NORMAL"
                'Dim dGuiasTaxPercentage As Double 'TAXA IMPOSTO RELATIVA AO PRODUTO   'CONFIRMAR!!!!!!!!
                Dim sGuiasTaxPayable As String = "0.00"
                Dim sGuiasNetTotal As String = "0.00"
                Dim sGuiasGrossTotal As String = "0.00"
                Dim sGuiasCurrencyCode As String = "EUR" 'ISO 4217
                Dim sGuiasCurrencyAmount As String = "0.00"  'penso que não é obrigatorio



                'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.TipoTerc, SUM(DocDet.Qtd) AS QtdTot, COUNT(DocDet.DocLnNr) AS NumLinhas FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.SAFT = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.TipoTerc "
                'Sql = "SELECT IdDocCab, EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, DtUltAlt, EstadoDoc, FormaPagtoID, UtilizadorID, OperadorID, DtRegisto, TipoTerc, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, Hash, ATDocCodeID, ChavePrivadaVersao FROM DocCab WHERE (SAFT = 1)  GROUP BY EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, EstadoDoc, FormaPagtoID, UtilizadorID, OperadorID, DtRegisto, IdDocCab, DataDoc, DtUltAlt, TipoTerc, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, Hash, ATDocCodeID, ChavePrivadaVersao"
                'Sql = "SELECT IdDocCab, EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, DtUltAlt, EstadoDoc, FormaPagtoID, UtilizadorID, OperadorID, DtRegisto, TipoTerc, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, Hash, ATDocCodeID, ChavePrivadaVersao FROM DocCab WHERE (SAFT = 1) GROUP BY EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, EstadoDoc, FormaPagtoID, UtilizadorID, OperadorID, DtRegisto, IdDocCab, DataDoc, DtUltAlt, TipoTerc, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, Hash, ATDocCodeID, ChavePrivadaVersao HAVING (TipoDocID = 'GT')"
                'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.MovementStartTime, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementEndTime, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, Terceiros.TipoTerc FROM DocCab INNER JOIN Terceiros ON DocCab.TercID = Terceiros.TercID WHERE (DocCab.SAFT = 1) AND (DocCab.TipoDocID = 'GT')"
                Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.MovementStartTime, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementEndTime, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, Terceiros.TipoTerc, Utilizadores.NomeUtilizador FROM DocCab INNER JOIN Terceiros ON DocCab.TercID = Terceiros.TercID INNER JOIN Utilizadores ON DocCab.UtilizadorID = Utilizadores.UtilizadorID WHERE (DocCab.SAFT = 1) AND (DocCab.TipoDocID = 'GT')"

                db.GetData(Sql, dtSaftGuia)

                For Each r As DataRow In dtSaftGuia.Rows

                    sGuiasDocumentNumber = Trim(r("TipoDocID")) & " " & Microsoft.VisualBasic.Left(r("DocNr"), 2) & Microsoft.VisualBasic.Right(r("ArmazemID"), 2) & "/" & Microsoft.VisualBasic.Right(r("DocNr"), 5)
                    'FORMATO "GT 1300/00001"
                    If RTrim(LTrim(r("EstadoDoc"))) = "A" Then sGuiasMovementStatus = "A" Else sGuiasMovementStatus = "N" '  N-NORMAL   OU   A-ANULADA
                    sGuiasMovementStatusDate = CDate(r("DtUltAlt")).ToString("s")
                    sGuiasAlteraSourceID = Trim(r("NomeUtilizador"))  'utilizador que alterou o documento
                    sGuiasSourceBilling = "P"
                    sGuiasHash = r("Hash")
                    sGuiasHashControl = r("ChavePrivadaVersao")
                    sGuiasMovementDate = CDate(r("DataDoc")).ToString("yyyy-MM-dd")
                    sGuiasMovementType = r("TipoDocID")
                    sGuiasSystemEntryDate = CDate(r("DataDoc")).ToString("s")
                    sGuiasSupplierID = "T" + Trim(r("TercID"))  'NÃO PERMITE FAZER GT'S PARA CLIENTES DE LOJA!!
                    sGuiasCustomerID = "T" + Trim(r("TercID"))  'NÃO PERMITE FAZER GT'S PARA CLIENTES DE LOJA!!
                    sGuiasCriaSourceID = Trim(r("NomeUtilizador")) 'UTILIZADOR RESP. PELA CRIAÇÃO DO DOCUMENTO
                    sGuiasDestinoAddressDetail = r("AddressDetailDescarga")  'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
                    sGuiasDestinoCity = r("CityDescarga")
                    sGuiasDestinoPostalCode = r("PostalCodeDescarga")
                    sGuiasDestinoCountry = r("CountryDescarga")  'ISO 3166 - 1-alpha-2
                    sGuiasOrigemAddressDetail = r("AddressDetailCarga") 'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
                    sGuiasOrigemCity = r("CityCarga")
                    sGuiasOrigemPostalCode = r("PostalCodeCarga")
                    sGuiasOrigemCountry = r("CountryCarga") 'ISO 3166 - 1-alpha-2
                    sGuiasMovementStartTime = CDate(r("MovementStartTime")).ToString("s")  'AAAA-MM-DDThh:mm:ss
                    sGuiasATDocCodeID = r("ATDocCodeID")


                    writer.WriteStartElement("StockMovement") '423
                    writer.WriteElementString("DocumentNumber", sGuiasDocumentNumber) '423.1
                    writer.WriteStartElement("DocumentStatus") '423.2
                    writer.WriteElementString("MovementStatus", sGuiasMovementStatus) '4232.1
                    writer.WriteElementString("MovementStatusDate", sGuiasMovementStatusDate) '4232.2
                    writer.WriteElementString("SourceID", sGuiasAlteraSourceID) '4232.4
                    writer.WriteElementString("SourceBilling", sGuiasSourceBilling) '4232.5
                    writer.WriteEndElement() 'DocumentStatus
                    writer.WriteElementString("Hash", sGuiasHash) '423.3
                    writer.WriteElementString("HashControl", sGuiasHashControl) '423.4
                    writer.WriteElementString("MovementDate", sGuiasMovementDate) '423.6
                    writer.WriteElementString("MovementType", sGuiasMovementType) '423.7
                    writer.WriteElementString("SystemEntryDate", sGuiasSystemEntryDate) '423.8
                    'Select Case Trim(dtSaftCustomer.Rows(0)("TipoTerc").ToString)
                    Select Case Trim(r("TipoTerc")).ToString
                        Case "F"
                            writer.WriteElementString("SupplierID", sGuiasSupplierID) '423.10
                        Case "I", "C"   'TODO: CONFIRMAR SE OS MOV INTERNOS FICAM NO CAMPO CustomerID
                            writer.WriteElementString("CustomerID", sGuiasCustomerID) '423.11
                    End Select
                    writer.WriteElementString("SourceID", sGuiasCriaSourceID) '423.12
                    writer.WriteStartElement("ShipTo") '423.15
                    writer.WriteStartElement("Address") '42315.5
                    writer.WriteElementString("AddressDetail", sGuiasDestinoAddressDetail) '42315.3
                    writer.WriteElementString("City", sGuiasDestinoCity) '42315.4
                    writer.WriteElementString("PostalCode", sGuiasDestinoPostalCode) '42315.5
                    writer.WriteElementString("Country", sGuiasDestinoCountry) '42315.7
                    writer.WriteEndElement() 'Address
                    writer.WriteEndElement() 'ShipTo

                    writer.WriteStartElement("ShipFrom") '423.16
                    writer.WriteStartElement("Address") '42315.5
                    writer.WriteElementString("AddressDetail", sGuiasOrigemAddressDetail) '42316.3
                    writer.WriteElementString("City", sGuiasOrigemCity) '42316.4
                    writer.WriteElementString("PostalCode", sGuiasOrigemPostalCode) '42316.5
                    writer.WriteElementString("Country", sGuiasOrigemCountry) '42316.7
                    writer.WriteEndElement() 'Address
                    writer.WriteEndElement() 'ShipFrom

                    writer.WriteElementString("MovementStartTime", sGuiasMovementStartTime) '423.18
                    writer.WriteElementString("ATDocCodeID", sGuiasATDocCodeID) '423.19

                    'CRIAR CICLO COM AS LINHAS DO DOCUMENTO

                    dtSaftGuiaLinha.Clear()
                    Sql = "SELECT DocCab.IdDocCab, DocCab.ArmazemID, DocDet.DocLnNr, DocDet.ModeloID + DocDet.CorID AS Artigo, ModeloCor.ModCorDescr, DocDet.Qtd, DocDet.Unidade, DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA AS PrecoLiq, CONVERT(char(10), DocCab.DataDoc,126) DataDoc,  DocDet.Descricao, (DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd AS ValorLiq, TaxIVA.TxIVA * 100 AS TxIVA, DocDet.VlrDescLn / (1 + TaxIVA.TxIVA) AS TDescLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.Saft = 1) AND (DocCab.IdDocCab = '" & r("IdDocCab").ToString & "') ORDER BY DocDet.DocLnNr"
                    db.GetData(Sql, dtSaftGuiaLinha)

                    For Each Linha As DataRow In dtSaftGuiaLinha.Rows

                        sGuiasLineNumber = Linha("DocLnNr")
                        sGuiasProductCode = Linha("Artigo")
                        sGuiasProductDescription = Trim(Linha("ModCorDescr"))
                        iGuiasQuantity = Linha("Qtd")
                        sGuiasUnitOfMeasure = Linha("Unidade")
                        sGuiasDescription = Trim(Linha("Descricao"))

                        writer.WriteStartElement("Line")  '423.20
                        writer.WriteElementString("LineNumber", sGuiasLineNumber) '423.20.1
                        writer.WriteElementString("ProductCode", sGuiasProductCode)
                        writer.WriteElementString("ProductDescription", sGuiasProductDescription)
                        writer.WriteElementString("Quantity", iGuiasQuantity)
                        writer.WriteElementString("UnitOfMeasure", sGuiasUnitOfMeasure)
                        writer.WriteElementString("UnitPrice", sGuiasUnitPrice)
                        writer.WriteElementString("Description", sGuiasDescription) '423.20.8
                        writer.WriteElementString("CreditAmount", "0.00")  '??????
                        writer.WriteEndElement() 'Line

                    Next

                    writer.WriteStartElement("DocumentTotals")  '423.21
                    writer.WriteElementString("TaxPayable", sGuiasTaxPayable) '42321.1
                    writer.WriteElementString("NetTotal", sGuiasNetTotal)
                    writer.WriteElementString("GrossTotal", sGuiasGrossTotal)
                    'writer.WriteStartElement("Currency")
                    'writer.WriteElementString("CurrencyCode", sGuiasCurrencyCode)
                    'writer.WriteElementString("CurrencyAmount", sGuiasCurrencyAmount)
                    'writer.WriteEndElement() 'Currency
                    writer.WriteEndElement() 'DocumentTotals

                    writer.WriteEndElement() 'StockMovement


                Next

                writer.WriteEndElement() 'MovementOfGoods

            End If


            writer.WriteEndElement() 'SourceDocuments
            writer.WriteEndElement() 'AuditFile
            writer.Close()

            ValidarEsquema()


            Sql = "UPDATE DOCCAB SET SAFT = 0 WHERE SAFT = 1 OR SAFT IS NULL"
            db.ExecuteData(Sql)


            MsgBox("Totais: " & Chr(13) & "QtdDocs: " & QtdDocs & Chr(13) & "IVA: " & FormatCurrency(AUXIVA) & Chr(13) & "Crédito: " & FormatCurrency(AUXTOTLIQ_CREDITO) & Chr(13) & "Débito: " & FormatCurrency(AUXTOTLIQ_DEBITO * -1) & Chr(13) & "Bruto: " & FormatCurrency(AUXTOTBRUTO))
            MsgBox("Arquivo SAFT-PT gerado com sucesso.")


            Me.Cursor = Cursors.Default

            ClearMemory()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    'SAFT PARA MODELO/COR
    'Private Sub GeraSAFT()



    '    Dim db As New ClsSqlBDados
    '    Dim dtSaftHeader As New DataTable
    '    Dim dtSaftCustomer As New DataTable
    '    Dim dtSaftSupplier As New DataTable
    '    Dim dtSaftProduct As New DataTable
    '    Dim dtSaftTaxTable As New DataTable
    '    Dim dtSaftInvoice As New DataTable
    '    Dim dtSaftInvoiceLinha As New DataTable
    '    Dim dtSaftGuia As New DataTable
    '    Dim dtSaftGuiaLinha As New DataTable


    '    Try

    '        AUXIVA = 0
    '        AUXTOTLIQ = 0
    '        AUXTOTLIQ_CREDITO = 0
    '        AUXTOTLIQ_DEBITO = 0
    '        QtdDocs = 0
    '        AUXTOTBRUTO = 0

    '        'Sql = "UPDATE  DocCab SET  SAFT = 0"
    '        'db.ExecuteData(Sql)

    '        Sql = "SELECT COUNT(*) FROM DOCCAB WHERE SAFT = 1"
    '        If db.GetDataValue(Sql) > 0 Then
    '            MsgBox("Outro Ulilizador está a exportar P.F. Tente mais tarde!")
    '            Exit Sub
    '        End If

    '        Me.Cursor = Cursors.WaitCursor

    '        Sql = "SELECT  EmpNome + ' ' + EmpDesigna sCompanyName , EmpContrib, EmpNrRegisto, EmpMorada + ' nº' + EmpNumPolicia sAddressDetail, EmpCodPostal, EmpLocalidade, EmpTelefone, EmpFax FROM Empresas WHERE EmpresaID = '" & xEmp & "'"
    '        db.GetData(Sql, dtSaftHeader)


    '        'SELECIONAR DOCUMENTOS PARA EXPORTAR   

    '        If cbIncGuiasTransp.Checked = True Then
    '            Sql = "UPDATE DocCab SET SAFT = 1 WHERE TipoDocID in ('FS','NC','FT','ND','GT') AND (EmpresaID = '" & xEmp & "') AND (DataDoc >= CONVERT(DATETIME, '" & dpDeData.Value.ToString("yyyy-MM-dd") & "', 102)) AND (DataDoc < CONVERT(DATETIME, '" & dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") & "', 102))"
    '        Else
    '            Sql = "UPDATE DocCab SET SAFT = 1 WHERE TipoDocID in ('FS','NC','FT','ND') AND (EmpresaID = '" & xEmp & "') AND (DataDoc >= CONVERT(DATETIME, '" & dpDeData.Value.ToString("yyyy-MM-dd") & "', 102)) AND (DataDoc < CONVERT(DATETIME, '" & dpAteData.Value.AddDays(1).ToString("yyyy-MM-dd") & "', 102))"
    '        End If
    '        db.ExecuteData(Sql)


    '        'ALTERAR CAMINHO E NOME DO FICHEIRO
    '        Dim writer As New XmlTextWriter("C:\Girl\SAFT-PT\" & sNomeAux & ".xml", System.Text.Encoding.Default)

    '        'INICIA O DOCUMENTO XML
    '        writer.WriteStartDocument()


    '        'DEFINE A INDENTAÇÃO DO ARQUIVO
    '        writer.Formatting = Formatting.Indented

    '        'AuditFile NIVEL 1 
    '        writer.WriteStartElement("AuditFile")
    '        writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
    '        writer.WriteAttributeString("xmlns", "urn:OECD:StandardAuditFile-Tax:PT_1.03_01")


    '        'CARREGAR DADOS E VARIÁVEIS HEADER

    '        Dim sAuditFileVersion As String = "1.03_01" 'TEXTO 10
    '        Dim sCompanyID As String = "VNGAIA 509634060" 'TEXTO 50
    '        Dim iTaxRegistrationNumber As Int32 = dtSaftHeader.Rows(0)("EmpContrib") 'INTEIRO 9
    '        Dim sTaxAccountingBasis As String = "F" 'TEXTO 1
    '        Dim sCompanyName As String = dtSaftHeader.Rows(0)("sCompanyName") 'TEXTO 100 
    '        Dim sAddressDetail As String = dtSaftHeader.Rows(0)("sAddressDetail") 'TEXTO 100
    '        Dim sCity As String = Trim(dtSaftHeader.Rows(0)("EmpLocalidade")) 'TEXTO 50
    '        Dim sPostalCode As String = dtSaftHeader.Rows(0)("EmpCodPostal") 'TEXTO 8
    '        Dim sCountry As String = "PT" 'TEXTO 2
    '        Dim iFiscalYear As Int16 = Year(dpDeData.Value) 'INTEIRO 4
    '        Dim dStartDate As String = dpDeData.Value.ToString("yyyy-MM-dd")
    '        Dim dEndDate As String = dpAteData.Value.ToString("yyyy-MM-dd")
    '        Dim sCurrencyCode As String = "EUR" 'TEXTO 3
    '        Dim dDateCreated As String = Now().ToString("yyyy-MM-dd")
    '        Dim sTaxEntity As String = "Global" 'TEXTO 20
    '        Dim sProductCompanyTaxID As String = "507687213" 'TEXTO 20  NIF DA ENTIDADE PRODUTORA SOFTWARE
    '        Dim sSoftwareCertificateNumber As String = "0" 'TEXTO 20
    '        Dim sProductID As String = "CELFERI/Grande Enigma" 'TEXTO 255
    '        Dim sProductVersion As String = "1.0" 'TEXTO 30
    '        Dim sEmpTelefone As String = dtSaftHeader.Rows(0)("EmpTelefone") 'TEXTO 20
    '        Dim sEmpFax As String = dtSaftHeader.Rows(0)("EmpFax") 'TEXTO 20


    '        '   Header NIVEL 2 
    '        writer.WriteStartElement("Header")
    '        writer.WriteElementString("AuditFileVersion", sAuditFileVersion)
    '        writer.WriteElementString("CompanyID", sCompanyID)
    '        writer.WriteElementString("TaxRegistrationNumber", iTaxRegistrationNumber)
    '        writer.WriteElementString("TaxAccountingBasis", sTaxAccountingBasis)
    '        writer.WriteElementString("CompanyName", sCompanyName)

    '        writer.WriteStartElement("CompanyAddress")
    '        writer.WriteElementString("AddressDetail", sAddressDetail)
    '        writer.WriteElementString("City", sCity)
    '        writer.WriteElementString("PostalCode", sPostalCode)
    '        writer.WriteElementString("Country", sCountry)
    '        writer.WriteEndElement()  'CompanyAddress

    '        writer.WriteElementString("FiscalYear", iFiscalYear)
    '        writer.WriteElementString("StartDate", dStartDate)
    '        writer.WriteElementString("EndDate", dEndDate)
    '        writer.WriteElementString("CurrencyCode", sCurrencyCode)
    '        writer.WriteElementString("DateCreated", dDateCreated)
    '        writer.WriteElementString("TaxEntity", sTaxEntity)
    '        writer.WriteElementString("ProductCompanyTaxID", sProductCompanyTaxID)
    '        writer.WriteElementString("SoftwareCertificateNumber", sSoftwareCertificateNumber)
    '        writer.WriteElementString("ProductID", sProductID)
    '        writer.WriteElementString("ProductVersion", sProductVersion)
    '        writer.WriteElementString("Telephone", sEmpTelefone)
    '        writer.WriteElementString("Fax", sEmpFax)

    '        writer.WriteEndElement() 'Header

    '        '   MasterFiles NIVEL 2 
    '        writer.WriteStartElement("MasterFiles")


    '        'Sql = "SELECT RTRIM(LTRIM(TERCEIROS.TerceiroID)) AS TerceiroID, TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID FROM (SELECT('T') + TercID AS TerceiroID, TipoTerc, Nome, Morada, CodPostal, Localidade, NIF, PaisID, DistritoID, TercID FROM Terceiros AS Terceiros_1 UNION SELECT STR(ClienteLojaID) AS TerceiroID, 'L' AS TipoTerc, Nome, Morada, Localidade, CodPostal, NIF, PaisID, DistritoID, ClienteLojaID AS TercID FROM ClientesLoja) AS TERCEIROS INNER JOIN DocCab ON TERCEIROS.TercID = DocCab.TercID WHERE (DocCab.SAFT = 1) GROUP BY RTRIM(LTRIM(TERCEIROS.TerceiroID)), TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID"
    '        Sql = "SELECT RTRIM(LTRIM(TERCEIROS.TerceiroID)) AS TerceiroID, TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID FROM (SELECT 'T' + TercID AS TerceiroID, TipoTerc, Nome, Morada, CodPostal, Localidade, NIF, PaisID, DistritoID, TercID FROM Terceiros AS Terceiros_1 UNION SELECT STR(ClienteLojaID) AS TerceiroID, 'L' AS TipoTerc, Nome, Morada, Localidade, CodPostal, NIF, PaisID, DistritoID, ClienteLojaID AS TercID FROM ClientesLoja) AS TERCEIROS INNER JOIN DocCab ON TERCEIROS.TercID = DocCab.TercID WHERE (DocCab.SAFT = 1) GROUP BY RTRIM(LTRIM(TERCEIROS.TerceiroID)), TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID HAVING (TERCEIROS.TipoTerc <> 'F')"
    '        db.GetData(Sql, dtSaftCustomer, False)


    '        Dim sCustomerID As String = "1"
    '        Dim sAccountID As String = "Desconhecido"
    '        Dim sCustomerTaxID As String = "999999990"
    '        Dim sCompanyNameCli As String = "Consumidor final"
    '        Dim sAddressDetailCli As String = "Desconhecido"
    '        Dim sCityCli As String = "Desconhecido"
    '        Dim sPostalCodeCli As String = "Desconhecido"
    '        Dim sCountryCli As String = "Desconhecido"
    '        Dim iSelfBillingIndicatorCli As Int16 = 0


    '        For Each lCustomer As DataRow In dtSaftCustomer.Rows

    '            If lCustomer("TerceiroID") = "0" Then sCustomerID = "0000" Else sCustomerID = lCustomer("TerceiroID").ToString
    '            sAccountID = "Desconhecido"
    '            sCustomerTaxID = IIf(Trim(lCustomer("NIF")) = "" Or Trim(lCustomer("NIF")) = "xxxxxxxxx", "999999990", lCustomer("NIF"))
    '            sCompanyNameCli = IIf(Trim(lCustomer("Nome")) = "", "Desconhecido", lCustomer("Nome"))
    '            sAddressDetailCli = IIf(Trim(lCustomer("Morada")) = "", "Desconhecido", lCustomer("Morada"))
    '            sCityCli = IIf(Trim(lCustomer("Localidade")) = "", "Desconhecido", lCustomer("Localidade"))
    '            sPostalCodeCli = IIf(Trim(lCustomer("CodPostal")) = "", "Desconhecido", lCustomer("CodPostal"))
    '            sCountryCli = IIf(Trim(lCustomer("PaisId")) = "", "Desconhecido", lCustomer("PaisId"))
    '            iSelfBillingIndicatorCli = 0

    '            '    Customer NIVEL 3 
    '            writer.WriteStartElement("Customer")
    '            writer.WriteElementString("CustomerID", sCustomerID)
    '            writer.WriteElementString("AccountID", sAccountID)
    '            writer.WriteElementString("CustomerTaxID", sCustomerTaxID)
    '            writer.WriteElementString("CompanyName", sCompanyNameCli)
    '            writer.WriteStartElement("BillingAddress")
    '            writer.WriteElementString("AddressDetail", sAddressDetailCli)
    '            writer.WriteElementString("City", sCityCli)
    '            writer.WriteElementString("PostalCode", sPostalCodeCli)
    '            writer.WriteElementString("Country", sCountryCli)
    '            writer.WriteEndElement() 'BillingAddress
    '            writer.WriteElementString("SelfBillingIndicator", iSelfBillingIndicatorCli)
    '            writer.WriteEndElement() 'Customer

    '        Next



    '        'FORNECEDOR
    '        Sql = "SELECT RTRIM(LTRIM(TERCEIROS.TerceiroID)) AS TerceiroID, TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID FROM (SELECT 'T' + TercID AS TerceiroID, TipoTerc, Nome, Morada, CodPostal, Localidade, NIF, PaisID, DistritoID, TercID FROM Terceiros AS Terceiros_1 UNION SELECT STR(ClienteLojaID) AS TerceiroID, 'L' AS TipoTerc, Nome, Morada, Localidade, CodPostal, NIF, PaisID, DistritoID, ClienteLojaID AS TercID FROM ClientesLoja) AS TERCEIROS INNER JOIN DocCab ON TERCEIROS.TercID = DocCab.TercID WHERE (DocCab.SAFT = 1) GROUP BY RTRIM(LTRIM(TERCEIROS.TerceiroID)), TERCEIROS.TercID, TERCEIROS.TipoTerc, TERCEIROS.Nome, TERCEIROS.Morada, TERCEIROS.CodPostal, TERCEIROS.Localidade, TERCEIROS.NIF, TERCEIROS.PaisID, TERCEIROS.DistritoID HAVING (TERCEIROS.TipoTerc = 'F')"
    '        db.GetData(Sql, dtSaftSupplier, False)


    '        Dim sSupplierID As String = "1"
    '        Dim sAccountIDSup As String = "Desconhecido"
    '        Dim sSupplierTaxID As String = "999999990"
    '        Dim sCompanyNameSup As String = "Consumidor final"
    '        Dim sAddressDetailSup As String = "Desconhecido"
    '        Dim sCitySup As String = "Desconhecido"
    '        Dim sPostalCodeSup As String = "Desconhecido"
    '        Dim sCountrySup As String = "Desconhecido"
    '        Dim iSelfBillingIndicatorSup As Int16 = 0


    '        For Each lSupplier As DataRow In dtSaftSupplier.Rows

    '            If lSupplier("TerceiroID") = "0" Then sSupplierID = "0000" Else sSupplierID = lSupplier("TerceiroID").ToString
    '            sAccountIDSup = "Desconhecido"
    '            sSupplierTaxID = IIf(Trim(lSupplier("NIF")) = "", "999999990", lSupplier("NIF"))
    '            sCompanyNameSup = IIf(Trim(lSupplier("Nome")) = "", "Desconhecido", lSupplier("Nome"))
    '            sAddressDetailSup = IIf(Trim(lSupplier("Morada")) = "", "Desconhecido", lSupplier("Morada"))
    '            sCitySup = IIf(Trim(lSupplier("Localidade")) = "", "Desconhecido", lSupplier("Localidade"))
    '            sPostalCodeSup = IIf(Trim(lSupplier("CodPostal")) = "", "Desconhecido", lSupplier("CodPostal"))
    '            sCountrySup = IIf(Trim(lSupplier("PaisId")) = "", "", lSupplier("PaisId"))
    '            iSelfBillingIndicatorSup = 0

    '            '    Supplier NIVEL 3 
    '            writer.WriteStartElement("Supplier")
    '            writer.WriteElementString("SupplierID", sSupplierID)
    '            writer.WriteElementString("AccountID", sAccountIDSup)
    '            writer.WriteElementString("SupplierTaxID", sSupplierTaxID)
    '            writer.WriteElementString("CompanyName", sCompanyNameSup)
    '            writer.WriteStartElement("BillingAddress")
    '            writer.WriteElementString("AddressDetail", sAddressDetailSup)
    '            writer.WriteElementString("City", sCitySup)
    '            writer.WriteElementString("PostalCode", sPostalCodeSup)
    '            writer.WriteElementString("Country", sCountrySup)
    '            writer.WriteEndElement() 'BillingAddress
    '            writer.WriteElementString("SelfBillingIndicator", iSelfBillingIndicatorSup)
    '            writer.WriteEndElement() 'Supplier

    '        Next


    '        'Sql = "SELECT DocDet.ModeloID + DocDet.CorID AS Artigo, RTRIM(ModeloCor.ModCorDescr) ModCorDescr FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.Saft = 1) GROUP BY DocDet.ModeloID + DocDet.CorID, ModeloCor.ModCorDescr ORDER BY Artigo"
    '        Sql = "SELECT DocDet.ModeloID + DocDet.CorID AS Artigo, RTRIM(ModeloCor.ModCorDescr) AS ModCorDescr, Modelos.TipoID FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID WHERE (DocCab.SAFT = 1) GROUP BY DocDet.ModeloID + DocDet.CorID, ModeloCor.ModCorDescr, Modelos.TipoID ORDER BY Artigo"

    '        db.GetData(Sql, dtSaftProduct)


    '        Dim sProductType As String = "P"   '"S" PARA SERVIÇO
    '        Dim sProductCode As String = "8700001"
    '        Dim sProductDescription As String = "Sapato de Criança Preto"
    '        Dim sProductNumberCode As String = "8700001"

    '        For Each lProduct As DataRow In dtSaftProduct.Rows

    '            sProductType = "P"
    '            'ALTERAR O VALOR DO PARAMETO sProductType PARA CASOS PARTICULARES

    '            Select Case Trim(lProduct("Artigo"))

    '                Case "0010099" 'FORRAR SALTOS
    '                    sProductType = "S"
    '                Case "0010098" 'CORTAR PELE MANUAL
    '                    sProductType = "S"
    '                Case "0010001" 'ADIANTAMENTO DE CLIENTES
    '                    sProductType = "O"
    '                Case "0010002" 'PORTES DE ENVIO
    '                    sProductType = "O"
    '                Case "0010003" 'ALIENAÇÃO DE ATIVOS
    '                    sProductType = "O"

    '            End Select


    '            sProductCode = lProduct("Artigo")
    '            sProductDescription = Trim(lProduct("ModCorDescr"))
    '            sProductNumberCode = lProduct("Artigo")

    '            writer.WriteStartElement("Product")
    '            writer.WriteElementString("ProductType", sProductType)
    '            writer.WriteElementString("ProductCode", sProductCode)
    '            writer.WriteElementString("ProductDescription", sProductDescription)
    '            writer.WriteElementString("ProductNumberCode", sProductNumberCode)
    '            writer.WriteEndElement() 'Product


    '        Next


    '        'TODO: **********  PASSAR A DINÂMICO    ***********
    '        '       TAXTABLE NIVEL 3 
    '        writer.WriteStartElement("TaxTable")
    '        writer.WriteStartElement("TaxTableEntry")
    '        writer.WriteElementString("TaxType", "IVA")
    '        writer.WriteElementString("TaxCountryRegion", "PT-MA")
    '        writer.WriteElementString("TaxCode", "NOR")
    '        writer.WriteElementString("Description", "IVA taxa normal")
    '        writer.WriteElementString("TaxPercentage", "22.00")
    '        writer.WriteEndElement() 'TaxTableEntry (1)
    '        writer.WriteStartElement("TaxTableEntry")
    '        writer.WriteElementString("TaxType", "IVA")
    '        writer.WriteElementString("TaxCountryRegion", "PT")
    '        writer.WriteElementString("TaxCode", "NOR")
    '        writer.WriteElementString("Description", "IVA taxa normal")
    '        writer.WriteElementString("TaxPercentage", "23.00")
    '        writer.WriteEndElement() 'TaxTableEntry (2)
    '        writer.WriteEndElement() 'TaxTable

    '        writer.WriteEndElement() 'MasterFiles


    '        'CARREGAR DADOS E VARIÁVEIS SalesInvoices

    '        '   SourceDocuments NIVEL 2
    '        writer.WriteStartElement("SourceDocuments")


    '        Sql = "SELECT COUNT(*) AS NumberOfEntries FROM DocCab WHERE Saft = 1 AND TipoDocID in ('FS','NC','FT','ND')"
    '        Dim iNumberOfEntries As Int32 = db.GetDataValue(Sql)

    '        Sql = "SELECT ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),0) AS TotalDebit FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE DocCab.Saft = 1 AND DocCab.EstadoDoc<>'A' AND DocCab.TipoDocID = 'NC'"
    '        Dim dTotalDebit As Double = Arredondamento(db.GetDataValue(Sql), 2)

    '        Sql = "SELECT ISNULL(SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd),0) AS TotalCredit FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE DocCab.Saft = 1 AND DocCab.EstadoDoc<>'A' AND DocCab.TipoDocID IN ('FS','FT','ND')"
    '        Dim dTotalCredit As Double = Arredondamento(db.GetDataValue(Sql), 2)


    '        writer.WriteStartElement("SalesInvoices")
    '        writer.WriteElementString("NumberOfEntries", iNumberOfEntries)
    '        writer.WriteElementString("TotalDebit", dTotalDebit)
    '        writer.WriteElementString("TotalCredit", dTotalCredit)


    '        Dim sInvoiceNo As String = ""
    '        Dim sInvoiceStatus As String
    '        Dim dInvoiceStatusDate As String
    '        'Dim dInvoiceStatusDateAux As Date
    '        Dim sHash As String
    '        Dim sHashControl As String
    '        Dim dInvoiceDate As String
    '        'Dim dInvoiceDateAux As Date
    '        Dim sInvoiceType As String
    '        Dim iSelfBillingIndicator As Int16
    '        Dim iCashVATSchemeIndicator As Int16
    '        Dim iThirdPartiesBillingIndicator As Int16
    '        Dim sDocAlteraSourceID As String
    '        Dim sDocCriaSourceID As String



    '        Dim dSystemEntryDate As String
    '        'Dim dSystemEntryDateAux As Date
    '        Dim sCustomerIDInv As String = ""

    '        'TOTAIS DO DOCUMENTO
    '        Dim dTaxPayable As Double = 0
    '        Dim dNetTotal As Double = 0
    '        Dim dGrossTotal As Double = 0
    '        'Dim sCurrencyCode1 As String = ""
    '        Dim dCurrencyAmount As Double = 0


    '        'VARIAVEIS DE LINHA
    '        Dim sArmazemID As String = ""
    '        Dim iLineNumber As Int32 = 1
    '        Dim sDocOrig As String
    '        Dim dOrderDate As String
    '        Dim sProductCodeLinha As String = "87000"
    '        Dim sProductDescriptionLinha As String = "Sapato de Criança"
    '        Dim dQuantity As Double = 99
    '        Dim sUnitOfMeasure As String = "Par"
    '        Dim dUnitPrice As Double = 19.9
    '        Dim sTaxPointDate As String = "2013-01-01"   'DATA DO ENVIO DO PRODUTO OU DA PRESTAÇÃO DE SERVIÇO
    '        Dim sDescription As String = "Sapato de Criança"
    '        'Dim dDebitAmount As Double = 19.9
    '        'Dim dCreditAmount As Double = 0
    '        Dim dAmount As Double = 0
    '        Dim sTaxType As String = "IVA"
    '        Dim sTaxCountryRegion As String = "PT"
    '        Dim sTaxCode As String = "NOR"
    '        Dim dTaxPercentage As Double = 23.0
    '        Dim dSettlementAmount As Double = 0

    '        Dim sPaymentMechanism As String = "NU"
    '        Dim dPaymentAmount As Double = 0
    '        Dim sPaymentDate As String


    '        'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, 'FT' TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.Saft = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
    '        'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA , DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.Saft = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
    '        'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.SAFT = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig HAVING DocCab.TipoDocID IN ('FT','FS','NC','ND') ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
    '        'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr LEFT OUTER JOIN FormaPagamento ON DocCab.FormaPagtoID = FormaPagamento.FormaPagtoID WHERE (DocCab.SAFT = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev HAVING (DocCab.TipoDocID IN ('FT', 'FS', 'NC')) ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"
    '        Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, SUM((DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd) AS TotalSIVA, SUM(DocDet.VlrIVA * DocDet.Qtd) AS TotalIVA, SUM((DocDet.Valor - DocDet.VlrDescLn) * DocDet.Qtd) AS TotalCIVA, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev, Utilizadores.NomeUtilizador FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Utilizadores ON DocCab.UtilizadorID = Utilizadores.UtilizadorID LEFT OUTER JOIN FormaPagamento ON DocCab.FormaPagtoID = FormaPagamento.FormaPagtoID WHERE (DocCab.SAFT = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, DocCab.DocOrig, DocCab.IdDocCabOrig, FormaPagamento.FPDescrAbrev, Utilizadores.NomeUtilizador HAVING (DocCab.TipoDocID IN ('FT', 'FS', 'NC')) ORDER BY DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr"



    '        db.GetData(Sql, dtSaftInvoice)

    '        For Each r As DataRow In dtSaftInvoice.Rows



    '            sInvoiceNo = Trim(r("TipoDocID")) & " " & Microsoft.VisualBasic.Left(r("DocNr"), 2) & Microsoft.VisualBasic.Right(r("ArmazemID"), 2) & "/" & Microsoft.VisualBasic.Right(r("DocNr"), 5)
    '            'FORMATO DA sInvoiceNo "FS 1013/00001"

    '            If RTrim(LTrim(r("EstadoDoc"))) = "A" Then sInvoiceStatus = "A" Else sInvoiceStatus = "N" '  N-NORMAL   OU   A-ANULADA
    '            'dInvoiceStatusDateAux = r("DtUltAlt")
    '            'dInvoiceStatusDate = dInvoiceStatusDateAux.ToString("s")
    '            dInvoiceStatusDate = CDate(r("DtUltAlt")).ToString("s")
    '            sHash = r("Hash")
    '            sHashControl = r("ChavePrivadaVersao")
    '            'dInvoiceDateAux = r("DataDoc")
    '            'dInvoiceDate = Microsoft.VisualBasic.Left(dInvoiceDateAux.ToString("s"), 10)
    '            ''dInvoiceDate = CDate(r("DataDoc")).ToString("s")
    '            'dInvoiceDate = Microsoft.VisualBasic.Left(CDate(r("DataDoc")).ToString("s"), 10)
    '            dInvoiceDate = CDate(r("DataDoc")).ToString("yyyy-MM-dd")
    '            sInvoiceType = r("TipoDocID")

    '            iSelfBillingIndicator = 0
    '            iCashVATSchemeIndicator = 0
    '            iThirdPartiesBillingIndicator = 0
    '            sDocAlteraSourceID = Trim(r("NomeUtilizador")) 'A Aplicação não permite alterar documentos
    '            sDocCriaSourceID = Trim(r("NomeUtilizador"))



    '            'dSystemEntryDateAux = r("DataDoc")
    '            'dSystemEntryDate = dSystemEntryDateAux.ToString("s")
    '            dSystemEntryDate = CDate(r("DataDoc")).ToString("s")
    '            'dSystemEntryDate = "2013-01-11T10:04:27"


    '            'DOCUMENTO DE ORIGEM
    '            sDocOrig = r("DocOrig")

    '            Select Case sInvoiceType
    '                Case "FS"
    '                    sCustomerIDInv = r("TercID")
    '                Case "NC"
    '                    If r("ArmazemID") = "0000" Then
    '                        sCustomerIDInv = "T" + r("TercID")
    '                    Else
    '                        sCustomerIDInv = r("TercID")
    '                    End If

    '                Case "FT"
    '                    sCustomerIDInv = "T" + r("TercID")
    '            End Select


    '            'Now.Date.ToString("yyyy-MM-dd")
    '            'Me.DateTimePicker3.Value.ToString("yyyy-MM-dd")

    '            'ALTERAR PARA CDate(r("DataDoc")).ToString("s")

    '            writer.WriteStartElement("Invoice")
    '            writer.WriteElementString("InvoiceNo", sInvoiceNo)
    '            writer.WriteStartElement("DocumentStatus")
    '            writer.WriteElementString("InvoiceStatus", sInvoiceStatus)
    '            writer.WriteElementString("InvoiceStatusDate", dInvoiceStatusDate)
    '            writer.WriteElementString("SourceID", sDocAlteraSourceID)  '4.1.4.2.4 - UTILIZADOR RESPONSAVEL PELO ACTUAL ESTADO DO DOCUMENTO
    '            writer.WriteElementString("SourceBilling", "P") 'TODO: "M" SE PROVENIENTE E RECUPERAÇÃO MANUAL...
    '            writer.WriteEndElement() 'DocumentStatus

    '            writer.WriteElementString("Hash", sHash)
    '            writer.WriteElementString("HashControl", sHashControl)
    '            writer.WriteElementString("InvoiceDate", dInvoiceDate)
    '            writer.WriteElementString("InvoiceType", sInvoiceType)

    '            writer.WriteStartElement("SpecialRegimes")
    '            writer.WriteElementString("SelfBillingIndicator", iSelfBillingIndicator)
    '            writer.WriteElementString("CashVATSchemeIndicator", iCashVATSchemeIndicator)
    '            writer.WriteElementString("ThirdPartiesBillingIndicator", iThirdPartiesBillingIndicator)
    '            writer.WriteEndElement() 'SpecialRegimes

    '            writer.WriteElementString("SourceID", sDocCriaSourceID)  '4.1.4.9 - Utilizador que gerou o documento 
    '            writer.WriteElementString("SystemEntryDate", dSystemEntryDate)
    '            writer.WriteElementString("CustomerID", sCustomerIDInv)
    '            'writer.WriteStartElement("ShipTo")
    '            'writer.WriteEndElement() 'ShipTo
    '            'writer.WriteStartElement("ShipFrom")
    '            'writer.WriteEndElement() 'ShipFrom



    '            'CRIAR CICLO COM AS LINHAS DO DOCUMENTO

    '            dtSaftInvoiceLinha.Clear()
    '            Sql = "SELECT DocCab.IdDocCab, DocCab.ArmazemID, DocDet.DocLnNr, DocDet.ModeloID + DocDet.CorID AS Artigo, ModeloCor.ModCorDescr, DocDet.Qtd, DocDet.Unidade, DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA AS PrecoLiq, CONVERT(char(10), DocCab.DataDoc,126) AS DataDoc,  DocDet.Descricao, (DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd AS ValorLiq, TaxIVA.TxIVA * 100 AS TxIVA, DocDet.VlrDescLn / (1 + TaxIVA.TxIVA) * DocDet.Qtd AS TDescLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.Saft = 1) AND (DocCab.IdDocCab = '" & r("IdDocCab").ToString & "') ORDER BY DocDet.DocLnNr"
    '            db.GetData(Sql, dtSaftInvoiceLinha)

    '            For Each Linha As DataRow In dtSaftInvoiceLinha.Rows
    '                If Linha("ValorLiq") > 0 Then
    '                    sArmazemID = Linha("ArmazemID")
    '                    iLineNumber = Linha("DocLnNr")
    '                    sProductCodeLinha = Linha("Artigo")
    '                    sProductDescriptionLinha = Trim(Linha("ModCorDescr"))
    '                    dQuantity = Linha("Qtd")
    '                    sUnitOfMeasure = Linha("Unidade")
    '                    dUnitPrice = Arredondamento(Linha("PrecoLiq"), 2) 'PASSEI PARA DUAS CASAS DECIMAIS (ESTAVAM 4)
    '                    sTaxPointDate = Linha("DataDoc")
    '                    sDescription = Trim(Linha("Descricao"))
    '                    dAmount = Arredondamento(Linha("ValorLiq"), 2)
    '                    sTaxType = "IVA"
    '                    'TODO: HÁ ERROS NOS DOCS DA MADEIRA EM RELAÇÃO AO IVA - ESTUDAR O MOTIVO - INCOERENCIA NOS DADOS EXPORTADOS PARA O SAFT!!!!
    '                    'TXIVA = 0 ????   IVAID=5 NA C-10????
    '                    Select Case sArmazemID  'TODO: POR ESTA VARIAVEL DINÂMICA 
    '                        Case "0002", "0010"
    '                            sTaxCountryRegion = "PT-MA"
    '                        Case Else
    '                            sTaxCountryRegion = "PT"
    '                    End Select
    '                    sTaxCode = "NOR"
    '                    dTaxPercentage = Linha("TxIVA")
    '                    dSettlementAmount = Arredondamento(Linha("TDescLiq"), 2)

    '                    writer.WriteStartElement("Line")
    '                    writer.WriteElementString("LineNumber", iLineNumber)
    '                    writer.WriteElementString("ProductCode", sProductCodeLinha)
    '                    writer.WriteElementString("ProductDescription", sProductDescriptionLinha)
    '                    writer.WriteElementString("Quantity", dQuantity)
    '                    writer.WriteElementString("UnitOfMeasure", sUnitOfMeasure)
    '                    writer.WriteElementString("UnitPrice", dUnitPrice)
    '                    writer.WriteElementString("TaxPointDate", sTaxPointDate)

    '                    If Len(sDocOrig) > 0 Then
    '                        Sql = "SELECT DataDoc from DocCab WHERE IdDocCab='" & r("IdDocCabOrig").ToString & "'"
    '                        dOrderDate = db.GetDataValue(Sql)
    '                        dOrderDate = CDate(dOrderDate).ToString("yyyy-MM-dd")
    '                        writer.WriteStartElement("References")
    '                        writer.WriteElementString("Reference", sDocOrig)
    '                        writer.WriteEndElement() 'References
    '                    End If

    '                    writer.WriteElementString("Description", sDescription)
    '                    Select Case sInvoiceType    'POSSO PASSAR A USAR O CAMPO MOVFIN DA TABELA TIPODOC
    '                        Case "NC"
    '                            writer.WriteElementString("DebitAmount", dAmount) '4.1.4.18.11
    '                            'AS LINHAS NEGATIVAS NAS FS ENTRA NO DebitAmount  
    '                        Case "FS", "FT", "ND"
    '                            writer.WriteElementString("CreditAmount", dAmount)
    '                    End Select
    '                    writer.WriteStartElement("Tax")
    '                    writer.WriteElementString("TaxType", sTaxType)
    '                    writer.WriteElementString("TaxCountryRegion", sTaxCountryRegion)
    '                    writer.WriteElementString("TaxCode", sTaxCode)
    '                    writer.WriteElementString("TaxPercentage", dTaxPercentage)
    '                    writer.WriteEndElement() 'Tax
    '                    writer.WriteElementString("SettlementAmount", dSettlementAmount)
    '                    writer.WriteEndElement() 'Line
    '                End If
    '            Next

    '            dTaxPayable = Arredondamento(r("TotalIVA"), 2)
    '            dNetTotal = Arredondamento(r("TotalSIVA"), 2)
    '            dGrossTotal = Arredondamento(r("TotalCIVA"), 2)
    '            'sCurrencyCode1 = "EUR"
    '            dCurrencyAmount = Arredondamento(r("TotalCIVA"), 2)

    '            writer.WriteStartElement("DocumentTotals")
    '            writer.WriteElementString("TaxPayable", dTaxPayable)
    '            writer.WriteElementString("NetTotal", dNetTotal)
    '            writer.WriteElementString("GrossTotal", dGrossTotal)
    '            'writer.WriteStartElement("Currency")
    '            'writer.WriteElementString("CurrencyCode", sCurrencyCode1)
    '            ''writer.WriteElementString("CurrencyAmount", dCurrencyAmount)   'NOVA VERSÃO???   NA PAG 6735 DA PORTARIA 382/2012 ESTÁ ASSIM!!!!!
    '            'writer.WriteElementString("CurrencyAmount", dCurrencyAmount)
    '            ''writer.WriteElementString("CurrencyDebitAmount", dCurrencyAmount) NA VERSÃO DE 23-04-2013 VOLTOU A DAR ERRO
    '            'writer.WriteEndElement() 'Currency

    '            sPaymentMechanism = "NU"  'TODO: PASSAR A DINÂMICO  SÓ ESTÁ A PERMITIR UMA FORMA DE PAG./DOC
    '            If r("FPDescrAbrev") = "MB" Then sPaymentMechanism = "MB"
    '            dPaymentAmount = dGrossTotal
    '            sPaymentDate = dInvoiceDate

    '            writer.WriteStartElement("Payment")
    '            writer.WriteElementString("PaymentMechanism", sPaymentMechanism)
    '            writer.WriteElementString("PaymentAmount", dPaymentAmount)
    '            writer.WriteElementString("PaymentDate", sPaymentDate)
    '            writer.WriteEndElement() 'Payment


    '            writer.WriteEndElement() 'DocumentTotals
    '            writer.WriteEndElement() 'Invoice




    '            Select Case sInvoiceType    'TODO: POSSO PASSAR A USAR O CAMPO MOVFIN DA TABELA TIPODOC
    '                Case "NC"
    '                    AUXIVA = AUXIVA - dTaxPayable
    '                    AUXTOTLIQ = AUXTOTLIQ - dNetTotal
    '                    AUXTOTLIQ_DEBITO = AUXTOTLIQ_DEBITO - dNetTotal
    '                    AUXTOTBRUTO = AUXTOTBRUTO - dGrossTotal
    '                Case "FS", "FT", "ND"
    '                    AUXIVA = AUXIVA + dTaxPayable
    '                    AUXTOTLIQ = AUXTOTLIQ + dNetTotal
    '                    AUXTOTLIQ_CREDITO = AUXTOTLIQ_CREDITO + dNetTotal
    '                    AUXTOTBRUTO = AUXTOTBRUTO + dGrossTotal
    '            End Select



    '            QtdDocs = QtdDocs + 1
    '        Next

    '        writer.WriteEndElement() 'SalesInvoices





    '        'GUIAS DE TRANSPORTE

    '        'NOTA : NÃO ESTOU A IR BUSCAR OS DOCUMENTOS DE ORIGEM NAS GUIAS DE TRANSPORTE



    '        Sql = "SELECT COUNT(*) FROM DocCab WHERE (DocCab.SAFT = 1) AND DocCab.TipoDocID in ('GT')"
    '        If cbIncGuiasTransp.Checked = True And db.GetDataValue(Sql) > 0 Then

    '            writer.WriteStartElement("MovementOfGoods")

    '            Sql = "SELECT COUNT(DocDet.DocLnNr) AS iNumberOfMovementLines FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.SAFT = 1) AND DocCab.TipoDocID in ('GT')"
    '            Dim iNumberOfMovementLines As Int32 = db.GetDataValue(Sql)

    '            Sql = "SELECT SUM(DocDet.Qtd) AS dTotalQuantityIssued FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.SAFT = 1)  AND DocCab.TipoDocID in ('GT')"
    '            Dim dTotalQuantityIssued As Double = db.GetDataValue(Sql)

    '            writer.WriteElementString("NumberOfMovementLines", iNumberOfMovementLines)
    '            writer.WriteElementString("TotalQuantityIssued", dTotalQuantityIssued)


    '            Dim sGuiasDocumentNumber As String   '  GT 1302/00001  MAX 60 carateres
    '            'Dim sGuiasDocumentStatus As String  '???
    '            Dim sGuiasMovementStatus As String 'N - NORMAL A - ANULADO
    '            Dim sGuiasMovementStatusDate As String  'AAAA-MM-DDThh:mm:ss
    '            Dim sGuiasAlteraSourceID As String 'UTILIZADOR RESP. PELO ESTADO ACTUAL DO DOCUMENTO
    '            Dim sGuiasSourceBilling As String 'P - DOC PRODUZIDO PELA APLICAÇÃO   M - DOC. PROV DE RECUPERAÇÃO MANUAL
    '            Dim sGuiasHash As String
    '            Dim sGuiasHashControl As String
    '            Dim sGuiasMovementDate As String 'DATA DE EMISSÃO DO DOCUMENTO DE TRANSPORTE
    '            Dim sGuiasMovementType As String ' GR, GT, GC, GD
    '            Dim sGuiasSystemEntryDate As String 'AAAA-MM-DDThh:mm:ss
    '            Dim sGuiasCustomerID As String 'SE O DESTINATÁRIO FOR O PRÓPRIO COLOCAR O CLIENTE GENÉRICO
    '            Dim sGuiasSupplierID As String 'DEVOLUÇÕES OU SUBCONTRATO
    '            Dim sGuiasCriaSourceID As String 'UTILIZADOR RESP. PELA CRIAÇÃO DO DOCUMENTO
    '            Dim sGuiasDestinoAddressDetail As String 'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
    '            Dim sGuiasDestinoCity As String
    '            Dim sGuiasDestinoPostalCode As String
    '            Dim sGuiasDestinoCountry As String   'ISO 3166 - 1-alpha-2
    '            Dim sGuiasOrigemAddressDetail As String 'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
    '            Dim sGuiasOrigemCity As String
    '            Dim sGuiasOrigemPostalCode As String
    '            Dim sGuiasOrigemCountry As String   'ISO 3166 - 1-alpha-2
    '            Dim sGuiasMovementStartTime As String    'AAAA-MM-DDThh:mm:ss
    '            Dim sGuiasATDocCodeID As String



    '            Dim sGuiasLineNumber As Int16  'MANTER A ORDEM DAS LINHAS
    '            Dim sGuiasProductCode As String ' CÓDIGO DO PRODUTO
    '            Dim sGuiasProductDescription As String ' DESCRIÇÃO DA TABELA DE PRODUTOS
    '            Dim iGuiasQuantity As Int16
    '            Dim sGuiasUnitOfMeasure As String
    '            Dim sGuiasUnitPrice As String = "0.0000"    'SE A GUIA NÃO LEVA VALORIZADA COLOCAR 0.00 
    '            Dim sGuiasDescription As String 'DESCRIÇÃO DA LINHA DE DOCUMENTO   MAX : 60
    '            'Dim sGuiasTaxType As String = "IVA"
    '            'Dim sGuiasTaxCountryRegion As String 'ISO 3166 -1-alpha-2 : PT ou PT-MA ou PT-MA
    '            'Dim sGuiasTaxCode As String = "NORMAL"
    '            'Dim dGuiasTaxPercentage As Double 'TAXA IMPOSTO RELATIVA AO PRODUTO   'CONFIRMAR!!!!!!!!
    '            Dim sGuiasTaxPayable As String = "0.00"
    '            Dim sGuiasNetTotal As String = "0.00"
    '            Dim sGuiasGrossTotal As String = "0.00"
    '            Dim sGuiasCurrencyCode As String = "EUR" 'ISO 4217
    '            Dim sGuiasCurrencyAmount As String = "0.00"  'penso que não é obrigatorio



    '            'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.TipoTerc, SUM(DocDet.Qtd) AS QtdTot, COUNT(DocDet.DocLnNr) AS NumLinhas FROM DocCab INNER JOIN DocDet ON DocCab.IdDocCab = DocDet.IdDocCab INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.SAFT = 1) GROUP BY DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.LocalCarga, DocCab.LocDesc, DocCab.HoraCarga, DocCab.HoraDesc, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.IdDocCab, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.TipoTerc "
    '            'Sql = "SELECT IdDocCab, EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, DtUltAlt, EstadoDoc, FormaPagtoID, UtilizadorID, OperadorID, DtRegisto, TipoTerc, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, Hash, ATDocCodeID, ChavePrivadaVersao FROM DocCab WHERE (SAFT = 1)  GROUP BY EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, EstadoDoc, FormaPagtoID, UtilizadorID, OperadorID, DtRegisto, IdDocCab, DataDoc, DtUltAlt, TipoTerc, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, Hash, ATDocCodeID, ChavePrivadaVersao"
    '            'Sql = "SELECT IdDocCab, EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, DtUltAlt, EstadoDoc, FormaPagtoID, UtilizadorID, OperadorID, DtRegisto, TipoTerc, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, Hash, ATDocCodeID, ChavePrivadaVersao FROM DocCab WHERE (SAFT = 1) GROUP BY EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, EstadoDoc, FormaPagtoID, UtilizadorID, OperadorID, DtRegisto, IdDocCab, DataDoc, DtUltAlt, TipoTerc, AddressDetailCarga, CityCarga, PostalCodeCarga, CountryCarga, MovementStartTime, AddressDetailDescarga, CityDescarga, PostalCodeDescarga, CountryDescarga, MovementEndTime, Hash, ATDocCodeID, ChavePrivadaVersao HAVING (TipoDocID = 'GT')"
    '            'Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.MovementStartTime, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementEndTime, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, Terceiros.TipoTerc FROM DocCab INNER JOIN Terceiros ON DocCab.TercID = Terceiros.TercID WHERE (DocCab.SAFT = 1) AND (DocCab.TipoDocID = 'GT')"
    '            Sql = "SELECT DocCab.IdDocCab, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.DtUltAlt, DocCab.EstadoDoc, DocCab.FormaPagtoID, DocCab.UtilizadorID, DocCab.OperadorID, DocCab.DtRegisto, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.MovementStartTime, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementEndTime, DocCab.Hash, DocCab.ATDocCodeID, DocCab.ChavePrivadaVersao, Terceiros.TipoTerc, Utilizadores.NomeUtilizador FROM DocCab INNER JOIN Terceiros ON DocCab.TercID = Terceiros.TercID INNER JOIN Utilizadores ON DocCab.UtilizadorID = Utilizadores.UtilizadorID WHERE (DocCab.SAFT = 1) AND (DocCab.TipoDocID = 'GT')"

    '            db.GetData(Sql, dtSaftGuia)

    '            For Each r As DataRow In dtSaftGuia.Rows

    '                sGuiasDocumentNumber = Trim(r("TipoDocID")) & " " & Microsoft.VisualBasic.Left(r("DocNr"), 2) & Microsoft.VisualBasic.Right(r("ArmazemID"), 2) & "/" & Microsoft.VisualBasic.Right(r("DocNr"), 5)
    '                'FORMATO "GT 1300/00001"
    '                If RTrim(LTrim(r("EstadoDoc"))) = "A" Then sGuiasMovementStatus = "A" Else sGuiasMovementStatus = "N" '  N-NORMAL   OU   A-ANULADA
    '                sGuiasMovementStatusDate = CDate(r("DtUltAlt")).ToString("s")
    '                sGuiasAlteraSourceID = Trim(r("NomeUtilizador"))  'utilizador que alterou o documento
    '                sGuiasSourceBilling = "P"
    '                sGuiasHash = r("Hash")
    '                sGuiasHashControl = r("ChavePrivadaVersao")
    '                sGuiasMovementDate = CDate(r("DataDoc")).ToString("yyyy-MM-dd")
    '                sGuiasMovementType = r("TipoDocID")
    '                sGuiasSystemEntryDate = CDate(r("DataDoc")).ToString("s")
    '                sGuiasSupplierID = "T" + Trim(r("TercID"))  'NÃO PERMITE FAZER GT'S PARA CLIENTES DE LOJA!!
    '                sGuiasCustomerID = "T" + Trim(r("TercID"))  'NÃO PERMITE FAZER GT'S PARA CLIENTES DE LOJA!!
    '                sGuiasCriaSourceID = Trim(r("NomeUtilizador")) 'UTILIZADOR RESP. PELA CRIAÇÃO DO DOCUMENTO
    '                sGuiasDestinoAddressDetail = r("AddressDetailDescarga")  'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
    '                sGuiasDestinoCity = r("CityDescarga")
    '                sGuiasDestinoPostalCode = r("PostalCodeDescarga")
    '                sGuiasDestinoCountry = r("CountryDescarga")  'ISO 3166 - 1-alpha-2
    '                sGuiasOrigemAddressDetail = r("AddressDetailCarga") 'NOME DA RUA,  NUMERO DE POLICIA, ANDAR SE APLICAVEL
    '                sGuiasOrigemCity = r("CityCarga")
    '                sGuiasOrigemPostalCode = r("PostalCodeCarga")
    '                sGuiasOrigemCountry = r("CountryCarga") 'ISO 3166 - 1-alpha-2
    '                sGuiasMovementStartTime = CDate(r("MovementStartTime")).ToString("s")  'AAAA-MM-DDThh:mm:ss
    '                sGuiasATDocCodeID = r("ATDocCodeID")


    '                writer.WriteStartElement("StockMovement") '423
    '                writer.WriteElementString("DocumentNumber", sGuiasDocumentNumber) '423.1
    '                writer.WriteStartElement("DocumentStatus") '423.2
    '                writer.WriteElementString("MovementStatus", sGuiasMovementStatus) '4232.1
    '                writer.WriteElementString("MovementStatusDate", sGuiasMovementStatusDate) '4232.2
    '                writer.WriteElementString("SourceID", sGuiasAlteraSourceID) '4232.4
    '                writer.WriteElementString("SourceBilling", sGuiasSourceBilling) '4232.5
    '                writer.WriteEndElement() 'DocumentStatus
    '                writer.WriteElementString("Hash", sGuiasHash) '423.3
    '                writer.WriteElementString("HashControl", sGuiasHashControl) '423.4
    '                writer.WriteElementString("MovementDate", sGuiasMovementDate) '423.6
    '                writer.WriteElementString("MovementType", sGuiasMovementType) '423.7
    '                writer.WriteElementString("SystemEntryDate", sGuiasSystemEntryDate) '423.8
    '                'Select Case Trim(dtSaftCustomer.Rows(0)("TipoTerc").ToString)
    '                Select Case Trim(r("TipoTerc")).ToString
    '                    Case "F"
    '                        writer.WriteElementString("SupplierID", sGuiasSupplierID) '423.10
    '                    Case "I", "C"   'TODO: CONFIRMAR SE OS MOV INTERNOS FICAM NO CAMPO CustomerID
    '                        writer.WriteElementString("CustomerID", sGuiasCustomerID) '423.11
    '                End Select
    '                writer.WriteElementString("SourceID", sGuiasCriaSourceID) '423.12
    '                writer.WriteStartElement("ShipTo") '423.15
    '                writer.WriteStartElement("Address") '42315.5
    '                writer.WriteElementString("AddressDetail", sGuiasDestinoAddressDetail) '42315.3
    '                writer.WriteElementString("City", sGuiasDestinoCity) '42315.4
    '                writer.WriteElementString("PostalCode", sGuiasDestinoPostalCode) '42315.5
    '                writer.WriteElementString("Country", sGuiasDestinoCountry) '42315.7
    '                writer.WriteEndElement() 'Address
    '                writer.WriteEndElement() 'ShipTo

    '                writer.WriteStartElement("ShipFrom") '423.16
    '                writer.WriteStartElement("Address") '42315.5
    '                writer.WriteElementString("AddressDetail", sGuiasOrigemAddressDetail) '42316.3
    '                writer.WriteElementString("City", sGuiasOrigemCity) '42316.4
    '                writer.WriteElementString("PostalCode", sGuiasOrigemPostalCode) '42316.5
    '                writer.WriteElementString("Country", sGuiasOrigemCountry) '42316.7
    '                writer.WriteEndElement() 'Address
    '                writer.WriteEndElement() 'ShipFrom

    '                writer.WriteElementString("MovementStartTime", sGuiasMovementStartTime) '423.18
    '                writer.WriteElementString("ATDocCodeID", sGuiasATDocCodeID) '423.19

    '                'CRIAR CICLO COM AS LINHAS DO DOCUMENTO

    '                dtSaftGuiaLinha.Clear()
    '                Sql = "SELECT DocCab.IdDocCab, DocCab.ArmazemID, DocDet.DocLnNr, DocDet.ModeloID + DocDet.CorID AS Artigo, ModeloCor.ModCorDescr, DocDet.Qtd, DocDet.Unidade, DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA AS PrecoLiq, CONVERT(char(10), DocCab.DataDoc,126) DataDoc,  DocDet.Descricao, (DocDet.Valor - DocDet.VlrDescLn - DocDet.VlrIVA) * DocDet.Qtd AS ValorLiq, TaxIVA.TxIVA * 100 AS TxIVA, DocDet.VlrDescLn / (1 + TaxIVA.TxIVA) AS TDescLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.Saft = 1) AND (DocCab.IdDocCab = '" & r("IdDocCab").ToString & "') ORDER BY DocDet.DocLnNr"
    '                db.GetData(Sql, dtSaftGuiaLinha)

    '                For Each Linha As DataRow In dtSaftGuiaLinha.Rows

    '                    sGuiasLineNumber = Linha("DocLnNr")
    '                    sGuiasProductCode = Linha("Artigo")
    '                    sGuiasProductDescription = Trim(Linha("ModCorDescr"))
    '                    iGuiasQuantity = Linha("Qtd")
    '                    sGuiasUnitOfMeasure = Linha("Unidade")
    '                    sGuiasDescription = Trim(Linha("Descricao"))

    '                    writer.WriteStartElement("Line")  '423.20
    '                    writer.WriteElementString("LineNumber", sGuiasLineNumber) '423.20.1
    '                    writer.WriteElementString("ProductCode", sGuiasProductCode)
    '                    writer.WriteElementString("ProductDescription", sGuiasProductDescription)
    '                    writer.WriteElementString("Quantity", iGuiasQuantity)
    '                    writer.WriteElementString("UnitOfMeasure", sGuiasUnitOfMeasure)
    '                    writer.WriteElementString("UnitPrice", sGuiasUnitPrice)
    '                    writer.WriteElementString("Description", sGuiasDescription) '423.20.8
    '                    writer.WriteElementString("CreditAmount", "0.00")  '??????
    '                    writer.WriteEndElement() 'Line

    '                Next

    '                writer.WriteStartElement("DocumentTotals")  '423.21
    '                writer.WriteElementString("TaxPayable", sGuiasTaxPayable) '42321.1
    '                writer.WriteElementString("NetTotal", sGuiasNetTotal)
    '                writer.WriteElementString("GrossTotal", sGuiasGrossTotal)
    '                'writer.WriteStartElement("Currency")
    '                'writer.WriteElementString("CurrencyCode", sGuiasCurrencyCode)
    '                'writer.WriteElementString("CurrencyAmount", sGuiasCurrencyAmount)
    '                'writer.WriteEndElement() 'Currency
    '                writer.WriteEndElement() 'DocumentTotals

    '                writer.WriteEndElement() 'StockMovement


    '            Next

    '            writer.WriteEndElement() 'MovementOfGoods

    '        End If


    '        writer.WriteEndElement() 'SourceDocuments
    '        writer.WriteEndElement() 'AuditFile
    '        writer.Close()

    '        ValidarEsquema()


    '        Sql = "UPDATE DOCCAB SET SAFT = 0 WHERE SAFT = 1 OR SAFT IS NULL"
    '        db.ExecuteData(Sql)


    '        MsgBox("Totais: " & Chr(13) & "QtdDocs: " & QtdDocs & Chr(13) & "IVA: " & FormatCurrency(AUXIVA) & Chr(13) & "Crédito: " & FormatCurrency(AUXTOTLIQ_CREDITO) & Chr(13) & "Débito: " & FormatCurrency(AUXTOTLIQ_DEBITO * -1) & Chr(13) & "Bruto: " & FormatCurrency(AUXTOTBRUTO))
    '        MsgBox("Arquivo SAFT-PT gerado com sucesso.")


    '        Me.Cursor = Cursors.Default

    '        ClearMemory()


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try


    'End Sub


  


  

End Class