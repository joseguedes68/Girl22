Public Class clsLogin




    Public Function CarregarDefenicoesServidor(Optional ByVal Local As Boolean = False) As Boolean


        Dim LinhaComando As String = Nothing
        Dim Servidor As String = Nothing
        Dim Armazem As String = Nothing
        Dim db As New ClsSqlBDados
        Dim xBdadosCelferi As String = ""
        Dim xBdadosGirl As String = ""


        If SystemInformation.UserName <> "joseg" And bDesenvolvimento = True Then
            MsgBox("Não é possivél aceder à Aplicação!!")
            Exit Function
        End If



        For Each argument As String In My.Application.CommandLineArgs
            LinhaComando = argument
        Next

        If LinhaComando Is Nothing Then
            Servidor = "SERVER"
        Else
            Servidor = LinhaComando.Substring(LinhaComando.IndexOf("/") + 1, LinhaComando.LastIndexOf("/") - 1)
        End If

        xBackupPath = "C:\Girl\BackUp\"

        'MsgBox("att : 'xFotosPath = C:\Girl\Fotos\")
        'xFotosPath = "\\25.96.178.140\Girl\Fotos\"
        xFotosPath = "C:\Girl\Fotos\"

        xRptPath = "C:\Girl\Reports\"


        Select Case Servidor

            Case "Local"

                xServidorGirl = My.Computer.Name '(local)
                xServidorCelferi = My.Computer.Name '(local)
                xBdadosGirl = "GirlLocal"
                xBdadosCelferi = "CelfGestLocal"

                ' ******  SE DESCOMENTAR AS LINHAS SEGUINTES VOU TRABALHAR DIRECTAMENTE NO SERVIDOR ********
                'xServidorGirl = "25.68.121.191"
                'xBdadosGirl = "Girl"

            Case "SERVER"


                'If VerificaServidorActivo("SERVER") = True Then
                '    xServidorGirl = "SERVER"
                '    'xServidorGirl = xEnderecoHamachi

                'Else
                '    Return False
                'End If

                xServidorGirl = "SERVER"



                If sAplicacao = "CELFGEST" Then
                    If VerificaServidorActivo("POSTO2") = True Then
                        xServidorCelferi = "POSTO2"
                    Else
                        Return False
                    End If
                    xBdadosCelferi = "CelfGest"

                End If


                xBdadosGirl = "Girl"


        End Select

        '190.190.200.100,1433


        If SystemInformation.UserName = "joseg" Then



            ''ligação direta ao servidor real
            'Dim sInstancia As String = "SQLEXPRESS"
            'xServidorGirl = "192.168.1.65"
            'xBdadosGirl = "Girl"
            'sconnectionstringGirl = "Data Source=" + xServidorGirl + "\SQLEXPRESS;Initial Catalog=" + xBdadosGirl + ";Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42"
            'sconnectionstringGirlReport = "Provider=SQLOLEDB.1;Password=gRANDEeNIGMA50768721330Lc42;Persist Security Info=True;User ID=sa;Initial Catalog=" & xBdadosGirl & ";Data Source=" & xServidorGirl & "\SQLEXPRESS"


            Dim sInstancia As String = "SQLEXPRESS"
            sconnectionstringGirl = "Data Source=" + xServidorGirl + "\" & sInstancia & ";Initial Catalog=" + xBdadosGirl + ";Integrated Security=SSPI"
            sconnectionstringGirlReport = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Initial Catalog=" & xBdadosGirl & ";Data Source=" & xServidorGirl & "\" & sInstancia
            sconnectionstringCelfGest = "Data Source=" & xServidorCelferi & "\" & sInstancia & ";Initial Catalog=" & xBdadosCelferi & ";Integrated Security=SSPI"
            sconnectionstringCelfGestReport = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Initial Catalog=" & xBdadosCelferi & ";Data Source=" & xServidorCelferi & "\" & sInstancia

        Else
            sconnectionstringGirl = "Data Source=" + xServidorGirl + "\SQLEXPRESS;Initial Catalog=" + xBdadosGirl + ";Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42"
            sconnectionstringGirlReport = "Provider=SQLOLEDB.1;Password=gRANDEeNIGMA50768721330Lc42;Persist Security Info=True;User ID=sa;Initial Catalog=" & xBdadosGirl & ";Data Source=" & xServidorGirl & "\SQLEXPRESS"
            sconnectionstringCelfGest = "Data Source=" & xServidorCelferi & "\SQLEXPRESS;Initial Catalog=" & xBdadosCelferi & ";Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42"
            sconnectionstringCelfGestReport = "Provider=SQLOLEDB.1;Password=gRANDEeNIGMA50768721330Lc42;Persist Security Info=True;User ID=sa;Initial Catalog=" & xBdadosCelferi & ";Data Source=" & xServidorCelferi & "\SQLEXPRESS"
        End If


        'VALORES POR DEFEITO
        If sAplicacao = "GIRL" Then
            sconnectionstring = sconnectionstringGirl
            sconnectionstringReport = sconnectionstringGirlReport
            xBdados = xBdadosGirl
            xServidor = xServidorGirl
        Else
            sconnectionstring = sconnectionstringCelfGest
            sconnectionstringReport = sconnectionstringCelfGestReport
            xBdados = xBdadosCelferi
            xServidor = xServidorCelferi
        End If



        ''SqlConnection cs = new SqlConnection(@"Data Source=(IP Address)\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=dbase;User ID=sa;Password=password");

        'Normal = "Data Source=(94.60.181.97)\SQLEXPRESS,3360;Network Library=DBMSSOCN;Initial Catalog=testes;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42"
        ''Normal = "Data Source=94.60.181.97,3360\SQLEXPRESS;Initial Catalog=testes;Persist Security Info=True;User ID=sa;Password=gRANDEeNIGMA50768721330Lc42"
        'xBdados = "testes"
        'xServidor = "94.60.181.97,3360"


        cn.ConnectionString = sconnectionstring

        If Math.Round(ClsDiscoRigido.EspacoLivre("C").ToString / 1024 / 1024 / 1024) < 10 Then
            MsgBox("DISCO C MUITO CHEIO!!", MsgBoxStyle.Information)
            EnviarEmail("DISCO C MUITO CHEIO!!", "", "")
        Else
            If Math.Round(ClsDiscoRigido.EspacoLivre("C").ToString / 1024 / 1024 / 1024) < 5 Then
                MsgBox("DISCO C MUITO CHEIO!!", MsgBoxStyle.Critical)
                Return False
            End If
        End If


        'If VerificaServidorActivo(xServidor) Then
        '    Return True
        'Else
        '    Return False
        'End If

        Return True

    End Function



End Class




