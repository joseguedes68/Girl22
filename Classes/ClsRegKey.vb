Imports Microsoft.Win32

Public Class ClsRegKey

#Region " LER DO REGISTRY "

    Public Function Ler(ByVal xKey As String, ByVal xSubKey As String) As String
        Try
            Dim xKeyReg As RegistryKey = Registry.LocalMachine.OpenSubKey(xKey, False)
            If Not xKeyReg Is Nothing Then
                Return xKeyReg.GetValue(xSubKey)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

#Region " ESCREVER NO REGISTRY "

    Dim xKey As RegistryKey
    Public Sub Escrever(ByVal xKey As String, ByVal xSubKey As String, ByVal xValue As String, ByVal RegType As RegistryValueKind)
        Try
            Dim xKeyReg As RegistryKey = Registry.LocalMachine.OpenSubKey(xKey, True)
            If Not xKeyReg Is Nothing Then
                xKeyReg.SetValue(xSubKey, xValue, RegistryValueKind.String)
            Else
                Registry.LocalMachine.CreateSubKey(xKey, RegistryKeyPermissionCheck.ReadWriteSubTree)
                xKeyReg.SetValue(xSubKey, xValue, RegistryValueKind.String)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

End Class
