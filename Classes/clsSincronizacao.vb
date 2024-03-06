Imports System.Collections.ObjectModel
Imports System.Data.SqlClient


Public Class clsSincronizacao
    Implements IDisposable
    Private ds As New DataSet("GIRL")
    Dim xFicheiro As String
    Dim DsXml As New DataSet
    Dim DSGirl As New GirlRootName.GirlDataSet
    Dim DA_Modelos As New GirlRootName.GirlDataSetTableAdapters.ModelosTableAdapter
    Dim DA_ModeloCor As New GirlRootName.GirlDataSetTableAdapters.ModeloCorTableAdapter
    Dim DA_DocCab As New GirlRootName.GirlDataSetTableAdapters.DocCabTableAdapter
    Dim DA_DocDet As New GirlRootName.GirlDataSetTableAdapters.DocDetTableAdapter
    Dim DA_Grupos As New GirlRootName.GirlDataSetTableAdapters.GruposTableAdapter
    Dim DA_Linhas As New GirlRootName.GirlDataSetTableAdapters.LinhasTableAdapter
    Dim DA_Tipos As New GirlRootName.GirlDataSetTableAdapters.TiposTableAdapter
    Dim DA_Cores As New GirlRootName.GirlDataSetTableAdapters.CoresTableAdapter
    Dim DA_Serie As New GirlRootName.GirlDataSetTableAdapters.SerieTableAdapter

#Region " IDisposable Support "
    Private disposedValue As Boolean = False        ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
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

