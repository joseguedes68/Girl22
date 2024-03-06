Imports System.Xml
Imports System.Xml.Schema
Public Class ValidarXML
    Private resultado As Boolean = True
    Private Sub btnValidaXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidaXML.Click

        If Not txtXML.Text = String.Empty And Not txtXSD.Text = String.Empty Then
            resultado = True
            Dim settings As New XmlReaderSettings()

            AddHandler settings.ValidationEventHandler, AddressOf Me.ValidationEventHandler

            'Valida o arquivo XML com o seu Schema XSD 
            lstValida.Items.Add("Validando o arquivo XML " & txtXML.Text & " com o arquivo de Schema : " & txtXSD.Text)
            Try
                settings.ValidationType = ValidationType.Schema
                settings.Schemas.Add("schema.xsd", XmlReader.Create(txtXSD.Text))

                Using XmlValidatingReader As XmlReader = XmlReader.Create(txtXML.Text, settings)
                    While XmlValidatingReader.Read()
                    End While
                End Using
            Catch ex As Exception
                lstValida.Items.Add(ex.Message)
                Exit Sub
            End Try

            lstValida.Items.Add("Validação concluída -> " & IIf(resultado = True, "Arquivo validado com SUCESSO", "Validação FALHOU"))
        Else
            MsgBox("Informe o arquivo XML e o arquivo XSD.")
        End If
    End Sub
    Public Sub ValidationEventHandler(ByVal sender As Object, ByVal args As ValidationEventArgs)
        resultado = False

        lstValida.Items.Add(vbTab + "Erro de Validação : " + args.Message)

        If args.Severity = XmlSeverityType.Warning Then
            MsgBox("Nenhum arquivo de Schema foi encontrado para efetuar a validação...")
        ElseIf args.Severity = XmlSeverityType.Error Then
            MsgBox("Ocorreu um erro durante a validação....")
        End If

        If Not (args.Exception Is Nothing) Then ' Erro na validação do schema XSD 
            MsgBox(args.Exception.SourceUri + "," & args.Exception.LinePosition & "," & args.Exception.LineNumber)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'abre a janela de dialogo e atribui o arquivo selecionado a caixa de texto txtXML
        If ofd.ShowDialog = DialogResult.OK Then
            txtXML.Text = ofd.FileName
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'abre a janela de dialogo e atribui o arquivo selecionado a caixa de texto txtXML
        If ofd.ShowDialog = DialogResult.OK Then
            txtXSD.Text = ofd.FileName
        End If
    End Sub


End Class
