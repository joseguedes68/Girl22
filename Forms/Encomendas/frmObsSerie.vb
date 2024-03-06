Imports System.Data.SqlClient
Imports C1.Win.C1TrueDBGrid

Public Class frmObsSerie

    Dim dtAux As New DataTable

    'EVENTOS NO FORM FrmObsSerie

    Private Sub frmObsSerie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If sFormChamador = "frmManutEncClientes" Then

                dtAux.Clear()
                tbEncomenda.Text = frmManutEncClientes.C1DGEnc.Item(frmManutEncClientes.C1DGEnc.Row, "NrEnc")
                tbEncomenda.TextAlign = HorizontalAlignment.Center
                tbEncomenda.Enabled = False
                tbEncomenda.Font = New Font("Arial", 10, FontStyle.Bold)
                tbArtigo.Text = frmManutEncClientes.C1DGEnc.Item(frmManutEncClientes.C1DGEnc.Row, "ModeloID") & "-" & frmManutEncClientes.C1DGEnc.Item(frmManutEncClientes.C1DGEnc.Row, "CorID")
                tbArtigo.TextAlign = HorizontalAlignment.Center
                tbArtigo.Enabled = False
                tbArtigo.Font = New Font("Arial", 10, FontStyle.Bold)
                tbDescr.Text = frmManutEncClientes.C1DGEnc.Item(frmManutEncClientes.C1DGEnc.Row, "ModCorDescr")
                tbDescr.TextAlign = HorizontalAlignment.Center
                tbDescr.Enabled = False
                tbDescr.Font = New Font("Arial", 10, FontStyle.Bold)
                tbObsEnc.Text = IIf(frmManutEncClientes.C1DGEnc.Item(frmManutEncClientes.C1DGEnc.Row, "Obs") Is DBNull.Value, "", frmManutEncClientes.C1DGEnc.Item(frmManutEncClientes.C1DGEnc.Row, "Obs"))
                tbObsEnc.TextAlign = HorizontalAlignment.Center
                tbObsEnc.Enabled = False
                tbObsEnc.Font = New Font("Arial", 10, FontStyle.Bold)


            Else

                dtAux.Clear()
                tbEncomenda.Text = frmManutEnc.C1DGEnc.Item(frmManutEnc.C1DGEnc.Row, "NrEnc")
                tbEncomenda.TextAlign = HorizontalAlignment.Center
                tbEncomenda.Enabled = False
                tbEncomenda.Font = New Font("Arial", 10, FontStyle.Bold)
                tbArtigo.Text = frmManutEnc.C1DGEnc.Item(frmManutEnc.C1DGEnc.Row, "ModeloID") & "-" & frmManutEnc.C1DGEnc.Item(frmManutEnc.C1DGEnc.Row, "CorID")
                tbArtigo.TextAlign = HorizontalAlignment.Center
                tbArtigo.Enabled = False
                tbArtigo.Font = New Font("Arial", 10, FontStyle.Bold)
                tbDescr.Text = frmManutEnc.C1DGEnc.Item(frmManutEnc.C1DGEnc.Row, "ModCorDescr")
                tbDescr.TextAlign = HorizontalAlignment.Center
                tbDescr.Enabled = False
                tbDescr.Font = New Font("Arial", 10, FontStyle.Bold)
                tbObsEnc.Text = IIf(frmManutEnc.C1DGEnc.Item(frmManutEnc.C1DGEnc.Row, "Obs") Is DBNull.Value, "", frmManutEnc.C1DGEnc.Item(frmManutEnc.C1DGEnc.Row, "Obs"))
                tbObsEnc.TextAlign = HorizontalAlignment.Center
                tbObsEnc.Enabled = False
                tbObsEnc.Font = New Font("Arial", 10, FontStyle.Bold)

            End If



            CarregaDados()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmObsSerie_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmObsSerie_Load")
        End Try

    End Sub

    Private Sub c1tgObsSerie_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles c1tgObsSerie.AfterColEdit


        Dim db As New ClsSqlBDados

        Try


            If e.Column.DataColumn.DataField = "Tam" Then
                Dim xSerie As String = Me.c1tgObsSerie(c1tgObsSerie.Row, "SerieID").ToString
                Dim xTam As String = Me.c1tgObsSerie(c1tgObsSerie.Row, "Tam").ToString
                If Me.c1tgObsSerie(c1tgObsSerie.Row, "SerieID").ToString <> "G" Then
                    Sql = "UPDATE SERIE SET TamId='" & xTam & "' WHERE SerieID='" & xSerie & "'"
                    db.ExecuteData(Sql)
                    Sql = "Select NrEnc from SERIE where SerieID='" & xSerie & "'"
                    ActualizaEncomenda(db.GetDataValue(Sql))
                    frmManutEnc.Act_Grelha_Tamanhos()
                    dtAux.AcceptChanges()
                Else
                    MsgBox("Não pode alterar. Talão já Executado!!")
                    CarregaDados()
                End If
            End If

            If e.Column.DataColumn.DataField = "MeiosPontos" Then

                Dim xSerie As String = Me.c1tgObsSerie(c1tgObsSerie.Row, "SerieID").ToString
                Dim xMeiosPontos As String = Me.c1tgObsSerie(c1tgObsSerie.Row, "MeiosPontos").ToString
                Sql = "UPDATE SERIE SET MeiosPontos='" & xMeiosPontos & "' WHERE SerieID='" & xSerie & "'"
                db.ExecuteData(Sql)

            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "c1tgObsSerie_AfterColEdit")
        Catch ex As Exception
            ErroVB(ex.Message, "c1tgObsSerie_AfterColEdit")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Close()
    End Sub


    'Funções 


    Private Sub CarregaDados()

        Dim db As New ClsSqlBDados

        Try

            dtAux.Clear()

            Sql = "SELECT ArmazemID, NrEnc, SerieID, TamID as Tam, EstadoID, MeiosPontos FROM Serie WHERE NrEnc = '" & tbEncomenda.Text & "' ORDER BY SerieID "
            db.GetData(Sql, dtAux)

            Me.c1tgObsSerie.DataSource = dtAux
            Me.c1tgObsSerie.AllowDelete = False
            Me.c1tgObsSerie.Splits(0).DisplayColumns("ArmazemID").Visible = False
            Me.c1tgObsSerie.Splits(0).DisplayColumns("NrEnc").Visible = False
            Me.c1tgObsSerie.Columns("SerieID").Caption = "Talão"
            Me.c1tgObsSerie.Columns("EstadoID").Caption = "Est"
            Me.c1tgObsSerie.Columns("MeiosPontos").Caption = "- MP -"
            c1tgObsSerie.AlternatingRows = True

            Dim Coluna As C1DisplayColumn
            For Each Coluna In Me.c1tgObsSerie.Splits(0).DisplayColumns
                Coluna.Style.Font = New Font("Arial", 10, FontStyle.Regular)
                Coluna.HeadingStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                Coluna.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Coluna.Locked = True
                Coluna.AutoSize()
            Next

            Me.c1tgObsSerie.Splits(0).DisplayColumns("SerieID").Locked = True
            Me.c1tgObsSerie.Splits(0).DisplayColumns("Tam").Locked = False
            Me.c1tgObsSerie.Splits(0).DisplayColumns("EstadoID").Locked = True
            Me.c1tgObsSerie.Splits(0).DisplayColumns("MeiosPontos").Locked = False


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregaDados")
        Catch ex As Exception
            ErroVB(ex.Message, "CarregaDados")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing

        End Try

    End Sub

    Private Sub ActualizaEncomenda(ByVal xNrEnc As String)
        Dim db As New ClsSqlBDados
        Dim dt As New DataTable
        Try

            Sql = "Select '0001' Emp,'0000' Arm, '" & xNrEnc & "' Enc, '1' LEnc, TamID, SUM(1) Qtd from SERIE WHERE NrEnc='" & xNrEnc & "' GROUP BY TamID "
            db.GetData(Sql, dt)

            Sql = "DELETE EncDetTam WHERE NrEnc='" & xNrEnc & "'"
            db.ExecuteData(Sql)

            For Each linha As DataRow In dt.Rows

                Sql = "INSERT INTO EncDetTam(EmpresaID, ArmazemID, NrEnc, LnEnc, TamID, Qtd) " & _
                "VALUES ('0001','0000','" & xNrEnc & "','1','" & linha("TamID") & "','" & linha("Qtd") & "')"
                db.ExecuteData(Sql)

            Next

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaEncomenda")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaEncomenda")

        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing

        End Try


    End Sub


End Class