#Region " EXPORTACAO "

    Public Sub Exportar(ByVal xLojaDestino As String, ByVal DestinoPath As String)
        Try
            Sql = "EXEC prc_Exportacao @EmpresaID = '" & xEmp & "', @Origem = '" & xArmz & "', @Destino = '" & xLojaDestino & "', @Operador = '" & xUtilizador & "'"
            If cn.State = ConnectionState.Closed Then cn.Open()
            da = New SqlDataAdapter(Sql, cn)
            da.Fill(ds)
            If ds.Tables.Count > 0 Then
                For Each t As DataTable In ds.Tables
                    If t.Rows.Count > 0 Then
                        t.TableName = t.Rows(0)(0)
                    End If
                Next
                GerarFicheiro(DestinoPath)
            End If
            Do
                ds.Tables(0).Clear()
                ds.Tables(0).Dispose()
                ds.Tables.Remove(ds.Tables(0))
            Loop While (ds.Tables.Count > 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GerarFicheiro(ByVal DestinoPath As String)
        Try
            Dim xFileName As String = ds.Tables("Ficheiro").Rows(0)("Ficheiro")
            If Not xFileName Is Nothing Then
                If Not ValidarExistencia(DestinoPath & "\" & xFileName.Trim & ".XML") Then
                    ds.WriteXmlSchema(DestinoPath & "\" & xFileName.Trim & ".XSD")
                    ds.WriteXml(DestinoPath & "\" & xFileName.Trim & ".XML")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ValidarExistencia(ByVal FilePath As String) As Boolean
        Try
            Return My.Computer.FileSystem.FileExists(FilePath)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

#End Region

#Region " IMPORTACAO LOJA"

    'TODO: GERAR SCRIPT DE IMPORTAÇÃO DINAMICO

    Public Sub VerFicheiros(ByVal FilePath As String, ByRef dt As DataTable)
        Dim files As ReadOnlyCollection(Of String)
        Dim dr As DataRow
        Try
            Dim folderExists As Boolean
            folderExists = My.Computer.FileSystem.DirectoryExists(FilePath)
            If folderExists Then
                files = My.Computer.FileSystem.FindInFiles(FilePath, Nothing, True, FileIO.SearchOption.SearchTopLevelOnly, "EXP" + xArmz + "*.XSD")
                For I As Integer = 0 To files.Count - 1
                    dr = dt.NewRow
                    dr(0) = files(I).Substring(files(I).IndexOf("EXP")).Replace(".XSD", Nothing)
                    dt.Rows.Add(dr)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            files = Nothing
            dr = Nothing
        End Try
    End Sub

    Public Sub ImportarFicheiro(ByVal FilesPath As String, ByVal FilesName As String)
        CarregarDataSet()
        CarregarXML(FilesPath, FilesName)
        SincronizarFicheiros()
        MsgBox("DS carregados")
    End Sub

    Private Function CarregarDataSet() As Boolean
        Try
            DA_Modelos.Fill(DSGirl.Modelos)
            DA_Cores.Fill(DSGirl.Cores)
            DA_DocCab.Fill(DSGirl.DocCab)
            DA_DocDet.Fill(DSGirl.DocDet)
            DA_Grupos.Fill(DSGirl.Grupos)
            DA_Linhas.Fill(DSGirl.Linhas)
            DA_ModeloCor.Fill(DSGirl.ModeloCor)
            DA_Serie.Fill(DSGirl.Serie)
            DA_Tipos.Fill(DSGirl.Tipos)
        Catch ex As Exception
            ErroVB(ex.Message, "clsSinconizacao: CarregarDataSet")
        End Try
    End Function

    Private Sub CarregarXML(ByVal FilesPath As String, ByVal FilesName As String)
        Try
            DsXml.ReadXmlSchema(FilesPath + "\" + FilesName + ".xsd")
            DsXml.ReadXml(FilesPath + "\" + FilesName + ".xml")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregarXML")
        End Try
    End Sub

    Private Sub SincronizarFicheiros()
        If SincronizarModelos() Then
            DA_Modelos.Update(DSGirl.Modelos)
        End If
        'If SincronizarCores() Then
        '    DA_Cores.Update(DSGirl.Cores)
        'End If
        If SincronizarDocCab() Then
            DA_DocCab.Update(DSGirl.DocCab)
        End If
        If SincronizarDocDet() Then
            DA_DocDet.Update(DSGirl.DocDet)
        End If
        If SincronizarGrupos() Then
            DA_Grupos.Update(DSGirl.Grupos)
        End If
        If SincronizarLinhas() Then
            DA_Linhas.Update(DSGirl.Linhas)
        End If
        If SincronizarModeloCor() Then
            DA_ModeloCor.Update(DSGirl.ModeloCor)
        End If
        If SincronizarTipos() Then
            DA_Tipos.Update(DSGirl.Tipos)
        End If
        If SincronizarSerie() Then
            DA_Serie.Update(DSGirl.Serie)
        End If
    End Sub

    Private Function SincronizarModelos() As Boolean
        Dim Dr As DataRow
        Dim Actualizado As Boolean
        Try
            For Each r As DataRow In DsXml.Tables("Modelos").Rows
                Dr = DSGirl.Modelos.NewRow
                For Each c As DataColumn In DSGirl.Modelos.Columns
                    Dr(c.ColumnName) = r(c.ColumnName)
                Next
                For Each rs As DataRow In DSGirl.Modelos.Select("ModeloID = '" + Dr("ModeloID") + "'")
                    rs.Delete()
                Next
                DSGirl.Modelos.Rows.Add(Dr)
                Actualizado = True
            Next
            Return Actualizado
        Catch ex As Exception
            ErroVB(ex.Message, "clsSincronizacao: SincronizarModelos")
            Return False
        End Try
    End Function

    Private Function SincronizarCores() As Boolean
        Dim Dr As DataRow
        Dim Actualizado As Boolean
        Try
            For Each r As DataRow In DsXml.Tables("Cores").Rows
                Dr = DSGirl.Cores.NewRow
                For Each c As DataColumn In DSGirl.Cores.Columns
                    Dr(c.ColumnName) = r(c.ColumnName)
                Next
                For Each rs As DataRow In DSGirl.Cores.Select("CorID = '" + Dr("CorID") + "'")
                    rs.Delete()
                Next
                DSGirl.Cores.Rows.Add(Dr)
                Actualizado = True
            Next
            Return Actualizado
        Catch ex As Exception
            ErroVB(ex.Message, "clsSincronizacao: SincronizarCores")
            Return False
        End Try
    End Function

    Private Function SincronizarDocCab() As Boolean
        Dim Dr As DataRow
        Dim Actualizado As Boolean
        Try
            For Each r As DataRow In DsXml.Tables("DocCab").Rows
                Dr = DSGirl.DocCab.NewRow
                For Each c As DataColumn In DSGirl.DocCab.Columns
                    Dr(c.ColumnName) = r(c.ColumnName)
                Next
                For Each rs As DataRow In DSGirl.DocCab.Select("EmpresaID = '" + Dr("EmpresaID") + "' AND ArmazemID = '" + Dr("ArmazemID") + "' AND TipoDocID = '" + Dr("TipoDocID") + "' AND DocNr = '" + Dr("DocNr") + "'")
                    rs.Delete()
                Next
                DSGirl.DocCab.Rows.Add(Dr)
                Actualizado = True
            Next
            Return Actualizado
        Catch ex As Exception
            ErroVB(ex.Message, "clsSincronizacao: SincronizarDocCab")
            Return False
        End Try
    End Function

    Private Function SincronizarDocDet() As Boolean
        Dim Dr As DataRow
        Dim Actualizado As Boolean
        Try
            For Each r As DataRow In DsXml.Tables("DocDet").Rows
                Dr = DSGirl.DocDet.NewRow
                For Each c As DataColumn In DSGirl.DocDet.Columns
                    Dr(c.ColumnName) = r(c.ColumnName)
                Next
                For Each rs As DataRow In DSGirl.DocDet.Select("EmpresaID = '" + Dr("EmpresaID") + "' AND ArmazemID = '" + Dr("ArmazemID") + "' AND TipoDocID = '" + Dr("TipoDocID") + "' AND DocNr = '" + Dr("DocNr") + "' AND DocLnNr = " + Dr("DocLnNr") + "")
                    rs.Delete()
                Next
                DSGirl.DocDet.Rows.Add(Dr)
                Actualizado = True
            Next
            Return Actualizado
        Catch ex As Exception
            ErroVB(ex.Message, "clsSincronizacao: SincronizarDocDet")
            Return False
        End Try
    End Function

    Private Function SincronizarGrupos() As Boolean
        Dim Dr As DataRow
        Dim Actualizado As Boolean
        Try
            For Each r As DataRow In DsXml.Tables("Grupos").Rows
                Dr = DSGirl.Grupos.NewRow
                For Each c As DataColumn In DSGirl.Grupos.Columns
                    Dr(c.ColumnName) = r(c.ColumnName)
                Next
                For Each rs As DataRow In DSGirl.Grupos.Select("GrupoID = '" + Dr("GrupoID") + "'")
                    rs.Delete()
                Next
                DSGirl.Grupos.Rows.Add(Dr)
                Actualizado = True
            Next
            Return Actualizado
        Catch ex As Exception
            ErroVB(ex.Message, "clsSincronizacao: SincronizarGrupos")
            Return False
        End Try
    End Function

    Private Function SincronizarLinhas() As Boolean
        Dim Dr As DataRow
        Dim Actualizado As Boolean
        Try
            For Each r As DataRow In DsXml.Tables("Linhas").Rows
                Dr = DSGirl.Linhas.NewRow
                For Each c As DataColumn In DSGirl.Linhas.Columns
                    Dr(c.ColumnName) = r(c.ColumnName)
                Next
                For Each rs As DataRow In DSGirl.Linhas.Select("LinhaID = '" + Dr("LinhaID") + "'")
                    rs.Delete()
                Next
                DSGirl.Linhas.Rows.Add(Dr)
                Actualizado = True
            Next
            Return Actualizado
        Catch ex As Exception
            ErroVB(ex.Message, "clsSincronizacao: SincronizarLinhas")
            Return False
        End Try
    End Function

    Private Function SincronizarModeloCor() As Boolean
        Dim Dr As DataRow
        Dim Actualizado As Boolean
        Try
            For Each r As DataRow In DsXml.Tables("ModeloCor").Rows
                Dr = DSGirl.ModeloCor.NewRow
                For Each c As DataColumn In DSGirl.ModeloCor.Columns
                    Dr(c.ColumnName) = r(c.ColumnName)
                Next
                For Each rs As DataRow In DSGirl.ModeloCor.Select("ModeloID = '" + Dr("ModeloID") + "' AND CorID = '" + Dr("CorID") + "'")
                    rs.Delete()
                Next
                DSGirl.ModeloCor.Rows.Add(Dr)
                Actualizado = True
            Next
            Return Actualizado
        Catch ex As Exception
            ErroVB(ex.Message, "clsSincronizacao: SincronizarModeloCor")
            Return False
        End Try
    End Function

    Private Function SincronizarTipos() As Boolean
        Dim Dr As DataRow
        Dim Actualizado As Boolean
        Try
            For Each r As DataRow In DsXml.Tables("Tipos").Rows
                Dr = DSGirl.Tipos.NewRow
                For Each c As DataColumn In DSGirl.Tipos.Columns
                    Dr(c.ColumnName) = r(c.ColumnName)
                Next
                For Each rs As DataRow In DSGirl.Tipos.Select("TipoId = '" + Dr("TipoId") + "'")
                    rs.Delete()
                Next
                DSGirl.Tipos.Rows.Add(Dr)
                Actualizado = True
            Next
            Return Actualizado
        Catch ex As Exception
            ErroVB(ex.Message, "clsSincronizacao: SincronizarTipos")
            Return False
        End Try
    End Function

    Private Function SincronizarSerie() As Boolean
        Dim Dr As DataRow
        Dim Actualizado As Boolean
        Try
            For Each r As DataRow In DsXml.Tables("Serie").Rows
                Dr = DSGirl.Serie.NewRow
                For Each c As DataColumn In DSGirl.Serie.Columns
                    Dr(c.ColumnName) = r(c.ColumnName)
                Next
                If DSGirl.Serie.Select("SerieID = '" + Dr("SerieID") + "'").Length > 0 Then
                    For Each rs As DataRow In DSGirl.Serie.Select("SerieID = '" + Dr("SerieID") + "'")
                        rs.BeginEdit()
                        If (rs("EstadoID") = "S" And Dr("EstadoID") = "T") Or (rs("EstadoID") = "T" And Dr("EstadoID") = "S") Then
                            rs("ModeloID") = Dr("ModeloID")
                            rs("CorID") = Dr("CorID")
                            rs("TamID") = Dr("TamID")
                            rs("PrecoEtiqueta") = Dr("PrecoEtiqueta")
                            rs("PrecoVenda") = Dr("PrecoVenda")
                            rs("Comissao") = Dr("Comissao")
                            rs("DocNr") = Dr("DocNr")
                            rs("DtSaida") = Dr("DtSaida")
                            rs("Obs") = Dr("Obs")
                            rs("OperadorID") = Dr("OperadorID")
                        ElseIf (rs("EstadoID") = "S" And Dr("EstadoID") = "S") Or (rs("EstadoID") = "T" And Dr("EstadoID") = "T") Then
                            rs("ModeloID") = Dr("ModeloID")
                            rs("CorID") = Dr("CorID")
                            rs("TamID") = Dr("TamID")
                            rs("ArmazemID") = Dr("ArmazemID")
                            rs("PrecoEtiqueta") = Dr("PrecoEtiqueta")
                            rs("PrecoVenda") = Dr("PrecoVenda")
                            rs("Comissao") = Dr("Comissao")
                            rs("DocNr") = Dr("DocNr")
                            rs("DtSaida") = Dr("DtSaida")
                            rs("Obs") = Dr("Obs")
                            rs("OperadorID") = Dr("OperadorID")
                        End If
                        rs.EndEdit()
                        'rs.Delete()
                    Next
                Else
                    DSGirl.Serie.Rows.Add(Dr)
                End If
                Actualizado = True
            Next
            Return Actualizado
        Catch ex As Exception
            ErroVB(ex.Message, "clsSincronizacao: SincronizarSerie")
            Return False
        End Try
    End Function

    'Private Function CarregarTabelas(ByVal dsInjun As DataSet) As Boolean
    '    Dim sColumnName As String
    '    Dim dr As DataRow
    '    Try
    '        For I As Integer = 0 To ds.Tables.Count - 1
    '            Debug.Print("*" + ds.Tables(I).TableName)
    '            If Not ds.Tables(I).TableName = "injuncoes" Then
    '                For Each r As DataRow In dsInjun.Tables(I).Rows
    '                    dr = ds.Tables(I).NewRow
    '                    For J As Integer = 0 To ds.Tables(I).Columns.Count - 1
    '                        sColumnName = ds.Tables(I).Columns(J).ColumnName
    '                        Debug.Print("-" + sColumnName)
    '                        If Not ds.Tables(I).Columns(J).AutoIncrement Then
    '                            Select Case sColumnName
    '                                Case "loteInjuncoes_Id"
    '                                    dr(sColumnName) = ds.Tables("loteInjuncoes").Rows(0)("loteInjuncoes_Id")
    '                                Case "requerente_Id"
    '                                    dr(sColumnName) = ds.Tables("requerente").Rows(0)("requerente_Id")
    '                                Case "injuncoes_Id"
    '                                    dr(sColumnName) = ds.Tables("injuncoes").Rows(0)("injuncoes_Id")
    '                                Case "injuncao_Id"
    '                                    dr(sColumnName) = ds.Tables("injuncao").Rows(I)("injuncao_Id")
    '                                Case "resumoTaxas_Id"
    '                                    dr(sColumnName) = ds.Tables("resumoTaxas").Rows(0)("resumoTaxas_Id")
    '                                Case Else
    '                                    dr(sColumnName) = r(sColumnName)
    '                            End Select
    '                        End If
    '                    Next
    '                    ds.Tables(I).Rows.Add(dr)
    '                    Debug.Print("------------------------------")
    '                Next
    '            Else
    '                dr = ds.Tables(I).NewRow
    '                dr("loteInjuncoes_Id") = ds.Tables("loteInjuncoes").Rows(0)("loteInjuncoes_Id")
    '                ds.Tables(I).Rows.Add(dr)
    '            End If
    '        Next
    '        Return True
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "clsSinconizacao: CarregarTabelas")
    '        Return False
    '    End Try
    'End Function


#End Region

End Class
