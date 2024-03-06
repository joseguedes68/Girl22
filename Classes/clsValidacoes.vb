
Public Class clsValidacoes
    Implements IDisposable

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

    Dim _FormName As String

    Public Sub New(Optional ByVal FormName As String = Nothing)
        _FormName = FormName
    End Sub

    Public Function ValidarConnetion() As Boolean
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            Return True
        Catch ex As SqlClient.SqlException
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ValidarPermicoes(ByVal Objecto As String) As Boolean

        Dim DB As New ClsSqlBDados


        Select Case _FormName
            Case "frmMenuPos"
                Select Case Objecto
                    Case "ImportarFotosToolStripMenuItem"
                        If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then Return True
                    Case "Background"
                        If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then Return True
                    Case "VendasToolStripMenuItem"
                        If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then Return True
                    Case "ManutençãoToolStripMenuItem"
                        If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then Return True
                    Case "ToolStripMenuItem6"
                        If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then Return True
                    Case "DevoluçõesToolStripMenuItem"
                        If xPosCallByBackOffice = True Then Return True

                End Select

            Case "frmConsultaTalao"
                Select Case Objecto
                    Case "C1TDBGCTaloes"
                        If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then Return True
                End Select
            Case "frmStockFoto"
                Select Case Objecto
                    Case "PanelReservas"
                        If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then Return True
                    Case "lbReserva"
                        If xServidor = "SERVER" Or xServidor = xEnderecoHamachi Then Return True
                End Select

            Case "frmRecepcao"
                If DevolveGrupoAcesso() = "ADMIN" Then Return True

            Case "frmRecolha"
                Select Case Objecto
                    Case "ApagarRecolhas"
                        If DevolveGrupoAcesso() = "ADMIN" Then Return True
                    Case "BtFacturar"
                        Return False
                End Select

        End Select

        Return False

    End Function

End Class
