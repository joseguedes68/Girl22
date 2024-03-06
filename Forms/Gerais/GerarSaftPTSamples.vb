Imports System.Xml

Public Class GerarSaftPTSamples


    Dim dtSaft As New DataTable
    Dim db As New ClsSqlBDados

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Try



            Dim writer As New XmlTextWriter("C:\GIRL\SAFT-PT.xml", System.Text.Encoding.UTF8)

            'inicia o documento xml
            writer.WriteStartDocument()

            'define a indentação do arquivo
            writer.Formatting = Formatting.Indented

            ''escreve um comentario
            'writer.WriteComment("Arquivos de filmes")

            'escreve o elmento raiz
            writer.WriteStartElement("AuditFile")
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")


            writer.WriteStartElement("Header")
            writer.WriteStartElement("MasterFiles")
            writer.WriteStartElement("SourceDocuments")






            'writer.WriteStartDocument(True)
            'writer.Formatting = Formatting.Indented
            'writer.Indentation = 2
            'writer.WriteStartElement("Table")
            'createNode(1, "Product 1", "1000", writer)
            'createNode(2, "Product 2", "2000", writer)
            'createNode(3, "Product 3", "3000", writer)
            'createNode(4, "Product 4", "4000", writer)
            'writer.WriteEndElement()
            'writer.WriteEndDocument()
            'writer.Close()






            'escrever o atributo ano com valor 2007
            'writer.WriteAttributeString("ano", "2007")

            'Escreve os sub-elementos 
            writer.WriteElementString("titulo", "Cada & Companhia")
            writer.WriteElementString("titulo", "007 contra Godzila")
            writer.WriteElementString("titulo", "O segredo do Dr. Haus's")

            ' encerra o elemento raiz
            writer.WriteEndElement()

            'Escreve o XML para o arquivo e fecha o objeto escritor 
            writer.Close()
            MsgBox("Arquivo XML gerado com sucesso.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim writer As New XmlTextWriter("filmes2.xml", Nothing)

        'inicia o documento xml
        writer.WriteStartDocument()

        'Usa a formatação
        writer.Formatting = Formatting.Indented

        'Escreve o elemento raiz
        writer.WriteStartElement("filmes")

        'Inicia um elemento
        writer.WriteStartElement("filme")

        'Inclui um atributo ao elemento
        writer.WriteAttributeString("classificacao", "R")

        'e sub-elementos
        writer.WriteElementString("titulo", "Matrix")
        writer.WriteElementString("formato", "DVD")

        'encerra os elementos itens
        writer.WriteEndElement()
        ' encerra o item

        'escreve alguns espaços entre os nodes 
        writer.WriteWhitespace("" & Chr(10) & "")

        'escreve um segundo elemento usando um raw de dados strings
        writer.WriteRaw("<filme>" + "<titulo>007 contra Godzila</titulo>" + "<formato>DVD</formato>" + "</filme>")

        'escreve o terceiro elemento na string
        writer.WriteRaw("" & Chr(10) & " <filme>" & Chr(10) & "" + " <titulo>O segredo do Dr. Hauss´s</titulo>" & Chr(10) & "" + " <formato>CD</formato>" & Chr(10) & "" + " </filme>" & Chr(10) & "")

        ' encerra o elemento raiz
        writer.WriteFullEndElement()

        'escreve o XML para o arquivo e fecha o escritor
        writer.Close()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ds As New DataSet
        ds.ReadXml("filmes.xml")
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        escreveXML(ds)
    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim ds As New DataSet
        ds.ReadXml("filmes2.xml")
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        escreveXML(ds)
    End Sub


    Private Sub escreveXML(ByVal ds As DataSet)

        If ds Is Nothing Then
            Return
        End If

        ' cria um arquivo 
        Dim filename As String = "arquivo.xml"

        ' Cria um FileStream  para escrita
        Dim mFileStream As New System.IO.FileStream(filename, System.IO.FileMode.Create)

        ' Cria um XmlTextWriter com o fileStream.
        Dim mXmlWriter As New System.Xml.XmlTextWriter(mFileStream, System.Text.Encoding.Unicode)

        ' escreve para o arquivo usando o método WriteXml
        ds.WriteXml(mXmlWriter)

        mXmlWriter.Close()
    End Sub





    Private Sub btGeraSAFT_Click(sender As System.Object, e As System.EventArgs) Handles btGeraSAFT.Click

        Dim dtSaftHeader As New DataTable


        Try

            Sql = "SELECT Empresas.* FROM Empresas WHERE EmpresaID = '" & xEmp & "'"
            db.GetData(Sql, dtSaftHeader)



            'FALTA FILTRO ENTRE DATAS
            Sql = "SELECT DocCab.EmpresaID AS Expr18, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocCab.DataDoc, DocCab.TipoDocOrig, DocCab.DocNrOrig, DocCab.Exp, DocCab.PPagID, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.HoraDesc, DocCab.Obs AS Expr11, DocCab.Obs1, DocCab.Obs2, DocCab.Obs3, DocCab.DescontoDoc, DocCab.EstadoDoc, DocCab.TipoTerc, DocCab.FormaPagtoID, DocCab.IdDocCab, DocCab.IdDocCabOrig, DocCab.UtilizadorID, DocCab.OperadorID AS Expr12, DocCab.DtRegisto AS Expr13, DocDet.EmpresaID AS Expr1, DocDet.ArmazemID AS Expr2, DocDet.TipoDocID AS Expr3, DocDet.DocNr AS Expr4, DocDet.DocLnNr, DocDet.SerieID, DocDet.ModeloID, DocDet.CorID, DocDet.TamID, DocDet.Descricao, DocDet.Unidade, DocDet.DocNrLnOrig, DocDet.Valor, DocDet.PercDescLn, DocDet.VlrDescLn, DocDet.IvaID AS Expr14, DocDet.VlrIVA, DocDet.TxIva AS Expr15, DocDet.Qtd, DocDet.FormaPagtoID AS Expr5, DocDet.Comissao, DocDet.Obs AS Expr6, DocDet.EstadoLn, DocDet.IdDocCab AS Expr7, DocDet.IdDocDet, DocDet.IdDocDetOrig, DocDet.UtilizadorID AS Expr8, DocDet.OperadorID AS Expr9, DocDet.DtRegisto AS Expr10, ClientesLoja.ClienteLojaID, ClientesLoja.Nome, ClientesLoja.Morada, ClientesLoja.Localidade, ClientesLoja.CodPostal, ClientesLoja.NIF, ClientesLoja.BI, ClientesLoja.Telefone, ClientesLoja.Telemovel, ClientesLoja.Email, ClientesLoja.Obs, ClientesLoja.OperadorID AS Expr16, ClientesLoja.DtRegisto AS Expr17, ClientesLoja.PaisID, ClientesLoja.DistritoID, TaxIVA.IvaID, TaxIVA.TxIVA, TaxIVA.TxIVADef, TaxIVA.OperadorID, TaxIVA.DtRegisto, Empresas.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpMorada, Empresas.EmpNumPolicia, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpPais, Empresas.EmpDistrito, Empresas.EmpLogo, Empresas.EmpMarca, Empresas.Moeda, Empresas.Bloquear, Empresas.Imprimir, Empresas.BackupPath, Empresas.Versao, Empresas.Var1, Empresas.Var2, Empresas.Var3, Empresas.Var4, Empresas.Var5 FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ClientesLoja ON DocCab.TercID = ClientesLoja.ClienteLojaID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID INNER JOIN Empresas ON DocCab.EmpresaID = Empresas.EmpresaID INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID WHERE (DocCab.TipoDocID = 'FS')"
            db.GetData(Sql, dtSaft)

            Dim xTotais As Double = dtSaft.Compute("SUM(VALOR)", "ARMAZEMID = '0003'")
            Dim xContribuinte As String = dtSaftHeader.Rows(0)("EmpContrib")

            Dim writer As New XmlTextWriter("C:\GIRL\SAFT-PT.xml", System.Text.Encoding.Default)

            'inicia o documento xml
            writer.WriteStartDocument()

            'define a indentação do arquivo
            writer.Formatting = Formatting.Indented

            'AuditFile NIVEL 1 
            writer.WriteStartElement("AuditFile")
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
            writer.WriteAttributeString("xmlns", "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")

            '   Header NIVEL 2 
            writer.WriteStartElement("Header")
            writer.WriteElementString("AuditFileVersion", "1.01_01")
            writer.WriteElementString("CompanyID", "VNGAIA 509634060")
            writer.WriteElementString("TaxRegistrationNumber", "509634060")
            writer.WriteElementString("TaxAccountingBasis", "F")
            writer.WriteElementString("CompanyName", "Grande Enigma, Lda")

            writer.WriteStartElement("CompanyAddress")
            writer.WriteElementString("AddressDetail", "Rua Almeida Garrett, nº20")
            writer.WriteElementString("City", "V.N.Gaia")
            writer.WriteElementString("PostalCode", "4430-300")
            writer.WriteElementString("Country", "PT")
            writer.WriteEndElement()  'CompanyAddress

            writer.WriteElementString("FiscalYear", "2013")
            writer.WriteElementString("StartDate", "2013-01-01")
            writer.WriteElementString("EndDate", "2013-01-21")
            writer.WriteElementString("CurrencyCode", "EUR")
            writer.WriteElementString("DateCreated", "2013-01-21")
            writer.WriteElementString("TaxEntity", "Global")
            writer.WriteElementString("ProductCompanyTaxID", "507687213")
            writer.WriteElementString("SoftwareCertificateNumber", "0")
            writer.WriteElementString("ProductID", "GIRL/Grande Enigma")
            writer.WriteElementString("ProductVersion", "1.0.10")
            writer.WriteElementString("Telephone", "+351 227832348")
            writer.WriteElementString("Email", "celferi@gmail.com")

            writer.WriteEndElement() 'Header

            '   MasterFiles NIVEL 2 
            writer.WriteStartElement("MasterFiles")
            '       Customer NIVEL 3 CRIAR CICLO COM TODOS OS CLIENTES NOS DOCUMENTOS A EXPORTAR 
            writer.WriteStartElement("Customer")
            writer.WriteElementString("CustomerID", "1")
            writer.WriteElementString("AccountID", "Desconhecido")
            writer.WriteElementString("CustomerTaxID", "999999990")
            writer.WriteElementString("CompanyName", "Consumidor final")

            writer.WriteStartElement("BillingAddress")
            writer.WriteElementString("AddressDetail", "Desconhecido")
            writer.WriteElementString("City", "Desconhecido")
            writer.WriteElementString("PostalCode", "Desconhecido")
            writer.WriteElementString("Country", "Desconhecido")
            writer.WriteEndElement()

            writer.WriteElementString("SelfBillingIndicator", "0")
            writer.WriteEndElement()

            '       Product NIVEL 3   CRIAR CICLO COM TODOS OS PRODUTOS DOS DOCUMENTOS A EXPORTAR
            writer.WriteStartElement("Product")
            writer.WriteElementString("ProductType", "P")
            writer.WriteElementString("ProductCode", "87000")
            'writer.WriteElementString("ProductGroup", "")
            writer.WriteElementString("ProductDescription", "Sapato de Criança")
            writer.WriteElementString("ProductNumberCode", "87000")
            writer.WriteEndElement()

            '       TaxTable NIVEL 3
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

            '   SourceDocuments NIVEL 2 
            writer.WriteStartElement("SourceDocuments")
            writer.WriteStartElement("SalesInvoices")
            writer.WriteElementString("NumberOfEntries", "99")
            writer.WriteElementString("TotalDebit", "1500.00")
            writer.WriteElementString("TotalCredit", "25000.00")
            writer.WriteStartElement("Invoice")         'CRIAR CICLO COM TODOS DO DOCUMENTOS
            writer.WriteElementString("InvoiceNo", "FS 1013/00001")
            writer.WriteElementString("InvoiceStatus", "N")
            'writer.WriteElementString("InvoiceStatusDate", "2013-01-11T10:04:27")
            'writer.WriteElementString("SourceID", "FERNANDO")
            writer.WriteElementString("Hash", "0")
            writer.WriteElementString("InvoiceDate", "2013-01-01")
            writer.WriteElementString("InvoiceType", "FS")
            writer.WriteElementString("SelfBillingIndicator", "0")
            'writer.WriteElementString("SourceID", "FERNANDO")
            writer.WriteElementString("SystemEntryDate", "2013-01-11T10:04:27")
            writer.WriteElementString("CustomerID", "1")
            'writer.WriteStartElement("ShipTo")
            'writer.WriteEndElement() 'ShipTo
            'writer.WriteStartElement("ShipFrom")
            'writer.WriteEndElement() 'ShipFrom
            writer.WriteStartElement("Line")   'CRIAR CICLO COM TODAS AS LINHAS DO DOCUMENTO

            writer.WriteElementString("LineNumber", "1")
            writer.WriteElementString("ProductCode", "87000")
            writer.WriteElementString("ProductDescription", "Sapato de Criança")
            writer.WriteElementString("Quantity", "99")
            writer.WriteElementString("UnitOfMeasure", "Par")
            writer.WriteElementString("UnitPrice", "19.90")
            writer.WriteElementString("TaxPointDate", "2013-01-01")
            writer.WriteElementString("Description", "Sapato de Criança")
            'writer.WriteElementString("DebitAmount", "0")  'CRÉDITO OU DEBITO!!!
            writer.WriteElementString("CreditAmount", "1970.10")
            writer.WriteStartElement("Tax")
            writer.WriteElementString("TaxType", "IVA")
            writer.WriteElementString("TaxCountryRegion", "PT")
            writer.WriteElementString("TaxCode", "NOR")
            writer.WriteElementString("TaxPercentage", "23.00")
            writer.WriteEndElement() 'Tax
            writer.WriteElementString("SettlementAmount", "0.00000")  'DESCONTOS DE LINHA
            writer.WriteEndElement() 'Line
            writer.WriteStartElement("DocumentTotals")
            writer.WriteElementString("TaxPayable", "368.39")
            writer.WriteElementString("NetTotal", "1601.71")
            writer.WriteElementString("GrossTotal", "1970.10")
            writer.WriteStartElement("Currency")
            writer.WriteElementString("CurrencyCode", "EUR")
            writer.WriteElementString("CurrencyCreditAmount", "1970.10")
            writer.WriteEndElement() 'Currency
            writer.WriteEndElement() 'DocumentTotals
            writer.WriteEndElement() 'Invoice
            writer.WriteEndElement() 'SalesInvoices
            'writer.WriteStartElement("MovementOfGoodes")    'AINDA NÃO É OBRIGATÓRIO
            'writer.WriteEndElement() 'MovementOfGoodes
            writer.WriteEndElement() 'SourceDocuments
            writer.WriteEndElement() 'AuditFile
            writer.Close()
            MsgBox("Arquivo XML gerado com sucesso.")



            'writer.WriteStartDocument(True)
            'writer.Formatting = Formatting.Indented
            'writer.Indentation = 2
            'writer.WriteStartElement("Table")
            'createNode(1, "Product 1", "1000", writer)
            'createNode(2, "Product 2", "2000", writer)
            'createNode(3, "Product 3", "3000", writer)
            'createNode(4, "Product 4", "4000", writer)



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub




    Private Sub btExibeSAFT_Click(sender As System.Object, e As System.EventArgs) Handles btExibeSAFT.Click
        Dim ds As New DataSet
        ds.ReadXml("C:\GIRL\SAFT-PT.xml")
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        escreveXML(ds)
    End Sub



End Class