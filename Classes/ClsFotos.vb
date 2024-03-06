Public Class ClsFotos
    Implements IDisposable

    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region " IDisposable Support "
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ''TODO: free unmanaged resources when explicitly called
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

    Public Overloads Sub CarregarFotoModelo(ByVal PicBox As PictureBox, ByVal Modelo As String)
        Dim sFotoPath As String = xFotosPath & Modelo & ".jpg"
        If IO.File.Exists(sFotoPath) Then
            If IO.File.OpenRead(sFotoPath).CanRead = False Then
                PicBox.Image = Nothing
                PicBox.Visible = False
                Exit Sub
            End If
            PicBox.Image = Image.FromFile(sFotoPath)
            PicBox.SizeMode = PictureBoxSizeMode.Zoom
            PicBox.Visible = True
        Else
            PicBox.Image = Nothing
            PicBox.Visible = False
        End If
        sFotoPath = Nothing
    End Sub

    Public Overloads Sub CarregarFotoModeloCor(ByVal PicBox As PictureBox, ByVal ModeloCor As String, Optional ByVal Modelodefault As String = Nothing)
        Dim sFotoPath As String = xFotosPath & ModeloCor & ".jpg"
        Try

            If IO.File.Exists(sFotoPath) Then
                If IO.File.OpenRead(sFotoPath).CanRead = False Then
                    PicBox.Image = Nothing
                    PicBox.Visible = False
                    Exit Sub
                End If
                PicBox.Image = Image.FromFile(sFotoPath)
                PicBox.SizeMode = PictureBoxSizeMode.Zoom
                PicBox.Visible = True
            Else
                If Modelodefault IsNot Nothing Then
                    sFotoPath = xFotosPath & Modelodefault & ".jpg"
                    If IO.File.Exists(sFotoPath) Then
                        If IO.File.OpenRead(sFotoPath).CanRead = False Then
                            PicBox.Image = Nothing
                            PicBox.Visible = False
                            Exit Sub
                        End If
                        PicBox.Image = Image.FromFile(sFotoPath)
                        PicBox.SizeMode = PictureBoxSizeMode.Zoom
                        PicBox.Visible = True
                    Else
                        PicBox.Image = Nothing
                        PicBox.Visible = False
                    End If
                Else
                    PicBox.Image = Nothing
                    PicBox.Visible = False
                End If
            End If
            sFotoPath = Nothing
        Catch ex As Exception
            PicBox.Image = Nothing
            PicBox.Visible = False
            ErroVB(ex.Message, "ClsFotos : CarregarFotoModeloCor")
        Finally
            sFotoPath = Nothing
        End Try
    End Sub


    Public Overloads Sub CarregarFotoAmostra(ByVal PicBox As PictureBox, ByVal Amostra As String, Optional ByVal Modelodefault As String = Nothing)

        Dim db As New ClsSqlBDados

        Dim xFotoPathAux As String = Microsoft.VisualBasic.Left(xFotosPath, Len(xFotosPath) - 1) & "_MAQ\ENCOMENDAS"
        Dim sFotoPath As String = xFotoPathAux & "/" & Trim(Amostra) & ".jpg"
        If IO.File.Exists(sFotoPath) Then
            If IO.File.OpenRead(sFotoPath).CanRead = False Then
                PicBox.Image = Nothing
                PicBox.Visible = False
                Exit Sub
            End If
            PicBox.Image = Image.FromFile(sFotoPath)
            PicBox.SizeMode = PictureBoxSizeMode.Zoom
            PicBox.Visible = True
        Else

            Sql = "SELECT MODELOID+CORID FROM ENCOMENDAS WHERE  FornID+'-'+RefForn = '" & Amostra & "' and ESTADOENC<>'E'"

            CarregarFotoModeloCor(PicBox, db.GetDataValue(Sql), "Xok")

            'If Modelodefault IsNot Nothing Then
            '    sFotoPath = xFotosPath & Modelodefault & ".jpg"
            '    If IO.File.Exists(sFotoPath) Then
            '        If IO.File.OpenRead(sFotoPath).CanRead = False Then
            '            PicBox.Image = Nothing
            '            PicBox.Visible = False
            '            Exit Sub
            '        End If
            '        PicBox.Image = Image.FromFile(sFotoPath)
            '        PicBox.SizeMode = PictureBoxSizeMode.Zoom
            '        PicBox.Visible = True
            '    Else
            '        PicBox.Image = Nothing
            '        PicBox.Visible = False
            '    End If
            'Else
            '    PicBox.Image = Nothing
            '    PicBox.Visible = False
            'End If
            ''PicBox.Image = Nothing
            ''PicBox.Visible = False
        End If
        sFotoPath = Nothing
    End Sub




End Class
