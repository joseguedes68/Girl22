Imports System.Data.SqlClient

Public Class frmExeEnc
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtCodBarras As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GirldataSet As GirlRootName.GirlDataSet
    Friend WithEvents C1FlexGrid As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdExecutar As System.Windows.Forms.Button
    Friend WithEvents txtQtd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExeEnc))
        Me.txtCodBarras = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdExecutar = New System.Windows.Forms.Button()
        Me.C1FlexGrid = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GirldataSet = New GirlRootName.GirlDataSet()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.txtQtd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btFechar = New System.Windows.Forms.Button()
        CType(Me.C1FlexGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirldataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCodBarras
        '
        Me.txtCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras.Location = New System.Drawing.Point(10, 212)
        Me.txtCodBarras.Name = "txtCodBarras"
        Me.txtCodBarras.Size = New System.Drawing.Size(220, 34)
        Me.txtCodBarras.TabIndex = 0
        Me.txtCodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(220, 28)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Talão"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdExecutar
        '
        Me.cmdExecutar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cmdExecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExecutar.Location = New System.Drawing.Point(10, 258)
        Me.cmdExecutar.Name = "cmdExecutar"
        Me.cmdExecutar.Size = New System.Drawing.Size(220, 84)
        Me.cmdExecutar.TabIndex = 4
        Me.cmdExecutar.TabStop = False
        Me.cmdExecutar.Text = "Executar"
        Me.cmdExecutar.UseVisualStyleBackColor = False
        '
        'C1FlexGrid
        '
        Me.C1FlexGrid.AllowDelete = True
        Me.C1FlexGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FlexGrid.AutoResize = False
        Me.C1FlexGrid.ColumnInfo = "10,1,0,0,0,95,Columns:0{Width:22;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1FlexGrid.Location = New System.Drawing.Point(240, 9)
        Me.C1FlexGrid.Name = "C1FlexGrid"
        Me.C1FlexGrid.Rows.DefaultSize = 19
        Me.C1FlexGrid.Size = New System.Drawing.Size(658, 462)
        Me.C1FlexGrid.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FlexGrid.Styles"))
        Me.C1FlexGrid.TabIndex = 5
        Me.C1FlexGrid.TabStop = False
        '
        'GirldataSet
        '
        Me.GirldataSet.DataSetName = "GirldataSet"
        Me.GirldataSet.Locale = New System.Globalization.CultureInfo("pt-PT")
        Me.GirldataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtData
        '
        Me.txtData.CustomFormat = "yyyy-MM-dd H:mm:ss"
        Me.txtData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtData.Location = New System.Drawing.Point(14, 74)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(216, 30)
        Me.txtData.TabIndex = 7
        Me.txtData.TabStop = False
        '
        'txtQtd
        '
        Me.txtQtd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtd.Location = New System.Drawing.Point(114, 376)
        Me.txtQtd.Name = "txtQtd"
        Me.txtQtd.Size = New System.Drawing.Size(97, 34)
        Me.txtQtd.TabIndex = 0
        Me.txtQtd.TabStop = False
        Me.txtQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 380)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 27)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Qtd :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btFechar
        '
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.btFechar.Location = New System.Drawing.Point(38, 14)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(144, 43)
        Me.btFechar.TabIndex = 8
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'frmExeEnc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(912, 485)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.C1FlexGrid)
        Me.Controls.Add(Me.cmdExecutar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtQtd)
        Me.Controls.Add(Me.txtCodBarras)
        Me.Name = "frmExeEnc"
        Me.Text = "frmExeEnc"
        CType(Me.C1FlexGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirldataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim dtTaloes As New DataTable
    Dim dtAux As New DataTable
    Dim xNrEnc As String

    Private Sub frmExeEnc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dtAux.Rows.Count > 0 Then
            If MsgBox("Quer Executar ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                cmdExecutar_Click(sender, e)
            End If
        End If
    End Sub

    'TODO: SE TODOS OS TALÕES DE UMA ENCOMENDA ESTIVEREM RECEPCIONADOS, O ESTADOENC PASSA A 'E'
    'TODO: AO FAZER DELETE DE UMA ENCOMENDA, ESTA PASSA A 'A' ANULADA OU 'F' FECHADA
    'TODO: QUANDO O NUMERO DE LINHAS ENCHEM O ECRAN, FICAM ESCONDIDAS 

    Private Sub frmExeEnc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CarregarTaloes()

        With dtAux.Columns
            .Add("SerieID", GetType(String)).Unique = True
            .Add("ModeloID", GetType(String))
            .Add("CorID", GetType(String))
            .Add("TamID", GetType(String))
            .Add("ModCorDescr", GetType(String))
            .Add("NrEnc", GetType(String))
            .Add("Obs", GetType(String))

        End With
        Me.C1FlexGrid.DataSource = dtAux
        Me.txtData.Value = Today

        C1FlexGrid.Cols("SerieID").AllowEditing = False
        C1FlexGrid.Cols("ModeloID").AllowEditing = False
        C1FlexGrid.Cols("CorID").AllowEditing = False
        C1FlexGrid.Cols("TamID").AllowEditing = False
        C1FlexGrid.Cols("ModCorDescr").AllowEditing = False
        C1FlexGrid.Cols("NrEnc").AllowEditing = False
        C1FlexGrid.Cols("Obs").AllowEditing = False

        C1FlexGrid.Cols("SerieID").Caption = "Talão"
        C1FlexGrid.Cols("ModeloID").Caption = "Modelo"
        C1FlexGrid.Cols("CorID").Caption = "Cor"
        C1FlexGrid.Cols("TamID").Caption = "Tam"
        C1FlexGrid.Cols("ModCorDescr").Caption = "Descrição"
        C1FlexGrid.Cols("NrEnc").Caption = "NrEnc"
        C1FlexGrid.Cols("Obs").Caption = "Obs"



    End Sub

    Private Sub txtCodBarras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBarras.KeyPress, txtQtd.KeyPress
        Try

            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                If Me.txtCodBarras.Text.Length = 8 Then
                    If ValidarFicha(Me.txtCodBarras.Text) Then
                        Dim dr() As DataRow
                        dr = dtTaloes.Select("SerieID = '" & Me.txtCodBarras.Text & "'", "")
                        dtAux.Rows.Add(New Object() {dr(0).Item("SerieID"), dr(0).Item("ModeloID"), dr(0).Item("CorID"), dr(0).Item("TamID"), dr(0).Item("ModCorDescr"), dr(0).Item("NrEnc"), dr(0).Item("Obs")})
                        Me.C1FlexGrid.AutoSizeCols()
                        Me.txtQtd.Text = Me.C1FlexGrid.Rows.Count - 1
                    Else
                        TalaoInvalido()
                    End If
                End If
                Me.txtCodBarras.SelectAll()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ValidarFicha(ByVal SerieID As String) As Boolean

        If dtTaloes.Select("SerieID = '" & Me.txtCodBarras.Text & "'", "").Length = 0 Then
            Return False
        End If
        If dtAux.Rows.Count > 0 Then
            If dtAux.Select("SerieID = '" & Me.txtCodBarras.Text & "'", "").Length > 0 Then
                Return False
            End If
        End If
        Return True

    End Function

    Private Sub cmdExecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExecutar.Click
        Dim db As New ClsSqlBDados
        Dim xReservados As String = ""
        Dim xReservAux As String


        Try
            If dtAux.Rows.Count > 0 Then
                'Dim data As String = txtData.Value.Year & "-" & txtData.Value.Month & "-" & txtData.Value.Day

                Dim xNovoDoc As String = PesquisaMaxNumDoc("RC")
                Dim xDocLnNr As String
                Dim xData As String = Format(CType(txtData.Text, Date), "yyyy-MM-dd H:mm:ss")
                Dim xSerie As String
                Dim xModelo As String
                Dim xCor As String
                Dim xTam As String


                Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, DataDoc, EstadoDoc, TipoTerc, OperadorID) VALUES('" & xEmp & "','" & xArmz & "','RC','" & xNovoDoc & "','" & xData & "','C','F','" & xUtilizador & "')"
                db.ExecuteData(Sql)

                For Each linha As DataRow In dtAux.Rows
                    xSerie = linha("SerieID")
                    xModelo = linha("ModeloID")
                    xCor = linha("CorID")
                    xTam = linha("TamID")

                    'VAI PESQUISAR O PRÓXIMO NUMERO DE LINHA DE DOCUMENTO

                    Sql = "SELECT ISNULL(MAX(DocLnNr),0)+1 FROM DocDet WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'RC' AND DocNr = '" & xNovoDoc & "'"
                    xDocLnNr = db.GetDataValue(Sql)

                    Sql = "Update Serie set ArmazemID='" & xArmz & "', EstadoID='S', DtEntrada='" & xData & "' WHERE SerieID='" & linha(0) & "'"
                    db.ExecuteData(Sql)

                    Sql = "SELECT ReservaModeloId+'-'+ReservaCorId+'-'+ReservaTamId+'   C-'+ArmzDest Reservado FROM Reservas where ReservaModeloId='" & xModelo & "' AND ReservaCorId='" & xCor & "' AND ReservaTamId='" & xTam & "' AND ReservaEstado='0' AND AuxRecEnc='0'"
                    xReservAux = db.GetDataValue(Sql)

                    Sql = "UPDATE RESERVAS SET AuxRecEnc='1' WHERE ReservaModeloId='" & xModelo & "' AND ReservaCorId='" & xCor & "' AND ReservaTamId='" & xTam & "' AND ReservaEstado='0'"
                    db.ExecuteData(Sql)

                    If Not xReservAux Is Nothing Then
                        xReservados = xReservAux + Chr(13) + xReservados
                    End If


                    'inserir linhas na tabela docdet
                    Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Qtd, EstadoLn, OperadorID) " & _
                        "VALUES ('" & xEmp & "', '" & xArmz & "', 'RC', '" & xNovoDoc & "', " & xDocLnNr & ", '" & xSerie & "', '" & xModelo & "', '" & xCor & "', " & xTam & ", 1, 'C','" & xUtilizador & "')"
                    If cn.State = ConnectionState.Closed Then cn.Open()
                    Cmd = New SqlCommand(Sql, cn)
                    Cmd.ExecuteNonQuery()
                Next



                Me.txtCodBarras.Clear()
                Me.txtQtd.Clear()
                dtAux.Clear()
                dtTaloes.Clear()
                CarregarTaloes()
                Me.txtCodBarras.Focus()

                Sql = "UPDATE ENCOMENDAS SET ESTADOENC='E' WHERE NrENC in (SELECT CRIADOS.EncCriada EncExecutadas FROM (SELECT Encomendas.NrEnc AS EncParaExecutar FROM Encomendas INNER JOIN Serie ON Encomendas.NrEnc = Serie.NrEnc WHERE (Encomendas.TGerado = 'TRUE') AND (Serie.EstadoID = 'G') AND (Encomendas.EstadoEnc = 'C') GROUP BY Encomendas.NrEnc) AS NEXECUTADOS RIGHT OUTER JOIN (SELECT NrEnc AS EncCriada FROM Encomendas AS Encomendas_1 WHERE (TGerado = 'TRUE') AND (EstadoEnc = 'C') GROUP BY NrEnc) AS CRIADOS ON NEXECUTADOS.EncParaExecutar = CRIADOS.EncCriada WHERE (NEXECUTADOS.EncParaExecutar IS NULL))"
                db.ExecuteData(Sql)

                If Len(Trim(xReservados)) > 1 Then
                    MsgBox("Produtos sobre Reserva : " + Chr(13) + xReservados)
                    'MsgBox("Existem Produtos sobre Reserva!!")
                End If

            End If

            Sql = "UPDATE RESERVAS SET AuxRecEnc='0' WHERE ReservaEstado='0'"
            db.ExecuteData(Sql)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "cmdExecutar_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "cmdExecutar_Click")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Private Sub C1FlexGrid_AfterDeleteRow(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid.AfterDeleteRow
        Me.dtAux.AcceptChanges()
        Me.txtQtd.Text = Me.C1FlexGrid.Rows.Count - 1
        Me.txtCodBarras.Focus()
        Me.txtCodBarras.SelectAll()
    End Sub

    Private Sub CarregarTaloes()
        'Sql = "SELECT A.SerieID, A.ModeloID, A.CorID, A.TamID, B.ModCorDescr, A.ArmazemID, A.NrEnc " & _
        '            "FROM Serie A LEFT OUTER JOIN ModeloCor B ON A.ModeloID = B.ModeloID AND A.CorID = B.CorID " & _
        '            "WHERE EstadoID = 'G'"

        Sql = "SELECT A.SerieID, A.ModeloID, A.CorID, A.TamID, B.ModCorDescr, A.NrEnc, E.FornId, A.Obs " & _
                "FROM Serie AS A LEFT OUTER JOIN Encomendas as E ON A.NrEnc = E.NrEnc  " & _
                "LEFT OUTER JOIN ModeloCor AS B ON A.ModeloID = B.ModeloID AND A.CorID = B.CorID WHERE A.EstadoID = 'G' "
        If cn.State = ConnectionState.Closed Then cn.Open()
        da = New SqlDataAdapter(Sql, cn)
        da.Fill(dtTaloes)
        cn.Close()

    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Close()
    End Sub

    'Private Sub CriaDocRecepcaoEnc()
    '    Dim xNovoDoc As String
    '    Dim xDocLnNr As String
    '    Dim xSerie As String
    '    Dim xModelo As String
    '    Dim xCor As String
    '    Dim xTam As String



    '    Try

    '        dtAux.AcceptChanges()
    '        If C1FlexGrid.Rows.Count > 0 Then
    '            xNovoDoc = PesquisaMaxNumDoc("ER")
    '            Dim xData As String = Format(CType(txtData.Text, Date), "yyyy-MM-dd")

    '            Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, " & _
    '                "DataDoc,TipoDocOrig, DocNrOrig, EstadoDoc, OperadorID) " & _
    '                "VALUES('" & xEmp & "','0000','','" & xNovoDoc & "'," & _
    '                "'0000','" & xData & "','ER','" & xData & "','C','" & xUtilizador & "')"

    '            Cmd = New SqlCommand(Sql, cn)
    '            If cn.State = ConnectionState.Closed Then cn.Open()
    '            Cmd.ExecuteNonQuery()
    '            Me.txtCodBarras.Focus()
    '        End If
    '        Application.DoEvents()

    '        'CRIAR DETALHE

    '        If cn.State = ConnectionState.Closed Then cn.Open()
    '        Sql = "SELECT ISNULL(MAX(DocLnNr),0)+1 FROM DocDet WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & xArmz & "' AND TipoDocID = 'SE' AND DocNr = '" & xNovoDoc & "'"
    '        Cmd = New SqlCommand(Sql, cn)
    '        xDocLnNr = Cmd.ExecuteScalar
    '        If CInt(xDocLnNr) >= 1 Then
    '            For Each r As DataRow In dtAux.Rows
    '                xSerie = r("SerieID")
    '                xModelo = r("ModeloID")
    '                xCor = r("CorID")
    '                xTam = r("TamID")

    '                Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Qtd, EstadoLn, OperadorID) " & _
    '                    "VALUES ('" & xEmp & "', '0000', 'ER', '" & xNovoDoc & "', " & xDocLnNr & ", '" & xSerie & "', '" & xModelo & "', '" & xCor & "', " & xTam & ", 1, 'C','" & xUtilizador & "')"
    '                If cn.State = ConnectionState.Closed Then cn.Open()
    '                Cmd = New SqlCommand(Sql, cn)
    '                Cmd.ExecuteNonQuery()

    '                xDocLnNr += 1

    '            Next
    '        End If

    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "CriaDocRecepcaoEnc")
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "CriaDocRecepcaoEnc")
    '    Finally
    '        cn.Close()
    '        Cmd.Dispose()
    '    End Try
    'End Sub

End Class
