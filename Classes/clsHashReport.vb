



Imports System.IO
Imports System.Security.Cryptography
Imports System.Text




Public Class clsHashReport

    'AQUI VOU TER DA VALIDAR TODOS OS REPORTS. PRIMEIRO TENHO QUE GERAR AS HASH PARA TODOS OS REPORTES COM A frm frmHashFromFile.vb
    'TODO : CHAMAR ESTA FUNÇÃO NO ARRANQUE DO PROGRAMA
    Public Function btGerarHash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) As Boolean
        'Dim myFile As String = "C:\Girl\Reports\DocGuiaTransporte.xml"
        Dim myFile As String = "C:\Girl\Reports\DocFaturaSimplificada.xml"
        If Not GetMD5(myFile) = "759145730F020FA2A2FCFBEA5319C40A" Then
            MsgBox("O Report : DocFaturaSimplificada foi alterado! Contacte o Administrador!")
            Return False
        End If


    End Function



    Function GetMD5(ByVal filePath As String) As String
        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
        Dim f As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)

        f = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        md5.ComputeHash(f)
        f.Close()

        Dim hash As Byte() = md5.Hash
        Dim buff As StringBuilder = New StringBuilder
        Dim hashByte As Byte

        For Each hashByte In hash
            buff.Append(String.Format("{0:X2}", hashByte))
        Next

        Dim md5string As String
        md5string = buff.ToString()

        Return md5string

    End Function


End Class
