
Imports System.Data.SqlClient


Public Class frmPassword


    'Friend cbVendedorX As Integer
    'Friend cbVendedorY As Integer


    Private Sub frmPassword_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Me.Location = New Point(cbVendedorX, cbVendedorY)
        lbErro.Visible = False
    End Sub

    Private Sub btOK_Click(sender As System.Object, e As System.EventArgs) Handles btOK.Click
        If ValidarPassWord() Then
            bPassWord = True
            Me.Close()
            Me.Dispose()
        Else
            bPassWord = False
            lbErro.Text = "PassWord Inválida!"
            lbErro.Visible = True
        End If

    End Sub

    Private Sub tbPassWord_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbPassWord.KeyPress
        lbErro.Visible = False
        If e.KeyChar = ChrW(Keys.Enter) Then
            btOK_Click(sender, e)

        End If
    End Sub

    Private Sub tbPassWord_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles tbPassWord.PreviewKeyDown
        If e.KeyData = Keys.Tab Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub tbPassWord_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbPassWord.KeyDown
        If e.KeyData = Keys.Tab Then
            btOK_Click(sender, e)
        End If
    End Sub

    Private Sub btCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btCancelar.Click
        bPassWord = False
        Me.Close()
        Me.Dispose()
    End Sub



    'FUNÇÕES


    Private Function ValidarPassWord() As Boolean


        Dim db As New ClsSqlBDados

        Try

            Sql = "SELECT PassWord FROM Utilizadores WHERE UtilizadorID = " & sVendedor
            If Not db.GetDataValue(Sql) Is Nothing Then
                If tbPassWord.Text <> Desencriptar(db.GetDataValue(Sql)) Then
                    tbPassWord.Focus()
                    tbPassWord.SelectAll()
                    Return False
                Else
                    Return True
                End If
                Return False
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": GravarPassWord")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": GravarPassWord")


        End Try



    End Function



End Class