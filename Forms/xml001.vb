Public Class xml001

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' get the file name
        Dim SFD As New SaveFileDialog
        SFD.Filter = "*.xml|*.xml"
        If SFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        ' create the xml writer object
        Dim XMLW As New Xml.XmlTextWriter(SFD.FileName, System.Text.Encoding.GetEncoding("windows-1256"))

        ' now we are ready to write xml file
        ' example:
        ' <myinfo>
        '    test
        ' </myinfo>

        XMLW.Formatting = System.Xml.Formatting.Indented

        ' write element
        XMLW.WriteStartElement("myinfo")
        XMLW.WriteValue("test")
        XMLW.WriteEndElement()

        ' close the element
        XMLW.Close()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ' get the file name
        Dim SFD As New SaveFileDialog
        SFD.Filter = "*.xml|*.xml"
        If SFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        ' create the xml writer object
        Dim XMLW As New Xml.XmlTextWriter(SFD.FileName, System.Text.Encoding.GetEncoding("windows-1256"))

        ' now we are ready to write xml file
        ' example:
        ' <myinfo>
        '    <name> smith </name>
        '    <age>  30    </age>
        ' </myinfo>

        XMLW.Formatting = System.Xml.Formatting.Indented

        ' write myinf, it starts here
        XMLW.WriteStartElement("myinfo")

        ' <name element>
        XMLW.WriteStartElement("name")
        XMLW.WriteValue("smith")
        XMLW.WriteEndElement()

        ' <age element>
        XMLW.WriteStartElement("age")
        XMLW.WriteValue(30)
        XMLW.WriteEndElement()

        ' the end of myinfo
        XMLW.WriteEndElement()

        ' close the element
        XMLW.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ' get the file name
        Dim SFD As New SaveFileDialog
        SFD.Filter = "*.xml|*.xml"
        If SFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        ' create the xml writer object
        Dim XMLW As New Xml.XmlTextWriter(SFD.FileName, System.Text.Encoding.GetEncoding("windows-1256"))

        ' now we are ready to write xml file
        ' example:
        ' <myinfo gender="male" >
        '    <name> smith </name>
        '    <age>  30    </age>
        ' </myinfo>

        XMLW.Formatting = System.Xml.Formatting.Indented

        ' write myinf, it starts here
        XMLW.WriteStartElement("myinfo")
        XMLW.WriteAttributeString("gender", "male")

        ' <name element>
        XMLW.WriteStartElement("name")
        XMLW.WriteValue("smith")
        XMLW.WriteEndElement()

        ' <age element>
        XMLW.WriteStartElement("age")
        XMLW.WriteValue(30)
        XMLW.WriteEndElement()

        ' the end of myinfo
        XMLW.WriteEndElement()

        ' close the element
        XMLW.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' get the file name
        Dim OFD As New OpenFileDialog
        OFD.Filter = "*.xml|*.xml"
        If OFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        ' create the xml xmlreader
        Dim XMLR As New Xml.XmlTextReader(OFD.FileName)


        ' now we are ready to write xml file
        ' example:
        ' <myinfo>
        '    test
        ' </myinfo>

        'If XMLR.IsStartElement("x") Then
        'MsgBox("x element was detected")
        'Else
        'MsgBox("not an x element")
        'End If

        XMLR.Read()
        Dim Val As String = XMLR.ReadString
        XMLR.ReadEndElement()

        ' close xml
        XMLR.Close()

        MsgBox(Val)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        ' get the file name
        Dim OFD As New OpenFileDialog
        OFD.Filter = "*.xml|*.xml"
        If OFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        ' create the xml xmlreader
        Dim XMLR As New Xml.XmlTextReader(OFD.FileName)

        ' now we are ready to write xml file
        ' example:
        ' <myinfo>
        '    <name> smith </name>
        '    <age>  30    </age>
        ' </myinfo>

        ' read the myinfo element
        XMLR.ReadStartElement("myinfo")

        ' read the value of the name element
        XMLR.ReadStartElement("name")
        Dim NME As String = XMLR.ReadString
        XMLR.ReadEndElement()

        XMLR.ReadStartElement("age")
        Dim AG As Integer = Integer.Parse(XMLR.ReadString)
        XMLR.ReadEndElement()

        ' close the myinfo element
        XMLR.ReadEndElement()

        'close xml
        XMLR.Close()

        MsgBox(NME & vbNewLine & AG)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        ' get the file name
        Dim OFD As New OpenFileDialog
        OFD.Filter = "*.xml|*.xml"
        If OFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        ' create the xml xmlreader
        Dim XMLR As New Xml.XmlTextReader(OFD.FileName)

        ' now we are ready to write xml file
        ' example:
        ' <myinfo gender="male" >
        '    <name> smith </name>
        '    <age>  30    </age>
        ' </myinfo>

        ' read the myinfo element

        XMLR.Read()
        Dim Gender As String = XMLR.GetAttribute("gender")
        XMLR.MoveToElement()

        XMLR.ReadStartElement("myinfo")


        ' read the value of the name element
        XMLR.ReadStartElement("name")
        Dim NME As String = XMLR.ReadString
        XMLR.ReadEndElement()

        XMLR.ReadStartElement("age")
        Dim AG As Integer = Integer.Parse(XMLR.ReadString)
        XMLR.ReadEndElement()

        ' close the myinfo element
        XMLR.ReadEndElement()


        'close xml
        XMLR.Close()

        MsgBox(NME & vbNewLine & AG & vbNewLine & Gender)


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ' get the file name
        Dim SFD As New SaveFileDialog
        SFD.Filter = "*.xml|*.xml"
        If SFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        ' create the xml writer object
        Dim XMLW As New Xml.XmlTextWriter(SFD.FileName, System.Text.Encoding.GetEncoding("windows-1256"))

        ' now we are ready to write xml file
        ' example:
        ' <myinfo gender="male" >
        '    <name family="john"> smith </name>
        '    <age notes="old">  30    </age>
        ' </myinfo>

        XMLW.Formatting = System.Xml.Formatting.Indented

        ' write myinf, it starts here
        XMLW.WriteStartElement("myinfo")
        XMLW.WriteAttributeString("gender", "male")

        ' <name element>
        XMLW.WriteStartElement("name")
        XMLW.WriteAttributeString("family", "john")
        XMLW.WriteValue("smith")
        XMLW.WriteEndElement()

        ' <age element>
        XMLW.WriteStartElement("age")
        XMLW.WriteAttributeString("notes", "old")
        XMLW.WriteValue(30)
        XMLW.WriteEndElement()

        ' the end of myinfo
        XMLW.WriteEndElement()

        ' close the element
        XMLW.Close()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        ' get the file name
        Dim OFD As New OpenFileDialog
        OFD.Filter = "*.xml|*.xml"
        If OFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        ' create the xml xmlreader
        Dim XMLR As New Xml.XmlTextReader(OFD.FileName)

        ' now we are ready to write xml file
        ' example:
        ' <myinfo gender="male" >
        '    <name family="john"> smith </name>
        '    <age notes="old">  30    </age>
        ' </myinfo>

        ' read the myinfo element

        XMLR.Read()
        Dim Gender As String = XMLR.GetAttribute("gender")
        XMLR.MoveToElement()

        XMLR.ReadStartElement("myinfo")


        ' read the value of the name element
        XMLR.Read()
        Dim Family As String = XMLR.GetAttribute("family")
        XMLR.MoveToElement()
        XMLR.ReadStartElement("name")
        Dim NME As String = XMLR.ReadString
        XMLR.ReadEndElement()

        XMLR.Read()
        Dim Notes As String = XMLR.GetAttribute("notes")
        XMLR.MoveToElement()
        XMLR.ReadStartElement("age")
        Dim AG As Integer = Integer.Parse(XMLR.ReadString)
        XMLR.ReadEndElement()

        ' close the myinfo element
        XMLR.ReadEndElement()


        'close xml
        XMLR.Close()

        MsgBox(NME & vbNewLine & AG & vbNewLine & Gender & vbNewLine & Notes & vbNewLine & Family)
    End Sub
End Class
