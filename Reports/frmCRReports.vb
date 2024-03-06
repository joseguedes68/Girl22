Public Class frmCRReports

    Friend WithEvents CRVGeral As CrystalDecisions.Windows.Forms.CrystalReportViewer


    Private Sub frmCRReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not CRVGeral Is Nothing Then CRVGeral.Dispose()
            Me.Cursor = Cursors.WaitCursor


            Me.CRVGeral = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
            Me.CRVGeral.ActiveViewIndex = -1
            Me.CRVGeral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CRVGeral.Cursor = System.Windows.Forms.Cursors.Default
            Me.CRVGeral.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CRVGeral.Location = New System.Drawing.Point(20, 50)
            Me.CRVGeral.Name = "Relatório"
            Me.CRVGeral.EnableDrillDown = False
            Me.CRVGeral.ToolPanelView = False
            'Me.CRVGeral.Size = New System.Drawing.Size(1004, 432)
            Me.CRVGeral.TabIndex = 43
            Me.Controls.Add(CRVGeral)


            If dtAuxReport.Rows.Count = 0 Then
                MsgBox("SEM DADOS PARA APRESENTAR!")
                Exit Sub
            End If


            Select Case NListagem

                Case "TRASFERENCIAS"

                    CRReportTransferencias()



            End Select


            dtAuxReport.Clear()




        Catch ex As Exception


        Finally

        End Try



    End Sub

    Private Sub frmCRReports_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not CRVGeral Is Nothing Then CRVGeral.Dispose()
        Pausa = False

    End Sub

    Private Sub CRReportTransferencias()

        Dim cryRpt As New CRTransferencias


        cryRpt.SetDataSource(dtAuxReport)
        cryRpt.SetParameterValue("Origem", xArmz)

        Me.CRVGeral.ReportSource = cryRpt
        Me.CRVGeral.Refresh()


    End Sub





End Class