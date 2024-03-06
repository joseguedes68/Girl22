Imports System.IO
Imports System.Security.AccessControl



Public Class ClsPermissoesFile




    Public Sub FilePermissions()


        Try
            Dim fileName As String = "test.xml"


            ' Add the access control entry to the file.
            AddFileSecurity(fileName, "DomainName\AccountName", FileSystemRights.ReadData, AccessControlType.Allow)

            ' Remove the access control entry from the file.
            RemoveFileSecurity(fileName, "DomainName\AccountName", FileSystemRights.ReadData, AccessControlType.Allow)

        Catch e As Exception
            MsgBox(e)
        End Try

    End Sub


    ' Adds an ACL entry on the specified file for the specified account.
    Sub AddFileSecurity(ByVal fileName As String, ByVal account As String, _
        ByVal rights As FileSystemRights, ByVal controlType As AccessControlType)

        ' Get a FileSecurity object that represents the 
        ' current security settings.
        Dim fSecurity As FileSecurity = File.GetAccessControl(fileName)

        ' Add the FileSystemAccessRule to the security settings. 
        Dim accessRule As FileSystemAccessRule = _
            New FileSystemAccessRule(account, rights, controlType)

        fSecurity.AddAccessRule(accessRule)

        ' Set the new access settings.
        File.SetAccessControl(fileName, fSecurity)

    End Sub


    ' Removes an ACL entry on the specified file for the specified account.
    Sub RemoveFileSecurity(ByVal fileName As String, ByVal account As String, _
        ByVal rights As FileSystemRights, ByVal controlType As AccessControlType)

        ' Get a FileSecurity object that represents the 
        ' current security settings.
        Dim fSecurity As FileSecurity = File.GetAccessControl(fileName)

        ' Remove the FileSystemAccessRule from the security settings. 
        fSecurity.RemoveAccessRule(New FileSystemAccessRule(account, _
            rights, controlType))

        ' Set the new access settings.
        File.SetAccessControl(fileName, fSecurity)

    End Sub






End Class
