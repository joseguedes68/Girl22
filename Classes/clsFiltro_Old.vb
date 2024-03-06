
Public Class clsFiltro_Old
    Implements IDisposable

#Region " IDisposable Support "

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ''TODO: free unmanaged resources when explicitly called
                frm.Dispose()
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

    Private WithEvents frm As New Windows.Forms.Form
    Private xFormOrigem As Form

    Public Sub New(ByVal xForm As Form, ByVal xDataTable As DataTable)
        xFormOrigem = xForm
        frm.StartPosition = FormStartPosition.CenterScreen
        'frm.MdiParent = xForm.MdiParent
        frm.AutoSizeMode = AutoSizeMode.GrowAndShrink
        frm.WindowState = FormWindowState.Normal
        InicializarForm(xDataTable)
    End Sub

    Public Sub ShowFilterForm()
        Try
            frm.AutoSize = True
            frm.ShowDialog(xFormOrigem)
        Catch ex As Exception
            ErroVB(ex.Message, "clsFiltro: ShowFilterForm")
        End Try
    End Sub

    Private Sub InicializarForm(ByVal xDataTable As DataTable)
        Dim I As Int16 = 0, J As Integer = 1
        Dim cmd As New Button
        Dim txt As TextBox
        Dim lbl As Label
        Dim cmb As ComboBox
        Try
            For Each c As DataColumn In xDataTable.Columns
                txt = New TextBox
                With txt
                    .Name = c.Caption
                    .Location = New System.Drawing.Point(100, 15 + I * 20)
                    .Font = New Font("Arial", 9, FontStyle.Regular)
                    .Size = New System.Drawing.Size(100, 20)
                    .TextAlign = HorizontalAlignment.Left
                    .Enabled = False
                    .Tag = "txt" + I.ToString
                    .TabIndex = J
                    J += 1
                End With
                frm.Controls.Add(txt)
                lbl = New Label
                With lbl
                    .Name = "lbl" + c.Caption
                    .Text = c.Caption
                    .TextAlign = ContentAlignment.MiddleRight
                    .BorderStyle = BorderStyle.None
                    .Font = New Font("Arial", 9, FontStyle.Bold)
                    .Location = New System.Drawing.Point(0, 15 + I * 20)
                    .Size = New System.Drawing.Size(90, 20)
                    .Tag = "lbl" + I.ToString
                End With
                frm.Controls.Add(lbl)
                cmb = New ComboBox
                With cmb
                    .Name = "cmb" + c.Caption
                    .Location = New System.Drawing.Point(200, 15 + I * 20)
                    .Font = New Font("Arial", 9, FontStyle.Bold)
                    .Size = New System.Drawing.Size(50, 20)
                    .Items.Add("")
                    .Items.Add(">")
                    .Items.Add("<")
                    .Items.Add("=")
                    .Items.Add("<>")
                    .Tag = "cmb" + I.ToString
                    .TabIndex = J
                    J += 1
                End With
                AddHandler cmb.TextChanged, AddressOf Me.cmb_SelectedValueChanged
                frm.Controls.Add(cmb)
                I += 1
            Next
            cmd = New Button
            With cmd
                .Name = "cmdFiltrar"
                .Location = New System.Drawing.Point(200, 30 + I * 20)
                .Font = New Font("Lucida Calligraphy", 12, FontStyle.Bold)
                .Size = New System.Drawing.Size(100, 40)
                .Text = "Filtrar"
                .TextAlign = ContentAlignment.MiddleCenter
            End With
            AddHandler cmd.Click, AddressOf Me.Button_Click
            frm.Controls.Add(cmd)
            cmd = New Button
            With cmd
                .Name = "cmdCancelar"
                .Location = New System.Drawing.Point(5, 30 + I * 20)
                .Font = New Font("Lucida Calligraphy", 12, FontStyle.Bold)
                .Size = New System.Drawing.Size(100, 40)
                .Text = "Cancelar"
                .TextAlign = ContentAlignment.MiddleCenter
            End With
            AddHandler cmd.Click, AddressOf Me.Button_Click
            frm.Controls.Add(cmd)
        Catch ex As Exception
            ErroVB(ex.Message, "clsFiltro: InicializarForm")
        Finally
            I = Nothing
            J = Nothing
            cmd = Nothing
            txt = Nothing
            lbl = Nothing
            cmb = Nothing
        End Try
    End Sub

    Private Sub cmb_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cmb As ComboBox
        cmb = CType(sender, ComboBox)
        If cmb.SelectedItem <> "" Then
            frm.Controls(cmb.Name.ToString.Substring(3, cmb.Name.ToString.Length - 3)).Enabled = True
            frm.Controls(cmb.Name.ToString.Substring(3, cmb.Name.ToString.Length - 3)).Focus()
        Else
            frm.Controls(cmb.Name.ToString.Substring(3, cmb.Name.ToString.Length - 3)).Enabled = False
        End If
    End Sub

    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cmd As Button
        cmd = CType(sender, Button)
        Select Case cmd.Text
            Case "Filtrar"
            Case "Cancelar"
                Me.frm.Close()
                Me.Dispose(True)
        End Select
    End Sub
End Class
