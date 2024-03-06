
Imports System.Data.SqlClient
Imports C1.Win.C1TrueDBGrid

Public Class frmConsultaModelosCor

    Dim dtConsultaTalao As New DataTable

    'TODO: NA LISTAGEM DE TALÕES DO NºXXX AO NºYYY SÓ DEVE LISTAR OS TALÕES EM STOCK
    Private Sub frmConsultaTalao_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarDados()
        '
        For Each Coluna As C1DisplayColumn In Me.C1TDBGCTaloes.Splits(0).DisplayColumns
            Coluna.Style.Font = New Font("Arial", 9, FontStyle.Regular)
            Coluna.HeadingStyle.Font = New Font("Arial", 9, FontStyle.Bold)
            Coluna.HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            Coluna.Style.HorizontalAlignment = AlignHorzEnum.Center
            Coluna.AutoSize()
        Next
        '
        With C1TDBGCTaloes
            With .Splits(0)
                .DisplayColumns("Talão").Width = 100
                .DisplayColumns("Descrição").Style.HorizontalAlignment = AlignHorzEnum.Near
                .DisplayColumns("Loja").Style.HorizontalAlignment = AlignHorzEnum.Near
                .DisplayColumns("PrTalão").Style.HorizontalAlignment = AlignHorzEnum.Far
            End With
            .Columns("PrTalão").NumberFormat = "Currency"
            .FilterBar = True
            .AllowFilter = False
            .FilterBarStyle.BackColor = Color.LightYellow
        End With

        WindowState = FormWindowState.Maximized


    End Sub

    Private Sub C1TDBGCTaloes_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1TDBGCTaloes.FilterChange

        C1TrueDBGridFilterChange(C1TDBGCTaloes, Me.C1TDBGCTaloes.Columns, dtConsultaTalao)

    End Sub

    Private Sub CmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdActualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActualiza.Click
        CarregarDados()
    End Sub

    Private Sub CarregarDados()

        dtConsultaTalao.Clear()
        Sql = "SELECT Serie.SerieID AS Talão, Serie.ModeloID AS Modelo, Serie.CorID AS Cor, Serie.TamID AS Tam, RTRIM(ModeloCor.ModCorDescr) AS Descrição, " & _
            "RTRIM(Serie.ArmazemID) + ' - ' + RTRIM(Armazens.ArmAbrev) AS Loja, Serie.EstadoID AS Estado, Serie.PrecoEtiqueta AS PrTalão " & _
            "FROM Serie LEFT OUTER JOIN ModeloCor ON Serie.CorID = ModeloCor.CorID AND Serie.ModeloID = ModeloCor.ModeloID LEFT OUTER JOIN " & _
            "Armazens ON Serie.ArmazemID = Armazens.ArmazemID"
        da = New SqlDataAdapter(Sql, cn)
        da.Fill(dtConsultaTalao)
        '
        C1TDBGCTaloes.DataSource = dtConsultaTalao
        C1DbNavigator.DataSource = dtConsultaTalao

    End Sub



End Class