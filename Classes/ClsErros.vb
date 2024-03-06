Imports System.IO

Public Class ClsErros

    Dim dtErros As New DataTable("Erros")
    Dim dsErros As New DataSet

    Enum x_ERROS
        SEM_COMUNICACAO = 17
    End Enum

    Public Sub ErroSql(ByVal Codigo As Integer, ByVal Descricao As String, ByVal Localizacao As String)

        MsgBox("Surgiu um erro no programa!" & Chr(13) & Chr(13) & _
               "Com o Código:" & Codigo & Chr(13) & _
               "Com Descrição:" & Descricao & Chr(13) & Chr(13) & _
               "Local do erro: " & Localizacao & Chr(13) & Chr(13) & _
               "Por favor informe o administrador do programa" & Chr(13) & _
               "a fim de relatar o problema obrigado.", _
               MsgBoxStyle.Critical, _
               Application.ProductName)
        Try
            If ValidarDirectorio() Then
                If ValidarFicheiro() Then
                    dsErros.Tables("Erros").Rows.Add(New Object() {Application.ProductName, Now, "Sql: CodError " & Codigo & " Descrição: " & Descricao, Localizacao})
                    dsErros.WriteXml("c:\" & Application.ProductName & "\LogErros.xml")
                End If
            End If

            If Codigo = x_ERROS.SEM_COMUNICACAO Then
                End
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ErroForms(ByVal Descricao As String, ByVal Localizacao As String)
        MsgBox("Surgiu um erro no programa!" & Chr(13) & Chr(13) & _
               "Com Descrição:" & Descricao & Chr(13) & Chr(13) & _
               "Local do erro: " & Localizacao & Chr(13) & Chr(13) & _
               "Por favor informe o administrador do programa" & Chr(13) & _
               "a fim de relatar o problema obrigado.", _
               MsgBoxStyle.Critical, _
               Application.ProductName)

        Try
            If ValidarDirectorio() Then
                If ValidarFicheiro() Then
                    dsErros.Tables("Erros").Rows.Add(New Object() {Application.ProductName, Now, "Forms: " & Descricao, Localizacao})
                    dsErros.WriteXml("c:\" & Application.ProductName & "\LogErros.xml")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ValidarDirectorio() As Boolean

        If Not Directory.Exists("c:\" & Application.ProductName) Then
            Directory.CreateDirectory("c:\" & Application.ProductName)
        End If
        Return True
    End Function

    Private Function ValidarFicheiro() As Boolean
        If Not File.Exists("c:\" & Application.ProductName & "\LogErros.xml") Then
            CriarTabela()
        Else
            dsErros.ReadXml("c:\" & Application.ProductName & "\LogErros.xml")
        End If
        Return True
    End Function

    Private Sub CriarTabela()
        With dtErros.Columns
            .Add("ProgramName", GetType(String))
            .Add("DateError", GetType(Date))
            .Add("MsgError", GetType(String))
            .Add("LocationError", GetType(String))
        End With
        dsErros.Tables.Add(dtErros)
    End Sub

End Class
