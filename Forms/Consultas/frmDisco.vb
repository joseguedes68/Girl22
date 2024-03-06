Imports System.Management

Public Class frmdisco

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDrive.SelectedIndex = 2
    End Sub
    Private Sub btnSerial_Click(sender As Object, e As EventArgs) Handles btnSerial.Click
        If cboDrive.SelectedIndex <> -1 Then
            Try
                lblInfo.Text = "Serial : " & ClsDiscoRigido.NumeroSerial(cboDrive.Text).ToString
            Catch ex As Exception
                lblInfo.Text = "Não Disponível " & ex.Message
            End Try
        End If
    End Sub
    Private Sub btnEspacoLivre_Click(sender As Object, e As EventArgs) Handles btnEspacoLivre.Click
        If cboDrive.SelectedIndex <> -1 Then
            Try

                Dim dblLivre As Double = 0
                'Espaço
                dblLivre = Math.Round(ClsDiscoRigido.EspacoLivre(cboDrive.Text).ToString / 1024 / 1024 / 1024)
                'Divide 3 vezes por 1024 ( Byte ) para obter GB 
                '1 KB = 1024 - KiloByte
                '1 MB = 1024 ^ 2 - MegaByte
                '1 GB = 1024 ^ 3 - GigaByte
                '1 TB = 1024 ^ 4 - TeraByte
                '1 PB = 1024 ^ 5 - PetaByte
                '1 EB = 1024 ^ 6 - ExaByte
                '1 ZB = 1024 ^ 7 - ZettaByte
                '1 YB = 1024 ^ 8 - YottaByte
                '1 BB = 1024 ^ 9 - BrontoByte
                lblInfo.Text = "Livres : " & dblLivre.ToString() + " GB"

            Catch ex As Exception
                lblInfo.Text = "Não Disponível " & ex.Message
            End Try
        End If
    End Sub
    Private Sub btnTamanho_Click(sender As Object, e As EventArgs) Handles btnTamanho.Click
        If cboDrive.SelectedIndex <> -1 Then
            Try
                Dim dblTamanho As Double = 0
                'tamanho
                dblTamanho = Math.Round(ClsDiscoRigido.Tamanho(cboDrive.Text).ToString / 1024 / 1024 / 1024)
                'Divide 3 vezes por 1024 ( Byte ) para obter GB
                '1 KB = 1024 - KiloByte
                '1 MB = 1024 ^ 2 - MegaByte
                '1 GB = 1024 ^ 3 - GigaByte
                '1 TB = 1024 ^ 4 - TeraByte
                '1 PB = 1024 ^ 5 - PetaByte
                '1 EB = 1024 ^ 6 - ExaByte
                '1 ZB = 1024 ^ 7 - ZettaByte
                '1 YB = 1024 ^ 8 - YottaByte
                '1 BB = 1024 ^ 9 - BrontoByte   
                lblInfo.Text = "Tamanho : " & dblTamanho.ToString & " GB"
            Catch ex As Exception
                lblInfo.Text = "Não Disponível " & ex.Message
            End Try
        End If
    End Sub
    Private Sub btnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
        If cboDrive.SelectedIndex <> -1 Then
            Try

                Dim strDriveType As String = Nothing
                'determina o tipo do drive
                Select Case ClsDiscoRigido.TipoDrive(cboDrive.Text).ToString
                    Case "0"
                        strDriveType = "Desconhecido"
                        Exit Select
                    Case "1"
                        strDriveType = "Readable"
                        Exit Select
                    Case "2"
                        strDriveType = "Writable"
                        Exit Select
                    Case "3"
                        strDriveType = "Read / Write Suportado"
                        Exit Select
                    Case "4"
                        strDriveType = "Write Once"
                End Select
                lblInfo.Text = "Tipo : " & strDriveType
            Catch ex As Exception
                lblInfo.Text = "Não Disponível " & ex.Message
            End Try
        End If
    End Sub
    Private Sub btnInfoSistema_Click(sender As Object, e As EventArgs) Handles btnInfoSistema.Click
        If cboDrive.SelectedIndex <> -1 Then
            Try
                lblInfo.Text = "Sistema : " & ClsDiscoRigido.Sistema(cboDrive.Text).ToString
            Catch ex As Exception
                lblInfo.Text = "Não Disponível " & ex.Message
            End Try
        End If
    End Sub
    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        If cboDrive.SelectedIndex <> -1 Then
            Try
                lblInfo.Text = "Modelo : " & ClsDiscoRigido.Modelo(cboDrive.Text).ToString
            Catch ex As Exception
                lblInfo.Text = "Não Disponível " & ex.Message
            End Try
        End If
    End Sub
    Private Sub btnInfoDispositivos_Click(sender As Object, e As EventArgs) Handles btnInfoDispositivos.Click
        ' Get todos os dispositivos
        Dim mosDisks As New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
        ' percrre cada objeto (disco)
        For Each moDisk As ManagementObject In mosDisks.[Get]()
            ' Inclui o dispositivo na label 
            lblInfo.Text = lblInfo.Text & moDisk("Model").ToString() & vbCrLf
        Next
    End Sub
End Class
