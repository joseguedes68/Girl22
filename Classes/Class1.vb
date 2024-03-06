

Imports System.IO

Public Class Sftp

    'field for storing the command for opening connections.
    Private _connect As String = ""

    Public Sub New(ByVal host As String, ByVal username As String, _
             ByVal password As String, Optional ByVal port As Integer = 22)

        ''get the full path to the systems temp folder for storing
        ''the WinSCP.com and WinSCP.exe files in.
        'Dim tempPath As String = Path.GetTempPath

        ''check to see if the WinSCP files are in the temp path.
        ''if they are not then copy them from the resources.
        'If File.Exists(tempPath & "WinSCP.com") = False Then
        '    File.WriteAllBytes(tempPath & "WinSCP.com", My.Resources.WinSCP)
        'End If
        'If File.Exists(tempPath & "WinSCP.exe") = False Then
        '    File.WriteAllBytes(tempPath & "WinSCP.exe", My.Resources.WinSCP1)
        'End If

        ''attempt to get the host key from the SSH server. This
        ''is required to make a connection to the server without storing it
        ''in the winscp.ini file.
        'Dim hostKey = GetAndStoreFingerprint(host & ":" & port.ToString)

        ''build connection string for opening ssh connections.
        ''this command needs to be run before any other commands.
        '_connect = "open sftp://" & username & ":" & password _
        '  & "@" & host & ":" & port.ToString _
        '  & " -hostKey=" & """" & hostKey & """"

    End Sub

    Public Function UploadFile(ByVal localFilePath As String, _
                   ByVal remoteFilePath As String) As Boolean

        'wrap paths in quotes.
        localFilePath = """" & localFilePath & """"
        remoteFilePath = """" & remoteFilePath & """"

        Try

            'create the required startinfo for WinSCP to run in background.
            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = Path.GetTempPath & "WinSCP.com"
            startInfo.RedirectStandardInput = True
            startInfo.RedirectStandardOutput = True
            startInfo.UseShellExecute = False
            startInfo.CreateNoWindow = True
            startInfo.WindowStyle = ProcessWindowStyle.Hidden

            'create the process object.
            Dim process As New Process
            process.StartInfo = startInfo
            process.Start()

            'run the commands
            process.StandardInput.WriteLine(_connect)
            process.StandardInput.WriteLine("put " & localFilePath & " " & remoteFilePath)
            process.StandardInput.Close()

            'get the response
            Dim response As String = process.StandardOutput.ReadToEnd
            process.WaitForExit()

            'check the result.
            Dim exitCode = process.ExitCode
            If exitCode = 0 Then
                Return True
            Else
                'find out why failed.
            End If


        Catch ex As Exception
            Return False
        End Try

        'failed because exitCode should be 0
        Return False
    End Function

    Public Function DownloadFile(ByVal remoteFilePath As String, _
                   ByVal localFilePath As String) As Boolean

        'wrap paths in quotes.
        localFilePath = """" & localFilePath & """"
        remoteFilePath = """" & remoteFilePath & """"

        Try

            'create the required startinfo for program to run in background.
            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = Path.GetTempPath & "WinSCP.com"
            startInfo.RedirectStandardInput = True
            startInfo.RedirectStandardOutput = True
            startInfo.UseShellExecute = False
            startInfo.CreateNoWindow = True
            startInfo.WindowStyle = ProcessWindowStyle.Hidden

            'create the process object.
            Dim process As New Process
            process.StartInfo = startInfo
            process.Start()

            'run the commands
            process.StandardInput.WriteLine(_connect)
            process.StandardInput.WriteLine("get " & remoteFilePath & " " & localFilePath)
            process.StandardInput.Close()

            'get the response
            Dim response As String = process.StandardOutput.ReadToEnd
            process.WaitForExit()

            'check the result.
            Dim exitCode = process.ExitCode
            If exitCode = 0 Then
                Return True
            Else
                'find out why failed.
            End If

        Catch ex As Exception
            Return False
        End Try

        'failed because exitCode should be 0
        Return False

    End Function

    Private Function GetAndStoreFingerprint(ByRef host As String) As String
        Try

            'attempt a connect and load the fingerprint from initial connect.
            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = Path.GetTempPath & "WinSCP.com"
            startInfo.RedirectStandardInput = True
            startInfo.RedirectStandardOutput = True
            startInfo.UseShellExecute = False
            startInfo.CreateNoWindow = True
            startInfo.WindowStyle = ProcessWindowStyle.Hidden

            Dim process As New Process
            process.StartInfo = startInfo
            process.Start()
            process.StandardInput.WriteLine("open " & host)
            process.StandardInput.Close()
            process.WaitForExit()

            'read the first line from the output of the command.
            Dim response As String = process.StandardOutput.ReadLine
            Dim rsa As String = ""

            'loop through all lines of the output for the line containing
            'the servers fingerprint (hostkey)
            While response <> Nothing
                If response.Contains("ssh-rsa") Then
                    rsa = response
                    Exit While
                End If
                response = process.StandardOutput.ReadLine
            End While

            'return the key
            Return rsa

        Catch ex As Exception
        End Try

        'return not found
        Return ""

    End Function

End Class
