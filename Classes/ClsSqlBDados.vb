Imports System.Data.SqlClient

Public Class ClsSqlBDados
    'HELDER: CONTROLAR QUANDO PERDE A CONECÇÃO
    Implements IDisposable

    Protected da As SqlDataAdapter
    Protected cmd As SqlCommand
    Protected connection As SqlConnection

    'Private Sub Modelo()
    '    Da = New SqlDataAdapter
    '    Cmd = New SqlCommand
    '    Cmd.CommandText = "SQL"
    '    Cmd.CommandType = CommandType.Text
    '    Cmd.CommandTimeout = 120
    '    Cmd.Connection = cn
    '    Da.SelectCommand = Cmd
    '    Da.Fill(_DS.CS_Injuncoes)
    'End Sub

#Region " Connection "


    Protected Property cn() As SqlConnection
        Get
            If (connection Is Nothing) Then
                Me.InitConnection()
            End If
            Return Me.connection
        End Get
        Set(ByVal value As System.Data.SqlClient.SqlConnection)
            Me.connection = value
        End Set
    End Property

    Protected Sub InitConnection()
        Me.connection = New System.Data.SqlClient.SqlConnection
        Me.connection.ConnectionString = sconnectionstring
    End Sub

#End Region

#Region " Command "

    Public Property Comando() As SqlCommand
        Get
            If cmd Is Nothing Then
                IniCommand()
            End If
            Return cmd
        End Get
        Set(ByVal value As SqlCommand)
            cmd = value
        End Set
    End Property

    Private Sub IniCommand(Optional ByVal sQuery As String = "")
        cmd = New SqlCommand
        cmd.Connection = cn
    End Sub

#End Region

#Region " DataAdapter "

    Protected Property Adapter() As SqlDataAdapter
        Get
            If (da Is Nothing) Then
                iniAdapter()
            End If
            Return da
        End Get
        Set(ByVal value As SqlDataAdapter)
            da = value
        End Set
    End Property

    Protected Sub iniAdapter()
        da = New SqlDataAdapter
    End Sub

#End Region

#Region " Get Data "

#Region " GetTableData "

    'Public Overloads Function GetTableData(ByVal TableName As String) As DataTable
    '    Dim dt As New DataTable
    '    Try
    '        With Comando
    '            .CommandText = "SELECT " + getTableFields(TableName) + " FROM " + TableName
    '            .CommandType = CommandType.Text
    '        End With
    '        Adapter.SelectCommand = Comando
    '        Adapter.FillSchema(dt, SchemaType.Source)
    '        Adapter.Fill(dt)
    '        Return dt
    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "ClsSqlBDados: GetTableData")
    '        Return Nothing
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "ClsSqlBDados: GetTableData")
    '        Return Nothing
    '    Finally
    '        If Not dt Is Nothing Then dt.Dispose()
    '        dt = Nothing
    '        Adapter.Dispose()
    '        Adapter = Nothing
    '        Comando.Dispose()
    '        Comando = Nothing
    '    End Try
    'End Function

    'Public Overloads Function GetTableData(ByVal TableName As String, ByVal Filtro As String) As DataTable
    '    Dim dt As New DataTable
    '    Try
    '        With Comando
    '            .CommandText = "SELECT " + getTableFields(TableName) + " FROM " + TableName + " WHERE " + Filtro
    '            .CommandType = CommandType.Text
    '        End With
    '        Adapter.SelectCommand = Comando
    '        Adapter.FillSchema(dt, SchemaType.Source)
    '        Adapter.Fill(dt)
    '        Return dt
    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "ClsSqlBDados: GetTableData")
    '        Return Nothing
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "ClsSqlBDados: GetTableData")
    '        Return Nothing
    '    Finally
    '        If Not dt Is Nothing Then dt.Dispose()
    '        dt = Nothing
    '        Adapter.Dispose()
    '        Adapter = Nothing
    '        Comando.Dispose()
    '        Comando = Nothing
    '    End Try
    'End Function

#End Region

    'Private Function getTableFields(ByVal TableName As String) As String
    '    Dim sString As String = ""
    '    Dim dr As SqlDataReader
    '    Try
    '        Sql = "prc_sys_AnalizarTable '" & TableName & "'"
    '        dr = GetData(Sql)
    '        With dr
    '            If Not .IsClosed Then
    '                If .HasRows Then
    '                    While .Read()
    '                        sString += "[" + .Item("Column") + "], "
    '                    End While
    '                    sString = Microsoft.VisualBasic.Left(sString.Trim, sString.Trim.Length - 1)
    '                    Return sString
    '                Else
    '                    MsgBox("Tabela não existe na base de dados", MsgBoxStyle.Critical, My.Application.Info.Title)
    '                End If
    '            End If
    '        End With
    '        Return Nothing
    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "ClsSqlBDados: getTableFields")
    '        Return Nothing
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "ClsSqlBDados: getTableFields")
    '        Return Nothing
    '    Finally
    '        If cn.State = ConnectionState.Open Then cn.Close()
    '        dr = Nothing
    '        sString = Nothing
    '    End Try
    'End Function

