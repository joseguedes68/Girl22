Imports System.Data.SqlClient
'Imports System.Drawing




Public Class frmArranque

    Inherits System.Windows.Forms.Form
    Dim dtUtil As New DataTable


    Private Sub frmArranque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'MsgBox("PesquisaMaxNumDoc TENHO QUE CONTROLAR QUANDO PesquisaMaxNumDoc DEVOLVE """)
            'MsgBox("TESTAR ARRANQUE SEM CÓPIAS ATIVAS, TESTAR SINAL..")

            PanelUser.Visible = False
            Me.StartPosition = FormStartPosition.CenterScreen
            'Me.lblProductName.Text = Application.ProductName

            If sAplicacao = "GIRL" Then
                Me.lblProductName.Text = "CELFERI"
                Me.BackColor = System.Drawing.Color.DarkCyan

            ElseIf sAplicacao = "CELFGEST" Then
                Me.lblProductName.Text = "CELFGEST"
                Me.BackColor = System.Drawing.Color.YellowGreen


            End If


            'Me.lblCompanyName.Text = "Company: " & Application.CompanyName
            Me.lblCompanyName.Text = "Grande Enigma, Lda"
            Me.lblVersao.Text = "Version: " & Application.ProductVersion.Substring(0, 3)
            Me.lblDescription.Text = "Gestão Integrada de Rede de Lojas!"
            Me.PanelUser.Visible = False
            Me.lblDesenvolvimento.Text = "Validar a Aplicação!"

            Me.lblDesenvolvimento.Visible = False
            Me.lblProductName.Top -= 30
            Me.lblDescription.Top -= 30
            Me.lblVersao.TextAlign = ContentAlignment.MiddleLeft
            Dim myFont As New Font("Arial", 10)
            Me.lblVersao.Font = myFont
            Me.PanelUser.Visible = False

            Me.TimerCopias.Interval = 1
            Me.TimerCopias.Start()

            Me.PanelUser.Visible = True
            Me.txtUtilizador.Focus()
            Me.Show()

            If bDesenvolvimento = True Then
                modoDesenvolvimento()
            End If

            'Me.TimerAlerta.Interval = 2000
            'Me.TimerAlerta.Start()


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmArranque_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmArranque_Load")
        End Try
    End Sub

    Public Sub txtUtilizador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUtilizador.KeyPress

        Dim db As New ClsSqlBDados

        Try
            If e.KeyChar = ChrW(Keys.Enter) Then

                e.Handled = True
                Me.txtPassword.Focus()
                Me.txtPassword.SelectAll()

            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "txtUtilizador_KeyPress")
        Catch ex As Exception
            ErroVB(ex.Message, "txtUtilizador_KeyPress")
        Finally

        End Try

    End Sub

    Private Sub txtUtilizador_Leave(sender As Object, e As System.EventArgs) Handles txtUtilizador.Leave
        ValidarUtilizador()
    End Sub

    Private Sub txtUtilizador_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUtilizador.Validating

        Try

            If dtUtil.Rows.Count <> 1 Then
                SendKeys.Send("{Enter}")
                If dtUtil.Rows.Count <> 1 Then
                    e.Cancel = True
                End If
            End If

        Catch ex As Exception
            ErroVB(ex.Message, "txtUtilizador_Validating")
        Finally

        End Try

    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmdOK_Click(sender, e)
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click


        Dim db As New ClsSqlBDados

        Dim bNovaPass As Boolean
        Dim dbManut As New ClsManutencaoBD


        Try

            bNovaPass = dtUtil.Rows(0)("NovaPassWord")
            If bNovaPass = True Then

                Dim xNovaPass As String
