Imports System.Data.SqlClient
Imports C1.Win
'Imports System.Xml
Imports System.IO.Ports
Imports System.Net.Mail
Imports System.Text

Imports System.Security.Cryptography
Imports System.Text.RegularExpressions

Imports MySql.Data.MySqlClient


Imports System.Data.OleDb
'Imports System.Data.Odbc



Imports System.Net


Module ModuleGeral

    'ULTIMA : "V20090126"


    'COMMAND LINE ARGUMENTS: /Local/0000


    Public Const xVersao As String = "V20090206"
    Public Const xEmpresa As String = "Celferi"
    Public Const xEmp As String = "0001"
    Public iUtilizadorID As Integer = 0
    Public xUtilizador As String = System.Environment.UserName.ToString()


    'Public xUtilizador As String = Mid(System.Security.Principal.WindowsIdentity.GetCurrent().Name, InStr(System.Security.Principal.WindowsIdentity.GetCurrent().Name, "\") + 1)
    'Public xEnderecoHamachi As String = "25.113.233.108"


    'Public xEnderecoHamachi As String = "2620:9b::1960:b28c"
    'Public xEnderecoHamachiP2 As String = "2620:9b::1970:d4ac"

    Public xEnderecoHamachi As String = "25.81.174.192"



    Public xAplicacao As String 'POS OR BACKOFFICE EST� DEFINIDO NOS UTILIZADORES


    Public sAplicacao As String = "CELFGEST"        'GIRL OR CELFGEST
    'Public sAplicacao As String = "GIRL"           'GIRL OR CELFGEST
    Public bDesenvolvimento As Boolean = False



    Public xServidorCelferi As String
    Public xServidorGirl As String


    'RETIRAR EM MODO DESENVOLVIMENTO
    Public ImagemFundo As Boolean = True


    Public xIvaID As Integer = 0
    Public xTaxaIva As Double = 0
    Public xServidor As String
    Public xBdados As String
    Public xBackupPath As String
    Public xArmz As String
    Public xTipoDoc As String
    Public xFiltraDataGrid As String = ""
    Public xLojaPropria As Boolean
    Public xCodAcessoLoja As String
    Public bCodAcessoLoja As Boolean = True
    Public xSaiAdmin As Boolean = False
    Public sVendedor As String
    Public sFormLoad As Boolean
    Public d2d As String = ""
    Public xArmzTemp As String
    Public xPosCallByBackOffice As Boolean
    Public xCallByPosDocs As Boolean
    Public da As SqlDataAdapter
    Public ds As New DataSet
    Public ds_Enc As New DataSet
    Public Cmd As SqlCommand
    Public dr As SqlDataReader
    Public frmRpt As frmReport
    Public frmSubRpt As frmReport
    'Public frmSplash As New frmSplashScreen
    Public frmSplash As New frmArranque
    Public xMovTalao As String
    Public xEditaReserva As Boolean
    Public xBloqueado As Boolean
    Public sIdDocCabAux As String = ""


    Public xGrupoAcesso As String = ""
    Public bTriplicado As Boolean = True

    Public sConnectionString As String
    Public sConnectionStringReport As String

    Public sConnectionStringCelfGest As String
    Public sConnectionStringGirl As String
    Public sConnectionStringCelfGestReport As String
    Public sConnectionStringGirlReport As String

    Public cn As New SqlConnection
    Public Sql As String = ""
    Public xNumDocNovo As String
    Public xNumero As String
    Public xFotoReport As Boolean
    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Public xFotosPath As String
    Public xRptPath As String
    Public xDeDataRecolha As Date
    Public xAteDataRecolha As Date
    Public dtAuxReport As New DataTable
    Public xNPag As Int16
    Public ControlaTransacao As Integer = 0
    Public xNovaTTAux As String
    Public bInstalacaoLocal As Boolean
    Public dtRecVendaSuspensa As New DataTable
    Public bRecuperaVenda As Boolean
    Public xDocNrAuxPrint As String
    Public NListagem As String
    Public Pausa As Boolean = False
    Public dberror As Boolean = False
    Public dberrorAtivo As Boolean = False
    Public bArranque As Boolean = True
    Public iPosicionamentoAux As Double = 0
    Public iNumEtiquetas As Double = 0
    Public HashAnteriorAux As String
    Public bCopiaSeguranca As Boolean = False
    Public fullPathBackup As String
    Public bPassWord As Boolean
    Public sReservasSinais As Boolean = False
    Public HashOK As Boolean = False
    Public bComunica��oAT As Boolean = False
    Public VarAux1 As String
    Public sIDClienteLoja As String = ""
    Public bEnviaEmail As Boolean = False
    Public sFormChamador As String





    Sub main()

        'MsgBox("FALTA CONTROLAR LINHAS EM BRANCO NOS DOCUMENTOS...DocDetDataGridView_CellEndEdit..")????

        Dim Login As New clsLogin

        Dim Validacoes As New clsValidacoes
        Dim db As New ClsSqlBDados

        'My.Settings.teste123 = ""
        'My.Settings.Save()

        Try
            If ValidarConfRegionais() Then

                If Login.CarregarDefenicoesServidor() Then
                    If Validacoes.ValidarConnetion() Then

                        frmArranque.Show()
                        Application.Run()
                    Else
                        MsgBox("N�O � POSSIVEL LIGAR AO SERVIDOR!!!")
                        Exit Sub
                    End If

                End If
            Else

                MsgBox("Alterar as Configura��es Regionais :" & Chr(13) & _
                   "Separador decimal: Ponto " & Chr(13) & _
                   "S�mbolo de agrupamento de d�gitos: Espa�o " & Chr(13) & _
                   "Fazer o mesmo para a moeda")
                Exit Sub

            End If


        Catch ex As Exception
            ErroVB(ex.Message, "ModuleGeral: main")
        Finally
            If Validacoes IsNot Nothing Then Validacoes.Dispose()
            Validacoes = Nothing
        End Try
    End Sub

    Public Sub C1TrueDBGridFilterChange(ByVal datagrid As C1TrueDBGrid.C1TrueDBGrid, ByVal C1TrueGrid As C1TrueDBGrid.C1DataColumnCollection, ByVal dt As DataTable, Optional ByVal sQuery As String = "")
        Try
            datagrid.MarqueeStyle = C1TrueDBGrid.MarqueeEnum.NoMarquee
            datagrid.SelectedRows.Clear()
            ' build our filter expression
            Dim sb As New System.Text.StringBuilder
            Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
            For Each dc In C1TrueGrid
                If dc.FilterText.Length > 0 Then
                    If sb.Length > 0 Then
                        sb.Append(" AND ")
                    End If
                    Dim dc1 As DataColumn = dt.Columns(dc.DataField)

                    If dc1.DataType Is System.Type.GetType("System.String") Then
                        sb.Append((dc.DataField + " like " + "'" + dc.FilterText + "*'"))
                    Else
                        sb.Append((dc.DataField + "=" + "'" + dc.FilterText + "'"))
                    End If
                End If
            Next dc
            ' filter the data
            If sQuery <> "" Then
                If sb.ToString() <> "" Then
                    dt.DefaultView.RowFilter = sQuery & " AND " & sb.ToString()
                Else
                    dt.DefaultView.RowFilter = sQuery
                End If
            Else
                dt.DefaultView.RowFilter = sb.ToString()
            End If
            'dt.DefaultView.RowFilter = "Tip like '27*' AND Loja like '0005*' AND PrTal�o>'5'"
            'dt.DefaultView.RowFilter = "Loja like '013*'"
            'dt.DefaultView.RowFilter = "loja like '013*'"

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "C1TrueDBGridFilterChange")
        Catch ex As Exception
            ErroVB(ex.Message, "C1TrueDBGridFilterChange")
        End Try
    End Sub

    Public Sub InserirFoto(ByVal PicBox As PictureBox, ByVal Caminho As String)
        Try
            If Caminho.Length > 0 Then
                With PicBox
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .Image = Image.FromFile(Caminho)
                    Dim PBHeight As Integer = .Height
                    Dim PBWidth As Integer = .Width
                    Dim FWidth As Integer = .Image.Width
                    Dim FHeight As Integer = .Image.Height
                    Dim xWidth As Integer = 0
                    Dim xHeight As Integer = 0
                    If FHeight > FWidth Then
                        Dim DifH As Integer
                        Dim DifW As Integer
                        DifH = FHeight - PBHeight
                        If DifH > 0 Then
                            DifW = FWidth * DifH / FHeight
                            xWidth = FWidth - DifW
                            xHeight = FHeight - DifH
                        End If
                    Else
                        Dim DifH As Integer
                        Dim DifW As Integer
                        DifW = FWidth - PBWidth
                        If DifW > 0 Then
                            DifH = FHeight * DifW / FWidth
                            xWidth = FWidth - DifW
                            xHeight = FHeight - DifH
                        End If
                    End If
                    .Height = xHeight
                    .Width = xWidth

                    .Visible = True


                End With
            Else
                PicBox.Visible = False
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "CarregarFoto")
        Catch ex As Exception

        End Try
    End Sub

    Public Sub C1TrueDBGrid_DigitsControl(ByVal C1TrueGrid As C1TrueDBGrid.C1TrueDBGrid, ByVal NumDigitos As Integer, ByVal Key As System.Windows.Forms.KeyEventArgs)
        Static sb As String
        If Key.KeyCode = Keys.Back Then
            sb = Microsoft.VisualBasic.Left(sb, sb.Length - 1)
        Else
            sb = sb & Key.KeyCode
        End If
        If sb.Length = NumDigitos Then
            sb = Nothing
            C1TrueGrid.Col += 1
        End If
    End Sub

    Public Function PesquisaMaxNumDoc(ByVal TipoDoc As String, Optional ByRef sLoja As String = "xpto") As String

        Try


            Dim xMaxNumDoc As String
            If sLoja = "xpto" Then sLoja = xArmz
            If cn.State = ConnectionState.Closed Then cn.Open()
            Sql = "SELECT MAX(DocNr) FROM DocCab WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & sLoja & "' AND TipoDocID = '" & TipoDoc & "'"
            Cmd = New SqlCommand(Sql, cn)
            If Not Cmd.ExecuteScalar Is DBNull.Value Then
                xMaxNumDoc = Cmd.ExecuteScalar
                If xMaxNumDoc.ToString.Substring(0, 2) <> Right(Year(Today), 2) Then
                    xMaxNumDoc = Right(Year(Today), 2) & "00000"
                End If
            Else
                xMaxNumDoc = Right(Year(Today), 2) & "00000"
            End If
            HashAnteriorAux = xMaxNumDoc
            Dim Incrementar As Integer = Microsoft.VisualBasic.Right(xMaxNumDoc, 5)
            Incrementar += 1
            xNumDocNovo = xMaxNumDoc.Substring(0, 2) & Format(Incrementar, "00000")


            'VAMOS VERIFICAR ESTE DOCUMENTO EST� CONFORME, SE N�O ESTIVER, BLOQUEIA A SERIE...
            'SE N�O ESTIVER VOU TER QUE O APAGAR, NO ENTANTO TENHO QUE VERIFICAR COMO � QUE EST� NO E-FATURA.
            'VERIFICAR HASH E VERIFICAR N�AT (S� NA GT)

            If Incrementar > 1 Then
                Dim sDocValido As String = ValidarDocumento(xEmp, sLoja, TipoDoc, xMaxNumDoc)
                If Left(sDocValido, 1) = 0 Then
                    xNumDocNovo = ""
                    MsgBox("S�rie Bloqueada! Contacte o administrador do Sistema!")
                    EnviarEmail("S�rie Bloqueada ", " S�rie : " & sLoja + " " + TipoDoc + " " + xMaxNumDoc & " Bloqueada!!")
                End If
            End If

            Return xNumDocNovo

        Catch ex As Exception

        End Try

    End Function

    Public Function ValidarDocumento(ByVal sEmp As String, ByVal sLoja As String, ByVal TipoDoc As String, ByVal xMaxNumDoc As String) As String

        Dim db As New ClsSqlBDados
        Dim sResposta As String = "0"
        Try

            If TipoDoc = "GT" Then

                Sql = "SELECT LEN(RTRIM(LTRIM(Hash4d))) FROM DocCab WHERE (EmpresaID = '" & sEmp & "') AND (ArmazemID = '" & sLoja & "') AND (TipoDocID = '" & TipoDoc & "') AND (DocNr = N'" & xMaxNumDoc & "')"
                If db.GetDataValue(Sql) = 4 Then
                    sResposta = "1"
                Else
                    sResposta = "0-Falta a Hash4d"
                    Return sResposta
                End If

                Sql = "SELECT LEN(RTRIM(LTRIM(ATDocCodeID))) FROM DocCab WHERE (EmpresaID = '" & sEmp & "') AND (ArmazemID = '" & sLoja & "') AND (TipoDocID = '" & TipoDoc & "') AND (DocNr = N'" & xMaxNumDoc & "')"
                If db.GetDataValue(Sql) > 5 Then
                    sResposta = "1"
                Else
                    sResposta = "0-Falta a ATDocCodeID"
                    Return sResposta
                End If

            ElseIf TipoDoc = "FS" Or TipoDoc = "FT" Or TipoDoc = "NC" Then

                Sql = "SELECT ISNULL(LEN(RTRIM(LTRIM(Hash4d))),0) FROM DocCab WHERE EmpresaID = '" & sEmp & "' AND ArmazemID = '" & sLoja & "' AND TipoDocID = '" & TipoDoc & "' AND DocNr = N'" & xMaxNumDoc & "'"
                If db.GetDataValue(Sql) = 4 Then
                    sResposta = "1"
                Else
                    sResposta = "0-Falta a Hash4d"
                    Return sResposta
                End If

            Else
                sResposta = "1"
            End If

            Return sResposta

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ValidarDocumento")
        Catch ex As Exception
            ErroVB(ex.Message, "ValidarDocumento")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function

    Public Function PesquisaMaxNumDocRECOLHA(ByVal TipoDoc As String, Optional ByRef sArmz As String = "XXXX") As String
        Dim xMaxNumDoc As String
        Dim db As New ClsSqlBDados

        If sArmz = "XXXX" Then sArmz = xArmz
        If cn.State = ConnectionState.Closed Then cn.Open()

        Sql = "SELECT ISNULL(MAX(DocNr),'') FROM DocCab WHERE EmpresaID = '" & xEmp & "' AND ArmazemID = '" & sArmz & "' AND TipoDocID = '" & TipoDoc & "'"


        If db.GetDataValue(Sql) <> "" Then
            xMaxNumDoc = db.GetDataValue(Sql)
            If xMaxNumDoc.ToString.Substring(0, 2) <> Right(Year(Today), 2) Then
                xMaxNumDoc = Right(Year(Today), 2) & "00000"
            End If
        Else
            xMaxNumDoc = Right(Year(Today), 2) & "00000"
        End If

        HashAnteriorAux = xMaxNumDoc
        Dim Incrementar As Integer = Microsoft.VisualBasic.Right(xMaxNumDoc, 5)
        Incrementar += 1
        xNumDocNovo = xMaxNumDoc.Substring(0, 2) & Format(Incrementar, "00000")

        Return xNumDocNovo


    End Function

    Public Sub ErroVB(ByVal Mensagem As String, ByVal Local As String)
        MsgBox("Surgiu um erro no programa!" & Chr(13) & Chr(13) & _
               "Com Descri��o:" & Mensagem & Chr(13) & Chr(13) & _
               "Local do erro: " & Local & Chr(13) & Chr(13) & _
               "Por favor informe o administrador do programa" & Chr(13) & _
               "a fim de relatar o problema obrigado.", _
               MsgBoxStyle.Critical, _
               Application.ProductName)
    End Sub

    Public Sub ErroSQL(ByVal Codigo As String, ByVal Mensagem As String, ByVal Local As String)
        MsgBox("Surgiu um erro no programa!" & Chr(13) & Chr(13) & _
               "Com o C�digo:" & Codigo & Chr(13) & _
               "Com Descri��o:" & Mensagem & Chr(13) & Chr(13) & _
               "Local do erro: " & Local & Chr(13) & Chr(13) & _
               "Por favor informe o administrador do programa" & Chr(13) & _
               "a fim de relatar o problema obrigado.", _
               MsgBoxStyle.Critical, _
               Application.ProductName)

        Select Case Codigo
            Case Is = 17
                End
                Application.Exit()
        End Select
    End Sub

    Private Function FotosPath() As Boolean
        Dim x_KeyReg As String = "SOFTWARE\\GIRL"
        Dim lerKey As New ClsRegKey
        Dim WrightKey As New ClsRegKey
        Dim xKey As String = x_KeyReg
        Dim xSubKey As String = "FOTOSPATH"
        xFotosPath = lerKey.Ler(xKey, xSubKey)
        If Not xFotosPath Is Nothing Then
            Return True
        Else
            xFotosPath = InputBox("Digite o caminho das Fotos!", Application.ProductName)
            If xFotosPath.Length > 0 Then
                WrightKey.Escrever(xKey, xSubKey, xFotosPath, Microsoft.Win32.RegistryValueKind.String)
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Sub TalaoInvalido()

        PlayLoopingBackgroundSoundFile()

        Do While MsgBox("Erro no Tal�o!", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok
            PlayLoopingBackgroundSoundFile()
        Loop

    End Sub

    Sub PlayLoopingBackgroundSoundFile()
        My.Computer.Audio.Play("C:\GIRL\ERRO.WAV", AudioPlayMode.WaitToComplete)
        My.Computer.Audio.Stop()
    End Sub

    Public Function Cronometro(ByVal Inicio As Date, ByVal Fim As Date) As Decimal
        'Fun��o para devolver o tempo de uma opera��o NOTA : declara��o do INICIO 'Dim Inicio As Date = Now
        Dim InicioSec As String = CDec(Format(Inicio, "ss"))
        Dim InicioCSec As String = CDec(Format(Inicio, "fff"))
        Dim FimSec As String = CDec(Format(Fim, "ss"))
        Dim FimCSec As String = CDec(Format(Fim, "fff"))
        Dim DifTempo As Decimal
        DifTempo = (CDec(FimSec) * 1000 + CDec(FimCSec)) - (CDec(InicioSec) * 1000 + CDec(InicioCSec))
        Return DifTempo

    End Function

    Public Function DevolveIva(ByVal IvaID As String) As Double
        Dim db As New ClsSqlBDados
        Try


            Sql = "Select TxIva from TaxIva where IvaID='" & IvaID & "'"
            Return db.GetDataValue(Sql)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DevolveIva")
        End Try

    End Function

    Private Function ValidarConfRegionais() As Boolean
        Try

            If System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "." Then
                If System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "." Then
                    If System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = " " Then
                        If System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = " " Then
                            Return True
                        End If
                    End If
                End If
            End If
            Return False

        Catch ex As Exception
            ErroVB(ex.Message, "ValidarConfRegionais")
        End Try


    End Function

    Public Function IsValidContrib(ByVal contrib As String) As Boolean

        Dim s As String = contrib
        Dim c As Char
        Dim i, checkDigit As Integer

        If (s.Length = 9) Then
            c = s.Chars(0)
            If (c.Equals("1"c) Or c.Equals("2"c) Or c.Equals("5"c) Or c.Equals("6"c) Or c.Equals("7"c) Or c.Equals("8"c) Or c.Equals("9"c)) Then
                checkDigit = Val(c) * 9
                For i = 2 To 8
                    checkDigit += Val(s.Chars(i - 1)) * (10 - i)
                Next
                checkDigit = 11 - (checkDigit Mod 11)
                If (checkDigit >= 10) Then checkDigit = 0
                If (checkDigit = Val(s.Chars(8))) Then Return True
            End If
        End If

        Return False

    End Function

    Public Function DevolveTipoArmz(ByRef xArmzem As String) As String
        Dim db As New ClsSqlBDados

        Try
            Sql = "SELECT RTRIM(EmpContrib) FROM Empresas"
            Dim xNifEmp As String = db.GetDataValue(Sql)

            Sql = "SELECT Terceiros.NIF FROM Armazens INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE Armazens.ArmazemID = '" & xArmzem & "' GROUP BY Terceiros.NIF"
            If db.GetDataValue(Sql) = xNifEmp Then
                Return "Interno"
            Else
                Return "Externo"
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DevolveTipoArmz")
        Catch ex As Exception
            ErroVB(ex.Message, "DevolveTipoArmz")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function

    Public Function DevolveComissao(ByRef xModelo As String, ByRef xCor As String, ByRef iVendedor As Integer, ByRef dPVReal As Double, ByRef xSerieID As String) As Double



        Dim db As New ClsSqlBDados
        Dim dPrecoTabela As Double
        Dim dComissao As Double = 0
        Dim dDesconto As Double = 0
        Dim bPrFixo As Boolean = False
        Dim sTabPrecoID As String



        Try

            'VERIFICAR SE O PRE�O � FIXO. SE SIM, A COMISS�O E O PRE�O DE VENDA � O QUE ESTIVER NA TABELA DOS TAL�ES.....
            Sql = "SELECT ISNULL(PrFixo,0) FROM  Serie WHERE SerieID = '" & xSerieID & "'"
            bPrFixo = db.GetDataValue(Sql)

            If bPrFixo Then
                Sql = "SELECT ISNULL(COMISSAO,0) FROM SERIE WHERE SerieID = '" & xSerieID & "'"
                Return db.GetDataValue(Sql)
            End If


            Sql = "SELECT ISNULL(PrecoVenda.Preco, 0) AS PV FROM PrecoVenda INNER JOIN Armazens ON PrecoVenda.TabPrecoID = Armazens.TabPrecoID WHERE Armazens.ArmazemID = '" & xArmz & "' AND PrecoVenda.ModeloID = '" & xModelo & "' AND PrecoVenda.CorID = '" & xCor & "'"
            If Not db.GetDataValue(Sql) Is DBNull.Value Then
                dPrecoTabela = db.GetDataValue(Sql)
                If dPrecoTabela > 0 Then
                    Sql = "SELECT TabPrecoID FROM Armazens WHERE (ArmazemID = '" & xArmz & "')"
                    sTabPrecoID = db.GetDataValue(Sql)
                Else
                    sTabPrecoID = "00"
                End If
            Else
                'N�O TEM PRE�O ATRIBUIDO PARA ESSE MODELO NESSA TABELA..
                sTabPrecoID = "00"
            End If


            'COM A TABELA DE PRE�O J� DEFINIDA VAMOS SABER QUAL A COMISS�O A ATRIBUIR
            Sql = "SELECT  C.Comissao FROM  Comissoes C, Modelos M, Armazens A  WHERE C.LinhaID = M.LinhaID AND C.ArmazemID = A.ArmazemID AND C.TabPrecoID = '" & sTabPrecoID & "' AND M.ModeloID = '" & xModelo & "' AND C.ArmazemID = '" & xArmz & "' AND C.UtilizadorID = " & iVendedor
            If db.GetDataValue(Sql) Is Nothing Then
                dComissao = 0.00000111
                EnviarEmail("Comiss�o", "Falta Comiss�o para o Vendedor: " & iVendedor & ", Armaz�m: " & xArmz & ", Tabela: " & sTabPrecoID)
            Else
                Sql = "SELECT  C.Comissao FROM  Comissoes C, Modelos M, Armazens A  WHERE C.LinhaID = M.LinhaID AND C.ArmazemID = A.ArmazemID AND C.TabPrecoID = '" & sTabPrecoID & "' AND M.ModeloID = '" & xModelo & "' AND C.ArmazemID = '" & xArmz & "' AND C.UtilizadorID = " & iVendedor
                dComissao = db.GetDataValue(Sql)
            End If

            Return dComissao


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DevolveComissao")
        Catch ex As Exception
            ErroVB(ex.Message, "DevolveComissao")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function

    Public Function DevolveGrupoAcesso() As String

        Dim db As New ClsSqlBDados

        Try

            Sql = "SELECT ISNULL(GRUPOACESSO,'') FROM UTILIZADORES WHERE UTILIZADORID=" & iUtilizadorID
            Return db.GetDataValue(Sql)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DevolveGrupoAcesso")
        Catch ex As Exception
            ErroVB(ex.Message, "DevolveGrupoAcesso")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function

    Public Function DevolveTipoNIF(ByRef PrimeiroDigitoNIF As String) As String


        Try

            'sujeito passivo de IVA

            Select Case PrimeiroDigitoNIF
                Case "x"
                    'PARTICULAR - CLIENTE FINAL SEM CONTRIBUINTE
                    Return "P"
                Case ""
                    'PARTICULAR - CLIENTE FINAL SEM CONTRIBUINTE
                    Return "P"
                Case "1"
                    'PARTICULAR - PESSOA SINGULAR
                    Return "P"
                Case "2"
                    'PARTICULAR - PESSOA SINGULAR
                    Return "P"
                Case "5"
                    'SUJEITO PASSIVO - PESSOA COLECTIVA
                    Return "SP"
                Case "6"
                    'SUJEITO PASSIVO - PESSOA COLECTIVA PUBLICA
                    Return "SP"
                Case "7"
                    'PARTICULAR - PESSOA SINGULAR
                    Return "P"
                Case "8"
                    'SUJEITO PASSIVO? - EMPRES�RIO EM NOME INDIVIDUAL
                    Return "SP"
                Case "9"
                    'SUJEITO PASSIVO? - PESSOA COLECTIVA IRREGULAR OU N� PROVIS�RIO
                    Return "SP"
            End Select

        Catch ex As Exception
            ErroVB(ex.Message, "DevolveTipoNIF")
        Finally

        End Try

    End Function

    Public Sub CarregarComissoes(ByRef sArmazem As String, ByRef sTabelaPreco As String)

        Dim db As New ClsSqlBDados
        Dim dtLinhas As New DataTable
        Dim dtUtilizadores As New DataTable

        Sql = "SELECT Linhaid FROM LINHAS"
        db.GetData(Sql, dtLinhas, False)

        Sql = "SELECT UtilizadorID FROM Utilizadores WHERE (ArmazemID = '" & sArmazem & "')"
        db.GetData(Sql, dtUtilizadores, False)


        For Each rL As DataRow In dtLinhas.Rows
            For Each rU As DataRow In dtUtilizadores.Rows
                Sql = "SELECT COUNT(*) AS Expr1 FROM Comissoes WHERE (ArmazemID = '" & sArmazem & "') AND (LinhaID = '" & rL("LinhaId") & "') AND (TabPrecoID = '" & sTabelaPreco & "') AND (UtilizadorID = " & rU("UtilizadorID") & ")"
                If db.GetDataValue(Sql) = 0 Then
                    Sql = "INSERT INTO Comissoes ([ArmazemID],[LinhaID],[TabPrecoID],[UtilizadorID],[Comissao]) values ('" & sArmazem & "','" & rL("LinhaId") & "','" & sTabelaPreco & "','" & rU("UtilizadorID") & "','0')"
                    db.ExecuteData(Sql)
                End If
            Next
        Next


        For Each rL As DataRow In dtLinhas.Rows
            For Each rU As DataRow In dtUtilizadores.Rows
                Sql = "SELECT COUNT(*) AS Expr2 FROM Comissoes WHERE (ArmazemID = '" & sArmazem & "') AND (LinhaID = '" & rL("LinhaId") & "') AND (TabPrecoID = '00') AND (UtilizadorID = " & rU("UtilizadorID") & ")"
                If db.GetDataValue(Sql) = 0 Then
                    Sql = "INSERT INTO Comissoes ([ArmazemID],[LinhaID],[TabPrecoID],[UtilizadorID],[Comissao]) values ('" & sArmazem & "','" & rL("LinhaId") & "','00','" & rU("UtilizadorID") & "','0')"
                    db.ExecuteData(Sql)
                End If
            Next
        Next

        'Sql = "INSERT INTO Comissoes ([ArmazemID],[LinhaID],[TabPrecoID],[UtilizadorID],[Comissao]) SELECT COMISSOESAUX.ArmazemID, COMISSOESAUX.LinhaID, COMISSOESAUX.TabPrecoID, COMISSOESAUX.UtilizadorID, 0 FROM (SELECT Serie.ArmazemID, Modelos.LinhaID, Armazens.TabPrecoID, Utilizadores.UtilizadorID FROM Serie INNER JOIN Modelos ON Serie.ModeloID = Modelos.ModeloID INNER JOIN Armazens ON Serie.ArmazemID = Armazens.ArmazemID INNER JOIN Utilizadores ON Armazens.ArmazemID = Utilizadores.ArmazemID GROUP BY Serie.ArmazemID, Modelos.LinhaID, Armazens.TabPrecoID, Utilizadores.UtilizadorID) AS COMISSOESAUX LEFT OUTER JOIN Comissoes ON COMISSOESAUX.ArmazemID = Comissoes.ArmazemID AND COMISSOESAUX.LinhaID = Comissoes.LinhaID AND  COMISSOESAUX.TabPrecoID = Comissoes.TabPrecoID AND COMISSOESAUX.UtilizadorID = Comissoes.UtilizadorID WHERE (Comissoes.Comissao IS NULL) AND (COMISSOESAUX.ArmazemID = '" & sArmazem & "') AND (COMISSOESAUX.TabPrecoID = '" & sTabelaPreco & "')"
        'db.ExecuteData(Sql)

    End Sub

    Public Function SistemaBloqueado() As Boolean
        Dim db As New ClsSqlBDados

        Try
            Sql = "SELECT ISNULL(Bloquear,'False') from EMPRESAS WHERE EMPRESAID='" & xEmp & "'"
            If db.GetDataValue(Sql) = True Then
                MsgBox("SISTEMA SUSPENSO TEMPORARIAMENTE! " & Chr(13) & "AGUARDE ALGUNS MINUTOS!")
                Return True
            Else
                Return False
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "VerificaSistemaBloqueado")
        Catch ex As Exception
            ErroVB(ex.Message, "VerificaSistemaBloqueado")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Function

    Public Sub GerarRecolha(ByRef gIdDocCabOrig As String)

        Try

            'TODO: ANTES DE INTEGRAR ESTE DOCUMENTO NA BASE, TEM QUE SER INTEGRADO O DOCUMENTO DAS VENDAS
            'TODO: AO INTEGRAR ESTES DOIS DOCUMENTOS, TEMOS QUE ACTUALIZAR A TABELA SERIE

            Dim db As New ClsSqlBDados

            Dim xData As String = Format(Now, "yyyy-MM-dd hh:mm:ss")
            Dim dtReAux As New DataTable
            Dim dtReDev As New DataTable
            'Dim gIdDocCabRE As Guid = Guid.NewGuid

            'RECTIFICAR : O VALOR DA VENDA TEM QUE VIR DA SEPARA��O - ATT AOS PRE�OS FIXOS...... TENHO UM SCRIPT PARA RECTIFICAR!!
            'Sql = "SELECT Unidades.UnidDescr, ModeloCor.ModCorDescr, Serie.SerieID, Serie.ModeloID, Serie.CorID, Serie.TamID, Serie.ArmazemID, Serie.PrecoEtiqueta, Serie.PrecoVenda, Serie.Comissao, Serie.NrEnc, Serie.DtEntrada, Serie.DocNr, Serie.PVndReal, Serie.DtSaida, Serie.Obs, Serie.Obs1, Serie.EstadoID, Serie.Rp, Serie.Vendedor, Serie.PrFixo, Serie.OperadorID, Serie.DtRegisto, DocDet.IdDocCab FROM Serie INNER JOIN Modelos ON Serie.ModeloID = Modelos.ModeloID INNER JOIN Unidades ON Modelos.UnidID = Unidades.UnidID INNER JOIN ModeloCor ON Serie.ModeloID = ModeloCor.ModeloID AND Serie.CorID = ModeloCor.CorID INNER JOIN DocDet ON Serie.SerieID = DocDet.SerieID WHERE (DocDet.IdDocCab = '" & gIdDocCabOrig.ToString & "')"
            'Sql = "SELECT Unidades.UnidDescr, ModeloCor.ModCorDescr, Serie.SerieID, Serie.ModeloID, Serie.CorID, Serie.TamID, Serie.ArmazemID, Serie.PrecoEtiqueta, Serie.PrecoVenda, Serie.Comissao, Serie.NrEnc, Serie.DtEntrada, Serie.DocNr, Serie.PrecoVenda, Serie.PVndReal, Serie.DtSaida, Serie.Obs, Serie.Obs1, Serie.EstadoID, Serie.Rp, Serie.Vendedor, Serie.PrFixo, Serie.OperadorID, Serie.DtRegisto, DocDet.IdDocCab, DocDet.EmpresaID FROM Serie INNER JOIN Modelos ON Serie.ModeloID = Modelos.ModeloID INNER JOIN Unidades ON Modelos.UnidID = Unidades.UnidID INNER JOIN ModeloCor ON Serie.ModeloID = ModeloCor.ModeloID AND Serie.CorID = ModeloCor.CorID INNER JOIN DocDet ON Serie.SerieID = DocDet.SerieID WHERE (DocDet.IdDocCab = '" & gIdDocCabOrig.ToString & "')"
            'Sql = "SELECT Unidades.UnidDescr, ModeloCor.ModCorDescr, Serie.SerieID, Serie.ModeloID, Serie.CorID, Serie.TamID, Serie.ArmazemID, Serie.PrecoEtiqueta, Serie.PrecoVenda, Serie.Comissao, Serie.NrEnc, Serie.DtEntrada, Serie.DocNr, Serie.PrecoVenda AS Expr1, Serie.PVndReal, Serie.DtSaida, Serie.Obs, Serie.Obs1, Serie.EstadoID, Serie.Rp, Serie.Vendedor, Serie.PrFixo, Serie.OperadorID, Serie.DtRegisto, DocDet.IdDocCab, DocDet.EmpresaID, DocCab.Obs AS ObsDoc, DocCab.Obs1 AS Obs1Doc FROM Serie INNER JOIN Modelos ON Serie.ModeloID = Modelos.ModeloID INNER JOIN Unidades ON Modelos.UnidID = Unidades.UnidID INNER JOIN ModeloCor ON Serie.ModeloID = ModeloCor.ModeloID AND Serie.CorID = ModeloCor.CorID INNER JOIN DocDet ON Serie.SerieID = DocDet.SerieID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.IdDocCab = '" & gIdDocCabOrig.ToString & "')"
            Sql = "SELECT Unidades.UnidDescr, ModeloCor.ModCorDescr, Serie.SerieID, Serie.ModeloID, Serie.CorID, Serie.TamID, Serie.ArmazemID, DocDet.Valor, Serie.Comissao, Serie.NrEnc, Serie.DtEntrada, Serie.DocNr, Serie.DtSaida, Serie.Obs, Serie.Obs1, Serie.EstadoID, Serie.Rp, Serie.Vendedor, Serie.PrFixo, Serie.OperadorID, Serie.DtRegisto, DocDet.IdDocCab, DocDet.EmpresaID, DocCab.Obs AS ObsDoc, DocCab.Obs1 AS Obs1Doc FROM Serie INNER JOIN Modelos ON Serie.ModeloID = Modelos.ModeloID INNER JOIN Unidades ON Modelos.UnidID = Unidades.UnidID INNER JOIN ModeloCor ON Serie.ModeloID = ModeloCor.ModeloID AND Serie.CorID = ModeloCor.CorID INNER JOIN DocDet ON Serie.SerieID = DocDet.SerieID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.IdDocCab = '" & gIdDocCabOrig.ToString & "')"
            db.GetData(Sql, dtReAux)

            If dtReAux.Rows.Count > 0 Then

                Dim xNovaRe As String = PesquisaMaxNumDocRECOLHA("RE", dtReAux.Rows(0)("ArmazemID"))


                Sql = "INSERT INTO DocCab(EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, Obs1, OperadorID) VALUES('" & dtReAux.Rows(0)("EmpresaID") & "','" & dtReAux.Rows(0)("ArmazemID") & "','RE','" & xNovaRe & "','" & dtReAux.Rows(0)("ArmazemID") & "',GETDATE(),'P','" & dtReAux.Rows(0)("Obs1Doc") & "','" & xUtilizador & "')"
                db.ExecuteData(Sql)

                Dim xDocLnNr As Int32 = 1

                For Each r As DataRow In dtReAux.Rows

                    'Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, Valor, PercDescLn, IvaID, Qtd, EstadoLn, OperadorID) " & _
                    '    "VALUES ('" & xEmp & "', '" & r("ArmazemID") & "', 'RE', '" & xNovaRe & "', " & xDocLnNr & ", '" & r("SerieID") & "', '" & r("ModeloID") & "', '" & r("CorID") & "', " & r("TamID") & ", '" & r("ModCorDescr") & "', '" & r("UnidDescr") & "', '" & r("PrecoVenda") & "', '" & r("Comissao") & "', '" & xIvaID & "', 1, 'G','" & xUtilizador & "')"

                    'COMISS�O ZERO E VAI BUSCAR O VALOR � SEPARA��O
                    Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, Valor, PercDescLn, IvaID, Qtd, EstadoLn, OperadorID) " & _
                        "VALUES ('" & xEmp & "', '" & r("ArmazemID") & "', 'RE', '" & xNovaRe & "', " & xDocLnNr & ", '" & r("SerieID") & "', '" & r("ModeloID") & "', '" & r("CorID") & "', " & r("TamID") & ", '" & r("ModCorDescr") & "', '" & r("UnidDescr") & "', '" & r("Valor") & "', '0', '" & xIvaID & "', 1, 'G','" & xUtilizador & "')"


                    db.ExecuteData(Sql)


                    'NOTA O UPDATE AO ESTADO DO TALAO EM XPTO123456 N�O VAI DESFAZER ISTO??
                    Sql = "UPDATE Serie SET EstadoID = 'R', DocNr = '" & xNovaRe & "', DtRegisto = GETDATE() WHERE SerieID = '" & r("SerieID") & "'"
                    db.ExecuteData(Sql)
                    xDocLnNr += 1

                Next

                'INSERIR DEVOLU��ES NA RECOLHA

                Sql = "SELECT * FROM DocDet WHERE EmpresaID='" & xEmp & "' AND ArmazemID = '" & dtReAux.Rows(0)("ArmazemID") & "' AND TipoDocID='DC' AND EstadoLN = 'G'"
                da = New SqlDataAdapter(Sql, cn)
                da.Fill(dtReDev)

                For Each r As DataRow In dtReDev.Rows
                    Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Qtd, EstadoLn, Valor, PercDescLn, VlrDescLn, OperadorID) " & _
                        "VALUES ('" & xEmp & "', '" & dtReAux.Rows(0)("ArmazemID") & "', 'RE', '" & xNovaRe & "', " & xDocLnNr & ", '" & r("SerieID") & "', '" & r("ModeloID") & "', '" & r("CorID") & "', " & r("TamID") & ", -1, 'G', " & r("Valor") & ", '" & r("PercDescLn") & "','" & r("VlrDescLn") & "' , '" & xUtilizador & "')"
                    db.ExecuteData(Sql)
                    xDocLnNr += 1
                Next

                Sql = "UPDATE DocDet SET EstadoLN = 'R' WHERE EmpresaID='" & xEmp & "' AND ArmazemID = '" & dtReAux.Rows(0)("ArmazemID") & "' AND TipoDocID='DC' AND EstadoLN = 'G'"
                db.ExecuteData(Sql)


            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GerarRecolha")
        Catch ex As Exception
            ErroVB(ex.Message, "GerarRecolha")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try

    End Sub

    Public Sub FecharEtiquetas(ByVal xDocFecho As String, ByVal gIdDocCabOrig As String)
        Try

            Dim db As New ClsSqlBDados
            Dim dtfxdetAux As New DataTable


            Sql = "SELECT SerieID FROM DocDet WHERE IdDocCab = '" & gIdDocCabOrig & "'"
            db.GetData(Sql, dtfxdetAux)

            For Each r As DataRow In dtfxdetAux.Rows
                'SE ESTADO <>'V' SIGNIFICA QUE HOUVE UMA DEVOLU��O!! LOGO O TAL�O FICA NO ESTADO S!!

                Sql = "UPDATE Serie SET EstadoID = 'R' WHERE SerieID='" & r("SerieID") & "' AND EstadoID='V'"
                db.ExecuteData(Sql)
            Next

            Sql = "SELECT COUNT(*) FROM SERIE WHERE ESTADOID='V' AND ARMAZEMID='" & xArmz & "'"
            If db.GetDataValue(Sql) > 0 Then EnviarEmail("Erro", "H� " + db.GetDataValue(Sql) + " TAL�O(�ES) ABERTOS DEPOIS DO FECHO: " + gIdDocCabOrig.ToString)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "FecharEtiquetas")
        Catch ex As Exception
            ErroVB(ex.Message, "FecharEtiquetas")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try

    End Sub

    Public Sub ListaDocEmpresa(ByVal xNumDoc As String, ByVal xTipodoc As String, Optional ByVal xTipoVia As String = "Original", Optional ByVal PrintDirect As Boolean = False)



        frmRpt = New frmReport
        frmSubRpt = New frmReport

        Dim bdados As New ClsSqlBDados
        Dim xTipoTerc As String = ""
        Dim db As New ClsSqlBDados
        Dim dt As New DataTable


        If verificar_doc(xNumDoc, xTipodoc) = False Then
            MsgBox("Documento sem numero de at. n�o � possivel imprimir!!")
            Exit Sub
        End If




        With frmRpt
            .StartPosition = FormStartPosition.CenterScreen
            .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.PageWidth





            'If xTipodoc = "VD" Or xTipodoc = "TD" Then
            '    'TD - Nota de Devolu��o da loja

            '    'Destino.TercId ----> Destino.ClienteLojaID
            '    'Terceiros ----> ClientesLoja

            '    'Sql = "SELECT '" & xTipoVia & "' AS Via, DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.ArmazemID AS xSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, SUM(DocDet.Qtd) AS Qtd, DocDet.VlrIVA FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ClientesLoja AS Destino ON DocCab.TercID = Destino.ClienteLojaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = '" & xNumDoc & "') GROUP BY DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END, Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocDet.VlrIVA"
            '    'Sql = "SELECT '" & xTipoVia & "' as Via, DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.ArmazemID xSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID DestCod, CASE WHEN DocCab.TercID='1' THEN '' WHEN DocCab.TercID<>'1' THEN Destino.Nome END as DestDescr, Destino.Morada as DestEndereco, Destino.CodPostal as DestCodPostal, Destino.Localidade as DestLocal, Destino.NIF AS DestNIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, TaxIVA.TxIVA, DocDet.TxIVA, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, sum(DocDet.Qtd) AS Qtd FROM Empresas, DocCab, DocDet, TaxIva, ClientesLoja Destino WHERE(DocCab.EmpresaID = Empresas.EmpresaID And DocDet.EmpresaID = DocCab.EmpresaID And DocDet.ArmazemID = DocCab.ArmazemID) AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr AND DocCab.TercID = Destino.ClienteLojaID AND DocCab.EmpresaID = '" & xEmp & "' AND DocCab.ArmazemID = '" & xArmz & "' AND DocCab.TipoDocID = '" & xTipodoc & "' AND DocCab.DocNr = '" & xNumDoc & "' AND DocDet.IvaID=TaxIva.IvaID Group by DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, CASE WHEN DocCab.TercID='1' THEN '' WHEN DocCab.TercID<>'1' THEN Destino.Nome END, Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, TaxIVA.TxIVA, DocDet.TxIVA, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc"
            '    'Sql = "SELECT '" & xTipoVia & "' AS Via, DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.ArmazemID AS xSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, SUM(DocDet.Qtd) AS Qtd, SUM(DocDet.VlrIVA) AS VIva FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ClientesLoja AS Destino ON DocCab.TercID = Destino.ClienteLojaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = N'" & xNumDoc & "') GROUP BY DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END, Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc"
            '    'Sql = "SELECT '" & xTipoVia & "' AS Via, DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.ArmazemID AS xSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, SUM(DocDet.Qtd) AS Qtd, DocDet.VlrIVA AS VIva FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ClientesLoja AS Destino ON DocCab.TercID = Destino.ClienteLojaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = N'" & xNumDoc & "') GROUP BY DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END, Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocDet.VlrIVA"

            '    Sql = "SELECT '" & xTipoVia & "' AS Via, DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.ArmazemID AS xSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, SUM(DocDet.Qtd) AS Qtd, DocDet.VlrIVA AS VIva, Terceiros.NomeAbrev AS LNome, Terceiros.Morada AS LMorada, Terceiros.CodPostal AS LCodPostal, Terceiros.Localidade AS LLocalidade, Terceiros.Telefone AS LTelefone, Terceiros.Site AS LSite FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ClientesLoja AS Destino ON DocCab.TercID = Destino.ClienteLojaID INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = N'" & xNumDoc & "') GROUP BY DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END, Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocDet.VlrIVA, Terceiros.Morada, Terceiros.CodPostal, Terceiros.Localidade, Terceiros.Telefone, Terceiros.Site, Terceiros.NomeAbrev"



            'Else

            '    If bTriplicado = True Then
            '        'DOCUMENTO COM TRIPLICADO
            '        Sql = "SELECT 'ORIGINAL' Copia INTO #Copia UNION SELECT 'DUPLICADO' Copia UNION SELECT 'TRIPLICADO' Copia; " & _
            '   "SELECT DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, " & _
            '   "Empresas.EmpLogo, Empresas.EmpMarca, DocCab.ArmazemID xSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID DestCod, Destino.Nome as DestDescr, Destino.Morada as DestEndereco, Destino.CodPostal as DestCodPostal, " & _
            '   "Destino.Localidade as DestLocal, Destino.NIF AS DestNIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIva.TxIva, DocCab.LocalCarga, DocCab.HoraCarga, " & _
            '   "DocCab.LocDesc, sum(DocDet.Qtd) AS Qtd, Copia " & _
            '   "FROM Empresas, DocCab, DocDet, TaxIva, Terceiros Destino, #Copia " & _
            '   "WHERE(DocCab.EmpresaID = Empresas.EmpresaID And DocDet.EmpresaID = DocCab.EmpresaID And DocDet.ArmazemID = DocCab.ArmazemID) " & _
            '   "AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr AND DocCab.TercID = Destino.TercID AND DocCab.EmpresaID = '" & xEmp & "' " & _
            '   "AND DocCab.ArmazemID = '" & xArmz & "' AND DocCab.TipoDocID = '" & xTipodoc & "' AND DocCab.DocNr = '" & xNumDoc & "' AND DocDet.IvaID=TaxIva.IvaID  " & _
            '   "Group by DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, " & _
            '   "Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, Destino.Nome, " & _
            '   "Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIva.TxIva, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, Copia ORDER BY Copia, DocDet.ModeloID, DocDet.CorID Asc "


            '        Sql = "SELECT DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.ArmazemID AS xSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, Destino.Nome AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.DocLnNr, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIVA.TxIVA, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, SUM(DocDet.Qtd) AS Qtd, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementStartTime FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Terceiros AS Destino ON DocCab.TercID = Destino.TercID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = '" & xNumDoc & "') GROUP BY DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, Destino.Nome, Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIVA.TxIVA, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementStartTime, DocDet.DocLnNr ORDER BY DocDet.DocLnNr"



            '    ElseIf bTriplicado = False Then

            '        'DOCUMENTO SEM TRIPLICADO
            '        Sql = "SELECT 'ORIGINAL' Copia INTO #Copia UNION SELECT 'DUPLICADO' Copia; " & _
            '    "SELECT DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, " & _
            '    "Empresas.EmpLogo, Empresas.EmpMarca, DocCab.ArmazemID xSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID DestCod, Destino.Nome as DestDescr, Destino.Morada as DestEndereco, Destino.CodPostal as DestCodPostal, " & _
            '    "Destino.Localidade as DestLocal, Destino.NIF AS DestNIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIva.TxIva, DocCab.LocalCarga, DocCab.HoraCarga, " & _
            '    "DocCab.LocDesc, sum(DocDet.Qtd) AS Qtd, Copia " & _
            '    "FROM Empresas, DocCab, DocDet, TaxIva, Terceiros Destino, #Copia " & _
            '    "WHERE(DocCab.EmpresaID = Empresas.EmpresaID And DocDet.EmpresaID = DocCab.EmpresaID And DocDet.ArmazemID = DocCab.ArmazemID) " & _
            '    "AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr AND DocCab.TercID = Destino.TercID AND DocCab.EmpresaID = '" & xEmp & "' " & _
            '    "AND DocCab.ArmazemID = '" & xArmz & "' AND DocCab.TipoDocID = '" & xTipodoc & "' AND DocCab.DocNr = '" & xNumDoc & "' AND DocDet.IvaID=TaxIva.IvaID  " & _
            '    "Group by DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, " & _
            '    "Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, Destino.Nome, " & _
            '    "Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIva.TxIva, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, Copia ORDER BY Copia, DocDet.ModeloID, DocDet.CorID Asc "

            '    End If

            '    bTriplicado = True

            'End If

            'Sql = "SELECT DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS DocNrSerie, DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DocNr AS Expr1, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, Destino.Nome AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.DocLnNr, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIVA.TxIVA, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, SUM(DocDet.Qtd) AS Qtd, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementStartTime, '" & xTipoVia & "' AS Via FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Terceiros AS Destino ON DocCab.TercID = Destino.TercID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = '" & xNumDoc & "') GROUP BY DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, Destino.Nome, Destino.Morada,  Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIVA.TxIVA, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementStartTime, DocDet.DocLnNr, DocCab.TipoDocID, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) ORDER BY DocDet.DocLnNr"
            'Sql = "SELECT DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS DocNrSerie, DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, Destino.Nome AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.DocLnNr, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIVA.TxIVA, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocDet.Qtd, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementStartTime, DocCab.ATDocCodeID, DocCab.Hash4d, '" & xTipoVia & "' AS Via, CAST(ROUND(DocDet.Valor/(1+TaxIVA.TxIVA),4) AS NUMERIC(36,4)) AS ValorLiq, CAST(ROUND(DocDet.VlrDescLn/(1+TaxIVA.TxIVA),4) AS NUMERIC(36,4)) AS VlrDescLnLiq FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Terceiros AS Destino ON DocCab.TercID = Destino.TercID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = '" & xNumDoc & "') ORDER BY DocDet.DocLnNr"
            'Sql = "SELECT DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS DocNrSerie, DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, Destino.Nome AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.DocLnNr, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIVA.TxIVA, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocDet.Qtd, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementStartTime, DocCab.ATDocCodeID, DocCab.Hash4d, 'Original' AS Via, CAST(ROUND(DocDet.Valor / (1 + TaxIVA.TxIVA), 4) AS NUMERIC(36, 4)) AS ValorLiq, CAST(ROUND(DocDet.VlrDescLn / (1 + TaxIVA.TxIVA), 4) AS NUMERIC(36, 4)) AS VlrDescLnLiq, DocCab.IdDocCab, DocCab.DocOrig FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Terceiros AS Destino ON DocCab.TercID = Destino.TercID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = '" & xNumDoc & "') ORDER BY DocDet.DocLnNr"
            'Sql = "SELECT DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS DocNrSerie, DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, Destino.Nome AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.DocLnNr, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIVA.TxIVA, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocDet.Qtd, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementStartTime, DocCab.ATDocCodeID, DocCab.Hash4d, '" & xTipoVia & "' AS Via, CAST(ROUND(DocDet.Valor / (1 + TaxIVA.TxIVA), 4) AS NUMERIC(36, 4)) AS ValorLiq, CAST(ROUND(DocDet.VlrDescLn / (1 + TaxIVA.TxIVA), 4) AS NUMERIC(36, 4)) AS VlrDescLnLiq, DocCab.IdDocCab, CASE DocCab.DocOrig WHEN '' THEN '' ELSE 'Doc. Origem: ' + DocCab.DocOrig END DocOrig FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Terceiros AS Destino ON DocCab.TercID = Destino.TercID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = '" & xNumDoc & "') ORDER BY DocDet.DocLnNr "
            Sql = "SELECT DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS DocNrSerie, DocCab.TipoDocID, DocCab.ArmazemID, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, Destino.Nome AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.DocLnNr, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, TaxIVA.TxIVA, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocDet.Qtd, DocCab.AddressDetailCarga, DocCab.CityCarga, DocCab.PostalCodeCarga, DocCab.CountryCarga, DocCab.AddressDetailDescarga, DocCab.CityDescarga, DocCab.PostalCodeDescarga, DocCab.CountryDescarga, DocCab.MovementStartTime, DocCab.ATDocCodeID, DocCab.Hash4d, '" & xTipoVia & "' AS Via, CAST(ROUND(DocDet.Valor / (1 + TaxIVA.TxIVA), 4) AS NUMERIC(36, 4)) AS ValorLiq, CAST(ROUND(DocDet.VlrDescLn / (1 + TaxIVA.TxIVA), 4) AS NUMERIC(36, 4)) AS VlrDescLnLiq, DocCab.IdDocCab, CASE DocCab.DocOrig WHEN '' THEN '' ELSE 'Doc. Origem: ' + DocCab.DocOrig END DocOrig, DocDet.ProductCode FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN Terceiros AS Destino ON DocCab.TercID = Destino.TercID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = '" & xNumDoc & "') ORDER BY DocDet.DocLnNr "




            db.GetData(Sql, dt)



            'TODO: A FUN��O SEGUINTE VAI VARIAR EM FUN��O DO TIPO DE DOCUMENTO
            If xTipodoc = "GT" Then .C1Report1.Load(xRptPath & "DocGuiaTransporte.xml", "GuiaTransp")
            If xTipodoc = "FT" Then .C1Report1.Load(xRptPath & "DocFactura.xml", "Factura")
            If xTipodoc = "NC" Then .C1Report1.Load(xRptPath & "DocNC.xml", "NC")
            If xTipodoc = "ND" Then .C1Report1.Load(xRptPath & "DocND.xml", "ND")

            If xTipodoc = "GA" Then .C1Report1.Load(xRptPath & "DocGuiaMovAP.xml", "GuiaMAP")
            If xTipodoc = "FC" Then .C1Report1.Load(xRptPath & "DocFacturaConsignacao.xml", "Consignacao")
            If xTipodoc = "VD" Then .C1Report1.Load(xRptPath & "DocVndDinheiro.xml", "DocVndDinheiro")
            If xTipodoc = "TD" Then .C1Report1.Load(xRptPath & "DocTalaoDevolucao.xml", "DocTalaoDevolucao")
            If xTipodoc = "TT" Then .C1Report1.Load(xRptPath & "DocVndDinheiro.xml", "DocVndDinheiro")


            .C1Report1.DataSource.ConnectionString = sConnectionStringReport
            .C1Report1.DataSource.RecordSource = Sql


            If xTipodoc = "FT" Or xTipodoc = "NC" Then
                frmSubRpt.C1Report1 = .C1Report1.Fields("srIva").Subreport
                frmSubRpt.C1Report1.DataSource.ConnectionString = sConnectionStringReport
                'frmSubRpt.C1Report1.DataSource.RecordSource = "SELECT TaxIVA.TxIVA, (DocDet.Valor - DocDet.VlrDescLn) * TaxIVA.TxIVA * DocDet.Qtd AS VIva, (DocDet.Valor - DocDet.VlrDescLn) / (1 + TaxIVA.TxIVA) * DocDet.Qtd AS VLiq, DocCab.IdDocCab FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.IdDocCab = '" & dt.Rows(0)("IdDocCab").ToString & "')"
                'frmSubRpt.C1Report1.DataSource.RecordSource = "SELECT DocDet.TxIva, (DocDet.Valor - DocDet.VlrDescLn) * (1 - 1 / (DocDet.TxIva + 1)) * DocDet.Qtd AS VIva, (DocDet.Valor - DocDet.VlrDescLn) / (1 + DocDet.TxIva) * DocDet.Qtd AS VLiq, DocCab.IdDocCab FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr WHERE (DocCab.IdDocCab = '" & dt.Rows(0)("IdDocCab").ToString & "')"
                frmSubRpt.C1Report1.DataSource.RecordSource = "SELECT DocCab.IdDocCab, DocDet.TxIva, SUM((DocDet.Valor - DocDet.VlrDescLn) * (1 - 1 / (DocDet.TxIva + 1)) * DocDet.Qtd) AS VIva, SUM((DocDet.Valor - DocDet.VlrDescLn) / (1 + DocDet.TxIva) * DocDet.Qtd) AS VLiq FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr GROUP BY DocDet.TxIva, DocCab.IdDocCab HAVING (DocCab.IdDocCab = '" & dt.Rows(0)("IdDocCab").ToString & "')"

                '.C1Report1.Fields("imgAnulado").Visible = False
            End If

            If xTipodoc = "GT" Then


                'VERIFICAR SE TEM NUM DE AT
            Else









            End If



            If PrintDirect = True Then
                JustPrint(.C1Report1)
            Else
                .C1PrtPreview.Document = frmRpt.C1Report1.Document
                .Show(frmReport)
            End If




            '*******  OPTAR POR IMPRIMIR DIRECTO PARA A IMPRESSORA   *************
            'If MsgBox("Visualizar o Documento", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '    .C1PrtPreview.Document = frmRpt.C1Report1.Document
            '    xNPag = frmRpt.C1PrtPreview.Pages.Count / 3
            '    'frmReport.C1Report1.MaxPages
            '    .Show(frmReport)
            'Else
            '    JustPrint(.C1Report1)
            '    'AskPrinter(.C1Report1)
            'End If




        End With
    End Sub

    Public Sub ListaDoc(ByVal xNumDoc As String, ByVal xTipodoc As String, Optional ByVal xTipoVia As String = "Original", Optional ByVal PrintDirect As Boolean = False)

        frmRpt = New frmReport
        Dim bdados As New ClsSqlBDados
        Dim xTipoTerc As String = ""


        With frmRpt
            .StartPosition = FormStartPosition.CenterScreen
            .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.PageWidth

            Sql = "SELECT '" & xTipoVia & "' AS Via, DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.ArmazemID AS xSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.TercID AS DestCod, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, SUM(DocDet.Qtd) AS Qtd, DocDet.VlrIVA AS VIva, Terceiros.NomeAbrev AS LNome, Terceiros.Morada AS LMorada, Terceiros.CodPostal AS LCodPostal, Terceiros.Localidade AS LLocalidade, Terceiros.Telefone AS LTelefone, Terceiros.Site AS LSite FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ClientesLoja AS Destino ON DocCab.TercID = Destino.ClienteLojaID INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = N'" & xNumDoc & "') GROUP BY DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocNrOrig, DocCab.ArmazemID, DocCab.TercID, CASE WHEN DocCab.TercID = '1' THEN '' WHEN DocCab.TercID <> '1' THEN Destino.Nome END, Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocDet.VlrIVA, Terceiros.Morada, Terceiros.CodPostal, Terceiros.Localidade, Terceiros.Telefone, Terceiros.Site, Terceiros.NomeAbrev"

            If xTipodoc = "FS" Then
                .C1Report1.Load(xRptPath & "DocVndDinheiro.xml", "DocVndDinheiro")
            ElseIf xTipodoc = "NC" Then
                .C1Report1.Load(xRptPath & "DocNotaCredito.xml", "DocNotaCredito")
            ElseIf xTipodoc = "GA" Then

                .C1Report1.Load(xRptPath & "DocGuiaMovAP.xml", "GuiaMAP")
            End If

            .C1Report1.DataSource.ConnectionString = sConnectionStringReport
            .C1Report1.DataSource.RecordSource = Sql

            If PrintDirect = True Then
                JustPrint(.C1Report1)
            Else
                .C1PrtPreview.Document = frmRpt.C1Report1.Document
                .Show(frmReport)
            End If

        End With

    End Sub

    Public Sub GravarObsRecolhas(ByVal xIdDocCab As String, ByVal xObs As String)
        Dim db As New ClsSqlBDados

        Sql = "UPDATE DocCab SET  Obs1 ='" & xObs & "' WHERE IdDocCab='" & xIdDocCab & "'"
        db.ExecuteData(Sql)

        Sql = "UPDATE DocCab SET  Obs1 ='" & xObs & "' WHERE IdDocCabOrig='" & xIdDocCab & "'"
        db.ExecuteData(Sql)


    End Sub

    Public Sub GravarObsRecolhasBackOffice(ByVal xIdDocCab As String, ByVal xObsLoja As String, ByVal xObs As String)
        Dim db As New ClsSqlBDados

        'recolha
        Sql = "UPDATE DocCab SET  Obs1 ='" & xObsLoja & "', Obs ='" & xObs & "' WHERE IdDocCab='" & xIdDocCab & "'"
        db.ExecuteData(Sql)

        'Fecho - Loja
        Sql = "UPDATE DocCab SET Obs1 = N'" & xObsLoja & "' FROM DocCab INNER JOIN DocCab AS DocCab_1 ON DocCab.IdDocCab = DocCab_1.IdDocCabOrig WHERE (DocCab_1.IdDocCab LIKE '" & xIdDocCab & "')"

        db.ExecuteData(Sql)



    End Sub

    Public Sub ListaSeparacao(ByVal xNumDoc As String, ByVal xArmzOrigem As String)
        Try
            frmRpt = New frmReport
            With frmRpt
                .StartPosition = FormStartPosition.CenterScreen
                .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize

                'Sql = "SELECT 'ORIGINAL' Copia INTO #Copia UNION SELECT 'DUPLICADO'; " & _
                '      "SELECT DocCab.DocNr, DocCab.DataDoc, DocCab.ArmazemID as OrigCod, Origem.ArmAbrev as OrigDescr,  DocCab.TercID DestCod, Destino.ArmAbrev as DestDescr, DocDet.SerieID, #Copia.Copia " & _
                '      "FROM  DocCab, Armazens Origem, Armazens Destino, DocDet, #Copia " & _
                '      "WHERE(DocCab.ArmazemID = Origem.ArmazemID) " & _
                '      "AND DocCab.TercID = Destino.ArmazemID  " & _
                '      "AND DocCab.EmpresaID = DocDet.EmpresaID " & _
                '      "AND DocCab.ArmazemID = DocDet.ArmazemID " & _
                '      "AND DocCab.TipoDocID = DocDet.TipoDocID " & _
                '      "AND DocCab.DocNr = DocDet.DocNr " & _
                '      "AND DocCab.EmpresaID='" & xEmp & "' " & _
                '      "AND DocCab.ArmazemID='" & xArmzOrigem & "' " & _
                '      "AND DocCab.DocNr='" & xNumDoc & "' " & _
                '      "AND DocCab.TipoDocID='SE' ORDER BY #Copia.Copia, DocDet.SerieID "


                Sql = "SELECT 'ORIGINAL' Copia INTO #Copia ; " & _
                      "SELECT DocCab.DocNr, DocCab.DataDoc, DocCab.ArmazemID as OrigCod, Origem.ArmAbrev as OrigDescr,  DocCab.TercID DestCod, Destino.ArmAbrev as DestDescr, DocDet.SerieID, #Copia.Copia " & _
                      "FROM  DocCab, Armazens Origem, Armazens Destino, DocDet, #Copia " & _
                      "WHERE(DocCab.ArmazemID = Origem.ArmazemID) " & _
                      "AND DocCab.TercID = Destino.ArmazemID  " & _
                      "AND DocCab.EmpresaID = DocDet.EmpresaID " & _
                      "AND DocCab.ArmazemID = DocDet.ArmazemID " & _
                      "AND DocCab.TipoDocID = DocDet.TipoDocID " & _
                      "AND DocCab.DocNr = DocDet.DocNr " & _
                      "AND DocCab.EmpresaID='" & xEmp & "' " & _
                      "AND DocCab.ArmazemID='" & xArmzOrigem & "' " & _
                      "AND DocCab.DocNr='" & xNumDoc & "' " & _
                      "AND DocCab.TipoDocID='SE' ORDER BY #Copia.Copia, DocDet.SerieID "




                .C1RptRelTaloes.Load(xRptPath & "rl.xml", "RelaTaloes")
                .C1RptRelTaloes.DataSource.ConnectionString = sConnectionStringReport
                .C1RptRelTaloes.DataSource.RecordSource = Sql
                .C1PrtPreview.Document = frmRpt.C1RptRelTaloes.Document
                .Show(frmReport)

            End With

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListaSeparacao")
        Catch ex As Exception
            ErroVB(ex.Message, "ListaSeparacao")
        End Try

    End Sub

    Public Sub ListaRecolha(ByVal xNumDoc As String, ByVal xArmzAux As String)
        Try
            frmRpt = New frmReport
            With frmRpt
                .StartPosition = FormStartPosition.CenterScreen
                .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize
                'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, Armazens.Armazem, DocCab.DocNr, DocCab.DataDoc, " & _
                '          "DocDet.SerieID AS Tal�o, DocDet.ModeloID AS Modelo, DocDet.CorID AS Cor, DocDet.TamID AS Tam,  " & _
                '          "Modelos.LinhaID, Linhas.DescrLinha AS Linha, DocDet.PercDescLn AS PerComisao, DocDet.Qtd AS Qtd,  " & _
                '          "DocDet.Valor * DocDet.Qtd AS ValorVnd, Serie.DtSaida AS DtVenda, " & _
                '          "(DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd) AS ValComissao,  " & _
                '          "(DocDet.Valor-DocDet.PercDescLn * DocDet.Valor)*DocDet.Qtd AS Deposito " & _
                '          "FROM DocDet INNER JOIN " & _
                '          "Serie ON DocDet.SerieID = Serie.SerieID INNER JOIN " & _
                '          "Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN " & _
                '          "Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN " & _
                '          "DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID  " & _
                '          "AND DocDet.TipoDocID = DocCab.TipoDocID  " & _
                '          "AND DocDet.DocNr = DocCab.DocNr INNER JOIN " & _
                '          "Armazens ON DocCab.ArmazemID = Armazens.ArmazemID " & _
                '          "WHERE DocDet.EmpresaID = '" & xEmp & "' AND DocDet.ArmazemID = '" & xArmzAux & "' AND DocDet.TipoDocID = 'RE' " & _
                '          "AND DocDet.DocNr = '" & xNumDoc & "' ORDER BY DocDet.SerieID"


                'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, Armazens.ArmAbrev Armazem, DocCab.DocNr, DocCab.DataDoc, DocDet.SerieID AS Tal�o, " & _
                '    "DocDet.ModeloID AS Modelo, DocDet.CorID AS Cor, DocDet.TamID AS Tam, Modelos.LinhaID, Linhas.DescrLinha AS Linha,  " & _
                '    "DocDet.PercDescLn AS PerComisao, DocDet.Qtd, DocDet.Valor * DocDet.Qtd AS Valor, ISNULL(VENDAS.QtdVnd, 0) AS QtdVnd,  " & _
                '    "ISNULL(VENDAS.ValorVnd, 0) AS ValorVnd, ISNULL(Devolucoes.QtdDev, 0) AS QtdDev, ISNULL(Devolucoes.ValorDev, 0) AS ValorDev, " & _
                '    "DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd AS ValComissao, (DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd AS Deposito " & _
                '    "FROM DocDet INNER JOIN " & _
                '    "Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN " & _
                '    "Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN " & _
                '    "DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND  " & _
                '    "DocDet.DocNr = DocCab.DocNr INNER JOIN " & _
                '    "Armazens ON DocCab.ArmazemID = Armazens.ArmazemID LEFT OUTER JOIN " & _
                '    "(SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd*-1 AS QtdDev, Valor AS ValorDev " & _
                '    "FROM DocDet AS DocDet_2 " & _
                '    "WHERE (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND  " & _
                '    "DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN " & _
                '    "(SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd " & _
                '    "FROM DocDet AS DocDet_1 " & _
                '    "WHERE (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND  " & _
                '    "DocDet.TipoDocID = VENDAS.TipoDocID And DocDet.DocNr = VENDAS.DocNr And DocDet.DocLnNr = VENDAS.DocLnNr " & _
                '    "WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmzAux & "') AND (DocDet.TipoDocID = 'RE') AND (DocDet.DocNr = '" & xNumDoc & "') " & _
                '    "ORDER BY Tal�o"



                'Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, Armazens.ArmAbrev AS Armazem, DocCab.DocNr, DocCab.DataDoc, DocDet.SerieID AS Tal�o, DocDet.ModeloID AS Modelo, DocDet.CorID AS Cor, DocDet.TamID AS Tam, Modelos.LinhaID, Linhas.DescrLinha AS Linha, DocDet.PercDescLn AS PerComisao, DocDet.Qtd, DocDet.Valor * DocDet.Qtd AS Valor, ISNULL(VENDAS.QtdVnd, 0) AS QtdVnd, ISNULL(VENDAS.ValorVnd, 0) AS ValorVnd, ISNULL(Devolucoes.QtdDev, 0) AS QtdDev, ISNULL(Devolucoes.ValorDev, 0) AS ValorDev, DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd AS ValComissao, (DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd AS Deposito, ISNULL(TABDESPESAS.Despesas, 0) AS Despesa, TABDESPESAS.Despesas FROM DocDet INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID LEFT OUTER JOIN (SELECT ReservaSerieID, Despesas FROM Reservas WHERE (ReservaID IN (SELECT DISTINCT MAX(ReservaID) AS Expr1 FROM Reservas AS Reservas_1 GROUP BY ReservaSerieID)) AND (Despesas <> 0) GROUP BY ReservaSerieID, Despesas) AS TABDESPESAS ON DocDet.SerieID = TABDESPESAS.ReservaSerieID LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd * - 1 AS QtdDev, Valor AS ValorDev FROM DocDet AS DocDet_2 WHERE (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd FROM DocDet AS DocDet_1 WHERE (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND DocDet.TipoDocID = VENDAS.TipoDocID AND DocDet.DocNr = VENDAS.DocNr AND DocDet.DocLnNr = VENDAS.DocLnNr WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmzAux & "') AND (DocDet.TipoDocID = 'RE') AND (DocDet.DocNr = '" & xNumDoc & "') ORDER BY Tal�o"
                Sql = "SELECT DocCab.EmpresaID, DocCab.ArmazemID, Armazens.ArmAbrev AS Armazem, DocCab.DocNr, DocCab.DataDoc, DocDet.SerieID AS Tal�o, DocDet.ModeloID AS Modelo, DocDet.CorID AS Cor, DocDet.TamID AS Tam, Modelos.LinhaID, Linhas.DescrLinha AS Linha, DocDet.PercDescLn AS PerComisao, DocDet.Qtd, DocDet.Valor * DocDet.Qtd AS Valor, ISNULL(VENDAS.QtdVnd, 0) AS QtdVnd, ISNULL(VENDAS.ValorVnd, 0) AS ValorVnd, ISNULL(Devolucoes.QtdDev, 0) AS QtdDev, ISNULL(Devolucoes.ValorDev, 0) AS ValorDev, DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd AS ValComissao, (DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd AS Deposito, ISNULL(TABDESPESAS.Despesas, 0) * ISNULL(VENDAS.QtdVnd, 0) AS Despesa FROM DocDet INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID LEFT OUTER JOIN (SELECT ReservaSerieID, Despesas FROM Reservas WHERE (ReservaID IN (SELECT DISTINCT MAX(ReservaID) AS Expr1 FROM Reservas AS Reservas_1 GROUP BY ReservaSerieID)) AND (Despesas <> 0) GROUP BY ReservaSerieID, Despesas) AS TABDESPESAS ON DocDet.SerieID = TABDESPESAS.ReservaSerieID LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd * - 1 AS QtdDev, Valor AS ValorDev FROM DocDet AS DocDet_2 WHERE (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd FROM DocDet AS DocDet_1 WHERE (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND DocDet.TipoDocID = VENDAS.TipoDocID AND DocDet.DocNr = VENDAS.DocNr AND DocDet.DocLnNr = VENDAS.DocLnNr WHERE (DocDet.EmpresaID = '" & xEmp & "') AND (DocDet.ArmazemID = '" & xArmzAux & "') AND (DocDet.TipoDocID = 'RE') AND (DocDet.DocNr = '" & xNumDoc & "') ORDER BY Tal�o"

                .C1Report1.Load(xRptPath & "RptRecolha.xml", "Recolha")
                .C1Report1.DataSource.ConnectionString = sConnectionStringReport
                .C1Report1.DataSource.RecordSource = Sql
                .C1PrtPreview.Document = frmRpt.C1Report1.Document
                .Show(frmReport)
            End With

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListaRecolha")
        Catch ex As Exception
            ErroVB(ex.Message, "ListaRecolha")
        End Try

    End Sub

    Public Sub ListaRecolhaMalas(ByVal xNumDoc As String, ByVal xArmzAux As String, ByVal xDeData As String, ByVal xAteData As String)
        Try
            frmRpt = New frmReport

            xDeDataRecolha = xDeData
            xAteDataRecolha = xAteData
            Dim xAteDataAux As Date = xAteData
            xAteData = Format(xAteDataAux.AddDays(1), "yyyy-MM-dd")



            With frmRpt
                .StartPosition = FormStartPosition.CenterScreen
                .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize

                'Sql = "SELECT DocDet.SerieID AS Tal�o, Linhas.DescrLinha AS Linha, DocDet.PercDescLn AS PerComisao, DocCab.ArmazemID, 1 AS Qtd, " & _
                '      "CASE WHEN DocCab.ArmazemID = '0099' THEN 0 ELSE DocDet.Valor * DocDet.Qtd END AS ValorVnd, DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd AS ValComissao,(DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd AS Deposito " & _
                '      "FROM DocDet INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN " & _
                '      "DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND  " & _
                '      "DocDet.DocNr = DocCab.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID " & _
                '      "WHERE (DocDet.TipoDocID = 'RE') AND (Modelos.GrupoID = '6') " & _
                '      "AND DocCab.DataDoc BETWEEN '" & xDeData & "' AND '" & xAteData & "' " & _
                '      "ORDER BY Tal�o"

                'ERRO NA ATEDATA
                'Sql = "SELECT     DocDet.SerieID AS Tal�o, DocCab.ArmazemID, DocDet.ModeloID AS Modelo, DocDet.CorID AS Cor, DocDet.TamID AS Tam, Modelos.LinhaID,  " & _
                '        "Linhas.DescrLinha AS Linha, DocDet.PercDescLn AS PerComisao, DocDet.Qtd, DocDet.Valor * DocDet.Qtd AS Valor, ISNULL(VENDAS.QtdVnd, 0)  " & _
                '      "AS QtdVnd, CASE WHEN DocCab.ArmazemID = '0099' THEN 0 ELSE DocDet.Valor * DocDet.Qtd END AS ValorVnd, ISNULL(Devolucoes.QtdDev, 0)   " & _
                '      "AS QtdDev, ISNULL(Devolucoes.ValorDev, 0) AS ValorDev, DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd AS ValComissao,   " & _
                '      "(DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd AS Deposito  " & _
                '        "FROM         DocDet INNER JOIN  " & _
                '      "Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN  " & _
                '      "Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN  " & _
                '      "DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND   " & _
                '      "DocDet.DocNr = DocCab.DocNr INNER JOIN  " & _
                '      "Armazens ON DocCab.ArmazemID = Armazens.ArmazemID LEFT OUTER JOIN  " & _
                '          "(SELECT     EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd * - 1 AS QtdDev, Valor AS ValorDev  " & _
                '            "FROM          DocDet AS DocDet_2  " & _
                '            "WHERE      (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND   " & _
                '      "DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN  " & _
                '          "(SELECT     EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd  " & _
                '            "FROM          DocDet AS DocDet_1  " & _
                '        "WHERE      (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND   " & _
                '"DocDet.TipoDocID = VENDAS.TipoDocID And DocDet.DocNr = VENDAS.DocNr And DocDet.DocLnNr = VENDAS.DocLnNr  " & _
                '"WHERE     (DocDet.TipoDocID = 'RE') AND (DocCab.DataDoc BETWEEN '" & xDeData & "' AND '" & xAteData & "') " & _
                '"AND (Modelos.GrupoID = '6')  " & _
                '"ORDER BY Tal�o"




                'Sql = "SELECT DocDet.SerieID AS Tal�o, DocCab.ArmazemID, DocDet.ModeloID AS Modelo, DocDet.CorID AS Cor, DocDet.TamID AS Tam, Modelos.LinhaID,  " & _
                '      "Linhas.DescrLinha AS Linha, DocDet.PercDescLn AS PerComisao, DocDet.Qtd, DocDet.Valor * DocDet.Qtd AS Valor, ISNULL(VENDAS.QtdVnd, 0)  " & _
                '    "AS QtdVnd, CASE WHEN DocCab.ArmazemID = '0099' THEN 0 ELSE DocDet.Valor * DocDet.Qtd END AS ValorVnd, ISNULL(Devolucoes.QtdDev, 0)   " & _
                '    "AS QtdDev, ISNULL(Devolucoes.ValorDev, 0) AS ValorDev, DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd AS ValComissao,   " & _
                '    "(DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd AS Deposito  " & _
                '    "FROM DocDet INNER JOIN  " & _
                '    "Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN  " & _
                '    "Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN  " & _
                '    "DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND   " & _
                '    "DocDet.DocNr = DocCab.DocNr INNER JOIN  " & _
                '    "Armazens ON DocCab.ArmazemID = Armazens.ArmazemID LEFT OUTER JOIN  " & _
                '    "(SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd * - 1 AS QtdDev, Valor AS ValorDev  " & _
                '    "FROM DocDet AS DocDet_2  " & _
                '    "WHERE (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND   " & _
                '    "DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN  " & _
                '    "(SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd  " & _
                '    "FROM DocDet AS DocDet_1  " & _
                '    "WHERE (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND   " & _
                '    "DocDet.TipoDocID = VENDAS.TipoDocID And DocDet.DocNr = VENDAS.DocNr And DocDet.DocLnNr = VENDAS.DocLnNr  " & _
                '    "WHERE (DocDet.TipoDocID = 'RE') AND DocCab.DataDoc>='" & xDeData & "' AND DocCab.DataDoc<='" & xAteData & "' " & _
                '    "AND Modelos.GrupoID IN ('6','4') ORDER BY Tal�o"


                'Sql = "Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd * - 1 AS QtdDev, Valor AS ValorDev FROM DocDet AS DocDet_2 WHERE (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd FROM DocDet AS DocDet_1 WHERE (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND DocDet.TipoDocID = VENDAS.TipoDocID AND DocDet.DocNr = VENDAS.DocNr AND DocDet.DocLnNr = VENDAS.DocLnNr WHERE (DocDet.TipoDocID = 'RE') AND (DocCab.DataDoc >= '" & xDeData & "') AND (DocCab.DataDoc <= '" & xAteData & "') AND (Modelos.GrupoID IN ('6', '4')) GROUP BY DocCab.ArmazemID HAVING (DocCab.ArmazemID <> '0099') ORDER BY DocCab.ArmazemID"
                Sql = "SELECT DocDet.SerieID AS Tal�o, DocCab.ArmazemID, DocDet.ModeloID AS Modelo, DocDet.CorID AS Cor, DocDet.TamID AS Tam, Modelos.LinhaID, Linhas.DescrLinha AS Linha, DocDet.PercDescLn AS PerComisao, DocDet.Qtd, DocDet.Valor * DocDet.Qtd AS Valor, ISNULL(VENDAS.QtdVnd, 0) AS QtdVnd, CASE WHEN DocCab.ArmazemID = '0099' THEN 0 ELSE DocDet.Valor * DocDet.Qtd END AS ValorVnd, ISNULL(Devolucoes.QtdDev, 0) AS QtdDev, ISNULL(Devolucoes.ValorDev, 0) AS ValorDev, DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd AS ValComissao, (DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd AS Deposito, Serie.PrecoEtiqueta, CASE WHEN DocDet.Valor >= PrecoEtiqueta THEN '0.3' ELSE '0.2' END AS CCelferi FROM DocDet INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd * - 1 AS QtdDev, Valor AS ValorDev FROM DocDet AS DocDet_2 WHERE (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd FROM DocDet AS DocDet_1 WHERE (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND DocDet.TipoDocID = VENDAS.TipoDocID AND DocDet.DocNr = VENDAS.DocNr AND DocDet.DocLnNr = VENDAS.DocLnNr WHERE (DocDet.TipoDocID = 'RE') AND (DocCab.DataDoc >= '" & xDeData & "') AND (DocCab.DataDoc <= '" & xAteData & "') AND (Modelos.GrupoID IN ('6', '4')) ORDER BY Tal�o"


                'Sql = "SELECT DocDet.SerieID AS Tal�o, DocCab.ArmazemID, DocDet.ModeloID AS Modelo, DocDet.CorID AS Cor, DocDet.TamID AS Tam, Modelos.LinhaID,  " & _
                '    "Linhas.DescrLinha AS Linha, DocDet.PercDescLn AS PerComisao, DocDet.Qtd, DocDet.Valor * DocDet.Qtd AS Valor, ISNULL(VENDAS.QtdVnd, 0)  " & _
                '  "AS QtdVnd, CASE WHEN DocCab.ArmazemID = '0099' THEN 0 ELSE DocDet.Valor * DocDet.Qtd END AS ValorVnd, ISNULL(Devolucoes.QtdDev, 0)   " & _
                '  "AS QtdDev, ISNULL(Devolucoes.ValorDev, 0) AS ValorDev, DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd AS ValComissao,   " & _
                '  "(DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd AS Deposito  " & _
                '  "FROM DocDet INNER JOIN  " & _
                '  "Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN  " & _
                '  "Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN  " & _
                '  "DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND   " & _
                '  "DocDet.DocNr = DocCab.DocNr INNER JOIN  " & _
                '  "Armazens ON DocCab.ArmazemID = Armazens.ArmazemID LEFT OUTER JOIN  " & _
                '  "(SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd * - 1 AS QtdDev, Valor AS ValorDev  " & _
                '  "FROM DocDet AS DocDet_2  " & _
                '  "WHERE (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND   " & _
                '  "DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN  " & _
                '  "(SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd  " & _
                '  "FROM DocDet AS DocDet_1  " & _
                '  "WHERE (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND   " & _
                '  "DocDet.TipoDocID = VENDAS.TipoDocID And DocDet.DocNr = VENDAS.DocNr And DocDet.DocLnNr = VENDAS.DocLnNr  " & _
                '  "WHERE (DocDet.TipoDocID = 'RE') AND DocCab.DataDoc>='" & xDeData & "' AND DocCab.DataDoc<='" & xAteData & "' " & _
                '  "AND Modelos.GrupoID IN ('6','4') ORDER BY Tal�o"



                .C1RptRecolhaMalas.Load(xRptPath & "RptRecolhaMalas.xml", "RecolhaMalas")
                .C1RptRecolhaMalas.DataSource.ConnectionString = sConnectionStringReport
                .C1RptRecolhaMalas.DataSource.RecordSource = Sql



                'Sql = "SELECT DocDet.SerieID AS Tal�o, DocCab.ArmazemID, DocDet.ModeloID AS Modelo, DocDet.CorID AS Cor, DocDet.TamID AS Tam, Modelos.LinhaID, DocDet.PercDescLn AS PerComisao, DocDet.Qtd, DocDet.Valor * DocDet.Qtd AS Valor, ISNULL(VENDAS.QtdVnd, 0) AS QtdVnd, CASE WHEN DocCab.ArmazemID = '0099' THEN 0 ELSE DocDet.Valor * DocDet.Qtd END AS ValorVnd, ISNULL(Devolucoes.QtdDev, 0) AS QtdDev, ISNULL(Devolucoes.ValorDev, 0) AS ValorDev, DocDet.PercDescLn * DocDet.Valor * DocDet.Qtd AS ValComissao, (DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd AS Deposito, Serie.PrecoEtiqueta, Serie.PVndReal, CASE WHEN Serie.PVndReal>=PrecoEtiqueta THEN '0.3' ELSE '0.2' END AS CCelferi FROM DocDet INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd * - 1 AS QtdDev, Valor AS ValorDev FROM DocDet AS DocDet_2 WHERE (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd FROM DocDet AS DocDet_1 WHERE (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND DocDet.TipoDocID = VENDAS.TipoDocID AND DocDet.DocNr = VENDAS.DocNr AND DocDet.DocLnNr = VENDAS.DocLnNr WHERE (DocDet.TipoDocID = 'RE') AND (DocCab.DataDoc >= '" & xDeData & "') AND (DocCab.DataDoc <= '" & xAteData & "') AND (Modelos.GrupoID IN ('6', '4')) ORDER BY Tal�o"
                '.C1RptRecolhaMalas.Load(xRptPath & "RptRecolhaMalas.xml", "RecolhaMalas")
                '.C1RptRecolhaMalas.DataSource.ConnectionString = sConnectionStringReport
                '.C1RptRecolhaMalas.DataSource.RecordSource = Sql


                'c1Report.Fields["ShippingDetailReport"].Subreport.DataSource.ConnectionString =
                'frmMain.FDBConnection.ConnectionString;

                .C1PrtPreview.Document = frmRpt.C1RptRecolhaMalas.Document

                .Show(frmReport)

            End With



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListaRecolhaMalas")
        Catch ex As Exception
            ErroVB(ex.Message, "ListaRecolhaMalas")
        End Try

    End Sub

    Public Sub ListaDocPOS(ByVal xNumDoc As String, ByVal xTipodoc As String, ByVal xTipoVia As String, Optional ByVal PrintDirect As Boolean = False)

        frmRpt = New frmReport
        Dim xTipoTerc As String = ""
        Dim db As New ClsSqlBDados

        Sql = "SELECT ISNULL(Hash4d,'') FROM DocCab WHERE (EmpresaID = '" & xEmp & "') AND (ArmazemID = '" & xArmz & "') AND (TipoDocID = '" & xTipodoc & "') AND (DocNr = N'" & xNumDoc & "')"
        Dim HashExist As String = db.GetDataValue(Sql)
        If Len(HashExist) <> 4 Then
            MsgBox("Erro na Cria��o do Documento!")
            EnviarEmail("Erro", "Erro 56849 na cria��o do documento! n�o gerou a Hash : " & xArmz + xTipodoc + xNumDoc)
            'APAGAR DOCUMENTO!!
            Exit Sub
        End If
        With frmRpt
            .StartPosition = FormStartPosition.CenterScreen
            .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize
            .WindowState = FormWindowState.Maximized
            .ShowInTaskbar = False
            .MaximizeBox = False
            .MinimizeBox = False


            Sql = "SELECT '" & xTipoVia & "' AS Via, DocCab.EmpresaID AS CodEmp, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.TipoDocID + ' ' + LEFT(DocCab.DocNr, 2) + RIGHT(DocCab.ArmazemID, 2) + '/' + RIGHT(DocCab.DocNr, 5) AS DocNrSerie, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocOrig, DocCab.Hash4d, DocCab.TercID AS DestCod, Destino.Nome AS DestDescr, Destino.Morada AS DestEndereco, Destino.CodPostal AS DestCodPostal, Destino.Localidade AS DestLocal, Destino.NIF AS DestNIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, CAST(ROUND(SUM(DocDet.Qtd), 2) AS NUMERIC(36, 0)) AS Qtd, DocDet.VlrIVA AS VIva, Terceiros.NomeAbrev AS LNome, Terceiros.Morada AS LMorada, Terceiros.CodPostal AS LCodPostal, Terceiros.Localidade AS LLocalidade, Terceiros.Telefone AS LTelefone, Terceiros.Site AS LSite, TaxIVA.TxIVA, DocDet.ProductCode FROM Empresas INNER JOIN DocCab ON Empresas.EmpresaID = DocCab.EmpresaID INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ClientesLoja AS Destino ON DocCab.TercID = Destino.ClienteLojaID INNER JOIN Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID WHERE (DocCab.EmpresaID = '" & xEmp & "') AND (DocCab.ArmazemID = '" & xArmz & "') AND (DocCab.TipoDocID = '" & xTipodoc & "') AND (DocCab.DocNr = N'" & xNumDoc & "') GROUP BY DocCab.EmpresaID, Empresas.EmpNome, Empresas.EmpDesigna, Empresas.EmpMorada, Empresas.EmpCodPostal, Empresas.EmpLocalidade, Empresas.EmpTelefone, Empresas.EmpFax, Empresas.EmpContrib, Empresas.EmpCapSocial, Empresas.EmpNrRegisto, Empresas.EmpLogo, Empresas.EmpMarca, DocCab.TipoDocID, DocCab.DocNr, DocCab.DataDoc, DocCab.Obs, DocCab.DescontoDoc, DocCab.DocOrig, DocCab.Hash4d, DocCab.ArmazemID, DocCab.TercID, Destino.Nome, Destino.Morada, Destino.CodPostal, Destino.Localidade, Destino.NIF, DocDet.ModeloID, DocDet.CorID, DocDet.Unidade, DocDet.Descricao, DocDet.Valor, DocDet.VlrDescLn, DocCab.LocalCarga, DocCab.HoraCarga, DocCab.LocDesc, DocDet.VlrIVA, Terceiros.Morada, Terceiros.CodPostal, Terceiros.Localidade, Terceiros.Telefone, Terceiros.Site, Terceiros.NomeAbrev, TaxIVA.TxIVA, DocDet.ProductCode "

            If xTipodoc = "FS" Then
                .C1Report1.Load(xRptPath & "DocFaturaSimplificada.xml", "DocFaturaSimplificada")
            ElseIf xTipodoc = "NC" Then
                .C1Report1.Load(xRptPath & "DocNotaCredito.xml", "DocNotaCredito")
            ElseIf xTipodoc = "FT" Then
                .C1Report1.Load(xRptPath & "DocFaturaReduzida.xml", "DocFaturaReduzida")
            End If

            .C1Report1.DataSource.ConnectionString = sConnectionStringReport
            .C1Report1.DataSource.RecordSource = Sql

            If PrintDirect = True Then
                JustPrint(.C1Report1)
            Else
                .C1PrtPreview.Document = frmRpt.C1Report1.Document
                .Show(frmReport)
            End If

        End With

    End Sub

    Public Sub ListaTaloes(ByVal xFiltro As String, ByVal xReport As String, Optional ByVal PrintDirect As Boolean = False)

        Dim sPath As String = xRptPath & xReport & ".xml"
        Dim db As New ClsSqlBDados

        xFotoReport = False
        If xReport = "RptTaloes_3x2" Then xFotoReport = True
        If xReport = "RptTaloes_8x2" Then xFotoReport = True
        If xReport = "RptTaloes_10x4SemTam" Then xFotoReport = False
        If xReport = "RptRelTaloes" Then xFotoReport = False
        If xReport = "RptRelaTaloesCB" Then xFotoReport = False
        If xReport = "RptTaloesReimpressao" Then xFotoReport = True
        If xReport = "EtiquetasPreco_13x5" Then xFotoReport = False
        If xReport = "RptEtiqAuto_100x38" Then xFotoReport = True


        If Not IO.File.Exists(sPath) Then
            MsgBox("Report n�o seleccionado")
            Exit Sub
        End If
        frmRpt = New frmReport
        With frmRpt
            '.MdiParent = frmMenuBackOffice
            .StartPosition = FormStartPosition.CenterParent
            .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize
            .WindowState = FormWindowState.Maximized
            .ShowInTaskbar = False
            .MaximizeBox = False
            .MinimizeBox = False


            If xReport = "EtiquetasPreco_13x5" Then
                Dim dtAux As New DataTable
                Dim strData As New StringBuilder
                Dim I As New Int16


                For I = 0 To iPosicionamentoAux - 2
                    Sql = "SELECT " & I & " Ordem, '' ModeloID, '' CorID, NULL PrecoEtiqueta ,NULL PrecoVenda FROM Serie UNION "
                    strData.AppendLine(Sql)
                Next
                Sql = "SELECT 9999999999 Ordem, ModeloID, CorID, PrecoEtiqueta, CASE PrecoEtiqueta WHEN PrecoVenda THEN NULL ELSE PrecoVenda END AS PrecoVenda FROM Serie WHERE (SerieID IN (" & xFiltro & ")) GROUP BY ModeloID, CorID, PrecoEtiqueta, PrecoVenda"
                db.GetData(Sql, dtAux)
                iPosicionamentoAux = iPosicionamentoAux + dtAux.Rows.Count()
                strData.AppendLine(Sql)
                Sql = strData.ToString
            Else
                'Sql = "SELECT S.SerieID, S.ModeloID, S.CorID, S.TamID, C.ModCorDescr, S.PrecoEtiqueta, S.PrecoVenda, S.ModeloID + S.CorID Foto, S.Obs, L.DescrLinha " & _
                '"FROM Serie S, Modelos M, ModeloCor C, Linhas L WHERE(S.ModeloID = C.ModeloID) " & _
                '"AND S.ModeloID = M.ModeloID AND S.CorID = C.CorID AND M.LinhaID = L.LinhaID AND S.SerieID in (" & xFiltro & ") " & _
                '"ORDER BY S.SerieID"
                Sql = "SELECT Serie.SerieID, Serie.ModeloID, Serie.CorID, Serie.TamID, Serie.PrecoEtiqueta, Serie.ModeloID + Serie.CorID AS Foto, Serie.Obs, Serie.ProductCode, Product.ProductDescription, Cores.DescrCor FROM Serie AS Serie INNER JOIN Product ON Serie.ProductCode = Product.ProductCode INNER JOIN Cores ON Serie.CorID = Cores.CorID WHERE Serie.SerieID IN (" & xFiltro & ") ORDER BY Serie.SerieID"

            End If

            .C1RptTaloes.Load(xRptPath & xReport & ".xml", "Tal�es")
            .C1RptTaloes.DataSource.ConnectionString = sConnectionStringReport
            .C1RptTaloes.DataSource.RecordSource = Sql


            '.C1PrtPreview.Document = .C1RptTaloes.Document
            '.Show()


            If PrintDirect = True Then
                JustPrint(.C1RptTaloes)
            Else
                .C1PrtPreview.Document = .C1RptTaloes.Document
                .Show(frmReport)
            End If

        End With
    End Sub

    Public Sub ListaRecolhaMalasResumo(ByVal xNumDoc As String, ByVal xArmzAux As String, ByVal xDeData As String, ByVal xAteData As String)
        Try
            frmRpt = New frmReport

            xDeDataRecolha = xDeData
            xAteDataRecolha = xAteData
            Dim xAteDataAux As Date = xAteData
            xAteData = Format(xAteDataAux.AddDays(1), "yyyy-MM-dd")



            With frmRpt
                .StartPosition = FormStartPosition.CenterScreen
                .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize

                Sql = "SELECT ARMAZENSMOV.ArmazemID, ARMAZENSMOV.ArmAbrev, ARMAZENSMOV.Vnd, SAPATOS.VndSapatos, SAPATOS.QtdSapatos, MALAS.VndMalas, MALAS.QtdMalas, MALAS.DepLojasMalas, MALAS.ReceberMalas FROM (SELECT TOP (100) PERCENT DocCab_1.ArmazemID, SUM(DocDet_1.Qtd) AS QtdSapatos, SUM(DocDet_1.Valor * DocDet_1.Qtd) AS VndSapatos FROM DocDet AS DocDet_1 INNER JOIN Modelos AS Modelos_1 ON DocDet_1.ModeloID = Modelos_1.ModeloID INNER JOIN DocCab AS DocCab_1 ON DocDet_1.EmpresaID = DocCab_1.EmpresaID AND DocDet_1.ArmazemID = DocCab_1.ArmazemID AND DocDet_1.TipoDocID = DocCab_1.TipoDocID AND DocDet_1.DocNr = DocCab_1.DocNr WHERE (DocDet_1.TipoDocID = 'RE') AND (DocCab_1.DataDoc >= '2010-10-01') AND (DocCab_1.DataDoc <= '2010-11-01') AND (NOT (Modelos_1.GrupoID IN ('6', '4'))) GROUP BY DocCab_1.ArmazemID ORDER BY DocCab_1.ArmazemID) AS SAPATOS RIGHT OUTER JOIN (SELECT TOP (100) PERCENT DocCab_2.ArmazemID, Armazens_1.ArmAbrev, SUM(DocDet_2.Valor * DocDet_2.Qtd) AS Vnd FROM DocDet AS DocDet_2 INNER JOIN DocCab AS DocCab_2 ON DocDet_2.EmpresaID = DocCab_2.EmpresaID AND DocDet_2.ArmazemID = DocCab_2.ArmazemID AND DocDet_2.TipoDocID = DocCab_2.TipoDocID AND DocDet_2.DocNr = DocCab_2.DocNr INNER JOIN Armazens AS Armazens_1 ON DocCab_2.ArmazemID = Armazens_1.ArmazemID WHERE (DocDet_2.TipoDocID = 'RE') AND (DocCab_2.DataDoc >= '2010-10-01') AND (DocCab_2.DataDoc <= '2010-11-01') GROUP BY DocCab_2.ArmazemID, Armazens_1.ArmAbrev HAVING (DocCab_2.ArmazemID <> '0099') AND (SUM(DocDet_2.Valor * DocDet_2.Qtd) > 0) ORDER BY DocCab_2.ArmazemID) AS ARMAZENSMOV ON SAPATOS.ArmazemID = ARMAZENSMOV.ArmazemID LEFT OUTER JOIN (SELECT TOP (100) PERCENT DocCab.ArmazemID, SUM(DocDet.Qtd) AS QtdMalas, SUM(DocDet.Valor * DocDet.Qtd) AS VndMalas, SUM((DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd) AS DepLojasMalas, SUM((DocDet.Valor - (CASE WHEN DocDet.Valor >= PrecoEtiqueta THEN '0.3' ELSE '0.2' END) * DocDet.Valor) * DocDet.Qtd) AS ReceberMalas FROM DocDet INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID WHERE (DocDet.TipoDocID = 'RE') AND (DocCab.DataDoc >= '2010-10-01') AND (DocCab.DataDoc <= '2010-11-01') AND (Modelos.GrupoID IN ('6', '4')) GROUP BY DocCab.ArmazemID ORDER BY DocCab.ArmazemID) AS MALAS ON ARMAZENSMOV.ArmazemID = MALAS.ArmazemID"

                'Sql = "SELECT DocCab.ArmazemID, SUM(DocDet.Valor * DocDet.Qtd) AS Valor, SUM((DocDet.Valor - DocDet.PercDescLn * DocDet.Valor) * DocDet.Qtd) AS Deposito, SUM((DocDet.Valor - (CASE WHEN Serie.PVndReal >= PrecoEtiqueta THEN '0.3' ELSE '0.2' END) * DocDet.Valor) * DocDet.Qtd) AS DepositoG FROM DocDet INNER JOIN Modelos ON DocDet.ModeloID = Modelos.ModeloID INNER JOIN Linhas ON Modelos.LinhaID = Linhas.LinhaID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr INNER JOIN  Armazens ON DocCab.ArmazemID = Armazens.ArmazemID INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd * - 1 AS QtdDev, Valor AS ValorDev FROM DocDet AS DocDet_2 WHERE (Qtd < 0)) AS Devolucoes ON DocDet.EmpresaID = Devolucoes.EmpresaID AND DocDet.ArmazemID = Devolucoes.ArmazemID AND DocDet.TipoDocID = Devolucoes.TipoDocID AND DocDet.DocNr = Devolucoes.DocNr AND DocDet.DocLnNr = Devolucoes.DocLnNr LEFT OUTER JOIN (SELECT EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, Qtd AS QtdVnd, Valor AS ValorVnd FROM DocDet AS DocDet_1 WHERE (Qtd > 0)) AS VENDAS ON DocDet.EmpresaID = VENDAS.EmpresaID AND DocDet.ArmazemID = VENDAS.ArmazemID AND DocDet.TipoDocID = VENDAS.TipoDocID AND DocDet.DocNr = VENDAS.DocNr AND DocDet.DocLnNr = VENDAS.DocLnNr WHERE (DocDet.TipoDocID = 'RE') AND (DocCab.DataDoc >= '" & xDeData & "') AND (DocCab.DataDoc <= '" & xAteData & "') AND (Modelos.GrupoID IN ('6', '4')) GROUP BY DocCab.ArmazemID HAVING (DocCab.ArmazemID <> '0099') ORDER BY DocCab.ArmazemID"
                .C1RptRecolhaMalasResumo.Load(xRptPath & "RptMalasResumo.xml", "ResumoMalas")
                .C1RptRecolhaMalasResumo.DataSource.ConnectionString = sConnectionStringReport
                .C1RptRecolhaMalasResumo.DataSource.RecordSource = Sql

                .C1PrtPreview.Document = frmRpt.C1RptRecolhaMalasResumo.Document

                .Show(frmReport)

            End With



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListaRecolhaMalas")
        Catch ex As Exception
            ErroVB(ex.Message, "ListaRecolhaMalas")
        End Try

    End Sub

    Public Sub ListaTalaoTroca(ByVal xFiltro As String, ByVal xReport As String)
        Try
            Dim sPath As String = xRptPath & xReport & ".xml"
            If Not IO.File.Exists(sPath) Then
                MsgBox("Report n�o seleccionado")
                Exit Sub
            End If
            frmRpt = New frmReport
            With frmRpt
                '.MdiParent = frmMenuPos
                .StartPosition = FormStartPosition.CenterScreen
                .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize
                Sql = "SELECT E.EmpNome, E.EmpDesigna, E.EmpMorada, E.EmpCodPostal, E.EmpLocalidade, E.EmpTelefone, E.EmpFax, E.EmpContrib, E.EmpCapSocial, E.EmpLogo, E.EmpMarca, S.SerieID, S.ModeloID, S.CorID, S.TamID, C.ModCorDescr, S.PvndReal " & _
                      "FROM Empresas E, Serie S, ModeloCor as C " & _
                      "WHERE EmpresaID = '" & xEmp & "' " & _
                      "AND S.ModeloID = C.ModeloID " & _
                      "AND S.CorID = C.CorID " & _
                      "AND S.SerieID in (" + xFiltro + ") ORDER BY S.SerieID "
                .C1RptTaloes.Load(sPath, "TalaoTroca")
                .C1RptTaloes.DataSource.ConnectionString = sConnectionStringReport
                .C1RptTaloes.DataSource.RecordSource = Sql
                .C1PrtPreview.Document = .C1RptTaloes.Document
                .Show()
            End With
        Catch ex As Exception
            ErroVB(ex.Message, " ListaTalaoTroca ")
        End Try
    End Sub

    Public Sub ListaConferencia(ByVal xNumDoc As String)

        Try
            frmRpt = New frmReport


            With frmRpt
                .StartPosition = FormStartPosition.CenterScreen
                .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize

                Sql = "SELECT 'ORIGINAL' Copia INTO #Copia UNION SELECT 'DUPLICADO'; " & _
                      "SELECT DocCab.DocNr, DocCab.DataDoc, DocCab.TercID DestCod, Destino.ArmAbrev as DestDescr, DocDet.SerieID, #Copia.Copia " & _
                      "FROM  DocCab, Armazens Origem, Armazens Destino, DocDet, #Copia " & _
                      "WHERE(DocCab.ArmazemID = Origem.ArmazemID) " & _
                      "AND DocCab.TercID = Destino.ArmazemID  " & _
                      "AND DocCab.EmpresaID = DocDet.EmpresaID " & _
                      "AND DocCab.ArmazemID = DocDet.ArmazemID " & _
                      "AND DocCab.TipoDocID = DocDet.TipoDocID " & _
                      "AND DocCab.DocNr = DocDet.DocNr " & _
                      "AND DocCab.EmpresaID='" & xEmp & "' " & _
                      "AND DocCab.ArmazemID='" & xArmz & "' " & _
                      "AND DocCab.DocNr='" & xNumDoc & "' " & _
                      "AND DocCab.TipoDocID='CF' ORDER BY #Copia.Copia, DocDet.SerieID "

                .C1RptRelTaloes.Load(xRptPath & "RptConferencia.xml", "Conferencia")
                .C1RptRelTaloes.DataSource.ConnectionString = sConnectionStringReport
                .C1RptRelTaloes.DataSource.RecordSource = Sql
                .C1PrtPreview.Document = frmRpt.C1RptRelTaloes.Document

                .Show(frmReport)
            End With

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListaConferencia")
        Catch ex As Exception
            ErroVB(ex.Message, "ListaConferencia")
        End Try
    End Sub

    Public Sub ListaConferir(ByVal xNumDoc As String)

        Try
            frmRpt = New frmReport


            With frmRpt
                .StartPosition = FormStartPosition.CenterScreen
                .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize

                Sql = "SELECT 'ORIGINAL' Copia INTO #Copia UNION SELECT 'DUPLICADO'; " & _
                      "SELECT DocCab.DocNr, DocCab.DataDoc, DocCab.TercID DestCod, Destino.ArmAbrev as DestDescr, DocDet.SerieID, DocDet.ModeloID, DocDet.CorID, DocDet.TamID, DocDet.Descricao, DocDet.Valor, #Copia.Copia " & _
                      "FROM  DocCab, Armazens Origem, Armazens Destino, DocDet, #Copia " & _
                      "WHERE(DocCab.ArmazemID = Origem.ArmazemID) " & _
                      "AND DocCab.TercID = Destino.ArmazemID  " & _
                      "AND DocCab.EmpresaID = DocDet.EmpresaID " & _
                      "AND DocCab.ArmazemID = DocDet.ArmazemID " & _
                      "AND DocCab.TipoDocID = DocDet.TipoDocID " & _
                      "AND DocCab.DocNr = DocDet.DocNr " & _
                      "AND DocCab.EmpresaID='" & xEmp & "' " & _
                      "AND DocCab.ArmazemID='" & xArmz & "' " & _
                      "AND DocCab.DocNr='" & xNumDoc & "' " & _
                      "AND DocCab.TipoDocID='CF' " & _
                      "AND DocDet.EstadoLn in ('S','T') " & _
                      "ORDER BY #Copia.Copia, DocDet.SerieID "

                .C1Report1.Load(xRptPath & "RptConferir.xml", "Conferencia")
                .C1Report1.DataSource.ConnectionString = sConnectionStringReport
                .C1Report1.DataSource.RecordSource = Sql


                '.C1PrtPreview.Document = frmRpt.C1Report1.Document
                '.Show(frmReport)


                'If PrintDirect = True Then
                '    JustPrint(.C1Report1)
                'Else
                '    .C1PrtPreview.Document = frmRpt.C1Report1.Document
                '    .Show(frmReport)
                'End If

                JustPrint(.C1Report1)


            End With

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListaConferir")
        Catch ex As Exception
            ErroVB(ex.Message, "ListaConferir")
        End Try
    End Sub

    Public Sub ListaConferidos(ByVal xNumDoc As String)
        Try
            frmRpt = New frmReport


            With frmRpt
                .StartPosition = FormStartPosition.CenterScreen
                .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize

                Sql = "SELECT 'ORIGINAL' Copia INTO #Copia UNION SELECT 'DUPLICADO'; " & _
                      "SELECT DocCab.DocNr, DocCab.DataDoc, DocCab.TercID DestCod, Destino.ArmAbrev as DestDescr, DocDet.SerieID, DocDet.ModeloID, DocDet.CorID, DocDet.TamID, DocDet.Descricao, DocDet.Valor, #Copia.Copia " & _
                      "FROM  DocCab, Armazens Origem, Armazens Destino, DocDet, #Copia " & _
                      "WHERE(DocCab.ArmazemID = Origem.ArmazemID) " & _
                      "AND DocCab.TercID = Destino.ArmazemID  " & _
                      "AND DocCab.EmpresaID = DocDet.EmpresaID " & _
                      "AND DocCab.ArmazemID = DocDet.ArmazemID " & _
                      "AND DocCab.TipoDocID = DocDet.TipoDocID " & _
                      "AND DocCab.DocNr = DocDet.DocNr " & _
                      "AND DocCab.EmpresaID='" & xEmp & "' " & _
                      "AND DocCab.ArmazemID='" & xArmz & "' " & _
                      "AND DocCab.DocNr='" & xNumDoc & "' " & _
                      "AND DocCab.TipoDocID='CF' " & _
                      "AND DocDet.EstadoLn in ('SC','TC') " & _
                      "ORDER BY #Copia.Copia, DocDet.SerieID "

                .C1Report1.Load(xRptPath & "RptConferidos.xml", "Conferencia")
                .C1Report1.DataSource.ConnectionString = sConnectionStringReport
                .C1Report1.DataSource.RecordSource = Sql
                .C1PrtPreview.Document = frmRpt.C1Report1.Document

                .Show(frmReport)
            End With

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListaConferidos")
        Catch ex As Exception
            ErroVB(ex.Message, "ListaConferidos")
        End Try
    End Sub

    Public Sub ListaDevolucao(ByVal xNumDoc As String)
        Try
            frmRpt = New frmReport
            With frmRpt
                .StartPosition = FormStartPosition.CenterScreen
                .C1PrtPreview.PreviewPane.ZoomMode = C1.Win.C1PrintPreview.ZoomModeEnum.ActualSize


                Sql = "SELECT DocCab.DataDoc, DocCab.DocNr, DocCab.TercID, DocDet.ModeloID, DocDet.CorID, ModeloCor.ModCorDescr, ModeloCor.RefForn, ModeloCor.CorForn, ModeloCor.PrCusto, Terceiros.NomeAbrev, SUM(DocDet.Qtd) AS Qtd FROM DocCab INNER JOIN DocDet ON DocCab.EmpresaID = DocDet.EmpresaID AND DocCab.ArmazemID = DocDet.ArmazemID AND DocCab.TipoDocID = DocDet.TipoDocID AND DocCab.DocNr = DocDet.DocNr INNER JOIN ModeloCor ON DocDet.ModeloID = ModeloCor.ModeloID AND DocDet.CorID = ModeloCor.CorID INNER JOIN Terceiros ON DocCab.TercID = Terceiros.TercID GROUP BY DocCab.DataDoc, DocCab.EmpresaID, DocCab.ArmazemID, DocCab.TipoDocID, DocCab.DocNr, DocCab.TercID, DocDet.ModeloID, DocDet.CorID, ModeloCor.ModCorDescr, ModeloCor.RefForn, ModeloCor.CorForn, ModeloCor.PrCusto, Terceiros.NomeAbrev HAVING (DocCab.EmpresaID = '0001') AND (DocCab.ArmazemID = '0000') AND (DocCab.TipoDocID = 'DF') AND (DocCab.DocNr = N'" & xNumDoc & "')"



                'Sql = "SELECT 'ORIGINAL' Copia INTO #Copia UNION SELECT 'DUPLICADO';" & _
                '        "SELECT DocCab.DocNr, DocCab.DataDoc, DocCab.ArmazemID as OrigCod, Origem.ArmAbrev as OrigDescr,  DocCab.TercID DestCod, Destino.NomeAbrev as DestDescr, DocDet.SerieID, #Copia.Copia " & _
                '        "FROM  DocCab, Armazens Origem, Terceiros Destino, DocDet, #Copia  " & _
                '        "WHERE(DocCab.ArmazemID = Origem.ArmazemID) " & _
                '        "AND DocCab.TercID = Destino.TercID  " & _
                '        "AND DocCab.EmpresaID = DocDet.EmpresaID " & _
                '        "AND DocCab.ArmazemID = DocDet.ArmazemID " & _
                '        "AND DocCab.TipoDocID = DocDet.TipoDocID " & _
                '        "AND DocCab.DocNr = DocDet.DocNr " & _
                '        "AND DocCab.EmpresaID='" & xEmp & "' " & _
                '        "AND DocCab.ArmazemID='" & xArmz & "' " & _
                '        "AND DocCab.DocNr='" & xNumDoc & "' " & _
                '        "AND DocCab.TipoDocID='DF' ORDER BY #Copia.Copia, DocDet.SerieID "


                .C1Report1.Load(xRptPath & "RptDevolucaoForn.xml", "Devolucao")
                .C1Report1.DataSource.ConnectionString = sConnectionStringReport
                .C1Report1.DataSource.RecordSource = Sql
                .C1PrtPreview.Document = frmRpt.C1Report1.Document
                .Show(frmReport)

            End With

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ListaDevolucao")
        Catch ex As Exception
            ErroVB(ex.Message, "ListaDevolucao")
        End Try

    End Sub

    Private Sub AskPrinter(ByRef c1r1 As C1.Win.C1Report.C1Report)
        ' load report definition
        'c1r1.Load(xRptPath, reportName)

        ' get PrintDocument object
        Dim doc As New Printing.PrintDocument
        doc = c1r1.Document

        ' show a PrintDialog so user can customize the printing
        Dim pd As PrintDialog = New PrintDialog()

        ' use PrinterSettings in report document
        pd.PrinterSettings = doc.PrinterSettings

        ' show the dialog and print the report
        If pd.ShowDialog() = DialogResult.OK Then
            doc.Print()
        End If
        ' cleanup and release PrintDialog resources
        pd.Dispose()
    End Sub

    Public Sub JustPrint(ByRef c1r1 As C1.Win.C1Report.C1Report)
        Try
            Dim doctoprint As New Printing.PrintDocument
            doctoprint = c1r1.Document
            doctoprint.Print()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ExportaSAFT(ByVal sAnoExercicio As String)
        Dim db As New ClsSqlBDados
        Dim dsSaft As New DataSet
        Dim dtSI As New DataTable
        Dim Dt As New DataTable
        Dim drL As DataRow
        Dim drT As DataRow
        Dim Ficheiro As String = xRptPath & "Documentos.xml"
        Dim fileExists As Boolean
        Dim LocalErro As String = ""
        Try
            fileExists = My.Computer.FileSystem.FileExists(Ficheiro)
            If fileExists Then
                fileExists = My.Computer.FileSystem.FileExists("C:\GIRL\SAFT\SAF-T-PT.XSD")
                If fileExists Then
                    dsSaft.ReadXml(Ficheiro)
                    '==========================================================================
                    'Header
                    LocalErro = "ExportaSAFT - Header"
                    dsSaft.Tables("CompanyAddress").Clear()
                    dsSaft.Tables("Header").Clear()
                    Sql = "SELECT '1.00_01' AuditFileVersion, EmpNrRegisto CompanyID, EmpContrib TaxRegistrationNumber, 'Factura��o' TaxAccountingBasis, EmpNome CompanyName, " + sAnoExercicio + " FiscalYear, dbo.Data(convert(char(10), '" + sAnoExercicio + "' + '-01-01', 120)) StartDate, dbo.Data(convert(char(10), '" + sAnoExercicio + "' + '-12-31', 120)) EndDate, Moeda CurrencyCode, dbo.Data(GETDATE()) DateCreated, 'GIRL' ProductID, '1000.1' ProductVersion, EmpTelefone Telephone, EmpFax Fax, 'info@celferi.pt' Email, '' WebSite, '' HeaderComment, 1 Header_Id FROM Empresas"
                    db.GetData(Sql, dsSaft.Tables("Header"))
                    Sql = "SELECT EmpNumPolicia BuildingNumber, EmpMorada StreetName, EmpMorada AddressDetail, EmpLocalidade City, EmpCodPostal PostalCode, EmpDistrito Region, EmpPais Country, 1 Header_Id FROM Empresas"
                    db.GetData(Sql, dsSaft.Tables("CompanyAddress"))
                    '==========================================================================
                    'Tax
                    LocalErro = "ExportaSAFT - Header"
                    dsSaft.Tables("TaxCodeDetails").Clear()
                    dsSaft.Tables("TaxType").Clear()
                    dsSaft.Tables("TaxTable").Clear()
                    Sql = "SELECT 0 MasterFiles_Id, CAST(IvaID AS SMALLINT) TaxTable_Id FROM TaxIVA"
                    db.GetData(Sql, dsSaft.Tables("TaxTable"))
                    Sql = "SELECT CAST(IvaID AS SMALLINT) TaxTable_Id, CAST(IvaID AS SMALLINT) TaxType_Id, 'IVACON' Description FROM TaxIVA"
                    db.GetData(Sql, dsSaft.Tables("TaxType"))
                    Sql = "SELECT CAST(IvaID AS SMALLINT) TaxType_Id, TxIVA*100 TaxPercentage FROM TaxIVA"
                    db.GetData(Sql, dsSaft.Tables("TaxCodeDetails"))
                    '==========================================================================
                    'SalesInvoices, Invoice, DocumentTotals, Line e Tax
                    dsSaft.Tables("DocumentTotals").Clear()
                    dsSaft.Tables("Tax").Clear()
                    dsSaft.Tables("Line").Clear()
                    dsSaft.Tables("Invoice").Clear()
                    '--SalesInvoices
                    'J� est� Tratado
                    LocalErro = "ExportaSAFT - SalesInvoices"
                    Sql = "SELECT COUNT(*) NumberOfEntries, SUM(TotalDebit)TotalDebit, SUM(TotalCredit) TotalCredit, 0 AS SourceDocuments_Id FROM (SELECT ArmazemID, DocNr, SUM(ValDebito*(1+TxIVA)) AS TotalDebit, SUM(ValCredito*(1+TxIVA)) AS TotalCredit, TxIVA FROM VW_SAFT_Invoices WHERE Ano = " + sAnoExercicio + " GROUP BY ArmazemID, DocNr, TxIVA) A"
                    db.GetData(Sql, dtSI, False)
                    '--
                    With dsSaft.Tables("SalesInvoices").Rows(0)
                        .Item("NumberOfEntries") = dtSI.Rows(0)("NumberOfEntries")
                        .Item("TotalDebit") = dtSI.Rows(0)("TotalDebit")
                        .Item("TotalCredit") = dtSI.Rows(0)("TotalCredit")
                        .Item("SourceDocuments_Id") = dtSI.Rows(0)("SourceDocuments_Id")
                        .AcceptChanges()
                    End With
                    '--Invoice
                    'J� est� Tratado
                    LocalErro = "ExportaSAFT - Invoice"
                    Sql = "SELECT DISTINCT FacturaNo AS InvoiceNo, dbo.Data(DataDoc) AS InvoiceDate, dbo.DataHora(DtRegistoCab) AS SystemEntryDate, TipoDoc AS InvoiceType, TercID AS CustomerID, InvoiceID Invoice_Id, 0 AS SalesInvoices_Id FROM VW_SAFT_Invoices WHERE (Ano = " + sAnoExercicio + ")"
                    db.GetData(Sql, dsSaft.Tables("Invoice"), False)
                    '--DocumentTotals
                    'Como existem Facturas que n�o t�m detalhe,
                    'tivemos que descubrir as que n�o t�m e for�ar inserindo-as a 0
                    '----------------
                    'como existe duvidas em rela��o ao Script Sql anterior optei po deixa copia do Antigo
                    'Sql = "SELECT CAST(CAST(CASE WHEN DocDet.TipoDocID = 'FT' THEN '1' WHEN DocDet.TipoDocID = 'NC' THEN '2' WHEN DocDet.TipoDocID = 'ND' THEN '3' WHEN DocDet.TipoDocID = 'VD' THEN '4' END AS VARCHAR(5)) + CAST(CAST(DocDet.ArmazemID AS INT) AS VARCHAR(5)) + CAST(DocDet.DocNr AS VARCHAR(12)) AS INT) AS Invoice_Id, SUM((DocDet.Valor * DocDet.Qtd) * (1 + TaxIVA.TxIVA)) AS GrossTotal, SUM(DocDet.Valor * DocDet.Qtd * TaxIVA.TxIVA) AS TaxPayable, SUM(DocDet.Valor * DocDet.Qtd) AS NetTotal FROM DocDet INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE DocDet.TipoDocID IN ('FT','NC','VD','ND') GROUP BY DocDet.TipoDocID, DocDet.ArmazemID, DocDet.DocNr UNION SELECT A.Invoice_Id, 0 GrossTotal, 0 TaxPayable, 0 NetTotal FROM (SELECT CAST(CAST(CASE WHEN A.TipoDocID = 'FT' THEN '1' WHEN A.TipoDocID = 'NC' THEN '2' WHEN A.TipoDocID = 'ND' THEN '3' WHEN A.TipoDocID = 'VD' THEN '4' END AS VARCHAR(5)) + CAST(CAST(A.ArmazemID AS INT) AS VARCHAR(5)) + CAST(A.DocNr AS VARCHAR(12)) AS INT) AS Invoice_Id FROM DocCab A WHERE A.TipoDocID IN ('FT','NC','VD','ND')) A LEFT OUTER JOIN (SELECT CAST(CAST(CASE WHEN DocDet.TipoDocID = 'FT' THEN '1' WHEN DocDet.TipoDocID = 'NC' THEN '2' WHEN DocDet.TipoDocID = 'ND' THEN '3' WHEN DocDet.TipoDocID = 'VD' THEN '4' END AS VARCHAR(5)) + CAST(CAST(DocDet.ArmazemID AS INT) AS VARCHAR(5)) + CAST(DocDet.DocNr AS VARCHAR(12)) AS INT) AS Invoice_Id FROM DocDet INNER JOIN TaxIVA ON DocDet.IvaID = TaxIVA.IvaID INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE (DocDet.TipoDocID IN ('FT','NC','VD','ND')) GROUP BY DocDet.TipoDocID, DocDet.ArmazemID, DocDet.DocNr ) B ON A.Invoice_Id = B.Invoice_Id WHERE B.Invoice_Id IS NULL"
                    'J� est� Tratado
                    LocalErro = "ExportaSAFT - DocumentTotals"
                    Sql = "SELECT InvoiceID Invoice_Id, SUM(ValComDescIVA) GrossTotal, SUM(ValIVA) TaxPayable, SUM(ValComDesc) NetTotal FROM VW_SAFT_Invoices WHERE Ano = " + sAnoExercicio + " GROUP BY InvoiceID"
                    db.GetData(Sql, dsSaft.Tables("DocumentTotals"), False)
                    '--Line e Tax
                    'Tal como os DocumentTotals temos que inserir tb as linhas que n�o existem
                    'Sql = "SELECT DocLnNr LineNumber, ISNULL(ModeloID + CorID,'DIV') ProductCode, ISNULL(Descricao, 'Diversos') ProductDescription, ISNULL(Qtd,0) Quantity, ISNULL(Unidade,'UN') UnitOfMeasure, ISNULL(Valor,0) UnitPrice, DataDoc TaxPointDate, ISNULL(Descricao, 'Diversos') Description, 0 DebitAmount, ISNULL(Valor * Qtd,0) CreditAmount, ISNULL(VlrDescLn * Qtd,0) SettlementAmount, CAST( 0 AS INT) Line_Id, dbo.InvoiceID(B.TipoDocID, B.ArmazemID, B.DocNr) AS Invoice_Id, CAST(C.IvaID AS SMALLINT) TaxType, C.TxIVA*100 TaxPercentage FROM DocCab A, DocDet B, TaxIVA C WHERE A.EmpresaID = B.EmpresaID AND A.ArmazemID = B.ArmazemID AND A.TipoDocID = B.TipoDocID AND A.DocNr = B.DocNr AND B.IvaID = C.IvaID AND A.TipoDocID IN ('FT','NC','VD','ND') UNION SELECT 1 LineNumber, 'DIV' ProductCode, 'Diversos' ProductDescription, 0 Quantity, 'UN' UnitOfMeasure, 0 UnitPrice, DataDoc TaxPointDate, 'Diversos' Description, 0 DebitAmount, 0 CreditAmount, 0 SettlementAmount, 0 Line_Id, dbo.InvoiceID(A.TipoDocID, A.ArmazemID, A.DocNr) AS Invoice_Id, B.IvaID TaxType, B.TxIVA*100 TaxPercentage FROM DocCab A, (SELECT IvaID, TxIva FROM TaxIVA WHERE IvaID IN (SELECT MAX(IvaID) FROM TaxIVA WHERE TxIvaDef =1)) B WHERE A.TipoDocID IN ('FT','NC','VD','ND') AND dbo.InvoiceID(A.TipoDocID, A.ArmazemID, A.DocNr) NOT IN (SELECT DISTINCT dbo.InvoiceID(B.TipoDocID, B.ArmazemID, B.DocNr)Invoice_Id FROM  DocDet B, TaxIVA C WHERE B.IvaID = C.IvaID AND B.TipoDocID IN ('FT','NC','VD','ND'))"
                    'J� est� Tratado
                    LocalErro = "ExportaSAFT - Line e Tax"
                    Sql = "SELECT DocLnNr AS LineNumber, ISNULL(CodProduto, 'DIV') AS ProductCode, ISNULL(ModCorDescr, 'Diversos') AS ProductDescription, ISNULL(Qtd, 0) AS Quantity, ISNULL(Unidade, 'UN') AS UnitOfMeasure, ISNULL(ValComDesc, 0) AS UnitPrice, dbo.Data(DataDoc) AS TaxPointDate, ISNULL(ModCorDescr, 'Diversos') AS Description, ValDebito*-1 AS DebitAmount, ValCredito AS CreditAmount, ISNULL(ValDesconto, 0) AS SettlementAmount, CAST(0 AS INT) AS Line_Id, InvoiceID AS Invoice_Id, IvaID AS TaxType, TxIVA * 100 AS TaxPercentage FROM VW_SAFT_Invoices WHERE Ano = " + sAnoExercicio
                    db.GetData(Sql, Dt, False)
                    Dim I As Int64 = 1
                    For Each r As DataRow In Dt.Rows
                        r.Item("Line_Id") = I
                        I = I + 1
                    Next
                    For Each r As DataRow In Dt.Rows
                        drL = dsSaft.Tables("Line").NewRow
                        For Each c As DataColumn In dsSaft.Tables("Line").Columns
                            drL.Item(c.ColumnName) = r.Item(c.ColumnName)
                        Next
                        dsSaft.Tables("Line").Rows.Add(drL)
                    Next
                    For Each r As DataRow In Dt.Rows
                        drT = dsSaft.Tables("Tax").NewRow
                        For Each c As DataColumn In dsSaft.Tables("Tax").Columns
                            drT.Item(c.ColumnName) = r.Item(c.ColumnName)
                        Next
                        dsSaft.Tables("Tax").Rows.Add(drT)
                    Next
                    '==========================================================================
                    'Product
                    LocalErro = "ExportaSAFT - Product"
                    dsSaft.Tables("Product").Clear()
                    Sql = "SELECT 'P' AS ProductType, ModeloCor.ModeloID + ModeloCor.CorID AS ProductCode, Grupos.GrupoDesc AS ProductGroup, case when ModeloCor.ModCorDescr is null then Grupos.GrupoDesc else ModeloCor.ModCorDescr end AS ProductDescription, ModeloCor.ModeloID + ModeloCor.CorID AS ProductNumberCode, 0 AS MasterFiles_Id FROM Modelos INNER JOIN ModeloCor ON Modelos.ModeloID = ModeloCor.ModeloID INNER JOIN Grupos ON Modelos.GrupoID = Grupos.GrupoID"
                    db.GetData(Sql, dsSaft.Tables("Product"))
                    '==========================================================================
                    'BillingAddress, Customer
                    LocalErro = "ExportaSAFT - BillingAddress, Customer"
                    dsSaft.Tables("BillingAddress").Clear()
                    dsSaft.Tables("Customer").Clear()
                    Sql = "SELECT TercID AS CustomerID, ISNULL(CASE WHEN LEN(LTRIM(RTRIM(NIF))) = 0 then 'Desconhecido' ELSE REPLACE(LTRIM(RTRIM(NIF)),' ','') END,'Desconhecido') AS CustomerTaxID, ISNULL(Nome,'Desconhecido') AS CompanyName, CAST(TercID AS INT) AS Customer_Id, 0 AS MasterFiles_Id FROM Terceiros WHERE (TipoTerc <> 'I')"
                    db.GetData(Sql, dsSaft.Tables("Customer"))
                    Sql = "SELECT CAST(TercID AS INT) AS Customer_Id, ISNULL(Morada,'Desconhecido') AS AddressDetail, ISNULL(Localidade,'Desconhecido') AS City, ISNULL(CodPostal,'Desconhecido') AS PostalCode, 'Portugal' AS Country FROM Terceiros WHERE (TipoTerc <> 'I') "
                    db.GetData(Sql, dsSaft.Tables("BillingAddress"))
                    '==========================================================================
                    'Exportacao
                    LocalErro = "ExportaSAFT - Exportacao"
                    dsSaft.WriteXml("C:\Girl\SAFT\SaftGIRL.xml")
                    'dsSaft.WriteXml(xServerPath & "SaftGIRL.xml")
                    '==========================================================================
                    'Exporta��o Concluida
                    MsgBox("Ficherio SAFT-PT Exportado!", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            ErroVB(ex.Message, LocalErro)
        Finally
            If dsSaft IsNot Nothing Then dsSaft.Dispose()
            dsSaft = Nothing
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
            If dtSI IsNot Nothing Then dtSI.Dispose()
            dtSI = Nothing
            If Dt IsNot Nothing Then Dt.Dispose()
            Dt = Nothing
            drL = Nothing
            drT = Nothing
            Dt = Nothing
            Ficheiro = Nothing
            fileExists = Nothing
        End Try
    End Sub

    Public Sub FreeMem()

        'HELDER: FAZER ROTINA PARA LIBERTAR MEM�RIA DO SERVIDOR

    End Sub

    Public Sub IniciaTransacao()

        Dim db As New ClsSqlBDados

        Try


            'BEGIN(TRANSACTION)
            'UPDATE SERIE SET ESTADOID='X' WHERE SERIEID='08027292'
            'COMMIT()

            'SELECT ESTADOID FROM SERIE WHERE SERIEID='08027292'
            'ROLLBACK

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "IniciaTransacao")
        Catch ex As Exception
            ErroVB(ex.Message, "IniciaTransacao")
        End Try

    End Sub

    Public Sub GravarEvento(ByVal EventoDescr As String, Optional ByVal Descr1 As String = "", Optional ByVal Descr2 As String = "", Optional ByVal Descr3 As String = "")

        Dim db As New ClsSqlBDados
        Dim xArtigo As String

        Try

            'descr1 - local do evento
            'descr2 - tal�o
            'descr3 - estado e local do tal�o

            If Descr3 = "EMAIL" Then
                Descr3 = ""
                EnviarEmail("Erro", EventoDescr)
            End If

            Sql = "SELECT ARMAZEMID + '/' + ESTADOID FROM SERIE WHERE SERIEID='" & Descr2 & "'"
            Descr3 = db.GetDataValue(Sql)

            Sql = "SELECT ISNULL(ModeloID + '-' + CorID + '-' + TamID,'') Artigo FROM Serie WHERE SERIEID='" & Descr2 & "'"
            xArtigo = db.GetDataValue(Sql)


            Sql = "INSERT INTO Eventos (EventoDescr, Descr1, Descr2, Descr3, Artigo, OperadorID) VALUES ('" & EventoDescr & "','" & Descr1 & "', '" & Descr2 & "', '" & Descr3 & "', '" & xArtigo & "', '" & xUtilizador & "')"
            db.ExecuteData(Sql)




        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "GravarEventos")
        Catch ex As Exception
            ErroVB(ex.Message, "GravarEventos")
        End Try


    End Sub

    Public Sub TipodeArmazem()

        Dim db As New ClsSqlBDados

        Try

            Sql = "SELECT COUNT(Armazens.ArmazemID) FROM Armazens INNER JOIN Terceiros ON Armazens.TercID = Terceiros.TercID INNER JOIN Empresas ON Terceiros.NIF = Empresas.EmpContrib WHERE (Armazens.ArmazemID = '" & xArmz & "')"
            If db.GetDataValue(Sql) = 0 Then
                xLojaPropria = False
            Else
                xLojaPropria = True
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "TipodeArmazem")
        Catch ex As Exception
            ErroVB(ex.Message, "TipodeArmazem")
        End Try


    End Sub

    Public Sub GetUserInfo(ByRef Util As String)

        Dim UserIdentityInfo As System.Security.Principal.WindowsIdentity
        Dim strMsg As String
        UserIdentityInfo = System.Security.Principal.WindowsIdentity.GetCurrent()

        strMsg = "User Name: " & UserIdentityInfo.Name & vbCrLf
        strMsg = strMsg & " Token: " & UserIdentityInfo.Token.ToString() & vbCrLf
        strMsg = strMsg & " Authenticated: " & UserIdentityInfo.AuthenticationType & vbCrLf
        strMsg = strMsg & " System: " & UserIdentityInfo.IsSystem & vbCrLf
        strMsg = strMsg & " Guest: " & UserIdentityInfo.IsGuest & vbCrLf
        strMsg = strMsg & " Anonymous: " & UserIdentityInfo.IsAnonymous & vbCrLf

        'MessageBox.Show(strMsg)
        Util = UserIdentityInfo.Name

    End Sub

    Public Function CompareTwoDataTable(ByVal dt1 As DataTable, ByVal dt2 As DataTable) As DataTable
        'Dim dt3 As New DataTable

        'dt1.Merge(dt2)

        'dt3 = dt2.GetChanges()

        'Return dt3



        dt1.Merge(dt2)

        Dim d3 As DataTable = dt2.GetChanges()

        Return d3

    End Function

    Public Function ActualizaLigacao(ByVal Liga��o As String) As Boolean


        Try




            Application.DoEvents()

            If Liga��o = "Girl" Then
                sConnectionString = sConnectionStringGirl
                sConnectionStringReport = sConnectionStringGirlReport
                'frmMenuCelfGest.Text = "Menu Principal - Girl"
            ElseIf Liga��o = "CelfGest" Then
                sConnectionString = sConnectionStringCelfGest
                sConnectionStringReport = sConnectionStringCelfGestReport
                'frmMenuCelfGest.Text = "Menu Principal - CelfGest"
            End If

            Application.DoEvents()

            'Dim iInicio As Int16 = sConnectionString.IndexOf("=")
            'Dim iFim As Int16 = sConnectionString.IndexOf("\")
            'Dim sServidorActivo As String = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(sConnectionString, iFim), iFim - iInicio - 1)
            'If Not My.Computer.Network.Ping(sServidorActivo) Then
            '    MsgBox("N�o � Possivel ligar ao servidor!!")
            '    Return False
            'End If

            If cn.State = ConnectionState.Open Then cn.Close()
            cn.ConnectionString = sConnectionString

            Return True

        Catch ex As Exception
            'GravarEvento("ERRO NA LIGA��O AO " & Liga��o, xArmz, Now, "EMAIL")
            EnviarEmail("Erro", "ERRO NA LIGA��O AO " & Liga��o + " " + xArmz + " " + Now)
            Return False
        End Try




    End Function

    Public Sub FecharForms()
        Dim frm As Form
        For Each frm In Application.OpenForms
            frm.Close()
        Next


    End Sub

    Public Sub ActualizaEstadosReservas()

        Dim db As New ClsSqlBDados

        Try

            'TODO: N�O PODE ATUALIZAR AS RESERVAS COM DESPESA
            Sql = "BEGIN TRANSACTION UPDATE Reservas SET ReservaEstado = 1 FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr INNER JOIN Serie ON DocDet.SerieID = Serie.SerieID INNER JOIN Reservas ON DocDet.SerieID = Reservas.ReservaSerieID WHERE (Reservas.ReservaDescr LIKE 'Transferir%') AND (DocDet.EstadoLn = 'G') AND (DocCab.TipoDocID = 'SE') AND Serie.EstadoID in ('S','T') AND (Reservas.ReservaEstado = 0); UPDATE Reservas SET ReservaEstado = 1 FROM Reservas INNER JOIN Serie ON Reservas.ReservaSerieID = Serie.SerieID WHERE (Serie.EstadoID IN ('V', 'R', 'A')) AND (Reservas.ReservaEstado = 0) AND (Reservas.Despesas = 0) COMMIT TRANSACTION"
            db.ExecuteData(Sql)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizaEstadosReservas")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizaEstadosReservas")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    'Private Sub EncryptAT(ByVal pPwdAT As String, ByVal pPathCertf As String)

    '    Dim sHash As String = "2010-05-18;2010-05-18T11:22:19;FAC 001/14;3.12;"


    '    Dim strEncryptPasswordAT As String, strEncryptCreatedAT As String, strEncryptNonceAT As String


    '    Try
    '        Dim CaminhoChavePublica As String = pPathCertf
    '        ' Variaveis a encriptar
    '        Dim PassFinancas As String = pPwdAT
    '        'Dim DataCriacao As String = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "Z"
    '        Dim DataCriacao As String = DateTime.UtcNow.ToString("s") & "Z"
    '        ' Carregar chave p�blica
    '        Dim certCP As New System.Security.Cryptography.X509Certificates.X509Certificate2
    '        certCP.Import(CaminhoChavePublica)
    '        Dim ChavePublica As String = certCP.PublicKey.Key.ToXmlString(False)
    '        ' Gerar Chave Sim�trica para o envio da informa��o
    '        ' Esta chave tem que ser diferente em todos os envios, pelo que dever�o arranjar um m�todo de ser sempre diferente
    '        ' Comprimento: 16
    '        ' Exemplo
    '        'Dim ChaveSimetrica As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
    '        'Dim ChaveSimetrica() As Byte = GerarChaveSimetrica()
    '        Dim aleatorios As New Random()
    '        Dim ChaveSimetrica(15) As Byte
    '        aleatorios.NextBytes(ChaveSimetrica)
    '        ' Inserir Chave Simetrica nos parametros de encripta��o
    '        Dim rijn As System.Security.Cryptography.SymmetricAlgorithm = System.Security.Cryptography.SymmetricAlgorithm.Create()
    '        rijn.Key = ChaveSimetrica
    '        rijn.IV = ChaveSimetrica
    '        rijn.Mode = System.Security.Cryptography.CipherMode.ECB
    '        rijn.Padding = System.Security.Cryptography.PaddingMode.PKCS7
    '        ' Encriptar password das financas
    '        Dim msPassFinancas As New System.IO.MemoryStream
    '        Dim csPassFinancas As New System.Security.Cryptography.CryptoStream(msPassFinancas, rijn.CreateEncryptor(rijn.Key, rijn.IV), System.Security.Cryptography.CryptoStreamMode.Write)
    '        Using swPassFinancas As New System.IO.StreamWriter(csPassFinancas)
    '            swPassFinancas.Write(PassFinancas)
    '        End Using
    '        ' Encriptar data de cria��o
    '        Dim msDataCriacao As New System.IO.MemoryStream
    '        Dim csDataCriacao As New System.Security.Cryptography.CryptoStream(msDataCriacao, rijn.CreateEncryptor(rijn.Key, rijn.IV), System.Security.Cryptography.CryptoStreamMode.Write)
    '        Using swDataCriacao As New System.IO.StreamWriter(csDataCriacao)
    '            swDataCriacao.Write(DataCriacao)
    '        End Using
    '        ' Converter de bytes para string
    '        Dim PassFinancasEncriptada As String = Convert.ToBase64String(msPassFinancas.ToArray())
    '        Dim DataCriacaoEncriptada As String = Convert.ToBase64String(msDataCriacao.ToArray())
    '        ' Encriptar a chave simetrica com o algoritmo RSA e com a chave p�blica
    '        Dim AlgRSA As New System.Security.Cryptography.RSACryptoServiceProvider
    '        AlgRSA.FromXmlString(ChavePublica)
    '        Dim Chave() As Byte = AlgRSA.Encrypt(ChaveSimetrica, False)
    '        Dim ChaveSimetricaEncriptada As String = Convert.ToBase64String(Chave)
    '        strEncryptPasswordAT = PassFinancasEncriptada
    '        strEncryptCreatedAT = DataCriacaoEncriptada
    '        strEncryptNonceAT = ChaveSimetricaEncriptada
    '    Catch ex As Exception
    '        strEncryptPasswordAT = ""
    '        strEncryptCreatedAT = ""
    '        strEncryptNonceAT = ""
    '    End Try
    'End Sub

    'ROTINAS DE IMPORTA��O e EXPORTA��O

    Public Function VerificaServidorActivo(ByVal xServidor As String) As Boolean
        Try
            If My.Computer.Network.Ping(xServidor) Then
                Return True
            Else
                MsgBox("ERRO NA LIGA��O AO " & xServidor)
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub ExportToGirl()

        Dim dbRastreio As New ClsSqlBDados
        Dim dbCelfGest As New ClsSqlBDados
        Dim dbGirl As New ClsSqlBDados
        Dim dbDelRastreio As New ClsSqlBDados
        Dim dtRastreio As New DataTable
        dberrorAtivo = True

        Try

            Sql = "SELECT ISNULL(Var3,'0') Var3 FROM Empresas WHERE EmpresaID = '" & xEmp & "' "
            If dbCelfGest.GetDataValue(Sql) = "1" Then
                MsgBox("A Exporta��o est� a ser executada por outro utilizador!")
                Exit Try
            End If

            Sql = "UPDATE Empresas SET Var3 ='1' WHERE EmpresaID = '" & xEmp & "'"
            dbCelfGest.ExecuteData(Sql)

            Sql = "SELECT idRastreio, TABELA, CHAVE, ACCAO, OperadorID, DtRegisto FROM Rastreio where Error='False' order by Seq Asc"
            dbRastreio.GetData(Sql, dtRastreio)

            For Each rRastreio As DataRow In dtRastreio.Rows

                Dim dr As SqlDataReader
                dberror = False

                Select Case rRastreio("TABELA").ToString

                    Case "Modelos"
                        'INSERT/UPDATE/DELETE

                        Select Case rRastreio("ACCAO").ToString

                            Case "INSERT"

                                Sql = "SELECT * FROM MODELOS WHERE MODELOID='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbCelfGest.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("Girl")
                                    Sql = "INSERT INTO Modelos (ModeloID, GrupoID, TipoID, Altura, EpocaID, LinhaID, UnidId, EscalaId, OperadorID) VALUES ('" & dr("ModeloID") & "', '" & dr("GrupoId") & "', '" & dr("TipoID") & "', '" & dr("Altura") & "', '" & dr("EpocaId") & "', '" & dr("LinhaID") & "', '" & dr("UnidId") & "', '" & dr("EscalaId") & "', '" & dr("OperadorID") & "') "
                                    dbGirl.ExecuteData(Sql)
                                End If
                                dr.Close()

                        End Select

                    Case "ModeloCor"

                        'INSERT/UPDATE/DELETE

                        Select Case rRastreio("ACCAO").ToString

                            Case "INSERT"

                                Sql = "SELECT * FROM MODELOCOR WHERE IDMODELOCOR='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbCelfGest.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("Girl")
                                    Sql = "INSERT INTO ModeloCor (ModeloID, CorID, ModCorDescr, FornId, RefForn, CorForn, PrCusto, PrVnd, OperadorID, Obs, IdModeloCor) VALUES ('" & dr("ModeloID") & "', '" & dr("CorID") & "', '" & dr("ModCorDescr") & "', '2000', ' ', '" & dr("CorForn") & "', " & dr("PrCusto") & ", " & dr("PrVnd") & ", '" & dr("OperadorID") & "', '" & dr("Obs") & "', '" & dr("IdModeloCor").ToString & "') "
                                    dbGirl.ExecuteData(Sql)
                                End If
                                dr.Close()


                        End Select

                    Case "Serie"
                        'INSERT

                        Select Case rRastreio("ACCAO").ToString

                            Case "INSERT"

                                'Sql = "SELECT * FROM SERIE WHERE SERIEID=" & rRastreio("CHAVE")
                                Sql = "SELECT SerieID, ModeloID, CorID, TamID, ArmazemID, PrecoEtiqueta, PrecoVenda, Comissao, NrEnc, DtEntrada, DocNr, PVndReal, ISNULL(DtSaida,'') DtSaida, Obs, Obs1, EstadoID, Rp, Vendedor, PrFixo, ProductCode, OperadorID, DtRegisto FROM Serie WHERE (SerieID = '" & rRastreio("CHAVE") & "')"

                                dr = dbCelfGest.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("Girl")
                                     Sql = "INSERT INTO  Serie (SerieID, ModeloID, CorID, TamID, ArmazemID, PrecoEtiqueta, PrecoVenda, DtSaida, EstadoID, ProductCode, OperadorID ) VALUES ('" & dr("SerieID") & "', '" & dr("ModeloID") & "', '" & dr("CorID") & "', '" & dr("TamID") & "', '" & dr("ArmazemID") & "', " & Format(dr("PrecoEtiqueta"), "#,##0.00") & ", " & Format(dr("PrecoEtiqueta"), "#,##0.00") & ", '" & Format(dr("DtSaida"), "yyyy-MM-dd") & "', '" & dr("EstadoID") & "', '" & dr("ProductCode") & "', '" & dr("OperadorID") & "')"
                                    dbGirl.ExecuteData(Sql)
                                End If
                                dr.Close()

                            Case "UPDATE"

                                Sql = "SELECT * FROM SERIE WHERE SERIEID=" & rRastreio("CHAVE")
                                dr = dbCelfGest.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("Girl")
                                    'Sql = "UPDATE Serie SET TamID='" & dr("TamID") & "', PrecoEtiqueta =  " & Format(dr("PrecoEtiqueta"), "#,##0.00") & ", Obs ='" & dr("Obs") & "', OperadorID ='" & dr("OperadorID") & "'  WHERE SERIEID=" & rRastreio("CHAVE")
                                    Sql = "UPDATE Serie SET TamID='" & dr("TamID") & "', MeiosPontos='" & dr("MeiosPontos") & "' WHERE SERIEID=" & rRastreio("CHAVE")
                                    dbGirl.ExecuteData(Sql)
                                End If
                                dr.Close()

                        End Select

                End Select

                ActualizaLigacao("CelfGest")
                Sql = "DELETE FROM RASTREIO WHERE idRastreio='" & rRastreio("idRastreio").ToString & "'"
                If dberror = False Then
                    dbDelRastreio.ExecuteData(Sql)
                Else
                    GravarEvento("Erro N�101!!", xArmz, "00000000", "Exp")
                    Sql = "UPDATE Rastreio SET Error = 'True' WHERE idRastreio='" & rRastreio("idRastreio").ToString & "'"
                    dbDelRastreio.ExecuteData(Sql)

                End If
            Next

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ExportToGirl")
        Catch ex As Exception
            ErroVB(ex.Message, "ExportToGirl")
        Finally

            If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")

            Sql = "UPDATE Empresas SET Var3 ='0' WHERE EmpresaID = '" & xEmp & "'"
            dbCelfGest.ExecuteData(Sql)

            If dbRastreio IsNot Nothing Then dbRastreio.Dispose()
            If dbCelfGest IsNot Nothing Then dbCelfGest.Dispose()
            If dbGirl IsNot Nothing Then dbGirl.Dispose()
            If dbDelRastreio IsNot Nothing Then dbGirl.Dispose()

            dbRastreio = Nothing
            dbCelfGest = Nothing
            dbGirl = Nothing
            dbDelRastreio = Nothing
            dr = Nothing
            dberrorAtivo = False



        End Try

    End Sub

    Public Sub ImportFromGirl()

        Dim dbRastreio As New ClsSqlBDados
        Dim dbCelfGest As New ClsSqlBDados

        Dim dbGirl As New ClsSqlBDados
        Dim dbDelRastreio As New ClsSqlBDados
        Dim dtRastreio As New DataTable
        dberrorAtivo = True
        Try


            Sql = "SELECT ISNULL(Var4,'0') Var4 FROM Empresas WHERE EmpresaID = '" & xEmp & "' "
            If dbCelfGest.GetDataValue(Sql) = "1" Then
                Exit Try
            End If

            Sql = "UPDATE Empresas SET Var4 ='1' WHERE EmpresaID = '" & xEmp & "'"
            dbCelfGest.ExecuteData(Sql)

            ActualizaLigacao("Girl")
            Sql = "SELECT idRastreio, TABELA, CHAVE, ACCAO, OperadorID, DtRegisto FROM Rastreio where Error='False' order by Seq Asc"
            dbRastreio.GetData(Sql, dtRastreio)

            ActualizaLigacao("CelfGest")

            If dtRastreio.Rows.Count >= 3500 Then
                GravarEvento(">3500 LINHAS NA IMP!", xArmz, "00000000", "xxxx")
                'If MsgBox("Tempo estimado de Importa��o : " & Int(dtRastreio.Rows.Count / 300) & " min", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                '    Exit Sub
                'End If
            End If

            For Each rRastreio As DataRow In dtRastreio.Rows

                Dim dr As SqlDataReader
                dberror = False

                Select Case rRastreio("TABELA").ToString

                    Case "Grupos"

                        Select Case rRastreio("ACCAO").ToString


                            Case "INSERT"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM GRUPOS WHERE GRUPOID='" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "INSERT INTO GRUPOS (GRUPOID, GRUPODESC, ESCALAIDDEF, UNIDIDDEF, OperadorID) VALUES ('" & dr("GRUPOID") & "','" & dr("GRUPODESC") & "','" & dr("ESCALAIDDEF") & "','" & dr("UNIDIDDEF") & "','" & dr("OperadorID") & "')"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM GRUPOS WHERE GRUPOID='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "UPDATE GRUPOS SET GRUPODESC='" & dr("GRUPODESC") & "', ESCALAIDDEF='" & dr("ESCALAIDDEF") & "', UNIDIDDEF='" & dr("UNIDIDDEF") & "', OperadorID='" & dr("OperadorID") & "' WHERE GRUPOID='" & dr("GRUPOID") & "'"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "DELETE"

                                ActualizaLigacao("CelfGest")
                                Sql = "DELETE GRUPOS Where GRUPOID='" & rRastreio("CHAVE").ToString & "'"
                                dbCelfGest.ExecuteData(Sql)

                        End Select


                    Case "Tipos"

                        Select Case rRastreio("ACCAO").ToString


                            Case "INSERT"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM TIPOS WHERE TIPOID='" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "INSERT INTO TIPOS (TIPOID, DESCRTIPO, DESCRABREV, DESCRAUX, CATEGORIES_ID, PID, PIDDESCR, Ordem, OperadorID) VALUES ('" & dr("TIPOID") & "','" & dr("DESCRTIPO") & "','" & dr("DESCRABREV") & "','" & dr("DESCRAUX") & "','" & dr("CATEGORIES_ID") & "','" & dr("PID") & "','" & dr("PIDDESCR") & "','" & dr("Ordem") & "''" & dr("OperadorID") & "','" & dr("DtRegisto").ToString & "')"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM TIPOS WHERE TIPOID='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "UPDATE TIPOS SET DESCRTIPO='" & dr("DESCRTIPO") & "', DESCRABREV='" & dr("DESCRABREV") & "', DESCRAUX='" & dr("DESCRAUX") & "', CATEGORIES_ID='" & dr("CATEGORIES_ID") & "', PID='" & dr("PID") & "', PIDDESCR='" & dr("PIDDESCR") & "', Ordem='" & dr("Ordem") & "', OperadorID='" & dr("OperadorID") & "' WHERE TIPOID='" & dr("TIPOID") & "'"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "DELETE"

                                ActualizaLigacao("CelfGest")
                                Sql = "DELETE TIPOS Where TIPOID='" & rRastreio("CHAVE").ToString & "'"
                                dbCelfGest.ExecuteData(Sql)

                        End Select



                    Case "Escalas"

                        Select Case rRastreio("ACCAO").ToString

                            Case "INSERT"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM ESCALAS WHERE EscalaID+TamID='" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "INSERT INTO ESCALAS (EscalaID, TamId, TamDescr) VALUES ('" & dr("EscalaID") & "','" & dr("TamId") & "','" & dr("TamDescr") & "')"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM ESCALAS WHERE EscalaID+TamID='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "UPDATE ESCALAS SET TamDescr='" & dr("TamDescr") & "' WHERE EscalaID='" & dr("EscalaID") & "' AND TamId='" & dr("TamId") & "'"

                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "DELETE"

                                ActualizaLigacao("CelfGest")
                                Sql = "DELETE ESCALAS Where EscalaID+TamID='" & rRastreio("CHAVE").ToString & "'"
                                dbCelfGest.ExecuteData(Sql)

                        End Select



                    Case "Cores"

                        Select Case rRastreio("ACCAO").ToString


                            Case "INSERT"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM Cores WHERE CORID='" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "INSERT INTO CORES (CORID, DESCRCOR, OPERADORID) VALUES ('" & dr("CORID") & "','" & dr("DESCRCOR") & "','" & dr("OPERADORID") & "')"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM CORES WHERE CORID='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "UPDATE CORES SET DESCRCOR='" & dr("DESCRCOR") & "', OperadorID='" & dr("OperadorID") & "' WHERE CORID='" & dr("CORID") & "'"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "DELETE"

                                ActualizaLigacao("CelfGest")
                                Sql = "DELETE CORES Where CORID='" & rRastreio("CHAVE").ToString & "'"
                                dbCelfGest.ExecuteData(Sql)

                        End Select


                    Case "Product"

                        Select Case rRastreio("ACCAO").ToString


                            Case "INSERT"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM Product WHERE ProductCode='" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "INSERT INTO Product  (ProductType, ProductCode, ProductGroup, ProductDescription, ProductNumberCode, UnitOfMeasure) VALUES ('" & dr("ProductType") & "','" & dr("ProductCode") & "','" & dr("ProductGroup") & "', '" & dr("ProductDescription") & "','" & dr("ProductNumberCode") & "','" & dr("UnitOfMeasure") & "')"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM Product WHERE ProductCode='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "UPDATE Product SET ProductType='" & dr("ProductType") & "', ProductGroup='" & dr("ProductGroup") & "', ProductDescription='" & dr("ProductDescription") & "', ProductNumberCode='" & dr("ProductNumberCode") & "', UnitOfMeasure='" & dr("UnitOfMeasure") & "' WHERE ProductCode='" & dr("ProductCode") & "'"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "DELETE"

                                ActualizaLigacao("CelfGest")
                                Sql = "DELETE Product Where ProductCode='" & rRastreio("CHAVE").ToString & "'"
                                dbCelfGest.ExecuteData(Sql)

                        End Select




                    Case "Modelos"


                        Select Case rRastreio("ACCAO").ToString

                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM MODELOS WHERE MODELOID='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "UPDATE Modelos SET GrupoID='" & dr("GrupoId") & "', TipoID='" & dr("TipoID") & "', Altura='" & dr("Altura") & "', EpocaID='" & dr("EpocaId") & "', LinhaID='" & dr("LinhaID") & "', UnidId='" & dr("UnidId") & "', EscalaId='" & dr("EscalaId") & "', OperadorID='" & dr("OperadorID") & "' WHERE ModeloID='" & dr("ModeloID") & "'"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()

                        End Select

                    Case "ModeloCor"


                        Select Case rRastreio("ACCAO").ToString

                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM MODELOCOR WHERE IDMODELOCOR='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "UPDATE ModeloCor SET ModCorDescr = '" & dr("ModCorDescr") & "', PrVnd =  " & dr("PrVnd") & ", PrCusto =" & dr("PrCusto") & ", OperadorID = '" & dr("OperadorID") & "' WHERE IdModeloCor='" & dr("IdModeloCor").ToString & "'"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()

                        End Select

                    Case "Serie"

                        Select Case rRastreio("ACCAO").ToString

                            Case "UPDATE"

                                ActualizaLigacao("Girl")

                                Sql = "SELECT COUNT(*) FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr AND DocDet.ArmazemID = DocCab.TercID WHERE (DocDet.TipoDocID = 'SE') AND (DocCab.EstadoDoc = 'C') AND (DocDet.SerieID = '" & rRastreio("CHAVE") & "')"
                                Dim sSepPropCasa As Integer = dbGirl.GetDataValue(Sql)


                                Sql = "SELECT * FROM SERIE WHERE SERIEID='" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)

                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Dim sdtSaida As String
                                    Dim sdtEntrada As String
                                    If dr("DtSaida") Is DBNull.Value Then sdtSaida = "1900-01-01" Else sdtSaida = Format(dr("DtSaida"), "yyyy-MM-dd HH:mm:ss.fff")
                                    If dr("DtEntrada") Is DBNull.Value Then sdtEntrada = "1900-01-01" Else sdtEntrada = Format(dr("DtEntrada"), "yyyy-MM-dd HH:mm:ss.fff")
                                    If dr("EstadoID") <> "P" Then  'ENQUANTO N�O APAGO O ESTADO P
                                        'SE ALGUEM MEXER EM INFORMA��O NA TABELA SERIE DO SERVIDOR ANTES DO ESTADO P, VAI ALTERAR UM TAL�O QUE PODE ESTAR SEPARADO

                                        If sSepPropCasa = 0 Then
                                            Sql = "UPDATE Serie SET ModeloID='" & dr("ModeloID") & "', CorID = '" & dr("CorID") & "', ArmazemID = '" & dr("ArmazemID") & "', PrecoEtiqueta =  " & Format(dr("PrecoEtiqueta"), "#,##0.00") & ", PrecoVenda =" & Format(dr("PrecoVenda"), "#,##0.00") & ", Comissao = " & dr("Comissao") & ", DtEntrada = '" & sdtEntrada & "', DocNr = '" & dr("DocNr") & "', PVndReal = " & Format(dr("PVndReal"), "#,##0.00") & ", DtSaida = '" & sdtSaida & "', Obs ='" & Trim(dr("Obs").ToString) & "', Obs1 ='" & Trim(dr("Obs1").ToString) & "', EstadoID = '" & dr("EstadoID") & "', Rp ='" & dr("Rp") & "', PrFixo ='" & dr("PrFixo") & "', Vendedor ='" & dr("Vendedor") & "', ProductCode ='" & dr("ProductCode") & "', MeiosPontos ='" & dr("MeiosPontos") & "', OperadorID ='" & dr("OperadorID") & "'  WHERE SERIEID='" & rRastreio("CHAVE") & "'"
                                        Else
                                            'N�O ALTERA O ESTADO!!!
                                            Sql = "UPDATE Serie SET ModeloID='" & dr("ModeloID") & "', CorID = '" & dr("CorID") & "', ArmazemID = '" & dr("ArmazemID") & "', PrecoEtiqueta =  " & Format(dr("PrecoEtiqueta"), "#,##0.00") & ", PrecoVenda =" & Format(dr("PrecoVenda"), "#,##0.00") & ", Comissao = " & dr("Comissao") & ", DtEntrada = '" & sdtEntrada & "', DocNr = '" & dr("DocNr") & "', PVndReal = " & Format(dr("PVndReal"), "#,##0.00") & ", DtSaida = '" & sdtSaida & "', Obs ='" & Trim(dr("Obs").ToString) & "', Obs1 ='" & Trim(dr("Obs1").ToString) & "', Rp ='" & dr("Rp") & "', PrFixo ='" & dr("PrFixo") & "', Vendedor ='" & dr("Vendedor") & "', ProductCode ='" & dr("ProductCode") & "', MeiosPontos ='" & dr("MeiosPontos") & "', OperadorID ='" & dr("OperadorID") & "'  WHERE SERIEID='" & rRastreio("CHAVE") & "'"
                                            'MeiosPontos
                                        End If
                                        dbCelfGest.ExecuteData(Sql)
                                    End If
                                End If
                                dr.Close()
                        End Select

                    Case "DocCab"
                        'INSERT

                        Select Case rRastreio("ACCAO").ToString

                            Case "INSERT"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM DocCab WHERE IdDocCab='" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Dim sIdDocCabOrig As String = ""
                                    Dim sFormaPagtoID As String = ""
                                    Dim sPPagID As String = ""
                                    Dim sObs2 As String = ""
                                    Dim sObs3 As String = ""
                                    Dim sDescontoDoc As String = ""

                                    Dim sDataDoc As String = Format(dr("DataDoc"), "yyyy-MM-dd HH:mm:ss.fff")
                                    If dr("IdDocCabOrig") Is DBNull.Value Then sIdDocCabOrig = "Null" Else sIdDocCabOrig = "'" & dr("IdDocCabOrig").ToString & "'"
                                    If dr("FormaPagtoID") Is DBNull.Value Then sFormaPagtoID = "Null" Else sFormaPagtoID = "'" & dr("FormaPagtoID").ToString & "'"
                                    If dr("PPagID") Is DBNull.Value Then sPPagID = "Null" Else sPPagID = "'" & dr("PPagID").ToString & "'"
                                    If dr("Obs2") Is DBNull.Value Then sObs2 = "Null" Else sObs2 = "'" & dr("Obs2").ToString & "'"
                                    If dr("Obs3") Is DBNull.Value Then sObs3 = "Null" Else sObs3 = "'" & dr("Obs3").ToString & "'"
                                    If dr("DescontoDoc") Is DBNull.Value Then sDescontoDoc = "Null" Else sDescontoDoc = "'" & dr("DescontoDoc").ToString & "'"



                                    'Sql = "INSERT INTO DocCab (EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, TipoDocOrig, DocNrOrig, IdDocCab, IdDocCabOrig, OperadorID) VALUES ('" & dr("EmpresaID") & "','" & dr("ArmazemID") & "','" & dr("TipoDocID") & "','" & dr("DocNr") & "','" & dr("TercID") & "','" & sDataDoc & "','" & Trim(dr("EstadoDoc")) & "','" & dr("TipoDocOrig") & "','" & dr("DocNrOrig") & "','" & dr("IdDocCab").ToString & "'," & sIdDocCabOrig & ",'" & dr("OperadorID") & "')"
                                    'Sql = "INSERT INTO DocCab (EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, TipoDocOrig, DocNrOrig, IdDocCab, IdDocCabOrig, OperadorID) VALUES ('" & dr("EmpresaID") & "', '" & dr("ArmazemID") & "', '" & dr("TipoDocID") & "', '" & dr("DocNr") & "', '" & dr("TercID") & "', '" & sDataDoc & "', '" & Trim(dr("EstadoDoc")) & "', '" & dr("TipoDocOrig") & "', '" & dr("DocNrOrig") & "', '" & dr("IdDocCab").ToString & "', " & sIdDocCabOrig & ", '" & dr("OperadorID") & "', '" & dr("LocalCarga") & "', '" & dr("HoraCarga") & "', '" & dr("LocDesc") & "', '" & dr("HoraDesc") & "', '" & dr("Obs") & "', '" & dr("Obs1") & "', '" & dr("TipoTerc") & "', '" & dr("PPagID") & "', '" & dr("Obs2") & "', '" & dr("Obs3") & "', '" & dr("DescontoDoc") & "', '" & dr("FormaPagtoID") & "')"
                                    Sql = "INSERT INTO DocCab (EmpresaID, ArmazemID, TipoDocID, DocNr, TercID, DataDoc, EstadoDoc, TipoDocOrig, DocNrOrig, IdDocCab, IdDocCabOrig, OperadorID, LocalCarga, HoraCarga, LocDesc, HoraDesc, Obs, Obs1, TipoTerc, PPagID, Obs2, Obs3, DescontoDoc, FormaPagtoID, UtilizadorID) VALUES ('" & dr("EmpresaID") & "', '" & dr("ArmazemID") & "', '" & dr("TipoDocID") & "', '" & dr("DocNr") & "', '" & dr("TercID") & "', '" & sDataDoc & "', '" & Trim(dr("EstadoDoc")) & "', '" & dr("TipoDocOrig") & "', '" & dr("DocNrOrig") & "', '" & dr("IdDocCab").ToString & "', " & sIdDocCabOrig & ", '" & dr("OperadorID") & "', '" & dr("LocalCarga") & "', '" & dr("HoraCarga") & "', '" & dr("LocDesc") & "', '" & dr("HoraDesc") & "', '" & dr("Obs") & "', '" & dr("Obs1") & "', '" & dr("TipoTerc") & "', " & sPPagID & ", " & sObs2 & ", " & sObs3 & ", " & sDescontoDoc & ",  " & sFormaPagtoID & ",  '" & dr("UtilizadorID") & "')"

                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "DELETE"

                                ActualizaLigacao("CelfGest")
                                Sql = "DELETE FROM DocCab Where IdDocCab='" & rRastreio("CHAVE").ToString & "'"
                                dbCelfGest.ExecuteData(Sql)

                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM DocCab WHERE IdDocCab='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")

                                    'Sql = "UPDATE dbo.DocCab SET EmpresaID = '" & dr("EstadoDoc") & "' ,ArmazemID = '" & dr("ArmazemID") & "' ,TipoDocID = '" & dr("TipoDocID") & "' ,DocNr = '" & dr("DocNr") & "' ,TercID = '" & dr("TercID") & "' ,DataDoc = 'DATA' ,TipoDocOrig = '" & dr("TipoDocOrig") & "' ,DocNrOrig = '" & dr("DocNrOrig") & "' ,Exp = '" & dr("Exp") & "' ,PPagID = 0 ,LocalCarga = '" & dr("LocalCarga") & "' ,HoraCarga = '" & dr("HoraCarga") & "' ,LocDesc = '" & dr("LocDesc") & "' ,HoraDesc = '" & dr("HoraDesc") & "' ,Obs = '" & dr("Obs") & "' ,Obs1 = '" & dr("Obs1") & "' ,Obs2 = 0 ,Obs3 = 0 ,DescontoDoc = 0 ,EstadoDoc = '" & dr("EstadoDoc") & "' ,TipoTerc = '" & dr("EstadoDoc") & "' ,NIFTerc = '" & dr("NIFTerc") & "' ,FormaPagtoID = 0 ,IdDocCab = '" & dr("IdDocCab") & "' ,IdDocCabOrig = '" & dr("IdDocCabOrig") & "' ,UtilizadorID = 0 ,OperadorID = '" & dr("OperadorID") & "' ,DtRegisto = 'DATA' ,SAFT = 0 ,DtUltAlt = 'DATA' ,AddressDetailCarga = '" & dr("AddressDetailCarga") & "' ,CityCarga = '" & dr("CityCarga") & "' ,PostalCodeCarga = '' ,CountryCarga ='' ,MovementStartTime = 'DATATIME' ,AddressDetailDescarga = '" & dr("EstadoDoc") & "' ,CityDescarga = '" & dr("EstadoDoc") & "' ,PostalCodeDescarga = '" & dr("EstadoDoc") & "' ,CountryDescarga = '" & dr("EstadoDoc") & "' ,MovementEndTime = 'DATATIME' ,ATDocCodeID = 0 ,Hash = '" & dr("EstadoDoc") & "' ,Hash4d = '" & dr("EstadoDoc") & "' ,ChaveAssinar = '" & dr("EstadoDoc") & "' ,ChavePrivadaVersao = 0 ,SerieDoc = '" & dr("EstadoDoc") & "' ,NrDoc = '" & dr("EstadoDoc") & "' ,DocOrig = '" & dr("EstadoDoc") & "' WHERE IdDocCab='" & dr("IdDocCab").ToString & "'"
                                    Sql = "UPDATE DOCCAB SET  EstadoDoc = '" & Trim(dr("EstadoDoc")) & "', Obs = '" & Trim(dr("Obs")) & "', Obs1 = '" & Trim(dr("Obs1")) & "' Where IdDocCab='" & rRastreio("CHAVE").ToString & "'"
                                    dbCelfGest.ExecuteData(Sql)

                                    'VERIFICAR SE � UMA SEPARA��O PARA A PR�PRIA CASA 'D-DEFEITOS' E SE FOI FEITO O ENVIO!!!
                                    If dr("ArmazemID").ToString = dr("TercID").ToString And dr("TipoDocID") = "SE" And Trim(dr("EstadoDoc")) = "D" Then
                                        GerarRecolha(rRastreio("CHAVE").ToString)
                                        Sql = "UPDATE DocCab SET EstadoDoc = 'R' WHERE IdDocCab='" & rRastreio("CHAVE").ToString & "'"
                                        dbCelfGest.ExecuteData(Sql)
                                    End If
                                End If
                                dr.Close()

                        End Select


                    Case "DocDet"
                        'INSERT

                        Select Case rRastreio("ACCAO").ToString

                            Case "INSERT"

                                ActualizaLigacao("Girl")
                                'Sql = "SELECT * FROM DocDet WHERE IdDocDet='" & rRastreio("CHAVE") & "'"
                                Sql = "SELECT DocDet.*, DocCab.TercID FROM DocDet INNER JOIN DocCab ON DocDet.EmpresaID = DocCab.EmpresaID AND DocDet.ArmazemID = DocCab.ArmazemID AND DocDet.TipoDocID = DocCab.TipoDocID AND DocDet.DocNr = DocCab.DocNr WHERE DocDet.IdDocDet = '" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Dim sIdDocCab As String = ""
                                    If dr("IdDocCab") Is DBNull.Value Then sIdDocCab = "Null" Else sIdDocCab = "'" & dr("IdDocCab").ToString & "'"

                                    'VERIFICAR SE � UMA SEPARA��O PARA A PR�PRIA CASA 'DEFEITOS'
                                    If dr("ArmazemID").ToString = dr("TercID").ToString And dr("TipoDocID") = "SE" Then

                                        Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, VlrIVA, Qtd, Comissao, Obs, EstadoLn, IDDocCab, IDDocDet, UtilizadorID, ProductCode, OperadorID) VALUES ('" & dr("EmpresaID") & "', '" & dr("ArmazemID") & "', '" & dr("TipoDocID") & "', '" & dr("DocNr") & "', '" & dr("DocLnNr") & "', '" & dr("SerieID") & "', '" & dr("ModeloID") & "', '" & dr("CorID") & "', '" & dr("TamID") & "', '" & dr("Descricao") & "', '" & dr("Unidade") & "', '" & dr("DocNrLnOrig") & "' ,'" & dr("Valor") & "', '" & dr("PercDescLn") & "', '" & dr("VlrDescLn") & "'  , '" & dr("IvaID") & "', '" & dr("VlrIVA") & "', '" & dr("Qtd") & "', '" & dr("Comissao") & "', '" & dr("Obs") & "', '" & dr("EstadoLn") & "'," & sIdDocCab & ",'" & dr("IDDocDet").ToString & "', '" & dr("UtilizadorID") & "', '" & dr("ProductCode") & "', '" & dr("OperadorID") & "')"
                                        dbCelfGest.ExecuteData(Sql)

                                        If dberror = False Then
                                            'NOTA O UPDATE AO ESTADO DO TALAO AQUI N�O VAI DESFAZER ISTO?? ( XPTO123456 )
                                            Sql = "UPDATE Serie SET EstadoID = 'V', PVndReal = '" & dr("Valor") & "', PrecoVenda='" & dr("Valor") & "', OperadorID = 'SEP', Vendedor = '" & dr("UtilizadorID") & "', DtSaida = CONVERT(datetime, '" & dr("DtRegisto") & "', 105) WHERE SerieID = '" & dr("SerieID") & "'"
                                            dbCelfGest.ExecuteData(Sql)
                                            If dberror = True Then 'VAI GRAVAR O EVENTO NO CELFGEST
                                                'GravarEvento("ERRO 395 AO ACTUALIZAR TAL�O PARA V", dr("SerieID") + "-" + dr("ArmazemID").ToString, Now, "EMAIL")
                                                EnviarEmail("Erro", "ERRO 395 AO ACTUALIZAR TAL�O PARA V" + " " + dr("SerieID") + " " + dr("ArmazemID").ToString + "  " + Now)
                                                dberror = False
                                            End If
                                        End If

                                    Else

                                        Sql = "INSERT INTO DocDet (EmpresaID, ArmazemID, TipoDocID, DocNr, DocLnNr, SerieID, ModeloID, CorID, TamID, Descricao, Unidade, DocNrLnOrig, Valor, PercDescLn, VlrDescLn, IvaID, VlrIVA, Qtd, Comissao, Obs, EstadoLn, IDDocCab, IDDocDet, UtilizadorID, ProductCode, OperadorID) VALUES ('" & dr("EmpresaID") & "', '" & dr("ArmazemID") & "', '" & dr("TipoDocID") & "', '" & dr("DocNr") & "', '" & dr("DocLnNr") & "', '" & dr("SerieID") & "', '" & dr("ModeloID") & "', '" & dr("CorID") & "', '" & dr("TamID") & "', '" & dr("Descricao") & "', '" & dr("Unidade") & "', '" & dr("DocNrLnOrig") & "' ,'" & dr("Valor") & "', '" & dr("PercDescLn") & "', '" & dr("VlrDescLn") & "'  , '" & dr("IvaID") & "', '" & dr("VlrIVA") & "', '" & dr("Qtd") & "', '" & dr("Comissao") & "', '" & dr("Obs") & "', '" & dr("EstadoLn") & "'," & sIdDocCab & ",'" & dr("IDDocDet").ToString & "', '" & dr("UtilizadorID") & "', '" & dr("ProductCode") & "', '" & dr("OperadorID") & "')"
                                        dbCelfGest.ExecuteData(Sql)

                                    End If

                                End If
                                dr.Close()

                            Case "DELETE"

                                ActualizaLigacao("CelfGest")
                                Sql = "DELETE DocDet Where IdDocDet='" & rRastreio("CHAVE").ToString & "'"
                                dbCelfGest.ExecuteData(Sql)

                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM DocDet WHERE IdDocDet='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)

                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    'Dim sdtSaida As String
                                    'If dr("DtSaida") Is DBNull.Value Then sdtSaida = "1900-01-01" Else sdtSaida = Format(dr("DtSaida"), "yyyy-MM-dd HH:mm:ss.fff")

                                    Sql = "UPDATE DocDet SET " & _
                                        "SerieID ='" & dr("SerieID") & _
                                        "', ModeloID ='" & dr("ModeloID") & _
                                        "', CorID ='" & dr("CorID") & _
                                        "', TamID ='" & dr("TamID") & _
                                        "', Descricao ='" & dr("Descricao") & _
                                        "', Unidade ='" & dr("Unidade") & _
                                        "', DocNrLnOrig ='" & dr("DocNrLnOrig") & _
                                        "', Valor ='" & dr("Valor") & _
                                        "', PercDescLn ='" & dr("PercDescLn") & _
                                        "', VlrDescLn ='" & dr("VlrDescLn") & _
                                        "', IvaID ='" & dr("IvaID") & _
                                        "', VlrIVA ='" & dr("VlrIVA") & _
                                        "', Qtd ='" & dr("Qtd") & _
                                        "', Obs ='" & dr("Obs") & _
                                        "', EstadoLn ='" & dr("EstadoLn") & _
                                        "', ProductCode ='" & dr("ProductCode") & _
                                        "', UtilizadorID ='" & dr("UtilizadorID") & _
                                        "', OperadorID ='" & dr("OperadorID") & _
                                        "' Where IdDocDet='" & rRastreio("CHAVE").ToString & "'"


                                    dbCelfGest.ExecuteData(Sql)

                                End If

                                dr.Close()

                        End Select


                    Case "Reservas"

                        Select Case rRastreio("ACCAO").ToString

                            Case "INSERT"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM Reservas WHERE IdReservas='" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")

                                    Dim dReservaData As String = Format(dr("ReservaData"), "yyyy-MM-dd HH:mm:ss").ToString

                                    'Format(drSerie("DtSaida"), "yyyy-MM-dd")
                                    ', '" & Format(dr("dtRegisto"), "yyyy-MM-dd HH:mm:ss").ToString & "'

                                    Dim ddtregisto As Date = FormatDateTime(dr("dtRegisto"))

                                    Dim sIdReservas As String = ""
                                    If dr("IdReservas") Is DBNull.Value Then sIdReservas = "Null" Else sIdReservas = "'" & dr("IdReservas").ToString & "'"
                                    Sql = "INSERT INTO Reservas (ReservaID, ArmazemID, ArmzDest, ReservaSerieID ,ReservaDescr ,ReservaModeloId ,ReservaCorId ,ReservaTamId ,ReservaData ,ReservaEstado ,EstadoTalao ,ReservaForn ,AuxRecEnc ,TipoReserva ,ArmazemActual ,Despesas ,SituacaoActual ,IDReservas ,OperadorID) VALUES ('" & dr("ReservaID") & "', '" & dr("ArmazemID") & "', '" & dr("ArmzDest").ToString & "', '" & dr("ReservaSerieID").ToString & "', '" & dr("ReservaDescr").ToString & "', '" & dr("ReservaModeloId").ToString & "', '" & dr("ReservaCorId").ToString & "', '" & dr("ReservaTamId").ToString & "', '" & Format(dr("ReservaData"), "yyyy-MM-dd HH:mm:ss").ToString & "', '" & dr("ReservaEstado").ToString & "', '" & dr("EstadoTalao").ToString & "', '" & dr("ReservaForn").ToString & "', '" & dr("AuxRecEnc").ToString & "', '" & dr("TipoReserva").ToString & "', '" & dr("ArmazemActual").ToString & "', '" & dr("Despesas").ToString & "', '" & dr("SituacaoActual").ToString & "', '" & dr("IDReservas").ToString & "', '" & dr("OperadorID").ToString & "')"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "DELETE"
                                ActualizaLigacao("CelfGest")
                                Sql = "DELETE Reservas Where IdReservas='" & rRastreio("CHAVE").ToString & "'"
                                dbCelfGest.ExecuteData(Sql)

                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM Reservas WHERE IdReservas='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)

                                If dr.HasRows Then
                                    dr.Read()

                                    ActualizaLigacao("CelfGest")
                                    Sql = "UPDATE Reservas SET ArmazemID = '" & dr("ArmazemID") & "', ArmzDest = '" & dr("ArmzDest").ToString & "', ReservaSerieID = '" & dr("ReservaSerieID").ToString & "', ReservaDescr = '" & dr("ReservaDescr").ToString & "', ReservaModeloId = '" & dr("ReservaModeloId").ToString & "' , ReservaCorId = '" & dr("ReservaCorId").ToString & "' ,ReservaTamId = '" & dr("ReservaTamId").ToString & "' ,ReservaData = '" & Format(dr("ReservaData"), "yyyy-MM-dd HH:mm:ss.fff") & "'  ,ReservaEstado = '" & dr("ReservaEstado").ToString & "' ,EstadoTalao = '" & dr("EstadoTalao").ToString & "' ,ReservaForn = '" & dr("ReservaForn").ToString & "' ,AuxRecEnc = '" & dr("AuxRecEnc").ToString & "' ,TipoReserva = '" & dr("TipoReserva").ToString & "' ,ArmazemActual = '" & dr("ArmazemActual").ToString & "' ,Despesas = '" & dr("Despesas").ToString & "' ,SituacaoActual = '" & dr("SituacaoActual").ToString & "' ,IDReservas = '" & dr("IDReservas").ToString & "' ,OperadorID = '" & dr("OperadorID").ToString & "' Where IdReservas='" & rRastreio("CHAVE").ToString & "'"
                                    dbCelfGest.ExecuteData(Sql)

                                End If
                                dr.Close()


                        End Select

                    Case "Armazens"    'FALTA RECTIFICAR CODIGO SQL...


                        Select Case rRastreio("ACCAO").ToString

                            Case "INSERT"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM Armazens WHERE ArmazemID='" & rRastreio("CHAVE") & "'"
                                dr = dbGirl.GetData(Sql)
                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "INSERT INTO Armazens (ArmazemID, Armazem, TercID, ArmAbrev, Endereco, CodPostal, Localidade, Telefone, NIF, TabPrecoID, Activo, ExpContador, Imprimir, UtilLog, OperadorID, DtRegisto) VALUES ('" & dr("ArmazemID") & "','" & dr("Armazem") & "','" & dr("TercID") & "','" & dr("ArmAbrev") & "','" & dr("Endereco") & "','" & dr("CodPostal") & "','" & dr("Localidade") & "','" & dr("Telefone") & "','" & dr("NIF") & "','" & dr("TabPrecoID") & "','" & dr("Activo") & "','" & dr("ExpContador") & "','" & dr("Imprimir") & "','" & dr("UtilLog") & "','" & dr("OperadorID") & "','" & dr("DtRegisto").ToString & "')"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()


                            Case "DELETE"

                                ActualizaLigacao("CelfGest")
                                Sql = "DELETE Armazens Where ArmazemID='" & rRastreio("CHAVE").ToString & "'"
                                dbCelfGest.ExecuteData(Sql)


                            Case "UPDATE"

                                ActualizaLigacao("Girl")
                                Sql = "SELECT * FROM Armazens WHERE ArmazemID='" & rRastreio("CHAVE").ToString & "'"
                                dr = dbGirl.GetData(Sql)

                                If dr.HasRows Then
                                    dr.Read()
                                    ActualizaLigacao("CelfGest")
                                    Sql = "UPDATE Armazens SET Armazem = '" & dr("Armazem") & "', TercID = '" & dr("TercID") & "', ArmAbrev = '" & dr("ArmAbrev") & "', Endereco = '" & dr("Endereco") & "', CodPostal = '" & dr("CodPostal") & "', Localidade = '" & dr("Localidade") & "', Telefone = '" & dr("Telefone") & "', NIF = '" & dr("NIF") & "', TabPrecoID = '" & dr("TabPrecoID") & "', Activo = '" & dr("Activo") & "', ExpContador = '" & dr("ExpContador") & "', Imprimir = '" & dr("Imprimir") & "', UtilLog = '" & dr("UtilLog") & "', OperadorID = '" & dr("OperadorID") & "', DtRegisto = '' Where ArmazemID ='" & rRastreio("CHAVE").ToString & "'"
                                    dbCelfGest.ExecuteData(Sql)
                                End If
                                dr.Close()

                        End Select

                End Select

                If dberror = False Then
                    ActualizaLigacao("Girl")
                    Sql = "DELETE FROM RASTREIO WHERE idRastreio='" & rRastreio("idRastreio").ToString & "'"
                    dbDelRastreio.ExecuteData(Sql)
                    If dberror = True Then
                        MsgBox("Erro N�102! Avise o Escrit�rio!")
                    End If
                    ''Else
                    '    ActualizaLigacao("CelfGest")
                    '    Sql = "INSERT INTO RastreioErros(idRastreio, TABELA, CHAVE, ACCAO, OperadorID, DtRegisto) VALUES ('" & rRastreio("idRastreio").ToString & "','" & rRastreio("TABELA") & "','" & rRastreio("CHAVE").ToString & "','" & rRastreio("ACCAO") & "','" & rRastreio("OperadorID") & "','" & rRastreio("DtRegisto") & "')"
                    '    dbCelfGest.ExecuteData(Sql)

                    '    ActualizaLigacao("Girl")
                    '    Sql = "DELETE FROM RASTREIO WHERE idRastreio='" & rRastreio("idRastreio").ToString & "'"
                    '    dbDelRastreio.ExecuteData(Sql)
                Else
                    'GravarEvento("ERRO SQL - 396 NA IMPORTA��O", , Now, "EMAIL")
                    EnviarEmail("Erro", "ERRO SQL - 396 NA IMPORTA��O" + " " + Now)
                    ActualizaLigacao("Girl")
                    Sql = "UPDATE Rastreio SET Error = 'True' WHERE idRastreio='" & rRastreio("idRastreio").ToString & "'"
                    dbDelRastreio.ExecuteData(Sql)
                End If

                ActualizaLigacao("CelfGest")


            Next


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ImportFromGirl")
        Catch ex As Exception
            ErroVB(ex.Message, "ImportFromGirl")

        Finally



            'LIBERTAR IMPORTA��O!!
            Sql = "UPDATE Empresas SET Var4 ='0' WHERE EmpresaID = '" & xEmp & "'"
            dbCelfGest.ExecuteData(Sql)


            If dberror = True Then GravarEvento("Erro N�102!!", xArmz, "00000000", "xxxx")
            If dbRastreio IsNot Nothing Then dbRastreio.Dispose()
            If dbCelfGest IsNot Nothing Then dbCelfGest.Dispose()

            If dbGirl IsNot Nothing Then dbGirl.Dispose()
            If dbDelRastreio IsNot Nothing Then dbGirl.Dispose()

            dbRastreio = Nothing
            dbCelfGest = Nothing
            dbGirl = Nothing
            dbDelRastreio = Nothing
            dr = Nothing
            dberrorAtivo = False




            ActualizaLigacao("CelfGest")

        End Try

    End Sub

    Public Sub ImpFotos(Optional ByVal sArtigo As String = "TODOS")

        Dim db As New ClsSqlBDados
        Dim dt As New DataTable

        Try



            If sArtigo = "TODOS" Then
                Sql = "SELECT ModeloId+CorId FROM ModeloCor"
                db.GetData(Sql, dt)
                For Each r As DataRow In dt.Rows
                    If Not My.Computer.FileSystem.FileExists("\\" & xServidorCelferi & "\Fotos\" + r(0) + ".jpg") Then
                        If My.Computer.FileSystem.FileExists("\\" & xServidorGirl & "\Fotos\" + r(0) + ".jpg") = True Then
                            My.Computer.FileSystem.CopyFile("\\" & xServidorGirl & "\Fotos\" + r(0) + ".jpg", "\\" & xServidorCelferi & "\Fotos\" + r(0) + ".jpg", False)
                        End If
                    End If
                Next
            Else
                If Not My.Computer.FileSystem.FileExists("\\" & xServidorCelferi & "\Fotos\" + sArtigo + ".jpg") Then
                    If My.Computer.FileSystem.FileExists("\\" & xServidorGirl & "\Fotos\" + sArtigo + ".jpg") = True Then
                        My.Computer.FileSystem.CopyFile("\\" & xServidorGirl & "\Fotos\" + sArtigo + ".jpg", "\\" & xServidorCelferi & "\Fotos\" + sArtigo + ".jpg", False)
                    End If
                End If
            End If



            'Sql = "SELECT ModeloId+CorId FROM ModeloCor"
            'db.GetData(Sql, dt)
            'For Each r As DataRow In dt.Rows
            '    If Not My.Computer.FileSystem.FileExists("C:\GIRL\FOTOS\" + r(0) + ".jpg") Then
            '        If My.Computer.FileSystem.FileExists("\\SERVIDOR\GIRL\Fotos\" + r(0) + ".jpg") = True Then
            '            My.Computer.FileSystem.CopyFile("\\SERVIDOR\GIRL\Fotos\" + r(0) + ".jpg", "C:\GIRL\Fotos\" + r(0) + ".jpg", False)
            '        End If
            '    End If
            'Next







            MsgBox("Imp Fotos OK")


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ImpFotos")
        Catch ex As Exception
            ErroVB(ex.Message, "ImpFotos")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub

    Public Sub ImpFotosRecentes()

        Dim db As New ClsSqlBDados
        Dim dt As New DataTable

        Try



            'Sql = "SELECT ModeloId+CorId FROM ModeloCor"
            Sql = "SELECT ModeloId+CorId FROM ModeloCor where DtRegisto>(SELECT GETDATE()-1)"
            db.GetData(Sql, dt)
            For Each r As DataRow In dt.Rows
                If Not My.Computer.FileSystem.FileExists("\\" & xServidorCelferi & "\Fotos\" + r(0) + ".jpg") Then
                    If My.Computer.FileSystem.FileExists("\\" & xServidorGirl & "\Fotos\" + r(0) + ".jpg") = True Then
                        My.Computer.FileSystem.CopyFile("\\" & xServidorGirl & "\Fotos\" + r(0) + ".jpg", "\\" & xServidorCelferi & "\Fotos\" + r(0) + ".jpg", False)
                    End If
                End If
            Next
            MsgBox("Imp Fotos OK")


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ImpFotosRecentes")
        Catch ex As Exception
            ErroVB(ex.Message, "ImpFotosRecentes")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Public Function Arredondamento(ByVal Numero As Double, ByVal Decimais As Double) As String
        Arredondamento = Int(Numero * 10 ^ Decimais + 1 / 2) / 10 ^ Decimais
    End Function

    Public Sub DocAnterior(ByRef sIdDoccab As String)

        Dim db As New ClsSqlBDados
        Dim dt As New DataTable
        Dim dt1 As New DataTable

        Try


            Sql = "SELECT TipoDocID, SerieDoc, NrDoc FROM DocCab where IdDocCab='" & sIdDoccab & "'"
            db.GetData(Sql, dt)

            Sql = "SELECT IdDocCab FROM DocCab WHERE TipoDocID='" & dt.Rows(0)("TipoDocID").ToString & "' and SerieDoc='" & dt.Rows(0)("SerieDoc").ToString & "' and NrDoc='" & Val(dt.Rows(0)("NrDoc")) - 1.ToString & "'"
            db.GetData(Sql, dt1)

            sIdDoccab = dt.Rows(0)("IdDocCab").ToString

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DocAnterior")
        Catch ex As Exception
            ErroVB(ex.Message, "DocAnterior")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
            dt = Nothing
            dt1 = Nothing

        End Try



    End Sub

    'Declaraci�n de la API
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    'Funcion de liberacion de memoria

    Public Sub ClearMemory()

        Try
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)
        Catch ex As Exception
            'Control de errores
        End Try

    End Sub

    Public Sub ReiniciarSpoler()

        Try



            Shell("C:\GIRL\RSPOOLER.bat", AppWinStyle.NormalFocus)


            ''EXEMPLO 1
            '' Run this specific executable on the shell.
            '' ... Specify that it is focused.
            'Shell("C:\procexp.exe", AppWinStyle.NormalFocus)

            ''EXEMPLO 2
            '' Run the 7-Zip console application to compress all txt files
            '' ... in the C:\ directory.
            'Dim id As Integer = Shell("C:\7za.exe a -t7z C:\files.7z C:\*.txt")
            'Console.WriteLine(id)


            ''EXEMPLO 3
            '' Use the notepad program to open this txt file.
            'Shell("notepad C:\file.txt", AppWinStyle.NormalFocus)


        Catch ex As Exception

            ErroVB(ex.Message, "ReiniciarSpoler")

        End Try


    End Sub

    Public Sub DesligarPC()
        'Desliga o Computador
        System.Diagnostics.Process.Start("shutdown", "-s -t 00")
    End Sub

    Public Sub ReiniciarPC()
        'Reinicia o Computador
        System.Diagnostics.Process.Start("shutdown", "-r -t 00")
    End Sub


    Private Declare Function ExitWindowsEx Lib "user32" (ByVal dwOptions As Integer, ByVal dwReserved As Integer) As Integer

    Public Sub LogoffPC()

        'TODO: falta controlar os administradores.....
        'If xUtilizador <> "FPOS" And xUtilizador <> "GUEDES" And xUtilizador <> "ISIDORO" And xUtilizador <> "RICARDO" Then
        '    If DevolveGrupoAcesso() <> "ADMIN" Then
        '        Process.Start("cmd", "/c shutdown /l /f")
        '        'System.Diagnostics.Process.Start("shutdown", "-l -t 01")
        '    End If
        'End If

        If xUtilizador <> "GUEDES" And xUtilizador <> "JGuedes" And xUtilizador <> "Guedes" Then
            'System.Diagnostics.Process.Start("shutdown", "-l -t 20") 'Log Off
            ExitWindowsEx(4, 0) 'also you can use ExitWindowsEx (4, 0) to force processes to terminate while logging-off  
        End If
        Application.Exit()

        'ExitWindowsEx(1, 0) 'The turn-off button  
        'ExitWindowsEx(2, 0)  'The restart button  
        'Application.SetSuspendState(PowerState.Suspend, True, True)  'The stand-by button  



    End Sub

    Public Function Encriptar(ByVal Input As String) As String


        Try


            Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("qualityi") 'La clave debe ser de 8 caracteres  
            Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave  
            Dim buffer() As Byte = Encoding.UTF8.GetBytes(Input)
            Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            des.Key = EncryptionKey
            des.IV = IV

            Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))


        Catch ex As Exception
            ErroVB(ex.Message, "Encriptar")
        End Try


    End Function

    Public Function Desencriptar(ByVal Input As String) As String

        Try

            Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("qualityi") 'La clave debe ser de 8 caracteres  
            Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave  
            Dim buffer() As Byte = Convert.FromBase64String(Input)
            Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            des.Key = EncryptionKey
            des.IV = IV
            Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))


        Catch ex As Exception
            ErroVB(ex.Message, "Desencriptar")
        End Try


    End Function

    Public Sub Limpiar_TextBox(ByVal formulario As Form)

        'Recorremos todos los controles del formulario que enviamos    
        For Each control As Control In formulario.Controls

            'Filtramos solo aquellos de tipo TextBox   
            If TypeOf control Is TextBox Then
                control.Text = "" ' eliminar el texto    
            End If
        Next

    End Sub

    Public Function DataArq(ByVal sArq As String) As Object
        If Dir$(sArq) <> "" Then
            DataArq = FileDateTime(sArq)
        Else
            DataArq = "ERRO"
        End If
    End Function

    Public Function IsValidZip(ByRef value As String) As Boolean

        'Dim myRegex As New Regex("^\d{4}([\-]\d{3})?$")
        Dim myRegex As New Regex("\d{4}[\-]")

        Return myRegex.IsMatch(value)

    End Function

    Public Sub EnviarEmail(Optional ByRef sSubject As String = "", Optional ByRef sBody As String = "", Optional ByRef sAttachments As String = "")

        Try

            Dim Mail As New MailMessage
            Mail.Subject = sSubject
            Mail.To.Add("josemanuelguedes@gmail.com")
            Mail.From = New MailAddress("josemanuelguedes@gmail.com")
            Mail.Body = sBody
            'Mail.Attachments.Add(New Attachment("sAttachments"))

            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("josemanuelguedes@gmail.com", "14.Af.13")
            SMTP.Port = "587"
            SMTP.Send(Mail)



        Catch ex As Exception

        End Try

    End Sub

    Public Sub RECarregarTalao(ByRef sTalao As String)

        'VAI REPOR O TAL�O NO SERVIDOR!!

        Dim dbCelfGest As New ClsSqlBDados
        Dim dbGirl As New ClsSqlBDados
        Dim dtTalao As New DataTable
        dberrorAtivo = True

        Try

            Sql = "SELECT * FROM Serie Where SerieId='" & sTalao & "'"
            dbCelfGest.GetData(Sql, dtTalao)

            ActualizaLigacao("Girl")
            For Each r As DataRow In dtTalao.Rows

                If r("EstadoID").ToString <> "S" Then
                    'GravarEvento("ERRO 256 AO EXPORTAR O TAL�O", "", Now, "EMAIL")
                    EnviarEmail("Erro", "ERRO 256 AO EXPORTAR O TAL�O " + Now)
                    If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")
                    Exit Sub
                End If


                Dim strData As New StringBuilder

                Sql = "BEGIN TRANSACTION"
                strData.AppendLine(Sql)

                'ENQUANTO N�O APAGAR OS TAL�ES EM ESTADO P TENHO QUE TER ESTE COMANDO!!
                Sql = "DELETE FROM SERIE WHERE SERIEID='" & sTalao & "' AND ESTADOID='P';"
                strData.AppendLine(Sql)

                Dim dEntrada As String
                If r("DtEntrada") Is DBNull.Value Then dEntrada = "1900-01-01" Else dEntrada = Format(r("DtEntrada"), "yyyy-MM-dd HH:mm:ss.fff")

                Sql = "INSERT INTO Serie (SerieID ,ModeloID, CorID ,TamID ,ArmazemID ,PrecoEtiqueta ,PrecoVenda ,Comissao ,NrEnc ,DtEntrada ,DocNr ,PVndReal ,DtSaida ,Obs ,Obs1 ,EstadoID ,Rp ,Vendedor, ProductCode, OperadorID ,DtRegisto) " & _
                "VALUES ('" & r("SerieID").ToString & "','" & r("ModeloID").ToString & "', '" & r("CorID").ToString & "','" & r("TamID").ToString & "','" & r("ArmazemID").ToString & "','" & r("PrecoEtiqueta").ToString & "','" & r("PrecoVenda").ToString & "','" & r("Comissao").ToString & "','" & r("NrEnc").ToString & "','" & dEntrada & "','" & r("DocNr").ToString & "','" & r("PVndReal").ToString & "','" & CDate(r("DtSaida")).ToString("s") & "','" & r("Obs").ToString & "','" & r("Obs1").ToString & "','" & r("EstadoID").ToString & "','" & r("Rp").ToString & "','" & r("Vendedor").ToString & "','" & r("ProductCode").ToString & "', '" & r("OperadorID").ToString & "','" & CDate(r("DtRegisto")).ToString("s") & "');"
                strData.AppendLine(Sql)

                Sql = "COMMIT TRANSACTION;"
                strData.AppendLine(Sql)
                Sql = strData.ToString
                dbGirl.ExecuteData(Sql)

                If dberror = True Then
                    'GravarEvento("ERRO NA GRAVA��O DA EXPORTA��O! 666", "", Now, "EMAIL")
                    EnviarEmail("Erro", "ERRO NA GRAVA��O DA EXPORTA��O! 666 " + Now)
                    MsgBox("N�O FOI POSSIVEL EXPORTAR O TAL�O", MsgBoxStyle.Information)
                End If



            Next

            If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")



        Catch ex As Exception
            ErroVB(ex.Message, "CarregarTalao")
        Finally

            dberrorAtivo = False
            If dbCelfGest IsNot Nothing Then dbCelfGest.Dispose()
            If dbGirl IsNot Nothing Then dbGirl.Dispose()
            dbCelfGest = Nothing
            dbGirl = Nothing
            dr = Nothing
            If sAplicacao = "CELFGEST" Then ActualizaLigacao("CelfGest")
        End Try

    End Sub

    Public Sub ExportFichasToGirl() 'N�O USADO

        Dim dbRastreio As New ClsSqlBDados
        Dim dbCelfGest As New ClsSqlBDados
        Dim dbGirl As New ClsSqlBDados
        Dim dbDelRastreio As New ClsSqlBDados


        Dim Tabela As String = ""
        Dim drCelfGest As SqlDataReader
        Dim drModelos As SqlDataReader
        Dim drModeloCor As SqlDataReader
        Dim drSerie As SqlDataReader


        Try



            'Sql = "SELECT idRastreio, TABELA, CHAVE, ACCAO, OperadorID, DtRegisto FROM Rastreio WHERE DtRegisto = (SELECT MIN(DtRegisto) AS MinDtRegisto FROM Rastreio)"
            Sql = "SELECT idRastreio, TABELA, CHAVE, ACCAO, OperadorID, DtRegisto FROM Rastreio order by DtRegisto Asc"
            drCelfGest = dbRastreio.GetData(Sql)

            While drCelfGest.Read()

                If drCelfGest("ACCAO") = "INSERT" Then
                    Tabela = drCelfGest("TABELA")


                    Select Case Tabela

                        Case "Modelos"
                            Sql = "SELECT * FROM MODELOS WHERE MODELOID=" & drCelfGest("CHAVE")
                            drModelos = dbCelfGest.GetData(Sql)
                            If drModelos.HasRows Then
                                drModelos.Read()
                                ActualizaLigacao("Girl")
                                'sConnectionString = sConnectionStringGirl
                                Sql = "INSERT INTO Modelos (ModeloID, GrupoID, TipoID, Altura, EpocaID, LinhaID, UnidId, EscalaId, OperadorID) VALUES ('" & drModelos("ModeloID") & "', '" & drModelos("GrupoId") & "', '" & drModelos("TipoID") & "', '" & drModelos("Altura") & "', '" & drModelos("EpocaId") & "', '" & drModelos("LinhaID") & "', '" & drModelos("UnidId") & "', '" & drModelos("EscalaId") & "', '" & drModelos("OperadorID") & "') "
                                dbGirl.ExecuteData(Sql)
                                drModelos.Close()
                            End If

                        Case "ModeloCor"
                            Sql = "SELECT * FROM MODELOCOR WHERE IDMODELOCOR='" & drCelfGest("CHAVE").ToString & "'"
                            drModeloCor = dbCelfGest.GetData(Sql)
                            If drModeloCor.HasRows Then
                                drModeloCor.Read()
                                ActualizaLigacao("Girl")
                                'sConnectionString = sConnectionStringGirl
                                Sql = "INSERT INTO ModeloCor (ModeloID, CorID, ModCorDescr, FornId, RefForn, CorForn, PrCusto, PrVnd, OperadorID) VALUES ('" & drModeloCor("ModeloID") & "', '" & drModeloCor("CorID") & "', '" & drModeloCor("ModCorDescr") & "', '" & DBNull.Value & "', '" & DBNull.Value & "', '" & drModeloCor("CorForn") & "', " & drModeloCor("PrCusto") & ", " & drModeloCor("PrVnd") & ", '" & drModeloCor("OperadorID") & "') "
                                dbGirl.ExecuteData(Sql)
                                drModeloCor.Close()
                            End If

                        Case "Serie"
                            Sql = "SELECT * FROM SERIE WHERE SERIEID=" & drCelfGest("CHAVE")
                            drSerie = dbCelfGest.GetData(Sql)

                            If drSerie.HasRows Then
                                drSerie.Read()
                                ActualizaLigacao("Girl")
                                'sConnectionString = sConnectionStringGirl
                                Sql = "INSERT INTO  Serie (SerieID, ModeloID, CorID, TamID, ArmazemID, PrecoEtiqueta, PrecoVenda, NrEnc, DtSaida, EstadoID, OperadorID ) VALUES ('" & drSerie("SerieID") & "', '" & drSerie("ModeloID") & "', '" & drSerie("CorID") & "', '" & drSerie("TamID") & "', '" & drSerie("ArmazemID") & "', " & Format(drSerie("PrecoEtiqueta"), "#,##0.00") & ", " & Format(drSerie("PrecoEtiqueta"), "#,##0.00") & ", '', '" & Format(drSerie("DtSaida"), "yyyy-MM-dd") & "', '" & drSerie("EstadoID") & "', '" & drSerie("OperadorID") & "')"
                                dbGirl.ExecuteData(Sql)
                                drSerie.Close()
                            End If

                    End Select

                    ActualizaLigacao("CelfGest")
                    'sConnectionString = sConnectionStringCelfGest
                    Sql = "DELETE FROM RASTREIO WHERE idRastreio='" & drCelfGest("idRastreio").ToString & "'"
                    dbDelRastreio.ExecuteData(Sql)

                End If

            End While
            drCelfGest.Close()

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ExportaTaloes")
        Catch ex As Exception
            ErroVB(ex.Message, "ExportaTaloes")

        Finally

            If dbRastreio IsNot Nothing Then dbRastreio.Dispose()
            If dbCelfGest IsNot Nothing Then dbCelfGest.Dispose()
            If dbGirl IsNot Nothing Then dbGirl.Dispose()
            If dbDelRastreio IsNot Nothing Then dbGirl.Dispose()

            dbRastreio = Nothing
            dbCelfGest = Nothing
            dbGirl = Nothing
            dbDelRastreio = Nothing

        End Try

    End Sub

    Public Sub ExportToWeb()

        'Dim cnCelferiLojaOnLine As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\GIRL\CelferiLojaOnLine.accdb; Persist Security Info=False;")
        Dim cnCelferiLojaOnLine As New OleDbConnection("Provider =Microsoft.Jet.OLEDB.4.0;Data Source=C:\GIRL\CelferiLojaOnLine.mdb")

        Dim db As New ClsSqlBDados
        Dim dtGirl As New DataTable
        Dim dtCelferiLojaOnLine As New DataTable
        Dim UltimoSerieExportar As String
        Dim dtGirlTamanhos As New DataTable



        'Dim daCelferiLojaOnLine As New OleDbDataAdapter()
        Dim cmd As New OleDb.OleDbCommand

        Try


            'Sql = "SELECT 'CELFERI' AS EMPRESA, ModeloCor.ModeloID + ModeloCor.CorID AS ARTIGOID, ModeloCor.ModCorDescr AS DESCR1, Grupos.GrupoDesc AS DESCR2, Tipos.DescrTipo AS DESCR3, 'CELFERI' AS DESCR4, 'Altura do Salto: ' + Modelos.Altura AS DESCR5, 'Unidade: ' + Unidades.UnidDescr AS DESCR6, 'Epoca: ' + Modelos.EpocaID AS DESCR7, Cores.DescrCor AS DESCR8, ISNULL(Tipos.Categories_id,'00') AS DESCR9, ModeloCor.PrVnd AS PVP1, 0 AS Qtd1, 0 AS PVP2, MAX(Serie.SerieID) AS MAXSERIE FROM ModeloCor INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID INNER JOIN Tipos ON Modelos.TipoID = Tipos.TipoId INNER JOIN Grupos ON Modelos.GrupoID = Grupos.GrupoID INNER JOIN Unidades ON Modelos.UnidID = Unidades.UnidID INNER JOIN Cores ON ModeloCor.CorID = Cores.CorID INNER JOIN Serie ON ModeloCor.ModeloID = Serie.ModeloID AND ModeloCor.CorID = Serie.CorID WHERE (Serie.SerieID >= (SELECT MAX(SerieID) AS Expr1 FROM ExportaWeb)) GROUP BY ModeloCor.ModeloID + ModeloCor.CorID, ModeloCor.ModCorDescr, Grupos.GrupoDesc, Tipos.DescrTipo, 'Altura do Salto: ' + Modelos.Altura, 'Unidade: ' + Unidades.UnidDescr, 'Epoca: ' + Modelos.EpocaID, Cores.DescrCor, Tipos.Categories_id, ModeloCor.PrVnd"
            Sql = "SELECT 'CELFERI' AS EMPRESA, ModeloCor.ModeloID + ModeloCor.CorID AS ARTIGOID, ModeloCor.ModCorDescr AS DESCR1, Grupos.GrupoDesc AS DESCR2, Tipos.DescrTipo AS DESCR3, 'CELFERI' AS DESCR4, 'Altura do Salto: ' + Modelos.Altura AS DESCR5, 'Unidade: ' + Unidades.UnidDescr AS DESCR6, 'Epoca: ' + Modelos.EpocaID AS DESCR7, Cores.DescrCor AS DESCR8, ISNULL(Tipos.Categories_id,'00') AS DESCR9, ModeloCor.PrVnd AS PVP1, 0 AS Qtd1, 0 AS PVP2, MAX(Serie.SerieID) AS MAXSERIE, ModeloCor.ModeloID, ModeloCor.CorID FROM ModeloCor INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID INNER JOIN Tipos ON Modelos.TipoID = Tipos.TipoId INNER JOIN Grupos ON Modelos.GrupoID = Grupos.GrupoID INNER JOIN Unidades ON Modelos.UnidID = Unidades.UnidID INNER JOIN Cores ON ModeloCor.CorID = Cores.CorID INNER JOIN Serie ON ModeloCor.ModeloID = Serie.ModeloID AND ModeloCor.CorID = Serie.CorID WHERE (Serie.SerieID >= (SELECT MAX(SerieID) AS Expr1 FROM ExportaWeb)) GROUP BY ModeloCor.ModeloID + ModeloCor.CorID, ModeloCor.ModCorDescr, Grupos.GrupoDesc, Tipos.DescrTipo, 'Altura do Salto: ' + Modelos.Altura, 'Unidade: ' + Unidades.UnidDescr, 'Epoca: ' + Modelos.EpocaID, Cores.DescrCor, Tipos.Categories_id, ModeloCor.PrVnd, ModeloCor.ModeloID, ModeloCor.CorID"

            db.GetData(Sql, dtGirl)

            UltimoSerieExportar = dtGirl.Compute("MAX(MAXSERIE)", "")

            If cnCelferiLojaOnLine.State = ConnectionState.Closed Then cnCelferiLojaOnLine.Open()
            cmd.Connection = cnCelferiLojaOnLine
            'daCelferiLojaOnLine.SelectCommand = New OleDbCommand(Sql, cnCelferiLojaOnLine)


            For Each r As DataRow In dtGirl.Rows
                cmd.CommandText = "SELECT COUNT(ARTIGOID) FROM ARTIGOSWEB WHERE ARTIGOID='" & r("ArtigoID") & "'"
                If cmd.ExecuteScalar() = 0 Then
                    cmd.CommandText = "INSERT INTO ArtigosWeb (Empresa, ArtigoID, Descr1, Descr2, Descr3, Descr4, Descr5, Descr6, Descr7, Descr8, Descr9, PVP1, Qtd1, PVP2 )" & _
                    " VALUES ('" & r("EMPRESA") & "','" & r("ArtigoID") & "','" & r("Descr1") & "','" & r("Descr2") & "','" & r("Descr3") & "','" & r("Descr4") & "','" & r("Descr5") & "','" & r("Descr6") & "','" & r("Descr7") & "','" & r("Descr8") & "','" & r("Descr9") & "'," & r("PVP1") & "," & r("Qtd1") & "," & r("PVP2") & ")"
                    cmd.ExecuteNonQuery()

                    dtGirlTamanhos.Clear()
                    Sql = "SELECT ModeloID + CorID AS ARTIGOID, TamID, SUM(1) AS QTD FROM Serie WHERE (EstadoID IN ('T', 'S', 'R', 'V')) GROUP BY ModeloID, CorID, TamID HAVING (ModeloID='" & r("ModeloID") & "' and CorID='" & r("CorID") & "') ORDER BY ModeloID, CorID"
                    db.GetData(Sql, dtGirlTamanhos)
                    For Each rt As DataRow In dtGirlTamanhos.Rows
                        cmd.CommandText = "INSERT INTO ArtigosTamanhosComprados (Empresa, ArtigoID, TamanhoComprado, StockActual)" & _
                                        " VALUES ('CELFERI','" & rt("ArtigoID") & "','" & rt("TamID") & "'," & rt("QTD") & ")"
                        cmd.ExecuteNonQuery()
                    Next


                End If
            Next

            Sql = "UPDATE ExportaWeb SET SerieID = N'" & UltimoSerieExportar & "'"
            db.ExecuteData(Sql)


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ExportToWeb")
        Catch ex As Exception
            ErroVB(ex.Message, "ExportToWeb")

        Finally

            cnCelferiLojaOnLine.Close()

        End Try


    End Sub

    Public Sub AtualizarQtdWeb()


    End Sub

    Public Sub FTPExport()

        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.drivehq.com/file.txt"), System.Net.FtpWebRequest)
        request.Credentials = New System.Net.NetworkCredential("user", "password")
        request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

        Dim file() As Byte = System.IO.File.ReadAllBytes("c:\file.txt")

        Dim strz As System.IO.Stream = request.GetRequestStream()
        strz.Write(file, 0, file.Length)
        strz.Close()
        strz.Dispose()


    End Sub

    Public Function LerTXT(ByVal xValor As String) As String

        Dim FILE_NAME As String = "C:\GIRL\Config.txt"
        Dim xValorAux As String
        Dim iValorAux As Integer

        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objReader As New System.IO.StreamReader(FILE_NAME)
            Do While objReader.Peek() <> -1
                xValorAux = objReader.ReadLine()
                If xValorAux.Substring(0, xValorAux.IndexOf(":")) = xValor Then
                    iValorAux = xValorAux.Substring(0, xValorAux.IndexOf(":")).Length + 1
                    Return xValorAux.Substring(iValorAux, xValorAux.Length - iValorAux)
                End If
            Loop
        Else
            MsgBox("Falta Ficheiro de Config.txt em C:\Girl")
        End If
        Return ""

        'C�DIGO ORIGINAL
        'Dim FILE_NAME As String = "C:\Users\Owner\Documents\test.txt"

        'Dim TextLine As String

        'If System.IO.File.Exists(FILE_NAME) = True Then

        '    Dim objReader As New System.IO.StreamReader(FILE_NAME)

        '    Do While objReader.Peek() <> -1

        '        TextLine = TextLine & objReader.ReadLine() & vbNewLine

        '    Loop

        '    Textbox1.Text = TextLine

        'Else

        '    MsgBox("File Does Not Exist")

        'End If


    End Function

    Public Function DevolveProductCode(ByVal sModelo As String) As String

        Dim db As New ClsSqlBDados


        Try

            Sql = "SELECT Tipos.PID FROM Modelos INNER JOIN Tipos ON Modelos.TipoID = Tipos.TipoId WHERE (Modelos.ModeloID = '" & sModelo & "')"
            Return db.GetDataValue(Sql)

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "DevolveProductCode")
        Catch ex As Exception
            ErroVB(ex.Message, "DevolveProductCode")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Function

    Public Sub UploadFile(ByVal _FileName As String, ByVal _UploadPath As String, ByVal _FTPUser As String, ByVal _FTPPass As String)



        Dim _FileInfo As New System.IO.FileInfo(_FileName)

        ' Create FtpWebRequest object from the Uri provided
        Dim _FtpWebRequest As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(New Uri(_UploadPath)), System.Net.FtpWebRequest)

        ' Provide the WebPermission Credintials
        _FtpWebRequest.Credentials = New System.Net.NetworkCredential(_FTPUser, _FTPPass)

        ' By default KeepAlive is true, where the control connection is not closed
        ' after a command is executed.
        _FtpWebRequest.KeepAlive = False

        ' set timeout for 20 seconds
        _FtpWebRequest.Timeout = 20000

        ' Specify the command to be executed.
        _FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

        ' Specify the data transfer type.
        _FtpWebRequest.UseBinary = True

        ' Notify the server about the size of the uploaded file
        _FtpWebRequest.ContentLength = _FileInfo.Length

        ' The buffer size is set to 2kb
        Dim buffLength As Integer = 2048
        Dim buff(buffLength - 1) As Byte

        ' Opens a file stream (System.IO.FileStream) to read the file to be uploaded
        Dim _FileStream As System.IO.FileStream = _FileInfo.OpenRead()

        Try
            ' Stream to which the file to be upload is written
            Dim _Stream As System.IO.Stream = _FtpWebRequest.GetRequestStream()

            ' Read from the file stream 2kb at a time
            Dim contentLen As Integer = _FileStream.Read(buff, 0, buffLength)

            ' Till Stream content ends
            Do While contentLen <> 0
                ' Write Content from the file stream to the FTP Upload Stream
                _Stream.Write(buff, 0, contentLen)
                contentLen = _FileStream.Read(buff, 0, buffLength)
            Loop

            ' Close the file stream and the Request Stream
            _Stream.Close()
            _Stream.Dispose()
            _FileStream.Close()
            _FileStream.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub DeleteFile(ByVal _DeletePath As String, ByVal _FTPUser As String, ByVal _FTPPass As String)


        ' Create FtpWebRequest object from the Uri provided
        Dim _FtpWebRequest As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(New Uri(_DeletePath)), System.Net.FtpWebRequest)

        ' Provide the WebPermission Credintials
        _FtpWebRequest.Credentials = New System.Net.NetworkCredential(_FTPUser, _FTPPass)

        ' By default KeepAlive is true, where the control connection is not closed
        ' after a command is executed.
        _FtpWebRequest.KeepAlive = False

        ' set timeout for 20 seconds
        _FtpWebRequest.Timeout = 20000

        ' Specify the command to be executed.
        _FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.DeleteFile

        ' Specify the data transfer type.
        _FtpWebRequest.UseBinary = True

        ' The buffer size is set to 2kb
        Dim buffLength As Integer = 2048
        Dim buff(buffLength - 1) As Byte

        Try

            Dim FTPDelResp As FtpWebResponse = _FtpWebRequest.GetResponse

            ' Close the file stream and the Request Stream
            FTPDelResp.Close()



        Catch ex As Exception

            'MessageBox.Show(ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub ExportaWeb()

        'TODO: IR BUSCAR OS PRE�OS DAS "PROMO��ES" � TABELA 2
        'TODO: CRIAR GRUPO PROMO��ES!! E CARREGAR PARA L� ESTES MODELOS
        'TODO: NA ADICIONAR OS ARTIGOS �S CATEGORIAS PRINCIPAIS...
        'TODO: AO EXPORTAR VERIFICAR SE J� L� EST�. SE SIM, N�O EXPORTA.....

        Dim db As New ClsSqlBDados
        Dim dtArtigosExportar As New DataTable
        Dim dtCategorias As New DataTable
        Dim iMarca As Integer
        Dim iQtdArtigos As Integer
        Dim iContador As Integer = 0
        Dim dtProdutosWeb As New DataTable



        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable
        Dim SQL As String




        'Dim cnString As String = "server=celferi.com;user id=celficom;password=cel!23co;database=celficom_ocloja"
        'Dim cnString As String = "server=celferi.com;user id=celficom_ocloja;password=celficom;database=celficom_ocloja"
        Dim cnString As String = "server=celferi.com;user id=celficom_girl;password=(m0,1(vF%h8@;database=celficom_ocloja"





        Try

            Dim sAnoExport As String = "14" 'ANO A PARTIR DO QUAL VOU EXPORTAR....
            'TODO ENCONTRAR UMA FORMA DE LIMITAR A QTD DE ARTIGOS A PASSAR, PERMITIR CANCELAR!!!!
            'SQL = "SELECT TABMC.EpocaID, TABMC.GrupoID, TABMC.TipoID, TABMC.ModeloID, TABMC.CorID, TABMC.ModCorDescr, TABMC.PEtiq, TABSERIE.PVP, TABMC.Web, TABMC.PictogramaID, TABMC.PID, TABMC.PIDDESCR, TABMC.IdModeloCor, TABSERIE.Qtd, TABMC.NomeAbrev FROM (SELECT Modelos.EpocaID, Modelos.GrupoID, Modelos.TipoID, ModeloCor.ModeloID, ModeloCor.CorID, ModeloCor.ModCorDescr, ModeloCor.PrVnd AS PEtiq, ModeloCor.Web, ModeloCor.PictogramaID, Tipos.PID, Tipos.PIDDESCR, ModeloCor.IdModeloCor, Terceiros.NomeAbrev FROM ModeloCor INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID INNER JOIN Tipos ON Modelos.TipoID = Tipos.TipoId INNER JOIN Terceiros ON ModeloCor.FornID = Terceiros.TercID) AS TABMC INNER JOIN (SELECT ModeloID, CorID, SUM(1) AS Qtd, MIN(PrecoVenda) AS PVP FROM Serie WHERE (EstadoID IN ('S', 'T')) GROUP BY ModeloID, CorID) AS TABSERIE ON TABMC.ModeloID = TABSERIE.ModeloID AND TABMC.CorID = TABSERIE.CorID WHERE (TABSERIE.Qtd > 0) AND (NOT (TABMC.GrupoID IN ('4', '6'))) AND (TABMC.Web = 0) ORDER BY TABMC.EpocaID DESC "
            'SQL = "SELECT TABMC.EpocaID, TABMC.GrupoID, TABMC.TipoID, TABMC.ModeloID, TABMC.CorID, TABMC.ModCorDescr, TABMC.PEtiq, TABSERIE.PVP, TABMC.Web, TABMC.PictogramaID, TABMC.PID, TABMC.PIDDESCR, TABMC.IdModeloCor, TABSERIE.Qtd, TABMC.NomeAbrev FROM (SELECT Modelos.EpocaID, Modelos.GrupoID, Modelos.TipoID, ModeloCor.ModeloID, ModeloCor.CorID, ModeloCor.ModCorDescr, ModeloCor.PrVnd AS PEtiq, ModeloCor.Web, ModeloCor.PictogramaID, Tipos.PID, Tipos.PIDDESCR, ModeloCor.IdModeloCor, Terceiros.NomeAbrev FROM ModeloCor INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID INNER JOIN Tipos ON Modelos.TipoID = Tipos.TipoId INNER JOIN Terceiros ON ModeloCor.FornID = Terceiros.TercID) AS TABMC INNER JOIN (SELECT ModeloID, CorID, SUM(1) AS Qtd, PrecoEtiqueta AS PVP FROM Serie WHERE (EstadoID IN ('S', 'T')) AND (LEFT(SerieID, 2) > '" & sAnoExport & "') GROUP BY ModeloID, CorID, PrecoEtiqueta) AS TABSERIE ON TABMC.ModeloID = TABSERIE.ModeloID AND TABMC.CorID = TABSERIE.CorID WHERE (TABSERIE.Qtd > 0) AND (NOT (TABMC.GrupoID IN ('4', '6'))) AND (TABMC.Web = 0) ORDER BY TABMC.EpocaID DESC"
            Sql = "SELECT TABMC.EpocaID, TABMC.GrupoID, TABMC.TipoID, TABMC.ModeloID, TABMC.CorID, TABMC.ModCorDescr, TABMC.PEtiq, TABMC.Web, TABMC.PictogramaID, TABMC.PID, TABMC.PIDDESCR, TABMC.IdModeloCor, TABSERIE.Qtd, TABMC.NomeAbrev FROM (SELECT Modelos.EpocaID, Modelos.GrupoID, Modelos.TipoID, ModeloCor.ModeloID, ModeloCor.CorID, ModeloCor.ModCorDescr, ModeloCor.PrVnd AS PEtiq, ModeloCor.Web, ModeloCor.PictogramaID, Tipos.PID, Tipos.PIDDESCR, ModeloCor.IdModeloCor, Terceiros.NomeAbrev FROM ModeloCor INNER JOIN Modelos ON ModeloCor.ModeloID = Modelos.ModeloID INNER JOIN Tipos ON Modelos.TipoID = Tipos.TipoId INNER JOIN Terceiros ON ModeloCor.FornID = Terceiros.TercID) AS TABMC INNER JOIN (SELECT ModeloID, CorID, SUM(1) AS Qtd FROM Serie WHERE (EstadoID IN ('S', 'T')) AND (LEFT(SerieID, 2) >= '" & sAnoExport & "') GROUP BY ModeloID, CorID) AS TABSERIE ON TABMC.ModeloID = TABSERIE.ModeloID AND TABMC.CorID = TABSERIE.CorID WHERE (TABSERIE.Qtd > 0) AND (NOT (TABMC.GrupoID IN ('4', '6'))) AND (TABMC.Web = 0) ORDER BY TABMC.EpocaID DESC"


            db.GetData(Sql, dtArtigosExportar)

            iQtdArtigos = dtArtigosExportar.Rows.Count

            'conn = New MySql.Data.MySqlClient.MySqlConnection
            conn.ConnectionString = cnString

            Sql = "SELECT category_id FROM celficom_ocloja.oc_category"
            If conn.State = ConnectionState.Closed Then conn.Open()
            myCommand.Connection = conn
            myCommand.CommandText = Sql
            myAdapter.SelectCommand = myCommand
            myAdapter.FillSchema(dtCategorias, SchemaType.Source)
            myAdapter.Fill(dtCategorias)


            Sql = "SELECT model FROM celficom_ocloja.oc_product"
            If conn.State = ConnectionState.Closed Then conn.Open()
            myCommand.Connection = conn
            myCommand.CommandText = Sql
            myAdapter.SelectCommand = myCommand
            myAdapter.FillSchema(dtProdutosWeb, SchemaType.Source)
            myAdapter.Fill(dtProdutosWeb)




            Dim sModel As String
            Dim sProduct_id As Integer
            Dim sData As DateTime = DateTime.Now.ToString("yyyy-MM-dd")
            Dim sPID As String
            Dim dPVP As Double



            Dim strData As New StringBuilder


            For Each r As DataRow In dtArtigosExportar.Rows

                sModel = r("ModeloID") & r("CorID")
                sProduct_id = sModel
                sPID = r("PID")

                If dtProdutosWeb.Compute("Count(model)", "model=" & sModel & "") = 0 Then

                    'ARTIGO AINDA N�O EST� NA WEB!

                    If dtCategorias.Compute("Count(category_id)", "category_id=" & sPID & "") = 0 Then
                        MsgBox("A Categoria : " & sPID & " n�o est� Criada! Exporta��o Suspensa!")
                        Exit Sub
                    End If

                    'xFotosPath = "\\25.96.178.140\Girl\Fotos\"
                    'xFotosPath = "\\PCPOSTO2\Girl\Fotos\"


                    If My.Computer.FileSystem.FileExists(xFotosPath + sModel + ".JPG") Then


                        UploadFile(xFotosPath + sModel + ".JPG", "ftp://ftp.celferi.com/public_html/loja/image/catalog/product/" + sModel + ".JPG", "celficom", "cel!23co")

                        'My.Computer.FileSystem.CopyFile(xFotosPath + r("ModeloID") & r("CorID") + ".JPG", "C:\Girl\FotosWeb\" + r("ModeloID") & r("CorID") + ".JPG", True)


                        'TODO: PASSAR O IVA A DIN�MICO
                        dPVP = r("PEtiq") / 1.23
                        'dPVPPromo = r("PVP") / 1.23


                        Sql = "SELECT manufacturer_id FROM celficom_ocloja.oc_manufacturer where name = '" & r("NomeAbrev") & "'"
                        If conn.State = ConnectionState.Closed Then conn.Open()
                        myCommand.CommandText = Sql
                        iMarca = myCommand.ExecuteScalar()

                        If iMarca = 0 Then iMarca = 8

                        'INSERIR VALORES NA TABELA PRODUCT!!
                        Sql = "INSERT INTO oc_product ( product_id, model, quantity, stock_status_id, image, manufacturer_id, shipping, price, points, tax_class_id, date_available, weight, weight_class_id, length, width, height, length_class_id, subtract, minimum, sort_order, status, date_added ) " &
                            "SELECT '" & sProduct_id & "', '" & sModel & "', '" & r("Qtd") & "', 5, 'catalog/product/" & sModel & ".JPG', " & iMarca & " , 1 ,  " & dPVP & ", 0, 9, '2015-09-28 00:00:00', 0, 1, 0, 0, 0, 1, 1, 1, " & 9999999 - sProduct_id & ", 1, '2015-09-28 00:00:00';"
                        strData.AppendLine(Sql)

                        Sql = "INSERT INTO oc_product_description (product_id, language_id, name, description, tag, meta_title, meta_description, meta_keyword) " &
                            "VALUES ('" & sProduct_id & "', '2', '" & sModel & "', '" & r("ModCorDescr") & "', 'tag', 'meta_title', 'meta_description', 'meta_keyword');"
                        strData.AppendLine(Sql)

                        Sql = "INSERT INTO oc_product_to_category (product_id, category_id) VALUES ('" & sProduct_id & "', '" & sPID & "');"
                        strData.AppendLine(Sql)

                        Sql = "INSERT INTO oc_product_to_store (product_id, store_id) VALUES ('" & sProduct_id & "', '0');"
                        strData.AppendLine(Sql)

                        Sql = "INSERT INTO oc_product_to_layout (product_id, store_id, layout_id) VALUES ('" & sProduct_id & "', '0', '0');"
                        strData.AppendLine(Sql)

                        Sql = "INSERT INTO oc_product_option (product_option_id, product_id, option_id, value, required) VALUES ('" & sProduct_id & "', '" & sProduct_id & "', '20', '', '1');"
                        strData.AppendLine(Sql)

                        myCommand.CommandText = strData.ToString
                        myCommand.ExecuteNonQuery()

                        strData.Clear()

                        'ActualizaPVPWeb(sModel)
                        'ActualizaTamWeb(sModel)

                        SQL = "UPDATE ModeloCor SET Web = 1 WHERE IdModeloCor = '" & r("IdModeloCor").ToString & "'"
                        db.ExecuteData(Sql)
                        iContador += 1




                    Else
                        'N�O TEM FOTO N�O EXPORTA
                    End If
                End If

            Next

            MsgBox(iContador.ToString + " Artigos Exportados para a web!")
            'TODO: CARREGAR AQUI UMA ROTINA PARA ACTUALIZAR STOCKS, PRE�OS DE VENDA E DE SALDO!!!




        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub LimparFotos()


        Dim db As New ClsSqlBDados
        Dim dtLimparModelosCor As New DataTable
        Dim sFotosServer As String = "\\" & xServidor & "\Fotos\"
        Dim PhotosCount As Integer = 0
        Dim folderExists As Boolean
        Dim fileExists As Boolean

        Try


            'Carregar Tabela com ModelosCor para eliminar fotos
            Sql = "SELECT Modeloid+corid+'.jpg' foto FROM ArtigosInexistentes"

            db.GetData(Sql, dtLimparModelosCor, False)

            folderExists = My.Computer.FileSystem.DirectoryExists(sFotosServer)
            If folderExists Then
                For Each r As DataRow In dtLimparModelosCor.Rows
                    fileExists = My.Computer.FileSystem.FileExists(sFotosServer + r(0))
                    If fileExists Then
                        My.Computer.FileSystem.DeleteFile(sFotosServer + r(0))
                        PhotosCount += 1
                    End If
                Next
            End If

            MsgBox("Foram " + PhotosCount.ToString + " fotos apagadas!")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    'Public Sub ActualizaPVPWeb(Optional ByVal sArtigo As String = "%")



    '    Dim dtPVPTAB02WEB As New DataTable
    '    Dim dtProdutosWeb As New DataTable

    '    Dim dbCelfGest As New ClsSqlBDados
    '    Dim dbGirl As New ClsSqlBDados

    '    Try



    '        If VerificaServidorActivo(xServidorGirl) Then
    '            ActualizaLigacao("Girl")
    '            Sql = "SELECT ModeloCor.ModeloID+ModeloCor.CorID ARTIGO , ModeloCor.PrVnd PVPETIQ, ISNULL(TAB02.PVP02, ModeloCor.PrVnd) AS PVP FROM (SELECT ModeloID, CorID, Preco AS PVP02 FROM PrecoVenda WHERE (TabPrecoID = '02')) AS TAB02 RIGHT OUTER JOIN ModeloCor ON TAB02.ModeloID = ModeloCor.ModeloID AND TAB02.CorID = ModeloCor.CorID"
    '            dbGirl.GetData(Sql, dtPVPTAB02WEB)
    '            ActualizaLigacao("CelfGest")
    '            If dtPVPTAB02WEB.Rows.Count = 0 Then
    '                MsgBox("Erro a Carregar os Pre�os!!")
    '                Exit Sub
    '            End If
    '        Else
    '            MsgBox("Falha na liga��o ao Servidor!", MsgBoxStyle.Critical)
    '            Exit Sub
    '        End If


    '        'ACTUALIZAR PRE�OS WEB

    '        Dim cnString As String = "server=celferi.com;user id=celficom;password=cel!23co;database=celficom_ocloja"

    '        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    '        Dim myCommand As New MySql.Data.MySqlClient.MySqlCommand
    '        Dim myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter

    '        conn = New MySql.Data.MySqlClient.MySqlConnection
    '        conn.ConnectionString = cnString

    '        Sql = "SELECT model, price FROM celficom_ocloja.oc_product WHERE model like '" & sArtigo & "' order by model"
    '        If conn.State = ConnectionState.Closed Then conn.Open()
    '        myCommand.Connection = conn
    '        myCommand.CommandText = Sql
    '        myAdapter.SelectCommand = myCommand
    '        myAdapter.FillSchema(dtProdutosWeb, SchemaType.Source)
    '        myAdapter.Fill(dtProdutosWeb)

    '        Dim rPVPTAB02WEB() As DataRow
    '        Dim dPVP As Double
    '        'Dim sData As DateTime = DateTime.Now.ToString("dd/MM/yyyy")
    '        Dim sDeData As String = Now.Day & "/" & Now.Month & "/" & Now.Year
    '        Dim sAteData As String = Now.Day & "/" & Now.Month & "/" & Now.Year + 10


    '        '.AddYears(5)


    '        For Each r As DataRow In dtProdutosWeb.Rows

    '            myCommand.CommandText = "DELETE FROM oc_product_special WHERE product_special_id='" & r("model") & "'"
    '            myCommand.ExecuteNonQuery()

    '            rPVPTAB02WEB = dtPVPTAB02WEB.Select("ARTIGO=" & r("model"))
    '            If rPVPTAB02WEB.Length > 0 Then
    '                dPVP = rPVPTAB02WEB(0)("PVP") / 1.23

    '                If Math.Round(dPVP, 2) < Math.Round(r("price"), 2) Then
    '                    myCommand.CommandText = "INSERT INTO oc_product_special (product_special_id, product_id, customer_group_id, priority, price, date_start, date_end) VALUES ('" & r("model") & "', '" & r("model") & "', '1', '0', '" & dPVP & "', '" & sDeData & "', '" & sAteData & "' );"
    '                    myCommand.ExecuteNonQuery()
    '                End If
    '            Else
    '                MsgBox("Falta o pre�o do Artigo: " & r("model"))
    '            End If


    '        Next

    '    Catch ex As Exception
    '        ActualizaLigacao("CelfGest")
    '        MsgBox(ex.Message)
    '    Finally
    '        ActualizaLigacao("CelfGest")
    '    End Try


    'End Sub

    'Public Sub ActualizaTamWeb(Optional ByVal sArtigo As String = "%")


    '    Try

    '        Dim dbTamanhos As New ClsSqlBDados
    '        Dim dtProdutosWeb As New DataTable
    '        Dim dtArtigoTamanhos As New DataTable
    '        Dim dbCelfGest As New ClsSqlBDados


    '        Dim cnString As String = "server=celferi.com;user id=celficom;password=cel!23co;database=celficom_ocloja"



    '        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    '        Dim myCommand As New MySql.Data.MySqlClient.MySqlCommand
    '        Dim myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter

    '        conn = New MySql.Data.MySqlClient.MySqlConnection
    '        conn.ConnectionString = cnString

    '        Sql = "SELECT model, price FROM celficom_ocloja.oc_product WHERE model like '" & sArtigo & "' order by model"
    '        If conn.State = ConnectionState.Closed Then conn.Open()
    '        myCommand.Connection = conn
    '        myCommand.CommandText = Sql
    '        myAdapter.SelectCommand = myCommand
    '        myAdapter.FillSchema(dtProdutosWeb, SchemaType.Source)
    '        myAdapter.Fill(dtProdutosWeb)

    '        If VerificaServidorActivo(xServidorGirl) Then
    '            ActualizaLigacao("Girl")
    '            'Sql = "SELECT CAST(ModeloID + CorID AS int) AS Product_id, TamID, SUM(1) AS Qtd FROM Serie WHERE (EstadoID IN ('S', 'T')) GROUP BY CAST(ModeloID + CorID AS int), TamID ORDER BY Product_id, TamID"
    '            'Sql = "SELECT IdModeloCor, ModeloID + CorID AS Artigo, TamID, SUM(1) AS Qtd FROM Serie WHERE (EstadoID IN ('S', 'T')) GROUP BY IdModeloCor, ModeloID + CorID, TamID ORDER BY Artigo, TamID"
    '            Dim sAnoExport As String = "12" 'ANO A PARTIR DO QUAL VOU EXPORTAR....
    '            Sql = "SELECT ModeloID + CorID AS Artigo, TamID, SUM(1) AS Qtd FROM Serie WHERE (EstadoID IN ('S', 'T')) AND (LEFT(SerieID, 2) > '" & sAnoExport & "') GROUP BY ModeloID + CorID, TamID ORDER BY Artigo, TamID"
    '            dbTamanhos.GetData(Sql, dtArtigoTamanhos)
    '            ActualizaLigacao("CelfGest")
    '        Else
    '            MsgBox("Falha na liga��o ao Servidor!", MsgBoxStyle.Critical)
    '            Exit Sub
    '        End If

    '        Dim sProduct_id As String
    '        Dim dProduct_id As Integer
    '        Dim sModeloId As String
    '        Dim sCorId As String

    '        Dim rArtigoTam() As DataRow

    '        For Each r As DataRow In dtProdutosWeb.Rows

    '            sProduct_id = r("model")
    '            dProduct_id = r("model")
    '            sModeloId = Microsoft.VisualBasic.Left(sProduct_id, 5)
    '            sCorId = Microsoft.VisualBasic.Right(sProduct_id, 2)

    '            rArtigoTam = dtArtigoTamanhos.Select("Artigo=" & r("model"))

    '            Sql = "DELETE FROM oc_product_option_value WHERE product_option_id='" & dProduct_id & "'"
    '            myCommand.CommandText = Sql
    '            myCommand.ExecuteNonQuery()

    '            Sql = "DELETE FROM oc_product_filter WHERE product_id='" & dProduct_id & "'"
    '            myCommand.CommandText = Sql
    '            myCommand.ExecuteNonQuery()

    '            If rArtigoTam.Length > 0 Then
    '                For i As Integer = 0 To rArtigoTam.Length - 1
    '                    'Debug.Write(index.ToString & " ")
    '                    Sql = "INSERT INTO oc_product_option_value (product_option_value_id, product_option_id, product_id, option_id, option_value_id, quantity, subtract, price, price_prefix, points, points_prefix, weight, weight_prefix) " & _
    '                           " VALUES ('" & dProduct_id & rArtigoTam(i)("TamID") & "', '" & dProduct_id & "', '" & dProduct_id & "', '20', '" & rArtigoTam(i)("TamID") & "', " & rArtigoTam(i)("Qtd") & ", '1', '0', '+', '0', '+', '0', '+');"
    '                    myCommand.CommandText = Sql
    '                    myCommand.ExecuteNonQuery()

    '                    Sql = "INSERT INTO oc_product_filter (product_id, filter_id) VALUES ('" & dProduct_id & "', '" & rArtigoTam(i)("TamID") & "');"
    '                    myCommand.CommandText = Sql
    '                    myCommand.ExecuteNonQuery()

    '                Next
    '                'Debug.WriteLine("")
    '            Else
    '                'limpar artigo da web
    '                myCommand.CommandText = "DELETE FROM celficom_ocloja.oc_product WHERE product_id='" & dProduct_id & "'"
    '                myCommand.ExecuteNonQuery()

    '                'APAGAR FOTO
    '                DeleteFile("ftp://ftp.celferi.com/public_html/loja/image/catalog/product/" + sProduct_id + ".JPG", "celficom", "cel!23co")

    '                'tirar o pico de web em modelocor.
    '                Sql = "UPDATE ModeloCor SET Web = 0 WHERE ModeloID = '" & sModeloId & "' and CorID = '" & sCorId & "'"
    '                dbCelfGest.ExecuteData(Sql)

    '            End If
    '        Next

    '    Catch ex As Exception
    '        ActualizaLigacao("CelfGest")
    '        MsgBox(ex.Message)
    '    Finally
    '        ActualizaLigacao("CelfGest")


    '    End Try





    'End Sub

    Public Sub AbrirGaveta()


        Try

            ''enviar instru��o para a porta com
            'Dim sData As String = ""
            'Using com1 As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort("COM3")
            '    com1.WriteLine(sData)
            'End Using
            'PrintSomeText("ABRIR GAVETA")



            'ESTA SOLU��O J� FUNCIONOU.....
            'FileOpen(1, "LPT1:", OpenMode.Output)
            'PrintLine(1, "ABRIR GAVETA")


            'Using com4 As IO.Ports.SerialPort =
            'My.Computer.Ports.OpenSerialPort("COM5")
            '    com4.WriteLine("ABRIR GAVETA")
            'End Using


            Dim sPorta As String = "COM5"

            If sPorta = "LPT1" Then
                FileOpen(1, "LPT1:", OpenMode.Output)
                PrintLine(1, "ABRIR GAVETA")
            Else
                Using COM As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort(sPorta)
                    COM.WriteLine("ABRIR GAVETA")
                End Using
            End If


        Catch ex As SqlException
            'ErroSQL(ex.Number, ex.Message, "ABRIR GAVETA")
        Catch ex As Exception
            'ErroVB(ex.Message, "ABRIR GAVETA")
        End Try


    End Sub

    Public Function IsDataGridViewEmpty(ByRef dataGridView As DataGridView) As Boolean
        Dim isEmpty As Boolean
        isEmpty = True
        For Each row As DataGridViewRow In dataGridView.Rows
            For Each cell As DataGridViewCell In row.Cells
                If Not String.IsNullOrEmpty(cell.Value) Then
                    ' Check if the string only consists of spaces
                    If Not String.IsNullOrEmpty(Trim(cell.Value.ToString())) Then
                        isEmpty = False
                        Exit For
                    End If
                End If
            Next
        Next
        Return isEmpty
    End Function

    Public Function ConverteNulos(Optional ByVal Valor As String = "") As String

        Try
            'N�O ESTA A SER USADA....
            Return Valor

        Catch ex As Exception

        End Try


    End Function

    Public Sub ActualizarClienteLoja(ByVal sIDClienteLojaAux As String, ByRef sClienteLojaIdAux As String, ByRef sNomeAux As String, ByRef sNifAux As String)

        Dim db As New ClsSqlBDados

        Try

            If sIDClienteLojaAux = "" Then
                'sNomeAux = "Cliente Ocasional"
                sNomeAux = "Consumidor Final"
                sNifAux = "xxxxxxxxx"
                sClienteLojaIdAux = "1"
            Else
                Sql = "SELECT NOME FROM CLIENTESLOJA WHERE IDClienteLoja='" & sIDClienteLojaAux & "'"
                sNomeAux = db.GetDataValue(Sql)

                Sql = "SELECT ClienteLojaID FROM CLIENTESLOJA WHERE IDClienteLoja='" & sIDClienteLojaAux & "'"
                sClienteLojaIdAux = db.GetDataValue(Sql)

                Sql = "SELECT ISNULL(NIF,'') FROM CLIENTESLOJA WHERE IDClienteLoja='" & sIDClienteLojaAux & "'"
                sNifAux = db.GetDataValue(Sql).ToString
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "ActualizarClienteLoja")
        Catch ex As Exception
            ErroVB(ex.Message, "ActualizarClienteLoja")
        Finally
            If Not db Is Nothing Then db.Dispose()
            db = Nothing
        End Try

    End Sub

    Public Function verificar_doc(ByVal xNumDoc As String, ByVal xTipodoc As String) As Boolean


        Dim db As New ClsSqlBDados


        Try


            Sql = "SELECT COUNT(*) FROM DocCab WHERE DocCab.EmpresaID = '" & xEmp & "' AND DocCab.ArmazemID = '" & xArmz & "' AND DocCab.TipoDocID = '" & xTipodoc & "' AND DocCab.DocNr = '" & xNumDoc & "' AND LEN(ATDocCodeID) > 0 AND LEN(Hash) > 0 AND LEN(Hash4d) > 0  AND LEN(ChaveAssinar) > 0"
            'Sql = "SELECT COUNT(*) FROM DocCab  WHERE IDDOCCAB='09e9cfc7-d99d-4abb-8d2f-1730e335d9fb'  AND LEN(ATDOCCODEID)>0 AND LEN(HASH)>0 AND LEN(HASH4D)>0 AND LEN(CHAVEASSINAR)>0"
            If db.GetDataValue(Sql) <> 1 Then
                Return False
            Else
                Return True
            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "verificar_doc")
            Return False
        Catch ex As Exception
            ErroVB(ex.Message, "verificar_doc")
            Return False
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try



    End Function

    'Private textToPrint As String
    'Private Sub PrintSomeText(ByVal text As String)
    '    Dim pd As New Printing.PrintDocument()
    '    Dim pDialog As New PrintDialog()
    '    If pDialog.ShowDialog() = DialogResult.Cancel Then Exit Sub
    '    pd.PrinterSettings = pDialog.PrinterSettings
    '    AddHandler pd.PrintPage, AddressOf PrintDocument_Print
    '    textToPrint = text
    '    pd.Print()
    'End Sub

    'Private Sub PrintDocument_Print(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
    '    e.Graphics.DrawString(textToPrint, Font, Brushes.Black, e.MarginBounds)
    'End Sub




End Module