#Region " GetData "

    Public Overloads Sub GetData(ByVal sQuery As String, ByRef dt As DataTable, Optional ByVal WithSchema As Boolean = True)
        Try
            dberror = False
            Debug.Print(sQuery)
            If ValidarConexao() Then
                With Comando
                    .CommandText = sQuery
                    .CommandType = CommandType.Text
                End With
                Adapter.SelectCommand = Comando
                If WithSchema Then Adapter.FillSchema(dt, SchemaType.Source)
                Adapter.Fill(dt)
            End If
        Catch ex As SqlException
            dberror = True
            If Not dberrorAtivo Then ErroSQL(ex.Number, ex.Message, "ClsSqlBDados: GetData: ByVal sQuery As String, ByRef dt As DataTable")
        Catch ex As Exception
            dberror = True
            ErroVB(ex.Message, "ClsSqlBDados: GetData: ByVal sQuery As String, ByRef dt As DataTable")
        Finally
            Comando.Dispose()
            Comando = Nothing
            Adapter.Dispose()
            Adapter = Nothing
        End Try
    End Sub

    Public Overloads Sub GetData(ByVal sQuery As String, ByRef ds As DataSet, Optional ByVal Schema As Boolean = True)
        Try
            dberror = False
            Debug.Print(sQuery)
            If ValidarConexao() Then
                With Comando
                    .CommandText = sQuery
                    .CommandType = CommandType.Text
                End With
                Adapter.SelectCommand = Comando
                If Schema Then Adapter.FillSchema(ds, SchemaType.Source)
                Adapter.Fill(ds)
            End If
        Catch ex As SqlException
            dberror = True
            If Not dberrorAtivo Then ErroSQL(ex.Number, ex.Message, "ClsSqlBDados: GetData: ByVal sQuery As String, ByRef dt As DataSet")
        Catch ex As Exception
            dberror = True
            ErroVB(ex.Message, "ClsSqlBDados: GetData: ByVal sQuery As String, ByRef dt As DataSet")
        Finally
            Comando.Dispose()
            Comando = Nothing
            Adapter.Dispose()
            Adapter = Nothing
        End Try
    End Sub

    Public Overloads Function GetData(ByVal sQuery As String) As SqlDataReader
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            dberror = False
            Debug.Print(sQuery)
            If ValidarConexao() Then
                cmd = New SqlCommand(sQuery, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                dr = cmd.ExecuteReader
                Return dr
            End If
            Return Nothing
        Catch ex As SqlException
            dberror = True
            If Not dberrorAtivo Then ErroSQL(ex.Number, ex.Message, "ClsSqlBDados: GetData(ByVal sQuery As String) As SqlDataReader")
            Return Nothing
        Catch ex As Exception
            dberror = True
            ErroVB(ex.Message, "ClsSqlBDados: GetData(ByVal sQuery As String) As SqlDataReader")
            Return Nothing
        Finally
            If Not cmd Is Nothing Then cmd.Dispose()
            cmd = Nothing
            dr = Nothing
            'SE FECHAR A CN O SQLDATAREADER PERDE-SE
        End Try
    End Function

    Public Overloads Function GetDataValue(ByVal sQuery As String) As String
        Try
            dberror = False
            Debug.Print(sQuery)
            If ValidarConexao() Then
                Comando = New SqlCommand(sQuery, cn)
                If cn.State = ConnectionState.Closed Then cn.Open()
                Return Comando.ExecuteScalar
            End If
            Return ""
        Catch ex As SqlException
            dberror = True
            If Not dberrorAtivo Then ErroSQL(ex.Number, ex.Message, "ClsSqlBDados: GetDataValue")
            Return Nothing
        Catch ex As Exception
            dberror = True
            ErroVB(ex.Message, "ClsSqlBDados: GetDataValue")
            Return Nothing
        Finally
            Comando.Dispose()
            Comando = Nothing
            'SE FECHAR A CN O SQLDATAREADER PERDE-SE
        End Try
    End Function


#End Region
    'alterei o timeout de 15 para 30 em 22/06/2023 vai na próxima instalação.... alterei para 120 em 14/12/2023
    Public Sub ExecuteData(ByVal sQuery As String, Optional ByVal Timeout As Integer = 120)
        Try
            dberror = False
            Debug.Print(sQuery)
            If ValidarConexao() Then
                cmd = New SqlCommand(sQuery, cn)
                cmd.CommandTimeout = Timeout
                If cn.State = ConnectionState.Closed Then cn.Open()
                cmd.ExecuteNonQuery()
            End If
        Catch ex As SqlException
            dberror = True
            If Not dberrorAtivo Then ErroSQL(ex.Number, ex.Message, "ClsSqlBDados: GetData: ByVal sQuery As String, ByRef dt As DataTable")
        Catch ex As Exception
            dberror = True
            ErroVB(ex.Message, "ClsSqlBDados: GetData: ByVal sQuery As String, ByRef dt As DataTable")
        End Try
    End Sub

#End Region

    Private Function ValidarConexao() As Boolean
        'Dim isAvailable As Boolean
        'isAvailable = My.Computer.Network.IsAvailable
        'If isAvailable Then
        '    Dim siteResponds As Boolean = False
        '    siteResponds = My.Computer.Network.Ping("SERVER")
        '    If siteResponds Then Return True
        'End If
        'MsgBox("Não existe Ligação!" + Chr(13) + "A aplicação vai ser encerrada.", MsgBoxStyle.Critical, "GIRL")
        'End
        ''return false - isto é o correcto
        Return True
    End Function

#Region " IDisposable Support "

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ''TODO: free unmanaged resources when explicitly called
                If Not connection Is Nothing Then If connection.State = ConnectionState.Open Then connection.Close()
                If Not cmd Is Nothing Then cmd.Dispose()
                cmd = Nothing
                If Not da Is Nothing Then da.Dispose()
                da = Nothing
            End If

            ''TODO: free shared unmanaged resources
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

End Class

