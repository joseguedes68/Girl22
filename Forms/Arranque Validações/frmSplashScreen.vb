Imports System.Data.SqlClient

Public Class frmSplashScreen
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
    Friend WithEvents lblVersao As System.Windows.Forms.Label
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents PanelUser As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtUtilizador As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblDesenvolvimento As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplashScreen))
        Me.lblVersao = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.PanelUser = New System.Windows.Forms.Panel()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUtilizador = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblDesenvolvimento = New System.Windows.Forms.Label()
        Me.PanelUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblVersao
        '
        Me.lblVersao.BackColor = System.Drawing.Color.Transparent
        Me.lblVersao.Location = New System.Drawing.Point(8, 336)
        Me.lblVersao.Name = "lblVersao"
        Me.lblVersao.Size = New System.Drawing.Size(496, 40)
        Me.lblVersao.TabIndex = 1
        Me.lblVersao.Text = "ProductVersion"
        Me.lblVersao.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblProductName
        '
        Me.lblProductName.BackColor = System.Drawing.Color.Transparent
        Me.lblProductName.Font = New System.Drawing.Font("Arial", 54.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.Location = New System.Drawing.Point(73, 98)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(376, 80)
        Me.lblProductName.TabIndex = 2
        Me.lblProductName.Text = "ProductName"
        Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCompanyName
        '
        Me.lblCompanyName.BackColor = System.Drawing.Color.Transparent
        Me.lblCompanyName.Location = New System.Drawing.Point(8, 8)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(496, 40)
        Me.lblCompanyName.TabIndex = 3
        Me.lblCompanyName.Text = "CompanyName"
        '
        'Timer
        '
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(12, 178)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(496, 40)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelUser
        '
        Me.PanelUser.BackColor = System.Drawing.Color.DarkKhaki
        Me.PanelUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelUser.Controls.Add(Me.txtPassword)
        Me.PanelUser.Controls.Add(Me.txtUtilizador)
        Me.PanelUser.Controls.Add(Me.Label2)
        Me.PanelUser.Controls.Add(Me.Label1)
        Me.PanelUser.Controls.Add(Me.cmdOK)
        Me.PanelUser.Controls.Add(Me.cmdCancelar)
        Me.PanelUser.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelUser.Location = New System.Drawing.Point(292, 229)
        Me.PanelUser.Name = "PanelUser"
        Me.PanelUser.Size = New System.Drawing.Size(208, 104)
        Me.PanelUser.TabIndex = 0
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(74, 33)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(128, 22)
        Me.txtPassword.TabIndex = 1
        '
        'txtUtilizador
        '
        Me.txtUtilizador.Location = New System.Drawing.Point(74, 9)
        Me.txtUtilizador.Name = "txtUtilizador"
        Me.txtUtilizador.Size = New System.Drawing.Size(128, 22)
        Me.txtUtilizador.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(2, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Utilizador"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOK
        '
        Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(28, 68)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(72, 24)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "Ok"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(108, 68)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(72, 24)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Cancelar"
        '
        'lblDesenvolvimento
        '
        Me.lblDesenvolvimento.BackColor = System.Drawing.Color.Transparent
        Me.lblDesenvolvimento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesenvolvimento.Location = New System.Drawing.Point(8, 272)
        Me.lblDesenvolvimento.Name = "lblDesenvolvimento"
        Me.lblDesenvolvimento.Size = New System.Drawing.Size(496, 40)
        Me.lblDesenvolvimento.TabIndex = 5
        Me.lblDesenvolvimento.Text = "Description"
        Me.lblDesenvolvimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSplashScreen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(14, 32)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(512, 384)
        Me.Controls.Add(Me.PanelUser)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblCompanyName)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.lblVersao)
        Me.Controls.Add(Me.lblDesenvolvimento)
        Me.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplashScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.PanelUser.ResumeLayout(False)
        Me.PanelUser.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " PROCEDIMENTOS BASICOS DO FORM "

    Dim DsDGrid As New GirlDataSet
    Private Sub frmSplashScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.lblProductName.Text = Application.ProductName
            Me.lblCompanyName.Text = "Company: " & Application.CompanyName
            Me.lblVersao.Text = "Version: " & Application.ProductVersion.Substring(0, 3)
            Me.lblDescription.Text = "Gestão Integrada de Rede de Lojas!"
            Me.PanelUser.Visible = False
            Me.lblDesenvolvimento.Text = "Validar a Aplicação!"
            Me.Show()
            Application.DoEvents()
            Sleep(1500)
            If ValidarAplicacao() Then
                Me.lblDesenvolvimento.Text = "Aplicação Validada!"
                Application.DoEvents()
                Sleep(1500)
                Me.lblDesenvolvimento.Text = "Vereficar Ligação com Base de Dados!"
                Application.DoEvents()
                If ValidarConnexao() Then
                    Me.lblDesenvolvimento.Text = "Ligação com Base de Dados OK!"
                    Application.DoEvents()
                    Sleep(1500)
                    Me.lblDesenvolvimento.Text = "A Carregar dados!"
                    Application.DoEvents()
                    If CarregarDadosGerais() Then
                        Me.lblDesenvolvimento.Text = "Dados Carregados!"
                        Application.DoEvents()
                        Me.Timer.Interval = 2000
                        Me.Timer.Enabled = True
                    End If
                End If
            Else
                'TODO: FECHAR A APLICACAO CASO ELA NÃO ESTAR VALIDADA
            End If
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "frmSplashScreen: frmSplashScreen_Load")
        Catch ex As Exception
            ErroVB(ex.Message, "frmSplashScreen: frmSplashScreen_Load")
        End Try
    End Sub

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

    'TODO: RETIRAR O PUBLIC NESTA FUNÇÃO E COLOCA-LA COMO PRIVATE
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

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Me.lblDesenvolvimento.Visible = False
        Me.lblProductName.Top -= 30
        Me.lblDescription.Top -= 30
        Me.lblVersao.TextAlign = ContentAlignment.MiddleLeft
        Dim myFont As New Font("Arial", 10)
        Me.lblVersao.Font = myFont
        Me.PanelUser.Visible = True
        Me.Timer.Enabled = False
        Me.txtUtilizador.Focus()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        End
        Application.Exit()
    End Sub

    Private Sub frmSplashScreen_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        frmSplash.Dispose()

    End Sub

    Public Sub txtUtilizador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUtilizador.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Me.txtPassword.Focus()
            Me.txtPassword.SelectAll()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmdOK_Click(sender, e)
        End If
    End Sub


