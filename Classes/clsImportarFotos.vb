
Public Class clsImportarFotos
    Implements IDisposable

#Region " IDisposable Support "
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
                If ModelosCor IsNot Nothing Then ModelosCor.Dispose()
                ModelosCor = Nothing
                sFotosServer = Nothing
                sFotosLocal = Nothing
            End If
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Dim ModelosCor As New DataTable
    Dim sFotosServer As String
    Dim sFotosLocal As String

    Public Sub VerificarFotos()
        CarregarModelosCor()
        CarregarPaths()
        CarregarFotos()


    End Sub

    Private Sub CarregarModelosCor()
        Dim db As New ClsSqlBDados
        Try
            Sql = "SELECT ModeloID + CorID AS Foto FROM ModeloCor"
            db.GetData(Sql, ModelosCor)
        Catch ex As Exception
            ErroVB(ex.Message, "clsImportarFotos: CarregarModelosCor")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub CarregarPaths()
        'Dim reg As New Regedit(xEmpresa, My.Application.Info.ProductName)
        Try
            'sFotosServer = reg.Ler("PhotoServerPath", xServerPath + "Fotos\", Microsoft.Win32.RegistryValueKind.String)
            'sFotosLocal = reg.Ler("PhotoLocalPath", "C:\Girl\Fotos\", Microsoft.Win32.RegistryValueKind.String)

            sFotosServer = "\\" & xServidor & "\Fotos\"
            sFotosLocal = "C:\Girl\Fotos\"

        Catch ex As Exception
            ErroVB(ex.Message, "clsImportarFotos: CarregarPaths")
        Finally
            'If reg IsNot Nothing Then reg.Dispose()
            'reg = Nothing
        End Try
    End Sub

    Private Sub CarregarFotos()
        Dim folderExists As Boolean
        Dim PhotosCount As Integer = 0
        Try
            folderExists = My.Computer.FileSystem.DirectoryExists(sFotosLocal)
            If Not folderExists Then
                My.Computer.FileSystem.CreateDirectory(sFotosLocal.Substring(0, sFotosLocal.Length - 1))
            End If
            folderExists = My.Computer.FileSystem.DirectoryExists(sFotosLocal)
            If folderExists Then
                For Each r As DataRow In ModelosCor.Rows
                    If Not VerificarExistenciaLocal(r(0)) Then
                        If VerificarExistenciaServidor(r(0)) Then
                            My.Computer.FileSystem.CopyFile(sFotosServer + r(0) + ".jpg", sFotosLocal + r(0) + ".jpg")
                            PhotosCount += 1
                        End If
                    End If
                Next
                If xArmz = "0000" Then
                    MsgBox("Processo concluido com sucesso!" + Chr(13) + "Foram Importadas " + PhotosCount.ToString + " Fotos...", MsgBoxStyle.Information, My.Application.Info.ProductName)
                End If
            Else
                MsgBox("Falha de Ligação com o Servidor!", MsgBoxStyle.Critical, My.Application.Info.ProductName)
            End If
        Catch ex As Exception
            ErroVB(ex.Message, "clsImportarFotos: CarregarFotos")
        Finally
            folderExists = Nothing
            PhotosCount = Nothing
        End Try
    End Sub



    Private Function VerificarExistenciaLocal(ByVal Foto As String) As Boolean
        Dim fileExists As Boolean
        'If Foto = "8584079" Then
        '    MsgBox("olá")
        'End If
        fileExists = My.Computer.FileSystem.FileExists(sFotosLocal + Foto + ".jpg")
        Return fileExists
    End Function

    Private Function VerificarExistenciaServidor(ByVal Foto As String) As Boolean
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(sFotosServer + Foto + ".jpg")
        Return fileExists
    End Function

End Class
