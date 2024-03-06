

Imports System.Data.SqlClient



Public Class frmEmpresa

    Private Sub EmpresasBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpresasBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.EmpresasBindingSource.EndEdit()
        Me.EmpresasTableAdapter.Update(Me.GirlDataSet.Empresas)

    End Sub

    Private Sub frmEmpresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New ClsSqlBDados

        'VAR1 - LIVRE
        'VAR2 - ENCOMENDAS
        'VAR3 - EXP
        'VAR4 - IMP


        Me.EmpresasTableAdapter.Fill(Me.GirlDataSet.Empresas)
        Me.lbVersao.Text = xVersao

        Sql = "SELECT ISNULL(Bloquear,'False') from EMPRESAS WHERE EMPRESAID='" & xEmp & "'"
        cbBloquear.Checked = db.GetDataValue(Sql)

        Sql = "SELECT ISNULL(Imprimir,'False') from EMPRESAS WHERE EMPRESAID='" & xEmp & "'"
        cbImp.Checked = db.GetDataValue(Sql)

        'Sql = "SELECT ISNULL(Var1,'0') from EMPRESAS WHERE EMPRESAID='" & xEmp & "'"
        'cbVar1.Checked = db.GetDataValue(Sql)

        Sql = "SELECT ISNULL(Var2,'0') from EMPRESAS WHERE EMPRESAID='" & xEmp & "'"
        cbVar2.Checked = db.GetDataValue(Sql)

        'Sql = "SELECT ISNULL(Var3,'0') from EMPRESAS WHERE EMPRESAID='" & xEmp & "'"
        'cbVar3.Checked = db.GetDataValue(Sql)

        'Sql = "SELECT ISNULL(Var4,'0') from EMPRESAS WHERE EMPRESAID='" & xEmp & "'"
        'cbVar4.Checked = db.GetDataValue(Sql)


    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Validate()
        Me.EmpresasBindingSource.EndEdit()
        Me.EmpresasTableAdapter.Update(Me.GirlDataSet.Empresas)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub cbBloquear_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBloquear.CheckedChanged

        Dim db As New ClsSqlBDados

        Try

            If cbBloquear.Checked = True Then
                Sql = "UPDATE EMPRESAS SET BLOQUEAR='TRUE' WHERE EMPRESAID='" & xEmp & "'"
                db.ExecuteData(Sql)
            Else
                Sql = "UPDATE EMPRESAS SET BLOQUEAR='FALSE' WHERE EMPRESAID='" & xEmp & "'"
                db.ExecuteData(Sql)
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "chbBloquear_CheckedChanged")
        Catch ex As Exception
            ErroVB(ex.Message, "chbBloquear_CheckedChanged")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try


    End Sub


    Private Sub cbImp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbImp.CheckedChanged
        Dim db As New ClsSqlBDados

        Try

            If cbImp.Checked = True Then
                Sql = "UPDATE EMPRESAS SET Imprimir='TRUE' WHERE EMPRESAID='" & xEmp & "'"
                db.ExecuteData(Sql)
            Else
                Sql = "UPDATE EMPRESAS SET Imprimir='FALSE' WHERE EMPRESAID='" & xEmp & "'"
                db.ExecuteData(Sql)
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "cbImp_CheckedChanged")
        Catch ex As Exception
            ErroVB(ex.Message, "cbImp_CheckedChanged")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub


    'Private Sub cbVar1_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbVar1.CheckedChanged
    '    Dim db As New ClsSqlBDados

    '    Try

    '        If cbVar1.Checked = True Then
    '            'Sql = "UPDATE EMPRESAS SET Var1='1' WHERE EMPRESAID='" & xEmp & "'"
    '            'db.ExecuteData(Sql)
    '        Else
    '            Sql = "UPDATE EMPRESAS SET Var1='0' WHERE EMPRESAID='" & xEmp & "'"
    '            db.ExecuteData(Sql)
    '        End If

    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "cbVar1_CheckedChanged")
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "cbVar1_CheckedChanged")
    '    Finally
    '        If db IsNot Nothing Then db.Dispose()
    '        db = Nothing
    '    End Try
    'End Sub

    Private Sub cbVar2_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbVar2.CheckedChanged
        Dim db As New ClsSqlBDados

        Try

            If cbVar2.Checked = True Then
                Sql = "UPDATE EMPRESAS SET Var2='1' WHERE EMPRESAID='" & xEmp & "'"
                db.ExecuteData(Sql)
            Else
                Sql = "UPDATE EMPRESAS SET Var2='0' WHERE EMPRESAID='" & xEmp & "'"
                db.ExecuteData(Sql)
            End If

        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, "cbVar2_CheckedChanged")
        Catch ex As Exception
            ErroVB(ex.Message, "cbVar2_CheckedChanged")
        Finally
            If db IsNot Nothing Then db.Dispose()
            db = Nothing
        End Try
    End Sub

    'Private Sub cbVar3_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbVar3.CheckedChanged
    '    Dim db As New ClsSqlBDados

    '    Try

    '        If cbVar3.Checked = True Then
    '            Sql = "UPDATE EMPRESAS SET Var3='1' WHERE EMPRESAID='" & xEmp & "'"
    '            db.ExecuteData(Sql)
    '        Else
    '            Sql = "UPDATE EMPRESAS SET Var3='0' WHERE EMPRESAID='" & xEmp & "'"
    '            db.ExecuteData(Sql)
    '        End If

    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "cbVar3_CheckedChanged")
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "cbVar3_CheckedChanged")
    '    Finally
    '        If db IsNot Nothing Then db.Dispose()
    '        db = Nothing
    '    End Try
    'End Sub

    'Private Sub cbVar4_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbVar4.CheckedChanged
    '    Dim db As New ClsSqlBDados

    '    Try

    '        If cbVar4.Checked = True Then
    '            Sql = "UPDATE EMPRESAS SET Var4='1' WHERE EMPRESAID='" & xEmp & "'"
    '            db.ExecuteData(Sql)
    '        Else
    '            Sql = "UPDATE EMPRESAS SET Var4='0' WHERE EMPRESAID='" & xEmp & "'"
    '            db.ExecuteData(Sql)
    '        End If

    '    Catch ex As SqlException
    '        ErroSQL(ex.Number, ex.Message, "cbVar4_CheckedChanged")
    '    Catch ex As Exception
    '        ErroVB(ex.Message, "cbVar4_CheckedChanged")
    '    Finally
    '        If db IsNot Nothing Then db.Dispose()
    '        db = Nothing
    '    End Try
    'End Sub




End Class