
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class frmHashFromFile

    Private Sub btGerarHash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGerarHash.Click
        'Dim myFile As String = "C:\Girl\Reports\DocGuiaTransporte.xml"
        Dim myFile As String = "C:\Girl\Reports\DocFaturaSimplificada.xml"
        Dim myHash As String = GetMD5(myFile)
        'MessageBox.Show("The MD5 hash is: " & myHash, "techusers.net", MessageBoxButtons.OK, MessageBoxIcon.Information)
        tbHash.Text = myHash
    End Sub

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