Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Public Class ClsManutencaoBD
    Implements IDisposable

#Region " IDisposable Support "

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
                sReportServer = Nothing
                sReportLocal = Nothing
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

    Dim sReportServer As String
    Dim sReportLocal As String
    Dim NomeFicheiro As String



    Public Sub ImportarParaLocal()

        Dim cnAux As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim NomeFicheiro As String
        Dim fullPath As String
        Dim MsgError As String = ""

        Try

            NomeFicheiro = "GIRL" + Date.Now
            'Sql = "BACKUP DATABASE GIRL " & _
            '      "   TO DISK = 'C:\Girl\BackUp\" + NomeFicheiro.Replace(":", "") + ".bak'"
            Sql = "BACKUP DATABASE GIRL " & _
                  "   TO DISK = '\\" + xServidor + "\BackUp\" + NomeFicheiro.Replace(":", "") + ".bak'"
            MsgError = "ClsManutencaoBD: ImportarParaLocal cn.Open"
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New System.Data.SqlClient.SqlCommand(Sql, cn)
            MsgError = "ClsManutencaoBD: ImportarParaLocal cmd.ExecuteNonQuery()"
            cmd.ExecuteNonQuery()
            fullPath = "C:\Girl\BackUp\" + NomeFicheiro.Replace(":", "") + ".bak"
            MsgError = "ClsManutencaoBD: ImportarParaLocal IO.File.Exists(fullPath)"
            If Not IO.File.Exists(fullPath) Then
                If Not IO.Directory.Exists(fullPath.Substring(0, fullPath.LastIndexOf("\"))) Then
                    MsgError = "ClsManutencaoBD: ImportarParaLocal CreateDirectory"
                    IO.Directory.CreateDirectory(fullPath.Substring(0, fullPath.LastIndexOf("\")))
                End If

                'If IO.File.Exists(xServerPath + "GIRL\BackUp\" + NomeFicheiro.Replace(":", "") + ".bak") Then
                '    MsgError = "ClsManutencaoBD: ImportarParaLocal IO.File.Copy"
                '    IO.File.Copy(xServerPath + "GIRL\BackUp\" + NomeFicheiro.Replace(":", "") + ".bak", fullPath)
                'End If

                If IO.File.Exists("\\" + xServidor + "\c$\Girl\BackUp\" + NomeFicheiro.Replace(":", "") + ".bak") Then
                    MsgError = "ClsManutencaoBD: ImportarParaLocal IO.File.Copy"
                    IO.File.Copy("\\" + xServidor + "\c$\Girl\BackUp\" + NomeFicheiro.Replace(":", "") + ".bak", fullPath)
                End If
            End If
            MsgError = "ClsManutencaoBD: ImportarParaLocal ValidarDataBase()"
            'TODO : SE O NÃO TIVER UMA INSTÂNCIA CRIADA, NÃO FUNCIONA
            ValidarDataBase()
            MsgError = "ClsManutencaoBD: ImportarParaLocal cn.Close()"
            If cn.State = ConnectionState.Open Then cn.Close()





            cnAux = New System.Data.SqlClient.SqlConnection("Data Source=(local)\SQLEXPRESS;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42")

            MsgError = "ClsManutencaoBD: ImportarParaLocal RESTORE DATABASE GirlLocal "


            Sql = "RESTORE DATABASE GirlLocal FROM DISK = '" + fullPath + "'  WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10"
            If cnAux.State = ConnectionState.Closed Then cnAux.Open()
            cmd = New System.Data.SqlClient.SqlCommand(Sql, cnAux)
            MsgError = "ClsManutencaoBD: ImportarParaLocal ExecuteNonQuery()"
            cmd.ExecuteNonQuery()
            MsgError = "ClsManutencaoBD: ImportarParaLocal ImportarReports()"

            ImportarReports()

            Dim Fotos As New clsImportarFotos
            Fotos.VerificarFotos()
            If Fotos IsNot Nothing Then Fotos.Dispose()
            Fotos = Nothing

            MsgBox("Copia efectuada com sucesso!", MsgBoxStyle.Information)
        Catch ex As Exception
            ErroVB(ex.Message, MsgError)
        Finally
            If cnAux.State = ConnectionState.Open Then cnAux.Close()
            If Not cmd Is Nothing Then cmd.Dispose()
            cmd = Nothing
            NomeFicheiro = Nothing
            fullPath = Nothing
        End Try
    End Sub

    Private Sub ValidarDataBase()
        Dim _DbName As String = "GirlLocal"
        Dim cn As New SqlConnection("Data Source=(local)\SQLEXPRESS;Initial Catalog=MASTER;Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42")
        Sql = "USE MASTER; " &
        " IF NOT EXISTS( SELECT db_name(s_mf.database_id) " &
        " from sys.master_files s_mf " &
        " where(s_mf.state = 0) " &
        " and has_dbaccess(db_name(s_mf.database_id)) = 1 " &
        " AND db_name(s_mf.database_id) = '" + _DbName + "') " &
        "BEGIN " &
        " CREATE DATABASE " + _DbName + " " &
        "End"
        If cn.State = ConnectionState.Closed Then cn.Open()
        Cmd = New System.Data.SqlClient.SqlCommand(Sql, cn)
        Cmd.ExecuteNonQuery()
    End Sub

    Public Sub ReporCopia()
        Dim cnAux As New System.Data.SqlClient.SqlConnection
        Dim cmdAux As New System.Data.SqlClient.SqlCommand
        Dim fullPath As String
        Dim ServidorReposicao, Basedados As String
        ServidorReposicao = ""
        Basedados = ""

        Try

            Dim xPassword As String = InputBox("Introduza a palavra pass!!")
            If xPassword <> "XOOK" Then Exit Sub

            'If MsgBox("ATENÇÃO !! Este procedimento vai apagar a Base de Dados e repôr a Seleccionada!" + Chr(13) + "Pretende continuar?", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, "GIRL") = MsgBoxResult.Yes Then
            'CriarCopia()
            'If ValidarServidor(ServidorReposicao) Then
            'cnAux = New System.Data.SqlClient.SqlConnection("Data Source=" + ServidorReposicao + "\SQLEXPRESS;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42")

            cnAux = New System.Data.SqlClient.SqlConnection("Data Source=(Local)\SQLEXPRESS;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42")


            If ValidarBasedados(Basedados, cnAux) Then
                fullPath = FicheiroPretendido()
                'Dim fileLocalExists As Boolean
                'fileLocalExists = My.Computer.FileSystem.FileExists("C:\GIRL\BACKUP\" + NomeFicheiro)
                'If fileLocalExists = False Then
                '    IO.File.Copy(fullPath, "C:\GIRL\BACKUP\" + NomeFicheiro)
                'End If
                'Dim fileExists As Boolean
                'fileExists = My.Computer.FileSystem.FileExists("C:\GIRL\BACKUP\" + NomeFicheiro)
                'If fileExists Then

                If MsgBox("Confirma a reposição para base de dados " & Basedados & " neste computador?", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, "GIRL") = MsgBoxResult.Yes Then
                    Sql = "RESTORE DATABASE " + Basedados + " FROM DISK = '" + fullPath + "'"
                    'Sql = "RESTORE DATABASE " + Basedados + " FROM DISK =   'C:\Girl\BackUp\" + NomeFicheiro + "'"
                    If cnAux.State = ConnectionState.Closed Then cnAux.Open()
                    cmdAux = New System.Data.SqlClient.SqlCommand(Sql, cnAux)
                    cmdAux.ExecuteNonQuery()
                    MsgBox("Reposição concluida com sucesso!", MsgBoxStyle.Information)
                Else
                    MsgBox("Operação Cancelada!", MsgBoxStyle.Critical)
                End If
            Else
                'MsgBox("O ficheiro " + fullPath + " não foi encontrado!", MsgBoxStyle.Critical)
                MsgBox("ERRO NA REPOSIÇÃO!", MsgBoxStyle.Critical)
            End If


        Catch ex As Exception
            MsgBox("ERRO NA REPOSIÇÃO!")
            'ErroVB(ex.Message, "ClsManutencaoBD: ReporCopia")
        Finally
            If cnAux.State = ConnectionState.Open Then cnAux.Close()
            If Not cmdAux Is Nothing Then cmdAux.Dispose()
            cmdAux = Nothing
            fullPath = Nothing
        End Try
    End Sub

    Private Function ValidarServidor(ByRef ServidorReposicao As String) As Boolean
        ServidorReposicao = InputBox("Indique o nome do Servidor para o qual pretende repor o Backup! ", "GIRL", "SERVER")
        If Not String.IsNullOrEmpty(ServidorReposicao) Then
            Dim siteResponds As Boolean = False
            'siteResponds = My.Computer.Network.Ping("SERVER")
            siteResponds = My.Computer.Network.Ping(ServidorReposicao)
            If siteResponds Then
                Return True
            Else
                MsgBox("O Servidor de reposição não foi encontrado!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Processo Cancelado!", MsgBoxStyle.Information)
        End If
        Return False
    End Function

    Private Function ValidarBasedados(ByRef Basedados As String, ByVal cnAux As System.Data.SqlClient.SqlConnection) As Boolean

        Dim cmdAux As New System.Data.SqlClient.SqlCommand

        Try
            Basedados = InputBox("Indique o nome da base de dados para a qual pretende repor o Backup!", "GIRL", "GirlLocal")
            If Not String.IsNullOrEmpty(Basedados) Then
                'Validar Existencia
                Sql = "select COUNT(*) from sys.databases where name = '" + Basedados + "'"
                If cnAux.State = ConnectionState.Closed Then cnAux.Open()
                cmdAux = New System.Data.SqlClient.SqlCommand(Sql, cnAux)
                If cmdAux.ExecuteScalar = 1 Then
                    Return True
                Else
                    MsgBox("Base de dados não foi encontrada!", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("Operação Cancelada!", MsgBoxStyle.Critical)
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cnAux.Close()
            If cmdAux IsNot Nothing Then cmdAux.Dispose()
            cmdAux = Nothing
        End Try
    End Function

    Private Function FicheiroPretendido() As String
        FicheiroPretendido = ""
        Dim openFileDialog1 As New OpenFileDialog()
        Dim FileName As String = ""
        Try

            'xBackupPath = "\\" + ServidorReposicao + "\C$\Girl\BackUp\"
            'openFileDialog1.InitialDirectory = xBackupPath
            openFileDialog1.InitialDirectory = "C:\"
            openFileDialog1.Filter = "BAK files (All files (*.*)|*.*|*.BAK)|*.BAK"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True
            If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                FileName = openFileDialog1.FileName
                NomeFicheiro = openFileDialog1.SafeFileName
                Return FileName
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            If Not openFileDialog1 Is Nothing Then openFileDialog1.Dispose()
            openFileDialog1 = Nothing
        End Try
    End Function

    'Public Sub CriarCopia()
    '    Dim cn As New System.Data.SqlClient.SqlConnection
    '    Dim cmd As New System.Data.SqlClient.SqlCommand
    '    Dim NomeFicheiro As String = (xBdados + Format(Date.Now, "yyyyMMdd HHmmss")).Replace(":", "") + ".bak"
    '    Dim fullPath As String
    '    Dim Destino As String
    '    Dim xServidorBackup As String = ""



    '    'Dim Caminho As String = "\\" + xServidor + "\Girl\BackUp\"
    '    Dim fbd As New FolderBrowserDialog
    '    Try
    '        cn = New System.Data.SqlClient.SqlConnection("Data Source=" + xServidor + "\SQLEXPRESS;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42")
    '        Sql = "BACKUP DATABASE " + xBdados + " " &
    '              "   TO DISK = 'C:\Girl\BackUp\" + NomeFicheiro + "'"
    '        If cn.State = ConnectionState.Closed Then cn.Open()
    '        cmd = New System.Data.SqlClient.SqlCommand(Sql, cn)
    '        cmd.ExecuteNonQuery()
    '        fullPath = xBackupPath + NomeFicheiro
    '        ClsZip.CompressFile(xBackupPath + NomeFicheiro, xBackupPath + "DropBox\" + NomeFicheiro)
    '        fullPath += ".gz"
    '        Dim fileExists As Boolean
    '        fileExists = My.Computer.FileSystem.FileExists(fullPath)
    '        If fileExists Then
    '            fullPathBackup = fullPath
    '            'DESTA FORMA SÓ DÁ PARA IR BUSCAR AO PRÓPRIO SERVIDOR
    '            MsgBox("No quadro seguinte, selecionar o locar para onde vai fazer a cópia!")
    '            'My.Computer.FileSystem.DeleteFile(fullPath.Replace(".gz", ""), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
    '            fbd.ShowDialog()
    '            Destino = fbd.SelectedPath
    '            If Not String.IsNullOrEmpty(Destino) Then

    '                Dim fileLocalExists As Boolean
    '                fileLocalExists = My.Computer.FileSystem.FileExists(Destino + "\" + NomeFicheiro)
    '                If fileLocalExists = False Then
    '                    IO.File.Copy(fullPath, Destino + "\" + NomeFicheiro)
    '                Else
    '                    MsgBox("ATENÇÃO!! A CÓPIA FOI FEITA PARA O PRÓPRIO SERVIDOR")
    '                End If

    '            End If



    '            'ALTERNATIVA


    '            'xServidorBackup = InputBox("Qual o Computador de Destino?", "Servidor Destino", "P3")
    '            'If xServidorBackup = "SERVER" Then
    '            '    MsgBox("ATENÇÃO!! A CÓPIA FOI FEITA PARA O PRÓPRIO SERVIDOR")
    '            'Else
    '            '    Destino = "\\" & xServidorBackup & "\GIRL\BACKUPS"
    '            '    IO.File.Copy(fullPath, Destino + "\" + NomeFicheiro)
    '            'End If

    '            MsgBox("Backup concluido com sucesso!", MsgBoxStyle.Information)


    '        End If
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "ClsManutencaoBD: CriarCopia")
    '    Finally
    '        If cn.State = ConnectionState.Open Then cn.Close()
    '        If Not cmd Is Nothing Then cmd.Dispose()
    '        cmd = Nothing
    '        NomeFicheiro = Nothing
    '        fullPath = Nothing
    '    End Try
    'End Sub

    Public Sub CriarCopiaSimples()

        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim NomeFicheiro As String = (xBdados + Format(Date.Now, "yyyyMMdd HHmmss")).Replace(":", "") + ".bak"
        Dim fullPath As String
        Dim xServidorBackup As String = ""
        Dim db As New ClsSqlBDados


        Try
            cn = New System.Data.SqlClient.SqlConnection("Data Source=" + xServidor + "\SQLEXPRESS;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42")
            Sql = "BACKUP DATABASE " + xBdados + " TO DISK = 'C:\Girl\BackUp\" + NomeFicheiro + "'"
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New System.Data.SqlClient.SqlCommand(Sql, cn)
            cmd.ExecuteNonQuery()
            fullPath = xBackupPath + NomeFicheiro

            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(fullPath)
            If fileExists Then
                Sql = "INSERT INTO BackUps (UtilizadorID, PathBackup) VALUES ('24','" & fullPath & "')"
                db.ExecuteData(Sql)
            End If



        Catch ex As Exception
            ErroVB(ex.Message, "ClsManutencaoBD: CriarCopiaSimples")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            If Not cmd Is Nothing Then cmd.Dispose()
            cmd = Nothing
            NomeFicheiro = Nothing
            fullPath = Nothing
            db = Nothing

        End Try
    End Sub

    Private Sub ImportarReports()
        CarregarPaths()
        CarregarReports()
    End Sub

    Private Sub CarregarPaths()
        'Dim reg As New Regedit(xEmpresa, My.Application.Info.ProductName)
        'Try
        '    sReportServer = reg.Ler("ReportsServerPath", "\\" + xServidor + "\c$\Reports\", Microsoft.Win32.RegistryValueKind.String)
        '    sReportLocal = reg.Ler("ReportsLocalPath", "c:\GIRL\Reports\", Microsoft.Win32.RegistryValueKind.String)
        'Catch ex As Exception
        '    ErroVB(ex.Message, "clsImportarFotos: CarregarPaths")
        'Finally
        '    If reg IsNot Nothing Then reg.Dispose()
        '    reg = Nothing
        'End Try
    End Sub

    Private Sub CarregarReports()
        Dim folderExists As Boolean
        Dim PhotosCount As Integer = 0
        Dim files As ReadOnlyCollection(Of String)
        Try
            folderExists = My.Computer.FileSystem.DirectoryExists(sReportLocal)
            If Not folderExists Then
                My.Computer.FileSystem.CreateDirectory(sReportLocal.Substring(0, sReportLocal.Length - 1))
            End If
            folderExists = My.Computer.FileSystem.DirectoryExists(sReportLocal)
            If folderExists Then
                files = My.Computer.FileSystem.GetFiles(sReportServer, FileIO.SearchOption.SearchTopLevelOnly, "*.xml")
                For i As Integer = 0 To files.Count - 1
                    My.Computer.FileSystem.CopyFile(files(i), sReportLocal + files(i).Replace(sReportServer, ""), True)
                Next
            Else
                MsgBox("Falha de Ligação com o Servidor!", MsgBoxStyle.Critical, My.Application.Info.ProductName)
            End If
        Catch ex As Exception
            ErroVB(ex.Message, "clsImportarFotos: CarregarFotos")
        Finally
            folderExists = Nothing
            PhotosCount = Nothing
            files = Nothing
        End Try
    End Sub

End Class
