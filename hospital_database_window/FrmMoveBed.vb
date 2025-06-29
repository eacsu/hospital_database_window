Imports Microsoft.Data.SqlClient

Public Class FrmMoveBed
    Public Sub CmdFind_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles CmdFind.Click
        Dim sqlcmd As String
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim dt As DataTable = New DataTable()
        If TxtAdNum.Text = "" Then
            MsgBox("请输入住院号！", vbOKOnly, "提示")
            TxtAdNum.Focus()
            Exit Sub
        End If
        sqlcmd = "select Leave_Time from Patient where Patient_ID='" & TxtAdNum.Text & "'"
        dt = SQLQRY(sqlcmd, da)

        If dt.Rows.Count = 0 Then
            MsgBox("未找到该病人的详细信息！", vbOKOnly, "提示")
            TxtAdNum.Focus()
            Exit Sub
        End If
        If dt.Rows(0).Item("Leave_Time").ToString() <> "" Then
            MsgBox("病人已出院！", vbOKOnly, "提示")
            Exit Sub
        End If
        'If dt Is Nothing Then
        '    MsgBox("未找到该病人的详细信息！", vbOKOnly, "提示")
        '    TxtAdNum.Focus()
        '    Exit Sub
        'End If
        sqlcmd = "select Name,Consultation_Office,Bed_No from Patient where Patient_ID='" & TxtAdNum.Text & "'"
        dt = SQLQRY(sqlcmd, da)
        If dt.Rows.Count = 0 Then
            MsgBox("未找到该病人的详细信息！", vbOKOnly, "提示")
            TxtAdNum.Focus()
            Exit Sub
        End If
        If dt.Rows.Count = 0 Then
            MsgBox("查无结果！", vbOKOnly, "提示")
            TxtAdNum.Focus()
            Exit Sub
        End If
        'If dt Is Nothing Then
        '    MsgBox("未找到该病人的详细信息！", vbOKOnly, "提示")
        '    TxtAdNum.Focus()
        '    Exit Sub
        'End If
        TxtName.Text = dt.Rows(0).Item("Name").ToString()
        TxtOfi.Text = dt.Rows(0).Item("Consultation_Office").ToString()
        TxtCBedNo.Text = dt.Rows(0).Item("Bed_No").ToString()
    End Sub

    Public Sub CmdEdit_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        Dim sqlcmd As String
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim dt As DataTable = New DataTable()
        If TxtTBedNo.Text = "" Then
            MsgBox("请输入新的床位号！", vbOKOnly, "提示")
            TxtTBedNo.Focus()
            Exit Sub
        End If
        sqlcmd = "select Patient_ID from Patient where Consultation_Office='" & TxtOfi.Text & "'" & " and Bed_No='" & TxtTBedNo.Text & "'"
        dt = SQLQRY(sqlcmd, da)
        If dt.Rows.Count <> 0 Then
            MsgBox("床位已占用！", vbOKOnly, "提示")
            TxtTBedNo.Text = ""
            TxtTBedNo.Focus()
            Exit Sub
        End If
        sqlcmd = "update Patient set Bed_No='" & TxtTBedNo.Text & "'" & "where Patient_ID='" & TxtAdNum.Text & "'"
        SQLDML(sqlcmd)
        MsgBox("床位已修改！", vbOKOnly, "提示")
    End Sub

    Public Sub CmdExit_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class