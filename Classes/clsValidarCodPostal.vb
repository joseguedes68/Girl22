Imports System.Text.RegularExpressions


Public Class clsValidarCodPostal


    'VALIDAR CÓDIGOS POSTAIS
    'Private Sub txtZipCodeIn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtZipCodeIn.Validating
    Public Function txtZipCodeIn_Validating(ByVal txtZipCodeIn As String) As Boolean

        If Not IsValidZip(txtZipCodeIn) Then
            'ErrorProvider1.SetError(txtZipCodeIn, "Incorrect Zip")
            Console.WriteLine("Bad Zip")
            Return False
        Else
            Console.WriteLine("Good Zip")
            Return True
        End If

    End Function


    Private Function IsValidZip(ByRef value As String) As Boolean

        Dim myRegex As New Regex("^\d{4}([\-]\d{3})?$")
        Return myRegex.IsMatch(value)

    End Function


End Class
