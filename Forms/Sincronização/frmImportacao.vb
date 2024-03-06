Public Class frmImportacao
    Dim Dt As New DataTable
    Private FBDialog As New FolderBrowserDialog

    Enum TipoStatusBar
        Erro
        Informativa
    End Enum

    Private Sub frmImportacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.txtOrigem.Text = GetDefaultPath()
            InicializarDT()
            ObterFicheiroSeguinte()
            ConfExistFicheiro()
            IniciarDG()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetDefaultPath() As String
        'Dim reg As New Regedit(xEmpresa, xAplicacao)
        'Try
        '    Return reg.Ler("IMPFilePath", "C:\GIRL\Importar")
        'Catch ex As Exception
        '    ErroVB(ex.Message, Me.Name + ": GetDefaultPath")
        '    Return ""
        'Finally
        '    If Not reg Is Nothing Then reg.Dispose()
        '    reg = Nothing
        'End Try
    End Function

    Private Sub InicializarDT()
        Dim Imp As New clsSincronizacao
        Try
            With Dt.Columns
                .Add("Ficheiro", GetType(String))
            End With
            Imp.VerFicheiros(Me.txtOrigem.Text, Dt)
            Me.dgFicheiros.DataSource = Dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Imp IsNot Nothing Then Imp.Dispose()
            Imp = Nothing
        End Try
    End Sub

    Private Sub ObterFicheiroSeguinte()
        Dim db As New ClsSqlBDados
        Dim NomeFicheiro As String
        Dim Num As String
        Try
            Sql = "SELECT ISNULL(ImpContador,0)+1 FROM Armazens WHERE Activo = 1 AND ArmazemID = '" & xArmz & "'"
            Num = db.GetDataValue(Sql)
            If Num.Length = 1 Then
                Num = "00" + Num
            ElseIf Num.Length = 2 Then
                Num = "0" + Num
            End If
            NomeFicheiro = "EXP" + xArmz + Num
            Me.Label1.Text = NomeFicheiro
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniciarDG()
        Me.dgFicheiros.IniciarDG(GridView.ModoLeitura.Sem_Qualquer_Tipo_Escrita, DataGridViewSelectionMode.CellSelect, DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub cmdLocalizacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLocalizacao.Click
        'Dim sPath As String
        'Dim reg As New Regedit(xEmpresa, xAplicacao)
        'Dim FBDialog As New FolderBrowserDialog
        'Try
        '    If Not Me.txtOrigem.Text.Length > 0 Then Me.txtOrigem.Text = "c:\"
        '    sPath = Me.txtOrigem.Text
        '    FBDialog.SelectedPath = sPath
        '    Dim result As DialogResult = FBDialog.ShowDialog()
        '    If (result = Windows.Forms.DialogResult.OK) Then
        '        sPath = FBDialog.SelectedPath
        '        Me.txtOrigem.Text = sPath
        '        reg.Escrever("IMPFilePath", sPath, Microsoft.Win32.RegistryValueKind.String)
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    If Not reg Is Nothing Then reg.Dispose()
        '    reg = Nothing
        '    sPath = Nothing
        'End Try
    End Sub

    Private Sub ConfExistFicheiro()
        Dim FileName As String = Me.Label1.Text
        If Dt.Rows.Count > 0 Then
            If Dt.Select("Ficheiro = '" + FileName + "'").Length > 0 Then
                Me.cmdImportacao.Enabled = True
                Me.preencherStatusBar("Ok", TipoStatusBar.Informativa)
            Else
                Me.cmdImportacao.Enabled = False
                Me.preencherStatusBar("Dos ficheiros existentes nenhum corresponde à sequencia de importação", TipoStatusBar.Erro)
            End If
        Else
            Me.cmdImportacao.Enabled = False
            Me.preencherStatusBar("Não existem ficheiros na pasta para serem Importados", TipoStatusBar.Erro)
        End If
    End Sub

    Private Sub cmdImportacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImportacao.Click
        Dim Imp As New clsSincronizacao
        Try
            Imp.ImportarFicheiro(Me.txtOrigem.Text, Me.Label1.Text)
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": cmdImportacao_Click")
        Finally
            If Imp IsNot Nothing Then Imp.Dispose()
            Imp = Nothing
        End Try
    End Sub

    Private Sub preencherStatusBar(ByVal Texto As String, ByVal TipoMsg As TipoStatusBar)
        With Me.StatusBar
            Select Case TipoMsg
                Case TipoStatusBar.Erro
                    .ForeColor = Color.DarkRed
                Case TipoStatusBar.Informativa
                    .ForeColor = Color.DarkGreen
            End Select
            .Font = New Font("arial", 9, FontStyle.Bold)
            .Text = Texto
        End With
    End Sub

    Private Sub txtOrigem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrigem.TextChanged
        Dim Imp As New clsSincronizacao
        Try
            If Dt.Columns.Count > 0 Then
                Me.Dt.Clear()
                Imp.VerFicheiros(Me.txtOrigem.Text, Dt)
                ConfExistFicheiro()
            End If
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name + ": txtOrigem_TextChanged")
        Finally
            If Imp IsNot Nothing Then Imp.Dispose()
            Imp = Nothing
        End Try
    End Sub

End Class