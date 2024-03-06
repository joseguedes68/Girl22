'Import the cryptography namespaces
Imports System.Security.Cryptography
Imports System.Text

Public Class HashTeste2
    'Declare global variables
    Dim textbytes, encryptedtextbytes As Byte()
    Dim rsa As New RSACryptoServiceProvider
    Dim encoder As New UTF8Encoding
    Dim encrypted, TextToDecrypt, TextToEncrypt, decrypted As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        TextToEncrypt = TextBox1.Text
        encrypt()
        TextBox2.Text = encrypted
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextToDecrypt = TextBox2.Text
        decrypt()
        TextBox3.Text = decrypted
    End Sub

    Sub encrypt()
        'Use UTF8 to convert the text string into a byte array
        textbytes = encoder.GetBytes(TextToEncrypt)
        'encrypt the text
        encryptedtextbytes = rsa.Encrypt(textbytes, True)
        'Convert the encrypted byte array into a Base64 string for display purposes
        encrypted = Convert.ToBase64String(encryptedtextbytes)
    End Sub

    Sub decrypt()

        encryptedtextbytes = Convert.FromBase64String(TextToDecrypt)
        'get the decrypted clear text byte array
        textbytes = rsa.Decrypt(encryptedtextbytes, True)
        'convert the byte array to text using the same encoding format that was used for encryption
        decrypted = encoder.GetString(textbytes)
    End Sub



End Class

