Public Class ClsCopias


    Public Sub CriarCopiaManual()

        Dim db As New ClsSqlBDados
        Dim NomeFicheiro As String = (xBdados + Format(Date.Now, "yyyyMMdd HHmmss")).Replace(":", "") + ".bak"
        Dim fullPath As String
        'Dim Destino As String
        Dim dt As New DataTable



        Dim fbd As New FolderBrowserDialog
        Try

            Sql = "BACKUP DATABASE " + xBdados + " TO DISK = '" + xBackupPath + NomeFicheiro + "'"
            db.ExecuteData(Sql)


            fullPath = xBackupPath + NomeFicheiro

            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(fullPath)
            If fileExists Then


                'ZIPAR
                'ClsZip.CompressFile(xBackupPath + NomeFicheiro, xBackupPath + NomeFicheiro + ".gz")
                ComprimirArquivo(xBackupPath + NomeFicheiro, xBackupPath + NomeFicheiro + ".gz")

                'ENVIAR PARA SERVIDOR VILAR
                'If My.Computer.Network.Ping("89.114.159.233") Then

                UploadFile(xBackupPath + NomeFicheiro + ".gz", "ftp://" & "89.114.159.233/bdados/" & NomeFicheiro + ".gz", "celferi", "2R>z9J4sPu*7PH:")

                Sql = "INSERT INTO BackUps (UtilizadorID, PathBackup) VALUES ('24','" & xBackupPath + NomeFicheiro & "')"
                db.ExecuteData(Sql)


                'BACKUP DAS FOTOS
                Sql = "SELECT ModeloId+CorId FROM ModeloCor where DtRegisto>(SELECT GETDATE()-60)"
                db.GetData(Sql, dt)
                For Each r As DataRow In dt.Rows
                    If My.Computer.FileSystem.FileExists("C:\Girl\Fotos\" + r(0) + ".jpg") Then
                        UploadFile("C:\Girl\Fotos\" + r(0) + ".jpg", "ftp://" & "89.114.159.233/fotos/" & r(0) + ".jpg", "celferi", "2R>z9J4sPu*7PH:")

                    End If
                Next


                'UploadFile(fullPath, "ftp://ftp.celferi.com/public_html/loja/image/catalog/product/" + NomeFicheiro, sUserCPanelCelferi, sPassCPanelCelferi)

                'METODO PARA GRAVAR O FICHEIRO NUMA PASTA ESCOLHIDA PELO UTILIZADOR 
                'fullPathBackup = fullPath
                'MsgBox("No quadro seguinte, selecionar o local para onde vai fazer a cópia!")
                'fbd.ShowDialog()
                'Destino = fbd.SelectedPath
                'If Not String.IsNullOrEmpty(Destino) Then

                '    Dim fileLocalExists As Boolean
                '    fileLocalExists = My.Computer.FileSystem.FileExists(Destino + "\" + NomeFicheiro)
                '    If fileLocalExists = False Then
                '        IO.File.Copy(fullPath, Destino + "\" + NomeFicheiro)
                '        MsgBox("Backup concluido com sucesso!", MsgBoxStyle.Information)
                '    Else
                '        MsgBox("ATENÇÃO!! ERRO NA CÓPIA")
                '    End If

                'End If


            End If
        Catch ex As Exception
            EnviarEmail("ERRO 56800 NA COPIA", "Não foi possivel fazer upload para a web do ficheiro: " + xBackupPath + NomeFicheiro)
            'ErroVB(ex.Message, "ClsManutencaoBD: CriarCopia")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            If Not Cmd Is Nothing Then Cmd.Dispose()
            Cmd = Nothing
            NomeFicheiro = Nothing
            fullPath = Nothing
        End Try
    End Sub

    'Public Sub CriarCopiabd()

    '    Dim db As New ClsSqlBDados


    '    Dim NomeFicheiro As String = xBdados

    '    Dim i As Integer = 1


    '    Try


    '        For i = 1 To 5
    '            NomeFicheiro = xBdados + "_" + i.ToString + ".bak"
    '            If Not My.Computer.FileSystem.FileExists(xBackupPath + NomeFicheiro) Then
    '                'numero a apagar
    '                If i = 5 Then i = 0
    '                IO.File.Delete(xBackupPath + xBdados + "_" + (i + 1).ToString + ".bak")
    '                Exit For
    '            End If
    '        Next


    '        'VAI BLOQUEAR A BASE DE DADOS PARA FAZER A CÓPIA....
    '        'Application.DoEvents() NÃO POSSO USAR ESTA FUNÇÃO DENTRO DO TIMER....

    '        Sql = "BACKUP DATABASE " + xBdados + " TO DISK = '" + xBackupPath + NomeFicheiro + "'"
    '        db.ExecuteData(Sql)



    '        If My.Computer.FileSystem.FileExists(xBackupPath + NomeFicheiro) Then



    '            'ZIPAR 

    '            Dim sDataHora As String = Format(Date.Now, "yyyyMMdd HHmmss").Replace(":", "")
    '            ClsZip.CompressFile(xBackupPath + NomeFicheiro, xBackupPath + xBdados + sDataHora + ".gz")
    '            'gz

    '            'UploadFile(xBackupPath + xBdados + sDataHora + ".gz", "ftp://ftp.gestiprod.online/" + "bdados/" + xBdados + sDataHora + ".gz", "jguedes@gestiprod.online", "30&Cl&42")
    '            UploadFile(xBackupPath + xBdados + sDataHora + ".gz", "ftp://ftp.gestiprod.com/" + xBdados + sDataHora + ".gz", "celferi_backups@gestiprod.com", "wi=4+]Q1;Fxk")



    '            Sql = "INSERT INTO BackUps (UtilizadorID, PathBackup) VALUES ('24','" & xBackupPath + NomeFicheiro & "')"
    '            db.ExecuteData(Sql)


    '        Else

    '            GravarEvento("Erro 56801 na Gravação!!")
    '            EnviarEmail("ERRO 56801 NA COPIA", "Ao fazer copia em ClsCopias.CriarCopia, não encontrou o ficheiro: " + xBackupPath + NomeFicheiro)

    '        End If



    '    Catch ex As Exception
    '        ErroVB(ex.Message, "ClsCopias: CriarCopia")
    '    Finally

    '        NomeFicheiro = Nothing

    '    End Try
    'End Sub

    Public Sub LimparCopias(ByRef sCaminho As String)


        Try


            'Dim f As String
            'For Each f In System.IO.Directory.GetFiles(sCaminho, "*.celtmp", System.IO.SearchOption.AllDirectories)
            '    System.IO.File.Delete(f)
            'Next

            Dim fileCreatedDate As DateTime
            For Each filename As String In IO.Directory.GetFiles(xBackupPath, "*.gztmp")
                fileCreatedDate = System.IO.File.GetCreationTime(filename)
                If fileCreatedDate < Now.AddDays(-1) Then
                    IO.File.Delete(filename)
                End If

            Next

        Catch ex As Exception

        End Try



    End Sub

    Public Sub CriarCopiaDiaria()

        Dim db As New ClsSqlBDados
        Dim NomeFicheiro As String = (xBdados + Format(Date.Now, "yyyyMMdd HHmmss")).Replace(":", "") + ".bak"
        Dim fullPath As String
        Dim dt As New DataTable



        Dim fbd As New FolderBrowserDialog
        Try

            Sql = "BACKUP DATABASE " + xBdados + " TO DISK = '" + xBackupPath + NomeFicheiro + "'"
            db.ExecuteData(Sql)

            fullPath = xBackupPath + NomeFicheiro

            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(fullPath)
            If fileExists Then


                'ZIPAR
                'ClsZip.CompressFile(xBackupPath + NomeFicheiro, xBackupPath + NomeFicheiro + ".gz")
                ComprimirArquivo(xBackupPath + NomeFicheiro, xBackupPath + NomeFicheiro + ".gz")

                ''ENVIAR PARA A NUVEM
                'If My.Computer.Network.Ping("137.74.207.187") Then

                '    'BACKUP DA BDADOS
                '    UploadFile(xBackupPath + NomeFicheiro + ".gz", "ftp://" & "137.74.207.187/" & NomeFicheiro + ".gz", sUtilizadorTugaTechFTP, sPasswordTugaTechFTP)


                '    Sql = "INSERT INTO BackUps (UtilizadorID, PathBackup) VALUES ('24','" & xBackupPath + NomeFicheiro & "')"
                '    db.ExecuteData(Sql)

                '    'BACKUP DAS FOTOS
                '    Sql = "SELECT ModeloId+CorId FROM ModeloCor where DtRegisto>(SELECT GETDATE()-60)"
                '    db.GetData(Sql, dt)
                '    For Each r As DataRow In dt.Rows
                '        If My.Computer.FileSystem.FileExists("C:\Girl\Fotos\" + r(0) + ".jpg") Then
                '            UploadFile("C:\Girl\Fotos\" + r(0) + ".jpg", "ftp://" & "137.74.207.187/fotos/" & r(0) + ".jpg", sUtilizadorTugaTechFTP, sPasswordTugaTechFTP)
                '        End If
                '    Next

                'Else

                '    EnviarEmail("ERRO 56896 NA COPIA", "Não foi possivel fazer upload para a web do ficheiro: " + xBackupPath + NomeFicheiro)

                'End If


                '  UploadFile(xBackupPath + NomeFicheiro + ".gz", "ftp://" & "89.114.159.233/bdados/" & NomeFicheiro + ".gz", "celferi", "2R>z9J4sPu*7PH:")

                'ENVIAR PARA A VILAR
                'If My.Computer.Network.Ping("89.114.159.233") Then

                'BACKUP DA BDADOS
                UploadFile(xBackupPath + NomeFicheiro + ".gz", "ftp://" & "89.114.159.233/bdados/" & NomeFicheiro + ".gz", "celferi", "2R>z9J4sPu*7PH:")


                Sql = "INSERT INTO BackUps (UtilizadorID, PathBackup) VALUES ('24','" & xBackupPath + NomeFicheiro & "')"
                db.ExecuteData(Sql)


                'BACKUP DAS FOTOS
                Sql = "SELECT ModeloId+CorId FROM ModeloCor where DtRegisto>(SELECT GETDATE()-60)"
                db.GetData(Sql, dt)
                For Each r As DataRow In dt.Rows
                    If My.Computer.FileSystem.FileExists("C:\Girl\Fotos\" + r(0) + ".jpg") Then
                        UploadFile("C:\Girl\Fotos\" + r(0) + ".jpg", "ftp://" & "89.114.159.233/fotos/" & r(0) + ".jpg", "celferi", "2R>z9J4sPu*7PH:")
                    End If
                Next


            End If
        Catch ex As Exception
            EnviarEmail("ERRO 56802 NA COPIA DIÁRIA", "Não foi possivel fazer upload para a web do ficheiro: " + xBackupPath + NomeFicheiro)
            'ErroVB(ex.Message, "ClsManutencaoBD: CriarCopiaDiaria")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            If Not Cmd Is Nothing Then Cmd.Dispose()
            Cmd = Nothing
            NomeFicheiro = Nothing
            fullPath = Nothing
        End Try
    End Sub




End Class