#End Region

#Region " PROCEDIMENTOS DE VALIDAÇÃO DO UTILIZADOR "

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Try
        '    If ValidarDados() Then
        '        If ValidarUtilizador(Me.txtUtilizador.Text.Trim, Me.txtPassword.Text.Trim) Then
        '            xUtilizador = Me.txtUtilizador.Text.Trim
        '            frmPrinc = New frmMenuBackOffice
        '            frmPrinc.Show()
        '            frmSplashScreen_Closed(sender, e)
        '        Else
        '            Static ContadorValidacao As Int16
        '            If ContadorValidacao > 2 Then
        '                MessageBox.Show("O número máximo de tentativas já foi excedido a aplicação vai encerrar!", _
        '                                Application.ProductName, _
        '                                MessageBoxButtons.OK, _
        '                                MessageBoxIcon.Error)
        '                End
        '                Application.Exit()
        '            Else
        '                ds.Tables("Utilizador").Clear()
        '                MessageBox.Show("A Validação do Utilizador não está correcta!", _
        '                                Application.ProductName, _
        '                                MessageBoxButtons.OK, _
        '                                MessageBoxIcon.Warning)
        '                Me.txtPassword.Text = vbNullString
        '                Me.txtUtilizador.Text = vbNullString
        '                Me.txtUtilizador.Focus()
        '                ContadorValidacao += 1
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    ErroVB(ex.Message, "ModGeral: main")
        'Finally
        '    Sql = Nothing
        'End Try
    End Sub

    Private Function ValidarUtilizador(ByVal Utilizador As String, ByVal Password As String) As Boolean
        'Try
        '    Sql = "SELECT OperadorID, Operador, PassWord, ArmazemID FROM Operadores where OperadorID = '" & Utilizador & "' and PassWord = '" & Password & "'"
        '    da = New SqlDataAdapter(Sql, cn)
        '    da.FillSchema(ds, SchemaType.Mapped, "Utilizador")
        '    da.Fill(ds, "Utilizador")
        '    If ds.Tables("Utilizador").Rows.Count > 0 Then
        '        Return True
        '    Else
        '        Return False
        '    End If
        'Catch ex As SqlException
        '    ErroSQL(ex.Number, ex.Message, "clsCodigo: ValidarUtilizador")
        'Catch ex As Exception
        '    ErroVB(ex.Message, "clsCodigo: ValidarUtilizador")
        'Finally
        '    da.Dispose()
        '    cn.Close()
        '    Sql = Nothing
        'End Try
    End Function

    Private Function ValidarDados() As Boolean

        'If Me.txtUtilizador.Text.Length > 0 Then
        '    If Me.txtPassword.Text.Length > 0 Then
        '        Return True
        '    Else
        '        Me.txtPassword.Focus()
        '        Return False
        '    End If
        'Else
        '    Me.txtUtilizador.Focus()
        '    Return False
        'End If
    End Function

#End Region

End Class
