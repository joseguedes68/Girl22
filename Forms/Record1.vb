Imports System.Runtime.InteropServices
Imports System.Text
Public Class Record1
    <DllImport("winmm.dll")> _
    Private Shared Function mciSendString(ByVal command As String, ByVal buffer As StringBuilder, ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            'Executar aplicações em background com Agendador de Tarefas Windows
            'Read more: http://www.linhadecodigo.com.br/artigo/2992/executar-aplicacoes-em-background-com-agendador-de-tarefas-windows.aspx#ixzz37cndp8uF

            Dim i As Integer
            i = mciSendString("open new type waveaudio alias capture", Nothing, 0, 0)
            Console.WriteLine(i)
            'i = mciSendString("set capture samplespersec " & lSamples & " channels " & lChannels & " bitspersample " & lBits & " alignment " & iBlockAlign & " bytespersec " & lBytesPerSec, Nothing, 0, 0)
            'Console.WriteLine(i)
            i = mciSendString("record capture", Nothing, 0, 0)
            Console.WriteLine(i)
            Me.Label1.Text = "Recording"
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim i As Integer
            i = mciSendString("save capture " & "d:\xvw.wav", Nothing, 0, 0)
            i = mciSendString("close capture", Nothing, 0, 0)
            Me.Label1.Text = "Idle"
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class