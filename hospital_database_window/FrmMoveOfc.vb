Imports Microsoft.Data.SqlClient
Public Class FrmMoveOfc
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
        sqlcmd = "select Patient_Name,Consultation_Office from Patient where Patient_ID='" & TxtAdNum.Text & "'"
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
        TxtName.Text = dt.Rows(0).Item("Patient_Name").ToString()
        TxtCOffice.Text = dt.Rows(0).Item("Consultation_Office").ToString()
    End Sub

    Public Sub CmdEdit_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        Dim sqlcmd As String
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim dt As DataTable = New DataTable()
        If TxtNOffice.Text = "" Then
            MsgBox("请输入新的科室！", vbOKOnly, "提示")
            TxtNOffice.Focus()
            Exit Sub
        End If
        If TxtNBedNo.Text = "" Then
            MsgBox("请输入新的床位！", vbOKOnly, "提示")
            TxtNBedNo.Focus()
            Exit Sub
        End If
        If TxtNDoctor.Text = "" Then
            MsgBox("请输入新的主治医生！", vbOKOnly, "提示")
            TxtNDoctor.Focus()
            Exit Sub
        End If
        sqlcmd = "select Patient_ID from Patient where Consultation_Office='" & TxtNOffice.Text & "'" & "and Bed_No='" & TxtNBedNo.Text & "'"
        dt = SQLQRY(sqlcmd, da)
        If dt.Rows.Count <> 0 Then
            MsgBox("床位已占用！", vbOKOnly, "提示")
            TxtNBedNo.Text = ""
            TxtNBedNo.Focus()
            Exit Sub
        End If
        sqlcmd = "update Patient set Consultation_Office='" & TxtNOffice.Text & "'" & "where Patient_ID='" & TxtAdNum.Text & "'"
        SQLDML(sqlcmd)
        sqlcmd = "update Patient set Bed_No='" & TxtNBedNo.Text & "'" & "where Patient_ID='" & TxtAdNum.Text & "'"
        SQLDML(sqlcmd)
        sqlcmd = "update Patient set Charge_Doctor='" & TxtNDoctor.Text & "'" & "where Patient_ID='" & TxtAdNum.Text & "'"
        SQLDML(sqlcmd)
        MsgBox("科室已修改！", vbOKOnly, "提示")
    End Sub

    Public Sub CmdExit_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class