10:             xNovaPass = InputBox("Alterar palavra Pass!", "NOVA PASSWORD!")
                If Len(Trim(xNovaPass)) < 4 Then
                    MsgBox("A Password tem que ter 4 ou mais digitos!")
                    GoTo 10
                End If
                If InputBox("Confirmar palavra Pass!", "CONFIRMAR PASSWORD!") <> xNovaPass Then
                    GoTo 10
                End If

                Sql = "UPDATE Utilizadores SET PassWord = N'" & Encriptar(xNovaPass) & "', NovaPassWord = 0 WHERE UtilizadorID = " & iUtilizadorID
                db.ExecuteData(Sql)
                bNovaPass = False

                Me.Hide()

            Else

                Sql = "SELECT PassWord FROM Utilizadores WHERE UtilizadorID = " & iUtilizadorID
                If Not db.GetDataValue(Sql) Is Nothing Then

                    If txtPassword.Text <> Desencriptar(db.GetDataValue(Sql)) Then
                        MsgBox("Palavar pass errada!")
                        txtPassword.Focus()
                        txtPassword.SelectAll()
                        Exit Sub
                    Else
                        Me.Hide()
                    End If
                End If

            End If

            xGrupoAcesso = dtUtil.Rows(0)("GRUPOACESSO")
            xArmz = dtUtil.Rows(0)("ArmazemID")

            DevolveIvaId(xArmz)


            If rbBackOffice.Checked = True Then
                If xGrupoAcesso = "ADMIN" And xArmz = "0000" Then
                    xAplicacao = "BACKOFFICE"
                    If sAplicacao = "GIRL" Then
                        frmMenuGirl.Show()
                    Else
                        frmMenuCelfGest.Show()
                    End If
                Else
                    MsgBox("Não tem Acesso ao BackOffice")
                    Application.Exit()
                End If
            Else

                If ArmazemConsignacao(xArmz) = True Then
                    bLojaConsignacao = True
                    xAplicacao = "POS"

                End If

                xAplicacao = "POS"
                frmMenuPos.Show()


            End If


        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "cmdOK_Click")
        Catch ex As Exception
            ErroVB(ex.Message, "cmdOK_Click")
        Finally

        End Try



    End Sub

    Private Sub frmArranque_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        frmSplash.Dispose()
        LogoffPC()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        LogoffPC()
    End Sub

    'FUNÇÕES

    Private Function ValidarUtilizador() As Boolean


        Dim db As New ClsSqlBDados


        Try

            If Len(txtUtilizador.Text) = 0 Then LogoffPC()


            dtUtil.Clear()
            Dim xUtil As String = txtUtilizador.Text.Trim.ToString



            Sql = "SELECT UtilizadorID, NomeUtilizador, UtilWindows, GrupoAcesso, ArmazemID, PassWord, NovaPassWord FROM Utilizadores WHERE NomeUtilizador = N'" & xUtil & "'"
            db.GetData(Sql, dtUtil)
            If dtUtil.Rows.Count = 0 Then
                MsgBox("Utilizador não Existe!")
                LogoffPC()
                'txtUtilizador.Focus()
                'txtUtilizador.SelectAll()
            Else
                iUtilizadorID = dtUtil.Rows(0)("UtilizadorID").ToString()
                If dtUtil.Rows(0)("ArmazemID").ToString() = "0000" Then
                    rbBackOffice.Checked = True
                Else
                    If sAplicacao <> "GIRL" Then
                        MsgBox("Utilizador nao autorizado para esta aplicação!")
                        LogoffPC()
                    End If

                    rbPOS.Checked = True
                End If
                'e.Handled = True
                Me.txtPassword.Focus()
                Me.txtPassword.SelectAll()
            End If



        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "txtUtilizador_KeyPress")
        Catch ex As Exception
            ErroVB(ex.Message, "txtUtilizador_KeyPress")
        Finally

        End Try



    End Function

    Private Sub TimerCopias_Tick(sender As System.Object, e As System.EventArgs) Handles TimerCopias.Tick


        Dim db As New ClsSqlBDados
        Dim dtUltimaCopia As Date

        Try

            Me.TimerCopias.Interval = 3600000 ' hora a hora 3600000


            If TimeOfDay > "#2:00:00 AM#" And TimeOfDay < "#4:00:00 AM#" Then

                Sql = "SELECT ISNULL(MAX(DATA),'1900-01-01') FROM BACKUPS"
                dtUltimaCopia = db.GetDataValue(Sql)
                If dtUltimaCopia < Now.AddHours(-6) Then
                    Dim cCopias As New ClsCopias
                    cCopias.CriarCopiaDiaria()
                    Me.TimerCopias.Interval = 7200000
                End If
            End If




        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "TimerCopias_Tick")
        Catch ex As Exception
            ErroVB(ex.Message, "TimerCopias_Tick")
        Finally
            db = Nothing
            'não sei se ao comentar estas linhas vou ter problemas.......
            'Me.PanelUser.Visible = True
            'Me.txtUtilizador.Focus()
            'Me.Show()  
        End Try


    End Sub

    Private Sub TimerAlerta_Tick(sender As System.Object, e As System.EventArgs) Handles TimerAlerta.Tick
        'VERIFICAR SE A PASTA FOTOS ESTÁ OK
        Try

            If Not My.Computer.FileSystem.FileExists("\\SERVIDOR\FOTOS\xok.jpg") Then
                EnviarEmail("A FOTO xok.jpg foi danificada!!!")
                Dim db As New ClsSqlBDados
                Sql = "UPDATE EMPRESAS SET BLOQUEAR='TRUE' WHERE EMPRESAID='" & xEmp & "'"
                db.ExecuteData(Sql)
                EnviarEmail("Verifica Fotos", "Caminho \\SERVIDOR\FOTOS\xok.jpg não encontrado!!")
            End If

            'TB DEVIA VERIFICAR A PASTA C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA ..... mdf
            'NÃO DEVIA PORQUE ESTOU A ABRIR O CAMINHO A TODOS.....

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmArranque TimerAlerta_Tick")
        Catch ex As Exception
            ErroVB(ex.Message, "frmArranque TimerAlerta_Tick")
        Finally
            Me.TimerAlerta.Interval = 600000 ' 10 min a 10 min 600000
        End Try


    End Sub

    Private Sub modoDesenvolvimento()

        If sAplicacao = "CELFGEST" Then
            txtUtilizador.Text = "GUEDES"
            txtPassword.Text = "C185"
        Else
            txtUtilizador.Text = "ADMIN"
            txtPassword.Text = "3042"
        End If



    End Sub

    'NÃO UTILIZADO

    Public Function CarregarDadosGerais() As Boolean
        Try
            'Sql = "SELECT FormaPagtoID FPagID, FPDescr Descri, cast(0 as numeric(9,2)) Valor FROM FormaPagamento order by 2"
            'da = New SqlDataAdapter(Sql, cn)
            'da.FillSchema(DsDGridForPag, SchemaType.Source, "FormaPagamento")
            'da.Fill(DsDGrid, "FormaPagamento")
            'If DsDGrid.Tables("FormaPagamento").Rows.Count > 0 Then
            'Sql = "SELECT TipoDocID, TipoDocDesc Descricao, MovStock, MovEstado FROM TipoDoc"
            'da = New SqlDataAdapter(Sql, cn)
            'da.FillSchema(DsDGrid, SchemaType.Mapped, "TiposDoc")
            'da.Fill(DsDGrid, "TiposDoc")
            'If DsDGrid.Tables("TiposDoc").Rows.Count > 0 Then
            '    Return True
            'Else
            '    Return False
            'End If
            'Else
            'Return False
            'End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmSplashScreen: CarregarDadosGerais")
        Catch ex As Exception
            ErroVB(ex.Message, "frmSplashScreen: CarregarDadosGerais")
        Finally
        End Try
    End Function

    Private Function ValidarEmpresa() As Boolean
        'Try
        '    Dim RegKey As Microsoft.Win32.RegistryKey
        '    RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\GIRL", True)
        '    If Not RegKey Is Nothing Then
        '        xEmp = RegKey.GetValue("COMPANY")
        '        If Not xEmp Is Nothing Then
        '            xArmz = RegKey.GetValue("WAREHOUSE")
        '            If Not xArmz Is Nothing Then
        '                Normal = RegKey.GetValue("CNString")
        '                If Not Normal Is Nothing Then
        '                    xFotosPath = RegKey.GetValue("FOTOSPATH")
        '                    If Not xFotosPath Is Nothing Then
        '                        Return True
        '                    Else
        '                        xFotosPath = InputBox("Digite o caminho das Fotos!", Application.ProductName)
        '                        If xFotosPath.Length > 0 Then
        '                            RegKey.SetValue("FOTOSPATH", xFotosPath)
        '                            Return True
        '                        Else
        '                            Return False
        '                        End If
        '                    End If
        '                Else
        '                    Normal = InputBox("Digite a string da base de dados!", Application.ProductName, "Integrated Security=SSPI;database=GIRL;SERVIDOR=(local)")
        '                    If Normal.Length > 0 Then
        '                        RegKey.SetValue("CNString", Normal)
        '                        Return True
        '                    Else
        '                        Return False
        '                    End If
        '                End If
        '            Else
        '                Dim Amz As String = InputBox("Digite o Armazem pretendido", Application.ProductName)
        '                If Amz.Length > 0 Then
        '                    RegKey.SetValue("WAREHOUSE", Amz.ToUpper)
        '                    Return True
        '                Else
        '                    Return False
        '                End If
        '            End If
        '        Else
        '            Dim Emp As String = InputBox("Digite a Empresa pretendida", Application.ProductName)
        '            If Emp.Length > 0 Then
        '                RegKey.SetValue("COMPANY", Emp.ToUpper)
        '                Return True
        '            Else
        '                Return False
        '            End If
        '        End If
        '    Else
        '        RegKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\GIRL")
        '        Dim Validar As Boolean
        '        Dim Emp As String = InputBox("Digite a Empresa pretendida", Application.ProductName)
        '        If Emp.Length > 0 Then
        '            RegKey.SetValue("COMPANY", Emp.ToUpper)
        '            xEmp = emp.ToUpper
        '            Validar = True
        '        Else
        '            Validar = False
        '        End If
        '        If Validar = False Then
        '            Return False
        '        End If
        '        Dim Amz As String = InputBox("Digite o Armazem pretendido", Application.ProductName)
        '        If Amz.Length > 0 Then
        '            RegKey.SetValue("WAREHOUSE", Amz.ToUpper)
        '            xArmz = amz.ToUpper
        '            Validar = True
        '        Else
        '            Validar = False
        '        End If
        '        Dim Fot As String = InputBox("Digite o caminho das Fotos!", Application.ProductName)
        '        If Fot.Length > 0 Then
        '            RegKey.SetValue("FOTOSPATH", Fot)
        '            xFotosPath = Fot.ToUpper
        '            Validar = True
        '        Else
        '            Validar = False
        '        End If

        '        If Validar = False Then
        '            Return False
        '        End If

        '        Normal = InputBox("Digite a string da base de dados!", Application.ProductName, "Integrated Security=SSPI;database=GIRL;SERVIDOR=(local)")
        '        If Normal.Length > 0 Then
        '            RegKey.SetValue("CNString", Normal)
        '            Validar = True
        '        Else
        '            Validar = False
        '        End If

        '        If Validar Then
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    End If
        'Catch ex As SqlException
        '    ErroSQL(ex.Number, ex.Message, "frmSplashScreen: ValidarEmpresa")
        'Catch ex As Exception
        '    ErroVB(ex.Message, "frmSplashScreen: ValidarEmpresa")
        'Finally
        'End Try
    End Function

    Public Function ValidarAplicacao() As Boolean
        'TODO: CRIAR O CODIGO DE EFECTUAR A VALIDAÇÃO
        If ValidarEmpresa() Then
            Return True
        Else
            Return False
        End If
        Return True
    End Function

    Private Function ValidarConnexao() As Boolean
        Try
            cn.Open()
            If cn.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmSplashScreen: ValidarConnexao")
        Catch ex As Exception
            ErroVB(ex.Message, "frmSplashScreen: ValidarConnexao")
        Finally
            cn.Close()
        End Try
    End Function







End Class